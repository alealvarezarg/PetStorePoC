using PetStore.PoC.Domain.Services.Interfaces;
using PetStore.PoC.Domain.Services;

namespace PetStore.PoC.WebApi.Jit.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddProjectDependencies(this IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddScoped<IPetStoreApiClient, PetStoreApiClient>();
            services.AddScoped<IPetStoreService, PetStoreService>();
        }
    }
}
