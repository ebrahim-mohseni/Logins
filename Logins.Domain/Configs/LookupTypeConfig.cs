using Logins.Domain.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logins.Domain.Configs
{
    public class LookupTypeConfig : IEntityTypeConfiguration<LookupType>
    {
        public void Configure(EntityTypeBuilder<LookupType> builder)
        {
            builder.HasKey(p => p.LookupTypeId);
            builder.Property(p => p.Caption).HasColumnType("nvarchar(500)").IsRequired();

            SetData(builder);
        }

        private void SetData(EntityTypeBuilder<LookupType> builder)
        {
            builder.HasData(            
                new LookupType { LookupTypeId = 1, Caption = "UserType" },                
                new LookupType { LookupTypeId = 2, Caption = "Position" }                
            );
        }
    }
}
