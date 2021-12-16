using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório VeiculoRepository
    /// </summary>
    interface IVeiculoRepository
    {
        //listar, buscar por id, deletar, atualizar e inserir

        /// <summary>
        /// Inseri/Cadastra um novo veiculo
        /// </summary>
        /// <param name="novoVeiculo">Objeto novoVeiculo que será inserido/cadastrado</param>
        void InserirVeiculo(VeiculoDomain novoVeiculo);

        /// <summary>
        /// Deleta um veiculo
        /// </summary>
        /// <param name="idVeiculo">Id do veiculo que será deletado</param>
        void DeletarVeiculo(int idVeiculo);

        /// <summary>
        /// Atualiza um cliente existente passando o id pela URL
        /// </summary>
        /// <param name="idVeiculo">Id do veiculo que será atualizado</param>
        /// <param name="veiculoAtualizado">Objeto veiculoAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrlVeiculo(int idVeiculo, VeiculoDomain veiculoAtualizado);

        /// <summary>
        ///  Busca um veiculo especifico pelo id
        /// </summary>
        /// <param name="idVeiculo">Id do veiculo que será buscado</param>
        /// <returns>Veiculo caso encontrado</returns>
        VeiculoDomain BuscarPorIdVeiculo(int idVeiculo);

        /// <summary>
        /// Lista todos os veiculos inseridos/cadastrados
        /// </summary>
        /// <returns>Lista dos veiculos inseridos/cadastrados</returns>
        List<VeiculoDomain> ListarTodosVeiculos(); 
    }
}
