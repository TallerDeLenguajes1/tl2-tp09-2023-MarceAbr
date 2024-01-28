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
        private int id;
        private int idTablero;
        private string? nombre;
        private string? descripcion;
        private string? color;
        private Estado estadoTarea;
        private int idUsuarioAsignado;

        public int Id { get => id; set => id = value; }
        public int IdTablero { get => idTablero; set => idTablero = value; }
        public string? Nombre {get => nombre; set => nombre = value;}
        public string? Descripcion { get => descripcion; set => descripcion = value; }
        public string? Color { get => color; set => color = value; }
        public Estado EstadoTarea { get => estadoTarea; set => estadoTarea = value; }
        public int IdUsuarioAsignado { get => idUsuarioAsignado; set => idUsuarioAsignado = value; }
    }
}