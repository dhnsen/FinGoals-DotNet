using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinGoals.Models;

namespace FinGoals.Controllers
{
    public class SavingsGoalController : Controller
    {
        private readonly SavingsGoalContext _context;

        public SavingsGoalController(SavingsGoalContext context)
        {
            _context = context;
        }

        // GET: SavingsGoal
        public async Task<IActionResult> Index()
        {
            return View();
        }

        // GET: SavingsGoal/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (savingsGoal == null)
            {
                return NotFound();
            }

            return View(savingsGoal);
        }

        // GET: SavingsGoal/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SavingsGoal/Create
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

        // GET: SavingsGoal/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoal.FindAsync(id);
            if (savingsGoal == null)
            {
                return NotFound();
            }
            return View(savingsGoal);
        }

        // POST: SavingsGoal/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,Name,Amount,Description,IsComplete")] SavingsGoal savingsGoal)
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

        // GET: SavingsGoal/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var savingsGoal = await _context.SavingsGoal
                .FirstOrDefaultAsync(m => m.Id == id);
            if (savingsGoal == null)
            {
                return NotFound();
            }

            return View(savingsGoal);
        }

        // POST: SavingsGoal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var savingsGoal = await _context.SavingsGoal.FindAsync(id);
            _context.SavingsGoal.Remove(savingsGoal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SavingsGoalExists(int id)
        {
            return _context.SavingsGoal.Any(e => e.Id == id);
        }
    }
}
