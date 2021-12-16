using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class JogoRepository : IJogoRepository
    {

        private string stringConexao = @"Data Source=NOTE0113E4\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"Data Source=NOTE0113H3\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrlJogo(int idJogo, JogoDomain jogoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE JOGO SET nomeJogo = @nomeJogo,descricaoJogo = @descricaoJogo, dataLancamento = @dataLancamento, valor = @valor, idEstudio = @idEstudio WHERE idJogo = @idJogo ";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoAtualizado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoAtualizado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoAtualizado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoAtualizado.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoAtualizado.idEstudio);
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public JogoDomain BuscarPorIdJogo(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idJogo,nomeJogo,descricao,dataLancamento,valor,idEstudio,nomeEstudio FROM JOGO LEFT JOIN ESTUDIO ON JOGO.idEstudio = ESTUDIO.idEstudio WHERE idJogo = @idJogo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        JogoDomain jogoBuscado = new JogoDomain
                        {
                            idJogo = Convert.ToInt32(reader["idJogo"]),
                            nomeJogo = reader["nomeEstudio"].ToString(),
                            descricao = reader["descricao"].ToString(),
                            valor = reader["valor"].ToString(),
                            dataLancamento = Convert.ToDateTime(reader["dataLancamento"]),
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(reader["idEstudio"]),

                                nomeEstudio = reader["nomeEstudio"].ToString()
                            }

                            
                        };
                        return jogoBuscado;
                    }
                    return null;
                }
            }
        }

        public void CadastrarJogo(JogoDomain jogoCadastrado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO JOGO (nomeJogo,descricao,dataLancamento,valor,idEstudio) VALUES (@nomeJogo,@descricao,@dataLancamento,@valor,@idEstudio,)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeJogo", jogoCadastrado.nomeJogo);
                    cmd.Parameters.AddWithValue("@descricao", jogoCadastrado.descricao);
                    cmd.Parameters.AddWithValue("@dataLancamento", jogoCadastrado.dataLancamento);
                    cmd.Parameters.AddWithValue("@valor", jogoCadastrado.valor);
                    cmd.Parameters.AddWithValue("@idEstudio", jogoCadastrado.idEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarJogo(int idJogo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM JOGO WHERE idJogo = @idJogo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idJogo", idJogo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<JogoDomain> ListarTodosJogos()
        {
            List<JogoDomain> listaJogos = new List<JogoDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = @"SELECT	idJogo,
		                                        nomeJogo, 
		                                        descricao, 
		                                        dataLancamento, 
		                                        valor, 
		                                        J.idEstudio, 
		                                        nomeEstudio 
                                        FROM JOGO J
                                        LEFT JOIN ESTUDIO E
                                        ON J.idEstudio = E.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        JogoDomain jogos = new JogoDomain()
                        {
                            idJogo = Convert.ToInt32(rdr["idJogo"]),
                            nomeJogo = rdr["nomeJogo"].ToString(),
                            descricao = rdr["descricao"].ToString(),
                            dataLancamento = Convert.ToDateTime(rdr["dataLancamento"]),
                            valor = (rdr["valor"]).ToString(),
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            estudio = new EstudioDomain()
                            {
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                                nomeEstudio = rdr["nomeEstudio"].ToString()
                            }
                        };

                        listaJogos.Add(jogos);
                    }
                }
            }
            return listaJogos;
        }
    }
}
