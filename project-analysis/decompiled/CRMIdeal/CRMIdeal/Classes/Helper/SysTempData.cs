using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class SysTempData
{
	public static int InsertUpdate(CrmsysTempDataViewModel model)
	{
		int result = 0;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			ObjectParameter objectParameter = new ObjectParameter("InsertTempDataId", typeof(int));
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)cRMSpIIEntities.CRMspInsertUpdateSysTempData(model.TempDataId, model.TempDataUserId, model.TempDataSysPartIdI, model.TempDataSysPartObjIdI, model.TempDataSysPartIdII, model.TempDataSysPartObjIdII, model.TempDataValue, userId, value2, value, now, registerDatePersian, appType, result2, objectParameter));
			int result3 = 0;
			if (mct_II_Result != null)
			{
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
			}
			if (result3 > 0 && objectParameter != null && objectParameter.Value != null)
			{
				int.TryParse(objectParameter.Value.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static bool Delete(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII)
	{
		bool result = false;
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)cRMSpIIEntities.CRMspDeleteSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII));
			int result3 = 0;
			if (mct_II_Result != null)
			{
				int.TryParse(mct_II_Result.Result.ToString(), out result3);
			}
			if (result3 > 0)
			{
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static CRMspSelectSysTempData_Result Select(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII)
	{
		CRMspSelectSysTempData_Result result = new CRMspSelectSysTempData_Result();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<CRMspSelectSysTempData_Result>((IEnumerable<CRMspSelectSysTempData_Result>)cRMSpIIEntities.CRMspSelectSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static List<CRMspSelectSysTempData_Result> SelectList(int tempDataId, int? tempDataUserId, int? tempDataSysPartIdI, int? tempDataSysPartObjIdI, int? tempDataSysPartIdII, int? tempDataSysPartObjIdII)
	{
		List<CRMspSelectSysTempData_Result> result = new List<CRMspSelectSysTempData_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSysTempData_Result>((IEnumerable<CRMspSelectSysTempData_Result>)cRMSpIIEntities.CRMspSelectSysTempData(tempDataId, tempDataUserId, tempDataSysPartIdI, tempDataSysPartObjIdI, tempDataSysPartIdII, tempDataSysPartObjIdII, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}

	public static List<CRMspSelectSysTempDataByIds_Result> SelectListByIds(string tempDataIds)
	{
		List<CRMspSelectSysTempDataByIds_Result> result = new List<CRMspSelectSysTempDataByIds_Result>();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectSysTempDataByIds_Result>((IEnumerable<CRMspSelectSysTempDataByIds_Result>)cRMSpIIEntities.CRMspSelectSysTempDataByIds(tempDataIds, lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIIEntities?.Dispose();
		}
		return result;
	}
}
