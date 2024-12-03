using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Modals.ValidationAttributes
{
    public class AtLeastOneRequiredUserAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            var properties = validationContext.ObjectType.GetProperties();
            var username = properties.FirstOrDefault(p => p.Name == "Username")?.GetValue(validationContext.ObjectInstance);
            var password = properties.FirstOrDefault(p => p.Name == "Password")?.GetValue(validationContext.ObjectInstance);
            var email = properties.FirstOrDefault(p => p.Name == "Email")?.GetValue(validationContext.ObjectInstance);
            var subscriptionId = properties.FirstOrDefault(p => p.Name == "SubscriptionId")?.GetValue(validationContext.ObjectInstance);


            if (username == null && password == null && email == null && subscriptionId == null)
            {
                return new ValidationResult("At least one of the fields is required.");
            }

            return ValidationResult.Success;
        }
    }
}
