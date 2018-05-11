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

        public PartialViewResult _Products()
        {
            var sanPhams = db.SanPhams.Take(10).ToList();
            return PartialView(sanPhams);
        }
        
        
    }
} 