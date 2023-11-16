
using Cooperchip.ADOnetWithgenerics.API.Configurations;
using Cooperchip.ADOnetWithgenerics.API.Infra;

namespace Cooperchip.ADOnetWithgenerics.API
{
    public class Program
    {
        public static void Main(string [] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            /*
             S - Single Resposability Principle
             O - Open Closed Principle
             L
             I - Interface Segregation Principle
             D
             */

            // Add services to the container.

            builder.Services.AddControllers();

            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            builder.Services.Configure<ConnectionStringOptions>(builder.Configuration.GetSection("ConnectionStrings"));

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerConfiguration();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerConfiguration();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}