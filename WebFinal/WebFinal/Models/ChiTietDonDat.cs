using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebFinal.Models
{
    public class ChiTietDonDat
    {

        BanHangModel db = new BanHangModel();
        public int iMaSP { get; set; }
        public string sTenSP { get; set; }
        public string sHinhAnh { get; set; }
        public double dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien
        {
            get { return iSoLuong * dDonGia; }
        }

        //Hàm tạo cho giỏ hàng
        public ChiTietDonDat(int iMaSP)
        {
            this.iMaSP = iMaSP;
            SanPham sp = db.SanPhams.Single(n => n.MaSP == iMaSP);
            sTenSP = sp.TenSP;
            sHinhAnh = sp.AnhBia;
            dDonGia = double.Parse(sp.GiaBan.ToString());
            iSoLuong = 1;
        }
    }
}