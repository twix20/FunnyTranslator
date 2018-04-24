using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.FunTranslationsAPI;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Interfaces;
using FunTranslationsApi;
using FunTranslationsApi.Models.Requests;

namespace FunnyTranslator.Application
{
    /// <summary>
    /// http://funtranslations.com/api
    /// </summary>
    public class FunTranslationsStrategy : ITranslationStrategy
    {
        private readonly FunTranslationsClient _client;
        private readonly string _translationType;

        public FunTranslationsStrategy(string translationType, string apiToken = default(string))
        {
            _translationType = translationType;
            _client = new FunTranslationsClient(apiToken);
        }

        public async Task<TranslationResult> Execute(string textToTranslate)
        {
            var responseData = await _client.TranslateAsync(new TranslateRequest()
            {
                TranslationType = _translationType,
                Text = textToTranslate
            });

            return new TranslationResult(new TranslationInfo()
            {
                TextToTranslate = textToTranslate,
                TranslatedText = responseData.Contents.Translated,
                TranslationMethod = $"{_translationType}"
            });
        }
    }
}
