using Molecule.Application.Common.Mappings;
using Molecule.Application.Interfaces;
using Molecule.Persistence;
using System.Reflection;
using Molecule.Application;
using System.Text.Json.Serialization;

namespace Molecule.Backend
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
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                try
                {
                    var serviceProvider = scope.ServiceProvider;

                    var context = serviceProvider.GetRequiredService<MoleculeDbContext>();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {

                }
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.MapGet("/", () => "Hello World!");

        }
    }
}