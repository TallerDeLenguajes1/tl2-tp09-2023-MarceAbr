namespace tl2_tp09_2023_MarceAbr.Models
{
    public enum Estado
    {
        Ideas,
        ToDo,
        Doing,
        Review,
        Done
    } 
    public class Tarea
    {
        private int Id {get; set;}
        private string? Nombre {get;set;}
        private string? Descripcion {get;set;}
        private string? Color {get;set;}
        private Estado EstadoTarea {get;set;}
        private int IdUsuarioAsignado {get;set;}

        public Tarea(){}

        public Tarea(string nomb, string desc, string color, Estado est, int IdUsu)
        {
            this.Nombre = nomb;
            this.Descripcion = desc;
            this.Color = color;
            this.EstadoTarea = est;
            this.IdUsuarioAsignado = IdUsu;
        }
    }
}