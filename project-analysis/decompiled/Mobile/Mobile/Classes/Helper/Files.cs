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

public class Files
{
	public string GetFilePath(int fileDirId)
	{
		CRMEntities cRMEntities = null;
		string text = "";
		if (fileDirId != 0)
		{
			try
			{
				cRMEntities = new CRMEntities();
				MobspSelectCrmFilesDirectory_Result mobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<MobspSelectCrmFilesDirectory_Result>((IEnumerable<MobspSelectCrmFilesDirectory_Result>)cRMEntities.MobspSelectCrmFilesDirectory(fileDirId));
				if (mobspSelectCrmFilesDirectory_Result != null)
				{
					string text2 = mobspSelectCrmFilesDirectory_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text2 = ((!text2.Contains("/" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.UserDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.StockSupplyDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.StockSupplyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName) : (Configuration.MainDirectoryPath + Configuration.StockSupplyDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + Configuration.FilesDirectoryPath + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.UserDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.FundDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.DyDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + Configuration.FilesDirectoryPath + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.KnlgTDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath + mobspSelectCrmFilesDirectory_Result.FolderName + "/" + mobspSelectCrmFilesDirectory_Result.FileName));
					if (text2 != "")
					{
						FilesManager filesManager = new FilesManager();
						string text3 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
						if (filesManager.CreateDirectory(text3))
						{
							text = HttpContext.Current.Server.MapPath(text3 + "/" + mobspSelectCrmFilesDirectory_Result.FileName);
							string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
							string text4 = "";
							if (array != null)
							{
								text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + mobspSelectCrmFilesDirectory_Result.FileName) : "");
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
				cRMEntities?.Dispose();
			}
		}
		return text;
	}

	public string GetFilePath(string FilePath, string FileName, string FolderName, bool isNewsImage)
	{
		CRMEntities cRMEntities = null;
		string text = "";
		try
		{
			string text2 = FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
			text2 = ((!text2.Contains("/" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.CmsGalleryDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.CmsGalleryDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + FolderName + "/" + FileName) : ((!isNewsImage) ? (Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + FolderName + "/" + Configuration.FilesDirectoryPath + "/" + FileName) : (Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + FolderName + "/" + Configuration.PictureDirectoryPath + "/" + FileName))) : (Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath + FolderName + "/" + FileName)) : (Configuration.MainDirectoryPath + Configuration.KnlgTDirectoryPath + FolderName + "/" + FileName)) : (Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath + FolderName + "/" + FileName));
			if (text2 != "")
			{
				FilesManager filesManager = new FilesManager();
				string text3 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
				if (filesManager.CreateDirectory(text3))
				{
					text = HttpContext.Current.Server.MapPath(text3 + "/" + FileName);
					string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
					string text4 = "";
					if (array != null)
					{
						text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + FileName) : "");
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return text;
	}

	public string GetCoLogoMobAppPath(int currLangId, int defLangId)
	{
		CRMEntities cRMEntities = null;
		string result = "";
		try
		{
			cRMEntities = new CRMEntities();
			MobspSelectCrmsysSetting_Result mobspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<MobspSelectCrmsysSetting_Result>((IEnumerable<MobspSelectCrmsysSetting_Result>)cRMEntities.MobspSelectCrmsysSetting(currLangId, defLangId));
			if (mobspSelectCrmsysSetting_Result != null)
			{
				string coLogoMobAppPath = mobspSelectCrmsysSetting_Result.CoLogoMobAppPath;
				string coLogoMobAppPath2 = mobspSelectCrmsysSetting_Result.CoLogoMobAppPath;
				coLogoMobAppPath2 = coLogoMobAppPath2.Replace(Configuration.MainDirectoryPath, "/");
				string text = coLogoMobAppPath2;
				coLogoMobAppPath2 = "~" + coLogoMobAppPath2;
				string path = HttpContext.Current.Server.MapPath(coLogoMobAppPath2);
				string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
				string text2 = "";
				if (array != null)
				{
					text2 = ((array[0] != null && array[0] != "") ? (array[0] + text) : "");
				}
				result = (File.Exists(path) ? text2 : ((!DownlaodFile(coLogoMobAppPath, coLogoMobAppPath2)) ? "" : text2));
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
