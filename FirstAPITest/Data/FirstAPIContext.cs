using Microsoft.EntityFrameworkCore;
using FirstAPITest.Models;

namespace FirstAPITest.Data
{
    public class FirstAPIContext : DbContext
    {
        public FirstAPIContext(DbContextOptions<FirstAPIContext> options):base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Microcontroller>().HasData(
                new Microcontroller()
                {
                    Id = 1,
                    Model = "ESP32S3",
                    Manufacturer = "Espressif",
                    ClockFz = 480
                },
                new Microcontroller()
                {
                    Id = 2,
                    Model = "ESP32C3",
                    Manufacturer = "Espressif",
                    ClockFz = 240
                },
                new Microcontroller()
                {
                    Id = 3,
                    Model = "UNO",
                    Manufacturer = "Arduino",
                    ClockFz = 16
                },
                new Microcontroller()
                {
                    Id = 4,
                    Model = "Nano",
                    Manufacturer = "Arduino",
                    ClockFz = 16
                }
                );
        }
        public DbSet<Microcontroller> Microcontrollers { get; set; } 
    }
}
