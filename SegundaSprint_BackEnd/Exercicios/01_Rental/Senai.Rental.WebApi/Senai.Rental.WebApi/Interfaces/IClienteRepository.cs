using Senai.Rental.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Interfaces
{
    /// <summary>
    /// Interface responsável pelo repositório ClienteRepository
    /// </summary>
    interface IClienteRepository
    {
        //listar, buscar por id, deletar, atualizar e inserir

        /// <summary>
        /// Lista todos os clientes do sistema
        /// </summary>
        /// <returns>Lista de clientes</returns>
        List<ClienteDomain> ListarTodosClientes();

        /// <summary>
        /// Busca um cliente especifico pelo id
        /// </summary>
        /// <param name="idCliente">Id do Cliente que será buscado</param>
        /// <returns>Cliente caso encontrado</returns>
        ClienteDomain BuscarPorIdCliente(int idCliente);

        /// <summary>
        /// Inseri/Cadastra um novo cliente
        /// </summary>
        /// <param name="novoCliente">Objeto novoCliente que será inserido/cadastrado</param>
        void InserirCliente(ClienteDomain novoCliente);

        /// <summary>
        /// Deleta um cliente
        /// </summary>
        /// <param name="idCliente">Id do cliente que será deletado</param>
        void DeletarCliente(int idCliente);

        /// <summary>
        /// Atualiza um cliente existente passando o id pela URL
        /// </summary>
        /// <param name="idCliente">Id do cliente que será atualizado</param>
        /// <param name="clienteAtualizar">Objeto clienteAtualizado com os novos dados atualizados</param>
        void AtualizarIdUrlCliente(int idCliente, ClienteDomain clienteAtualizado);
    }
}
