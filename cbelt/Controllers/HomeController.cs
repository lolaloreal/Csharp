using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using cbelt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace cbelt.Controllers
{
    public class HomeController : Controller
    {
        private CbeltContext _context;
    
        public HomeController(CbeltContext context)
        {
            _context = context;
        }
        
        //++++++++++++++
        //THIS IS USERS
        //++++++++++++++

        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
        

        //LOGOUT AS LINK
        [HttpGet]
        [Route("ClearSession")]

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        //LOGIN W/ LOGIC
        [HttpPost]
        [Route("Login")]

        public IActionResult Login(string Username, string LoginPass)
        {
            System.Console.WriteLine("in login");
            User LoginUser = _context.Users.SingleOrDefault(user => user.Username == Username);

            if (LoginUser != null && LoginPass != null)
            //check to see if the user exists
            //checks if not empty
            {
                var HashPass = new PasswordHasher<User>();
                
                if (0 != HashPass.VerifyHashedPassword(LoginUser, LoginUser.Password, LoginPass))
                { 
                    HttpContext.Session.SetString("Username", LoginUser.Username);
                    HttpContext.Session.SetInt32("UserId", LoginUser.UserId);
        
                    //check to see if the email matches
                    // return RedirectToAction("Account", new {UserId = LoginUser.UserId});
                    return RedirectToAction("Dashboard"); 
                }
            }
            ViewBag.Errors = new List<string>();
            return View("Index");     
        }    

        //REGISTER
        [HttpPost]
        [Route("Register")]

        public IActionResult Register(RegisterViewModel Model)
        {
            if (ModelState.IsValid)
            {           
                System.Console.WriteLine("in register");
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                User NewUser = new User
                {
                    FirstName = Model.FirstName,
                    LastName = Model.LastName,
                    Username = Model.Username,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };

                System.Console.WriteLine("before hash pass");
                NewUser.Password = Hasher.HashPassword(NewUser, Model.Password);

                System.Console.WriteLine("added new user//after hashed pass");
                // NewUser.CreatedAt = DateTime.Now;
                // NewUser.UpdatedAt = DateTime.Now;
                _context.Add(NewUser);
                _context.SaveChanges();

                User CurrUser = _context.Users.FirstOrDefault(user => user.Username == Model.Username);
                //SingleOrDefault assumes that there is a single item and returns it (or default if none exists). Multiple items are a violation of contract, an exception is thrown.
                HttpContext.Session.SetString("Username", CurrUser.Username);
                HttpContext.Session.SetInt32("UserId", CurrUser.UserId);

                double wallet = 1000.00;
                // foreach (var transaction in Transactions)
                // {
                //     money = money + transaction.Amount;
                // }

                ViewBag.Wallet = wallet;
                // return RedirectToAction("Account", new {UserId = CurrUser.UserId});
                return RedirectToAction("Dashboard"); 
                //added above 
            }
            else
            {
                System.Console.WriteLine("else of register//not valid model");
                ViewBag.Errors = new List<string>();
                //will show errors that may have occured
                return View("Index");
            }
        }
        
        //DASH
        //LINK TO DASH//
        [HttpGet]
        [Route("Dashboard")]
        public IActionResult Dashboard()
        {
            int? LoginUserId = HttpContext.Session.GetInt32("UserId");

            if(LoginUserId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.LoginUser = HttpContext.Session.GetString("Username");
            ViewBag.LoginUserId = HttpContext.Session.GetInt32("UserId");

            double Wallet = 1000.00;
            // foreach (var transaction in Transactions)
            // {
            //     money = money + transaction.Amount;
            // }

            ViewBag.Wallet = Wallet;
            ViewBag.CurrUser = _context.Users.SingleOrDefault(user => user.UserId == (int)LoginUserId);

            System.Console.WriteLine(ViewBag.LoginUser);
            System.Console.WriteLine(ViewBag.LoginUserid);

            return View("Dashboard");        
        }   

        [HttpGet]
        [Route("NewAuction")]

        public IActionResult NewAuction()
        {
            int? LoginUserId = HttpContext.Session.GetInt32("UserId");

            if(LoginUserId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.LoginUser = HttpContext.Session.GetString("Username");
            ViewBag.LoginUserId = HttpContext.Session.GetInt32("UserId");

            System.Console.WriteLine(ViewBag.LoginUser);
            System.Console.WriteLine(ViewBag.LoginUserid);

            return View("NewAuction");

        }


        [HttpPost]
        [Route("NewAuction")]
        public IActionResult NewAuction(AuctionViewModel Model)
        {
            int? LoginUserId = HttpContext.Session.GetInt32("UserId");

            if(LoginUserId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.LoginUser = HttpContext.Session.GetString("Username");
            ViewBag.LoginUserId = HttpContext.Session.GetInt32("UserId");
            ViewBag.Errors = new List<string>();

            System.Console.WriteLine("********are you going into model*******");
            if (ModelState.IsValid)
            {
                if (Model.EndDate > DateTime.Now)
                {   
                    System.Console.WriteLine("******in new auction valid******");
                    Auction NewAuction = new Auction
                    {
                        UserId = ViewBag.LoginUserId,
                        ProductName = Model.ProductName,
                        Description = Model.Description,
                        StartingBid = Model.StartingBid,
                        EndDate = Model.EndDate,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now
                    };

                    System.Console.WriteLine("added new auction");
                    // NewUser.CreatedAt = DateTime.Now;
                    // NewUser.UpdatedAt = DateTime.Now;
                    _context.Add(NewAuction);
                    _context.SaveChanges();

                    return RedirectToAction("Dashboard");
                }
                ViewBag.Errors = new List<string>();
                ViewBag.Errors.Add("Must be in the future silly.");
                return RedirectToAction("NewAuction");
            }
            else
            {
                System.Console.WriteLine("else of add auction/not valid model+++++++++++++++");
                ViewBag.Errors = new List<string>();
                
                //will show errors that may have occured
                return View("NewAuction");
            }
        }


        [HttpGet]
        [Route("OneAuction")]

        public IActionResult OneAuction()
        {
            int? LoginUserId = HttpContext.Session.GetInt32("UserId");

            if(LoginUserId == null)
            {
                return RedirectToAction("Index");
            }

            ViewBag.LoginUser = HttpContext.Session.GetString("Username");
            ViewBag.LoginUserId = HttpContext.Session.GetInt32("UserId");

            System.Console.WriteLine(ViewBag.LoginUser);
            System.Console.WriteLine(ViewBag.LoginUserid);

            return View("OneAuction");

        }
    }
}
