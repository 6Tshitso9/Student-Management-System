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
        [Required(ErrorMessage = "Please enter your firstname")]
        [Display(Name = "Enter your firstname")]
        public string Student_FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your surname")]
        [Display(Name = "Enter your surname")]
        public string Student_LastName { get; set; }

        [Required(ErrorMessage = "Please choose your university")]
        [Display(Name = "Choose your university")]
        public string Student_UniversityNumber { get; set; }
        
        //public string Student_ContactNumber { get; set; }

        [Required(ErrorMessage = "Please Enter Password...")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Student_Password { get; set; }

        
       // public string confirmPassword { get; set; }
        [Required(ErrorMessage = "Please choose your campus")]
        [Display(Name = "Choose your campus")]
        public int Campus_ID { get; set; }

       // public string university { get; set; }




    }
}
