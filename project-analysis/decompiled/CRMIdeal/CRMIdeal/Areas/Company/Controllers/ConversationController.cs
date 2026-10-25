using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Company.Controllers;

public class ConversationController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	[HttpPost]
	public string GetOperations(int id, int prjId, int countShowCnvs, int cnvsFtr = 0, int cnvsPrsId = 0, bool isShowFreeSms = false, bool isShowFreeEmail = false, string prjTitleGroup = "", bool prjIsFinished = false, string oprTypeIds = "", int pageSize = 100, int pageFirstId = 0, int pageLastId = 0)
	{
		List<CRMspSelectCompanyOperationsWeb_Result> list = new List<CRMspSelectCompanyOperationsWeb_Result>();
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
			int userId = UserLogin.CurrentUser.UserId;
			string buyOrderText = Labels.buyOrderText;
			list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)_dbI.CRMspSelectCompanyOperationsWeb(id, prjId, countShowCnvs, userId, lCID, result, buyOrderText, isShowFreeSms, isShowFreeEmail, prjTitleGroup, prjIsFinished, oprTypeIds, pageSize, pageFirstId, pageLastId, result2));
			if (cnvsFtr != 0 && list != null && Enumerable.Any<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list))
			{
				switch (cnvsFtr)
				{
				case 2:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 2)));
					break;
				case -2:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 2 && m.OprPersonId == cnvsPrsId)));
					break;
				case 4:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 4 || m.OprTypeId.GetValueOrDefault() == 6)));
					break;
				case 8:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 8)));
					break;
				case 10:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 10)));
					break;
				case 20:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 20)));
					break;
				case 30:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 30)));
					break;
				case 40:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 40 || m.OprTypeId.GetValueOrDefault() == 41)));
					break;
				case 51:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 51 || m.OprTypeId.GetValueOrDefault() == 52)));
					break;
				case 60:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 60 || m.OprTypeId.GetValueOrDefault() == 61)));
					break;
				case 71:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 71)));
					break;
				case 80:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 80)));
					break;
				case 101:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 101)));
					break;
				case 102:
					list = Enumerable.ToList<CRMspSelectCompanyOperationsWeb_Result>(Enumerable.Where<CRMspSelectCompanyOperationsWeb_Result>((IEnumerable<CRMspSelectCompanyOperationsWeb_Result>)list, (Func<CRMspSelectCompanyOperationsWeb_Result, bool>)((CRMspSelectCompanyOperationsWeb_Result m) => m.OprTypeId.GetValueOrDefault() == 102)));
					break;
				}
			}
			foreach (CRMspSelectCompanyOperationsWeb_Result item in list)
			{
				item.OprDate = (item.OprDateTime.HasValue ? item.OprDateTime.Value.ToString("yyyy/MM/dd") : "");
				item.OprRemindDate = (item.OprRemindDateTime.HasValue ? item.OprRemindDateTime.Value.ToString("yyyy/MM/dd") : "");
				item.OprRemindDateForAllarm = (item.OprRemindDateTimeForAllarm.HasValue ? item.OprRemindDateTimeForAllarm.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		catch (Exception)
		{
			throw;
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	public int SelectCnvsReminderCount(string date = "")
	{
		int num = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			if (!string.IsNullOrWhiteSpace(date))
			{
				DateTime? dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrEmpty(date))
					{
						text = PersianDate.GetFormatetdDate(date.Replace("/", ""));
						dateTime = lCID switch
						{
							1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
							1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
						};
					}
					else
					{
						dateTime = null;
						text = null;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num = -1;
				}
				if (num == 0)
				{
					CRMSpSelectCnvsReminderCountBetweenDate_Result cRMSpSelectCnvsReminderCountBetweenDate_Result = Enumerable.FirstOrDefault<CRMSpSelectCnvsReminderCountBetweenDate_Result>((IEnumerable<CRMSpSelectCnvsReminderCountBetweenDate_Result>)db.CRMSpSelectCnvsReminderCountBetweenDate(userId, dateTime, dateTime));
					if (cRMSpSelectCnvsReminderCountBetweenDate_Result != null)
					{
						num = cRMSpSelectCnvsReminderCountBetweenDate_Result.cmpRemindCnt.GetValueOrDefault();
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = -1;
		}
		return num;
	}
}
