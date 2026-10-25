using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web.Http;
using CRM.Resources;
using Elmah;
using GSD.Globalization;
using Mobile.Cache.Setting;
using Mobile.Classes;
using Mobile.Classes.Helper;
using Mobile.DataType;
using Mobile.Models;

namespace Mobile.Controllers;

public class LetterController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LetterDetailViewModel> SelectLetterWithId(int letId, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		LetterDetailViewModel letterDetailViewModel = null;
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
					MobspSelectLetterWithID_Result mobspSelectLetterWithID_Result = Enumerable.FirstOrDefault<MobspSelectLetterWithID_Result>((IEnumerable<MobspSelectLetterWithID_Result>)cRMEntities.MobspSelectLetterWithID(letId, result, result2));
					if (mobspSelectLetterWithID_Result != null)
					{
						if (mobspSelectLetterWithID_Result.LetterTypeId == 1)
						{
							if (!UserLogin.IsUserAccess("frmMain", "actltrSendLetters", UserLogin.CurrentUser, cId))
							{
								return new ServiceResult<LetterDetailViewModel>
								{
									Message = Messages.MobMsgErrorAccessLimited,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
						else
						{
							if (mobspSelectLetterWithID_Result.LetterTypeId != 2)
							{
								return new ServiceResult<LetterDetailViewModel>
								{
									Message = Messages.MobMsgErrorAccessLimited,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
							if (!UserLogin.IsUserAccess("frmMain", "actltrReceiveLetters", UserLogin.CurrentUser, cId))
							{
								return new ServiceResult<LetterDetailViewModel>
								{
									Message = Messages.MobMsgErrorAccessLimited,
									Data = null,
									Status = ServiceResultStatus.Fail
								};
							}
						}
						letterDetailViewModel = new LetterDetailViewModel();
						letterDetailViewModel.Letter = mobspSelectLetterWithID_Result;
						letterDetailViewModel.LetterFiles = new List<MobspSelectFilesDirectory_Result>();
						letterDetailViewModel.InternalMsg = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
						List<MobspSelectFilesDirectory_Result> list = Enumerable.ToList<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)cRMEntities.MobspSelectFilesDirectory("", "", "", "50", letId.ToString(), result, result2, false, cId));
						if (Enumerable.Any<MobspSelectFilesDirectory_Result>((IEnumerable<MobspSelectFilesDirectory_Result>)list))
						{
							letterDetailViewModel.LetterFiles = list;
						}
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list2 = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list2))
						{
							letterDetailViewModel.InternalMsg = list2;
						}
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorLetterNotFound;
						letterDetailViewModel = null;
						status = ServiceResultStatus.Error;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					letterDetailViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				letterDetailViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			letterDetailViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LetterDetailViewModel>
		{
			Message = message,
			Data = letterDetailViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> LetterVerify(int letId, int letTypeId, int? ln = null, int? cId = null)
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
					switch (letTypeId)
					{
					case 1:
						if (!UserLogin.IsUserAccess("frmSendLetters", "actVerifyLetter", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					case 2:
						if (!UserLogin.IsUserAccess("frmReceiveLetters", "actVerifyLetter", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					default:
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = letId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (letId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorLetterNotFound,
							Data = letId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					string appType = Mobile.Classes.Configuration.AppType;
					cRMEntities.MobspLetterVerify(letId, token2.userId, registerDatePersian, value, appType);
					data = letId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = letId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = letId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = letId;
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
	public ServiceResult<int> LetterVerifyExit(int letId, int letTypeId, int? ln = null, int? cId = null)
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
					switch (letTypeId)
					{
					case 1:
						if (!UserLogin.IsUserAccess("frmSendLetters", "actExitFromIsVerify", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					case 2:
						if (!UserLogin.IsUserAccess("frmReceiveLetters", "actExitFromIsVerify", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					default:
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = letId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (letId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorLetterNotFound,
							Data = letId,
							Status = ServiceResultStatus.Error
						};
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					cRMEntities.MobspLetterVerifyExit(letId, token2.userId, registerDatePersian, value);
					data = letId;
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = letId;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = letId;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = letId;
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
	public ServiceResult<int> ReturnLetterTypeIdFromLetterId(int letId, int? ln = null)
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
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMEntities.MobspReturnLetterTypeIdFromLetterId(letId));
					data = (num.HasValue ? num.Value : 0);
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
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
	public ServiceResult<List<MobspSelectCompanyLetters_Result>> SelectCompanyLetters(int cmpId, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		List<MobspSelectCompanyLetters_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCompanyLetters_Result>((IEnumerable<MobspSelectCompanyLetters_Result>)cRMEntities.MobspSelectCompanyLetters(cmpId, 0, pageNumber, pageSize, result, result2, cId, token2.userId));
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
		return new ServiceResult<List<MobspSelectCompanyLetters_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<long> GetLetterNumber(int typeId, int letterNumberCounterId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		long data = 0L;
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
					data = Enumerable.FirstOrDefault<long>(cRMEntities.Database.SqlQuery<long>($"Select dbo.SecfnReturnLetterNumber({Financial.Get().Id}, {typeId},{letterNumberCounterId},{cId})", Array.Empty<object>()));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0L;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0L;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0L;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<long>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<long> GetLetterNumberII(int typeId, int letterNumberCounterId = 0, int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		long data = 0L;
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
					data = Enumerable.FirstOrDefault<long>(cRMEntities.Database.SqlQuery<long>($"Select dbo.SecfnReturnLetterNumberII({Financial.Get().Id}, {typeId},{letterNumberCounterId},{cId})", Array.Empty<object>()));
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					data = 0L;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				data = 0L;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			data = 0L;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return new ServiceResult<long>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<InsertLetterResultViewModel> InsertLetter(InsertLetterViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		InsertLetterResultViewModel insertLetterResultViewModel = new InsertLetterResultViewModel();
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
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("ResErrorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("ResInsertedLetterId", 0);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertLetter(model.LetterParams, userId, year1: value3, month1: value2, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: num, defaultLanguageID: result2, resErrorMessage: objectParameter, resInsertedLetterId: objectParameter2));
					if (!string.IsNullOrEmpty(objectParameter.Value?.ToString()))
					{
						string text = "";
						string[] array = objectParameter.Value.ToString().Split(new string[1] { "#|^|#" }, StringSplitOptions.None);
						string[] array2 = array;
						foreach (string text2 in array2)
						{
							if (!string.IsNullOrEmpty(text2))
							{
								switch (text2.Split(new string[1] { "|^|" }, StringSplitOptions.None)[0])
								{
								case "ParseData=Error":
									text = Messages.MobMsgErrorInSentData;
									break;
								case "LetterNumber=Dup":
									text = Messages.MobMsgLetterNumberIsRepeated;
									break;
								case "Error":
									text = Messages.MobMsgErrorSubmitLetter;
									break;
								}
							}
						}
						if (string.IsNullOrEmpty(text))
						{
							text = array[0];
						}
						message = text;
						status = ServiceResultStatus.Fail;
					}
					else
					{
						insertLetterResultViewModel.InsertLetterId = objectParameter2.Value.ToString() ?? "0";
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					insertLetterResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				insertLetterResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			insertLetterResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<InsertLetterResultViewModel>
		{
			Message = message,
			Data = insertLetterResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> GetMobLetterCnt(int? ln = null, int? cId = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
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
					cRMSpEntities = new CRMSpEntities();
					data = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspReturnMobLetterCnt(cId)).GetValueOrDefault();
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
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
	public ServiceResult<SendLetterListAndIntMsgViewModel> GetSendLetterList(GetSendLetterListViewMdoel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		SendLetterListAndIntMsgViewModel sendLetterListAndIntMsgViewModel = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<SendLetterListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					sendLetterListAndIntMsgViewModel = new SendLetterListAndIntMsgViewModel();
					sendLetterListAndIntMsgViewModel.Letters = new List<MobspLetterIndicator_Result>();
					sendLetterListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					DateTime now = DateTime.Now;
					string rptDate = now.ToString("yyyy/MM/dd", new PersianCulture());
					string rptDay = DateTimeClass.DefineDayeOfWeekPersian(now.DayOfWeek.ToString());
					if (!string.IsNullOrEmpty(model.LetterSubject))
					{
						switch (model.LetterSubject)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterSubject = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterSubject = "-1";
							break;
						}
					}
					if (!string.IsNullOrEmpty(model.LetterContext))
					{
						switch (model.LetterContext)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterContext = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterContext = "-1";
							break;
						}
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					sendLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)cRMSpEntities.MobspLetterIndicator("1", model.LetterPreNumber, model.LetterNumber, null, null, null, model.LetterCompanyNameId, model.LetterSubject, model.LetterSubjectLikely, null, null, model.LetterContext, model.LetterContextLikely, null, null, null, null, null, null, token2.userId.ToString(), rptDate, rptDay, model.LetterFDateTime, model.LetterTDateTime, null, null, null, null, null, model.PageNumber, model.PageSize, num, result2, model.CenterId));
					if (!VersionBuyer.Letters)
					{
						sendLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>(Enumerable.Take<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)sendLetterListAndIntMsgViewModel.Letters, 2));
					}
					foreach (MobspLetterIndicator_Result letter in sendLetterListAndIntMsgViewModel.Letters)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letter.LetterId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							sendLetterListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					sendLetterListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				sendLetterListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			sendLetterListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<SendLetterListAndIntMsgViewModel>
		{
			Message = message,
			Data = sendLetterListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<ReceiveLetterListAndIntMsgViewModel> GetReceiveLetterList(GetReceiveLetterListViewMdoel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		ReceiveLetterListAndIntMsgViewModel receiveLetterListAndIntMsgViewModel = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<ReceiveLetterListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					receiveLetterListAndIntMsgViewModel = new ReceiveLetterListAndIntMsgViewModel();
					receiveLetterListAndIntMsgViewModel.Letters = new List<MobspLetterIndicator_Result>();
					receiveLetterListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					DateTime now = DateTime.Now;
					string rptDate = now.ToString("yyyy/MM/dd", new PersianCulture());
					string rptDay = DateTimeClass.DefineDayeOfWeekPersian(now.DayOfWeek.ToString());
					if (!string.IsNullOrEmpty(model.LetterSubject))
					{
						switch (model.LetterSubject)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterSubject = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterSubject = "-1";
							break;
						}
					}
					if (!string.IsNullOrEmpty(model.LetterContext))
					{
						switch (model.LetterContext)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterContext = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterContext = "-1";
							break;
						}
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					receiveLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)cRMSpEntities.MobspLetterIndicator("2", null, null, model.LetterNumberII, null, null, model.LetterCompanyNameId, model.LetterSubject, model.LetterSubjectLikely, null, null, model.LetterContext, model.LetterContextLikely, null, null, null, null, null, null, token2.userId.ToString(), rptDate, rptDay, model.LetterFDateTime, model.LetterTDateTime, null, null, null, null, null, model.PageNumber, model.PageSize, num, result2, model.CenterId));
					if (!VersionBuyer.Letters)
					{
						receiveLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>(Enumerable.Take<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)receiveLetterListAndIntMsgViewModel.Letters, 2));
					}
					foreach (MobspLetterIndicator_Result letter in receiveLetterListAndIntMsgViewModel.Letters)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letter.LetterId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							receiveLetterListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					receiveLetterListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				receiveLetterListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			receiveLetterListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<ReceiveLetterListAndIntMsgViewModel>
		{
			Message = message,
			Data = receiveLetterListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanySendLetterListAndIntMsgViewModel> GetCompanySendLetterList(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		CompanySendLetterListAndIntMsgViewModel companySendLetterListAndIntMsgViewModel = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<CompanySendLetterListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					companySendLetterListAndIntMsgViewModel = new CompanySendLetterListAndIntMsgViewModel();
					companySendLetterListAndIntMsgViewModel.Letters = new List<MobspSelectCompanyLetters_Result>();
					companySendLetterListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					_ = Labels.ManualIssuing;
					_ = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					companySendLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspSelectCompanyLetters_Result>((IEnumerable<MobspSelectCompanyLetters_Result>)cRMEntities.MobspSelectCompanyLetters(companyId, 1, pageNumber, pageSize, result, result2, cId, token2.userId));
					if (!VersionBuyer.Letters)
					{
						companySendLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspSelectCompanyLetters_Result>(Enumerable.Take<MobspSelectCompanyLetters_Result>((IEnumerable<MobspSelectCompanyLetters_Result>)companySendLetterListAndIntMsgViewModel.Letters, 2));
					}
					foreach (MobspSelectCompanyLetters_Result letter in companySendLetterListAndIntMsgViewModel.Letters)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letter.LetterId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							companySendLetterListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					companySendLetterListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				companySendLetterListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			companySendLetterListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CompanySendLetterListAndIntMsgViewModel>
		{
			Message = message,
			Data = companySendLetterListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<CompanyReceiveLetterListAndIntMsgViewModel> GetCompanyReceiveLetterList(int companyId, int? pageNumber = 1, int? pageSize = 10, int? cId = null, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		CompanyReceiveLetterListAndIntMsgViewModel companyReceiveLetterListAndIntMsgViewModel = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<CompanyReceiveLetterListAndIntMsgViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					companyReceiveLetterListAndIntMsgViewModel = new CompanyReceiveLetterListAndIntMsgViewModel();
					companyReceiveLetterListAndIntMsgViewModel.Letters = new List<MobspSelectCompanyLetters_Result>();
					companyReceiveLetterListAndIntMsgViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					_ = Labels.ManualIssuing;
					_ = Labels.SystemIssuing;
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					companyReceiveLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspSelectCompanyLetters_Result>((IEnumerable<MobspSelectCompanyLetters_Result>)cRMEntities.MobspSelectCompanyLetters(companyId, 2, pageNumber, pageSize, result, result2, cId, token2.userId));
					if (!VersionBuyer.Letters)
					{
						companyReceiveLetterListAndIntMsgViewModel.Letters = Enumerable.ToList<MobspSelectCompanyLetters_Result>(Enumerable.Take<MobspSelectCompanyLetters_Result>((IEnumerable<MobspSelectCompanyLetters_Result>)companyReceiveLetterListAndIntMsgViewModel.Letters, 2));
					}
					foreach (MobspSelectCompanyLetters_Result letter in companyReceiveLetterListAndIntMsgViewModel.Letters)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letter.LetterId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							companyReceiveLetterListAndIntMsgViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					companyReceiveLetterListAndIntMsgViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				companyReceiveLetterListAndIntMsgViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			companyReceiveLetterListAndIntMsgViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<CompanyReceiveLetterListAndIntMsgViewModel>
		{
			Message = message,
			Data = companyReceiveLetterListAndIntMsgViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<LetterIndicatorResultViewModel> LetterIndicator(LetterIndicatorViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMEntities cRMEntities = null;
		CRMSpEntities cRMSpEntities = null;
		LetterIndicatorResultViewModel letterIndicatorResultViewModel = null;
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
					if (base.Request.Headers.TryGetValues("imeiCode", out var _) && !Common.CheckUserImeiCode(token2.userId, Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("imeiCode")), Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("appName"))))
					{
						return new ServiceResult<LetterIndicatorResultViewModel>
						{
							Message = Messages.MobMsgUserImeiNotPreDefined,
							Data = null,
							Status = ServiceResultStatus.Fail
						};
					}
					letterIndicatorResultViewModel = new LetterIndicatorResultViewModel();
					letterIndicatorResultViewModel.Letters = new List<MobspLetterIndicator_Result>();
					letterIndicatorResultViewModel.InternalMessages = new List<MobspIntMsgGetByTypeAndAttachRecId_Result>();
					DateTime now = DateTime.Now;
					string rptDate = now.ToString("yyyy/MM/dd", new PersianCulture());
					string rptDay = DateTimeClass.DefineDayeOfWeekPersian(now.DayOfWeek.ToString());
					if (!string.IsNullOrEmpty(model.LetterSubject))
					{
						switch (model.LetterSubject)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterSubject = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterSubject = "-1";
							break;
						}
					}
					if (!string.IsNullOrEmpty(model.LetterContext))
					{
						switch (model.LetterContext)
						{
						case "#Have":
						case "#دارد":
						case "#يملك":
							model.LetterContext = "-2";
							break;
						case "#HaveNot":
						case "#ندارد":
						case "#لا يملك":
							model.LetterContext = "-1";
							break;
						}
					}
					cRMEntities = new CRMEntities();
					cRMSpEntities = new CRMSpEntities();
					letterIndicatorResultViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)cRMSpEntities.MobspLetterIndicator(model.LetterTypeId, model.LetterPreNumber, model.LetterNumber, null, null, null, model.LetterCompanyNameId, model.LetterSubject, model.LetterSubjectLikely, null, null, model.LetterContext, model.LetterContextLikely, null, null, null, null, null, null, token2.userId.ToString(), rptDate, rptDay, model.LetterFDateTime, model.LetterTDateTime, null, null, null, null, null, model.PageNumber, model.PageSize, num, result2, model.CenterId));
					if (!VersionBuyer.Letters)
					{
						letterIndicatorResultViewModel.Letters = Enumerable.ToList<MobspLetterIndicator_Result>(Enumerable.Take<MobspLetterIndicator_Result>((IEnumerable<MobspLetterIndicator_Result>)letterIndicatorResultViewModel.Letters, 2));
					}
					foreach (MobspLetterIndicator_Result letter in letterIndicatorResultViewModel.Letters)
					{
						List<MobspIntMsgGetByTypeAndAttachRecId_Result> list = Enumerable.ToList<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)cRMEntities.MobspIntMsgGetByTypeAndAttachRecId(token2.userId, 14, letter.LetterId, result, result2));
						if (Enumerable.Any<MobspIntMsgGetByTypeAndAttachRecId_Result>((IEnumerable<MobspIntMsgGetByTypeAndAttachRecId_Result>)list))
						{
							letterIndicatorResultViewModel.InternalMessages.AddRange(list);
						}
					}
					message = Messages.MobMsgSuccessAction;
					status = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					letterIndicatorResultViewModel = null;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				letterIndicatorResultViewModel = null;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			letterIndicatorResultViewModel = null;
			status = ServiceResultStatus.Error;
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
			cRMEntities?.Dispose();
		}
		return new ServiceResult<LetterIndicatorResultViewModel>
		{
			Message = message,
			Data = letterIndicatorResultViewModel,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> FixLetter(int letId, int letTypeId, int? cId)
	{
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMSpEntities = new CRMSpEntities();
					switch (letTypeId)
					{
					case 1:
						if (!UserLogin.IsUserAccess("frmSendLetters", "actIsFixed", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					case 2:
						if (!UserLogin.IsUserAccess("frmReceiveLetters", "actIsFixed", UserLogin.CurrentUser, cId))
						{
							return new ServiceResult<int>
							{
								Message = Messages.MobMsgErrorAccessLimited,
								Data = letId,
								Status = ServiceResultStatus.Fail
							};
						}
						break;
					default:
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorAccessLimited,
							Data = letId,
							Status = ServiceResultStatus.Fail
						};
					}
					if (letId <= 0)
					{
						return new ServiceResult<int>
						{
							Message = Messages.MobMsgErrorOrderNotFound,
							Data = letId,
							Status = ServiceResultStatus.Error
						};
					}
					data = cRMSpEntities.MobspLetterIsFixed(letId);
					message = "";
					status = ServiceResultStatus.Success;
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<int>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
