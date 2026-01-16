using GestaoDePaciente.Repository;
using GestaoDePaciente.Repository.Interfaces;
using GestaoDePaciente.Services;
using GestaoDePaciente.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GestaoDePaciente.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>
                (
                    x => x.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.GetName().Name)
                ));

            services.AddHttpClient<IViaCepService, ViaCepService>();
            services.AddScoped<IPacienteService, PacienteService>();
            services.AddScoped<IPacienteRepository, PacienteRepository>();

            return services;
        }
    }
}