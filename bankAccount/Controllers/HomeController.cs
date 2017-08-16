using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using bankAccount.Models;

namespace bankAccount.Controllers
{
    public class HomeController : Controller
    {
        private BankContext _context;
    
        public HomeController(BankContext context)
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
        
        //LOGIN AS LINK
        [HttpGet]
        [Route("Login")]

        public IActionResult Login()
        {
            return View("Login");
        }

        //LOGOUT AS LINK
        [HttpGet]
        [Route("ClearSession")]

        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return View("Login");
        }

        //LOGIN W/ LOGIC
        [HttpPost]
        [Route("Login")]

        public IActionResult Login(string Email, string LoginPass)
        {
            System.Console.WriteLine("in login");
            User LoginUser = _context.Users.SingleOrDefault(user => user.Email == Email);

            if (LoginUser != null && LoginPass != null)
            //check to see if the user exists
            //checks if not empty
            {
                var HashPass = new PasswordHasher<User>();
                
                if (0 != HashPass.VerifyHashedPassword(LoginUser, LoginUser.Password, LoginPass))
                { 
                    HttpContext.Session.SetString("FirstName", LoginUser.FirstName);
                    HttpContext.Session.SetInt32("UserId", LoginUser.UserId);
        
                    //check to see if the email matches
                    return RedirectToAction("Account", new {UserId = LoginUser.UserId});
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
                    Email = Model.Email,
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

                User CurrUser = _context.Users.SingleOrDefault(user => user.Email == Model.Email);
                //SingleOrDefault assumes that there is a single item and returns it (or default if none exists). Multiple items are a violation of contract, an exception is thrown.
                HttpContext.Session.SetString("FirstName", CurrUser.FirstName);
                HttpContext.Session.SetInt32("UserId", CurrUser.UserId);
                return RedirectToAction("Account", new {UserId = CurrUser.UserId});
                //maybe add this:  new {UserId = CurrUser.UserId}
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

        //++++++++++++++
        //THIS IS NOW TRANSACTIONS
        //++++++++++++++

        //ACCOUNT GET
        [HttpGet]
        [Route("Account/{UserId}")]

        public IActionResult Account(int UserId)
        {
            string LoginUserName = ViewBag.User = HttpContext.Session.GetString("FirstName");
            int? LoginUserId = ViewBag.User = HttpContext.Session.GetInt32("UserId");
            
            if (UserId != LoginUserId)
            {
                System.Console.WriteLine("not able to view this account");
                return RedirectToAction("Register", "User");
            }

            ViewBag.Name = LoginUserName;
            ViewBag.Id = LoginUserId;

            List<Transaction> Transactions = _context.Transactions.Where(transaction => transaction.UserId == LoginUserId).ToList();

            ViewBag.Transactions = Transactions;
            System.Console.WriteLine("in account before money");

            double money = 0.00;
            foreach (var transaction in Transactions)
            {
                money = money + transaction.Amount;
            }

            ViewBag.Money = money;
            System.Console.WriteLine(money);
            return View();
        }

        //ACCOUNT POST
        [HttpPost]
        [Route("Process")]

        public IActionResult Process(double amount)
        {
            string LoginUserName = ViewBag.User = HttpContext.Session.GetString("FirstName");
            int? LoginUserId = ViewBag.User = HttpContext.Session.GetInt32("UserId");

            Transaction NewTransaction = new Transaction
            {
                Amount = amount,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
                UserId = (int)LoginUserId
            };

            _context.Add(NewTransaction);
            _context.SaveChanges();
            return RedirectToAction("Account", new {UserId = LoginUserId});
        }
    }
}
