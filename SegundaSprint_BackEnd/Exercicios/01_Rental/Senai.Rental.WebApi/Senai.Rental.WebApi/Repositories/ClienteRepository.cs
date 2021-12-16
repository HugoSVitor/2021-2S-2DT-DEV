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
    /// Classe responsável pelo repositório dos clientes
    /// </summary>
    public class ClienteRepository : IClienteRepository
    {
        //private string stringConexao = @"data source=NOTE0113F1\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";
        //private string stringConexao = @"data source=NOTE0113E2\SQLEXPRESS; initial catalog = T_Rental; user Id=sa; pwd= Senai@132";
        public string stringConexao = @"data source=NOTE0113E4\SQLEXPRESS; initial catalog=T_Rental; user Id=sa; pwd=Senai@132";


        public void AtualizarIdUrlCliente(int idCliente, ClienteDomain clienteAtualizado)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryUpdateUrl = "UPDATE Cliente SET nomeCliente = @nomeCliente, sobrenomeCliente = @sobrenomeCliente, cpfCliente = @cpfCliente, cnhCliente = @cnhCliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryUpdateUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", clienteAtualizado.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", clienteAtualizado.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", clienteAtualizado.cpfCliente);
                    cmd.Parameters.AddWithValue("@cnhCliente", clienteAtualizado.cnhCliente);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public ClienteDomain BuscarPorIdCliente(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectById = "SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente, cnhCliente FROM Cliente WHERE idCliente = @idCliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectById, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    rdr = cmd.ExecuteReader();

                    if (rdr.Read())
                    {
                        ClienteDomain clienteBuscado = new ClienteDomain
                        {
                            idCliente = Convert.ToInt32(rdr["idCliente"]),
                            nomeCliente = rdr["nomeCliente"].ToString(),
                            sobrenomeCliente = rdr["sobrenomeCliente"].ToString(),
                            cpfCliente = rdr["cpfCliente"].ToString(),
                            cnhCliente = rdr["cnhCliente"].ToString()
                        };
                        return clienteBuscado;
                    }
                    return null;
                }
            }
        }

        public void DeletarCliente(int idCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryDelete = "DELETE FROM Cliente WHERE idCliente = @idCliente";

                using (SqlCommand cmd = new SqlCommand(queryDelete, con))
                {
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void InserirCliente(ClienteDomain novoCliente)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInsert = "INSERT INTO Cliente (nomeCliente,sobrenomeCliente,cpfCliente,cnhCliente) VALUES (@nomeCliente,@sobrenomeCliente,@cpfCliente,@cnhCliente)";

                con.Open();

                using (SqlCommand cmd = new SqlCommand(queryInsert, con))
                {
                    cmd.Parameters.AddWithValue("@nomeCliente", novoCliente.nomeCliente);
                    cmd.Parameters.AddWithValue("@sobrenomeCliente", novoCliente.sobrenomeCliente);
                    cmd.Parameters.AddWithValue("@cpfCliente", novoCliente.cpfCliente);
                    cmd.Parameters.AddWithValue("@cnhCliente", novoCliente.cnhCliente);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<ClienteDomain> ListarTodosClientes()
        {
            List<ClienteDomain> listaClientes = new List<ClienteDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idCliente, nomeCliente, sobrenomeCliente, cpfCliente, cnhCliente FROM Cliente";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        ClienteDomain cliente = new ClienteDomain()
                        {
                            idCliente = Convert.ToInt32(rdr["idCliente"]),

                            nomeCliente = rdr["nomeCliente"].ToString(),

                            sobrenomeCliente = rdr["sobrenomeCliente"].ToString(),

                            cpfCliente = rdr["cpfCliente"].ToString(),

                            cnhCliente = rdr["cnhCliente"].ToString()
                        };

                        listaClientes.Add(cliente);
                    }
                }
            }
            return listaClientes;
        }
    }
}
