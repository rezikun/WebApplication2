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
    public class ClubsController : Controller
    {
        private readonly DBFCLUBSContext _context;

        public ClubsController(DBFCLUBSContext context)
        {
            _context = context;
        }

        // GET: Clubs
        public async Task<IActionResult> Index()
        {
            var dBFCLUBSContext = _context.Clubs.Include(c => c.League);
            return View(await dBFCLUBSContext.ToListAsync());
        }

        // GET: Clubs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs
                .Include(c => c.League)
                .FirstOrDefaultAsync(m => m.ClubId == id);
            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // GET: Clubs/Create
        public IActionResult Create()
        {
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "LeagueName");
            return View();
        }

        // POST: Clubs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClubId,ClubName,Location,YearOfFoundation,LeagueId,Description")] Clubs clubs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "LeagueName", clubs.LeagueId);
            return View(clubs);
        }

        // GET: Clubs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs.FindAsync(id);
            if (clubs == null)
            {
                return NotFound();
            }
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "LeagueName", clubs.LeagueId);
            return View(clubs);
        }

        // POST: Clubs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ClubId,ClubName,Location,YearOfFoundation,LeagueId,Description")] Clubs clubs)
        {
            if (id != clubs.ClubId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubsExists(clubs.ClubId))
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
            ViewData["LeagueId"] = new SelectList(_context.Leagues, "LeagueId", "LeagueName", clubs.LeagueId);
            return View(clubs);
        }

        // GET: Clubs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubs = await _context.Clubs
                .Include(c => c.League)
                .FirstOrDefaultAsync(m => m.ClubId == id);
            if (clubs == null)
            {
                return NotFound();
            }

            return View(clubs);
        }

        // POST: Clubs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubs = await _context.Clubs.FindAsync(id);
            _context.Clubs.Remove(clubs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubsExists(int id)
        {
            return _context.Clubs.Any(e => e.ClubId == id);
        }
    }
}
