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
    /// Classe responsável pelo repositório dos veiculos
    /// </summary>
    public class VeiculoRepository : IVeiculoRepository
    {
        /// <summary>
        /// String de conexão com o banco de dados que recebe os parâmetros.
        /// Data Source= Nome do Servidor
        /// initial catalog = Nome do Banco de Dados
        /// user ID= sa; pwd= Senai@132 = Faz autenticação com o SQL SERVER passando o Login e Senha.
        /// integrated security=true = Faz autenticação com o usuario do sistema (Windows)
        /// </summary>
        //private string stringConexao = @"data source=NOTE0113F1\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"data source=NOTE0113E2\SQLEXPRESS; initial catalog = T_Rental; user Id=sa; pwd= Senai@132";
        public string stringConexao = @"data source=NOTE0113E4\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";

        public void AtualizarIdUrlVeiculo(int idVeiculo, VeiculoDomain veiculoAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Veiculo SET idModelo = @idModelo, idMarca = @idMarca, placa = @placa WHERE idVeiculo = @idVeiculo ";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@idModelo", veiculoAtualizado.idModelo);
                    cmd.Parameters.AddWithValue("@idMarca", veiculoAtualizado.idMarca);
                    cmd.Parameters.AddWithValue("@placa", veiculoAtualizado.placa);
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public VeiculoDomain BuscarPorIdVeiculo(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT * FROM Veiculo WHERE idVeiculo = @idVeiculo";

                con.Open();

                SqlDataReader reader;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        VeiculoDomain veiculoBuscado = new VeiculoDomain
                        {
                            idVeiculo = Convert.ToInt32(reader["idVeiculo"]),
                            idMarca = Convert.ToInt32(reader["idMarca"]),
                            idModelo = Convert.ToInt32(reader["idModelo"]),
                            idEmpresa = Convert.ToInt32(reader["idEmpresa"]),
                            placa = reader["placa"].ToString()
                        };
                        return veiculoBuscado;
                    }
                    return null;
                }
            }
        }

        public void DeletarVeiculo(int idVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Veiculo WHERE idVeiculo = @idVeiculo";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idVeiculo", idVeiculo);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }

            }
        }

        public void InserirVeiculo(VeiculoDomain novoVeiculo)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Veiculo (idEmpresa,idModelo,idMarca,placa) VALUES (@idEMpresa,@idModelo,@idMarca,@placa)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert,con))
                {
                    cmd.Parameters.AddWithValue("@idEmpresa", novoVeiculo.idEmpresa);
                    cmd.Parameters.AddWithValue("@idModelo", novoVeiculo.idModelo);
                    cmd.Parameters.AddWithValue("@idMarca", novoVeiculo.idMarca);
                    cmd.Parameters.AddWithValue("@placa", novoVeiculo.placa);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<VeiculoDomain> ListarTodosVeiculos()
        {
            List<VeiculoDomain> listaVeiculos = new List<VeiculoDomain>();

            using (SqlConnection con =  new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT * FROM Veiculo";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll,con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        VeiculoDomain veiculo = new VeiculoDomain()
                        {
                            idVeiculo = Convert.ToInt32(rdr["idVeiculo"]),

                            idModelo = Convert.ToInt32(rdr["idModelo"]),
                            
                            idMarca = Convert.ToInt32(rdr["idMarca"]),

                            placa = rdr["placa"].ToString()
                        };

                        listaVeiculos.Add(veiculo);
                    }
                }
            }
            return listaVeiculos;
        }
    }
}
