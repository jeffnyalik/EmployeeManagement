﻿// <auto-generated />
using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EmployeeManagement.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    partial class EmployeeDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EmployeeManagement.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Department")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("PhotoPath")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Department = 3,
                            Email = "nyake@yahoo.com",
                            Name = "Jeff"
                        },
                        new
                        {
                            Id = 2,
                            Department = 3,
                            Email = "nyake@yahoo.com",
                            Name = "Nyake"
                        },
                        new
                        {
                            Id = 3,
                            Department = 2,
                            Email = "bruce@hotmail.com",
                            Name = "Bruce"
                        },
                        new
                        {
                            Id = 4,
                            Department = 4,
                            Email = "oloo@oloo.com",
                            Name = "Oloo"
                        },
                        new
                        {
                            Id = 5,
                            Department = 5,
                            Email = "krishna@gmail.com",
                            Name = "Krishna"
                        },
                        new
                        {
                            Id = 6,
                            Department = 2,
                            Email = "jane@gmail.com",
                            Name = "Jane"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
