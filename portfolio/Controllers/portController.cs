using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace portDisplay.Controllers
{
    public class portController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }    

        [HttpGet]
        [Route("project")]
        public IActionResult Portfolio()
        {
            return View("Project");
            //Both of these returns will render the same view (You only need one!)
        }   

        [HttpGet]
        [Route("contact")]
        public IActionResult Contact()
        {
            return View("Contact");
            //Both of these returns will render the same view (You only need one!)
        }   
   }
}