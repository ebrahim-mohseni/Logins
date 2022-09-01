using Logins.Domain.Class;
using Logins.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Logins.Domain.Config
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
            builder.Property(p => p.Profile).IsRequired();

            SetData(builder);
        }

        private void SetData(EntityTypeBuilder<Users> builder)
        {
            builder.HasData(
            new Users
            {
                UserId = -1,
                Email = "mahdi@goodlawsoftware.co.uk",
                Password = EncryptHelper.Encrypt("admin"),
                SignupDate = DateTime.Now,
                Locked = false,
                Profile = string.Empty
            });
        }
    }


}
