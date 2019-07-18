using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinGoals.Models;

namespace FinGoals.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SavingsGoalController : ControllerBase
    {
        private readonly SavingsGoalContext _context;

        public SavingsGoalController(SavingsGoalContext context)
        {
            _context = context;
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
    }
}