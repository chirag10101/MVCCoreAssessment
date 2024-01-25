using MVCCoreAssessment.Controllers;
using System.ComponentModel.DataAnnotations;

namespace MVCCoreAssessment.Models
{
    public class IdValidator :ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                int id = (int)value;

                if (!BatchController.IsIdExist(id))
                {
                    return ValidationResult.Success;
                }
            }
            return new ValidationResult(ErrorMessage ?? "Id already exist !!");
            //return base.IsValid(value, validationContext);
        }
    }
}
