#region Using Directives

using System;
using System.IO;
using System.Security.Cryptography;

#endregion Using Directives

namespace FeedbackAppV3._0
{
    internal class Crypto
    {
        #region Function (byte[])EncryptStringToBytes Handler

        public static byte[] EncryptStringToBytes(string plainText, byte[] Key, byte[] IV)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            byte[] encrypted;
            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                var encryptor = rijAlg.CreateEncryptor(rijAlg.Key, rijAlg.IV);

                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }

                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return encrypted;

        }

        #endregion Function (byte[])EncryptStringToBytes Handler

        #region Function (string)DecryptStringFromBytes Handler

        public static string DecryptStringFromBytes(byte[] cipherText, byte[] Key, byte[] IV)
        {
            if (cipherText == null || cipherText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (Key == null || Key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(Key));
            }

            if (IV == null || IV.Length <= 0)
            {
                throw new ArgumentNullException(nameof(IV));
            }

            string plainText = null;

            using (var rijAlg = new RijndaelManaged())
            {
                rijAlg.Key = Key;
                rijAlg.IV = IV;

                var decryptor = rijAlg.CreateDecryptor(rijAlg.Key, rijAlg.IV);

                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plainText = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plainText;
        }

        #endregion Function (string)DecryptStringFromBytes Handler

    }
}
