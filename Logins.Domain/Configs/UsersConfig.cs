using Logins.Domain.Classes;
using Logins.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logins.Domain.Configs
{
    public class UsersConfig : IEntityTypeConfiguration<Users>
    {
        public void Configure(EntityTypeBuilder<Users> builder)
        {
            builder.HasKey(p => p.UserId);
            builder.Property(p => p.Email).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.Password).IsRequired();
            builder.Property(p => p.UserTypeId).IsRequired();
            builder.Property(p => p.SignupDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(p => p.Locked).HasDefaultValue(false);
            builder.Property(p => p.FirstName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.LastName).HasColumnType("nvarchar(500)").IsRequired();
            builder.Property(p => p.PositionId).IsRequired();
            builder.Property(p => p.BirthDate).IsRequired();
            builder.Property(p => p.HireDate).IsRequired();
            builder.Property(p => p.Address).HasColumnType("nvarchar(max)");

            SetData(builder);
        }

        private void SetData(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(
            new Users
            {
                UserId = -1,
                Email = "mahdi@goodlawsoftware.co.uk",
                Password = EncryptHelper.PasswordHash("admin"),
                SignupDate = DateTime.Now,
                Locked = false,
                FirstName = "mahdi",
                LastName = "joveyni",
                BirthDate = DateTime.Now,
                HireDate = DateTime.Now
            });
        }
    }


}
