using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;

namespace CRM.General.IO;

public class MyFTP
{
	private string host = "";

	private string user = "";

	private string pass = "";

	private FtpWebRequest ftpRequest;

	private FtpWebResponse ftpResponse;

	private Stream ftpStream;

	private int bufferSize = 2048;

	public MyFTP(string hostIP, string userName, string password)
	{
		host = hostIP;
		user = userName;
		pass = password;
	}

	public void download(string remoteFile, string localFile)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + remoteFile);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "RETR";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			ftpStream = ((WebResponse)ftpResponse).GetResponseStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Create);
			byte[] buffer = new byte[bufferSize];
			int num = ftpStream.Read(buffer, 0, bufferSize);
			try
			{
				while (num > 0)
				{
					fileStream.Write(buffer, 0, num);
					num = ftpStream.Read(buffer, 0, bufferSize);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			fileStream.Close();
			ftpStream.Close();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
	}

	public void upload(string remoteFile, string localFile)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + remoteFile);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "STOR";
			ftpStream = ((WebRequest)ftpRequest).GetRequestStream();
			FileStream fileStream = new FileStream(localFile, FileMode.Create);
			byte[] buffer = new byte[bufferSize];
			int num = fileStream.Read(buffer, 0, bufferSize);
			try
			{
				while (num != 0)
				{
					ftpStream.Write(buffer, 0, num);
					num = fileStream.Read(buffer, 0, bufferSize);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			fileStream.Close();
			ftpStream.Close();
			ftpRequest = null;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
	}

	public void delete(string deleteFile)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + deleteFile);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "DELE";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public void rename(string currentFileNameAndPath, string newFileName)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_0089: Unknown result type (might be due to invalid IL or missing references)
		//IL_0093: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + currentFileNameAndPath);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "RENAME";
			ftpRequest.RenameTo = newFileName;
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public void createDirectory(string newDirectory)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + newDirectory);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "MKD";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
		}
		catch (Exception ex)
		{
			Console.WriteLine(ex.ToString());
		}
	}

	public string getFileCreatedDateTime(string fileName)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + fileName);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "MDTM";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			ftpStream = ((WebResponse)ftpResponse).GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string result = null;
			try
			{
				result = streamReader.ReadToEnd();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
			return result;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
		return "";
	}

	public string getFileSize(string fileName)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + fileName);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "SIZE";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			ftpStream = ((WebResponse)ftpResponse).GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string result = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					result = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
			return result;
		}
		catch (Exception ex2)
		{
			Console.WriteLine(ex2.ToString());
		}
		return "";
	}

	public string[] directoryListSimple(string directory)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "NLST";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			ftpStream = ((WebResponse)ftpResponse).GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					text = text + streamReader.ReadLine() + "|";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
			try
			{
				return text.Split("|".ToCharArray());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.ToString());
		}
		return new string[1] { "" };
	}

	public string[] directoryListDetailed(string directory)
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_003d: Expected O, but got Unknown
		//IL_007d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0087: Expected O, but got Unknown
		try
		{
			ftpRequest = (FtpWebRequest)WebRequest.Create(host + "/" + directory);
			((WebRequest)ftpRequest).Credentials = (ICredentials)new NetworkCredential(user, pass);
			ftpRequest.UseBinary = true;
			ftpRequest.UsePassive = true;
			ftpRequest.KeepAlive = true;
			((WebRequest)ftpRequest).Method = "LIST";
			ftpResponse = (FtpWebResponse)((WebRequest)ftpRequest).GetResponse();
			ftpStream = ((WebResponse)ftpResponse).GetResponseStream();
			StreamReader streamReader = new StreamReader(ftpStream);
			string text = null;
			try
			{
				while (streamReader.Peek() != -1)
				{
					text = text + streamReader.ReadLine() + "|";
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
			streamReader.Close();
			ftpStream.Close();
			((WebResponse)ftpResponse).Close();
			ftpRequest = null;
			try
			{
				return text.Split("|".ToCharArray());
			}
			catch (Exception ex2)
			{
				Console.WriteLine(ex2.ToString());
			}
		}
		catch (Exception ex3)
		{
			Console.WriteLine(ex3.ToString());
		}
		return new string[1] { "" };
	}

	private void sample()
	{
		MyFTP myFTP = new MyFTP("ftp://10.10.10.10/", "user", "password");
		myFTP.upload("etc/test.txt", "C:\\Users\\metastruct\\Desktop\\test.txt");
		myFTP.download("etc/test.txt", "C:\\Users\\metastruct\\Desktop\\test.txt");
		myFTP.delete("etc/test.txt");
		myFTP.rename("etc/test.txt", "test2.txt");
		myFTP.createDirectory("etc/test");
		Console.WriteLine(myFTP.getFileCreatedDateTime("etc/test.txt"));
		Console.WriteLine(myFTP.getFileSize("etc/test.txt"));
		string[] array = myFTP.directoryListDetailed("/etc");
		for (int i = 0; i < Enumerable.Count<string>((IEnumerable<string>)array); i++)
		{
			Console.WriteLine(array[i]);
		}
		string[] array2 = myFTP.directoryListDetailed("/etc");
		for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)array2); j++)
		{
			Console.WriteLine(array2[j]);
		}
		myFTP = null;
	}
}
