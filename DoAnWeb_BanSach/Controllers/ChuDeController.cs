using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_BanSach.Models;

namespace DoAnWeb_BanSach.Controllers
{
    public class ChuDeController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: ChuDe
        public ActionResult ChuDepartial()
        {
            return PartialView(db.ChuDes.Take(5).ToList());
        }
        public ViewResult SachTheochuDe(int MaChuDe=0)
        {
            ChuDe cd = db.ChuDes.SingleOrDefault(n => n.MaChuDe == MaChuDe);
            if(cd==null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> Lstsach = db.Saches.Where(n => n.MaChuDe == MaChuDe).OrderBy(n => n.GiaBan).ToList();
            if (Lstsach.Count == 0)
            {
                ViewBag.Sach = "Không tìm thấy sách nào theo chủ đề vừa chọn";
            }
            return View(Lstsach);
        }
        // Hiển thị tất cả chủ đề
        public ViewResult DanhMucChuDe()
        {
            return View(db.ChuDes.ToList());
        }
    }
}