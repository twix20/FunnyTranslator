using System.Threading.Tasks;
using FunnyTranslator.Application.FunTranslationsAPI.Models.Requests;
using FunnyTranslator.Application.FunTranslationsAPI.Models.Responses;
using RestSharp;

namespace FunnyTranslator.Application.FunTranslationsAPI
{
    public class FunTranslationsClient
    {
        public readonly string BASE_URL = "http://api.funtranslations.com";

        private readonly IRestClient _client;

        public FunTranslationsClient(string apiToken = default(string))
        {
            _client = new RestClient(BASE_URL)
            {
                Authenticator = new ApiTokenAuthenticator(apiToken)
            };
        }

        public Task<TranslateResponse> TranslateAsync(TranslateRequest model)
        {
            IRestRequest request = new RestRequest("/translate/{translationType}.json", Method.GET);
            request.AddUrlSegment("translationType", model.TranslationType);
            request.AddQueryParameter("text", model.Text);

            return _client.ExecuteTaskAsync<TranslateResponse>(request).EnsureSuccess();
        }

    }
}
