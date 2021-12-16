using Microsoft.AspNetCore.Mvc;
using Senai.Rental.WebApi.Domains;
using Senai.Rental.WebApi.Interfaces;
using Senai.Rental.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    /// <summary>
    /// Controller responsavel pelos endpoints referentes aos clientes
    /// </summary>
    public class VeiculosController : Controller
    {
        private IVeiculoRepository _veiculoRepository { get; set; }

        public VeiculosController()
        {
            _veiculoRepository = new VeiculoRepository();
        }


        [HttpGet]
        public IActionResult Get()
        {
            List<VeiculoDomain> listaVeiculos = _veiculoRepository.ListarTodosVeiculos();

            return Ok(listaVeiculos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorIdVeiculo(id);

            if (veiculoBuscado == null)
            {
                return NotFound("Nenhum veiculo encontrado!");
            }

            return Ok(veiculoBuscado);
        }

        [HttpPost]
        public IActionResult Post(VeiculoDomain novoVeiculo)
        {
            _veiculoRepository.InserirVeiculo(novoVeiculo);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, VeiculoDomain veiculoAtualizado)
        {
            VeiculoDomain veiculoBuscado = _veiculoRepository.BuscarPorIdVeiculo(id);

            if (veiculoBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Nenhum veiculo encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _veiculoRepository.AtualizarIdUrlVeiculo(id, veiculoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpDelete("excluir/{id}")]
        public IActionResult Delete(int id)
        {
            _veiculoRepository.DeletarVeiculo(id);

            return NoContent();
        }
    }
}
