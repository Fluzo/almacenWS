namespace AlmacenWS.BaseDatos
{
    public class ARTICULOS
    {
        public int ID_ARTICULO { get; set; }
        public string NOMBRE { get; set; }
        public Nullable<int> ALTO { get; set; }
        public Nullable<int> ANCHO { get; set; }
        public Nullable<int> PESO { get; set; }
    }
}
