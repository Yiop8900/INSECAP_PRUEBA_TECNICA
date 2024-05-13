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
    public class ProfesorsController : Controller
    {
        private readonly CapacitacionesContext _context;

        public ProfesorsController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: Profesors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Profesors.ToListAsync());
        }

        // GET: Profesors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .FirstOrDefaultAsync(m => m.RunProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // GET: Profesors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Profesors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RunProfesor,DvProfesor,Nombre,Apellido")] Profesor profesor)
        {
            if (ModelState.IsValid)
            {
                var existingProfesor = await _context.Profesors.FirstOrDefaultAsync(a => a.RunProfesor == profesor.RunProfesor);
                if (existingProfesor != null)
                {
                    TempData["MensajeError"] = "Este profesor ya se encuentra registrado.";
                    return RedirectToAction(nameof(Create));
                }
                _context.Add(profesor);
                await _context.SaveChangesAsync();

                TempData["MensajeExito"] = "Profesor guardado exitosamente.";
                return RedirectToAction(nameof(Create));
            }
            return View(profesor);
        }

        // GET: Profesors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor == null)
            {
                return NotFound();
            }
            return View(profesor);
        }

        // POST: Profesors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RunProfesor,DvProfesor,Nombre,Apellido")] Profesor profesor)
        {
            if (id != profesor.RunProfesor)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profesor);

                    TempData["MensajeExito"] = "Profesor Editado Exitosamente.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["MensajeError"] = "Error al editar: " + ex.Message;
                    if (!ProfesorExists(profesor.RunProfesor))
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
            return View(profesor);
        }

        // GET: Profesors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profesor = await _context.Profesors
                .FirstOrDefaultAsync(m => m.RunProfesor == id);
            if (profesor == null)
            {
                return NotFound();
            }

            return View(profesor);
        }

        // POST: Profesors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var profesor = await _context.Profesors.FindAsync(id);
            if (profesor != null)
            {
                _context.Profesors.Remove(profesor);
            }

            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = "Profesor Eliminado Exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool ProfesorExists(int id)
        {
            return _context.Profesors.Any(e => e.RunProfesor == id);
        }
    }
}
