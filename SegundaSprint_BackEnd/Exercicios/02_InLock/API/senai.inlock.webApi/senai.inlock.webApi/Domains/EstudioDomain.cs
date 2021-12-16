using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.inlock.webApi_.Domains
{
    public class EstudioDomain
    {
        public int idEstudio { get; set; }
        public string nomeEstudio { get; set; }
        public JogoDomain Jogo { get; set; }
    }
}
