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


        [HttpPost]
        [Route("EditarUsuario")]
        public async Task<IActionResult> EditarUsuario(UsuarioDTO dto)
        {
            var result = await _service.EditarUsuario(dto);
            return Ok(result);
        }

        [HttpGet]
        [Route("DameUsuarios")]
        public async Task<IActionResult> DameUsuarios(string? usuario, string? email, Nullable<int> idPerfil, Nullable<bool> activo)
        {
            FiltroUsuariosDTO filtro = new FiltroUsuariosDTO()
            {
                Usuario = usuario,
                Email = email,
                IdPerfil = idPerfil,
                Activo = activo
            };
            var result = _service.DameUsuarios(filtro);
            return Ok(result);
        }
    }
}
