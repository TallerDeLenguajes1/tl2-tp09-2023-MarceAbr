using System.Data.SQLite;
using tl2_tp09_2023_MarceAbr.Models;

namespace tl2_tp09_2023_MarceAbr.Repositorios
{
    public class TareaRepository : ITareaRepository
    {
        private string CadenaDeConexion = "Data Source=C:/Users/Marcelo/Desktop/PU/Segundo Semestre/Taller 2/tl2-tp09-2023-MarceAbr/BD/kanban.db;Cache=Shared";
        public void CrearTarea(int idTab, Tarea tarea)
        {
            var queryString = @"INSERT INTO Tarea (id_tablero, nombre, estado, descripcion, color, id_usuario_asignado) 
                                VALUES (@idTablero, @nombre, @estado, @desc, @color, @idUsuAsignado);";

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTab));
                comando.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                comando.Parameters.Add(new SQLiteParameter("@estado", tarea.EstadoTarea));
                comando.Parameters.Add(new SQLiteParameter("@desc", tarea.Descripcion));
                comando.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                comando.Parameters.Add(new SQLiteParameter("@idUsuAsignado", tarea.IdUsuarioAsignado));

                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void ModificarTarea(int idTarea, Tarea tarea)
        {
            var queryString = @"UPDATE Tarea SET nombre = @nombre, estado = @estado, descripcion = @desc,
                                color = @color, id_usuario_asignado = @idUsuAsignado, id_tablero = @idTab WHERE id = @idTarea;";

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                comando.Parameters.Add(new SQLiteParameter("@idTab", tarea.IdTablero));
                comando.Parameters.Add(new SQLiteParameter("@nombre", tarea.Nombre));
                comando.Parameters.Add(new SQLiteParameter("@estado", tarea.EstadoTarea));
                comando.Parameters.Add(new SQLiteParameter("@desc", tarea.Descripcion));
                comando.Parameters.Add(new SQLiteParameter("@color", tarea.Color));
                comando.Parameters.Add(new SQLiteParameter("@idUsuAsignado", tarea.IdUsuarioAsignado));

                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public Tarea MostrarTareaPorId(int idTarea)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id = @idTarea;";
            Tarea tarea = new Tarea();

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("idTarea", idTarea));

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.EstadoTarea = (Estado)Convert.ToInt32(reader["estado"]);

                        if (reader["id_usuario_asignado"] == DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = 0;
                        } else {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        }
                    }
                }
                conexion.Close();
            }
            return tarea;
        }

        public List<Tarea> ListarTareaPorUsuario(int idUsu)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idUsu;"; 
            List<Tarea> tareas = new List<Tarea>();

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", idUsu));

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.EstadoTarea = (Estado)Convert.ToInt32(reader["estado"]);
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tareas.Add(tarea);
                    }
                }
                conexion.Close();
            }
            return tareas;
        }

        public List<Tarea> ListarTareasPorTablero(int idTab)
        {
            var queryString = @"SELECT * FROM Tarea WHERE id_usuario_asignado = @idTablero;"; 
            List<Tarea> tareas = new List<Tarea>();

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTablero", idTab));

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        tarea.EstadoTarea = (Estado)Convert.ToInt32(reader["estado"]);
                        tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        tareas.Add(tarea);
                    }
                }
                conexion.Close();
            }
            return tareas;
        }

        public void EliminarTarea(int idTarea)
        {
            var queryString = @"DELETE FROM Tarea WHERE id = @idTarea;";

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public void AsignarUsuarioATarea(int idTarea, int idUsu)
        {
            var queryString = @"UPDATE Tarea SET id_usuario_asignado = @idUsu WHERE id = @idTarea;";

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);
                comando.Parameters.Add(new SQLiteParameter("@idUsu", idUsu));
                comando.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));

                comando.ExecuteNonQuery();
                conexion.Close();
            }
        }

        public List<Tarea> ListarTareas()
        {
            var queryString = @"SELECT * FROM tarea;";
            List<Tarea> tareas = new List<Tarea>();

            using (SQLiteConnection conexion = new SQLiteConnection(CadenaDeConexion))
            {
                conexion.Open();
                SQLiteCommand comando = new SQLiteCommand(queryString, conexion);

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Tarea tarea = new Tarea();
                        tarea.Id = Convert.ToInt32(reader["id"]);
                        tarea.IdTablero = Convert.ToInt32(reader["id_tablero"]);
                        tarea.Nombre = reader["nombre"].ToString();
                        tarea.EstadoTarea = (Estado)Convert.ToInt32(reader["estado"]);
                        tarea.Descripcion = reader["descripcion"].ToString();
                        tarea.Color = reader["color"].ToString();
                        if (reader["id_usuario_asignado"] == DBNull.Value)
                        {
                            tarea.IdUsuarioAsignado = 0;   
                        } else {
                            tarea.IdUsuarioAsignado = Convert.ToInt32(reader["id_usuario_asignado"]);
                        }
                        tareas.Add(tarea);
                    }
                }
                conexion.Close();
            }
            return tareas;
        }
    }
}