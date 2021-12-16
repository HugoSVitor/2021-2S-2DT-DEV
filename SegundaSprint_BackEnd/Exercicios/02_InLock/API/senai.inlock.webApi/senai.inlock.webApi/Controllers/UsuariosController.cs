using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.inlock.webApi_.Domains;
using senai.inlock.webApi_.Interfaces;
using senai.inlock.webApi_.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Controllers
{
    [Produces("application/json")]

    [Route("api/[controller]")]

    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult ListarTodos()
        {
            List<UsuarioDomain> listaUsuarios = _usuarioRepository.ListarTodosUsuarios();

            return Ok(listaUsuarios);
        }

        [HttpGet("{idUsuario}")]
        public IActionResult BuscarPorId(int idUsuario)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorIdUsuario(idUsuario);

            if (usuarioBuscado == null)
            {
                return NotFound("Nenhum usuario encontrado!");
            }

            return Ok(usuarioBuscado);
        }

        [HttpPost("cadastro/")]
        public IActionResult Cadastrar(UsuarioDomain usuarioCadastrado)
        {
            _usuarioRepository.CadastrarUsuario(usuarioCadastrado);

            return StatusCode(201);
        }

        [HttpDelete("excluir/{idUsuario}")]
        public IActionResult Deletar(int idUsuarioDeletado)
        {
            _usuarioRepository.DeletarUsuario(idUsuarioDeletado);

            return NoContent();
        }

        [HttpPut]
        public IActionResult Atualizar(int idUsuario, UsuarioDomain usuarioAtualizado)
        {
            UsuarioDomain usuarioBuscado = _usuarioRepository.BuscarPorIdUsuario(idUsuario);

            if (usuarioBuscado == null)
            {
                return NotFound(
                    new
                    {
                        mensagem = "Usuario não encontrado!",
                        erro = true
                    }
                    );
            }
            try
            {
                _usuarioRepository.AtualizarIdUrlUsuario(idUsuario, usuarioAtualizado);

                return NoContent();
            }
            catch (Exception erro)
            {
                return BadRequest(erro);
            }
        }

        [HttpPost("login/")]
        public IActionResult Login(UsuarioDomain login)
        {
           UsuarioDomain usuarioBuscado = _usuarioRepository.Logar(login.email, login.senha);

            if (usuarioBuscado ==  null)
            {
                return NotFound("Email ou senha não inválidos!");
            }

            //return Ok(usuarioBuscado);

            var minhasClaims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.email),
                new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.idUsuario.ToString()),
                new Claim(ClaimTypes.Role, usuarioBuscado.idTipoUsuario.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("inlock-chave-acesso"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var meuToken = new JwtSecurityToken(
                    issuer : "senai.inlock.webApi",
                    audience : "senai.inlock.webApi",
                    claims : minhasClaims,
                    expires : DateTime.Now.AddMinutes(30),
                    signingCredentials : creds
                );

            return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
        }
    }
}
