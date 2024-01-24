using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PoC.Domain.Services.Interfaces
{
    public interface IPetStoreService
    {
        Task<IEnumerable<PetOutput?>?> GetPets();
        Task<IEnumerable<PetOutput?>?> AddPets(AddPets command);
    }
}
