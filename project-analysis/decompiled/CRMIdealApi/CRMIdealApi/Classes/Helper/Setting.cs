using System;
using System.Collections.Generic;
using System.Linq;
using CRMIdealApi.ApiModels;

namespace CRMIdealApi.Classes.Helper;

public class Setting
{
	public static ApispSelectCrmsysSetting_Result GetSysSetting()
	{
		ApispSelectCrmsysSetting_Result result = new ApispSelectCrmsysSetting_Result();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result != null)
			{
				result = apispSelectCrmsysSetting_Result;
			}
		}
		catch (Exception)
		{
		}
		return result;
	}

	public static int GetMobNumLen()
	{
		int result = 0;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result != null)
			{
				result = apispSelectCrmsysSetting_Result.MobNumLen.GetValueOrDefault(1);
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}

	public static bool GetMobNumLenNoCheck()
	{
		bool result = false;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result != null)
			{
				result = apispSelectCrmsysSetting_Result.MobNumLenNoCheck.HasValue && apispSelectCrmsysSetting_Result.MobNumLenNoCheck != false;
			}
			cRMEntities.Dispose();
		}
		catch (Exception)
		{
			cRMEntities.Dispose();
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return result;
	}
}
