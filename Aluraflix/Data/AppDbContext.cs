using Aluraflix.Models;
using Microsoft.EntityFrameworkCore;

namespace Aluraflix.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Video>()
                .HasOne(video => video.Categoria)
                .WithMany(categoria => categoria.Videos)
                .HasForeignKey(video => video.CategoriaId);
        }

        public DbSet<Video> Videos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

    }


}
