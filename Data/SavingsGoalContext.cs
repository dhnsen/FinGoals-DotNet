using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinGoals.Models;

    public class SavingsGoalContext : DbContext
    {
        public SavingsGoalContext (DbContextOptions<SavingsGoalContext> options)
            : base(options)
        {
        }

        public DbSet<FinGoals.Models.SavingsGoal> SavingsGoal { get; set; }
    }
