using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FunnyTranslator.Controllers
{
    public class TranslatorController : Controller
    {
        // GET: Translator
        public ActionResult Index()
        {
            return View();
        }
    }
}