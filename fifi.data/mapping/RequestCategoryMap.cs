using System;
using System.Data.Entity.ModelConfiguration;
using fifi.data.entities;


namespace fifi.data.mapping
{
    public class RequestCategoryMap : EntityTypeConfiguration<ReportCategory>
    {
        public RequestCategoryMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Label)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}
