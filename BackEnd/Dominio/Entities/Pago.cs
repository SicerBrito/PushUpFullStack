namespace Dominio.Entities;
    public class Pago : BaseEntity{

        public string ? Nombre { get; set; }

        public ICollection<ClienteCompra> ? ClienteCompras { get; set; }

    }
