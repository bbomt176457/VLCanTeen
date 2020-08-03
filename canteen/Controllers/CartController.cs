using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;
using System.Web.Script.Serialization;

namespace canteen.Controllers
{
    public class CartController : Controller
    {
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
       

        public JsonResult Delete(long id)
        {
            var sessionCart =(List<CartItem>)Session[CartSession];
            sessionCart.RemoveAll(x => x.Food.Food_ID == id);
            Session[CartSession] = sessionCart;
            return Json(new
            {
                status = true
            });


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

    }
}