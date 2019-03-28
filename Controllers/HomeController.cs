using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CRUDelicious.Models;

namespace CRUDelicious.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;

        // here we can "inject" our context service into the constructor
        // NOW THE CONTEXT AND CONTROLLER ARE CONNECTED
        public HomeController(MyContext context)
        {
            dbContext = context;
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            List<Dishes> AllDishes = dbContext.Dishes.ToList();
            // Can use LINQ methods to perform queries



            ViewBag.Dishes = AllDishes;

            return View();
        }

        [Route("Create")]
        [HttpPost]
        public IActionResult Create(Dishes newDish)
        {
            if (ModelState.IsValid)
            {
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View("AddDish");
            }

        }
        [Route("AddDish")]
        [HttpGet]
        public IActionResult AddDish()
        {
            return View("AddDish");
        }


        [Route("ViewDish/{id}")]
        [HttpGet]
        public IActionResult ViewDish(int id)
        {
            System.Console.WriteLine(id);
            Dishes ViewDish = dbContext.Dishes.FirstOrDefault(dish => dish.UserId == id);

            ViewBag.ViewDish = ViewDish;

            return View("ViewDish");
        }

        [Route("EditDish/{id}")]
        [HttpGet]
        public IActionResult EditDish(int id)
        {

            return View("EditDish");
        }

        [Route("Update/{id}")]
        [HttpPost]
        public IActionResult Update(Dishes newDish)
        {
            if (ModelState.IsValid)
            {
                System.Console.WriteLine("///////////////////");
                Dishes UpdateDish = dbContext.Dishes.SingleOrDefault(Update => Update.UserId == newDish.UserId);
                UpdateDish.Chef = Request.Form["Chef"];
                UpdateDish.Name = Request.Form["Name"];
                //   Int32.TryParse(Label1.Text, out imageWidth
                int Cals = 0;
                Int32.TryParse(Request.Form["Calories"], out Cals);
                UpdateDish.Calories = Cals;
                int Taste = 0;
                Int32.TryParse(Request.Form["Tastiness"], out Taste);
                UpdateDish.Tastiness = Taste;

                UpdateDish.Text = Request.Form["Text"];

                dbContext.SaveChanges();

                System.Console.WriteLine("?????????????????");
                System.Console.WriteLine(Request.Form["Calories"]);

                return RedirectToAction("Index");
            }
            else{
                System.Console.WriteLine("**********************");
                return View("EditDish");
            }


            


            ;
        }

    }
}

