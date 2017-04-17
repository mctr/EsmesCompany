using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using EsmesCompany.Migrations;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace EsmesCompany.Models
{
    public class EsmesContext : DbContext
    {
        public EsmesContext() :base("EsmesContext")
        {
            Database.SetInitializer(new  MigrateDatabaseToLatestVersion<EsmesContext, Configuration>("EsmesContext"));
        }
        
        public DbSet<User> Users { get; set; }
        public DbSet<Subscription> Subscriptions { get; set; }
        public DbSet<Year> Years { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}