namespace Dominio.Entities;
    public class DetalleProducto : BaseEntity{

        public int IdProductoFk { get; set; }
        public Producto ? Productos { get; set; }
        public string ? DetallesAdicionalesProducto { get; set; }

    }
