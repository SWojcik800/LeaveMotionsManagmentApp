using LeaveMotionsManagmentApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LeaveMotionsManagmentApp.Validation.Attributes
{
    
    public class LaterThanTomorrow : ValidationAttribute
    {

        public string GetErrorMessage() =>
            $"Date must be greater than tomorrow.";

        //Checks if requested date is greater than tomorrow

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var laterDate = ((DateTime)value);
            if (laterDate > DateTime.Now.AddDays(1))
                return ValidationResult.Success;
            return new ValidationResult(GetErrorMessage());
        }
    }
}
