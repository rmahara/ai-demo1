namespace ConcreteShipping.Models
{
    // 配合マスタ
    public class MixDesign
    {
        public int Id { get; set; }
        public string Code { get; set; }  // 配合コード
        public string Name { get; set; }  // 配合名
        public int Strength { get; set; }  // 強度 (Fc)
        public int Slump { get; set; }     // スランプ
        public string Aggregate { get; set; }  // 骨材
        public decimal UnitPrice { get; set; }  // 単価
        public bool IsActive { get; set; }  // 有効フラグ
        public ICollection<Order> Orders { get; set; }
    }
}
