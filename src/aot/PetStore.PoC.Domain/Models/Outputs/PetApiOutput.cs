using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Outputs
{
    public class PetApiOutput
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName ("type")]
        public string Type { get; set; } = string.Empty;
        [JsonPropertyName("price")]
        public double Price { get; set; }
    }
}
