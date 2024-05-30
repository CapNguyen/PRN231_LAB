using AutoMapper;
using Lab_AttendanceManagement.Models;
using Lab_PRN231.DTOs;

namespace Lab_PRN231.Mappers
{
    public class MyMapperProfile : Profile
    {
        public MyMapperProfile()
        {
            CreateMap<Course, CourseDTO>()
                .ForMember(dest => dest.SubjectCode, opt =>
                    opt.MapFrom(src => src.Subject!.Code));
            CreateMap<Schedule, ScheduleDTO>()
                .ForMember(dest => dest.CourseName, opt =>
                    opt.MapFrom(src => src.Course!.CourseName))
                .ForMember(dest => dest.TeacherName, opt =>
                    opt.MapFrom(src => src.Teacher!.Name));
            CreateMap<Student, StudentDTO>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<Subject, SubjectDTO>();

        }
    }
}
