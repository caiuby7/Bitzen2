using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class TipoCombustivel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }


        public virtual List<Abastecimento> Abastecimentos { get; set; }
        public TipoCombustivel(string descricao)
        {
            Descricao = descricao;
         }
    }
}
