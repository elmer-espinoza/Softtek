using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softtek.Models;

namespace Softtek.Controllers
{
  //[Route("api/[controller]")]
    [Route("GestionVentas")]
    [ApiController]
    public class VentasDBController : ControllerBase
    {
        private readonly VentasDBContext _dbContext;

        public VentasDBController(VentasDBContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        /*
        
        {
          "id": 1,
          "factura": "F001-00002020",
          "fecha": "2023-02-04T06:59:45.029Z",
          "cliente": "MINERA YANACOCHA",
          "producto": "IMPRESORA PHASER 8050",
          "vendedor": "Karina Sarmiento",
          "total": 7200.50
        }   
         
        {
          "id": 2,
          "factura": "F001-00001919",
          "fecha": "2023-02-04T07:02:45.029Z",
          "cliente": "AFP INTEGRA SAC",
          "producto": "COPIADORA HODAKA 4550",
          "vendedor": "Fiorella Piccini",
          "total": 2400.50
        }   

        */


        [HttpGet]
        [Route("Listar")]
        public List<Ventas> ListarVentas()
        {
            return _dbContext.Ventas.ToList();
        }

        //[HttpGet("{id}")] 
        [HttpGet]
        [Route("Leer")]
        public dynamic LeerVenta(int id)
        {
            var venta = _dbContext.Ventas.SingleOrDefault(e => e.Id == id);
            if (venta == null)
            {
                return "Venta con Id " + id.ToString() + " no existe";
            }

            return _dbContext.Ventas.SingleOrDefault(e => e.Id == id);
        }

        [HttpPost]
        [Route("Adicionar")]
        public IActionResult AdicionarVenta(Ventas venta)
        {
            _dbContext.Add(venta);
            _dbContext.SaveChanges();
            return Created("Venta con Id " + venta.Id.ToString() + " fue creada", venta);
        }


        [HttpDelete]
        [Route("Remover")]
        public IActionResult RemoverVenta(int id)
        {
            var venta = _dbContext.Ventas.SingleOrDefault(e => e.Id == id);
            if (venta == null)
            {
                return NotFound("Venta con Id " + id.ToString() + " no existe");
            }
            _dbContext.Remove(venta);
            _dbContext.SaveChanges();
            return Ok("Venta con Id " + id.ToString() + " fue removida");
        }


        [HttpPut]
        [Route("Actualizar")]
        public IActionResult ActualizarVenta(int id, Ventas venta)
        {
            var _venta = _dbContext.Ventas.SingleOrDefault(e => e.Id == id);
            if (_venta == null)
            {
                return NotFound("Venta con Id " + id.ToString() + " no existe");
            }
            _venta.Factura = venta.Factura;
            _venta.Fecha = venta.Fecha;
            _venta.Cliente = venta.Cliente;
            _venta.Producto = venta.Producto;
            _venta.Vendedor = venta.Vendedor;
            _venta.Total = venta.Total;
            _dbContext.Update(_venta);
            _dbContext.SaveChanges();
            return Ok("Venta con Id " + id.ToString() + " fue actualizada");
        }
    }
}
