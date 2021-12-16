using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IUsuarioRepository
    {
        UsuarioDomain Logar(string email, string senha);
        void CadastrarUsuario(UsuarioDomain usuarioCadastrado);

        void DeletarUsuario(int idUsuario);

        List<UsuarioDomain> ListarTodosUsuarios();

        UsuarioDomain BuscarPorIdUsuario(int idUsuario);

        void AtualizarIdUrlUsuario(int idUsuario, UsuarioDomain usuarioAtualizado);
    }
}
