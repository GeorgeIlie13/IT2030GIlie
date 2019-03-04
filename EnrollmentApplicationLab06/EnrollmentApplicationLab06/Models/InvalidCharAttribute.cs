using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class InvalidCharAttribute : ValidationAttribute
    {
        readonly string invalidChar;



        public InvalidCharAttribute(string invalidChar) : base("{0} contains invalid characters!")

        {

            this.invalidChar = invalidChar;

        }



        protected override ValidationResult IsValid(object value, ValidationContext validationContext)

        {

            if (value.ToString().Contains(invalidChar))

            {

                var errormessage = FormatErrorMessage(validationContext.DisplayName);

                return new ValidationResult(errormessage);

            }

            return ValidationResult.Success;

        }

    }

}