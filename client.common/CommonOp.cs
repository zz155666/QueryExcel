using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace client.common
{
  public  class CommonOp
    {
        public class StringSecurity
        {
            /// <summary>  
            /// MD5加密。  
            /// </summary>  
            public static string MD5Encrypt(string originalString)
            {
                MD5 md5 = new MD5CryptoServiceProvider();
                byte[] palindata = Encoding.Default.GetBytes(originalString);
                byte[] encryptdata = md5.ComputeHash(palindata);

                return Convert.ToBase64String(encryptdata);
            }

            /// <summary>  
            /// RAS加密。  
            /// </summary>  
            public static string RSAEncrypt(string originalString)
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = "ECPCIII";

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
                {
                    byte[] plaindata = Encoding.Default.GetBytes(originalString);
                    byte[] encryptdata = rsa.Encrypt(plaindata, false);

                    return Convert.ToBase64String(encryptdata);
                }
            }

            /// <summary>  
            /// RAS解密。  
            /// </summary>  
            public static string RSADecrypt(string securitylString)
            {
                CspParameters param = new CspParameters();
                param.KeyContainerName = "ECPCIII";
                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
                {
                    byte[] encryptdata = Convert.FromBase64String(securitylString);
                    byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                    return Encoding.Default.GetString(decryptdata);
                }
            }

            /// <summary>  
            /// DES加密。  
            /// </summary>  
            public static string DESEncrypt(string originalString)
            {
                string securtyString = null;
                string key = "15948146";
                string iv = "45987654";
                byte[] btKey = Encoding.UTF8.GetBytes(key);
                byte[] btIV = Encoding.UTF8.GetBytes(iv);
                byte[] inData = Encoding.UTF8.GetBytes(originalString);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(btKey, btIV), CryptoStreamMode.Write);

                cs.Write(inData, 0, inData.Length);
                cs.FlushFinalBlock();

                securtyString = Convert.ToBase64String(ms.ToArray());
                cs.Close();
                ms.Close();

                return securtyString;
            }

            /// <summary>  
            /// DES解密。  
            /// </summary>  
            public static string DESDecrypt(string securityString)
            {
                byte[] inData = null;
                try
                {
                    inData = Convert.FromBase64String(securityString);
                }
                catch (Exception)
                {
                    return null;
                }

                string originalString = null;
                string key = "15948146";
                string iv = "45987654";
                byte[] btKey = Encoding.UTF8.GetBytes(key);
                byte[] btIV = Encoding.UTF8.GetBytes(iv);

                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(btKey, btIV), CryptoStreamMode.Write);

                cs.Write(inData, 0, inData.Length);
                try
                {
                    cs.FlushFinalBlock();
                }
                catch (Exception)
                {
                    ms.Close();
                    return null;
                }


                originalString = Encoding.UTF8.GetString(ms.ToArray());
                cs.Close();
                ms.Close();

                return originalString;
            }
        }
    }
}
