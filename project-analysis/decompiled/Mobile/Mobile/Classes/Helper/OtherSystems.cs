using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using CRM.Resources;
using Elmah;
using Mobile.Cache.Setting;
using Mobile.DataType;
using Mobile.Models;
using Newtonsoft.Json;

namespace Mobile.Classes.Helper;

public class OtherSystems
{
	public class ArpaSettingViewModel
	{
		public string ArpaServerAddress { get; set; }

		public string ArpaUserName { get; set; }

		public string ArpaPassword { get; set; }

		public string PrdLinkedField { get; set; }

		public int WrhsSyncTypeId { get; set; }
	}

	public class HamrahanSettingViewModel
	{
		public string HamrahanApiAddress { get; set; }

		public string HamrahanApiVersion { get; set; }

		public string HamrahanApiVersionDefineCmp { get; set; }

		public string HamrahanApiKey { get; set; }

		public string HamrahanCompanyId { get; set; }

		public string HamrahanCurrentFiscalYear { get; set; }

		public string HamrahanApiUserId { get; set; }

		public string HamrahanCurrencyUnit { get; set; }

		public string PrdLinkedField { get; set; }

		public string LegalStateFormal { get; set; }

		public string RealStateFormal { get; set; }

		public string LegalCompanyType { get; set; }

		public string RealIndexOwner { get; set; }

		public string RealIndexState { get; set; }

		public string RealIndexClass { get; set; }

		public string RealIndexKind { get; set; }

		public string RealIndexCredit { get; set; }

		public string LegalIndexOwner { get; set; }

		public string LegalIndexState { get; set; }

		public string LegalIndexClass { get; set; }

		public string LegalIndexKind { get; set; }

		public string LegalIndexCredit { get; set; }

		public int WrhsSyncTypeId { get; set; }
	}

	public static List<CRMspSelectLinkAccSettingDBIsActive_Result> GetLinkAccSettingDBList(int linkAccSystemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)cRMSpEntities.CRMspSelectLinkAccSettingDBIsActive(linkAccSystemId));
			if (list == null)
			{
				list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
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
		return list;
	}

	public static TimeSpan RestApiTimeout(int day = 0, int hour = 0, int min = 0, int sec = 0, int milisec = 0)
	{
		if (day <= 0 && hour <= 0 && min <= 0 && sec <= 0 && milisec <= 0)
		{
			milisec = 500;
		}
		return new TimeSpan(day, hour, min, sec, milisec);
	}

	public static ArpaSettingViewModel GetArpaSetting(int settingId = 0, string objectType = "", int? ln = null)
	{
		ArpaSettingViewModel arpaSettingViewModel = new ArpaSettingViewModel();
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(12, settingId, objectType, result, result2));
			if (list != null)
			{
				arpaSettingViewModel.ArpaServerAddress = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaServerAddress")).PartValue;
				arpaSettingViewModel.ArpaUserName = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaUserName")).PartValue;
				arpaSettingViewModel.ArpaPassword = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaPassword")).PartValue;
			}
			list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(12, settingId, "Product", result, result2));
			if (list != null && Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				arpaSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(12, settingId, "Warehouse", result, result2));
			if (list != null && Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				arpaSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
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
		return arpaSettingViewModel;
	}

	public static HamrahanSettingViewModel GetHamrahanSetting(int settingId = 0, string objectType = "", int? ln = null)
	{
		HamrahanSettingViewModel hamrahanSettingViewModel = new HamrahanSettingViewModel();
		CRMSpEntities cRMSpEntities = null;
		try
		{
			cRMSpEntities = new CRMSpEntities();
			int result = 1065;
			if (ln.HasValue)
			{
				int.TryParse(ln.ToString(), out result);
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(17, settingId, objectType, result, result2));
			if (list != null)
			{
				hamrahanSettingViewModel.HamrahanApiAddress = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersion = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiVersion")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersionDefineCmp = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiVersionDefineCmp")).PartValue;
				hamrahanSettingViewModel.HamrahanApiKey = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiKey")).PartValue;
				hamrahanSettingViewModel.HamrahanCompanyId = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CompanyId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrentFiscalYear = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrentFiscalYear")).PartValue;
				hamrahanSettingViewModel.HamrahanApiUserId = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUserId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrencyUnit = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrencyUnit")).PartValue;
			}
			list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(17, settingId, "Product", result, result2));
			if (list != null && Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				hamrahanSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(17, settingId, "Company", result, result2));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalStateFormal")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalStateFormal")).PartValue;
					hamrahanSettingViewModel.LegalStateFormal = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealStateFormal")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealStateFormal")).PartValue;
					hamrahanSettingViewModel.RealStateFormal = ((!string.IsNullOrWhiteSpace(partValue3)) ? partValue3 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalCompanyType")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalCompanyType")).PartValue;
					hamrahanSettingViewModel.LegalCompanyType = ((!string.IsNullOrWhiteSpace(partValue4)) ? partValue4 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexOwner")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexOwner")).PartValue;
					hamrahanSettingViewModel.RealIndexOwner = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexState")) != null)
				{
					string partValue6 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexState")).PartValue;
					hamrahanSettingViewModel.RealIndexState = ((!string.IsNullOrWhiteSpace(partValue6)) ? partValue6 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexClass")) != null)
				{
					string partValue7 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexClass")).PartValue;
					hamrahanSettingViewModel.RealIndexClass = ((!string.IsNullOrWhiteSpace(partValue7)) ? partValue7 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexKind")) != null)
				{
					string partValue8 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexKind")).PartValue;
					hamrahanSettingViewModel.RealIndexKind = ((!string.IsNullOrWhiteSpace(partValue8)) ? partValue8 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexCredit")) != null)
				{
					string partValue9 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexCredit")).PartValue;
					hamrahanSettingViewModel.RealIndexCredit = ((!string.IsNullOrWhiteSpace(partValue9)) ? partValue9 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexOwner")) != null)
				{
					string partValue10 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexOwner")).PartValue;
					hamrahanSettingViewModel.LegalIndexOwner = ((!string.IsNullOrWhiteSpace(partValue10)) ? partValue10 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexState")) != null)
				{
					string partValue11 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexState")).PartValue;
					hamrahanSettingViewModel.LegalIndexState = ((!string.IsNullOrWhiteSpace(partValue11)) ? partValue11 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexClass")) != null)
				{
					string partValue12 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexClass")).PartValue;
					hamrahanSettingViewModel.LegalIndexClass = ((!string.IsNullOrWhiteSpace(partValue12)) ? partValue12 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexKind")) != null)
				{
					string partValue13 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexKind")).PartValue;
					hamrahanSettingViewModel.LegalIndexKind = ((!string.IsNullOrWhiteSpace(partValue13)) ? partValue13 : "");
				}
				if (Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexCredit")) != null)
				{
					string partValue14 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexCredit")).PartValue;
					hamrahanSettingViewModel.LegalIndexCredit = ((!string.IsNullOrWhiteSpace(partValue14)) ? partValue14 : "");
				}
			}
			list = Enumerable.ToList<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)cRMSpEntities.FOMobspSelectLinkAccSettingByLinkAccSystemId(17, settingId, "Warehouse", result, result2));
			if (list != null && Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue15 = Enumerable.FirstOrDefault<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<FOMobspSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((FOMobspSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				hamrahanSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue15)) ? int.Parse(partValue15) : 0);
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
		return hamrahanSettingViewModel;
	}

	public static ServiceResult<string> GetPrdQuantity(HttpRequestHeaders header, string wcf, string prdIds, int cmpId, int whId, int ln, string linkAccWhId = "", string tracing = "", string sefareshCode = "")
	{
		string text = "";
		string message = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			HttpClient httpClient = new HttpClient();
			string text2 = $"{wcf}/api/ProductQuantityApi/GetLinkAccProductQuantityByIds?prdIds={prdIds}&cmpId={cmpId}&whId={whId}&ln={ln}&linkAccWhId={linkAccWhId}&tracing={tracing}&sefareshCode={sefareshCode}";
			httpClient.BaseAddress = new Uri(text2);
			foreach (KeyValuePair<string, IEnumerable<string>> item in header)
			{
				if (!item.Key.Equals("Host", StringComparison.OrdinalIgnoreCase) && !item.Key.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
				{
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, Enumerable.ToArray<string>(item.Value));
				}
			}
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.GetAsync(text2).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result2))
				{
					text = Enumerable.FirstOrDefault<MobLinkAccPrdQuantityViewModel>((IEnumerable<MobLinkAccPrdQuantityViewModel>)JsonConvert.DeserializeObject<ServiceResult<List<MobLinkAccPrdQuantityViewModel>>>(result2).Data).PrdQuantity.ToString();
					serviceResultStatus = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.msgErrorRunFunction;
					text = "";
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.msgErrorRunFunction;
				text = "";
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			message = ex.Message;
			text = "";
			serviceResultStatus = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = text,
			Status = serviceResultStatus
		};
	}

	public static ServiceResult<string> GetPrdQuantityById(HttpRequestHeaders header, string wcf, string prdId, int cmpId, int whId, int ln, string linkAccWhId = "", string tracing = "", string sefareshCode = "")
	{
		string text = "";
		string message = "";
		ServiceResultStatus serviceResultStatus = ServiceResultStatus.Fail;
		try
		{
			HttpClient httpClient = new HttpClient();
			string text2 = $"{wcf}/api/ProductQuantityApi/GetLinkAccProductQuantityById?prdId={prdId}&cmpId={cmpId}&whId={whId}&ln={ln}&linkAccWhId={linkAccWhId}&tracing={tracing}&sefareshCode={sefareshCode}";
			httpClient.BaseAddress = new Uri(text2);
			foreach (KeyValuePair<string, IEnumerable<string>> item in header)
			{
				if (!item.Key.Equals("Host", StringComparison.OrdinalIgnoreCase) && !item.Key.Equals("Content-Length", StringComparison.OrdinalIgnoreCase))
				{
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation(item.Key, Enumerable.ToArray<string>(item.Value));
				}
			}
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result = httpClient.GetAsync(text2).Result;
			if (result.IsSuccessStatusCode)
			{
				string result2 = result.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrEmpty(result2))
				{
					text = JsonConvert.DeserializeObject<ServiceResult<MobLinkAccPrdQuantityViewModel>>(result2).Data.PrdQuantity.ToString();
					serviceResultStatus = ServiceResultStatus.Success;
				}
				else
				{
					message = Messages.msgErrorRunFunction;
					text = "";
					serviceResultStatus = ServiceResultStatus.Error;
				}
			}
			else
			{
				message = Messages.msgErrorRunFunction;
				text = "";
				serviceResultStatus = ServiceResultStatus.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			message = ex.Message;
			text = "";
			serviceResultStatus = ServiceResultStatus.Error;
		}
		return new ServiceResult<string>
		{
			Message = message,
			Data = text,
			Status = serviceResultStatus
		};
	}
}
