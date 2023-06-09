﻿// <auto-generated />
using System;
using BlogWebsite.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BlogWebsite.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230511090452_22")]
    partial class _22
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BlogWebsite.Models.BlogPost", b =>
                {
                    b.Property<int?>("BlogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("BlogId"), 1L, 1);

                    b.Property<DateTime?>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserLoginId")
                        .HasColumnType("int");

                    b.HasKey("BlogId");

                    b.HasIndex("UserLoginId");

                    b.ToTable("Blogs");
                });

            modelBuilder.Entity("BlogWebsite.Models.UserDetails", b =>
                {
                    b.Property<int?>("UId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("UId"), 1L, 1);

                    b.Property<string>("ContactNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileBio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicUrl")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UId");

                    b.HasIndex("LoginId")
                        .IsUnique()
                        .HasFilter("[LoginId] IS NOT NULL");

                    b.ToTable("Details");
                });

            modelBuilder.Entity("BlogWebsite.Models.UserLogin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("BlogWebsite.Models.BlogPost", b =>
                {
                    b.HasOne("BlogWebsite.Models.UserLogin", "Users")
                        .WithMany("Blogs")
                        .HasForeignKey("UserLoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BlogWebsite.Models.UserDetails", b =>
                {
                    b.HasOne("BlogWebsite.Models.UserLogin", "Login")
                        .WithOne("UserDetails")
                        .HasForeignKey("BlogWebsite.Models.UserDetails", "LoginId");

                    b.Navigation("Login");
                });

            modelBuilder.Entity("BlogWebsite.Models.UserLogin", b =>
                {
                    b.Navigation("Blogs");

                    b.Navigation("UserDetails")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
