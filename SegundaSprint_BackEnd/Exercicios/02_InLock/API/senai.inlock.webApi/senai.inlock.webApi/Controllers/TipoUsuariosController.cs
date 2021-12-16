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

    [Authorize]
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<TipoUsuarioDomain> listaUsuarios = _tipoUsuarioRepository.ListarTodosTipoUsuario();

            return Ok(listaUsuarios);
        }

        [HttpGet("{idTipoUsuario}")]
        public IActionResult BuscarPorId(int idTipoUsuario)
        {
            TipoUsuarioDomain tipoUsuarioBuscado = _tipoUsuarioRepository.BuscarPorIdTipoUsuario(idTipoUsuario);

            if (tipoUsuarioBuscado == null)
            {
                return NotFound("Nenhum tipo de usuario encontrado!");
            }

            return Ok(tipoUsuarioBuscado);
        }

        [HttpPost]
        public IActionResult Cadastrar(TipoUsuarioDomain tipoUsuarioCadastrado)
        {
            _tipoUsuarioRepository.CadastrarTipoUsuario(tipoUsuarioCadastrado);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{idTipoUsuario}")]
        public IActionResult Deletar(int tipoUsuarioDeletado)
        {
            _tipoUsuarioRepository.DeletarTipoUsuario(tipoUsuarioDeletado);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar(int idTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado)
        {
            TipoUsuarioDomain usuarioBuscado = _tipoUsuarioRepository.BuscarPorIdTipoUsuario(idTipoUsuario);

            if (usuarioBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Tipo usuario não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {
                _tipoUsuarioRepository.AtualizarIdUrlTipoUsuario(idTipoUsuario, tipoUsuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }
    }
}
