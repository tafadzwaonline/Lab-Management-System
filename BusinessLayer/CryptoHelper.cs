using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BusinessLayer
{
	// Token: 0x02000026 RID: 38
	public class CryptoHelper
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00007180 File Offset: 0x00005380
		public static string Encrypt(string strText, string Password)
		{
			byte[] rgbIV = new byte[]
			{
				77,
				48,
				byte.MaxValue,
				138,
				51,
				18,
				175,
				138
			};
			string result;
			try
			{
				PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, new byte[]
				{
					32,
					79
				});
				byte[] bytes = passwordDeriveBytes.GetBytes(8);
				byte[] bytes2 = Encoding.UTF8.GetBytes(strText);
				RC2CryptoServiceProvider rc2CryptoServiceProvider = new RC2CryptoServiceProvider();
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, rc2CryptoServiceProvider.CreateEncryptor(bytes, rgbIV), CryptoStreamMode.Write);
				cryptoStream.Write(bytes2, 0, bytes2.Length);
				cryptoStream.Close();
				result = Convert.ToBase64String(memoryStream.ToArray());
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00007240 File Offset: 0x00005440
		public static string Decrypt(string strText, string Password)
		{
			byte[] rgbIV = new byte[]
			{
				77,
				48,
				byte.MaxValue,
				138,
				51,
				18,
				175,
				138
			};
			byte[] array = new byte[strText.Length + 1];
			string result;
			try
			{
				PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(Password, new byte[]
				{
					32,
					79
				});
				byte[] bytes = passwordDeriveBytes.GetBytes(8);
				RC2CryptoServiceProvider rc2CryptoServiceProvider = new RC2CryptoServiceProvider();
				array = Convert.FromBase64String(strText);
				MemoryStream memoryStream = new MemoryStream();
				CryptoStream cryptoStream = new CryptoStream(memoryStream, rc2CryptoServiceProvider.CreateDecryptor(bytes, rgbIV), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.Close();
				Encoding utf = Encoding.UTF8;
				result = utf.GetString(memoryStream.ToArray());
			}
			catch (Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
	}
}
