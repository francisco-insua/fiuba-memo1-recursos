using Memo1.Recursos.Application.Contracts.Repositories;
using Memo1.Recursos.Infrastructure.Persistence;
using Memo1.Recursos.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Memo1.Recursos.Infrastructure.Extensions;

public static class DatabaseServiceCollectionExtensions
{
    public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("Postgres");

        services.AddDbContext<RecursosDbContext>(
            options => options.UseNpgsql(connectionString));
        
            
        // Repositories
        services.AddScoped<ICargaHorariaRepository, CargaHorariaRepository>();

        return services;
    }
}