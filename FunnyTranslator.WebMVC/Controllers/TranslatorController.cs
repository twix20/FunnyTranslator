using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using FunnyTranslator.Application.Interfaces.Services;
using FunnyTranslator.Core;
using FunnyTranslator.Core.Entities;
using FunnyTranslator.Data.Context;
using FunnyTranslator.Infrastructure;
using FunnyTranslator.Models;

namespace FunnyTranslator.Controllers
{
    public class TranslatorController : Controller
    {
        private readonly ITranslationService _translationService;

        public TranslatorController(ITranslationService translationService)
        {
            _translationService = translationService;
        }

        // GET: Translator
        public ActionResult Index()
        {
            var vm = new TranslatorViewModel()
            {
                SupportedTranslationMethods = _translationService.SupportedTranslationMethods
            };

            return View(vm);
        }

        // POST: Translator/Translate
        [HttpPost]
        [ValidateModel]
        [HandleHttpExceptionError]
        public async Task<ActionResult> Translate(TranslateFormViewModel model)
        {

            var translationResult = await _translationService.TranslateAsync(model.Text, model.TranslateType);


            return Json(translationResult);
        }
    }
}