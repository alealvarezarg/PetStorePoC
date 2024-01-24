using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;
using PetStore.PoC.Domain.Services.Interfaces;
using PetStore.PoC.Domain.Models.Extensions;

namespace PetStore.PoC.Domain.Services
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetStoreApiClient _petStoreApiClient;

        public PetStoreService(IPetStoreApiClient petStoreApiClient)
        {
            _petStoreApiClient = petStoreApiClient;
        }

        public async Task<IEnumerable<PetOutput?>?> AddPets(AddPets command)
        {
            var tasks = command.Pets
                .Select(x => _petStoreApiClient.CreatePet(x.ToPetModel()));

            try
            {
                await Task.WhenAll(tasks);

                var petOutputs = tasks.Where(x => x.IsCompletedSuccessfully)
                    .Select(x => x.Result?.ToPetOutput());

                return petOutputs;
            }
            catch (Exception)
            {
            }

            return null;
        }

        public async Task<IEnumerable<PetOutput?>?> GetPets()
        {
            var petDtos = await _petStoreApiClient.GetPets();

            var petOutputs = petDtos?.Select(x => x?.ToPetOutput());
            return petOutputs;
        }
    }
}
