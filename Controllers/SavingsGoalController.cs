using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinGoals_DotNet.Data;
using FinGoals_DotNet.Models;

namespace FinGoals_DotNet.Controllers
{
    public class SavingsGoalController : Controller
    {
        private readonly SavingsGoalContext _context;

        public SavingsGoalController(SavingsGoalContext context)
        {
            _context = context;
        }

        // GET: SavingsGoals
        public async Task<IActionResult> Index()
        {
            return View(await _context.SavingsGoals.ToListAsync());
        }

        // GET: SavingsGoals/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (savingsGoal == null)
            {
                return NotFound();
            }

            return View(savingsGoal);
        }

        // GET: SavingsGoals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavingsGoals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,Name,Amount,Description,IsComplete")] SavingsGoal savingsGoal)
        {
            if (ModelState.IsValid)
            {
                _context.Add(savingsGoal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(savingsGoal);
        }

        // GET: SavingsGoals/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoals.FindAsync(id);
            if (savingsGoal == null)
            {
                return NotFound();
            }
            return View(savingsGoal);
        }

        // POST: SavingsGoals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("Id,UserId,Name,Amount,Description,IsComplete")] SavingsGoal savingsGoal)
        {
            if (id != savingsGoal.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(savingsGoal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SavingsGoalExists(savingsGoal.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(savingsGoal);
        }

        // GET: SavingsGoals/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoals
                .FirstOrDefaultAsync(m => m.Id == id);
            if (savingsGoal == null)
            {
                return NotFound();
            }

            return View(savingsGoal);
        }

        // POST: SavingsGoals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var savingsGoal = await _context.SavingsGoals.FindAsync(id);
            _context.SavingsGoals.Remove(savingsGoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavingsGoalExists(long id)
        {
            return _context.SavingsGoals.Any(e => e.Id == id);
        }
    }
}
