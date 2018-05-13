using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;


namespace WebFinal.Controllers
{
    public class NguoiDungController : Controller
    {

        BanHangModel db = new BanHangModel();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang khachHang)
        {
            // Insert dữ liệu
            if (ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["TaiKhoan"].ToString();
            string sMatKhau = f["MatKhau"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => (n.TaiKhoan == sTaiKhoan) && (n.MatKhau == sMatKhau));
                
            if (kh != null)
            {
                ViewBag.ThongBao = "Chúc mừng bạn đăng nhập thành công!";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng!";
            return View();
        }
    }
}