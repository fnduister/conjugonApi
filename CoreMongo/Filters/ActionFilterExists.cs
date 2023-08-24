using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using ConjugonApi.Data;
using ConjugonApi.Models.Common;

namespace ConjugonApi.Filters
{
    public class ActionFilterExists<T> : IActionFilter where T : IEntity
    {
        private readonly TennisDbContext _tennisDbContext;

        public ActionFilterExists(TennisDbContext tennisDbContext)
        {
            _tennisDbContext = tennisDbContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            Guid id = Guid.Empty;

            if(!context.ActionArguments.ContainsKey("Id")) {
                context.Result = new BadRequestObjectResult("Something aint right");
            }
            else
            {
                if(context.ActionArguments["Id"] != null)
                {
                    id = (Guid)context.ActionArguments["Id"];
                }
            }

            var entity = _tennisDbContext.Set<T>().SingleOrDefault(x => x.Id == id);

            if(entity == null)
            {
                context.Result = new NotFoundResult();
            }
            else
            {
                context.HttpContext.Items.Add("entity", entity);
            }

        }
    }
}
