using Microsoft.EntityFrameworkCore;

namespace beltPlate.Models{
        public class UserContext : DbContext
        {
                public UserContext (DbContextOptions<UserContext> options) : base(options) {}
                public DbSet<User> Users { get; set; }
                public DbSet<Activity> Activities { get; set; }
                public DbSet<Rsvp> Rsvps { get; set; }
        }
}