
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Bitzen.Helpers
{
  public class PermissaoHelper
  {
    public const string Admin = "Administrador";
    public const string Sistema = "Sistema";
    public const string Consulta = "Consultas";

    public static readonly IList<string> RolesSystem = new ReadOnlyCollection<string>(new List<string>
    {
        PermissaoHelper.Admin,
        PermissaoHelper.Sistema,
        PermissaoHelper.Consulta
    });
  }
}