using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using fifi.data.entities;

namespace fifi.data.mapping
{
    public class ReportMap : EntityTypeConfiguration<Report>
    {
        public ReportMap()
        {
            this.HasKey(p => p.Id);
            this.Property(p => p.Lat)
                .IsRequired();
            this.Property(p => p.Long)
                .IsRequired();
            this.Property(p => p.Type)
                .IsRequired();
            this.Property(p => p.Narrative)
                .IsOptional();
            this.Property(p => p.Address)
                .IsOptional();
            this.Property(p => p.Mode)
                .IsRequired();
            this.Property(p => p.CreatedOn)
                .IsOptional();
            this.Property(p => p.Description)
                .IsOptional();
            this.Property(p => p.Image)
                .IsOptional();
        }
    }
}
