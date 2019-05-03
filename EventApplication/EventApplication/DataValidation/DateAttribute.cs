using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EventApplication.CustomValidation
{
    public class DateAttribute : ValidationAttribute
    {
        private readonly DateTime _minDate;

        public DateAttribute(string minDate){

            if (minDate.Equals("today"))
            {
                _minDate = DateTime.Now;
            }
            else
            {
                _minDate = DateTime.Parse(minDate);
            }
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                if (_minDate.Date.CompareTo(value) < 0) {

                    return new ValidationResult("Date cannot be in the past");

                }


            }


            return ValidationResult.Success;
        }
    }
}