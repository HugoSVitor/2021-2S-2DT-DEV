using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IJogoRepository
    {
        void CadastrarJogo(JogoDomain jogoCadastrado);

        void DeletarJogo(int idJogo);

        List<JogoDomain> ListarTodosJogos();

        JogoDomain BuscarPorIdJogo(int idJogo);

        void AtualizarIdUrlJogo(int idJogo, JogoDomain jogoAtualizado);
    }
}
