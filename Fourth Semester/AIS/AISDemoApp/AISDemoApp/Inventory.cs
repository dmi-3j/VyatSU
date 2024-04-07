using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDemoApp
{
    public class Inventory
    {
        public Guid Id { get; set; }
        public string InventoryName { get; set; } = null!;
        public string InventoryType { get; set; } = null!;
        public decimal Size { get; set; }
        public decimal RentPrice { get; set; }
        public string? PhotoPath { get; set; }
        public ICollection<CartItem> CartItems { get; set; }

    }
}
