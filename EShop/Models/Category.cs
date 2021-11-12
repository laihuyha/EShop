using System;
using System.Collections.Generic;

#nullable disable

namespace EShop.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CateId { get; set; }
        public string CategoryName { get; set; }
        public string Descriptions { get; set; }
        public int ParentId { get; set; }
        public int? Levels { get; set; }
        public int? Ordering { get; set; }
        public bool? IsPublished { get; set; }
        public string ThumbImg { get; set; }
        public string Title { get; set; }
        public string Alias { get; set; }
        public string Cover { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
