using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Interfaces;

namespace FunnyTranslator.Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationStrategyFactory _strategyFactory;

        public TranslationService(ITranslationStrategyFactory strategyFactory)
        {
            _strategyFactory = strategyFactory;
        }

        public IEnumerable<string> SupportedTranslationMethods => _strategyFactory.SupportedTranslationMethods;

        public async Task<TranslationResult> TranslateAsync(string textToTranslate, string translationMethod)
        {
            //Basic validation
            if(string.IsNullOrWhiteSpace(textToTranslate))
                return new TranslationResult(new List<string>() { "Text To Translate can't be null or empty" });

            var strategy = _strategyFactory.CreateForMethod(translationMethod);
            if(strategy == null)
                return new TranslationResult(new List<string>() { $"Translation method: {translationMethod} is not supported yet!" });

            var result = await strategy.Execute(textToTranslate);
            return result;
        }
    }
}
