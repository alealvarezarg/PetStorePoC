using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;

namespace PetStore.PoC.Domain.Services.Interfaces
{
    public interface IPetStoreService
    {
        Task<List<PetApiOutput>> GetPets();
        Task<List<PetImageOutput>> GetPetImages(int limit = 10);
        Task<SavePetsResponseDto> ProcessPets(ProcessPetRequest petRequest);
    }
}
