using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebDoAn.Models.DB;

namespace WebDoAn.Controllers
{
    public class CGrammarsController : Controller
    {
        private readonly P_NIHONGOContext _context;

        public CGrammarsController(P_NIHONGOContext context)
        {
            _context = context;
        }

        // GET: CGrammars
        public async Task<IActionResult> Index()
        {
            return View(await _context.CGrammar.ToListAsync());
        }

        // GET: CGrammars/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cGrammar = await _context.CGrammar
                .SingleOrDefaultAsync(m => m.Grammarcode == id);
            if (cGrammar == null)
            {
                return NotFound();
            }

            return View(cGrammar);
        }

        // GET: CGrammars/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CGrammars/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Grammarcode,Title,Index1,Index2,Index3,Detail1,Detail2,Detail3,Usercode,Image,Votenumber,Toppiccode,Levelcode,Minacode,Example1,MeanEx1,Example2,MeanEx2,Example3,MeanEx3,Description,Status,Attribute1,Attribute2,CreateDate,UpDate")] CGrammar cGrammar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cGrammar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cGrammar);
        }

        // GET: CGrammars/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cGrammar = await _context.CGrammar.SingleOrDefaultAsync(m => m.Grammarcode == id);
            if (cGrammar == null)
            {
                return NotFound();
            }
            return View(cGrammar);
        }

        // POST: CGrammars/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Grammarcode,Title,Index1,Index2,Index3,Detail1,Detail2,Detail3,Usercode,Image,Votenumber,Toppiccode,Levelcode,Minacode,Example1,MeanEx1,Example2,MeanEx2,Example3,MeanEx3,Description,Status,Attribute1,Attribute2,CreateDate,UpDate")] CGrammar cGrammar)
        {
            if (id != cGrammar.Grammarcode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cGrammar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CGrammarExists(cGrammar.Grammarcode))
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
            return View(cGrammar);
        }

        // GET: CGrammars/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cGrammar = await _context.CGrammar
                .SingleOrDefaultAsync(m => m.Grammarcode == id);
            if (cGrammar == null)
            {
                return NotFound();
            }

            return View(cGrammar);
        }

        // POST: CGrammars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var cGrammar = await _context.CGrammar.SingleOrDefaultAsync(m => m.Grammarcode == id);
            _context.CGrammar.Remove(cGrammar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CGrammarExists(string id)
        {
            return _context.CGrammar.Any(e => e.Grammarcode == id);
        }
    }
}
