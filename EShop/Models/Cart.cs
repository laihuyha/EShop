using System;
using System.Collections.Generic;

#nullable disable

namespace EShop.Models
{
    public partial class Cart
    {
        public Cart()
        {
            Accounts = new HashSet<Account>();
        }

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        public int? Quantity { get; set; }
        public int? Price { get; set; }
        public DateTime? DateCreated { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
