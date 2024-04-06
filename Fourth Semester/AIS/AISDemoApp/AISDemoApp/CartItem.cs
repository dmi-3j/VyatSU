using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDemoApp
{
    public class CartItem
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }
        public Inventory Inventory { get; set; }

        public Guid CartId { get; set; }
        public Cart Cart { get; set; }
    }
}
