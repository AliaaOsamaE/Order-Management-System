using Application.Abstraction.Error_Models;
using ErrorModels;
using Microsoft.AspNetCore.Mvc;

namespace Order_Management_System.Factories
{
    public class ApiResponseFactory
    {
        public static IActionResult GenerateApiValidationErrorResponse(ActionContext context)
        {
            var errors = context.ModelState.Where(e => e.Value.Errors.Any())
                  .Select(e => new validationError()
                  {
                      Field = e.Key,
                      Errors = e.Value.Errors.Select(x => x.ErrorMessage)
                  });

            var Response = new ValidationErrorToReturn
            {
                ValidationErrors = errors
            };
            return new BadRequestObjectResult(Response);
        }
    }
}
