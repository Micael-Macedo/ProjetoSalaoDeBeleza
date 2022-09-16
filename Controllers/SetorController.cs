using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Models;

namespace ProjetoSalaoDeBeleza.Controllers
{
    public class SetorController : Controller
    {
        private readonly ProjetoSalaoContext _context;

        public SetorController(ProjetoSalaoContext context)
        {
            _context = context;
        }

        // GET: Setor
        public async Task<IActionResult> Index()
        {
              return _context.Setores != null ? 
                          View(await _context.Setores.ToListAsync()) :
                          Problem("Entity set 'ProjetoSalaoContext.Setores'  is null.");
        }

        // GET: Setor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Setores == null)
            {
                return NotFound();
            }

            var setor = await _context.Setores
                .FirstOrDefaultAsync(m => m.SetorId == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // GET: Setor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Setor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SetorId,Nome,Descricao")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(setor);
        }

        // GET: Setor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Setores == null)
            {
                return NotFound();
            }

            var setor = await _context.Setores.FindAsync(id);
            if (setor == null)
            {
                return NotFound();
            }
            return View(setor);
        }

        // POST: Setor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SetorId,Nome,Descricao")] Setor setor)
        {
            if (id != setor.SetorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(setor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SetorExists(setor.SetorId))
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
            return View(setor);
        }

        // GET: Setor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Setores == null)
            {
                return NotFound();
            }

            var setor = await _context.Setores
                .FirstOrDefaultAsync(m => m.SetorId == id);
            if (setor == null)
            {
                return NotFound();
            }

            return View(setor);
        }

        // POST: Setor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Setores == null)
            {
                return Problem("Entity set 'ProjetoSalaoContext.Setores'  is null.");
            }
            var setor = await _context.Setores.FindAsync(id);
            if (setor != null)
            {
                _context.Setores.Remove(setor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SetorExists(int id)
        {
          return (_context.Setores?.Any(e => e.SetorId == id)).GetValueOrDefault();
        }
    }
}
