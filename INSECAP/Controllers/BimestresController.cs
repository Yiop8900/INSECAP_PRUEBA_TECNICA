using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using INSECAP.Models;

namespace INSECAP.Controllers
{
    public class BimestresController : Controller
    {
        private readonly CapacitacionesContext _context;

        public BimestresController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: Bimestres
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bimestres.ToListAsync());
        }

        // GET: Bimestres/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestres
                .FirstOrDefaultAsync(m => m.IdBimestre == id);
            if (bimestre == null)
            {
                return NotFound();
            }

            return View(bimestre);
        }

        // GET: Bimestres/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bimestres/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdBimestre,Anio,NumeroBimestre,FechaInicio,FechaFin")] Bimestre bimestre)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bimestre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bimestre);
        }

        // GET: Bimestres/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestres.FindAsync(id);
            if (bimestre == null)
            {
                return NotFound();
            }
            return View(bimestre);
        }

        // POST: Bimestres/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdBimestre,Anio,NumeroBimestre,FechaInicio,FechaFin")] Bimestre bimestre)
        {
            if (id != bimestre.IdBimestre)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bimestre);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BimestreExists(bimestre.IdBimestre))
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
            return View(bimestre);
        }

        // GET: Bimestres/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bimestre = await _context.Bimestres
                .FirstOrDefaultAsync(m => m.IdBimestre == id);
            if (bimestre == null)
            {
                return NotFound();
            }

            return View(bimestre);
        }

        // POST: Bimestres/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bimestre = await _context.Bimestres.FindAsync(id);
            if (bimestre != null)
            {
                _context.Bimestres.Remove(bimestre);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BimestreExists(int id)
        {
            return _context.Bimestres.Any(e => e.IdBimestre == id);
        }
    }
}
