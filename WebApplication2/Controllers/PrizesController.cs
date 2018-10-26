using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FlashPoints.Data;
using FlashPoints.Models;

namespace WebApplication2.Controllers
{
    public class PrizesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PrizesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Prizes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Prize.ToListAsync());
        }

        // GET: Prizes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _context.Prize
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prize == null)
            {
                return NotFound();
            }

            return View(prize);
        }

        // GET: Prizes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Prizes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title,Description,PointPrice,ImagePath,CurrentInventory,Location,ActualCost")] Prize prize)
        {
            if (ModelState.IsValid)
            {
                _context.Add(prize);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(prize);
        }

        // GET: Prizes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _context.Prize.FindAsync(id);
            if (prize == null)
            {
                return NotFound();
            }
            return View(prize);
        }

        // POST: Prizes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title,Description,PointPrice,ImagePath,CurrentInventory,Location,ActualCost")] Prize prize)
        {
            if (id != prize.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(prize);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PrizeExists(prize.ID))
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
            return View(prize);
        }

        // GET: Prizes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var prize = await _context.Prize
                .FirstOrDefaultAsync(m => m.ID == id);
            if (prize == null)
            {
                return NotFound();
            }

            return View(prize);
        }

        // POST: Prizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var prize = await _context.Prize.FindAsync(id);
            _context.Prize.Remove(prize);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PrizeExists(int id)
        {
            return _context.Prize.Any(e => e.ID == id);
        }
    }
}
