using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetStore.PoC.Domain.Models
{
    public class Pet
    {
        public string Name { get; set; } = string.Empty;
        public IEnumerable<string> Tags { get; set; } = Enumerable.Empty<string>();
        public string Category { get; set; } = string.Empty;
        public double Price { get; set; }
        public PetImage? Image { get; set; }
    }
}
