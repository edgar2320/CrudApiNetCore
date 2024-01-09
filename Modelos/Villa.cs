using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiPrimeraApiRest.Modelos
{
    public class Villa
    {
        [Key]//INDICAMOS QUE ES LA LLAVE PRIMARIA
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        
        public double Tarifa { get; set; }
        
        public int Ocupantes { get; set; }

        public int MetrosCuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidades { get; set; }

        public DateTime FechaModificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

    }
}
