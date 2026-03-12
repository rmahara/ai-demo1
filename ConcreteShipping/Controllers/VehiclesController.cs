using ConcreteShipping.Data;
using ConcreteShipping.Models;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteShipping.Controllers
{
    // 車両マスタコントローラー
    // 意図的な問題: [Authorize]属性なし
    public class VehiclesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var vehicles = _context.Vehicles.ToList();
            return View(vehicles);
        }

        public IActionResult Details(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Vehicle vehicle)
        {
            vehicle.IsActive = true;
            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        [HttpPost]
        public IActionResult Edit(int id, Vehicle vehicle)
        {
            _context.Update(vehicle);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle == null) return NotFound();
            return View(vehicle);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var vehicle = _context.Vehicles.Find(id);
            if (vehicle != null)
            {
                _context.Vehicles.Remove(vehicle);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
