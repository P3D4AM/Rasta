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

public class SmsSettingController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		SmsSetting smsSetting = new SmsSetting();
		try
		{
			DateTime now = DateTime.Now;
			smsSetting = Queryable.FirstOrDefault<SmsSetting>((IQueryable<SmsSetting>)_dbTbl.SmsSetting) ?? new SmsSetting
			{
				RegisterDate = now,
				FirstRegisterDate = now,
				Id = 0,
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				Year1 = short.Parse(Financial.Get().Id.ToString()),
				Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
				AppType = Configuration.AppType,
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture())
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		SetRegisterInfo(smsSetting);
		return View(smsSetting);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult Index(SmsSetting model)
	{
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage))) + "<br/> <a href='/Sms/SmsInfo/SmsWebServiceSetting' target='_blank' style='color:blue; text-decoration: underline;'>" + Menus.actsmsWSSetting + "</a>";
		}
		else
		{
			DateTime now = DateTime.Now;
			try
			{
				if (model.Id > 0)
				{
					model.UserId = UserLogin.CurrentUser.UserId;
					model.RegisterDate = now;
					model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					model.Year1 = short.Parse(Financial.Get().Id.ToString());
					model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					model.AppType = Configuration.AppType;
					_dbTbl.Entry(model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SmsSeting.Update();
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					model.UserId = UserLogin.CurrentUser.UserId;
					model.RegisterDate = now;
					model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					model.Year1 = short.Parse(Financial.Get().Id.ToString());
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
					_dbTbl.SmsSetting.Add(model);
					_dbTbl.SaveChanges();
					SmsSeting.Update();
					if (model.Id <= 0)
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

	public void SetRegisterInfo(SmsSetting model)
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
			string? text5 = (model.FirstRegisterUserId.HasValue ? model.FirstRegisterUserId : new int?(UserLogin.CurrentUser.UserId)).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = (model.FirstRegisterUserId.HasValue ? model.FirstRegisterUserId : new int?(UserLogin.CurrentUser.UserId));
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				SmsSetting smsSetting = model;
				_ = model.UserId;
				smsSetting.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = text3 + " (" + text6 + ")";
			text2 = text4 + " (" + text8 + ") (" + text7 + ")";
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
