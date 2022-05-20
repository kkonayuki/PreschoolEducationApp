using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PreschoolEducationApp.Models;
using System.Text.RegularExpressions;

namespace PreschoolEducationApp.Data
{
    public class PreschoolDbContext : DbContext
    {
        public PreschoolDbContext(DbContextOptions<PreschoolDbContext> options) : base(options)
        {

        }

        public DbSet<Kid> Kids { get; set; }
        public DbSet<KidGroup> KidGroups { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Address> Addresses { get; set; }

    }
}
