namespace AlmacenWS.Usuarios.DTO.GestionUsuarios
{
    public class FiltroUsuariosDTO
    {
        public string? Usuario { get; set; }
        public string? Email { get; set; }
        public Nullable<int> IdPerfil { get; set; }
        public Nullable<bool> Activo { get; set; }
    }
}
