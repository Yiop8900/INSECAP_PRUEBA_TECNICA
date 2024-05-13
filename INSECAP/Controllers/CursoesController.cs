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
    public class CursoesController : Controller
    {
        private readonly CapacitacionesContext _context;

        public CursoesController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: Cursoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cursos.ToListAsync());
        }

        // GET: Cursoes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // GET: Cursoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cursoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoCurso,NombreCurso")] Curso curso)
        {
            if (ModelState.IsValid)
            {
                var existingCurso = await _context.Cursos.FirstOrDefaultAsync(a => a.CodigoCurso == curso.CodigoCurso);
                if (existingCurso != null)
                {
                    TempData["MensajeError"] = "Este curso ya se encuentra registrado.";
                    return RedirectToAction(nameof(Create));
                }

                _context.Add(curso);
                await _context.SaveChangesAsync();
                TempData["MensajeExito"] = "Curso guardado exitosamente.";
                return RedirectToAction(nameof(Create));
            }
            return View(curso);
        }

        // GET: Cursoes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }
            return View(curso);
        }

        // POST: Cursoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoCurso,NombreCurso")] Curso curso)
        {
            if (id != curso.CodigoCurso)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curso);
                    TempData["MensajeExito"] = "Editado exitosamente.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["MensajeError"] = "Error al editar: " + ex.Message;
                    if (!CursoExists(curso.CodigoCurso))
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
            return View(curso);
        }

        // GET: Cursoes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curso = await _context.Cursos
                .FirstOrDefaultAsync(m => m.CodigoCurso == id);
            if (curso == null)
            {
                return NotFound();
            }

            return View(curso);
        }

        // POST: Cursoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso != null)
            {
                _context.Cursos.Remove(curso);
            }

            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = "Curso Eliminado Exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool CursoExists(string id)
        {
            return _context.Cursos.Any(e => e.CodigoCurso == id);
        }
    }
}
