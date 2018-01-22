using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using ERPSolution.Generic;

namespace ERPSolution.Helper
{
    public static class CryptoHelper
    {
        #region Declarations

        private static readonly string EncryptionKey = EntityBase.InstanceValues.Where(iv => iv.PropertyName.ToUpper() == "ENCRYPTIONKEY").Select(iv => iv.Value).FirstOrDefault();

        #endregion

        #region Public Methods

        public static string EncryptData(string data)
        {
            if (string.IsNullOrEmpty(data))
                return string.Empty;

            byte[] clearBytes = Encoding.Unicode.GetBytes(data);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    data = Convert.ToBase64String(ms.ToArray());
                }
            }
            return data;
        }

        public static string DecryptData(string data)
        {
            if (string.IsNullOrEmpty(data))
                return string.Empty;
            //
            //string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(data);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    data = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return data;
        }
        
        #endregion
    }
}