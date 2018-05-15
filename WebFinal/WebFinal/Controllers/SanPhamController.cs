using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;
using PagedList;
using PagedList.Mvc;

namespace WebFinal.Controllers
{
    public class SanPhamController : Controller
    {

        BanHangModel db = new BanHangModel();
        

        public ViewResult Index(int maSP=-1)
        {
            SanPham sp = db.SanPhams.SingleOrDefault(n => n.MaSP == maSP);
            if (sp == null)
            {
                Response.StatusCode = 404;
                // TODO 
                return null;
            }
            return View(sp);
        }

 /*       public PartialViewResult _Products(int? page)
        {
            //Tạo biến số sản phẩm trên trang
            int pageSize = 10;
            //Tạo biến số trang
            int pageNumber = (page ?? 1);
            return PartialView(db.SanPhams.ToList().OrderBy(n=> n.GiaBan).ToPagedList(pageNumber, pageSize));
        }
*/
        public PartialViewResult _SanPhamTheoLoai(int MaLoaiSP)
        {
            var sanPhams = db.SanPhams.Where(n => n.MaLoaiSP == MaLoaiSP).Take(10).ToList();
            return PartialView(sanPhams);
        }
        
    }
} 