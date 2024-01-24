using PetStore.PoC.Domain.Models.Outputs;
using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.DTOs
{
    public class PetApiDto
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public double Price { get; set; }

        public PetApiOutput ToPetOutput()
        {
            var outputPet = new PetApiOutput()
            {
                Id = this.Id,
                Type = this.Type,
                Price = this.Price,
            };
            return outputPet;
        }
    }
}
