using System.ComponentModel.DataAnnotations;

namespace Blogging_Platform_API.Validations
{
    public class ContainsUppercaseAttribute :  ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            string valueString = value.ToString()!;
            
            if (!valueString.Any(char.IsUpper))
            {
                return new ValidationResult("Must contain an uppercase letter");
            }

            return ValidationResult.Success;
        }
    }
}
