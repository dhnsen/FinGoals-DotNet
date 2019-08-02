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
    public class GoalController : ControllerBase
    {
        private readonly GoalContext _context;

        public GoalController(GoalContext context)
        {
            _context = context;

            if (_context.Goals.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Goals.Add(
                    new Goal
                    {
                        Name = "First Goal",
                        Amount = 1.00,
                        Description = "This is your first goal!"
                    }
                    );
                _context.SaveChanges();
            }
        }

        // GET: api/Goal
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Goal>>> GetGoals()
        {
            return await _context.Goals.ToListAsync();
        }
    }
}