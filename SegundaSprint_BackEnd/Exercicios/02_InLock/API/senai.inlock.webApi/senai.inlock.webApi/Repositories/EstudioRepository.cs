using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Repositories
{
    public class EstudioRepository : IEstudioRepository
    {
        //private string stringConexao = @"Data Source=NOTE0113C4\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"Data Source=NOTE0113H3\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";
        private string stringConexao = @"Data Source=NOTE0113E4\SQLEXPRESS; initial catalog=inlock_games_tarde; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrlEstudio(int idEstudio, EstudioDomain estudioAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE ESTUDIO SET nomeEstudio = @nomeEstudio WHERE idEstudio = @idEstudio ";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio", estudioAtualizado.nomeEstudio);
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public EstudioDomain BuscarPorIdEstudio(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Veiculo WHERE idEstudio = @idEstudio";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        EstudioDomain estudioBuscado = new EstudioDomain
                        {
                            idEstudio = Convert.ToInt32(reader["idEstudio"]),
                            nomeEstudio = reader["nomeEstudio"].ToString()
                        };
                        return estudioBuscado;
                    }
                    return null;
                }
            }
        }

        public void CadastrarEstudio(EstudioDomain estudioCadastrado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO ESTUDIO (nomeEstudio) VALUES(@nomeEstudio)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeEstudio",estudioCadastrado.nomeEstudio);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletarEstudio(int idEstudio)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM ESTUDIO WHERE idEstudio = @idEstudio";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idEstudio", idEstudio);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<EstudioDomain> ListarEstudiosJogos()
        {
            List<EstudioDomain> listaEstudio = new List<EstudioDomain>();


            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelect = @"SELECT ESTUDIO.idEstudio, nomeEstudio, ISNULL(descricao, 'Não Cadastrado') descricao, 
                                        ISNULL(nomeJogo, 'Não cadastrado') nomeJogo, ISNULL(idJogo, 0) idJogo, ISNULL(valor, 0) valor, 
                                        ISNULL(dataLancamento, '') dataLancamento FROM ESTUDIO LEFT JOIN JOGO ON JOGO.idEstudio = ESTUDIO.idEstudio";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelect, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain ESTUDIO = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                            nomeEstudio = rdr["nomeEstudio"].ToString(),
                            Jogo = new JogoDomain()
                            {
                                idEstudio = Convert.ToInt32(rdr["idEstudio"]),
                                idJogo = Convert.ToInt32(rdr["idJogo"]),
                                nomeJogo = rdr["nomeJogo"].ToString(),
                                descricao = rdr["descricao"].ToString(),
                                valor = (rdr["valor"]).ToString(),
                                dataLancamento = Convert.ToDateTime(rdr["dataLancamento"])
                            }
                        };

                        listaEstudio.Add(ESTUDIO);
                    }
                }
            }

            return listaEstudio;
        }

        public List<EstudioDomain> ListarTodosEstudios()
        {
            List<EstudioDomain> listaEstudios = new List<EstudioDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM ESTUDIO";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        EstudioDomain estudios = new EstudioDomain()
                        {
                            idEstudio = Convert.ToInt32(rdr[0]),

                            nomeEstudio = rdr[1].ToString()
                        };

                        listaEstudios.Add(estudios);
                    }
                }
            }
            return listaEstudios;
        }
    }
}
