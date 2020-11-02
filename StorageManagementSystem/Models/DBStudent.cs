using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class DBStudent
    {   [Key]
        public int Student_ID { get; set; }
       
        public string Student_Email { get; set; }
      
        public string Student_FirstName { get; set; }

    
        public string Student_LastName { get; set; }

        
        public string Student_UniversityNumber { get; set; }
       
        public string Student_ContactNumber { get; set; }

       
        public string Student_Password { get; set; }
       
        public int Campus_ID { get; set; }
    }
}
