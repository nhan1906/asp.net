namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThemBangThongTinCuaHang : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PThongTinCuaHangOST",
                c => new
                    {
                        Ma = c.Int(nullable: false, identity: true),
                        TenCuaHang = c.String(),
                        SoDienThoai = c.String(),
                    })
                .PrimaryKey(t => t.Ma);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PThongTinCuaHangOST");
        }
    }
}
