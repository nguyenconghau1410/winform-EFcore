﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WinFormsApp2;

#nullable disable

namespace WinFormsApp2.Migrations
{
    [DbContext(typeof(EFDbContext))]
    [Migration("20231024083523_migration1")]
    partial class migration1
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WinFormsApp2.models.Disease", b =>
                {
                    b.Property<string>("DiseaseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DiseaseID");

                    b.ToTable("Diseases");

                    b.HasData(
                        new
                        {
                            DiseaseID = "Diabetes",
                            Name = "Bệnh tiểu đường"
                        },
                        new
                        {
                            DiseaseID = "HeartDisease",
                            Name = "Bệnh cơ tim"
                        },
                        new
                        {
                            DiseaseID = "LiverDisease",
                            Name = "Bệnh gan"
                        },
                        new
                        {
                            DiseaseID = "DigestiveDiseases",
                            Name = "Bệnh tiêu hóa"
                        },
                        new
                        {
                            DiseaseID = "KidneyDisease",
                            Name = "Bệnh thận"
                        },
                        new
                        {
                            DiseaseID = "LungDisease",
                            Name = "Bệnh phổi"
                        },
                        new
                        {
                            DiseaseID = "IntestinalDisease",
                            Name = "Bệnh đường ruột"
                        },
                        new
                        {
                            DiseaseID = "Nephrolithiasis",
                            Name = "Bệnh sỏi thận"
                        },
                        new
                        {
                            DiseaseID = "Stomachache",
                            Name = "Bệnh đau dạ dày"
                        },
                        new
                        {
                            DiseaseID = "Colds",
                            Name = "Bệnh cảm"
                        });
                });

            modelBuilder.Entity("WinFormsApp2.models.Sympton", b =>
                {
                    b.Property<string>("SymptonID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("DiseaseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SymptonID");

                    b.HasIndex("DiseaseID");

                    b.ToTable("Symptons");
                });

            modelBuilder.Entity("WinFormsApp2.models.Sympton", b =>
                {
                    b.HasOne("WinFormsApp2.models.Disease", "Disease")
                        .WithMany("Symptons")
                        .HasForeignKey("DiseaseID");

                    b.Navigation("Disease");
                });

            modelBuilder.Entity("WinFormsApp2.models.Disease", b =>
                {
                    b.Navigation("Symptons");
                });
#pragma warning restore 612, 618
        }
    }
}
