namespace WebFinal.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name = "Mã sản phẩm")]
        public int MaSP { get; set; }

        [StringLength(100)]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; }
        [Display(Name = "Giá bán")]
        public decimal? GiaBan { get; set; }
        [Display(Name = "Mô tả")]
        public string MoTa { get; set; }

        [StringLength(50)]
        [Display(Name = "Ảnh")]
        public string AnhBia { get; set; }
        [Display(Name = "Trạng thái")]
        public int TrangThai { get; set; }
        [Display(Name = "Ngày cập nhật")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? NgayCapNhat { get; set; }
        [Display(Name = "Mã loại sản phẩm")]
        public int? MaLoaiSP { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual LoaiSanPham LoaiSanPham { get; set; }
    }
}
