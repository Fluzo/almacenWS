namespace AlmacenWS.Usuarios.DTO.GestionUsuarios
{
    public class UsuarioDTO
    {
        public Nullable<int> IdUsuario { get; set; }
        public string Usuario { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Nullable<int> IdPerfil { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
