
namespace Bitzen.Models
{
  public class DefaultViewModel 
  {
    public DefaultViewModel(bool sucesso, string mensagem, object dados)
    {
      Sucesso = sucesso;
      Mensagem = mensagem;
      Dados = dados;
    }

    public DefaultViewModel(bool sucesso, string mensagem, int id)
    {
      Sucesso = sucesso;
      Mensagem = mensagem;
      Id = id;
    }
    
    public DefaultViewModel(bool sucesso, string mensagem, object dados, int id)
    {
      Sucesso = sucesso;
      Mensagem = mensagem;
      Id = id;
      Dados = dados;
    }
    public bool Sucesso { get; set; }
    public string Mensagem { get; set; }
    public object Dados { get; set; }
    public int Id { get; set; }
  }
}