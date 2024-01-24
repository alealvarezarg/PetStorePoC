using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Outputs
{
    public class PetOutputDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; } = new List<string>();
        [JsonPropertyName("category")]
        public string Category { get; set; }
        [JsonPropertyName("price")]
        public double Price { get; set; }
        [JsonPropertyName("images")]
        public List<string> Images { get; set; } = new List<string>();
    }
}
