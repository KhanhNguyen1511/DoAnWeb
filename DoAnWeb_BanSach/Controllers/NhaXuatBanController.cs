using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnWeb_BanSach.Models;

namespace DoAnWeb_BanSach.Controllers
{
    public class NhaXuatBanController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        // GET: NhaXuatBan
        public PartialViewResult NXBpartial()
        {
            return PartialView(db.NhaXuatBans.Take(6).OrderBy(n =>n.TenNXB).ToList());
        }
        public ViewResult SachTheoNXB(int MaNXB=0)
        {
            NhaXuatBan nxb = db.NhaXuatBans.SingleOrDefault(n => n.MaNXB == MaNXB);
            if (nxb == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<Sach> Lstsach = db.Saches.Where(n => n.MaNXB == MaNXB).OrderBy(n => n.GiaBan).ToList();
            if (Lstsach.Count == 0)
            {
                ViewBag.Sach = "Không tìm thấy sách nào theo NXB vừa chọn";
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