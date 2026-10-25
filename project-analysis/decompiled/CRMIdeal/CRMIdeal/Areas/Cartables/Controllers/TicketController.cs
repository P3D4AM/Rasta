using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class TicketController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int cnvsId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public int prjId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcTicket")]
	public ActionResult Index()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
		if (!VersionBuyer.TicketPlus)
		{
			base.Response.Redirect("/Cartables/Cartables/HomePage", false);
		}
		GetTicketsProjectTitleGroupsSelectListItem();
		GetMsgUser(UserLogin.CurrentUser.UserId);
		base.ViewBag.ProjectTitleAndTitleGroup = SelectTicketProjectTitleAndTitleGroup_SelectListItem_I();
		base.ViewBag.ConversationPriorities = SelectConversationPriority_SelectListItem(0);
		IncDate();
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)_db.CRMspSelectFoSetting(null, null, null, null, null, null, null, null, null, null, null, null, null, 0, 0, centerId));
			if (cRMspSelectFoSetting_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = "TicketColorAllarm",
					Value = cRMspSelectFoSetting_Result.TicketColorAllarm.GetValueOrDefault().ToString()
				});
				if (!string.IsNullOrWhiteSpace(cRMspSelectFoSetting_Result.TicketColorAllarmJs))
				{
					list.Add(new SelectListItem
					{
						Text = "TicketColorAllarmJs",
						Value = cRMspSelectFoSetting_Result.TicketColorAllarmJs.ToString()
					});
				}
			}
		}
		catch (Exception)
		{
		}
		base.ViewBag.FoSetting = JsonConvert.SerializeObject(list);
		return View();
	}

	[LoginAuthorize]
	public List<CRMspSelectTicketsProjectTitleGroups_Result> GetTicketsProjectTitleGroups()
	{
		List<CRMspSelectTicketsProjectTitleGroups_Result> result = new List<CRMspSelectTicketsProjectTitleGroups_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectTicketsProjectTitleGroups_Result>((IEnumerable<CRMspSelectTicketsProjectTitleGroups_Result>)_dbI.CRMspSelectTicketsProjectTitleGroups(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public List<SelectListItem> GetTicketsProjectTitleGroupsSelectListItem()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectTicketsProjectTitleGroups_Result> ticketsProjectTitleGroups = GetTicketsProjectTitleGroups();
		int Id = 0;
		list.AddRange(Enumerable.Select<CRMspSelectTicketsProjectTitleGroups_Result, SelectListItem>((IEnumerable<CRMspSelectTicketsProjectTitleGroups_Result>)ticketsProjectTitleGroups, (Func<CRMspSelectTicketsProjectTitleGroups_Result, SelectListItem>)delegate(CRMspSelectTicketsProjectTitleGroups_Result x)
		{
			SelectListItem obj = new SelectListItem
			{
				Text = x.prjTitleGroup
			};
			int num = ++Id;
			obj.Value = num.ToString();
			return obj;
		}));
		base.ViewBag.ProjectTitleGroupsSelectListItemJs = JsonConvert.SerializeObject(list);
		return list;
	}

	[LoginAuthorize]
	public JsonResult GetProjectTitleGroup(string textValue = "")
	{
		List<SelectListItem> data = new List<SelectListItem>();
		try
		{
			data = Enumerable.ToList<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)GetTicketsProjectTitleGroupsSelectListItem(), (Func<SelectListItem, bool>)((SelectListItem x) => x.Value.ToString().Contains(textValue))));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult ConversationHistory(int projectId = 0, int companyId = 0, int conversationId = 0, bool isPopup = false)
	{
		base.ViewBag.ConversationHistoryListJs = ConversationHistoryListJs(projectId);
		base.ViewBag.IsPopup = isPopup;
		return View();
	}

	[LoginAuthorize]
	public string ConversationHistoryListJs(int projectId = 0, int topValue = 50, int lastConversationId = 0)
	{
		List<CRMspSelectTicketConversationHistoryWithProjectId_Result> list = new List<CRMspSelectTicketConversationHistoryWithProjectId_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (projectId > 0)
			{
				list = Enumerable.ToList<CRMspSelectTicketConversationHistoryWithProjectId_Result>((IEnumerable<CRMspSelectTicketConversationHistoryWithProjectId_Result>)_dbI.CRMspSelectTicketConversationHistoryWithProjectId(projectId, topValue, lastConversationId, lCID, result, DateTime.Now));
				foreach (CRMspSelectTicketConversationHistoryWithProjectId_Result item in list)
				{
					item.RegisterDatePersian = item.FirstRegisterDate?.ToString("yyyyMMdd");
					item.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd HH:mm:ss");
					item.cnvsFirstRegisterDate = item.FirstRegisterDate?.ToString("yyyy/MM/dd dddd");
					item.prjToDoTimePersian = item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeRegisterPersian = item.prjToDoTimeRegister?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeDonePersian = item.prjToDoTimeDone?.ToString("yyyy/MM/dd HH:mm");
					item.prjStartDateTimePersian = item.prjStartDateTime?.ToString("yyyy/MM/dd HH:mm");
					item.prjFinishedDateTimePersian = item.prjFinishedDateTime?.ToString("yyyy/MM/dd HH:mm");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	[LoginAuthorize]
	public string GetFilesDirectoryJs(int companyId, int personId, int projectId, int conversationID)
	{
		List<CRMspSelectFilesDirectory_Result> value = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			value = Files.SelectFilesDirectory(companyId.ToString(), personId.ToString(), projectId.ToString(), "2", conversationID.ToString(), "0", "0", false);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	public string UpdateConversationHappyVote(int cnvsId = 0, int? vote = null)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			if (!UserLogin.IsUserAccess("frmMain", "actcTicketCanChangeCnvsHappyVote", UserLogin.CurrentUser))
			{
				text = text + Messages.DoNotHaveAccess + "</br>";
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				ObjectParameter objectParameter = new ObjectParameter("ResultId", 0);
				_dbI.CRMspUpdateConversationHappyVote(cnvsId, vote, userId, value, registerDatePersian, value2, value3, appType, lCID, objectParameter);
				if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()) && int.Parse(objectParameter.Value.ToString()) == 0)
				{
					text = text + Messages.msgErrorOperationFailed + "</br>";
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = text + "Error: " + ex.Message + "</br>";
		}
		return text;
	}

	public JsonResult GetCnvsKnowledgeTanks(string cnvsKnowledgeTankIds)
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
			if (!string.IsNullOrWhiteSpace(cnvsKnowledgeTankIds))
			{
				List<CRMspknlgSelectKnowledgeTankByIds_Result> list2 = Enumerable.ToList<CRMspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByIds_Result>)_dbI.CRMspknlgSelectKnowledgeTankByIds(cnvsKnowledgeTankIds, UserLogin.CurrentUser.RollId, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByIds_Result>)list2) && list2 != null && Enumerable.Any<CRMspknlgSelectKnowledgeTankByIds_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankByIds_Result>)list2))
				{
					foreach (CRMspknlgSelectKnowledgeTankByIds_Result item2 in list2)
					{
						SelectListItem item = new SelectListItem
						{
							Text = (item2.knlgTitle ?? ""),
							Value = item2.KnowledgeTankId.ToString()
						};
						list.Add(item);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[LoginAuthorize]
	public JsonResult GetTicketList(bool? isFinished, bool? isAnswered, int projectId = 0, int conversationId = 0, int lastRowNumber = 0, int pageSize = 50, int crmUserId = 0, string prjTitleGroup = "", string closedTicketDate = "", string closedTicketDateTo = "", string tabname = "", int prjTitleGroupId = 0, int cnvsStatusGroupId = 0, int cnvsStatusId = 0, int priorityId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		_ = Configuration.AppType;
		_ = DateTime.Now;
		DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
		List<CRMspResultsTicketCartable_Result> list = new List<CRMspResultsTicketCartable_Result>();
		try
		{
			int num = 0;
			switch (tabname)
			{
			case "is-new":
				num = 5;
				break;
			case "in-progress":
				num = 10;
				break;
			case "done":
				num = 15;
				break;
			case "cmp-replied":
				num = 20;
				break;
			case "pending":
				num = 25;
				break;
			}
			DateTime dateTime = DateTime.Now;
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(closedTicketDate))
				{
					text = PersianDate.GetFormatetdDate(closedTicketDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						closedTicketDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						closedTicketDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						closedTicketDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (closedTicketDate != null)
			{
				closedTicketDate = closedTicketDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			DateTime value = dateTime;
			try
			{
				if (!string.IsNullOrEmpty(closedTicketDateTo))
				{
					text = PersianDate.GetFormatetdDate(closedTicketDateTo.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						closedTicketDateTo = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						closedTicketDateTo = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						closedTicketDateTo = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (closedTicketDateTo != null)
			{
				closedTicketDateTo = closedTicketDateTo.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			DateTime value2 = dateTime;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (num > 0)
			{
				CRMSpIEntities dbI = _dbI;
				int? mode = num;
				int? userId2 = userId;
				int? crmUserId2 = crmUserId;
				int? lastRowNumber2 = lastRowNumber;
				int? pageSize2 = pageSize;
				int? num2 = lCID;
				int? num3 = result;
				list = Enumerable.ToList<CRMspResultsTicketCartable_Result>((IEnumerable<CRMspResultsTicketCartable_Result>)dbI.CRMspResultsTicketCartable(prjTitleGroup: prjTitleGroup, currDateTime: DateTime.Now, languageID: num2, defaultLanguageID: num3, closedTicketDate: value, closedTicketDateTo: value2, mode: mode, userId: userId2, lastRowNumber: lastRowNumber2, pageSize: pageSize2, prjTitleGroupId: prjTitleGroupId, cnvsStatusGroupId: cnvsStatusGroupId, cnvsStatusId: cnvsStatusId, priorityId: priorityId, crmUserId: crmUserId2, centerId: result2));
			}
			foreach (CRMspResultsTicketCartable_Result item in list)
			{
				item.prjStartDatePersian = (item.prjStartDate.HasValue ? item.prjStartDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.LastCnvsDatePersian = (item.LastCnvsDate.HasValue ? item.LastCnvsDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimeRegisterPersian = (item.prjToDoTimeRegister.HasValue ? item.prjToDoTimeRegister?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimeDonePersian = (item.prjToDoTimeDone.HasValue ? item.prjToDoTimeDone?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimePersian = (item.prjToDoTime.HasValue ? item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.LastCnvsPriorityColor = Public.TColorToHex(item.LastCnvsPriorityColor);
				item.prjTitleGroupColor = Public.TColorToHex(item.prjTitleGroupColor);
				item.prjFinishedDatePersian = (item.prjToDoTime.HasValue ? item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm") : "");
				item.prjValidityOrdItemExpireDatePersian = (item.prjValidityOrdItemExpireDate.HasValue ? item.prjValidityOrdItemExpireDate?.ToString("yyyy/MM/dd") : "");
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public bool SetTicketAsRead(int prjId = 0, int cnvsId = 0)
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
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			DateTime now = DateTime.Now;
			int num = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (cnvsId > 0)
			{
				_dbI.CRMspUpdateConversationRemindOk(cnvsId, true, userId, short.Parse(now.ToString("MM", new PersianCulture())), short.Parse(num.ToString()), now.ToString("yyyyMMdd", new PersianCulture()), now, appType, centerId);
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public string SearchTicketWithProjectId(int projectId = 0)
	{
		List<CRMspSearchTicketWithProjectId_Result> list = new List<CRMspSearchTicketWithProjectId_Result>();
		if (projectId > 0)
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspSearchTicketWithProjectId_Result>((IEnumerable<CRMspSearchTicketWithProjectId_Result>)_dbI.CRMspSearchTicketWithProjectId(projectId, userId, DateTime.Now, lCID, result, result2));
			foreach (CRMspSearchTicketWithProjectId_Result item in list)
			{
				item.prjPostFix = (item.prjIsTicketNew.GetValueOrDefault() ? Labels.FOTicketStatusIsNotAnswered : Labels.FOTicketStatusIsAnswered);
				item.prjStartDatePersian = (item.prjStartDate.HasValue ? item.prjStartDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.LastCnvsDatePersian = (item.LastCnvsDate.HasValue ? item.LastCnvsDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimeRegisterPersian = (item.prjToDoTimeRegister.HasValue ? item.prjToDoTimeRegister?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimeDonePersian = (item.prjToDoTimeDone.HasValue ? item.prjToDoTimeDone?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.prjToDoTimePersian = (item.prjToDoTime.HasValue ? item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.LastCnvsPriorityColor = Public.TColorToHex(item.LastCnvsPriorityColor);
				item.prjTitleGroupColor = Public.TColorToHex(item.prjTitleGroupColor);
				item.prjFinishedDatePersian = (item.prjToDoTime.HasValue ? item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm") : "");
				item.prjValidityOrdItemExpireDatePersian = (item.prjValidityOrdItemExpireDate.HasValue ? item.prjValidityOrdItemExpireDate?.ToString("yyyy/MM/dd") : "");
			}
		}
		return JsonConvert.SerializeObject(list);
	}

	public void SetProjectsRead(string lstProjectIdsStr = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			DateTime now = DateTime.Now;
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			if (!string.IsNullOrWhiteSpace(lstProjectIdsStr))
			{
				_dbI.CRMspUpdateProjectReadFromTicket(lstProjectIdsStr, userId, short.Parse(now.ToString("MM", new PersianCulture())), now, registerDatePersian, appType);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[LoginAuthorize]
	public ActionResult SetProjectToDoFields(int prjId = 0, int cnvsId = 0, int mode = 0, string prjToDoTime = "", string prjToDoTimeRegister = "")
	{
		_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
		_003C_003Ec__DisplayClass17_.cnvsId = cnvsId;
		int userId = UserLogin.CurrentUser.UserId;
		ProjectToDoFields projectToDoFields = new ProjectToDoFields();
		projectToDoFields.ProjectId = prjId;
		projectToDoFields.ConversationId = _003C_003Ec__DisplayClass17_.cnvsId;
		projectToDoFields.cnvsReferUserId = userId;
		projectToDoFields.ToDoYear = 0;
		projectToDoFields.ToDoMonth = 0;
		projectToDoFields.ToDoDay = 0;
		projectToDoFields.ToDoHour = 0;
		projectToDoFields.ToDoMinute = 0;
		projectToDoFields.Mode = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspCalculateProjectToDoTimes_Result cRMspCalculateProjectToDoTimes_Result = Enumerable.FirstOrDefault<CRMspCalculateProjectToDoTimes_Result>((IEnumerable<CRMspCalculateProjectToDoTimes_Result>)_dbI.CRMspCalculateProjectToDoTimes(prjId, DateTime.Now));
			if (cRMspCalculateProjectToDoTimes_Result != null)
			{
				projectToDoFields.ToDoYear = cRMspCalculateProjectToDoTimes_Result.prjToDoTotalYear;
				projectToDoFields.ToDoMonth = cRMspCalculateProjectToDoTimes_Result.prjToDoTotalMonth;
				projectToDoFields.ToDoDay = cRMspCalculateProjectToDoTimes_Result.prjToDoTotalDay;
				projectToDoFields.ToDoHour = cRMspCalculateProjectToDoTimes_Result.prjToDoTotalHour;
				projectToDoFields.ToDoMinute = cRMspCalculateProjectToDoTimes_Result.prjToDoTotalMinute;
				projectToDoFields.ToDoTimeRegister = cRMspCalculateProjectToDoTimes_Result.prjToDoTimeRegister;
				if (mode == 0)
				{
					projectToDoFields.ToDoYear = 0;
					projectToDoFields.ToDoMonth = 0;
					projectToDoFields.ToDoDay = 0;
					projectToDoFields.ToDoHour = 0;
					projectToDoFields.ToDoMinute = 0;
					DbSet<CrmConversation> crmConversation = _dbTbl.CrmConversation;
					ParameterExpression val = Expression.Parameter(typeof(CrmConversation), "x");
					CrmConversation crmConversation2 = Queryable.FirstOrDefault<CrmConversation>((IQueryable<CrmConversation>)crmConversation, Expression.Lambda<Func<CrmConversation, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (crmConversation2 != null && crmConversation2.cnvsReferUserId > 0)
					{
						base.ViewBag.ThisTicketIsTaken = true;
						projectToDoFields.cnvsReferUserId = crmConversation2.cnvsReferUserId;
					}
					if (UserLogin.IsUserAccess("frmMain", "actcTicketSetToDoTimeAgain", UserLogin.CurrentUser))
					{
						base.ViewBag.ThisTicketIsTaken = false;
					}
				}
			}
			GetMsgUser(projectToDoFields.cnvsReferUserId.GetValueOrDefault(userId), showOpenTickets: true);
			if (mode == 1)
			{
				projectToDoFields.Mode = 1;
				if (!string.IsNullOrWhiteSpace(prjToDoTime) && !string.IsNullOrWhiteSpace(prjToDoTimeRegister))
				{
					DateTime dateTime = DateTime.Parse(prjToDoTime);
					DateTime dateTime2 = DateTime.Parse(prjToDoTimeRegister);
					int num = (int)(dateTime - dateTime2).TotalSeconds;
					int value = (int)Math.Round((double)(num / 60 / 60 / 24 / 30 / 12 % 30));
					int value2 = (int)Math.Round((double)(num / 60 / 60 / 24 / 30 % 12));
					Math.Round((double)(num / 60 / 60 / 24 / 7));
					int num2 = (int)Math.Round((double)(num / 60 / 60 / 24 % 30));
					int value3 = (int)Math.Round((double)(num / 60 / 60 % 24));
					int value4 = (int)Math.Round((double)(num / 60 % 60));
					Math.Round((double)(num % 60));
					num2 = num2;
					projectToDoFields.ToDoYear = value;
					projectToDoFields.ToDoMonth = value2;
					projectToDoFields.ToDoDay = num2;
					projectToDoFields.ToDoHour = value3;
					projectToDoFields.ToDoMinute = value4;
				}
				base.ViewBag.ThisTicketIsTaken = false;
			}
			CRMspSelectCrmConversationWithID_Result cRMspSelectCrmConversationWithID_Result = Enumerable.FirstOrDefault<CRMspSelectCrmConversationWithID_Result>((IEnumerable<CRMspSelectCrmConversationWithID_Result>)_db.CRMspSelectCrmConversationWithID(_003C_003Ec__DisplayClass17_.cnvsId, lCID, result));
			if (cRMspSelectCrmConversationWithID_Result != null)
			{
				projectToDoFields.CnvsPriorityId = cRMspSelectCrmConversationWithID_Result.cnvsPriorityId;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationPriorities = SelectConversationPriority_SelectListItem(projectToDoFields.CnvsPriorityId);
		return View(projectToDoFields);
	}

	[AjaxOnly]
	[LoginAuthorize]
	public string SetProjectToDoFieldsInsertEdit(int ProjectId, int ConversationId, int ToDoYear = 0, int ToDoMonth = 0, int ToDoDay = 0, int ToDoHour = 0, int ToDoMinute = 0, int mode = 0, int cnvsReferUserId = 0, string cnvsReferUserDesc = "", string prjToDoTimeRegisterMain = "", string prjToDoTimeRegisterTimeMain = "", long prjToDoTimeSec = 0L, int cnvsPriorityId = 0)
	{
		string text = "";
		ProjectToDoFields projectToDoFields = new ProjectToDoFields();
		projectToDoFields.ProjectId = ProjectId;
		projectToDoFields.ConversationId = ConversationId;
		projectToDoFields.ToDoYear = ToDoYear;
		projectToDoFields.ToDoMonth = ToDoMonth;
		projectToDoFields.ToDoDay = ToDoDay;
		projectToDoFields.ToDoHour = ToDoHour;
		projectToDoFields.ToDoMinute = ToDoMinute;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			int? centerId2 = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId2 = UserLogin.CurrentUser.UserLastCId;
			}
			if (cnvsReferUserId == 0)
			{
				cnvsReferUserId = userId;
			}
			if (base.ModelState.IsValid)
			{
				switch (mode)
				{
				case 0:
				{
					if (projectToDoFields.ToDoYear > 0 || projectToDoFields.ToDoMonth > 0 || projectToDoFields.ToDoDay > 0 || projectToDoFields.ToDoHour > 0 || projectToDoFields.ToDoMinute > 0)
					{
						_ = DateTime.Now;
					}
					else if (UserLogin.IsUserAccess("frmMain", "actcTicketToDoTimeNotNull", UserLogin.CurrentUser))
					{
						text = Messages.ErrorNotAccess + "<br>" + Messages.msgErrorNotEnteredToDoTimeFields;
					}
					int result2 = 0;
					if (string.IsNullOrWhiteSpace(text))
					{
						CRMspSelectFoSetting_Result cRMspSelectFoSetting_Result = Enumerable.FirstOrDefault<CRMspSelectFoSetting_Result>((IEnumerable<CRMspSelectFoSetting_Result>)_db.CRMspSelectFoSetting(null, null, null, null, null, null, null, null, null, null, null, null, null, lCID, result, centerId));
						if (cRMspSelectFoSetting_Result != null && cRMspSelectFoSetting_Result.TicketAutoReplyAfterSetDoingTime.GetValueOrDefault())
						{
							CRMspSelectCrmProjectsById_Result cRMspSelectCrmProjectsById_Result = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(ProjectId, lCID, result));
							if (cRMspSelectCrmProjectsById_Result != null && cRMspSelectCrmProjectsById_Result.prjIsTicketNew.GetValueOrDefault())
							{
								string text3 = "";
								if (ToDoYear > 0)
								{
									text3 = text3 + ToDoYear + " " + Labels.Year + " ";
								}
								if (ToDoMonth > 0)
								{
									text3 = text3 + ToDoMonth + " " + Labels.Month + " ";
								}
								if (ToDoDay > 0)
								{
									text3 = text3 + ToDoDay + " " + Labels.Day + " ";
								}
								if (ToDoHour > 0)
								{
									text3 = text3 + ToDoHour + " " + Labels.Hour + " ";
								}
								if (ToDoMinute > 0)
								{
									text3 = text3 + ToDoMinute + " " + Labels.Minute + " ";
								}
								text3 = text3.Trim();
								ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
								ObjectParameter objectParameter2 = new ObjectParameter("ConversationId", 0);
								_dbI.CRMspInsertConversationAutoReplyAfterSetDoingTimeTicket(cRMspSelectCrmProjectsById_Result.prjCompanyId, cRMspSelectCrmProjectsById_Result.ProjectID, null, ConversationId, null, userId, cnvsReferUserId, value, registerDatePersian, ((int)value.DayOfWeek).ToString(), value.ToString("HH:mm:ss"), 0, value2, value3, appType, lCID, result, text3, objectParameter, objectParameter2, centerId2);
								if (objectParameter != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
								{
									foreach (string item in Enumerable.ToList<string>((IEnumerable<string>)objectParameter.Value.ToString().Split(new char[1] { '|' })))
									{
										if (item == "NotCnvsStatus")
										{
											text = text + Messages.msgErrorTicketAutoReplyConversationStatusNotConfiged + "<br>";
										}
										if (item == "EmpPerson")
										{
											text = text + Messages.msgErrorTicketAutoReplyCompanyPersonNotConfiged + "<br>";
										}
										else if (item.Contains("NotSendedSMS"))
										{
											text = text + string.Format(Messages.msgErrorSendSmsTo, item.Replace("NotSendedSMS[", "").Replace("]", "")) + "<br>";
										}
										else if (item.Contains("NotSendedEmail"))
										{
											text = text + string.Format(Messages.msgErrorSendEmailTo, item.Replace("NotSendedEmail[", "").Replace("]", "")) + "<br>";
										}
									}
								}
								if (objectParameter2 != null)
								{
									int.TryParse(objectParameter2.Value.ToString(), out result2);
								}
							}
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						string text4 = string.Format(Messages.TicketMsgCnvsReferDesc, DateTime.Now.ToString("yyyy/MM/dd"), UserLogin.CurrentUser.FullName);
						if (!string.IsNullOrWhiteSpace(cnvsReferUserDesc))
						{
							text4 = text4 + "\n" + cnvsReferUserDesc;
						}
						_dbI.CRMspUpdateProjectToDoTime(ProjectId, ToDoYear, ToDoMonth, ToDoDay, ToDoHour, ToDoMinute, DateTime.Now, null, userId, value3, value, registerDatePersian, appType, true, ConversationId, userId, cnvsReferUserId, text4, cnvsPriorityId, result2);
						base.ViewBag.Successfull = string.Format(Messages.msgSuccessfulySavedValues, Labels.TicketToDoUpdateFieldsTitle);
					}
					break;
				}
				case 1:
				{
					DateTime dateTime = DateTime.Now;
					DateTime now2 = DateTime.Now;
					DateTime dateTime2 = default(DateTime);
					string text2 = "";
					try
					{
						prjToDoTimeRegisterTimeMain = DateTime.Now.ToString("HH:mm:ss");
						if (!string.IsNullOrEmpty(prjToDoTimeRegisterMain))
						{
							text2 = PersianDate.GetFormatetdDate(prjToDoTimeRegisterMain.Replace("/", ""));
							dateTime = lCID switch
							{
								1065 => DateTime.Parse(text2 + " " + prjToDoTimeRegisterTimeMain, new PersianCulture()), 
								1025 => DateTime.Parse(text2 + " " + prjToDoTimeRegisterTimeMain, new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text2 + " " + prjToDoTimeRegisterTimeMain, new CultureInfo("en-US")), 
							};
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					DateTime dateTime3 = dateTime;
					if (ProjectId > 0)
					{
						CRMspGetTicketFirstDoingInfo_Result cRMspGetTicketFirstDoingInfo_Result = Enumerable.FirstOrDefault<CRMspGetTicketFirstDoingInfo_Result>((IEnumerable<CRMspGetTicketFirstDoingInfo_Result>)_dbI.CRMspGetTicketFirstDoingInfo(ProjectId));
						if (cRMspGetTicketFirstDoingInfo_Result != null && cRMspGetTicketFirstDoingInfo_Result.FirstRegisterDate.HasValue)
						{
							dateTime3 = cRMspGetTicketFirstDoingInfo_Result.FirstRegisterDate.Value;
						}
					}
					now2 = dateTime3;
					if (projectToDoFields.ToDoYear > 0)
					{
						now2 = now2.AddYears(projectToDoFields.ToDoYear.GetValueOrDefault());
					}
					if (projectToDoFields.ToDoMonth > 0)
					{
						now2 = now2.AddMonths(projectToDoFields.ToDoMonth.GetValueOrDefault());
					}
					if (projectToDoFields.ToDoDay > 0)
					{
						now2 = now2.AddDays(projectToDoFields.ToDoDay.GetValueOrDefault());
					}
					if (projectToDoFields.ToDoHour > 0)
					{
						now2 = now2.AddHours(projectToDoFields.ToDoHour.GetValueOrDefault());
					}
					if (projectToDoFields.ToDoMinute > 0)
					{
						now2 = now2.AddMinutes(projectToDoFields.ToDoMinute.GetValueOrDefault());
					}
					prjToDoTimeSec = projectToDoFields.ToDoYear.GetValueOrDefault() * 31556926 + projectToDoFields.ToDoMonth.GetValueOrDefault() * 2629743 + projectToDoFields.ToDoDay.GetValueOrDefault() * 86400 + projectToDoFields.ToDoHour.GetValueOrDefault() * 3600 + projectToDoFields.ToDoMinute.GetValueOrDefault() * 60;
					text = "1|" + now2.ToString("yyyy/MM/dd HH:mm:ss") + "|" + dateTime.ToString("yyyy/MM/dd HH:mm:ss") + "|" + prjToDoTimeSec;
					break;
				}
				}
			}
			else
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				text = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
			text = ex.Message;
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			text = "1";
		}
		return text;
	}

	public ActionResult AllNotFinishedTicket_Read([DataSourceRequest] DataSourceRequest request, int lastRowNumber = 0, int pageSize = 200, int crmUserId = 0, string prjTitleGroup = "", int prjTitleGroupId = 0, int cnvsStatusGroupId = 0, int cnvsStatusId = 0, int priorityId = 0)
	{
		List<CRMspSelectTicketNotFinished_Result> list = new List<CRMspSelectTicketNotFinished_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			list = Enumerable.ToList<CRMspSelectTicketNotFinished_Result>((IEnumerable<CRMspSelectTicketNotFinished_Result>)_dbI.CRMspSelectTicketNotFinished(userId, lastRowNumber, pageSize, prjTitleGroup, DateTime.Now, lCID, result, crmUserId: crmUserId, prjTitleGroupId: prjTitleGroupId, cnvsStatusGroupId: cnvsStatusGroupId, cnvsStatusId: cnvsStatusId, priorityId: priorityId, centerId: result2));
			if (list != null)
			{
				foreach (CRMspSelectTicketNotFinished_Result item in list)
				{
					item.prjStartDatePersian = item.prjStartDate?.ToString("yyyy/MM/dd HH:mm");
					item.LastCnvsDatePersian = item.LastCnvsDate?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimePersian = item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeRegisterPersian = item.prjToDoTimeRegister?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeDonePersian = item.prjToDoTimeDone?.ToString("yyyy/MM/dd HH:mm");
					item.prjValidityOrdItemExpireDatePersian = (item.prjValidityOrdItemExpireDate.HasValue ? item.prjValidityOrdItemExpireDate?.ToString("yyyy/MM/dd") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult AllTodayTickets_Read([DataSourceRequest] DataSourceRequest request, int lastRowNumber = 0, int pageSize = 200, int crmUserId = 0, int prjTitleGroupId = 0, int cnvsStatusGroupId = 0, int cnvsStatusId = 0, string selectedDate = "", int priorityId = 0)
	{
		List<CRMspSelectTicketDaily_Result> list = new List<CRMspSelectTicketDaily_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime value = DateTime.Now;
			string text = "";
			try
			{
				if (!string.IsNullOrEmpty(selectedDate))
				{
					text = PersianDate.GetFormatetdDate(selectedDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						selectedDate = value.ToString("yyyyMMdd");
						break;
					case 1025:
						value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						selectedDate = value.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						value = DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						selectedDate = value.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			list = Enumerable.ToList<CRMspSelectTicketDaily_Result>((IEnumerable<CRMspSelectTicketDaily_Result>)_dbI.CRMspSelectTicketDaily(value, value, userId, lastRowNumber, pageSize, "", DateTime.Now, lCID, result, crmUserId: crmUserId, prjTitleGroupId: prjTitleGroupId, cnvsStatusGroupId: cnvsStatusGroupId, cnvsStatusId: cnvsStatusId, priorityId: priorityId, centerId: result2));
			if (list != null)
			{
				foreach (CRMspSelectTicketDaily_Result item in list)
				{
					item.prjStartDatePersian = item.prjStartDate?.ToString("yyyy/MM/dd HH:mm");
					item.LastCnvsDatePersian = item.LastCnvsDate?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimePersian = item.prjToDoTime?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeRegisterPersian = item.prjToDoTimeRegister?.ToString("yyyy/MM/dd HH:mm");
					item.prjToDoTimeDonePersian = item.prjToDoTimeDone?.ToString("yyyy/MM/dd HH:mm");
					item.prjValidityOrdItemExpireDatePersian = (item.prjValidityOrdItemExpireDate.HasValue ? item.prjValidityOrdItemExpireDate?.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcTicketChangeProjectTitleGroup")]
	public ActionResult ChangeTicketTitleGroup(int prjId = 0, string titleGroup = "")
	{
		_003C_003Ec__DisplayClass21_0 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_0();
		_003C_003Ec__DisplayClass21_.prjId = prjId;
		base.ViewBag.PrjId = _003C_003Ec__DisplayClass21_.prjId;
		base.ViewBag.TitleGroup = titleGroup;
		base.ViewBag.TicketsPrjTitleGroups = GetTicketsProjectTitleGroupsSelectListItem();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
		ParameterExpression val = Expression.Parameter(typeof(CrmProjects_Lang), "x");
		List<CrmProjects_Lang> list2 = Enumerable.ToList<CrmProjects_Lang>((IEnumerable<CrmProjects_Lang>)Queryable.Where<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass21_, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		if (list2 != null && list2.Count > 0)
		{
			list.AddRange(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list2, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang x) => new CommonMultiLanguageViewModel
			{
				LanguageId = x.LanguageID,
				Value = x.prjTitleGroup
			})));
		}
		base.ViewBag.TitleGroupLangJs = JsonConvert.SerializeObject(list);
		return View();
	}

	[LoginAuthorize]
	[HttpPost]
	public string SetTicketTitleGroup(int prjId = 0, string titleGroup = "", string titleGroupLangJs = "")
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
			int userId = UserLogin.CurrentUser.UserId;
			string appType = Configuration.AppType;
			DateTime now = DateTime.Now;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			if (prjId > 0)
			{
				_dbI.CRMspUpdateProjectTitleGroup(prjId, titleGroup, titleGroupLangJs, userId, value, value2, registerDatePersian: now.ToString("yyyyMMdd", new PersianCulture()), registerDate: now, appType: appType, languageID: lCID);
			}
			else
			{
				result = Messages.msgErrorProjectNotSelected;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByMonth_Result> ChartTicketByMonth(string date = "")
	{
		List<CRMspChartTicketByMonth_Result> result = new List<CRMspChartTicketByMonth_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByMonth_Result> list = Enumerable.ToList<CRMspChartTicketByMonth_Result>((IEnumerable<CRMspChartTicketByMonth_Result>)_dbI.CRMspChartTicketByMonth(value, lCID, result2, Labels.All, Labels.Closed, Labels.NotClosed, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByMonthJs(string date = "")
	{
		return JsonConvert.SerializeObject(ChartTicketByMonth(date));
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByMonthPrjTitleGroup_Result> ChartTicketByMonthPrjTitleGroup(string date = "", bool? isFinished = null)
	{
		List<CRMspChartTicketByMonthPrjTitleGroup_Result> result = new List<CRMspChartTicketByMonthPrjTitleGroup_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByMonthPrjTitleGroup_Result> list = Enumerable.ToList<CRMspChartTicketByMonthPrjTitleGroup_Result>((IEnumerable<CRMspChartTicketByMonthPrjTitleGroup_Result>)_dbI.CRMspChartTicketByMonthPrjTitleGroup(value, isFinished, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByMonthPrjTitleGroupJs(string date = "", bool? isFinished = null)
	{
		return JsonConvert.SerializeObject(ChartTicketByMonthPrjTitleGroup(date, isFinished));
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByDay_Result> ChartTicketByDay(string date = "")
	{
		List<CRMspChartTicketByDay_Result> result = new List<CRMspChartTicketByDay_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByDay_Result> list = Enumerable.ToList<CRMspChartTicketByDay_Result>((IEnumerable<CRMspChartTicketByDay_Result>)_dbI.CRMspChartTicketByDay(value, lCID, result2, Labels.All, Labels.Closed, Labels.NotClosed, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByDayJs(string date = "")
	{
		return JsonConvert.SerializeObject(ChartTicketByDay(date));
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByDayPrjTitleGroup_Result> ChartTicketByDayPrjTitleGroup(string date = "", bool? isFinished = null)
	{
		List<CRMspChartTicketByDayPrjTitleGroup_Result> result = new List<CRMspChartTicketByDayPrjTitleGroup_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByDayPrjTitleGroup_Result> list = Enumerable.ToList<CRMspChartTicketByDayPrjTitleGroup_Result>((IEnumerable<CRMspChartTicketByDayPrjTitleGroup_Result>)_dbI.CRMspChartTicketByDayPrjTitleGroup(value, isFinished, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByDayPrjTitleGroupJs(string date = "", bool? isFinished = null)
	{
		return JsonConvert.SerializeObject(ChartTicketByDayPrjTitleGroup(date, isFinished));
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByMonthWithUserId_Result> ChartTicketByMonthWithUserId(string date = "", int? selectedUserId = null)
	{
		List<CRMspChartTicketByMonthWithUserId_Result> result = new List<CRMspChartTicketByMonthWithUserId_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByMonthWithUserId_Result> list = Enumerable.ToList<CRMspChartTicketByMonthWithUserId_Result>((IEnumerable<CRMspChartTicketByMonthWithUserId_Result>)_dbI.CRMspChartTicketByMonthWithUserId(value, UserLogin.CurrentUser.UserId, selectedUserId, 7, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByMonthWithUserIdJs(string date = "", int? selectedUserId = null)
	{
		return JsonConvert.SerializeObject(ChartTicketByMonthWithUserId(date, selectedUserId));
	}

	[LoginAuthorize]
	public List<CRMspChartTicketByDayWithUserId_Result> ChartTicketByDayWithUserId(string date = "", int selectedUserId = 0)
	{
		List<CRMspChartTicketByDayWithUserId_Result> result = new List<CRMspChartTicketByDayWithUserId_Result>();
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
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartTicketByDayWithUserId_Result> list = Enumerable.ToList<CRMspChartTicketByDayWithUserId_Result>((IEnumerable<CRMspChartTicketByDayWithUserId_Result>)_dbI.CRMspChartTicketByDayWithUserId(UserLogin.CurrentUser.UserId, selectedUserId, value, 7, lCID, result2, result3));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ChartTicketByDayWithUserIdJs(string date = "", int selectedUserId = 0)
	{
		return JsonConvert.SerializeObject(ChartTicketByDayWithUserId(date, selectedUserId));
	}

	[AjaxOnly]
	[LoginAuthorize]
	public JsonResult GetMsgUser(int selectedId = 0, bool showOpenTickets = false)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			if (list2 != null)
			{
				List<CRMspSelectTicketNotFinished_Result> list3 = new List<CRMspSelectTicketNotFinished_Result>();
				if (showOpenTickets)
				{
					list3 = Enumerable.ToList<CRMspSelectTicketNotFinished_Result>((IEnumerable<CRMspSelectTicketNotFinished_Result>)_dbI.CRMspSelectTicketNotFinished(UserLogin.CurrentUser.UserId, 0, -1, null, DateTime.Now, lCID, result, null, null, null, null, null, result2));
				}
				foreach (CRMspSelectUserForLinkedType_Result i in list2)
				{
					string text = i.UserName;
					if (showOpenTickets)
					{
						int num = 0;
						if (list3 != null)
						{
							num = Enumerable.ToList<CRMspSelectTicketNotFinished_Result>(Enumerable.Where<CRMspSelectTicketNotFinished_Result>((IEnumerable<CRMspSelectTicketNotFinished_Result>)list3, (Func<CRMspSelectTicketNotFinished_Result, bool>)((CRMspSelectTicketNotFinished_Result x) => x.LastCnvsUserId == i.LinkedUserId))).Count;
						}
						if (num > 0)
						{
							text = text + " ( " + Labels.cTicketAllNotFinished + " : " + num + " )";
						}
					}
					list.Add(new SelectListItem
					{
						Text = text,
						Value = i.LinkedUserId.ToString(),
						Selected = (i.LinkedUserId == selectedId)
					});
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectConversationPriority_Result> SelectConversationPriority()
	{
		List<CRMspSelectConversationPriority_Result> result = new List<CRMspSelectConversationPriority_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectConversationPriority_SelectListItem(int? selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectConversationPriority_Result> list2 = SelectConversationPriority();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)list2, (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result x) => new SelectListItem
				{
					Text = x.Priority,
					Value = x.ConversationPriorityID.ToString(),
					Selected = (x.ConversationPriorityID == selectedId)
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<CRMspSelectProjectTitleGroups_Result> SelectProjectTitleGroups()
	{
		List<CRMspSelectProjectTitleGroups_Result> result = new List<CRMspSelectProjectTitleGroups_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectProjectTitleGroups_Result>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)_dbI.CRMspSelectProjectTitleGroups(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectProjectTitleGroups_SelectListItem(int? selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectProjectTitleGroups_Result> list2 = SelectProjectTitleGroups();
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectProjectTitleGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectTitleGroups_Result>)list2, (Func<CRMspSelectProjectTitleGroups_Result, SelectListItem>)((CRMspSelectProjectTitleGroups_Result x) => new SelectListItem
			{
				Text = x.ProjectTitleGroup,
				Value = x.ProjectTitleGroupId.ToString(),
				Selected = (x.ProjectTitleGroupId == selectedId)
			})));
		}
		return list;
	}

	public List<CRMspSelectTicketProjectTitleAndTitleGroup_Result> SelectTicketProjectTitleAndTitleGroup()
	{
		List<CRMspSelectTicketProjectTitleAndTitleGroup_Result> result = new List<CRMspSelectTicketProjectTitleAndTitleGroup_Result>();
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
			result = Enumerable.ToList<CRMspSelectTicketProjectTitleAndTitleGroup_Result>((IEnumerable<CRMspSelectTicketProjectTitleAndTitleGroup_Result>)_dbI.CRMspSelectTicketProjectTitleAndTitleGroup(lCID, result2, result3));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectTicketProjectTitleAndTitleGroup_SelectListItem_I(string selectedId = "")
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectTicketProjectTitleAndTitleGroup_Result> list2 = SelectTicketProjectTitleAndTitleGroup();
		list.AddRange(Enumerable.Select<CRMspSelectTicketProjectTitleAndTitleGroup_Result, SelectListItem>((IEnumerable<CRMspSelectTicketProjectTitleAndTitleGroup_Result>)list2, (Func<CRMspSelectTicketProjectTitleAndTitleGroup_Result, SelectListItem>)((CRMspSelectTicketProjectTitleAndTitleGroup_Result x) => new SelectListItem
		{
			Text = x.prjTitleGroup + " ( " + x.prjcnvsStatusGroup + " )",
			Value = x.prjTitleGroupId + "-" + x.prjcnvsStatusGroupId,
			Selected = (x.prjTitleGroupId + "-" + x.prjcnvsStatusGroupId == selectedId)
		})));
		return list;
	}

	public List<CRMspSelectConversationStatus_Result> SelectConversationStatus(int groupId = 0)
	{
		List<CRMspSelectConversationStatus_Result> result = new List<CRMspSelectConversationStatus_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (groupId > 0)
			{
				result = Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)_db.CRMspSelectConversationStatus(groupId, lCID, result2));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string SelectConversationStatusJs(int groupId = 0)
	{
		return JsonConvert.SerializeObject(SelectConversationStatus(groupId));
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectDelayTicketsCnt()
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
			int value = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspSelectDelayTicketsCnt_Result cRMspSelectDelayTicketsCnt_Result = Enumerable.FirstOrDefault<CRMspSelectDelayTicketsCnt_Result>((IEnumerable<CRMspSelectDelayTicketsCnt_Result>)_dbII.CRMspSelectDelayTicketsCnt(DateTime.Now, UserLogin.CurrentUser.UserId, value, value2, value3, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, result, result2));
			if (cRMspSelectDelayTicketsCnt_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(cRMspSelectDelayTicketsCnt_Result)
				});
				if (cRMspSelectDelayTicketsCnt_Result.TotalIntMsgSendedSeperateByUsers > 0)
				{
					PushNotif.NewIntMsgNotify();
				}
				_ = cRMspSelectDelayTicketsCnt_Result.TotalSmsSendedToTankSeperateByUsers;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectBusyTicketsCnt()
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
			int value = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			CRMspSelectBusyTicketsCnt_Result cRMspSelectBusyTicketsCnt_Result = Enumerable.FirstOrDefault<CRMspSelectBusyTicketsCnt_Result>((IEnumerable<CRMspSelectBusyTicketsCnt_Result>)_dbII.CRMspSelectBusyTicketsCnt(DateTime.Now, UserLogin.CurrentUser.UserId, value, value2, value3, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, result, result2));
			if (cRMspSelectBusyTicketsCnt_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(cRMspSelectBusyTicketsCnt_Result)
				});
				if (cRMspSelectBusyTicketsCnt_Result.TotalIntMsgSendedSeperateByUsers > 0)
				{
					PushNotif.NewIntMsgNotify();
				}
				_ = cRMspSelectBusyTicketsCnt_Result.TotalSmsSendedToTankSeperateByUsers;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectUnhappyTicketsCnt()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int value = ((Financial.Get() != null) ? Financial.Get().Id : 0);
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			CRMspSelectUnhappyTicketsCnt_Result cRMspSelectUnhappyTicketsCnt_Result = Enumerable.FirstOrDefault<CRMspSelectUnhappyTicketsCnt_Result>((IEnumerable<CRMspSelectUnhappyTicketsCnt_Result>)_dbII.CRMspSelectUnhappyTicketsCnt(DateTime.Now, UserLogin.CurrentUser.UserId, value, value2, value3, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, lCID, result, result2));
			if (cRMspSelectUnhappyTicketsCnt_Result != null)
			{
				list.Add(new SelectListItem
				{
					Text = "Data",
					Value = JsonConvert.SerializeObject(cRMspSelectUnhappyTicketsCnt_Result)
				});
				if (cRMspSelectUnhappyTicketsCnt_Result.TotalIntMsgSendedSeperateByUsers > 0)
				{
					PushNotif.NewIntMsgNotify();
				}
				_ = cRMspSelectUnhappyTicketsCnt_Result.TotalSmsSendedToTankSeperateByUsers;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(new SelectListItem
			{
				Text = "Error",
				Value = ex.Message
			});
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string IncDate(string date = "", int inc = 1)
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
			DateTime dateTime = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			string text = dateTime.AddDays(-1 * inc).ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "PriorDate",
				Value = text
			});
			base.ViewBag.PriorDate = text;
			string text2 = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDate",
				Value = text2
			});
			base.ViewBag.CurrDate = text2;
			string text3 = dateTime.ToString("dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateDayNum",
				Value = text3
			});
			base.ViewBag.CurrDateDayNum = text3;
			string text4 = dateTime.ToString("MM", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateMonthNum",
				Value = text4
			});
			base.ViewBag.CurrDateMonthNum = text4;
			string text5 = dateTime.ToString("MMM", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateMonthName",
				Value = text5
			});
			base.ViewBag.CurrDateMonthName = text5;
			string text6 = dateTime.ToString("yyyy", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateYear",
				Value = text6
			});
			base.ViewBag.CurrDateYear = text6;
			string text7 = dateTime.AddDays(inc).ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "NextDate",
				Value = text7
			});
			base.ViewBag.NextDate = text7;
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return JsonConvert.SerializeObject(list);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
