using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql;

namespace Diploma.DataContext
{
    class DiplomaDataContext : DbContext
    {
        public DbSet<Case> Cases { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Org> Orgs { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<AccessModel>AccessModels { get; set; }
        public DbSet<Position>Positions { get; set; }
        public DbSet<Rank> Ranks { get; set; }

        public DiplomaDataContext()
        {

            //Database.EnsureCreated();
            //Database.Migrate();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=127.0.0.1;user=dbuser;password=;database=;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasAlternateKey(u => new { u.PrivateNumber });
            modelBuilder.Entity<Case>().HasAlternateKey(u => new { u.CaseNumber });

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Org)
                .WithMany(e => e.Cases)
                .HasForeignKey(c => c.OrgID);

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Profile)
                .WithMany(p => p.Cases)
                .HasForeignKey(c => c.ProfileID);
           
            modelBuilder.Entity<Case>()
                .HasOne(n => n.Nationality)
                .WithMany(e => e.Cases)
                .HasForeignKey(n => n.NationalityID);

            modelBuilder.Entity<Case>()
                .HasOne(c => c.Gender)
                .WithMany(p => p.Cases)
                .HasForeignKey(c => c.GenderID);
        }
    }
}