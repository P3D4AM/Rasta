using System;
using System.IO;
using System.Net;
using System.Text;

namespace CRM.General.IO.FTP;

public static class MyFTP
{
	public static bool CopyFile(string fileName, string FileToCopy, string userName, string password, string FtpAddress)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_002f: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FtpWebRequest val = (FtpWebRequest)WebRequest.Create(FtpAddress + fileName);
			((WebRequest)val).Method = "RETR";
			((WebRequest)val).Credentials = (ICredentials)new NetworkCredential(userName, password);
			Stream responseStream = ((WebResponse)(FtpWebResponse)((WebRequest)val).GetResponse()).GetResponseStream();
			Upload(FtpAddress + FileToCopy, ToByteArray(responseStream), userName, password);
			responseStream.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static byte[] ToByteArray(Stream stream)
	{
		MemoryStream memoryStream = new MemoryStream();
		byte[] array = new byte[4096];
		int count;
		while ((count = stream.Read(array, 0, array.Length)) > 0)
		{
			memoryStream.Write(array, 0, count);
		}
		return memoryStream.ToArray();
	}

	public static bool Upload(string FileName, byte[] Image, string FtpUsername, string FtpPassword)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0018: Expected O, but got Unknown
		//IL_0018: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			FtpWebRequest val = (FtpWebRequest)WebRequest.Create(FileName);
			((WebRequest)val).Credentials = (ICredentials)new NetworkCredential(FtpUsername, FtpPassword);
			((WebRequest)val).Method = "STOR";
			Stream requestStream = ((WebRequest)val).GetRequestStream();
			requestStream.Write(Image, 0, Image.Length);
			requestStream.Close();
			requestStream.Dispose();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public static void CopyFileToFTP(string fileName, string FileToCopy, string userName, string password, string FtpAddress)
	{
		//IL_000d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0012: Unknown result type (might be due to invalid IL or missing references)
		//IL_001d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0020: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected O, but got Unknown
		//IL_0048: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_006d: Unknown result type (might be due to invalid IL or missing references)
		FtpWebRequest val = (FtpWebRequest)WebRequest.Create(FtpAddress + fileName);
		((WebRequest)val).Method = "STOR";
		((WebRequest)val).Credentials = (ICredentials)new NetworkCredential(userName, password);
		StreamReader streamReader = new StreamReader(fileName);
		byte[] bytes = Encoding.UTF8.GetBytes(streamReader.ReadToEnd());
		streamReader.Close();
		((WebRequest)val).ContentLength = bytes.Length;
		Stream requestStream = ((WebRequest)val).GetRequestStream();
		requestStream.Write(bytes, 0, bytes.Length);
		requestStream.Close();
		((WebResponse)(FtpWebResponse)((WebRequest)val).GetResponse()).Close();
	}

	private static void UploadFileToFTP(string source)
	{
		//IL_001f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_0027: Unknown result type (might be due to invalid IL or missing references)
		//IL_0031: Expected O, but got Unknown
		//IL_0031: Unknown result type (might be due to invalid IL or missing references)
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_003f: Unknown result type (might be due to invalid IL or missing references)
		string text = "@ftpurl";
		string text2 = "@ftpusername";
		string text3 = "@ftppassword";
		try
		{
			Path.GetFileName(source);
			FtpWebRequest val = (FtpWebRequest)WebRequest.Create(text);
			((WebRequest)val).Credentials = (ICredentials)new NetworkCredential(text2, text3);
			val.KeepAlive = true;
			val.UseBinary = true;
			((WebRequest)val).Method = "STOR";
			FileStream fileStream = System.IO.File.OpenRead(source);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			Stream requestStream = ((WebRequest)val).GetRequestStream();
			requestStream.Write(array, 0, array.Length);
			requestStream.Close();
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
