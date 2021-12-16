using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representante da entidade(tabela) MARCA
    /// </summary>
    public class MarcaDomain
    {
        public int idMarca { get; set; }
        public string nomeMarca { get; set; }
    }
}
