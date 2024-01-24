using Amazon.Lambda.APIGatewayEvents;
using PetStore.PoC.Domain.Models.DTOs;
using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Outputs;
using System.Text.Json.Serialization;

namespace PetStore.PoC.Domain.Models.Serializers
{
    [JsonSerializable(typeof(AddPets))]
    [JsonSerializable(typeof(PetOutput))]
    [JsonSerializable(typeof(PetDto))]
    [JsonSerializable(typeof(IEnumerable<PetOutput>))]
    [JsonSerializable(typeof(IEnumerable<PetDto>))]
    [JsonSerializable(typeof(APIGatewayProxyRequest))]
    [JsonSerializable(typeof(APIGatewayProxyResponse))]
    public partial class JsonPetStoreSerializerContext : JsonSerializerContext
    {
    }
}
