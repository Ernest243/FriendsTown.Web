using FriendsTown.Data.Repositories;
using FriendsTown.Domain;
using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.Web.Controllers
{
    public class ActivityController : Controller
    {
        private readonly IActivityRepository _activityRepository;

        public ActivityController(IActivityRepository activityRepository) 
        {
            _activityRepository = activityRepository;
        }

        public IActionResult Index()
        {
            var activities = _activityRepository.GetAll();

            var model = activities.Select(a => new ActivityViewModel
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description
            });

            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(Guid id) 
        {
            var activity = _activityRepository.FindById(id);

            var model = new ActivityViewModel
            {
                Id = id,
                Name = activity.Name,
                Description = activity.Description
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(ActivityViewModel model) 
        {
            var actividad = new Activity(model.Id);
            actividad.Update(model.Name, model.Description);
            _activityRepository.Update(actividad);

            return RedirectToAction("Index");   
        }

        public IActionResult Details(Guid id) 
        {
            var activity = _activityRepository.FindById(id);

            var model = new ActivityViewModel
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new ActivityViewModel();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ActivityViewModel model) 
        {
            var activity = new Activity(Guid.NewGuid());
            activity.Update(model.Name, model.Description);
            _activityRepository.Add(activity);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(Guid id) 
        {
            var activity = _activityRepository.FindById(id);

            var model = new ActivityViewModel 
            {
                Id = activity.Id,
                Name = activity.Name,
                Description = activity.Description
            };

            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(Guid id) 
        {
            _activityRepository.Delete(id);

            return RedirectToAction("Index");
        }
    }
}
