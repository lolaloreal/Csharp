using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace dojoSurvey.Controllers
{
    public class dojoController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }   

        [HttpPost]
        [Route("process")]
        public IActionResult Process(string name, string moon, string planet, string comment)
        {
            // Do something with form input
            ViewBag.Name = name;
            ViewBag.Moon = moon;
            ViewBag.Planet = planet;
            ViewBag.Comment = comment;
            return View("Results");

        } 

        [HttpGet]
        [Route("results")]
        public IActionResult Results()
        {
            return View("Results");
            //Both of these returns will render the same view (You only need one!)
        }   

        // [HttpGet]
        // [Route("contact")]
        // public IActionResult Contact()
        // {
        //     return View("Contact");
        //     //Both of these returns will render the same view (You only need one!)
        // }   
   }
}