using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {

        private string stringConexao = @"Data Source=NOTE0113E4\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"Data Source=NOTE0113H3\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrlUsuario(int idUsuario, UsuarioDomain usuarioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE USUARIO SET email = @email, senha = @senha, idTipoUsuario = @idTipoUsuario WHERE idUsuario = @idUsuario ";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@email", usuarioAtualizado.email);
                    cmd.Parameters.AddWithValue("@senha", usuarioAtualizado.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuarioAtualizado.idTipoUsuario);
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public UsuarioDomain Logar(string email, string senha)
        {
            using (SqlConnection con = new(stringConexao))
            {
                string querySelect = @"SELECT    idUsuario
                                                 , email
                                                , senha
                                                , U.idTipoUsuario
                                                , titulo
                                                FROM USUARIO U
                                                INNER JOIN TIPOUSUARIO T 
                                                ON U.idTipoUsuario =                                        T.idTipoUsuario
                                                WHERE email = @email
                                                and senha = @senha";

                using (SqlCommand cmd = new(querySelect,con))
                {
                    cmd.Parameters.AddWithValue("@email",email);
                    cmd.Parameters.AddWithValue("@senha", senha);

                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"])
                        };

                        return usuarioBuscado;
                    }

                    return null;
                }
            }
        }

        public UsuarioDomain BuscarPorIdUsuario(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT email,senha,titulo FROM USUARIO LEFT JOIN TIPOUSUARIO ON USUARIO.idTipoUsuario = TIPOUSUARIO.idTipoUsuario WHERE idUsuario = @idUsuario";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        UsuarioDomain usuarioBuscado = new UsuarioDomain
                        {
                            idUsuario = Convert.ToInt32(reader["idUsuario"]),
                            email = reader["email"].ToString(),
                            senha = reader["senha"].ToString(),
                            idTipoUsuario = Convert.ToInt32(reader["idTipoUsuario"]),

                        };
                        return usuarioBuscado;
                    }
                    return null;
                }
            }
        }

        public void CadastrarUsuario(UsuarioDomain usuarioCadastrado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO USUARIO (email,senha,idTipoUsuario) VALUES (@email,@senha,@idTipoUsuario)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@email", usuarioCadastrado.email);
                    cmd.Parameters.AddWithValue("@senha", usuarioCadastrado.senha);
                    cmd.Parameters.AddWithValue("@idTipoUsuario", usuarioCadastrado.idTipoUsuario);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarUsuario(int idUsuario)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM USUARIO WHERE idUsuario = @idUsuario";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<UsuarioDomain> ListarTodosUsuarios()
        {
            List<UsuarioDomain> listaUsuarios = new List<UsuarioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM USUARIO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        UsuarioDomain usuarios = new UsuarioDomain()
                        {
                            idUsuario = Convert.ToInt32(rdr["idUsuario"]),
                            idTipoUsuario = Convert.ToInt32(rdr["idTipoUsuario"]),
                            email = rdr["email"].ToString(),
                            senha = rdr["senha"].ToString()

                        };

                        listaUsuarios.Add(usuarios);
                    }
                }
            }
            return listaUsuarios;
        }
    }
}
