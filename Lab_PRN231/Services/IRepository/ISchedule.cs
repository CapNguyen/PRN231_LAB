using Lab_PRN231.DTOs;

namespace Lab_PRN231.Services.IRepository
{
    public interface ISchedule
    {
        Task<List<ScheduleDTO>> All();

    }
}
