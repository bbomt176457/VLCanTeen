using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;

namespace canteen.Areas.Admin.Controllers
{
    public class LoginAdminController : Controller
    {
       

            private SEP23Team9Entities1 db = new SEP23Team9Entities1();

            // GET: Login
            public ActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Index(LoginModel user)
            {
                AdminWeb admin = db.AdminWebs.Where(x => x.Email == user.Email && x.Password == user.Password).FirstOrDefault();
                if (admin != null)
                {
                    Session.Add("Id", admin.id);
                    Session.Timeout = 720;
                }

                return RedirectToAction("Index", "adminFood");
            }

            public ActionResult Logout()
            {
                Session.Clear();

                return RedirectToAction("Index", "LoginAdmin");
            }

        }
    }
