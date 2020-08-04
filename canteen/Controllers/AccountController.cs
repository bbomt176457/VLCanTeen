using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;

namespace canteen.Controllers
{
    public class AccountController : Controller
    {
        SEP23Team9Entities db = new SEP23Team9Entities();
        // GET: Account
        public ActionResult IndexAccount()
        {
            var food = db.Food1.OrderByDescending(x => x.Food_ID).ToList();



            return View(food);
        }
        [HttpGet]
        public ActionResult DetailsAccount(int id)
        {
            var food = db.Food1.FirstOrDefault(x => x.Food_ID == id);
            return View(food);
        }
        public ActionResult CartAccount()
        {
            return View();
        }
    }
}