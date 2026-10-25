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

namespace Mobile.Controllers;

public class InternalTaskCartableController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>> SelectInternalMessageType(string fromDate, string toDate, int? ln = null, int? cId = null)
	{
		int LangId = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out LangId);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgSelectInternalMessageType_Result> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((LangId > 0) ? LangId : result);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
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
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>> result2 = new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result2;
						}
						fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now = ((LangId != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"));
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>> result3 = new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result3;
					}
					try
					{
						if (string.IsNullOrEmpty(toDate))
						{
							ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>> result4 = new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
							{
								Message = Messages.MobMsgErrorDateNotEntered,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result4;
						}
						toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						now2 = ((LangId != 1065) ? DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None) : DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"));
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>> result5 = new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result5;
					}
					string unReadText = Labels.MoblblUnRead;
					MobspSelectLanguages_Result mobspSelectLanguages_Result = Enumerable.FirstOrDefault<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages()), (Func<MobspSelectLanguages_Result, bool>)((MobspSelectLanguages_Result m) => m.LanguageID == LangId));
					if (mobspSelectLanguages_Result != null)
					{
						unReadText = MyResource.GetResourceString("MoblblUnRead", mobspSelectLanguages_Result.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					}
					data = Enumerable.ToList<MobspIntMsgSelectInternalMessageType_Result>((IEnumerable<MobspIntMsgSelectInternalMessageType_Result>)cRMEntities.MobspIntMsgSelectInternalMessageType(token2.userId, now, now2, LangId, result, unReadText, cId));
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
		return new ServiceResult<List<MobspIntMsgSelectInternalMessageType_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>> SelectUserMessageFromType(string fromDate, string toDate, int msgTypeId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgSelectUserMessageFromType_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					try
					{
						if (string.IsNullOrEmpty(fromDate))
						{
							ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>> result3 = new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
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
						ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>> result4 = new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
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
							ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>> result5 = new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
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
						ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>> result6 = new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result6;
					}
					CRMEntities cRMEntities2 = cRMEntities;
					int? userId = token2.userId;
					int? typeId = msgTypeId;
					DateTime? fDate = now;
					DateTime? tDate = now2;
					int? languageID = result;
					int? defaultLanguageID = result2;
					list = Enumerable.ToList<MobspIntMsgSelectUserMessageFromType_Result>((IEnumerable<MobspIntMsgSelectUserMessageFromType_Result>)cRMEntities2.MobspIntMsgSelectUserMessageFromType(userId, typeId, fDate, tDate, pageNumber, pageSize, languageID, defaultLanguageID, cId));
					foreach (MobspIntMsgSelectUserMessageFromType_Result item in list)
					{
						int result7 = 0;
						int.TryParse(item.InternalMessageID.ToString(), out result7);
						int result8 = 0;
						int.TryParse(item.msgdTypeId.ToString(), out result8);
						UpdateInternalMessage("Receive", result7, result8, cId);
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e3)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspIntMsgSelectUserMessageFromType_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<DropDownItemWithParentId>> UserTreeInternalMessageCartable(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<DropDownItemWithParentId> data = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<DropDownItemWithParentId>>
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<DropDownItemWithParentId>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					List<MobspIntMsgUserTreeInternalMessageCartable_Result> list = Enumerable.ToList<MobspIntMsgUserTreeInternalMessageCartable_Result>((IEnumerable<MobspIntMsgUserTreeInternalMessageCartable_Result>)cRMEntities.MobspIntMsgUserTreeInternalMessageCartable(token2.userId, 5, result, result2, cId));
					List<DropDownItemWithParentId> list2 = new List<DropDownItemWithParentId>();
					foreach (MobspIntMsgUserTreeInternalMessageCartable_Result item in list)
					{
						DropDownItemWithParentId dropDownItemWithParentId = new DropDownItemWithParentId();
						int result3 = 0;
						int.TryParse(item.KeyID.ToString(), out result3);
						dropDownItemWithParentId.Id = result3;
						dropDownItemWithParentId.Title = item.KeyName;
						int result4 = 0;
						int.TryParse(item.cnt.ToString(), out result4);
						Dictionary<string, string> dictionary = new Dictionary<string, string>();
						dictionary.Add("Count", result4.ToString());
						dropDownItemWithParentId.ExtraField = dictionary;
						list2.Add(dropDownItemWithParentId);
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
		return new ServiceResult<List<DropDownItemWithParentId>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspInternalMessageLoadShortUserMessage_Result>> InternalMessageLoadShortUserMessage(int msgTypeId, int? pageNumber = 1, int? pageSize = 10, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspInternalMessageLoadShortUserMessage_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspInternalMessageLoadShortUserMessage_Result>>
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<MobspInternalMessageLoadShortUserMessage_Result>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMEntities = new CRMEntities();
					CRMEntities cRMEntities2 = cRMEntities;
					int? userID = token2.userId;
					int? typeID = msgTypeId;
					int? languageID = result;
					int? defaultLanguageID = result2;
					list = Enumerable.ToList<MobspInternalMessageLoadShortUserMessage_Result>((IEnumerable<MobspInternalMessageLoadShortUserMessage_Result>)cRMEntities2.MobspInternalMessageLoadShortUserMessage(userID, typeID, pageNumber, pageSize, languageID, defaultLanguageID, cId));
					int result3 = 0;
					if (list.Count > 0)
					{
						MobspInternalMessageLoadShortUserMessage_Result mobspInternalMessageLoadShortUserMessage_Result = Enumerable.FirstOrDefault<MobspInternalMessageLoadShortUserMessage_Result>((IEnumerable<MobspInternalMessageLoadShortUserMessage_Result>)list);
						if (mobspInternalMessageLoadShortUserMessage_Result != null)
						{
							int.TryParse(mobspInternalMessageLoadShortUserMessage_Result.InternalMessageID.ToString(), out result3);
							int result4 = 0;
							int.TryParse(mobspInternalMessageLoadShortUserMessage_Result.msgdTypeId.ToString(), out result4);
							UpdateInternalMessage("Receive", result3, result4, cId);
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspInternalMessageLoadShortUserMessage_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InternalTaskDetailsViewModel> SelectMessageInType(int msgId, int msgTypeId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		InternalTaskDetailsViewModel internalTaskDetailsViewModel = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<InternalTaskDetailsViewModel>
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
					if (msgTypeId == 0)
					{
						ServiceResult<InternalTaskDetailsViewModel> result3 = new ServiceResult<InternalTaskDetailsViewModel>
						{
							Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (msgId == 0)
					{
						ServiceResult<InternalTaskDetailsViewModel> result4 = new ServiceResult<InternalTaskDetailsViewModel>
						{
							Message = Messages.MobMsgErrorIntMsgIdNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					if (msgTypeId == 1 || msgTypeId == 5 || msgTypeId == 6 || msgTypeId == 7 || msgTypeId == 8 || msgTypeId == 10 || msgTypeId == 12 || msgTypeId == 9 || msgTypeId == 14 || msgTypeId == 16 || msgTypeId == 45 || msgTypeId == 50 || msgTypeId == 55 || msgTypeId == 60 || msgTypeId == 17 || msgTypeId == 18 || msgTypeId == 19 || msgTypeId == 20 || msgTypeId == 21)
					{
						UpdateInternalMessage("Read", msgId, msgTypeId, cId);
					}
					MobspIntMsgSelectMessageInType_Result mobspIntMsgSelectMessageInType_Result = Enumerable.FirstOrDefault<MobspIntMsgSelectMessageInType_Result>((IEnumerable<MobspIntMsgSelectMessageInType_Result>)cRMEntities.MobspIntMsgSelectMessageInType(msgId, token2.userId, msgTypeId, result, result2));
					if (mobspIntMsgSelectMessageInType_Result != null)
					{
						internalTaskDetailsViewModel = new InternalTaskDetailsViewModel();
						internalTaskDetailsViewModel.Detail = mobspIntMsgSelectMessageInType_Result;
						List<MobspIntMsgSelectMessageFiles_Result> fileList = Enumerable.ToList<MobspIntMsgSelectMessageFiles_Result>((IEnumerable<MobspIntMsgSelectMessageFiles_Result>)cRMEntities.MobspIntMsgSelectMessageFiles(msgId));
						internalTaskDetailsViewModel.FileList = fileList;
						List<MobspIntMsgGetToUsersInfo_Result> receiverList = Enumerable.ToList<MobspIntMsgGetToUsersInfo_Result>((IEnumerable<MobspIntMsgGetToUsersInfo_Result>)cRMEntities.MobspIntMsgGetToUsersInfo(msgId, result, result2));
						internalTaskDetailsViewModel.ReceiverList = receiverList;
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					internalTaskDetailsViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				internalTaskDetailsViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			internalTaskDetailsViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<InternalTaskDetailsViewModel>
		{
			Message = message,
			Data = internalTaskDetailsViewModel,
			Status = status
		};
	}

	public bool UpdateInternalMessage(string mode, int messageId, int typeId, int? cId = null)
	{
		CRMEntities cRMEntities = null;
		bool result = false;
		try
		{
			cRMEntities = new CRMEntities();
			string date = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string time = DateTime.Now.ToString("HH:mm:ss");
			cRMEntities.MobspInternalMessageUpdate(mode, messageId, UserLogin.CurrentUser.UserId, typeId, time, date, Mobile.Classes.Configuration.AppType, cId);
			result = true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = false;
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GotoUnreadMessage(int msgId, int msgTypeId, int? ln = null, int? cId = null)
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
			if (!UserLogin.IsUserAccess("frmInternalMessageView", "actGotoUnread", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<string>
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
					if (msgTypeId == 0)
					{
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (msgId == 0)
					{
						ServiceResult<string> result4 = new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorIntMsgIdNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					data = (UpdateInternalMessage("UnRead", msgId, msgTypeId, cId) ? "yes" : "no");
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> Insert(InsertInternalMessageViewModel model)
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
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmInternalMessageNew", "actSend", UserLogin.CurrentUser, model.CenterId))
			{
				return new ServiceResult<string>
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
					string text = "";
					int countError = 0;
					cRMEntities.MobspInternalMessageLoadReceiver(token2.userId);
					text = CheckBeforeSubmitInternalMessage(model, result, ref countError);
					if (countError > 0)
					{
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = text,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					DateTime now = DateTime.Now;
					DateTime value = DateTime.Now;
					DateTime value2 = default(DateTime);
					DateTime dateTime = default(DateTime);
					string text2 = "";
					try
					{
						if (!string.IsNullOrEmpty(model.FirstRegisterDatePersian) && !string.IsNullOrEmpty(model.FirstRegisterDatePersian))
						{
							text2 = PersianDate.GetFormatetdDate(model.FirstRegisterDatePersian.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text2 + " " + now.ToString("HH:mm:ss"), new PersianCulture());
								model.FirstRegisterDatePersian = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text2 + " " + now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								model.FirstRegisterDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						ServiceResult<string> result4 = new ServiceResult<string>
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
						if (!string.IsNullOrEmpty(model.MsgSendDate))
						{
							string text3 = ((!string.IsNullOrEmpty(model.MsgSendTime)) ? model.MsgSendTime : "00:00:00");
							text2 = PersianDate.GetFormatetdDate(model.MsgSendDate.Replace("/", ""));
							if (result == 1065)
							{
								dateTime = DateTime.Parse(text2 + " " + text3, new PersianCulture());
								model.MsgSendDate = dateTime.ToString("yyyyMMdd");
							}
							else
							{
								dateTime = DateTime.Parse(text2 + " " + text3, new CultureInfo("en-US"));
								model.MsgSendDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							value2 = dateTime;
						}
					}
					catch (Exception e2)
					{
						ErrorSignal.FromCurrentContext().Raise(e2);
						ServiceResult<string> result5 = new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorDateFormatIncorrect,
							Data = null,
							Status = ServiceResultStatus.Error
						};
						cRMEntities?.Dispose();
						return result5;
					}
					int userId = token2.userId;
					model.MsgFromUserId = token2.userId;
					DateTime value3 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value4 = short.Parse(now.ToString("yyyy", new PersianCulture()));
					short value5 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					if (!string.IsNullOrEmpty(model.MsgToUsersId))
					{
						cRMEntities.MobspIntMsgUpdateMultiReceiver(token2.userId, model.MsgToUsersId, true);
					}
					model.AttachRecId = ((model.MessageAttachRecId > 0) ? model.MessageAttachRecId : 0);
					if (model.MsgActiveInCycle.GetValueOrDefault())
					{
						model.MsgTypeId = 12;
					}
					if (model.MsgTypeId <= 0 || model.MsgTypeId == 2)
					{
						model.MsgTypeId = 1;
					}
					if (model.MsgTypeId != 12)
					{
						_ = Enumerable.FirstOrDefault<MobspSelectUser_Result>((IEnumerable<MobspSelectUser_Result>)cRMEntities.MobspSelectUser(token2.userId, result, result2, model.CenterId))?.FullName;
						if (!string.IsNullOrEmpty(model.MsgBody))
						{
							List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
							string text4 = "";
							string text5 = "";
							string text6 = "";
							foreach (MobspSelectLanguages_Result item in list)
							{
								string text7 = ((item.LanguageID == 1065) ? now.ToString("yyyy/MM/dd", new PersianCulture()) : now.ToString("yyyy/MM/dd", new CultureInfo("en-US")));
								text4 = "";
								text5 = "";
								text4 = ((!string.IsNullOrEmpty(model.MsgSubject)) ? model.MsgSubject : "");
								text5 = Environment.NewLine + "-->" + Common.GetUserName(token2.userId, result2, item.LanguageID, model.CenterId) + "  " + text7 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + model.MsgBody;
								text6 = text6 + "MsgSubj=" + text4 + "|@#@|MsgBody=" + text5 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
							}
							model.MsgBody = text6;
						}
					}
					if (model.ReplyPriorityId == 0)
					{
						model.ReplyPriorityId = null;
					}
					if (model.MsgLastGroupId == 0)
					{
						model.MsgLastGroupId = null;
					}
					if (model.MsgMasterId == 0)
					{
						model.MsgMasterId = null;
					}
					if (countError == 0)
					{
						string text8 = "";
						string text9 = "";
						ObjectParameter objectParameter = new ObjectParameter("InternalMessageID", 0);
						CRMEntities cRMEntities2 = cRMEntities;
						int? msgMasterId = model.MsgMasterId;
						string msgSubject = model.MsgSubject;
						string msgBody = model.MsgBody;
						bool? msgActiveInCycle = model.MsgActiveInCycle;
						int? msgdTypeId = model.MsgTypeId;
						int? msgdFromUserId = model.MsgFromUserId;
						int? msgdToUserId = 0;
						string msgSendDate = model.MsgSendDate;
						string msgSendTime = model.MsgSendTime;
						DateTime? msgdSendDateTime = value2;
						int? replyPriorityId = model.ReplyPriorityId;
						string msgdAttachFile = (string.IsNullOrEmpty(text8) ? null : text8);
						int? msgdAttachRecId = model.AttachRecId;
						string msgdAttachRecDesc = (string.IsNullOrEmpty(text9) ? null : text9);
						int? msgLastGroupId = model.MsgLastGroupId;
						int? userId2 = userId;
						short? year = value4;
						short? month = value5;
						DateTime? registerDate = value3;
						int? languageID = result2;
						int? firstRegisterUserId = model.FirstRegisterUserId;
						DateTime? firstRegisterDate = value;
						string firstRegisterDatePersian = model.FirstRegisterDatePersian;
						string apiId = model.ApiId;
						int? msgdAttachRecIdI = model.msgdAttachRecIdI;
						string msgdAttachRecDescI = model.msgdAttachRecDescI;
						string msgdExtraData = model.MsgdExtraData;
						ObjectResult<int?> objectResult = cRMEntities2.MobspInsertInternalMessage(msgMasterId, msgSubject, msgBody, msgActiveInCycle, msgdTypeId, msgdFromUserId, msgdToUserId, msgSendDate, msgSendTime, msgdSendDateTime, replyPriorityId, msgdAttachFile, msgdAttachRecId, msgdAttachRecDesc, msgLastGroupId, userId2, year, month, registerDate, registerDatePersian, appType, languageID, firstRegisterUserId, firstRegisterDate, firstRegisterDatePersian, apiId, objectParameter, msgdAttachRecIdI, msgdAttachRecDescI, msgdExtraData, model.CenterId);
						_ = (int)objectParameter.Value;
						int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)objectResult).ToString(), out var result6);
						if (result6 >= 1 || result6 == -1)
						{
							if (result6 > 0)
							{
								if (model.MsgMasterId > 0 && (model.MsgTypeId == 1 || model.MsgTypeId == 5 || model.MsgTypeId == 6 || model.MsgTypeId == 7 || model.MsgTypeId == 8 || model.MsgTypeId == 10 || model.MsgTypeId == 12 || model.MsgTypeId == 9 || model.MsgTypeId == 14 || model.MsgTypeId == 16 || model.MsgTypeId == 45 || model.MsgTypeId == 50 || model.MsgTypeId == 55 || model.MsgTypeId == 60 || model.MsgTypeId == 17 || model.MsgTypeId == 18 || model.MsgTypeId == 19 || model.MsgTypeId == 20 || model.MsgTypeId == 21))
								{
									UpdateInternalMessage("Read", model.MsgMasterId.GetValueOrDefault(), model.MsgTypeId, model.CenterId);
								}
								PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
								data = result6.ToString();
								message = Messages.MobInternalMessageSuccessfullySend;
								status = ServiceResultStatus.Success;
							}
							else
							{
								data = "0";
								message = Messages.MobInternalMessageFailSend;
								status = ServiceResultStatus.Fail;
							}
						}
						else
						{
							data = "0";
							message = Messages.MobInternalMessageFailSend;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = null;
						message = text;
						status = ServiceResultStatus.Fail;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	public string CheckBeforeSubmitInternalMessage(InsertInternalMessageViewModel intMsg, int? ln, ref int countError)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		string text = "";
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		intMsg.MsgSubject = ((intMsg.MsgSubject == "@khali@") ? null : intMsg.MsgSubject);
		intMsg.MsgBody = ((intMsg.MsgBody == "@khali@") ? null : intMsg.MsgBody);
		intMsg.MsgAttachRecId = ((intMsg.MsgAttachRecId == 0) ? null : intMsg.MsgAttachRecId);
		intMsg.MsgLastGroupId = ((intMsg.MsgLastGroupId == 0) ? null : intMsg.MsgLastGroupId);
		intMsg.ReplyPriorityId = ((intMsg.ReplyPriorityId == 0) ? null : intMsg.ReplyPriorityId);
		intMsg.MessageAttachRecId = ((intMsg.MessageAttachRecId != 0) ? intMsg.MessageAttachRecId : 0);
		intMsg.LoadMessage = ((intMsg.LoadMessage == "@khali@") ? null : intMsg.LoadMessage);
		intMsg.AttachRecId = ((intMsg.AttachRecId != 0) ? intMsg.AttachRecId : 0);
		if (string.IsNullOrEmpty(intMsg.MsgToUsersTitle))
		{
			text = text + Messages.MobCheckEmptyMsgToUsersTitle + "\r\n";
			countError++;
		}
		if (string.IsNullOrEmpty(intMsg.MsgBody))
		{
			text = text + Messages.MobCheckEmptyMsgBody + "\r\n";
			countError++;
		}
		if (intMsg.MsgActiveInCycle.GetValueOrDefault() && (!intMsg.MsgLastGroupId.HasValue || intMsg.MsgLastGroupId == 0))
		{
			text = text + Messages.MobCheckEmptyMsgActiveInCycle + "\r\n";
			countError++;
		}
		if (!string.IsNullOrEmpty(intMsg.FirstRegisterDatePersian))
		{
			if (!DateTime.TryParse(DateTimeClass.ConvertDateWoSlashToSlash(intMsg.FirstRegisterDatePersian), out var _))
			{
				countError++;
				text = text + Messages.MobCheckFormatIntMsgImportDate + "\r\n";
			}
		}
		else
		{
			text = text + Messages.MobCheckEmptyIntMsgImportDate + "\r\n";
			countError++;
		}
		if (!string.IsNullOrEmpty(intMsg.MsgSendDate))
		{
			if (!DateTime.TryParse(DateTimeClass.ConvertDateWoSlashToSlash(intMsg.MsgSendDate), out var _))
			{
				countError++;
				text = text + Messages.MobCheckFormatIntMsgSendDate + "\r\n";
			}
		}
		else
		{
			text = text + Messages.MobCheckEmptyIntMsgSendDate + "\r\n";
			countError++;
		}
		if (!string.IsNullOrEmpty(intMsg.MsgSendTime))
		{
			string s = intMsg.MsgSendTime.Replace(":", "");
			int result5 = 0;
			if (intMsg.MsgSendTime.Length < 5 || intMsg.MsgSendTime.Length > 8 || !int.TryParse(s, out result5))
			{
				countError++;
				text = text + Messages.MobCheckFormatIntMsgSendTime + "\r\n";
			}
		}
		else
		{
			text = text + Messages.MobCheckEmptyIntMsgSendTime + "\r\n";
			countError++;
		}
		if (!string.IsNullOrEmpty(intMsg.MsgSubject) && intMsg.MsgSubject.Length > 200)
		{
			countError++;
			text = text + Messages.MobCheckLengthIntMsgSubject + "\r\n";
		}
		if (!string.IsNullOrEmpty(intMsg.MsgBody) && intMsg.MsgBody.Length > 10000)
		{
			countError++;
			text = text + Messages.MobCheckLengthIntMsgBody + "\r\n";
		}
		return text;
	}

	public string CheckBeforeSubmitInternalMessage(SendPublicInternalMessageViewModel intMsg, int? ln, ref int countError)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		string text = "";
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		intMsg.MsgSubject = ((intMsg.MsgSubject == "@khali@") ? null : intMsg.MsgSubject);
		intMsg.MsgBody = ((intMsg.MsgBody == "@khali@") ? null : intMsg.MsgBody);
		intMsg.MsgAttachRecId = ((intMsg.MsgAttachRecId == 0) ? null : intMsg.MsgAttachRecId);
		intMsg.MsgLastGroupId = ((intMsg.MsgLastGroupId == 0) ? null : intMsg.MsgLastGroupId);
		intMsg.ReplyPriorityId = ((intMsg.ReplyPriorityId == 0) ? null : intMsg.ReplyPriorityId);
		intMsg.MessageAttachRecId = ((intMsg.MessageAttachRecId != 0) ? intMsg.MessageAttachRecId : 0);
		intMsg.LoadMessage = ((intMsg.LoadMessage == "@khali@") ? null : intMsg.LoadMessage);
		intMsg.AttachRecId = ((intMsg.AttachRecId != 0) ? intMsg.AttachRecId : 0);
		if (string.IsNullOrEmpty(intMsg.MsgToUsersTitle))
		{
			text = text + Messages.MobCheckEmptyMsgToUsersTitle + "\r\n";
			countError++;
		}
		if (string.IsNullOrEmpty(intMsg.MsgBody))
		{
			text = text + Messages.MobCheckEmptyMsgBody + "\r\n";
			countError++;
		}
		if (intMsg.MsgActiveInCycle.GetValueOrDefault() && (!intMsg.MsgLastGroupId.HasValue || intMsg.MsgLastGroupId == 0))
		{
			text = text + Messages.MobCheckEmptyMsgActiveInCycle + "\r\n";
			countError++;
		}
		if (!string.IsNullOrEmpty(intMsg.MsgSubject) && intMsg.MsgSubject.Length > 200)
		{
			countError++;
			text = text + Messages.MobCheckLengthIntMsgSubject + "\r\n";
		}
		if (!string.IsNullOrEmpty(intMsg.MsgBody) && intMsg.MsgBody.Length > 2000)
		{
			countError++;
			text = text + Messages.MobCheckLengthIntMsgBody + "\r\n";
		}
		return text;
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgSelectCmpVerifyMessage_Result>> SelectCmpVerifyMessage(int cmpId, int toUserId, int pageNumber, int pageSize, bool? isRead, int? ln = null, int? cmpPersonId = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgSelectCmpVerifyMessage_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspIntMsgSelectCmpVerifyMessage_Result>>
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
					list = Enumerable.ToList<MobspIntMsgSelectCmpVerifyMessage_Result>((IEnumerable<MobspIntMsgSelectCmpVerifyMessage_Result>)cRMEntities.MobspIntMsgSelectCmpVerifyMessage(cmpId, toUserId, pageNumber, pageSize, isRead, result, result2, cmpPersonId, cId));
					foreach (MobspIntMsgSelectCmpVerifyMessage_Result item in list)
					{
						int result3 = 0;
						int.TryParse(item.InternalMessageID.ToString(), out result3);
						int result4 = 0;
						int.TryParse(item.msgdTypeId.ToString(), out result4);
						UpdateInternalMessage("Receive", result3, result4, cId);
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspIntMsgSelectCmpVerifyMessage_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgSelectCmpReferMessage_Result>> SelectCmpReferMessage(int cmpId, int toUserId, int pageNumber, int pageSize, bool? isRead, int? ln = null, int? cmpPersonId = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgSelectCmpReferMessage_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobspIntMsgSelectCmpReferMessage_Result>>
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
					list = Enumerable.ToList<MobspIntMsgSelectCmpReferMessage_Result>((IEnumerable<MobspIntMsgSelectCmpReferMessage_Result>)cRMEntities.MobspIntMsgSelectCmpReferMessage(cmpId, toUserId, pageNumber, pageSize, isRead, result, result2, cmpPersonId, cId));
					foreach (MobspIntMsgSelectCmpReferMessage_Result item in list)
					{
						int result3 = 0;
						int.TryParse(item.InternalMessageID.ToString(), out result3);
						int result4 = 0;
						int.TryParse(item.msgdTypeId.ToString(), out result4);
						UpdateInternalMessage("Receive", result3, result4, cId);
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<List<MobspIntMsgSelectCmpReferMessage_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result>> IntMsgGetOrSendByTypeAndAttachRecId(int msgdTypeId, int msgdAttachRecId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result> data = null;
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
					data = Enumerable.ToList<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetOrSendByTypeAndAttachRecId(token2.userId, msgdTypeId, msgdAttachRecId, result, result2));
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
		return new ServiceResult<List<MobspIntMsgGetOrSendByTypeAndAttachRecId_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<MobspSelectInternalMessageDetailsById_Result> SelectInternalMessageDetailsById(int msgDetailId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		MobspSelectInternalMessageDetailsById_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectInternalMessageDetailsById_Result>((IEnumerable<MobspSelectInternalMessageDetailsById_Result>)cRMEntities.MobspSelectInternalMessageDetailsById(msgDetailId, result, result2));
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
		return new ServiceResult<MobspSelectInternalMessageDetailsById_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	public ServiceResult<string> SendPublicInternalMessage(SendPublicInternalMessageViewModel model)
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
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			string extra = "";
			if (base.Request.Headers.Contains("extra"))
			{
				extra = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("extra"));
			}
			if (new FoCommon().CheckExtra(extra))
			{
				cRMEntities = new CRMEntities();
				string text = "";
				int countError = 0;
				cRMEntities.MobspInternalMessageLoadReceiverWithoutLink(model.UserId);
				text = CheckBeforeSubmitInternalMessage(model, result, ref countError);
				if (countError > 0)
				{
					ServiceResult<string> result3 = new ServiceResult<string>
					{
						Message = text,
						Data = null,
						Status = ServiceResultStatus.Fail
					};
					cRMEntities?.Dispose();
					return result3;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				string msgdSendTime = now.ToString("HH:mm:ss", new PersianCulture());
				short value2 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Mobile.Classes.Configuration.AppType;
				if (!string.IsNullOrEmpty(model.MsgToUsersId))
				{
					cRMEntities.MobspIntMsgUpdateMultiReceiver(model.UserId, model.MsgToUsersId, true);
				}
				model.AttachRecId = ((model.MessageAttachRecId > 0) ? model.MessageAttachRecId : 0);
				if (model.MsgActiveInCycle.GetValueOrDefault())
				{
					model.MsgTypeId = 12;
				}
				if (model.MsgTypeId <= 0 || model.MsgTypeId == 2)
				{
					model.MsgTypeId = 1;
				}
				if (model.MsgTypeId != 12)
				{
					_ = Enumerable.FirstOrDefault<MobspSelectUser_Result>((IEnumerable<MobspSelectUser_Result>)cRMEntities.MobspSelectUser(model.UserId, result, result2, model.CenterId))?.FullName;
					if (!string.IsNullOrEmpty(model.MsgBody))
					{
						List<MobspSelectLanguages_Result> list = Enumerable.ToList<MobspSelectLanguages_Result>((IEnumerable<MobspSelectLanguages_Result>)cRMEntities.MobspSelectLanguages());
						string text3 = "";
						string text4 = "";
						string text5 = "";
						foreach (MobspSelectLanguages_Result item in list)
						{
							string text6 = ((item.LanguageID == 1065) ? now.ToString("yyyy/MM/dd", new PersianCulture()) : now.ToString("yyyy/MM/dd", new CultureInfo("en-US")));
							text3 = "";
							text4 = "";
							text3 = ((!string.IsNullOrEmpty(model.MsgSubject)) ? model.MsgSubject : "");
							text4 = Environment.NewLine + "-->" + Common.GetUserName(model.UserId, result2, item.LanguageID, model.CenterId) + "  " + text6 + " " + DateTime.Now.ToString("HH:mm:ss") + Environment.NewLine + model.MsgBody;
							text5 = text5 + "MsgSubj=" + text3 + "|@#@|MsgBody=" + text4 + "|@#@|LangId=" + item.LanguageID + "|@#@||^#^|";
						}
						model.MsgBody = text5;
					}
				}
				if (model.ReplyPriorityId == 0)
				{
					model.ReplyPriorityId = null;
				}
				if (model.MsgLastGroupId == 0)
				{
					model.MsgLastGroupId = null;
				}
				if (model.MsgMasterId == 0)
				{
					model.MsgMasterId = null;
				}
				if (countError == 0)
				{
					string text7 = "";
					string text8 = "";
					ObjectParameter objectParameter = new ObjectParameter("InternalMessageID", 0);
					CRMEntities cRMEntities2 = cRMEntities;
					int? msgMasterId = model.MsgMasterId;
					string msgSubject = model.MsgSubject;
					string msgBody = model.MsgBody;
					bool? msgActiveInCycle = model.MsgActiveInCycle;
					int? msgdTypeId = model.MsgTypeId;
					int? msgdFromUserId = model.MsgFromUserId;
					int? msgdToUserId = 0;
					DateTime? msgdSendDateTime = now;
					int? replyPriorityId = model.ReplyPriorityId;
					string msgdAttachFile = (string.IsNullOrEmpty(text7) ? null : text7);
					int? msgdAttachRecId = model.AttachRecId;
					string msgdAttachRecDesc = (string.IsNullOrEmpty(text8) ? null : text8);
					int? msgLastGroupId = model.MsgLastGroupId;
					int? userId = model.UserId;
					short? year = value2;
					short? month = value3;
					DateTime? registerDate = value;
					int? languageID = result2;
					int? firstRegisterUserId = model.FirstRegisterUserId;
					DateTime? firstRegisterDate = now;
					string apiId = model.ApiId;
					int? msgdAttachRecIdI = model.msgdAttachRecIdI;
					string msgdAttachRecDescI = model.msgdAttachRecDescI;
					string msgdExtraData = model.MsgdExtraData;
					ObjectResult<int?> objectResult = cRMEntities2.MobspInsertInternalMessage(msgMasterId, msgSubject, msgBody, msgActiveInCycle, msgdTypeId, msgdFromUserId, msgdToUserId, text2, msgdSendTime, msgdSendDateTime, replyPriorityId, msgdAttachFile, msgdAttachRecId, msgdAttachRecDesc, msgLastGroupId, userId, year, month, registerDate, text2, appType, languageID, firstRegisterUserId, firstRegisterDate, text2, apiId, objectParameter, msgdAttachRecIdI, msgdAttachRecDescI, msgdExtraData, model.CenterId);
					_ = (int)objectParameter.Value;
					int.TryParse(Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)objectResult).ToString(), out var result4);
					if (result4 >= 1 || result4 == -1)
					{
						if (result4 > 0)
						{
							PushNotif.NewIntMsgNotify(withthread: true, model.CenterId);
							data = result4.ToString();
							message = Messages.MobInternalMessageSuccessfullySend;
							status = ServiceResultStatus.Success;
						}
						else
						{
							data = "0";
							message = Messages.MobInternalMessageFailSend;
							status = ServiceResultStatus.Fail;
						}
					}
					else
					{
						data = "0";
						message = Messages.MobInternalMessageFailSend;
						status = ServiceResultStatus.Fail;
					}
				}
				else
				{
					data = null;
					message = text;
					status = ServiceResultStatus.Fail;
				}
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
	public ServiceResult<string> GotoReadMessage(int msgId, int msgTypeId, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					if (msgTypeId == 0)
					{
						ServiceResult<string> result3 = new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result3;
					}
					if (msgId == 0)
					{
						ServiceResult<string> result4 = new ServiceResult<string>
						{
							Message = Messages.MobMsgErrorIntMsgIdNotSelected,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
						cRMEntities?.Dispose();
						return result4;
					}
					data = (UpdateInternalMessage("Read", msgId, msgTypeId, cId) ? "yes" : "no");
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GotoReadMessageMultiple(string internalIds, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					if (!string.IsNullOrEmpty(internalIds))
					{
						string[] array = internalIds.Split(new char[1] { '|' });
						foreach (string text in array)
						{
							if (string.IsNullOrEmpty(text))
							{
								continue;
							}
							string[] array2 = text.Split(new char[1] { ',' });
							int result3 = 0;
							int result4 = 0;
							int.TryParse(array2[0], out result3);
							int.TryParse(array2[1], out result4);
							if (result3 > 0 && result4 > 0)
							{
								UpdateInternalMessage("Read", result3, result4, cId);
								continue;
							}
							if (result3 == 0)
							{
								ServiceResult<string> result5 = new ServiceResult<string>
								{
									Message = Messages.MobMsgErrorIntMsgIdNotSelected,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
								cRMEntities?.Dispose();
								return result5;
							}
							ServiceResult<string> result6 = new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						data = Messages.MobMsgSuccessAction;
						message = "";
						status = ServiceResultStatus.Success;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> GotoUnReadMessageMultiple(string internalIds, int? ln = null, int? cId = null)
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
				if (new Common().GetToken(token) != null)
				{
					if (!string.IsNullOrEmpty(internalIds))
					{
						string[] array = internalIds.Split(new char[1] { '|' });
						foreach (string text in array)
						{
							if (string.IsNullOrEmpty(text))
							{
								continue;
							}
							string[] array2 = text.Split(new char[1] { ',' });
							int result3 = 0;
							int result4 = 0;
							int.TryParse(array2[0], out result3);
							int.TryParse(array2[1], out result4);
							if (result3 > 0 && result4 > 0)
							{
								UpdateInternalMessage("UnRead", result3, result4, cId);
								continue;
							}
							if (result3 == 0)
							{
								ServiceResult<string> result5 = new ServiceResult<string>
								{
									Message = Messages.MobMsgErrorIntMsgIdNotSelected,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
								cRMEntities?.Dispose();
								return result5;
							}
							ServiceResult<string> result6 = new ServiceResult<string>
							{
								Message = Messages.MobMsgErrorIntMsgTypeNotSelected,
								Data = null,
								Status = ServiceResultStatus.Fail
							};
							cRMEntities?.Dispose();
							return result6;
						}
						data = Messages.MobMsgSuccessAction;
						message = "";
						status = ServiceResultStatus.Success;
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<string> UpdateInternalMessageAttachFileCount(int msgId, int? ln = null)
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
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					cRMEntities.MobspUpdateInternalMessageAttachFileCount(msgId, 1);
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
		return new ServiceResult<string>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspIntMsgGetAttachRecIdMessageHistory_Result>> GetAttachRecIdMessageHistory(int msgdTypeId, int msgdAttachRecId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgGetAttachRecIdMessageHistory_Result> data = null;
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
					data = Enumerable.ToList<MobspIntMsgGetAttachRecIdMessageHistory_Result>((IEnumerable<MobspIntMsgGetAttachRecIdMessageHistory_Result>)cRMEntities.MobspIntMsgGetAttachRecIdMessageHistory(msgdTypeId, msgdAttachRecId, result, result2));
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
		return new ServiceResult<List<MobspIntMsgGetAttachRecIdMessageHistory_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> GetUnReadMessageCnt(int? ln = null, int? cId = null)
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
				Token token2 = new Common().GetToken(token);
				if (token2 != null)
				{
					cRMEntities = new CRMEntities();
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspIntMsgGetUnReadMessgeCnt(token2.userId, cId));
					if (num.HasValue)
					{
						data = num.GetValueOrDefault();
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErorrNotFound;
						data = 0;
						status = ServiceResultStatus.Fail;
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
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0;
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
	public ServiceResult<List<MobspIntMsgSelectMessageFiles_Result>> GetInternalMessageFiles(int msgId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspIntMsgSelectMessageFiles_Result> data = null;
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
					data = Enumerable.ToList<MobspIntMsgSelectMessageFiles_Result>((IEnumerable<MobspIntMsgSelectMessageFiles_Result>)cRMEntities.MobspIntMsgSelectMessageFiles(msgId));
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
		return new ServiceResult<List<MobspIntMsgSelectMessageFiles_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>> HrmInternalMessageLoadShortUserMessage(string msgTypeIds, int isRead = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result> list = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		BaseInfo baseInfo = new BaseInfo();
		int culture = ((result > 0) ? result : result2);
		baseInfo.SetCulture(culture);
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actcInternalTask", UserLogin.CurrentUser, cId))
			{
				return new ServiceResult<List<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>>
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<List<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					cRMSpEntities = new CRMSpEntities();
					list = Enumerable.ToList<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>((IEnumerable<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>)cRMSpEntities.MobHrmspInternalMessageLoadShortUserMessageByTypes(token2.userId, isRead, msgTypeIds, ",", result, result2));
					int result3 = 0;
					if (list.Count > 0)
					{
						MobHrmspInternalMessageLoadShortUserMessageByTypes_Result mobHrmspInternalMessageLoadShortUserMessageByTypes_Result = Enumerable.FirstOrDefault<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>((IEnumerable<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>)list);
						if (mobHrmspInternalMessageLoadShortUserMessageByTypes_Result != null)
						{
							int.TryParse(mobHrmspInternalMessageLoadShortUserMessageByTypes_Result.InternalMessageID.ToString(), out result3);
							int result4 = 0;
							int.TryParse(mobHrmspInternalMessageLoadShortUserMessageByTypes_Result.msgdTypeId.ToString(), out result4);
							UpdateInternalMessage("Receive", result3, result4, cId);
						}
					}
					message = "";
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					list = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				list = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			list = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobHrmspInternalMessageLoadShortUserMessageByTypes_Result>>
		{
			Message = message,
			Data = list,
			Status = status
		};
	}
}
