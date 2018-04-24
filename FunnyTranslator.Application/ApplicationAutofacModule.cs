using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Application.Services;
using FunnyTranslator.Core.Interfaces;

namespace FunnyTranslator.Application
{
    public class ApplicationAutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //TODO: add services
            builder.RegisterType<TranslationStrategyFactory>().As<ITranslationStrategyFactory>();
            builder.RegisterType<TranslationService>().As<ITranslationService>();
            base.Load(builder);
        }
    }
}
