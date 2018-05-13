using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using WebFinal.Models;
using PagedList;
using PagedList.Mvc;

namespace WebFinal.Controllers
{
    public class QuanLySanPhamController : Controller
    {

        BanHangModel db = new BanHangModel();
        // GET: QuanLySanPham
        public ActionResult Index(int? page)
        {
            int pageNumber = (page ?? 1);
            int pageSize = 2;
            return View(db.SanPhams.ToList().OrderBy(n=>n.TenSP).ToPagedList(pageNumber, pageSize));
        }

        [HttpGet]
        public ActionResult ThemMoi()
        {
            //Đưa dữ liệu vào dropdownlist
            ViewBag.MaLoaiSP = new SelectList( db.LoaiSanPhams.ToList().OrderBy(n=>n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            return View();
        }

        [HttpPost]
        public ActionResult ThemMoi(SanPham sanPham, HttpPostedFileBase fileUpload)
        {
            //Lưu tên file
            var fileName = Path.GetFileName(fileUpload.FileName);
            //Lưu đường dẫn của file
            var path = Path.Combine(Server.MapPath("~/images/products"), fileName);
            //Kiểm tra hình ảnh đã tồn tại chưa
            if (System.IO.File.Exists(path))
            {
                ViewBag.ThongBao = "Hình ảnh đã tồn tại";
            }
            else
            {
                fileUpload.SaveAs(path);
            }
            //Đưa dữ liệu vào dropdownlist
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPhams.ToList().OrderBy(n => n.TenLoaiSP), "MaLoaiSP", "TenLoaiSP");
            return View();
        }
    }
}