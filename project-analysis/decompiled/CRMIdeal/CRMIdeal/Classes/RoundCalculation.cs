using System;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes;

public class RoundCalculation
{
	public static decimal RoundNumber(decimal num)
	{
		try
		{
			int result = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.PriceRoundType.ToString(), out result);
			}
			num = result switch
			{
				-1 => Math.Floor(num), 
				0 => Math.Round(num), 
				1 => Math.Ceiling(num), 
				_ => Math.Round(num), 
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return num;
	}
}
