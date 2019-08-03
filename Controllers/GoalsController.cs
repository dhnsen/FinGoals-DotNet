using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinGoals.Models;

namespace FinGoals.Controllers
{

    public class GoalsController : Controller
    {
        private readonly GoalContext _context;

        public GoalsController(GoalContext context)
        {
            _context = context;

            if (_context.Goals.Count() == 0)
            {
                // Create a new Goal if collection is empty,
                // which means you can't delete all Goals.
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

        // GET: Goals
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Goals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals
                .FirstOrDefaultAsync(g => g.Id == id);
            if (goal == null)
            {
                return NotFound();
            }

            return View(goal);
        }
    }
}