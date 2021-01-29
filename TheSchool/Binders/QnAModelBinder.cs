
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;


namespace TheSchool.Binders
{
    public class QnAModelBinder : IModelBinder
    {
        public static object BindQnAModel(IFormCollection values, ModelStateDictionary modelState)
        {
            //TODO: Implement model binder for QuestionAndAnswerModel
            throw new NotImplementedException();
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            return Task.FromResult(BindQnAModel(bindingContext.HttpContext.Request.Form, bindingContext.ModelState));
        }
    }
}