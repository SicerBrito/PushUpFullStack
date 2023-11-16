using API.Dtos;
using API.Dtos.DtosProject;
using API.Dtos.Generic;
using AutoMapper;
using Dominio.Entities;

namespace API.Profiles;
    public class MappingProfile : Profile{
        public MappingProfile(){

            CreateMap<Rol, RolDto>()
                .ReverseMap();

            CreateMap<CarritoCompra, CarritoCompraDto>()
                .ReverseMap();

            CreateMap<CategoriaProducto, CategoriaProductoDto>()
                .ReverseMap();

            CreateMap<Cliente, ClienteDto>()
                .ReverseMap();

            CreateMap<ClienteCompra, ClienteCompraDto>()
                .ReverseMap();

            CreateMap<Compra, CompraDto>()
                .ReverseMap();

            CreateMap<DetalleProducto, DetalleProductoDto>()
                .ReverseMap();

            CreateMap<Pago, PagoDto>()
                .ReverseMap();

            CreateMap<Producto, ProductoDto>()
                .ReverseMap();

        }
    }
