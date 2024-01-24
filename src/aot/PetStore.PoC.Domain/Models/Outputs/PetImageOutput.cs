using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Outputs
{
    public class PetImageOutput
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("width")]
        public decimal Width { get; set; }
        [JsonPropertyName("height")]
        public decimal Height { get; set; }
    }
}
