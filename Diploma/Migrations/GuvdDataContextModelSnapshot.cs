// <auto-generated />
using System;
using Diploma.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Diploma.Migrations
{
    [DbContext(typeof(DiplomaDataContext))]
    partial class GuvdDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Diploma.DataContext.Case", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int?>("CaseNumber")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Citizenship")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Contacts")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Conviction")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DateBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ExtremistOrgID")
                        .HasColumnType("int");

                    b.Property<string>("FamilyComposition")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Fullname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("GenderID")
                        .HasColumnType("int");

                    b.Property<string>("Height")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("HumanForm")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool?>("IsWanted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LivingPlace")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("NationalityID")
                        .HasColumnType("int");

                    b.Property<string>("Nickname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Note")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("OCGMember")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Photo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PlaceBirth")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ProfileID")
                        .HasColumnType("int");

                    b.Property<string>("PublishedDate")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Secondname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SocialNetwork")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasAlternateKey("CaseNumber");

                    b.HasIndex("ExtremistOrgID");

                    b.HasIndex("GenderID");

                    b.HasIndex("NationalityID");

                    b.HasIndex("ProfileID");

                    b.ToTable("Cases");
                });

            modelBuilder.Entity("Diploma.DataContext.ExtremistOrg", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("ExtremistOrgs");
                });

            modelBuilder.Entity("Diploma.DataContext.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Diploma.DataContext.Nationality", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.ToTable("Nationalities");
                });

            modelBuilder.Entity("Diploma.DataContext.Profile", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Blocked")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Firstname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Image")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Login")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Position")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PrivateNumber")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Rank")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Secondname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Surname")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("UserSID")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("ID");

                    b.HasAlternateKey("PrivateNumber");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Diploma.DataContext.Case", b =>
                {
                    b.HasOne("Diploma.DataContext.ExtremistOrg", "ExtremistOrg")
                        .WithMany("Cases")
                        .HasForeignKey("ExtremistOrgID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.DataContext.Gender", "Gender")
                        .WithMany("Cases")
                        .HasForeignKey("GenderID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.DataContext.Nationality", "Nationality")
                        .WithMany("Cases")
                        .HasForeignKey("NationalityID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diploma.DataContext.Profile", "Profile")
                        .WithMany("Cases")
                        .HasForeignKey("ProfileID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
