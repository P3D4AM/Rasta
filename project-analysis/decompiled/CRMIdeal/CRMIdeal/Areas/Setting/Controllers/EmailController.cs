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

public class EmailController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		EmailSetting emailSetting = new EmailSetting();
		try
		{
			emailSetting = Queryable.FirstOrDefault<EmailSetting>((IQueryable<EmailSetting>)_dbTbl.EmailSetting);
			DateTime now = DateTime.Now;
			if (emailSetting == null)
			{
				emailSetting = new EmailSetting
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
		SetRegisterInfo(emailSetting);
		return View(emailSetting);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult Index(EmailSetting model)
	{
		string text = "";
		if (!base.ModelState.IsValid)
		{
			base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
		}
		else
		{
			try
			{
				DateTime now = DateTime.Now;
				if (model.EmailSettingId > 0)
				{
					EmailSetting emailSetting = _dbTbl.EmailSetting.Find(model.EmailSettingId);
					if (emailSetting != null)
					{
						emailSetting.UserId = UserLogin.CurrentUser.UserId;
						emailSetting.RegisterDate = now;
						emailSetting.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						emailSetting.AppType = Configuration.AppType;
						emailSetting.EmailBulkingIsActive = model.EmailBulkingIsActive;
						emailSetting.EmailBulkingDelayTime = model.EmailBulkingDelayTime;
						emailSetting.EmailBulkingDailyStarTime = model.EmailBulkingDailyStarTime;
						emailSetting.EmailBulkingDailyEndTime = model.EmailBulkingDailyEndTime;
						emailSetting.EmailsAttachFilePath = model.EmailsAttachFilePath;
						emailSetting.EmailsAttachShareFilePath = model.EmailsAttachShareFilePath;
						emailSetting.CmpPattern = model.CmpPattern;
						emailSetting.CmpPrsPattern = model.CmpPrsPattern;
						emailSetting.CmpPrsJobPattern = model.CmpPrsJobPattern;
						emailSetting.EmailSU = model.EmailSU;
						emailSetting.EmailSP = model.EmailSP;
						emailSetting.EmailSenderEditorFilePath = model.EmailSenderEditorFilePath;
						emailSetting.EmailsPDFBodyFilePath = model.EmailsPDFBodyFilePath;
						emailSetting.EmailsAttachShareFilePathFtp = model.EmailsAttachShareFilePathFtp;
						emailSetting.EmailsPDFBodyFilePathFtp = model.EmailsPDFBodyFilePathFtp;
						_dbTbl.Entry(emailSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						EmailSettings.Update();
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						model.UserId = emailSetting.UserId;
						model.FirstRegisterUserId = emailSetting.FirstRegisterUserId;
						model.FirstRegisterDate = emailSetting.FirstRegisterDate;
						model.RegisterDate = emailSetting.RegisterDate;
						model.AppType = emailSetting.AppType;
					}
					else
					{
						text = Messages.ErrorNotFound;
					}
				}
				else
				{
					model.UserId = UserLogin.CurrentUser.UserId;
					model.RegisterDate = now;
					model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
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
					_dbTbl.EmailSetting.Add(model);
					_dbTbl.SaveChanges();
					if (model.EmailSettingId > 0)
					{
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						text = Messages.msgErrorRunFunction;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.frmErrorMessage;
			}
		}
		base.ViewBag.FirstName = text;
		SetRegisterInfo(model);
		return View(model);
	}

	public void SetRegisterInfo(EmailSetting model)
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
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				EmailSetting emailSetting = model;
				_ = model.UserId;
				emailSetting.UserId = model.UserId;
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
