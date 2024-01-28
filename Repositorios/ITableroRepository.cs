using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public interface ITableroRepository
    {
        public void CrearTablero(Tablero tablero);
        public void ModificarTablero(int id, Tablero tablero);
        public Tablero MostrarTableroPorId(int id);
        public List<Tablero> ListarTableros();
        public List<Tablero> ListarTableroPorUsuario(int idUsu);
        public void EliminarTablero(int idTab);
    }
}