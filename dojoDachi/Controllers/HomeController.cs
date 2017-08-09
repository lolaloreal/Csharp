using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using dojoDachi.Models;

namespace dojoDachi.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetObjectFromJson<Dachi>("dachi") == null)
            {
                HttpContext.Session.SetObjectAsJson("dachi", new Dachi());
            }
            ViewBag.dachi = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            return View();
        }

        [HttpGet]
        [Route("reset")]

        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("process")]

        public IActionResult Process(string Activity)
        {
            Dachi curDachi = HttpContext.Session.GetObjectFromJson<Dachi>("dachi");
            if (Activity == "Feed")
            {
                curDachi.feed();
                System.Console.WriteLine("Hello");
            }
            else if (Activity == "Work")
            {
                curDachi.work();
            }
            else if (Activity == "Play")
            {
                curDachi.play();
            }
            else if (Activity == "Sleep")
            {
                curDachi.sleep();
            }
            HttpContext.Session.SetObjectAsJson("dachi", curDachi);
            // ViewBag.dachi = curDachi;
            return RedirectToAction("Index");
        }
    }
}
