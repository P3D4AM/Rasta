using System.Security.Cryptography;
using System.Text;

namespace CRMIdealApi.Classes.Helper;

public class BaseInfo
{
	public static string ConverSHA256(string value)
	{
		StringBuilder stringBuilder = new StringBuilder();
		if (!string.IsNullOrWhiteSpace(value))
		{
			using SHA256 sHA = SHA256.Create();
			Encoding uTF = Encoding.UTF8;
			byte[] array = sHA.ComputeHash(uTF.GetBytes(value));
			byte[] array2 = array;
			foreach (byte b in array2)
			{
				stringBuilder.Append(b.ToString("x2"));
			}
		}
		return stringBuilder.ToString();
	}
}
