
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text;

namespace Bitzen.Services
{
  public class PasswordService
  {
    public static string Encrypt(string password)
    {
      password += "|43a5d36f-b316-42e1-8a3c-7a19b924057d";
      var md5 = MD5.Create();
      var data = md5.ComputeHash(System.Text.Encoding.Default.GetBytes(password));

      var sbString = new StringBuilder();
      for (int i = 0; i < data.Length; i++)
        sbString.Append(data[i].ToString("x2"));

      return sbString.ToString();
    }
  }
}

