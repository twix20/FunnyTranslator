using RestSharp;
using RestSharp.Authenticators;

namespace FunTranslationsApi
{
    public class ApiTokenAuthenticator : IAuthenticator
    {
        private readonly string _apiKey;

        public ApiTokenAuthenticator(string apiKey)
        {
            _apiKey = apiKey;
        }

        public void Authenticate(IRestClient client, IRestRequest request)
        {
            request.AddHeader("X-FunTranslations-Api-Secret", _apiKey);
        }
    }
}
