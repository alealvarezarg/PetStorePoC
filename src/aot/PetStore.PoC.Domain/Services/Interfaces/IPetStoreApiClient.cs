using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models.Inputs;

namespace PetStore.PoC.Domain.Services.Interfaces
{
    public interface IPetStoreApiClient
    {
        Task<List<PetApiDto?>?> GetPets();
        Task<PetApiSaveResponseDto> SavePets(PetApiSaveRequestDto request);
    }
}
