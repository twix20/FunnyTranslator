using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces.Services;

namespace FunnyTranslator.Application.Interfaces
{
    public interface ITranslationStrategy
    {
        Task<TranslationResult> Execute(string textToTranslate);
    }
}
