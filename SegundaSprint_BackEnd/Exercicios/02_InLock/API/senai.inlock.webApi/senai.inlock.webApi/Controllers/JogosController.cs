using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    
    public class JogosController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }

        public JogosController()
        {
            _jogoRepository = new JogoRepository();
        }

        [Authorize]
        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<JogoDomain> listaJogos = _jogoRepository.ListarTodosJogos();

            return Ok(listaJogos);
        }

        [HttpGet("{idJogo}")]
        public IActionResult BuscarPorId(int idJogo)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorIdJogo(idJogo);

            if (jogoBuscado == null)
            {
                return NotFound("Nenhum jogo encontrado!");
            }

            return Ok(jogoBuscado);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPost]
        public IActionResult CadastrarJogo(JogoDomain jogoCadastrado)
        {
            _jogoRepository.CadastrarJogo(jogoCadastrado);

            return StatusCode(201);
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpDelete("excluir/{idJogo}")]
        public IActionResult DeletarJogo(int idJogoDeletado)
        {
            _jogoRepository.DeletarJogo(idJogoDeletado);

            return NoContent();
        }

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpPut]
        public IActionResult AtualizarJogo(int idJogo, JogoDomain jogoAtualizado)
        {
            JogoDomain jogoBuscado = _jogoRepository.BuscarPorIdJogo(idJogo);

            if (jogoBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Jogo não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {
                _jogoRepository.AtualizarIdUrlJogo(idJogo, jogoAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
