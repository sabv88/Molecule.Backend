using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Molecule.Application.Interfaces;

namespace Molecule.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection
           services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DbConnection");
            services.AddDbContext<MoleculeDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
            services.AddScoped<IMoleculeDbContext>(provider =>
                provider.GetService<MoleculeDbContext>());
            return services;
        }
    }
}
