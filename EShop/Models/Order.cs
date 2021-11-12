using System;
using System.Collections.Generic;

#nullable disable

namespace EShop.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public DateTime? ShipDate { get; set; }
        public int? TransactionStatusId { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsPaid { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? PaymentId { get; set; }
        public string Note { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual TransactStatus TransactionStatus { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
