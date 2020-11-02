using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class DBUniversity
    {
        [Key]
        public int University_ID { get; set; }
        public string University_Name { get; set; }

        public string University_City { get; set; }

    }
}
