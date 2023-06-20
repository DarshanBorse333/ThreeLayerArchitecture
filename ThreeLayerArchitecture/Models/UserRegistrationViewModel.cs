using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using ThreeLayerArchitecture.DAL;

namespace ThreeLayerArchitecture.Models
{
    public class UserRegistrationViewModel
    {

        public int Id { get; set; }

        [Required]
        [EmailAddress]
        //[Remote(action: "IsEmailIdValid", controller: "User")]
        public string? Email { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string? LastName { get; set; }

        public int? GenderId { get; set; }
        [Required]
        [RegularExpression(@"^(\+\d{1,2}\s?)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}$", ErrorMessage = "Mobile Number isn't valid")]
        [Display(Name = "Mobile")]
        public string? MobileNumber { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 8, ErrorMessage = "Password Should be minimum length of 8 and a maximum length of 20 Characters")]
        public string? Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Password doesn't matched")]
        public string? ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"/(^[0-9]{4}[0-9]{4}[0-9]{4}$)|(^[0-9]{4}\s[0-9]{4}\s[0-9]{4}$)|(^[0-9]{4}-[0-9]{4}-[0-9]{4}$)/", ErrorMessage = "enter Integers only")]
        public string? AadharNumber { get; set; }
        
        public string? Category { get; set; }
        
        public bool TermsConditions { get; set; }

        public string? GenderName { get; set; }
    }
}
