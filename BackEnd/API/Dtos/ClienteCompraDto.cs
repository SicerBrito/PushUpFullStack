namespace API.Dtos.DtosProject;
    public class ClienteCompraDto
    {

        public int Id { get; set; }
        public int IdClienteFk { get; set; }
        public int IdCompraFk { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public double ValorTotalTransaccion { get; set; }
        public int IdMetodoPagoFk { get; set; }
        public string ? DireccionCliente { get; set; }

    }
