using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EShop.Models
{
    public partial class Cart
    {

        public int CartId { get; set; }
        public int? UserId { get; set; }
        public int? ProductId { get; set; }
        [Required(ErrorMessage = "Không được để trống đơn vị!")]
        [Display(Name = "Số lượng")]
        public int? Quantity { get; set; }
        [Required(ErrorMessage ="Không được để trống giá!")]
        [Display(Name ="Giá")]
        public int? Price { get; set; }
        public DateTime? DateCreated { get; set; }

    }
}
