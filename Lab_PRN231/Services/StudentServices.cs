using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class StudentServices : IStudent
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public StudentServices(IMapper mapper, LabDBContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }
        public async Task<List<StudentDTO>> All()
        {
            var students = await db.Students.ToListAsync();
            var dtos = mapper.Map<List<StudentDTO>>(students);
            return dtos;
        }
        public async Task<StudentDTO> GetStudent(int id)
        {
            var student = await db.Students.FindAsync(id);
            StudentDTO dto = null;
            if (student != null)
            {
                dto = mapper.Map<StudentDTO>(student);
            }
            else
            {
                Console.WriteLine("Not found");
            }
            return dto;
        }

        public async Task AddStudent(StudentDTO studentDTO)
        {
            Student s = mapper.Map<Student>(studentDTO);
            db.Students.Add(s);
            await db.SaveChangesAsync();
        }


        public async Task DeleteStudent(int id)
        {
            Student s = await db.Students.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            db.Students.Remove(s);
            await db.SaveChangesAsync();
        }


        public async Task UpdateStudent(int id, StudentDTO studentDTO)
        {
            Student s = await db.Students.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            s = mapper.Map(studentDTO, s);
            await db.SaveChangesAsync();
        }
    }
}
