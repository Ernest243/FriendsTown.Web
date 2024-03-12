using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.Web.Controllers
{
    public class ActivityController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<ActivityViewModel>
            {
                new ActivityViewModel { Id = Guid.NewGuid(), Name = "Climbing", Description = "Climb local peaks" },
                new ActivityViewModel { Id = Guid.NewGuid(), Name = "Hiking", 
                    Description = "Walk through natural trails"},
                new ActivityViewModel { Id = Guid.NewGuid(), Name = "Yoga", Description = "Activity in a park" }
            };

            return View(model);
        }

        public IActionResult Edit() 
        {
            var model = new ActivityViewModel 
            {
                Id = Guid.NewGuid(),
                Name = "Climbing",
                Description = "Climb local peaks"
            };

            return View(model);
        }

        public IActionResult Details() 
        {
            var model = new ActivityViewModel
            {
                Id = Guid.NewGuid(),
                Name = "Climbing",
                Description = "Climb local peaks"
            };

            return View(model);
        }
    }
}
