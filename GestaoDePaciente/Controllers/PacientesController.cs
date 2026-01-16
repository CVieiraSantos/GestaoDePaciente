using GestaoDePaciente.DTOs.Paciente;
using GestaoDePaciente.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GestaoDePaciente.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly IPacienteService _service;

        public PacientesController(IPacienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreatePacienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _service.CreateAsync(dto);
            
            if (created == null) 
                return BadRequest("Erro ao criar paciente");
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            var paciente = await _service.GetByIdAsync(id);
            
            if (paciente == null) 
                return NotFound();
            return Ok(paciente);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreatePacienteDto dto)
        {
            if (!ModelState.IsValid) 
                return BadRequest(ModelState);
            
            var ok = await _service.UpdateAsync(id, dto);
            
            if (!ok) 
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ok = await _service.DeleteAsync(id);
            if (!ok) 
                return NotFound();
            return NoContent();
        }
    }
}
