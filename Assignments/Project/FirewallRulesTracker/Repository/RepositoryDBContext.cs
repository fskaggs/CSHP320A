using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Repository.Models;

#nullable disable

namespace Repository
{
    public partial class RepositoryDBContext : DbContext
    {
        public RepositoryDBContext()
        {
        }

        public RepositoryDBContext(DbContextOptions<RepositoryDBContext> options)
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
        public DbSet<FWRuleDBModel> Rules { get; set; }
    }
}
