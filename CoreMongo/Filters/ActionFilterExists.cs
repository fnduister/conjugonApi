using ConjugonApi.Core;
using ConjugonApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MongoDB.Bson;

namespace ConjugonApi.Filters
{
    public class ActionFilterExists<T> : IActionFilter where T : IEntity
    {
        private readonly ConjugonDbContext _conjugonDbContext;

        public ActionFilterExists(ConjugonDbContext conjugonDbContext)
        {
            _conjugonDbContext = conjugonDbContext;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            ObjectId id = ObjectId.Empty;

            if(!context.ActionArguments.ContainsKey("Id")) {
                context.Result = new BadRequestObjectResult("Something ain't right");
            }
            else
            {
                if(context.ActionArguments["Id"] != null)
                {
                    id = (ObjectId)context.ActionArguments["Id"]!;
                }
            }

            var entity = _conjugonDbContext.Set<T>().SingleOrDefault(x => x.Id == id);

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
