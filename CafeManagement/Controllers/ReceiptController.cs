using Microsoft.AspNetCore.Mvc;
using CafeManagement.Models;
using System.Linq;

namespace CafeManagement.Controllers
{
    public class ReceiptController : Controller
    {
        private readonly CafeContext _context;

        public ReceiptController(CafeContext context)
        {
            _context = context;
        }

        // Adisyonları listele
        public IActionResult Index()
        {
            var receipts = _context.Receipts.ToList();
            return View(receipts);
        }

        // Yeni adisyon oluştur
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Receipt receipt)
        {
            if (ModelState.IsValid)
            {
                _context.Receipts.Add(receipt);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(receipt);
        }

    }
}
