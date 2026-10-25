using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.OpenSsl;
using Org.BouncyCastle.Security;

namespace CRMIdeal.Classes.Helper.TspApi;

public class SigntureData
{
	public static string SignData(string stringToBeSigned, string privateKey)
	{
		RSAParameters parameters = DotNetUtilities.ToRSAParameters((RsaPrivateCrtKeyParameters)(AsymmetricKeyParameter)new PemReader(new StringReader("-----BEGIN PRIVATE KEY-----\n" + privateKey + "\n-----END PRIVATE KEY-----")).ReadObject());
		RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
		rSACryptoServiceProvider.ImportParameters(parameters);
		byte[] bytes = Encoding.UTF8.GetBytes(stringToBeSigned);
		return Convert.ToBase64String(rSACryptoServiceProvider.SignData(bytes, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1));
	}
}
