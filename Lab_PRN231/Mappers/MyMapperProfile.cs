using AutoMapper;
using Lab_PRN231.Models;
using Lab_PRN231.DTOs;

namespace Lab_PRN231.Mappers
{
    public class MyMapperProfile : Profile
    {
        public MyMapperProfile()
        {
            CreateMap<Course, CourseDTO>()
                //.ForMember(dest => dest.SubjectCode, opt =>
                //    opt.MapFrom(src => src.Subject!.Code));
                //.ForMember(dest => dest.Students, opt =>
                //    opt.MapFrom(src => src.StudentCourses!.Select(sc => sc.Student)));
                .ForMember(dest => dest.TeacherId, opt => opt.Ignore())
                ;
            CreateMap<Schedule, ScheduleDTO>()
                .ForMember(dest => dest.CourseName, opt =>
                    opt.MapFrom(src => src.Course!.CourseName))
                .ForMember(dest => dest.TeacherName, opt =>
                    opt.MapFrom(src => src.Teacher!.Name));
            CreateMap<Student, StudentDTO>();
            CreateMap<Teacher, TeacherDTO>();
            CreateMap<Subject, SubjectDTO>();

            CreateMap<CourseDTO, Course>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Subject, opt =>
                    opt.MapFrom(src => new Subject { Code = src.SubjectCode }));
            CreateMap<ScheduleDTO, Schedule>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Course, opt =>
                    opt.MapFrom(src => new Course { Id = (int)src.CourseId }))
                .ForMember(dest => dest.Teacher, opt =>
                    opt.MapFrom(src => new Teacher { Id = (int)src.TeacherId }));
            CreateMap<StudentDTO, Student>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<TeacherDTO, Teacher>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
            CreateMap<SubjectDTO, Subject>()
                .ForMember(dest => dest.Code, opt => opt.Ignore());
        }
    }
}
