using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ToDo.Filters
{
    public class UserFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            int? userid = context.HttpContext.Session.GetInt32("id");
            if (!userid.HasValue) 
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary
                {
                    {"action","Index" },
                    {"controller","Home"}
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
