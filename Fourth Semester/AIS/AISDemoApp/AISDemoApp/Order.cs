using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AISDemoApp
{
    public class Order
    {

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        [Column(TypeName = "date")]
        public DateTime OrderDate { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public string Services { get; set; }
        public decimal TotalAmount { get; set; }

    }
}
