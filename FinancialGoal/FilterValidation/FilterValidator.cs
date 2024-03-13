using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FinancialGoal.API.FilterValidation
{
    public class FilterValidator : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // ignore
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                var message = context.ModelState
                                .SelectMany(ms => ms.Value.Errors)
                                .Select(e => e.ErrorMessage)
                                .ToList();

                context.Result = new BadRequestObjectResult(message);
            }
        }
    }
}
