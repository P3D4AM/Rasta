using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class TicketAlarmSettingController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index()
	{
		return View();
	}

	[LoginAuthorize]
	public ActionResult InsertEdit(int id = 0)
	{
		base.ViewBag.lstProviders = SelectActiveProviders();
		base.ViewBag.lstProjectTitleGroups = SelectProjectsGroupByTitleGroup();
		return View(SelectTicketAlarmSettingWithId(id));
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertEdit(int id = 0, int tasTypeId = 0, bool? tasIsActive = null, string tasProjectTitleGroup = null, string tasProjectTitleGroup_Lang = null, int? tasDelayAlarmDay = null, string tasDelayAlarmTime = null, int? tasBusyAllMsgCnt = null, int? tasBusyUserRepCnt = null, int? tasUnhappyMinVote = null, string tasReceiverIds = null, string tasMessage = null, string tasMessage_Lang = null, bool? tasSendSMS = null, int? tasSendSMSProviderId = null, string tasSendSMSNumber = null, int? OrderView = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			List<Languages> list = Language.Get();
			List<CRMspSelectTicketAlarmSetting_Result> list2 = new List<CRMspSelectTicketAlarmSetting_Result>();
			list2.AddRange(Enumerable.Select<Languages, CRMspSelectTicketAlarmSetting_Result>((IEnumerable<Languages>)list, (Func<Languages, CRMspSelectTicketAlarmSetting_Result>)((Languages x) => new CRMspSelectTicketAlarmSetting_Result
			{
				LanguageID = x.LanguageID
			})));
			if (!string.IsNullOrWhiteSpace(tasMessage_Lang))
			{
				List<CommonMultiLanguageViewModel> list3 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(tasMessage_Lang);
				foreach (CRMspSelectTicketAlarmSetting_Result i in list2)
				{
					if (Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == i.LanguageID)) != null)
					{
						i.tasMessage = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel x) => x.LanguageId == i.LanguageID)).Value;
					}
				}
			}
			if (id == 0)
			{
				ObjectParameter insertedTicketAlarmSettingID = new ObjectParameter("InsertedTicketAlarmSettingID", 0);
				_dbII.CRMspInsertTicketAlarmSetting(tasTypeId, tasIsActive, tasProjectTitleGroup, tasDelayAlarmDay, tasDelayAlarmTime, tasBusyAllMsgCnt, tasBusyUserRepCnt, tasUnhappyMinVote, tasReceiverIds, tasMessage, tasSendSMS, tasSendSMSProviderId, tasSendSMSNumber, JsonConvert.SerializeObject(list2), OrderView, userId, now, registerDatePersian, value, value2, appType, lCID, result2, insertedTicketAlarmSettingID);
			}
			else
			{
				_dbII.CRMspUpdateTicketAlarmSetting(id, tasTypeId, tasIsActive, tasProjectTitleGroup, tasDelayAlarmDay, tasDelayAlarmTime, tasBusyAllMsgCnt, tasBusyUserRepCnt, tasUnhappyMinVote, tasReceiverIds, tasMessage, tasSendSMS, tasSendSMSProviderId, tasSendSMSNumber, JsonConvert.SerializeObject(list2), OrderView, userId, now, registerDatePersian, value, value2, appType, lCID, result2);
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
	public string Delete(int id = 0)
	{
		string result = "";
		try
		{
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteTicketAlarmSetting(id));
			if (mct_II_Result == null || mct_II_Result.Result <= 0)
			{
				result = Messages.RedundancyMessage;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = "Error: " + ex.Message;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectProjectsGroupByTitleGroup()
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectProjectsGroupByTitleGroup_Result> list = Enumerable.ToList<CRMspSelectProjectsGroupByTitleGroup_Result>((IEnumerable<CRMspSelectProjectsGroupByTitleGroup_Result>)_dbII.CRMspSelectProjectsGroupByTitleGroup(lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(list);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public List<CRMspSelectTicketAlarmSetting_Result> SelectTicketAlarmSetting()
	{
		List<CRMspSelectTicketAlarmSetting_Result> result = new List<CRMspSelectTicketAlarmSetting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectTicketAlarmSetting_Result> list = Enumerable.ToList<CRMspSelectTicketAlarmSetting_Result>((IEnumerable<CRMspSelectTicketAlarmSetting_Result>)_dbII.CRMspSelectTicketAlarmSetting(lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectTicketAlarmSetting_Result item in list)
				{
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public CRMspSelectTicketAlarmSettingWithId_Result SelectTicketAlarmSettingWithId(int ticketAllarmSettingId = 0)
	{
		CRMspSelectTicketAlarmSettingWithId_Result result = new CRMspSelectTicketAlarmSettingWithId_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectTicketAlarmSettingWithId_Result cRMspSelectTicketAlarmSettingWithId_Result = Enumerable.FirstOrDefault<CRMspSelectTicketAlarmSettingWithId_Result>((IEnumerable<CRMspSelectTicketAlarmSettingWithId_Result>)_dbII.CRMspSelectTicketAlarmSettingWithId(ticketAllarmSettingId, lCID, result2));
			if (cRMspSelectTicketAlarmSettingWithId_Result != null)
			{
				cRMspSelectTicketAlarmSettingWithId_Result.FirstRegisterDatePersian = cRMspSelectTicketAlarmSettingWithId_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm");
				cRMspSelectTicketAlarmSettingWithId_Result.RegisterDatePersian = cRMspSelectTicketAlarmSettingWithId_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm");
				result = cRMspSelectTicketAlarmSettingWithId_Result;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[LoginAuthorize]
	public List<SelectListItem> SelectActiveProviders()
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
			List<SmsspSelectActiveProviders_Result> list2 = Enumerable.ToList<SmsspSelectActiveProviders_Result>((IEnumerable<SmsspSelectActiveProviders_Result>)_db.SmsspSelectActiveProviders());
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
}
