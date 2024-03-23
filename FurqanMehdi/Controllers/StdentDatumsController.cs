using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FurqanMehdi.Models;

namespace FurqanMehdi.Controllers
{
    public class StdentDatumsController : Controller
    {
        private readonly Maju3Context _context;

        public StdentDatumsController(Maju3Context context)
        {
            _context = context;
        }

        // GET: StdentDatums
        public async Task<IActionResult> Index()
        {
            return View(await _context.StdentData.ToListAsync());
        }

        // GET: StdentDatums/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdentDatum = await _context.StdentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdentDatum == null)
            {
                return NotFound();
            }

            return View(stdentDatum);
        }

        // GET: StdentDatums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StdentDatums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,LastName,Email,Program,PhoneNo")] StdentDatum stdentDatum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(stdentDatum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stdentDatum);
        }

        // GET: StdentDatums/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdentDatum = await _context.StdentData.FindAsync(id);
            if (stdentDatum == null)
            {
                return NotFound();
            }
            return View(stdentDatum);
        }

        // POST: StdentDatums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Program,PhoneNo")] StdentDatum stdentDatum)
        {
            if (id != stdentDatum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(stdentDatum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StdentDatumExists(stdentDatum.Id))
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
            return View(stdentDatum);
        }

        // GET: StdentDatums/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var stdentDatum = await _context.StdentData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (stdentDatum == null)
            {
                return NotFound();
            }

            return View(stdentDatum);
        }

        // POST: StdentDatums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var stdentDatum = await _context.StdentData.FindAsync(id);
            if (stdentDatum != null)
            {
                _context.StdentData.Remove(stdentDatum);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StdentDatumExists(int id)
        {
            return _context.StdentData.Any(e => e.Id == id);
        }
    }
}
