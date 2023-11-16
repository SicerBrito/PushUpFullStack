namespace API.Dtos.DtosProject;
    public class CarritoCompraDto
    {
        public int Id { get; set; }
        public int IdClienteFk { get; set; }
        public int IdProductoFk { get; set; }
        public string ? ProductoEnCarrito { get; set; }
        public int CantidadCadaProductoEnCarrito { get; set; }
        public double PrecioTotalCarrito { get; set; }

    }
