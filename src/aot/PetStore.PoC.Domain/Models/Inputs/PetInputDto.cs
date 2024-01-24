using PetStore.PoC.Domain.Models.Internal;

namespace PetStore.PoC.Domain.Models.Inputs
{
    public class PetInputDto
    {
        public string Name { get; set; } = string.Empty;
        public List<string> Tags { get; set; } = new List<string>();
        public string Category { get; set; } = string.Empty;
        public double Price { get; set; }

        public Pet ToPet()
        {
            var category = new Category()
            {
                Name = this.Category,
                Value = this.Category,
            };
            var tags = this.Tags.Select(x => new Tag()
            {
                Name = x,
                Value = x,
            }).ToList();

            var pet = new Pet()
            {
                Name = this.Name,
                Tags = tags,
                Category = category,
                Price = this.Price,
            };

            return pet;
        }
    }
}
