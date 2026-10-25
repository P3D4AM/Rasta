using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using CRM.General.IO.FTP;
using CRMIdealApi.ApiModels;
using Elmah;

namespace CRMIdealApi.Classes;

public class Files
{
	public string GetFilePath(int fileDirId, int userId)
	{
		CRMEntities cRMEntities = null;
		string text = "";
		if (fileDirId != 0)
		{
			try
			{
				cRMEntities = new CRMEntities();
				ApispSelectCrmFilesDirectory_Result apispSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<ApispSelectCrmFilesDirectory_Result>((IEnumerable<ApispSelectCrmFilesDirectory_Result>)cRMEntities.ApispSelectCrmFilesDirectory(fileDirId));
				if (apispSelectCrmFilesDirectory_Result != null)
				{
					string text2 = apispSelectCrmFilesDirectory_Result.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
					text2 = ((!text2.Contains("/" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text2.Contains("/" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "/") && !text2.Contains("\\" + Configuration.CmsNewsDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + apispSelectCrmFilesDirectory_Result.FolderName + "/" + apispSelectCrmFilesDirectory_Result.FileName) : (Configuration.MainDirectoryPath + Configuration.CmsNewsDirectoryPath + apispSelectCrmFilesDirectory_Result.FolderName + "/" + Configuration.FilesDirectoryPath + "/" + apispSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.KnlgTDirectoryPath + apispSelectCrmFilesDirectory_Result.FolderName + "/" + apispSelectCrmFilesDirectory_Result.FileName)) : (Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath + apispSelectCrmFilesDirectory_Result.FolderName + "/" + apispSelectCrmFilesDirectory_Result.FileName));
					if (text2 != "")
					{
						FilesManager filesManager = new FilesManager();
						string text3 = filesManager.SetNameDirectory(userId);
						if (filesManager.CreateDirectory(text3))
						{
							text = HttpContext.Current.Server.MapPath(text3 + "/" + apispSelectCrmFilesDirectory_Result.FileName);
							string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
							string[] array = absoluteUri.Split(new string[1] { "/Api/" }, StringSplitOptions.None);
							string text4 = "";
							if (array != null)
							{
								text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + apispSelectCrmFilesDirectory_Result.FileName) : "");
							}
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							if (!facadeFTP.Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text, text2, overwrite: true, Configuration.UsePassiveFtp))
							{
								if (!string.IsNullOrEmpty(text))
								{
									text = HttpContext.Current.Server.MapPath(text3 + "/");
									if (Directory.Exists(text))
									{
										DirectoryInfo directoryInfo = new DirectoryInfo(text);
										FileInfo[] files = directoryInfo.GetFiles();
										foreach (FileInfo fileInfo in files)
										{
											fileInfo.Delete();
										}
										DirectoryInfo[] directories = directoryInfo.GetDirectories();
										foreach (DirectoryInfo directoryInfo2 in directories)
										{
											directoryInfo2.Delete(recursive: true);
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

	public string GetFilePath(string FilePath, string FileName, string FolderName, bool isNewsImage, int userId)
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
				string text3 = filesManager.SetNameDirectory(userId);
				if (filesManager.CreateDirectory(text3))
				{
					text = HttpContext.Current.Server.MapPath(text3 + "/" + FileName);
					string absoluteUri = HttpContext.Current.Request.Url.AbsoluteUri;
					string[] array = absoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
					string text4 = "";
					if (array != null)
					{
						text4 = ((array[0] != null && array[0] != "") ? (array[0] + text3 + "/" + FileName) : "");
					}
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					if (!facadeFTP.Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text, text2, overwrite: true, Configuration.UsePassiveFtp))
					{
						if (!string.IsNullOrEmpty(text))
						{
							text = HttpContext.Current.Server.MapPath(text3 + "/");
							if (Directory.Exists(text))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(text);
								FileInfo[] files = directoryInfo.GetFiles();
								foreach (FileInfo fileInfo in files)
								{
									fileInfo.Delete();
								}
								DirectoryInfo[] directories = directoryInfo.GetDirectories();
								foreach (DirectoryInfo directoryInfo2 in directories)
								{
									directoryInfo2.Delete(recursive: true);
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

	public static bool DownlaodFile(string sourceFile, string filePath)
	{
		bool result = false;
		try
		{
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
