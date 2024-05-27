using AutoSzerelo;
using AutoSzerelo.Shared;
using Microsoft.AspNetCore.Mvc;

namespace MechanicApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MunkaController : ControllerBase
    {
        private readonly IMunkaSzolgaltatas _munkaSzolgaltatas;

        public MunkaController(IMunkaSzolgaltatas munkaSzolgaltatas)
        {
            _munkaSzolgaltatas = munkaSzolgaltatas;
        }

        [HttpGet]
        public async Task<ActionResult<List<Munka>>> GetAll()
        {
            return Ok(await _munkaSzolgaltatas.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Munka>> Get(Guid id)
        {
            var munka = await _munkaSzolgaltatas.Get(id);

            if (munka is null)
            {
                return NotFound();
            }

            return Ok(munka);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Munka ujMunka)
        {
            if (id != ujMunka.MunkaId)
            {
                return BadRequest();
            }

            var letezoMunka = await _munkaSzolgaltatas.Get(id);

            if (letezoMunka is null)
            {
                return NotFound();
            }

            await _munkaSzolgaltatas.Update(ujMunka);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Munka munka)
        {
            var existingJob = await _munkaSzolgaltatas.Get(munka.MunkaId);

            if (existingJob is not null)
            {
                return Conflict();
            }

            await _munkaSzolgaltatas.Add(munka);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var job = await _munkaSzolgaltatas.Get(id);

            if (job is null)
            {
                return NotFound();
            }

            await _munkaSzolgaltatas.Delete(id);

            return Ok();
        }
    }
}