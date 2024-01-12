using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vaccinecalend
{
    public class VaccineCalendarContext : DbContext
    {

        public DbSet<Vaccinated> Vaccinated { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public DbSet<MedicalOrganization> MedicalOrganizations {get; set;}
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<ReactionOnVaccination> Reactions { get; set; }
        public DbSet<Vaccine> Vaccines { get; set; }

        public DbSet<VaccineComponent> Components { get; set; }
        public DbSet<CompleteComponent> ComponentsComplete { get; set; }
        public DbSet<CompleteVaccineComponent> CompleteVaccines { get; set; }
        public DbSet<VaccinationDisease> VaccinationDiseases { get; set; }
        public DbSet<RecordToVaccination> Records { get; set; }

        public DbSet<VaccinationDiary> vaccinationDiary { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=vac;Username=postgres;Password=1");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompleteVaccineComponent>()
                .HasKey(c => new { c.CompleteComponentId, c.ComponentId });
            modelBuilder.Entity<VaccinationDisease>()
                .HasKey(c => new { c.VaccinationId, c.DiseaseId });
        }
    }
}
