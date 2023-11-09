namespace Dominio.Entities;
    public class DetalleProducto : BaseEntity{

        public int IdProducto { get; set; }
        public Producto ? Productos { get; set; }
        public string ? DetallesAdicionalesProducto { get; set; }

    }
