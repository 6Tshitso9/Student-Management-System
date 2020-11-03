using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class DBStorageRental
    {   [Key]
        public int Rental_Number { get; set; }
        [Display(Name = "Check In Date")]
        [DataType(DataType.Date)]
        public DateTime Rental_StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Check Out Date")]
        public DateTime Rental_EndDate { get; set; }
        [Display(Name = "Price")]
        [Column(TypeName = "float(18,2)")]
        public float Rental_Price { get; set; }
        [Display(Name = "Tracking Number")]
        public String Rental_Locator { get; set; }
        [Display(Name = "Checked In")]
        public String Rental_CheckedIn { get; set; }
        public int Size_ID { get; set; }

        public int Venue_ID { get; set; }

        public int Student_ID { get; set; }
    }
}
