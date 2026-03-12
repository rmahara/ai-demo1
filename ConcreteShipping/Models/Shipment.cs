namespace ConcreteShipping.Models
{
    // 出荷
    public class Shipment
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        public DateTime ShippedAt { get; set; }  // 出荷日時
        public decimal Quantity { get; set; }  // 出荷量 (m3)
        public string Status { get; set; }  // "Dispatched", "Delivered"
        public string Notes { get; set; }  // 備考
    }
}
