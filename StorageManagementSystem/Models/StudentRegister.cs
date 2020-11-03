using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class StudentRegister
    {
        [Key] 
        public int Student_ID{ get; set; }
        [Required(ErrorMessage = "Please Enter Email...")]
        [Display(Name = "Email")]
        public string Student_Email { get; set; }
        [Required(ErrorMessage = "Please enter you first name(s):")]
        [Display(Name = "First Name(s):")]
        public string Student_FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your lastname")]
        [Display(Name = "Last Name:")]
        public string Student_LastName { get; set; }

        [Required(ErrorMessage = "Please enter you university identifier (student number)")]
        [Display(Name = "Student Number:")]
        public string Student_UniversityNumber { get; set; }
        [Required(ErrorMessage = "Please enter your contact number")]
        [Display(Name = "Cellphone Number:")]
        public string Student_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        public string Student_Password { get; set; }

        [Required(ErrorMessage = "Please Confirm your Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password:")]
        [Compare("Student_Password")]
        public string confirmPassword { get; set; }
        [Required(ErrorMessage = "Please choose your university")]
        [Display(Name = "University:")]
        public string University_Name;
        public IEnumerable<SelectListItem> Universities;
        [Required(ErrorMessage = "Please choose your campus")]
        [Display(Name = "Campus:")]
        public string Campus_Name { get; set; }
        public IEnumerable<SelectListItem> Campuses;







    }
}
