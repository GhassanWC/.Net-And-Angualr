using Microsoft.EntityFrameworkCore;
using webApi1.Entities;

namespace webApi1.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<AppUser> Users { get; set; }
    }
}
