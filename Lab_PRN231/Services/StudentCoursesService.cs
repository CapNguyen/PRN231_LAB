using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class StudentCoursesService : IStudentCourses
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public StudentCoursesService(LabDBContext db, IMapper mapper)
        {
            this.db = db;
            this.mapper = mapper;
        }

        public async Task AddStudentsToCourse(int courseId, List<int> studentId)
        {
            Course c = db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (c != null)
            {
                foreach (int id in studentId)
                {
                    Student s = db.Students.FirstOrDefault(s => s.Id == id);
                    if (s != null)
                    {
                        await db.AddAsync(new StudentCourse(id, s, courseId, c));
                        foreach (Schedule schedule in c.Schedules)
                        {
                            await db.AddAsync(new StudentSchedule(s.Id, s, schedule.Id, schedule, Status.NotYet));
                        }
                    }
                }
            }
            await db.SaveChangesAsync();
        }

        public async Task DeletetStudentFromCourse(int courseId, List<int> studentId)
        {
            Course c = db.Courses.FirstOrDefault(c => c.Id == courseId);
            if (c != null)
            {
                foreach (int id in studentId)
                {
                    Student s = db.Students.FirstOrDefault(s => s.Id == id);
                    if (s != null)
                    {
                        StudentCourse sc = db.StudentCourses.FirstOrDefault(sc => (sc.StudentId == id && sc.CourseId == courseId));
                        db.Remove(sc);
                    }
                }
            }
            await db.SaveChangesAsync();
        }

        public async Task<List<StudentDTO>> StudentInCourse(int courseId)
        {
            List<Student?> students = await db.StudentCourses
                                    .Where(sc => sc.CourseId == courseId)
                                    .Select(sc => sc.Student)
                                    .ToListAsync();
            var dtos = mapper.Map<List<StudentDTO>>(students);
            return dtos;
        }
    }
}
