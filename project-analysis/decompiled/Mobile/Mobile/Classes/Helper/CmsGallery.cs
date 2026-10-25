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
using Mobile.Models.ViewModel.FrontOffice;

namespace Mobile.Classes.Helper;

public class CmsGallery
{
	public static LoadGalleryViewModel GetGallery1(int galleryId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LoadGalleryViewModel loadGalleryViewModel = new LoadGalleryViewModel();
		loadGalleryViewModel.Gallery = new MobspCmsSelectGallery_Result();
		loadGalleryViewModel.GalleryItems = new List<MobspCmsSelectGalleryItems_Result>();
		loadGalleryViewModel.IsFind = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			Common common = new Common();
			if (galleryId > 0)
			{
				loadGalleryViewModel.Gallery = Enumerable.FirstOrDefault<MobspCmsSelectGallery_Result>((IEnumerable<MobspCmsSelectGallery_Result>)cRMEntities.MobspCmsSelectGallery(galleryId, lCID, result));
				if (loadGalleryViewModel.Gallery != null)
				{
					loadGalleryViewModel.GalleryItems = Enumerable.ToList<MobspCmsSelectGalleryItems_Result>((IEnumerable<MobspCmsSelectGalleryItems_Result>)cRMEntities.MobspCmsSelectGalleryItems(galleryId, lCID, result));
					if (Enumerable.Any<MobspCmsSelectGalleryItems_Result>((IEnumerable<MobspCmsSelectGalleryItems_Result>)loadGalleryViewModel.GalleryItems))
					{
						loadGalleryViewModel.IsFind = true;
					}
					foreach (MobspCmsSelectGalleryItems_Result galleryItem in loadGalleryViewModel.GalleryItems)
					{
						if (!string.IsNullOrEmpty(galleryItem.ItemTitleFontColor))
						{
							galleryItem.ItemTitleFontColor = common.DelphiCToRgbolor(galleryItem.ItemTitleFontColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemDescFontColor))
						{
							galleryItem.ItemDescFontColor = common.DelphiCToRgbolor(galleryItem.ItemDescFontColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemLinkBgColor))
						{
							galleryItem.ItemLinkBgColor = common.DelphiCToRgbolor(galleryItem.ItemLinkBgColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemLinkFontColor))
						{
							galleryItem.ItemLinkFontColor = common.DelphiCToRgbolor(galleryItem.ItemLinkFontColor);
						}
						if (string.IsNullOrEmpty(galleryItem.FilePath))
						{
							continue;
						}
						string filePath = galleryItem.FilePath;
						string filePath2 = galleryItem.FilePath;
						filePath2 = filePath2.Replace(Configuration.MainDirectoryPath, "/");
						filePath2 = "~" + filePath2;
						if (!File.Exists(HttpContext.Current.Server.MapPath(filePath2)))
						{
							if (DownlaodFile(filePath, filePath2))
							{
								galleryItem.FilePath = filePath2;
							}
							else
							{
								galleryItem.FilePath = "";
							}
						}
						else
						{
							galleryItem.FilePath = filePath2;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return loadGalleryViewModel;
	}

	public static FoGetHomeGallery GetGallery(int galleryId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		FoGetHomeGallery foGetHomeGallery = new FoGetHomeGallery();
		foGetHomeGallery.Gallery = new FOMobspCmsSelectGallery_Result();
		foGetHomeGallery.GalleryItems = new List<FOMobspCmsSelectGalleryItems_Result>();
		foGetHomeGallery.IsFind = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			Common common = new Common();
			if (galleryId > 0)
			{
				foGetHomeGallery.Gallery = Enumerable.FirstOrDefault<FOMobspCmsSelectGallery_Result>((IEnumerable<FOMobspCmsSelectGallery_Result>)cRMEntities.FOMobspCmsSelectGallery(galleryId, lCID, result));
				if (foGetHomeGallery.Gallery != null)
				{
					foGetHomeGallery.GalleryItems = Enumerable.ToList<FOMobspCmsSelectGalleryItems_Result>((IEnumerable<FOMobspCmsSelectGalleryItems_Result>)cRMEntities.FOMobspCmsSelectGalleryItems(galleryId, lCID, result));
					if (Enumerable.Any<FOMobspCmsSelectGalleryItems_Result>((IEnumerable<FOMobspCmsSelectGalleryItems_Result>)foGetHomeGallery.GalleryItems))
					{
						foGetHomeGallery.IsFind = true;
					}
					foreach (FOMobspCmsSelectGalleryItems_Result galleryItem in foGetHomeGallery.GalleryItems)
					{
						if (!string.IsNullOrEmpty(galleryItem.ItemTitleFontColor))
						{
							galleryItem.ItemTitleFontColor = common.DelphiCToRgbolor(galleryItem.ItemTitleFontColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemDescFontColor))
						{
							galleryItem.ItemDescFontColor = common.DelphiCToRgbolor(galleryItem.ItemDescFontColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemLinkBgColor))
						{
							galleryItem.ItemLinkBgColor = common.DelphiCToRgbolor(galleryItem.ItemLinkBgColor);
						}
						if (!string.IsNullOrEmpty(galleryItem.ItemLinkFontColor))
						{
							galleryItem.ItemLinkFontColor = common.DelphiCToRgbolor(galleryItem.ItemLinkFontColor);
						}
						if (string.IsNullOrEmpty(galleryItem.FilePath))
						{
							continue;
						}
						string filePath = galleryItem.FilePath;
						string filePath2 = galleryItem.FilePath;
						filePath2 = filePath2.Replace(Configuration.MainDirectoryPath, "/");
						string text = filePath2;
						filePath2 = "~" + filePath2;
						string path = HttpContext.Current.Server.MapPath(filePath2);
						string[] array = HttpContext.Current.Request.Url.AbsoluteUri.Split(new string[1] { "/api/" }, StringSplitOptions.None);
						string filePath3 = "";
						if (array != null)
						{
							filePath3 = ((array[0] != null && array[0] != "") ? (array[0] + text) : "");
						}
						if (!File.Exists(path))
						{
							if (DownlaodFile(filePath, filePath2))
							{
								galleryItem.FilePath = filePath3;
							}
							else
							{
								galleryItem.FilePath = "";
							}
						}
						else
						{
							galleryItem.FilePath = filePath3;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return foGetHomeGallery;
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
