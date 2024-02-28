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
        public DbSet<Log> Log { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Custumer>(c =>
            {
                c.HasKey(ci => ci.CustumerID);

                c.Property(cn => cn.CustumerName)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

                c.Property(e => e.Email)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

                c.Property(c => c.CPF)
                .IsRequired()
                .HasColumnType("varchar(14)")
                .HasMaxLength(14);

                c.Property(p => p.Password)
                .IsRequired()
                .HasColumnType("varchar(100)")
                .HasMaxLength(100);

                c.Property(cdh => cdh.CriationDateHour)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

                c.Property(u => u.UserType)
                .IsRequired()
                .HasColumnType("INT");

                c.Property(a => a.IsActivate)
                .IsRequired()
                .HasColumnType("BIT")
                .HasDefaultValue(0);
            });

            builder.Entity<Log>(l =>
            {
                l.HasKey(li => li.LogID);

                l.Property(ll => ll.LogLevel)
                .IsRequired()
                .HasColumnType("varchar(50)")
                .HasMaxLength(50);

                l.Property(m => m.Message)
                .IsRequired()
                .HasColumnType("nvarchar(max)")
                .HasMaxLength(100);

                l.Property(e => e.Exception)
                .IsRequired()
                .HasColumnType("nvarchar(max)")
                .HasMaxLength(100);

                l.Property(ld => ld.LogDate)
                .IsRequired()
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });
        }
    }
}
