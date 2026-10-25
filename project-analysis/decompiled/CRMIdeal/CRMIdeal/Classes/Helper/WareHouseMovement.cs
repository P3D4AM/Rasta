using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class WareHouseMovement
{
	public static bool IsSentToLinkAcc(int docId)
	{
		bool result = false;
		CRMSpIEntities cRMSpIEntities = new CRMSpIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectDocById_Result wSspSelectDocById_Result = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)cRMSpIEntities.WSspSelectDocById(docId, lCID, result2));
			if (wSspSelectDocById_Result != null)
			{
				bool.TryParse(wSspSelectDocById_Result.IsSentToLinkAcc.ToString(), out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpIEntities?.Dispose();
		}
		return result;
	}

	public static bool IsSentToLinkAccByAction(int docId)
	{
		bool result = false;
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmWareHouseMovement", "actChangeAfterSendToLinkAcc", currentUser))
			{
				result = IsSentToLinkAcc(docId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}
}
