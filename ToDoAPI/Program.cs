using ToDoAPI.Data.Mapper;
using ToDoAPI.Repositories;
using ToDoAPI.Services;

namespace ToDoAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<TaskService, TaskService>();
            builder.Services.AddScoped<TaskRepository, TaskRepository>();
            builder.Services.AddScoped<TaskMapper, TaskMapper>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}