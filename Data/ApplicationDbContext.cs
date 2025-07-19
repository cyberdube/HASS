using Microsoft.EntityFrameworkCore;

using HASS_v1.Models;



namespace HASS_v1.Data

{

    public class ApplicationDbContext : DbContext

    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)

          : base(options)

        {

        }



        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public DbSet<Appointment> Appointments { get; set; }

        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);



            // Seed admin user


            modelBuilder.Entity<User>().HasData(new User
            {
                UserId = 1,
                Username = "admin",
                Password = "admin123",
                Role = "Admin"
            });


        }

    }

}

