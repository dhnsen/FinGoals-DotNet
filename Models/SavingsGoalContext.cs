using Microsoft.EntityFrameworkCore;

public class SavingsGoalContext : DbContext 
{
    public SavingsGoalContext(DbContextOptions<SavingsGoalContext> options)
            : base(options)
        {
        }
}
