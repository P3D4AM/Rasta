using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Controllers;

public class ReminderCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> Tree(string date, bool isShowTicket, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItem> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<DropDownItem>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					_ = DateTime.Now;
					int result3 = 0;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<DropDownItem>> result4 = new ServiceResult<List<DropDownItem>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						int.TryParse(date, out result3);
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<DropDownItem>> result5 = new ServiceResult<List<DropDownItem>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result5;
					}
					string mobAllUsers = Labels.MobAllUsers;
					List<MobspUserTreeReminderCartable_Result> list = Enumerable.ToList<MobspUserTreeReminderCartable_Result>((IEnumerable<MobspUserTreeReminderCartable_Result>)cRMEntities.MobspUserTreeReminderCartable(token2.userId, 1, result3, now, mobAllUsers, result, result2, isShowTicket, cId));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (MobspUserTreeReminderCartable_Result item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result6 = 0;
						int.TryParse(item.KeyId.ToString(), out result6);
						dropDownItem.Id = result6;
						dropDownItem.Title = item.KeyName;
						int result7 = 0;
						int.TryParse(item.KeyId.ToString(), out result7);
						dropDownItem.OrderView = result7;
						list2.Add(dropDownItem);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspResultsReminderCartable_Result>> Result(string date, int usId, bool isShowTicket, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspResultsReminderCartable_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspResultsReminderCartable_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(date))
						{
							ServiceResult<List<MobspResultsReminderCartable_Result>> result3 = new ServiceResult<List<MobspResultsReminderCartable_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						date = date.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(date) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspResultsReminderCartable_Result>> result4 = new ServiceResult<List<MobspResultsReminderCartable_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					if (usId == 0)
					{
						ServiceResult<List<MobspResultsReminderCartable_Result>> result5 = new ServiceResult<List<MobspResultsReminderCartable_Result>>
						{
							Message = Messages.MobMsgErrorUserNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					data = Enumerable.ToList<MobspResultsReminderCartable_Result>((IEnumerable<MobspResultsReminderCartable_Result>)cRMEntities.MobspResultsReminderCartable(token2.userId, now, result, result2, pageNumber, pageSize, usId, isShowTicket, cId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspResultsReminderCartable_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItem>> SelectConversationStatusGroups(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItem> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<DropDownItem>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectConversationStatusGroups_Result> list = Enumerable.ToList<MobspSelectConversationStatusGroups_Result>((IEnumerable<MobspSelectConversationStatusGroups_Result>)cRMEntities.MobspSelectConversationStatusGroups(result, result2));
					List<DropDownItem> list2 = new List<DropDownItem>();
					foreach (MobspSelectConversationStatusGroups_Result item in list)
					{
						DropDownItem dropDownItem = new DropDownItem();
						int result3 = 0;
						int.TryParse(item.Id.ToString(), out result3);
						dropDownItem.Id = result3;
						dropDownItem.Title = item.Title;
						int result4 = 0;
						int.TryParse(item.OrderView.ToString(), out result4);
						dropDownItem.OrderView = result4;
						list2.Add(dropDownItem);
					}
					data = list2;
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<DropDownItem>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> SelectCompanyProjectFromRemindDate(string fromDate, string toDate, bool isFinished, int statusGroupId, int userId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCompanyProjectFromRemindDate_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> result3 = new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> result4 = new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (string.IsNullOrEmpty(toDate))
						{
							ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> result5 = new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result5;
						}
						toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((result != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> result6 = new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result6;
					}
					if (statusGroupId == 0)
					{
						ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>> result7 = new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
						{
							Message = Messages.MobMsgErrorStatusGroupIdNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result7;
					}
					isFinished = isFinished;
					CRMEntities cRMEntities2 = cRMEntities;
					string fDate = fromDate;
					string tDate = toDate;
					DateTime? fDateTime = now;
					DateTime? tDateTime = now2;
					int? num = statusGroupId;
					bool? prjIsFinished = isFinished;
					int? prjcnvsStatusGroupId = num;
					int? languageID = result;
					int? defaultLanguageID = result2;
					data = Enumerable.ToList<MobspSelectCompanyProjectFromRemindDate_Result>((IEnumerable<MobspSelectCompanyProjectFromRemindDate_Result>)cRMEntities2.MobspSelectCompanyProjectFromRemindDate(fDate, tDate, fDateTime, tDateTime, prjIsFinished, prjcnvsStatusGroupId, pageNumber, pageSize, languageID, defaultLanguageID, userId, cId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectCompanyProjectFromRemindDate_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LoadUserTasksResultViewModel> LoadUserTasks(string date, int usId, bool? selectWithCnvs, int? ln = null, int? cId = null, int? groupId = 0, int? priorityId = 0, int? didItStatus = -1)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		LoadUserTasksResultViewModel loadUserTasksResultViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
					{
						return new ServiceResult<LoadUserTasksResultViewModel>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					if (usId == 0)
					{
						ServiceResult<LoadUserTasksResultViewModel> result3 = new ServiceResult<LoadUserTasksResultViewModel>
						{
							Message = Messages.MobMsgErrorUserNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					loadUserTasksResultViewModel = new LoadUserTasksResultViewModel();
					loadUserTasksResultViewModel.UserTasks = new List<MobspLoadUserTasks_Result>();
					loadUserTasksResultViewModel.Repeats = new List<MobspSelectUserTasksRepeats_Result>();
					if (!string.IsNullOrWhiteSpace(date))
					{
						List<string> datesOfWeekSelectListItemFromSp = Reminder.GetDatesOfWeekSelectListItemFromSp(date);
						date = Enumerable.LastOrDefault<string>((IEnumerable<string>)datesOfWeekSelectListItemFromSp);
						if (datesOfWeekSelectListItemFromSp != null)
						{
							foreach (string item in datesOfWeekSelectListItemFromSp)
							{
								DateTime value = default(DateTime);
								string text = "";
								try
								{
									if (!string.IsNullOrEmpty(item))
									{
										text = PersianDate.GetFormatetdDate(item.Replace("/", ""));
										value = num switch
										{
											1065 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
											1025 => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
											_ => DateTime.Parse(text + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
										};
									}
								}
								catch (Exception e)
								{
									ErrorSignal.FromCurrentContext().Raise(e);
								}
								List<MobspLoadUserTasks_Result> list = Enumerable.ToList<MobspLoadUserTasks_Result>((IEnumerable<MobspLoadUserTasks_Result>)cRMEntities.MobspLoadUserTasks(value, usId, result, result2, selectWithCnvs, token2.userId, cId, groupId, priorityId, didItStatus));
								if (list != null)
								{
									loadUserTasksResultViewModel.UserTasks.AddRange(list);
								}
							}
						}
					}
					DateTime value2 = DateTime.Now;
					if (!string.IsNullOrWhiteSpace(date))
					{
						DateTime dateTime = default(DateTime);
						string text2 = "";
						try
						{
							if (!string.IsNullOrEmpty(date))
							{
								text2 = PersianDate.GetFormatetdDate(date.Replace("/", ""));
								value2 = num switch
								{
									1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()), 
									1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")), 
									_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")), 
								};
							}
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
					List<MobspSelectUserTasksRepeats_Result> list2 = Enumerable.ToList<MobspSelectUserTasksRepeats_Result>((IEnumerable<MobspSelectUserTasksRepeats_Result>)cRMEntities.MobspSelectUserTasksRepeats(usId, languageID: result, defaultLanguageID: result2, currDate: value2, centerId: cId, userTaskGroupId: groupId, userTaskPriorityId: priorityId, userTaskDidItStatus: didItStatus, crmUserId: token2.userId));
					if (list2 != null)
					{
						loadUserTasksResultViewModel.Repeats = list2;
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					loadUserTasksResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				loadUserTasksResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			loadUserTasksResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LoadUserTasksResultViewModel>
		{
			Message = message,
			Data = loadUserTasksResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectUserTaskWithID_Result> SelectUserTaskWithId(int taskId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectUserTaskWithID_Result data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcReminder", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<MobspSelectUserTaskWithID_Result>
				{
					Message = Messages.MobMsgErrorAccessLimited,
					Data = null,
					Status = ServiceResultStatus.Fail
				};
			}
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					MobspSelectUserTaskWithID_Result mobspSelectUserTaskWithID_Result = Enumerable.FirstOrDefault<MobspSelectUserTaskWithID_Result>((IEnumerable<MobspSelectUserTaskWithID_Result>)cRMEntities.MobspSelectUserTaskWithID(taskId, result, result2));
					if (mobspSelectUserTaskWithID_Result != null)
					{
						data = mobspSelectUserTaskWithID_Result;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorUserTaskNotFound;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<MobspSelectUserTaskWithID_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> InsertCrmUserTask(InsertUpdateUserTaskViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					int num = 0;
					DateTime dateTime = default(DateTime);
					string text = "";
					DateTime value = default(DateTime);
					DateTime value2 = default(DateTime);
					DateTime? dateTime2 = default(DateTime);
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDatePersian))
						{
							text = PersianDate.GetFormatetdDate(model.UserTaskDatePersian.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = 0;
						status = ServiceResultStatus.Error;
						num++;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDateEndPersian))
						{
							text = PersianDate.GetFormatetdDate(model.UserTaskDateEndPersian.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
								model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value2 = dateTime;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = 0;
						status = ServiceResultStatus.Error;
						num++;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskRemindTime))
						{
							if (!string.IsNullOrEmpty(model.UserTaskRemindDate))
							{
								text = PersianDate.GetFormatetdDate(model.UserTaskRemindDate.Replace("/", ""));
								if (result == 1065)
								{
									dateTime = DateTime.Parse(text + " " + model.UserTaskRemindTime, new PersianCulture());
									model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd");
								}
								else
								{
									dateTime = DateTime.Parse(text + " " + model.UserTaskRemindTime, new CultureInfo("en-US"));
									model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								}
								dateTime2 = dateTime;
							}
							else
							{
								message = Messages.MobMsgErrorUserTaskRemindDateIsNotEntered;
								data = 0;
								status = ServiceResultStatus.Error;
								num++;
							}
						}
						else
						{
							dateTime2 = null;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = 0;
						status = ServiceResultStatus.Error;
						num++;
					}
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspCheckUserTaskTimeOverlap(0, dateTime2, model.UserTaskTime, model.UserTaskTimeEnd, token2.userId)).Value > 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserTaskTimeOverlap,
							Data = 0,
							Status = status
						};
					}
					if (num == 0)
					{
						DateTime now = DateTime.Now;
						DateTime value3 = now;
						string text2 = now.ToString("yyyyMMdd", new PersianCulture());
						short value4 = short.Parse(Financial.Get().Id.ToString());
						short value5 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string appType = Mobile.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("InsertedUserTaskId", 0);
						CRMEntities cRMEntities2 = cRMEntities;
						string userTaskDatePersian = model.UserTaskDatePersian;
						string userTaskTime = model.UserTaskTime;
						DateTime? userTaskDate = value;
						string userTaskTitle = model.UserTaskTitle;
						string userTaskDescription = model.UserTaskDescription;
						int? userTaskPriorityId = model.UserTaskPriorityId;
						int? userTaskGroupId = model.UserTaskGroupId;
						int? userTaskShowAllarm = model.UserTaskShowAllarm;
						bool? userTaskDidIt = model.UserTaskDidIt;
						int? userId = token2.userId;
						short? year = value4;
						short? month = value5;
						DateTime? registerDate = value3;
						string userTaskRemindDate = model.UserTaskRemindDate;
						string userTaskRemindTime = model.UserTaskRemindTime;
						DateTime? userTaskRemindDateTime = dateTime2;
						bool? userTaskIsPublic = model.UserTaskIsPublic;
						DateTime? firstRegisterDate = value3;
						int? languageID = result2;
						ObjectParameter insertedUserTaskId = objectParameter;
						int? num2 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspInsertCrmUserTasks(userTaskDatePersian, userTaskTime, userTaskDate, userTaskTitle, userTaskDescription, userTaskPriorityId, userTaskGroupId, userTaskShowAllarm, userTaskDidIt, userId, year, month, registerDate, text2, userTaskRemindDate, userTaskRemindTime, userTaskRemindDateTime, userTaskIsPublic, text2, firstRegisterDate, appType, languageID, model.UserTaskTimeEnd, model.ObjectTypeId, model.ObjectId, model.UserTaskNoTimeOverlap, model.UserTaskCompanyIds, model.UserTaskRepeatDaily, model.UserTaskRepeatWeekly, model.UserTaskRepeatMonthly, model.UserTaskRepeatYearly, model.UserTaskRemindRepeatDaily, model.UserTaskRemindRepeatWeekly, model.UserTaskRemindRepeatMonthly, model.UserTaskRemindRepeatYearly, model.UserTaskUserId, insertedUserTaskId, model.CenterId, model.UserTaskDateEndPersian, value2));
						if (!num2.HasValue || num2 >= 1)
						{
							if (objectParameter.Value != null)
							{
								int result3 = 0;
								int.TryParse(objectParameter.Value.ToString(), out result3);
								if (result3 > 0)
								{
									data = result3;
									message = Messages.MobMsgSuccessAction;
									status = ServiceResultStatus.Success;
								}
								else
								{
									data = 0;
									message = Messages.MobMsgErrorDoneOperation;
									status = ServiceResultStatus.Fail;
								}
							}
							else
							{
								data = 0;
								message = Messages.MobMsgErrorDoneOperation;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = 0;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e4)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> UpdateCrmUserTask(InsertUpdateUserTaskViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					string text = "";
					int num = 0;
					int num2 = 0;
					DateTime dateTime = default(DateTime);
					string text2 = "";
					DateTime value = default(DateTime);
					DateTime value2 = default(DateTime);
					DateTime value3 = default(DateTime);
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(model.UserTaskDatePersian.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = model.UserTaskId;
						status = ServiceResultStatus.Error;
						num++;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskDateEndPersian))
						{
							text2 = PersianDate.GetFormatetdDate(model.UserTaskDateEndPersian.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text2 + " 00:00:00", new PersianCulture());
								model.UserTaskDateEndPersian = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text2 + " 00:00:00", new CultureInfo("en-US"));
								model.UserTaskDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value2 = dateTime;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = model.UserTaskId;
						status = ServiceResultStatus.Error;
						num++;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.UserTaskRemindTime))
						{
							if (!string.IsNullOrEmpty(model.UserTaskRemindDate))
							{
								text2 = PersianDate.GetFormatetdDate(model.UserTaskRemindDate.Replace("/", ""));
								if (result == 1065)
								{
									dateTime = DateTime.Parse(text2 + " " + model.UserTaskRemindTime, new PersianCulture());
									model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd");
								}
								else
								{
									dateTime = DateTime.Parse(text2 + " " + model.UserTaskRemindTime, new CultureInfo("en-US"));
									model.UserTaskRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								}
								value3 = dateTime;
							}
							else
							{
								message = Messages.MobMsgErrorUserTaskRemindDateIsNotEntered;
								data = model.UserTaskId;
								status = ServiceResultStatus.Error;
								num++;
							}
						}
						else
						{
							message = Messages.MobMsgErrorUserTaskRemindTimeIsNotEntered;
							data = model.UserTaskId;
							status = ServiceResultStatus.Error;
							num++;
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						message = Messages.MobMsgErrorDateFormatIncorrect;
						data = model.UserTaskId;
						status = ServiceResultStatus.Error;
						num++;
					}
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspCheckUserTaskTimeOverlap(model.UserTaskId, value3, model.UserTaskTime, model.UserTaskTimeEnd, token2.userId)).Value > 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserTaskTimeOverlap,
							Data = 0,
							Status = status
						};
					}
					if (num == 0)
					{
						DateTime now = DateTime.Now;
						DateTime value4 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						short value5 = short.Parse(Financial.Get().Id.ToString());
						short value6 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string appType = Mobile.Classes.Configuration.AppType;
						ObjectParameter objectParameter = new ObjectParameter("UpdatedUserTaskId", 0);
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						CRMEntities cRMEntities2 = cRMEntities;
						int? userTaskId = model.UserTaskId;
						string userTaskDatePersian = model.UserTaskDatePersian;
						DateTime? userTaskDate = value;
						string userTaskTime = model.UserTaskTime;
						string userTaskTitle = model.UserTaskTitle;
						string userTaskDescription = model.UserTaskDescription;
						int? userTaskPriorityId = model.UserTaskPriorityId;
						int? userTaskGroupId = model.UserTaskGroupId;
						int? userTaskShowAllarm = model.UserTaskShowAllarm;
						bool? userTaskDidIt = model.UserTaskDidIt;
						int? userId = token2.userId;
						short? year = value5;
						short? month = value6;
						DateTime? registerDate = value4;
						string userTaskRemindDate = model.UserTaskRemindDate;
						string userTaskRemindTime = model.UserTaskRemindTime;
						DateTime? userTaskRemindDateTime = value3;
						bool? userTaskIsPublic = model.UserTaskIsPublic;
						int? defaultLanguageID = result2;
						ObjectParameter updatedUserTaskId = objectParameter;
						ObjectParameter errorMessage = objectParameter2;
						int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateCrmUserTasks(userTaskId, userTaskDatePersian, userTaskDate, userTaskTime, userTaskTitle, userTaskDescription, userTaskPriorityId, userTaskGroupId, userTaskShowAllarm, userTaskDidIt, userId, year, month, registerDate, registerDatePersian, userTaskRemindDate, userTaskRemindTime, userTaskRemindDateTime, userTaskIsPublic, appType, defaultLanguageID, model.UserTaskTimeEnd, model.ObjectTypeId, model.ObjectId, model.UserTaskNoTimeOverlap, model.UserTaskCompanyIds, model.UserTaskRepeatDaily, model.UserTaskRepeatWeekly, model.UserTaskRepeatMonthly, model.UserTaskRepeatYearly, model.UserTaskRemindRepeatDaily, model.UserTaskRemindRepeatWeekly, model.UserTaskRemindRepeatMonthly, model.UserTaskRemindRepeatYearly, model.UserTaskUserId, updatedUserTaskId, errorMessage, model.UserTaskDateEndPersian, value2));
						if (objectParameter2.Value != null)
						{
							if (objectParameter2.Value.ToString() != "")
							{
								text = objectParameter2.Value.ToString();
								text = text.Replace("|Msg=0", Messages.MobMsgErrorUserTaskNotFound);
								num++;
							}
							else
							{
								text = "";
							}
						}
						num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
						if (!num3.HasValue || num3 >= 1)
						{
							if (num > 0)
							{
								data = model.UserTaskId;
								message = text;
								status = ServiceResultStatus.Fail;
							}
							else
							{
								data = num2;
								message = Messages.MobMsgSuccessAction;
								status = ServiceResultStatus.Success;
							}
						}
						else
						{
							data = model.UserTaskId;
							message = Messages.MobMsgErrorDoneOperation;
							status = ServiceResultStatus.Fail;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = model.UserTaskId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = model.UserTaskId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e4)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = model.UserTaskId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string ChekeBeforeSubmitUserTask(InsertUpdateUserTaskViewModel uTask, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(uTask.UserTaskTitle))
		{
			text = text + Messages.MobMsgErrorUserTaskTitleIsNotEntered + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskDatePersian))
		{
			text = text + Messages.MobMsgErrorUserTaskDateIsNotEntered + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskRemindDate))
		{
			text = text + Messages.MobMsgErrorUserTaskRemindDateIsNotEntered + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskTime))
		{
			text = text + Messages.MobMsgErrorUserTaskTimeIsNotEntered + "<br>";
			countError++;
		}
		if (string.IsNullOrEmpty(uTask.UserTaskRemindTime))
		{
			text = text + Messages.MobMsgErrorUserTaskRemindTimeIsNotEntered + "<br>";
			countError++;
		}
		return text;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> DeleteCrmUserTasks(int userTaskId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (Enumerable.FirstOrDefault<MobspSelectUserTaskWithID_Result>((IEnumerable<MobspSelectUserTaskWithID_Result>)cRMEntities.MobspSelectUserTaskWithID(userTaskId, result, result2)) == null)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserTaskNotFound,
							Data = userTaskId,
							Status = ServiceResultStatus.Error
						};
					}
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspDeleteCrmUserTasks(userTaskId));
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 == 1)
					{
						data = userTaskId;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						data = userTaskId;
						message = Messages.MobMsgErrorRedundancy;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = userTaskId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = userTaskId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = userTaskId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UpdateUserTaskDidIt(int userTaskId, bool? state, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					if (Enumerable.FirstOrDefault<MobspSelectUserTaskWithID_Result>((IEnumerable<MobspSelectUserTaskWithID_Result>)cRMEntities.MobspSelectUserTaskWithID(userTaskId, result, result2)) == null)
					{
						return new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorUserTaskNotFound,
							Data = null,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspUpdateUserTaskDidIt(userTaskId, state, token2.userId, value3, value2, value, registerDatePersian, appType);
					data = null;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> UpdateCrmUserTaskRemindTime(int userTaskId, int minute, int typeReminder, string clientCurrentTime, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					string appType = Mobile.Classes.Configuration.AppType;
					int num = 0;
					string text = "";
					int num2 = 0;
					if (Enumerable.FirstOrDefault<MobspSelectUserTaskWithID_Result>((IEnumerable<MobspSelectUserTaskWithID_Result>)cRMEntities.MobspSelectUserTaskWithID(userTaskId, result, result2)) == null || typeReminder != 1)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorUserTaskNotFound,
							Data = userTaskId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime dateTime = DateTime.Now;
					if (clientCurrentTime != "")
					{
						dateTime = DateTime.Parse(dateTime.ToString("yyyy/MM/dd") + " " + clientCurrentTime);
					}
					DateTime dateTime2 = dateTime;
					dateTime2 = dateTime2.AddMinutes(minute);
					string userTaskRemindDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					DateTime value = dateTime2;
					string userTaskRemindTime = dateTime2.ToString("HH:mm");
					ObjectParameter objectParameter = new ObjectParameter("UpdatedUserTaskId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspUpdateCrmUserTaskRemindTime(userTaskId, userTaskRemindDate, userTaskRemindTime, value, appType, objectParameter, objectParameter2));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", Messages.MobMsgErrorUserTaskNotFound);
							num++;
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (!num3.HasValue || num3 >= 1)
					{
						if (num > 0)
						{
							data = userTaskId;
							message = text;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = num2;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = userTaskId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = userTaskId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = userTaskId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = userTaskId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> UpdateCrmConversationRemindTimeForAllarm(int cnvsId, int minute, int typeReminder, string clientCurrentTime, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					string appType = Mobile.Classes.Configuration.AppType;
					int num = 0;
					string text = "";
					int num2 = 0;
					if (Enumerable.FirstOrDefault<MobspSelectConversationWithID_Result>((IEnumerable<MobspSelectConversationWithID_Result>)cRMEntities.MobspSelectConversationWithID(cnvsId, result, result2)) == null || typeReminder != 2)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorIsNotConversation,
							Data = cnvsId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime dateTime = DateTime.Now;
					if (clientCurrentTime != "")
					{
						dateTime = DateTime.Parse(dateTime.ToString("yyyy/MM/dd") + " " + clientCurrentTime);
					}
					DateTime dateTime2 = dateTime;
					dateTime2 = dateTime2.AddMinutes(minute);
					string text2 = dateTime2.ToString("yyyyMMdd", new PersianCulture());
					DateTime value = dateTime2;
					string cnvsRemindTime = dateTime2.ToString("HH:mm");
					ObjectParameter objectParameter = new ObjectParameter("UpdatedConversationId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
					CRMEntities cRMEntities2 = cRMEntities;
					int? conversationId = cnvsId;
					string cnvsRemindDateForAllarm = text2;
					int? num3 = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspUpdateCrmConversationRemindTimeForAllarm(conversationId, cnvsRemindTime, cnvsRemindDateForAllarm, value, appType, objectParameter, objectParameter2));
					if (objectParameter2.Value != null)
					{
						if (objectParameter2.Value.ToString() != "")
						{
							text = objectParameter2.Value.ToString();
							text = text.Replace("|Msg=0", Messages.MobMsgErrorIsNotConversation);
							num++;
						}
						else
						{
							text = "";
						}
					}
					num2 = ((objectParameter.Value != null) ? ((int)(objectParameter.Value ?? ((object)0))) : 0);
					if (!num3.HasValue || num3 >= 1)
					{
						if (num > 0)
						{
							data = cnvsId;
							message = text;
							status = ServiceResultStatus.Fail;
						}
						else
						{
							data = num2;
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
					}
					else
					{
						data = cnvsId;
						message = Messages.MobMsgErrorDoneOperation;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = cnvsId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = cnvsId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = cnvsId;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspLoadRemindingTask_Result>> LoadRemindingTask(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<MobspLoadRemindingTask_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					string text = now.ToString("yyyyMMdd");
					DateTime value = DateTime.Parse(now.ToString("yyyy/MM/dd") + " 23:59:59");
					data = Enumerable.ToList<MobspLoadRemindingTask_Result>((IEnumerable<MobspLoadRemindingTask_Result>)cRMEntities.MobspLoadRemindingTask(text, dateTime: value, userId: token2.userId, languageID: result, defaultLanguageID: result2, centerId: cId));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspLoadRemindingTask_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspLoadRemindingTaskWithFuture_Result>> LoadRemindingTaskWithFuture(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		List<MobspLoadRemindingTaskWithFuture_Result> data;
		string message;
		ServiceResultStatus status;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					now.ToString("yyyyMMdd");
					DateTime value = DateTime.Parse(now.ToString("yyyy/MM/dd") + " 23:59:59");
					data = Enumerable.ToList<MobspLoadRemindingTaskWithFuture_Result>((IEnumerable<MobspLoadRemindingTaskWithFuture_Result>)cRMEntities.MobspLoadRemindingTaskWithFuture(dateTime: value, userId: token2.userId, languageID: result, defaultLanguageID: result2));
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspLoadRemindingTaskWithFuture_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UserTaskDidIt(int userTaskId = 0, bool? isFinish = null, string targetDate = "", int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = DateTime.Now;
					if (!string.IsNullOrEmpty(targetDate))
					{
						targetDate = targetDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						value = num switch
						{
							1065 => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00")), 
							1025 => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00"), new CultureInfo("ar-SA"), DateTimeStyles.None), 
							_ => DateTime.Parse(PersianDate.GetFormatetdDate(targetDate) + " " + now.Hour.ToString("00") + ":" + now.Minute.ToString("00") + ":" + now.Second.ToString("00"), new CultureInfo("en-US"), DateTimeStyles.None), 
						};
					}
					if (userTaskId > 0)
					{
						string text = "";
						short value2 = short.Parse(Financial.Get().Id.ToString());
						short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
						DateTime value4 = now;
						string text2 = now.ToString("yyyyMMdd", new PersianCulture());
						MobspSelectUserTaskById_Result mobspSelectUserTaskById_Result = Enumerable.FirstOrDefault<MobspSelectUserTaskById_Result>((IEnumerable<MobspSelectUserTaskById_Result>)cRMSpEntities.MobspSelectUserTaskById(num, result2, userTaskId));
						if (mobspSelectUserTaskById_Result == null)
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorUserTaskNotFound,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						if (mobspSelectUserTaskById_Result.UserId != UserLogin.CurrentUser.UserId)
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorUserTaskNotBelongToUser,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						_ = mobspSelectUserTaskById_Result.UserTaskRepeatDaily;
						_ = mobspSelectUserTaskById_Result.UserTaskRepeatWeekly;
						_ = mobspSelectUserTaskById_Result.UserTaskRepeatMonthly;
						_ = mobspSelectUserTaskById_Result.UserTaskRepeatYearly;
						bool flag = mobspSelectUserTaskById_Result.UserTaskRepeatDaily.GetValueOrDefault() || mobspSelectUserTaskById_Result.UserTaskRepeatWeekly.GetValueOrDefault() || mobspSelectUserTaskById_Result.UserTaskRepeatMonthly.GetValueOrDefault() || mobspSelectUserTaskById_Result.UserTaskRepeatYearly.GetValueOrDefault();
						bool flag2 = false;
						if (flag && !string.IsNullOrEmpty(mobspSelectUserTaskById_Result.UserTaskDidItInfoJson))
						{
							Dictionary<string, string> dictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(mobspSelectUserTaskById_Result.UserTaskDidItInfoJson);
							if (dictionary != null && dictionary.ContainsKey(targetDate))
							{
								flag2 = true;
							}
						}
						if (flag && flag2 && !isFinish.GetValueOrDefault())
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorUserTaskAlreadyDoneOnDate,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						if ((mobspSelectUserTaskById_Result.UserTaskDidIt.GetValueOrDefault() && !flag) || (mobspSelectUserTaskById_Result.UserTaskDidIt.GetValueOrDefault() && flag && isFinish.GetValueOrDefault()))
						{
							return new ServiceResult<string>
							{
								Message = Messages.msgErrorUserTaskAlreadyCompleted,
								Data = null,
								Status = ServiceResultStatus.Error
							};
						}
						CRMSpEntities cRMSpEntities2 = cRMSpEntities;
						int? userTaskId2 = userTaskId;
						int? userId = UserLogin.CurrentUser.UserId;
						short? num2 = value2;
						cRMSpEntities2.MobspUserTaskDidIt(month1: value3, year1: num2, registerDate: value4, registerDatePersian: text2, appType: Mobile.Classes.Configuration.AppType, isFinish: isFinish, userTaskId: userTaskId2, userId: userId, targetDate: value);
						try
						{
							UserLoginInfo currentUser = UserLogin.CurrentUser;
							DateTime now2 = DateTime.Now;
							string date = now2.ToString("yyyyMMdd");
							DateTime value5 = DateTime.Parse(now2.ToString("yyyy/MM/dd") + " 23:59:59");
							foreach (MobspLoadRemindingTask_Result item in Enumerable.ToList<MobspLoadRemindingTask_Result>((IEnumerable<MobspLoadRemindingTask_Result>)cRMSpEntities.MobspLoadRemindingTask(date, currentUser.UserId, value5, num, result2, currentUser.UserLastCId)))
							{
								if (text.Trim() != "")
								{
									text += "@";
								}
								text = text + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.cnvsCompanyId + "|" + item.cnvsPersonId + "|" + item.cnvsProjectId + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						data = text;
						message = ((isFinish.HasValue && isFinish != false) ? Messages.msgPrivateReminderCompletedSuccessfully : Messages.msgPrivateReminderDoneSuccessfully);
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.msgErrorSelectedItemIsNotAnItem;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> AlarmUserTaskDidIt(int userTaskId = 0, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		string data = "";
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : result2);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					string text = "";
					DateTime now = DateTime.Now;
					if (userTaskId > 0)
					{
						short value = short.Parse(Financial.Get().Id.ToString());
						short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
						DateTime value3 = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						MobspSelectUserTaskById_Result mobspSelectUserTaskById_Result = Enumerable.FirstOrDefault<MobspSelectUserTaskById_Result>((IEnumerable<MobspSelectUserTaskById_Result>)cRMSpEntities.MobspSelectUserTaskById(num, result2, userTaskId));
						if (mobspSelectUserTaskById_Result == null)
						{
							return new ServiceResult<string>
							{
								Data = null,
								Message = Messages.msgErrorUserTaskNotFound,
								Status = ServiceResultStatus.Error
							};
						}
						if (mobspSelectUserTaskById_Result.UserId != UserLogin.CurrentUser.UserId)
						{
							return new ServiceResult<string>
							{
								Data = null,
								Message = Messages.msgErrorUserTaskNotBelongToUser,
								Status = ServiceResultStatus.Error
							};
						}
						Calendar calendar = (num switch
						{
							1065 => new CultureInfo("fa-IR"), 
							1025 => new CultureInfo("ar-SA"), 
							_ => new CultureInfo("en-US"), 
						}).Calendar;
						bool? userTaskRemindRepeatDaily = mobspSelectUserTaskById_Result.UserTaskRemindRepeatDaily;
						bool? userTaskRemindRepeatWeekly = mobspSelectUserTaskById_Result.UserTaskRemindRepeatWeekly;
						bool? userTaskRemindRepeatMonthly = mobspSelectUserTaskById_Result.UserTaskRemindRepeatMonthly;
						bool? userTaskRemindRepeatYearly = mobspSelectUserTaskById_Result.UserTaskRemindRepeatYearly;
						if (!mobspSelectUserTaskById_Result.UserTaskRemindRepeatDaily.GetValueOrDefault() && !mobspSelectUserTaskById_Result.UserTaskRemindRepeatWeekly.GetValueOrDefault() && !mobspSelectUserTaskById_Result.UserTaskRemindRepeatMonthly.GetValueOrDefault() && !mobspSelectUserTaskById_Result.UserTaskRemindRepeatYearly.GetValueOrDefault())
						{
							return new ServiceResult<string>
							{
								Data = null,
								Message = Messages.msgErrorUserTaskAlreadyCompleted,
								Status = ServiceResultStatus.Error
							};
						}
						TimeSpan value4 = TimeSpan.Zero;
						if (!string.IsNullOrEmpty(mobspSelectUserTaskById_Result.UserTaskTime))
						{
							value4 = ((!TimeSpan.TryParse(mobspSelectUserTaskById_Result.UserTaskTime, out var result3)) ? DateTime.ParseExact(mobspSelectUserTaskById_Result.UserTaskTime, "HH:mm", CultureInfo.InvariantCulture).TimeOfDay : result3);
						}
						mobspSelectUserTaskById_Result.UserTaskDate.Date.Add(value4);
						mobspSelectUserTaskById_Result.UserTaskDateEnd?.Date.Add(value4);
						DateTime? userTaskRemindDateTime = mobspSelectUserTaskById_Result.UserTaskRemindDateTime;
						DateTime? userTaskRemindDateTime2 = userTaskRemindDateTime;
						string userTaskRemindDate = null;
						if (userTaskRemindDateTime.HasValue && userTaskRemindDateTime <= now)
						{
							userTaskRemindDateTime2 = GetNextRepeatDate(calendar, userTaskRemindDateTime.Value, now, null, userTaskRemindRepeatDaily.GetValueOrDefault(), userTaskRemindRepeatWeekly.GetValueOrDefault(), userTaskRemindRepeatMonthly.GetValueOrDefault(), userTaskRemindRepeatYearly.GetValueOrDefault());
							if (userTaskRemindDateTime2.HasValue)
							{
								DateTime date = userTaskRemindDateTime2.Value.Date;
								DateTime value5 = userTaskRemindDateTime.Value;
								userTaskRemindDateTime2 = date.AddHours(value5.Hour).AddMinutes(value5.Minute).AddSeconds(value5.Second);
								userTaskRemindDate = userTaskRemindDateTime2.Value.ToString("yyyyMMdd", new PersianCulture());
							}
						}
						cRMSpEntities.MobspUserTaskAlarmDidIt(userTaskId, UserLogin.CurrentUser.UserId, year1: value, month1: value2, registerDate: value3, registerDatePersian: registerDatePersian, appType: Mobile.Classes.Configuration.AppType, userTaskRemindDateTime: userTaskRemindDateTime2, userTaskRemindDate: userTaskRemindDate);
						try
						{
							UserLoginInfo currentUser = UserLogin.CurrentUser;
							DateTime now2 = DateTime.Now;
							string date2 = now2.ToString("yyyyMMdd");
							DateTime value6 = DateTime.Parse(now2.ToString("yyyy/MM/dd") + " 23:59:59");
							foreach (MobspLoadRemindingTask_Result item in Enumerable.ToList<MobspLoadRemindingTask_Result>((IEnumerable<MobspLoadRemindingTask_Result>)cRMSpEntities.MobspLoadRemindingTask(date2, currentUser.UserId, value6, num, result2, currentUser.UserLastCId)))
							{
								if (text.Trim() != "")
								{
									text += "@";
								}
								text = text + item.Type + "|" + item.UserTaskId + "|" + item.UserTaskTitle + "|" + item.UserTaskTime + "|" + item.UserTaskDatePersian + "|" + item.UserTaskRemindTime + "|" + item.UserTaskRemindDate + "|" + item.cnvsCompanyId + "|" + item.cnvsPersonId + "|" + item.cnvsProjectId + "|" + item.UserTaskDate.ToString() + "|" + item.UserTaskRemindDateTime.ToString() + "|" + ((item.IsRecurringTask != false) ? 1 : 0);
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						data = text;
						message = Messages.msgReminderAlarmTimeChangedSuccessfully;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.msgErrorSelectedItemIsNotAnItem;
						data = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e2)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	private DateTime? GetNextRepeatDate(Calendar calendar, DateTime startDate, DateTime currentDate, DateTime? endDate, bool repeatDaily, bool repeatWeekly, bool repeatMonthly, bool repeatYearly)
	{
		if (startDate == DateTime.MinValue || startDate == DateTime.MaxValue)
		{
			return null;
		}
		if (endDate.HasValue && startDate.Date > endDate.Value.Date)
		{
			return null;
		}
		if (startDate.Date > currentDate.Date)
		{
			return startDate;
		}
		DateTime dateTime = startDate;
		if (repeatDaily)
		{
			int num = (int)(currentDate.Date - startDate.Date).TotalDays;
			if (num < 0)
			{
				return startDate;
			}
			dateTime = startDate.AddDays(num + 1);
		}
		else if (repeatWeekly)
		{
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = dateTime.AddDays(7.0);
			}
		}
		else if (repeatMonthly)
		{
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = calendar.AddMonths(dateTime, 1);
			}
		}
		else
		{
			if (!repeatYearly)
			{
				return null;
			}
			while (dateTime.Date <= currentDate.Date)
			{
				dateTime = calendar.AddYears(dateTime, 1);
			}
		}
		if (endDate.HasValue && dateTime.Date > endDate.Value.Date)
		{
			return null;
		}
		return dateTime;
	}
}
