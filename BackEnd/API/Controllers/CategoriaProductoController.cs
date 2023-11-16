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
    public class CategoriaProductoController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public CategoriaProductoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<CategoriaProductoDto>>> Get(){
            var records = await _UnitOfWork.CategoriaProductos!.GetAllAsync();
            return _Mapper.Map<List<CategoriaProductoDto>>(records);
        }

        [HttpGet("Pager")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<CategoriaProductoDto>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.CategoriaProductos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<CategoriaProductoDto>>(record.registros);
            return new Pager<CategoriaProductoDto>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CategoriaProductoDto>> Get(int id)
        {
            var record = await _UnitOfWork.CategoriaProductos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<CategoriaProductoDto>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaProducto>> Post(CategoriaProductoDto recordDto){
            var records = _Mapper.Map<List<CategoriaProducto>>(recordDto);
            foreach (var record in records)
            {
                _UnitOfWork.CategoriaProductos!.Add(record);
                if (record == null)
                {
                    return BadRequest();
                }
            }
            await _UnitOfWork.SaveAsync();
            var createdRecordsDto = _Mapper.Map<List<CategoriaProductoDto>>(records);
            return CreatedAtAction(nameof(Post), createdRecordsDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<CategoriaProductoDto>> Put(string id, [FromBody]CategoriaProductoDto recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<CategoriaProducto>(recordDto);
            _UnitOfWork.CategoriaProductos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            try
            {
                var record = await _UnitOfWork.CategoriaProductos!.GetByIdAsync(id);
                if(record == null){
                    return NotFound();
                }
                _UnitOfWork.CategoriaProductos.Remove(record);
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
