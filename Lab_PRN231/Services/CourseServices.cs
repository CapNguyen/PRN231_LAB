using AutoMapper;
using Lab_PRN231.Models;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class CourseServices : ICourse
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public CourseServices(IMapper mapper, LabDBContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public async Task<List<CourseDTO>> All()
        {
            var courses = await db.Courses.ToListAsync();
            var dtos = mapper.Map<List<CourseDTO>>(courses);
            return dtos;
        }

        public async Task<CourseDTO> GetCourse(int id)
        {
            var Course = await db.Courses.FindAsync(id);
            CourseDTO dto = null;
            if (Course != null)
            {
                dto = mapper.Map<CourseDTO>(Course);
            }
            else
            {
                Console.WriteLine("Not found");
            }
            return dto;
        }

        public async Task AddCourse(CourseDTO courseDTO)
        {
            Course course = mapper.Map<Course>(courseDTO);
            if (string.IsNullOrEmpty(courseDTO.SubjectCode))
            {
                course.Subject = null;
            }
            else
            {
                var subject = await db.Subjects.FirstOrDefaultAsync(s => s.Code == courseDTO.SubjectCode);
                course.Subject = (subject == null) ? null : subject;
            }
            await db.Courses.AddAsync(course);
            await db.SaveChangesAsync();
        }


        public async Task DeleteCourse(int id)
        {
            Course s = await db.Courses.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            db.Courses.Remove(s);
            await db.SaveChangesAsync();
        }


        public async Task UpdateCourse(int id, CourseDTO CourseDTO)
        {
            Course s = await db.Courses.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            s = mapper.Map(CourseDTO, s);
            await db.SaveChangesAsync();
        }

        public async Task<List<CourseDTO>> GetAll()
        {
            var courses = await db.Courses
                .Join(db.StudentCourses, c => c.Id, sc => sc.CourseId, (c, sc) => new { c, sc })
                .Join(db.Students, sc => sc.c.Id, s => s.Id, (c, s) => new { c, s })
                .ToListAsync();
            var dtos = mapper.Map<List<CourseDTO>>(courses);
            return dtos;
        }
    }
}
