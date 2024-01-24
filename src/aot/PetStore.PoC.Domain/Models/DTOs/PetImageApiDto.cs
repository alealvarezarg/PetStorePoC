using PetStore.PoC.Domain.Models.Internal;
using PetStore.PoC.Domain.Models.Outputs;
using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.DTOs
{
    public class PetImageApiDto
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = string.Empty;
        [JsonPropertyName("url")]
        public string Url { get; set; } = string.Empty;
        [JsonPropertyName("width")]
        public decimal Width { get; set; }
        [JsonPropertyName("height")]
        public decimal Height { get; set; }

        public PetImageOutput ToPetImageOutput()
        {
            var petImageOutput = new PetImageOutput()
            {
                Id = this.Id,
                Url = this.Url,
                Width = this.Width,
                Height = this.Height,
            };

            return petImageOutput;
        }

        public PetImage ToPetImage()
        {
            var petImage = new PetImage()
            {
                Name = this.Id,
                Url = this.Url,
            };

            return petImage;
        }
    }
}
