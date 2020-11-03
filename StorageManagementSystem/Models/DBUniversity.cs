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
        public int Uni_ID { get; set; }
        public string Uni_Name { get; set; }

        public string Uni_City { get; set; }

    }
}
