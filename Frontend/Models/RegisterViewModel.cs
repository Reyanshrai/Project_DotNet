using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Frontend.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [JsonProperty("firstname")]
        public required string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [JsonProperty("lastname")]
        public required string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [JsonProperty("email")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [JsonProperty("dateOfBirth")]
        public required string Dob { get; set; }

        [Required(ErrorMessage = "Mobile number is required")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Mobile number must be 10 digits")]
        [JsonProperty("mobileNumber")]
        public required string Mobile { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        [JsonProperty("gender")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [JsonProperty("password")]
        public required string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        [JsonIgnore]
        public required string RepeatPassword { get; set; }
    }
}
