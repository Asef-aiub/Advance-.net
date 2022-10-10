using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Lab_Task_2.CustomAnnotation
{
    public class IdEmailValidation : ValidationAttribute
    {
        public string OtherProperty { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            if (Equals(((string)value).Substring(0, 10), otherPropertyValue))
                return null;
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
}