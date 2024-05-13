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

        // GET: AsignacionCursosAlus/Dettalles
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

        // GET: AsignacionCursosAlus/Crear
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
        public async Task<IActionResult> Create([Bind("CodigoCurso,CodigoSala,RunAlumno,IdBimestre")] AsignacionCursosAlu asignacionCursosAlu)
        {
            

            try
            {
                ModelState.Remove("CodigoCursoNavigation");
                ModelState.Remove("CodigoSalaNavigation");
                ModelState.Remove("RunAlumnoNavigation");
                ModelState.Remove("IdBimestreNavigation");
                if (ModelState.IsValid)
                {
                    var lastAsignacion = await _context.AsignacionCursosAlus.OrderByDescending(a => a.IdAsignacion).FirstOrDefaultAsync();
                    asignacionCursosAlu.IdAsignacion = (lastAsignacion != null ? lastAsignacion.IdAsignacion : 0) + 1;


                    var existingAsignacion = await _context.AsignacionCursosAlus.FirstOrDefaultAsync(a => a.IdAsignacion == asignacionCursosAlu.IdAsignacion);
                    if (existingAsignacion != null)
                    {
                        TempData["MensajeError"] = "Esta asignacion ya existe.";
                        return RedirectToAction(nameof(Create));

                    }
                    ViewData["CodigoCurso"] = new SelectList(_context.Cursos, "CodigoCurso", "CodigoCurso", asignacionCursosAlu.CodigoCurso);
                    ViewData["CodigoSala"] = new SelectList(_context.Salas, "CodigoSala", "CodigoSala", asignacionCursosAlu.CodigoSala);
                    ViewData["RunAlumno"] = new SelectList(_context.Alumnos, "RunAlumno", "RunAlumno", asignacionCursosAlu.RunAlumno);
                    ViewData["IdBimestre"] = new SelectList(_context.Bimestres.Select(b => new SelectListItem
                    {
                        Value = b.IdBimestre.ToString(),
                        Text = b.FechaInicio.ToString("dd/MM/yyyy") // Ajusta el formato de la fecha según tus necesidades
                    }), "Value", "Text");



                    _context.Add(asignacionCursosAlu);
                    await _context.SaveChangesAsync();
                    TempData["MensajeExito"] = "Asignado Correctamente.";

                    return RedirectToAction(nameof(Create));
                }
                return RedirectToAction(nameof(Create));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al guardar la asignación del curso: " + ex.Message);
                Console.WriteLine("Seguimiento de la pila: " + ex.StackTrace);
                // Manejo de la excepción
                TempData["MensajeError"] = "Error al guardar la asignación del curso: " + ex.Message;
                return RedirectToAction(nameof(Create));
            }
        }

        // GET: AsignacionCursosAlus/Editar
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

        // POST: AsignacionCursosAlus/Editar
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAsignacion,CodigoCurso,CodigoSala,RunAlumno,IdBimestre")] AsignacionCursosAlu asignacionCursosAlu)
        {
            ModelState.Remove("CodigoCursoNavigation");
            ModelState.Remove("CodigoSalaNavigation");
            ModelState.Remove("RunAlumnoNavigation");
            ModelState.Remove("IdBimestreNavigation");
            if (id != asignacionCursosAlu.IdAsignacion)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(asignacionCursosAlu);

                    TempData["MensajeExito"] = "Editado Correctamente.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["MensajeError"] = "Error al editar: " + ex.Message;
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

        // GET: AsignacionCursosAlus/Eliminar
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

        // POST: AsignacionCursosAlus/Eliminar
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
            TempData["MensajeExito"] = "Eliminado Correctamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool AsignacionCursosAluExists(int id)
        {
            return _context.AsignacionCursosAlus.Any(e => e.IdAsignacion == id);
        }
    }
}
