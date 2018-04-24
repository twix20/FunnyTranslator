using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Interfaces;
using log4net;
using Newtonsoft.Json;

namespace FunnyTranslator.Application.Services
{
    public class TranslationService : ITranslationService
    {
        private readonly ITranslationStrategyFactory _strategyFactory;
        private readonly ILog _logger;

        public TranslationService(ITranslationStrategyFactory strategyFactory, ILog logger)
        {
            _strategyFactory = strategyFactory;
            _logger = logger;
        }

        public IEnumerable<string> SupportedTranslationMethods => _strategyFactory.SupportedTranslationMethods;

        public async Task<TranslationResult> TranslateAsync(string textToTranslate, string translationMethod)
        {
            _logger.Info($"textToTranslate: {textToTranslate}; translationMethod: {translationMethod}");

            var result = new TranslationResult();
            var strategy = _strategyFactory.CreateForMethod(translationMethod);

            if (string.IsNullOrWhiteSpace(textToTranslate))
                result.AddError("Text To Translate can't be null or empty");

            if (strategy == null)
                result.AddError($"Translation method: {translationMethod} is not supported yet!");

            //When no validation errors, execute strategy
            if (result.IsSuccess)
            {
                result = await strategy.Execute(textToTranslate);
            }

            _logger.Info(JsonConvert.SerializeObject(result));
            return result;
        }
    }
}
