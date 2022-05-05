namespace AlmacenWS.Usuarios.DTO.Login
{
    public class LoginResponseDTO
    {
        public int IdUsuario { get; set; }

        public LoginResponseDTO()
        {
           
        }

        public LoginResponseDTO(int idUsuario)
        {
            IdUsuario = idUsuario;
        }
    }
}
