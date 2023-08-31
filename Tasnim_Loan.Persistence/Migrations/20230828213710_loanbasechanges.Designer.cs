﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tasnim_Loan.Persistence.Context;

namespace Tasnim_Loan.Persistence.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    [Migration("20230828213710_loanbasechanges")]
    partial class loanbasechanges
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.Loan", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<bool>("Cleared")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("DateCleared")
                        .HasColumnType("datetime2");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Guaranty")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Introducer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("Loan_Num")
                        .HasColumnType("int");

                    b.Property<int>("Payment_Amount")
                        .HasColumnType("int");

                    b.Property<int>("Payment_Num")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Total_Amount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Loans");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.LoanInType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<int>("LoanId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("LoanId");

                    b.HasIndex("TypeId");

                    b.ToTable("LoanInTypes");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.Typee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Types");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Creditor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Debtor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Trans_Num")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("User_ID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("User_ID");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.NewUser", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("National_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("Unique_Payment_Identifier")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Userss");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.Role", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            InsertTime = new DateTime(2023, 8, 29, 1, 7, 7, 548, DateTimeKind.Local).AddTicks(203),
                            IsRemoved = false,
                            Name = "Admin"
                        },
                        new
                        {
                            ID = 2,
                            InsertTime = new DateTime(2023, 8, 29, 1, 7, 7, 559, DateTimeKind.Local).AddTicks(8502),
                            IsRemoved = false,
                            Name = "Operator"
                        },
                        new
                        {
                            ID = 3,
                            InsertTime = new DateTime(2023, 8, 29, 1, 7, 7, 559, DateTimeKind.Local).AddTicks(9063),
                            IsRemoved = false,
                            Name = "Customer"
                        });
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.UserInRole", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("InsertTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsRemoved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("RemoveTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInRoles");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.Loan", b =>
                {
                    b.HasOne("Tasnim_Loan.Domain.Entities.Users.NewUser", "User")
                        .WithMany("Loan")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.LoanInType", b =>
                {
                    b.HasOne("Tasnim_Loan.Domain.Entities.Loans.Loan", "Loan")
                        .WithMany()
                        .HasForeignKey("LoanId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasnim_Loan.Domain.Entities.Loans.Typee", "Type")
                        .WithMany("LoanInType")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Loan");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Transaction", b =>
                {
                    b.HasOne("Tasnim_Loan.Domain.Entities.Users.NewUser", "User")
                        .WithMany("Transaction")
                        .HasForeignKey("User_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.UserInRole", b =>
                {
                    b.HasOne("Tasnim_Loan.Domain.Entities.Users.Role", "Role")
                        .WithMany("UserInRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tasnim_Loan.Domain.Entities.Users.NewUser", "User")
                        .WithMany("UserInRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Loans.Typee", b =>
                {
                    b.Navigation("LoanInType");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.NewUser", b =>
                {
                    b.Navigation("Loan");

                    b.Navigation("Transaction");

                    b.Navigation("UserInRoles");
                });

            modelBuilder.Entity("Tasnim_Loan.Domain.Entities.Users.Role", b =>
                {
                    b.Navigation("UserInRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
