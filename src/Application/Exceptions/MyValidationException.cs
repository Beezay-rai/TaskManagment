using FluentValidation.Results;

namespace TaskManagementApplication.Exception
{
    public class MyValidationException : ApplicationException
    {
        public List<string> Errors { get; set; } = new List<string>();
        public MyValidationException(ValidationResult validationResult)
        {
            foreach(var error in validationResult.Errors)
            {
                Errors.Add(error.ErrorMessage);
            }
        
        
        }
        
    }
}
