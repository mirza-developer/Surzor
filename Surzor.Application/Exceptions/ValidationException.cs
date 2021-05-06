using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Surzor.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string> ErrorMessages { get; set; }
        public ValidationException(ValidationResult validationResult)
        {
            ErrorMessages = new List<string>();
            foreach (ValidationFailure failure in validationResult.Errors)
            {
                ErrorMessages.Add(failure.ErrorMessage);
            }
        }
    }
}
