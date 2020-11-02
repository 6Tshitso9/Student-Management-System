using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class DBCampus
    {
        [Key]
        public int Campus_ID { get; set; }

        public string Campus_Name { get; set; }

        public string University_ID { get; set; }
    }
}
