using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using CRM.General.Utilities;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using Elmah;

namespace CRMIdeal.Classes.Helper;

public class OnlinePayment
{
	private const string SaleLoginAccountSessionKey = "SaleLoginAccount";

	public static CRMspSelectOnlinePayBankInfoByName_Result GetOnlinePayBankInfo(int onlinePayBankInfoId, string bankName)
	{
		CRMspSelectOnlinePayBankInfoByName_Result result = new CRMspSelectOnlinePayBankInfoByName_Result();
		CRMEntities cRMEntities = new CRMEntities();
		CRMSpIIEntities cRMSpIIEntities = new CRMSpIIEntities();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.FirstOrDefault<CRMspSelectOnlinePayBankInfoByName_Result>((IEnumerable<CRMspSelectOnlinePayBankInfoByName_Result>)cRMSpIIEntities.CRMspSelectOnlinePayBankInfoByName(onlinePayBankInfoId, bankName, lCID, result2));
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

	public static List<CommonMultiLanguageViewModel> CreatePayDescWhenToBank()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		try
		{
			List<Languages> list2 = Language.Get();
			if (list2 != null)
			{
				foreach (Languages item in Enumerable.ToList<Languages>((IEnumerable<Languages>)list2))
				{
					CommonMultiLanguageViewModel commonMultiLanguageViewModel = new CommonMultiLanguageViewModel();
					commonMultiLanguageViewModel.LanguageId = item.LanguageID;
					commonMultiLanguageViewModel.Value = MyResource.GetResourceString("FOOnlinePaymentDescGoToBanlGetway", item.LanguageCollation, "CRM.Resources.Labels", typeof(Labels).GetTypeInfo().Assembly);
					list.Add(commonMultiLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}
}
