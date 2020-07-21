using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace PanelDashboard.Service
{
    public class CrypetoBase64Service
    {
        private const string passphrase = "panel-dashboard-2020";

        public string Encode(string str)
        {
            try
            {
                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byKey = Encoding.UTF8.GetBytes(passphrase.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                return Convert.ToBase64String(ms.ToArray());
            }
            catch
            {
                return "error";
            }

        }
        public string Decode(string str)
        {
            try
            {
                str = str.Replace(" ", "+");
                byte[] byKey = { };
                byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
                byte[] inputByteArray = new byte[str.Length];

                byKey = Encoding.UTF8.GetBytes(passphrase.Substring(0, 8));
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding encoding = Encoding.UTF8;
                return encoding.GetString(ms.ToArray());
            }
            catch
            {
                return "error";
            }

        }
        public string UrlEncode(string Url)
        {
            try
            {
                Url = Encode(Url);
                Url = Url.Replace("/", "_");
                Url = Url.Replace("+", "-");

                return Url;
            }
            catch
            {
                return "error";
            }
        }
        public string UrlDecode(string Url)
        {
            try
            {
                Url = Url.Replace("_", "/");
                Url = Url.Replace("-", "+");

                Url = Decode(Url);

                return Url;
            }
            catch
            {
                return "error";
            }
        }
    }
}
