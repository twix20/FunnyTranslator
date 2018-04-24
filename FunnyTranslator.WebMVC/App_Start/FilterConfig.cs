using System.Web;
using System.Web.Mvc;
using FunnyTranslator.Infrastructure;

namespace FunnyTranslator
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new InternationalizationAttribute());
            filters.Add(new HandleErrorAttribute());
        }
    }
}
