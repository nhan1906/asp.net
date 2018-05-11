using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class LoaiSanPhamController : Controller
    {

        BanHangModel db = new BanHangModel();

        // GET: SanPham
        public ViewResult Index(int MaLoaiSP = -1)
        {
            LoaiSanPham loai = db.LoaiSanPhams.SingleOrDefault(n => n.MaLoaiSP == MaLoaiSP);
            if (loai == null)
            {
                Response.StatusCode = 404;
                // TODO 
                return null;
            }
            List<SanPham> sanPhams = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP).OrderBy(n => n.GiaBan).ToList();
            if (sanPhams.Count == 0)
            {
                ViewBag.SanPham = "Không có sản phẩm nào thuộc chủ đề này!";
            }
            return View(sanPhams);
        }


        public PartialViewResult _LoaiSanPhamMenuChinh()
        {
            var loaiSanPhams = db.LoaiSanPhams.ToList();
            return PartialView(loaiSanPhams);
        }


        public PartialViewResult _LoaiSanPhamMenuTrai()
        {
            var loaiSanPhams = db.LoaiSanPhams.ToList();
            return PartialView(loaiSanPhams);
        }

        public PartialViewResult _LoaiSanPhamHome()
        {
            var loaiSanPhams = db.LoaiSanPhams.ToList();
            return PartialView(loaiSanPhams);
        }

        public PartialViewResult _DanhSachSanPham()
        {
            var sanPhams = db.SanPhams.ToList();
            return PartialView(sanPhams);
        }
        
        //Hiển thị view categories trang chủ
        public PartialViewResult _Categories()
        {
            var loaiSanPhams = db.LoaiSanPhams.ToList();
            return PartialView(loaiSanPhams);
        }
    }
}