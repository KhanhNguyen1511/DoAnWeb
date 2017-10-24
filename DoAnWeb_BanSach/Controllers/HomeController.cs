using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnWeb_BanSach.Models;
using System.Web.Mvc;

  
namespace DoAnWeb_BanSach.Controllers
{
    public class HomeController : Controller
    {
        QLBanHangEntities db = new QLBanHangEntities();
        
        // GET: Home
        public ActionResult Index()
        { 
            return View(db.Saches.Where(n =>n.Moi==1).ToList());
        }    
        
    }
}