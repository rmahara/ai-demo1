namespace ConcreteShipping.Models
{
    // 車両マスタ
    public class Vehicle
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }  // ナンバープレート
        public decimal Capacity { get; set; }  // 積載量 (m3)
        public string DriverName { get; set; }  // 運転手名
        public bool IsActive { get; set; }  // 有効フラグ
        public ICollection<Shipment> Shipments { get; set; }
    }
}
