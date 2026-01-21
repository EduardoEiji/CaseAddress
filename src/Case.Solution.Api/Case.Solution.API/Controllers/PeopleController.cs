using Case.Solution.Application.DTOs;
using Case.Solution.Application.Services;
using Case.Solution.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace Case.Solution.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
	public class PeopleController : ControllerBase
    {
		private readonly PersonService _service;
		private readonly ViaCepService _cepService;
		public PeopleController(PersonService service, ViaCepService cepService)
		{
			_service = service;
			_cepService = cepService;
		}

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
				var myEnd = await _cepService.GetAddressByCepAsync(dto.Address.Cep);
				dto.Address.Logradouro = myEnd.Logradouro;
				dto.Address.Localidade = myEnd.Localidade;
				dto.Address.Regiao = myEnd.Regiao;
				dto.Address.Siafi = myEnd.Siafi;
				dto.Address.Bairro = myEnd.Bairro;
				dto.Address.Ddd = myEnd.Ddd;
				dto.Address.Ibge = myEnd.Ibge;
				dto.Address.Siafi =myEnd.Siafi;
				dto.Address.Uf = myEnd.Uf;
				dto.Address.Estado = myEnd.Estado;
				dto.Address.Unidade = myEnd.Unidade;
				dto.Address.Gia = myEnd.Gia;
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
