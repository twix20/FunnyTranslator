using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application;

namespace FunnyTranslator.Core
{
    public class TranslationResult : GenericObjectResult<TranslationInfo, string>
    {
        public TranslationResult(TranslationInfo info) : base(info)
        {
        }

        public TranslationResult() : base(new List<string>())
        {
        }

    }

    public class TranslationInfo
    {
        public string TranslationMethod { get; set; }
        public string TranslatedText { get; set; }
        public string TextToTranslate { get; set; }
    }
}
