using Microsoft.AspNetCore.Mvc;
using CafeManagement.Models;
using System.Linq;

namespace CafeManagement.Controllers
{
    public class TableController : Controller
    {
        private readonly CafeContext _context;

        public TableController(CafeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var tables = _context.Tables.ToList();
            return View(tables);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Tables.Add(table);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        public IActionResult Edit(int id)
        {
            var table = _context.Tables.Find(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        [HttpPost]
        public IActionResult Edit(Table table)
        {
            if (ModelState.IsValid)
            {
                _context.Tables.Update(table);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(table);
        }

        public IActionResult Delete(int id)
        {
            var table = _context.Tables.Find(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var table = _context.Tables.Find(id);
            if (table != null)
            {
                _context.Tables.Remove(table);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var table = _context.Tables.Find(id);
            if (table == null)
            {
                return NotFound();
            }
            return View(table);
        }
    }
}
