using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class StorageRentalDetails
    {
        public DBStorageRental rental { get; set; }
        [Display(Name = "Venue: ")]
        public string venueName { get; set; }

        public string size { get; set; }
    }
}
