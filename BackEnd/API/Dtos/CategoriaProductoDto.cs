namespace API.Dtos.DtosProject;
    public class CategoriaProductoDto
    {

        public int Id { get; set; }
        public string ? Nombre { get; set; }

        public List<ProductoDto> ? Productos { get; set; }

    }
