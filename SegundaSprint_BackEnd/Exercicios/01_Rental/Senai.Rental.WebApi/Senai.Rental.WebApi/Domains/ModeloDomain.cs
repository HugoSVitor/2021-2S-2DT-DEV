using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Rental.WebApi.Domains
{
    /// <summary>
    /// Classe representante da entidade(tabela) MODELO
    /// </summary>
    public class ModeloDomain
    {
        public int idModelo {get;set;}
        public int idMarca { get; set; }
        public string nomeModelo { get; set; }
    }
}
