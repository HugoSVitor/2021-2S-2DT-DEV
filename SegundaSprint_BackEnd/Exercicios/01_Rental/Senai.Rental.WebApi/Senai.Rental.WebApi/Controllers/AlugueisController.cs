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
    public class AlugueisController : Controller
    {
        private IAluguelRepository _aluguelRepository { get; set; }
        public AlugueisController ()
        {
            _aluguelRepository = new AluguelRespository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<AluguelDomain> listaAlugueis = _aluguelRepository.ListarTodosAlugueis();

            return Ok(listaAlugueis);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            AluguelDomain alguelBuscado = _aluguelRepository.BuscarPorIdAluguel(id);

            if (alguelBuscado == null)
            {
                return NotFound("Nenhum aluguel encontrado!");
            }

            return Ok(alguelBuscado);
        }

        [HttpPost]
        public IActionResult Post(AluguelDomain novoAluguel)
        {
            _aluguelRepository.InserirAluguel(novoAluguel);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, AluguelDomain aluguelAtualizado)
        {
            AluguelDomain aluguelBuscado = _aluguelRepository.BuscarPorIdAluguel(id);

            if (aluguelBuscado == null)
            {
                return NotFound(
                        new
                        {
                            mensagem = "Nenhum aluguel encontrado!",
                            erro = true
                        }
                    );
            }

            try
            {
                _aluguelRepository.AtualizarIdUrlAluguel(id, aluguelAtualizado);

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
            _aluguelRepository.DeletarAluguel(id);

            return NoContent();
        }
    }
}
