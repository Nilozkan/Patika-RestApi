
using RestApi.Services;

namespace RestApi.Extensions
{
    public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddCustomServices(this IServiceCollection services)
    {
        services.AddSingleton<ICarService, FakeCarService>();
        return services;
    }
}
}