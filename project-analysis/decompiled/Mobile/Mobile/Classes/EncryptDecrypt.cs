using System;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Mobile.Classes;

public static class EncryptDecrypt
{
	public static string Encrypting(string plainText)
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		byte[] bytes = Encoding.UTF8.GetBytes(plainText);
		new AppSettingsReader();
		string s = "I Develop An APPMOB";
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
		mD5CryptoServiceProvider.Clear();
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = key;
		tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
		tripleDESCryptoServiceProvider.IV = new byte[8];
		tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
		byte[] array = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		tripleDESCryptoServiceProvider.Clear();
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string Decrypting(string cipherText)
	{
		try
		{
			byte[] array = Convert.FromBase64String(cipherText);
			string s = "I Develop An APPMOB";
			MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
			byte[] key = mD5CryptoServiceProvider.ComputeHash(Encoding.UTF8.GetBytes(s));
			mD5CryptoServiceProvider.Clear();
			TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
			tripleDESCryptoServiceProvider.Key = key;
			tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
			tripleDESCryptoServiceProvider.IV = new byte[8];
			tripleDESCryptoServiceProvider.Padding = PaddingMode.PKCS7;
			byte[] bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
			tripleDESCryptoServiceProvider.Clear();
			return Encoding.UTF8.GetString(bytes);
		}
		catch (Exception)
		{
			return "Invalid";
		}
	}
}
