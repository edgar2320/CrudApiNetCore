using System.ComponentModel.DataAnnotations;

namespace MiPrimeraApiRest.DTOS
{
    public class VillaDtoCreate
    {
       
        public string Nombre { get; set; }
        public string Detalle { get; set; }

        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidades { get; set; }

    }
}
