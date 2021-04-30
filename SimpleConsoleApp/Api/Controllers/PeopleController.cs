using Application;
using Data;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    // configures to help build APIs 
    [ApiController]
    [Route("/api/[controller]/")]
    //ControllerBase is a part of AspNetCore - contains basic functionality controllers need
    public class PeopleController : ControllerBase
    {
        private readonly IPersonService _personService;
        public PeopleController(IPersonService personService)
        {
            _personService = personService;
        }
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            var stuff = _personService.GetPeople();

            return Ok(stuff);
        }
    }
}