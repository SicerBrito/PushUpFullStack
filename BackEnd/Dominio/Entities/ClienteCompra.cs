namespace Dominio.Entities;
    public class ClienteCompra : BaseEntity{

        public int IdClienteFk { get; set; }
        public Cliente ? Clientes { get; set; }
        public int IdCompraFk { get; set; }
        public Compra ? Compras { get; set; }
        public DateTime FechaTransaccion { get; set; }
        public double ValorTotalTransaccion { get; set; }
        public int IdMetodoPagoFk { get; set; }
        public Pago ? Pagos { get; set; }
        public string ? DireccionCliente { get; set; }

    }
