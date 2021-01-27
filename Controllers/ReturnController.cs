using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AplikasiPerpustakaan.Data;
using AplikasiPerpustakaan.Models;
using Microsoft.AspNetCore.Authorization;

namespace AplikasiPerpustakaan.Controllers
{

    [Authorize]
    public class ReturnController : Controller
    {
        private readonly DbContextBook _context;

        public ReturnController(DbContextBook context)
        {
            _context = context;
        }

        // GET: Return
        public async Task<IActionResult> Index()
        {
            return View(await _context.Return.ToListAsync());
        }

        // GET: Return/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .FirstOrDefaultAsync(m => m.Id_Return == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // GET: Return/Create
        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {

            List<Borrow> li = new List<Borrow>();
            li = _context.Borrow.ToList();
            ViewBag.listborrow = li;

            return View();
        }

        // POST: Return/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Return,nama_pengembali,tanggal_pengembalian,Id_Borrow,ket")] Return @return)
        {
            if (ModelState.IsValid)
            {
                _context.Add(@return);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@return);
        }

        // GET: Return/Edit/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Edit(int? id)
        {

            List<Borrow> li = new List<Borrow>();
            li = _context.Borrow.ToList();
            ViewBag.listborrow = li;

            if (id == null)
            {
                return NotFound();
            }

            var @return = await _context.Return.FindAsync(id);
            if (@return == null)
            {
                return NotFound();
            }
            return View(@return);
        }

        // POST: Return/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Return,nama_pengembali,tanggal_pengembalian,Id_Borrow,ket")] Return @return)
        {
            if (id != @return.Id_Return)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@return);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReturnExists(@return.Id_Return))
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
            return View(@return);
        }

        // GET: Return/Delete/5
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @return = await _context.Return
                .FirstOrDefaultAsync(m => m.Id_Return == id);
            if (@return == null)
            {
                return NotFound();
            }

            return View(@return);
        }

        // POST: Return/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @return = await _context.Return.FindAsync(id);
            _context.Return.Remove(@return);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReturnExists(int id)
        {
            return _context.Return.Any(e => e.Id_Return == id);
        }
    }
}
