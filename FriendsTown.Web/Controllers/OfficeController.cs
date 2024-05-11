using FriendsTown.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FriendsTown.Web.Controllers
{
    [Route("api")]
    [ApiController]
    public class OfficeController : Controller
    {
        [Route("Offices")]
        [HttpGet]
        public List<Office> GetAll() 
        {
            var officeService = new Office();

            return officeService.GetAll();
        }

        [Route("Offices/{code}")]
        [HttpGet]
        public IActionResult FindById(string code) 
        {
            var officeService = new Office();
            var office = officeService.GetAll()
                .FirstOrDefault(o => o.Code == code);

            if (office != null)
            {
                return Ok(office);
            }
            else 
            {
                return NotFound();
            }
        }

        [Route("Offices")]
        [HttpPost]
        public IActionResult Add(Office office) 
        {
            var officeService = new Office();
            var officeList = officeService.GetAll();
            officeList.Add(office);

            string url = $"/api/offices/{office.Code}";

            return Created(url, officeList);
        }

        [Route("Offices")]
        [HttpPut]
        public IActionResult Update (Office office) 
        {
            if (string.IsNullOrEmpty(office.Code) || string.IsNullOrEmpty(office.Name))
            {
                return BadRequest();
            }
            
            var officeService = new Office();
            var officeToUpdate = officeService.GetAll()
                .FirstOrDefault(o => o.Code == office.Code);

            if (officeToUpdate == null) 
            {
                return NotFound();
            }

            officeToUpdate.Name = office.Name;

            return Ok(officeToUpdate);
        }

        [Route("Offices")]
        [HttpDelete]
        public IActionResult Delete(string code) 
        {
            var officeService = new Office();
            var officeList = officeService.GetAll();
            var deletedCount = officeList.RemoveAll(o => o.Code == code);

            if (deletedCount > 0) 
            {
                return Ok(officeList);
            }

            return NotFound();
        }
    }
}
