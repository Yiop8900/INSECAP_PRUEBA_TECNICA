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
    public class AsignacionCursosAlusController : Controller
    {
        private readonly CapacitacionesContext _context;

        public AsignacionCursosAlusController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: AsignacionCursosAlus
        public async Task<IActionResult> Index()
        {
            var capacitacionesContext = _context.AsignacionCursosAlus.Include(a => a.CodigoCursoNavigation).Include(a => a.CodigoSalaNavigation).Include(a => a.IdBimestreNavigation).Include(a => a.RunAlumnoNavigation);
            return View(await capacitacionesContext.ToListAsync());
        }

        // GET: AsignacionCursosAlus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosAlu = await _context.AsignacionCursosAlus
                .Include(a => a.CodigoCursoNavigation)
                .Include(a => a.CodigoSalaNavigation)
                .Include(a => a.IdBimestreNavigation)
                .Include(a => a.RunAlumnoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionCursosAlu == null)
            {
                return NotFound();
            }

            return View(asignacionCursosAlu);
        }

        // GET: AsignacionCursosAlus/Create
        public IActionResult Create()
        {
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso");
            ViewData["CodigoSala"] = new SelectList(_context.Salas, "CodigoSala", "CodigoSala");
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre");
            ViewData["RunAlumno"] = new SelectList(_context.Alumnos, "RunAlumno", "RunAlumno");
            return View();
        }

        // POST: AsignacionCursosAlus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAsignacion,CodigoCurso,CodigoSala,RunAlumno,IdBimestre")] AsignacionCursosAlu asignacionCursosAlu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacionCursosAlu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosAlu.CodigoCurso);
            ViewData["CodigoSala"] = new SelectList(_context.Salas, "CodigoSala", "CodigoSala", asignacionCursosAlu.CodigoSala);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosAlu.IdBimestre);
            ViewData["RunAlumno"] = new SelectList(_context.Alumnos, "RunAlumno", "RunAlumno", asignacionCursosAlu.RunAlumno);
            return View(asignacionCursosAlu);
        }

        // GET: AsignacionCursosAlus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosAlu = await _context.AsignacionCursosAlus.FindAsync(id);
            if (asignacionCursosAlu == null)
            {
                return NotFound();
            }
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosAlu.CodigoCurso);
            ViewData["CodigoSala"] = new SelectList(_context.Salas, "CodigoSala", "CodigoSala", asignacionCursosAlu.CodigoSala);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosAlu.IdBimestre);
            ViewData["RunAlumno"] = new SelectList(_context.Alumnos, "RunAlumno", "RunAlumno", asignacionCursosAlu.RunAlumno);
            return View(asignacionCursosAlu);
        }

        // POST: AsignacionCursosAlus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,CodigoCurso,CodigoSala,RunAlumno,IdBimestre")] AsignacionCursosAlu asignacionCursosAlu)
        {
            if (id != asignacionCursosAlu.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacionCursosAlu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsignacionCursosAluExists(asignacionCursosAlu.IdAsignacion))
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
            ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosAlu.CodigoCurso);
            ViewData["CodigoSala"] = new SelectList(_context.Salas, "CodigoSala", "CodigoSala", asignacionCursosAlu.CodigoSala);
            ViewData["IdBimestre"] = new SelectList(_context.Bimestres, "IdBimestre", "IdBimestre", asignacionCursosAlu.IdBimestre);
            ViewData["RunAlumno"] = new SelectList(_context.Alumnos, "RunAlumno", "RunAlumno", asignacionCursosAlu.RunAlumno);
            return View(asignacionCursosAlu);
        }

        // GET: AsignacionCursosAlus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asignacionCursosAlu = await _context.AsignacionCursosAlus
                .Include(a => a.CodigoCursoNavigation)
                .Include(a => a.CodigoSalaNavigation)
                .Include(a => a.IdBimestreNavigation)
                .Include(a => a.RunAlumnoNavigation)
                .FirstOrDefaultAsync(m => m.IdAsignacion == id);
            if (asignacionCursosAlu == null)
            {
                return NotFound();
            }

            return View(asignacionCursosAlu);
        }

        // POST: AsignacionCursosAlus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var asignacionCursosAlu = await _context.AsignacionCursosAlus.FindAsync(id);
            if (asignacionCursosAlu != null)
            {
                _context.AsignacionCursosAlus.Remove(asignacionCursosAlu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionCursosAluExists(int id)
        {
            return _context.AsignacionCursosAlus.Any(e => e.IdAsignacion == id);
        }
    }
}
