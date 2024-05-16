using FriendsTown.Data.Repositories;
using FriendsTown.Domain;
using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace FriendsTown.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _eventRepository;
        private readonly IActivityRepository _activityRepository;
        private readonly IFriendRepository _friendRepository;

        public EventController(IEventRepository eventRepository, 
        IActivityRepository activityRepository, IFriendRepository friendRepository)
        {
            _eventRepository = eventRepository;
            _activityRepository = activityRepository;
            _friendRepository = friendRepository;
        }

        public IActionResult Index()
        {
            var model = _eventRepository.GetAll()
                .Select(ev => new EventViewModel
                {
                    Id = ev.Id,
                    Date = ev.Date.Value,
                    Activity = ev.ActivityType.Name,
                    Organizer = ev.Organizer.Name,
                    City = ev.Place.City,
                    Street = ev.Place.Street,
                    Number = ev.Place.Number
                });

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var _activities = _activityRepository.GetAll()
                .Select(a => new DropDownViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                });

            var _friends = _friendRepository.GetAll()
                .Select(a => new DropDownViewModel 
                { 
                    Id = a.Id,
                    Name = a.Name
                });
            
            ViewBag.ActivitiesList = JsonSerializer.Serialize(_activities);
            ViewBag.FriendsList = JsonSerializer.Serialize(_friends);

            return View();
        }

        [HttpPost]
        public IActionResult Create (EventInputModel inputModel)
        {
            if (ModelState.IsValid)
            {
                var friend = _friendRepository.FindById(inputModel.IdOrganizer);
                var activity = _activityRepository.FindById(inputModel.IdActivity);
                var date = Date.FromDate(inputModel.Date);
                var place = Place.Create(inputModel.City, inputModel.Street, inputModel.Number, inputModel.Reference);

                var theEvent = new Event(Guid.NewGuid());
                theEvent.Update(friend, activity, date, place);

                _eventRepository.Add(theEvent);

                return RedirectToAction("Index");
            }
            else 
            {
                //var errors = ModelState.Values.SelectMany(x => x.Errors);
                return View();  
            }
        }

        public IActionResult Details(Guid id)
        {
            var theEvent = _eventRepository.FindById(id);
            var eventData = new 
            {
                date = theEvent.Date.Value,
                activity = theEvent.ActivityType.Name,
                organizer = theEvent.Place.City,
                street = theEvent.Place.Street,
                number = theEvent.Place.Number,
                reference = theEvent.Place.Reference
            };

            string stringData = JsonSerializer.Serialize(eventData);
            ViewBag.Data = stringData;

            return View();
        }
    }
}