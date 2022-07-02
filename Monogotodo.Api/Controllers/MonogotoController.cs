using Monogotodo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Monogotodo.Api.Controllers
{
    [ApiController]
    [Route("crumb")]
    public class MonogotoController: ControllerBase
    {
        private readonly IMonogotoRepository _monogotoRepository;

        public MonogotoController(IMonogotoRepository monogotoRepository)
        {
            _monogotoRepository = monogotoRepository;
        }
        
        [HttpGet]
        public IActionResult GetTest()
        {
            var monogotos = _monogotoRepository.GetMonogotos("SELECT * FROM public.\"Queries\"");
            return Ok("Testing crumb controller");
        }
    }
}