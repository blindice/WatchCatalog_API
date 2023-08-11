﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WatchCatalog_API.Context;

#nullable disable

namespace WatchCatalog_API.Migrations
{
    [DbContext(typeof(WatchContext))]
    partial class WatchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("WatchCatalog_API.Model.tbl_watch", b =>
                {
                    b.Property<int>("WatchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WatchId"), 1L, 1);

                    b.Property<string>("Caliber")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<string>("Case")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Diameter")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Full_Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal>("Height")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Jewel")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(13,4)");

                    b.Property<string>("Short_description")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Strap")
                        .IsRequired()
                        .HasMaxLength(30)
                        .IsUnicode(false)
                        .HasColumnType("varchar(30)");

                    b.Property<decimal>("Thickness")
                        .HasColumnType("decimal(8,2)");

                    b.Property<string>("WatchName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(8,2)");

                    b.HasKey("WatchId")
                        .HasName("PK__tbl_watc__3BA3DAA3319953BA");

                    b.ToTable("tbl_watch");
                });
#pragma warning restore 612, 618
        }
    }
}
