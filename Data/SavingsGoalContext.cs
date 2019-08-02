using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinGoals_DotNet.Models;

namespace FinGoals_DotNet.Data
{
    public class SavingsGoalContext : DbContext
    {
        public DbSet<SavingsGoal> SavingsGoals { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=Blogging;Integrated Security=True");
        }
    }
}
