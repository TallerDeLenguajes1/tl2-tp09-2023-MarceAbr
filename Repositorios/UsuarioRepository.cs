using System.Data.SqlClient;
using System.Data.SQLite;
using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private string CadenaDeConexion = "Data Source=C:/Users/Marcelo/Desktop/PU/Segundo Semestre/Taller 2/tl2-tp09-2023-MarceAbr/BD/kanban.db;Cache=Shared";
        public void CrearUsuario(Usuario usu)
        {
            var queryString = @"INSERT INTO Usuario (nombre_de_usuario) VALUES(@nombre);";

            using(SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@nombre", usu.NombreDeUsuario));
                comando.ExecuteNonQuery();

                conexion.Close();   
            }
        }

        public void ModificarUsuario(int id, Usuario Usu)
        {
            var queryString = @"UPDATE Usuario SET nombre_de_usuario = @nombre WHERE id = @idUsu;";

            using(SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);

                comando.Parameters.Add(new SQLiteParameter("@idUsu", id));
                comando.Parameters.Add(new SQLiteParameter("@nombre", Usu.NombreDeUsuario));
                comando.ExecuteNonQuery();

                conexion.Close();
            }
        }

        public List<Usuario> ListarUsuarios()
        {
            var queryString = @"SELECT * FROM Usuario;";
            List<Usuario> usuarios = new List<Usuario>();

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        Usuario usuario = new Usuario();
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();
                        usuarios.Add(usuario);
                    }
                }
                conexion.Close();
            }
            return usuarios;
        }

        public Usuario MostrarUsuario(int id)
        {
            var queryString = @"SELECT * FROM Usuario WHERE id = @idUsu;";
            Usuario usuario = new Usuario();

            using(SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", id));

                using(SQLiteDataReader reader = comando.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        usuario.Id = Convert.ToInt32(reader["id"]);
                        usuario.NombreDeUsuario = reader["nombre_de_usuario"].ToString();                          
                    }
                }
                conexion.Close();
            }
            return usuario;
        }

        public void EliminarUsuario(int id)
        {
            var queryString = @"DELETE FROM Usuario WHERE id = @idUsu;";

            using(SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {   
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", id));
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}