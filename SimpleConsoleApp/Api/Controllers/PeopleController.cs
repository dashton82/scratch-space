using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]/")]
    public class PeopleController
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetAll()
        {
            return new OkResult();
        }
    }
}