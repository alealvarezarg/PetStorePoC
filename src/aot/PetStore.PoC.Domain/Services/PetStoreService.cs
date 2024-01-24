using PetStore.PoC.Domain.Models.Outputs;
using PetStore.PoC.Domain.Services.Interfaces;
using Microsoft.Extensions.Logging;
using PetStore.PoC.Domain.Models.Inputs;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2;
using PetStore.PoC.Domain.Constants;

namespace PetStore.PoC.Domain.Services
{
    public class PetStoreService : IPetStoreService
    {
        private readonly IPetStoreApiClient _petStoreApiClient;
        private readonly IPetImageApiClient _petImageApiClient;
        private readonly IAmazonDynamoDB _dynamoDbClient;
        private readonly ILogger _logger;

        public PetStoreService(IPetStoreApiClient petStoreApiClient
            , IPetImageApiClient petImageApiClient
            , IAmazonDynamoDB dynamoDbClient
            , ILogger<PetStoreService> logger)
        {
            _petStoreApiClient = petStoreApiClient;
            _petImageApiClient = petImageApiClient;
            _dynamoDbClient = dynamoDbClient;
            _logger = logger;
        }

        public async Task<List<PetApiOutput>> GetPets()
        {
            var petDtos = await _petStoreApiClient.GetPets();

            var petOutputs = petDtos?.Select(x => x?.ToPetOutput())
                .ToList();

            return petOutputs;
        }

        public async Task<List<PetImageOutput>> GetPetImages(int limit = 10)
        {
            var petImages = await _petImageApiClient.GetPetImages(limit);

            var petImageOutputs = petImages?.Select(x => x?.ToPetImageOutput())
                .ToList();

            return petImageOutputs;
        }

        public async Task<SavePetsResponseDto> ProcessPets(ProcessPetRequest petRequest)
        {
            // Mapping input to domain objects
            var pets = petRequest.Pets.Select(x => x.ToPet())
                .ToList();

            // Add images to domain objects
            var images = (await _petImageApiClient.GetPetImages())
                .Select(x => x.ToPetImage())
                .ToList();

            foreach (var pet in pets)
            {
                var selectedImages = images.Count > 0 ? images.Skip(new Random().Next(6))
                .Take(2).ToList() : images;
                pet.Images = selectedImages;
            }

            // Save pets in Pet Store external API
            var petStoreRequests = pets.Select(x => x.ToPetApiSaveRequestDto())
                .ToList();

            var saveTasks = petStoreRequests.Select(x => _petStoreApiClient.SavePets(x))
                .ToArray();

            // Save data to dynamo db
            var table = Table.LoadTable(_dynamoDbClient, PetStoreConstants.DYNAMO_DB_TABLE);

            var documents = pets.Select(x => x.ToDynamoDocument())
                .ToList();

            var putTasks = documents.Select(x => table.PutItemAsync(x))
                .ToArray();

            // Execute task async
            await Task.WhenAll(saveTasks);
            await Task.WhenAll(putTasks);

            // Mapping return object
            var petOutput = pets.Select(x => x.ToPetOutputDto())
                .ToList();

            var saveOutput = new SavePetsResponseDto()
            {
                Pets = petOutput,
            };

            return saveOutput;
        }
    }
}
