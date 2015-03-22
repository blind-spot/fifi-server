using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using fifi.data.entities;

namespace fifi.data.contexts
{
    public class DataContext : BaseContext<DataContext>
    {

        public DbSet<ReportCategory> RequestCategories { get; set; }
        public DbSet<Report> ReportInteractions { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
