using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using logReg.Models;

namespace logReg.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbConnector _DbConnector;

        public HomeController(DbConnector connect)
        {
            _DbConnector = connect;
        }
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.Errors = new List<string>();
            //Errors can be accessed via ViewBag
            return View();
        }


        [HttpPost]
        [Route("AddUser")]
        public IActionResult AddUser(User NewUser)
        //this compares the data added directly to the model
        //instantiating a new user
        {
            if (ModelState.IsValid)
            //seeing if the data added is valid
            {            
                System.Console.WriteLine(NewUser);
                string query = $"INSERT INTO logUsers (first_name, last_name, email, password, created_at, updated_at) VALUES ('{NewUser.FirstName}', '{NewUser.LastName}', '{NewUser.Email}', '{NewUser.Password}', NOW(), NOW())";
                //make a string to query
                _DbConnector.Execute(query);
                //adding the string into the DB
                string AddUserQuery = "SELECT * FROM logUsers ORDER BY userId DESC LIMIT 1";
                //get the most recently added user (should be who was last registered)
                var CurrUser = _DbConnector.Query(AddUserQuery);
                //setting a variable for the most recently added user
                string UserName = (string)CurrUser[0]["first_name"];
                //setting a variable for FirstName at [0] because it is on top of the stack (most recently added)
                //should match what is in SQL
                int UserId = (int)CurrUser[0]["userId"];
                //setting a variable for UserId at [0] because it is on top of the stack (most recently added)
                //should match what is in SQL
                HttpContext.Session.SetString("UserName", UserName);
                //set session for the UserName must be turned into an object, hence the syntax of ("variable", variable)
                HttpContext.Session.SetInt32("UserId", UserId);
                //set session for the UserId must be turned into an object, hence the syntax of ("variable", variable)
                return RedirectToAction("Results");
                //send to the session code within the results route
            }
            System.Console.WriteLine("Something went wrong");
            return View("Index");
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(string Email, string Password)
        {
            System.Console.WriteLine("In results for log in");
            string query = $"SELECT * FROM logUsers WHERE (email='{Email}' AND password='{Password}')";
            //make a string to query
            var CurrUser = _DbConnector.Query(query);
            //make a variable that is the action of querying the parametetrs of email and password that are provided at log in
            if (CurrUser.Count > 0)
            //if the query was able to find a user matching the params 
            {
                System.Console.WriteLine("In if statement of Results");
                string UserName = (string)CurrUser[0]["first_name"];
                //set variable for UserName by accessing the CurrUser dictionary ([0]) that was provided by the query
                int UserId = (int)CurrUser[0]["userId"];
                //set variable for UserId by accessing the CurrUser dictionary ([0]) that was provided by the query
                HttpContext.Session.SetString("UserName", UserName);
                //set session for the UserName must be turned into an object, hence the syntax of ("variable", variable)
                HttpContext.Session.SetInt32("UserId", UserId);
                //set session for the UserId must be turned into an object, hence the syntax of ("variable", variable)
                return RedirectToAction("Results");
                //*******************/
                //UPDATE WHERE I WANT THIS TO GO
                //******************/
            }
            System.Console.WriteLine("Something went wrong in the if statement of results");
            ViewBag.Errors = new List<string>
            {
                "Something went wrong. Invalid email or password."
            };
            return View("Index");
        }

        [HttpGet]
        [Route("Results")]
        public IActionResult Results()
        {
            string CurrUser = HttpContext.Session.GetString("UserName");
            //set variable for session string of UserName
            int? CurrUserId = HttpContext.Session.GetInt32("UserId");
            //set variable for session string of UserId
            System.Console.WriteLine(CurrUser);
            System.Console.WriteLine(CurrUserId);
            ViewBag.CurrUser = CurrUser;
            //create access for the session variable CurrUser via ViewBag 
            ViewBag.CurrUserId = CurrUserId;
            //create access for the session variable CurrUserId via ViewBag
            return View();
        }


        [HttpGet]
        [Route("ClearSession")]
        public IActionResult ClearSession()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
