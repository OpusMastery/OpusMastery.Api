﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OpusMastery.Dal.Contexts;

#nullable disable

namespace OpusMastery.Dal.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20230529220637_AddUserRoleEntityRightsTable")]
    partial class AddUserRoleEntityRightsTable
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OpusMastery.Dal.Models.Company", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CompanyId")
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.EmployeeRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("EmployeeRoles");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MiddleName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUserRoleEntityRights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("CanAdd")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanDelete")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanModify")
                        .HasColumnType("boolean");

                    b.Property<bool>("CanRead")
                        .HasColumnType("boolean");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EntityName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoleEntityRights");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Company", b =>
                {
                    b.HasOne("OpusMastery.Dal.Models.Identity.SystemUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Employee", b =>
                {
                    b.HasOne("OpusMastery.Dal.Models.Company", "Company")
                        .WithMany("Employees")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpusMastery.Dal.Models.EmployeeRole", "Role")
                        .WithMany("Employees")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("OpusMastery.Dal.Models.Identity.SystemUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUser", b =>
                {
                    b.HasOne("OpusMastery.Dal.Models.Identity.SystemUserRole", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUserRoleEntityRights", b =>
                {
                    b.HasOne("OpusMastery.Dal.Models.Identity.SystemUserRole", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Company", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.EmployeeRole", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("OpusMastery.Dal.Models.Identity.SystemUserRole", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
