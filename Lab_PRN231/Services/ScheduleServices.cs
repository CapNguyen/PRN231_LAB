using AutoMapper;
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
            var schedules = await db.Schedules.ToListAsync();
            var dtos = mapper.Map<List<ScheduleDTO>>(schedules);
            return dtos;
        }
    }
}
