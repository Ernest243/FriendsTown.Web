using FriendsTown.Data.Repositories;
using FriendsTown.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.WebApi.Controllers
{
    [Route("api")]
    public class FriendController : Controller
    {
        private readonly IFriendRepository _friendRepository;

        public FriendController(IFriendRepository friendRepository) 
        {
            _friendRepository = friendRepository;
        }

        [Route("friends/{name}")]
        [EnableCors]
        [HttpGet]
        public IActionResult ListByName(string name) 
        {
            if (ModelState.IsValid) 
            {
                var friends = _friendRepository.GetByName(name);

                var results = new FriendListPresentation
                {
                    FriendsList = friends.Select(a => new FriendPresentation 
                    {
                        Id = a.Id,
                        Name = a.Name
                    })
                };
                
                return new OkObjectResult(results);
            }
            else 
            {
                return BadRequest("The id is incorrect");
            }
        }
    }
}
