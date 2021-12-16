using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface ITipoUsuarioRepository
    {
        void CadastrarTipoUsuario(TipoUsuarioDomain tipoUsuarioCadastrado);

        void DeletarTipoUsuario(int idTipoUsuario);
        
        List<TipoUsuarioDomain> ListarTodosTipoUsuario();

        TipoUsuarioDomain BuscarPorIdTipoUsuario(int idTipoUsuario);

        void AtualizarIdUrlTipoUsuario(int idTipoUsuario, TipoUsuarioDomain tipoUsuarioAtualizado);
    }
}
