
using HR.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace HR.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var currentTime = DateTime.UtcNow;
            builder.HasData(
                new ApplicationUser
                {
                    Id = "41776062 - 6086 - 1fbf - b923 - 2879a6680b9a",
                    Email = "admin@gmail.com",
                    NormalizedEmail = "ADMIN@GMAIL.COM",
                    UserName = "13566",
                    NormalizedUserName = "13566",
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                    Otp = "2452",
                    OtpExpiryTime = currentTime.AddSeconds(48)

                },
                new ApplicationUser
                {
                    Id = "41776062 - 6086 - 1fcf - b923 - 2879a6680b9a",
                    Email = "sunny@gmail.com",
                    NormalizedEmail = "SUNNY@GMAIL.COM",
                    UserName = "13558",
                    NormalizedUserName = "135",
                    PasswordHash = hasher.HashPassword(null, "Sunny@123"),
                    Otp = "3223",
                    OtpExpiryTime = currentTime.AddSeconds(48)
                }
            );
        }
    }
}
