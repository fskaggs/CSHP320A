using System;
using FirewallRulesTracker.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FirewallRulesTracker
{
    public partial class FirewallRulesContext : DbContext
    {
        public FirewallRulesContext()
        {
        }

        public FirewallRulesContext(DbContextOptions<FirewallRulesContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(local);Initial Catalog=FirewallRules;integrated security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        //public DbSet<Service> Services { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<FWRule> Rules { get; set; }
    }
}
