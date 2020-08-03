using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class Abastecimento
    {
        public int Id { get; set; }
        public string Km { get; set; }
        public string Litros { get; set; }
        public string ValorPago { get; set; }
        public DateTime Data { get; set; }
        public string NomePosto { get; set; }
        public int IdVeiculo { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoCombustivel { get; set; }
        public bool ativo { get; set; }

        public virtual Usuario usuario { get; set; }

        public virtual TipoCombustivel tipocombustivel { get; set; }

        public virtual Veiculo veiculo { get; set; }


    }
}
