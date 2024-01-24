using PetStore.PoC.Domain.Constants;
using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Services.Interfaces;
using System.Text.Json;
using PetStore.PoC.Domain.Models.Serializers;
using Microsoft.Extensions.Logging;
using PetStore.PoC.Domain.Models.Inputs;
using System.Text;

namespace PetStore.PoC.Domain.Services
{
    public class PetStoreApiClient : IPetStoreApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger _logger;

        public PetStoreApiClient(IHttpClientFactory httpClientFactory, ILogger<PetStoreApiClient> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }

        public async Task<List<PetApiDto>> GetPets()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var endpoint = $"{PetStoreConstants.PETSTOREAPI_BASE_URL}";

            var response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                var petDtos = JsonSerializer.Deserialize(message, JsonPetStoreSerializerContext.Default.ListPetApiDto);

                return petDtos;
            }
            return null;
        }

        public async Task<PetApiSaveResponseDto> SavePets(PetApiSaveRequestDto request)
        {
            var httpClient = _httpClientFactory.CreateClient();

            var endpoint = $"{PetStoreConstants.PETSTOREAPI_BASE_URL}";

            var json = JsonSerializer.Serialize(request, JsonPetStoreSerializerContext.Default.PetApiSaveRequestDto);
            var content = new StringContent(json, Encoding.UTF8, mediaType: "application/json");

            var response = await httpClient.PostAsync(endpoint, content);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                var petDtos = JsonSerializer.Deserialize(message, JsonPetStoreSerializerContext.Default.PetApiSaveResponseDto);

                return petDtos;
            }
            return null;
        }
    }
}
