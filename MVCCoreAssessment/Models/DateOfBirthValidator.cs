using MVCCoreAssessment.Controllers;
using System.ComponentModel.DataAnnotations;

namespace MVCCoreAssessment.Models
{
        public class DateOfBirthValidator : ValidationAttribute
        {
            protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime Dob = (DateTime)value;

                if ( Dob.Year < 2007 && Dob.Year > 2001)
                {
                    return ValidationResult.Success;
                }
                }
                return new ValidationResult(ErrorMessage ?? "Dob must be betwwen 01/01/2002 and 01/01/2008");
                //return base.IsValid(value, validationContext);
            }
        }
}

