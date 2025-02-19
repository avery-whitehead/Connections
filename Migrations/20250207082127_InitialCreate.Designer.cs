﻿// <auto-generated />
using System;
using Connections.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Connections.Migrations
{
    [DbContext(typeof(ConnectionsContext))]
    [Migration("20250207082127_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Connections.Models.Group", b =>
                {
                    b.Property<int>("PuzzleId")
                        .HasColumnType("int");

                    b.Property<int>("Difficulty")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Member1")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Member2")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Member3")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.Property<string>("Member4")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("nvarchar(55)");

                    b.HasKey("PuzzleId", "Difficulty");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            PuzzleId = 1,
                            Difficulty = 1,
                            Description = "Parts of a Bicycle Wheel",
                            Member1 = "Spoke",
                            Member2 = "Hub",
                            Member3 = "Rim",
                            Member4 = "Tire"
                        },
                        new
                        {
                            PuzzleId = 1,
                            Difficulty = 2,
                            Description = "Types of Fabric",
                            Member1 = "Cotton",
                            Member2 = "Silk",
                            Member3 = "Wool",
                            Member4 = "Linen"
                        },
                        new
                        {
                            PuzzleId = 1,
                            Difficulty = 3,
                            Description = "To Regard",
                            Member1 = "Deem",
                            Member2 = "Rate",
                            Member3 = "Judge",
                            Member4 = "Reckon"
                        },
                        new
                        {
                            PuzzleId = 1,
                            Difficulty = 4,
                            Description = "Last words of David Lynch titles",
                            Member1 = "Peaks",
                            Member2 = "Empire",
                            Member3 = "Drive",
                            Member4 = "Velvet"
                        });
                });

            modelBuilder.Entity("Connections.Models.Puzzle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<DateTimeOffset>("CreatedOn")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("ShareId")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("ShareId")
                        .IsUnique();

                    b.ToTable("Puzzles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "avery",
                            CreatedOn = new DateTimeOffset(new DateTime(2025, 2, 7, 0, 21, 26, 974, DateTimeKind.Unspecified).AddTicks(6094), new TimeSpan(0, -8, 0, 0, 0)),
                            ShareId = "test1234",
                            Title = "Example Puzzle"
                        });
                });

            modelBuilder.Entity("Connections.Models.Group", b =>
                {
                    b.HasOne("Connections.Models.Puzzle", "Puzzle")
                        .WithMany("Groups")
                        .HasForeignKey("PuzzleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Puzzle");
                });

            modelBuilder.Entity("Connections.Models.Puzzle", b =>
                {
                    b.Navigation("Groups");
                });
#pragma warning restore 612, 618
        }
    }
}
