using FriendsTown.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using FriendsTown.Domain;
using FriendsTown.Web.Models;

namespace FriendsTown.Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public IActionResult Index() 
        {
            var notice = _newsRepository.GetAll();

            var model = notice.Select(a => new NewsViewModel
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

                return RedirectToAction("Index");
            }
            else 
            {
                return View(model);
            }
        }
    }
}
