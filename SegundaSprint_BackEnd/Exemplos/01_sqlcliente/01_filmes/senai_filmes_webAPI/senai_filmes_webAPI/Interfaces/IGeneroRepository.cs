using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório GeneroRepository
    /// </summary>
    interface IGeneroRepository
    {
        // Estrututa dos métodos
        // TipoRetorno NomeMetodo(tipoParamentro nomeParametro)
        //Ex. GeneroDomain Cadastrar()

        /// <summary>
        /// Listar todos os gêneros
        /// </summary>
        /// <returns>Lista de gêneros</returns>
        List<GeneroDomain> ListarTodos();

        /// <summary>
        /// Busca um gênero através do id
        /// </summary>
        /// <param name="idGenero">Id do gênero que será buscado</param>
        /// <returns>Um gênero buscado</returns>
        GeneroDomain BuscarPorId(int idGenero);

        /// <summary>
        /// Cadastra um novo gênero
        /// </summary>
        /// <param name="Domain">Objeto novo gênero com os novos dados</param>
        void Cadastrar(GeneroDomain novoGenero);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="generoAtualizado">Objeto com os novos dados</param>
        void AtualizarIdCorpo(GeneroDomain generoAtualizado);

        /// <summary>
        /// Atualiza um gênero existente
        /// </summary>
        /// <param name="idGenero">Id do gênero que será atualizado</param>
        /// <param name="generoAtualizado">Objeto com os novos dados</param>
        void AtualizarIdUrl(int idGenero, GeneroDomain generoAtualizado);

        /// <summary>
        /// Deleta um gênero existente
        /// </summary>
        /// <param name="idGenero">Id do gênero que será deletado</param>
        void Deletar(int idGenero);
    }
}
