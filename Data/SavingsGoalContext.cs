using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinGoals.Data
{
    public class SavingsGoalContext : IdentityDbContext
    {
        public SavingsGoalContext(DbContextOptions<SavingsGoalContext> options)
            : base(options)
        {
        }
    }
}
