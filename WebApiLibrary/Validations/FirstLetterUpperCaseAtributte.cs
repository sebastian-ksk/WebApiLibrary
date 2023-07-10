using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApiLibrary.Entities;
namespace WebApiLibrary.Validations
{
    public class FirstLetterUpperCaseAtributte: ValidationAttribute
    {
        protected override ValidationResult IsValid(object Value, ValidationContext validationContext)
        {

            if (Value == null || string.IsNullOrEmpty(Value.ToString()))
            {
                return ValidationResult.Success;
            }

            var firstLetter = Value.ToString()[0].ToString();
            if (firstLetter != firstLetter.ToUpper())
            {
                return new ValidationResult("First letter must be upper case");
            }

            return ValidationResult.Success;
        }
    }
}


