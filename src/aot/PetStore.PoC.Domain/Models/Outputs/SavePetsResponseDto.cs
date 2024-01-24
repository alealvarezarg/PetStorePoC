using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Outputs
{
    public class SavePetsResponseDto
    {
        [JsonPropertyName("pets")]
        public List<PetOutputDto> Pets { get; set; } = new List<PetOutputDto>();
    }
}
