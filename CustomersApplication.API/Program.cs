using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CustomersApplication.API.Data;
using System.Configuration;
namespace CustomersApplication.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<CustomersApplicationAPIContext>(options =>
                options.UseSqlite(builder.Configuration.GetConnectionString("CustomersApplicationAPIContext") ?? throw new InvalidOperationException("Connection string 'CustomersApplicationAPIContext' not found.")));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            
            //Add CORS policy and allow any localhost port
            builder.Services.AddCors(options =>
            {
                var corsDomains = new List<string> { "localhost" };

                options.AddPolicy(name: "DevelopmentEnvironment",
                    builder =>
                    {
                        builder.SetIsOriginAllowed(origin => corsDomains.Any(a => new Uri(origin).Host.Equals(a, StringComparison.CurrentCultureIgnoreCase)))
                            .AllowAnyHeader()
                                .WithExposedHeaders(new string[] { "Content-Disposition", "Content-Length" })
                            .WithMethods("POST", "PUT", "GET", "DELETE")
                            .AllowCredentials()
                            ;
                    });
            });

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
