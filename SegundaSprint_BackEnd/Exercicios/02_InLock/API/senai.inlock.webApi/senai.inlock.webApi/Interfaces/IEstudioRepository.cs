using senai.inlock.webApi_.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Interfaces
{
    interface IEstudioRepository
    {
        void CadastrarEstudio(EstudioDomain estudioCadastrado);

        void DeletarEstudio(int idEstudio);

        List<EstudioDomain> ListarTodosEstudios();

        EstudioDomain BuscarPorIdEstudio(int idEstudio);

        void AtualizarIdUrlEstudio(int idEstudio, EstudioDomain estudioAtualizado);
        List<EstudioDomain> ListarEstudiosJogos();
    }
}
