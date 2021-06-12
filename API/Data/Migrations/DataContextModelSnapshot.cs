﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.7");

            modelBuilder.Entity("API.Entities.AccountTransaction", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Category")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("TEXT");

                    b.Property<string>("Note")
                        .HasColumnType("TEXT");

                    b.Property<int>("TransactionValue")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("isIncome")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Country")
                        .HasColumnType("TEXT");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("TEXT");

                    b.Property<string>("FirstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<int>("MonthlyCashFlow")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearlyCashFlow")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Entities.MoneyAccount", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Currency")
                        .HasColumnType("TEXT");

                    b.Property<int>("CurrentBalance")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ExcludeFromTotal")
                        .HasColumnType("INTEGER");

                    b.Property<int>("InitialBalance")
                        .HasColumnType("INTEGER");

                    b.Property<int>("MonthlyCashFlow")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("YearlyCashFlow")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("API.Entities.AccountTransaction", b =>
                {
                    b.HasOne("API.Entities.MoneyAccount", "AddedToAccount")
                        .WithMany("Transactions")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AddedToAccount");
                });

            modelBuilder.Entity("API.Entities.MoneyAccount", b =>
                {
                    b.HasOne("API.Entities.AppUser", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("API.Entities.AppUser", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("API.Entities.MoneyAccount", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
