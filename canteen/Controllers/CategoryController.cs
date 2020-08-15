using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;

namespace canteen.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        SEP23Team9Entities1 db = new SEP23Team9Entities1();
        public ActionResult Index()
        {
            //tạo ra các Viewbag để load ra sản phẩm
            // tạo list thức ăn
            var lstQAM = db.Food1.Where(n => n.Category_ID == 1 ).ToList().OrderBy(n => n.Price);
            //gán vào viewbang
            ViewBag.lstQAM = lstQAM;
            // list đồ uống
            var lstMPM = db.Food1.Where(n => n.Category_ID == 2 ).ToList().OrderBy(n => n.Price);
            //gán vào viewbang
            ViewBag.lstMPM = lstMPM;
            
           return View();
        }
        public ActionResult MenuPartial()
        {
            // truy vấn list sản phẩm
            var lstSanPham = db.Food1;
            return PartialView(lstSanPham);
        }
    }
}