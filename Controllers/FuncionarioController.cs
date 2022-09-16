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
    public class FuncionarioController : Controller
    {
        private readonly ProjetoSalaoContext _context;

        public FuncionarioController(ProjetoSalaoContext context)
        {
            _context = context;
        }

        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var projetoSalaoContext = _context.Funcionarios.Include(f => f.Setor);
            return View(await projetoSalaoContext.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Setor)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            ViewData["SetorId"] = new SelectList(_context.Setores, "SetorId", "SetorId");
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FuncionarioId,Nome,Funcao,Matricula,TemCNH,Salario,SetorId")] Funcionario funcionario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(funcionario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SetorId"] = new SelectList(_context.Setores, "SetorId", "SetorId", funcionario.SetorId);
            return View(funcionario);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            ViewData["SetorId"] = new SelectList(_context.Setores, "SetorId", "SetorId", funcionario.SetorId);
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FuncionarioId,Nome,Funcao,Matricula,TemCNH,Salario,SetorId")] Funcionario funcionario)
        {
            if (id != funcionario.FuncionarioId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(funcionario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.FuncionarioId))
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
            ViewData["SetorId"] = new SelectList(_context.Setores, "SetorId", "SetorId", funcionario.SetorId);
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Funcionarios == null)
            {
                return NotFound();
            }

            var funcionario = await _context.Funcionarios
                .Include(f => f.Setor)
                .FirstOrDefaultAsync(m => m.FuncionarioId == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Funcionarios == null)
            {
                return Problem("Entity set 'ProjetoSalaoContext.Funcionarios'  is null.");
            }
            var funcionario = await _context.Funcionarios.FindAsync(id);
            if (funcionario != null)
            {
                _context.Funcionarios.Remove(funcionario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
          return (_context.Funcionarios?.Any(e => e.FuncionarioId == id)).GetValueOrDefault();
        }
    }
}
