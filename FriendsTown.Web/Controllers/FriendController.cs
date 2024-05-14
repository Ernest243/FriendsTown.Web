using FriendsTown.Data.Repositories;
using FriendsTown.Domain;
using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.Web.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendRepository _friendRepository;

        public FriendController(IFriendRepository friendRepository)
        {
            _friendRepository = friendRepository;
        }

        public IActionResult Index() 
        {
            var friends = _friendRepository.GetAll();

            var model = friends.Select(a => new FriendViewModel 
            {
                Name = a.Name,
                Email = a.Email,
                Phone = a.Phone
            });

            return View(model);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            var model = new FriendViewModel();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(FriendViewModel model) 
        {
            var friend = new Friend(Guid.NewGuid());
            friend.Update(model.Name, model.Phone, model.Email, model.Password);
            _friendRepository.Add(friend);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult List() 
        {
            return View();  
        }

        [HttpPost]
        public IActionResult List(string text, [FromServices]IHttpClientFactory clientFactory) 
        {
            var client = clientFactory.CreateClient("FriendsTownWebApi");
            var model = HttpClientJsonExtensions.GetFromJsonAsync<FriendApiModel>
                (client, $"Friends/{text}").Result;

            return View(model);
        }
    }
}
