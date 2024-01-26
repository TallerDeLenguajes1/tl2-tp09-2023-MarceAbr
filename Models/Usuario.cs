namespace tl2_tp09_2023_MarceAbr.Models
{
    public class Usuario
    {
        private int Id {get ; set;}
        private string? NombreDeUsuario {get ; set;} 

        public Usuario(){}

        public Usuario(string usu)
        {
            this.NombreDeUsuario = usu;
        }
    }
}