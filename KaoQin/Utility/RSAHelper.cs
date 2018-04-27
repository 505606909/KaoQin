 

using System;
using System.Security.Cryptography;
using System.Text;


using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KaoQin.Utility
{
    public static class RsaHelper
    {
        public static string key = "CD3A5758870E4B870E4BA870E4BAA79170E4BA870E3E13870E4BAEE4BA79169870E4BA4665C30262694665C30262";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="rawInput"></param>
        /// <returns></returns>
        public static string Encrypt(string rawInput)
        {
            if (string.IsNullOrEmpty(rawInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Invalid Public Key");
            }
            CspParameters param = new CspParameters();
            param.KeyContainerName = key;//密匙容器的名称，保持加密解密一致才能解密成功 

            using (var rsaProvider = new RSACryptoServiceProvider(param))
            {
                var inputBytes = Encoding.UTF8.GetBytes(rawInput);//有含义的字符串转化为字节流
              
                int bufferSize = (rsaProvider.KeySize / 8) - 11;//单块最大长度
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    { //分段加密
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var encryptedBytes = rsaProvider.Encrypt(temp, false);
                        outputStream.Write(encryptedBytes, 0, encryptedBytes.Length);
                    }
                    return Convert.ToBase64String(outputStream.ToArray());//转化为字节流方便传输
                }
            }
        }
        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="encryptedInput"></param>
        /// <returns></returns>
        public static string Decrypt(string encryptedInput)
        {
            if (string.IsNullOrEmpty(encryptedInput))
            {
                return string.Empty;
            }

            if (string.IsNullOrWhiteSpace(key))
            {
                throw new ArgumentException("Invalid Private Key");
            }
            CspParameters param = new CspParameters();
            param.KeyContainerName = key;//密匙容器的名称，保持加密解密一致才能解密成功 

            using (var rsaProvider =  new RSACryptoServiceProvider(param))
            {
                var inputBytes = Convert.FromBase64String(encryptedInput); 
                int bufferSize = rsaProvider.KeySize / 8;
                var buffer = new byte[bufferSize];
                using (MemoryStream inputStream = new MemoryStream(inputBytes),
                     outputStream = new MemoryStream())
                {
                    while (true)
                    {
                        int readSize = inputStream.Read(buffer, 0, bufferSize);
                        if (readSize <= 0)
                        {
                            break;
                        }

                        var temp = new byte[readSize];
                        Array.Copy(buffer, 0, temp, 0, readSize);
                        var rawBytes = rsaProvider.Decrypt(temp, false);
                        outputStream.Write(rawBytes, 0, rawBytes.Length);
                    }
                    return Encoding.UTF8.GetString(outputStream.ToArray());
                }
            }
        }
    }
}
 
