using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using canteen.Models;
using PagedList;

namespace canteen.Controllers
{
    public class MenuFoodController : Controller
    {
        SEP23Team9Entities1 db = new SEP23Team9Entities1();
        // GET: Food
        // xây dựng aciton load sản phẩm theo mã  sản phẩm và mã nhà sản xuất
        
        public ActionResult TrangSanPham(int? IdLoaiSanPham, int? page)
        {

            if (IdLoaiSanPham == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // load sản phẩm dựa vào loại sản phẩm và nhà sản xuất trong bảng sản phẩm
            var lstSanPham = db.Food1.Where(n => n.Category_ID == IdLoaiSanPham);
            if (lstSanPham.Count() == 0)
            {
                // thông báo ko tìm thấy
                return HttpNotFound();
            }
            // thực hiện phân trang
            // tạo biến số sản phẩm trên trang
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int Pagesize = 9;
            // tạo biến số trang hiện tại
            int PageNumber = (page ?? 1);
            ViewBag.IdLoaiSanPham = IdLoaiSanPham;
            return View(lstSanPham.OrderBy(n => n.Food_ID).ToPagedList(PageNumber, Pagesize));
        }
    }
}

