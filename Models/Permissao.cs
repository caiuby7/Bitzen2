using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class Permissao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public Boolean Ativo { get; set; }

        public virtual List<Usuario> Usuarios { get; set; }
        public Permissao(string descricao)
        {
            Descricao = descricao;
            Ativo = true;
        }
    }
}
