using Clothes.Store.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clothes.Store.Repository
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DbContext> options) : base(options){}

        public DbSet<Custumer> Custumer { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Custumer>(e =>
            {
                e.HasKey(d => d.CustumerID);

                e.Property(d => d.CustumerName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                e.Property(d => d.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnType("varchar(100)");

                e.Property(d => d.CPF)
                    .IsRequired()
                    .HasMaxLength(15)
                    .HasColumnType("varchar(15)");

                e.Property(d => d.Password)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnType("varchar(16)");

                e.Property(d => d.CriationDateHour)
                    .IsRequired()
                    .HasColumnType("DATETIME");

                e.Property(d => d.TypeUser)
                    .IsRequired()
                    .HasColumnType("INT");

                e.Property(d => d.IsActivate)
                    .IsRequired()
                    .HasColumnType("BIT");
            });
        }
    }
}
