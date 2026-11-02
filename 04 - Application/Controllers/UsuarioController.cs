using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TrabalhoCodigoH1.Application.Controllers;

[ApiController]
[Route("api/usuario")]
public class UsuarioController : ControllerBase
{
    [Authorize]
    [HttpGet("perfil")]
    public IActionResult Perfil()
    {
        var nome = User.Identity?.Name;
        return Ok(new { mensagem = $"Olá, {nome}! Você está autenticado." });
    }
}
