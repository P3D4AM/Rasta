using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using CRM.General.IO.FTP;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Product
{
	public class PrdSelectedDoneTimeRes
	{
		public int SaleCenterId { get; set; }

		public int SaleCenterParentId { get; set; }
	}

	public static List<SHPMobspCheckSelectedPrdDoneTime_Result> CheckSelectedDoneTimeAvailable(string prdsJs, out bool resultCheck)
	{
		List<SHPMobspCheckSelectedPrdDoneTime_Result> result = new List<SHPMobspCheckSelectedPrdDoneTime_Result>();
		resultCheck = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			ObjectParameter objectParameter = new ObjectParameter("ResultCheck", false);
			List<SHPMobspCheckSelectedPrdDoneTime_Result> list = Enumerable.ToList<SHPMobspCheckSelectedPrdDoneTime_Result>((IEnumerable<SHPMobspCheckSelectedPrdDoneTime_Result>)cRMSpEntities.SHPMobspCheckSelectedPrdDoneTime(prdsJs, objectParameter, true, lCID, result2, null));
			if (list != null)
			{
				result = list;
			}
			bool.TryParse(objectParameter.Value.ToString(), out resultCheck);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetProductPictureFilePath(string FilePath, string FileName, string FolderName)
	{
		string result = "";
		try
		{
			string text = FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
			text = ((!text.Contains("/" + Configuration.PrdGroupDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + FolderName + "/" + FileName) : (Configuration.MainDirectoryPath + Configuration.PrdGroupDirectoryPath + FolderName + "/" + FileName));
			if (text != "")
			{
				FilesManager filesManager = new FilesManager();
				string text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
				if (filesManager.CreateDirectory(text2))
				{
					result = HttpContext.Current.Server.MapPath(text2 + "/" + FileName);
					string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
					string text3 = "";
					if (array != null)
					{
						text3 = ((array[0] != null && array[0] != "") ? (array[0] + text2 + "/" + FileName) : "");
					}
					if (!new FacadeFTP(Configuration.FacadeFtp).Download(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, result, text, overwrite: true, Configuration.UsePassiveFtp))
					{
						if (!string.IsNullOrEmpty(result))
						{
							result = HttpContext.Current.Server.MapPath(text2 + "/");
							if (Directory.Exists(result))
							{
								DirectoryInfo directoryInfo = new DirectoryInfo(result);
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
								if (Directory.Exists(result))
								{
									Directory.Delete(result);
								}
							}
						}
						result = "";
					}
					else
					{
						result = text3;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		return result;
	}
}
