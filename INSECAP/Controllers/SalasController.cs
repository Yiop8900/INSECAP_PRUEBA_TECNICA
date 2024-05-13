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
    public class SalasController : Controller
    {
        private readonly CapacitacionesContext _context;

        public SalasController(CapacitacionesContext context)
        {
            _context = context;
        }

        // GET: Salas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Salas.ToListAsync());
        }

        // GET: Salas/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.CodigoSala == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // GET: Salas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CodigoSala,CapacidadMaxima,CaracteristicasEspeciales")] Sala sala)
        {
            if (ModelState.IsValid)
            {
                var existingSala = await _context.Salas.FirstOrDefaultAsync(a => a.CodigoSala == sala.CodigoSala);
                if (existingSala != null)
                {
                    TempData["MensajeError"] = "Esta sala ya se encuentra registrada.";
                }
                _context.Add(sala);
                await _context.SaveChangesAsync();
                TempData["MensajeExito"] = "Sala agregada con Exito.";
                return RedirectToAction(nameof(Create));
            }
            return View(sala);
        }

        // GET: Salas/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas.FindAsync(id);
            if (sala == null)
            {
                return NotFound();
            }
            return View(sala);
        }

        // POST: Salas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("CodigoSala,CapacidadMaxima,CaracteristicasEspeciales")] Sala sala)
        {
            if (id != sala.CodigoSala)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sala);
                    TempData["MensajeExito"] = "Sala Editada Exitosamente.";
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Edit));
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    TempData["MensajeError"] = "Error al editar: " + ex.Message;
                    if (!SalaExists(sala.CodigoSala))
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
            return View(sala);
        }

        // GET: Salas/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sala = await _context.Salas
                .FirstOrDefaultAsync(m => m.CodigoSala == id);
            if (sala == null)
            {
                return NotFound();
            }

            return View(sala);
        }

        // POST: Salas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var sala = await _context.Salas.FindAsync(id);
            if (sala != null)
            {
                _context.Salas.Remove(sala);
            }

            await _context.SaveChangesAsync();
            TempData["MensajeExito"] = "Sala Eliminada Exitosamente.";
            return RedirectToAction(nameof(Index));
        }

        private bool SalaExists(string id)
        {
            return _context.Salas.Any(e => e.CodigoSala == id);
        }
    }
}
