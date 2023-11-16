namespace API.Dtos.DtosProject;
    public class ClienteDto
    {

        public int Id { get; set; }
        public string ? Nombres { get; set; }
        public string ? Apellidos { get; set; }
        public string ? Direccion { get; set; }
        public double NroContacto { get; set; }

        public List<ClienteCompraDto> ? ClienteCompras { get; set; }
        public List<CarritoCompraDto> ? CarritoCompras { get; set; }

    }
