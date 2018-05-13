using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
namespace WebFinal.Controllers
{
    public class GioHangController : Controller
    {

        BanHangModel db = new BanHangModel();
        // Lấy giỏ hàng;
        public List<ChiTietDonDat> LayGioHang()
        {
            List<ChiTietDonDat> lstGioHang = Session["GioHang"] as List<ChiTietDonDat>;
            if (lstGioHang == null)
            {
                //Nếu giỏ hàng chưa tồn tại thì mình khởi tạo list giỏ hàng (sessionGioHang)
                lstGioHang = new List<ChiTietDonDat> ();
                Session["GioHang"] = lstGioHang;
            }
            return lstGioHang;
        }

        //Thêm giỏ hàng
        public ActionResult ThemGioHang(int MaSP, string strUrl)
        {
            //Kiểm tra xem SanPham có tồn tại người dùng thao tác trên đường dẫn tự tạo
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }

            //Lấy ra session giỏ hàng
            List<ChiTietDonDat> lstGioHang = LayGioHang();
            //Sản phẩm mua chưa đã tồn tại trong session 
            ChiTietDonDat gioHang = lstGioHang.Find(n => n.iMaSP == MaSP);
            if (gioHang == null)
            {
                gioHang = new ChiTietDonDat(MaSP);
                lstGioHang.Add(gioHang);
                return Redirect(strUrl);
            }
            else
            {
                gioHang.iSoLuong++;
                return Redirect(strUrl);
            }

        }

        //Cập nhật giỏ hàng
        public ActionResult CapNhatGioHang(int MaSP, FormCollection f)
        {
            //Kiểm tra mssp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<ChiTietDonDat> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            ChiTietDonDat donHang = lstGioHang.SingleOrDefault(n => n.iMaSP == MaSP);
            if (donHang != null)
            {
                donHang.iSoLuong = int.Parse(f["txtSoLuong"].ToString());

            }
            return View("GioHang");
        }

        //Xóa giỏ hàng
        public ActionResult XoaGioHang(int MaSP)
        {
            //Kiểm tra mssp
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy giỏ hàng ra từ session
            List<ChiTietDonDat> lstGioHang = LayGioHang();
            //Kiểm tra sp có tồn tại trong session["GioHang"]
            ChiTietDonDat donHang = lstGioHang.SingleOrDefault(n => n.iMaSP == MaSP);
            //Nếu mà tồn tại thì xóa hết
            if (donHang != null)
            {
                lstGioHang.RemoveAll(n => n.iMaSP == MaSP);
                
            }
            if (lstGioHang.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("GioHang");

        }

        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<ChiTietDonDat> lstGioHang = LayGioHang();
            return View(lstGioHang);
        }

        //Tính tổng số lượng và tổng tiền
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<ChiTietDonDat> lstGioHang = Session["GioHang"] as List<ChiTietDonDat>;
            if (lstGioHang != null)
            {
                iTongSoLuong = lstGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }

        private double TongTien()
        {
            double dTongTien = 0;
            List<ChiTietDonDat> lstGioHang = Session["GioHang"] as List<ChiTietDonDat>;
            if (lstGioHang != null)
            {
                dTongTien = lstGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }

        public PartialViewResult _GioHangPartial()
        {
            if(TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
    }
}