using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório AluguelRepository
    /// </summary>
    interface IAluguelRepository
    {
        //listar, buscar por id, deletar, atualizar e inserir

        /// <summary>
        /// Inseri/Cadastra um novo aluguel
        /// </summary>
        /// <param name="novoAluguel">Objeto novoAluguel que será inserido/cadastrado</param>
        void InserirAluguel(AluguelDomain novoAluguel);

        /// <summary>
        /// Deleta um aluguel
        /// </summary>
        /// <param name="idAluguel">Id do aluguel que será deletado</param>
        void DeletarAluguel(int idAluguel);

        /// <summary>
        /// Atualiza um aluguel existente passando o id pela URL
        /// </summary>
        /// <param name="idAluguel">Id do aluguel que será atualizado</param>
        /// <param name="aluguelAtualizado">Objeto aluguelAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrlAluguel(int idAluguel, AluguelDomain aluguelAtualizado);

        /// <summary>
        ///  Busca um aluguel especifico pelo id
        /// </summary>
        /// <param name="idAluguel">Id do aluguel que será buscado</param>
        /// <returns>Aluguel caso encontrado</returns>
        AluguelDomain BuscarPorIdAluguel(int idAluguel);

        /// <summary>
        /// Lista todos os alugueis inseridos/cadastrados
        /// </summary>
        /// <returns>Lista dos algueis inseridos/cadastrados</returns>
        List<AluguelDomain> ListarTodosAlugueis();
    }
}
