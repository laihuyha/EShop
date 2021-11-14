using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
        [Required]
        [Display(Name ="Tên sản phẩm")]
        [StringLength(100, ErrorMessage = "Tên loại sản phẩm không được quá 100 ký tự")]
        public string ProductName { get; set; }
        public string ShortDesc { get; set; }
        [Required]
        [StringLength(1000, ErrorMessage = "Mô tả sản phẩm không được quá 1000 ký tự")]
        [Display(Name = "Mô tả sản phẩm")]
        public string Descriptions { get; set; }
        public int? CateId { get; set; }
        [Display(Name ="Giá")]
        [Required(ErrorMessage ="Không để trống giá")] 
        [Range(1000,100000000)]
        public long? Price { get; set; }
        [Display(Name ="Chiết khấu")]
        public int? Discount { get; set; }
        public string ThumbImg { get; set; }
        [Display(Name ="Video")]
        public string Video { get; set; }
        [Display(Name ="Ngày nhập hàng")]
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
