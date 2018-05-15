namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MergeCodeFileKhachHangVaKhachHangDangNhap : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHang", "HoTen", c => c.String(nullable: false));
            AlterColumn("dbo.KhachHang", "MatKhau", c => c.String(nullable: false, unicode: false));
            AlterColumn("dbo.KhachHang", "GioiTinh", c => c.String());
            AlterColumn("dbo.KhachHang", "NgaySinh", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHang", "NgaySinh", c => c.DateTime());
            AlterColumn("dbo.KhachHang", "GioiTinh", c => c.String(maxLength: 3));
            AlterColumn("dbo.KhachHang", "MatKhau", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KhachHang", "HoTen", c => c.String(maxLength: 50));
        }
    }
}
