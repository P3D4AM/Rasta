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

public class SysTempDataController : ApiController
{
	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<int> InsertUpdate(CrmsysTempDataViewModel model)
	{
		int result = 1065;
		if (model.Ln.HasValue)
		{
			int.TryParse(model.Ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		int result3 = 0;
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
					cRMSpEntities = new CRMSpEntities();
					DateTime now = DateTime.Now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Mobile.Classes.Configuration.AppType;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					ObjectParameter objectParameter = new ObjectParameter("InsertTempDataId", typeof(int));
					int? num = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.MobspInsertUpdateSysTempData(model.TempDataId, (model.TempDataUserId == 0) ? token2.userId : model.TempDataUserId, model.TempDataSysPartIdI, model.TempDataSysPartObjIdI, model.TempDataSysPartIdII, model.TempDataSysPartObjIdII, model.TempDataValue, userId, value2, value, now, registerDatePersian, appType, result2, objectParameter));
					int result4 = 0;
					if (num.HasValue)
					{
						int.TryParse(num.ToString(), out result4);
					}
					if (result4 > 0 && objectParameter != null && objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result3);
						message = "";
						status = ServiceResultStatus.Success;
					}
				}
				else
				{
					message = Messages.MobMsgErrorAccessingToken;
					result3 = 0;
					status = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.MobMsgErrorAccessingToken;
				result3 = 0;
				status = ServiceResultStatus.Error;
			}
		}
		catch (Exception e)
		{
			message = Messages.MobMsgErrorDoneOperation;
			result3 = 0;
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
			Data = result3,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<bool> Delete(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		bool data = false;
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
					int num = cRMSpEntities.MobspDeleteSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII);
					int result3 = 0;
					int.TryParse(num.ToString(), out result3);
					if (result3 > 0)
					{
						data = true;
					}
					message = "";
					status = ServiceResultStatus.Success;
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
	public ServiceResult<MobspSelectSysTempData_Result> Select(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		MobspSelectSysTempData_Result data = null;
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
					data = Enumerable.FirstOrDefault<MobspSelectSysTempData_Result>((IEnumerable<MobspSelectSysTempData_Result>)cRMSpEntities.MobspSelectSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII, num, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<MobspSelectSysTempData_Result>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectSysTempData_Result>> SelectList(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectSysTempData_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectSysTempData_Result>((IEnumerable<MobspSelectSysTempData_Result>)cRMSpEntities.MobspSelectSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII, num, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectSysTempData_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}

	[HttpPost]
	[MobileAuthorize]
	public ServiceResult<List<MobspSelectSysTempDataByIds_Result>> SelectListByIds(string tempDataIds, int? ln = null)
	{
		int result = 1065;
		if (ln.HasValue)
		{
			int.TryParse(ln.ToString(), out result);
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectSysTempDataByIds_Result> data = null;
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
					data = Enumerable.ToList<MobspSelectSysTempDataByIds_Result>((IEnumerable<MobspSelectSysTempDataByIds_Result>)cRMSpEntities.MobspSelectSysTempDataByIds(tempDataIds, num, result2));
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
			cRMSpEntities?.Dispose();
		}
		return new ServiceResult<List<MobspSelectSysTempDataByIds_Result>>
		{
			Message = message,
			Data = data,
			Status = status
		};
	}
}
