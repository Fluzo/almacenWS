using AlmacenWS.BaseDatos;
using AlmacenWS.Articulos.Servicios;
using AlmacenWS.Articulos.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AlmacenWS.Articulos
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticulosController : ControllerBase
    {
        public readonly IArticulosService _service;
        public ArticulosController(IArticulosService service)
        {
            this._service = service;
        }

        [HttpGet]
        [Route("ObtenerStockArticulos")]
        public ActionResult<List<V_STOCK_ARTICULOS>> ObtenerStockArticulos(string? nombreArticulo)
        {
            FiltroStockArticulos filtro = new FiltroStockArticulos();
            filtro.NombreArticulo = nombreArticulo;
            List < V_STOCK_ARTICULOS > stockArticulos = this._service.ObtenerStockArticulos(filtro);
            return Ok(stockArticulos);
        }
    }
}
