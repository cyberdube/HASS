using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Filters;



namespace HASS_v1.Filters

{

    public class AdminAuthorizationFilter : IActionFilter

    {

        public void OnActionExecuting(ActionExecutingContext context)

        {

            var isAdmin = context.HttpContext.Session.GetString("IsAdmin");

            if (string.IsNullOrEmpty(isAdmin) || isAdmin != "true")

            {

                context.Result = new RedirectToActionResult("Login", "Account", null);

            }

        }



        public void OnActionExecuted(ActionExecutedContext context)

        {

            // No need to implement for this filter
             
        }

    }

}

