using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class PrintFormat
{
	public static int GetPrintFormatCId(int printFormatId = 0, string fileName = "", int currLangId = 0, int defLangId = 0)
	{
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		int result = 0;
		try
		{
			if (defLangId == 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out defLangId);
			}
			if (defLangId <= 0)
			{
				defLangId = 1065;
			}
			if (currLangId == 0)
			{
				currLangId = Thread.CurrentThread.CurrentCulture.LCID;
			}
			if (printFormatId != 0)
			{
				MObspSelectPrintFormatById_Result mObspSelectPrintFormatById_Result = Enumerable.FirstOrDefault<MObspSelectPrintFormatById_Result>((IEnumerable<MObspSelectPrintFormatById_Result>)cRMSpEntities.MObspSelectPrintFormatById(printFormatId, currLangId, defLangId));
				if (mObspSelectPrintFormatById_Result != null)
				{
					result = mObspSelectPrintFormatById_Result.CId.GetValueOrDefault();
				}
			}
			else if (!string.IsNullOrWhiteSpace(fileName))
			{
				if (!fileName.ToLower().EndsWith(".mrt"))
				{
					fileName += ".mrt";
				}
				MobspSelectPrintFormatByFileName_Result mobspSelectPrintFormatByFileName_Result = Enumerable.FirstOrDefault<MobspSelectPrintFormatByFileName_Result>((IEnumerable<MobspSelectPrintFormatByFileName_Result>)cRMSpEntities.MobspSelectPrintFormatByFileName(fileName, currLangId, defLangId));
				if (mobspSelectPrintFormatByFileName_Result != null)
				{
					result = mobspSelectPrintFormatByFileName_Result.CId.GetValueOrDefault();
				}
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
