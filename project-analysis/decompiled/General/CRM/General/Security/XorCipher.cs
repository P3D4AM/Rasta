using System;
using System.Text;

namespace CRM.General.Security;

public class XorCipher
{
	private static readonly string _privateKey = "wN.N^vDr`bpxy==/K}k/6o2H<^4";

	private static readonly string _publicKey = ")w+TYUBq$52!Cj%8X,*YxQ@%UGW}5i";

	private static readonly string _linkAccKey = "(:u.{ui1B2tq#}x.PrIMYli;E?|s6BG)";

	public static string PrivateKey => _privateKey;

	public static string PublicKey => _publicKey;

	public static string LinkAccKey => _linkAccKey;

	public static string EncryptByPrivateKey(string input)
	{
		input = input.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] bytes = unicodeEncoding.GetBytes(input);
		byte[] bytes2 = unicodeEncoding.GetBytes(_privateKey);
		byte[] array = new byte[bytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[i] = (byte)(bytes[i] ^ bytes2[i % bytes2.Length]);
		}
		return Convert.ToBase64String(array).Trim();
	}

	public static string DecryptByPrivateKey(string encryptedValue)
	{
		encryptedValue = encryptedValue.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] array = Convert.FromBase64String(encryptedValue);
		byte[] bytes = unicodeEncoding.GetBytes(_privateKey);
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (byte)(array[i] ^ bytes[i % bytes.Length]);
		}
		return unicodeEncoding.GetString(array2).Trim();
	}

	public static string EncryptByPublicKey(string input)
	{
		input = input.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] bytes = unicodeEncoding.GetBytes(input);
		byte[] bytes2 = unicodeEncoding.GetBytes(_publicKey);
		byte[] array = new byte[bytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[i] = (byte)(bytes[i] ^ bytes2[i % bytes2.Length]);
		}
		return Convert.ToBase64String(array).Trim();
	}

	public static string DecryptByPublicKey(string encryptedValue)
	{
		encryptedValue = encryptedValue.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] array = Convert.FromBase64String(encryptedValue);
		byte[] bytes = unicodeEncoding.GetBytes(_publicKey);
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (byte)(array[i] ^ bytes[i % bytes.Length]);
		}
		return unicodeEncoding.GetString(array2).Trim();
	}

	public static string TryDecryptOrReturnOriginal(string input, string key = "")
	{
		if (string.IsNullOrEmpty(key))
		{
			key = _privateKey;
		}
		try
		{
			byte[] array = Convert.FromBase64String(input);
			byte[] bytes = Encoding.Unicode.GetBytes(_privateKey);
			for (int i = 0; i < array.Length; i++)
			{
				array[i] ^= bytes[i % bytes.Length];
			}
			return Encoding.Unicode.GetString(array);
		}
		catch
		{
			return input;
		}
	}

	public static string PreparePrivateKeyKeyForSql()
	{
		string text = "1,7Z";
		string s = "L8VC" + PrivateKey + text;
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
	}

	public static string PreparePublicKeyForSql()
	{
		string text = "1,7Z";
		string s = "L8VC" + PublicKey + text;
		return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
	}

	public static string EncryptByMode(string input, int mode)
	{
		input = input.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] bytes = unicodeEncoding.GetBytes(input);
		string s = "";
		if (mode == 1)
		{
			s = _linkAccKey;
		}
		byte[] bytes2 = unicodeEncoding.GetBytes(s);
		byte[] array = new byte[bytes.Length];
		for (int i = 0; i < bytes.Length; i++)
		{
			array[i] = (byte)(bytes[i] ^ bytes2[i % bytes2.Length]);
		}
		return Convert.ToBase64String(array).Trim();
	}

	public static string DecryptByMode(string encryptedValue, int mode)
	{
		encryptedValue = encryptedValue.Trim();
		UnicodeEncoding unicodeEncoding = new UnicodeEncoding(bigEndian: false, byteOrderMark: false);
		byte[] array = Convert.FromBase64String(encryptedValue);
		string s = "";
		if (mode == 1)
		{
			s = _linkAccKey;
		}
		byte[] bytes = unicodeEncoding.GetBytes(s);
		byte[] array2 = new byte[array.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array2[i] = (byte)(array[i] ^ bytes[i % bytes.Length]);
		}
		return unicodeEncoding.GetString(array2).Trim();
	}
}
