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
        //khi nào Db đầy đủ thì cast ra
        public int CustommerId { get; set; }
        public string Username { get; set; }
        //[Required(ErrorMessage = "Mật khẩu không được để trống!")]
        //[DataType(DataType.Password)]
        //[StringLength(100, ErrorMessage = "Mật khẩu không vượt quá 100 kí tự")]
        //[Display(Name = "Mật khẩu")]
        public string Password { get; set; }
        //[Required(ErrorMessage = "Họ và tên không được để trống!")]
        [Display(Name = "Họ và Tên")]
        public string FullName { get; set; }
        public DateTime? BirthDay { get; set; }
        public string Avatar { get; set; }
        //[Required(ErrorMessage = "Địa chỉ không được để trống!")]
        [Display(Name ="Địa chỉ")]
        public string Address { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Sai định dạng Email")]
        public string Mail { get; set; }
        [Display(Name = "SĐT")]
        [DataType(DataType.PhoneNumber)]
        [StringLength(maximumLength: 12, ErrorMessage = "Số điện thoại quá dài hoặc quá ngắn", MinimumLength = 9)]
        public string Phone { get; set; }
        public int? LocationId { get; set; }
        //[Required(ErrorMessage = "Không được để trống!")]
        [Display(Name ="Quận")]
        public int? District { get; set; }
        //[Required(ErrorMessage = "Không được để trống!")]
        [Display(Name ="Phường/xã")]
        public int? Ward { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActived { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
