using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bitzen.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
        public int IdPermissao { get; set; }
        public Boolean Ativo { get; set; }

        public virtual Permissao Permissao { get; set; }

        public Usuario(string nome, string login, string senha, string email, int idPermissao)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            IdPermissao = idPermissao;
        }
        public Usuario(int id, string nome, string login, string senha, string email, int idPermissao, Boolean ativo)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
            Email = email;
            IdPermissao = idPermissao;
            Ativo = ativo;
        }

        public Usuario()
        {
        }
    }
}
