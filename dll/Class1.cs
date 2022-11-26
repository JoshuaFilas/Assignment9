using System.Security.Cryptography;
using System.Text;

namespace dll
{
    public class Encrypt
    {
        public string encryptPassword(string password)
        {
            StringBuilder stringBuilder = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Encoding encode = Encoding.UTF8;
                byte[] result = hash.ComputeHash(encode.GetBytes(password));
                foreach (byte b in result)
                {
                    stringBuilder.Append(b.ToString("x2"));
                }
            }
            return stringBuilder.ToString();
        }
    }
}