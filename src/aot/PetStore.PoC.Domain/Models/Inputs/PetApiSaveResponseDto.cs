using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Inputs
{
    public class PetApiSaveResponseDto
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = string.Empty;
    }
}
