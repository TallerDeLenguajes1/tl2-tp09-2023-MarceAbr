using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public interface ITareaRepository
    {
        public void CrearTarea(int idTablero, Tarea tarea);
        public void ModificarTarea(int idTarea, Tarea tarea);
        public Tarea MostrarTareaPorId(int idTarea);
        public List<Tarea> ListarTareaPorUsuario(int idUsu);
        public List<Tarea> ListarTareasPorTablero(int idTab);
        public void EliminarTarea(int idTarea);
        public void AsignarUsuarioATarea(int idTarea, int idUsu);
        public List<Tarea> ListarTareas();
    }
}