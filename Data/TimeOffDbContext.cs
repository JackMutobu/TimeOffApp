using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeOffApp.Models;

namespace TimeOffApp.Data
{
    public class TimeOffDbContext : IdentityDbContext<User>
    {
        public TimeOffDbContext(DbContextOptions<TimeOffDbContext> options)
            : base(options)
        {
        }

        public DbSet<TimeOff> TimeOffs { get; set; } = null!;
    }
}