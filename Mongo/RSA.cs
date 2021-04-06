using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Serialization;

namespace Mongo
{
    public class RSA
    {
        public static string GetStrKey(RSAParameters klic)
        {
            var sw = new StringWriter();
            var xmlSerializer = new XmlSerializer(typeof(RSAParameters));
            xmlSerializer.Serialize(sw, klic);
            return sw.ToString();
        }
        
        public static string Encrypt(string text, string publicKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(text);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(publicKeyString.ToString());
                var enData = rsa.Encrypt(bytesToEncrypt, true);
                var base64En = Convert.ToBase64String(enData);
                return base64En;
            }
        }

        public static string Decrypt(string text, string privateKeyString)
        {
            var bytesToEncrypt = Encoding.UTF8.GetBytes(text);
            using (var rsa = new RSACryptoServiceProvider(2048))
            {
                rsa.FromXmlString(privateKeyString);
                var resBytes = Convert.FromBase64String(text);
                var decBytes = rsa.Decrypt(resBytes, true);
                var decData = Encoding.UTF8.GetString(decBytes);
                return decData.ToString();
            }
        }
    }
}