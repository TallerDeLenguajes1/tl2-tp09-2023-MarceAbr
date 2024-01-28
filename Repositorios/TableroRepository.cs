using System.Data.SQLite;
using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public class TableroRepository : ITableroRepository
    {
        private string cadenaDeConexion = "Data Source=DB/kanban.db;Cache=Shared";

        public void CrearTablero(Tablero tab)
        {
            var queryString = @"SELECT INTO Tablero (id_usuario_propietario, nombre, descripcion) VALUES (@idUsu, @nombre, @desc);";

            using(SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();

                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", tab.IdUsuario));
                comando.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
                comando.Parameters.Add(new SQLiteParameter("@desc", tab.Descripcion));

                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void ModificarTablero(int idTab, Tablero tab)
        {
            var queryString = @"UPDATE Tablero SET nombre = @nombre, descripcion = @desc, id_usuario_propietario = @idUsu WHERE id = @idTablero;";

            using(SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();

                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTab));
                comando.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
                comando.Parameters.Add(new SQLiteParameter("@desc", tab.Descripcion));
                comando.Parameters.Add(new SQLiteParameter("@idUsu", tab.IdUsuario));
                
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public Tablero MostrarTableroPorId(int idTab)
        {
            var queryString = @"SELECT * FROM Tablero WHERE id = @idTablero;";
            Tablero tablero = new Tablero();

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTab));

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                    }
                }
                conexion.Close();
            }
            return tablero;
        }

        public List<Tablero> ListarTableros()
        {
            var queryString = @"SELECT * FROM Tablero;";
            List<Tablero> tableros = new List<Tablero>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tablero tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                conexion.Close();
            }
            return tableros;
        }

        public List<Tablero> ListarTableroPorUsuario(int idUsuario)
        {
            var queryString = @"SELECT * FROM Tablero WHERE id = @idUsu;";
            List<Tablero> tableros = new List<Tablero>();

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", idUsuario));

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tablero tablero = new Tablero();
                        tablero.Id = Convert.ToInt32(reader["id"]);
                        tablero.IdUsuario = Convert.ToInt32(reader["id_usuario_propietario"]);
                        tablero.Nombre = reader["nombre"].ToString();
                        tablero.Descripcion = reader["descripcion"].ToString();
                        tableros.Add(tablero);
                    }
                }
                conexion.Close();
            }
            return tableros;
        }

        public void EliminarTablero(int idTab)
        {
            var queryString = @"DELETE * FROM Tablero WHERE id = @idTablero;";

            using (SQLiteConnection conexion = new SQLiteConnection(cadenaDeConexion))
            {
                conexion.Open();

                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTab));
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }
    }
}