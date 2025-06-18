namespace ServiceCenter.Classes
{
    public class OrderPart
    {
        public int Id { get; set; }
        public string OrderId { get; set; }
        public Order Order { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public int Quantity { get; set; }
    }
}
