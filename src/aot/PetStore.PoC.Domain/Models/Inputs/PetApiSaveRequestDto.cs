using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Inputs
{
    public class PetApiSaveRequestDto
    {
        [JsonPropertyName("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
