using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using sistemasugestao.Models;

namespace sistemasugestao.Context
{
    public class MyContext : IdentityDbContext<Login>
    {
        public DbSet<Avaliador> Avaliadores { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Sugestao> Sugestoes { get; set; }
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Avaliador>().ToTable("Avaliador");
            modelBuilder.Entity<Campanha>().ToTable("Campanha");
            modelBuilder.Entity<Sugestao>().ToTable("Sugestao");

        }

    }
}
