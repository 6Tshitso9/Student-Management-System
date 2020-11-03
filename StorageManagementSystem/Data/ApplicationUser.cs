using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Extensions.Configuration;

namespace StorageManagementSystem.Models
{
    public class ApplicationUser : DbContext
    {
        public ApplicationUser(DbContextOptions<ApplicationUser> options) : base(options)
        {
           
        }
        public DbSet<DBStudent> Student { get; set; }
        public DbSet<DBUniversity> University { get; set; }

        public DbSet<DBCampus> Campus { get; set; }

       

    }
}
