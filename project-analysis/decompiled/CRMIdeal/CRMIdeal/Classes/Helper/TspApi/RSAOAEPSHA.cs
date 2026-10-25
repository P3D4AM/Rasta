using System;
using System.Security.Cryptography;
using System.Text;
using Elmah;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace CRMIdeal.Classes.Helper.TspApi;

public class RSAOAEPSHA
{
	public static string EncryptData(string stringToBeEncrypted, string publicKey)
	{
		try
		{
			RsaKeyParameters rsaKeyParameters = (RsaKeyParameters)PublicKeyFactory.CreateKey(Convert.FromBase64String(publicKey));
			RSAParameters parameters = default(RSAParameters);
			parameters.Modulus = rsaKeyParameters.Modulus.ToByteArrayUnsigned();
			parameters.Exponent = rsaKeyParameters.Exponent.ToByteArrayUnsigned();
			RSACng rSACng = new RSACng();
			rSACng.ImportParameters(parameters);
			string text = Convert.ToBase64String(rSACng.Encrypt(Encoding.UTF8.GetBytes(stringToBeEncrypted), RSAEncryptionPadding.OaepSHA256));
			if (text.Length % 4 == 3)
			{
				text += "=";
			}
			else if (text.Length % 4 == 2)
			{
				text += "==";
			}
			return text;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "error";
		}
	}
}
