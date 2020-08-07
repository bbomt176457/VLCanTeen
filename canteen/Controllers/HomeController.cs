using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        public ActionResult Index(int page = 1, int pageSize = 6)
        {
            var tai = new IndexTai();
            var model = tai.ListAllPaging(page, pageSize);
            UserSave();
            return View(model);
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

        public void UserSave()
        {
            var userclaims = User.Identity as System.Security.Claims.ClaimsIdentity;
            string email = userclaims?.FindFirst("preferred_username")?.Value.ToString();
            string name = userclaims?.FindFirst("name")?.Value.ToString();
            string usertype = "Customer";
            if (userclaims.IsAuthenticated)
            {
                User user = db.Users.FirstOrDefault(x => x.Email == email);
                if (user != null)
                {
                    user.LastAccess = DateTime.Now;
                }
                else
                {
                    user = new User();
                    user.Name = name;
                    user.Email = email;
                    user.Role = usertype;
                    user.LastAccess = DateTime.Now;
                    db.Users.Add(user);
                }
                db.SaveChanges();
            };
        }
    }
}