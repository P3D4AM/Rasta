using System;
using System.Collections.Generic;
using System.Linq;
using CRMIdealApi.ApiModels;
using Elmah;

namespace CRMIdealApi.Classes;

public class RoundCalculation
{
	public static decimal RoundNumber(decimal num)
	{
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			int result = 0;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.PriceRoundType.ToString(), out result);
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
		finally
		{
			cRMEntities?.Dispose();
		}
		return num;
	}
}
