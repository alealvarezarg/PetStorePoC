using PetStore.PoC.Domain.Constants;
using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models;
using PetStore.PoC.Domain.Services.Interfaces;
using System.Text.Json;
using PetStore.PoC.Domain.Models.Serializers;

namespace PetStore.PoC.Domain.Services
{
    public class PetStoreApiClient : IPetStoreApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public PetStoreApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<PetDto?> CreatePet(Pet pet)
        {
            //var httpClient = _httpClientFactory.CreateClient();

            //var endpoint = $"{PetStoreConstants.PETSTOREAPI_BASE_URL}";
            //var serializer = new JsonSerializerSettings()
            //{
            //    ContractResolver = new CamelCasePropertyNamesContractResolver()
            //};
            //var body = JsonConvert.SerializeObject(pet, serializer);
            //var content = new StringContent(body, Encoding.UTF8, mediaType: "application/json");

            //var response = await httpClient.PostAsync(endpoint, content);
            //if (response.IsSuccessStatusCode)
            //{
            //    var message = await response.Content.ReadAsStringAsync();
            //    var petDto = JsonConvert.DeserializeObject<PetDto>(message);
            //    return petDto;
            //}
            return await Task.FromResult<PetDto>(default);
        }

        public async Task<IEnumerable<PetDto?>?> GetPets()
        {
            var httpClient = _httpClientFactory.CreateClient();

            var endpoint = $"{PetStoreConstants.PETSTOREAPI_BASE_URL}";

            var response = await httpClient.GetAsync(endpoint);
            if (response.IsSuccessStatusCode)
            {
                var message = await response.Content.ReadAsStringAsync();

                var petDtos = JsonSerializer.Deserialize(message, JsonPetStoreSerializerContext.Default.IEnumerablePetDto);

                return petDtos;
            }
            return null;
        }
    }
}
