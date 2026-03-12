using ConcreteShipping.Data;
using ConcreteShipping.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteShipping.Controllers
{
    // 工場マスタコントローラー
    // 意図的な問題: [Authorize]属性なし
    public class FactoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FactoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var factories = _context.Factories.ToList();
            return View(factories);
        }

        public IActionResult Details(int id)
        {
            var factory = _context.Factories.Find(id);
            if (factory == null) return NotFound();
            return View(factory);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Factory factory)
        {
            _context.Factories.Add(factory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var factory = _context.Factories.Find(id);
            if (factory == null) return NotFound();
            return View(factory);
        }

        [HttpPost]
        public IActionResult Edit(int id, Factory factory)
        {
            _context.Update(factory);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var factory = _context.Factories.Find(id);
            if (factory == null) return NotFound();
            return View(factory);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var factory = _context.Factories.Find(id);
            if (factory != null)
            {
                _context.Factories.Remove(factory);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
