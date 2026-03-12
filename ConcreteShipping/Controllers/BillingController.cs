using ConcreteShipping.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ConcreteShipping.Controllers
{
    // 請求管理コントローラー
    // 意図的な問題: 認証チェックなし
    public class BillingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BillingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 月次請求一覧
        public IActionResult Index()
        {
            var today = DateTime.Today;
            var year = today.Year;
            var month = today.Month;

            // 今月の完了済み受注を得意先別に集計
            var completedOrders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.MixDesign)
                .Where(o => o.Status == "Completed"
                    && o.DeliveryDate.Year == year
                    && o.DeliveryDate.Month == month)
                .ToList();

            // 得意先別集計
            var billing = completedOrders
                .GroupBy(o => new { o.CustomerId, o.Customer.Name })
                .Select(g => new
                {
                    CustomerId = g.Key.CustomerId,
                    CustomerName = g.Key.Name,
                    OrderCount = g.Count(),
                    TotalQuantity = g.Sum(o => o.Quantity),
                    TotalAmount = g.Sum(o => o.Quantity * o.MixDesign.UnitPrice)
                })
                .ToList();

            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.BillingData = billing;
            ViewBag.GrandTotal = billing.Sum(b => b.TotalAmount);

            return View();
        }

        // 月次請求処理 GET
        public IActionResult Process(int year, int month)
        {
            if (year == 0) year = DateTime.Today.Year;
            if (month == 0) month = DateTime.Today.Month;

            ViewBag.Year = year;
            ViewBag.Month = month;

            var orders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.MixDesign)
                .Where(o => o.Status == "Completed"
                    && o.DeliveryDate.Year == year
                    && o.DeliveryDate.Month == month)
                .ToList();

            return View(orders);
        }

        // 月次請求処理 POST
        [HttpPost]
        public IActionResult Process(int year, int month, string action)
        {
            // 意図的な問題: エラーハンドリングなし
            ViewBag.Year = year;
            ViewBag.Month = month;
            ViewBag.Message = $"{year}年{month}月の請求処理が完了しました。（デモ）";
            return View("ProcessResult");
        }
    }
}
