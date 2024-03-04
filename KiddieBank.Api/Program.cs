
using KiddieBank.Api.Repositories;
using KiddieBank.Api.Repositories.Interfaces;
using KiddieBank.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace KiddieBank.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var configuration = builder.Configuration;

            // Pass the configuration to the DbContext
            builder.Services.AddDbContext<KiddieBankContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("KiddieBank")));



            var app = builder.Build();
            app.UseCors(options => options
              .AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod()
              );


            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "KiddieBank API v1");
                });
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
