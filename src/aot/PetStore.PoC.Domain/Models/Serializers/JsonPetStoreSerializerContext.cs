using Amazon.Lambda.APIGatewayEvents;
using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Internal;
using PetStore.PoC.Domain.Models.Outputs;
using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Serializers
{
    // Dtos
    [JsonSerializable(typeof(PetApiDto))]
    [JsonSerializable(typeof(PetImageApiDto))]
    [JsonSerializable(typeof(List<PetApiDto>))]
    [JsonSerializable(typeof(List<PetImageApiDto>))]
    // Inputs
    [JsonSerializable(typeof(PetApiSaveRequestDto))]
    [JsonSerializable(typeof(PetApiSaveResponseDto))]
    [JsonSerializable(typeof(PetInputDto))]
    [JsonSerializable(typeof(ProcessPetRequest))]
    [JsonSerializable(typeof(List<PetApiSaveRequestDto>))]
    [JsonSerializable(typeof(List<PetApiSaveResponseDto>))]
    [JsonSerializable(typeof(List<PetInputDto>))]
    [JsonSerializable(typeof(List<ProcessPetRequest>))]
    // Internal
    [JsonSerializable(typeof(Category))]
    [JsonSerializable(typeof(Pet))]
    [JsonSerializable(typeof(PetImage))]
    [JsonSerializable(typeof(Tag))]
    [JsonSerializable(typeof(List<Category>))]
    [JsonSerializable(typeof(List<Pet>))]
    [JsonSerializable(typeof(List<PetImage>))]
    [JsonSerializable(typeof(List<Tag>))]
    // Outputs
    [JsonSerializable(typeof(PetApiOutput))]
    [JsonSerializable(typeof(PetImageOutput))]
    [JsonSerializable(typeof(PetOutputDto))]
    [JsonSerializable(typeof(SavePetsResponseDto))]
    [JsonSerializable(typeof(List<PetApiOutput>))]
    [JsonSerializable(typeof(List<PetImageOutput>))]
    [JsonSerializable(typeof(List<PetOutputDto>))]
    [JsonSerializable(typeof(List<SavePetsResponseDto>))]
    // Other
    [JsonSerializable(typeof(string))]
    [JsonSerializable(typeof(List<string>))]
    // Events
    [JsonSerializable(typeof(APIGatewayProxyRequest))]
    [JsonSerializable(typeof(APIGatewayProxyResponse))]
    public partial class JsonPetStoreSerializerContext : JsonSerializerContext
    {
    }
}
