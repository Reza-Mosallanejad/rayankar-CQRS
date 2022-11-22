using System.ComponentModel.DataAnnotations;

namespace CRUDTest.Domain.DTOs
{
    public class CustomerDTO
    {
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [MaxLength(150, ErrorMessage = "{0} length should be less than 150")]
        public string Firstname { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "{0} is Required")]
        [MaxLength(150, ErrorMessage = "{0} length should be less than 150")]
        public string Lastname { get; set; }

        [Display(Name = "Birth Date")]
        [Required(ErrorMessage = "{0} is Required")]
        public DateOnly DateOfBirth { get; set; }

        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "{0} is Required")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} is Required")]
        [MaxLength(150, ErrorMessage = "{0} length should be less than 150")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Bank Account Number")]
        [Required(ErrorMessage = "{0} is Required")]
        [RegularExpression("^[0-9]{12}", ErrorMessage = "Please enter 12 lengh numberic string")]
        public string BankAccountNumber { get; set; }
    }
}
