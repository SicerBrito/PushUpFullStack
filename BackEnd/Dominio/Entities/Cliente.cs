namespace Dominio.Entities;
    public class Cliente : BaseEntity{

        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Direccion { get; set; }
        public double NroContacto { get; set; }

        public ICollection<ClienteCompra> ? ClienteCompras { get; set; }
        public ICollection<CarritoCompra> ? CarritoCompras { get; set; }

    }
