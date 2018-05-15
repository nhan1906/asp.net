using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Policy;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
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
        //Action Đăng ký
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(KhachHang khachHang)
        {
            bool Status = false;
            string message = "";
            // Kiểm tra tính toàn vẹn của mô hình.
            if (ModelState.IsValid)
            {
                //Kiểm tra xem người dùng đã có trong DB chưa, dùng địa chỉ email.
                bool isExist = IsEmailExist(khachHang.Email);
                if (isExist)
                {
                    //Nếu đã tồn tại thì thông báo lỗi
                    ModelState.AddModelError("AccountExist", "Tài khoản đã tồn tại với email " + khachHang.Email);
                    return View(khachHang);
                }

                //Băm mật khẩu (hashing). Hàm băm là hàm một chiều tạo ra một chuỗi ngẫu nhiên. Mình sẽ lưu chuỗi này thay vì mật khẩu để đảm bảo bảo mật
                //Khi người dùng đăng nhập thì mình chỉ cần so sánh kết quả của hàm băm với chuỗi đã có trong DB
                //Điều này có nghĩa là không ai có thể biết mật khẩu của người dùng, kể cả quản trị viên.
                string hashed = Hash(khachHang.MatKhau);

                //Thay mật khẩu bằng mã băm
                khachHang.MatKhau = hashed;

                //keyword 'using' dùng cho Class có cài đặt interface IDisposable. Đối tượng đc sử dụng sẽ tự giải phóng tài nguyên (trong trường hợp này là 
                //đối tượng 'db').           
                using (BanHangModel db = new BanHangModel())
                {
                    //Thêm khách hàng vào DB
                    db.KhachHangs.Add(khachHang);
                    db.SaveChanges();

                    message = "Bạn đã đăng ký tài khoản thành công";
                    Status = true;
                }
            }
            else
            {
                message = "Invalid request";
            }

            //Tìm hiểu về Razor để biết nó làm gì
            ViewBag.Message = message;
            ViewBag.Status = Status;

            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangNhap(KhachHangDangNhap ThongTinDangNhap, string ReturnUrl = "")
        {
            string message = "";
            using (BanHangModel m = new BanHangModel())
            {
                var v = m.KhachHangs.FirstOrDefault(a => a.Email == ThongTinDangNhap.EmailID);
                if (v != null)
                {
                    if (String.Compare(Hash(ThongTinDangNhap.Password), v.MatKhau) == 0)
                    {
                        //Tạo cookie để lưu phiên đăng nhập nếu người dùng chọn nhớ
                        int timeOut = ThongTinDangNhap.RememberMe ? 525600 : 20;
                        var ticket = new FormsAuthenticationTicket(ThongTinDangNhap.EmailID, ThongTinDangNhap.RememberMe, timeOut);
                        string encrypted = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encrypted);
                        cookie.Expires = DateTime.Now.AddMinutes(timeOut);
                        cookie.HttpOnly = true;
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(ReturnUrl))
                        {
                            return Redirect(ReturnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                    else
                    {
                        message = "Tài khoản hoặc mật khẩu không đúng";
                    }
                }
                else
                {
                    message = "Tài khoản hoặc mật khẩu không đúng";
                }
            }

            ViewBag.Message = message;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult DangXuat()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("DangNhap", "NguoiDung");
        }

        [NonAction]
        public bool IsEmailExist(string emailID)
        {
            using (BanHangModel m = new BanHangModel())
            {
                var v = m.KhachHangs.FirstOrDefault(a => a.Email == emailID);
                return v != null;
            }
        }

        [NonAction]
        public string Hash(string password)
        {
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }
    }
}
