using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;
using System.Web.Script.Serialization;
using canteen.Models.Tai;

namespace canteen.Controllers
{

    public class CartController : Controller
    {
        SEP23Team9Entities1 db = new SEP23Team9Entities1();
        private const string CartSession = "CartSession";
        // GET: Cart
        public ActionResult IndexCart()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }

        public RedirectToRouteResult SuaSoLuong(int id, int soluongmoi)
        {
            // tìm carditem muon sua
            List<CartItem> cart = Session[CartSession] as List<CartItem>;
            CartItem itemSua = cart.FirstOrDefault(m => m.Food.Food_ID == id);
            if (itemSua != null)
            {
                itemSua.Amount = soluongmoi;
            }
            return RedirectToAction("IndexCart");

        }
        public RedirectToRouteResult XoaKhoiGio(int id)
        {
            List<CartItem> cart = Session[CartSession] as List<CartItem>;
            CartItem itemXoa = cart.FirstOrDefault(m => m.Food.Food_ID == id);
            if (itemXoa != null)
            {
                cart.Remove(itemXoa);
            }
            return RedirectToAction("IndexCart");
        }
        public ActionResult AddItem(long foodID, int amount)
        {
            var food = new FoodItem().Viewdetail(foodID);
            var cart = Session[CartSession];


            if (cart != null)
            {
                var list = (List<CartItem>)cart;
                if (list.Exists(x => x.Food.Food_ID == foodID))
                {
                    foreach (var item in list)
                    {
                        if (item.Food.Food_ID == foodID)
                        {
                            item.Amount += amount;
                        }
                    }
                }
                else
                {
                    var item = new CartItem();
                    item.Food = food;
                    item.Amount = amount;

                    list.Add(item);
                }
                Session[CartSession] = list;
            }
            else
            {
                var item = new CartItem();
                item.Food = food;
                item.Amount = amount;
                var list = new List<CartItem>();
                list.Add(item);

                Session[CartSession] = list;

            }
            return RedirectToAction("IndexCart");
        }


        public ActionResult CartDetail()
        {
            var cart = Session[CartSession];
            var list = new List<CartItem>();
            if (cart != null)
            {
                list = (List<CartItem>)cart;
            }
            return View(list);
        }
        [HttpPost]
        public ActionResult CartDetail(string time)
        {
            var cart = (List<CartItem>)Session[CartSession];
            var id = 0;
            foreach (var item in cart)
            {
                var order = new Bill();
                order.Date = DateTime.Now;
                order.Time = time;
                order.Price = item.Total;
                order.Amount = item.Amount;
                order.Food_ID = item.Food.Food_ID;
                order.User_ID = 6;
                id = new BillTai().Insert(order);
            }

            foreach (var item in cart)
            {
                var orderDetail = new BillDetail();
                orderDetail.Food_ID = item.Food.Food_ID;
                orderDetail.Bill_ID = id;
                orderDetail.Quantity = item.Amount;
                new BillDetailTai().Insert(orderDetail);
            }
            
            return RedirectToAction("Success", "Cart");
        }
        public ActionResult Success()
        {
            return View();
        }

    }
}
