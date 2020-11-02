using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StorageManagementSystem.Models
{
    public class ApplicationUser:DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {

        }
        public DbSet<DBStudent> Student { get; set; }

        public DbSet<DBUniversity> University { get; set; }

        public DbSet<DBCampus> Campus { get; set; }
    }
}
