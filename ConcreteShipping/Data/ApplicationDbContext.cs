using ConcreteShipping.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ConcreteShipping.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<MixDesign> MixDesigns { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // 得意先シードデータ
            builder.Entity<Customer>().HasData(
                new Customer { Id = 1, Name = "山田建設株式会社", Address = "東京都江東区有明1-1-1", Phone = "03-1234-5678", ContactPerson = "山田太郎", UnitPrice = 12000m, IsActive = true },
                new Customer { Id = 2, Name = "鈴木工務店", Address = "東京都墨田区押上2-2-2", Phone = "03-2345-6789", ContactPerson = "鈴木一郎", UnitPrice = 11500m, IsActive = true },
                new Customer { Id = 3, Name = "佐藤土木建設", Address = "神奈川県横浜市中区3-3-3", Phone = "045-345-6789", ContactPerson = "佐藤次郎", UnitPrice = 11000m, IsActive = true }
            );

            // 配合マスタシードデータ
            builder.Entity<MixDesign>().HasData(
                new MixDesign { Id = 1, Code = "21N-8-20", Name = "普通コンクリート 21N", Strength = 21, Slump = 8, Aggregate = "20mm", UnitPrice = 12000m, IsActive = true },
                new MixDesign { Id = 2, Code = "24N-12-20", Name = "普通コンクリート 24N", Strength = 24, Slump = 12, Aggregate = "20mm", UnitPrice = 13000m, IsActive = true },
                new MixDesign { Id = 3, Code = "18N-15-25", Name = "軽量コンクリート 18N", Strength = 18, Slump = 15, Aggregate = "25mm", UnitPrice = 11000m, IsActive = true }
            );

            // 車両マスタシードデータ
            builder.Entity<Vehicle>().HasData(
                new Vehicle { Id = 1, LicensePlate = "品川100 あ 1234", Capacity = 10m, DriverName = "田中運転手", IsActive = true },
                new Vehicle { Id = 2, LicensePlate = "品川100 い 5678", Capacity = 8m, DriverName = "中村運転手", IsActive = true },
                new Vehicle { Id = 3, LicensePlate = "品川100 う 9012", Capacity = 7m, DriverName = "小林運転手", IsActive = true }
            );

            // 工場マスタシードデータ
            builder.Entity<Factory>().HasData(
                new Factory { Id = 1, Name = "東京生コン第一工場", Address = "東京都江東区新木場4-4-4", Phone = "03-4567-8901" }
            );

            // 受注シードデータ
            var baseDate = new DateTime(2026, 3, 1);
            builder.Entity<Order>().HasData(
                new Order { Id = 1, OrderDate = baseDate, CustomerId = 1, MixDesignId = 1, Quantity = 30m, DeliveryDate = baseDate.AddDays(1), DeliveryAddress = "東京都江東区有明1-1-1", OrderType = "PreOrder", Status = "Completed", Notes = "1便目 朝イチ希望" },
                new Order { Id = 2, OrderDate = baseDate, CustomerId = 2, MixDesignId = 2, Quantity = 20m, DeliveryDate = baseDate.AddDays(1), DeliveryAddress = "東京都墨田区押上2-2-2", OrderType = "Phone", Status = "Completed", Notes = "" },
                new Order { Id = 3, OrderDate = baseDate.AddDays(1), CustomerId = 3, MixDesignId = 1, Quantity = 15m, DeliveryDate = baseDate.AddDays(2), DeliveryAddress = "神奈川県横浜市中区3-3-3", OrderType = "PreOrder", Status = "Shipped", Notes = "雨天延期可" },
                new Order { Id = 4, OrderDate = baseDate.AddDays(2), CustomerId = 1, MixDesignId = 3, Quantity = 25m, DeliveryDate = baseDate.AddDays(3), DeliveryAddress = "東京都江東区有明1-1-1 2工区", OrderType = "PreOrder", Status = "Assigned", Notes = "" },
                new Order { Id = 5, OrderDate = baseDate.AddDays(3), CustomerId = 2, MixDesignId = 1, Quantity = 18m, DeliveryDate = baseDate.AddDays(4), DeliveryAddress = "東京都墨田区押上2-2-2", OrderType = "Phone", Status = "Pending", Notes = "午後指定" },
                new Order { Id = 6, OrderDate = baseDate.AddDays(4), CustomerId = 3, MixDesignId = 2, Quantity = 40m, DeliveryDate = baseDate.AddDays(5), DeliveryAddress = "神奈川県横浜市中区3-3-3", OrderType = "PreOrder", Status = "Pending", Notes = "" },
                new Order { Id = 7, OrderDate = baseDate.AddDays(5), CustomerId = 1, MixDesignId = 1, Quantity = 12m, DeliveryDate = baseDate.AddDays(6), DeliveryAddress = "東京都江東区有明1-1-1 3工区", OrderType = "PreOrder", Status = "Pending", Notes = "" },
                new Order { Id = 8, OrderDate = baseDate.AddDays(5), CustomerId = 2, MixDesignId = 3, Quantity = 22m, DeliveryDate = baseDate.AddDays(7), DeliveryAddress = "東京都墨田区押上2-2-2", OrderType = "Phone", Status = "Pending", Notes = "基礎工事用" },
                new Order { Id = 9, OrderDate = baseDate.AddDays(6), CustomerId = 3, MixDesignId = 2, Quantity = 35m, DeliveryDate = baseDate.AddDays(8), DeliveryAddress = "神奈川県横浜市中区3-3-3", OrderType = "PreOrder", Status = "Pending", Notes = "" },
                new Order { Id = 10, OrderDate = baseDate.AddDays(7), CustomerId = 1, MixDesignId = 1, Quantity = 50m, DeliveryDate = baseDate.AddDays(9), DeliveryAddress = "東京都江東区有明1-1-1 大型案件", OrderType = "PreOrder", Status = "Pending", Notes = "大型案件 要確認" }
            );

            // 出荷シードデータ
            builder.Entity<Shipment>().HasData(
                new Shipment { Id = 1, OrderId = 1, VehicleId = 1, ShippedAt = baseDate.AddDays(1).AddHours(8), Quantity = 10m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 2, OrderId = 1, VehicleId = 2, ShippedAt = baseDate.AddDays(1).AddHours(9), Quantity = 10m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 3, OrderId = 1, VehicleId = 3, ShippedAt = baseDate.AddDays(1).AddHours(10), Quantity = 10m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 4, OrderId = 2, VehicleId = 1, ShippedAt = baseDate.AddDays(1).AddHours(13), Quantity = 10m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 5, OrderId = 2, VehicleId = 2, ShippedAt = baseDate.AddDays(1).AddHours(14), Quantity = 10m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 6, OrderId = 3, VehicleId = 1, ShippedAt = baseDate.AddDays(2).AddHours(8), Quantity = 8m, Status = "Delivered", Notes = "" },
                new Shipment { Id = 7, OrderId = 3, VehicleId = 2, ShippedAt = baseDate.AddDays(2).AddHours(9), Quantity = 7m, Status = "Dispatched", Notes = "" },
                new Shipment { Id = 8, OrderId = 4, VehicleId = 1, ShippedAt = baseDate.AddDays(3).AddHours(8), Quantity = 10m, Status = "Dispatched", Notes = "" },
                new Shipment { Id = 9, OrderId = 4, VehicleId = 2, ShippedAt = baseDate.AddDays(3).AddHours(9), Quantity = 8m, Status = "Dispatched", Notes = "" },
                new Shipment { Id = 10, OrderId = 4, VehicleId = 3, ShippedAt = baseDate.AddDays(3).AddHours(10), Quantity = 7m, Status = "Dispatched", Notes = "" },
                new Shipment { Id = 11, OrderId = 2, VehicleId = 3, ShippedAt = baseDate.AddDays(1).AddHours(15), Quantity = 0m, Status = "Delivered", Notes = "完了確認" }
            );
        }
    }
}
