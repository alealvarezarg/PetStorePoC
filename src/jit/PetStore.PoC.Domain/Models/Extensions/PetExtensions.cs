using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PoC.Domain.Models.Extensions
{
    public static class PetExtensions
    {
        public static Pet ToPetModel(this PetInput inputPet)
        {
            var outputPet = new Pet()
            {
                Name = inputPet.Name,
                Tags = inputPet.Tags,
                Category = inputPet.Category,
                Price = inputPet.Price,
            };
            return outputPet;
        }

        public static PetOutput ToPetOutput(this PetDto inputPet)
        {
            var outputPet = new PetOutput()
            {
                Id = inputPet.Id,
                Type = inputPet.Type,
                Price = inputPet.Price,
            };
            return outputPet;
        }
    }
}
