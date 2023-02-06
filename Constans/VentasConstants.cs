using Microsoft.EntityFrameworkCore;
using Softtek.Models;
using System.ComponentModel.DataAnnotations;

namespace Softtek.Constans
{
    public class VentasConstans
    {
        public static List<Ventas> Ventas = new List<Ventas>() {
           new Ventas() { Id = 1, Cliente = "MINERA AURIFERA RETAMAS",      Factura = "F001-00001240", Fecha = new DateTime(2022,02,05), Producto="IMPRESORA 1090",      Total = 12500.33, Vendedor = "Jessica Silva" },
           new Ventas() { Id = 2, Cliente = "AFP PRIMA",                    Factura = "F001-00001242", Fecha = new DateTime(2022,02,04), Producto="MULTIFUNCIONAL 4220", Total =  8500.13, Vendedor = "Erika Roeder" },
           new Ventas() { Id = 3, Cliente = "BANCO DE COMERCIO",            Factura = "F001-00001244", Fecha = new DateTime(2022,02,03), Producto="COPIADORA 1025",      Total =  1500.23, Vendedor = "Monica Kollman" },
           new Ventas() { Id = 4, Cliente = "ENTEL PERU S.A",               Factura = "F001-00001246", Fecha = new DateTime(2022,02,02), Producto="SCANNER 9090",        Total =   900.43, Vendedor = "Karina Sarmiento" },
           new Ventas() { Id = 5, Cliente = "UNIVERSIDAD TECSUP",           Factura = "F001-00001248", Fecha = new DateTime(2022,02,01), Producto="PLOTTER 8041",        Total =  8500.63, Vendedor = "Fiorella Piccini" },
           new Ventas() { Id = 6, Cliente = "MINISTERIO DE LA PRODUCCION",  Factura = "F001-00001250", Fecha = new DateTime(2022,01,31), Producto="DOCUSHARE V3",        Total = 88500.63, Vendedor = "Patricia Pisano" },
 
    };

     }

    
    
}
