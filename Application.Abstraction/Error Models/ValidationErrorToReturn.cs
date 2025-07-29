using Application.Abstraction.Error_Models;
using System.Net;

namespace ErrorModels
{
    public class ValidationErrorToReturn
    {
        public int StatusCode { get; set; } =(int) HttpStatusCode.BadRequest;
        public string Message { get; set; } = "Validation Failed";
        public IEnumerable<validationError> ValidationErrors { get; set; } = [];
    }

}
