namespace Softtek.Models
{
    public class Ventas
    {
        public int Id { get; set; }
        public string? Factura { get; set; }
        public DateTime? Fecha { get; set; }    
        public string? Cliente { get; set; } 
        public string? Producto { get; set; }
        public string? Vendedor { get; set; }
        public double? Total { get; set; }
            
    }
}
