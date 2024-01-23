using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace _10_Cryptography.BL
{
    public static class RsaAlgo
    {
        private static RSAParameters privateKey;
        private static RSAParameters publicKey;

        // Hardcoded key values
        private static string privateKeyModulus = "vNVT3KcFaqAde4w85QqZhU6K+jv5B4bjpt/8P1buBR2RYgo5ZuBfEUFzTLy8z/4gsYhQwuDgVtAyVvEP3rYFaNkjf5j05d3jriVJrDGDXEzAVzOex8Q7RtdFoFfM+0bN1ndnTkBLyCz9fHKRYF6hXEuMGztlvf6gLA1SUVk=";
        private static string privateKeyExponent = "AQAB";
        private static string privateKeyP = "/kZaC9idJ1lh4WQW6F7INsH1W5n1zMjozhdMW4oqo2cPMMkOi+B8O9bsh9lG5LwvOU65mN2nV6kA8M3qyJ7Xpw==";
        private static string privateKeyQ = "zrTZ5qvlGJFfpQ3/0/Eodmd7HylF9Zug0JjF/LVlL0YtFKg2zGugpWx9sXYYV8ZLJe8Rrdlxw0wQk7V08KklFw==";
        private static string privateKeyDP = "YL0xVRypwKkU4e92+M0HP0DzAkLQnTlDZYXh3VtS5ltU64F/eP8yz1Aa1fe7Hzx1w9Mu9f0YsBx4Js4dL+ucTw==";
        private static string privateKeyDQ = "eLjkfn+RGr4Jr/zFg/fHQR3yFdTCWD9c7eOe+3i2q0T1rvgR47LB9neceVtVJSz8iW91nC+bkUShL8vKq2rH+Q==";
        private static string privateKeyInverseQ = "dWlIn1lTz4eEeSv0vQ3mYsMQoFGLVRvTwWV8De6vDhxWumU+5I3FMrTm8zyuRU3KtMPkiv0O+SmLpAPkt9lCqg==";
        private static string privateKeyD = "mq/BGVSxiT35ENiQxCMJ0h9gm+8Mqfv8MGTnE2sLhaGRuXg8Zm8v8TsiFdyDDJjz3UQUy7gLw8VhtSt3P8zFq6ztTeJFJvQ3WnsjTeExOVtpzYXSS3LT0EgZpI+QUoD0RDAdyGorI9FGeEFjhW+Up1HY9G2INzL/fq2GfEiKE=";

        private static string publicKeyModulus = "vNVT3KcFaqAde4w85QqZhU6K+jv5B4bjpt/8P1buBR2RYgo5ZuBfEUFzTLy8z/4gsYhQwuDgVtAyVvEP3rYFaNkjf5j05d3jriVJrDGDXEzAVzOex8Q7RtdFoFfM+0bN1ndnTkBLyCz9fHKRYF6hXEuMGztlvf6gLA1SUVk=";
        private static string publicKeyExponent = "AQAB";

        static RsaAlgo()
        {
            privateKey = new RSAParameters
            {
                Modulus = Convert.FromBase64String(privateKeyModulus),
                Exponent = Convert.FromBase64String(privateKeyExponent),
                P = Convert.FromBase64String(privateKeyP),
                Q = Convert.FromBase64String(privateKeyQ),
                DP = Convert.FromBase64String(privateKeyDP),
                DQ = Convert.FromBase64String(privateKeyDQ),
                InverseQ = Convert.FromBase64String(privateKeyInverseQ),
                D = Convert.FromBase64String(privateKeyD)
            };

            publicKey = new RSAParameters
            {
                Modulus = Convert.FromBase64String(publicKeyModulus),
                Exponent = Convert.FromBase64String(publicKeyExponent)
            };
        }

        public static string Encrypt(string plainText)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(publicKey);

                byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
                byte[] encryptedBytes = rsa.Encrypt(plainBytes, false);

                return Convert.ToBase64String(encryptedBytes);
            }
        }

        public static string Decrypt(string cipherText)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(privateKey);

                byte[] cipherBytes = Convert.FromBase64String(cipherText);
                byte[] decryptedBytes = rsa.Decrypt(cipherBytes, false);

                return Encoding.UTF8.GetString(decryptedBytes);
            }
        }
    }
}