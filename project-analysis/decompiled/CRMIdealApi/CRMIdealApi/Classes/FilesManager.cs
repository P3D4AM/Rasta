using System;
using System.Globalization;
using System.IO;
using System.Web;
using CRM.General.IO.FTP;

namespace CRMIdealApi.Classes;

public class FilesManager
{
	public string CrmDirectory
	{
		get
		{
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			if (!facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, "/", "CRM", Configuration.UsePassiveFtp))
			{
				return "";
			}
			return "CRM";
		}
	}

	public string FilesDirectory
	{
		get
		{
			string destination = "/" + CrmDirectory + "/";
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			if (!facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, destination, "Files", Configuration.UsePassiveFtp))
			{
				return "";
			}
			return "Files";
		}
	}

	public string DoNotChangeDirectory
	{
		get
		{
			string destination = "/" + CrmDirectory + "/" + FilesDirectory + "/";
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			if (!facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, destination, "DoNotChange", Configuration.UsePassiveFtp))
			{
				return "";
			}
			return "DoNotChange";
		}
	}

	public bool DeleteDirectory(string nameDirectory)
	{
		try
		{
			string path = HttpContext.Current.Server.MapPath(nameDirectory);
			if (Directory.Exists(path))
			{
				string[] files = Directory.GetFiles(path);
				foreach (string path2 in files)
				{
					File.Delete(path2);
				}
				string[] directories = Directory.GetDirectories(path);
				foreach (string nameDirectory2 in directories)
				{
					DeleteDirectory(nameDirectory2);
				}
				Directory.Delete(path);
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool CreateDirectory(string dirName)
	{
		try
		{
			if (!Directory.Exists(HttpContext.Current.Server.MapPath(dirName)))
			{
				Directory.CreateDirectory(HttpContext.Current.Server.MapPath(dirName));
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public string SetNameDirectory(string date)
	{
		Random random = new Random();
		int num = random.Next(1, 100000);
		string path = HttpContext.Current.Server.MapPath("/Download/" + date + "/");
		if (Directory.Exists(path))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.Delete();
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string[] array = directoryInfo2.Name.Split(new char[1] { '-' });
				if (array != null && array[0] != null && array[0] != "")
				{
					string s = array[0].Substring(0, 8);
					if (int.Parse(s) < int.Parse(DateTime.Now.ToString("yyyyMMdd")))
					{
						directoryInfo2.Delete(recursive: true);
					}
				}
			}
		}
		return "/Download/" + date + "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + num + "-" + date;
	}

	public string SetNameDirectory(int userId)
	{
		Random random = new Random();
		int num = random.Next(1, 100000);
		string path = HttpContext.Current.Server.MapPath("/Download/" + userId + "/");
		if (Directory.Exists(path))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles();
			foreach (FileInfo fileInfo in files)
			{
				fileInfo.Delete();
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string[] array = directoryInfo2.Name.Split(new char[1] { '-' });
				if (array != null && array[0] != null && array[0] != "")
				{
					string s = array[0].Substring(0, 8);
					if (int.Parse(s) < int.Parse(DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US"))))
					{
						directoryInfo2.Delete(recursive: true);
					}
				}
			}
		}
		return "/Download/" + userId + "/" + DateTime.Now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "-" + num + "-" + userId;
	}
}
