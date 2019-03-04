using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EnrollmentApplicationLab06.Models
{
    public class Student : IValidatableObject
    {
        [Display(Name = "Student ID")]
        public virtual int StudentId { get; set; }

        [Required(ErrorMessage = "A Last Name is required.")]
        [Display(Name = "Last Name")]
        [InvalidChar("*", ErrorMessage = "Last Name cannot contain invalid characters")]
        [StringLength(50, ErrorMessage = "Last Name cannot be more the 50 characters.")]
        public virtual string StudentLastName { get; set; }

        [Required(ErrorMessage = "A First Name is required.")]
        [Display(Name = "First Name")]
        [InvalidChar("*")]
        [StringLength(50, ErrorMessage = "Firest Name cannot be more then 50 characters.")]
        public virtual string StudentFirstName { get; set; }

        [MinimumAge(20)]
        public virtual int Age { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string State { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            // Address 1 not the same as Address 2
            if (Address1 == Address2)
            {
                yield return (new ValidationResult("Address 2 cannot be the same as Address 1"));
            }

            // State 2 digits
     
            if (State.Length != 2)
            {
                yield return (new ValidationResult("Enter a 2 digit State code"));
            }

            // State 2 digits
            if (Zipcode.Length != 5)
            {
                yield return (new ValidationResult("Enter a 5 digit Zipcode"));
            }
        
        }

    }
}
 