using FriendsTown.Data.Repositories;
using FriendsTown.Domain;
using FriendsTown.Web.Hubs;
using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
namespace FriendsTown.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;
        private readonly IHubContext<BoardHub> _hubContext;

        public NewsController(INewsRepository newsRepository,
                              IHubContext<BoardHub> hubContext)
        {
            _newsRepository = newsRepository;
            _hubContext = hubContext;
        }

        public IActionResult Index()
        {
            var noticias = _newsRepository.GetAll();
            var model = noticias.Select(a => new NewsViewModel
            {
                Description = a.Description,
                Date = a.Date.Value,
                City = a.Place.City,
                Street = a.Place.Street,
                Number = a.Place.Number,
                Reference = a.Place.Reference
            });
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new NewsViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(NewsViewModel model)
        {
            if (ModelState.IsValid)
            {
                var news = new News(Guid.NewGuid());
                news.Update(Date.FromDate(model.Date.Value),
                Place.Create(model.City, model.Street, model.Number, model.Reference),
                    model.Description);
                _newsRepository.Add(news);

                _hubContext.Clients.All.SendAsync("newsCreated", $"{news.Id}");

                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Board()
        {
            return View();
        }
    }
}

