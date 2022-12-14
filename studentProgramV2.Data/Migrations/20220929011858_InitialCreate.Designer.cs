// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using studentProgramV2.Data.Concrete.EntityFramework.Contexts;

namespace studentProgramV2.Data.Migrations
{
    [DbContext(typeof(studentProgramV2Context))]
    [Migration("20220929011858_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("studentProgramV2.Entities.Concrete.Lesson", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Credit")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.ToTable("Lessons");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2022, 9, 29, 4, 18, 58, 549, DateTimeKind.Local).AddTicks(699),
                            Credit = 6,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2022, 9, 29, 4, 18, 58, 549, DateTimeKind.Local).AddTicks(9503),
                            Name = "Matematik 1",
                            Note = "default"
                        },
                        new
                        {
                            Id = 2,
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2022, 9, 29, 4, 18, 58, 550, DateTimeKind.Local).AddTicks(421),
                            Credit = 5,
                            IsActive = true,
                            IsDeleted = false,
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2022, 9, 29, 4, 18, 58, 550, DateTimeKind.Local).AddTicks(426),
                            Name = "Fizik 1",
                            Note = "default"
                        });
                });

            modelBuilder.Entity("studentProgramV2.Entities.Concrete.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ModifiedByName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Note")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.HasKey("Id");

                    b.ToTable("Students");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2022, 9, 29, 4, 18, 58, 552, DateTimeKind.Local).AddTicks(1195),
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Çiftçi",
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2022, 9, 29, 4, 18, 58, 552, DateTimeKind.Local).AddTicks(1200),
                            Name = "Ahmet",
                            Note = "default",
                            Number = "211213100"
                        },
                        new
                        {
                            Id = 2,
                            CreatedByName = "Admin",
                            CreatedDate = new DateTime(2022, 9, 29, 4, 18, 58, 552, DateTimeKind.Local).AddTicks(1995),
                            IsActive = true,
                            IsDeleted = false,
                            LastName = "Göksu",
                            ModifiedByName = "Admin",
                            ModifiedDate = new DateTime(2022, 9, 29, 4, 18, 58, 552, DateTimeKind.Local).AddTicks(1998),
                            Name = "Mehmet",
                            Note = "default",
                            Number = "212705001"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
