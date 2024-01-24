using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Services.Interfaces;

namespace PetStore.PoC.WebApi.Jit.Extensions
{
    public static class WebApplicationExtensions
    {
        public static void MapPetEndpoints(this WebApplication app)
        {
            //var api = app.MapGroup("/");
            //api.MapGet("/", async (IPetStoreService service) => await service.GetPets());
            //api.MapPost("/", async (IPetStoreService service, AddPets command) => await service.AddPets(command));

            app.MapGet("/pets", async (IPetStoreService service) => await service.GetPets());
            app.MapPost("/pets", async (IPetStoreService service, AddPets command) => await service.AddPets(command));
        }
    }
}
