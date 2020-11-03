using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class StorageVenueRental
    {
        public List<DBStorageRental> Rentals { get; set; }
        public string venueName { get; set; }
        public string SearchString { get; set; }

        public string orderBy { get; set; }
    }
}
