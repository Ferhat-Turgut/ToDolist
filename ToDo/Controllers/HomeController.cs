using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ToDo.Models;

namespace ToDo.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext context=new DatabaseContext();

        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Index(string UserName, string Password)
        {
            //Kullanıcı Giriş kontrolü
            var LogControl = context.Users.FirstOrDefault(p => p.UserName == UserName && p.Password == Password);
            if (LogControl != null)
            {
                
                HttpContext.Session.SetString("UserName", UserName);
                HttpContext.Session.SetInt32("id",LogControl.Id);
                TempData["Sessionname"] = HttpContext.Session.GetString("UserName");
                TempData["Sessionid"] = HttpContext.Session.GetInt32("id");

                return RedirectToAction("Index", "Plans");
            }
            
            else return View(TempData["LoginError"] = "Please check your information!"); 
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return Redirect("Index");
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            var RegisterControl = context.Users.FirstOrDefault(p => p.UserName == user.UserName);
            if (RegisterControl==null)
            {
                context.Users.Add(user);
                context.SaveChanges();
                ViewBag.message = "Successful"; //düzeltilecek
                return Redirect("Index");
            }
            else
            {
                
                ViewBag.message = "This username has been taken"; //düzeltilecek
                return Redirect("Index");
            }
            
        }


    }
}