using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Lambda.Serialization.SystemTextJson;
using PetStore.PoC.Domain.Constants;
using PetStore.PoC.Domain.Models.Inputs;
using PetStore.PoC.Domain.Models.Serializers;
using PetStore.PoC.Domain.Services;
using PetStore.PoC.Domain.Services.Interfaces;

namespace PetStore.PoC.WebApi.Aot
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();

            builder.Services.ConfigureHttpJsonOptions(options =>
            {
                options.SerializerOptions.AddContext<JsonPetStoreSerializerContext>();
            });

            // Add dependencies
            builder.Services.AddHttpClient();
            builder.Services.AddSingleton<IPetStoreApiClient, PetStoreApiClient>();
            builder.Services.AddSingleton<IPetImageApiClient, PetImageApiClient>();
            builder.Services.AddSingleton<IPetStoreService, PetStoreService>();
            builder.Services.AddSingleton<IAmazonDynamoDB>(provider => 
            {
                var dynamoClient = new AmazonDynamoDBClient(RegionEndpoint.GetBySystemName(PetStoreConstants.DYNAMO_DB_REGION));
                return dynamoClient;
            });

            builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi, options =>
            {
                options.Serializer = new SourceGeneratorLambdaJsonSerializer<JsonPetStoreSerializerContext>();
            });

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            var app = builder.Build();

            // Add endpoints
            app.MapGet("/", () => "Running");
            app.MapGet("/pets", (IPetStoreService service) => service.GetPets().Result);
            app.MapGet("/images", (IPetStoreService service) => service.GetPetImages().Result);
            app.MapGet("/images/{limit}", (IPetStoreService service, int limit) => service.GetPetImages(limit).Result);
            app.MapPost("/process", (IPetStoreService service, ProcessPetRequest request) => service.ProcessPets(request).Result);

            app.Run();
        }
    }
}
