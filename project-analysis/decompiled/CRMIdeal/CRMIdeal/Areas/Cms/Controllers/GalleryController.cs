using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cms.Controllers;

public class GalleryController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public CrmCmsGalleryLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__11;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public CrmCmsGallery model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_0
	{
		public int galleryItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_0
	{
		public int galleryItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public CrmCmsGalleryItemsLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__9;

		public Func<Languages, bool> _003C_003E9__23;

		internal bool _003CInsertEditItem_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__9(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEditItem_003Eb__23(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public CrmCmsGalleryItems model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEditItem_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEditItem_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_0
	{
		public int galleryItemId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int galleryId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int galleryId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineGallery")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialGalleryTree()
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			List<CRMspCmsSelectGallery_Result> list = Enumerable.ToList<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)_db.CRMspCmsSelectGallery(0, cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result));
			List<TreeViewItemModel> list2 = new List<TreeViewItemModel>();
			if (Enumerable.Any<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list))
			{
				foreach (CRMspCmsSelectGallery_Result item in list)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.GalleryId.ToString()));
					treeViewItemModel.Id = item.GalleryId.ToString();
					treeViewItemModel.Text = item.GalleryTitle;
					treeViewItemModel.ImageUrl = "";
					treeViewItemModel.Items = null;
					list2.Add(treeViewItemModel);
				}
			}
			base.ViewBag.GalleryTree = list2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public ActionResult GalleryItem_Read([DataSourceRequest] DataSourceRequest request, int galleryId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspCmsSelectGalleryItems_Result> enumerable = new List<CRMspCmsSelectGalleryItems_Result>();
		try
		{
			string cmsTargetSelfMode = Labels.CmsTargetSelfMode;
			string cmsTargetBlankMode = Labels.CmsTargetBlankMode;
			enumerable = Enumerable.ToList<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)_db.CRMspCmsSelectGalleryItems(galleryId, 0, cmsTargetSelfMode, cmsTargetBlankMode, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcmsDefineGallery")]
	public JsonResult GetGallery(int galleryId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCmsGalleryViewModel currentCmsGalleryViewModel = new CurrentCmsGalleryViewModel();
		try
		{
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			CRMspCmsSelectGallery_Result cRMspCmsSelectGallery_Result = Enumerable.FirstOrDefault<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)_db.CRMspCmsSelectGallery(galleryId, cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result));
			if (cRMspCmsSelectGallery_Result != null)
			{
				currentCmsGalleryViewModel.IsFind = true;
				currentCmsGalleryViewModel.Message = "";
				currentCmsGalleryViewModel.Gallery = cRMspCmsSelectGallery_Result;
				currentCmsGalleryViewModel.GalleryCurrentId = cRMspCmsSelectGallery_Result.GalleryId;
				_ = cRMspCmsSelectGallery_Result.FirstRegisterDate;
				cRMspCmsSelectGallery_Result.FirstRegisterDatePersian = cRMspCmsSelectGallery_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = cRMspCmsSelectGallery_Result.RegisterDate;
				cRMspCmsSelectGallery_Result.RegisterDatePersian = cRMspCmsSelectGallery_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(cRMspCmsSelectGallery_Result.AppType))
				{
					cRMspCmsSelectGallery_Result.AppType = Configuration.AppType;
				}
				cRMspCmsSelectGallery_Result.AppType = Configuration.GetAppType(cRMspCmsSelectGallery_Result.AppType);
			}
			else
			{
				currentCmsGalleryViewModel.IsFind = false;
				currentCmsGalleryViewModel.Message = Messages.ErrorNotFound;
				currentCmsGalleryViewModel.Gallery = null;
				currentCmsGalleryViewModel.GalleryCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCmsGalleryViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCmsGalleryViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCmsGalleryViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public ActionResult _PartialGalleryPerview(int galleryId)
	{
		CurrentCmsGalleryViewModel currentCmsGalleryViewModel = new CurrentCmsGalleryViewModel();
		currentCmsGalleryViewModel.Gallery = new CRMspCmsSelectGallery_Result();
		currentCmsGalleryViewModel.GalleryItems = new List<CRMspCmsSelectGalleryItems_Result>();
		currentCmsGalleryViewModel.IsFind = false;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			BaseInfo baseInfo = new BaseInfo();
			string cmsGalleryGalleryEffectSlideTxt = Labels.CmsGalleryGalleryEffectSlideTxt;
			string cmsGalleryGalleryEffectFadeTxt = Labels.CmsGalleryGalleryEffectFadeTxt;
			string cmsTargetSelfMode = Labels.CmsTargetSelfMode;
			string cmsTargetBlankMode = Labels.CmsTargetBlankMode;
			currentCmsGalleryViewModel.Gallery = Enumerable.FirstOrDefault<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)_db.CRMspCmsSelectGallery(galleryId, cmsGalleryGalleryEffectSlideTxt, cmsGalleryGalleryEffectFadeTxt, lCID, result));
			if (currentCmsGalleryViewModel.Gallery != null)
			{
				currentCmsGalleryViewModel.GalleryItems = Enumerable.ToList<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)_db.CRMspCmsSelectGalleryItems(galleryId, 0, cmsTargetSelfMode, cmsTargetBlankMode, lCID, result));
				if (Enumerable.Any<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)currentCmsGalleryViewModel.GalleryItems))
				{
					currentCmsGalleryViewModel.IsFind = true;
				}
				foreach (CRMspCmsSelectGalleryItems_Result galleryItem in currentCmsGalleryViewModel.GalleryItems)
				{
					if (!string.IsNullOrEmpty(galleryItem.ItemTitleFontColor))
					{
						galleryItem.ItemTitleFontColor = baseInfo.DelphiCToRgbolor(galleryItem.ItemTitleFontColor);
					}
					if (!string.IsNullOrEmpty(galleryItem.ItemDescFontColor))
					{
						galleryItem.ItemDescFontColor = baseInfo.DelphiCToRgbolor(galleryItem.ItemDescFontColor);
					}
					if (!string.IsNullOrEmpty(galleryItem.ItemLinkBgColor))
					{
						galleryItem.ItemLinkBgColor = baseInfo.DelphiCToRgbolor(galleryItem.ItemLinkBgColor);
					}
					if (!string.IsNullOrEmpty(galleryItem.ItemLinkFontColor))
					{
						galleryItem.ItemLinkFontColor = baseInfo.DelphiCToRgbolor(galleryItem.ItemLinkFontColor);
					}
					if (string.IsNullOrEmpty(galleryItem.FilePath))
					{
						continue;
					}
					string filePath = galleryItem.FilePath;
					string filePath2 = galleryItem.FilePath;
					filePath2 = filePath2.Replace(Configuration.MainDirectoryPath, "/");
					filePath2 = "~" + filePath2;
					if (!System.IO.File.Exists(base.Server.MapPath(filePath2)))
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(currentCmsGalleryViewModel);
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
						if (!System.IO.File.Exists(text))
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

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineGallery", ActionName = "actDelete")]
	public string DeleteGallery(int galleryId)
	{
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.galleryId = galleryId;
		string result = "";
		try
		{
			DbSet<CrmCmsGallery> crmCmsGallery = _dbTbl.CrmCmsGallery;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsGallery), "c");
			if (Queryable.FirstOrDefault<CrmCmsGallery>((IQueryable<CrmCmsGallery>)crmCmsGallery, Expression.Lambda<Func<CrmCmsGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteGallery(_003C_003Ec__DisplayClass8_.galleryId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsGallery");
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCmsDefineGallery", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int galleryId = 0)
	{
		_003C_003Ec__DisplayClass9_0 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_0();
		_003C_003Ec__DisplayClass9_.galleryId = galleryId;
		CrmCmsGalleryLanguageViewModel crmCmsGalleryLanguageViewModel = new CrmCmsGalleryLanguageViewModel();
		try
		{
			CrmCmsGallery crmCmsGallery = new CrmCmsGallery();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass9_.galleryId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineGallery", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsGallery_Lang> crmCmsGallery_Lang = _dbTbl.CrmCmsGallery_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsGallery_Lang), "c");
				List<CrmCmsGallery_Lang> list = Enumerable.ToList<CrmCmsGallery_Lang>((IEnumerable<CrmCmsGallery_Lang>)Queryable.Where<CrmCmsGallery_Lang>((IQueryable<CrmCmsGallery_Lang>)crmCmsGallery_Lang, Expression.Lambda<Func<CrmCmsGallery_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsGallery> crmCmsGallery2 = _dbTbl.CrmCmsGallery;
				val = Expression.Parameter(typeof(CrmCmsGallery), "c");
				crmCmsGallery = Queryable.FirstOrDefault<CrmCmsGallery>((IQueryable<CrmCmsGallery>)crmCmsGallery2, Expression.Lambda<Func<CrmCmsGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass9_, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmCmsGallery == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsGallery_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsGallery_Lang>)list, (Func<CrmCmsGallery_Lang, CommonMultiLanguageViewModel>)((CrmCmsGallery_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.GalleryTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsGallery.GalleryTitle,
					LanguageId = result
				});
				crmCmsGalleryLanguageViewModel = new CrmCmsGalleryLanguageViewModel
				{
					GalleryId = crmCmsGallery.GalleryId,
					GalleryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					GalleryTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					GalleryInterval = crmCmsGallery.GalleryInterval,
					GalleryEffect = crmCmsGallery.GalleryEffect,
					IsActive = crmCmsGallery.IsActive,
					IsShowTitle = crmCmsGallery.IsShowTitle,
					OrderView = crmCmsGallery.OrderView,
					FirstRegisterUserId = crmCmsGallery.FirstRegisterUserId,
					FirstRegisterDate = crmCmsGallery.FirstRegisterDate,
					FirstRegisterDatePersian = crmCmsGallery.FirstRegisterDatePersian,
					UserId = crmCmsGallery.UserId,
					Year1 = crmCmsGallery.Year1,
					Month1 = crmCmsGallery.Month1,
					RegisterDate = crmCmsGallery.RegisterDate,
					RegisterDatePersian = crmCmsGallery.RegisterDatePersian,
					GUId = crmCmsGallery.GUId,
					AppType = crmCmsGallery.AppType,
					LanguageID = crmCmsGallery.LanguageID,
					GallerySystemPartIds = crmCmsGallery.GallerySystemPartIds
				};
				if (crmCmsGallery != null && !string.IsNullOrWhiteSpace(crmCmsGallery.GallerySystemPartIds) && !crmCmsGallery.GallerySystemPartIds.EndsWith(","))
				{
					crmCmsGallery.GallerySystemPartIds += ",";
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineGallery", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsGalleryLanguageViewModel = new CrmCmsGalleryLanguageViewModel
				{
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					Year1 = short.Parse(Financial.Get().Id.ToString()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					AppType = Configuration.AppType,
					LanguageID = result,
					IsActive = true
				};
				List<CRMspCmsSelectGallery_Result> list3 = Enumerable.ToList<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)_db.CRMspCmsSelectGallery(0, "", "", currLangID, result));
				if (!Enumerable.Any<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list3))
				{
					crmCmsGalleryLanguageViewModel.OrderView = 10;
				}
				else
				{
					int result2 = 10;
					CRMspCmsSelectGallery_Result cRMspCmsSelectGallery_Result = Enumerable.LastOrDefault<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list3);
					if (cRMspCmsSelectGallery_Result != null)
					{
						int.TryParse(cRMspCmsSelectGallery_Result.OrderView.ToString(), out result2);
						result2 = ((result2 == 0) ? 10 : (result2 + 10));
					}
					crmCmsGalleryLanguageViewModel.OrderView = result2;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetEffect();
		return View(crmCmsGalleryLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsDefineGalleryDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmCmsGalleryLanguageViewModel vm)
	{
		//IL_0086: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetEffect();
		try
		{
			_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
			_003C_003Ec__DisplayClass10_.model = new CrmCmsGallery();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.GalleryTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.GalleryTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.GalleryTitle,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			string text = "";
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.GalleryTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CrmCmsGalleryTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.GalleryTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CrmCmsGalleryTitle) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass10_.model = new CrmCmsGallery();
				if (CS_0024_003C_003E8__locals0.vm.GalleryId > 0)
				{
					DbSet<CrmCmsGallery> crmCmsGallery = _dbTbl.CrmCmsGallery;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsGallery), "c");
					_003C_003Ec__DisplayClass10_.model = Queryable.FirstOrDefault<CrmCmsGallery>((IQueryable<CrmCmsGallery>)crmCmsGallery, Expression.Lambda<Func<CrmCmsGallery, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass10_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass10_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass10_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass10_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass10_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass10_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass10_.model.GalleryTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass10_.model.GalleryInterval = CS_0024_003C_003E8__locals0.vm.GalleryInterval;
				_003C_003Ec__DisplayClass10_.model.GalleryEffect = CS_0024_003C_003E8__locals0.vm.GalleryEffect;
				_003C_003Ec__DisplayClass10_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass10_.model.IsShowTitle = CS_0024_003C_003E8__locals0.vm.IsShowTitle;
				_003C_003Ec__DisplayClass10_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				_003C_003Ec__DisplayClass10_.model.GallerySystemPartIds = CS_0024_003C_003E8__locals0.vm.GallerySystemPartIds;
				if (_003C_003Ec__DisplayClass10_.model != null && !string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass10_.model.GallerySystemPartIds) && !_003C_003Ec__DisplayClass10_.model.GallerySystemPartIds.EndsWith(","))
				{
					_003C_003Ec__DisplayClass10_.model.GallerySystemPartIds = _003C_003Ec__DisplayClass10_.model.GallerySystemPartIds + ",";
				}
				if (_003C_003Ec__DisplayClass10_.model.GalleryId > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass10_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass10_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass10_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmCmsGallery_Lang> crmCmsGallery_Lang = _dbTbl.CrmCmsGallery_Lang;
							ParameterExpression val = Expression.Parameter(typeof(CrmCmsGallery_Lang), "c");
							CrmCmsGallery_Lang crmCmsGallery_Lang2 = Queryable.FirstOrDefault<CrmCmsGallery_Lang>((IQueryable<CrmCmsGallery_Lang>)crmCmsGallery_Lang, Expression.Lambda<Func<CrmCmsGallery_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCmsGallery_Lang2 != null)
							{
								crmCmsGallery_Lang2.GalleryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCmsGallery_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmCmsGallery_Lang2 = new CrmCmsGallery_Lang();
							crmCmsGallery_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmCmsGallery_Lang2.GalleryId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.GalleryId;
							crmCmsGallery_Lang2.GalleryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmCmsGallery_Lang.Add(crmCmsGallery_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					text = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
					{
						List<CRMspCmsSelectGallery_Result> list2 = Enumerable.ToList<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)_db.CRMspCmsSelectGallery(0, "", "", lCID, CS_0024_003C_003E8__locals0.defLangID));
						int num2 = (Enumerable.Any<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list2) ? Enumerable.Count<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list2) : 0);
						_003C_003Ec__DisplayClass10_.model.OrderView = num2 * 10 + 10;
						if (Enumerable.LastOrDefault<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list2) != null)
						{
							int valueOrDefault = Enumerable.LastOrDefault<CRMspCmsSelectGallery_Result>((IEnumerable<CRMspCmsSelectGallery_Result>)list2).OrderView.GetValueOrDefault();
							if (valueOrDefault > 0)
							{
								_003C_003Ec__DisplayClass10_.model.OrderView = valueOrDefault + 10;
							}
						}
					}
					else
					{
						_003C_003Ec__DisplayClass10_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
					}
					_003C_003Ec__DisplayClass10_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass10_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass10_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass10_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass10_.model.GUId = Guid.NewGuid();
					_dbTbl.CrmCmsGallery.Add(_003C_003Ec__DisplayClass10_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						CrmCmsGallery_Lang crmCmsGallery_Lang3 = new CrmCmsGallery_Lang();
						crmCmsGallery_Lang3.LanguageID = lang.LanguageID;
						crmCmsGallery_Lang3.GalleryId = _003C_003Ec__DisplayClass10_.model.GalleryId;
						crmCmsGallery_Lang3.GalleryTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsGallery_Lang.Add(crmCmsGallery_Lang3);
						_dbTbl.SaveChanges();
					}
					text = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.GalleryId = _003C_003Ec__DisplayClass10_.model.GalleryId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass10_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass10_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass10_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass10_.model.FirstRegisterUserId;
				base.ViewBag.Successfull = text;
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsGallery");
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				base.ViewBag.Error = text;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineGallery", ActionName = "actDeleteSlide")]
	public string DeleteGalleryItem(int galleryItemId)
	{
		_003C_003Ec__DisplayClass12_0 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_0();
		_003C_003Ec__DisplayClass12_.galleryItemId = galleryItemId;
		string result = "";
		try
		{
			DbSet<CrmCmsGalleryItems> crmCmsGalleryItems = _dbTbl.CrmCmsGalleryItems;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsGalleryItems), "c");
			CrmCmsGalleryItems crmCmsGalleryItems2 = Queryable.FirstOrDefault<CrmCmsGalleryItems>((IQueryable<CrmCmsGalleryItems>)crmCmsGalleryItems, Expression.Lambda<Func<CrmCmsGalleryItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCmsGalleryItems2 != null)
			{
				try
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					if (!string.IsNullOrEmpty(crmCmsGalleryItems2.FilePath))
					{
						string text = crmCmsGalleryItems2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
						text = Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath + crmCmsGalleryItems2.FolderName + "/" + crmCmsGalleryItems2.FileName;
						FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
						string destination = text;
						if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, crmCmsGalleryItems2.FileName, destination, Configuration.UsePassiveFtp))
						{
							mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteGalleryItem(_003C_003Ec__DisplayClass12_.galleryItemId));
							if (mct_Result != null && mct_Result.Result > 0)
							{
								result = "";
								CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsGalleryItems");
							}
							else if (mct_Result != null && mct_Result.Result == 0)
							{
								result = Messages.RedundancyMessage;
							}
						}
						DeleteOldGalleryFromFtp(crmCmsGalleryItems2.FilePath);
					}
					else
					{
						mct_Result mct_Result2 = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspCmsDeleteGalleryItem(_003C_003Ec__DisplayClass12_.galleryItemId));
						if (mct_Result2 != null && mct_Result2.Result > 0)
						{
							result = "";
						}
						else if (mct_Result2 != null && mct_Result2.Result == 0)
						{
							result = Messages.RedundancyMessage;
						}
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCmsDefineGallery", ActionName = "actInsertSlide,actEditSlide")]
	public ActionResult InsertEditItem(int galleryId, int galleryItemId = 0)
	{
		_003C_003Ec__DisplayClass13_0 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_0();
		_003C_003Ec__DisplayClass13_.galleryItemId = galleryItemId;
		CrmCmsGalleryItemsLanguageViewModel crmCmsGalleryItemsLanguageViewModel = new CrmCmsGalleryItemsLanguageViewModel();
		try
		{
			CrmCmsGalleryItems crmCmsGalleryItems = new CrmCmsGalleryItems();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass13_.galleryItemId > 0)
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineGallery", "actEditSlide"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmCmsGalleryItems_Lang> crmCmsGalleryItems_Lang = _dbTbl.CrmCmsGalleryItems_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmCmsGalleryItems_Lang), "c");
				List<CrmCmsGalleryItems_Lang> list = Enumerable.ToList<CrmCmsGalleryItems_Lang>((IEnumerable<CrmCmsGalleryItems_Lang>)Queryable.Where<CrmCmsGalleryItems_Lang>((IQueryable<CrmCmsGalleryItems_Lang>)crmCmsGalleryItems_Lang, Expression.Lambda<Func<CrmCmsGalleryItems_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmCmsGalleryItems> crmCmsGalleryItems2 = _dbTbl.CrmCmsGalleryItems;
				val = Expression.Parameter(typeof(CrmCmsGalleryItems), "c");
				crmCmsGalleryItems = Queryable.FirstOrDefault<CrmCmsGalleryItems>((IQueryable<CrmCmsGalleryItems>)crmCmsGalleryItems2, Expression.Lambda<Func<CrmCmsGalleryItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				BaseInfo baseInfo = new BaseInfo();
				if (crmCmsGalleryItems == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsGalleryItems_Lang>)list, (Func<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>)((CrmCmsGalleryItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ItemTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsGalleryItems.ItemTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsGalleryItems_Lang>)list, (Func<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>)((CrmCmsGalleryItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ItemDesc,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsGalleryItems.ItemDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCmsGalleryItems_Lang>)list, (Func<CrmCmsGalleryItems_Lang, CommonMultiLanguageViewModel>)((CrmCmsGalleryItems_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.ItemLinkTitle,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCmsGalleryItems.ItemLinkTitle,
					LanguageId = result
				});
				crmCmsGalleryItemsLanguageViewModel = new CrmCmsGalleryItemsLanguageViewModel
				{
					GalleryItemId = crmCmsGalleryItems.GalleryItemId,
					GalleryId = crmCmsGalleryItems.GalleryId,
					ItemTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					ItemTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					ItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					ItemDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					ItemLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
					ItemLinkTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
					ItemTitleFontColor = baseInfo.DelphiCToRgbolor(crmCmsGalleryItems.ItemTitleFontColor),
					ItemDescFontColor = baseInfo.DelphiCToRgbolor(crmCmsGalleryItems.ItemDescFontColor),
					ItemLink = crmCmsGalleryItems.ItemLink,
					ItemLinkBgColor = baseInfo.DelphiCToRgbolor(crmCmsGalleryItems.ItemLinkBgColor),
					ItemLinkFontColor = baseInfo.DelphiCToRgbolor(crmCmsGalleryItems.ItemLinkFontColor),
					TargetMode = crmCmsGalleryItems.TargetMode,
					IsActive = crmCmsGalleryItems.IsActive,
					IsShowTitle = crmCmsGalleryItems.IsShowTitle,
					IsShowDesc = crmCmsGalleryItems.IsShowDesc,
					FileName = crmCmsGalleryItems.FileName,
					FolderName = crmCmsGalleryItems.FolderName,
					FilePath = crmCmsGalleryItems.FilePath,
					OrderView = crmCmsGalleryItems.OrderView,
					FirstRegisterUserId = crmCmsGalleryItems.FirstRegisterUserId,
					FirstRegisterDate = crmCmsGalleryItems.FirstRegisterDate,
					FirstRegisterDatePersian = crmCmsGalleryItems.FirstRegisterDatePersian,
					UserId = crmCmsGalleryItems.UserId,
					Year1 = crmCmsGalleryItems.Year1,
					Month1 = crmCmsGalleryItems.Month1,
					RegisterDate = crmCmsGalleryItems.RegisterDate,
					RegisterDatePersian = crmCmsGalleryItems.RegisterDatePersian,
					GUId = crmCmsGalleryItems.GUId,
					AppType = crmCmsGalleryItems.AppType,
					LanguageID = crmCmsGalleryItems.LanguageID
				};
				if (!string.IsNullOrEmpty(crmCmsGalleryItemsLanguageViewModel.FilePath))
				{
					_ = crmCmsGalleryItemsLanguageViewModel.FilePath;
					crmCmsGalleryItemsLanguageViewModel.FilePath = crmCmsGalleryItemsLanguageViewModel.FilePath.Replace(Configuration.MainDirectoryPath, "/");
					crmCmsGalleryItemsLanguageViewModel.FilePath = crmCmsGalleryItemsLanguageViewModel.FilePath;
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmCmsDefineGallery", "actInsertSlide"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				crmCmsGalleryItemsLanguageViewModel = new CrmCmsGalleryItemsLanguageViewModel
				{
					GalleryId = galleryId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					Year1 = short.Parse(Financial.Get().Id.ToString()),
					Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
					AppType = Configuration.AppType,
					LanguageID = result,
					IsActive = true
				};
				List<CRMspCmsSelectGalleryItems_Result> list5 = Enumerable.ToList<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)_db.CRMspCmsSelectGalleryItems(galleryId, 0, "", "", currLangID, result));
				if (!Enumerable.Any<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list5))
				{
					crmCmsGalleryItemsLanguageViewModel.OrderView = 10;
				}
				else
				{
					int result2 = 10;
					CRMspCmsSelectGalleryItems_Result cRMspCmsSelectGalleryItems_Result = Enumerable.LastOrDefault<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list5);
					if (cRMspCmsSelectGalleryItems_Result != null)
					{
						int.TryParse(cRMspCmsSelectGalleryItems_Result.OrderView.ToString(), out result2);
						result2 = ((result2 == 0) ? 10 : (result2 + 10));
					}
					crmCmsGalleryItemsLanguageViewModel.OrderView = result2;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetTargetMode();
		return View(crmCmsGalleryItemsLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCmsDefineGallerySlideDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEditItem(CrmCmsGalleryItemsLanguageViewModel vm, HttpPostedFileBase FileUrlUpload)
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_014b: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass14_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetTargetMode();
		string text = "";
		try
		{
			_003C_003Ec__DisplayClass14_1 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_1();
			int customWidth = 1920;
			int customHeight = 730;
			BaseInfo baseInfo = new BaseInfo();
			_003C_003Ec__DisplayClass14_.model = new CrmCmsGalleryItems();
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ItemTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ItemTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ItemTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ItemDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ItemDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ItemDesc,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ItemLinkTitle_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.ItemLinkTitle_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.vm.ItemLinkTitle,
				LanguageId = lCID
			});
			_ = CRMIdeal.Cache.Setting.Language.Get().Count;
			int num = 0;
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.ItemTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.CrmCmsGalleryItemTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.ItemTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.CrmCmsGalleryItemTitle) + "<br>";
				num++;
			}
			if (num > 0)
			{
				base.ViewBag.Error = text;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			DateTime now;
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass14_.model = new CrmCmsGalleryItems();
				if (CS_0024_003C_003E8__locals0.vm.GalleryItemId > 0)
				{
					DbSet<CrmCmsGalleryItems> crmCmsGalleryItems = _dbTbl.CrmCmsGalleryItems;
					ParameterExpression val = Expression.Parameter(typeof(CrmCmsGalleryItems), "c");
					_003C_003Ec__DisplayClass14_.model = Queryable.FirstOrDefault<CrmCmsGalleryItems>((IQueryable<CrmCmsGalleryItems>)crmCmsGalleryItems, Expression.Lambda<Func<CrmCmsGalleryItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass14_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				_003C_003Ec__DisplayClass14_.model.UserId = UserLogin.CurrentUser.UserId;
				now = DateTime.Now;
				_003C_003Ec__DisplayClass14_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass14_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass14_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass14_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass14_.model.Year1 = short.Parse(Financial.Get().Id.ToString());
				_003C_003Ec__DisplayClass14_.model.GalleryId = CS_0024_003C_003E8__locals0.vm.GalleryId;
				_003C_003Ec__DisplayClass14_.model.ItemTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass14_.model.ItemDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass14_.model.ItemLinkTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass14_.model.ItemTitleFontColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ItemTitleFontColor);
				_003C_003Ec__DisplayClass14_.model.ItemDescFontColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ItemDescFontColor);
				_003C_003Ec__DisplayClass14_.model.ItemLink = CS_0024_003C_003E8__locals0.vm.ItemLink;
				_003C_003Ec__DisplayClass14_.model.ItemLinkBgColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ItemLinkBgColor);
				_003C_003Ec__DisplayClass14_.model.ItemLinkFontColor = baseInfo.RgbToDelphiColor(CS_0024_003C_003E8__locals0.vm.ItemLinkFontColor);
				_003C_003Ec__DisplayClass14_.model.TargetMode = CS_0024_003C_003E8__locals0.vm.TargetMode;
				_003C_003Ec__DisplayClass14_.model.IsActive = CS_0024_003C_003E8__locals0.vm.IsActive;
				_003C_003Ec__DisplayClass14_.model.IsShowTitle = CS_0024_003C_003E8__locals0.vm.IsShowTitle;
				_003C_003Ec__DisplayClass14_.model.IsShowDesc = CS_0024_003C_003E8__locals0.vm.IsShowDesc;
				_003C_003Ec__DisplayClass14_.model.FileName = CS_0024_003C_003E8__locals0.vm.FileName;
				_003C_003Ec__DisplayClass14_.model.FolderName = CS_0024_003C_003E8__locals0.vm.FolderName;
				_003C_003Ec__DisplayClass14_.model.FilePath = CS_0024_003C_003E8__locals0.vm.FilePath;
				_003C_003Ec__DisplayClass14_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				if (FileUrlUpload == null)
				{
					if (FileUrlUpload != null || CS_0024_003C_003E8__locals0.vm.GalleryItemId > 0)
					{
						if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass14_.model.FilePath))
						{
							base.ViewBag.Error = Messages.msgErrorNoFileInNotSelect;
							return View(CS_0024_003C_003E8__locals0.vm);
						}
						goto IL_0850;
					}
					base.ViewBag.Error = Messages.msgErrorNoFileInNotSelect;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
				string text2 = FileUrlUpload.ContentType.ToLower();
				string text3 = ((FileUrlUpload.FileName != null) ? Path.GetExtension(FileUrlUpload.FileName).ToLower() : "");
				if ((text2 != "image/jpg" && text2 != "image/jpeg" && text2 != "image/pjpeg" && text2 != "image/gif" && text2 != "image/x-png" && text2 != "image/png") || (text3 != ".jpg" && text3 != ".png" && text3 != ".gif" && text3 != ".jpeg"))
				{
					text = Messages.msgErrorFileIsNotPic;
				}
				else
				{
					int num2 = 1048576;
					if (FileUrlUpload.ContentLength <= num2)
					{
						_003C_003Ec__DisplayClass14_.model.FolderName = _003C_003Ec__DisplayClass14_.model.GalleryId.ToString();
						_003C_003Ec__DisplayClass14_.model.FileName = _003C_003Ec__DisplayClass14_.model.GalleryId.ToString();
						_003C_003Ec__DisplayClass14_.model.FilePath = _003C_003Ec__DisplayClass14_.model.FilePath;
						goto IL_0850;
					}
					string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(FileUrlUpload.ContentLength);
					string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
					text = string.Format(Messages.msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
				}
			}
			else
			{
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				base.ViewBag.Error = text;
			}
			goto end_IL_0062;
			IL_180e:
			text = Messages.frmFormBaseInsertSuccessFulMessage;
			goto IL_1814;
			IL_0850:
			if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass14_.model.FilePath) && _003C_003Ec__DisplayClass14_.model.FilePath.IndexOf(Configuration.MainDirectoryPath) < 0)
			{
				if (_003C_003Ec__DisplayClass14_.model.FilePath.StartsWith("/"))
				{
					_003C_003Ec__DisplayClass14_.model.FilePath = _003C_003Ec__DisplayClass14_.model.FilePath.TrimStart(new char[1] { '/' });
				}
				_003C_003Ec__DisplayClass14_.model.FilePath = Configuration.MainDirectoryPath + _003C_003Ec__DisplayClass14_.model.FilePath;
			}
			if (_003C_003Ec__DisplayClass14_.model.GalleryItemId > 0)
			{
				_dbTbl.Entry(_003C_003Ec__DisplayClass14_.model).State = EntityState.Modified;
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass14_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass14_2();
						CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass14_;
						CS_0024_003C_003E8__locals1.lang = enumerator.Current;
						DbSet<CrmCmsGalleryItems_Lang> crmCmsGalleryItems_Lang = _dbTbl.CrmCmsGalleryItems_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmCmsGalleryItems_Lang), "c");
						CrmCmsGalleryItems_Lang crmCmsGalleryItems_Lang2 = Queryable.FirstOrDefault<CrmCmsGalleryItems_Lang>((IQueryable<CrmCmsGalleryItems_Lang>)crmCmsGalleryItems_Lang, Expression.Lambda<Func<CrmCmsGalleryItems_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass14_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmCmsGalleryItems_Lang2 != null)
						{
							crmCmsGalleryItems_Lang2.ItemTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsGalleryItems_Lang2.ItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							crmCmsGalleryItems_Lang2.ItemLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.Entry(crmCmsGalleryItems_Lang2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							continue;
						}
						crmCmsGalleryItems_Lang2 = new CrmCmsGalleryItems_Lang();
						crmCmsGalleryItems_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
						crmCmsGalleryItems_Lang2.GalleryItemId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.GalleryItemId;
						crmCmsGalleryItems_Lang2.ItemTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						crmCmsGalleryItems_Lang2.ItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						crmCmsGalleryItems_Lang2.ItemLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
						_dbTbl.CrmCmsGalleryItems_Lang.Add(crmCmsGalleryItems_Lang2);
						_dbTbl.SaveChanges();
					}
				}
				if (_003C_003Ec__DisplayClass14_.model.GalleryItemId <= 0 || FileUrlUpload == null)
				{
					goto IL_10c1;
				}
				string[] array = FileUrlUpload.FileName.Split(new char[1] { '.' });
				string text4 = _003C_003Ec__DisplayClass14_.model.GalleryId + "-" + _003C_003Ec__DisplayClass14_.model.GalleryItemId + "." + array[^1];
				FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
				string pathFtp = Configuration.PathFtp;
				string userNameFtp = Configuration.UserNameFtp;
				string passwordFtp = Configuration.PasswordFtp;
				bool usePassiveFtp = Configuration.UsePassiveFtp;
				string mainDirectoryPath = Configuration.MainDirectoryPath;
				string cmsGalleryDirectoryPath = Configuration.CmsGalleryDirectoryPath;
				cmsGalleryDirectoryPath = (cmsGalleryDirectoryPath.EndsWith("/") ? cmsGalleryDirectoryPath.TrimEnd(new char[1] { '/' }) : cmsGalleryDirectoryPath);
				bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, cmsGalleryDirectoryPath, usePassiveFtp);
				if (!flag)
				{
					flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, cmsGalleryDirectoryPath, usePassiveFtp);
				}
				mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath;
				bool flag2 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, _003C_003Ec__DisplayClass14_.model.GalleryId.ToString(), usePassiveFtp);
				if (!flag2)
				{
					flag2 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath, _003C_003Ec__DisplayClass14_.model.GalleryId.ToString(), usePassiveFtp);
				}
				if (flag && flag2)
				{
					mainDirectoryPath = Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath + _003C_003Ec__DisplayClass14_.model.GalleryId + "/";
					string text5 = mainDirectoryPath;
					text5 = text5.Replace(Configuration.MainDirectoryPath, "/");
					text5 = base.Server.MapPath(text5);
					if (!System.IO.Directory.Exists(text5))
					{
						System.IO.Directory.CreateDirectory(text5);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
					}
					if (System.IO.Directory.Exists(text5))
					{
						string text6 = text5 + "Initial-" + text4;
						text5 += text4;
						if (System.IO.File.Exists(text5))
						{
							System.IO.File.Delete(text5);
						}
						FileUrlUpload.SaveAs(text6);
						if (System.IO.File.Exists(text6))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text6,
								DestPath = text5,
								CustomHeight = customHeight,
								CustomWidth = customWidth
							});
							ImageManager.DeleteFile(new ImageManager.ImageParam
							{
								FilePath = text6
							});
						}
					}
					if (!System.IO.File.Exists(text5))
					{
						goto IL_10c1;
					}
					if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, mainDirectoryPath + text4, text5, usePassiveFtp))
					{
						_003C_003Ec__DisplayClass14_.model.FileName = text4;
						_003C_003Ec__DisplayClass14_.model.FilePath = mainDirectoryPath + text4;
						_dbTbl.Entry(_003C_003Ec__DisplayClass14_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						string pathFtpFo = Configuration.PathFtpFo;
						string userNameFtpFo = Configuration.UserNameFtpFo;
						string passwordFtpFo = Configuration.PasswordFtpFo;
						_ = Configuration.UsePassiveFtpFo;
						if (!string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo))
						{
							try
							{
								string text7 = "/" + Configuration.CmsGalleryDirectoryPath + _003C_003Ec__DisplayClass14_.model.GalleryId;
								Files.UploadFileToFtp(pathFtpFo, userNameFtpFo, passwordFtpFo, usePassiveFtp, text7 + "/" + text4);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						goto IL_10c1;
					}
					Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath + text4);
					ErrorSignal.FromCurrentContext().Raise(e2);
					text = Messages.frmErrorInSendingFile;
				}
				else
				{
					Exception e3 = new Exception("خطا در ایجاد فولدر ftp,   -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = Messages.frmErrorInSendingFile;
				}
			}
			else
			{
				if (!CS_0024_003C_003E8__locals0.vm.OrderView.HasValue)
				{
					List<CRMspCmsSelectGalleryItems_Result> list4 = Enumerable.ToList<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)_db.CRMspCmsSelectGalleryItems(_003C_003Ec__DisplayClass14_.model.GalleryId, 0, "", "", lCID, CS_0024_003C_003E8__locals0.defLangID));
					int num3 = (Enumerable.Any<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list4) ? Enumerable.Count<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list4) : 0);
					_003C_003Ec__DisplayClass14_.model.OrderView = num3 * 10 + 10;
					if (Enumerable.LastOrDefault<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list4) != null)
					{
						int valueOrDefault = Enumerable.LastOrDefault<CRMspCmsSelectGalleryItems_Result>((IEnumerable<CRMspCmsSelectGalleryItems_Result>)list4).OrderView.GetValueOrDefault();
						if (valueOrDefault > 0)
						{
							_003C_003Ec__DisplayClass14_.model.OrderView = valueOrDefault + 10;
						}
					}
				}
				else
				{
					_003C_003Ec__DisplayClass14_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				}
				_003C_003Ec__DisplayClass14_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass14_.model.FirstRegisterDate = now;
				_003C_003Ec__DisplayClass14_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass14_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
				_003C_003Ec__DisplayClass14_.model.GUId = Guid.NewGuid();
				_dbTbl.CrmCmsGalleryItems.Add(_003C_003Ec__DisplayClass14_.model);
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
				{
					CrmCmsGalleryItems_Lang crmCmsGalleryItems_Lang3 = new CrmCmsGalleryItems_Lang();
					crmCmsGalleryItems_Lang3.LanguageID = lang.LanguageID;
					crmCmsGalleryItems_Lang3.GalleryItemId = _003C_003Ec__DisplayClass14_.model.GalleryItemId;
					crmCmsGalleryItems_Lang3.ItemTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					crmCmsGalleryItems_Lang3.ItemDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					crmCmsGalleryItems_Lang3.ItemLinkTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
					_dbTbl.CrmCmsGalleryItems_Lang.Add(crmCmsGalleryItems_Lang3);
					_dbTbl.SaveChanges();
				}
				if (_003C_003Ec__DisplayClass14_.model.GalleryItemId <= 0 || FileUrlUpload == null)
				{
					goto IL_180e;
				}
				string[] array2 = FileUrlUpload.FileName.Split(new char[1] { '.' });
				string text8 = _003C_003Ec__DisplayClass14_.model.GalleryId + "-" + _003C_003Ec__DisplayClass14_.model.GalleryItemId + "." + array2[^1];
				FacadeFTP facadeFTP2 = new FacadeFTP(Configuration.FacadeFtp);
				string pathFtp2 = Configuration.PathFtp;
				string userNameFtp2 = Configuration.UserNameFtp;
				string passwordFtp2 = Configuration.PasswordFtp;
				bool usePassiveFtp2 = Configuration.UsePassiveFtp;
				string mainDirectoryPath2 = Configuration.MainDirectoryPath;
				string cmsGalleryDirectoryPath2 = Configuration.CmsGalleryDirectoryPath;
				cmsGalleryDirectoryPath2 = (cmsGalleryDirectoryPath2.EndsWith("/") ? cmsGalleryDirectoryPath2.TrimEnd(new char[1] { '/' }) : cmsGalleryDirectoryPath2);
				bool flag3 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, mainDirectoryPath2, cmsGalleryDirectoryPath2, usePassiveFtp2);
				if (!flag3)
				{
					flag3 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, Configuration.MainDirectoryPath, cmsGalleryDirectoryPath2, usePassiveFtp2);
				}
				mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath;
				bool flag4 = facadeFTP2.ExistsDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, mainDirectoryPath2, _003C_003Ec__DisplayClass14_.model.GalleryId.ToString(), usePassiveFtp2);
				if (!flag4)
				{
					flag4 = facadeFTP2.CreateDirectoryInFtp(pathFtp2, userNameFtp2, passwordFtp2, mainDirectoryPath2, _003C_003Ec__DisplayClass14_.model.GalleryId.ToString(), usePassiveFtp2);
				}
				if (flag3 && flag4)
				{
					mainDirectoryPath2 = Configuration.MainDirectoryPath + Configuration.CmsGalleryDirectoryPath + _003C_003Ec__DisplayClass14_.model.GalleryId + "/";
					string text9 = mainDirectoryPath2;
					text9 = text9.Replace(Configuration.MainDirectoryPath, "/");
					text9 = base.Server.MapPath(text9);
					if (!System.IO.Directory.Exists(text9))
					{
						System.IO.Directory.CreateDirectory(text9);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
					}
					if (System.IO.Directory.Exists(text9))
					{
						string text10 = text9 + "Initial-" + text8;
						text9 += text8;
						if (System.IO.File.Exists(text9))
						{
							System.IO.File.Delete(text9);
						}
						FileUrlUpload.SaveAs(text10);
						if (System.IO.File.Exists(text10))
						{
							ImageManager.CompressFile(new ImageManager.ImageParam
							{
								FilePath = text10,
								DestPath = text9,
								CustomHeight = customHeight,
								CustomWidth = customWidth
							});
							ImageManager.DeleteFile(new ImageManager.ImageParam
							{
								FilePath = text10
							});
						}
					}
					if (!System.IO.File.Exists(text9))
					{
						goto IL_180e;
					}
					if (facadeFTP2.UploadFtpFormTable(pathFtp2, userNameFtp2, passwordFtp2, mainDirectoryPath2 + text8, text9, usePassiveFtp2))
					{
						_003C_003Ec__DisplayClass14_.model.FileName = text8;
						_003C_003Ec__DisplayClass14_.model.FilePath = mainDirectoryPath2 + text8;
						_dbTbl.Entry(_003C_003Ec__DisplayClass14_.model).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						string pathFtpFo2 = Configuration.PathFtpFo;
						string userNameFtpFo2 = Configuration.UserNameFtpFo;
						string passwordFtpFo2 = Configuration.PasswordFtpFo;
						_ = Configuration.UsePassiveFtpFo;
						if (!string.IsNullOrEmpty(pathFtpFo2) && !string.IsNullOrEmpty(userNameFtpFo2) && !string.IsNullOrEmpty(passwordFtpFo2))
						{
							try
							{
								string text11 = "/" + Configuration.CmsGalleryDirectoryPath + _003C_003Ec__DisplayClass14_.model.GalleryId;
								Files.UploadFileToFtp(pathFtpFo2, userNameFtpFo2, passwordFtpFo2, usePassiveFtp2, text11 + "/" + text8);
							}
							catch (Exception e4)
							{
								ErrorSignal.FromCurrentContext().Raise(e4);
							}
						}
						goto IL_180e;
					}
					Exception e5 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath2 + text8);
					ErrorSignal.FromCurrentContext().Raise(e5);
					text = Messages.frmErrorInSendingFile;
				}
				else
				{
					Exception e6 = new Exception("خطا در ایجاد فولدر ftp,   -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + mainDirectoryPath2);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = Messages.frmErrorInSendingFile;
				}
			}
			goto end_IL_0062;
			IL_1814:
			CS_0024_003C_003E8__locals0.vm.GalleryItemId = _003C_003Ec__DisplayClass14_.model.GalleryItemId;
			CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass14_.model.RegisterDate;
			CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass14_.model.UserId;
			CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass14_.model.FirstRegisterDate;
			CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass14_.model.FirstRegisterUserId;
			CS_0024_003C_003E8__locals0.vm.FilePath = _003C_003Ec__DisplayClass14_.model.FilePath;
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FilePath))
			{
				CS_0024_003C_003E8__locals0.vm.FilePath = CS_0024_003C_003E8__locals0.vm.FilePath.Replace(Configuration.MainDirectoryPath, "/");
				CS_0024_003C_003E8__locals0.vm.FilePath = CS_0024_003C_003E8__locals0.vm.FilePath;
			}
			base.ViewBag.Successfull = text;
			text = "";
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCmsGalleryItems");
			goto end_IL_0062;
			IL_10c1:
			text = Messages.frmFormBaseEditSuccessFulMessage;
			goto IL_1814;
			end_IL_0062:;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public ImageFormat SetImageFormat(string fileName)
	{
		ImageFormat result = ImageFormat.Png;
		if (string.IsNullOrEmpty(fileName))
		{
			return result;
		}
		string[] array = fileName.Split(new char[1] { '.' });
		if (Enumerable.Any<string>((IEnumerable<string>)array) && array.Length == 2)
		{
			switch (array[1].ToLower())
			{
			case "jpeg":
			case "jpg":
				result = ImageFormat.Jpeg;
				break;
			case "png":
				result = ImageFormat.Png;
				break;
			case "gif":
				result = ImageFormat.Gif;
				break;
			case "tiff":
				result = ImageFormat.Tiff;
				break;
			case "bmp":
				result = ImageFormat.Bmp;
				break;
			default:
				result = ImageFormat.Png;
				break;
			}
		}
		return result;
	}

	public static bool ResizeImage(string orgFile, string resizedFile, ImageFormat format, int width, int height)
	{
		//IL_000b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0010: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		//IL_001b: Expected O, but got Unknown
		//IL_003d: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			Image val = Image.FromFile(orgFile);
			try
			{
				Bitmap val2 = new Bitmap(width, height, val.PixelFormat);
				Graphics obj = Graphics.FromImage((Image)val2);
				obj.CompositingQuality = (CompositingQuality)2;
				obj.SmoothingMode = (SmoothingMode)2;
				obj.InterpolationMode = (InterpolationMode)7;
				Rectangle val3 = default(Rectangle);
				((Rectangle)(ref val3))._002Ector(0, 0, width, height);
				obj.DrawImage(val, val3);
				((Image)val2).Save(resizedFile, format);
			}
			finally
			{
				((IDisposable)val)?.Dispose();
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	[AjaxOnly]
	public JsonResult GetEffect()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsGalleryGalleryEffectSlideTxt,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsGalleryGalleryEffectFadeTxt,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.EffectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTargetMode()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			SelectListItem item = new SelectListItem
			{
				Text = Labels.CmsTargetSelfMode,
				Value = "1",
				Selected = false
			};
			list.Add(item);
			item = new SelectListItem
			{
				Text = Labels.CmsTargetBlankMode,
				Value = "2",
				Selected = false
			};
			list.Add(item);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TargetModeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCmsDefineGallerySlideDataEntry", ActionName = "actDeletePicture")]
	public string DeleteGalleryItemPicture(int galleryItemId)
	{
		_003C_003Ec__DisplayClass19_0 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_0();
		_003C_003Ec__DisplayClass19_.galleryItemId = galleryItemId;
		string result = "";
		if (!UserLogin.IsUserAccess("frmCmsDefineGallerySlideDataEntry", "actDeletePicture", UserLogin.CurrentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DbSet<CrmCmsGalleryItems> crmCmsGalleryItems = _dbTbl.CrmCmsGalleryItems;
			ParameterExpression val = Expression.Parameter(typeof(CrmCmsGalleryItems), "c");
			CrmCmsGalleryItems crmCmsGalleryItems2 = Queryable.FirstOrDefault<CrmCmsGalleryItems>((IQueryable<CrmCmsGalleryItems>)crmCmsGalleryItems, Expression.Lambda<Func<CrmCmsGalleryItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCmsGalleryItems2 == null)
			{
				return Messages.DoNotHaveAccess;
			}
			if (string.IsNullOrWhiteSpace(crmCmsGalleryItems2.FilePath))
			{
				return Messages.msgErrorNotFilePath;
			}
			string text = crmCmsGalleryItems2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
			if (text.IndexOf(Configuration.MainDirectoryPath.ToLower()) < 0)
			{
				if (text.StartsWith("/"))
				{
					text = text.TrimStart(new char[1] { '/' });
				}
				text = Configuration.MainDirectoryPath + text;
			}
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string destination = text;
			if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, crmCmsGalleryItems2.FileName, destination, Configuration.UsePassiveFtp))
			{
				string text2 = crmCmsGalleryItems2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "").Replace(Configuration.MainDirectoryPath.ToLower(), "");
				string text3 = "/" + text2;
				string path = HttpContext.Current.Server.MapPath(text3);
				if (System.IO.File.Exists(path) && crmCmsGalleryItems2.FileName.IndexOf(".") > 0)
				{
					System.IO.File.Delete(path);
					string text4 = text3;
					text4 = text4.Insert(text3.IndexOf("."), "-Thumb");
					string path2 = HttpContext.Current.Server.MapPath(text4);
					if (System.IO.File.Exists(path2))
					{
						System.IO.File.Delete(path2);
					}
				}
				DeleteOldGalleryFromFtp(crmCmsGalleryItems2.FilePath);
				crmCmsGalleryItems2.UserId = UserLogin.CurrentUser.UserId;
				DateTime dateTime = (crmCmsGalleryItems2.RegisterDate = DateTime.Now);
				crmCmsGalleryItems2.RegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
				crmCmsGalleryItems2.Month1 = short.Parse(dateTime.ToString("MM", new PersianCulture()));
				crmCmsGalleryItems2.AppType = Configuration.AppType;
				crmCmsGalleryItems2.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmCmsGalleryItems2.FileName = null;
				crmCmsGalleryItems2.FolderName = null;
				crmCmsGalleryItems2.FilePath = null;
				_dbTbl.Entry(crmCmsGalleryItems2).State = EntityState.Modified;
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				result = "";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	public void DeleteOldGalleryFromFtp(string filePath)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			new FilesManager();
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			_ = Configuration.UsePassiveFtp;
			bool flag = !string.IsNullOrEmpty(pathFtp) && !string.IsNullOrEmpty(userNameFtp) && !string.IsNullOrEmpty(passwordFtp);
			string pathFtpFo = Configuration.PathFtpFo;
			string userNameFtpFo = Configuration.UserNameFtpFo;
			string passwordFtpFo = Configuration.PasswordFtpFo;
			bool usePassiveFtpFo = Configuration.UsePassiveFtpFo;
			bool flag2 = !string.IsNullOrEmpty(pathFtpFo) && !string.IsNullOrEmpty(userNameFtpFo) && !string.IsNullOrEmpty(passwordFtpFo);
			string text = "";
			string[] array = filePath.Split(new char[1] { '/' });
			if (array != null && array.Length != 0)
			{
				text = array[^1];
			}
			if (string.IsNullOrWhiteSpace(filePath) || string.IsNullOrWhiteSpace(text))
			{
				return;
			}
			if (flag)
			{
				new FacadeFTP(Configuration.FacadeFtp);
				filePath.ToLower();
				string text2 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
				text2 = text2.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
				text2 = text2;
				text2 = base.Server.MapPath(text2);
				if (System.IO.File.Exists(text2))
				{
					System.IO.File.Delete(text2);
				}
				if (!string.IsNullOrWhiteSpace(text))
				{
					string text3 = "";
					string[] array2 = text.Split(new char[1] { '.' });
					if (array2 != null && array2.Length != 0)
					{
						text3 = text.Replace("." + array2[^1], "");
						text3 = text3 + "-Thumb." + array2[^1];
					}
					if (!string.IsNullOrWhiteSpace(text3))
					{
						string text4 = text2;
						text4 = text4.Replace(text, text3);
						if (System.IO.File.Exists(text4))
						{
							System.IO.File.Delete(text4);
						}
					}
				}
			}
			if (!flag2)
			{
				return;
			}
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtpFo);
			string text5 = filePath.ToLower().Replace(pathFtp.ToLower(), "");
			text5 = text5.Replace(Configuration.MainDirectoryPath.ToLower(), "/");
			text5 = text5;
			text5 = text5.Replace("~", "").ToLower();
			facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text, text5, usePassiveFtpFo);
			if (!string.IsNullOrWhiteSpace(text))
			{
				string text6 = "";
				string[] array3 = text.Split(new char[1] { '.' });
				if (array3 != null && array3.Length != 0)
				{
					text6 = text.Replace("." + array3[^1], "");
					text6 = text6 + "-Thumb." + array3[^1];
				}
				if (!string.IsNullOrWhiteSpace(text6))
				{
					string text7 = text5;
					text7 = text7.Replace(text, text6);
					facadeFTP.Delete(pathFtpFo, userNameFtpFo, passwordFtpFo, text6, text7, usePassiveFtpFo);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
