using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_BanSach.Models;



namespace DoAnWeb_BanSach.Controllers
{
    public class TimKiemController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        [HttpPost]
        public ActionResult KetQuaTim(FormCollection f)
        {
            string TuKhoa = f["txtTimKiem"].ToString();
            List<Sach> lstKQTK = db.Saches.Where(n => n.TenSach.Contains(TuKhoa)).ToList();
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy sản phẩm.";
                return View(db.Saches.OrderBy(n => n.TenSach));
            }
            return View(lstKQTK.OrderBy(n=>n.TenSach).ToList());
        }
    }
}