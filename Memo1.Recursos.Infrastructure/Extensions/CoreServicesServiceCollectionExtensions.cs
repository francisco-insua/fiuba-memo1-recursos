using Memo1.Recursos.Application.Contracts.Services;
using Memo1.Recursos.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Memo1.Recursos.Infrastructure.Extensions;

public static class CoreServicesServiceCollectionExtensions
{
    public static IServiceCollection AddCoreServices(this IServiceCollection services)
    {
        // Services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICargaHorariaService, CargaHorariaService>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        return services;
    }
}