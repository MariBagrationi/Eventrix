using Eventrix.API.Infrastructure.Extensions;
using Eventrix.App;
using MediatR;
using Eventrix.Persistence.Connections;
using Eventrix.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Eventrix.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<EventrixContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString(nameof(ConnectionString.DefaultConnection))));
            builder.Services.AddServices();

            builder.Services.AddMediatR(Assembly.GetAssembly(typeof(DependencyMarker))!);

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
