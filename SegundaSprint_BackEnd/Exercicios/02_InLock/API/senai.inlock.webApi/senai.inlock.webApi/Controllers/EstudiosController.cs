using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    
    public class EstudiosController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }

        public EstudiosController()
        {
            _estudioRepository = new EstudioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodosEstudios();

            return Ok(listaEstudios);
        }

        [HttpGet("listar")]
        public IActionResult ListarEstudiosJogos()
        {
            List<EstudioDomain> listaEstudios = _estudioRepository.ListarEstudiosJogos();

            return Ok(listaEstudios);
        }

        [HttpGet("{idEstudio}")]
        public IActionResult BuscarPorId(int idEstudio)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorIdEstudio(idEstudio);

            if (estudioBuscado == null)
            {
                return NotFound("Nenhum estudio encontrado!");
            }

            return Ok(estudioBuscado);
        }

        [HttpPost]
        public IActionResult CadastrarEstudio(EstudioDomain estudioCadastrado)
        {
            _estudioRepository.CadastrarEstudio(estudioCadastrado);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{idEstudio}")]
        public IActionResult DeletarEstudio(int idEstudioDeletado)
        {
            _estudioRepository.DeletarEstudio(idEstudioDeletado);

            return NoContent();
        }

        [HttpPut]
        public IActionResult AtualizarEstudio(int idEstudio, EstudioDomain estudioAtualizado)
        {
            EstudioDomain estudioBuscado = _estudioRepository.BuscarPorIdEstudio(idEstudio);

            if (estudioBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Estudio não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {
                _estudioRepository.AtualizarIdUrlEstudio(idEstudio, estudioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }


    }
}
