using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using CRM.Resources;
using Mobile.Classes.Helper;
using Newtonsoft.Json;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;

namespace Mobile.Classes;

public class Security
{
	private static readonly string _publicKey = "-----BEGIN PUBLIC KEY-----\r\nMIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAxnNRtlDMRQdtVV+FQZ14\r\nua2DFBIzK/SbgDJ8OFB/OiLBVkKQgR1UmLjNMpvzCA0Sxr9xSHVi9Gk/IVZa4xTA\r\nvcguOUIeelpayNKP0AfOvyR97amoY3NAptLg0LSgZOjlsx1+duRuu6XsMHMWQkDS\r\nrk3Fp82/RdzTSUl2WU5+ognnRgQCUbyOkY4KhyxcOTTVEosFPhVzALwHj9qQ+0GC\r\nEYTdiQx5L6abdz/DV0VwzRHESrOMp8uSJSWCWFLoSaA3hmYlIMVM7tU2scqe1f1z\r\ndlfxRQG958JLNNb/MfrMM2V2VyjUVSfvGeCiC5HUgQqJ77CJt6n8Zf/xNhDOIAcJ\r\nGQIDAQAB\r\n-----END PUBLIC KEY-----";

	private static readonly string _privateKey = "-----BEGIN RSA PRIVATE KEY-----\r\nMIIEpAIBAAKCAQEAxnNRtlDMRQdtVV+FQZ14ua2DFBIzK/SbgDJ8OFB/OiLBVkKQ\r\ngR1UmLjNMpvzCA0Sxr9xSHVi9Gk/IVZa4xTAvcguOUIeelpayNKP0AfOvyR97amo\r\nY3NAptLg0LSgZOjlsx1+duRuu6XsMHMWQkDSrk3Fp82/RdzTSUl2WU5+ognnRgQC\r\nUbyOkY4KhyxcOTTVEosFPhVzALwHj9qQ+0GCEYTdiQx5L6abdz/DV0VwzRHESrOM\r\np8uSJSWCWFLoSaA3hmYlIMVM7tU2scqe1f1zdlfxRQG958JLNNb/MfrMM2V2VyjU\r\nVSfvGeCiC5HUgQqJ77CJt6n8Zf/xNhDOIAcJGQIDAQABAoIBABLRKBDxTZBiD7Qf\r\nqZAHyxG4HSZP3EaxTylZub03pmJJ0Pev7VA0CsVGCKPHqJGKQ84d180DrHPGb83M\r\n1WaUA8g7BsvRGpJTDPar2I0X06FjAW0B2ecMLGr+srVRDnOWQQMgRQSOM0QoJUj2\r\nykgf9pomfIGlZbSaWsJ0bJXNQ2UNZl5/pfBtrpXZE0Sq5wJHNGgFQ6v44TV7WhJd\r\nj+MjiAaZA8cEqJ+VIe1Mt3QAZqP3hqsWxYjSf01UryEIqLMbnA++v6fkIzf1zloE\r\n61wrNOrzJkdHtX+Oy9hVSIbzJnLOZFFT0cbq1z0UwLTI4XPkPNmx5FnmjB7YPGaI\r\nIMsbzd0CgYEA+hthQiLPXA3uttfKrsvDG+HkPuuQvCcGASQe8Tgmz3fnSDZocIjc\r\n6OeYibV+IxpKBiDePVS6dUg8NiB4sHxovi1iOrL0AzQXCTt4iPNoUL1GdluzkFaa\r\nSQdu1NrXoV1TX6zKXC+/xntY1IsOeu/IwLxp0fJIjf+Gqokw4+mE2OcCgYEAyyBa\r\nPoc3hcQPAR9aeSaP16hUwglU5yqpqPNZQRCeLAQIBKp6MYZC6HPPqj+lwpB9dwzh\r\nCqBXR+UkkWoQA7Cp07mtVpdq4OgKfAFg+5kyirhGSLE2pdLTtpPSshihtHcrgnQ3\r\nI6wZuS3cH4i0ERJnEhhgrXsGqtwdX85gz9quzf8CgYA9ee9tHztTCEWuAdrbHlDG\r\nEL9Wy/ZWmUz7iNJmPoQjqPhboqwHRUzvnsW6y7bGkBaz7O5TqvjuDSRntZGU5++j\r\nF2q2vPgHtY0YAts85n+0oOGqBB5eEzt3SfFvNp+cFWGB+en/wOjls7oA/HFBvKDe\r\n5zEnnuNArBeA4Zn325WA7wKBgQCGrQCojIZnjkJUgDFAOi0M03K+4+kDC+pJNm9r\r\nEFWO4W1fiphR1a7u6Do7qs+AXMSS9lsO7Jhx9p90Olo72BoBYw5mZyZZz/+DkHZ4\r\n2m4EQ4F2GOkesNXmK8R6iJJOUOTsLZmRcT3s5VcZIU4iM41bFgajfvpAtohTSUYv\r\nCdL0iQKBgQCdTWfF8OTEcp+hYfcB4Uuj74hUZzg54SITAwaN0fBHZAaKK7quoUed\r\nPEWy7nBT7esJQqok/B5HT7aHPaY4X6yJh6mJJgfiszXOS1gnwtT3FR9lXz8RQZCE\r\naamHad9ak9+eLocyfOUR2ehxP56ZgxNr6vWyAK8jrKnQA9dTXKzK/Q==\r\n-----END RSA PRIVATE KEY-----";

	public string DecryptAesKey(string base64EncryptedKey)
	{
		byte[] array = Convert.FromBase64String(base64EncryptedKey);
		AsymmetricKeyParameter param;
		using (StringReader reader = new StringReader(_privateKey))
		{
			object obj = new PemReader(reader).ReadObject();
			param = ((!(obj is AsymmetricCipherKeyPair)) ? ((AsymmetricKeyParameter)obj) : ((AsymmetricCipherKeyPair)obj).Private);
		}
		OaepEncoding oaepEncoding = new OaepEncoding(new RsaBlindedEngine(), new Sha256Digest());
		oaepEncoding.Init(forEncryption: false, param);
		return Convert.ToBase64String(oaepEncoding.ProcessBlock(array, 0, array.Length));
	}

	public byte[] EncryptJson(object data, string aesKeyString)
	{
		byte[] key = Convert.FromBase64String(aesKeyString);
		string s = JsonConvert.SerializeObject(data);
		byte[] bytes = Encoding.UTF8.GetBytes(s);
		byte[] array = new byte[12];
		using (RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider())
		{
			rNGCryptoServiceProvider.GetBytes(array);
		}
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, array, null);
		gcmBlockCipher.Init(forEncryption: true, parameters);
		byte[] array2 = new byte[gcmBlockCipher.GetOutputSize(bytes.Length)];
		int num = gcmBlockCipher.ProcessBytes(bytes, 0, bytes.Length, array2, 0);
		num += gcmBlockCipher.DoFinal(array2, num);
		byte[] array3 = new byte[array.Length + num];
		Buffer.BlockCopy(array, 0, array3, 0, array.Length);
		Buffer.BlockCopy(array2, 0, array3, array.Length, num);
		return array3;
	}

	public string DecryptJson(string encryptedData, string aesKeyString)
	{
		byte[] key = Convert.FromBase64String(aesKeyString);
		byte[] array = Convert.FromBase64String(encryptedData);
		if (array.Length < 28)
		{
			Common.InsTextToElmah("Invalid encrypted data.");
			throw new FormatException(Messages.MobInvalidEncryptionData);
		}
		byte[] array2 = new byte[12];
		Buffer.BlockCopy(array, 0, array2, 0, 12);
		byte[] array3 = new byte[array.Length - 12];
		Buffer.BlockCopy(array, 12, array3, 0, array3.Length);
		GcmBlockCipher gcmBlockCipher = new GcmBlockCipher(new AesEngine());
		AeadParameters parameters = new AeadParameters(new KeyParameter(key), 128, array2, null);
		gcmBlockCipher.Init(forEncryption: false, parameters);
		byte[] array4 = new byte[gcmBlockCipher.GetOutputSize(array3.Length)];
		int num;
		try
		{
			num = gcmBlockCipher.ProcessBytes(array3, 0, array3.Length, array4, 0);
			num += gcmBlockCipher.DoFinal(array4, num);
		}
		catch (InvalidCipherTextException)
		{
			Common.InsTextToElmah("Unable to decrypt data. The AES key or encrypted data is invalid.");
			throw new CryptographicException(Messages.MobErrorOnDecryptData);
		}
		return Encoding.UTF8.GetString(array4, 0, num);
	}
}
