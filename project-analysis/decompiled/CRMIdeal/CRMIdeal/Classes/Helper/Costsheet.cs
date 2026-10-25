using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class Costsheet
{
	public static bool IsFixed(int ctshId)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)cRMSpEntities.WSspSelectCostSheetsById(ctshId, lCID, result2));
			if (wSspSelectCostSheetsById_Result != null && wSspSelectCostSheetsById_Result.ctshIsVerified.HasValue && wSspSelectCostSheetsById_Result.ctshIsVerified.GetValueOrDefault())
			{
				result = true;
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}

	public static bool UpdatePreOrderByCostSheetId_Remove(int ctshId, bool IsCheckHadPord = true)
	{
		bool result = false;
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			if (ctshId > 0)
			{
				WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)cRMSpEntities.WSspSelectCostSheetsById(ctshId, lCID, result2));
				int num = 0;
				if (wSspSelectCostSheetsById_Result != null)
				{
					num = wSspSelectCostSheetsById_Result.PreOrderId.GetValueOrDefault();
				}
				if ((!IsCheckHadPord || num != 0) ? true : false)
				{
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)cRMSpEntities.WSspUpdatePreOrderByCostSheetId(ctshId, userId, id, value2, value, registerDatePersian, appType, result2, objectParameter));
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							Exception e = new Exception(Messages.msgErrorRunFunction + " (" + objectParameter.Value.ToString() + ")");
							ErrorSignal.FromCurrentContext().Raise(e);
						}
						else
						{
							result = true;
						}
					}
					else
					{
						result = true;
					}
				}
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}
}
