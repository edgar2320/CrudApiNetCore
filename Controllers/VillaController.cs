using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimeraApiRest.Datos;
using MiPrimeraApiRest.DTOS;
using MiPrimeraApiRest.Modelos;

namespace MiPrimeraApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class VillaController : ControllerBase
    {  
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _bd;
        private readonly IMapper _mapper;
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext bd, IMapper mapper)
        {
            _logger = logger;
            _bd = bd;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<VillaDto>>> GetVillas()
        {  

            if (VillaStore.listaVillaDto.Count == 0) { return NotFound();}
            _logger.LogInformation("Listando villas");
            IEnumerable<Villa> miListDto = await _bd.Villas.ToListAsync();
            return Ok(_mapper.Map<IEnumerable<VillaDto>>(miListDto));
        }

        [HttpGet("{id}",Name ="listar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public async Task<ActionResult<VillaDto>> GetObtenerVilla(int id)
        {
            if (id == 0) { return BadRequest(); }
            var villaSeach= await _bd.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if (villaSeach == null) { return NotFound();}
            return Ok(_mapper.Map<VillaDto>(villaSeach));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<VillaDto>> PostVilla([FromBody] VillaDtoCreate villa) {
            if (ModelState.IsValid == false) { return BadRequest(ModelState); }
            //VALIDACION PERSONALIZADA
            if(await _bd.Villas.FirstOrDefaultAsync(x=>x.Nombre.ToLower()==villa.Nombre.ToLower())!=null) { 
                ModelState.AddModelError("Nombre",$"El nombre no puede ser {villa.Nombre}");
                return BadRequest(ModelState);
            }
            if (villa == null) { return StatusCode(StatusCodes.Status500InternalServerError); }
            Villa villaSave= _mapper.Map<Villa>(villa);
            await _bd.Villas.AddAsync(villaSave);
            await _bd.SaveChangesAsync();
            return CreatedAtRoute("listar", new {id=villaSave.Id}, villaSave);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<IActionResult> DeleteVilla(int id)
        {
            if (id == 0) { return BadRequest(); }
            var villaSeach = await _bd.Villas.FirstOrDefaultAsync(x => x.Id == id);
            if (villaSeach == null) { return NotFound(); }
            _bd.Villas.Remove(villaSeach);
            await _bd.SaveChangesAsync();
            return NoContent(); //seimpre retorna 204 cuando se elimina un recurso correctamente 
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public async Task<IActionResult> UpdateVilla(int id, [FromBody] VillaDtoUpdate villa)
        {
            if (villa == null) {
                return BadRequest();
            }
            Villa VillaSearch = await _bd.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (VillaSearch==null)
            {
                return NotFound();
            }

            Villa miVilla= _mapper.Map<Villa>(villa);

           
            _bd.Villas.Update(miVilla);
            await _bd.SaveChangesAsync();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> actionResult(int id, JsonPatchDocument<VillaDtoUpdate> villaPatch)
        {
            if (villaPatch == null || id==0)
            {
                return BadRequest();
            }
            var VillaSearch = await _bd.Villas.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (VillaSearch == null)
            {
                return NotFound();
            }

            VillaDtoUpdate villaData = _mapper.Map<VillaDtoUpdate>(VillaSearch);
            villaPatch.ApplyTo(villaData, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
             Villa villaUpdate=_mapper.Map<Villa>(villaData);
            _bd.Villas.Update(villaUpdate);
            await _bd.SaveChangesAsync();
            return NoContent();
        }

       
    }
}
