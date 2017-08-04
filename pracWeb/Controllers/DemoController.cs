using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
 
namespace pracWeb.Controllers
{
    public class DemoController : Controller
    {
        // [HttpGet]
        // [Route("")]
        // public string Index()
        // {
        //     return "LB Morse!";
        // }


        [HttpGet]
        [Route("card/{FirstName}/{LastName}/{Age}/{FavColor}")]
        public JsonResult CallCard(string FirstName, string LastName, int Age, string FavColor)
        {
            return Json(new {FirstName, LastName, Age, FavColor});
        }      
    }
}