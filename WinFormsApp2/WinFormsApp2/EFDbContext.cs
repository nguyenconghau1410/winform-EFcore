using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp2.models;

namespace WinFormsApp2
{
    internal class EFDbContext : DbContext
    {
        public DbSet<Sympton> Symptons { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public void ConfigureServices(IServiceCollection services)
            => services.AddDbContext<EFDbContext>();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer(ConfigurationManager.ConnectionStrings["db"].ConnectionString);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Disease>().HasData(
                new Disease
                {
                    DiseaseID = "Diabetes",
                    Name = "Bệnh tiểu đường"
                },
                new Disease
                {
                    DiseaseID = "HeartDisease",
                    Name = "Bệnh cơ tim"
                },
                new Disease
                {
                    DiseaseID = "LiverDisease",
                    Name = "Bệnh gan"
                },
                new Disease
                {
                    DiseaseID = "DigestiveDiseases",
                    Name = "Bệnh tiêu hóa"
                },
                new Disease
                {
                    DiseaseID = "KidneyDisease",
                    Name = "Bệnh thận"
                },
                new Disease
                {
                    DiseaseID = "LungDisease",
                    Name = "Bệnh phổi"
                },
                new Disease
                {
                    DiseaseID = "IntestinalDisease",
                    Name = "Bệnh đường ruột"
                },
                new Disease
                {
                    DiseaseID = "Nephrolithiasis",
                    Name = "Bệnh sỏi thận"
                },
                new Disease
                {
                    DiseaseID = "Stomachache",
                    Name = "Bệnh đau dạ dày"
                },
                new Disease
                {
                    DiseaseID = "Colds",
                    Name = "Bệnh cảm"
                }
            );
        }
    }
}
