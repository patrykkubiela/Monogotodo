using Monogotodo.Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Monogotodo.Data.Models;

namespace Monogotodo.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MonogotoController: ControllerBase
    {
        private readonly IMonogotoRepository _monogotoRepository;

        public MonogotoController(IMonogotoRepository monogotoRepository)
        {
            _monogotoRepository = monogotoRepository;
        }
        
        [HttpGet]
        public IActionResult GetMonogotos()
        {
            var monogotos = _monogotoRepository.GetMonogotos().Result;
            return Ok(monogotos);
        }
        
        [HttpGet]
        [Route("{name}")]
        public IActionResult GetMonogotosByName([FromRoute] string name)
        {
            var monogotos = _monogotoRepository.GetMonogotosByName(name).Result;
            return Ok(monogotos);
        }

        [HttpPut]
        public IActionResult PutMonogoto([FromBody] Monogoto monogoto)
        {
            _monogotoRepository.InsertMonogoto(monogoto);
            return Ok("Testing crumb controller");
        }
    }
}