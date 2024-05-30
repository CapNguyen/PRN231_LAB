using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class TeacherServices : ITeacher
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public TeacherServices(IMapper mapper, LabDBContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<List<TeacherDTO>> All()
        {
            var teachers = await db.Teachers.ToListAsync();
            var dtos = mapper.Map<List<TeacherDTO>>(teachers);
            return dtos;
        }
        public async Task<TeacherDTO> GetTeacher(int id)
        {
            var Teacher = await db.Teachers.FindAsync(id);
            TeacherDTO dto = null;
            if (Teacher != null)
            {
                dto = mapper.Map<TeacherDTO>(Teacher);
            }
            else
            {
                Console.WriteLine("Not found");
            }
            return dto;
        }

        public async Task AddTeacher(TeacherDTO TeacherDTO)
        {
            Teacher s = mapper.Map<Teacher>(TeacherDTO);
            db.Teachers.Add(s);
            await db.SaveChangesAsync();
        }


        public async Task DeleteTeacher(int id)
        {
            Teacher s = await db.Teachers.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            db.Teachers.Remove(s);
            await db.SaveChangesAsync();
        }


        public async Task UpdateTeacher(int id, TeacherDTO TeacherDTO)
        {
            Teacher s = await db.Teachers.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            s = mapper.Map(TeacherDTO, s);
            await db.SaveChangesAsync();
        }
    }
}
