using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application;

namespace FunnyTranslator.Core
{
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
