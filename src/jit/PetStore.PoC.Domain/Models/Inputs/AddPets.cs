using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PoC.Domain.Models.Inputs
{
    public class AddPets
    {
        public IEnumerable<PetInput> Pets { get; set; } = Enumerable.Empty<PetInput>();
    }
}
