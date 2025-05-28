using Microsoft.EntityFrameworkCore;

namespace ParkingApi.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<ParkingSession> ParkingSessions { get; set; }
    }
}
