using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Softtek.Constans;
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

        
        [HttpPost]
        [Route("Resetear")]
        [Authorize(Roles = ("Administrador"))]
        public IActionResult ResetearVentas()
        {
            var venta = VentasConstans.Ventas;

            foreach (var _venta in _dbContext.Ventas)
            {
                _dbContext.Remove(_venta);
            }
            _dbContext.SaveChanges();

            for (int i = 0; i < venta.Count; i++)
         // for (int i = venta.Count - 1;  i > -1; i--)
            {
                _dbContext.Add(venta[i]);
            }
            _dbContext.SaveChanges();
            return Created("In Memory DataBse fue Reseteada",venta);
        }



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

            return venta;
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
