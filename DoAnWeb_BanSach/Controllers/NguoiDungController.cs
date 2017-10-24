using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_BanSach.Models;

namespace DoAnWeb_BanSach.Controllers
{
    public class NguoiDungController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: NguoiDung
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DangKy(KhachHang kh)
        {
            if (ModelState.IsValid)
            {
                //insert data vào bảng khách hàng
                db.KhachHangs.Add(kh);
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
            String sTaikhoan = f["txtTaiKhoan"].ToString();
            String sMatkhau = f["txtMatKhau"].ToString();
            KhachHang kh = db.KhachHangs.SingleOrDefault(n => n.TaiKhoan == sTaikhoan && n.MatKhau == sMatkhau);
            if (kh != null)
            {
                ViewBag.ThongBao = "Đăng nhập thành công";
                Session["TaiKhoan"] = kh;
                return View();
            }
            ViewBag.ThongBao = "Tên tài khoản hoặc mật khẩu không đúng";          
            return View();
        }

    }
}