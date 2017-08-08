using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace randPass.Controllers
{
    public class randController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int? RandCount = HttpContext.Session.GetInt32("RandCount");
            if(RandCount == null){
                RandCount = 0;
            }
            RandCount++;
            string Input = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string Passcode = "";
            Random Rand = new Random();
            for (int i = 0; i < 14; i++)
            {
                Passcode = Passcode + Input[Rand.Next(0, Input.Length)];
            }
            ViewBag.Passcode = Passcode;
            ViewBag.RandCount = RandCount;
            HttpContext.Session.SetInt32("RandCount", (int)RandCount);
            return View("Index");
            //Both of these returns will render the same view (You only need one!)
        }     
   }
}