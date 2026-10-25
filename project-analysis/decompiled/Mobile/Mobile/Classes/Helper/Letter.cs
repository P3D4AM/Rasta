using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Letter
{
	public static bool IsVerifed(int letterId)
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if ((Enumerable.FirstOrDefault<MobspSelectLetterWithID_Result>((IEnumerable<MobspSelectLetterWithID_Result>)cRMEntities.MobspSelectLetterWithID(letterId, lCID, result3))?.LetterIsVerified).GetValueOrDefault())
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
			cRMEntities.Dispose();
		}
		return result;
	}
}
