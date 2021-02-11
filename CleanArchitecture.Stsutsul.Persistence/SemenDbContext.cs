using CleanArchitecture.Stsutsul.Application;
using CleanArchitecture.Stsutsul.Domain;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Stsutsul.Persistence
{
    public class SemenDbContext : DbContext, ISemenDbContext
    {
        public SemenDbContext(DbContextOptions<SemenDbContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Semen> Semens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SemenDbContext).Assembly);
        }
    }
}