using Case.Solution.Application.DTOs;
using Case.Solution.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case.Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class PeopleController : ControllerBase
    {
		private readonly PersonService _service;
		public PeopleController(PersonService service) => _service = service;

		[HttpGet]
		public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

		[HttpGet("{id:guid}")]
		public async Task<IActionResult> Get(Guid id)
		{
			var p = await _service.GetByIdAsync(id);
			return p == null ? NotFound() : Ok(p);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromBody] CreatePersonDto dto)
		{
			try
			{
				var created = await _service.CreateAsync(dto);
				return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
			}
			catch (ArgumentException ex)
			{
				return BadRequest(new { error = ex.Message });
			}
		}

		[HttpPut("{id:guid}")]
		public async Task<IActionResult> Update(Guid id, [FromBody] CreatePersonDto dto)
		{
			var updated = await _service.UpdateAsync(id, dto);
			if (updated == null) return NotFound();
			return Ok(updated);
		}

		[HttpDelete("{id:guid}")]
		public async Task<IActionResult> Delete(Guid id)
		{
			var ok = await _service.DeleteAsync(id);
			return ok ? NoContent() : NotFound();
		}
	}
}
