using AutoMapper;
using Lab_PRN231.Controllers;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class ScheduleServices : ISchedule
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public ScheduleServices(IMapper mapper, LabDBContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<List<ScheduleDTO>> All()
        {
            var schedules = await db.Schedules.Include(s => s.Teacher).Include(s => s.Course).ToListAsync();
            var dtos = mapper.Map<List<ScheduleDTO>>(schedules);
            return dtos;
        }
        public async Task<List<ScheduleDTO>> AttendanceOfStudent(int studentId)
        {
            Student s = db.Students.FirstOrDefault(s => s.Id == studentId);
            if (s == null)
            {
                return null;
            }
            var attendances = await db.StudentSchedules
                .Include(ss => ss.Schedule)
                    .ThenInclude(s => s.Course)
                .Include(ss => ss.Schedule)
                    .ThenInclude(s => s.Teacher)
                .Where(ss => ss.StudentId == studentId)
                .ToListAsync();

            var dtos = mapper.Map<List<ScheduleDTO>>(attendances);
            return dtos;
        }

        public async Task<List<ScheduleDTO>> AttendancesInCourse(int courseId)
        {
            Course c = db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (c == null)
            {
                return null;
            }
            var attendances = await db.Schedules
                .Where(s => s.CourseId == courseId)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.StudentSchedules)
                    .ThenInclude(ss => ss.Student)
                .Distinct()
                .ToListAsync();
            var dtos = mapper.Map<List<ScheduleDTO>>(attendances);
            return dtos;
        }

        public async Task<List<ScheduleDTO>> AttendancesInCourseBySlot(int courseId, int slot)
        {
            var courseExists = await db.Courses.AnyAsync(c => c.Id == courseId);
            if (!courseExists)
            {
                return null;
            }

            var attendances = await db.Schedules
                .Where(s => s.CourseId == courseId && s.Slot == slot)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.StudentSchedules)
                    .ThenInclude(ss => ss.Student)
                .SelectMany(s => s.StudentSchedules.Select(ss => new ScheduleDTO
                {
                    Id = s.Id,
                    Slot = s.Slot,
                    Date = s.Date,
                    CourseId = s.CourseId,
                    CourseName = s.Course.CourseName,
                    TeacherId = s.TeacherId,
                    TeacherName = s.Teacher.Name,
                    Status = ss.Status,
                    StudentId = ss.StudentId,
                    StudentName = ss.Student.Name
                }))
                .ToListAsync();

            return attendances;


        }

        public async Task<ScheduleDTO> TakeAttendance(int studentId, int scheduleId, Status status)
        {
            Student student = db.Students
                .FirstOrDefault(s => s.Id == studentId);
            Schedule schedule = db.Schedules
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .FirstOrDefault(s => s.Id == scheduleId);
            StudentSchedule ss = db.StudentSchedules
                .Include(s => s.Student)
                .Include(s => s.Schedule)
                    .ThenInclude(s => s.Course)
                .Include(s => s.Schedule)
                    .ThenInclude(s => s.Teacher)
                .FirstOrDefault(ss => (ss.ScheduleId == scheduleId && ss.StudentId == studentId));
            if (ss != null)
            {
                if (status == Status.NotYet)
                {
                    ss = new StudentSchedule(studentId, student, scheduleId, schedule, status);
                    await db.AddAsync(ss);
                }
                else
                {
                    ss.Status = status;
                    await db.SaveChangesAsync();
                }
            }
            var dto = new ScheduleDTO()
            {
                Id = schedule.Id,
                Slot = schedule.Slot,
                Date = schedule.Date,
                CourseId = schedule.CourseId,
                CourseName = schedule.Course.CourseName,
                TeacherId = schedule.TeacherId,
                TeacherName = schedule.Teacher.Name,
                Status = ss.Status
            };
            return dto;
        }
        public async Task<List<ScheduleDTO>> TakeAttendances(List<TakeAttendanceRequest> requests)
        {
            var dtos = new List<ScheduleDTO>();
            foreach (var request in requests)
            {
                Student student = await db.Students
                    .FirstOrDefaultAsync(s => s.Id == request.StudentId);
                Schedule schedule = await db.Schedules
                    .Include(s => s.Course)
                    .Include(s => s.Teacher)
                    .FirstOrDefaultAsync(s => s.Id == request.ScheduleId);
                StudentSchedule ss = await db.StudentSchedules
                    .Include(s => s.Student)
                    .Include(s => s.Schedule)
                        .ThenInclude(s => s.Course)
                    .Include(s => s.Schedule)
                        .ThenInclude(s => s.Teacher)
                    .FirstOrDefaultAsync(ss => (ss.ScheduleId == request.ScheduleId && ss.StudentId == request.StudentId));
                if (ss != null)
                {
                        ss.Status = request.Status;
                }
                await db.SaveChangesAsync();
                var dto = new ScheduleDTO()
                {
                    Id = schedule.Id,
                    Slot = schedule.Slot,
                    Date = schedule.Date,
                    CourseId = schedule.CourseId,
                    CourseName = schedule.Course.CourseName,
                    TeacherId = schedule.TeacherId,
                    TeacherName = schedule.Teacher.Name,
                    StudentId = ss.StudentId,
                    StudentName = ss.Student.Name,
                    Status = ss.Status

                };
                dtos.Add(dto);
            }
            return dtos;
        }
    }
}
