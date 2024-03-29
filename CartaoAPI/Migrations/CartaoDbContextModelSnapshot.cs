﻿// <auto-generated />
using System;
using CartaoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CartaoAPI.Migrations
{
    [DbContext(typeof(CartaoDbContext))]
    partial class CartaoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CartaoAPI.Models.Cartao", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("CVV")
                        .HasColumnType("int");

                    b.Property<string>("NomeCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumCartao")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VencimentoAno")
                        .HasColumnType("int");

                    b.Property<int>("VencimentoMes")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Cartoes");
                });
#pragma warning restore 612, 618
        }
    }
}
