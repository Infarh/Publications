using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Publications.Web.Data;

namespace Publications.Web.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorsController(ApplicationDbContext db) => _db = db;

        // GET: Authors
        public async Task<IActionResult> Index() => View(await _db.Authors.ToListAsync());

        // GET: Authors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null) return NotFound();
            var author = await _db.Authors.FirstOrDefaultAsync(m => m.Id == id);
            return author is null ? (IActionResult) NotFound() : View(author);
        }

        public IActionResult Create() => View();

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Surname,Patronymic,Birthday,Description,Meta")] Author author)
        {
            if (!ModelState.IsValid) return View(author);
            _db.Add(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null) return NotFound();
            var author = await _db.Authors.FindAsync(id);
            return author is null ? (IActionResult) NotFound() : View(author);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Surname,Patronymic,Birthday,Description,Meta")] Author author)
        {
            if (id != author.Id) return NotFound();
            if (!ModelState.IsValid) return View(author);
            try
            {
                _db.Update(author);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(author.Id)) return NotFound();
                throw;
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null) return NotFound();
            var author = await _db.Authors.FirstOrDefaultAsync(m => m.Id == id);
            return author is null ? (IActionResult) NotFound() : View(author);
        }

        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var author = await _db.Authors.FindAsync(id);
            _db.Authors.Remove(author);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AuthorExists(int id) => _db.Authors.Any(e => e.Id == id);
    }
}
