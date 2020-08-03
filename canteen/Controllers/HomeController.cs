using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using canteen.Models;
using canteen.Tai;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using PagedList;
using PagedList.Mvc;

namespace canteen.Controllers
{
    public class HomeController : Controller
    {
        SEP23Team9Entities1 db = new SEP23Team9Entities1();
        public ActionResult Index(int page = 1,int pageSize =1)
        {
            

            var tai = new IndexTai();
            var model = tai.ListAllPaging(page, pageSize);
            return View(model);
        }

        public void SignIn()
        {
            HttpContext.GetOwinContext().Authentication.Challenge(
                new AuthenticationProperties { RedirectUri = "/" },
                OpenIdConnectAuthenticationDefaults.AuthenticationType);
        }

        public void SignOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(
                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                CookieAuthenticationDefaults.AuthenticationType);
        }


        public ActionResult About()
        {
            
            return View();
        }

        public ActionResult Contact()
        {


            return View();
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var food = db.Food1.FirstOrDefault(x => x.Food_ID == id);
            return View(food);
        }
        
       
    }
}