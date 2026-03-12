using ConcreteShipping.Data;
using ConcreteShipping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConcreteShipping.Controllers
{
    // 出荷管理コントローラー
    // 意図的な問題: N+1クエリ
    public class ShipmentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ShipmentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 出荷実績一覧
        // 意図的な問題: N+1クエリ - Include()なし
        public IActionResult Index()
        {
            var shipments = _context.Shipments.ToList();
            // ビューでshipment.Order.DeliveryAddressにアクセスする際にN+1クエリが発生する
            return View(shipments);
        }

        // 出荷詳細
        public IActionResult Details(int id)
        {
            var shipment = _context.Shipments
                .Include(s => s.Order)
                    .ThenInclude(o => o.Customer)
                .Include(s => s.Vehicle)
                .FirstOrDefault(s => s.Id == id);

            if (shipment == null) return NotFound();
            return View(shipment);
        }

        // 出荷指示 GET
        public IActionResult Create()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .Where(o => o.Status == "Pending" || o.Status == "Assigned")
                .ToList();

            ViewBag.Orders = new SelectList(orders.Select(o => new {
                o.Id,
                Name = $"{o.Customer.Name} - {o.DeliveryDate:MM/dd} ({o.Quantity}m3)"
            }), "Id", "Name");

            ViewBag.Vehicles = new SelectList(_context.Vehicles.Where(v => v.IsActive), "Id", "LicensePlate");
            return View();
        }

        // 出荷指示 POST
        [HttpPost]
        public IActionResult Create(Shipment shipment)
        {
            shipment.ShippedAt = DateTime.Now;
            shipment.Status = "Dispatched";
            _context.Shipments.Add(shipment);

            // 受注ステータスを更新
            var order = _context.Orders.Find(shipment.OrderId);
            if (order != null && order.Status == "Pending")
            {
                order.Status = "Assigned";
            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // 出荷編集 GET
        public IActionResult Edit(int id)
        {
            var shipment = _context.Shipments
                .Include(s => s.Order)
                .FirstOrDefault(s => s.Id == id);
            if (shipment == null) return NotFound();

            ViewBag.Orders = new SelectList(_context.Orders, "Id", "Id", shipment.OrderId);
            ViewBag.Vehicles = new SelectList(_context.Vehicles.Where(v => v.IsActive), "Id", "LicensePlate", shipment.VehicleId);
            return View(shipment);
        }

        // 出荷編集 POST
        [HttpPost]
        public IActionResult Edit(int id, Shipment shipment)
        {
            _context.Update(shipment);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // 週次集計レポート
        public IActionResult WeeklyReport()
        {
            var today = DateTime.Today;
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Monday);
            if (today.DayOfWeek == DayOfWeek.Sunday) startOfWeek = startOfWeek.AddDays(-7);

            var weeklyShipments = _context.Shipments
                .Include(s => s.Order)
                    .ThenInclude(o => o.Customer)
                .Include(s => s.Vehicle)
                .Where(s => s.ShippedAt >= startOfWeek && s.ShippedAt < startOfWeek.AddDays(7))
                .OrderBy(s => s.ShippedAt)
                .ToList();

            ViewBag.WeekStart = startOfWeek;
            ViewBag.WeekEnd = startOfWeek.AddDays(6);
            ViewBag.TotalQuantity = weeklyShipments.Sum(s => s.Quantity);
            ViewBag.TripCount = weeklyShipments.Count;

            return View(weeklyShipments);
        }
    }
}
