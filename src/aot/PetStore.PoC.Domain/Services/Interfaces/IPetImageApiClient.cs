using PetStore.PoC.Domain.Models.DTOs;

namespace PetStore.PoC.Domain.Services.Interfaces
{
    public interface IPetImageApiClient
    {
        Task<List<PetImageApiDto>> GetPetImages(int limit = 10);
    }
}
