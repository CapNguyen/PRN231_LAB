using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;

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
                && s.EndDate == courseDTO.EndDate
                && s.SubjectCode == courseDTO.SubjectCode
                && s.TimeSlot == courseDTO.TimeSlot));
            var teacher = db.Teachers.FirstOrDefault(t => t.Id == courseDTO.TeacherId);
            var subject = db.Subjects.FirstOrDefault(s => s.Code == courseDTO.SubjectCode);
            if (subject == null)
            {
                return;
            }
            var timeslot = DeserializeTimeSlot(courseDTO.TimeSlot);
            var t1 = timeslot[0];
            var t2 = timeslot[1];
            List<Schedule> schedules = new List<Schedule>();
            int t1_count = 1;
            int t2_count = 2;
            DateTime start = courseDTO.StartDate;
            DateTime ts1 = GetNextDayOfWeek(GetDayOfWeek(t1.Day), start);
            do
            {
                var s = new Schedule()
                {
                    Slot = t1_count,
                    Date = ts1,
                    CourseId = course.Id,
                    Course = course,
                    TeacherId = teacher.Id,
                    Teacher = teacher
                };
                schedules.Add(s);
                t1_count += 2;
                ts1.AddDays(7);
            }
            while (t1_count <= subject.NumberOfSlot);
            DateTime ts2 = GetNextDayOfWeek(GetDayOfWeek(t2.Day), start);
            do
            {
                var s = new Schedule()
                {
                    Slot = t2_count,
                    Date = ts2,
                    CourseId = course.Id,
                    Course = course,
                    TeacherId = teacher.Id,
                    Teacher = teacher
                };
                schedules.Add(s);
                t2_count += 2;
                ts2.AddDays(7);
            }
            while (t2_count <= subject.NumberOfSlot);
            await db.Schedules.AddRangeAsync(schedules);
            await db.SaveChangesAsync();    
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
