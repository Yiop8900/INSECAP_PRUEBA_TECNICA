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
    public class AsignacionCursosProesController : Controller
    {
        private readonly CapacitacionesContext _context;

        public AsignacionCursosProesController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: AsignacionCursosProes
        public async Task<IActionResult> Index()
        {
            var capacitacionesContext = _context.AsignacionCursosPros.Include(a => a.CodigoCursoNavigation).Include(a => a.IdBimestreNavigation).Include(a => a.RunProfesorNavigation);
            return View(await capacitacionesContext.ToListAsync());
        }

        // GET: AsignacionCursosProes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosPro = await _context.AsignacionCursosPros
                .Include(a => a.CodigoCursoNavigation)
                .Include(a => a.IdBimestreNavigation)
                .Include(a => a.RunProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionCursosPro == null)
            {
                return NotFound();
            }

            return View(asignacionCursosPro);
        }

        // GET: AsignacionCursosProes/Create
        public IActionResult Create()
        {
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso");
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre");
            ViewData["RunProfesor"] = new SelectList(_context.Profesors, "RunProfesor", "RunProfesor");
            return View();
        }

        // POST: AsignacionCursosProes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,CodigoCurso,RunProfesor,IdBimestre")] AsignacionCursosPro asignacionCursosPro)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionCursosPro);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosPro.CodigoCurso);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosPro.IdBimestre);
            ViewData["RunProfesor"] = new SelectList(_context.Profesors, "RunProfesor", "RunProfesor", asignacionCursosPro.RunProfesor);
            return View(asignacionCursosPro);
        }

        // GET: AsignacionCursosProes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosPro = await _context.AsignacionCursosPros.FindAsync(id);
            if (asignacionCursosPro == null)
            {
                return NotFound();
            }
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosPro.CodigoCurso);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosPro.IdBimestre);
            ViewData["RunProfesor"] = new SelectList(_context.Profesors, "RunProfesor", "RunProfesor", asignacionCursosPro.RunProfesor);
            return View(asignacionCursosPro);
        }

        // POST: AsignacionCursosProes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,CodigoCurso,RunProfesor,IdBimestre")] AsignacionCursosPro asignacionCursosPro)
        {
            if (id != asignacionCursosPro.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionCursosPro);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionCursosProExists(asignacionCursosPro.IdAsignacion))
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
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosPro.CodigoCurso);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosPro.IdBimestre);
            ViewData["RunProfesor"] = new SelectList(_context.Profesors, "RunProfesor", "RunProfesor", asignacionCursosPro.RunProfesor);
            return View(asignacionCursosPro);
        }

        // GET: AsignacionCursosProes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosPro = await _context.AsignacionCursosPros
                .Include(a => a.CodigoCursoNavigation)
                .Include(a => a.IdBimestreNavigation)
                .Include(a => a.RunProfesorNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionCursosPro == null)
            {
                return NotFound();
            }

            return View(asignacionCursosPro);
        }

        // POST: AsignacionCursosProes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionCursosPro = await _context.AsignacionCursosPros.FindAsync(id);
            if (asignacionCursosPro != null)
            {
                _context.AsignacionCursosPros.Remove(asignacionCursosPro);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionCursosProExists(int id)
        {
            return _context.AsignacionCursosPros.Any(e => e.IdAsignacion == id);
        }
    }
}
