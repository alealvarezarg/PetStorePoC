using Amazon.DynamoDBv2.DocumentModel;
using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;

namespace PetStore.PoC.Domain.Models.Internal
{
    public class Pet
    {
        public string Name { get; set; } = string.Empty;
        public List<Tag> Tags { get; set; } = new List<Tag>();
        public Category Category { get; set; }
        public double Price { get; set; }
        public List<PetImage> Images { get; set; } =  new List<PetImage>();

        public PetApiSaveRequestDto ToPetApiSaveRequestDto()
        {
            var request = new PetApiSaveRequestDto()
            {
                Type = this.Category.Value,
                Price = this.Price,
            };

            return request;
        }

        public PetOutputDto ToPetOutputDto()
        {
            var tags = this.Tags.Select(x => x.Value)
                .ToList();
            var images = this.Images.Select(x => x.Url)
                .ToList();

            var output = new PetOutputDto()
            {
                Name = this.Name,
                Tags = tags,
                Category = this.Category.Value,
                Price = this.Price,
                Images = images,
            };

            return output;
        }

        public Document ToDynamoDocument()
        {
            var tagsDocuments = this.Tags.Select(x => new Document()
            {
                ["Name"] = x.Name,
                ["Value"] = x.Value,
            }).ToList();
            var categoryDocument = new Document()
            {
                ["Name"] = this.Category.Name,
                ["Value"] = this.Category.Value,
            };
            var imageDocuments = this.Images.Select(x => new Document()
            {
                ["Name"] = x.Name,
                ["Url"] = x.Url,
            }).ToList();

            var document = new Document()
            {
                ["Id"] = Guid.NewGuid().ToString(),
                ["Name"] = this.Name,
                ["Tags"] = tagsDocuments,
                ["Category"] = categoryDocument,
                ["Price"] = this.Price,
                ["Images"] = imageDocuments,
            };

            return document;
        }
    }
}
