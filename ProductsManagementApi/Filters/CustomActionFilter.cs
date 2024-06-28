using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace ProductsManagementApi.Filters
{
    public class CustomActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            // Code to execute before the action executes
            Debug.WriteLine("Action is executing");
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // Code to execute after the action executes
            Debug.WriteLine("Action executed");
        }
    }
}
