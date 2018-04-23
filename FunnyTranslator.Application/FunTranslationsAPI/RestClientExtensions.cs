using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;

namespace FunnyTranslator.Application.FunTranslationsAPI
{
    public static class RestClientExtensions
    {
        public static async Task<T> EnsureSuccess<T>(this Task<IRestResponse<T>> requestTask)
        {
            var response = await requestTask;
            if (!response.IsSuccessful)
                throw response.ErrorException;

            return response.Data;
        }
    }
}
