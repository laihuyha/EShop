using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace EShop.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Orders = new HashSet<Order>();
        }

        public int CustommerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Avatar { get; set; }
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Sai định dạng Email")]
        public string Mail { get; set; }
        [Display(Name = "SĐT")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 12, ErrorMessage = "Số điện thoại quá dài hoặc quá ngắn", MinimumLength = 9)]
        public string Phone { get; set; }
        public string Province { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActived { get; set; }
        public int? CartId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
