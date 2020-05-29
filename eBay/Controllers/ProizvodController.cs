using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eBay.Models;
using Microsoft.AspNetCore.Authorization;

namespace eBay.Controllers
{
    public class ProizvodController : Controller
    {
        private readonly EBayContext _context;

        public ProizvodController(EBayContext context)
        {
            _context = context;
        }

        // GET: Proizvod
        public async Task<IActionResult> Index()
        {
            return View(await _context.Proizvod.ToListAsync());
        }

        // GET: Proizvod/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod
                .FirstOrDefaultAsync(m => m.ProizvodId == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // GET: Proizvod/Create
        [Authorize(Roles = "Prodavac")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Proizvod/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Prodavac")]
        public async Task<IActionResult> Create([Bind("Naziv,OpisProizvoda,Cijena,URLSlike")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                _context.Add(proizvod);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(proizvod);
        }

        // GET: Proizvod/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod.FindAsync(id);
            if (proizvod == null)
            {
                return NotFound();
            }
            return View(proizvod);
        }

        // POST: Proizvod/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Naziv,OpisProizvoda,Cijena,URLSlike")] Proizvod proizvod)
        {
            if (id != proizvod.ProizvodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(proizvod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProizvodExists(proizvod.ProizvodId))
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
            return View(proizvod);
        }

        // GET: Proizvod/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var proizvod = await _context.Proizvod
                .FirstOrDefaultAsync(m => m.ProizvodId == id);
            if (proizvod == null)
            {
                return NotFound();
            }

            return View(proizvod);
        }

        // POST: Proizvod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var proizvod = await _context.Proizvod.FindAsync(id);
            _context.Proizvod.Remove(proizvod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProizvodExists(int id)
        {
            return _context.Proizvod.Any(e => e.ProizvodId == id);
        }
    }
}
