using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BigSchool.Models;

namespace BigSchool.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
            _dbContext = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcommingCourse = _dbContext.Coureses
              .Include(c => c.Lecturer)
              .Include(c => c.Category)
              .Where(c => c.DateTime > DateTime.Now);
            return View(upcommingCourse);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        private ApplicationDbContext _dbContext;
        
    }
}