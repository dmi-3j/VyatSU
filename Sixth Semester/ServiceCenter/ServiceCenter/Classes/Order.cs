namespace ServiceCenter.Classes
{
    public class Order
    {
        public string OrderId { get; set; }
        public string CustomerName { get; set; }
        public string PhoneNumber { get; set; }
        public string DeviceType { get; set; }
        public string DeviceModel { get; set; }
        public string RepairType { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public string WarehouseRequestStatus { get; set; }
        public string OrderDate { get; set; }
        public string ResponsibleMaster { get; set; }
        public List<OrderPart> Parts { get; set; } = new List<OrderPart>();
        public double Price { get; set; }
        public double CalculateTotalPrice(List<WarehousePart> warehouseParts)
        {
            double totalPartsPrice = 0;

            foreach (var orderPart in Parts)
            {
                var warehousePart = warehouseParts.FirstOrDefault(p => p.Name == orderPart.Name);
                if (warehousePart != null)
                {
                    totalPartsPrice += warehousePart.Price * orderPart.Quantity;
                }
            }

            return Price + totalPartsPrice;
        }

    }
}
