using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinGoals.Models;

namespace FinGoals.Controllers
{
    [Route("api/SavingsGoal")]
    [ApiController]
    public class SavingsGoalController : ControllerBase
    {
        private readonly SavingsGoalContext _context;

        public SavingsGoalController(SavingsGoalContext context)
        {
            _context = context;

            if (_context.SavingsGoals.Count() == 0)
            {
                // Create a new SavingsGoal if collection is empty,
                // which means you can't delete all SavingsGoals.
                _context.SavingsGoals.Add(new SavingsGoal
                {
                    Name = "First Goal",
                    Description = "This is your first Savings Goal",
                    Amount = 1.0
                });
                _context.SaveChanges();
            }
        }

        // GET: api/SavingsGoal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SavingsGoal>>> GetSavingsGoals()
        {
            return await _context.SavingsGoals.ToListAsync();
        }

        // GET: api/SavingsGoal/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SavingsGoal>> GetSavingsGoal(long id)
        {
            var SavingsGoal = await _context.SavingsGoals.FindAsync(id);

            if (SavingsGoal == null)
            {
                return NotFound();
            }

            return SavingsGoal;
        }

        //POST: api/SavingsGoal
        [HttpPost]
        public async Task<ActionResult<SavingsGoal>> PostSavingsGoal(SavingsGoal item)
        {
            _context.SavingsGoals.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSavingsGoal), new { id = item.Id}, item);
        }
    }
}