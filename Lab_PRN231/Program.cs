using Lab_PRN231.Models;
using Lab_PRN231.Mappers;
using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using Lab_PRN231.Services;
using Lab_PRN231.Services.IRepository;
using Lab_PRN231.DTOs;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
                    .AddOData(opt => opt.Select().Filter().Count().OrderBy().Expand().SetMaxTop(100).SkipToken()
                    .AddRouteComponents("lab", GetEdmModel())
                    )
                    ;
builder.Services.AddDbContext<LabDBContext>(opt =>
                    {
                        opt.UseSqlServer(builder.Configuration.GetConnectionString("MyCnn"));
                    });
builder.Services.AddAutoMapper(typeof(MyMapperProfile).Assembly);
builder.Services.AddTransient<ICourse, CourseServices>();
builder.Services.AddTransient<ISchedule, ScheduleServices>();
builder.Services.AddTransient<IStudent, StudentServices>();
builder.Services.AddTransient<ITeacher, TeacherServices>();
builder.Services.AddTransient<ISubject, SubjectServices>();
builder.Services.AddTransient<IStudentCourses, StudentCoursesService>();
builder.Services.AddTransient<IStudentSchedules, StudentSchedulesServices>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Course>("Courses");
    builder.EntitySet<Schedule>("Schedules");
    builder.EntitySet<Student>("Students");
    builder.EntitySet<Teacher>("Teachers");
    builder.EntitySet<Subject>("Subjects");
    //builder.EntitySet<StudentCourse>("StudentCourses");
    //builder.EntitySet<StudentSchedule>("StudentSchedules");
    return builder.GetEdmModel();
}
