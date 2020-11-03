using Microsoft.EntityFrameworkCore;
using StorageManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Data
{
    public class StorageContext:DbContext
    {
        public StorageContext(DbContextOptions<StorageContext> options) : base(options)
        {

        }

        public DbSet<DBStorageRental> StorageRental { get; set; }

        public DbSet<DBVenue> Venue { get; set; }
    }
}
