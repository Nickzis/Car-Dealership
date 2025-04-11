using Microsoft.EntityFrameworkCore;

namespace Fitness_Tracker.Model
{
    public class TrackerContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Querie> Queries { get; set; }
        public object Querie { get; internal set; }
        public IQueryable<Querie> Querries { get; internal set; }

        public TrackerContext(DbContextOptions options) :base(options)
        {
            
        }
    }
}
