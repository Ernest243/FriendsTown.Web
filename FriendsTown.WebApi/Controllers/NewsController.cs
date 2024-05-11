using FriendsTown.Data.Repositories;
using FriendsTown.Domain;
using FriendsTown.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.WebApi.Controllers
{
    [Route("api")]
    public class NewsController : ControllerBase
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository) 
        {
            _newsRepository = newsRepository;
        }

        [Route("news")]
        [HttpGet]
        public IActionResult Index() 
        {
            var newList = _newsRepository.GetAll();

            var result = newList.Select(n => new NewsPresentation
            {
                Id = n.Id,
                Date = n.Date.Value,
                Place = new PlacePresentation 
                {
                    City = n.Place.City,
                    Street = n.Place.Street,
                    Number = n.Place.Number,
                    Reference = n.Place.Reference,
                },
                
                Description = n.Description
            });

            return new OkObjectResult(result);
        }

        [Route("Board")]
        [HttpGet]
        public IActionResult Board() 
        {
            var newsList = _newsRepository.GetAll()
                .OrderBy(n => n.Date.Value);

            var result = newsList.Select(n => new BoardViewModel()
            {
                Description = n.Description,
                NewsDate = n.Date.Annoucement,
                RemainingDays = n.Date.RemainingDays,
                Place = n.Place.ToString()
            });

            return new OkObjectResult(result);
        }

        [Route("news/{id}")]
        [HttpGet]
        public IActionResult FindById(Guid id) 
        {
            if (ModelState.IsValid) 
            {
                var news = _newsRepository.FindById(id);

                if (news == null)
                    return NotFound($"The news {id} doesn't exists.");

                var result = new NewsPresentation
                {
                    Id = news.Id,
                    Date = news.Date.Value,
                    Place = new PlacePresentation 
                    {
                        City = news.Place.City,
                        Street = news.Place.Street,
                        Number = news.Place.Number,
                        Reference = news.Place.Reference
                    },

                    Description = news.Description
                };

                return new OkObjectResult(result);
            }
            else 
            {
                return BadRequest("The id is incorrect");
            }
        }

        [HttpPost]
        [Route("news")]
        public ActionResult Create([FromBody] AddNewsInput news) 
        {
            if (ModelState.IsValid) 
            {
                var newsToAdd = News.Create(
                    Guid.NewGuid(),
                    Date.FromDate(news.Date),
                    Place.Create(news.City, news.Street, news.Number, news.Reference),
                    news.Description);

                _newsRepository.Add(newsToAdd);

                return new CreatedResult($"news/{newsToAdd.Id}", news);
            }

            return BadRequest(ModelState.Values.SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));
        }

        [HttpPut]
        [Route("news")]
        public ActionResult Update([FromBody] EditNewsInput news) 
        {
            if (ModelState.IsValid) 
            {
                var newsToUpdate = _newsRepository.FindById(news.Id);

                if (newsToUpdate is null) 
                {
                    return NotFound($"The news {newsToUpdate.Id} does not exist.");
                }

                newsToUpdate.Update(newsToUpdate.Date, newsToUpdate.Place,
                    news.Description);

                return new OkObjectResult(new { url = $"notice/{news.Id}" });
            }

            return BadRequest(ModelState.Values.SelectMany(v => v.Errors
                    .Select(e => e.ErrorMessage)));
        }

        [HttpDelete]
        [Route("news")]
        public ActionResult Delete(Guid id) 
        {
            if (ModelState.IsValid) 
            {
                _newsRepository.Delete(id);
                return new OkResult();
            }

            return BadRequest("The id is incorrect");
        }
    }
}
