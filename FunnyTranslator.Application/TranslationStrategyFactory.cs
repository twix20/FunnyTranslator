using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FunnyTranslator.Application.Interfaces;
using FunnyTranslator.Core.Interfaces;

namespace FunnyTranslator.Application
{
    public class TranslationStrategyFactory : ITranslationStrategyFactory
    {
        readonly Dictionary<string, ITranslationStrategy> _translationStrategies = new Dictionary<string, ITranslationStrategy>()
        {
            { "leetspeak", new FunTranslationsStrategy("leetspeak")},
            { "yoda", new FunTranslationsStrategy("yoda")},
        };

        public IEnumerable<string> SupportedTranslationMethods => new List<string>(_translationStrategies.Keys);

        public ITranslationStrategy CreateForMethod(string translationMethod)
        {
            _translationStrategies.TryGetValue(translationMethod, out var strategy);

            return strategy;
        }
    }
}
