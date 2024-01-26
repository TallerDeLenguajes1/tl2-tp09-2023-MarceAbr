namespace tl2_tp09_2023_MarceAbr.Models
{
    public class Tablero
    {
        private int Id {get; set;}
        private int IdUsuarioPropietario {get; set;}
        private string? Nombre {get; set;}
        private string? Descripcion {get; set;}

        public Tablero(){}

        public Tablero(int idUsu, string nomb, string desc)
        {
            this.IdUsuarioPropietario = idUsu;
            this.Nombre = nomb;
            this.Descripcion = desc;
        }
    }
}