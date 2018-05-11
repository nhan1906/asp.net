using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    [Table("PThongTinCuaHangOST")]
    public class ThongTinCuaHang
    {
        [Key]
        public int Ma { get; set; }

        public string TenCuaHang { get; set; }
        public string SoDienThoai { get; set; }
    }
}