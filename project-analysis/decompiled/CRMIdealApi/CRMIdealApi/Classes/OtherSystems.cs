using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using CRMIdealApi.ApiModels;
using CRMIdealApi.Classes.Common;
using CRMIdealApi.Classes.Helper;
using CRMIdealApi.Controllers;
using CRMIdealApi.Resources;
using Elmah;
using GSD.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CRMIdealApi.Classes;

public class OtherSystems
{
	public class ArpaSettingViewModel
	{
		public string ArpaServerAddress { get; set; }

		public string ArpaUserName { get; set; }

		public string ArpaPassword { get; set; }

		public string DefUserGroupId { get; set; }

		public string PrdLinkedField { get; set; }

		public int WrhsSyncTypeId { get; set; }
	}

	public class ShygunSettingViewModel
	{
		public bool AllowRowSecurity { get; set; }

		public string AuthUser { get; set; }

		public string AuthPassword { get; set; }

		public string DataBaseName { get; set; }

		public string DBUserName { get; set; }

		public string DBPassword { get; set; }

		public int Language { get; set; }

		public int Level { get; set; }

		public string Server { get; set; }

		public int From { get; set; }

		public int To { get; set; }

		public string IP { get; set; }

		public ShygunConfig conf { get; set; }

		public string CmpMoeinAccCode { get; set; }

		public string PrdPriceGroup { get; set; }

		public string OrdTax { get; set; }

		public string OrdTaxFieldTitle { get; set; }

		public string OrdRound { get; set; }

		public string OrdRoundFieldTitle { get; set; }

		public string OrdTransportation { get; set; }

		public string OrdTransportationFieldTitle { get; set; }

		public string OrdCurrencyUnit { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public string DefPrjTitle { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int PrdGroupSyncTypeId { get; set; }

		public string PrdLinkedField { get; set; }

		public string DocMovementAccountNumber { get; set; }

		public string DocMovementAccountNumber_PartLabelTitle { get; set; }

		public string DocMovementAccountGUId { get; set; }

		public int DocMovementAccountGUId_Id { get; set; }
	}

	public class ShygunApiParamViewModel<T>
	{
		public string StartVersion { get; set; }

		public string EndVersion { get; set; }

		public ShygunConfig Config { get; set; }

		public T Domain { get; set; }
	}

	public class ShygunApiGetItemGetRemainResultViewModel
	{
		public List<ShygunItemGetRemainViewModel> Result { get; set; }
	}

	public class ShygunItemGetRemainViewModel
	{
		public decimal? RemainCost { get; set; }

		public decimal? RemainUnit1Price { get; set; }

		public decimal? RemainUnit2Price { get; set; }

		public string StoreNumber { get; set; }

		public string StoreName { get; set; }

		public string ItemCode { get; set; }

		public string ItemDescription { get; set; }

		public string Unit1Name { get; set; }

		public double? Quantity1 { get; set; }

		public double? Quantity2 { get; set; }

		public string ItemGuId { get; set; }

		public string StockGuId { get; set; }
	}

	public class ShygunConfig
	{
		public string Server;

		public bool AllowRowSecurity;

		public int Level;

		public string DBUserName;

		public string DBPassword;

		public string DataBaseName;

		public string AuthUser;

		public string AuthPassword;

		public int Language;

		public string TokenString;

		public Guid DeviceID;

		public string ApplicationName;

		public string RequestGuId;
	}

	public class ShygunDomainFilter
	{
		public string From;

		public string To;

		public IList<string> In;

		public string DataSetName;

		public string DomainName;

		public ShygunDomainFilter()
		{
		}

		public ShygunDomainFilter(string DataSetName, string DomainName)
		{
			this.DataSetName = DataSetName;
			this.DomainName = DomainName;
			In = new List<string>();
		}
	}

	public class ShygunDomainItemRemain
	{
		private ShygunDomainFilter FSort;

		private ShygunDomainFilter FSTNumber;

		private ShygunDomainFilter FDate;

		private ShygunDomainFilter FItemCode;

		private ShygunDomainFilter FItemGuId;

		private ShygunDomainFilter FStockGuId;

		private ShygunDomainFilter FShowItemsZeroRemain;

		private ShygunDomainFilter FItemMainGroupCode;

		private ShygunDomainFilter FItemGroupCode;

		public ShygunDomainFilter Sort
		{
			get
			{
				if (FSort == null)
				{
					FSort = new ShygunDomainFilter("KernelRQ", "DSort");
				}
				return FSort;
			}
			set
			{
				FSort = value;
				FSort.DataSetName = "KernelRQ";
				FSort.DomainName = "DSort";
			}
		}

		public ShygunDomainFilter Date
		{
			get
			{
				if (FDate == null)
				{
					FDate = new ShygunDomainFilter("KernelRQ", "DDate");
				}
				return FDate;
			}
			set
			{
				FDate = value;
				FDate.DataSetName = "KernelRQ";
				FDate.DomainName = "DDate";
			}
		}

		public ShygunDomainFilter ItemCode
		{
			get
			{
				if (FItemCode == null)
				{
					FItemCode = new ShygunDomainFilter("ItemRQ", "DItemCode");
				}
				return FItemCode;
			}
			set
			{
				FItemCode = value;
				FItemCode.DataSetName = "ItemRQ";
				FItemCode.DomainName = "DItemCode";
			}
		}

		public ShygunDomainFilter ItemGuID
		{
			get
			{
				if (FItemGuId == null)
				{
					FItemGuId = new ShygunDomainFilter("ItemRQ", "DItemGuID");
				}
				return FItemGuId;
			}
			set
			{
				FItemGuId = value;
				FItemGuId.DataSetName = "ItemRQ";
				FItemGuId.DomainName = "DItemGuID";
			}
		}

		public ShygunDomainFilter StockGuID
		{
			get
			{
				if (FStockGuId == null)
				{
					FStockGuId = new ShygunDomainFilter("StoreRQ", "DGuID");
				}
				return FStockGuId;
			}
			set
			{
				FStockGuId = value;
				FStockGuId.DataSetName = "StoreRQ";
				FStockGuId.DomainName = "DGuID";
			}
		}

		public ShygunDomainFilter STNumber
		{
			get
			{
				if (FSTNumber == null)
				{
					FSTNumber = new ShygunDomainFilter("StoreRQ", "DSTNumber");
				}
				return FSTNumber;
			}
			set
			{
				FSTNumber = value;
				FSTNumber.DataSetName = "StoreRQ";
				FSTNumber.DomainName = "DSTNumber";
			}
		}

		public ShygunDomainFilter ShowItemsZeroRemain
		{
			get
			{
				if (FShowItemsZeroRemain == null)
				{
					FShowItemsZeroRemain = new ShygunDomainFilter("KernelRQ", "DShowItemsZeroRemain");
				}
				return FShowItemsZeroRemain;
			}
			set
			{
				FShowItemsZeroRemain = value;
				FShowItemsZeroRemain.DataSetName = "KernelRQ";
				FShowItemsZeroRemain.DomainName = "DShowItemsZeroRemain";
			}
		}

		public ShygunDomainFilter ItemMainGroupCode
		{
			get
			{
				if (FItemMainGroupCode == null)
				{
					FItemMainGroupCode = new ShygunDomainFilter("ACQ3308N3", "DItemMainGCode");
				}
				return FItemMainGroupCode;
			}
			set
			{
				FItemMainGroupCode = value;
				FItemMainGroupCode.DataSetName = "ACQ3308N3";
				FItemMainGroupCode.DomainName = "DItemMainGCode";
			}
		}

		public ShygunDomainFilter ItemGroupCode
		{
			get
			{
				if (FItemGroupCode == null)
				{
					FItemGroupCode = new ShygunDomainFilter("ACQ3308N4", "DItemGroupCode");
				}
				return FItemGroupCode;
			}
			set
			{
				FItemGroupCode = value;
				FItemGroupCode.DataSetName = "ACQ3308N4";
				FItemGroupCode.DomainName = "DItemGroupCode";
			}
		}
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

	public class NilramSettingViewModel
	{
		public string ApiAddress { get; set; }

		public string ApiToken { get; set; }

		public int DefCurrencyUnitId { get; set; }

		public string DefPrjTitle { get; set; }

		public int DefPrjCvnsStatusGroupId { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public int WrhsSyncTypeLinkAccSettingId { get; set; }

		public string PrdLinkedField { get; set; }
	}

	public class NoAvaranCapillarySettingViewModel
	{
		public string ApiUserId { get; set; }

		public int WrhsSyncTypeId { get; set; }

		public string PrdLinkedField { get; set; }
	}

	public class RahkaranRetailSettingViewModel
	{
		public string ApiAddress { get; set; }

		public string ApiUsername { get; set; }

		public string ApiPassword { get; set; }

		public string ApiMachineName { get; set; }

		public string ApiCookieName { get; set; }

		public string ApiCookie { get; set; }

		public int ApiCookieLinkAccSettingId { get; set; }

		public int CurrencyRef { get; set; }
	}

	public class HamyarProvider
	{
		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Key = "ApiKey";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_LegalMoadiType = "LegalMoadiType";

		public const string _KeyName_RealMoadiType = "RealMoadiType";

		private static string _ApiAddress = "";

		private static string _ApiKey = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> _CrmSetting = null;

		private static string _Access_Token = "";

		private static string _Refresh_Token = "";

		private List<LkCrmCompanyGroupsIIIViewModel> _Vaheds;

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)GetCrmSetting(false), (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				return _ApiAddress;
			}
		}

		public string ApiKey
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiKey))
				{
					_ApiKey = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)GetCrmSetting(false), (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiKey")).PartValue ?? "";
				}
				return _ApiKey;
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)GetCrmSetting(false), (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)GetCrmSetting(false), (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
		}

		public HamyarProvider(bool? getVahed = false)
		{
			GetCrmSetting(false);
			GetToken();
			GetVahed(getVahed.GetValueOrDefault());
		}

		public List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> GetCrmSetting(bool? readAgain = false, int? currLangId = null, int? defLangId = null)
		{
			if (!readAgain.GetValueOrDefault() && _CrmSetting != null)
			{
				return _CrmSetting;
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				int value = 21;
				int value2 = -1;
				List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list2 = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
				int? linkAccSettingId = 0;
				int? languageID = currLangId;
				int? defaultLanguageID = defLangId;
				list2 = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, linkAccSettingId, "Company", languageID, defaultLanguageID, value2));
				if (list2 != null)
				{
					list.AddRange(list2);
				}
				defaultLanguageID = 0;
				languageID = currLangId;
				linkAccSettingId = defLangId;
				list2 = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, defaultLanguageID, "Setting", languageID, linkAccSettingId, value2));
				if (list2 != null)
				{
					list.AddRange(list2);
				}
				if (list.Count > 0)
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
					if (!text.EndsWith("/"))
					{
						Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue += "/";
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			cRMEntities.Dispose();
			return list;
		}

		public static ApispSelectLinkAccSettingDetails_Result GetCrmSettingDetails(int settingDetailId = 0, int objId = 0, string objectType = "", string partTitle = "", int? currLangId = 1065, int? defLangId = 1065)
		{
			ApispSelectLinkAccSettingDetails_Result result = new ApispSelectLinkAccSettingDetails_Result();
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				int value = 21;
				int value2 = -1;
				if (settingDetailId < 0)
				{
					settingDetailId = 0;
				}
				List<ApispSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingDetails_Result>((IEnumerable<ApispSelectLinkAccSettingDetails_Result>)cRMEntities.ApispSelectLinkAccSettingDetails(settingDetailId, objId, objectType, currLangId, defLangId, value, value2));
				if (list != null)
				{
					result = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingDetails_Result>((IEnumerable<ApispSelectLinkAccSettingDetails_Result>)list, (Func<ApispSelectLinkAccSettingDetails_Result, bool>)((ApispSelectLinkAccSettingDetails_Result x) => x.PartTitle == partTitle));
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

		public string GetToken(bool getNew = false)
		{
			string text = "";
			try
			{
				string apiAddress = ApiAddress;
				HamyarTokenViewModel value = new HamyarTokenViewModel
				{
					username = ApiUsername,
					password = ApiPassword
				};
				apiAddress += "api/Auth/login";
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)GetCrmSetting(false), (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "APIActiveTls12")).PartValue.ToLower().Trim() == "true")
				{
					ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
				}
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(apiAddress);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(value);
				HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(apiAddress, content2).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string value2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(value2))
					{
						value2 = value2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value2))
					{
						HamyarAPIResponseViewModel<HamyarTokenResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarTokenResponseViewModel>>(value2);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							_Access_Token = hamyarAPIResponseViewModel.data.accessToken ?? "";
							_Refresh_Token = hamyarAPIResponseViewModel.data.refreshToken ?? "";
							if (!string.IsNullOrWhiteSpace(_Access_Token))
							{
								_Access_Token = "Bearer " + _Access_Token;
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			return _Access_Token;
		}

		public static List<LkCrmCompanyGroupsIIIViewModel> GetCrmGroupsIII(int currLangId = 1065, int defLangId = 1065)
		{
			List<LkCrmCompanyGroupsIIIViewModel> list = new List<LkCrmCompanyGroupsIIIViewModel>();
			CRMEntities cRMEntities = new CRMEntities();
			List<ApispSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<ApispSelectCompanyGroupsIII_Result>((IEnumerable<ApispSelectCompanyGroupsIII_Result>)cRMEntities.ApispSelectCompanyGroupsIII(currLangId, defLangId));
			list.AddRange(Enumerable.Select<ApispSelectCompanyGroupsIII_Result, LkCrmCompanyGroupsIIIViewModel>((IEnumerable<ApispSelectCompanyGroupsIII_Result>)list2, (Func<ApispSelectCompanyGroupsIII_Result, LkCrmCompanyGroupsIIIViewModel>)((ApispSelectCompanyGroupsIII_Result x) => new LkCrmCompanyGroupsIIIViewModel
			{
				CmpGroupIIIId = x.ApiCompanyGroupIIIID,
				CmpGroupIIIName = x.ApiGroupIIIName
			})));
			foreach (ApispSelectCompanyGroupsIII_Result itm in list2)
			{
				ApispSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, itm.ApiCompanyGroupIIIID, "Company", "NoeVahed", 1065, 1065);
				if (crmSettingDetails != null && !string.IsNullOrWhiteSpace(crmSettingDetails.PartValue))
				{
					Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)list, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CmpGroupIIIId == itm.ApiCompanyGroupIIIID)).LinkAccId = crmSettingDetails.PartValue;
					Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)list, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CmpGroupIIIId == itm.ApiCompanyGroupIIIID)).LinkAccName = itm.ApiGroupIIIName;
				}
			}
			return list;
		}

		public List<LkCrmCompanyGroupsIIIViewModel> GetVahed(bool readAgain = false)
		{
			if ((_Vaheds == null || _Vaheds.Count > 0) && !readAgain)
			{
				return _Vaheds;
			}
			List<LkCrmCompanyGroupsIIIViewModel> list = new List<LkCrmCompanyGroupsIIIViewModel>();
			try
			{
				string text = ApiAddress + "Customer/Vahed-Type";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.GetAsync(text).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string result = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(result))
					{
						result = result.ClearHiddenCharacters();
						List<ApispSelectCompanyGroupsIII_Result> companyGroupsIII = Company.GetCompanyGroupsIII(1065, 1065);
						HamyarAPIResponseViewModel<List<HamyarVahedInfoViewModel>> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<List<HamyarVahedInfoViewModel>>>(result);
						if (hamyarAPIResponseViewModel != null && hamyarAPIResponseViewModel.data != null && hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							foreach (HamyarVahedInfoViewModel datum in hamyarAPIResponseViewModel.data)
							{
								LkCrmCompanyGroupsIIIViewModel vm = new LkCrmCompanyGroupsIIIViewModel();
								vm.LinkAccName = datum.name;
								vm.LinkAccId = datum.value.ToString();
								ApispSelectLinkAccSettingDetails_Result crmSettingDetails = GetCrmSettingDetails(0, (int)datum.value, "Company", "NoeVahed", 1065, 1065);
								if (crmSettingDetails != null && crmSettingDetails.PartValue != null)
								{
									vm.CmpGroupIIIId = int.Parse(crmSettingDetails.PartValue);
									if (companyGroupsIII != null)
									{
										ApispSelectCompanyGroupsIII_Result apispSelectCompanyGroupsIII_Result = Enumerable.FirstOrDefault<ApispSelectCompanyGroupsIII_Result>((IEnumerable<ApispSelectCompanyGroupsIII_Result>)companyGroupsIII, (Func<ApispSelectCompanyGroupsIII_Result, bool>)((ApispSelectCompanyGroupsIII_Result x) => x.ApiCompanyGroupIIIID == vm.CmpGroupIIIId));
										if (apispSelectCompanyGroupsIII_Result != null)
										{
											vm.CmpGroupIIIName = apispSelectCompanyGroupsIII_Result.ApiGroupIIIName;
										}
									}
								}
								list.Add(vm);
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			_Vaheds = list;
			return list;
		}

		public string SendCompany(int cmpId, int? centerId = 0, int? currLangId = null, int? defLangId = null, bool? isSendingToOtherCenters = false, string centerCode = "")
		{
			CRMEntities cRMEntities = new CRMEntities();
			string text = "";
			try
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string text2 = now.ToString("HH:mm:ss");
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(now.ToString("yyyy", new PersianCulture()));
				int value4 = -10;
				ApispSelectCompanyById_Result cmp = Enumerable.FirstOrDefault<ApispSelectCompanyById_Result>((IEnumerable<ApispSelectCompanyById_Result>)cRMEntities.ApispSelectCompanyById(cmpId, currLangId, defLangId, centerId, centerCode));
				ApispSelectCompanyPersonsByID_Result companyPerson;
				string cId;
				ApispSelectCentersWithIds_Result apispSelectCentersWithIds_Result2;
				List<LinkAccDataViewModel> list2;
				if (cmp != null)
				{
					companyPerson = GetCompanyPerson(cmp.CompanyID, cmp.cmpMainPersonId);
					cId = centerId.GetValueOrDefault().ToString();
					if (string.IsNullOrWhiteSpace(cId) || cId == "0")
					{
						cId = (cmp.cmpCIds ?? "").Split(new char[1] { ',' })[0];
					}
					if (!isSendingToOtherCenters.GetValueOrDefault() && !string.IsNullOrWhiteSpace(cmp.cmpLinkAccData))
					{
						List<LinkAccDataViewModel> list = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(cmp.cmpLinkAccData);
						if (list != null)
						{
							for (int i = 0; i < Enumerable.Count<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list); i++)
							{
								string text3 = list[i].CId.GetValueOrDefault().ToString();
								string code = list[i].Code;
								ApispSelectCentersWithIds_Result apispSelectCentersWithIds_Result = Enumerable.FirstOrDefault<ApispSelectCentersWithIds_Result>((IEnumerable<ApispSelectCentersWithIds_Result>)Center.GetWithIds(text3));
								if (!string.IsNullOrWhiteSpace(text3) && !(text3 == cId) && !string.IsNullOrWhiteSpace(code))
								{
									int result = 0;
									int.TryParse(text3, out result);
									if (apispSelectCentersWithIds_Result != null && result != 0 && !apispSelectCentersWithIds_Result.CenterInActive.GetValueOrDefault())
									{
										int? centerId2 = result;
										bool? isSendingToOtherCenters2 = true;
										SendCompany(cmpId, centerId2, null, null, isSendingToOtherCenters2);
									}
								}
							}
						}
					}
					apispSelectCentersWithIds_Result2 = new ApispSelectCentersWithIds_Result();
					List<ApispSelectCentersWithIds_Result> withIds = Center.GetWithIds(cId);
					if (withIds.Count <= 0)
					{
						text = text + Messages.msgErrorCenterNotFound + "|";
					}
					else
					{
						apispSelectCentersWithIds_Result2 = withIds[0];
						if (string.IsNullOrWhiteSpace(apispSelectCentersWithIds_Result2.LinkAccCenterCode))
						{
							text = text + string.Format(Messages.msgErrorOtherSystemsNotFindCenter, apispSelectCentersWithIds_Result2.CenterName, cmp.CompanyName, cmp.cmpNumber, Labels.Hamyar) + "|";
						}
						else
						{
							string value5 = cmp.cmpLinkAccData ?? "";
							list2 = new List<LinkAccDataViewModel>();
							if (string.IsNullOrWhiteSpace(value5))
							{
								goto IL_03a1;
							}
							list2 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(value5);
							if (list2 == null || list2.Count <= 0)
							{
								goto IL_03a1;
							}
							LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId.ToString() == cId));
							if (linkAccDataViewModel == null)
							{
								goto IL_03a1;
							}
							string arg = cmp.CompanyName;
							if (cmp.cmpKind.GetValueOrDefault() == 1)
							{
								arg = (companyPerson.prsFName + " " + companyPerson.prsLName).Trim();
							}
							text = text + string.Format(Messages.msgLinkAccSendedBefore, arg, Labels.Hamyar) + "|";
						}
					}
				}
				else
				{
					text = text + Messages.CompanyNotFound + "|";
				}
				goto end_IL_000c;
				IL_03a1:
				HamyarCustomerDefineViewModel hamyarCustomerDefineViewModel = new HamyarCustomerDefineViewModel();
				hamyarCustomerDefineViewModel.centerCode = long.Parse(apispSelectCentersWithIds_Result2.LinkAccCenterCode);
				hamyarCustomerDefineViewModel.bankCode = 0L;
				hamyarCustomerDefineViewModel.shobehBankCode = 0L;
				hamyarCustomerDefineViewModel.address2 = null;
				hamyarCustomerDefineViewModel.shomarehParvande = "";
				hamyarCustomerDefineViewModel.codeKargah = "";
				hamyarCustomerDefineViewModel.codeOstanKargah = 0L;
				hamyarCustomerDefineViewModel.codeShahrKargah = 0L;
				hamyarCustomerDefineViewModel.codeNaghshTejari = "";
				hamyarCustomerDefineViewModel.codeShobehKharidar = "";
				hamyarCustomerDefineViewModel.noeVahed = 0L;
				List<LkCrmCompanyGroupsIIIViewModel> crmGroupsIII = GetCrmGroupsIII();
				if (crmGroupsIII != null)
				{
					LkCrmCompanyGroupsIIIViewModel lkCrmCompanyGroupsIIIViewModel = Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)crmGroupsIII, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.CmpGroupIIIId == cmp.cmpGroupIdIII));
					if (lkCrmCompanyGroupsIIIViewModel != null)
					{
						hamyarCustomerDefineViewModel.noeVahed = long.Parse(lkCrmCompanyGroupsIIIViewModel.LinkAccId);
					}
				}
				hamyarCustomerDefineViewModel.phone1 = cmp.cmpPreTel + cmp.cmpTel + cmp.cmpTelUpTo;
				hamyarCustomerDefineViewModel.phone2 = cmp.cmpPreTelII + cmp.cmpTelII + cmp.cmpTelUpToII;
				if (string.IsNullOrWhiteSpace(hamyarCustomerDefineViewModel.phone2))
				{
					hamyarCustomerDefineViewModel.phone2 = null;
				}
				hamyarCustomerDefineViewModel.address1 = cmp.cmpAddress;
				hamyarCustomerDefineViewModel.codePosti = cmp.cmpZipCode;
				hamyarCustomerDefineViewModel.fax = cmp.cmpFax;
				hamyarCustomerDefineViewModel.siteAddress = cmp.cmpWebSite;
				hamyarCustomerDefineViewModel.shomarehEghtesadi = cmp.cmpEconomicCode;
				hamyarCustomerDefineViewModel.tarikhJazbMoshtari = cmp.FirstRegisterDate?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
				hamyarCustomerDefineViewModel.mahaiatFaliatTafsili = 0L;
				List<ApispSelectCompanyGroupsWithAccLinkField_Result> list3 = Enumerable.ToList<ApispSelectCompanyGroupsWithAccLinkField_Result>((IEnumerable<ApispSelectCompanyGroupsWithAccLinkField_Result>)cRMEntities.ApispSelectCompanyGroupsWithAccLinkField(currLangId, defLangId, true, false));
				if (list3 != null)
				{
					ApispSelectCompanyGroupsWithAccLinkField_Result apispSelectCompanyGroupsWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectCompanyGroupsWithAccLinkField_Result>((IEnumerable<ApispSelectCompanyGroupsWithAccLinkField_Result>)list3, (Func<ApispSelectCompanyGroupsWithAccLinkField_Result, bool>)((ApispSelectCompanyGroupsWithAccLinkField_Result x) => x.CompanyGroupID == cmp.cmpGroupId));
					if (apispSelectCompanyGroupsWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(apispSelectCompanyGroupsWithAccLinkField_Result.LinkAccGroupIdStr))
					{
						hamyarCustomerDefineViewModel.mahaiatFaliatTafsili = long.Parse(apispSelectCompanyGroupsWithAccLinkField_Result.LinkAccGroupIdStr);
					}
				}
				List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> crmSetting = GetCrmSetting(false);
				if (cmp.cmpKind == 0)
				{
					hamyarCustomerDefineViewModel.moadiTypeEnum = long.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)crmSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalMoadiType")).PartValue);
					hamyarCustomerDefineViewModel.companyName = cmp.CompanyName;
					hamyarCustomerDefineViewModel.shomarehSabt = cmp.cmpRegistrationNumber;
					hamyarCustomerDefineViewModel.namayandehKharid = cmp.cmpMainPerson;
					hamyarCustomerDefineViewModel.modirAmelName = cmp.cmpMainPerson;
					hamyarCustomerDefineViewModel.mobileNumber = cmp.cmpMobile;
					hamyarCustomerDefineViewModel.codeMeli = cmp.cmpNationalCode;
					hamyarCustomerDefineViewModel.email = cmp.cmpEmail;
					goto IL_07e5;
				}
				if (cmp.cmpKind.GetValueOrDefault() != 1)
				{
					goto IL_07e5;
				}
				hamyarCustomerDefineViewModel.moadiTypeEnum = long.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)crmSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealMoadiType")).PartValue);
				if (companyPerson != null)
				{
					hamyarCustomerDefineViewModel.firstName = companyPerson.prsFName;
					hamyarCustomerDefineViewModel.lastName = companyPerson.prsLName;
					hamyarCustomerDefineViewModel.tarikhTavalod = companyPerson.prsBirthDateTime?.ToString("yyyy/MM/dd", new CultureInfo("fa-IR"));
					hamyarCustomerDefineViewModel.mobileNumber = companyPerson.prsMobile;
					hamyarCustomerDefineViewModel.codeMeli = companyPerson.prsNationalCode;
					hamyarCustomerDefineViewModel.email = companyPerson.prsEmail;
					goto IL_07e5;
				}
				text = text + Messages.PersonNotFound + "|";
				goto end_IL_000c;
				IL_07e5:
				if (!string.IsNullOrWhiteSpace(cmp.LinkAccCityIdStr))
				{
					hamyarCustomerDefineViewModel.cityCode = long.Parse(cmp.LinkAccCityIdStr);
					hamyarCustomerDefineViewModel.codeShahrKargah = hamyarCustomerDefineViewModel.cityCode;
				}
				if (!string.IsNullOrWhiteSpace(cmp.LinkAccProvinceIdStr))
				{
					hamyarCustomerDefineViewModel.codeOstanKargah = long.Parse(cmp.LinkAccProvinceIdStr);
				}
				if (!string.IsNullOrWhiteSpace(cmp.LinkAccCountryIdStr))
				{
					hamyarCustomerDefineViewModel.countryCode = long.Parse(cmp.LinkAccCountryIdStr);
				}
				string text4 = ApiAddress + "addCustomer";
				HttpClient httpClient = new HttpClient();
				httpClient.BaseAddress = new Uri(text4);
				httpClient.DefaultRequestHeaders.Add("X-API-KEY", ApiKey);
				httpClient.DefaultRequestHeaders.Add("Authorization", GetToken());
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent(JsonConvert.SerializeObject(hamyarCustomerDefineViewModel), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(text4, content).Result;
				string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(result2))
				{
					result2 = result2.ClearHiddenCharacters();
					HamyarAPIResponseViewModel<HamyarInsertCompanyResponseViewModel> hamyarAPIResponseViewModel = JsonConvert.DeserializeObject<HamyarAPIResponseViewModel<HamyarInsertCompanyResponseViewModel>>(result2);
					if (hamyarAPIResponseViewModel != null)
					{
						if (hamyarAPIResponseViewModel.data != null || hamyarAPIResponseViewModel.isSuccess.GetValueOrDefault())
						{
							int num = list2.FindIndex((LinkAccDataViewModel x) => x.CId == int.Parse(cId));
							if (num == -1)
							{
								list2.Add(new LinkAccDataViewModel
								{
									CId = int.Parse(cId),
									FTDate = DateTime.Now,
									LTDate = DateTime.Now,
									DBId = 0,
									Id = "0",
									Code = hamyarAPIResponseViewModel.data.tafsiliCode.ToString()
								});
							}
							else
							{
								list2[num].LTDate = DateTime.Now;
								list2[num].Code = hamyarAPIResponseViewModel.data.tafsiliCode.ToString();
							}
							cRMEntities.ApispUpdateCompanyWithLinkAccField(cmp.CompanyID, null, null, null, null, null, value4, value2, value3, value, registerDatePersian, appType, JsonConvert.SerializeObject(list2), DateTime.Now, DateTime.Now);
							text = "1|" + Messages.msgSuccessAction;
						}
						else if (hamyarAPIResponseViewModel.errors != null && Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors) > 0)
						{
							for (int j = 0; j < Enumerable.Count<string>((IEnumerable<string>)hamyarAPIResponseViewModel.errors); j++)
							{
								text = text + hamyarAPIResponseViewModel.errors[j] + "|";
							}
						}
						else
						{
							text = text + Messages.ErrorEmptyServerResult + "|";
						}
					}
				}
				else
				{
					text = text + Messages.ErrorEmptyServerResult + "|";
				}
				end_IL_000c:;
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
				text = text + Messages.ErrorDoneOperation + ": " + ex.Message + "|";
			}
			finally
			{
				cRMEntities.Dispose();
			}
			return text;
		}
	}

	public class RahkaranInternalSalesProvider
	{
		private const string authAddressPath = "Framework/Services/AuthenticationService.svc";

		public HttpClient client = new HttpClient();

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_CurrencyRef = "CurrencyRef";

		public const string _KeyName_AddressTypeSendPrd = "AddressTypeSendPrd";

		public const string _KeyName_AddressTypeSendOrd = "AddressTypeSendOrd";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		public const string _KeyName_DefCurrencyUnitId = "DefCurrencyUnitId";

		public const string _KeyName_DefPrjTitle = "DefPrjTitle";

		public const string _KeyName_DefPrjCvnsStatusGroupId = "DefPrjCvnsStatusGroupId";

		private static string _ApiAddress = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static long _CurrencyRef = 0L;

		private static int _AddressTypeSendPrd = 0;

		private static int _AddressTypeSendOrd = 0;

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static int _DefCurrencyUnitId = 0;

		private static string _DefPrjTitle = "";

		private static int _DefPrjCvnsStatusGroupId = 0;

		private static List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> _LinkAccSetting = null;

		public string seesionID { get; set; }

		public bool loginResult { get; set; }

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public long CurrencyRef
		{
			get
			{
				if (_CurrencyRef == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrencyRef")).PartValue ?? "0", out _CurrencyRef);
				}
				return _CurrencyRef;
			}
			set
			{
				_CurrencyRef = 0L;
			}
		}

		public int AddressTypeSendPrd
		{
			get
			{
				if (_AddressTypeSendPrd == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "AddressTypeSendPrd")).PartValue ?? "0", out _AddressTypeSendPrd);
				}
				return _AddressTypeSendPrd;
			}
			set
			{
				_AddressTypeSendPrd = 0;
			}
		}

		public int AddressTypeSendOrd
		{
			get
			{
				if (_AddressTypeSendOrd == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "AddressTypeSendOrd")).PartValue ?? "0", out _AddressTypeSendOrd);
				}
				return _AddressTypeSendOrd;
			}
			set
			{
				_AddressTypeSendOrd = 0;
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public int DefCurrencyUnitId
		{
			get
			{
				if (_DefCurrencyUnitId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefCurrencyUnitId")).PartValue ?? "0", out _DefCurrencyUnitId);
				}
				return _DefCurrencyUnitId;
			}
			set
			{
				_DefCurrencyUnitId = 0;
			}
		}

		public string DefPrjTitle
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_DefPrjTitle))
				{
					_DefPrjTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefPrjTitle")).PartValue ?? "";
				}
				return _DefPrjTitle;
			}
			set
			{
				_DefPrjTitle = "";
			}
		}

		public int DefPrjCvnsStatusGroupId
		{
			get
			{
				if (_DefPrjCvnsStatusGroupId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId")).PartValue ?? "0", out _DefPrjCvnsStatusGroupId);
				}
				return _DefPrjCvnsStatusGroupId;
			}
			set
			{
				_DefPrjCvnsStatusGroupId = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			CurrencyRef = 0L;
			AddressTypeSendPrd = 0;
			AddressTypeSendOrd = 0;
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
			DefCurrencyUnitId = 0;
			DefPrjTitle = "";
			DefPrjCvnsStatusGroupId = 0;
		}

		public List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> GetLinkAccSetting(bool? readAgain = false, int currLangID = 1065, int defLangID = 1065)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				int value = 22;
				int value2 = -1;
				list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSettingId: 0, languageID: currLangID, defaultLanguageID: defLangID, linkAccSystemId: value, objectType: "", linkAccSettingDBId: value2));
				if (list == null)
				{
					list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
				}
			}
			catch (Exception)
			{
			}
			cRMEntities.Dispose();
			return list;
		}

		public RahkaranInternalSalesProvider(bool isUpdateList = false, bool isLogin = true, int currLangID = 1065, int defLangID = 1065)
		{
			_LinkAccSetting = GetLinkAccSetting(true, currLangID, defLangID);
			ClearFields();
			string apiUsername = ApiUsername;
			string apiPassword = ApiPassword;
			client.BaseAddress = new Uri(ApiAddress);
			if (isLogin)
			{
				apiPassword = GeneratePassword(client, apiPassword);
				loginResult = PostAsyncLogin(client, apiUsername, apiPassword, seesionID);
			}
		}

		private static byte[] HexStringToBytes(string hex)
		{
			if (hex.Length == 0)
			{
				return new byte[1];
			}
			if (hex.Length % 2 == 1)
			{
				hex = "0" + hex;
			}
			byte[] array = new byte[hex.Length / 2];
			for (int i = 0; i < hex.Length / 2; i++)
			{
				array[i] = byte.Parse(hex.Substring(2 * i, 2), NumberStyles.AllowHexSpecifier);
			}
			return array;
		}

		private static string BytesToHexString(byte[] input)
		{
			StringBuilder stringBuilder = new StringBuilder(64);
			for (int i = 0; i < input.Length; i++)
			{
				stringBuilder.Append($"{input[i]:X2}");
			}
			return stringBuilder.ToString();
		}

		private static string GetAsyncSession(HttpClient client)
		{
			HttpResponseMessage result = client.GetAsync("Framework/Services/AuthenticationService.svc/session").Result;
			string result2 = "";
			if (result.IsSuccessStatusCode)
			{
				result2 = result.Content.ReadAsStringAsync().Result;
			}
			return result2;
		}

		public string GeneratePassword(HttpClient client, string password)
		{
			string asyncSession = GetAsyncSession(client);
			JObject jObject = JObject.Parse(asyncSession);
			string hex = jObject["rsa"]["M"].ToString();
			string hex2 = jObject["rsa"]["E"].ToString();
			string text2 = (seesionID = jObject["id"].ToString());
			RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
			rSACryptoServiceProvider.ImportParameters(new RSAParameters
			{
				Exponent = HexStringToBytes(hex2),
				Modulus = HexStringToBytes(hex)
			});
			password = BytesToHexString(rSACryptoServiceProvider.Encrypt(Encoding.UTF8.GetBytes(text2 + "**" + password), fOAEP: false));
			return password;
		}

		private static bool PostAsyncLogin(HttpClient client, string username, string password, string seesionId)
		{
			client.DefaultRequestHeaders.Add("ContentType", "application/json");
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			string content = "{\"password\": \"" + password + "\",\"username\": \"" + username + "\",\"sessionId\": \"" + seesionId + "\"}";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result = client.PostAsync("Framework/Services/AuthenticationService.svc/login", content2).Result;
			string text = "";
			text = result.Content.ReadAsStringAsync().Result;
			if (result.IsSuccessStatusCode)
			{
				string value = Enumerable.ToArray<string>(result.Headers.GetValues("Set-Cookie"))[1].Split(new char[1] { ';' })[0] + "; path=/; HttpOnly";
				client.DefaultRequestHeaders.Add("Set-Cookie", value);
				return true;
			}
			return false;
		}

		public double GetPrdQuqntity(long prdId, long whId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string requestUri = "Sales/SalesDocument/Services/SalesDocumentService.svc/productInventoryRemainingValue";
			double result = 0.0;
			string text = "";
			if (loginResult)
			{
				int num = 0;
				string content = "{" + $"\"ProductID\": \"{prdId}\"" + $",\"InventoryID\": {whId}" + $",\"PlantID\": {num}" + "}";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(requestUri, content2).Result;
				if (result2.IsSuccessStatusCode)
				{
					text = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						RahkaranInternalSalesProductRemainingResponseViewModel rahkaranInternalSalesProductRemainingResponseViewModel = JsonConvert.DeserializeObject<RahkaranInternalSalesProductRemainingResponseViewModel>(text);
						if (rahkaranInternalSalesProductRemainingResponseViewModel != null)
						{
							result = rahkaranInternalSalesProductRemainingResponseViewModel.ActualRemainingValue ?? rahkaranInternalSalesProductRemainingResponseViewModel.physicalRemainingValue.GetValueOrDefault();
						}
					}
				}
			}
			return result;
		}
	}

	public class RayvarzProvider
	{
		private const string authAddressPath = "RayvarzApi/Core/Sso/Authenticate";

		public HttpClient client = new HttpClient();

		private string _AccessToken = "";

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "ApiUsername";

		public const string _KeyName_Password = "ApiPassword";

		public const string _KeyName_BranchId = "ApiBranchId";

		public const string _KeyName_FiscalYear = "FiscalYear";

		public const string _KeyName_PrdLinkedField = "PrdLinkedField";

		public const string _KeyName_WrhsSyncTypeId = "WrhsSyncTypeId";

		public const string _KeyName_LegalCenterGroupId = "LegalCenterGroupId";

		public const string _KeyName_LegalParentCenterId = "LegalParentCenterId";

		public const string _KeyName_RealCenterGroupId = "RealCenterGroupId";

		public const string _KeyName_RealParentCenterId = "RealParentCenterId";

		public const string _KeyName_CmpAccountRemainMode = "CmpAccountRemainMode";

		private static string _ApiAddress = "";

		private static string _ApiUsername = "";

		private static string _ApiPassword = "";

		private static string _ApiBranchId = "";

		private static string _FiscalYear = "";

		private static long _FiscalYearId = 0L;

		private static string _PrdLinkedField = "";

		private static int _WrhsSyncTypeId = 0;

		private static int _WrhsSyncTypeLinkAccSettingId = 0;

		private static long _LegalCenterGroupId = 0L;

		private static long _LegalParentCenterId = 0L;

		private static long _RealCenterGroupId = 0L;

		private static long _RealParentCenterId = 0L;

		private static string _CmpAccountRemainMode = "";

		private static List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> _LinkAccSetting = null;

		public bool loginResult { get; set; }

		public string AccessToken
		{
			get
			{
				return _AccessToken;
			}
			set
			{
				_AccessToken = value;
			}
		}

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUsername")).PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiPassword")).PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public string ApiBranchId
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiBranchId))
				{
					_ApiBranchId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiBranchId")).PartValue ?? "";
				}
				return _ApiBranchId;
			}
			set
			{
				_ApiBranchId = "";
			}
		}

		public string FiscalYear
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_FiscalYear))
				{
					_FiscalYear = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "FiscalYear")).PartValue ?? "";
					if (string.IsNullOrWhiteSpace(_FiscalYear))
					{
						_FiscalYear = DateTime.Now.ToString("yyyy", new PersianCulture());
					}
				}
				return _FiscalYear;
			}
			set
			{
				_FiscalYear = "";
			}
		}

		public long FiscalYearId
		{
			get
			{
				return _FiscalYearId;
			}
			set
			{
				_FiscalYearId = 0L;
			}
		}

		public string PrdLinkedField
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_PrdLinkedField))
				{
					_PrdLinkedField = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue ?? "";
				}
				return _PrdLinkedField;
			}
			set
			{
				_PrdLinkedField = "";
			}
		}

		public int WrhsSyncTypeId
		{
			get
			{
				if (_WrhsSyncTypeId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue ?? "0", out _WrhsSyncTypeId);
				}
				return _WrhsSyncTypeId;
			}
			set
			{
				_WrhsSyncTypeId = 0;
			}
		}

		public int WrhsSyncTypeLinkAccSettingId
		{
			get
			{
				if (_WrhsSyncTypeLinkAccSettingId == 0)
				{
					int.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).LinkAccSettingId.ToString(), out _WrhsSyncTypeLinkAccSettingId);
				}
				return _WrhsSyncTypeLinkAccSettingId;
			}
			set
			{
				_WrhsSyncTypeLinkAccSettingId = 0;
			}
		}

		public long LegalCenterGroupId
		{
			get
			{
				if (_LegalCenterGroupId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalCenterGroupId")).PartValue ?? "0", out _LegalCenterGroupId);
				}
				return _LegalCenterGroupId;
			}
			set
			{
				_LegalCenterGroupId = 0L;
			}
		}

		public long LegalParentCenterId
		{
			get
			{
				if (_LegalParentCenterId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalParentCenterId")).PartValue ?? "0", out _LegalParentCenterId);
				}
				return _LegalParentCenterId;
			}
			set
			{
				_LegalParentCenterId = 0L;
			}
		}

		public long RealCenterGroupId
		{
			get
			{
				if (_RealCenterGroupId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealCenterGroupId")).PartValue ?? "0", out _RealCenterGroupId);
				}
				return _RealCenterGroupId;
			}
			set
			{
				_RealCenterGroupId = 0L;
			}
		}

		public long RealParentCenterId
		{
			get
			{
				if (_RealParentCenterId == 0L)
				{
					long.TryParse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealParentCenterId")).PartValue ?? "0", out _RealParentCenterId);
				}
				return _RealParentCenterId;
			}
			set
			{
				_RealParentCenterId = 0L;
			}
		}

		public string CmpAccountRemainMode
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_CmpAccountRemainMode))
				{
					_CmpAccountRemainMode = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CmpAccountRemainMode")).PartValue ?? "";
				}
				return _CmpAccountRemainMode;
			}
			set
			{
				_CmpAccountRemainMode = "";
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			ApiBranchId = "";
			FiscalYear = "";
			PrdLinkedField = "";
			WrhsSyncTypeId = 0;
			WrhsSyncTypeLinkAccSettingId = 0;
			LegalCenterGroupId = 0L;
			LegalParentCenterId = 0L;
			RealCenterGroupId = 0L;
			RealParentCenterId = 0L;
			CmpAccountRemainMode = "";
		}

		public List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> GetLinkAccSetting(bool? readAgain = false, int currLangID = 1065, int defLangID = 1065)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				int value = 23;
				int value2 = -1;
				list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSettingId: 0, languageID: currLangID, defaultLanguageID: defLangID, linkAccSystemId: value, objectType: "", linkAccSettingDBId: value2));
				if (list == null)
				{
					list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
				}
			}
			catch (Exception)
			{
			}
			cRMEntities.Dispose();
			return list;
		}

		public RayvarzProvider(bool isUpdateList = false, bool isLogin = true, int currLangID = 1065, int defLangID = 1065)
		{
			_LinkAccSetting = GetLinkAccSetting(true, currLangID, defLangID);
			ClearFields();
			string apiUsername = ApiUsername;
			string apiPassword = ApiPassword;
			client.BaseAddress = new Uri(ApiAddress);
			if (isLogin)
			{
				apiPassword = GeneratePasswordHash(apiPassword);
				string token = "";
				loginResult = PostAsyncAuthenticate(client, apiUsername, apiPassword, ref token);
				AccessToken = token;
				FiscalYearId = GetSalesFiscalYearId();
			}
		}

		public string GeneratePasswordHash(string password)
		{
			if (!string.IsNullOrWhiteSpace(password))
			{
				password = BaseInfo.ConverSHA256(password);
			}
			return password;
		}

		private static bool PostAsyncAuthenticate(HttpClient client, string username, string password, ref string token)
		{
			client.DefaultRequestHeaders.Add("ContentType", "application/json");
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			string content = "[\"" + username + "\",\"" + password + "\"]";
			StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
			HttpResponseMessage result = client.PostAsync("RayvarzApi/Core/Sso/Authenticate", content2).Result;
			string text = "";
			text = result.Content.ReadAsStringAsync().Result;
			if (result.IsSuccessStatusCode)
			{
				token = text;
				if (!string.IsNullOrWhiteSpace(token))
				{
					token = token.Replace("\"", "");
				}
				return true;
			}
			return false;
		}

		public List<RayvarzSalesFiscalYearResponseViewModel> GetSalesFiscalYear()
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			httpClient.DefaultRequestHeaders.Add("Access_Token", AccessToken);
			httpClient.DefaultRequestHeaders.Add("BranchId", ApiBranchId);
			string requestUri = "RayvarzApi/Sales/SalesFiscalYear/List";
			List<RayvarzSalesFiscalYearResponseViewModel> list = new List<RayvarzSalesFiscalYearResponseViewModel>();
			string text = "";
			if (loginResult)
			{
				string content = "";
				StringContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(requestUri, content2).Result;
				if (result.IsSuccessStatusCode)
				{
					text = result.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						text = text.Replace("\"[", "[").Replace("]\"", "]").Replace("\\\"", "\"");
						List<RayvarzSalesFiscalYearResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzSalesFiscalYearResponseViewModel>>(text);
						if (list2 != null && Enumerable.Any<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)list2))
						{
							list.AddRange(list2);
						}
					}
				}
				if (list == null)
				{
					list = new List<RayvarzSalesFiscalYearResponseViewModel>();
				}
			}
			return list;
		}

		public long GetSalesFiscalYearId()
		{
			long result = 0L;
			List<RayvarzSalesFiscalYearResponseViewModel> salesFiscalYear = GetSalesFiscalYear();
			if (salesFiscalYear != null && Enumerable.Any<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)salesFiscalYear))
			{
				RayvarzSalesFiscalYearResponseViewModel rayvarzSalesFiscalYearResponseViewModel = Enumerable.FirstOrDefault<RayvarzSalesFiscalYearResponseViewModel>((IEnumerable<RayvarzSalesFiscalYearResponseViewModel>)salesFiscalYear, (Func<RayvarzSalesFiscalYearResponseViewModel, bool>)((RayvarzSalesFiscalYearResponseViewModel m) => m.fiscalYear.GetValueOrDefault().ToString() == FiscalYear));
				if (rayvarzSalesFiscalYearResponseViewModel != null)
				{
					result = rayvarzSalesFiscalYearResponseViewModel.salesFiscalYearId.GetValueOrDefault();
				}
			}
			return result;
		}

		public double GetPrdQuqntity(string prdId, string whId)
		{
			HttpClient httpClient = client;
			httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
			httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
			string text = "RayvarzApi/Sales/SalesInventoryInterop/StockList";
			double result = 0.0;
			string text2 = "";
			if (loginResult)
			{
				string text3 = "?itemDataId=" + prdId + "&warehouseId=" + whId;
				string content = "";
				text = ApiAddress + text + text3;
				HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, text);
				httpRequestMessage.Headers.Add("access_token", AccessToken);
				httpRequestMessage.Headers.Add("BranchId", ApiBranchId);
				StringContent stringContent = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.GetAsync(text).Result;
				if (result2.IsSuccessStatusCode)
				{
					text2 = result2.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						List<RayvarzProductRemainingResponseViewModel> list = JsonConvert.DeserializeObject<List<RayvarzProductRemainingResponseViewModel>>(text2);
						if (list != null && Enumerable.Any<RayvarzProductRemainingResponseViewModel>((IEnumerable<RayvarzProductRemainingResponseViewModel>)list))
						{
							RayvarzProductRemainingResponseViewModel rayvarzProductRemainingResponseViewModel = Enumerable.FirstOrDefault<RayvarzProductRemainingResponseViewModel>((IEnumerable<RayvarzProductRemainingResponseViewModel>)list, (Func<RayvarzProductRemainingResponseViewModel, bool>)((RayvarzProductRemainingResponseViewModel m) => (m.warehouseId ?? "") == whId && (m.itemDataId ?? "") == prdId));
							if (rayvarzProductRemainingResponseViewModel != null)
							{
								decimal valueOrDefault = rayvarzProductRemainingResponseViewModel.remainedStockPartialQtySum.GetValueOrDefault();
								decimal num = default(decimal);
								if (rayvarzProductRemainingResponseViewModel.itemData != null)
								{
									num = rayvarzProductRemainingResponseViewModel.itemData.salesBulkToPieceConvertRate.GetValueOrDefault(1m);
								}
								if (num == 0m)
								{
									num = 1m;
								}
								double.TryParse((valueOrDefault / num).ToString(), out result);
							}
						}
					}
				}
			}
			return result;
		}
	}

	public class HolooProvider
	{
		public HttpClient client = new HttpClient();

		private readonly CRMEntities _dbLink = new CRMEntities();

		private string _AccessToken = "";

		public const string _KeyName_Address = "ApiAddress";

		public const string _KeyName_Username = "UserName";

		public const string _KeyName_Password = "Password";

		public const string _KeyName_CashAccCode = "CashAccCode";

		public const string _KeyName_PrdInvStockDisplayType = "PrdInvStockDisplayType";

		public const string _KeyName_TaxCalculateType = "TaxCalculateType";

		public const string _KeyName_TaxPercent = "TaxPercent";

		public const string _KeyName_DutyPercent = "DutyPercent";

		public const string _KeyName_AllowDuplicateEco = "AllowDuplicateEco";

		public const string _KeyName_AllowDuplicateNatCode = "AllowDuplicateNatCode";

		public const string _KeyName_AllowDuplicateMobile = "AllowDuplicateMobile";

		public const string _KeyName_SendTaxAndDutyPercentToApi = "SendTaxAndDutyPercentToApi";

		public const string _KeyName_CmpMnBgRate = "CmpMnBgRate";

		public const string _KeyName_CmpMnBgExpireDay = "CmpMnBgExpireDay";

		public const string _KeyName_SendPrdUnitToApi = "SendPrdUnitToApi";

		public const string _KeyName_DoneActionsAfterOrdVerify = "DoneActionsAfterOrdVerify";

		public const string _KeyName_OrderTimeOut = "OrderTimeOut";

		public const string _KeyName_ProductTimeOut = "ProductTimeOut";

		public const string _KeyName_CompanyTimeOut = "CompanyTimeOut";

		public const string _KeyName_CmpLinkedField = "_CmpLinkedField";

		private static string _Token = "";

		private string _ApiAddress = "";

		private string _ApiUsername = "";

		private string _ApiPassword = "";

		private string _CashAccCode = "";

		private int? _PrdInvStockDisplayType;

		private int? _TaxCalculateType;

		private int? _TaxPercent;

		private int? _DutyPercent;

		private bool? _AllowDuplicateEco;

		private bool? _AllowDuplicateNatCode;

		private bool? _AllowDuplicateMobile;

		private bool? _SendTaxAndDutyPercentToApi;

		private int? _CmpMnBgRate;

		private int? _CmpMnBgExpireDay;

		private bool? _SendPrdUnitToApi;

		private bool? _DoneActionsAfterOrdVerify;

		private int _OrderTimeOut;

		private int _CompanyTimeOut;

		private int _ProductTimeOut;

		private int _CmpLinkedField;

		private static List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> _LinkAccSetting = null;

		private static ApispSelectLinkAccSettingDbById_Result _LinkAccSettingDB = null;

		public bool loginResult { get; set; }

		public string AccessToken
		{
			get
			{
				return _AccessToken;
			}
			set
			{
				_AccessToken = value;
			}
		}

		public string Token => _Token;

		public string ApiAddress
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiAddress))
				{
					_ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress"))?.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(_ApiAddress) && !_ApiAddress.EndsWith("/"))
				{
					_ApiAddress += "/";
				}
				return _ApiAddress;
			}
			set
			{
				_ApiAddress = "";
			}
		}

		public string ApiUsername
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiUsername))
				{
					_ApiUsername = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "UserName"))?.PartValue ?? "";
				}
				return _ApiUsername;
			}
			set
			{
				_ApiUsername = "";
			}
		}

		public string ApiPassword
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_ApiPassword))
				{
					_ApiPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "Password"))?.PartValue ?? "";
				}
				return _ApiPassword;
			}
			set
			{
				_ApiPassword = "";
			}
		}

		public string CashAccCode
		{
			get
			{
				if (string.IsNullOrWhiteSpace(_CashAccCode))
				{
					_CashAccCode = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CashAccCode"))?.PartValue ?? "";
				}
				return _CashAccCode;
			}
			set
			{
				_CashAccCode = "";
			}
		}

		public int PrdInvStockDisplayType
		{
			get
			{
				if (_PrdInvStockDisplayType.GetValueOrDefault() == 0)
				{
					_PrdInvStockDisplayType = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdInvStockDisplayType"))?.PartValue ?? "0");
				}
				return _PrdInvStockDisplayType.Value;
			}
			set
			{
				_PrdInvStockDisplayType = 0;
			}
		}

		public int TaxCalculateType
		{
			get
			{
				if (_TaxCalculateType.GetValueOrDefault() == 0)
				{
					_TaxCalculateType = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "TaxCalculateType"))?.PartValue ?? "0");
				}
				return _TaxCalculateType.Value;
			}
			set
			{
				_TaxCalculateType = 0;
			}
		}

		public int TaxPercent
		{
			get
			{
				if (_TaxPercent.GetValueOrDefault() == 0)
				{
					_TaxPercent = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "TaxPercent"))?.PartValue ?? "0");
				}
				return _TaxPercent.Value;
			}
			set
			{
				_TaxPercent = 0;
			}
		}

		public int DutyPercent
		{
			get
			{
				if (_DutyPercent.GetValueOrDefault() == 0)
				{
					_DutyPercent = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DutyPercent"))?.PartValue ?? "0");
				}
				return _DutyPercent.Value;
			}
			set
			{
				_DutyPercent = 0;
			}
		}

		public bool AllowDuplicateEco
		{
			get
			{
				if (!_AllowDuplicateEco.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "AllowDuplicateEco"))?.PartValue ?? "false";
					_AllowDuplicateEco = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateEco.Value;
			}
			set
			{
				_AllowDuplicateEco = false;
			}
		}

		public bool AllowDuplicateNatCode
		{
			get
			{
				if (!_AllowDuplicateNatCode.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "AllowDuplicateNatCode"))?.PartValue ?? "false";
					_AllowDuplicateNatCode = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateNatCode.Value;
			}
			set
			{
				_AllowDuplicateNatCode = false;
			}
		}

		public bool AllowDuplicateMobile
		{
			get
			{
				if (!_AllowDuplicateMobile.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "AllowDuplicateMobile"))?.PartValue ?? "false";
					_AllowDuplicateMobile = text.ToLower() == bool.TrueString.ToLower();
				}
				return _AllowDuplicateMobile.Value;
			}
			set
			{
				_AllowDuplicateMobile = false;
			}
		}

		public bool SendTaxAndDutyPercentToApi
		{
			get
			{
				if (!_SendTaxAndDutyPercentToApi.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "SendTaxAndDutyPercentToApi"))?.PartValue ?? "false";
					_SendTaxAndDutyPercentToApi = text.ToLower() == bool.TrueString.ToLower();
				}
				return _SendTaxAndDutyPercentToApi.Value;
			}
			set
			{
				_SendTaxAndDutyPercentToApi = false;
			}
		}

		public int CmpMnBgRate
		{
			get
			{
				if (_CmpMnBgRate.GetValueOrDefault() == 0)
				{
					_CmpMnBgRate = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CmpMnBgRate"))?.PartValue ?? "0");
				}
				return _CmpMnBgRate.Value;
			}
			set
			{
				_CmpMnBgRate = 0;
			}
		}

		public int? CmpMnBgExpireDay
		{
			get
			{
				if (_CmpMnBgExpireDay.GetValueOrDefault() == 0)
				{
					_CmpMnBgExpireDay = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CmpMnBgExpireDay"))?.PartValue ?? "0");
				}
				return _CmpMnBgExpireDay.Value;
			}
			set
			{
				_CmpMnBgExpireDay = 0;
			}
		}

		public bool SendPrdUnitToApi
		{
			get
			{
				if (!_SendPrdUnitToApi.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "SendPrdUnitToApi"))?.PartValue ?? "false";
					_SendPrdUnitToApi = text.ToLower() == bool.TrueString.ToLower();
				}
				return _SendPrdUnitToApi.Value;
			}
			set
			{
				_SendPrdUnitToApi = false;
			}
		}

		public bool DoneActionsAfterOrdVerify
		{
			get
			{
				if (!_DoneActionsAfterOrdVerify.GetValueOrDefault())
				{
					string text = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DoneActionsAfterOrdVerify"))?.PartValue ?? "false";
					_DoneActionsAfterOrdVerify = text.ToLower() == bool.TrueString.ToLower();
				}
				return _DoneActionsAfterOrdVerify.Value;
			}
			set
			{
				_DoneActionsAfterOrdVerify = false;
			}
		}

		public int OrderTimeOut
		{
			get
			{
				if (_OrderTimeOut == 0)
				{
					_OrderTimeOut = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "OrderTimeOut"))?.PartValue ?? "20");
				}
				return _OrderTimeOut;
			}
			set
			{
				_OrderTimeOut = 0;
			}
		}

		public int CompanyTimeOut
		{
			get
			{
				if (_CompanyTimeOut == 0)
				{
					_CompanyTimeOut = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CompanyTimeOut"))?.PartValue ?? "20");
				}
				return _CompanyTimeOut;
			}
			set
			{
				_CompanyTimeOut = 0;
			}
		}

		public int ProductTimeOut
		{
			get
			{
				if (_ProductTimeOut == 0)
				{
					_ProductTimeOut = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ProductTimeOut"))?.PartValue ?? "20");
				}
				return _ProductTimeOut;
			}
			set
			{
				_ProductTimeOut = 0;
			}
		}

		public int CmpLinkedField
		{
			get
			{
				if (_CmpLinkedField == 0)
				{
					_CmpLinkedField = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_LinkAccSetting, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "_CmpLinkedField"))?.PartValue ?? "1");
				}
				return _CmpLinkedField;
			}
			set
			{
				_CmpLinkedField = 0;
			}
		}

		public void ClearFields()
		{
			ApiAddress = "";
			ApiUsername = "";
			ApiPassword = "";
			CashAccCode = "";
			PrdInvStockDisplayType = 0;
			TaxCalculateType = 0;
			TaxPercent = 0;
			DutyPercent = 0;
			AllowDuplicateEco = false;
			AllowDuplicateNatCode = false;
			AllowDuplicateMobile = false;
			SendTaxAndDutyPercentToApi = false;
			CmpMnBgRate = 0;
			CmpMnBgExpireDay = 0;
			SendPrdUnitToApi = false;
			DoneActionsAfterOrdVerify = false;
			OrderTimeOut = 20;
			ProductTimeOut = 20;
			CompanyTimeOut = 20;
		}

		public List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> GetLinkAccSetting(int linkAccSettingDBId, bool? readAgain = false)
		{
			if (!readAgain.GetValueOrDefault() && _LinkAccSetting != null)
			{
				return _LinkAccSetting;
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
			try
			{
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)_dbLink.ApispSelectCrmsysSetting());
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 4;
				list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_dbLink.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSettingId: 0, languageID: lCID, defaultLanguageID: result, linkAccSystemId: value, objectType: "", linkAccSettingDBId: linkAccSettingDBId));
				if (list == null)
				{
					list = new List<ApispSelectLinkAccSettingByLinkAccSystemId_Result>();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			_dbLink.Dispose();
			return list;
		}

		public ApispSelectLinkAccSettingDbById_Result GetLinkAccSettingDB(int linkAccSettingDBId)
		{
			if (_LinkAccSettingDB != null)
			{
				return _LinkAccSettingDB;
			}
			ApispSelectLinkAccSettingDbById_Result apispSelectLinkAccSettingDbById_Result = new ApispSelectLinkAccSettingDbById_Result();
			CRMEntities cRMEntities = new CRMEntities();
			try
			{
				ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int value = 4;
				apispSelectLinkAccSettingDbById_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingDbById_Result>((IEnumerable<ApispSelectLinkAccSettingDbById_Result>)_dbLink.ApispSelectLinkAccSettingDbById(value, linkAccSettingDBId, lCID, result));
				if (apispSelectLinkAccSettingDbById_Result == null)
				{
					apispSelectLinkAccSettingDbById_Result = new ApispSelectLinkAccSettingDbById_Result();
				}
			}
			catch (Exception ex)
			{
				Public.InsExceptToElmah(ex);
			}
			_dbLink.Dispose();
			return apispSelectLinkAccSettingDbById_Result;
		}

		public HolooProvider(int linkAccSettingDBId, string timeOutMode = "", bool isUpdateList = false, bool isLogin = true)
		{
			_LinkAccSetting = GetLinkAccSetting(linkAccSettingDBId, true);
			_LinkAccSettingDB = GetLinkAccSettingDB(linkAccSettingDBId);
			ClearFields();
		}

		public string Authenticate(string timeOutMode = "")
		{
			string text = "";
			_Token = "";
			string text2 = _LinkAccSettingDB.LinkAccSettingDbName ?? "";
			if (!string.IsNullOrWhiteSpace(ApiAddress) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(ApiUsername) && !string.IsNullOrWhiteSpace(ApiPassword))
			{
				if (!ApiAddress.EndsWith("/"))
				{
					ApiAddress += "/";
				}
				HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
				holooLoginViewModel.userinfo = new HolooUserInfoViewModel
				{
					dbname = text2,
					username = ApiUsername,
					userpass = ApiPassword
				};
				string text3 = "api/Login";
				HttpClient httpClient = new HttpClient();
				int? num = null;
				if (!string.IsNullOrWhiteSpace(timeOutMode))
				{
					num = timeOutMode.ToLower() switch
					{
						"order" => _OrderTimeOut, 
						"product" => _ProductTimeOut, 
						"company" => _CompanyTimeOut, 
						_ => 20, 
					};
					if (num.HasValue)
					{
						httpClient.Timeout = TimeSpan.FromSeconds(num.Value);
					}
				}
				httpClient.BaseAddress = new Uri(ApiAddress + text3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string content = JsonConvert.SerializeObject(holooLoginViewModel);
				HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
				HttpResponseMessage result = httpClient.PostAsync(ApiAddress + text3, content2).Result;
				if (result.IsSuccessStatusCode)
				{
					string result2 = result.Content.ReadAsStringAsync().Result;
					HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2);
					if (holooLoginResultViewModel != null)
					{
						if (holooLoginResultViewModel.Login != null)
						{
							if (holooLoginResultViewModel.Login.State)
							{
								_Token = holooLoginResultViewModel.Login.Token ?? "";
								if (string.IsNullOrWhiteSpace(_Token))
								{
									string message = Messages.msgErrorRunFunction + "<br> Token is null";
									Exception ex = new Exception(message);
									ErrorSignal.FromCurrentContext().Raise(ex);
									return ex.Message + "|";
								}
								return "";
							}
							string msgErrorRunFunction = Messages.msgErrorRunFunction;
							string error = holooLoginResultViewModel.Login.Error;
							_ = holooLoginResultViewModel.Login.ErrorCode;
							string message2 = string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode);
							Exception ex2 = new Exception(message2);
							ErrorSignal.FromCurrentContext().Raise(ex2);
							return ex2.Message + "|";
						}
						string message3 = Messages.msgErrorRunFunction + "<br> Error in login";
						Exception ex3 = new Exception(message3);
						ErrorSignal.FromCurrentContext().Raise(ex3);
						return ex3.Message + "|";
					}
					string message4 = Messages.msgErrorRunFunction + "<br> Error in login";
					Exception ex4 = new Exception(message4);
					ErrorSignal.FromCurrentContext().Raise(ex4);
					return ex4.Message + "|";
				}
				string message5 = Messages.msgErrorRunFunction + "<br> Error in login";
				Exception ex5 = new Exception(message5);
				ErrorSignal.FromCurrentContext().Raise(ex5);
				return ex5.Message + "|";
			}
			string errorInReadingSetting = Messages.errorInReadingSetting;
			Exception ex6 = new Exception(errorInReadingSetting);
			ErrorSignal.FromCurrentContext().Raise(ex6);
			return ex6.Message + "|";
		}

		public void GetPrdQuantity(ApispSelectProductsWithId_Result prd, string collation, ref string result, ref string errorMessage)
		{
			ResourceManager resourceManager = new ResourceManager();
			if (string.IsNullOrWhiteSpace(Token))
			{
				return;
			}
			string text = "?code=" + prd.PrdLinkAccPrdCode;
			if (!string.IsNullOrWhiteSpace(prd.FGLinkAccGroupIdStr))
			{
				text = text + "&maingrouperpcode=" + prd.FGLinkAccGroupIdStr;
			}
			if (!string.IsNullOrWhiteSpace(prd.SGLinkAccGroupIdStr))
			{
				text = text + "&sidegrouperpcode=" + prd.SGLinkAccGroupIdStr;
			}
			HttpClient httpClient = new HttpClient();
			httpClient.Timeout = RestApiTimeout();
			httpClient.BaseAddress = new Uri(ApiAddress);
			httpClient.DefaultRequestHeaders.Add("Authorization", Token);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string requestUri = "api/Product" + text;
			HttpResponseMessage result2 = httpClient.GetAsync(requestUri).Result;
			if (result2.IsSuccessStatusCode)
			{
				string result3 = result2.Content.ReadAsStringAsync().Result;
				HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result3);
				if (holooProductListViewModel != null)
				{
					if (holooProductListViewModel.product == null)
					{
						return;
					}
					if (holooProductListViewModel.product.Count != 1)
					{
						string message = resourceManager.Get("msgErrorRunFunction", collation, resourceManager.TypeMsg) + " (not find prodcut information from Holoo or find more one than) ";
						Exception e = new Exception(message);
						ErrorSignal.FromCurrentContext().Raise(e);
						errorMessage = resourceManager.Get("frmError", collation, resourceManager.TypeLbl);
						return;
					}
					double valueOrDefault = holooProductListViewModel.product[0].Few.GetValueOrDefault();
					double valueOrDefault2 = holooProductListViewModel.product[0].fewspd.GetValueOrDefault();
					if (PrdInvStockDisplayType == 1)
					{
						result = valueOrDefault2.ToString();
					}
					else
					{
						result = valueOrDefault.ToString();
					}
				}
				else
				{
					string message2 = resourceManager.Get("msgErrorRunFunction", collation, resourceManager.TypeMsg) + " (get product information from Holoo) ";
					Exception e2 = new Exception(message2);
					ErrorSignal.FromCurrentContext().Raise(e2);
					errorMessage = resourceManager.Get("frmError", collation, resourceManager.TypeLbl);
				}
			}
			else
			{
				string message3 = resourceManager.Get("msgErrorRunFunction", collation, resourceManager.TypeMsg) + " (get product information from Holoo) ";
				Exception e3 = new Exception(message3);
				ErrorSignal.FromCurrentContext().Raise(e3);
				errorMessage = resourceManager.Get("frmError", collation, resourceManager.TypeLbl);
			}
		}
	}

	private readonly CRMEntities _db = new CRMEntities();

	private ResourceManager RS = new ResourceManager();

	public static string GetPrdQuantity(int currUserId, int prdId = 0, int whId = 0, string linkAccWhId = "", string tracing = "", int cmpId = 0, int currLangID = 0, int defLangID = 0, string sefaresh = "", int linkAccSettingDBId = 0)
	{
		string result = "";
		try
		{
			ApiOtherSystemsController apiOtherSystemsController = new ApiOtherSystemsController();
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)new CRMEntities().ApispSelectCrmsysSetting());
			int num = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				num = apispSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
			}
			switch (num)
			{
			case 3:
			{
				decimal prdPrice = default(decimal);
				double prdQuantity = 0.0;
				string text = apiOtherSystemsController.TarazGetPrdQuantityAndPrice(prdId, cmpId, whId, 0, ref prdPrice, ref prdQuantity, "pord", currUserId, currLangID, defLangID);
				result = prdQuantity.ToString();
				break;
			}
			case 4:
				result = apiOtherSystemsController.HolooGetPrdQuantity(prdId, currLangID, defLangID, linkAccSettingDBId);
				break;
			case 11:
				result = apiOtherSystemsController.ShomaranGetPrdQuantity(prdId, whId, linkAccWhId, tracing, sefaresh, currLangID, defLangID);
				break;
			case 12:
				result = apiOtherSystemsController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing, "", currLangID, defLangID);
				break;
			default:
				result = apiOtherSystemsController.LinkAccGetPrdQuantity(num, prdId, whId, linkAccWhId, tracing, "", currLangID, defLangID);
				break;
			case 0:
			case 6:
			case 7:
				break;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static TimeSpan RestApiTimeout(int day = 0, int hour = 0, int min = 0, int sec = 0, int milisec = 0)
	{
		if (day <= 0 && hour <= 0 && min <= 0 && sec <= 0 && milisec <= 0)
		{
			min = 20;
		}
		return new TimeSpan(day, hour, min, sec, milisec);
	}

	public string TarazGetPrdQuantityAndPrice(int linkAccSystemId, int prdId, int cmpId, int whId, int prdPriceGroupId, ref decimal prdPrice, ref double prdQuantity, string CrmOrdType = "pord", int currLangId = 1065, int defLangId = 1065, int centerId = 0, string centerCode = "")
	{
		string result = "0";
		try
		{
			if (cmpId <= 0)
			{
				result = "0";
			}
			else if (prdId <= 0)
			{
				result = "0";
			}
			else if (whId <= 0)
			{
				result = "0";
			}
			else
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)_db.ApispSelectProductsWithId(prdId, currLangId, defLangId));
				if (apispSelectProductsWithId_Result != null)
				{
					ApispSelectCompanyById_Result apispSelectCompanyById_Result = Enumerable.FirstOrDefault<ApispSelectCompanyById_Result>((IEnumerable<ApispSelectCompanyById_Result>)_db.ApispSelectCompanyById(cmpId, currLangId, defLangId, centerId, centerCode));
					if (apispSelectCompanyById_Result != null)
					{
						ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
						List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)_db.ApispSelectWareHouseWithAccLinkField(false, false, false, false, currLangId, defLangId));
						if (list != null)
						{
							apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
						}
						if (apispSelectWareHouseWithAccLinkField_Result != null)
						{
							if (!string.IsNullOrEmpty(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								if (!string.IsNullOrEmpty(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
								{
									if (!string.IsNullOrEmpty(apispSelectCompanyById_Result.cmpLinkAccCustomerIdStr))
									{
										List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list2 = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_db.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSystemId, 0, "Setting", currLangId, defLangId, 0));
										if (list2 != null)
										{
											string text = "";
											ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list2, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 1));
											if (apispSelectLinkAccSettingByLinkAccSystemId_Result != null)
											{
												text = apispSelectLinkAccSettingByLinkAccSystemId_Result.PartValue ?? "";
											}
											string value = "";
											string text2 = "";
											ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result2 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list2, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 2));
											if (apispSelectLinkAccSettingByLinkAccSystemId_Result2 != null)
											{
												text2 = apispSelectLinkAccSettingByLinkAccSystemId_Result2.PartValue ?? "";
											}
											string text3 = "";
											ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result3 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list2, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 3));
											if (apispSelectLinkAccSettingByLinkAccSystemId_Result3 != null)
											{
												text3 = apispSelectLinkAccSettingByLinkAccSystemId_Result3.PartValue ?? "";
											}
											ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result4 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list2, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 6));
											if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
											{
												if (!text.EndsWith("/"))
												{
													text += "/";
												}
												if (string.IsNullOrWhiteSpace(value))
												{
													TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
													tarazGetAuthViewModel.username = text2;
													tarazGetAuthViewModel.password = text3;
													string text4 = "tws/authenticate";
													HttpClient httpClient = new HttpClient();
													httpClient.Timeout = RestApiTimeout();
													httpClient.BaseAddress = new Uri(text + text4);
													httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
													string content = JsonConvert.SerializeObject(tarazGetAuthViewModel);
													HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
													HttpResponseMessage result2 = httpClient.PostAsync(text + text4, content2).Result;
													if (result2.IsSuccessStatusCode)
													{
														string result3 = result2.Content.ReadAsStringAsync().Result;
														TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result3);
														if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
														{
															value = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
														}
														else
														{
															result = "0";
														}
													}
													else
													{
														result = "0";
													}
												}
												if (string.IsNullOrWhiteSpace(value))
												{
													result = "0";
												}
												if (!string.IsNullOrWhiteSpace(value))
												{
													string text5 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
													HttpClient httpClient2 = new HttpClient();
													httpClient2.Timeout = RestApiTimeout();
													httpClient2.BaseAddress = new Uri(text);
													httpClient2.DefaultRequestHeaders.Add("Authorization", value);
													httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
													string text6 = "6001";
													List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list3 = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_db.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSystemId, 0, "VoucherType", currLangId, defLangId, 0));
													if (list3 != null)
													{
														string text7 = "";
														ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result5 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list3, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 10));
														if (apispSelectLinkAccSettingByLinkAccSystemId_Result5 != null)
														{
															text7 = apispSelectLinkAccSettingByLinkAccSystemId_Result5.PartValue ?? "";
														}
														if (!string.IsNullOrEmpty(text7))
														{
															text6 = text7;
														}
													}
													if (string.IsNullOrEmpty(text6))
													{
														text6 = "6001";
													}
													string requestUri = "tws/sale/goods?voucherDate=" + text5 + "&voucherTypeID=" + text6 + "&customerID=" + apispSelectCompanyById_Result.cmpLinkAccCustomerIdStr + "&goodsCode=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode + "&storeID=" + apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
													HttpResponseMessage result4 = httpClient2.GetAsync(requestUri).Result;
													if (result4.IsSuccessStatusCode)
													{
														string result5 = result4.Content.ReadAsStringAsync().Result;
														List<TarazSaleGoodsViewModel> list4 = JsonConvert.DeserializeObject<List<TarazSaleGoodsViewModel>>(result5);
														if (list4 != null)
														{
															long prdLinkAccPrdIdStr = 0L;
															long.TryParse(apispSelectProductsWithId_Result.PrdLinkAccPrdIdStr, out prdLinkAccPrdIdStr);
															TarazSaleGoodsViewModel tarazSaleGoodsViewModel = Enumerable.FirstOrDefault<TarazSaleGoodsViewModel>((IEnumerable<TarazSaleGoodsViewModel>)list4, (Func<TarazSaleGoodsViewModel, bool>)((TarazSaleGoodsViewModel m) => m.goodsID == prdLinkAccPrdIdStr));
															if (tarazSaleGoodsViewModel != null)
															{
																prdPrice = tarazSaleGoodsViewModel.price.GetValueOrDefault();
																prdQuantity = tarazSaleGoodsViewModel.remain.GetValueOrDefault();
																result = "0";
															}
															else
															{
																result = "0";
															}
														}
														else
														{
															result = "0";
														}
													}
													else
													{
														result = "0";
													}
												}
											}
											else
											{
												result = "0";
											}
										}
										else
										{
											result = "0";
										}
									}
									else
									{
										result = "0";
									}
								}
								else
								{
									result = "0";
								}
							}
							else
							{
								result = "0";
							}
						}
						else
						{
							result = "0";
						}
					}
					else
					{
						result = "0";
					}
				}
				else
				{
					result = "0";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string HolooGetPrdQuantity(int linkAccSystemId, int prdId, int currLangID, int defLangID)
	{
		string result = "0";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)_db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result != null)
				{
					if (!string.IsNullOrEmpty(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
					{
						List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)_db.ApispSelectLinkAccSettingByLinkAccSystemId(linkAccSystemId, 0, "Setting", currLangID, defLangID, 0));
						if (list != null)
						{
							string text = "";
							ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 1));
							if (apispSelectLinkAccSettingByLinkAccSystemId_Result != null)
							{
								text = apispSelectLinkAccSettingByLinkAccSystemId_Result.PartValue ?? "";
							}
							string text2 = "";
							ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result2 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 2));
							if (apispSelectLinkAccSettingByLinkAccSystemId_Result2 != null)
							{
								text2 = apispSelectLinkAccSettingByLinkAccSystemId_Result2.PartValue ?? "";
							}
							string text3 = "";
							ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result3 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 3));
							if (apispSelectLinkAccSettingByLinkAccSystemId_Result3 != null)
							{
								text3 = apispSelectLinkAccSettingByLinkAccSystemId_Result3.PartValue ?? "";
							}
							string text4 = "";
							ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result4 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 4));
							if (apispSelectLinkAccSettingByLinkAccSystemId_Result4 != null)
							{
								text4 = apispSelectLinkAccSettingByLinkAccSystemId_Result4.PartValue ?? "";
							}
							string s = "";
							ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result5 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result m) => m.LinkAccSettingId == 6));
							if (apispSelectLinkAccSettingByLinkAccSystemId_Result5 != null)
							{
								s = apispSelectLinkAccSettingByLinkAccSystemId_Result5.PartValue ?? "";
							}
							string text5 = "";
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text.EndsWith("/"))
								{
									text += "/";
								}
								HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
								holooLoginViewModel.userinfo = new HolooUserInfoViewModel
								{
									dbname = text2,
									username = text3,
									userpass = text4
								};
								string text6 = "api/Login";
								HttpClient httpClient = new HttpClient();
								httpClient.Timeout = RestApiTimeout();
								httpClient.BaseAddress = new Uri(text + text6);
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								string content = JsonConvert.SerializeObject(holooLoginViewModel);
								HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
								HttpResponseMessage result2 = httpClient.PostAsync(text + text6, content2).Result;
								if (!result2.IsSuccessStatusCode)
								{
									return result;
								}
								string result3 = result2.Content.ReadAsStringAsync().Result;
								HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result3);
								if (holooLoginResultViewModel == null)
								{
									return result;
								}
								if (holooLoginResultViewModel.Login == null)
								{
									return result;
								}
								if (!holooLoginResultViewModel.Login.State)
								{
									return result;
								}
								text5 = holooLoginResultViewModel.Login.Token ?? "";
								if (string.IsNullOrWhiteSpace(text5))
								{
									return result;
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									string text7 = "?code=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode;
									if (!string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.FGLinkAccGroupIdStr))
									{
										text7 = text7 + "&maingrouperpcode=" + apispSelectProductsWithId_Result.FGLinkAccGroupIdStr;
									}
									if (!string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.SGLinkAccGroupIdStr))
									{
										text7 = text7 + "&sidegrouperpcode=" + apispSelectProductsWithId_Result.SGLinkAccGroupIdStr;
									}
									HttpClient httpClient2 = new HttpClient();
									httpClient2.Timeout = RestApiTimeout();
									httpClient2.BaseAddress = new Uri(text);
									httpClient2.DefaultRequestHeaders.Add("Authorization", text5);
									httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "api/Product" + text7;
									HttpResponseMessage result4 = httpClient2.GetAsync(requestUri).Result;
									if (result4.IsSuccessStatusCode)
									{
										string result5 = result4.Content.ReadAsStringAsync().Result;
										HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result5);
										if (holooProductListViewModel != null)
										{
											if (holooProductListViewModel.product != null)
											{
												if (holooProductListViewModel.product.Count != 1)
												{
													result = "0";
												}
												else
												{
													double valueOrDefault = holooProductListViewModel.product[0].Few.GetValueOrDefault();
													double valueOrDefault2 = holooProductListViewModel.product[0].fewspd.GetValueOrDefault();
													int result6 = 0;
													int.TryParse(s, out result6);
													result = ((result6 != 1) ? valueOrDefault.ToString() : valueOrDefault2.ToString());
												}
											}
										}
										else
										{
											result = "0";
										}
									}
									else
									{
										result = "0";
									}
								}
							}
							else
							{
								result = "0";
							}
						}
						else
						{
							result = "0";
						}
					}
					else
					{
						result = "0";
					}
				}
				else
				{
					result = "0";
				}
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string ShomaranGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", string tracing = "", string sefaresh = "", int currLangID = 1065, int defLangID = 1065)
	{
		string result = "0";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)_db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					result = "0";
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)_db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							result = "0";
						}
						else
						{
							List<ApispLkShomaranReturnProductQuantity_Result> list2 = Enumerable.ToList<ApispLkShomaranReturnProductQuantity_Result>((IEnumerable<ApispLkShomaranReturnProductQuantity_Result>)_db.ApispLkShomaranReturnProductQuantity(prdId, whId, linkAccWhId, tracing, sefaresh, currLangID, defLangID));
							decimal num = default(decimal);
							if (list2 != null && Enumerable.Any<ApispLkShomaranReturnProductQuantity_Result>((IEnumerable<ApispLkShomaranReturnProductQuantity_Result>)list2))
							{
								foreach (ApispLkShomaranReturnProductQuantity_Result item in list2)
								{
									num += item.sumaount.GetValueOrDefault();
								}
							}
							result = num.ToString();
						}
					}
					else
					{
						result = "0";
					}
				}
				else
				{
					result = "0";
				}
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string Arpa_GetToken(int currLangID, int defLangID)
	{
		string text = "";
		try
		{
			ArpaSettingViewModel arpaSetting = GetArpaSetting(0, "", currLangID, defLangID);
			if (arpaSetting != null)
			{
				string text2 = arpaSetting.ArpaServerAddress ?? "";
				string text3 = arpaSetting.ArpaUserName ?? "";
				string text4 = arpaSetting.ArpaPassword ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
				{
					text2 += "serv/";
				}
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					HttpClient httpClient = new HttpClient();
					string text5 = string.Format(text2 + "token/GetServiceToken?username={0}&password={1}", text3, text4);
					httpClient.BaseAddress = new Uri(text5);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					string content = "";
					HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text5, content2).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						string text6 = result2;
						if (!string.IsNullOrWhiteSpace(text6))
						{
							text = text6 ?? "";
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = "Bearer " + text;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	public static ArpaSettingViewModel GetArpaSetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		ArpaSettingViewModel arpaSettingViewModel = new ArpaSettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(12, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				arpaSettingViewModel.ArpaServerAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaServerAddress")).PartValue;
				arpaSettingViewModel.ArpaUserName = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaUserName")).PartValue;
				arpaSettingViewModel.ArpaPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ArpaPassword")).PartValue;
				arpaSettingViewModel.DefUserGroupId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefUserGroupId")).PartValue;
			}
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(12, settingId, "Product", currLangID, defLangID, 0));
			if (list != null && Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				arpaSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(12, settingId, "Warehouse", currLangID, defLangID, 0));
			if (list != null && Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				arpaSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
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
		return arpaSettingViewModel;
	}

	public string ArpaGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int currLangID = 1065, int defLangID = 1065)
	{
		string result = "0";
		try
		{
			if (prdId > 0)
			{
				ApispSelectProductsWithId_Result apispSelectProductsWithId_Result = Enumerable.FirstOrDefault<ApispSelectProductsWithId_Result>((IEnumerable<ApispSelectProductsWithId_Result>)_db.ApispSelectProductsWithId(prdId, currLangID, defLangID));
				if (apispSelectProductsWithId_Result == null)
				{
					result = "0";
				}
				if (apispSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(apispSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					ApispSelectWareHouseWithAccLinkField_Result apispSelectWareHouseWithAccLinkField_Result = new ApispSelectWareHouseWithAccLinkField_Result();
					List<ApispSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)_db.ApispSelectWareHouseWithAccLinkField(false, false, false, true, currLangID, defLangID));
					if (list != null)
					{
						apispSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<ApispSelectWareHouseWithAccLinkField_Result>((IEnumerable<ApispSelectWareHouseWithAccLinkField_Result>)list, (Func<ApispSelectWareHouseWithAccLinkField_Result, bool>)((ApispSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (apispSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							result = "0";
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel == null || string.IsNullOrWhiteSpace(linkAccWhId))
								{
									commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2);
								}
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								linkWhId = apispSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								string value = Arpa_GetToken(currLangID, defLangID);
								if (!string.IsNullOrWhiteSpace(value))
								{
									ArpaSettingViewModel arpaSetting = GetArpaSetting(0, "", currLangID, defLangID);
									if (arpaSetting != null)
									{
										string text = arpaSetting.ArpaServerAddress ?? "";
										if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
										{
											text += "serv/";
										}
										if (!string.IsNullOrWhiteSpace(text))
										{
											string text2 = "?ItemCode=" + apispSelectProductsWithId_Result.PrdLinkAccPrdCode;
											HttpClient httpClient = new HttpClient();
											string text3 = text + "api/GetStockByDetails" + text2;
											httpClient.BaseAddress = new Uri(text3);
											httpClient.DefaultRequestHeaders.Add("Authorization", value);
											httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
											string content = "";
											HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
											HttpResponseMessage result2 = httpClient.PostAsync(text3, content2).Result;
											if (result2.IsSuccessStatusCode)
											{
												string value2 = result2.Content.ReadAsStringAsync().Result;
												if (!string.IsNullOrWhiteSpace(value2))
												{
													value2 = value2.ClearHiddenCharacters();
												}
												ArpaProductQuantityResponseViewModel arpaProductQuantityResponseViewModel = JsonConvert.DeserializeObject<ArpaProductQuantityResponseViewModel>(value2);
												if (arpaProductQuantityResponseViewModel != null && arpaProductQuantityResponseViewModel.data != null && Enumerable.Any<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data))
												{
													ArpaProductQuantityInfoViewModel arpaProductQuantityInfoViewModel = Enumerable.FirstOrDefault<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data, (Func<ArpaProductQuantityInfoViewModel, bool>)((ArpaProductQuantityInfoViewModel m) => m.StockAreaID == linkWhId));
													decimal num = default(decimal);
													if (arpaProductQuantityInfoViewModel != null)
													{
														num = arpaProductQuantityInfoViewModel.Qty.GetValueOrDefault();
													}
													result = num.ToString();
												}
											}
										}
									}
								}
							}
							else
							{
								result = "0";
							}
						}
					}
					else
					{
						result = "0";
					}
				}
				else
				{
					result = "0";
				}
			}
			else
			{
				result = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public static ShygunSettingViewModel GetShygunSetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		ShygunSettingViewModel shygunSettingViewModel = new ShygunSettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 8;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				string partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunAllowRowSecurity")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue) && partValue == "1")
				{
					shygunSettingViewModel.AllowRowSecurity = true;
				}
				else
				{
					shygunSettingViewModel.AllowRowSecurity = false;
				}
				shygunSettingViewModel.AuthUser = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunAuthUser")).PartValue;
				shygunSettingViewModel.AuthPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunAuthPassword")).PartValue;
				shygunSettingViewModel.DataBaseName = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunDataBaseName")).PartValue;
				shygunSettingViewModel.DBUserName = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunDBUserName")).PartValue;
				shygunSettingViewModel.DBPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunDBPassword")).PartValue;
				partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunLanguage")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.Language = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunLanguage")).PartValue);
				}
				else
				{
					shygunSettingViewModel.Language = 3;
				}
				partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunLevel")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.Level = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunLevel")).PartValue);
				}
				else
				{
					shygunSettingViewModel.Level = 0;
				}
				shygunSettingViewModel.Server = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunServer")).PartValue;
				partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunFrom")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.From = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunFrom")).PartValue);
				}
				else
				{
					shygunSettingViewModel.From = 0;
				}
				partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunTo")).PartValue;
				if (!string.IsNullOrWhiteSpace(partValue))
				{
					shygunSettingViewModel.To = int.Parse(Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunTo")).PartValue);
				}
				else
				{
					shygunSettingViewModel.To = 0;
				}
				shygunSettingViewModel.IP = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ShygunIP")).PartValue;
				ShygunConfig shygunConfig = new ShygunConfig();
				shygunConfig.AllowRowSecurity = shygunSettingViewModel.AllowRowSecurity;
				shygunConfig.AuthUser = shygunSettingViewModel.AuthUser;
				shygunConfig.AuthPassword = shygunSettingViewModel.AuthPassword;
				shygunConfig.DataBaseName = shygunSettingViewModel.DataBaseName;
				shygunConfig.DBUserName = shygunSettingViewModel.DBUserName;
				shygunConfig.DBPassword = shygunSettingViewModel.DBPassword;
				shygunConfig.Language = shygunSettingViewModel.Language;
				shygunConfig.Level = shygunSettingViewModel.Level;
				shygunConfig.Server = shygunSettingViewModel.Server;
				shygunSettingViewModel.conf = shygunConfig;
				shygunSettingViewModel.OrdTax = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefTaxAccLink")).PartValue ?? "";
				shygunSettingViewModel.OrdTaxFieldTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefTaxAccLink")).PartLabelTitle;
				shygunSettingViewModel.OrdCurrencyUnit = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefCurrencyUnitId")).PartValue ?? "";
			}
			objectType = "CompanyType";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				shygunSettingViewModel.CmpMoeinAccCode = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CmpMoeinAccCode")).PartValue;
			}
			objectType = "ProductPrice";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				shygunSettingViewModel.PrdPriceGroup = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdPriceGroup")).PartValue ?? "";
			}
			objectType = "Order";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				shygunSettingViewModel.OrdRound = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "OrdRound")).PartValue ?? "";
				shygunSettingViewModel.OrdRoundFieldTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "OrdRound")).PartLabelTitle;
				shygunSettingViewModel.OrdTransportation = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "OrdTransportation")).PartValue ?? "";
				shygunSettingViewModel.OrdTransportationFieldTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "OrdTransportation")).PartLabelTitle;
			}
			objectType = "CmpProject";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				string partValue2 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefPrjCvnsStatusGroupId")).PartValue;
				shygunSettingViewModel.DefPrjCvnsStatusGroupId = ((!string.IsNullOrWhiteSpace(partValue2)) ? int.Parse(partValue2) : 0);
				shygunSettingViewModel.DefPrjTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DefPrjTitle")).PartValue ?? "";
			}
			objectType = "Wrhs";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				string partValue3 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				shygunSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue3)) ? int.Parse(partValue3) : 0);
			}
			objectType = "PrdGroup";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				string partValue4 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdGroupSyncTypeId")).PartValue;
				shygunSettingViewModel.PrdGroupSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue4)) ? int.Parse(partValue4) : 0);
			}
			objectType = "Prd";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				string partValue5 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				shygunSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
			}
			objectType = "Doc";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				shygunSettingViewModel.DocMovementAccountNumber = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DocMovementAccountNumber")).PartValue;
				shygunSettingViewModel.DocMovementAccountNumber_PartLabelTitle = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DocMovementAccountNumber")).PartLabelTitle;
				shygunSettingViewModel.DocMovementAccountGUId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DocMovementAccountGUId")).PartValue;
				shygunSettingViewModel.DocMovementAccountGUId_Id = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "DocMovementAccountGUId")).LinkAccSettingId;
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
		return shygunSettingViewModel;
	}

	public static HamrahanSettingViewModel GetHamrahanSetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		HamrahanSettingViewModel hamrahanSettingViewModel = new HamrahanSettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 17;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				hamrahanSettingViewModel.HamrahanApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersion = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiVersion")).PartValue;
				hamrahanSettingViewModel.HamrahanApiVersionDefineCmp = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiVersionDefineCmp")).PartValue;
				hamrahanSettingViewModel.HamrahanApiKey = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiKey")).PartValue;
				hamrahanSettingViewModel.HamrahanCompanyId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CompanyId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrentFiscalYear = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrentFiscalYear")).PartValue;
				hamrahanSettingViewModel.HamrahanApiUserId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUserId")).PartValue;
				hamrahanSettingViewModel.HamrahanCurrencyUnit = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrencyUnit")).PartValue;
			}
			objectType = "Product";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null && Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")) != null)
			{
				string partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "PrdLinkedField")).PartValue;
				hamrahanSettingViewModel.PrdLinkedField = ((!string.IsNullOrWhiteSpace(partValue)) ? partValue : "");
			}
			objectType = "Company";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null)
			{
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalStateFormal")) != null)
				{
					string partValue2 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalStateFormal")).PartValue;
					hamrahanSettingViewModel.LegalStateFormal = ((!string.IsNullOrWhiteSpace(partValue2)) ? partValue2 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealStateFormal")) != null)
				{
					string partValue3 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealStateFormal")).PartValue;
					hamrahanSettingViewModel.RealStateFormal = ((!string.IsNullOrWhiteSpace(partValue3)) ? partValue3 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalCompanyType")) != null)
				{
					string partValue4 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalCompanyType")).PartValue;
					hamrahanSettingViewModel.LegalCompanyType = ((!string.IsNullOrWhiteSpace(partValue4)) ? partValue4 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexOwner")) != null)
				{
					string partValue5 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexOwner")).PartValue;
					hamrahanSettingViewModel.RealIndexOwner = ((!string.IsNullOrWhiteSpace(partValue5)) ? partValue5 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexState")) != null)
				{
					string partValue6 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexState")).PartValue;
					hamrahanSettingViewModel.RealIndexState = ((!string.IsNullOrWhiteSpace(partValue6)) ? partValue6 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexClass")) != null)
				{
					string partValue7 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexClass")).PartValue;
					hamrahanSettingViewModel.RealIndexClass = ((!string.IsNullOrWhiteSpace(partValue7)) ? partValue7 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexKind")) != null)
				{
					string partValue8 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexKind")).PartValue;
					hamrahanSettingViewModel.RealIndexKind = ((!string.IsNullOrWhiteSpace(partValue8)) ? partValue8 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexCredit")) != null)
				{
					string partValue9 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "RealIndexCredit")).PartValue;
					hamrahanSettingViewModel.RealIndexCredit = ((!string.IsNullOrWhiteSpace(partValue9)) ? partValue9 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexOwner")) != null)
				{
					string partValue10 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexOwner")).PartValue;
					hamrahanSettingViewModel.LegalIndexOwner = ((!string.IsNullOrWhiteSpace(partValue10)) ? partValue10 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexState")) != null)
				{
					string partValue11 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexState")).PartValue;
					hamrahanSettingViewModel.LegalIndexState = ((!string.IsNullOrWhiteSpace(partValue11)) ? partValue11 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexClass")) != null)
				{
					string partValue12 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexClass")).PartValue;
					hamrahanSettingViewModel.LegalIndexClass = ((!string.IsNullOrWhiteSpace(partValue12)) ? partValue12 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexKind")) != null)
				{
					string partValue13 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexKind")).PartValue;
					hamrahanSettingViewModel.LegalIndexKind = ((!string.IsNullOrWhiteSpace(partValue13)) ? partValue13 : "");
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexCredit")) != null)
				{
					string partValue14 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "LegalIndexCredit")).PartValue;
					hamrahanSettingViewModel.LegalIndexCredit = ((!string.IsNullOrWhiteSpace(partValue14)) ? partValue14 : "");
				}
			}
			objectType = "Warehouse";
			list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, 0));
			if (list != null && Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")) != null)
			{
				string partValue15 = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "WrhsSyncTypeId")).PartValue;
				hamrahanSettingViewModel.WrhsSyncTypeId = ((!string.IsNullOrWhiteSpace(partValue15)) ? int.Parse(partValue15) : 0);
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
		return hamrahanSettingViewModel;
	}

	public static NilramSettingViewModel GetNilramSetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		NilramSettingViewModel nilramSettingViewModel = new NilramSettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 20;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, value2));
			if (list != null)
			{
				nilramSettingViewModel.ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				nilramSettingViewModel.ApiToken = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiToken")).PartValue;
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
		return nilramSettingViewModel;
	}

	public static NoAvaranCapillarySettingViewModel GetNoAvaranCapillarySetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		NoAvaranCapillarySettingViewModel noAvaranCapillarySettingViewModel = new NoAvaranCapillarySettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 18;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, value2));
			if (list != null)
			{
				noAvaranCapillarySettingViewModel.ApiUserId = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUserId")).PartValue;
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
		return noAvaranCapillarySettingViewModel;
	}

	public static RahkaranRetailSettingViewModel GetRahkaranRetailSetting(int settingId = 0, string objectType = "", int currLangID = 1065, int defLangID = 1065)
	{
		RahkaranRetailSettingViewModel rahkaranRetailSettingViewModel = new RahkaranRetailSettingViewModel();
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 19;
			int value2 = -1;
			if (settingId < 0)
			{
				settingId = 0;
			}
			if (string.IsNullOrWhiteSpace(objectType))
			{
				objectType = "Setting";
			}
			List<ApispSelectLinkAccSettingByLinkAccSystemId_Result> list = Enumerable.ToList<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)cRMEntities.ApispSelectLinkAccSettingByLinkAccSystemId(value, settingId, objectType, currLangID, defLangID, value2));
			if (list != null)
			{
				rahkaranRetailSettingViewModel.ApiAddress = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiAddress")).PartValue;
				rahkaranRetailSettingViewModel.ApiUsername = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiUsername")).PartValue;
				rahkaranRetailSettingViewModel.ApiPassword = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiPassword")).PartValue;
				rahkaranRetailSettingViewModel.ApiMachineName = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiMachineName")).PartValue;
				rahkaranRetailSettingViewModel.ApiCookieName = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiCookieName")).PartValue;
				ApispSelectLinkAccSettingByLinkAccSystemId_Result apispSelectLinkAccSettingByLinkAccSystemId_Result = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "ApiCookie"));
				if (apispSelectLinkAccSettingByLinkAccSystemId_Result != null)
				{
					rahkaranRetailSettingViewModel.ApiCookie = apispSelectLinkAccSettingByLinkAccSystemId_Result.PartValue;
					rahkaranRetailSettingViewModel.ApiCookieLinkAccSettingId = apispSelectLinkAccSettingByLinkAccSystemId_Result.LinkAccSettingId;
				}
				if (Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrencyRef")) != null)
				{
					string partValue = Enumerable.FirstOrDefault<ApispSelectLinkAccSettingByLinkAccSystemId_Result>((IEnumerable<ApispSelectLinkAccSettingByLinkAccSystemId_Result>)list, (Func<ApispSelectLinkAccSettingByLinkAccSystemId_Result, bool>)((ApispSelectLinkAccSettingByLinkAccSystemId_Result x) => x.PartTitle == "CurrencyRef")).PartValue;
					rahkaranRetailSettingViewModel.CurrencyRef = ((!string.IsNullOrWhiteSpace(partValue)) ? int.Parse(partValue) : 0);
				}
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
		return rahkaranRetailSettingViewModel;
	}

	public static string CreateRahkaranCookie(string cookieValue)
	{
		string result = "";
		try
		{
			if (!string.IsNullOrWhiteSpace(cookieValue))
			{
				result = "sg-auth-sg=" + cookieValue + "; Path=/; Expires=" + DateTime.Now.AddYears(1).ToString("r");
				RahkaranRetailSettingViewModel rahkaranRetailSetting = GetRahkaranRetailSetting();
				if (rahkaranRetailSetting != null)
				{
					string text = rahkaranRetailSetting.ApiCookieName ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = text + "=" + cookieValue + "; Path=/; Expires=" + DateTime.Now.AddYears(1).ToString("r");
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public double LinkAccGetPrdQuantity(int prdId, int currCmpId, int currLangID, int defLangID, int whId)
	{
		double result = 0.0;
		string text = "";
		try
		{
			string linkAccWhId = "";
			string tracing = "";
			string text2 = "";
			int result2 = 0;
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)_db.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return 0.0;
			}
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			int result3 = 0;
			int.TryParse(currCmpId.ToString(), out result3);
			switch (result2)
			{
			case 3:
			{
				decimal prdPrice = default(decimal);
				double prdQuantity = 0.0;
				string text3 = TarazGetPrdQuantityAndPrice(result2, prdId, result3, whId, 0, ref prdPrice, ref prdQuantity);
				text = prdQuantity.ToString();
				break;
			}
			case 4:
				text = HolooGetPrdQuantity(result2, prdId, currLangID, defLangID);
				break;
			case 11:
				text = ShomaranGetPrdQuantity(prdId, whId, linkAccWhId, tracing, "", currLangID, defLangID);
				break;
			case 12:
				text = ArpaGetPrdQuantity(prdId, whId, linkAccWhId, currLangID, defLangID);
				break;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				result = 0.0;
			}
			else if (text != RS.Get("frmError", "fa-IR", RS.TypeLbl))
			{
				double.TryParse(text, out result);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = 0.0;
		}
		return result;
	}

	public static ApispSelectCompanyPersonsByID_Result GetCompanyPerson(int? cmpId = 0, int? prsId = 0)
	{
		ApispSelectCompanyPersonsByID_Result apispSelectCompanyPersonsByID_Result = null;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			int value = 1065;
			int value2 = 1065;
			if (apispSelectCompanyPersonsByID_Result == null && prsId.GetValueOrDefault() != 0)
			{
				apispSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<ApispSelectCompanyPersonsByID_Result>((IEnumerable<ApispSelectCompanyPersonsByID_Result>)cRMEntities.ApispSelectCompanyPersonsByID(prsId, value2, value));
			}
			if (apispSelectCompanyPersonsByID_Result == null && cmpId.GetValueOrDefault() != 0)
			{
				ApispSelectCompanyPersonTop1ByOrderView_Result apispSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<ApispSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<ApispSelectCompanyPersonTop1ByOrderView_Result>)cRMEntities.ApispSelectCompanyPersonTop1ByOrderView(cmpId, value2, value));
				if (apispSelectCompanyPersonTop1ByOrderView_Result != null)
				{
					apispSelectCompanyPersonsByID_Result = new ApispSelectCompanyPersonsByID_Result
					{
						CompanyPersonID = apispSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
						prsCompanyId = apispSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
						prsLName = apispSelectCompanyPersonTop1ByOrderView_Result.prsLName,
						prsFName = apispSelectCompanyPersonTop1ByOrderView_Result.prsFName,
						prsTitleId = apispSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
						prsJobId = apispSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
						prsTypeId = apispSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
						prsGroupId = apispSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
						prsSexId = apispSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
						prsEducationId = apispSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
						prsPreTel = apispSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
						prsTel = apispSelectCompanyPersonTop1ByOrderView_Result.prsTel,
						prsTelUpTo = apispSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
						prsTelDesc = apispSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
						prsTelII = apispSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
						prsFax = apispSelectCompanyPersonTop1ByOrderView_Result.prsFax,
						prsFaxDesc = apispSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
						prsMobile = apispSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
						prsWebSite = apispSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
						prsEmail = apispSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
						prsEmailII = apispSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
						prsCountryId = apispSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
						prsProvinceId = apispSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
						prsCityId = apispSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
						prsAddress = apispSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
						prsAddressDesc = apispSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
						prsZipCode = apispSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
						prsPostBox = apispSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
						prsNationalCode = apispSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
						prsIdentityNumber = apispSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
						prsFatherName = apispSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
						prsBirthDate = apispSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
						prsBirthDateTime = apispSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
						prsBirthPlace = apispSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
						prsIsMarried = apispSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
						prsMarriageDate = apispSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
						prsMarriageDateTime = apispSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
						prsEducationField = apispSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
						prsSkill = apispSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
						prsStudyField = apispSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
						prsInteresting = apispSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
						prsSpecialPoint = apispSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
						prsDescription = apispSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
						UserId = apispSelectCompanyPersonTop1ByOrderView_Result.UserId,
						Year1 = apispSelectCompanyPersonTop1ByOrderView_Result.Year1,
						Month1 = apispSelectCompanyPersonTop1ByOrderView_Result.Month1,
						RegisterDate = apispSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
						RegisterDatePersian = apispSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
						AddType = apispSelectCompanyPersonTop1ByOrderView_Result.AddType,
						ImportDate = apispSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
						ImportDateTime = apispSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
						prsFirstRegisterUserId = apispSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
						prsDepartmentId = apispSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
						prsStopSendSms = apispSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
						prsOrderView = apispSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
						prsWorkingOut = apispSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
						GUId = apispSelectCompanyPersonTop1ByOrderView_Result.GUId,
						CompanyPersonTemplateID = apispSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
						LanguageID = apispSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
						FirstRegisterUserId = apispSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
						FirstRegisterDatePersian = apispSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
						FirstRegisterDate = apispSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
						prsTelegramId = apispSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
						PersonName = apispSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
						prsTitle = apispSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
					};
				}
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		finally
		{
			cRMEntities.Dispose();
		}
		return apispSelectCompanyPersonsByID_Result;
	}

	public static bool SendCmpToLinkAccByShpIsActive(int cmpId, int currentCId, string centerCode, ref string errorMsg)
	{
		//IL_010a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a8: Unknown result type (might be due to invalid IL or missing references)
		bool result = true;
		CRMEntities cRMEntities = new CRMEntities();
		try
		{
			ApispSelectCrmsysSetting_Result apispSelectCrmsysSetting_Result = Enumerable.FirstOrDefault<ApispSelectCrmsysSetting_Result>((IEnumerable<ApispSelectCrmsysSetting_Result>)cRMEntities.ApispSelectCrmsysSetting());
			if (apispSelectCrmsysSetting_Result == null)
			{
				return true;
			}
			int result2 = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.DefaultLanguageID.ToString(), out result2);
			}
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int value = result2;
			if (currentCId == 0 && !string.IsNullOrWhiteSpace(centerCode))
			{
				ApispSelectCenterWithCode_Result apispSelectCenterWithCode_Result = Enumerable.FirstOrDefault<ApispSelectCenterWithCode_Result>((IEnumerable<ApispSelectCenterWithCode_Result>)cRMEntities.ApispSelectCenterWithCode(centerCode, value, result2));
				if (apispSelectCenterWithCode_Result != null)
				{
					currentCId = apispSelectCenterWithCode_Result.CenterID;
				}
			}
			if (currentCId == 0)
			{
				result = true;
				return result;
			}
			int result3 = 0;
			if (apispSelectCrmsysSetting_Result != null)
			{
				int.TryParse(apispSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			if (result3 != 21)
			{
				result = true;
				return result;
			}
			ApispSelectCompanyById_Result apispSelectCompanyById_Result = Enumerable.FirstOrDefault<ApispSelectCompanyById_Result>((IEnumerable<ApispSelectCompanyById_Result>)cRMEntities.ApispSelectCompanyById(cmpId, value, result2, currentCId, centerCode));
			if (apispSelectCompanyById_Result != null)
			{
				List<CmpFOInfoViewModel> list = new List<CmpFOInfoViewModel>();
				bool flag = false;
				if (!string.IsNullOrWhiteSpace(apispSelectCompanyById_Result.cmpFOInfo))
				{
					list = new JavaScriptSerializer().Deserialize<List<CmpFOInfoViewModel>>(apispSelectCompanyById_Result.cmpFOInfo);
					if (list != null && Enumerable.Any<CmpFOInfoViewModel>((IEnumerable<CmpFOInfoViewModel>)list))
					{
						foreach (CmpFOInfoViewModel item in list)
						{
							int result4 = 0;
							int.TryParse(item.CId, out result4);
							int result5 = 0;
							int.TryParse(item.ShpAct, out result5);
							if (result4 != 0 && result4 == currentCId && result5 == 1)
							{
								flag = true;
							}
						}
					}
				}
				if (flag)
				{
					string cmpLinkAccData = apispSelectCompanyById_Result.cmpLinkAccData;
					bool flag2 = false;
					if (!string.IsNullOrWhiteSpace(cmpLinkAccData))
					{
						List<LinkAccDataViewModel> list2 = new JavaScriptSerializer().Deserialize<List<LinkAccDataViewModel>>(cmpLinkAccData);
						if (list2 != null && Enumerable.Any<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2))
						{
							foreach (LinkAccDataViewModel item2 in list2)
							{
								int valueOrDefault = item2.CId.GetValueOrDefault();
								if (valueOrDefault != 0 && valueOrDefault == currentCId && !flag2)
								{
									flag2 = true;
								}
							}
						}
					}
					if (flag2)
					{
						result = true;
					}
					else
					{
						HamyarProvider hamyarProvider = new HamyarProvider(true);
						string text = hamyarProvider.SendCompany(cmpId, currentCId, null, null, false);
						if (!string.IsNullOrEmpty(text))
						{
							string[] array = text.Split(new char[1] { '|' });
							if (array != null)
							{
								if (array[0] == "1")
								{
									if (!string.IsNullOrWhiteSpace(array[1]))
									{
										result = true;
										errorMsg = "";
									}
									else
									{
										result = false;
										errorMsg = Messages.msgErrorRunFunction;
									}
								}
								else
								{
									result = false;
									errorMsg = array[0];
								}
							}
							else
							{
								result = false;
								errorMsg = Messages.msgErrorRunFunction;
							}
						}
						else
						{
							result = false;
							errorMsg = Messages.msgErrorRunFunction;
						}
					}
				}
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
}
