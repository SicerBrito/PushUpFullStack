namespace API.Dtos.DtosProject;
    public class PagoDto
    {

        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<ClienteCompraDto> ? ClienteCompras { get; set; }

    }
