using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunnyTranslator.Application
{
    public class GenericObjectResult<TResult, TError>
    {
        public bool IsSuccess => !Errors.Any();
        public ICollection<TError> Errors { get; } = new List<TError>();

        public TResult Result { get; }


        public GenericObjectResult(TResult result)
        {
            Result = result;
        }

        public GenericObjectResult(ICollection<TError> errors)
        {
            foreach (var error in errors)
            {
                AddError(error);
            }
        }

        public void AddError(TError error)
        {
            Errors.Add(error);
        }
    }
}
