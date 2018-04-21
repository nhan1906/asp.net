using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class SanPhamController : Controller
    {

        BanHangModel db = new BanHangModel();
        // GET: SanPham
        public ActionResult Index()
        {
            return View();  
        }

        public ViewResult XemChiTiet(int maSP)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == maSP);
            //if (sp == null)
            //{
             //   Response.StatusCode = 404;
              //  return null;
            //}
            return View(sp);
        }

        public PartialViewResult DanhSachLoaiSanPham()
        {
            var loaiSanPhams = db.LoaiSanPhams.ToList();
            return PartialView(loaiSanPhams);
        }
    }
}