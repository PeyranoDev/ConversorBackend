using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals.ValidationAttributes
{
    public class AtLeastOneRequiredCurrencyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            var properties = validationContext.ObjectType.GetProperties();
            var code = properties.FirstOrDefault(p => p.Name == "Code")?.GetValue(validationContext.ObjectInstance);
            var legend = properties.FirstOrDefault(p => p.Name == "Legend")?.GetValue(validationContext.ObjectInstance);
            var convertibilityIndex = properties.FirstOrDefault(p => p.Name == "ConvertibilityIndex")?.GetValue(validationContext.ObjectInstance);

            
            if (code == null && legend == null && (convertibilityIndex == null || convertibilityIndex.Equals(0)))
            {
                return new ValidationResult("At least one of the fields 'Code', 'Legend', or 'ConvertibilityIndex' is required.");
            }

            return ValidationResult.Success;
        }
    }
}
