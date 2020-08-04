using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class Veiculo
    {
        public int Id { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Placa { get; set; }
        public int KM { get; set; }
        public int IdUsuario { get; set; }
        public int IdTipoVeiculo { get; set; }
        public string foto { get; set; }

        public virtual Usuario usuario { get; set; }

        public virtual TipoVeiculo tipoveiculo { get; set; }

        public List<Abastecimento> abastecimentos { get; set; }
        public Relatorio_Abastecimento relatorio_abastecimento { get; set; }
    }
}
