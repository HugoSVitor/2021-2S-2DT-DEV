using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {

        private string stringConexao = @"Data Source=NOTE0113C4\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"Data Source=NOTE0113H3\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrlTipoUsuario(int idTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE TIPOUSUARIO SET titulo = @titulo WHERE idTipoUsuario = @idTipoUsuario ";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", tipoUsuarioAtualizado.titulo);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public TipoUsuarioDomain BuscarPorIdTipoUsuario(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM TIPOUSUARIO WHERE idTipoUsuario = @idTipoUsuario";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        TipoUsuarioDomain tipoUsuarioBuscado = new TipoUsuarioDomain
                        {
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),
                            titulo = reader["titulo"].ToString(),

                        };
                        return tipoUsuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void CadastrarTipoUsuario(TipoUsuarioDomain tipoUsuarioCadastrado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO TIPOUSUARIO (titulo) VALUES (@titulo)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@titulo", tipoUsuarioCadastrado.titulo);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarTipoUsuario(int idTipoUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM TIPOUSUARIO WHERE idTipoUsuario = @idTipoUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idTipoUsuario", idTipoUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<TipoUsuarioDomain> ListarTodosTipoUsuario()
        {
            List<TipoUsuarioDomain> listaTipoUsuario = new List<TipoUsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM TIPOUSUARIO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        TipoUsuarioDomain tipoUsuarios = new TipoUsuarioDomain()
                        {
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            titulo = rdr["titulo"].ToString()
                        };

                        listaTipoUsuario.Add(tipoUsuarios);
                    }
                }
            }
            return listaTipoUsuario;
        }
    }
}
