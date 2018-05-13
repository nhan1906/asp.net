namespace WebFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SuaModelChiTietDonHang : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ChiTietDonHang", "DonGia", c => c.Double(nullable: false));
            DropColumn("dbo.ChiTietDonHang", "DonGian");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ChiTietDonHang", "DonGian", c => c.String(maxLength: 10, fixedLength: true));
            DropColumn("dbo.ChiTietDonHang", "DonGia");
        }
    }
}
