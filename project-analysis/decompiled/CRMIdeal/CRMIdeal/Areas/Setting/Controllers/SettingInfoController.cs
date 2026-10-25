using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache;
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

namespace CRMIdeal.Areas.Setting.Controllers;

public class SettingInfoController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_1
	{
		public CRMspSelectCrmsysSetting_Result coSettingfromCache;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public int defLangID;

		public CrmsysSettingLanguageViewModel model;

		public Func<Languages, bool> _003C_003E9__20;

		internal bool _003CSysSettingEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CSysSettingEdit_003Eb__20(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals1;

		internal bool _003CSysSettingEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CSysSettingEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public void SetRegisterInfoSysSetting(CRMspSelectCrmsysSetting_Result model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds((model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId) + "," + (model.UserId.HasValue ? model.UserId : new int?(UserLogin.CurrentUser.UserId)));
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				model.UserId = (model.UserId.HasValue ? model.UserId : new int?(UserLogin.CurrentUser.UserId));
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text5 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			string text6 = (model.RegisterDate.HasValue ? model.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text7 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text5 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text7 + ") (" + text6 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)db.CRMspSelectCrmsysSetting(lCID, result)));
		SetRegisterInfoSysSetting(cRMspSelectCrmsysSetting_Result);
		return View(cRMspSelectCrmsysSetting_Result);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineTimeAttendanceBase")]
	public ActionResult DefineTimeAttendanceBase()
	{
		return View();
	}

	public ActionResult _PartialDefineTimeAttendanceBase()
	{
		return PartialView();
	}

	public ActionResult TimeAttendanceBase_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<CrmTimeAttendanceBaseViewModel> list = new List<CrmTimeAttendanceBaseViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DbSet<CrmTimeAttendanceBase> crmTimeAttendanceBase = _dbTbl.CrmTimeAttendanceBase;
			ParameterExpression val = Expression.Parameter(typeof(CrmTimeAttendanceBase), "c");
			List<CrmTimeAttendanceBase> list2 = Enumerable.ToList<CrmTimeAttendanceBase>((IEnumerable<CrmTimeAttendanceBase>)Queryable.OrderBy<CrmTimeAttendanceBase, int>((IQueryable<CrmTimeAttendanceBase>)crmTimeAttendanceBase, Expression.Lambda<Func<CrmTimeAttendanceBase, int>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			List<CRMspSelectUsers_Result> list3 = CRMIdeal.Classes.Helper.User.SelectUsers(0);
			foreach (CrmTimeAttendanceBase item in list2)
			{
				CrmTimeAttendanceBaseViewModel crmTimeAttendanceBaseViewModel = new CrmTimeAttendanceBaseViewModel();
				crmTimeAttendanceBaseViewModel.TimeAttendanceBaseId = item.TimeAttendanceBaseId;
				crmTimeAttendanceBaseViewModel.tmbDay = item.tmbDay;
				crmTimeAttendanceBaseViewModel.tmbDayTitle = DateTimeClass.ConvertNumToDayeOfWeek(item.tmbDay);
				crmTimeAttendanceBaseViewModel.tmbEntryBase = item.tmbEntryBase;
				crmTimeAttendanceBaseViewModel.tmbEntryAllowMin = item.tmbEntryAllowMin;
				crmTimeAttendanceBaseViewModel.tmbExitBase = item.tmbExitBase;
				crmTimeAttendanceBaseViewModel.tmbExitAllowMin = item.tmbExitAllowMin;
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				crmTimeAttendanceBaseViewModel.AppType = Configuration.GetAppType(item.AppType);
				CRMspSelectUsers_Result cRMspSelectUsers_Result = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.FirstRegisterUserId));
				string text = ((cRMspSelectUsers_Result != null) ? (cRMspSelectUsers_Result.LName + ((cRMspSelectUsers_Result.FName != null) ? (" " + cRMspSelectUsers_Result.FName) : "")) : "");
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				crmTimeAttendanceBaseViewModel.FirstRegisterDatePersian = text + " (" + text2 + ")";
				CRMspSelectUsers_Result cRMspSelectUsers_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)list3, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result c) => c.UserId == item.UserId));
				string text3 = ((cRMspSelectUsers_Result2 != null) ? (cRMspSelectUsers_Result2.LName + ((cRMspSelectUsers_Result2.FName != null) ? (" " + cRMspSelectUsers_Result2.FName) : "")) : "");
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				crmTimeAttendanceBaseViewModel.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + crmTimeAttendanceBaseViewModel.AppType + ")  (" + text4 + ")";
				list.Add(crmTimeAttendanceBaseViewModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request));
	}

	[DynamicAuthorize(ControllerName = "frmDefineTimeAttendanceBase", ActionName = "actEdit")]
	public ActionResult DefineTimeAttendanceBaseEdit(int tmpId)
	{
		CrmTimeAttendanceBase crmTimeAttendanceBase = _dbTbl.CrmTimeAttendanceBase.Find(tmpId);
		if (crmTimeAttendanceBase == null)
		{
			crmTimeAttendanceBase = new CrmTimeAttendanceBase
			{
				UserId = UserLogin.CurrentUser.UserId,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
				RegisterDate = DateTime.Now,
				RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd"),
				FirstRegisterDate = DateTime.Now,
				TimeAttendanceBaseId = tmpId
			};
		}
		return View(crmTimeAttendanceBase);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineTimeAttendanceBase", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult DefineTimeAttendanceBaseEdit(CrmTimeAttendanceBase tmp)
	{
		string text = "";
		int countError = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				text = ChkBeforeSubmitTaBase(tmp, ref countError);
				if (countError == 0)
				{
					DateTime now = DateTime.Now;
					tmp.UserId = UserLogin.CurrentUser.UserId;
					tmp.RegisterDate = now;
					tmp.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					tmp.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					tmp.AppType = Configuration.AppType;
					_dbTbl.Entry(tmp).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmTimeAttendanceBase");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.Error = text;
		return View(tmp);
	}

	public string ChkBeforeSubmitTaBase(CrmTimeAttendanceBase tmp, ref int countError)
	{
		string text = "";
		DateTime result;
		if (string.IsNullOrEmpty(tmp.tmbEntryBase))
		{
			text = text + Messages.CheckTmbEntryBase + "<\\br>";
			countError++;
		}
		else if (!DateTime.TryParseExact(tmp.tmbEntryBase, "HH:mm:ss", new CultureInfo("fr-FR"), DateTimeStyles.None, out result))
		{
			text = text + Messages.CheckTmbEntryBaseFormat + "<\\br>";
			countError++;
		}
		DateTime result2;
		if (string.IsNullOrEmpty(tmp.tmbExitBase))
		{
			text = text + Messages.CheckTmbExitBase + "<\\br>";
			countError++;
		}
		else if (!DateTime.TryParseExact(tmp.tmbExitBase, "HH:mm:ss", new CultureInfo("fr-FR"), DateTimeStyles.None, out result2))
		{
			text = text + Messages.CheckTmbExitBaseFormat + "<\\br>";
			countError++;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actInsertPicture")]
	public ActionResult CoLogoUpload()
	{
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		CrmSysSettingViewModel crmSysSettingViewModel = new CrmSysSettingViewModel();
		crmSysSettingViewModel.ID = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			crmSysSettingViewModel.ID = cRMspSelectCrmsysSetting_Result.ID;
			if (cRMspSelectCrmsysSetting_Result.CoLoGo == null)
			{
				base.ViewBag.HasLoGo = false;
			}
			else
			{
				base.ViewBag.HasLoGo = true;
			}
		}
		base.ViewBag.Update = false;
		return View(crmSysSettingViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult CoLogoUpload(CrmSysSettingViewModel Pic, HttpPostedFileBase CoLogoUrlUpload)
	{
		if (base.ModelState.IsValid)
		{
			try
			{
				if (CoLogoUrlUpload == null)
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotFileSelected);
					return View(Pic);
				}
				string text = CoLogoUrlUpload.ContentType.ToLower();
				string text2 = Path.GetExtension(CoLogoUrlUpload.FileName).ToLower();
				if ((text != "image/jpg" && text != "image/jpeg" && text != "image/pjpeg" && text != "image/gif" && text != "image/x-png" && text != "image/png") || (text2 != ".jpg" && text2 != ".png" && text2 != ".gif" && text2 != ".jpeg"))
				{
					base.ModelState.AddModelError("error", Messages.frmErrorNotImageFile);
					return View(Pic);
				}
				if (CoLogoUrlUpload.ContentLength / 1024 > Configuration.MaxImageSizeForUploadKb)
				{
					base.ModelState.AddModelError("error", string.Format(Messages.frmErrorMaxImageSizeForUpload, Configuration.MaxImageSizeForUploadKb));
					return View(Pic);
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				CrmsysSetting crmsysSetting = _dbTbl.CrmsysSetting.Find(cRMspSelectCrmsysSetting_Result.ID);
				if (crmsysSetting != null)
				{
					crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmsysSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					crmsysSetting.RegisterDate = DateTime.Now;
					crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
					crmsysSetting.CoLoGo = ImageManager.CompressHttpPostedFileBase(new ImageManager.ImageParam
					{
						HttpPostedFileBase_Var = CoLogoUrlUpload
					});
					crmsysSetting.AppType = Configuration.AppType;
					_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SysSeting.Update();
					if (crmsysSetting.CoLoGo == null)
					{
						base.ViewBag.HasLoGo = false;
					}
					else
					{
						base.ViewBag.HasLoGo = true;
					}
					base.ViewBag.Update = true;
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
				}
				else
				{
					base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
			}
		}
		return View(Pic);
	}

	[AjaxOnly]
	public string DeleteCoLogoFile()
	{
		string result = "0";
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		CrmsysSetting crmsysSetting = _dbTbl.CrmsysSetting.Find(cRMspSelectCrmsysSetting_Result.ID);
		if (crmsysSetting != null)
		{
			crmsysSetting.CoLoGo = null;
			crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
			crmsysSetting.RegisterDate = DateTime.Now;
			crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
			crmsysSetting.Month1 = short.Parse(DateTime.Now.ToString("MM"));
			crmsysSetting.AppType = Configuration.AppType;
			_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
			_dbTbl.SaveChanges();
			result = "1";
			SysSeting.Update();
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult SysSettingEdit()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
		GetConversationTopics();
		GetStsupVerificationWorkFlow();
		GetStsupVerifierRequest();
		GetRolls();
		CrmsysSettingLanguageViewModel crmsysSettingLanguageViewModel = new CrmsysSettingLanguageViewModel();
		try
		{
			_003C_003Ec__DisplayClass15_1 _003C_003Ec__DisplayClass15_ = new _003C_003Ec__DisplayClass15_1();
			CrmsysSetting crmsysSetting = new CrmsysSetting();
			_003C_003Ec__DisplayClass15_.coSettingfromCache = SysSeting.Get();
			if (_003C_003Ec__DisplayClass15_.coSettingfromCache != null)
			{
				DbSet<CrmsysSetting> crmsysSetting2 = _dbTbl.CrmsysSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting), "m");
				crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)crmsysSetting2, Expression.Lambda<Func<CrmsysSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass15_, typeof(_003C_003Ec__DisplayClass15_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			}
			else
			{
				crmsysSetting = new CrmsysSetting
				{
					UserId = UserLogin.CurrentUser.UserId,
					Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
					Year1 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture())),
					RegisterDate = DateTime.Now,
					ID = 0
				};
			}
			if (crmsysSetting == null)
			{
				crmsysSetting = new CrmsysSetting
				{
					UserId = UserLogin.CurrentUser.UserId,
					Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture())),
					Year1 = short.Parse(DateTime.Now.ToString("yyyy", new PersianCulture())),
					RegisterDate = DateTime.Now,
					ID = 0
				};
			}
			base.ViewBag.TimeAttendanceRecTempVerifyUsers = GetUsersName(crmsysSetting.TimeAttendanceRecTempVerifyUserIds);
			base.ViewBag.TimeAttendanceRecTempExpiredDatePersian = crmsysSetting.TimeAttendanceRecTempExpirDate?.ToString("yyyy/MM/dd");
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.CoName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.CoName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Address,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.Address,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PublicNotice,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.PublicNotice,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.QuickAddress,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.QuickAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.MuBuySaleWhTitle,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.MuBuySaleWhTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SaleOrderLbl,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.SaleOrderLbl,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.SaleReturnOrderLbl,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.SaleReturnOrderLbl,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.PrjPostFixTooltip,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.PrjPostFixTooltip,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.DyFormCartablesLbl,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = crmsysSetting.DyFormCartablesLbl,
				LanguageId = result
			});
			crmsysSettingLanguageViewModel = new CrmsysSettingLanguageViewModel
			{
				LanguageID = currLangID,
				UserId = crmsysSetting.UserId,
				AppType = crmsysSetting.AppType,
				FirstRegisterUserId = crmsysSetting.FirstRegisterUserId,
				FirstRegisterDate = crmsysSetting.FirstRegisterDate,
				FirstRegisterDatePersian = crmsysSetting.FirstRegisterDatePersian,
				GUId = crmsysSetting.GUId,
				RegisterDate = crmsysSetting.RegisterDate,
				Year1 = crmsysSetting.Year1,
				DefaultLanguageID = crmsysSetting.DefaultLanguageID,
				ID = crmsysSetting.ID,
				Month1 = crmsysSetting.Month1,
				AppFilePath = crmsysSetting.AppFilePath,
				CallerIDOldVersion = crmsysSetting.CallerIDOldVersion,
				CallerIDServerIP = crmsysSetting.CallerIDServerIP,
				CallerIDVersion = crmsysSetting.CallerIDVersion,
				CantSaveDupPrsEmail = crmsysSetting.CantSaveDupPrsEmail,
				Email = crmsysSetting.Email,
				Fax = crmsysSetting.Fax,
				CantSaveDupPrsMob = crmsysSetting.CantSaveDupPrsMob,
				CoLoGo = crmsysSetting.CoLoGo,
				DisablefrmcmpSearchOnType = crmsysSetting.DisablefrmcmpSearchOnType,
				NationalCode = crmsysSetting.NationalCode,
				ZipCode = crmsysSetting.ZipCode,
				EconomicCode = crmsysSetting.EconomicCode,
				LockNU = crmsysSetting.LockNU,
				MustFullcnvsRemindDate = crmsysSetting.MustFullcnvsRemindDate,
				LockControl = crmsysSetting.LockControl,
				LockCounter = crmsysSetting.LockCounter,
				LockSerial = crmsysSetting.LockSerial,
				RecordingVoiceServerIP = crmsysSetting.RecordingVoiceServerIP,
				RegistrationNumber = crmsysSetting.RegistrationNumber,
				SMSGSMServiceOldVersion = crmsysSetting.SMSGSMServiceOldVersion,
				SMSGSMServiceVersion = crmsysSetting.SMSGSMServiceVersion,
				SMSServiceOldVersion = crmsysSetting.SMSServiceOldVersion,
				SMSServiceVersion = crmsysSetting.SMSServiceVersion,
				SantralPreNumber = crmsysSetting.SantralPreNumber,
				ServerIP = crmsysSetting.ServerIP,
				ServiceBuyOrdIP = crmsysSetting.ServiceBuyOrdIP,
				ServiceCIIP = crmsysSetting.ServiceCIIP,
				ServiceEmailIP = crmsysSetting.ServiceEmailIP,
				ServiceFADeAc = crmsysSetting.ServiceFADeAc,
				WebSite = crmsysSetting.WebSite,
				ServiceSGIP = crmsysSetting.ServiceSGIP,
				ServiceSIP = crmsysSetting.ServiceSIP,
				Telephone = crmsysSetting.Telephone,
				ServiceRIP = crmsysSetting.ServiceRIP,
				ServiceLetterIP = crmsysSetting.ServiceLetterIP,
				CoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				PublicNotice = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				QuickAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				CoName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				Address_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				QuickAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				PublicNotice_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				FOUrl = crmsysSetting.FOUrl,
				CrmIPStatic = crmsysSetting.CrmIPStatic,
				CrmSysInternalDomain = crmsysSetting.CrmSysInternalDomain,
				PrdBarcodeFormula = crmsysSetting.PrdBarcodeFormula,
				InvStockFromLink = crmsysSetting.InvStockFromLink,
				CmpAccFromLink = crmsysSetting.CmpAccFromLink,
				PrdPriceFromLink = crmsysSetting.PrdPriceFromLink,
				DefCmpCityId = crmsysSetting.DefCmpCityId,
				DefAnswerCnvsTopicId = crmsysSetting.DefAnswerCnvsTopicId,
				DefCallCnvsTopicId = crmsysSetting.DefCallCnvsTopicId,
				CanUseDupTracing = crmsysSetting.CanUseDupTracing,
				AddTracingCodeFromSerial = crmsysSetting.AddTracingCodeFromSerial,
				MustFullTracingCode = crmsysSetting.MustFullTracingCode,
				FullDiscountPerWithRateInAdd = crmsysSetting.FullDiscountPerWithRateInAdd,
				CoLatitude = crmsysSetting.CoLatitude,
				CoLongitude = crmsysSetting.CoLongitude,
				CoZoom = crmsysSetting.CoZoom,
				CheckLocForScanQR = crmsysSetting.CheckLocForScanQR,
				UserLoginAccessDistance = crmsysSetting.UserLoginAccessDistance,
				CoLocations = crmsysSetting.CoLocations,
				SmartTimeAttendance = crmsysSetting.SmartTimeAttendance,
				NotShowMenuNotModule = crmsysSetting.NotShowMenuNotModule,
				PrjPostFixRegEx = crmsysSetting.PrjPostFixRegEx,
				CmpQuickRegDefCmpKind = crmsysSetting.CmpQuickRegDefCmpKind,
				MuBuySaleWhTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				MuBuySaleWhTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				SaleOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				SaleOrderLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				SaleReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				SaleReturnOrderLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				PrjPostFixTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				PrjPostFixTooltip_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				DyFormCartablesLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : ""),
				DyFormCartablesLbl_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID)))),
				CheckLocForScanQRInMission = crmsysSetting.CheckLocForScanQRInMission,
				PwaServerUrl = crmsysSetting.PwaServerUrl,
				UserLoginAccessTimeDiffInMission = crmsysSetting.UserLoginAccessTimeDiffInMission,
				TaxableOrderOprIds = crmsysSetting.TaxableOrderOprIds,
				stsupDefVerificationWorkFlowId = crmsysSetting.stsupDefVerificationWorkFlowId,
				stsupDefVerifierRequestId = crmsysSetting.stsupDefVerifierRequestId,
				PriceRoundType = crmsysSetting.PriceRoundType,
				ApiDomain = crmsysSetting.ApiDomain,
				ProvincePreCode = crmsysSetting.ProvincePreCode,
				CityId = crmsysSetting.CityId,
				TimeAttendanceRecIsTemp = crmsysSetting.TimeAttendanceRecIsTemp,
				TimeAttendanceRecTempVerifyUserIds = crmsysSetting.TimeAttendanceRecTempVerifyUserIds,
				TimeAttendanceRecTempVerifyRollId = crmsysSetting.TimeAttendanceRecTempVerifyRollId,
				TimeAttendanceRecTempExpirDate = crmsysSetting.TimeAttendanceRecTempExpirDate,
				AIDomain = crmsysSetting.AIDomain,
				LoginAuthUrl = crmsysSetting.LoginAuthUrl,
				IsActiveJobSmsSend = crmsysSetting.IsActiveJobSmsSend,
				IsActiveJobSmsReceive = crmsysSetting.IsActiveJobSmsReceive,
				IsActiveJobEmailSend = crmsysSetting.IsActiveJobEmailSend,
				IsActiveJobEmailReceive = crmsysSetting.IsActiveJobEmailReceive,
				IsActiveJobSendCongratulate = crmsysSetting.IsActiveJobSendCongratulate,
				IsActiveJobControlTicketAlert = crmsysSetting.IsActiveJobControlTicketAlert,
				IsActiveJobTicketAutoClose = crmsysSetting.IsActiveJobTicketAutoClose
			};
			if (crmsysSettingLanguageViewModel != null && !string.IsNullOrWhiteSpace(crmsysSettingLanguageViewModel.TaxableOrderOprIds))
			{
				List<WSspSelectOrderOprByIds_Result> list11 = Enumerable.ToList<WSspSelectOrderOprByIds_Result>((IEnumerable<WSspSelectOrderOprByIds_Result>)_dbI.WSspSelectOrderOprByIds(crmsysSettingLanguageViewModel.TaxableOrderOprIds, currLangID, result));
				if (list11 != null && Enumerable.Any<WSspSelectOrderOprByIds_Result>((IEnumerable<WSspSelectOrderOprByIds_Result>)list11))
				{
					List<CommonMultiAndIdLanguageViewModel> list12 = new List<CommonMultiAndIdLanguageViewModel>();
					foreach (WSspSelectOrderOprByIds_Result item3 in list11)
					{
						CommonMultiAndIdLanguageViewModel item2 = new CommonMultiAndIdLanguageViewModel
						{
							Id = item3.OrderOprID,
							Value = (item3.Name ?? "")
						};
						list12.Add(item2);
					}
					if (list12 != null && Enumerable.Any<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list12))
					{
						crmsysSettingLanguageViewModel.TaxableOrderOrdJson = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiAndIdLanguageViewModel>((IEnumerable<CommonMultiAndIdLanguageViewModel>)list12));
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmsysSettingLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult SysSettingEdit(CrmsysSettingLanguageViewModel model)
	{
		//IL_01bf: Unknown result type (might be due to invalid IL or missing references)
		//IL_0213: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Unknown result type (might be due to invalid IL or missing references)
		//IL_02bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_030f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0363: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_040b: Unknown result type (might be due to invalid IL or missing references)
		//IL_045f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetConversationTopics();
		GetStsupVerificationWorkFlow();
		GetStsupVerifierRequest();
		GetRolls();
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.FOUrl) && !CS_0024_003C_003E8__locals0.model.FOUrl.ToLower().Trim().StartsWith("http"))
		{
			text = string.Format(Messages.msgErrorHttpRequired, Labels.FOUrl);
		}
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.CrmIPStatic) && !CS_0024_003C_003E8__locals0.model.CrmIPStatic.ToLower().Trim().StartsWith("http"))
		{
			text = string.Format(Messages.msgErrorHttpRequired, Labels.CrmIPStatic);
		}
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.ApiDomain) && !CS_0024_003C_003E8__locals0.model.ApiDomain.ToLower().Trim().StartsWith("http"))
		{
			text = string.Format(Messages.msgErrorHttpRequired, Labels.CrmSysSettingApiDomain);
		}
		if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.AIDomain) && !CS_0024_003C_003E8__locals0.model.AIDomain.ToLower().Trim().StartsWith("http"))
		{
			text = string.Format(Messages.msgErrorHttpRequired, Labels.CrmSysSettingAIDomain);
		}
		try
		{
			if (text == "")
			{
				if (base.ModelState.IsValid)
				{
					List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.CoName_Lang))
					{
						list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.CoName_Lang);
					}
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.CoName,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Address_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Address_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.Address,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PublicNotice_Lang))
					{
						list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PublicNotice_Lang);
					}
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.PublicNotice,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.QuickAddress_Lang))
					{
						list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.QuickAddress_Lang);
					}
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.QuickAddress,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.MuBuySaleWhTitle_Lang))
					{
						list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.MuBuySaleWhTitle_Lang);
					}
					list5.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.MuBuySaleWhTitle,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SaleOrderLbl_Lang))
					{
						list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SaleOrderLbl_Lang);
					}
					list6.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.SaleOrderLbl,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SaleReturnOrderLbl_Lang))
					{
						list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SaleReturnOrderLbl_Lang);
					}
					list7.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.SaleReturnOrderLbl,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.PrjPostFixTooltip_Lang))
					{
						list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.PrjPostFixTooltip_Lang);
					}
					list8.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.PrjPostFixTooltip,
						LanguageId = lCID
					});
					List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DyFormCartablesLbl_Lang))
					{
						list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.DyFormCartablesLbl_Lang);
					}
					list9.Add(new CommonMultiLanguageViewModel
					{
						Value = CS_0024_003C_003E8__locals0.model.DyFormCartablesLbl,
						LanguageId = lCID
					});
					if (num == 0)
					{
						CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
						if (crmsysSetting != null)
						{
							crmsysSetting.FOUrl = CS_0024_003C_003E8__locals0.model.FOUrl;
							crmsysSetting.CrmIPStatic = CS_0024_003C_003E8__locals0.model.CrmIPStatic;
							crmsysSetting.CrmSysInternalDomain = CS_0024_003C_003E8__locals0.model.CrmSysInternalDomain;
							crmsysSetting.PrdBarcodeFormula = CS_0024_003C_003E8__locals0.model.PrdBarcodeFormula;
							crmsysSetting.InvStockFromLink = CS_0024_003C_003E8__locals0.model.InvStockFromLink;
							crmsysSetting.CmpAccFromLink = CS_0024_003C_003E8__locals0.model.CmpAccFromLink;
							crmsysSetting.CanUseDupTracing = CS_0024_003C_003E8__locals0.model.CanUseDupTracing;
							crmsysSetting.AddTracingCodeFromSerial = CS_0024_003C_003E8__locals0.model.AddTracingCodeFromSerial;
							crmsysSetting.MustFullTracingCode = CS_0024_003C_003E8__locals0.model.MustFullTracingCode;
							crmsysSetting.FullDiscountPerWithRateInAdd = CS_0024_003C_003E8__locals0.model.FullDiscountPerWithRateInAdd;
							crmsysSetting.DefCmpCityId = CS_0024_003C_003E8__locals0.model.DefCmpCityId;
							crmsysSetting.DefAnswerCnvsTopicId = CS_0024_003C_003E8__locals0.model.DefAnswerCnvsTopicId;
							crmsysSetting.DefCallCnvsTopicId = CS_0024_003C_003E8__locals0.model.DefCallCnvsTopicId;
							crmsysSetting.PrdPriceFromLink = CS_0024_003C_003E8__locals0.model.PrdPriceFromLink;
							crmsysSetting.Telephone = CS_0024_003C_003E8__locals0.model.Telephone;
							crmsysSetting.Fax = CS_0024_003C_003E8__locals0.model.Fax;
							crmsysSetting.Email = CS_0024_003C_003E8__locals0.model.Email;
							crmsysSetting.WebSite = CS_0024_003C_003E8__locals0.model.WebSite;
							crmsysSetting.RegistrationNumber = CS_0024_003C_003E8__locals0.model.RegistrationNumber;
							crmsysSetting.EconomicCode = CS_0024_003C_003E8__locals0.model.EconomicCode;
							crmsysSetting.NationalCode = CS_0024_003C_003E8__locals0.model.NationalCode;
							crmsysSetting.ZipCode = CS_0024_003C_003E8__locals0.model.ZipCode;
							crmsysSetting.SantralPreNumber = CS_0024_003C_003E8__locals0.model.SantralPreNumber;
							crmsysSetting.AppFilePath = CS_0024_003C_003E8__locals0.model.AppFilePath;
							crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
							crmsysSetting.RegisterDate = DateTime.Now;
							crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmsysSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
							crmsysSetting.AppType = Configuration.AppType;
							crmsysSetting.CoLatitude = CS_0024_003C_003E8__locals0.model.CoLatitude;
							crmsysSetting.CoLongitude = CS_0024_003C_003E8__locals0.model.CoLongitude;
							crmsysSetting.CoZoom = CS_0024_003C_003E8__locals0.model.CoZoom;
							crmsysSetting.CheckLocForScanQR = CS_0024_003C_003E8__locals0.model.CheckLocForScanQR;
							crmsysSetting.UserLoginAccessDistance = CS_0024_003C_003E8__locals0.model.UserLoginAccessDistance;
							if (VersionBuyer.SmartTimeAttendance)
							{
								crmsysSetting.SmartTimeAttendance = CS_0024_003C_003E8__locals0.model.SmartTimeAttendance;
							}
							crmsysSetting.Address = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.QuickAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.CoName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.PublicNotice = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.NotShowMenuNotModule = CS_0024_003C_003E8__locals0.model.NotShowMenuNotModule;
							crmsysSetting.PrjPostFixRegEx = CS_0024_003C_003E8__locals0.model.PrjPostFixRegEx;
							crmsysSetting.CmpQuickRegDefCmpKind = CS_0024_003C_003E8__locals0.model.CmpQuickRegDefCmpKind;
							crmsysSetting.MuBuySaleWhTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.SaleOrderLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.SaleReturnOrderLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.PrjPostFixTooltip = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.DyFormCartablesLbl = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmsysSetting.CheckLocForScanQRInMission = CS_0024_003C_003E8__locals0.model.CheckLocForScanQRInMission;
							crmsysSetting.PwaServerUrl = CS_0024_003C_003E8__locals0.model.PwaServerUrl;
							crmsysSetting.UserLoginAccessTimeDiffInMission = CS_0024_003C_003E8__locals0.model.UserLoginAccessTimeDiffInMission;
							crmsysSetting.TaxableOrderOprIds = CS_0024_003C_003E8__locals0.model.TaxableOrderOprIds;
							crmsysSetting.stsupDefVerificationWorkFlowId = CS_0024_003C_003E8__locals0.model.stsupDefVerificationWorkFlowId;
							crmsysSetting.stsupDefVerifierRequestId = CS_0024_003C_003E8__locals0.model.stsupDefVerifierRequestId;
							crmsysSetting.PriceRoundType = CS_0024_003C_003E8__locals0.model.PriceRoundType;
							crmsysSetting.ApiDomain = CS_0024_003C_003E8__locals0.model.ApiDomain;
							crmsysSetting.ProvincePreCode = CS_0024_003C_003E8__locals0.model.ProvincePreCode;
							crmsysSetting.AIDomain = CS_0024_003C_003E8__locals0.model.AIDomain;
							crmsysSetting.CityId = CS_0024_003C_003E8__locals0.model.CityId;
							crmsysSetting.TimeAttendanceRecIsTemp = CS_0024_003C_003E8__locals0.model.TimeAttendanceRecIsTemp;
							crmsysSetting.TimeAttendanceRecTempVerifyUserIds = CS_0024_003C_003E8__locals0.model.TimeAttendanceRecTempVerifyUserIds;
							crmsysSetting.TimeAttendanceRecTempVerifyRollId = CS_0024_003C_003E8__locals0.model.TimeAttendanceRecTempVerifyRollId;
							crmsysSetting.TimeAttendanceRecTempExpirDate = CS_0024_003C_003E8__locals0.model.TimeAttendanceRecTempExpirDate;
							crmsysSetting.IsActiveJobSmsSend = CS_0024_003C_003E8__locals0.model.IsActiveJobSmsSend;
							crmsysSetting.IsActiveJobSmsReceive = CS_0024_003C_003E8__locals0.model.IsActiveJobSmsReceive;
							crmsysSetting.IsActiveJobEmailSend = CS_0024_003C_003E8__locals0.model.IsActiveJobEmailSend;
							crmsysSetting.IsActiveJobEmailReceive = CS_0024_003C_003E8__locals0.model.IsActiveJobEmailReceive;
							crmsysSetting.IsActiveJobSendCongratulate = CS_0024_003C_003E8__locals0.model.IsActiveJobSendCongratulate;
							crmsysSetting.IsActiveJobControlTicketAlert = CS_0024_003C_003E8__locals0.model.IsActiveJobControlTicketAlert;
							crmsysSetting.IsActiveJobTicketAutoClose = CS_0024_003C_003E8__locals0.model.IsActiveJobTicketAutoClose;
							crmsysSetting.LoginAuthUrl = CS_0024_003C_003E8__locals0.model.LoginAuthUrl;
						}
						_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_1();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmsysSetting_Lang> crmsysSetting_Lang = _dbTbl.CrmsysSetting_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmsysSetting_Lang), "c");
								CrmsysSetting_Lang crmsysSetting_Lang2 = Queryable.FirstOrDefault<CrmsysSetting_Lang>((IQueryable<CrmsysSetting_Lang>)crmsysSetting_Lang, Expression.Lambda<Func<CrmsysSetting_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmsysSetting_Lang2 != null)
								{
									crmsysSetting_Lang2.Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.QuickAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.CoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.PublicNotice = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.MuBuySaleWhTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.SaleOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.SaleReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.PrjPostFixTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmsysSetting_Lang2.DyFormCartablesLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmsysSetting_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmsysSetting_Lang2 = new CrmsysSetting_Lang
								{
									Address = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									QuickAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									CoName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									PublicNotice = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									MuBuySaleWhTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									SaleOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									SaleReturnOrderLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									PrjPostFixTooltip = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									DyFormCartablesLbl = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									ID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.ID
								};
								_dbTbl.CrmsysSetting_Lang.Add(crmsysSetting_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
						if (!SysSeting.Update())
						{
							text = Messages.ErrorInCacheUpdate;
						}
						else
						{
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							CRMspSelectCrmsysSetting_Result registerInfoSysSetting = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)db.CRMspSelectCrmsysSetting(lCID, CS_0024_003C_003E8__locals0.defLangID)));
							SetRegisterInfoSysSetting(registerInfoSysSetting);
						}
					}
				}
				else
				{
					text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		base.ViewBag.Error = text;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetStsupVerificationWorkFlow()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectVerificationWorkFlowWithObjectType_Result> list2 = Enumerable.ToList<WSspSelectVerificationWorkFlowWithObjectType_Result>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)db.WSspSelectVerificationWorkFlowWithObjectType(45, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>((IEnumerable<WSspSelectVerificationWorkFlowWithObjectType_Result>)list2, (Func<WSspSelectVerificationWorkFlowWithObjectType_Result, SelectListItem>)((WSspSelectVerificationWorkFlowWithObjectType_Result item) => new SelectListItem
			{
				Text = item.VerificationWorkFlowTitle,
				Value = item.VerificationWorkFlowId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StsupVerificationWorkFlowList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetStsupVerifierRequest()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectStockSupplyVerifiers_Result> list2 = Enumerable.ToList<WSspSelectStockSupplyVerifiers_Result>((IEnumerable<WSspSelectStockSupplyVerifiers_Result>)_dbII.WSspSelectStockSupplyVerifiers(UserLogin.CurrentUser.UserId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectStockSupplyVerifiers_Result, SelectListItem>((IEnumerable<WSspSelectStockSupplyVerifiers_Result>)list2, (Func<WSspSelectStockSupplyVerifiers_Result, SelectListItem>)((WSspSelectStockSupplyVerifiers_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StsupVerifierRequestList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult WebSettingEdit()
	{
		dynamic viewBag = base.ViewBag;
		DbSet<CrmWebSetting> crmWebSetting = _dbTbl.CrmWebSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmWebSetting), "c");
		viewBag.ListSetting = Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)Queryable.Where<CrmWebSetting>((IQueryable<CrmWebSetting>)crmWebSetting, Expression.Lambda<Func<CrmWebSetting, bool>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		return View(new CrmWebSettingViewModel());
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult WebSettingEdit(CrmWebSettingViewModel model)
	{
		dynamic viewBag = base.ViewBag;
		DbSet<CrmWebSetting> crmWebSetting = _dbTbl.CrmWebSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmWebSetting), "c");
		viewBag.ListSetting = Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)Queryable.Where<CrmWebSetting>((IQueryable<CrmWebSetting>)crmWebSetting, Expression.Lambda<Func<CrmWebSetting, bool>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		try
		{
			if (base.ModelState.IsValid)
			{
				string[] array = model.AllSettings.Split(new char[1] { '|' });
				foreach (string text in array)
				{
					if (!(text != ""))
					{
						continue;
					}
					string[] array2 = text.Split(new char[1] { '^' });
					if (array2.Length == 2)
					{
						int.TryParse(array2[0], out var result);
						CrmWebSetting crmWebSetting2 = _dbTbl.CrmWebSetting.Find(result);
						if (crmWebSetting2 != null)
						{
							if (!crmWebSetting2.IsRequired || !(array2[1].Trim() == ""))
							{
								if (crmWebSetting2.IsDecoded)
								{
									if (crmWebSetting2.Key.ToLower().Contains("password") && crmWebSetting2.Type == "password")
									{
										string text2 = XorCipher.EncryptByPrivateKey(crmWebSetting2.Value);
										if (array2[1] != text2)
										{
											crmWebSetting2.Value = CodeDecode.Codding(array2[1]);
										}
									}
									else
									{
										crmWebSetting2.Value = CodeDecode.Codding(array2[1]);
									}
								}
								else
								{
									crmWebSetting2.Value = array2[1];
								}
								crmWebSetting2.UserId = UserLogin.CurrentUser.UserId;
								crmWebSetting2.RegisterDate = DateTime.Now;
								crmWebSetting2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								crmWebSetting2.Year1 = short.Parse(Financial.Get().Id.ToString());
								crmWebSetting2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
								crmWebSetting2.AppType = Configuration.AppType;
								_dbTbl.Entry(crmWebSetting2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							base.ViewBag.Error = $"فیلد [{crmWebSetting2.KeyFa}] نباید خالی باشد";
							return View(model);
						}
						base.ViewBag.Error = Messages.msgErrorInFindSetting;
						return View(model);
					}
					base.ViewBag.Error = Messages.msgErrorLackInfo;
					return View(model);
				}
				if (!Manager.UpdateAllSettingCach())
				{
					base.ViewBag.Error = Messages.ErrorInCacheUpdate;
					return View(model);
				}
				base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				List<CrmWebSetting> list = WebSetting.Get();
				string value = ApplicationSettings.GetValue("CacheDefaultName");
				if (value != null)
				{
					Configuration.CacheDefaultName = value;
				}
				CrmWebSetting crmWebSetting3 = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key == "CacheDefaultTimeInMinutes"));
				if (crmWebSetting3 != null)
				{
					int.TryParse(crmWebSetting3.IsDecoded ? CodeDecode.DeCodding(crmWebSetting3.Value) : crmWebSetting3.Value, out var result2);
					Configuration.CacheDefaultTimeInMinutes = result2;
				}
				string value2 = ApplicationSettings.GetValue("CacheUniqueName");
				if (value2 != null)
				{
					Configuration.CacheUniqueName = value2;
				}
				crmWebSetting3 = Enumerable.FirstOrDefault<CrmWebSetting>((IEnumerable<CrmWebSetting>)list, (Func<CrmWebSetting, bool>)((CrmWebSetting c) => c.Key == "MinimumTimeoutLoginInMin"));
				if (crmWebSetting3 != null)
				{
					int.TryParse(crmWebSetting3.IsDecoded ? CodeDecode.DeCodding(crmWebSetting3.Value) : crmWebSetting3.Value, out var result3);
					Configuration.MinimumTimeoutLoginInMin = result3;
				}
				string lockSerial = SysSeting.Get().LockSerial;
				if (!string.IsNullOrEmpty(lockSerial))
				{
					string[] array3 = CodeDecode.RegDeCodding(ApplicationSettings.GetValue("RegisterCode")).Split(new char[1] { '|' });
					if (CodeDecode.RegDeCodding(array3[0].Split(new char[1] { '@' })[1]) == lockSerial)
					{
						string text3 = CodeDecode.RegDeCodding(array3[0].Split(new char[1] { '@' })[0]);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							string[] array4 = text3.Split(new string[1] { "UsrMob" }, StringSplitOptions.None);
							if (array4 != null && array4.Length == 2)
							{
								text3 = array4[0];
								text3 = CodeDecode.RegDeCodding(text3);
							}
						}
						text3 = text3.Remove(text3.Length - 5);
						text3 = text3.Substring(6);
						int.TryParse(text3, out var result4);
						Configuration.MaxCountOfOnlineUser = result4;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		return View(model);
	}

	[AjaxOnly]
	public ActionResult _PartialWebSettingEdit()
	{
		dynamic viewBag = base.ViewBag;
		DbSet<CrmWebSetting> crmWebSetting = _dbTbl.CrmWebSetting;
		ParameterExpression val = Expression.Parameter(typeof(CrmWebSetting), "c");
		viewBag.ListSetting = Enumerable.ToList<CrmWebSetting>((IEnumerable<CrmWebSetting>)Queryable.Where<CrmWebSetting>((IQueryable<CrmWebSetting>)crmWebSetting, Expression.Lambda<Func<CrmWebSetting, bool>>((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		return PartialView();
	}

	public JsonResult GetCompanyCity(string value, int? cityId = 0)
	{
		List<mct_CRMspSelectUserAccessCompanyCity_Result> list = new List<mct_CRMspSelectUserAccessCompanyCity_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)db.mfi_CRMspSelectUserAccessCompanyCity(UserLogin.CurrentUser.UserId, value, lCID, result, result2));
			if (list != null && Enumerable.Any<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : ((cityId.HasValue && cityId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)) : ((!cityId.HasValue || cityId == 0) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, 600)) : Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), 600)))));
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[HttpPost]
	[LoginAuthorize]
	public List<mct_CRMspSelectUserAccessCompanyCity_Result> GetUserCity(string value, int? cityId = 0)
	{
		List<mct_CRMspSelectUserAccessCompanyCity_Result> result = new List<mct_CRMspSelectUserAccessCompanyCity_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			int num = 100;
			List<mct_CRMspSelectUserAccessCompanyCity_Result> list = Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)db.mfi_CRMspSelectUserAccessCompanyCity(UserLogin.CurrentUser.UserId, value, lCID, result2, result3));
			if (list != null && Enumerable.Any<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list))
			{
				list = ((!string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, num)) : ((cityId.HasValue && cityId != 0 && string.IsNullOrWhiteSpace(value)) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), num)) : ((!cityId.HasValue || cityId == 0) ? Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, num)) : Enumerable.ToList<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Take<mct_CRMspSelectUserAccessCompanyCity_Result>(Enumerable.Where<mct_CRMspSelectUserAccessCompanyCity_Result>((IEnumerable<mct_CRMspSelectUserAccessCompanyCity_Result>)list, (Func<mct_CRMspSelectUserAccessCompanyCity_Result, bool>)((mct_CRMspSelectUserAccessCompanyCity_Result m) => m.CityID == cityId)), num)))));
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetUserCityJson(string value, int? cityId = 0)
	{
		return JsonConvert.SerializeObject(GetUserCity(value, cityId));
	}

	[AjaxOnly]
	public JsonResult GetConversationTopics()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)db.CRMspSelectConversationTopics(lCID, result)), (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DefAnswerCnvsTopiclist = list;
		base.ViewBag.DefCallCnvsTopiclist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult SysSettingEditLocation(string lat = "", string lng = "", int zoom = 12)
	{
		base.ViewBag.Zoom = zoom;
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		foreach (Languages item in CRMIdeal.Cache.Setting.Language.Get())
		{
			if (item.LanguageID != lCID)
			{
				list.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = item.LanguageID
				});
			}
		}
		base.ViewBag.LangModel = JsonConvert.SerializeObject(list);
		base.ViewBag.AllowCopyLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		return View();
	}

	[HttpPost]
	public string getCoLocations()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string value = "";
		string value2 = "";
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)Enumerable.ToList<CRMspSelectCrmsysSetting_Result>((IEnumerable<CRMspSelectCrmsysSetting_Result>)db.CRMspSelectCrmsysSetting(currLangID, result)));
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			if ((currLangID != result) & (cRMspSelectCrmsysSetting_Result.CoLocations != null))
			{
				List<CrmSysSettingCoLocationViewModel> list = JsonConvert.DeserializeObject<List<CrmSysSettingCoLocationViewModel>>(cRMspSelectCrmsysSetting_Result.CoLocations);
				string value3 = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(cRMspSelectCrmsysSetting_Result.CoLocations_Lang), (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == currLangID)).Value;
				if (!string.IsNullOrWhiteSpace(value3))
				{
					List<CrmSysSettingCoLocationViewModel> list2 = JsonConvert.DeserializeObject<List<CrmSysSettingCoLocationViewModel>>(value3);
					for (int i = 0; i < list.Count; i++)
					{
						list[i].Title = list2[i].Title;
					}
				}
				cRMspSelectCrmsysSetting_Result.CoLocations = JsonConvert.SerializeObject(list);
			}
			value = cRMspSelectCrmsysSetting_Result.CoLocations;
			value2 = cRMspSelectCrmsysSetting_Result.CoLocations_Lang;
		}
		return JsonConvert.SerializeObject(new Dictionary<string, string>
		{
			{ "Data", value },
			{ "LangData", value2 }
		});
	}

	[HttpPost]
	public void updateSysSetttingColocations(string locationsStr, string langLocationsStr)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		if (CRMIdeal.Cache.User.Language.Get(UserLogin.CurrentUser.UserId).Count <= 1)
		{
			langLocationsStr = "";
		}
		_dbII.CRMspUpdateSysSettingCoLocations(locationsStr, langLocationsStr, result);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult SmsSettingAfterVerify()
	{
		CrmsysSettingLanguageViewModel crmsysSettingLanguageViewModel = new CrmsysSettingLanguageViewModel();
		try
		{
			CrmsysSetting tbl = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
			if (tbl != null)
			{
				List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				list2.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = tbl.LanguageID.GetValueOrDefault(),
					Value = tbl.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula
				});
				list2.AddRange(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang x) => new CommonMultiLanguageViewModel
				{
					LanguageId = x.LanguageID,
					Value = x.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula
				})));
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != tbl.LanguageID))));
				crmsysSettingLanguageViewModel.LanguageID = tbl.LanguageID;
				crmsysSettingLanguageViewModel.DefaultLanguageID = tbl.DefaultLanguageID;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerify = tbl.SendSMSOrdFOLinkAfterVerify;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyType = tbl.SendSMSOrdFOLinkAfterVerifyType;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyGSM = tbl.SendSMSOrdFOLinkAfterVerifyGSM;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyGSMSetId = tbl.SendSMSOrdFOLinkAfterVerifyGSMSetId;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyWeb = tbl.SendSMSOrdFOLinkAfterVerifyWeb;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyWebProviderId = tbl.SendSMSOrdFOLinkAfterVerifyWebProviderId;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyNumber = tbl.SendSMSOrdFOLinkAfterVerifyNumber;
				crmsysSettingLanguageViewModel.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == tbl.LanguageID)).Value;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerify = tbl.SendSMSPordFOLinkAfterVerify;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyType = tbl.SendSMSPordFOLinkAfterVerifyType;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyGSM = tbl.SendSMSPordFOLinkAfterVerifyGSM;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyGSMSetId = tbl.SendSMSPordFOLinkAfterVerifyGSMSetId;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyWeb = tbl.SendSMSPordFOLinkAfterVerifyWeb;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyWebProviderId = tbl.SendSMSPordFOLinkAfterVerifyWebProviderId;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyNumber = tbl.SendSMSPordFOLinkAfterVerifyNumber;
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyBodyPatternFormula = tbl.SendSMSPordFOLinkAfterVerifyBodyPatternFormula;
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				list3.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = tbl.LanguageID.GetValueOrDefault(),
					Value = tbl.SendSMSPordFOLinkAfterVerifyBodyPatternFormula
				});
				list3.AddRange(Enumerable.Select<CrmsysSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmsysSetting_Lang>)list, (Func<CrmsysSetting_Lang, CommonMultiLanguageViewModel>)((CrmsysSetting_Lang x) => new CommonMultiLanguageViewModel
				{
					LanguageId = x.LanguageID,
					Value = x.SendSMSPordFOLinkAfterVerifyBodyPatternFormula
				})));
				crmsysSettingLanguageViewModel.SendSMSPordFOLinkAfterVerifyBodyPatternFormula_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId != tbl.LanguageID))));
				crmsysSettingLanguageViewModel.CoLocations = tbl.CoLocations;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.GsmSettings = GetGsmSettingsSelectListItem();
		base.ViewBag.SmsProviders = GetSmsProviderSelectListItem();
		return View(crmsysSettingLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult SmsSettingAfterVerify(CrmsysSettingLanguageViewModel model)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (model != null)
			{
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				List<CrmsysSetting_Lang> list = Enumerable.ToList<CrmsysSetting_Lang>((IEnumerable<CrmsysSetting_Lang>)_dbTbl.CrmsysSetting_Lang);
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(model.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula_Lang))
				{
					list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(model.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = model.LanguageID.GetValueOrDefault(),
					Value = model.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrWhiteSpace(model.SendSMSPordFOLinkAfterVerifyBodyPatternFormula_Lang))
				{
					list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(model.SendSMSPordFOLinkAfterVerifyBodyPatternFormula_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					LanguageId = model.LanguageID.GetValueOrDefault(),
					Value = model.SendSMSPordFOLinkAfterVerifyBodyPatternFormula
				});
				foreach (CrmsysSetting_Lang set in list)
				{
					set.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula = null;
					if (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == set.LanguageID)) != null)
					{
						set.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == set.LanguageID)).Value;
					}
					set.SendSMSPordFOLinkAfterVerifyBodyPatternFormula = null;
					if (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == set.LanguageID)) != null)
					{
						set.SendSMSPordFOLinkAfterVerifyBodyPatternFormula = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == set.LanguageID)).Value;
					}
					_dbTbl.Entry(set).State = EntityState.Modified;
					_dbTbl.SaveChanges();
				}
				crmsysSetting.SendSMSOrdFOLinkAfterVerify = model.SendSMSOrdFOLinkAfterVerify;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyType = model.SendSMSOrdFOLinkAfterVerifyType;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyGSM = model.SendSMSOrdFOLinkAfterVerifyGSM;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyGSMSetId = model.SendSMSOrdFOLinkAfterVerifyGSMSetId;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyWeb = model.SendSMSOrdFOLinkAfterVerifyWeb;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyWebProviderId = model.SendSMSOrdFOLinkAfterVerifyWebProviderId;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyNumber = model.SendSMSOrdFOLinkAfterVerifyNumber;
				crmsysSetting.SendSMSOrdFOLinkAfterVerifyBodyPatternFormula = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == model.LanguageID)).Value;
				crmsysSetting.SendSMSPordFOLinkAfterVerify = model.SendSMSPordFOLinkAfterVerify;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyType = model.SendSMSPordFOLinkAfterVerifyType;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyGSM = model.SendSMSPordFOLinkAfterVerifyGSM;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyGSMSetId = model.SendSMSPordFOLinkAfterVerifyGSMSetId;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyWeb = model.SendSMSPordFOLinkAfterVerifyWeb;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyWebProviderId = model.SendSMSPordFOLinkAfterVerifyWebProviderId;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyNumber = model.SendSMSPordFOLinkAfterVerifyNumber;
				crmsysSetting.SendSMSPordFOLinkAfterVerifyBodyPatternFormula = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == model.LanguageID)).Value;
				_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
				_dbTbl.SaveChanges();
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = ex.Message + "\n";
		}
		base.ViewBag.GsmSettings = GetGsmSettingsSelectListItem();
		base.ViewBag.SmsProviders = GetSmsProviderSelectListItem();
		base.ViewBag.Error = text;
		if (text == "")
		{
			base.ViewBag.Successfull = string.Format(Messages.msgSuccessfulySavedValues, "");
		}
		return View(model);
	}

	public List<SelectListItem> GetGsmSettingsSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<SmsspSelectGSMModemSetting_Result> list2 = Enumerable.ToList<SmsspSelectGSMModemSetting_Result>((IEnumerable<SmsspSelectGSMModemSetting_Result>)db.SmsspSelectGSMModemSetting());
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<SmsspSelectGSMModemSetting_Result, SelectListItem>((IEnumerable<SmsspSelectGSMModemSetting_Result>)list2, (Func<SmsspSelectGSMModemSetting_Result, SelectListItem>)((SmsspSelectGSMModemSetting_Result item) => new SelectListItem
				{
					Text = (item.DeviceName ?? ""),
					Value = item.ID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	public List<SelectListItem> GetSmsProviderSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<SmsspSelectActiveProviders_Result> list2 = Enumerable.ToList<SmsspSelectActiveProviders_Result>((IEnumerable<SmsspSelectActiveProviders_Result>)db.SmsspSelectActiveProviders());
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<SmsspSelectActiveProviders_Result, SelectListItem>((IEnumerable<SmsspSelectActiveProviders_Result>)list2, (Func<SmsspSelectActiveProviders_Result, SelectListItem>)((SmsspSelectActiveProviders_Result item) => new SelectListItem
				{
					Text = (item.ProviderName ?? ""),
					Value = item.Id.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult ShowCrmIdealAPIUserInfo()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		string text2 = "";
		string text3 = "";
		try
		{
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(-15);
			if (cRMspSelectUsersById_Result != null)
			{
				text = cRMspSelectUsersById_Result.FullName ?? "";
				num = cRMspSelectUsersById_Result.UserId;
				text2 = cRMspSelectUsersById_Result.UserName ?? "";
				text3 = cRMspSelectUsersById_Result.Password ?? "";
				if (!string.IsNullOrWhiteSpace(text2))
				{
					text2 = CodeDecode.Codding(text2);
				}
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text3 = CodeDecode.Codding(text3);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserId = num;
		base.ViewBag.UserInfo = text;
		base.ViewBag.UserName = text2;
		base.ViewBag.UserPassWord = text3;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult ChangeCrmIdealAPIUserPassword()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult ActChangeAPIUserPassword(int userId, string userPassword, string newUserPassword)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			Users users = _dbTbl.Users.Find(userId);
			if (users == null)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.ErrorNotFound;
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = Financial.Get().Id;
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			BaseInfo baseInfo = new BaseInfo();
			string text = "";
			if (!string.IsNullOrWhiteSpace(userPassword))
			{
				text = baseInfo.ConvertMd5(userPassword).ToLower();
			}
			if (text != users.Password && !string.IsNullOrWhiteSpace(users.Password))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorPasswordWrong;
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string text2 = baseInfo.ConvertMd5(newUserPassword).ToLower();
			users.IsAdmin = text2 + newUserPassword;
			users.Password = text2;
			users.UserId1 = userId;
			users.Month1 = value2;
			users.RegisterDate = value;
			users.RegisterDatePersian = registerDatePersian;
			users.AppType = appType;
			_dbTbl.Entry(users).State = EntityState.Modified;
			_dbTbl.SaveChanges();
			string tag = CodeDecode.Codding(text2);
			commonReturnResultViewModel.MessageExtra = "";
			commonReturnResultViewModel.IsDone = true;
			commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			commonReturnResultViewModel.Tag = tag;
		}
		catch (Exception e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}

	public string GetUsersName(string usersId)
	{
		string text = "";
		try
		{
			if (!string.IsNullOrEmpty(usersId))
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				List<CRMspSelectUsers_Result> users = CRMIdeal.Classes.Helper.User.SelectUsers(0);
				if (Enumerable.Any<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)users))
				{
					text = Enumerable.Aggregate<CRMspSelectUsers_Result, string>(Enumerable.Where<CRMspSelectUsers_Result>(Enumerable.Select<string, CRMspSelectUsers_Result>(Enumerable.Where<string>((IEnumerable<string>)usersId.Split(new char[1] { '|' }), (Func<string, bool>)((string us) => !string.IsNullOrEmpty(us))), (Func<string, CRMspSelectUsers_Result>)((string us) => Enumerable.FirstOrDefault<CRMspSelectUsers_Result>((IEnumerable<CRMspSelectUsers_Result>)users, (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result m) => m.UserId == int.Parse(us))))), (Func<CRMspSelectUsers_Result, bool>)((CRMspSelectUsers_Result u) => u != null)), text, (Func<string, CRMspSelectUsers_Result, string>)((string current, CRMspSelectUsers_Result u) => current + ((!string.IsNullOrEmpty(u.LName)) ? u.LName : "") + ((!string.IsNullOrEmpty(u.FName)) ? (" " + u.FName + " ") : "") + ","));
					if (!string.IsNullOrEmpty(text))
					{
						text = text.TrimEnd(new char[1] { ',' });
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[AjaxOnly]
	public void GetRolls()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		try
		{
			list = GetRollsList();
			list2 = GetRollsList();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RollList = list;
		base.ViewBag.CheckerRollList = list2;
	}

	public List<SelectListItem> GetRollsList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectsysRolls_Result> list2 = Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)db.CRMspSelectsysRolls(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspSelectsysRolls_Result, SelectListItem>((IEnumerable<CRMspSelectsysRolls_Result>)Enumerable.ToList<CRMspSelectsysRolls_Result>((IEnumerable<CRMspSelectsysRolls_Result>)list2), (Func<CRMspSelectsysRolls_Result, SelectListItem>)((CRMspSelectsysRolls_Result i) => new SelectListItem
				{
					Text = i.RollName,
					Value = i.ID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}
}
