using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using UsuariosApi.Models;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<CustomIdentityUser, IdentityRole<int>, int>
    {
        private IConfiguration _configuration;
        public UserDbContext(DbContextOptions<UserDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityUser<int>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(110);
                entity.Property(m => m.Email).HasMaxLength(130);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(130);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(130);
                entity.Property(m => m.UserName).HasMaxLength(130);
            });
            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.Property(m => m.Id).HasMaxLength(200);
                entity.Property(m => m.Name).HasMaxLength(130);
                entity.Property(m => m.NormalizedName).HasMaxLength(130);
            });
            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.Property(m => m.LoginProvider).HasMaxLength(130);
                entity.Property(m => m.ProviderKey).HasMaxLength(130);
            });
            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(130);
                entity.Property(m => m.RoleId).HasMaxLength(130);
            });
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.Property(m => m.UserId).HasMaxLength(110);
                entity.Property(m => m.LoginProvider).HasMaxLength(110);
                entity.Property(m => m.Name).HasMaxLength(110);

            });

            CustomIdentityUser admin = new CustomIdentityUser()
            {
                Id = 99999,
                UserName = "admin",
                Email = "admin@admin.com",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@ADMIN.COM",
                NormalizedUserName = "ADMIN",
                SecurityStamp = Guid.NewGuid().ToString()

            };

            PasswordHasher<CustomIdentityUser> passwordHasher = new PasswordHasher<CustomIdentityUser>();
            admin.PasswordHash = passwordHasher.HashPassword(admin, _configuration.GetValue<string>("admininfo:password"));

            builder.Entity<CustomIdentityUser>().HasData(admin);

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99999, Name = "admin", NormalizedName = "ADMIN" }
            );

            builder.Entity<IdentityRole<int>>().HasData(
                new IdentityRole<int> { Id = 99997, Name = "regular", NormalizedName = "REGULAR" }
            );

            builder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int> { RoleId = 99999, UserId = 99999 }
            );
        }

    }
}
