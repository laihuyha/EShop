using System;
using System.Collections.Generic;

#nullable disable

namespace EShop.Models
{
    public partial class Product
    {
        public Product()
        {
            AttributePrices = new HashSet<AttributePrice>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        public string Descriptions { get; set; }
        public int? CateId { get; set; }
        public int? Price { get; set; }
        public int? Discount { get; set; }
        public string ThumbImg { get; set; }
        public string Video { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public bool IsBestsellers { get; set; }
        public bool? Homeflag { get; set; }
        public bool IsActived { get; set; }
        public string Tag { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public int? UnitInStock { get; set; }

        public virtual Category Cate { get; set; }
        public virtual ICollection<AttributePrice> AttributePrices { get; set; }
    }
}
