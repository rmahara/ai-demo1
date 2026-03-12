using ConcreteShipping.Data;
using Microsoft.AspNetCore.Mvc;

namespace ConcreteShipping.Controllers
{
    // ダッシュボードコントローラー
    // 意図的な問題: 全データを読み込む (フィルタリングなし、非同期なし)
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // 意図的な問題: 全データを非同期なしで読み込む
            var allOrders = _context.Orders.ToList();
            var allShipments = _context.Shipments.ToList();

            // 今日の統計
            var today = DateTime.Today;
            var todayShipments = allShipments.Where(s => s.ShippedAt.Date == today).ToList();

            ViewBag.TotalOrders = allOrders.Count;
            ViewBag.PendingOrders = allOrders.Count(o => o.Status == "Pending");
            ViewBag.ShippedToday = todayShipments.Count;
            ViewBag.TotalQuantityToday = todayShipments.Sum(s => s.Quantity);

            // ステータス別集計 (グラフ用)
            ViewBag.StatusPending = allOrders.Count(o => o.Status == "Pending");
            ViewBag.StatusAssigned = allOrders.Count(o => o.Status == "Assigned");
            ViewBag.StatusShipped = allOrders.Count(o => o.Status == "Shipped");
            ViewBag.StatusCompleted = allOrders.Count(o => o.Status == "Completed");

            // 直近7日の出荷量 (Chart.js用)
            var last7Days = Enumerable.Range(0, 7).Select(i => today.AddDays(-6 + i)).ToList();
            var dailyQuantities = last7Days.Select(d =>
                allShipments.Where(s => s.ShippedAt.Date == d).Sum(s => s.Quantity)
            ).ToList();

            ViewBag.ChartLabels = string.Join(",", last7Days.Select(d => $"'{d:M/d}'"));
            ViewBag.ChartData = string.Join(",", dailyQuantities);

            return View();
        }
    }
}
