using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public interface IUsuarioRepository
    {
        public void CrearUsuario(Usuario usu);
        public void ModificarUsuario(int id, Usuario usu);
        public List<Usuario> ListarUsuarios();
        public Usuario MostrarUsuario(int id);
        public void EliminarUsuario(int id);
    }
}