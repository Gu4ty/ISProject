using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ISProject.Data;
using ISProject.Data.Models;

namespace ISProject.Controllers
{
    public class SellController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SellController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sell
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sells.Include(s => s.Product).Include(s => s.User);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sell/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // GET: Sell/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            ViewData["UserId"] = new SelectList(_context.Users2, "Id", "Id");
            return View();
        }

        // POST: Sell/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UserId,ProductId,Price,Units,Date")] Sell sell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users2, "Id", "Id", sell.UserId);
            return View(sell);
        }

        // GET: Sell/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells.FindAsync(id);
            if (sell == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users2, "Id", "Id", sell.UserId);
            return View(sell);
        }

        // POST: Sell/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,ProductId,Price,Units,Date")] Sell sell)
        {
            if (id != sell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellExists(sell.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", sell.ProductId);
            ViewData["UserId"] = new SelectList(_context.Users2, "Id", "Id", sell.UserId);
            return View(sell);
        }

        // GET: Sell/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sell = await _context.Sells
                .Include(s => s.Product)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sell == null)
            {
                return NotFound();
            }

            return View(sell);
        }

        // POST: Sell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sell = await _context.Sells.FindAsync(id);
            _context.Sells.Remove(sell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellExists(int id)
        {
            return _context.Sells.Any(e => e.Id == id);
        }
    }
}
