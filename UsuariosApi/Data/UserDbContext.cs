using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace UsuariosApi.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser<int>, IdentityRole<int>, int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) :base(options)
        {

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
        }

    }
}
