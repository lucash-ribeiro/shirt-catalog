using Microsoft.AspNetCore.Mvc;
using ShirtCatalog.Application.InputModels;
using ShirtCatalog.Application.Services.Interfaces;
using ShirtCatalog.Application.ViewModel;

namespace ShirtCatalog.API.Controllers
{
    [Route("api/shirts/[action]")]
    public class ShirtController : ControllerBase
    {
        private readonly IShirtService _shirtService;
        public ShirtController(IShirtService shirtService)
        {
            _shirtService = shirtService;
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var shirt = _shirtService.GetById(id);

            if (shirt == null)
            {
                return NotFound();
            }

            return Ok(shirt);
        }

        [HttpGet]
        public async Task<ActionResult<ShirtDetailsViewModel>> Get()
        {
            var shirts = await _shirtService.GetAll();

            if (shirts == null)
            {
                return NotFound();     
            }

            return Ok(shirts);
        }

        [HttpPost]
        public IActionResult Post([FromBody] NewShirtInputModel inputModel)
        {
            var id = _shirtService.Create(inputModel);

            return CreatedAtAction(nameof(GetById), new { id = id }, inputModel);
        }

        [HttpPut]
        public IActionResult Put([FromBody] UpdateShirtInputModel inputModel)
        {
            _shirtService.Update(inputModel);

            return NoContent();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _shirtService.Delete(id);

            return NoContent();
        }
    }
}
