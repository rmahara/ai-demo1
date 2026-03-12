namespace ConcreteShipping.Models
{
    // 受注
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }  // 受注日
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int MixDesignId { get; set; }
        public MixDesign MixDesign { get; set; }
        public decimal Quantity { get; set; }  // 数量 (m3)
        public DateTime DeliveryDate { get; set; }  // 納期
        public string DeliveryAddress { get; set; }  // 納入先
        public string OrderType { get; set; }  // "Phone" or "PreOrder"
        public string Status { get; set; }  // "Pending", "Assigned", "Shipped", "Completed"
        public string Notes { get; set; }  // 備考
        public ICollection<Shipment> Shipments { get; set; }
    }
}
