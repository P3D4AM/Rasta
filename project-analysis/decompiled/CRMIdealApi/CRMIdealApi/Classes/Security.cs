using System;
using System.Security.Cryptography;
using System.Text;

namespace CRMIdealApi.Classes;

public class Security
{
	private ICryptoTransform rijndaelDecryptor;

	private byte[] rawSecretKey = new byte[16];

	public Security(string passphrase)
	{
		byte[] rgbKey = encodeDigest(passphrase);
		RijndaelManaged rijndaelManaged = new RijndaelManaged();
		rijndaelDecryptor = rijndaelManaged.CreateDecryptor(rgbKey, rawSecretKey);
	}

	public string Decrypt(byte[] encryptedData)
	{
		byte[] bytes = rijndaelDecryptor.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
		return Encoding.ASCII.GetString(bytes);
	}

	public string DecryptFromBase64(string encryptedBase64)
	{
		return Decrypt(Convert.FromBase64String(encryptedBase64));
	}

	private byte[] encodeDigest(string text)
	{
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		byte[] bytes = Encoding.ASCII.GetBytes(text);
		return mD5CryptoServiceProvider.ComputeHash(bytes);
	}

	public static string Codding(string GetString)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		string s = "I Love GOD";
		byte[] bytes = Encoding.ASCII.GetBytes(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(s));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] array = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string Codding(string GetString, string Key)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		byte[] bytes = Encoding.ASCII.GetBytes(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(Key));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] array = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string DeCodding(string GetString)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		string s = "I Love GOD";
		GetString = GetString.Replace(" ", "+");
		byte[] array = Convert.FromBase64String(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(s));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
		return Encoding.ASCII.GetString(bytes);
	}

	public static string DeCodding(string GetString, string Key)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		GetString = GetString.Replace(" ", "+");
		byte[] array = Convert.FromBase64String(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(Key));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
		return Encoding.ASCII.GetString(bytes);
	}

	public static string computeMD5Hash(string GetString)
	{
		byte[] array = new byte[16];
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		array = mD5CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(GetString));
		return Convert.ToBase64String(array);
	}

	public static string computeSHA1Hasher(string GetString)
	{
		byte[] array = new byte[16];
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		SHA1CryptoServiceProvider sHA1CryptoServiceProvider = new SHA1CryptoServiceProvider();
		array = sHA1CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(GetString));
		return Convert.ToBase64String(array);
	}

	public static string ComputeSHA256Hasher(string GetString)
	{
		byte[] array = new byte[16];
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		SHA256CryptoServiceProvider sHA256CryptoServiceProvider = new SHA256CryptoServiceProvider();
		array = sHA256CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(GetString));
		return Convert.ToBase64String(array);
	}

	public static string ComputeSHA384Hasher(string GetString)
	{
		byte[] array = new byte[16];
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		SHA384CryptoServiceProvider sHA384CryptoServiceProvider = new SHA384CryptoServiceProvider();
		array = sHA384CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(GetString));
		return Convert.ToBase64String(array);
	}

	public static string ComputeSHA512Hasher(string GetString)
	{
		byte[] array = new byte[16];
		UTF8Encoding uTF8Encoding = new UTF8Encoding();
		SHA512CryptoServiceProvider sHA512CryptoServiceProvider = new SHA512CryptoServiceProvider();
		array = sHA512CryptoServiceProvider.ComputeHash(uTF8Encoding.GetBytes(GetString));
		return Convert.ToBase64String(array);
	}

	public static string CoddingUTF8(string GetString)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		string s = "I Love GOD";
		byte[] bytes = Encoding.UTF8.GetBytes(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(s));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] array = tripleDESCryptoServiceProvider.CreateEncryptor().TransformFinalBlock(bytes, 0, bytes.Length);
		return Convert.ToBase64String(array, 0, array.Length);
	}

	public static string DeCoddingUTF8(string GetString)
	{
		byte[] iV = new byte[8] { 240, 32, 45, 29, 0, 76, 173, 59 };
		string s = "I Love GOD";
		GetString = GetString.Replace(" ", "+");
		byte[] array = Convert.FromBase64String(GetString);
		TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider();
		MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
		tripleDESCryptoServiceProvider.Key = mD5CryptoServiceProvider.ComputeHash(Encoding.ASCII.GetBytes(s));
		tripleDESCryptoServiceProvider.IV = iV;
		byte[] bytes = tripleDESCryptoServiceProvider.CreateDecryptor().TransformFinalBlock(array, 0, array.Length);
		return Encoding.UTF8.GetString(bytes);
	}
}
