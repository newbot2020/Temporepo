using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using one2many.Data;
using one2many.Models;

namespace one2many.Controllers
{
    public class ClassinfosController : Controller
    {
        private readonly one2manyContext _context;

        public ClassinfosController(one2manyContext context)
        {
            _context = context;
        }

        // GET: Classinfos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Classinfo.ToListAsync());
        }

        // GET: Classinfos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classinfo = await _context.Classinfo
                .FirstOrDefaultAsync(m => m.id == id);
            if (classinfo == null)
            {
                return NotFound();
            }

            return View(classinfo);
        }

        // GET: Classinfos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Classinfos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,Class")] Classinfo classinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(classinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(classinfo);
        }

        // GET: Classinfos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classinfo = await _context.Classinfo.FindAsync(id);
            if (classinfo == null)
            {
                return NotFound();
            }
            return View(classinfo);
        }

        // POST: Classinfos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,Class")] Classinfo classinfo)
        {
            if (id != classinfo.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(classinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassinfoExists(classinfo.id))
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
            return View(classinfo);
        }

        // GET: Classinfos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classinfo = await _context.Classinfo
                .FirstOrDefaultAsync(m => m.id == id);
            if (classinfo == null)
            {
                return NotFound();
            }

            return View(classinfo);
        }

        // POST: Classinfos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var classinfo = await _context.Classinfo.FindAsync(id);
            _context.Classinfo.Remove(classinfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClassinfoExists(int id)
        {
            return _context.Classinfo.Any(e => e.id == id);
        }
    }
}
