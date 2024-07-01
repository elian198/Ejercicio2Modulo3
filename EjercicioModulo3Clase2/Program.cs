using EjercicioModulo3Clase2.Repository;
using EjercicioModulo3Clase2.Services;
using EjercicioModulo3Clase2.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EjercicioModulo3Clase2
{
    public class Program
    {
        public static void Main( string[] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            String connection =  builder.Configuration.GetConnectionString("DefaulConnection");
            builder.Services.AddDbContext<ToDoListDBContext>(opt =>
            {
                opt.UseSqlServer(connection);
            });

            builder.Services.AddScoped<ITasksService, TasksService>();

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
        }
    }
}