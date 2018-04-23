using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTranslator.Application.Interfaces.Services
{
    public interface ITranslationService
    {
        Task<TranslationResult> TranslateAsync(string textToTranslate, ITranslationStrategy strategy);
    }

    public class TranslationResult : GenericObjectResult<string, string>
    {
        public TranslationResult(string translatedText) : base(translatedText)
        {
        }

        public TranslationResult(ICollection<string> errors) : base(errors)
        {
        }
    }
}
