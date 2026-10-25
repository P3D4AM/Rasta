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

public class FoFiles
{
	public string GetFilePath(int fileDirId)
	{
		CRMSpEntities cRMSpEntities = null;
		string result = "";
		if (fileDirId != 0)
		{
			try
			{
				cRMSpEntities = new CRMSpEntities();
				FOMobspSelectCrmFilesDirectory_Result fOMobspSelectCrmFilesDirectory_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFilesDirectory_Result>((IEnumerable<FOMobspSelectCrmFilesDirectory_Result>)cRMSpEntities.FOMobspSelectCrmFilesDirectory(fileDirId));
				if (fOMobspSelectCrmFilesDirectory_Result != null)
				{
					string filePath = fOMobspSelectCrmFilesDirectory_Result.FilePath;
					string filePath2 = fOMobspSelectCrmFilesDirectory_Result.FilePath;
					filePath2 = filePath2.Replace(Configuration.MainDirectoryPath, "/");
					string text = filePath2;
					filePath2 = "~" + filePath2;
					string path = HttpContext.Current.Server.MapPath(filePath2);
					string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
					string text2 = "";
					if (array != null)
					{
						text2 = ((array[0] != null && array[0] != "") ? (array[0] + text) : "");
					}
					result = (File.Exists(path) ? text2 : ((!DownlaodFile(filePath, filePath2)) ? "" : text2));
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				result = "";
			}
			finally
			{
				cRMSpEntities?.Dispose();
			}
		}
		return result;
	}

	public string GetFoMobEntryLogoPath(int currLangId, int defLangId, int? cId = null, int? foSettingId = null)
	{
		CRMSpEntities cRMSpEntities = null;
		string result = "";
		try
		{
			cRMSpEntities = new CRMSpEntities();
			FOMobspSelectCrmFoSetting_Result fOMobspSelectCrmFoSetting_Result = Enumerable.FirstOrDefault<FOMobspSelectCrmFoSetting_Result>((IEnumerable<FOMobspSelectCrmFoSetting_Result>)cRMSpEntities.FOMobspSelectCrmFoSetting(currLangId, defLangId, cId, foSettingId));
			if (fOMobspSelectCrmFoSetting_Result != null)
			{
				string foMobEntryLogoPath = fOMobspSelectCrmFoSetting_Result.FoMobEntryLogoPath;
				string foMobEntryLogoPath2 = fOMobspSelectCrmFoSetting_Result.FoMobEntryLogoPath;
				foMobEntryLogoPath2 = foMobEntryLogoPath2.Replace(Configuration.MainDirectoryPath, "/");
				string text = foMobEntryLogoPath2;
				foMobEntryLogoPath2 = "~" + foMobEntryLogoPath2;
				string path = HttpContext.Current.Server.MapPath(foMobEntryLogoPath2);
				string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
				string text2 = "";
				if (array != null)
				{
					text2 = ((array[0] != null && array[0] != "") ? (array[0] + text) : "");
				}
				result = (File.Exists(path) ? text2 : ((!DownlaodFile(foMobEntryLogoPath, foMobEntryLogoPath2)) ? "" : text2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		finally
		{
			cRMSpEntities?.Dispose();
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
