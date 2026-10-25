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

public class CompanyAddressController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyAddressesLatLong_Result>> SelectCompanyAddressesLatLong(int companyId)
	{
		CRMEntities cRMEntities = null;
		string message = "";
		ServiceResultStatus status = ServiceResultStatus.Fail;
		List<MobspSelectCompanyAddressesLatLong_Result> data;
		try
		{
			if (base.Request.Headers.Contains("token"))
			{
				string token = Enumerable.FirstOrDefault<string>(base.Request.Headers.GetValues("token"));
				if (new Common().GetToken(token) != null)
				{
					cRMEntities = new CRMEntities();
					List<MobspSelectCompanyAddressesLatLong_Result> list = Enumerable.ToList<MobspSelectCompanyAddressesLatLong_Result>((IEnumerable<MobspSelectCompanyAddressesLatLong_Result>)cRMEntities.MobspSelectCompanyAddressesLatLong(companyId));
					if (list != null)
					{
						data = list;
						message = "";
						status = ServiceResultStatus.Success;
					}
					else
					{
						message = Messages.MobMsgErrorCompanyNotFound;
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
		return new ServiceResult<List<MobspSelectCompanyAddressesLatLong_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectCompanyAddresses_Result>> GetCompanyAddress(int companyId, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectCompanyAddresses_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectCompanyAddresses_Result>((IEnumerable<MobspSelectCompanyAddresses_Result>)cRMSpEntities.MobspSelectCompanyAddresses(companyId, result, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectCompanyAddresses_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> InsertCompanyAddress(InsertCompanyAddressViewModel model)
	{
		int result = 1065;
		if (model.LanguageId.HasValue)
		{
			int.TryParse(model.LanguageId.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int data = 0;
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
					_ = Financial.Get().Id;
					short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					int userId = token2.userId;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					ObjectParameter objectParameter = new ObjectParameter("ResErrorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("ResInsertedId", 0);
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertCompanyAddresses(model.CompanyAddressParams, userId, value3, value2, value, registerDatePersian, appType, num, result2, objectParameter, objectParameter2));
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
								case "ParseData=Empty":
									text = Messages.MobMsgErrorSentDataIsEmpty;
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
						int result3 = 0;
						int.TryParse(objectParameter2.Value.ToString() ?? "0", out result3);
						data = result3;
						message = Messages.MobMsgSuccessAction;
						status = ServiceResultStatus.Success;
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
