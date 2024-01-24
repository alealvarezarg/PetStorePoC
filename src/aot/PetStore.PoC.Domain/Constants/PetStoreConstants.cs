namespace PetStore.PoC.Domain.Constants
{
    public static class PetStoreConstants
    {
        public const string PETSTOREAPI_BASE_URL = $"https://viowgkz4z0.execute-api.us-east-2.amazonaws.com/v1/pets";
        public const string PETIMAGEAPI_BASE_URL = $"https://api.thecatapi.com/v1/images/search";
        public const string DYNAMO_DB_REGION = "us-east-2";
        public const string DYNAMO_DB_TABLE = "PetStoreTable";
    }
}
