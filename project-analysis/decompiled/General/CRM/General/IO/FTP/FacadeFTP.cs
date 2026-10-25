using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Hosting;

namespace CRM.General.IO.FTP;

public class FacadeFTP
{
	private static string _facadeType = "";

	public FacadeFTP(string facadeType)
	{
		_facadeType = facadeType;
	}

	public bool Upload(string hostname, string username, string password, string destination, HttpPostedFileBase postedFile, bool usePassive)
	{
		bool result = false;
		try
		{
			if (postedFile != null)
			{
				string facadeType = _facadeType;
				result = ((facadeType == "ftp") ? new FTPclient(hostname, username, password, usePassive).Upload(postedFile.InputStream, destination) : ((!(facadeType == "windows")) ? CopyFile(hostname, username, password, destination, postedFile) : CopyFile(hostname, username, password, destination, postedFile)));
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private bool CopyFile(string hostname, string username, string password, string destination, HttpPostedFileBase postedFile)
	{
		bool result = true;
		try
		{
			Match val = Regex.Match(hostname, "\\d+.\\d+.\\d+.\\d+");
			if (MyPing(((Capture)val).Value))
			{
				if (LoginToNetwork.Impersonate(hostname + destination, username, password))
				{
					string text = hostname + destination;
					if (System.IO.File.Exists(text))
					{
						FileAttributes fileAttributes = FileAttributes.None;
						fileAttributes = System.IO.File.GetAttributes(text);
						if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly || (fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden)
						{
							System.IO.File.SetAttributes(text, FileAttributes.Normal);
						}
					}
					postedFile.SaveAs(text);
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private bool MyPing(string IP)
	{
		//IL_000a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Expected O, but got Unknown
		//IL_0028: Unknown result type (might be due to invalid IL or missing references)
		//IL_0050: Unknown result type (might be due to invalid IL or missing references)
		//IL_0055: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		bool result = true;
		int num = 0;
		try
		{
			Ping val = new Ping();
			int num2 = 3;
			for (int i = 0; i < 4; i++)
			{
				PingReply val2 = val.Send(IP, 2000);
				if ((int)val2.Status != 0)
				{
					num++;
					if (text == null || text == "")
					{
						IPStatus status = val2.Status;
						text = "** Error: Ping Fail " + IP + " . Last Error: " + ((object)(IPStatus)(ref status)).ToString();
					}
				}
			}
			if (num > num2)
			{
				result = false;
			}
		}
		catch (Exception ex)
		{
			text = "** Error: Ping Fail " + IP + " . Last Error: " + ex.Message;
			result = false;
		}
		return result;
	}

	public bool Download(string hostname, string username, string password, string destination, string source, bool overwrite, bool usePassive)
	{
		bool flag = false;
		try
		{
			string facadeType = _facadeType;
			if (!(facadeType == "ftp"))
			{
				if (facadeType == "windows")
				{
					return CopyFile(hostname, username, password, destination, source, overwrite);
				}
				return CopyFile(hostname, username, password, destination, source, overwrite);
			}
			return new FTPclient(hostname, username, password, usePassive).Download(source, destination, overwrite);
		}
		catch
		{
			return false;
		}
	}

	private bool CopyFile(string hostname, string username, string password, string destination, string source, bool overwrite)
	{
		bool result = true;
		try
		{
			Match val = Regex.Match(hostname, "\\d+.\\d+.\\d+.\\d+");
			if (MyPing(((Capture)val).Value))
			{
				if (LoginToNetwork.Impersonate(hostname + source, username, password))
				{
					if (System.IO.File.Exists(destination))
					{
						FileAttributes fileAttributes = FileAttributes.None;
						fileAttributes = System.IO.File.GetAttributes(destination);
						if ((fileAttributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly || (fileAttributes & FileAttributes.Hidden) == FileAttributes.Hidden)
						{
							System.IO.File.SetAttributes(destination, FileAttributes.Normal);
						}
					}
					System.IO.File.Copy(source, destination, overwrite);
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public bool Delete(string hostname, string username, string password, string filename, string destination, bool usePassive)
	{
		bool result = false;
		try
		{
			if (filename != null)
			{
				string facadeType = _facadeType;
				result = ((facadeType == "ftp") ? new FTPclient(hostname, username, password, usePassive).FtpDelete(destination) : ((!(facadeType == "windows")) ? DeleteFile(hostname, username, password, destination) : DeleteFile(hostname, username, password, destination)));
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	private bool DeleteFile(string hostname, string username, string password, string destination)
	{
		bool result = true;
		try
		{
			Match val = Regex.Match(hostname, "\\d+.\\d+.\\d+.\\d+");
			if (MyPing(((Capture)val).Value))
			{
				if (LoginToNetwork.Impersonate(hostname + destination, username, password))
				{
					string text = hostname + destination;
					if (System.IO.File.Exists(text))
					{
						System.IO.File.Delete(HostingEnvironment.MapPath(text));
					}
				}
				else
				{
					result = false;
				}
			}
			else
			{
				result = false;
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public bool CreateDirectoryInFtp(string hostname, string username, string password, string destination, string directoryName, bool usePassive)
	{
		string text = hostname + destination + directoryName;
		bool flag = false;
		try
		{
			string facadeType = _facadeType;
			if (!(facadeType == "ftp"))
			{
				if (facadeType == "windows")
				{
					Match val = Regex.Match(hostname, "\\d+.\\d+.\\d+.\\d+");
					if (MyPing(((Capture)val).Value) && LoginToNetwork.Impersonate(hostname + destination, username, password))
					{
						if (!System.IO.Directory.Exists(text))
						{
							System.IO.Directory.CreateDirectory(text);
							Directory.SetFullControlForEveryOne(text);
						}
						flag = true;
					}
				}
			}
			else
			{
				flag = new FTPclient(hostname, username, password, usePassive).FtpCreateDirectory(destination + directoryName);
			}
			if (flag)
			{
				try
				{
					FTPclient fTPclient = new FTPclient(hostname, username, password, usePassive);
					string text2 = HostingEnvironment.MapPath("/blank.png");
					if (!string.IsNullOrEmpty(text2))
					{
						fTPclient.Upload(text2, destination + directoryName + "/blank.png");
					}
				}
				catch
				{
				}
			}
		}
		catch
		{
			flag = false;
		}
		return flag;
	}

	public bool ExistsDirectoryInFtp(string hostname, string username, string password, string destination, string directoryName, bool usePassive)
	{
		string text = hostname + destination + directoryName;
		bool result = false;
		try
		{
			string facadeType = _facadeType;
			if (!(facadeType == "ftp"))
			{
				if (facadeType == "windows")
				{
					Match val = Regex.Match(hostname, "\\d+.\\d+.\\d+.\\d+");
					if (MyPing(((Capture)val).Value) && LoginToNetwork.Impersonate(hostname + destination, username, password))
					{
						if (!System.IO.Directory.Exists(text))
						{
							System.IO.Directory.CreateDirectory(text);
							Directory.SetFullControlForEveryOne(text);
						}
						result = true;
					}
				}
			}
			else
			{
				result = new FTPclient(hostname, username, password, usePassive).FtpDirectoryExists(destination + directoryName);
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public bool UploadFtpFormTable(string hostname, string username, string password, string destination, string source, bool usePassive)
	{
		bool result = false;
		try
		{
			if (source != null)
			{
				string facadeType = _facadeType;
				result = ((facadeType == "ftp") ? new FTPclient(hostname, username, password, usePassive).Upload(source, destination) : ((!(facadeType == "windows")) ? CopyFile(hostname, username, password, destination, source, overwrite: true) : CopyFile(hostname, username, password, destination, source, overwrite: true)));
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}

	public bool RenameCopyInFtp(string hostname, string username, string password, string destination, string source, bool usePassive)
	{
		bool flag = false;
		try
		{
			return new FTPclient(hostname, username, password, usePassive).FtpRename(source, destination);
		}
		catch
		{
			return false;
		}
	}

	public bool DownloadFtpContents(string hostname, string username, string password, bool usePassive, bool overwrite, string destination)
	{
		bool result = false;
		try
		{
			_ = hostname + destination;
			string facadeType = _facadeType;
			if (!(facadeType == "ftp"))
			{
				if (facadeType == "windows")
				{
				}
			}
			else
			{
				FTPclient fTPclient = new FTPclient(hostname, username, password, usePassive);
				List<string> list = fTPclient.ListDirectory(destination);
				if (list != null)
				{
					foreach (string item in list)
					{
						if (string.IsNullOrEmpty(item))
						{
							continue;
						}
						string text = HostingEnvironment.MapPath(destination + "\\" + item);
						if (fTPclient.FtpFileExists(destination + "\\" + item))
						{
							if (!System.IO.File.Exists(text))
							{
								Download(hostname, username, password, text, destination + "\\" + item, overwrite: true, usePassive);
							}
							continue;
						}
						if (!System.IO.Directory.Exists(text))
						{
							System.IO.Directory.CreateDirectory(text);
							Directory.SetFullControlForEveryOne(text);
						}
						if (System.IO.Directory.Exists(text))
						{
							DownloadFtpContents(hostname, username, password, usePassive, overwrite: true, destination + "\\" + item);
						}
					}
				}
				result = true;
			}
		}
		catch (Exception)
		{
			result = false;
		}
		return result;
	}

	public bool UploadFtpAllContents(string hostname, string username, string password, string destination, string source, bool usePassive)
	{
		bool result = false;
		try
		{
			if (source != null)
			{
				string facadeType = _facadeType;
				if (!(facadeType == "ftp"))
				{
					if (facadeType == "windows")
					{
					}
				}
				else
				{
					FTPclient fTPclient = new FTPclient(hostname, username, password, usePassive);
					string text = HostingEnvironment.MapPath(source);
					string[] directories = System.IO.Directory.GetDirectories(text);
					if (directories != null)
					{
						string[] array = directories;
						foreach (string text2 in array)
						{
							if (string.IsNullOrEmpty(text2))
							{
								continue;
							}
							string text3 = text2.Replace("\\", "\\");
							text3 = text3.Replace(text + "\\", "");
							if (!string.IsNullOrEmpty(text3))
							{
								bool flag = ExistsDirectoryInFtp(hostname, username, password, destination + "/", text3, usePassive);
								if (!flag)
								{
									flag = CreateDirectoryInFtp(hostname, username, password, destination + "/", text3, usePassive);
								}
								if (flag)
								{
									bool usePassive2 = usePassive;
									UploadFtpAllContents(hostname, username, password, destination + "/" + text3, source + "/" + text3, usePassive2);
								}
							}
						}
					}
					string[] files = System.IO.Directory.GetFiles(text);
					if (files != null)
					{
						string[] array = files;
						foreach (string text4 in array)
						{
							if (!string.IsNullOrEmpty(text4))
							{
								string text5 = text4.Replace("\\", "\\");
								text5 = text5.Replace(text + "\\", "");
								if (!string.IsNullOrEmpty(text5) && !fTPclient.FtpFileExists(destination + "\\" + text4))
								{
									string localFilename = HostingEnvironment.MapPath(source + "/" + text5);
									fTPclient.Upload(localFilename, destination + "/" + text5);
								}
							}
						}
					}
					result = true;
				}
			}
		}
		catch
		{
			result = false;
		}
		return result;
	}
}
