using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PoC.Domain.Services.Interfaces
{
    public interface IPetStoreApiClient
    {
        Task<PetDto?> CreatePet(Pet pet);
        Task<IEnumerable<PetDto?>?> GetPets();
    }
}
