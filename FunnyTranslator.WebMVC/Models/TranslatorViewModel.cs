using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FunnyTranslator.Models
{
    public class TranslatorViewModel
    {
        public IEnumerable<string> SupportedTranslationMethods { get; set; }
    }
}