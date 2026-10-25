using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Http;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace CRMIdeal.Controllers;

public class OutlookAPIController : ApiController
{
	public class InsertReminderViewModel : CrmUserTasks
	{
		public string UserTaskPriority { get; set; }

		public string UserTaskGroup { get; set; }

		public int? DefaultLanguageID { get; set; }
	}

	public enum APIServiceResultStatus
	{
		Success = 1,
		Fail,
		Error
	}

	public class APIServiceResult<T>
	{
		public T Data;

		[JsonConverter(typeof(StringEnumConverter))]
		public APIServiceResultStatus Status;

		public string Message;

		public APIServiceResult()
		{
			Status = APIServiceResultStatus.Success;
		}

		public APIServiceResult(APIServiceResultStatus type)
		{
			Status = type;
		}
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private static string _Service_Token = "OutlookLinkIdeal";

	private static string _Service_Username = "Shir";

	private static string _Service_Password = "Palang";

	[HttpPost]
	public APIServiceResult<int> GetUserId(string username = "", string password = "", string crmUsername = "", string crmPassword = "", string activeDirectoryUsername = "")
	{
		string text = "";
		int data = 0;
		APIServiceResultStatus status = APIServiceResultStatus.Fail;
		try
		{
			string text2 = CodeDecode.Codding(_Service_Token);
			string text3 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text3 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			if (string.IsNullOrWhiteSpace(text3) || text3 != text2)
			{
				text = Messages.msgErrorNotEnteredToken;
				data = 0;
				status = APIServiceResultStatus.Error;
			}
			if (username != CodeDecode.ComputeSHA256Hasher(_Service_Username) || password != CodeDecode.ComputeSHA256Hasher(_Service_Password))
			{
				text = Messages.msgErrorCheckUsernamePassword;
				status = APIServiceResultStatus.Error;
				data = 0;
			}
			if (string.IsNullOrWhiteSpace(crmUsername) || string.IsNullOrWhiteSpace(crmPassword))
			{
				text = Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = 0;
			}
			if (text == "")
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspLoadUserLoginInfo_Result cRMspLoadUserLoginInfo_Result = Enumerable.FirstOrDefault<CRMspLoadUserLoginInfo_Result>((IEnumerable<CRMspLoadUserLoginInfo_Result>)_db.CRMspLoadUserLoginInfo(0, crmUsername, crmPassword, lCID, result, activeDirectoryUsername));
				if (cRMspLoadUserLoginInfo_Result != null)
				{
					data = cRMspLoadUserLoginInfo_Result.UserId;
					text = "";
					status = APIServiceResultStatus.Success;
				}
				else
				{
					text = Messages.msgEnteredDataInvalid;
					status = APIServiceResultStatus.Error;
					data = 0;
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "(" + ex.Message + ")";
			data = 0;
			status = APIServiceResultStatus.Error;
		}
		return new APIServiceResult<int>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public APIServiceResult<bool> DeleteReminder(string username = "", string password = "", string outlookId = "")
	{
		string text = "";
		bool data = false;
		APIServiceResultStatus status = APIServiceResultStatus.Fail;
		try
		{
			string text2 = CodeDecode.Codding(_Service_Token);
			string text3 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text3 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			if (string.IsNullOrWhiteSpace(text3) || text3 != text2)
			{
				text = Messages.msgErrorNotEnteredToken;
				data = false;
				status = APIServiceResultStatus.Error;
			}
			if (username != CodeDecode.ComputeSHA256Hasher(_Service_Username) || password != CodeDecode.ComputeSHA256Hasher(_Service_Password))
			{
				text = Messages.msgErrorCheckUsernamePassword;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (string.IsNullOrWhiteSpace(outlookId ?? ""))
			{
				text = Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			_ = text == "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "(" + ex.Message + ")";
			data = false;
			status = APIServiceResultStatus.Error;
		}
		return new APIServiceResult<bool>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	public APIServiceResult<bool> UpdateReminderLinkId(string username = "", string password = "", int userId = 0, int id = 0, string outlookId = "")
	{
		string text = "";
		bool data = false;
		APIServiceResultStatus status = APIServiceResultStatus.Fail;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string text2 = CodeDecode.Codding(_Service_Token);
			string text3 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text3 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			if (string.IsNullOrWhiteSpace(text3) || text3 != text2)
			{
				text = Messages.msgErrorNotEnteredToken;
				data = false;
				status = APIServiceResultStatus.Error;
			}
			if (username != CodeDecode.ComputeSHA256Hasher(_Service_Username) || password != CodeDecode.ComputeSHA256Hasher(_Service_Password))
			{
				text = Messages.msgErrorCheckUsernamePassword;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (userId == 0)
			{
				text = Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (id <= 0)
			{
				text = Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (string.IsNullOrWhiteSpace(outlookId ?? ""))
			{
				text = Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (text == "")
			{
				ObjectParameter updatedId = new ObjectParameter("UpdatedId", 0);
				_dbII.CRMspUpdateUserTaskLinkIdStr(id, outlookId, userId, CRMIdeal.Classes.Common.Configuration.AppType, lCID, result, DateTime.Now, DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")), updatedId);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "(" + ex.Message + ")";
			data = false;
			status = APIServiceResultStatus.Error;
		}
		return new APIServiceResult<bool>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public APIServiceResult<bool> InsertUpdateUserTask(string username = "", string password = "", string js = "")
	{
		string text = "";
		bool data = false;
		APIServiceResultStatus status = APIServiceResultStatus.Fail;
		try
		{
			string text2 = CodeDecode.Codding(_Service_Token);
			string text3 = "";
			if (base.Request.Headers.Contains("token"))
			{
				text3 = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
			}
			List<InsertReminderViewModel> list = new List<InsertReminderViewModel>();
			if (string.IsNullOrWhiteSpace(text3) || text3 != text2)
			{
				text += Messages.msgErrorNotEnteredToken;
				data = false;
				status = APIServiceResultStatus.Error;
			}
			if (username != CodeDecode.ComputeSHA256Hasher(_Service_Username) || password != CodeDecode.ComputeSHA256Hasher(_Service_Password))
			{
				text += Messages.msgErrorCheckUsernamePassword;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (string.IsNullOrWhiteSpace((js ?? "").Replace("[]", "").Replace("{}", "").Trim()))
			{
				text += Messages.msgEnteredDataInvalid;
				status = APIServiceResultStatus.Error;
				data = false;
			}
			if (string.IsNullOrWhiteSpace(js))
			{
				text = text + Messages.msgEnteredDataInvalid + "\n";
				status = APIServiceResultStatus.Error;
				data = false;
			}
			else
			{
				try
				{
					List<InsertReminderViewModel> list2 = JsonConvert.DeserializeObject<List<InsertReminderViewModel>>(js);
					if (list2 == null || list2.Count <= 0)
					{
						text = text + Messages.msgErrorFieldRequired + "[Data Empty]\n";
					}
					else
					{
						list = list2;
					}
				}
				catch (Exception ex)
				{
					text = text + "Error: " + ex.Message + "\n";
				}
			}
			if (text == "")
			{
				DateTime now = DateTime.Now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = CRMIdeal.Classes.Common.Configuration.AppType;
				foreach (InsertReminderViewModel item in list)
				{
					string userTaskTitle = item.UserTaskTitle;
					try
					{
						ObjectParameter foundedId = new ObjectParameter("FoundedId", 0);
						ObjectParameter insertedId = new ObjectParameter("InsertedId", 0);
						ObjectParameter updatedId = new ObjectParameter("UpdatedId", 0);
						_dbII.CRMspInsertUpdateUserTaskFromOutlook(item.UserTaskDatePersian, item.UserTaskDate, item.UserTaskTime, item.UserTaskTitle, item.UserTaskDescription, item.UserTaskPriorityId, item.UserTaskPriority, item.UserTaskGroupId, item.UserTaskGroup, item.UserTaskShowAllarm, item.UserTaskDidIt, item.UserTaskRemindDate, item.UserTaskRemindTime, item.UserTaskRemindDateTime, item.UserTaskIsPublic, item.UserTaskTimeEnd, item.ObjectTypeId, item.ObjectId, item.UserTaskNoTimeOverlap, item.UserTaskCompanyIds, item.UserTaskRepeatDaily, item.UserTaskRepeatWeekly, item.UserTaskRepeatMonthly, item.UserTaskRepeatYearly, item.UserTaskRemindRepeatDaily, item.UserTaskRemindRepeatWeekly, item.UserTaskRemindRepeatMonthly, item.UserTaskRemindRepeatYearly, item.Year1, item.Month1, appType, item.LanguageID, item.DefaultLanguageID, item.UserId, now, registerDatePersian, item.FirstRegisterUserId, item.FirstRegisterDatePersian, item.FirstRegisterDate, item.UserTaskLinkIdStr, foundedId, insertedId, updatedId, item.UserTaskDateEnd, item.UserTaskDateEndPersian);
					}
					catch (Exception ex2)
					{
						text = text + userTaskTitle + " (Error: " + ex2.Message + ")";
						data = false;
						status = APIServiceResultStatus.Error;
					}
				}
			}
		}
		catch (Exception ex3)
		{
			Public.InsExceptToElmah(ex3);
			text = text + Messages.msgErrorRunFunction + "(" + ex3.Message + ")";
			data = false;
			status = APIServiceResultStatus.Error;
		}
		return new APIServiceResult<bool>
		{
			Message = text,
			Data = data,
			Status = status
		};
	}
}
