using Logins.Domain.Class;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logins.Domain.Config
{
    public class LookupConfig : IEntityTypeConfiguration<Lookup>
    {
        public void Configure(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasKey(p => new { p.LookupId, p.LookupTypeId });
            builder.Property(p => p.Caption).HasColumnType("nvarchar(500)").IsRequired();

            SetData(builder);
        }

        private void SetData(EntityTypeBuilder<Lookup> builder)
        {
            builder.HasData(
                //UserType
                new Lookup { LookupId = 1, LookupTypeId = 1, Caption = "Admin" },
                new Lookup { LookupId = 2, LookupTypeId = 1, Caption = "Default" },
                // Position
                new Lookup { LookupId = 1, LookupTypeId = 2, Caption = "CEO" },
                new Lookup { LookupId = 2, LookupTypeId = 2, Caption = "CMO" },
                new Lookup { LookupId = 3, LookupTypeId = 2, Caption = "HR Manager" },
                new Lookup { LookupId = 4, LookupTypeId = 2, Caption = "Sales Assistant" },
                new Lookup { LookupId = 5, LookupTypeId = 2, Caption = "HR Assistant" },
                new Lookup { LookupId = 6, LookupTypeId = 2, Caption = "IT Manager" }
            );
        }
    }
}