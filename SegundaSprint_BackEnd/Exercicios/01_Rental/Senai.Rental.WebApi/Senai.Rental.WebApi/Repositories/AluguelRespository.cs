using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Repositories
{
    /// <summary>
    /// Classe responsável pelo repositório dos alugueis
    /// </summary>
    public class AluguelRespository : IAluguelRepository
    {
        //private string stringConexao = @"data source=NOTE0113F1\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"data source=NOTE0113E2\SQLEXPRESS; initial catalog = T_Rental; user Id=sa; pwd= Senai@132";
        public string stringConexao = @"data source=NOTE0113E4\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        public void AtualizarIdUrlAluguel(int idAluguel, AluguelDomain aluguelAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Aluguel SET idCliente = @idCliente, idVeiculo = @idVeiculo, dataDevolucao = @dataDevolucao, dataRetirada = @dataRetirada' WHERE idAluguel = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", aluguelAtualizado.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", aluguelAtualizado.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataDevolucao", aluguelAtualizado.dataDevolucao);
                    cmd.Parameters.AddWithValue("@dataRetirada", aluguelAtualizado.dataRetirada);
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public AluguelDomain BuscarPorIdAluguel(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Aluguel WHERE idAluguel = @idAluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        AluguelDomain aluguelBuscado = new AluguelDomain
                        {
                            idCliente = Convert.ToInt32(rdr["idCliente"]),
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),
                            idAluguel = Convert.ToInt32(rdr["idAluguel"]),
                            dataDevolucao = Convert.ToDateTime(rdr["dataDevolucao"]),
                            dataRetirada = Convert.ToDateTime(rdr["dataRetirada"])
                        };
                        return aluguelBuscado;
                    }
                    return null;
                }
            }
        }

        public void DeletarAluguel(int idAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Aluguel WHERE idAluguel = @idAluguel";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idAluguel", idAluguel);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void InserirAluguel(AluguelDomain novoAluguel)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Aluguel (idCliente,idVeiculo,dataRetirada,dataDevolucao) VALUES (@idCliente,@idVeiculo,@dataRetirada,@dataDevolucao)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", novoAluguel.idCliente);
                    cmd.Parameters.AddWithValue("@idVeiculo", novoAluguel.idVeiculo);
                    cmd.Parameters.AddWithValue("@dataRetirada", novoAluguel.dataRetirada);
                    cmd.Parameters.AddWithValue("@dataDevolucao", novoAluguel.dataDevolucao);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<AluguelDomain> ListarTodosAlugueis()
        {
            List<AluguelDomain> listaAlugueis = new List<AluguelDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Aluguel";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        AluguelDomain alugueis = new AluguelDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),

                            idCliente = Convert.ToInt32(rdr["idCliente"]),

                            idAluguel = Convert.ToInt32(rdr["idAluguel"]),

                            dataDevolucao = Convert.ToDateTime(rdr["dataDevolucao"]),

                            dataRetirada = Convert.ToDateTime(rdr["dataRetirada"])
                        };

                        listaAlugueis.Add(alugueis);
                    }
                }
            }
            return listaAlugueis;
        }
    }
}
