using ConcreteShipping.Data;
using ConcreteShipping.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ConcreteShipping.Controllers
{
    // 受注管理コントローラー
    // 意図的な問題: 認証チェックなし、N+1クエリ、生SQL使用
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 受注一覧
        // 意図的な問題: N+1クエリ - Include()を使用していない
        public IActionResult Index()
        {
            var orders = _context.Orders.ToList();
            // ビューでorder.Customer.Nameにアクセスする際にN+1クエリが発生する
            return View(orders);
        }

        // 受注詳細
        public IActionResult Details(int id)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.MixDesign)
                .Include(o => o.Shipments)
                .FirstOrDefault(o => o.Id == id);

            if (order == null) return NotFound();
            return View(order);
        }

        // 受注入力 GET
        public IActionResult Create()
        {
            ViewBag.Customers = new SelectList(_context.Customers.Where(c => c.IsActive), "Id", "Name");
            ViewBag.MixDesigns = new SelectList(_context.MixDesigns.Where(m => m.IsActive), "Id", "Name");
            return View();
        }

        // 受注入力 POST
        // 意図的な問題: バリデーションが不十分
        [HttpPost]
        public IActionResult Create(Order order)
        {
            // 意図的な問題: 最低限のModelStateチェックのみ
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // 受注編集 GET
        // 意図的な問題: 認証・認可チェックなし
        public IActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            if (order == null) return NotFound();

            ViewBag.Customers = new SelectList(_context.Customers.Where(c => c.IsActive), "Id", "Name", order.CustomerId);
            ViewBag.MixDesigns = new SelectList(_context.MixDesigns.Where(m => m.IsActive), "Id", "Name", order.MixDesignId);
            return View(order);
        }

        // 受注編集 POST
        // 意図的な問題: 認証・認可チェックなし
        [HttpPost]
        public IActionResult Edit(int id, Order order)
        {
            _context.Update(order);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        // 受注削除 GET
        public IActionResult Delete(int id)
        {
            var order = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.MixDesign)
                .FirstOrDefault(o => o.Id == id);
            if (order == null) return NotFound();
            return View(order);
        }

        // 受注削除 POST
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var order = _context.Orders.Find(id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        // 得意先別検索
        // 意図的な問題: SQLインジェクション脆弱性のある生SQL
        public IActionResult SearchByCustomer(int customerId)
        {
            // 意図的な問題: SQLインジェクション脆弱性
            var results = _context.Orders.FromSqlRaw($"SELECT * FROM Orders WHERE CustomerId = {customerId}").ToList();
            return View("Index", results);
        }

        // 配車計画
        public IActionResult AssignVehicles()
        {
            var pendingOrders = _context.Orders
                .Include(o => o.Customer)
                .Include(o => o.MixDesign)
                .Where(o => o.Status == "Pending")
                .ToList();
            return View(pendingOrders);
        }
    }
}
