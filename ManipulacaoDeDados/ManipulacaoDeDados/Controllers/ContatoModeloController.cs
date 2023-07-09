using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ManipulacaoDeDados.Data;
using ManipulacaoDeDados.Models;

namespace ManipulacaoDeDados.Controllers
{
    public class ContatoModeloController : Controller
    {
        private readonly BancoContexto _context;

        public ContatoModeloController(BancoContexto context)
        {
            _context = context;
        }

        // GET: ContatoModelo
        public async Task<IActionResult> Index()
        {
              return View(await _context.Contatos.ToListAsync());
        }

        // GET: ContatoModelo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModelo = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModelo == null)
            {
                return NotFound();
            }

            return View(contatoModelo);
        }

        // GET: ContatoModelo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ContatoModelo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,nome,email,telemovel")] ContatoModelo contatoModelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contatoModelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contatoModelo);
        }

        // GET: ContatoModelo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModelo = await _context.Contatos.FindAsync(id);
            if (contatoModelo == null)
            {
                return NotFound();
            }
            return View(contatoModelo);
        }

        // POST: ContatoModelo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,nome,email,telemovel")] ContatoModelo contatoModelo)
        {
            if (id != contatoModelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contatoModelo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContatoModeloExists(contatoModelo.Id))
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
            return View(contatoModelo);
        }

        // GET: ContatoModelo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Contatos == null)
            {
                return NotFound();
            }

            var contatoModelo = await _context.Contatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contatoModelo == null)
            {
                return NotFound();
            }

            return View(contatoModelo);
        }

        // POST: ContatoModelo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Contatos == null)
            {
                return Problem("Entity set 'BancoContexto.Contatos'  is null.");
            }
            var contatoModelo = await _context.Contatos.FindAsync(id);
            if (contatoModelo != null)
            {
                _context.Contatos.Remove(contatoModelo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContatoModeloExists(int id)
        {
          return _context.Contatos.Any(e => e.Id == id);
        }
    }
}
