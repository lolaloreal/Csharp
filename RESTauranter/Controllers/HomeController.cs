using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;
using RESTauranter.Models;

namespace RESTauranter.Controllers
{
    public class HomeController : Controller
    {
        private RestContext _context;
    
        public HomeController(RestContext context)
        {
            _context = context;
        }

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("AddReview")]

        public IActionResult AddReview(Review NewReview)
        {
            if(ModelState.IsValid)
            {
                System.Console.WriteLine($"Model is Valid {NewReview}.");
                NewReview.CreatedAt = DateTime.Now;
                NewReview.UpdatedAt = DateTime.Now;
                _context.Add(NewReview);
                _context.SaveChanges();
                //add and commit
                return RedirectToAction("Show");
            }
            else
            {
                System.Console.WriteLine("Model is NOT Valid");
                return View("Index");
            }
            // System.Console.WriteLine(NewReview);
            // _context.Add(NewReview);
            // _context.SaveChanges();
            // return RedirectToAction("Results");
        }

        [HttpGet]
        [Route("Show")]
        public IActionResult Show()
        {
            List<Review> AllReviews = _context.Reviews.ToList();
            ViewBag.AllReviews = AllReviews;
            return View("Results");
            //no specification will lead to the show html
            // ViewBag.review = _context.Reviews.OrderByDescending(r => r.CreatedAt);
            // return View("Reults");

        }
    }
}
