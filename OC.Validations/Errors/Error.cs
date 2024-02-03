using OC.Validations.Errors.Enums;

namespace OC.Validations.Errors
{
    public static class Error
    {
        public static ErrorMessage NotFound(string code = "Default.NotFound", string message = "A not found error has ocurred!")
        {
            return new ErrorMessage(code, message, ErrorType.NotFound);
        }
        public static ErrorMessage Validation(string code = "Default.Validation", string message = "A validation error has ocurred!")
        {
            return new ErrorMessage(code, message, ErrorType.Validation);
        }        
        public static ErrorMessage Failure(string code = "Default.Failure", string message = "A failure has ocurred!")
        {
            return new ErrorMessage(code, message, ErrorType.Failure);
        }
    }

    public class ErrorMessage
    {
        public string Code { get; set; }
        public string Message { get; set; }
        public ErrorType ErrorType { get; set; }

        public ErrorMessage(string code, string message, ErrorType errorType)
        {
            Code = code;
            Message = message;
            ErrorType = errorType;
        }
    }
}
