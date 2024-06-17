using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class StudentSchedulesServices : IStudentSchedules
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;
        public StudentSchedulesServices(LabDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task GenerateScheduleForCourse(CourseDTO courseDTO)
        {
            var course = db.Courses
                .FirstOrDefault(s =>
                (s.CourseName == courseDTO.CourseName
                && s.StartDate == courseDTO.StartDate
                && s.SubjectCode == courseDTO.SubjectCode
                && s.TimeSlot == courseDTO.TimeSlot));
            var teacher = db.Teachers.FirstOrDefault(t => t.Id == courseDTO.TeacherId);
            var subject = db.Subjects.FirstOrDefault(s => s.Code == courseDTO.SubjectCode);
            if (subject == null || teacher == null)
            {
                return;
            }
            List<Schedule> schedules = new List<Schedule>();
            DateTime start = courseDTO.StartDate;
            var timeslot = DeserializeTimeSlot(courseDTO.TimeSlot);
            var count = 1;
            var t1 = timeslot[0];
            DateTime ts1 = start;
            DateTime ts2 = new DateTime();
            if (timeslot.Count > 1)
            {
                var t2 = timeslot[1];
                ts2 = GetNextDayOfWeek(GetDayOfWeek(t2.Day), start);
            }
            if (t1.Day > 0)
            {
                do
                {
                    var s1 = new Schedule()
                    {
                        Slot = count,
                        Date = ts1,
                        CourseId = course.Id,
                        Course = course,
                        TeacherId = teacher.Id,
                        Teacher = teacher,
                    };
                    schedules.Add(s1);
                    count += 1;
                    ts1 = ts1.AddDays(7);

                    if (timeslot.Count > 1)
                    {
                        var t2 = timeslot[1];
                        if (t2.Day > 0)
                        {
                            var s2 = new Schedule()
                            {
                                Slot = count,
                                Date = ts2,
                                CourseId = course.Id,
                                Course = course,
                                TeacherId = teacher.Id,
                                Teacher = teacher
                            };
                            schedules.Add(s2);
                            count += 1;
                            ts2 = ts2.AddDays(7);
                        }
                    }
                }
                while (count <= subject.NumberOfSlot);
            }
           
            await db.Schedules.AddRangeAsync(schedules);
            await db.SaveChangesAsync();
            GenerateStudentSchedule(course.Id, schedules);
        }
        public void GenerateStudentSchedule(int courseId, List<Schedule> schedules)
        {
            Course c = db.Courses.FirstOrDefault(c => c.Id == courseId);
            var students = db.StudentCourses
                .Where(sc => sc.CourseId == courseId)
                .Include(sc => sc.Student)
                .Select(sc => sc.Student)
                .ToList();
            foreach (Schedule schedule in schedules)
            {
                foreach (Student student in students)
                {
                    db.StudentSchedules.Add(new StudentSchedule(student.Id, student, schedule.Id, schedule, Status.NotYet));
                }
            }
            db.SaveChanges();
        }
        public List<TimeSlotResponse> DeserializeTimeSlot(string timeslot)
        {
            List<TimeSlotResponse> result = new List<TimeSlotResponse>();
            string t0 = timeslot[0].ToString();
            string t1 = timeslot[1].ToString();
            string t2 = timeslot[2].ToString();
            if (!"A".Equals(t0) && !"P".Equals(t0))
            {
                result = null;
            }
            if ("A".Equals(t0))
            {
                TimeSlotResponse res1 = new TimeSlotResponse(Convert.ToInt32(t1), 1);
                TimeSlotResponse res2 = new TimeSlotResponse(Convert.ToInt32(t2), 2);
                result.Add(res1);
                result.Add(res2);
            }
            if ("P".Equals(t0))
            {
                TimeSlotResponse res1 = new TimeSlotResponse(Convert.ToInt32(t1), 3);
                TimeSlotResponse res2 = new TimeSlotResponse(Convert.ToInt32(t2), 4);
                result.Add(res1);
                result.Add(res2);
            }

            result = result.OrderBy(r => r.Day).Where(r => r.Day != 0).ToList();
            return result;
        }
        public DayOfWeek GetDayOfWeek(int dayValue)
        {
            switch (dayValue)
            {
                case 2:
                    return DayOfWeek.Monday;
                case 3:
                    return DayOfWeek.Tuesday;
                case 4:
                    return DayOfWeek.Wednesday;
                case 5:
                    return DayOfWeek.Thursday;
                case 6:
                    return DayOfWeek.Friday;
                case 7:
                    return DayOfWeek.Saturday;
                case 8:
                    return DayOfWeek.Sunday;
                default:
                    throw new Exception("Invalid dayValue");
            }
        }
        public DateTime GetNextDayOfWeek(DayOfWeek targetDay, DateTime startDate)
        {
            int daysToAdd = ((int)targetDay - (int)startDate.DayOfWeek + 7) % 7;

            if (daysToAdd == 0)
            {
                daysToAdd = 7;
            }

            return startDate.AddDays(daysToAdd);
        }

    }
    public class TimeSlotResponse
    {
        public int Day { get; set; }
        public int Slot { get; set; }

        public TimeSlotResponse(int day, int slot)
        {
            Day = day;
            Slot = slot;
        }
    }
}
