using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using CRM.General.IO.FTP;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class HrmFiles
{
	public string GetFilePath(int fileDirId)
	{
		CRMSpEntities cRMSpEntities = null;
		string text = "";
		if (fileDirId != 0)
		{
			try
			{
				cRMSpEntities = new CRMSpEntities();
				HRMMobspSelectCrmFilesDirectory_Result hRMMobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<HRMMobspSelectCrmFilesDirectory_Result>((IEnumerable<HRMMobspSelectCrmFilesDirectory_Result>)cRMSpEntities.HRMMobspSelectCrmFilesDirectory(fileDirId));
				if (hRMMobspSelectCrmFilesDirectory_Result != null)
				{
					string text2 = hRMMobspSelectCrmFilesDirectory_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text2 = ((!text2.Contains("/" + Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + hRMMobspSelectCrmFilesDirectory_Result.FolderName + "/" + hRMMobspSelectCrmFilesDirectory_Result.FileName) : (Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath + hRMMobspSelectCrmFilesDirectory_Result.FolderName + "/" + hRMMobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.UserDirectoryPath + hRMMobspSelectCrmFilesDirectory_Result.FolderName + "/" + hRMMobspSelectCrmFilesDirectory_Result.FileName));
					if (text2 != "")
					{
						FilesManager filesManager = new FilesManager();
						string text3 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
						if (filesManager.CreateDirectory(text3))
						{
							text = HttpContext.Current.Server.MapPath(text3 + "/" + hRMMobspSelectCrmFilesDirectory_Result.FileName);
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text4 = "";
							if (array != null)
							{
								text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + hRMMobspSelectCrmFilesDirectory_Result.FileName) : "");
							}
							if (!new FacadeFTP(Configuration.FacadeFtp).Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text, text2, overwrite: true, Configuration.UsePassiveFtp))
							{
								if (!string.IsNullOrEmpty(text))
								{
									text = HttpContext.Current.Server.MapPath(text3 + "/");
									if (Directory.Exists(text))
									{
										DirectoryInfo directoryInfo = new DirectoryInfo(text);
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
										if (Directory.Exists(text))
										{
											Directory.Delete(text);
										}
									}
								}
								text = "";
							}
							else
							{
								text = text4;
							}
						}
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = "";
			}
			finally
			{
				cRMSpEntities?.Dispose();
			}
		}
		return text;
	}

	public string GetCoLogoMobHRMAppPath(int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = null;
		string result = "";
		try
		{
			cRMEntities = new CRMEntities();
			HRMMobspSelectCrmsysSetting_Result hRMMobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<HRMMobspSelectCrmsysSetting_Result>((IEnumerable<HRMMobspSelectCrmsysSetting_Result>)cRMEntities.HRMMobspSelectCrmsysSetting(currLangId, defLangId));
			if (hRMMobspSelectCrmsysSetting_Result != null)
			{
				string coLogoMobHRMAppPath = hRMMobspSelectCrmsysSetting_Result.CoLogoMobHRMAppPath;
				string coLogoMobHRMAppPath2 = hRMMobspSelectCrmsysSetting_Result.CoLogoMobHRMAppPath;
				coLogoMobHRMAppPath2 = coLogoMobHRMAppPath2.Replace(Configuration.MainDirectoryPath, "/");
				string text = coLogoMobHRMAppPath2;
				coLogoMobHRMAppPath2 = "~" + coLogoMobHRMAppPath2;
				string path = HttpContext.Current.Server.MapPath(coLogoMobHRMAppPath2);
				string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
				string text2 = "";
				if (array != null)
				{
					text2 = ((array[0] != null && array[0] != "") ? (array[0] + text) : "");
				}
				result = (File.Exists(path) ? text2 : ((!DownlaodFile(coLogoMobHRMAppPath, coLogoMobHRMAppPath2)) ? "" : text2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static bool DownlaodFile(string sourceFile, string filePath)
	{
		bool result = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			if (!string.IsNullOrEmpty(sourceFile) && !string.IsNullOrEmpty(filePath))
			{
				string text = "";
				if (!string.IsNullOrEmpty(sourceFile))
				{
					string source = sourceFile.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					bool flag = false;
					string text2 = filePath;
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(new char[1] { '/' });
						text2 = "";
						if (Enumerable.Any<string>((IEnumerable<string>)array))
						{
							for (int i = 0; i < array.Length - 1; i++)
							{
								if (!string.IsNullOrEmpty(array[i]) && array[i].IndexOf(".", StringComparison.Ordinal) <= 0)
								{
									text2 = text2 + array[i] + "/";
								}
							}
						}
						flag = filesManager.CreateDirectory(text2);
					}
					if (flag)
					{
						bool flag2 = true;
						text = HttpContext.Current.Server.MapPath(filePath);
						if (!File.Exists(text))
						{
							flag2 = facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text, source, overwrite: true, usePassiveFtp);
						}
						result = flag2;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}
