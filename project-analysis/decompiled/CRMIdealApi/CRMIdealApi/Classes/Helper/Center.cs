using System;
using System.Collections.Generic;
using System.Linq;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes.Common;
using Elmah;

namespace CRMIdealApi.Classes.Helper;

public class Center
{
	public static ApispSelectDefaultCenter_Result GetTop1()
	{
		ApispSelectDefaultCenter_Result result = new ApispSelectDefaultCenter_Result();
		CRMEntities cRMEntities = null;
		try
		{
			ApispSelectDefaultCenter_Result apispSelectDefaultCenter_Result = Enumerable.FirstOrDefault<ApispSelectDefaultCenter_Result>((IEnumerable<ApispSelectDefaultCenter_Result>)cRMEntities.ApispSelectDefaultCenter(1065, 1065));
			if (apispSelectDefaultCenter_Result != null)
			{
				result = apispSelectDefaultCenter_Result;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static bool Exists(int? centerId = null)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCenterWithId_Result apispSelectCenterWithId_Result = Enumerable.FirstOrDefault<ApispSelectCenterWithId_Result>((IEnumerable<ApispSelectCenterWithId_Result>)cRMEntities.ApispSelectCenterWithId(centerId, 1065, 1065));
			if (apispSelectCenterWithId_Result != null)
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
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static bool Exists(string centerCode)
	{
		bool result = false;
		CRMEntities cRMEntities = null;
		try
		{
			cRMEntities = new CRMEntities();
			ApispSelectCenterWithCode_Result apispSelectCenterWithCode_Result = Enumerable.FirstOrDefault<ApispSelectCenterWithCode_Result>((IEnumerable<ApispSelectCenterWithCode_Result>)cRMEntities.ApispSelectCenterWithCode(centerCode, 1065, 1065));
			if (apispSelectCenterWithCode_Result != null)
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
			cRMEntities?.Dispose();
		}
		return result;
	}

	public static List<ApispSelectCentersWithIds_Result> GetWithIds(string cIds = "")
	{
		CRMEntities cRMEntities = null;
		List<ApispSelectCentersWithIds_Result> result = new List<ApispSelectCentersWithIds_Result>();
		try
		{
			cRMEntities = new CRMEntities();
			List<ApispSelectCentersWithIds_Result> list = Enumerable.ToList<ApispSelectCentersWithIds_Result>((IEnumerable<ApispSelectCentersWithIds_Result>)cRMEntities.ApispSelectCentersWithIds(cIds, ",", 1065, 1065));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMEntities?.Dispose();
		}
		return result;
	}
}
