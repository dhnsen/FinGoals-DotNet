using Microsoft.EntityFrameworkCore;

namespace FinGoals.Models
{
    public class GoalContext : DbContext
    {
        public GoalContext(DbContextOptions<GoalContext> options)
            : base(options)
        {
        }

        public DbSet<Goal> Goals { get; set; }
    }
}