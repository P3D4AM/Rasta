using System;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;

namespace CRMIdeal.Classes.Helper.TspApi;

public class AES_GCM
{
	public static string AesEncrypt(byte[] payload, byte[] key, byte[] iv)
	{
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		gcmBlockCipher.Init(forEncryption: true, new AeadParameters(associatedText: new byte[0], key: new KeyParameter(key), macSize: 128, nonce: iv));
		byte[] array = new byte[gcmBlockCipher.GetOutputSize(payload.Length)];
		int outOff = gcmBlockCipher.ProcessBytes(payload, 0, payload.Length, array, 0);
		gcmBlockCipher.DoFinal(array, outOff);
		return Convert.ToBase64String(array);
	}

	public static byte[] Xor(byte[] left, byte[] right)
	{
		byte[] array = new byte[left.Length];
		for (int i = 0; i < left.Length; i++)
		{
			array[i] = (byte)(left[i] ^ right[i]);
		}
		return array;
	}

	public static byte[] CreateKey(int len)
	{
		RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
		byte[] array = new byte[len];
		rNGCryptoServiceProvider.GetBytes(array);
		for (int i = 0; i < array.Length; i++)
		{
			int num = array[i] & 0xFE;
			int num2 = 0;
			for (int num3 = num; num3 != 0; num3 >>= 1)
			{
				num2 ^= num3 & 1;
			}
			array[i] = (byte)((uint)num | ((num2 == 0) ? 1u : 0u));
		}
		return array;
	}

	public static string ByteArrayToString(byte[] ba)
	{
		StringBuilder stringBuilder = new StringBuilder(ba.Length * 2);
		foreach (byte b in ba)
		{
			stringBuilder.AppendFormat("{0:x2}", b);
		}
		return stringBuilder.ToString();
	}
}
