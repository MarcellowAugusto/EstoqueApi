using EstoqueApi.DTOs;
using EstoqueApi.Services;

using Microsoft.AspNetCore.Mvc;

namespace EstoqueApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstoqueController : ControllerBase
    {
        private readonly EstoqueService _service;

        public EstoqueController(EstoqueService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<List<EstoqueReadDto>>> GetAll()
        {
            var estoques = await _service.GetAll();
            return Ok(estoques);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetById(int id)
        {
            var estoque = await _service.GetById(id);
            if (estoque == null) return NotFound();
            return Ok(estoque);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] EstoqueCreateDto dto)
        {
            var created = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] EstoqueUpdateDto dto)
        {
            var updated = await _service.Update(id, dto);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        [HttpDelete("{id:int}")]

        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.Delete(id);
            if (!deleted) return NotFound();
            return NoContent();
        }



    }
}
