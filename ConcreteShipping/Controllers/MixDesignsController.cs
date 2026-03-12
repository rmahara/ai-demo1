using ConcreteShipping.Data;
using ConcreteShipping.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteShipping.Controllers
{
    // 配合マスタコントローラー
    // 意図的な問題: [Authorize]属性なし
    public class MixDesignsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MixDesignsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var mixDesigns = _context.MixDesigns.ToList();
            return View(mixDesigns);
        }

        public IActionResult Details(int id)
        {
            var mixDesign = _context.MixDesigns.Find(id);
            if (mixDesign == null) return NotFound();
            return View(mixDesign);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(MixDesign mixDesign)
        {
            mixDesign.IsActive = true;
            _context.MixDesigns.Add(mixDesign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var mixDesign = _context.MixDesigns.Find(id);
            if (mixDesign == null) return NotFound();
            return View(mixDesign);
        }

        [HttpPost]
        public IActionResult Edit(int id, MixDesign mixDesign)
        {
            _context.Update(mixDesign);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var mixDesign = _context.MixDesigns.Find(id);
            if (mixDesign == null) return NotFound();
            return View(mixDesign);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var mixDesign = _context.MixDesigns.Find(id);
            if (mixDesign != null)
            {
                _context.MixDesigns.Remove(mixDesign);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
