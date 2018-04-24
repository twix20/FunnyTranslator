using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FunnyTranslator.Infrastructure
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.Controller.ViewData.ModelState.IsValid)
            {
                actionContext.Result = new ViewResult
                {
                    ViewData = actionContext.Controller.ViewData,
                    TempData = actionContext.Controller.TempData
                };
            }
        }
    }
}