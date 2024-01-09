using MiPrimeraApiRest.DTOS;

namespace MiPrimeraApiRest.Datos
{
    public static class VillaStore
    {
        public static List<VillaDto> listaVillaDto= new List<VillaDto>
        {
            new VillaDto
            {
                Id = 1,
                Nombre = "Villa 1",
                Ocupantes = 4,
                MetrosCuadrados=20
            },
            new VillaDto
            {
                Id = 2,
                Nombre = "Villa 2",
                 Ocupantes = 1,
                MetrosCuadrados=10
            },
            new VillaDto
            {
                Id = 3,
                Nombre = "Villa 3",
                 Ocupantes = 6,
                MetrosCuadrados=200
            }
        };
}
}
