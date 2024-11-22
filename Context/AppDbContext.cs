using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Register.Models;
using Register.Models.DTO;
using System.Threading;

namespace Register.Context
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = MyBase; 
                                        Integrated Security = true");
            optionsBuilder.UseLazyLoadingProxies(true);
        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Entity> Entity { get; set; }

        public DbSet<Carrier> Carrieres { get; set; }
        public DbSet<Qualification> Qualifications { get; set; }
        public DbSet<Category> Category { get; set; }

        public DbSet<Civil_Status> Civil_Status { get; set; }
        public DbSet<MenuProfil> MenuProfils { get; set; }

        public DbSet<Menu> Menus { get; set; }

       public DbSet<Profil> Profils { get; set; }

       // public DbSet<MenuProfile> MenuProfiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users").HasOne(u => u.Qualification)
                .WithMany(c => c.Users).HasForeignKey(u => u.QualificationId);

            modelBuilder.Entity<User>().ToTable("users").HasOne(u => u.Civil_Status)
                .WithMany(c => c.Users).HasForeignKey(u => u.Civil_StatusId);

            modelBuilder.Entity<User>().ToTable("users").HasOne(u => u.Profil)
              .WithMany(c => c.Users).HasForeignKey(u => u.ProfilId);




            modelBuilder.Entity<Entity>().ToTable("entity");

            modelBuilder.Entity<Qualification>().ToTable("qualification");

            modelBuilder.Entity<Carrier>().ToTable("carrieres");

            modelBuilder.Entity<User>()
           .HasMany(u => u.Carrieres)
           .WithOne(c => c.User)
           .HasForeignKey(c => c.UserId);


            modelBuilder.Entity<Qualification>()
           .HasMany(u => u.Carriers)
           .WithOne(c => c.Qualification)
           .HasForeignKey(c => c.QualificationId);


            modelBuilder.Entity<Civil_Status>()
          .HasMany(u => u.Carriers)
          .WithOne(c => c.Civil_Status)
          .HasForeignKey(c => c.Civil_StatusId);







            modelBuilder.Entity<MenuProfil>()
           .HasKey(mp => new { mp.MenuId, mp.ProfilId });

            modelBuilder.Entity<MenuProfil>()
                .HasOne(mp => mp.Menu)
                .WithMany(m => m.MenuProfils)
                .HasForeignKey(mp => mp.MenuId);

            modelBuilder.Entity<MenuProfil>()
                .HasOne(mp => mp.Profil)
                .WithMany(p => p.MenuProfils)
                .HasForeignKey(mp => mp.ProfilId);


            /* modelBuilder.Entity<Menu>()
            .HasMany(m => m.Profiles)
            .WithMany(p => p.Menus)
            .UsingEntity<Dictionary<string, object>>(
              "MenuProfileDto",
              j => j.HasOne<ProfileDto>().WithMany().HasForeignKey("ProfileDtoId"),
              j => j.HasOne<Menu>().WithMany().HasForeignKey("MenuId"));*/

        }
    }
}
