namespace API.Dtos.DtosProject;
    public class CompraDto
    {

        public int Id { get; set; }
        public int IdProductoFk { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnitUSD { get; set; }

        public List<ClienteCompraDto> ? ClienteCompras { get; set; }

    }
