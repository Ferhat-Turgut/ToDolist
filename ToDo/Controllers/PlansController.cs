using Azure.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDo.Filters;
using ToDo.Models;

namespace ToDo.Controllers
{
    [UserFilter]
    public class PlansController : Controller
    {
        
        DatabaseContext context=new DatabaseContext();
        public IActionResult Index()
        {
            //Session id deki değere uyan plan veritabanındaki verileri getirdik.
            int? UserLogId = HttpContext.Session.GetInt32("id");
            var model = context.Plans.Where(p=> p.UserId== UserLogId).ToList();
            var user = context.Users.Where(n => n.Id == UserLogId).FirstOrDefault();
            TempData["UserName"] = user.UserName;
            TempData["Name"] = user.Name;
            TempData["Surname"] = user.SurName;
            
           
            return View(model);
        }
        public  IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Plan plan)
        {
            try
            {
                plan.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                context.Plans.Add(plan);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Edit(int id)
        {
            var model = context.Plans.Find(id);
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id,Plan plan)
        {
            try
            {
                plan.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                context.Plans.Update(plan);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }
        public IActionResult Details(int id)
        {
            var model = context.Plans.Find(id);
            
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var model = context.Plans.Find(id);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id,Plan plan)
        {
            try
            {
                plan.UserId = Convert.ToInt32(HttpContext.Session.GetInt32("id"));
                context.Plans.Remove(plan);
                context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch (Exception)
            {
                return View();
            }
        }

    }
}
