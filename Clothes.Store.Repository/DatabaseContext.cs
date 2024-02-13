using Clothes.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Clothes.Store.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options) { }

        public DbSet<Custumer> Custumer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Custumer>(e =>
            {
                e.HasKey(c => c.CustumerID);

                e.Property(c => c.CustumerName)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

                e.Property(c => c.Email)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

                e.Property(c => c.CPF)
                .IsRequired()
                .HasColumnType("varchar(14)")
                .HasMaxLength(14);

                e.Property(c => c.Password)
                .IsRequired()
                .HasColumnType("varchar(16)")
                .HasMaxLength(16);

                e.Property(c => c.CriationDateHour)
                .IsRequired()
                .HasColumnType("DATETIME");

                e.Property(c => c.UserType)
                .IsRequired()
                .HasColumnType("INT");

                e.Property(c => c.IsActivate)
                .IsRequired()
                .HasColumnType("BIT");
            });
        }
    }
}
