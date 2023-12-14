using Fraccionamientos_LDS.Entities;
using Fraccionamientos_LDS.Services;
using Microsoft.AspNetCore.Mvc;

namespace Fraccionamientos_LDS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _usuarioService;

        public UserController(IUserService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            var usuarios = _usuarioService.GetUsers();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var usuario = _usuarioService.GetUserById(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public IActionResult CrearUsuario(User user)
        {
            _usuarioService.CrearUsuario(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }

        [HttpPut("{id}")]
        public IActionResult ActualizarUsuario(int id, User usuario)
        {
            if (id != usuario.UserId)
            {
                return BadRequest();
            }

            _usuarioService.ActualizarUsuario(usuario);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarUsuario(int id)
        {
            _usuarioService.EliminarUsuario(id);
            return NoContent();
        }
    }
}
