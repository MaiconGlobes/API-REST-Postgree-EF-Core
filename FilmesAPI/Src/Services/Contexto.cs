using FilmesAPI.Models;
using FilmesAPI.Src.Models;
using Microsoft.EntityFrameworkCore;

namespace EF_Core_Postgre.Src.Services
{
   public class Contexto : DbContext
   {
      public DbSet<Filme> FILME { get; set; }
      public DbSet<Site> SITE { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         modelBuilder.Entity<Site>()
                 .HasOne(site => site.Filmes)      //Tem um...
                 .WithMany(b => b.sites)           //Com muitos...
                 .HasForeignKey(p => p.filmeId);   //Tem chave estrangeira...

         modelBuilder.Entity<Site>()
            .HasIndex(a => a.url)
            .IsUnique();
      }
      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseLazyLoadingProxies()
                             .UseNpgsql("Host=127.0.0.1;Database=postgres;Username=postgres;Password=root");
   }
}
