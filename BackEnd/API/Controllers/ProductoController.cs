using API.Dtos;
using API.Helpers;
using AutoMapper;
using Dominio.Entities;
using Dominio.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

    [ApiVersion("1.0")]
    [ApiVersion("1.1")]
    public class ProductoController : BaseApiController{

        private readonly IUnitOfWork _UnitOfWork;
        private readonly IMapper _Mapper;

        public ProductoController(IUnitOfWork unitOfWork,IMapper mapper){
            _UnitOfWork = unitOfWork;
            _Mapper = mapper;
        }

        [HttpGet]
        [MapToApiVersion("1.0")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<IEnumerable<ProductoController>>> Get(){
            var records = await _UnitOfWork.Productos!.GetAllAsync();
            return _Mapper.Map<List<ProductoController>>(records);
        }

        [HttpGet("Pager")]
        [MapToApiVersion("1.1")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Pager<ProductoController>>> Get11([FromQuery] Params recordParams)
        {
            var record = await _UnitOfWork.Productos!.GetAllAsync(recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
            var lstrecordsDto = _Mapper.Map<List<ProductoController>>(record.registros);
            return new Pager<ProductoController>(lstrecordsDto,record.totalRegistros,recordParams.PageIndex,recordParams.PageSize,recordParams.Search);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductoController>> Get(int id)
        {
            var record = await _UnitOfWork.Productos!.GetByIdAsync(id);
            if (record == null){
                return NotFound();
            }
            return _Mapper.Map<ProductoController>(record);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Producto>> Post(ProductoController recordDto){
            var records = _Mapper.Map<List<Producto>>(recordDto);
            foreach (var record in records)
            {
                _UnitOfWork.Productos!.Add(record);
                if (record == null)
                {
                    return BadRequest();
                }
            }
            await _UnitOfWork.SaveAsync();
            var createdRecordsDto = _Mapper.Map<List<ProductoController>>(records);
            return CreatedAtAction(nameof(Post), createdRecordsDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProductoController>> Put(string id, [FromBody]ProductoController recordDto){
            if(recordDto == null)
                return NotFound();
            var records = _Mapper.Map<Producto>(recordDto);
            _UnitOfWork.Productos!.Update(records);
            await _UnitOfWork.SaveAsync();
            return recordDto;
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id){
            try
            {
                var record = await _UnitOfWork.Productos!.GetByIdAsync(id);
                if(record == null){
                    return NotFound();
                }
                _UnitOfWork.Productos.Remove(record);
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
