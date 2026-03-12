namespace ConcreteShipping.Models
{
    // 得意先マスタ
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }  // 得意先名
        public string Address { get; set; }  // 住所
        public string Phone { get; set; }  // 電話番号
        public string ContactPerson { get; set; }  // 担当者
        public decimal UnitPrice { get; set; }  // 単価
        public bool IsActive { get; set; }  // 有効フラグ
        public ICollection<Order> Orders { get; set; }
    }
}
