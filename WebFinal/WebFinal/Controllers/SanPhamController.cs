﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebFinal.Models;

namespace WebFinal.Controllers
{
    public class SanPhamController : Controller
    {

        BanHangEntities db = new BanHangEntities();
        

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
        
        
    }
} 