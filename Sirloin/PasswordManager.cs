using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sirloin.Security
{
    public class PasswordManager
    {

        public string HashPassword(string username,string password)
        {
            return HashData(string.Format("{0}{1}",username.Substring(0,4).ToLower(),password.ToLower()));
        }
        public static string HashData(string data)
        {
            SHA256 hasher = SHA256Managed.Create();
            byte[] result = hasher.ComputeHash(Encoding.Unicode.GetBytes(data));
            StringBuilder sb = new StringBuilder(result.Length * 2);
            foreach (byte b in result)
            {
                sb.AppendFormat("{0:x2}", b);
            }
            return sb.ToString();
        }
        public bool IsValidPassword(string username, string password,string storedpassword)
        {
            return string.Compare(storedpassword, HashPassword(username, password)) == 0;
        }
        
    }
}