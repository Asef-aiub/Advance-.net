using Lab_Task_2.CustomAnnotation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab_Task_2.Models
{
    public class Student
    {
        [Required, MinLength(3), MaxLength(25), DataType(DataType.Text), RegularExpression(@"^[a-zA-z \.\-]+$")]
        public string Name { get; set; }
        [Required, RegularExpression("^[0-9]{2}-[0-9]{5}-[1-3]{1}$")]
        public string Id { get; set; }
        [Required, RegularExpression("^[0-9]{2}-[0-9]{5}-[1-3]{1}@student.aiub.edu$"), IdEmailValidation(OtherProperty = "Id")]
        public string Email { get; set; }
        [Required, RegularExpression(@"^(\+88)?01[356789]{1}[0-9]{8}$")]
        public string Phone { get; set; }
        [DateValidation]
        public DateTime DateOfBirth { get; set; }
        [Required, RegularExpression(@"^(A|B|O|AB)(\+|-)$")]
   
        public string Gender { get; set; }

        [Required, StringLength(50, MinimumLength = 8), RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,50}$")]
        public string Password { get; set; }

        [Compare("Password")]
        public string ConfirmPassword { get; set; }

    }
}