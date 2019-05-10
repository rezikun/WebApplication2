using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TitlesController : Controller
    {
        private readonly DBFCLUBSContext _context;

        public TitlesController(DBFCLUBSContext context)
        {
            _context = context;
        }

        // GET: Titles
        public async Task<IActionResult> Index()
        {
            var dBFCLUBSContext = _context.Titles.Include(t => t.Federation);
            return View(await dBFCLUBSContext.ToListAsync());
        }

        // GET: Titles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titles = await _context.Titles
                .Include(t => t.Federation)
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (titles == null)
            {
                return NotFound();
            }

            return View(titles);
        }

        // GET: Titles/Create
        public IActionResult Create()
        {
            ViewData["FederationId"] = new SelectList(_context.Federations, "FederationId", "FederationName");
            return View();
        }

        // POST: Titles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TitleId,TitleName,FederationId")] Titles titles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(titles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FederationId"] = new SelectList(_context.Federations, "FederationId", "FederationName", titles.FederationId);
            return View(titles);
        }

        // GET: Titles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titles = await _context.Titles.FindAsync(id);
            if (titles == null)
            {
                return NotFound();
            }
            ViewData["FederationId"] = new SelectList(_context.Federations, "FederationId", "FederationName", titles.FederationId);
            return View(titles);
        }

        // POST: Titles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TitleId,TitleName,FederationId")] Titles titles)
        {
            if (id != titles.TitleId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(titles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TitlesExists(titles.TitleId))
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
            ViewData["FederationId"] = new SelectList(_context.Federations, "FederationId", "FederationName", titles.FederationId);
            return View(titles);
        }

        // GET: Titles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var titles = await _context.Titles
                .Include(t => t.Federation)
                .FirstOrDefaultAsync(m => m.TitleId == id);
            if (titles == null)
            {
                return NotFound();
            }

            return View(titles);
        }

        // POST: Titles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var titles = await _context.Titles.FindAsync(id);
            _context.Titles.Remove(titles);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TitlesExists(int id)
        {
            return _context.Titles.Any(e => e.TitleId == id);
        }
    }
}
