using HousingAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HousingAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<HousingLocation> HousingLocations { get; set; }
    }
}