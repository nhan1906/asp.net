namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSeedAndModelKhachHang : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.KhachHang", "TaiKhoan", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KhachHang", "MatKhau", c => c.String(nullable: false, maxLength: 50, unicode: false));
            AlterColumn("dbo.KhachHang", "Email", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.KhachHang", "DienThoai", c => c.String(nullable: false, maxLength: 50, unicode: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.KhachHang", "DienThoai", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.KhachHang", "Email", c => c.String(maxLength: 100));
            AlterColumn("dbo.KhachHang", "MatKhau", c => c.String(maxLength: 50, unicode: false));
            AlterColumn("dbo.KhachHang", "TaiKhoan", c => c.String(maxLength: 50, unicode: false));
        }
    }
}
