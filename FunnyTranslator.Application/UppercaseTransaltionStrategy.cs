using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Interfaces;

namespace FunnyTranslator.Application
{
    public class UppercaseTransaltionStrategy : ITranslationStrategy
    {
        public Task<TranslationResult> Execute(string textToTranslate)
        {
            return Task.FromResult(new TranslationResult(new TranslationInfo()
            {
                TranslationMethod = "Uppercase",
                TextToTranslate = textToTranslate,
                TranslatedText = textToTranslate.ToUpper()
            }));
        }
    }
}
