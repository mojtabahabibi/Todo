using FluentValidation.Results;
using System;
using System.Collections.Generic;

namespace Todo.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        public List<string>? Errors { get; set; } = new List<string>();
        public ValidationException(ValidationResult validationResult) 
        {
            foreach (var err in validationResult.Errors)
            {
                Errors.Add(err.ErrorMessage);
            }
        }
    }
}
