using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Setting.Controllers;

public class CIPopUpController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		CrmsysCIPopUpSetting crmsysCIPopUpSetting = new CrmsysCIPopUpSetting();
		try
		{
			CRMspCallerIDSelectPopUpSetting_Result cRMspCallerIDSelectPopUpSetting_Result = Enumerable.FirstOrDefault<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)Enumerable.ToList<CRMspCallerIDSelectPopUpSetting_Result>((IEnumerable<CRMspCallerIDSelectPopUpSetting_Result>)_db.CRMspCallerIDSelectPopUpSetting()));
			if (cRMspCallerIDSelectPopUpSetting_Result != null)
			{
				crmsysCIPopUpSetting.CIPopUpSettingID = cRMspCallerIDSelectPopUpSetting_Result.CIPopUpSettingID;
				crmsysCIPopUpSetting.IsActive = cRMspCallerIDSelectPopUpSetting_Result.IsActive;
				crmsysCIPopUpSetting.SettingTitle = cRMspCallerIDSelectPopUpSetting_Result.SettingTitle;
				crmsysCIPopUpSetting.UseClientNameForNetworking = cRMspCallerIDSelectPopUpSetting_Result.UseClientNameForNetworking;
				crmsysCIPopUpSetting.PopUpDeActive = cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActive;
				crmsysCIPopUpSetting.PopUpWinFormIDeActive = cRMspCallerIDSelectPopUpSetting_Result.PopUpWinFormIDeActive;
				crmsysCIPopUpSetting.PopUpDeActiveForUnknownNumber = cRMspCallerIDSelectPopUpSetting_Result.PopUpDeActiveForUnknownNumber;
				crmsysCIPopUpSetting.PopUpJustForcmpReferUser = cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUser;
				crmsysCIPopUpSetting.PopUpJustForcmpReferUserAndLinked = cRMspCallerIDSelectPopUpSetting_Result.PopUpJustForcmpReferUserAndLinked;
				crmsysCIPopUpSetting.PatternFormulaPopUp = cRMspCallerIDSelectPopUpSetting_Result.PatternFormulaPopUp;
				crmsysCIPopUpSetting.PatternForLineNumber = cRMspCallerIDSelectPopUpSetting_Result.PatternForLineNumber;
				crmsysCIPopUpSetting.PatternForCallTime = cRMspCallerIDSelectPopUpSetting_Result.PatternForCallTime;
				crmsysCIPopUpSetting.PatternForPhoneNumber = cRMspCallerIDSelectPopUpSetting_Result.PatternForPhoneNumber;
				crmsysCIPopUpSetting.PatternForcmpName = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpName;
				crmsysCIPopUpSetting.PatternForcmpPrsName = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpPrsName;
				crmsysCIPopUpSetting.PatternForPhoneName = cRMspCallerIDSelectPopUpSetting_Result.PatternForPhoneName;
				crmsysCIPopUpSetting.PatternForLastcnvscmpPerson = cRMspCallerIDSelectPopUpSetting_Result.PatternForLastcnvscmpPerson;
				crmsysCIPopUpSetting.PatternForLastProject = cRMspCallerIDSelectPopUpSetting_Result.PatternForLastProject;
				crmsysCIPopUpSetting.PatternForLastcnvsRefUser = cRMspCallerIDSelectPopUpSetting_Result.PatternForLastcnvsRefUser;
				crmsysCIPopUpSetting.PatternForLastcnvsStatus = cRMspCallerIDSelectPopUpSetting_Result.PatternForLastcnvsStatus;
				crmsysCIPopUpSetting.PatternForcmpReferUser = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpReferUser;
				crmsysCIPopUpSetting.PatternForcmpActivityType = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpActivityType;
				crmsysCIPopUpSetting.PatternForcmpCountry = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCountry;
				crmsysCIPopUpSetting.PatternForcmpProvince = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpProvince;
				crmsysCIPopUpSetting.PatternForcmpCity = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCity;
				crmsysCIPopUpSetting.PatternForcmpPresentation = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpPresentation;
				crmsysCIPopUpSetting.PatternForcmpCompanyType = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCompanyType;
				crmsysCIPopUpSetting.PatternForcmpCompanyGroup = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCompanyGroup;
				crmsysCIPopUpSetting.PatternForcmpSubGroupName = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpSubGroupName;
				crmsysCIPopUpSetting.PatternForcmpCompanyGroupII = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCompanyGroupII;
				crmsysCIPopUpSetting.PatternForcmpCompanyGroupIII = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCompanyGroupIII;
				crmsysCIPopUpSetting.PatternForcmpCompanyGroupIV = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCompanyGroupIV;
				crmsysCIPopUpSetting.PatternForcmpCIWord = cRMspCallerIDSelectPopUpSetting_Result.PatternForcmpCIWord;
				crmsysCIPopUpSetting.FirstRegisterDate = cRMspCallerIDSelectPopUpSetting_Result.FirstRegisterDate;
				crmsysCIPopUpSetting.FirstRegisterDatePersian = cRMspCallerIDSelectPopUpSetting_Result.FirstRegisterDatePersian;
				crmsysCIPopUpSetting.FirstRegisterUserId = cRMspCallerIDSelectPopUpSetting_Result.FirstRegisterUserId;
				crmsysCIPopUpSetting.UserId = cRMspCallerIDSelectPopUpSetting_Result.UserId;
				crmsysCIPopUpSetting.Year1 = cRMspCallerIDSelectPopUpSetting_Result.Year1;
				crmsysCIPopUpSetting.Month1 = cRMspCallerIDSelectPopUpSetting_Result.Month1;
				crmsysCIPopUpSetting.RegisterDate = cRMspCallerIDSelectPopUpSetting_Result.RegisterDate;
				crmsysCIPopUpSetting.RegisterDatePersian = cRMspCallerIDSelectPopUpSetting_Result.RegisterDatePersian;
				crmsysCIPopUpSetting.GUId = cRMspCallerIDSelectPopUpSetting_Result.GUId;
				crmsysCIPopUpSetting.AppType = cRMspCallerIDSelectPopUpSetting_Result.AppType;
				crmsysCIPopUpSetting.LanguageID = cRMspCallerIDSelectPopUpSetting_Result.LanguageID;
				crmsysCIPopUpSetting.PopUpActiveWithExt = cRMspCallerIDSelectPopUpSetting_Result.PopUpActiveWithExt;
			}
			DateTime now = DateTime.Now;
			if (crmsysCIPopUpSetting == null)
			{
				crmsysCIPopUpSetting = new CrmsysCIPopUpSetting
				{
					UserId = UserLogin.CurrentUser.UserId,
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					FirstRegisterDate = now
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfo(crmsysCIPopUpSetting);
		return View(crmsysCIPopUpSetting);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult Index(CrmsysCIPopUpSetting model)
	{
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			DateTime now = DateTime.Now;
			try
			{
				if (model.CIPopUpSettingID > 0)
				{
					model.UserId = UserLogin.CurrentUser.UserId;
					model.RegisterDate = now;
					model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					model.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					model.AppType = Configuration.AppType;
					_dbTbl.Entry(model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					CIPopUpSetting.Update();
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					model.UserId = UserLogin.CurrentUser.UserId;
					model.RegisterDate = now;
					model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					model.Year1 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					model.AppType = Configuration.AppType;
					model.GUId = Guid.NewGuid();
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
					if (result <= 0)
					{
						result = 1065;
					}
					model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					model.FirstRegisterDate = now;
					model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					model.LanguageID = result;
					_dbTbl.CrmsysCIPopUpSetting.Add(model);
					_dbTbl.SaveChanges();
					CIPopUpSetting.Update();
					if (model.CIPopUpSettingID <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.frmErrorMessage;
			}
		}
		SetRegisterInfo(model);
		return View(model);
	}

	public void SetRegisterInfo(CrmsysCIPopUpSetting model)
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
			_ = model.FirstRegisterUserId;
			string text5 = model.FirstRegisterUserId.ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CrmsysCIPopUpSetting crmsysCIPopUpSetting = model;
				_ = model.FirstRegisterUserId;
				crmsysCIPopUpSetting.FirstRegisterUserId = model.FirstRegisterUserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				CrmsysCIPopUpSetting crmsysCIPopUpSetting2 = model;
				_ = model.UserId;
				crmsysCIPopUpSetting2.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			_ = model.FirstRegisterDate;
			string text6 = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
