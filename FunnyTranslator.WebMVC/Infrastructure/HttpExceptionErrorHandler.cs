using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FunnyTranslator.Models;

namespace FunnyTranslator.Infrastructure
{
    public class HandleHttpExceptionErrorAttribute : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!(filterContext.Exception is HttpException exception))
                return;

            filterContext.ExceptionHandled = true;
            filterContext.RequestContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.ServiceUnavailable;
            filterContext.Result = new JsonResult()
            {
                ContentType = "application/json",
                Data = new ApiError()
                {
                    ErrorCode = exception.GetHttpCode().ToString(),
                    ErrorMessage = exception.Message
                }
            };
        }
    }
}