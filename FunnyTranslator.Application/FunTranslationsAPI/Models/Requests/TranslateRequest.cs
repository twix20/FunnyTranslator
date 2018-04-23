using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTranslator.Application.FunTranslationsAPI.Models.Requests
{
    public class TranslateRequest
    {
        public string TranslationType { get; set; }
        public string Text { get; set; }
    }
}
