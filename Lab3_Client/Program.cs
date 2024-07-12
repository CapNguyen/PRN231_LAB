using Grpc.Net.Client;
using Lab3_Client.Services;
using Lab3_Client.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient(provider =>
{
    var channel = GrpcChannel.ForAddress("http://localhost:5294");
    return channel;
});
builder.Services.AddTransient<ICourse, CourseService>();
builder.Services.AddTransient<ISchedule, ScheduleService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
