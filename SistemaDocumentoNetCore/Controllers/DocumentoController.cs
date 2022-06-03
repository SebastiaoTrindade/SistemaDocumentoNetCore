using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaDocumentoNetCore.AppData;
using SistemaDocumentoNetCore.Models;

namespace SistemaDocumentoNetCore.Controllers
{
    public class DocumentoController : Controller
    {
        private readonly AppDbContext _context;

        public DocumentoController(AppDbContext context)
        {
            _context = context;
        }        
        

        // GET: Documento
        public async Task<IActionResult> Index()
        {
              return _context.Documentos != null ? 
                          View(await _context.Documentos.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Documentos'  is null.");
        }

        // GET: Documento/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.DocumentoId == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }


        // GET: Documento/Create
        public IActionResult Create()
        {            
            return View();
        }

        // POST: Documento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DocumentoId,Codigo,Titulo,Processo,Categoria,Arquivo")] Documento documento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(documento);
                await _context.SaveChangesAsync();
                TempData["MensagemAlerta"] = "Documento Inserido com Sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(documento);
        }

        // GET: Documento/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos.FindAsync(id);
            if (documento == null)
            {
                return NotFound();
            }
            return View(documento);
        }

        // POST: Documento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DocumentoId,Codigo,Titulo,Processo,Categoria,Arquivo")] Documento documento)
        {
            if (id != documento.DocumentoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(documento);
                    await _context.SaveChangesAsync();
                    TempData["MensagemAlerta"] = "Documento Editado com Sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocumentoExists(documento.DocumentoId))
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
            return View(documento);
        }

        // GET: Documento/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Documentos == null)
            {
                return NotFound();
            }

            var documento = await _context.Documentos
                .FirstOrDefaultAsync(m => m.DocumentoId == id);
            if (documento == null)
            {
                return NotFound();
            }

            return View(documento);
        }

        // POST: Documento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Documentos == null)
            {
                return Problem("Entity set 'AppDbContext.Documentos'  is null.");
            }
            var documento = await _context.Documentos.FindAsync(id);
            if (documento != null)
            {
                _context.Documentos.Remove(documento);
            }
            
            await _context.SaveChangesAsync();
            TempData["MensagemAlerta"] = "Documento Excluido com Sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool DocumentoExists(int id)
        {
          return (_context.Documentos?.Any(e => e.DocumentoId == id)).GetValueOrDefault();
        }
    }
}
