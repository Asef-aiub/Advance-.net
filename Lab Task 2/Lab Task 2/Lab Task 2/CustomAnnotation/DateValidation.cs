using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_Task_2.CustomAnnotation
{
    public class DateValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime date = DateTime.Now;
            date.AddYears(-18);
            return date > Convert.ToDateTime(value);
        }
    }
}