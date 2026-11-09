using Microsoft.AspNetCore.Mvc;
using Uniaraxa.Domain.Entities;
using Uniaraxa.Domain.Interfaces;

namespace Uniaraxa.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TeacherController : ControllerBase
{
    private readonly ITeacherService _service;

    public TeacherController(ITeacherService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Teacher>> ListarTodos() => Ok(_service.ListarTodos());

    [HttpGet("{id:int}")]
    public ActionResult<Teacher> BuscarPorId(int id)
    {
        var teacher = _service.BuscarPorId(id);
        return teacher is null ? NotFound() : Ok(teacher);
    }

    [HttpPost]
    public ActionResult<Teacher> Inserir([FromBody] Teacher teacher)
    {
        try
        {
            var criado = _service.Inserir(teacher);
            return CreatedAtAction(nameof(BuscarPorId), new { id = criado.Id }, criado);
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id:int}")]
    public IActionResult Atualizar(int id, [FromBody] Teacher teacher)
    {
        try
        {
            return _service.Atualizar(id, teacher) ? NoContent() : NotFound();
        }
        catch (ArgumentException ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id:int}")]
    public IActionResult Remover(int id) => _service.Remover(id) ? NoContent() : NotFound();
}
