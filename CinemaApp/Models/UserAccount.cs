using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace CinemaApp.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email required")]
        [RegularExpression("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@((\\[[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\])|(([a-zA-Z\\-0-9]+\\.)+[a-zA-Z]{2,}))$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "User Name required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage = "Confirm your password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}