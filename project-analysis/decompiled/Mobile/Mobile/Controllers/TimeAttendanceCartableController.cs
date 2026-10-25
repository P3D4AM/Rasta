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

public class TimeAttendanceCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<TimeAttendanceResultViewModel> ResultsTimeAttendanceCartable(int userId, DateTime fromDate, DateTime toDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		TimeAttendanceResultViewModel timeAttendanceResultViewModel = null;
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
					cRMSpEntities = new CRMSpEntities();
					timeAttendanceResultViewModel = new TimeAttendanceResultViewModel();
					ObjectParameter executedQuery = new ObjectParameter("ExecutedQuery", "");
					timeAttendanceResultViewModel.Result = Enumerable.ToList<MobspResultsTimeAttendanceCartable_Result>((IEnumerable<MobspResultsTimeAttendanceCartable_Result>)cRMEntities.MobspResultsTimeAttendanceCartable(userID: userId, fDate: fromDate, tDate: toDate, currDateTime: DateTime.Now, currUserID: token2.userId, languageID: result, defaultLanguageID: result2, executedQuery: executedQuery));
					timeAttendanceResultViewModel.Footer = Enumerable.FirstOrDefault<MobspResultsTimeAttendanceCartableFooter_Result>((IEnumerable<MobspResultsTimeAttendanceCartableFooter_Result>)cRMSpEntities.MobspResultsTimeAttendanceCartableFooter(userID: userId, fDate: fromDate, tDate: toDate, currDateTime: DateTime.Now, currUserID: token2.userId, languageID: result, defaultLanguageID: result2));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					timeAttendanceResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				timeAttendanceResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			timeAttendanceResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<TimeAttendanceResultViewModel>
		{
			Message = message,
			Data = timeAttendanceResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<TimeAttendanceEditRequestResultViewModel> GetTimeAttendanceEditRequest(int msgdId = 0, int attachRecId = 0, int attachRecIdI = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		TimeAttendanceEditRequestResultViewModel timeAttendanceEditRequestResultViewModel = null;
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
					timeAttendanceEditRequestResultViewModel = new TimeAttendanceEditRequestResultViewModel();
					MobspSelectTimeAttendanceRequestMessage_Result mobspSelectTimeAttendanceRequestMessage_Result = Enumerable.FirstOrDefault<MobspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<MobspSelectTimeAttendanceRequestMessage_Result>)cRMEntities.MobspSelectTimeAttendanceRequestMessage(attachRecId, null, null, null, null, msgdId));
					if (mobspSelectTimeAttendanceRequestMessage_Result != null)
					{
						timeAttendanceEditRequestResultViewModel.FirstRequest = mobspSelectTimeAttendanceRequestMessage_Result;
						TimeAttendanceRequestDataViewModel timeAttendanceRequestDataViewModel = Enumerable.FirstOrDefault<TimeAttendanceRequestDataViewModel>((IEnumerable<TimeAttendanceRequestDataViewModel>)JsonConvert.DeserializeObject<List<TimeAttendanceRequestDataViewModel>>(mobspSelectTimeAttendanceRequestMessage_Result.RequestData));
						if (timeAttendanceRequestDataViewModel.tmUserId.GetValueOrDefault() != 0)
						{
							timeAttendanceRequestDataViewModel.tmUser = Mobile.Classes.Helper.User.GetUserName(timeAttendanceRequestDataViewModel.tmUserId.Value, num, result2);
							List<TimeAttendanceRequestDataViewModel> list = new List<TimeAttendanceRequestDataViewModel>();
							list.Add(timeAttendanceRequestDataViewModel);
							timeAttendanceEditRequestResultViewModel.FirstRequest.RequestData = JsonConvert.SerializeObject(list);
						}
						DateTime value = DateTime.Now;
						if (!string.IsNullOrEmpty(timeAttendanceRequestDataViewModel.tmDate))
						{
							value = DateTime.Parse(timeAttendanceRequestDataViewModel.tmDate + " 00:00:00", new CultureInfo("en-US"));
						}
						if (attachRecIdI != 0)
						{
							timeAttendanceEditRequestResultViewModel.SecondRequest = Enumerable.FirstOrDefault<MobspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<MobspSelectTimeAttendanceRequestMessage_Result>)cRMEntities.MobspSelectTimeAttendanceRequestMessage(attachRecIdI, null, null, null, null, msgdId));
						}
						else
						{
							timeAttendanceEditRequestResultViewModel.SecondRequest = Enumerable.FirstOrDefault<MobspSelectTimeAttendanceRequestMessage_Result>((IEnumerable<MobspSelectTimeAttendanceRequestMessage_Result>)cRMEntities.MobspSelectTimeAttendanceRequestMessage(null, (mobspSelectTimeAttendanceRequestMessage_Result.RequestTypeId != 1) ? 1 : 2, token2.userId, value.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0, null));
						}
						timeAttendanceEditRequestResultViewModel.CurrentRecord = Enumerable.FirstOrDefault<MobspSelectTimeAttendanceByDate_Result>((IEnumerable<MobspSelectTimeAttendanceByDate_Result>)cRMEntities.MobspSelectTimeAttendanceByDate(value, timeAttendanceRequestDataViewModel.tmUserId, num, result2));
						if (timeAttendanceEditRequestResultViewModel.FirstRequest != null && timeAttendanceEditRequestResultViewModel.FirstRequest.MessageId.GetValueOrDefault() != 0 && timeAttendanceEditRequestResultViewModel.FirstRequest.MsgdTypeId != 0)
						{
							ReadInternalMessage(timeAttendanceEditRequestResultViewModel.FirstRequest.MessageId.Value, timeAttendanceEditRequestResultViewModel.FirstRequest.MsgdTypeId, cId);
						}
						if (timeAttendanceEditRequestResultViewModel.SecondRequest != null && timeAttendanceEditRequestResultViewModel.SecondRequest.MessageId.GetValueOrDefault() != 0 && timeAttendanceEditRequestResultViewModel.SecondRequest.MsgdTypeId != 0)
						{
							ReadInternalMessage(timeAttendanceEditRequestResultViewModel.SecondRequest.MessageId.Value, timeAttendanceEditRequestResultViewModel.SecondRequest.MsgdTypeId, cId);
						}
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					timeAttendanceEditRequestResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				timeAttendanceEditRequestResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			timeAttendanceEditRequestResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<TimeAttendanceEditRequestResultViewModel>
		{
			Message = message,
			Data = timeAttendanceEditRequestResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> VerifyTimeAttendanceEditRequest(TimeAttendanceVerifyEditRequestViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		string data = null;
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
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					now.ToString("HH:mm:ss");
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					string text2 = null;
					DateTime? dateTime = null;
					DateTime? dateTime2 = null;
					DateTime? dateTime3 = null;
					DateTime dateTime4 = default(DateTime);
					string text3 = "";
					if (!string.IsNullOrEmpty(model.tmEntryTime))
					{
						model.tmEntryTime += ":00";
					}
					if (!string.IsNullOrEmpty(model.tmExitTime))
					{
						model.tmExitTime += ":00";
					}
					try
					{
						if (string.IsNullOrEmpty(model.tmDatePersian))
						{
							ServiceResult<string> result3 = new ServiceResult<string>
							{
								Message = Messages.msgErrorEnterDate,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result3;
						}
						string text4 = DateTime.Now.ToString("HH:mm:ss");
						if (!string.IsNullOrEmpty(model.tmEntryTime))
						{
							text4 = model.tmEntryTime;
						}
						text3 = PersianDate.GetFormatetdDate(model.tmDatePersian.Replace("/", ""));
						dateTime4 = num switch
						{
							1065 => DateTime.Parse(text3 + " " + text4, new PersianCulture()), 
							1025 => DateTime.Parse(text3 + " " + text4, new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text3 + " " + text4, new CultureInfo("en-US")), 
						};
						dateTime = dateTime4;
						text2 = dateTime4.ToString("yyyyMMdd", new CultureInfo("fa-IR"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<string> result4 = new ServiceResult<string>
						{
							Message = Messages.ErrorFormatDatePersian,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.tmEntryTime))
						{
							text3 = PersianDate.GetFormatetdDate(model.tmDatePersian.Replace("/", ""));
							dateTime2 = num switch
							{
								1065 => DateTime.Parse(text3 + " " + model.tmEntryTime, new PersianCulture()), 
								1025 => DateTime.Parse(text3 + " " + model.tmEntryTime, new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text3 + " " + model.tmEntryTime, new CultureInfo("en-US")), 
							};
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<string> result5 = new ServiceResult<string>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result5;
					}
					try
					{
						if (!string.IsNullOrEmpty(model.tmExitTime))
						{
							text3 = PersianDate.GetFormatetdDate(model.tmDatePersian.Replace("/", ""));
							dateTime3 = num switch
							{
								1065 => DateTime.Parse(text3 + " " + model.tmExitTime, new PersianCulture()), 
								1025 => DateTime.Parse(text3 + " " + model.tmExitTime, new CultureInfo("ar-SA")), 
								_ => DateTime.Parse(text3 + " " + model.tmExitTime, new CultureInfo("en-US")), 
							};
						}
					}
					catch (Exception e3)
					{
						ErrorSignal.FromCurrentContext().Raise(e3);
						ServiceResult<string> result6 = new ServiceResult<string>
						{
							Message = Messages.ErrorFormatTime,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result6;
					}
					if (!model.VerifyEntryRequest.GetValueOrDefault() && model.VerifyExitRequest.GetValueOrDefault() && Enumerable.FirstOrDefault<MobspSelectTimeAttendanceByDate_Result>((IEnumerable<MobspSelectTimeAttendanceByDate_Result>)cRMEntities.MobspSelectTimeAttendanceByDate(dateTime, model.tmUserId, num, result2)) == null)
					{
						ServiceResult<string> result7 = new ServiceResult<string>
						{
							Message = Messages.CtmVerifyEntryTimeReqRquiredBecauseIsEmpty,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result7;
					}
					if (string.IsNullOrEmpty(model.tmEntryRegisterIP))
					{
						model.tmEntryRegisterIP = null;
					}
					if (string.IsNullOrEmpty(model.tmExitRegisterIP))
					{
						model.tmExitRegisterIP = null;
					}
					int num2 = 0;
					if (model.VerifyEntryRequest.GetValueOrDefault() && model.VerifyExitRequest.GetValueOrDefault())
					{
						num2 = 1;
						model.tmEntryTimeVerifyUserId = userId;
						model.tmEntryTimeVerifyDate = value;
						model.tmEntryTimeVerifyDatePersian = text;
						model.tmExitTimeVerifyUserId = userId;
						model.tmExitTimeVerifyDate = value;
						model.tmExitTimeVerifyDatePersian = text;
					}
					else if (model.VerifyEntryRequest.GetValueOrDefault())
					{
						num2 = 2;
						model.tmEntryTimeVerifyUserId = userId;
						model.tmEntryTimeVerifyDate = value;
						model.tmEntryTimeVerifyDatePersian = text;
					}
					else if (model.VerifyExitRequest.GetValueOrDefault())
					{
						num2 = 3;
						model.tmExitTimeVerifyUserId = userId;
						model.tmExitTimeVerifyDate = value;
						model.tmExitTimeVerifyDatePersian = text;
					}
					ObjectParameter objectParameter = new ObjectParameter("Result", 0);
					if (num2 != 0)
					{
						CRMEntities cRMEntities2 = cRMEntities;
						int? mode = num2;
						DateTime? tmDate = dateTime;
						string tmDatePersian = text2;
						int? tmUserId = model.tmUserId;
						DateTime? tmEntryTime = dateTime2;
						string tmEntryRegisterIP = model.tmEntryRegisterIP;
						DateTime? tmExitTime = dateTime3;
						string tmExitRegisterIP = model.tmExitRegisterIP;
						int? userId2 = userId;
						short? year = value2;
						short? month = value3;
						DateTime? registerDate = value;
						int? languageID = num;
						int? defaultLanguageID = result2;
						ObjectParameter result8 = objectParameter;
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities2.MobspInsertUpdateTimeAttendance(mode, null, tmDate, tmDatePersian, tmUserId, tmEntryTime, tmEntryRegisterIP, tmExitTime, tmExitRegisterIP, null, userId2, year, month, registerDate, text, appType, languageID, defaultLanguageID, model.tmEntryTimeVerifyUserId, model.tmEntryTimeVerifyDate, model.tmEntryTimeVerifyDatePersian, model.tmExitTimeVerifyUserId, model.tmExitTimeVerifyDate, model.tmExitTimeVerifyDatePersian, result8));
					}
					else
					{
						objectParameter.Value = 1;
					}
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "1")
						{
							if (model.VerifyEntryRequest.GetValueOrDefault())
							{
								cRMEntities.MobspUpdateTimeAttendanceRequestVerified(model.EntryRequestId.Value, true, userId, value, text, appType);
							}
							else if (model.UnVerifyEntryRequest.GetValueOrDefault())
							{
								cRMEntities.MobspUpdateTimeAttendanceRequestVerified(model.EntryRequestId.Value, false, userId, value, text, appType);
							}
							if (model.VerifyExitRequest.GetValueOrDefault())
							{
								cRMEntities.MobspUpdateTimeAttendanceRequestVerified(model.ExitRequestId.Value, true, userId, value, text, appType);
							}
							else if (model.UnVerifyExitRequest.GetValueOrDefault())
							{
								cRMEntities.MobspUpdateTimeAttendanceRequestVerified(model.ExitRequestId.Value, false, userId, value, text, appType);
							}
							message = Messages.MobMsgSuccessAction;
							status = ServiceResultStatus.Success;
						}
						else
						{
							message = Messages.msgErrorRunFunction;
							status = ServiceResultStatus.Success;
						}
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
		catch (Exception e4)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e4);
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

	public bool ReadInternalMessage(int messageId, int typeId, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			cRMEntities.MobspInternalMessageUpdate("Read", messageId, UserLogin.CurrentUser.UserId, typeId, time, date, Mobile.Classes.Configuration.AppType, cId);
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectTimeAttendanceByDate_Result> GetToDayTimeAttendance(int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectTimeAttendanceByDate_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectTimeAttendanceByDate_Result>((IEnumerable<MobspSelectTimeAttendanceByDate_Result>)cRMEntities.MobspSelectTimeAttendanceByDate(userId: token2.userId, date: DateTime.Now, languageID: result, defaultLanguageID: result2));
					status = ServiceResultStatus.Success;
					message = "";
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
		return new ServiceResult<MobspSelectTimeAttendanceByDate_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
