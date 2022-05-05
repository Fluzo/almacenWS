namespace AlmacenWS.BaseDatos
{
    public class V_USUARIOS
    {
        public int ID_USUARIO { get; set; }
        public string USUARIO { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public int ID_PERFIL { get; set; }
        public string PERFIL { get; set; }
        public bool ACTIVO { get; set; }
    }

}
