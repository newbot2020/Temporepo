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
    public class ResultsController : Controller
    {
        private readonly one2manyContext _context;

        public ResultsController(one2manyContext context)
        {
            _context = context;
        }

        // GET: Results
        public async Task<IActionResult> Index()
        {
            var one2manyContext = _context.Result.Include(r => r.Classinfo).Include(r => r.Students);
            return View(await one2manyContext.ToListAsync());
        }

        // GET: Results/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.Classinfo)
                .Include(r => r.Students)
                .FirstOrDefaultAsync(m => m.id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // GET: Results/Create
        public IActionResult Create()
        {
            ViewData["Classinfoid"] = new SelectList(_context.Classinfo, "id", "id");
            ViewData["Studentid"] = new SelectList(_context.Student, "id", "email");
            return View();
        }

        // POST: Results/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,term,termresult,meritpostion,Studentid,Classinfoid")] Result result)
        {
            if (ModelState.IsValid)
            {
                _context.Add(result);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Classinfoid"] = new SelectList(_context.Classinfo, "id", "id", result.Classinfoid);
            ViewData["Studentid"] = new SelectList(_context.Student, "id", "email", result.Studentid);
            return View(result);
        }

        // GET: Results/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result.FindAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewData["Classinfoid"] = new SelectList(_context.Classinfo, "id", "id", result.Classinfoid);
            ViewData["Studentid"] = new SelectList(_context.Student, "id", "email", result.Studentid);
            return View(result);
        }

        // POST: Results/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,term,termresult,meritpostion,Studentid,Classinfoid")] Result result)
        {
            if (id != result.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(result);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultExists(result.id))
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
            ViewData["Classinfoid"] = new SelectList(_context.Classinfo, "id", "id", result.Classinfoid);
            ViewData["Studentid"] = new SelectList(_context.Student, "id", "email", result.Studentid);
            return View(result);
        }

        // GET: Results/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var result = await _context.Result
                .Include(r => r.Classinfo)
                .Include(r => r.Students)
                .FirstOrDefaultAsync(m => m.id == id);
            if (result == null)
            {
                return NotFound();
            }

            return View(result);
        }

        // POST: Results/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var result = await _context.Result.FindAsync(id);
            _context.Result.Remove(result);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultExists(int id)
        {
            return _context.Result.Any(e => e.id == id);
        }
    }
}
