using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using CRM.General.Calendar;
using CRM.General.Utilities;
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

public class HRMRequestController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> TimeAttendanceEditRequest(HrmTimeAttendanceEditReqViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
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
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					string msgdSendTime = now.ToString("HH:mm:ss");
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					model.tmUserId = token2.userId;
					HRMMobspSelectUsersById_Result hRMMobspSelectUsersById_Result = Enumerable.FirstOrDefault<HRMMobspSelectUsersById_Result>((IEnumerable<HRMMobspSelectUsersById_Result>)cRMSpEntities.HRMMobspSelectUsersById(model.tmUserId, num, defLangId, model.CenterId));
					if ((hRMMobspSelectUsersById_Result?.ResponsibleUserId).GetValueOrDefault() == 0)
					{
						ServiceResult<bool> result2 = new ServiceResult<bool>
						{
							Message = Messages.HrmMobMsgErrorResponsibleUserNotDefined,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					int value4 = hRMMobspSelectUsersById_Result.ResponsibleUserId.Value;
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result item in list)
					{
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = model.tmDescription,
							LanguageId = item.LanguageID
						});
					}
					string tmDate = "";
					if (!string.IsNullOrEmpty(model.tmDatePersian))
					{
						DateTime now2 = DateTime.Now;
						string formatetdDate = PersianDate.GetFormatetdDate(model.tmDatePersian.Replace("/", ""));
						tmDate = (num switch
						{
							1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
						}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					}
					if (model.IsEntryRequestDuplicate.GetValueOrDefault())
					{
						model.IsEntryRequest = false;
					}
					if (model.IsExitRequestDuplicate.GetValueOrDefault())
					{
						model.IsExitRequest = false;
					}
					int? requestId = null;
					int? requestTypeId = null;
					string requestData = null;
					int? requestIdI = null;
					int? requestTypeIdI = null;
					string requestDataI = null;
					if (model.IsEntryRequest.GetValueOrDefault())
					{
						requestData = JsonConvert.SerializeObject(Enumerable.ToList<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)new List<HrmTimeAttendanceVerifyExtraDataViewModel>
						{
							new HrmTimeAttendanceVerifyExtraDataViewModel
							{
								tmTime = model.tmEntryTime,
								tmRegisterIP = model.tmEntryRegisterIP,
								tmDate = tmDate,
								tmDescription = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2)),
								tmUserId = model.tmUserId,
								UserLat = model.UserLat,
								UserLng = model.UserLng
							}
						}));
						requestTypeId = 1;
					}
					else if (model.ResendEntryRequestId.GetValueOrDefault() != 0)
					{
						requestId = model.ResendEntryRequestId;
						HRMMobspSelectTimeAttendanceRequest_Result hRMMobspSelectTimeAttendanceRequest_Result = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(model.ResendEntryRequestId, null, null, null, null));
						if (hRMMobspSelectTimeAttendanceRequest_Result != null)
						{
							list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(Enumerable.FirstOrDefault<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<HrmTimeAttendanceVerifyExtraDataViewModel>>(hRMMobspSelectTimeAttendanceRequest_Result.RequestData)).tmDescription);
						}
						else
						{
							requestId = null;
						}
					}
					if (model.IsExitRequest.GetValueOrDefault())
					{
						List<HrmTimeAttendanceVerifyExtraDataViewModel> list3 = new List<HrmTimeAttendanceVerifyExtraDataViewModel>();
						HrmTimeAttendanceVerifyExtraDataViewModel hrmTimeAttendanceVerifyExtraDataViewModel = new HrmTimeAttendanceVerifyExtraDataViewModel();
						hrmTimeAttendanceVerifyExtraDataViewModel.tmTime = model.tmExitTime;
						hrmTimeAttendanceVerifyExtraDataViewModel.tmRegisterIP = model.tmExitRegisterIP;
						hrmTimeAttendanceVerifyExtraDataViewModel.tmDate = tmDate;
						hrmTimeAttendanceVerifyExtraDataViewModel.tmDescription = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2));
						hrmTimeAttendanceVerifyExtraDataViewModel.tmUserId = model.tmUserId;
						hrmTimeAttendanceVerifyExtraDataViewModel.UserLat = model.UserLat;
						hrmTimeAttendanceVerifyExtraDataViewModel.UserLng = model.UserLng;
						list3.Add(hrmTimeAttendanceVerifyExtraDataViewModel);
						if (!model.IsEntryRequest.GetValueOrDefault())
						{
							requestData = JsonConvert.SerializeObject(Enumerable.ToList<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)list3));
							requestTypeId = 2;
						}
						else
						{
							requestDataI = JsonConvert.SerializeObject(Enumerable.ToList<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)list3));
							requestTypeIdI = 2;
						}
					}
					else if (model.ResendExitRequestId.GetValueOrDefault() != 0)
					{
						if (requestId.HasValue)
						{
							requestIdI = model.ResendExitRequestId;
						}
						else
						{
							requestId = model.ResendExitRequestId;
						}
						HRMMobspSelectTimeAttendanceRequest_Result hRMMobspSelectTimeAttendanceRequest_Result2 = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(model.ResendExitRequestId, null, null, null, null));
						if (hRMMobspSelectTimeAttendanceRequest_Result2 != null)
						{
							list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(Enumerable.FirstOrDefault<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<HrmTimeAttendanceVerifyExtraDataViewModel>>(hRMMobspSelectTimeAttendanceRequest_Result2.RequestData)).tmDescription);
						}
						else
						{
							requestId = null;
						}
					}
					List<HrmTimeAttendanceEditReqMultiLanguageViewModel> list4 = new List<HrmTimeAttendanceEditReqMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result lang in list)
					{
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
						HrmTimeAttendanceEditReqMultiLanguageViewModel hrmTimeAttendanceEditReqMultiLanguageViewModel = new HrmTimeAttendanceEditReqMultiLanguageViewModel();
						if (model.tmUserId == userId)
						{
							hrmTimeAttendanceEditReqMultiLanguageViewModel.Subject = MyResource.GetResourceString("CTimeAttendanceEditRequst", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						}
						else
						{
							hrmTimeAttendanceEditReqMultiLanguageViewModel.Subject = MyResource.GetResourceString("CTimeAttendanceEditRequstForAnotherUser", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						}
						string languageCollation = lang.LanguageCollation;
						CultureInfo cultureInfo = ((languageCollation.Trim().ToLower() == "fa-ir") ? new PersianCulture() : new CultureInfo(languageCollation));
						string text2 = DateTime.Now.ToString("yyyy/MM/dd", cultureInfo);
						hrmTimeAttendanceEditReqMultiLanguageViewModel.Body = Environment.NewLine + "-->" + Common.GetUserName(userId, defLangId, lang.LanguageID, model.CenterId) + "  " + text2 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + commonMultiLanguageViewModel.Value;
						hrmTimeAttendanceEditReqMultiLanguageViewModel.LanguageId = lang.LanguageID;
						list4.Add(hrmTimeAttendanceEditReqMultiLanguageViewModel);
					}
					string msgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list4));
					string msgSubject = ((Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list4, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list4, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)).Subject : null);
					string msgBody = ((Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list4, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list4, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)).Body : null);
					ObjectParameter objectParameter = new ObjectParameter("InsertedID", -1);
					if (requestId.HasValue || requestTypeId.HasValue)
					{
						Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSendTimeAttendanceEditRequest(requestId, requestTypeId, requestData, requestIdI, requestTypeIdI, requestDataI, msgSubject, msgBody, msgLangValue, userId, value4, text, msgdSendTime, value, userId, value2, value3, value, text, appType, defLangId, objectParameter, model.CenterId));
					}
					else
					{
						objectParameter.Value = 1;
					}
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.HrmMobMsgErrorAction;
							data = false;
							status = ServiceResultStatus.Error;
						}
						else
						{
							PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
							message = Messages.HrmMobMsgSuccessAction;
							data = true;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<HRMMobspSelectTimeAttendanceRequestHistory_Result>> TimeAttendanceRequestHistory(DateTime fromDate, DateTime toDate, int? pageNumber = 1, int? pageSize = 10, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<HRMMobspSelectTimeAttendanceRequestHistory_Result> data = null;
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
					CRMEntities cRMEntities2 = cRMEntities;
					int? userID = token2.userId;
					DateTime? fDate = fromDate;
					DateTime? tDate = toDate;
					int? languageID = result;
					int? defaultLanguageID = result2;
					data = Enumerable.ToList<HRMMobspSelectTimeAttendanceRequestHistory_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequestHistory_Result>)cRMEntities2.HRMMobspSelectTimeAttendanceRequestHistory(userID, fDate, tDate, pageNumber, pageSize, languageID, defaultLanguageID));
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
		return new ServiceResult<List<HRMMobspSelectTimeAttendanceRequestHistory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HrmTimeAttendanceDateStatusViewModel> GetTimeAttendanceDateStatus(string tmDate, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HrmTimeAttendanceDateStatusViewModel hrmTimeAttendanceDateStatusViewModel = null;
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
					DateTime value = DateTime.Now;
					if (!string.IsNullOrEmpty(tmDate))
					{
						string formatetdDate = PersianDate.GetFormatetdDate(tmDate.Replace("/", ""));
						value = num switch
						{
							1065 => DateTime.Parse(formatetdDate + " 00:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(formatetdDate + " 00:00:00", new CultureInfo("en-US")), 
						};
					}
					HRMMobspSelectTimeAttendanceByDate_Result hRMMobspSelectTimeAttendanceByDate_Result = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceByDate_Result>((IEnumerable<HRMMobspSelectTimeAttendanceByDate_Result>)cRMEntities.HRMMobspSelectTimeAttendanceByDate(value, token2.userId, result, result2));
					hrmTimeAttendanceDateStatusViewModel = ((hRMMobspSelectTimeAttendanceByDate_Result == null) ? new HrmTimeAttendanceDateStatusViewModel
					{
						HasAttendance = false
					} : new HrmTimeAttendanceDateStatusViewModel
					{
						tmCurrentEntryTime = ((!hRMMobspSelectTimeAttendanceByDate_Result.tmEntryTime.HasValue) ? null : hRMMobspSelectTimeAttendanceByDate_Result.tmEntryTime.Value.ToString("HH:mm:ss")),
						tmCurrentExitTime = ((!hRMMobspSelectTimeAttendanceByDate_Result.tmExitTime.HasValue) ? null : hRMMobspSelectTimeAttendanceByDate_Result.tmExitTime.Value.ToString("HH:mm:ss")),
						tmCurrentEntryRegisterIP = hRMMobspSelectTimeAttendanceByDate_Result.tmEntryRegisterIP,
						tmCurrentExitRegisterIP = hRMMobspSelectTimeAttendanceByDate_Result.tmExitRegisterIP,
						HasAttendance = true
					});
					hrmTimeAttendanceDateStatusViewModel.tmDate = (tmDate = value.ToString("yyyy/MM/dd", new CultureInfo("fa-IR")));
					HRMMobspSelectTimeAttendanceRequest_Result hRMMobspSelectTimeAttendanceRequest_Result = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(null, 1, token2.userId, value.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0));
					if (hRMMobspSelectTimeAttendanceByDate_Result == null && hRMMobspSelectTimeAttendanceRequest_Result == null)
					{
						hrmTimeAttendanceDateStatusViewModel.EntryRequestIsRequired = true;
					}
					if (hRMMobspSelectTimeAttendanceRequest_Result != null)
					{
						hrmTimeAttendanceDateStatusViewModel.tmDuplicateEntryRequestId = hRMMobspSelectTimeAttendanceRequest_Result.TimeAttendanceRequestId;
						HrmTimeAttendanceVerifyExtraDataViewModel hrmTimeAttendanceVerifyExtraDataViewModel = Enumerable.FirstOrDefault<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<HrmTimeAttendanceVerifyExtraDataViewModel>>(hRMMobspSelectTimeAttendanceRequest_Result.RequestData));
						hrmTimeAttendanceDateStatusViewModel.tmDuplicateEntryTime = hrmTimeAttendanceVerifyExtraDataViewModel.tmTime;
					}
					HRMMobspSelectTimeAttendanceRequest_Result hRMMobspSelectTimeAttendanceRequest_Result2 = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(null, 2, token2.userId, value.ToString("yyyy-MM-dd", new CultureInfo("en-US")), 0));
					if (hRMMobspSelectTimeAttendanceRequest_Result2 != null)
					{
						hrmTimeAttendanceDateStatusViewModel.tmDuplicateExitRequestId = hRMMobspSelectTimeAttendanceRequest_Result2.TimeAttendanceRequestId;
						HrmTimeAttendanceVerifyExtraDataViewModel hrmTimeAttendanceVerifyExtraDataViewModel2 = Enumerable.FirstOrDefault<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<HrmTimeAttendanceVerifyExtraDataViewModel>>(hRMMobspSelectTimeAttendanceRequest_Result2.RequestData));
						hrmTimeAttendanceDateStatusViewModel.tmDuplicateExitTime = hrmTimeAttendanceVerifyExtraDataViewModel2.tmTime;
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					hrmTimeAttendanceDateStatusViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				hrmTimeAttendanceDateStatusViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			hrmTimeAttendanceDateStatusViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<HrmTimeAttendanceDateStatusViewModel>
		{
			Message = message,
			Data = hrmTimeAttendanceDateStatusViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> ResendTimeAttendanceEditRequest(int requestId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int num = ((result > 0) ? result : defLangId);
		baseInfo.SetCulture(num);
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					if (requestId == 0)
					{
						ServiceResult<bool> result2 = new ServiceResult<bool>
						{
							Message = Messages.MobMsgErrorParamHaveNotCorrectlyInitialized,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result2;
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					int userId = token2.userId;
					DateTime value = now;
					string text = now.ToString("yyyyMMdd", new PersianCulture());
					string msgdSendTime = now.ToString("HH:mm:ss");
					short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					List<HRMMobspSelectLanguages_Result> list = Enumerable.ToList<HRMMobspSelectLanguages_Result>((IEnumerable<HRMMobspSelectLanguages_Result>)cRMEntities.HRMMobspSelectLanguages());
					HRMMobspSelectUsersById_Result hRMMobspSelectUsersById_Result = Enumerable.FirstOrDefault<HRMMobspSelectUsersById_Result>((IEnumerable<HRMMobspSelectUsersById_Result>)cRMSpEntities.HRMMobspSelectUsersById(token2.userId, num, defLangId, cId));
					if ((hRMMobspSelectUsersById_Result?.ResponsibleUserId).GetValueOrDefault() == 0)
					{
						ServiceResult<bool> result3 = new ServiceResult<bool>
						{
							Message = Messages.HrmMobMsgErrorResponsibleUserNotDefined,
							Data = false,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						cRMSpEntities?.Dispose();
						return result3;
					}
					int value4 = hRMMobspSelectUsersById_Result.ResponsibleUserId.Value;
					List<CommonMultiLanguageViewModel> list2 = JsonConvert.DeserializeObject<List<CommonMultiLanguageViewModel>>(Enumerable.FirstOrDefault<HrmTimeAttendanceVerifyExtraDataViewModel>((IEnumerable<HrmTimeAttendanceVerifyExtraDataViewModel>)JsonConvert.DeserializeObject<List<HrmTimeAttendanceVerifyExtraDataViewModel>>(Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(requestId, null, null, null, null)).RequestData)).tmDescription);
					List<HrmTimeAttendanceEditReqMultiLanguageViewModel> list3 = new List<HrmTimeAttendanceEditReqMultiLanguageViewModel>();
					foreach (HRMMobspSelectLanguages_Result lang in list)
					{
						CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel m) => m.LanguageId == lang.LanguageID)));
						HrmTimeAttendanceEditReqMultiLanguageViewModel hrmTimeAttendanceEditReqMultiLanguageViewModel = new HrmTimeAttendanceEditReqMultiLanguageViewModel();
						hrmTimeAttendanceEditReqMultiLanguageViewModel.Subject = MyResource.GetResourceString("CTimeAttendanceEditRequst", lang.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
						string languageCollation = lang.LanguageCollation;
						CultureInfo cultureInfo = ((languageCollation.Trim().ToLower() == "fa-ir") ? new PersianCulture() : new CultureInfo(languageCollation));
						string text2 = DateTime.Now.ToString("yyyy/MM/dd", cultureInfo);
						hrmTimeAttendanceEditReqMultiLanguageViewModel.Body = Environment.NewLine + "-->" + Common.GetUserName(userId, defLangId, lang.LanguageID, cId) + "  " + text2 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + commonMultiLanguageViewModel.Value;
						hrmTimeAttendanceEditReqMultiLanguageViewModel.LanguageId = lang.LanguageID;
						list3.Add(hrmTimeAttendanceEditReqMultiLanguageViewModel);
					}
					string msgLangValue = JsonConvert.SerializeObject(Enumerable.ToList<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list3));
					string msgSubject = ((Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)).Subject : null);
					string msgBody = ((Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<HrmTimeAttendanceEditReqMultiLanguageViewModel>((IEnumerable<HrmTimeAttendanceEditReqMultiLanguageViewModel>)list3, (Func<HrmTimeAttendanceEditReqMultiLanguageViewModel, bool>)((HrmTimeAttendanceEditReqMultiLanguageViewModel c) => c.LanguageId == defLangId)).Body : null);
					ObjectParameter objectParameter = new ObjectParameter("InsertedID", -1);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.HRMMobspSendTimeAttendanceEditRequest(requestId, null, null, null, null, null, msgSubject, msgBody, msgLangValue, userId, value4, text, msgdSendTime, value, userId, value2, value3, value, text, appType, defLangId, objectParameter, cId));
					if (objectParameter != null)
					{
						if (objectParameter.Value.ToString() == "-1")
						{
							message = Messages.HrmMobMsgErrorAction;
							data = false;
							status = ServiceResultStatus.Error;
						}
						else
						{
							PushNotif.NewIntMsgNotify(withthread: true, cId);
							message = Messages.HrmMobMsgSuccessAction;
							data = true;
							status = ServiceResultStatus.Success;
						}
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = false;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = false;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = false;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<bool>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<HRMMobspSelectTimeAttendanceRequest_Result> TimeAttendanceRequestById(int reqId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		HRMMobspSelectTimeAttendanceRequest_Result data = null;
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
					data = Enumerable.FirstOrDefault<HRMMobspSelectTimeAttendanceRequest_Result>((IEnumerable<HRMMobspSelectTimeAttendanceRequest_Result>)cRMEntities.HRMMobspSelectTimeAttendanceRequest(reqId, null, null, null, null));
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
		return new ServiceResult<HRMMobspSelectTimeAttendanceRequest_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
