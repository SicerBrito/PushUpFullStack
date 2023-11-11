namespace Dominio.Entities;
    public class CarritoCompra : BaseEntity{

        public int IdClienteFk { get; set; }
        public Cliente ? Clientes { get; set; }
        public int IdProductoFk { get; set; }
        public Producto ? Productos { get; set; }
        public string ? ProductoEnCarrito { get; set; }
        public int CantidadCadaProductoEnCarrito { get; set; }
        public double PrecioTotalCarrito { get; set; }

    }

