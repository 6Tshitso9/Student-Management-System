using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class DBStorageSize
    {
        [Key]
        public int Size_ID { get; set; }

        public string Size_Name { get; set; }

        public int Size_Length { get; set; }

        public int Size_Width { get; set; }


        public int Size_Height { get; set; }

        public decimal Size_PricePerDay { get; set; }

        public int Size_NumSpaces { get; set; }

        public int Venue_ID { get; set; }
    }
}
