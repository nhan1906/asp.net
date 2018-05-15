namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebFinal.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<WebFinal.Models.BanHangModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebFinal.Models.BanHangModel context)
        {
            context.LoaiSanPhams.AddOrUpdate(x => x.TenLoaiSP, 
                new LoaiSanPham() { TenLoaiSP = "Nhẫn" },
                new LoaiSanPham() { TenLoaiSP = "Vòng tay" },
                new LoaiSanPham() { TenLoaiSP = "Dây chuyền" },
                new LoaiSanPham() { TenLoaiSP = "Lắc tay" },
                new LoaiSanPham() { TenLoaiSP = "Bộ sản phẩm" });

            context.SanPhams.AddOrUpdate(x => x.TenSP,
                new SanPham() { TenSP = "CẶP NHẪN BẠC TITAN", GiaBan = 199000, AnhBia = "NB00001", MaLoaiSP = 1  },
                new SanPham() { TenSP = "Nhẫn bạc cao cấp trái tim xanh", GiaBan = 250000, AnhBia = "NB00002", MaLoaiSP = 1 },
                new SanPham() { TenSP = "Nhẫn Bạc BJsilver 925 Cóc Ngậm Ngọc đá Synthetic tròn 3li ", GiaBan = 550000, AnhBia = "NB00003", MaLoaiSP = 1 },
                new SanPham() { TenSP = "Nhẫn lá bạc 925", GiaBan = 150000, AnhBia = "NB00004", MaLoaiSP = 1 },
                new SanPham() { TenSP = "Nhẫn Kim Tiền Thần Tài Bạc S925 Hàn Quốc", GiaBan = 70000, AnhBia = "NB00005", MaLoaiSP = 1 });

        }
    }
}
