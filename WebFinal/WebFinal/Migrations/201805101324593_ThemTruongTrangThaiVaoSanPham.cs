namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemTruongTrangThaiVaoSanPham : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChiTietDonHang",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false),
                        MaSP = c.Int(nullable: false),
                        SoLuong = c.Int(),
                        DonGian = c.String(maxLength: 10, fixedLength: true),
                    })
                .PrimaryKey(t => new { t.MaDonHang, t.MaSP })
                .ForeignKey("dbo.DonHang", t => t.MaDonHang)
                .ForeignKey("dbo.SanPham", t => t.MaSP)
                .Index(t => t.MaDonHang)
                .Index(t => t.MaSP);
            
            CreateTable(
                "dbo.DonHang",
                c => new
                    {
                        MaDonHang = c.Int(nullable: false, identity: true),
                        DaThanhToan = c.Int(),
                        TinhTrangGiaoHang = c.Int(),
                        NgayDat = c.DateTime(),
                        NgayGiao = c.DateTime(),
                        MaKH = c.Int(),
                    })
                .PrimaryKey(t => t.MaDonHang)
                .ForeignKey("dbo.KhachHang", t => t.MaKH)
                .Index(t => t.MaKH);
            
            CreateTable(
                "dbo.KhachHang",
                c => new
                    {
                        MaKH = c.Int(nullable: false, identity: true),
                        HoTen = c.String(maxLength: 50),
                        TaiKhoan = c.String(maxLength: 50, unicode: false),
                        MatKhau = c.String(maxLength: 50, unicode: false),
                        Email = c.String(maxLength: 100),
                        DiaChi = c.String(maxLength: 200),
                        DienThoai = c.String(maxLength: 50, unicode: false),
                        GioiTinh = c.String(maxLength: 3),
                        NgaySinh = c.DateTime(),
                    })
                .PrimaryKey(t => t.MaKH);
            
            CreateTable(
                "dbo.SanPham",
                c => new
                    {
                        MaSP = c.Int(nullable: false, identity: true),
                        TenSP = c.String(maxLength: 100),
                        GiaBan = c.Decimal(precision: 18, scale: 0),
                        MoTa = c.String(),
                        AnhBia = c.String(maxLength: 50),
                        TrangThai = c.Int(nullable: false, defaultValueSql: "0"),
                        NgayCapNhat = c.DateTime(),
                        MaLoaiSP = c.Int(),
                    })
                .PrimaryKey(t => t.MaSP)
                .ForeignKey("dbo.LoaiSanPham", t => t.MaLoaiSP)
                .Index(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.LoaiSanPham",
                c => new
                    {
                        MaLoaiSP = c.Int(nullable: false, identity: true),
                        TenLoaiSP = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.MaLoaiSP);
            
            CreateTable(
                "dbo.POST_PARENT",
                c => new
                    {
                        MaPostParent = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.MaPostParent);
            
            CreateTable(
                "dbo.POST",
                c => new
                    {
                        MaBai = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 200),
                        Content = c.String(),
                        MaPostParent = c.Int(),
                    })
                .PrimaryKey(t => t.MaBai)
                .ForeignKey("dbo.POST_PARENT", t => t.MaPostParent)
                .Index(t => t.MaPostParent);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.POST", "MaPostParent", "dbo.POST_PARENT");
            DropForeignKey("dbo.SanPham", "MaLoaiSP", "dbo.LoaiSanPham");
            DropForeignKey("dbo.ChiTietDonHang", "MaSP", "dbo.SanPham");
            DropForeignKey("dbo.DonHang", "MaKH", "dbo.KhachHang");
            DropForeignKey("dbo.ChiTietDonHang", "MaDonHang", "dbo.DonHang");
            DropIndex("dbo.POST", new[] { "MaPostParent" });
            DropIndex("dbo.SanPham", new[] { "MaLoaiSP" });
            DropIndex("dbo.DonHang", new[] { "MaKH" });
            DropIndex("dbo.ChiTietDonHang", new[] { "MaSP" });
            DropIndex("dbo.ChiTietDonHang", new[] { "MaDonHang" });
            DropTable("dbo.POST");
            DropTable("dbo.POST_PARENT");
            DropTable("dbo.LoaiSanPham");
            DropTable("dbo.SanPham");
            DropTable("dbo.KhachHang");
            DropTable("dbo.DonHang");
            DropTable("dbo.ChiTietDonHang");
        }
    }
}
