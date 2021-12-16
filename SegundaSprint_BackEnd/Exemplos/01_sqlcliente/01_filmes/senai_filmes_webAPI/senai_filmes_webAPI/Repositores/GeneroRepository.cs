using senai_filmes_webAPI.Domains;
using senai_filmes_webAPI.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Repositores
{
    /// <summary>
    /// Classe responsável pelo repositório dos gêneros
    /// </summary>
    public class GeneroRepository : IGeneroRepository
    {
        /// <summary>
        /// String conexão com o banco de dados que recebe os parâmentros.
        /// Data Source = Nome servidor
        /// initial catalog = Nome do banco de dados
        /// user Id = sa; pwd = Senai@132 = Faz autenticação com o SQL SERVER passando o login.
        /// </summary>
        private string stringConexao = @"Data Source = NOTE0113F1\SQLEXPRESS; initial catalog = CATALOGO; user Id = sa; pwd = Senai@132";

        public void AtualizarIdCorpo(GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado)
        {
            throw new NotImplementedException();
        }

        public GeneroDomain BuscarPorId(int idGenero)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(GeneroDomain novoGenero)
        {
            throw new NotImplementedException();
        }

        public void Deletar(int idGenero)
        {
            throw new NotImplementedException();
        }

        public List<GeneroDomain> ListarTodos()
        {
            List<GeneroDomain> listaGeneros = new List<GeneroDomain>();

            // Declara a SqlConnection "con" passando a string de conexão como parâmetro
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string querySelectAll = "SELECT idGenero, nomeGenero FROM GENERO";

                //Abre a conexão com o banco de dados.
                con.Open();

                //Declarando SqlDataReader rdr para percorrer a tabela do nosso banco de dados.
                SqlDataReader rdr;

                //Declara o SqlCommand passando o query que será executada e a conexão com parâmetros.
                using (SqlCommand cmd = new SqlCommand(querySelectAll, con))
                {
                    //Executa a query e armazena os dados no rdr.
                    rdr = cmd.ExecuteReader();

                    //Enquanto tiver registros para serem lidos no rdr, o laço se repete,
                    while (rdr.Read())
                    {
                        //Instancia um objeto tipo GeneroDomain.
                        GeneroDomain genero = new GeneroDomain()
                        {
                            //Atribui a propriedade idGenero o valor da primeira coluna do banco de dados.
                            idGenero = Convert.ToInt32(rdr[0]),
                            //Atribui a propriedade nomeGenero o valor da segunda coluna do banco de dados.
                            nomeGenero = rdr[1].ToString()
                        };
                        //Adiciona o objeto genero criado a lista listaGeneros.
                        listaGeneros.Add(genero);
                    }
                }
            };
            return listaGeneros;
        }
    }
}
