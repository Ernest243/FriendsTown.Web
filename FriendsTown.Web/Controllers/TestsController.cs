using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.Web.Controllers
{
    public class TestsController : Controller
    {
        public ContentResult Index()
        {
            string message = "Welcome to FriendsTown" + $" today is {DateTime.Today}";

            return new ContentResult
            {
                Content = message
            };
        }

        public ContentResult Html() 
        {
            return new ContentResult
            {
                Content = "<h1>Welcome to FriendsTown</h1>",
                ContentType = "html"
            };
        }

        public ContentResult Forbidden() 
        {
            return new ContentResult
            {
                StatusCode = 403
            };
        }

        public JsonResult JsonData() 
        {
            var user = new { Id = 1, Name = "Marry" };

            return new JsonResult(user);
        }

        public ContentResult ShowCode(string id) 
        {
            return new ContentResult 
            {
                Content = $"Received Code: {id}"
            };
        }

        public ContentResult ProcessName (string name) 
        {
            return new ContentResult 
            {
                Content = $"Hi: {name} your name has " + $"{name.Length} letters"
            };
        }

        public ContentResult NetPrice(decimal price, decimal discount) 
        {
            decimal calculatedDiscount = price * discount / 100;
            decimal netPrice = price - calculatedDiscount;

            return new ContentResult 
            {
                Content = $"Price: {price} discount: {calculatedDiscount} " + 
                    $"Net Price: {netPrice}"
            };
        }

        public ViewResult Welcome() 
        {
            ViewBag.Framework = AppContext.TargetFrameworkName;
            ViewBag.Today = DateTime.Today;

            return View();
        }

        public ViewResult BodyMass(decimal? weight, decimal? height) 
        {
            if (weight is not null && height is not null) 
            {
                ViewBag.Index = (weight.Value / (height.Value * height.Value)).ToString("0.00");
            }

            return View();
        }

        public ViewResult Doorman(int age) 
        {
            ViewBag.Age = age;

            return View();
        }

        public ViewResult Multiply(int multiplier) 
        {
            ViewBag.Multiplier = multiplier;

            return View();
        }

        public ViewResult Product() 
        {
            var product = new ProductViewModel
            {
                Code = 2345,
                Name = "Bike",
                Price = 275
            };

            return View(product);
        }
    }
}
