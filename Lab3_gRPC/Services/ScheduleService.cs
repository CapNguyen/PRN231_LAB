using Grpc.Core;
using Lab3_gRPC.Models;
using Lab3_gRPC.Protos;
using Lab3_gRPC.Utils;
using Microsoft.EntityFrameworkCore;

namespace Lab3_gRPC.Services
{
    public class ScheduleService : ScheduleServices.ScheduleServicesBase
    {
        private LabDBContext db;

        public ScheduleService(LabDBContext db)
        {
            this.db = db;
        }

        public override Task<Attendances> AttendanceOfStudentInCourse(AttendanceOfStudentInCourseReq request, ServerCallContext context)
        {
            Student s = db.Students.FirstOrDefault(s => s.Id == request.StudentId);
            Course c = db.Courses.FirstOrDefault(c => c.Id == request.CourseId);
            if (s == null)
            {
                return null;
            }
            var attendances = db.StudentSchedules
                .Include(ss => ss.Schedule)
                    .ThenInclude(s => s.Course)
                .Include(ss => ss.Schedule)
                    .ThenInclude(s => s.Teacher)
                .Where(ss => ss.StudentId == request.StudentId && ss.Schedule.Course.Id == request.CourseId)
                .ToList();
            Attendances resp = new Attendances();
            resp.Attendances_.AddRange(attendances.Select(a => new Attendance
            {
                Id = a.ScheduleId,
                Slot = a.Schedule!.Slot,
                Datetime = gRPCConverter.toTimestamp(a.Schedule!.Date),
                CourseId = a.Schedule!.CourseId,
                CourseName = a.Schedule!.Course.CourseName,
                TeacherId = a.Schedule!.TeacherId,
                TeacherName = a.Schedule!.Teacher.Name,
                StudentId = a.StudentId,
                StudentName = a.Student.Name,
                Status = gRPCConverter.convertToProtoStatus(a.Status),
            }));
            return Task.FromResult(resp);
        }

        public override Task<Attendances> AttendancesInCourseBySlot(AttendancesInCourseBySlotReq request, ServerCallContext context)
        {
            var courseExists = db.Courses.Any(c => c.Id == request.CourseId);
            if (!courseExists)
            {
                return null;
            }

            var attendances = db.Schedules
                .Where(s => s.CourseId == request.CourseId && s.Slot == request.SlotId)
                .Include(s => s.Course)
                .Include(s => s.Teacher)
                .Include(s => s.StudentSchedules)
                    .ThenInclude(ss => ss.Student)
                .SelectMany(s => s.StudentSchedules.Select(ss => new Attendance
                {
                    Id = s.Id,
                    Slot = s.Slot,
                    Datetime = gRPCConverter.toTimestamp(s.Date),
                    CourseId = s.CourseId,
                    CourseName = s.Course.CourseName,
                    TeacherId = s.TeacherId,
                    TeacherName = s.Teacher.Name,
                    Status = gRPCConverter.convertToProtoStatus(ss.Status),
                    StudentId = ss.StudentId,
                    StudentName = ss.Student.Name
                }))
                .ToList();
            Attendances resp = new Attendances();
            resp.Attendances_.Add(attendances);
            return Task.FromResult(resp);
        }

        public override Task<TakeAttendanceResp> TakeAttendance(TakeAttendanceReqs request, ServerCallContext context)
        {
            TakeAttendanceResp resp = new TakeAttendanceResp();
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    foreach (var req in request.Request)
                    {
                        var student = db.Students
                            .FirstOrDefault(s => s.Id == req.StudentId);
                        var schedule = db.Schedules
                            .Include(s => s.Course)
                            .Include(s => s.Teacher)
                            .FirstOrDefault(s => s.Id == req.ScheduleId);
                        var ss = db.StudentSchedules
                            .Include(s => s.Student)
                            .Include(s => s.Schedule)
                                .ThenInclude(s => s.Course)
                            .Include(s => s.Schedule)
                                .ThenInclude(s => s.Teacher)
                            .FirstOrDefault(ss => (ss.ScheduleId == req.ScheduleId && ss.StudentId == req.StudentId));
                        if (ss != null)
                        {
                            ss.Status = gRPCConverter.convertToModelStatus(req.Status);
                        }
                        db.SaveChanges();
                    }
                    transaction.Commit();
                    resp.Status = "OK";
                    resp.Message = "Take attendance successfully!";
                }
                catch (Exception ex) {
                    transaction.Rollback();
                    resp.Status = "Failed";
                    resp.Message = ex.Message;
                }
            }
            return Task.FromResult(resp);
            
        }

    }
}
