﻿// <auto-generated />
using HavingFun.EFDA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace HavingFun.EFDAL.Migrations
{
    [DbContext(typeof(MainDBContext))]
    [Migration("20190910221236_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("HavingFun.EFDAL.Entities.Claim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Claims","schUsers");
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(1024);

                    b.HasKey("Id");

                    b.ToTable("Roles","schUsers");
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FirstName")
                        .HasMaxLength(256);

                    b.Property<string>("LastName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(64);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.ToTable("Users","schUsers");
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.UserClaims", b =>
                {
                    b.Property<int>("ClaimId");

                    b.Property<int>("UserId");

                    b.HasKey("ClaimId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserClaims","schUsers");
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.UserRoles", b =>
                {
                    b.Property<int>("RoleId");

                    b.Property<int>("UserId");

                    b.HasKey("RoleId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles","schUsers");
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.UserClaims", b =>
                {
                    b.HasOne("HavingFun.EFDAL.Entities.Claim", "Claim")
                        .WithMany("UserClaims")
                        .HasForeignKey("ClaimId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HavingFun.EFDAL.Entities.User", "User")
                        .WithMany("UserClaims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("HavingFun.EFDAL.Entities.UserRoles", b =>
                {
                    b.HasOne("HavingFun.EFDAL.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("HavingFun.EFDAL.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}