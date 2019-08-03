using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinGoals.Models;

namespace FinGoals.Controllers
{

    public class GoalController : Controller
    {
        private readonly GoalContext _context;

        public GoalController(GoalContext context)
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

        // GET: Goal
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: Goal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var goal = await _context.Goals.FindAsync(id);
            if (goal == null)
            {
                return NotFound();
            }
            return View(goal);
        }
    }
}