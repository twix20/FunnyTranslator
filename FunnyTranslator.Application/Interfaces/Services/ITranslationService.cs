using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Interfaces;

namespace FunnyTranslator.Application.Interfaces.Services
{
    public interface ITranslationService
    {
        IEnumerable<string> SupportedTranslationMethods { get; }
        Task<TranslationResult> TranslateAsync(string textToTranslate, string translationMethod);
    }
}
