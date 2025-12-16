using System.ComponentModel.DataAnnotations;

namespace Blogging_Platform_API.Validations
{
    public class ContainsSpecialCharacterAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }

            bool containsSpecialCharacter = false;
            string valueString = value.ToString()!;
            char[] valueStringCharacters = valueString.ToCharArray();
            char[] SpecialCharacters =
                [ '!', '@', '#', '$', '%', '^', '&', '*', '(', ')','-', '_', '=', '+', '[', ']', '{', '}', '\\', '|',
                  ';', ':', '\'', '"', ',', '.', '<', '>', '/', '?','~', '`'
                ];

            foreach (char specialCharacter in SpecialCharacters)
            {
                foreach(char valueStringCharacter in valueStringCharacters)
                {
                    if(valueStringCharacter == specialCharacter)
                    {
                        containsSpecialCharacter = true;
                        break;
                    }
                }
            }

            if (!containsSpecialCharacter)
            {
                return new ValidationResult("The password must contain at least one special character");
            }

            return ValidationResult.Success;
        }
    }
}
