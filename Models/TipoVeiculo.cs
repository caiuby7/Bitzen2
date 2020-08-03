using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class TipoVeiculo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
      

        public virtual List<Veiculo> Veiculos { get; set; }
        public TipoVeiculo(string descricao)
        {
            Descricao = descricao;
         }
    }
}
