﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using xpUpBackend.ContextDb;

#nullable disable

namespace xpUpBackend.Migrations
{
    [DbContext(typeof(XpUpContext))]
    partial class XpUpContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("xpUpBackend.Models.CheckIn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Check")
                        .HasColumnType("tinyint(1)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Events")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Events");

                    b.HasIndex("Users");

                    b.ToTable("CheckIn");
                });

            modelBuilder.Entity("xpUpBackend.Models.Courses", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Users");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("xpUpBackend.Models.Events", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Users");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("xpUpBackend.Models.Likes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Like")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("News")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("News");

                    b.HasIndex("Users");

                    b.ToTable("Likes");
                });

            modelBuilder.Entity("xpUpBackend.Models.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Subtitle")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("Users")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Users");

                    b.ToTable("News");
                });

            modelBuilder.Entity("xpUpBackend.Models.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("Courses")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("UserRole")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Courses");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("xpUpBackend.Models.CheckIn", b =>
                {
                    b.HasOne("xpUpBackend.Models.Events", "Event")
                        .WithMany()
                        .HasForeignKey("Events")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xpUpBackend.Models.Users", "CheckedBy")
                        .WithMany()
                        .HasForeignKey("Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CheckedBy");

                    b.Navigation("Event");
                });

            modelBuilder.Entity("xpUpBackend.Models.Courses", b =>
                {
                    b.HasOne("xpUpBackend.Models.Users", "Enrolleds")
                        .WithMany()
                        .HasForeignKey("Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Enrolleds");
                });

            modelBuilder.Entity("xpUpBackend.Models.Events", b =>
                {
                    b.HasOne("xpUpBackend.Models.Users", "PublishedBy")
                        .WithMany()
                        .HasForeignKey("Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("xpUpBackend.Models.Likes", b =>
                {
                    b.HasOne("xpUpBackend.Models.News", "Notice")
                        .WithMany("Likes")
                        .HasForeignKey("News")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("xpUpBackend.Models.Users", "LikedBy")
                        .WithMany()
                        .HasForeignKey("Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LikedBy");

                    b.Navigation("Notice");
                });

            modelBuilder.Entity("xpUpBackend.Models.News", b =>
                {
                    b.HasOne("xpUpBackend.Models.Users", "PublishedBy")
                        .WithMany()
                        .HasForeignKey("Users")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublishedBy");
                });

            modelBuilder.Entity("xpUpBackend.Models.Users", b =>
                {
                    b.HasOne("xpUpBackend.Models.Courses", "Course")
                        .WithMany()
                        .HasForeignKey("Courses")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("xpUpBackend.Models.News", b =>
                {
                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
