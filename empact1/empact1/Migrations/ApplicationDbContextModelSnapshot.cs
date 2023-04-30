﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using empact1.Models;

#nullable disable

namespace empact1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("empact1.Models.CategoryModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Domain")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MediaContentId")
                        .HasColumnType("int");

                    b.Property<string>("MediaCredit")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MediaDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("NewsItemModelId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MediaContentId");

                    b.HasIndex("NewsItemModelId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("empact1.Models.MediaContentModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Medium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Width")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("MediaContents");
                });

            modelBuilder.Entity("empact1.Models.NewsItemModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DcCreator")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublishDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("empact1.Models.CategoryModel", b =>
                {
                    b.HasOne("empact1.Models.MediaContentModel", "MediaContent")
                        .WithMany()
                        .HasForeignKey("MediaContentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("empact1.Models.NewsItemModel", null)
                        .WithMany("Categories")
                        .HasForeignKey("NewsItemModelId");

                    b.Navigation("MediaContent");
                });

            modelBuilder.Entity("empact1.Models.NewsItemModel", b =>
                {
                    b.Navigation("Categories");
                });
#pragma warning restore 612, 618
        }
    }
}
