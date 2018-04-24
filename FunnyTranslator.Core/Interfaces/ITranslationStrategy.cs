using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTranslator.Core.Interfaces
{
    public interface ITranslationStrategy
    {
        Task<TranslationResult> Execute(string textToTranslate);
    }
}
