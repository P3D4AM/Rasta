using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class DyFormController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcDyForms")]
	public ActionResult Index()
	{
		return View();
	}

	public JsonResult CInternalTaskVerifyRequests(int typeId = 16)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspInternalMessageLoadShortUserMessage_Result> list = new List<CRMspInternalMessageLoadShortUserMessage_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (typeId != 0)
			{
				list = Enumerable.ToList<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)_db.CRMspInternalMessageLoadShortUserMessage(UserLogin.CurrentUser.UserId, typeId, lCID, result, false, result2));
				foreach (CRMspInternalMessageLoadShortUserMessage_Result item in list)
				{
					if (item.msgdSendDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
						item.SendDateTime = result3.ToString("yyyy/MM/dd HH:mm:ss");
					}
				}
			}
			int messageId = 0;
			if (list.Count > 0)
			{
				messageId = Enumerable.FirstOrDefault<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)list).InternalMessageID;
			}
			UpdateInternalMessage("Receive", messageId, typeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CInternalTaskVerifyRequests = JsonConvert.SerializeObject(list);
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult CInternalTaskSendForInformation(int typeId = 17)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspInternalMessageLoadShortUserMessage_Result> list = new List<CRMspInternalMessageLoadShortUserMessage_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (typeId != 0)
			{
				list = Enumerable.ToList<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)_db.CRMspInternalMessageLoadShortUserMessage(UserLogin.CurrentUser.UserId, typeId, lCID, result, false, result2));
				foreach (CRMspInternalMessageLoadShortUserMessage_Result item in list)
				{
					if (item.msgdSendDateTime.HasValue)
					{
						DateTime.TryParse(item.msgdSendDateTime.ToString(), out var result3);
						item.SendDateTime = result3.ToString("yyyy/MM/dd HH:mm:ss");
					}
				}
			}
			int messageId = 0;
			if (list.Count > 0)
			{
				messageId = Enumerable.FirstOrDefault<CRMspInternalMessageLoadShortUserMessage_Result>((IEnumerable<CRMspInternalMessageLoadShortUserMessage_Result>)list).InternalMessageID;
			}
			UpdateInternalMessage("Receive", messageId, typeId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CInternalTaskSendForInformation = JsonConvert.SerializeObject(list);
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public void UpdateInternalMessage(string mode, int messageId, int typeId)
	{
		try
		{
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			_db.CRMspInternalMessageUpdate(mode, messageId, UserLogin.CurrentUser.UserId, typeId, time, date, Configuration.AppType, result);
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
