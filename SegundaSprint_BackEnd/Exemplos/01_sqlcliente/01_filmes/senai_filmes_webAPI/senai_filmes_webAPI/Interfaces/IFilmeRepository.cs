using senai_filmes_webAPI.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_filmes_webAPI.Interfaces
{
    /// <summary>
    /// Interface responsvel pelo repositório FilmeRepository
    /// </summary>
    interface IFilmeRepository
    {
        /// <summary>
        /// Lista todos os filmes
        /// </summary>
        /// <returns>Lista de filmes</returns>
        List<FilmeDomain> ListarTodos();

        /// <summary>
        /// Busca um filme pelo id
        /// </summary>
        /// <param name="idFilme">Id do filme que será buscado</param>
        /// <returns>Retorna o filme buscado</returns>
        FilmeDomain BurcasPorId(int idFilme);

        /// <summary>
        /// Cadastra um novo filme
        /// </summary>
        /// <param name="novoFilme">Objeto novo filme com os novos dados</param>
        void Cadastrar(FilmeDomain novoFilme);

        /// <summary>
        /// Atualiza um filme existente
        /// </summary>
        /// <param name="idFilme">Id do filme que será atualizado</param>
        /// <param name="filmeAtualizado">Objeto com os novos dados</param>
        void AtualizarIdUrl(int idFilme, FilmeDomain filmeAtualizado);

        /// <summary>
        /// Deleta um filme existente pelo seu id
        /// </summary>
        /// <param name="idFilme">Id do filme que será deletado</param>
        void Deletar(int idFilme);
    }
}
