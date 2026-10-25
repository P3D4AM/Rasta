using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class PayRoll
{
	public static bool IsVerify(int cycleId)
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
			PayRollspSelectUserCycle_Result payRollspSelectUserCycle_Result = Enumerable.FirstOrDefault<PayRollspSelectUserCycle_Result>((IEnumerable<PayRollspSelectUserCycle_Result>)cRMSpEntities.PayRollspSelectUserCycle(0, cycleId, 0, null, null, lCID, result2));
			if (payRollspSelectUserCycle_Result != null)
			{
				result = payRollspSelectUserCycle_Result.CycleIsVerified.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities.Dispose();
		}
		return result;
	}
}
