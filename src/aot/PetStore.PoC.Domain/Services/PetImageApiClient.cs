using Microsoft.Extensions.Logging;
using PetStore.PoC.Domain.Constants;
using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models.Serializers;
using PetStore.PoC.Domain.Services.Interfaces;
using System.Text.Json;

namespace PetStore.PoC.Domain.Services
{
    public class PetImageApiClient : IPetImageApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public PetImageApiClient(IHttpClientFactory httpClientFactory, ILogger<PetStoreApiClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<PetImageApiDto>> GetPetImages(int limit = 10)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var endpoint = $"{PetStoreConstants.PETIMAGEAPI_BASE_URL}?limit={limit}";

            var response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                var petImages = JsonSerializer.Deserialize(message, JsonPetStoreSerializerContext.Default.ListPetImageApiDto);

                return petImages;
            }
            return null;
        }
    }
}
