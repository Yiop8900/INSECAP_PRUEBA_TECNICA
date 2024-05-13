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
    public class AlumnoesController : Controller
    {
        private readonly CapacitacionesContext _context;


        public AlumnoesController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: Alumnoes
        public async Task<IActionResult> Index()
        {
            if (TempData.ContainsKey("MensajeExito"))
            {
                // Si es así, pasa el mensaje a la vista
                ViewBag.MensajeExito = TempData["MensajeExito"];
            }

            return View(await _context.Alumnos.ToListAsync());
        }

        // GET: Alumnoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.RunAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }
                             
            return View(alumno);
        }

        // GET: Alumnoes/Create
        public IActionResult Create()
        {
            
            return View();
        }

        // POST: Alumnoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RunAlumno,DvAlumno,Nombre,Apellido,FechaNacimiento,Genero")] Alumno alumno)
        {
            if (ModelState.IsValid)
            {
                // Verifica si el alumno ya existe en la base de datos
                var existingAlumno = await _context.Alumnos.FirstOrDefaultAsync(a => a.RunAlumno == alumno.RunAlumno);
                if (existingAlumno != null)
                {
                    TempData["MensajeError"] = "Este alumno ya se encuentra registrado.";
                    return RedirectToAction(nameof(Create));
                }

                // Si el alumno no existe, guarda el nuevo alumno en la base de datos
                _context.Add(alumno);
                await _context.SaveChangesAsync();

                // Establece un mensaje de éxito en TempData
                TempData["MensajeExito"] = "Alumno guardado exitosamente.";
                return RedirectToAction(nameof(Create));
            }

            return View(alumno);
        }

        // GET: Alumnoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            return View(alumno);
        }

        // POST: Alumnoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RunAlumno,DvAlumno,Nombre,Apellido,FechaNacimiento,Genero")] Alumno alumno)
        {
            if (id != alumno.RunAlumno)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alumno);

                    TempData["MensajeExito"] = "Alumno Editado Exitosamente.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["MensajeError"] = "Error al editar: " + ex.Message;
                    if (!AlumnoExists(alumno.RunAlumno))
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
            return View(alumno);
        }

        // GET: Alumnoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alumno = await _context.Alumnos
                .FirstOrDefaultAsync(m => m.RunAlumno == id);
            if (alumno == null)
            {
                return NotFound();
            }

            return View(alumno);
        }

        // POST: Alumnoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alumno = await _context.Alumnos.FindAsync(id);
            if (alumno != null)
            {
                _context.Alumnos.Remove(alumno);
                
            }

            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = "Alumno Eliminado Exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool AlumnoExists(int id)
        {
            return _context.Alumnos.Any(e => e.RunAlumno == id);
        }
    }
}
