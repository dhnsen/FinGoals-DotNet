using Microsoft.EntityFrameworkCore;

namespace FinGoals.Models
{
    public class SavingsGoalContext : DbContext
    {
        public SavingsGoalContext(DbContextOptions<SavingsGoalContext> options)
                : base(options)
        {
        }

        public DbSet<SavingsGoal> SavingsGoals { get; set; }
    }
}