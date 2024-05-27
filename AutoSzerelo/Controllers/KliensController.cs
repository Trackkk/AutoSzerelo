using Microsoft.AspNetCore.Mvc;
using AutoSzerelo.Shared;

namespace AutoSzerelo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class KliensController : ControllerBase
    {
        private readonly IKliensSzolgaltatas _kliensSzolgaltatas;

        public KliensController(IKliensSzolgaltatas kliensSzolgaltatas)
        {
            _kliensSzolgaltatas = kliensSzolgaltatas;
        }

        [HttpGet]
        public async Task<ActionResult<List<Kliens>>> GetAll()
        {
            return Ok(await _kliensSzolgaltatas.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<Kliens>> Get(Guid id)
        {
            var kliens = await _kliensSzolgaltatas.Get(id);

            if (kliens == null)
            {
                return NotFound();
            }

            return kliens;
        }

        [HttpGet("{id:guid}/munka")]
        public async Task<ActionResult<IEnumerable<Munka>>> GetJobsOfClient(Guid id)
        {
            var munkak = await _kliensSzolgaltatas.Get(id);
            if (munkak == null)
            {
                return NotFound();
            }
            return Ok(await _kliensSzolgaltatas.GetJobsOfClient(id));
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Kliens ujKliens)
        {
            if (id != ujKliens.KliensId)
            {
                return BadRequest();
            }

            var letezoKliens = await _kliensSzolgaltatas.Get(id);

            if (letezoKliens is null)
            {
                return NotFound();
            }

            await _kliensSzolgaltatas.Update(ujKliens);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Kliens kliens)
        {
            var letezoKliens = await _kliensSzolgaltatas.Get(kliens.KliensId);

            if (letezoKliens is not null)
            {
                return Conflict();
            }

            await _kliensSzolgaltatas.Add(kliens);

            return Ok();
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> DeleteKliens(Guid id)
        {
            var person = await _kliensSzolgaltatas.Get(id);

            if (person is null)
            {
                return NotFound();
            }

            await _kliensSzolgaltatas.Delete(id);

            return Ok();
        }
    }
}
