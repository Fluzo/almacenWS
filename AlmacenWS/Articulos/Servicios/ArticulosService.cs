using AlmacenWS.Articulos.DTO;
using AlmacenWS.BaseDatos;

namespace AlmacenWS.Articulos.Servicios
{

    public interface IArticulosService
    {
        List<V_STOCK_ARTICULOS> ObtenerStockArticulos(FiltroStockArticulos filtros);
    }

    /*
     
        ####################IMPORTANTE####################

        Fijate que ArticulosService implementa IArticulosService
     
     */

    public class ArticulosService : IArticulosService
    {
        public AlmacenContext _ctx;
        public ArticulosService (AlmacenContext ctx)
        {
            this._ctx = ctx;
        }

        public List<V_STOCK_ARTICULOS> ObtenerStockArticulos(FiltroStockArticulos filtros)
        {
            return this._ctx.V_STOCK_ARTICULOS.Where(x => x.CANTIDAD > 0).ToList();
        }
    }
}
