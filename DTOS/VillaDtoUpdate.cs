using System.ComponentModel.DataAnnotations;

namespace MiPrimeraApiRest.DTOS
{
    public class VillaDtoUpdate
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidades { get; set; }

    }
}
