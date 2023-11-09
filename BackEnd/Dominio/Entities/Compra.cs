namespace Dominio.Entities;
    public class Compra : BaseEntity{

        public int IdProductoFk { get; set; }
        public Producto ? Productos { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnitUSD { get; set; }

        public ICollection<ClienteCompra> ? ClienteCompras { get; set; }

    }
