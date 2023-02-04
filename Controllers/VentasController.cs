using Microsoft.AspNetCore.Mvc;
using Softtek.Models;
using System.ComponentModel.DataAnnotations;

namespace Softtek.Controllers
{

    [ApiController]
    [Route("GestionVentas")]
    public class VentasController : ControllerBase
    {
        [HttpGet]
        [Route("ListarVentas")]
        public dynamic listarVentas()
        {
            // return "hola se listo datos "+DateTime.Now.ToString();

            List<Ventas> ventas = new List<Ventas>
            {

        new Ventas
                {
                    Id= 1,  
                    Factura = "001-00001245",
                    Fecha = new DateTime(2022,02,02), 
                    Cliente = "MINERA YANACOCHA",
                    Producto = "IMPRESORA PHASER 8020",
                    Vendedor = "Patricia Pisano",
                    Total = 2540.80
                },
                new Ventas
                {
                    Id= 2,
                    Factura = "001-00001246",
                    Fecha = new DateTime(2022,02,01),
                    Cliente = "AFP INTEGRA",
                    Producto = "SCANNER FUJI 8720",
                    Vendedor = "Luis Aguilar",
                    Total = 1200.25
                },
                new Ventas
                {
                    Id= 3,
                    Factura = "001-00001247",
                    Fecha = new DateTime(2022,01,30),
                    Cliente = "MINISTERIO DE ECONOMIA",
                    Producto = "PAPEL A4",
                    Vendedor = "Patricia Araoz",
                    Total = 800.50
                },
            };
            return ventas;
        }

        [HttpPost]
        [Route("GuardarVentas")]
        public dynamic guardarVentas(Ventas ventas)
        {
            // return "hola se guardo datos " + DateTime.Now.ToString(); 

            return new 
            {
                sucess = true,
                message = "se guardo informacion de ventas de la factura "+ ventas.Factura.ToString(),
                result =  "Ok"
            };
        }

        [HttpPost]
        [Route("EliminarVentas")]
        public dynamic eliminarVentas(Ventas ventas)
        {
            string token = "";
            token = Request.Headers.Where(x => x.Key == "Authorization").First().Value;

            if (token != "Poison")
            {
                return new
                {
                    sucess = false,
                    message = "Token no es valido",
                    result = default(string)

                };
            }

            return new
            {
                sucess = true,
                message = "se guardo informacion de ventas de la factura " + ventas.Factura.ToString(),
                result = "Ok"
            };
        }


    }
}
