using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Inputs
{
    public class ProcessPetRequest
    {
        [JsonPropertyName("pets")]
        public List<PetInputDto> Pets { get; set; } = new List<PetInputDto>();
    }
}
