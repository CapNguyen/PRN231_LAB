using AutoMapper;
using Lab_PRN231.DTOs;
using Lab_PRN231.Models;
using Lab_PRN231.Services.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab_PRN231.Services
{
    public class SubjectServices : ISubject
    {
        private readonly LabDBContext db;
        private readonly IMapper mapper;

        public SubjectServices(IMapper mapper, LabDBContext db)
        {
            this.mapper = mapper;
            this.db = db;
        }

        public async Task<List<SubjectDTO>> All()
        {
            var subjects = await db.Subjects.ToListAsync();
            var dtos = mapper.Map<List<SubjectDTO>>(subjects);
            return dtos;


        }
        public async Task<SubjectDTO> GetSubject(string id)
        {
            var Subject = await db.Subjects.FindAsync(id);
            SubjectDTO dto = null;
            if (Subject != null)
            {
                dto = mapper.Map<SubjectDTO>(Subject);
            }
            else
            {
                Console.WriteLine("Not found");
            }
            return dto;
        }

        public async Task AddSubject(SubjectDTO SubjectDTO)
        {
            Subject s = mapper.Map<Subject>(SubjectDTO);
            s.Code = SubjectDTO.Code;
            await db.Subjects.AddAsync(s);
            await db.SaveChangesAsync();
        }


        public async Task DeleteSubject(string id)
        {
            Subject s = await db.Subjects.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            db.Subjects.Remove(s);
            await db.SaveChangesAsync();
        }


        public async Task UpdateSubject(string id, SubjectDTO SubjectDTO)
        {
            Subject s = await db.Subjects.FindAsync(id);
            if (s == null)
            {
                Console.WriteLine("Not found");
            }
            s = mapper.Map(SubjectDTO, s);
            await db.SaveChangesAsync();
        }
    }
}
