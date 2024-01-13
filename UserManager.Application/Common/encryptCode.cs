using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace UserManager.Application.Common
{
    public class encryptCode
    {
       public  static string EncodePassword(string password)
        {
            var provider = MD5.Create();
            string codeBase = "1A0C1AB2-2A95-458E-8A28-25A4B07D6EB3";
            byte[] bytes = provider.ComputeHash(Encoding.UTF32.GetBytes(codeBase + password));
            return BitConverter.ToString(bytes).Replace("-", "").ToLower();
        }

    }
}
