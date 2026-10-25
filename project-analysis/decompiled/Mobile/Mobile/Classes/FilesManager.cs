using System;
using System.Globalization;
using System.IO;
using System.Web;
using CRM.General.IO.FTP;

namespace Mobile.Classes;

public class FilesManager
{
	public string CrmDirectory
	{
		get
		{
			if (!new FacadeFTP(Configuration.FacadeFtp).CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, "/", "CRM", Configuration.UsePassiveFtp))
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
			if (!new FacadeFTP(Configuration.FacadeFtp).CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, destination, "Files", Configuration.UsePassiveFtp))
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
			if (!new FacadeFTP(Configuration.FacadeFtp).CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, destination, "DoNotChange", Configuration.UsePassiveFtp))
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
				for (int i = 0; i < files.Length; i++)
				{
					File.Delete(files[i]);
				}
				files = Directory.GetDirectories(path);
				foreach (string nameDirectory2 in files)
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

	public string SetNameDirectory(int userId)
	{
		int num = new Random().Next(1, 100000);
		string path = HttpContext.Current.Server.MapPath("/Download/" + userId + "/");
		if (Directory.Exists(path))
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				files[i].Delete();
			}
			DirectoryInfo[] directories = directoryInfo.GetDirectories();
			foreach (DirectoryInfo directoryInfo2 in directories)
			{
				string[] array = directoryInfo2.Name.Split(new char[1] { '-' });
				if (array != null && array[0] != null && array[0] != "" && int.Parse(array[0].Substring(0, 8)) < int.Parse(DateTime.Now.ToString("yyyyMMdd", new CultureInfo("en-US"))))
				{
					directoryInfo2.Delete(recursive: true);
				}
			}
		}
		return "/Download/" + userId + "/" + DateTime.Now.ToString("yyyyMMddHHmmss", new CultureInfo("en-US")) + "-" + num + "-" + userId;
	}
}
