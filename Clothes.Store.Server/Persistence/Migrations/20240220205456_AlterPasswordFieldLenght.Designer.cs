﻿// <auto-generated />
using System;
using Clothes.Store.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Clothes.Store.Server.Persistence.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20240220205456_AlterPasswordFieldLenght")]
    partial class AlterPasswordFieldLenght
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Clothes.Store.Domain.Entities.Custumer", b =>
                {
                    b.Property<Guid>("CustumerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("varchar(14)");

                    b.Property<DateTime>("CriationDateHour")
                        .HasColumnType("DATETIME");

                    b.Property<string>("CustumerName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<bool>("IsActivate")
                        .HasColumnType("BIT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("varchar(16)");

                    b.Property<int>("UserType")
                        .HasColumnType("INT");

                    b.HasKey("CustumerID");

                    b.ToTable("Custumer");
                });
#pragma warning restore 612, 618
        }
    }
}
