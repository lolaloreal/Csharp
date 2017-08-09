using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace quotingDojo.Controllers
{
    public class HomeController : Controller
    {
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            // List<Dictiionary<string, object>> AllUsers = DbConnector.Query("SELECT * FROM users")
            return View();
        }

        [HttpPost]
        [Route("/quotes")]

        public IActionResult AddQuotes(string name, string quote)
        {
            System.Console.WriteLine(name);
            System.Console.WriteLine(quote);
            string query = $"INSERT INTO Users (name, quote, created_at, updated_at) VALUES ('{name}', '{quote}', NOW(), NOW())";
            DbConnector.Execute(query);
            return RedirectToAction("Quotes");
        }

        [HttpGet]
        [Route("/quotes")]

        public IActionResult Quotes()
        {
            string query = "SELECT * from Users";
            var AllUsers = DbConnector.Query(query);
            System.Console.WriteLine(AllUsers);
            ViewBag.AllUsers = AllUsers;
            return View("Results");
        }
    }
}
