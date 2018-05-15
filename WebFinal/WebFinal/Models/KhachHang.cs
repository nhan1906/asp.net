namespace WebFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public sealed partial class KhachHang
    {
        public KhachHang()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        [Display(Name = "Mã khách hàng")]
        public int MaKH { get; set; }

        [Display(Name = "Tên khách hàng")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Xin vui lòng nhập tên.")]
        public string HoTen { get; set; }

        [StringLength(50)]
        [Display(Name = "Tên đăng nhập")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "{0} không được để trống")]
        public string TaiKhoan { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Xin vui lòng điền mật khẩu.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Tối thiểu 8 ký tự")]
        public string MatKhau { get; set; }

        [NotMapped]
        [Display(Name = "Xác nhận mật khẩu")]
        [Compare("MatKhau", ErrorMessage = "Mật khẩu không khớp.")]
        [DataType(DataType.Password)]
        public string XacNhanMatKhau { get; set; }

        [StringLength(100)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(200)]
        [Display(Name = "Địa chỉ")]
        public string DiaChi { get; set; }

        [StringLength(50)]
        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "{0} không được để trống")]
        [DataType(DataType.PhoneNumber)]
        public string DienThoai { get; set; }

        [Display(Name = "Giới tính")]
        public string GioiTinh { get; set; }

        [Display(Name = "Ngày sinh")]
        [DataType(DataType.DateTime)]
        public DateTime NgaySinh { get; set; }

        private ICollection<DonHang> DonHangs { get; set; }
    }
}
