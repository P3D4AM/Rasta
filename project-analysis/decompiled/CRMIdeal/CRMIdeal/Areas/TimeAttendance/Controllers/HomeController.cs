using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.Leave.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.TimeAttendance.Controllers;

public class HomeController : Controller
{
	public const string _TAD_Key_QRCode = "tadQRCode";

	public const string _TAD_Key_QRCode_Exit = "tadQRCodeExit";

	public CRMSpEntities _db = new CRMSpEntities();

	public CRMSpIEntities _dbI = new CRMSpIEntities();

	public CRMSpIIEntities _dbII = new CRMSpIIEntities();

	public CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	private const int _LeaveTypeId_HourlyLeave = 1;

	private const int _LeaveTypeId_DailyLeave = 2;

	private const int _LeaveTypeId_HourlyMission = 3;

	private const int _LeaveTypeId_DailyMission = 4;

	[LoginAuthorize]
	public ActionResult Index(int userId = 0)
	{
		if (userId == 0)
		{
			userId = UserLogin.CurrentUser.UserId;
		}
		base.ViewBag.UserId = userId;
		GetUserShiftWorkingTimeByDate(userId);
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertTimeAttendanceDetail(int? shiftWorkingTimeId, int? leaveId, string leaveStepIds = null, string userLoginIP = null, int? userLoginId = null, DateTime? userLoginDate = null, string userLoginDateStr = "")
	{
		List<string> list = new List<string>();
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			userLoginId = ((userLoginId.GetValueOrDefault() == 0) ? userLoginId : new int?(userId));
			userLoginIP = ((!string.IsNullOrWhiteSpace(userLoginIP)) ? userLoginIP : base.Request.UserHostAddress);
			if (!userLoginDate.HasValue)
			{
				userLoginDate = ((!string.IsNullOrWhiteSpace(userLoginDateStr)) ? DateTimeClass.GetDateFromPersian(userLoginDateStr) : new DateTime?(now));
			}
			if (shiftWorkingTimeId.GetValueOrDefault() == 0 && leaveId.GetValueOrDefault() == 0)
			{
				list.Add(Messages.msgErrorFieldRequired);
			}
			else if (!userLoginDate.HasValue)
			{
				list.Add(string.Format(Messages.msgErrorFieldRequired, Labels.Date));
			}
			else
			{
				_dbII.CRMspInsertTimeAttendanceDetail(shiftWorkingTimeId, leaveId, leaveStepIds, userLoginIP, userLoginId, userLoginDate, userLoginDate?.ToString("yyyyMMdd", new PersianCulture()), userId, value, registerDatePersian, value3, value2, appType, lCID, result);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			list.Add(Messages.MsgErrorDoneOperation);
		}
		return string.Join("<br />", list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string InsertTimeAttendanceDetailWithQR(int? shiftWorkingTimeId, int? leaveId, string leaveStepIds = null, ParamViewModel p = null)
	{
		List<string> list = new List<string>();
		int userId = UserLogin.CurrentUser.UserId;
		LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = null;
		if (p.SUId.GetValueOrDefault() != 0 && p.GUId.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(p.KeyValue))
		{
			loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(p.GUId.GetValueOrDefault());
		}
		if (loginUserSmartTimeAttendanceViewModel != null && p.GUId.GetValueOrDefault() != 0 && p.GUId == userId)
		{
			string text = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "";
			if (text.Trim() != "" && text == p.KeyValue)
			{
				return InsertTimeAttendanceDetail(shiftWorkingTimeId, leaveId, leaveStepIds, p.SIP, p.SUId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			}
			list.Add(Messages.MsgErrorDoneOperationTryAgain);
		}
		return string.Join("<br />", list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GenerateQRCode_Old(int? userId = null)
	{
		AdvanceResultViewModel advanceResultViewModel = new AdvanceResultViewModel();
		try
		{
			int userId2 = UserLogin.CurrentUser.UserId;
			if (userId.GetValueOrDefault() != 0)
			{
				ParamViewModel paramObject = Public.GetParamObject(new ParamViewModel
				{
					KeyName = "tadQRCode",
					KeyValue = Guid.NewGuid().ToString()
				});
				UserLoginSmartTimeAttendance.Update(userId2, "", paramObject.KeyValue, "");
				advanceResultViewModel.Code = XorCipher.EncryptByPrivateKey(JsonConvert.SerializeObject(paramObject, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				}));
				advanceResultViewModel.Status = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultViewModel.Errors.Add(Messages.MsgErrorDoneOperation);
			advanceResultViewModel.Status = CommonResultStatusViewModel.Error;
		}
		return JsonConvert.SerializeObject(advanceResultViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetShiftWorkingDetails()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int? centerId = currentUser?.UserLastCId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectUsersById_Result cRMspSelectUsersById_Result = Enumerable.FirstOrDefault<CRMspSelectUsersById_Result>((IEnumerable<CRMspSelectUsersById_Result>)_db.CRMspSelectUsersById(currentUser.UserId, lCID, result, centerId));
			if (cRMspSelectUsersById_Result != null && cRMspSelectUsersById_Result.ShiftWorkingId.GetValueOrDefault() != 0)
			{
				list.Add(new SelectListItem
				{
					Text = "sw",
					Value = GetShiftWorkingById_Json(cRMspSelectUsersById_Result.ShiftWorkingId.GetValueOrDefault())
				});
				list.Add(new SelectListItem
				{
					Text = "swt",
					Value = GetActiveShiftWorkingTimes_Json(cRMspSelectUsersById_Result.ShiftWorkingId.GetValueOrDefault())
				});
			}
			List<CRMspSelectLeaveByDate_Result> leaves = GetLeaveByDate();
			list.Add(new SelectListItem
			{
				Text = "leaves",
				Value = JsonConvert.SerializeObject(leaves)
			});
			List<CRMspSelectLeaveSteps_Result> list2 = new List<CRMspSelectLeaveSteps_Result>();
			int i;
			for (i = 0; i < leaves.Count; i++)
			{
				if (list2.FindIndex((CRMspSelectLeaveSteps_Result x) => x.LeaveStepGroupId == leaves[i].StepGroupId) == -1)
				{
					list2.AddRange(GetLeaveSteps(leaves[i].StepGroupId.GetValueOrDefault()));
				}
			}
			list.Add(new SelectListItem
			{
				Text = "leavesSteps",
				Value = JsonConvert.SerializeObject(list2)
			});
			list.Add(new SelectListItem
			{
				Text = "TA",
				Value = GetTimeAttendanceByDate_Json()
			});
			list.Add(new SelectListItem
			{
				Text = "TAD",
				Value = GetTimeAttendanceDetail_Json()
			});
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(list);
	}

	[HttpPost]
	[LoginAuthorize]
	public CRMspSelectShiftWorkingById_Result GetShiftWorkingById(int swId = 0)
	{
		CRMspSelectShiftWorkingById_Result result = new CRMspSelectShiftWorkingById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (swId != 0)
			{
				CRMspSelectShiftWorkingById_Result cRMspSelectShiftWorkingById_Result = Enumerable.FirstOrDefault<CRMspSelectShiftWorkingById_Result>((IEnumerable<CRMspSelectShiftWorkingById_Result>)_dbII.CRMspSelectShiftWorkingById(swId, lCID, result2));
				if (cRMspSelectShiftWorkingById_Result != null)
				{
					result = cRMspSelectShiftWorkingById_Result;
				}
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
	public string GetShiftWorkingById_Json(int swId = 0)
	{
		return JsonConvert.SerializeObject(GetShiftWorkingById(swId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectActiveShiftWorkingTimes_Result> GetActiveShiftWorkingTimes(int swId = 0)
	{
		List<CRMspSelectActiveShiftWorkingTimes_Result> result = new List<CRMspSelectActiveShiftWorkingTimes_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (swId != 0)
			{
				List<CRMspSelectActiveShiftWorkingTimes_Result> list = Enumerable.ToList<CRMspSelectActiveShiftWorkingTimes_Result>((IEnumerable<CRMspSelectActiveShiftWorkingTimes_Result>)_dbII.CRMspSelectActiveShiftWorkingTimes(swId, lCID, result2));
				if (list != null)
				{
					result = list;
				}
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
	public string GetActiveShiftWorkingTimes_Json(int swId = 0)
	{
		return JsonConvert.SerializeObject(GetActiveShiftWorkingTimes(swId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectLeaveByDate_Result> GetLeaveByDate(int userId = 0, int timeAttendanceMode = -1, DateTime? dt = null, string dtPersian = null)
	{
		List<CRMspSelectLeaveByDate_Result> result = new List<CRMspSelectLeaveByDate_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (!dt.HasValue && !string.IsNullOrWhiteSpace(dtPersian))
			{
				dt = DateTimeClass.GetDateFromPersian(dtPersian);
			}
			if (!dt.HasValue)
			{
				dt = DateTime.Now;
			}
			List<CRMspSelectLeaveByDate_Result> list = Enumerable.ToList<CRMspSelectLeaveByDate_Result>((IEnumerable<CRMspSelectLeaveByDate_Result>)_dbII.CRMspSelectLeaveByDate(dt, userId, timeAttendanceMode, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectLeaveByDate_Result item in list)
				{
					item.FromDate = item.FromDateTime?.ToString("yyyy/MM/dd");
					item.ToDate = item.ToDateTime?.ToString("yyyy/MM/dd");
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

	[HttpPost]
	[LoginAuthorize]
	public string GetLeaveByDate_Json(int userId = 0, int timeAttendanceMode = -1)
	{
		return JsonConvert.SerializeObject(GetLeaveByDate(userId, timeAttendanceMode));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectConsecutiveLeaveByDate_Result> GetConsecutiveLeaveByDate(int userId = 0, int timeAttendanceMode = -1, DateTime? dt = null)
	{
		List<CRMspSelectConsecutiveLeaveByDate_Result> result = new List<CRMspSelectConsecutiveLeaveByDate_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			if (!dt.HasValue)
			{
				dt = DateTime.Now;
			}
			List<CRMspSelectConsecutiveLeaveByDate_Result> list = Enumerable.ToList<CRMspSelectConsecutiveLeaveByDate_Result>((IEnumerable<CRMspSelectConsecutiveLeaveByDate_Result>)_dbIII.CRMspSelectConsecutiveLeaveByDate(dt, userId, timeAttendanceMode, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectConsecutiveLeaveByDate_Result item in list)
				{
					item.FromDate = item.FromDateTime?.ToString("yyyy/MM/dd");
					item.ToDate = item.ToDateTime?.ToString("yyyy/MM/dd");
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

	[HttpPost]
	[LoginAuthorize]
	public string GetTomorrowLeaves_Json(int userId = 0)
	{
		return JsonConvert.SerializeObject(GetConsecutiveLeaveByDate(userId, 2, DateTime.Now));
	}

	[HttpPost]
	public string GetUserLeaves(int userId = 0, int timeAttendanceMode = 1)
	{
		List<CRMspSelectLeaveByDate_Result> value = new List<CRMspSelectLeaveByDate_Result>();
		try
		{
			if (userId != 0)
			{
				List<CRMspSelectLeaveByDate_Result> list = Enumerable.ToList<CRMspSelectLeaveByDate_Result>((IEnumerable<CRMspSelectLeaveByDate_Result>)Enumerable.OrderBy<CRMspSelectLeaveByDate_Result, string>((IEnumerable<CRMspSelectLeaveByDate_Result>)Enumerable.ToList<CRMspSelectLeaveByDate_Result>((IEnumerable<CRMspSelectLeaveByDate_Result>)_dbII.CRMspSelectLeaveByDate(userId: userId, date: DateTime.Now, timeAttendanceMode: timeAttendanceMode, languageID: Thread.CurrentThread.CurrentCulture.LCID, defaultLanguageID: SysSeting.Get().DefaultLanguageID)), (Func<CRMspSelectLeaveByDate_Result, string>)((CRMspSelectLeaveByDate_Result x) => x.FromTime)));
				if (list != null)
				{
					value = list;
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLeaveSteps(int leaveId = 0, int groupId = 0)
	{
		return JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.Leave().SelectLeaveStepsWithTimeAttendance(leaveId, groupId, DateTime.Now));
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetLeaveSteps_Json(int leaveId = 0, int groupId = 0)
	{
		return JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.Leave().SelectLeaveStepsWithTimeAttendance(leaveId, groupId, DateTime.Now));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectLeaveSteps_Result> GetLeaveSteps(int groupId = 0)
	{
		List<CRMspSelectLeaveSteps_Result> result = new List<CRMspSelectLeaveSteps_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (groupId != 0)
			{
				List<CRMspSelectLeaveSteps_Result> list = Enumerable.ToList<CRMspSelectLeaveSteps_Result>((IEnumerable<CRMspSelectLeaveSteps_Result>)_dbII.CRMspSelectLeaveSteps(groupId, lCID, result2));
				if (list != null)
				{
					result = list;
				}
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
	public List<CRMspSelectTimeAttendanceByDate_Result> GetTimeAttendanceByDate(string dtPer = "", int userId = 0)
	{
		List<CRMspSelectTimeAttendanceByDate_Result> result = new List<CRMspSelectTimeAttendanceByDate_Result>();
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			_ = currentUser?.UserLastCId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? date = null;
			if (!string.IsNullOrWhiteSpace(dtPer))
			{
				date = DateTimeClass.GetDateFromPersian(dtPer);
			}
			if (!date.HasValue)
			{
				date = DateTime.Now;
			}
			if (userId == 0)
			{
				userId = currentUser.UserId;
			}
			List<CRMspSelectTimeAttendanceByDate_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceByDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByDate_Result>)_dbI.CRMspSelectTimeAttendanceByDate(date, userId, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectTimeAttendanceByDate_Result item in list)
				{
					item.tmTimeStr = item.tmDate.ToString("HH:mm");
					item.tmEntryBaseTimeStr = item.tmEntryBase?.ToString("HH:mm");
					item.tmEntryTimeStr = item.tmEntryTime.ToString("HH:mm");
					item.tmEntryDelayStr = DateTimeClass.GetMinuteInFormat(item.tmEntryDelay.GetValueOrDefault());
					item.tmEntryDelayAllowMinStr = DateTimeClass.GetMinuteInFormat(item.tmEntryDelayAllowMin.GetValueOrDefault());
					item.tmExitBaseTimeStr = item.tmExitBase?.ToString("HH:mm");
					item.tmExitTimeStr = item.tmExitTime?.ToString("HH:mm");
					item.tmExitHurryStr = DateTimeClass.GetMinuteInFormat(item.tmExitHurry.GetValueOrDefault());
					item.tmExitHurryAllowMinStr = DateTimeClass.GetMinuteInFormat(item.tmExitHurryAllowMin.GetValueOrDefault());
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

	[HttpPost]
	[LoginAuthorize]
	public string GetTimeAttendanceByDate_Json(string dtPer = "", int userId = 0)
	{
		return JsonConvert.SerializeObject(GetTimeAttendanceByDate(dtPer, userId));
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectTimeAttendanceDetail_Result> GetTimeAttendanceDetail()
	{
		List<CRMspSelectTimeAttendanceDetail_Result> result = new List<CRMspSelectTimeAttendanceDetail_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			List<CRMspSelectTimeAttendanceDetail_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceDetail_Result>((IEnumerable<CRMspSelectTimeAttendanceDetail_Result>)_dbII.CRMspSelectTimeAttendanceDetail(DateTime.Now, null, null, userId, lCID, result2));
			if (list != null)
			{
				foreach (CRMspSelectTimeAttendanceDetail_Result item in list)
				{
					item.tmdEntryTimeDelayStr = DateTimeClass.GetMinuteInFormat(item.tmdEntryTimeDelay.GetValueOrDefault());
					item.tmdExitTimeDelayStr = DateTimeClass.GetMinuteInFormat(item.tmdExitTimeDelay.GetValueOrDefault());
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

	[HttpPost]
	[LoginAuthorize]
	public string GetTimeAttendanceDetail_Json()
	{
		return JsonConvert.SerializeObject(GetTimeAttendanceDetail());
	}

	[HttpPost]
	public List<SelectListItem> GetUserShiftWorkingTimeByDate(int userId = 0, int? userShiftWorkingId = null, int timeAttendanceMode = 1)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectShiftWorkingTimeByDate_Result> list2 = Enumerable.ToList<CRMspSelectShiftWorkingTimeByDate_Result>((IEnumerable<CRMspSelectShiftWorkingTimeByDate_Result>)_dbII.CRMspSelectShiftWorkingTimeByDate(userId, DateTime.Now, userShiftWorkingId, timeAttendanceMode, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID));
			if (list2 != null)
			{
				bool flag = false;
				_ = DateTime.Now;
				string text = DateTime.Now.ToString("HH:mm");
				int num = int.Parse(text.Split(new char[1] { ':' })[0]) * 60 + int.Parse(text.Split(new char[1] { ':' })[1]);
				for (int i = 0; i < list2.Count; i++)
				{
					bool selected = false;
					if (!flag)
					{
						if (list2[i].EntryTimeMin != 0 && list2[i].ExitTimeMin != 0 && num >= list2[i].EntryTimeMin - 60 && num <= list2[i].ExitTimeMin + 60)
						{
							flag = true;
							selected = true;
						}
						else if (!(num >= list2[i].ExitTimeMin + list2[i].ExitTimeLateMin.GetValueOrDefault()))
						{
							flag = true;
							selected = true;
						}
					}
					list.Add(new SelectListItem
					{
						Text = list2[i].swtTitle + " - " + list2[i].EntryTime + " - " + list2[i].ExitTime,
						Value = list2[i].ShiftWorkingTimeId.ToString(),
						Selected = selected
					});
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		base.ViewBag.UserShiftWorkingTimes = list;
		return list;
	}

	[HttpPost]
	public string GetUserShiftWorkingTimeByDate_Json(int userId = 0, int? userShiftWorkingId = null, int timeAttendanceMode = 1)
	{
		return JsonConvert.SerializeObject(GetUserShiftWorkingTimeByDate(userId, userShiftWorkingId, timeAttendanceMode));
	}

	[HttpPost]
	[LoginAuthorize]
	public string CheckSmartTimeAttendance()
	{
		bool flag = false;
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		bool result = false;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			bool.TryParse(cRMspSelectCrmsysSetting_Result.SmartTimeAttendance.ToString(), out result);
		}
		bool result2 = false;
		if (currentUser != null)
		{
			bool.TryParse(currentUser.DeActiveSmartTimeAttendance.ToString(), out result2);
		}
		if (result)
		{
			flag = true;
		}
		return flag.ToString();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GenerateExitQRCode(int? userId = null)
	{
		AdvanceResultViewModel advanceResultViewModel = new AdvanceResultViewModel();
		try
		{
			int userId2 = UserLogin.CurrentUser.UserId;
			if (userId.GetValueOrDefault() != 0)
			{
				ParamViewModel paramObject = Public.GetParamObject(new ParamViewModel
				{
					KeyName = "tadQRCodeExit",
					KeyValue = Guid.NewGuid().ToString()
				});
				UserLoginSmartTimeAttendance.Update(userId2, "", paramObject.KeyValue, "");
				advanceResultViewModel.Code = XorCipher.EncryptByPrivateKey(JsonConvert.SerializeObject(paramObject, new JsonSerializerSettings
				{
					NullValueHandling = NullValueHandling.Ignore
				}));
				advanceResultViewModel.Status = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			advanceResultViewModel.Errors.Add(Messages.MsgErrorDoneOperation);
			advanceResultViewModel.Status = CommonResultStatusViewModel.Error;
		}
		return JsonConvert.SerializeObject(advanceResultViewModel);
	}

	[HttpPost]
	[LoginAuthorize]
	public string LogTimeAttendanceExit(int? shiftWorkingTimeId, int? leaveId, string leaveStepIds = null, string userLoginIP = null, int? userLoginId = null, DateTime? userLoginDate = null, string userLoginDateStr = "", string addLeavesIds = null, string appType = "", double? lat = null, double? lng = null, bool? isTemp = null, double? zoom = null, string sDomain = null)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			int? num = ((userLoginId.GetValueOrDefault() == 0) ? new int?(UserLogin.CurrentUser.UserId) : userLoginId);
			DateTime value = now;
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType2 = (((appType ?? "") != "") ? appType : Configuration.AppType);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			userLoginId = ((userLoginId.GetValueOrDefault() == 0) ? userLoginId : num);
			if (userLoginId.GetValueOrDefault() == 0)
			{
				userLoginId = num;
			}
			object obj;
			switch (sDomain)
			{
			default:
				obj = sDomain;
				break;
			case "":
			case null:
			case "null":
			case "NULL":
				obj = "";
				break;
			}
			sDomain = (string)obj;
			if (sDomain != "")
			{
				bool flag = false;
				if (leaveId.GetValueOrDefault() == 0)
				{
					flag = true;
				}
				else
				{
					CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(userLoginId, leaveId, null, -1, null, null, null, result2, null, UserLogin.CurrentUser.UserLastCId));
					if (cRMspSelectLeave_Result != null && (cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 1 || cRMspSelectLeave_Result.LeaveTypeId.GetValueOrDefault() == 2))
					{
						flag = true;
					}
				}
				if (flag)
				{
					string text2 = SysSeting.Get().LoginAuthUrl ?? "";
					if (!string.IsNullOrWhiteSpace(text2) && !text2.Contains(sDomain))
					{
						result = Messages.MobMsgErrorNotInLoginAuthUrl;
						LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(UserLogin.CurrentUser.UserId);
						if (!string.IsNullOrWhiteSpace(loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceParamJson))
						{
							ParamViewModel paramViewModel = JsonConvert.DeserializeObject<ParamViewModel>(loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceParamJson);
							UserLoginSmartTimeAttendance.Update(userLoginId.GetValueOrDefault(), loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceQRCode, paramViewModel.KeyValue, null);
						}
						return result;
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(addLeavesIds))
			{
				_dbII.CRMspAutoInsertTimeAttendanceLeave(addLeavesIds, DateTime.Now.AddDays(1.0), num, value, text, value3, value2, appType2, lCID, result2);
			}
			if (string.IsNullOrWhiteSpace(userLoginIP) && base.Request != null)
			{
				userLoginIP = base.Request.UserHostAddress;
			}
			_dbII.CRMspTimeAttendanceExit(shiftWorkingTimeId, leaveId, leaveStepIds, userLoginIP, userLoginId, value, text, num, value, text, value3, value2, appType2, lCID, result2, lat.HasValue ? lat.ToString() : null, lng.HasValue ? lng.ToString() : null, zoom ?? null, isTemp.GetValueOrDefault() ? isTemp : null);
			_dbI.CRMspInsertTimeAttendanceLog(2, num, userLoginIP, appType2, result2);
			if (num.GetValueOrDefault() != 0)
			{
				DateTime now2 = DateTime.Now;
				new CRMIdeal.Areas.Leave.Controllers.HomeController().ActExecuteLeave(0, 0, num.GetValueOrDefault().ToString(), now2, now2, num.GetValueOrDefault());
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string LogTimeAttendanceExitWithCode(int? shiftWorkingTimeId, int? leaveId, string leaveStepIds = null, ParamViewModel p = null, string addLeavesIds = null)
	{
		List<string> list = new List<string>();
		int userId = UserLogin.CurrentUser.UserId;
		LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = null;
		if (p.SUId.GetValueOrDefault() != 0 && p.GUId.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(p.KeyValue))
		{
			loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(p.GUId.GetValueOrDefault());
		}
		if (loginUserSmartTimeAttendanceViewModel != null && p.GUId.GetValueOrDefault() != 0 && p.GUId == userId)
		{
			string text = loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "";
			if (text.Trim() != "" && text == p.KeyValue)
			{
				return LogTimeAttendanceExit(shiftWorkingTimeId, leaveId, leaveStepIds, p.SIP, p.SUId, DateTime.Now, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()), addLeavesIds, "", p.Lat, p.Lng, zoom: p.Zoom, isTemp: (p.Mode.GetValueOrDefault() == 0) ? null : new bool?(true), sDomain: p.SDomain);
			}
			list.Add(Messages.MsgErrorDoneOperationTryAgain);
		}
		return string.Join("<br />", list);
	}

	[HttpPost]
	[LoginAuthorize]
	public string CheckSmartTimeAttendanceScanStatus()
	{
		try
		{
			LoginUserSmartTimeAttendanceViewModel loginUserSmartTimeAttendanceViewModel = UserLoginSmartTimeAttendance.Get(UserLogin.CurrentUser.UserId);
			if (loginUserSmartTimeAttendanceViewModel != null)
			{
				if ((loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "") == "true")
				{
					return loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode + "|#|" + loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceParamJson;
				}
				return loginUserSmartTimeAttendanceViewModel.SmartTimeAttendanceMainQRCode ?? "";
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return "";
	}

	[HttpPost]
	[LoginAuthorize]
	public string LogTimeAttendanceEntry(int? shiftWorkingTimeId, int? leaveId, string leaveStepIds = null, string userLoginIP = null, int? userLoginId = null, DateTime? userLoginDate = null, string userLoginDateStr = "", string addLeavesIds = null, string appType = "", string clearTimeAttendanceIds = "", double? lat = null, double? lng = null, bool? isTemp = null, double? zoom = null)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			int? num = ((userLoginId.GetValueOrDefault() == 0) ? new int?(UserLogin.CurrentUser.UserId) : userLoginId);
			string text = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType2 = (((appType ?? "") == "") ? Configuration.AppType : appType);
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			userLoginId = ((userLoginId.GetValueOrDefault() == 0) ? userLoginId : num);
			if (userLoginId.GetValueOrDefault() == 0)
			{
				userLoginId = num;
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			bool result3 = false;
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				bool.TryParse(cRMspSelectCrmsysSetting_Result.SmartTimeAttendance.ToString(), out result3);
			}
			if (string.IsNullOrWhiteSpace(userLoginIP) && base.Request != null)
			{
				userLoginIP = base.Request.UserHostAddress;
			}
			if (!result3)
			{
				_db.CRMspRegisterDailyTimeAttendance(1, text, userLoginId, userLoginIP, appType2, result2);
			}
			else
			{
				_dbII.CRMspTimeAttendanceEntry(shiftWorkingTimeId, leaveId, leaveStepIds, userLoginIP, userLoginId, now, text, userLoginId, now, text, value2, value, appType2, result2, result2, clearTimeAttendanceIds, lat.HasValue ? lat.ToString() : null, lng.HasValue ? lng.ToString() : null, zoom ?? null, isTemp.GetValueOrDefault() ? isTemp : null);
				_dbI.CRMspInsertTimeAttendanceLog(1, userLoginId, userLoginIP, appType2, result2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}

	[HttpPost]
	public string SelectLeaveByUserShiftStartTime(int userId, int shiftWorkingTimeId)
	{
		List<CRMspSelectLeaveByUserShiftStartTime_Result> value = new List<CRMspSelectLeaveByUserShiftStartTime_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectLeaveByUserShiftStartTime_Result> list = Enumerable.ToList<CRMspSelectLeaveByUserShiftStartTime_Result>((IEnumerable<CRMspSelectLeaveByUserShiftStartTime_Result>)_dbII.CRMspSelectLeaveByUserShiftStartTime(DateTime.Now, shiftWorkingTimeId, userId, lCID, result));
			if (list != null)
			{
				value = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(value);
	}

	[HttpPost]
	[LoginAuthorize]
	public string AutoInsertTimeAttendanceLeave(int userId)
	{
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			_ = UserLogin.CurrentUser.UserId;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			text = Messages.MsgErrorDoneOperation;
		}
		return text.ToString();
	}

	[HttpPost]
	public List<CRMspSelectTimeAttendanceByLeaveDate_Result> SelectTimeAttendanceByLeaveDate(int userId = 0, string dtPersian = null)
	{
		List<CRMspSelectTimeAttendanceByLeaveDate_Result> result = new List<CRMspSelectTimeAttendanceByLeaveDate_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime? date = DateTimeClass.GetDateFromPersian(dtPersian);
			if (!date.HasValue)
			{
				date = DateTime.Now;
			}
			if (userId == 0 && UserLogin.CurrentUser != null)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectTimeAttendanceByLeaveDate_Result> list = Enumerable.ToList<CRMspSelectTimeAttendanceByLeaveDate_Result>((IEnumerable<CRMspSelectTimeAttendanceByLeaveDate_Result>)_dbII.CRMspSelectTimeAttendanceByLeaveDate(date, userId, lCID, result2));
			if (list != null)
			{
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
	public string SelectTimeAttendanceByLeaveDate_Json(int userId = 0, string dtPersian = null)
	{
		return JsonConvert.SerializeObject(SelectTimeAttendanceByLeaveDate(userId, dtPersian));
	}

	protected override void Dispose(bool disposing)
	{
		if (_db != null)
		{
			_db.Dispose();
		}
		if (_dbI != null)
		{
			_dbI.Dispose();
		}
		if (_dbII != null)
		{
			_dbII.Dispose();
		}
		if (_dbIII != null)
		{
			_dbIII.Dispose();
		}
		base.Dispose(disposing);
	}

	[LoginAuthorize]
	public ActionResult VerifyTimeAttendanceIsTemp(int intMsgId = 0, int taId = 0)
	{
		CRMspSelectTimeAttendanceById_Result model = new CRMspSelectTimeAttendanceById_Result();
		if (taId != 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				CRMspSelectTimeAttendanceById_Result cRMspSelectTimeAttendanceById_Result = Enumerable.FirstOrDefault<CRMspSelectTimeAttendanceById_Result>((IEnumerable<CRMspSelectTimeAttendanceById_Result>)_dbII.CRMspSelectTimeAttendanceById(taId, lCID, result));
				if (cRMspSelectTimeAttendanceById_Result != null)
				{
					cRMspSelectTimeAttendanceById_Result.tmDatePersian = cRMspSelectTimeAttendanceById_Result.tmDate.ToString("yyyy/MM/dd");
					cRMspSelectTimeAttendanceById_Result.tmEntryDatePersian = cRMspSelectTimeAttendanceById_Result.tmEntryTime?.ToString("yyyy/MM/dd");
					cRMspSelectTimeAttendanceById_Result.tmEntryBaseStr = cRMspSelectTimeAttendanceById_Result.tmEntryBase?.ToString("HH:mm");
					cRMspSelectTimeAttendanceById_Result.tmEntryTimeStr = cRMspSelectTimeAttendanceById_Result.tmEntryTime?.ToString("HH:mm");
					cRMspSelectTimeAttendanceById_Result.tmEntryDelayStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmEntryDelay);
					cRMspSelectTimeAttendanceById_Result.tmEntryDelayAllowMinStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmEntryDelayAllowMin);
					cRMspSelectTimeAttendanceById_Result.tmExitDatePersian = cRMspSelectTimeAttendanceById_Result.tmExitTime?.ToString("yyyy/MM/dd");
					cRMspSelectTimeAttendanceById_Result.tmExitBaseStr = cRMspSelectTimeAttendanceById_Result.tmExitBase?.ToString("HH:mm");
					cRMspSelectTimeAttendanceById_Result.tmExitTimeStr = cRMspSelectTimeAttendanceById_Result.tmExitTime?.ToString("HH:mm");
					cRMspSelectTimeAttendanceById_Result.tmExitHurryStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmExitHurry.GetValueOrDefault());
					cRMspSelectTimeAttendanceById_Result.tmExitHurryAllowMinStr = DateTimeClass.GetMinuteInFormat(cRMspSelectTimeAttendanceById_Result.tmExitHurryAllowMin.GetValueOrDefault());
					model = cRMspSelectTimeAttendanceById_Result;
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
		}
		return View(model);
	}

	[LoginAuthorize]
	[HttpPost]
	public string VerifyTimeAttendanceIsTemp(int timeAttendanceId, bool? entryEditing, string tmEntryDatePersian, string tmEntryTimeStr, string tmEntryDelayStr, string tmEntryRegisterIP, bool? tmEntryIsTemp, bool? exitEditing, string tmExitDatePersian, string tmExitTimeStr, string tmExitHurryStr, string tmExitRegisterIP, bool? tmExitIsTemp)
	{
		string result = "";
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
			short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (!tmEntryIsTemp.GetValueOrDefault())
			{
				DateTime? tmEntryTime = null;
				if (!string.IsNullOrWhiteSpace(tmEntryDatePersian) && !string.IsNullOrWhiteSpace(tmEntryTimeStr))
				{
					tmEntryTime = DateTime.Parse(tmEntryDatePersian + " " + tmEntryTimeStr);
				}
				int? num = null;
				if (!string.IsNullOrWhiteSpace(tmEntryDelayStr))
				{
					num = Math.Abs(int.Parse(tmEntryDelayStr.Split(new char[1] { ':' })[0])) * 60 + Math.Abs(int.Parse(tmEntryDelayStr.Split(new char[1] { ':' })[1]));
				}
				if (num.GetValueOrDefault() == 0)
				{
					num = null;
				}
				else if (tmEntryDelayStr.Contains("-"))
				{
					num *= -1;
				}
				_dbII.CRMspUpdateTimeAttendanceEntryIsTemp(timeAttendanceId, tmEntryIsTemp, entryEditing.GetValueOrDefault() ? 1 : 0, tmEntryTime, num, tmEntryRegisterIP, userId, value, registerDatePersian, value3, value2, appType, lCID, result2);
			}
			if (!tmExitIsTemp.GetValueOrDefault())
			{
				DateTime? tmExitTime = null;
				if (!string.IsNullOrWhiteSpace(tmExitDatePersian) && !string.IsNullOrWhiteSpace(tmExitTimeStr))
				{
					tmExitTime = DateTime.Parse(tmExitDatePersian + " " + tmExitTimeStr);
				}
				int? num2 = null;
				if (!string.IsNullOrWhiteSpace(tmExitHurryStr))
				{
					num2 = Math.Abs(int.Parse(tmExitHurryStr.Split(new char[1] { ':' })[0])) * 60 + Math.Abs(int.Parse(tmExitHurryStr.Split(new char[1] { ':' })[1]));
				}
				if (num2.GetValueOrDefault() == 0)
				{
					num2 = null;
				}
				else if (tmExitHurryStr.Contains("-"))
				{
					num2 *= -1;
				}
				_dbII.CRMspUpdateTimeAttendanceExitIsTemp(timeAttendanceId, tmExitIsTemp, exitEditing.GetValueOrDefault() ? 1 : 0, tmExitTime, num2, tmExitRegisterIP, userId, value, registerDatePersian, value3, value2, appType, lCID, result2);
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
			result = Messages.MsgErrorDoneOperation;
		}
		return result;
	}
}
