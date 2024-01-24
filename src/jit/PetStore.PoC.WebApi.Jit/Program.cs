using PetStore.PoC.WebApi.Jit.Extensions;

namespace PetStore.PoC.WebApi.Jit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add project dependencies
            builder.Services.AddProjectDependencies();

            builder.Services.AddAWSLambdaHosting(LambdaEventSource.RestApi);

            var app = builder.Build();

            // Add endpoints
            app.MapPetEndpoints();

            app.Run();
        }
    }
}
