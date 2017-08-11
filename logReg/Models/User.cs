using System;
using System.ComponentModel.DataAnnotations;

namespace logReg.Models
{
    public class User : BaseEntity
    {
        [Required(ErrorMessage = "First Name is required.")]
        [MinLength(2, ErrorMessage = "First Name must be at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,45}$", ErrorMessage = "Numbers are not allowed in first name.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        [MinLength(2, ErrorMessage = "Last Name must be at least 2 characters long.")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{2,45}$", ErrorMessage = "Numbers are not allowed in your last name.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Email format must be valid.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Password Confirmation is required.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password Confirmation must match Password provided above.")]
        public string PassConfirm { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

    }
}