using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.Models;

namespace Mobile.Classes.Helper;

public class Center
{
	public static int TotalCnt => Get().Count;

	public static bool HaveModule => VersionBuyer.Center;

	public static List<MobspSelectCenters_Result> Get()
	{
		List<MobspSelectCenters_Result> result = new List<MobspSelectCenters_Result>();
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<MobspSelectCenters_Result> list = Enumerable.ToList<MobspSelectCenters_Result>((IEnumerable<MobspSelectCenters_Result>)cRMSpEntities.MobspSelectCenters(lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	[LoginAuthorize]
	public static List<MobspSelectCentersWithIds_Result> GetWithIds(string userCIds)
	{
		CRMSpEntities cRMSpEntities = null;
		List<MobspSelectCentersWithIds_Result> result = new List<MobspSelectCentersWithIds_Result>();
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<MobspSelectCentersWithIds_Result> list = Enumerable.ToList<MobspSelectCentersWithIds_Result>((IEnumerable<MobspSelectCentersWithIds_Result>)cRMSpEntities.MobspSelectCentersWithIds(userCIds, ",", lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		finally
		{
			cRMSpEntities?.Dispose();
		}
		return result;
	}

	public static string GetNames(string cIds = "")
	{
		return string.Join(", ", Enumerable.Select<MobspSelectCentersWithIds_Result, string>((IEnumerable<MobspSelectCentersWithIds_Result>)GetWithIds(cIds), (Func<MobspSelectCentersWithIds_Result, string>)((MobspSelectCentersWithIds_Result x) => x.CenterName)));
	}
}
