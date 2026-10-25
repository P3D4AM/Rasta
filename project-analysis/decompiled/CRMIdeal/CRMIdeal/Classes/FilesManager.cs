using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Hosting;
using CRM.General.IO.FTP;
using CRM.Resources;
using CRMIdeal.Classes.Common;

namespace CRMIdeal.Classes;

public class FilesManager
{
	public const int _MoveIndex_FtpPath = 0;

	public const int _MoveIndex_FuncStatus = 1;

	public const int _MoveIndex_ErrorMessage = 2;

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

	public bool DeleteDirectory(string nameDirectory, int mode = 0)
	{
		try
		{
			string path = ((mode == 0) ? HttpContext.Current.Server.MapPath(nameDirectory) : nameDirectory);
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
			if (!Directory.Exists(HostingEnvironment.MapPath(dirName)))
			{
				Directory.CreateDirectory(HostingEnvironment.MapPath(dirName));
			}
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool CreateDirectoryI(string dirName, HttpServerUtility server)
	{
		try
		{
			if (!Directory.Exists(server.MapPath(dirName)))
			{
				Directory.CreateDirectory(server.MapPath(dirName));
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
		return "/Download/" + DateTime.Now.ToString("yyyyMMdd-HHmmss") + "-" + num + "-" + userId;
	}

	public static List<dynamic> MoveFile(string fromFolder, string fromFileName, string toFolder, string toFileName, HttpServerUtility server)
	{
		List<object> list = new List<object>();
		list.Add("");
		list.Add(false);
		list.Add("");
		string text = "";
		string text2 = "";
		string text3 = Guid.NewGuid().ToString().Replace("-", "");
		try
		{
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			string mainDirectoryPath = Configuration.MainDirectoryPath;
			string text4 = Path.Combine(mainDirectoryPath, fromFolder, fromFileName).Replace("\\", "/");
			string text5 = Path.Combine(mainDirectoryPath, toFolder, toFileName).Replace("\\", "/");
			text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
			filesManager.CreateDirectoryI(text2, server);
			text2 = server.MapPath(text2);
			bool flag = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text2 + "\\" + text3, text4, overwrite: true, usePassiveFtp);
			if (!flag)
			{
				text = text + "|" + Messages.frmErrorInSendingFile;
			}
			else if (flag)
			{
				bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, toFolder, usePassiveFtp);
				if (!flag2)
				{
					flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, toFolder, usePassiveFtp);
				}
				if (flag2)
				{
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text5, text2 + "\\" + text3, usePassiveFtp))
					{
						if (facadeFTP.Delete(pathFtp, userNameFtp, passwordFtp, text4, text4, usePassiveFtp))
						{
							list[0] = text5;
							list[1] = true;
						}
					}
					else
					{
						Public.InsTextToElmah(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text5 + " ,directoryName: " + toFolder);
						text = text + "|" + Messages.frmErrorInSendingFile;
					}
				}
				else
				{
					Public.InsTextToElmah(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text5 + " ,directoryName: " + toFolder);
					text = text + "|" + Messages.frmErrorInSendingFile;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		list[2] = text;
		if (!string.IsNullOrWhiteSpace(text2))
		{
			try
			{
				if (Directory.Exists(text2))
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
					FileInfo[] files = directoryInfo.GetFiles();
					for (int i = 0; i < files.Length; i++)
					{
						files[i].Delete();
					}
					DirectoryInfo[] directories = directoryInfo.GetDirectories();
					for (int i = 0; i < directories.Length; i++)
					{
						directories[i].Delete(recursive: true);
					}
					if (Directory.Exists(text2))
					{
						Directory.Delete(text2);
					}
				}
			}
			catch (Exception ex2)
			{
				Public.InsExceptToElmah(ex2);
			}
		}
		return list;
	}
}
