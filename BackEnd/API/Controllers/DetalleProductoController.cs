using API.Dtos;
using API.Dtos.DtosProject;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class DetalleProductoController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public DetalleProductoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<DetalleProductoDto>>> Get(){
            var records = await _UnitOfWork.DetalleProductos!.GetAllAsync();
            return _Mapper.Map<List<DetalleProductoDto>>(records);
        }

        [HttpGet("Pager")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<DetalleProductoDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.DetalleProductos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<DetalleProductoDto>>(record.registros);
            return new Pager<DetalleProductoDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<DetalleProductoDto>> Get(int id)
        {
            var record = await _UnitOfWork.DetalleProductos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<DetalleProductoDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleProducto>> Post(DetalleProductoDto recordDto){
            var records = _Mapper.Map<List<DetalleProducto>>(recordDto);
            foreach (var record in records)
            {
                _UnitOfWork.DetalleProductos!.Add(record);
                if (record == null)
                {
                    return BadRequest();
                }
            }
            await _UnitOfWork.SaveAsync();
            var createdRecordsDto = _Mapper.Map<List<DetalleProductoDto>>(records);
            return CreatedAtAction(nameof(Post), createdRecordsDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<DetalleProductoDto>> Put(string id, [FromBody]DetalleProductoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<DetalleProducto>(recordDto);
            _UnitOfWork.DetalleProductos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            try
            {
                var record = await _UnitOfWork.DetalleProductos!.GetByIdAsync(id);
                if(record == null){
                    return NotFound();
                }
                _UnitOfWork.DetalleProductos.Remove(record);
                await _UnitOfWork.SaveAsync();
                return StatusCode(StatusCodes.Status200OK, "Se ha borrado exitosamente");
            }
            catch (Exception)
            {
                // Manejo de excepciones
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor o no esta autorizado este servicio");
            }

        }
    }
