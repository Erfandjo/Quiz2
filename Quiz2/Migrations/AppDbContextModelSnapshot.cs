﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Quiz2.Infrastructure;

#nullable disable

namespace Quiz2.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Quiz2.Entities.Card", b =>
                {
                    b.Property<string>("CardNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<float>("Balance")
                        .HasColumnType("real");

                    b.Property<string>("HolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("WrongPasswordTries")
                        .HasColumnType("int");

                    b.HasKey("CardNumber");

                    b.HasIndex("UserId");

                    b.ToTable("Cards");

                    b.HasData(
                        new
                        {
                            CardNumber = "6037997568331020",
                            Balance = 500f,
                            HolderName = "MeliCard",
                            IsActive = false,
                            Password = "1234",
                            UserId = 1,
                            WrongPasswordTries = 0
                        },
                        new
                        {
                            CardNumber = "6037997568331030",
                            Balance = 100f,
                            HolderName = "MeliCard",
                            IsActive = false,
                            Password = "1234",
                            UserId = 2,
                            WrongPasswordTries = 0
                        });
                });

            modelBuilder.Entity("Quiz2.Entities.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TransactionId"));

                    b.Property<DateTime>("ActionAt")
                        .HasColumnType("datetime2");

                    b.Property<float>("Amount")
                        .HasColumnType("real");

                    b.Property<string>("DestinationCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsSuccess")
                        .HasColumnType("bit");

                    b.Property<string>("SourceCardNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("TransactionId");

                    b.HasIndex("DestinationCardNumber");

                    b.HasIndex("SourceCardNumber");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("Quiz2.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "ali",
                            LastName = "jafari"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "erfan",
                            LastName = "joharzadeh"
                        });
                });

            modelBuilder.Entity("Quiz2.Entities.Card", b =>
                {
                    b.HasOne("Quiz2.Entities.User", "User")
                        .WithMany("Cards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Quiz2.Entities.Transaction", b =>
                {
                    b.HasOne("Quiz2.Entities.Card", "DestinationCard")
                        .WithMany("TransactionsAsDestination")
                        .HasForeignKey("DestinationCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Quiz2.Entities.Card", "SourceCard")
                        .WithMany("TransactionsAsSource")
                        .HasForeignKey("SourceCardNumber")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("DestinationCard");

                    b.Navigation("SourceCard");
                });

            modelBuilder.Entity("Quiz2.Entities.Card", b =>
                {
                    b.Navigation("TransactionsAsDestination");

                    b.Navigation("TransactionsAsSource");
                });

            modelBuilder.Entity("Quiz2.Entities.User", b =>
                {
                    b.Navigation("Cards");
                });
#pragma warning restore 612, 618
        }
    }
}
