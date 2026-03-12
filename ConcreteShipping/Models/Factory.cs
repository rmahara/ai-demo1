namespace ConcreteShipping.Models
{
    // 工場マスタ
    public class Factory
    {
        public int Id { get; set; }
        public string Name { get; set; }  // 工場名
        public string Address { get; set; }  // 住所
        public string Phone { get; set; }  // 電話番号
    }
}
