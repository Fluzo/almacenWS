using AlmacenWS.BaseDatos;
using AlmacenWS.Articulos.Servicios;
using AlmacenWS.Usuarios.Servicios;
using AlmacenWS.Usuarios.DTO;

using Microsoft.AspNetCore.Mvc;
using AlmacenWS.Usuarios.DTO.Login;
using AlmacenWS.Usuarios.DTO.GestionUsuarios;

namespace AlmacenWS.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        public readonly IUsuariosService _service;
        public UsuariosController(IUsuariosService service)
        {
            this._service = service;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDTO dto)
        {
            var result = await _service.Login(dto);
            return Ok(result);
        }

        [HttpPost]
        [Route("AltaUsuario")]
        public async Task<IActionResult> AltaUsuario(UsuarioDTO dto)
        {
            var result = await _service.AltaUsuario(dto);
            return Ok(result);
        }
    }
}
