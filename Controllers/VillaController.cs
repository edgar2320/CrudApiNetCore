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
        public VillaController(ILogger<VillaController> logger, ApplicationDbContext bd)
        {
            _logger = logger;
            _bd = bd;
        }
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public ActionResult<IEnumerable<VillaDto>> GetVillas()
        {  

            if (VillaStore.listaVillaDto.Count == 0) { return NotFound();}
            _logger.LogInformation("Listando villas");
            return Ok(_bd.Villas.ToList());
        }

        [HttpGet("{id}",Name ="listar")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]

        public ActionResult<VillaDto> GetObtenerVilla(int id)
        {
            if (id == 0) { return BadRequest(); }
            var villaSeach=_bd.Villas.FirstOrDefault(x => x.Id == id);
            if (villaSeach == null) { return NotFound();}
            return Ok(villaSeach);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDto> PostVilla([FromBody] VillaDto villa) {
            if (ModelState.IsValid == false) { return BadRequest(ModelState); }
            //VALIDACION PERSONALIZADA
            if(_bd.Villas.FirstOrDefault(x=>x.Nombre.ToLower()==villa.Nombre.ToLower())!=null) { 
                ModelState.AddModelError("Nombre",$"El nombre no puede ser {villa.Nombre}");
                return BadRequest(ModelState);
            }
            if (villa == null) { return StatusCode(StatusCodes.Status500InternalServerError); }
           
            Villa villaSave=new Villa() { 
             Detalle=villa.Detalle,
             Tarifa=villa.Tarifa,
             ImagenUrl=villa.ImagenUrl,
             Amenidades=villa.Amenidades,
             MetrosCuadrados=villa.MetrosCuadrados,
             Nombre=villa.Nombre,
             Ocupantes=villa.Ocupantes
            };
            _bd.Villas.Add(villaSave);
            _bd.SaveChanges();
            return CreatedAtRoute("listar", new {id=villa.Id},villa);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public IActionResult DeleteVilla(int id)
        {
            if (id == 0) { return BadRequest(); }
            var villaSeach = _bd.Villas.FirstOrDefault(x => x.Id == id);
            if (villaSeach == null) { return NotFound(); }
            _bd.Villas.Remove(villaSeach);
            _bd.SaveChanges();
            return NoContent(); //seimpre retorna 204 cuando se elimina un recurso correctamente 
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]

        public IActionResult UpdateVilla(int id, [FromBody] VillaDto villa)
        {
            if (villa == null) {
                return BadRequest();
            }
            Villa VillaSearch = _bd.Villas.FirstOrDefault(x => x.Id == id);
            if (VillaSearch==null)
            {
                return NotFound();
            }

            
            VillaSearch.Nombre = villa.Nombre;
            VillaSearch.MetrosCuadrados = villa.MetrosCuadrados;
            VillaSearch.Ocupantes = villa.Ocupantes;
            VillaSearch.Tarifa = villa.Tarifa;
            VillaSearch.ImagenUrl = villa.ImagenUrl;
            VillaSearch.Amenidades = villa.Amenidades;
            VillaSearch.Detalle = villa.Detalle;
            _bd.Villas.Update(VillaSearch);
            _bd.SaveChanges();
            return NoContent();
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult actionResult(int id, JsonPatchDocument<VillaDto> villaPatch)
        {
            if (villaPatch == null || id==0)
            {
                return BadRequest();
            }
            var VillaSearch = _bd.Villas.AsNoTracking().FirstOrDefault(x => x.Id == id);
            if (VillaSearch == null)
            {
                return NotFound();
            }

            var villaData = new VillaDto()
            {
                Id = id,
                Nombre = VillaSearch.Nombre,
                MetrosCuadrados = VillaSearch.MetrosCuadrados,
                Ocupantes = VillaSearch.Ocupantes,
                Tarifa = VillaSearch.Tarifa,
                ImagenUrl = VillaSearch.ImagenUrl,
                Amenidades = VillaSearch.Amenidades,
                Detalle = VillaSearch.Detalle
            };

            villaPatch.ApplyTo(villaData, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _bd.Villas.Update(new Villa()
            {   Id=villaData.Id,
                Nombre = villaData.Nombre,
                MetrosCuadrados = villaData.MetrosCuadrados,
                Ocupantes = villaData.Ocupantes,
                Tarifa = villaData.Tarifa,
                ImagenUrl = villaData.ImagenUrl,
                Amenidades = villaData.Amenidades,
                Detalle = villaData.Detalle

            });
            _bd.SaveChanges();
            return NoContent();
        }

       
    }
}
