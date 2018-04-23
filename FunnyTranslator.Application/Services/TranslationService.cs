using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Application.Interfaces.Services;

namespace FunnyTranslator.Application.Services
{
    public class TranslationService : ITranslationService
    {
        public async Task<TranslationResult> TranslateAsync(string textToTranslate, ITranslationStrategy strategy)
        {
            //Basic validation
            if(string.IsNullOrWhiteSpace(textToTranslate))
                return new TranslationResult(new List<string>() { "Text To Translate can't be null or empty" });

            var result = await strategy.Execute(textToTranslate);
            return result;
        }
    }
}
