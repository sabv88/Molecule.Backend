using Molecule.Application.Common.Mappings;
using Molecule.Application.Interfaces;
using Molecule.Persistence;
using System.Reflection;
using Molecule.Application;
using System.Text.Json.Serialization;
using Notes.WebApi.Middleware;
using System.Xml.Linq;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddAutoMapper(config =>
            {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IMoleculeDbContext).Assembly));
            });

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
            });

            builder.Services.AddApplication();
            builder.Services.AddPersistence(builder.Configuration);
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });

            builder.Services.AddSwaggerGen(config =>
            {
                //var a = Assembly.GetExecutingAssembly().GetName().Name;
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //new XDocument().Save(xmlPath)
                config.IncludeXmlComments(xmlPath, true);
            });
            var app = builder.Build();
            app.UseSwagger();
            app.UseSwaggerUI(config =>
            {
                config.RoutePrefix = string.Empty;
                config.SwaggerEndpoint("swagger/v1/swagger.json", "Molecule API");
            });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.MapControllers();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.Run();
        }
    }
}