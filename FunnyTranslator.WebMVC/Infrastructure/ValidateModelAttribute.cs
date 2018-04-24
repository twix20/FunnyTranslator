using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunnyTranslator.Models;

namespace FunnyTranslator.Infrastructure
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.Controller.ViewData.ModelState.IsValid)
            {
                actionContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                actionContext.Result = new JsonResult()
                {
                    ContentType = "application/json",
                    Data = new ApiError()
                    {
                        ErrorCode = HttpStatusCode.BadRequest.ToString(),
                        ErrorMessage = string.Join(", ", actionContext.Controller.ViewData.ModelState.Values
                            .SelectMany(v => v.Errors).Select(e => e.ErrorMessage))
                    }
                };
            }
        }
    }
}