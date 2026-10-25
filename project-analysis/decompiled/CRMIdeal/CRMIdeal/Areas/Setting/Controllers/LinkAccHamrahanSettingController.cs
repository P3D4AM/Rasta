using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccHamrahanSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass19_1
	{
		public CRMspSelectLinkAccHamrahanSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_1
	{
		public CRMspSelectLinkAccHamrahanSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccHamrahanSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpEntities _dbSp = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		GetOrderOpr();
		GetOrdPayType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccHamrahanSetting_Result> list = new List<CRMspSelectLinkAccHamrahanSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)_dbLink.CRMspSelectLinkAccHamrahanSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccHamrahanSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccHamrahanSettingId == 4)
					{
						item.PartValue = "******";
					}
					else
					{
						if (item.LinkAccHamrahanSettingId != 6)
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
							if (item.PartValue.ToLower() == "prdcode")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdCode;
							}
							else if (item.PartValue.ToLower() == "prdfirstbarcode")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdFirstBarcode;
							}
							else if (item.PartValue.ToLower() == "prdmodel")
							{
								item.PartValue = Labels.OtherSystemsLinkedPrdModel;
							}
						}
						else
						{
							item.PartValue = "";
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEdit(string objectType)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccHamrahanSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)_dbLink.CRMspSelectLinkAccHamrahanSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccHamrahanSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccHamrahanSetting_Lang> crmLinkAccHamrahanSetting_Lang = _dbTbl.CrmLinkAccHamrahanSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHamrahanSetting_Lang), "c");
					List<CrmLinkAccHamrahanSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccHamrahanSetting_Lang>((IEnumerable<CrmLinkAccHamrahanSetting_Lang>)Queryable.Where<CrmLinkAccHamrahanSetting_Lang>((IQueryable<CrmLinkAccHamrahanSetting_Lang>)crmLinkAccHamrahanSetting_Lang, Expression.Lambda<Func<CrmLinkAccHamrahanSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccHamrahanSetting> crmLinkAccHamrahanSetting = _dbTbl.CrmLinkAccHamrahanSetting;
					val = Expression.Parameter(typeof(CrmLinkAccHamrahanSetting), "c");
					CrmLinkAccHamrahanSetting crmLinkAccHamrahanSetting2 = Queryable.FirstOrDefault<CrmLinkAccHamrahanSetting>(Queryable.Where<CrmLinkAccHamrahanSetting>((IQueryable<CrmLinkAccHamrahanSetting>)crmLinkAccHamrahanSetting, Expression.Lambda<Func<CrmLinkAccHamrahanSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccHamrahanSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccHamrahanSetting_Lang>)list3, (Func<CrmLinkAccHamrahanSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccHamrahanSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccHamrahanSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccHamrahanSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass7_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass7_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass7_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass7_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass7_.item.PartTitle;
					list.Add(crmLinkAccSettingOtherLanguageViewModel);
				}
			}
			if (objectType == "OrdPayType")
			{
				base.ViewBag.BankAccount = GetHamrahanBankAccountList();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectType = objectType;
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSetting(string setting, string objType)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			new List<CrmLinkAccSettingViewModel>();
			List<CrmLinkAccSettingViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingViewModel>>(setting);
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value = short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value3 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			string text = "";
			string text2 = "";
			foreach (CrmLinkAccSettingViewModel item in list)
			{
				int accSettimgId = item.AccSettimgId;
				string text3 = item.PartValue ?? "";
				string text4 = item.PartField ?? "";
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item.Desc_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = item.Desc,
					LanguageId = lCID
				});
				string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
				{
					foreach (CommonMultiLanguageViewModel item2 in list3)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
					}
				}
				text = text + "[AccSettimgId=" + accSettimgId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
			}
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				_dbLink.CRMspUpdateLinkAccHamrahanSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	public bool checkMultiLanguage(string defaultValue, List<CommonMultiLanguageViewModel> list)
	{
		bool result = true;
		List<CRMspSelectUserLanguages_Result> list2 = CRMIdeal.Cache.User.Language.Get();
		bool isCurrentUserAllowCopyOtherLanguage = UserLogin.IsCurrentUserAllowCopyOtherLanguage;
		foreach (Languages itemLang in CRMIdeal.Cache.Setting.Language.Get())
		{
			CommonMultiLanguageViewModel commonMultiLanguageViewModel = Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == itemLang.LanguageID));
			if (commonMultiLanguageViewModel == null)
			{
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						list.Add(new CommonMultiLanguageViewModel
						{
							LanguageId = itemLang.LanguageID,
							Value = defaultValue
						});
					}
					else
					{
						result = false;
					}
				}
				else
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						LanguageId = itemLang.LanguageID,
						Value = defaultValue
					});
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(commonMultiLanguageViewModel.Value))
				{
					continue;
				}
				if (Enumerable.Any<CRMspSelectUserLanguages_Result>((IEnumerable<CRMspSelectUserLanguages_Result>)list2, (Func<CRMspSelectUserLanguages_Result, bool>)((CRMspSelectUserLanguages_Result c) => c.LanguageID == itemLang.LanguageID)))
				{
					if (isCurrentUserAllowCopyOtherLanguage)
					{
						commonMultiLanguageViewModel.Value = defaultValue;
					}
					else
					{
						result = false;
					}
				}
				else
				{
					commonMultiLanguageViewModel.Value = defaultValue;
				}
			}
		}
		return result;
	}

	public string Hamrahan_GetToken()
	{
		string result = "";
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				string text = hamrahanSetting.HamrahanApiAddress ?? "";
				string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
				string text3 = hamrahanSetting.HamrahanApiKey ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					if (!text.EndsWith("api/"))
					{
						text += "api/";
					}
				}
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
				{
					text = text + "v" + text2 + "/";
					HttpClient httpClient = new HttpClient();
					string text4 = string.Format(text + "GetToken?key={0}", text3);
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value))
						{
							value = value.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value))
						{
							HamrahanGetTokenResponseViewModel hamrahanGetTokenResponseViewModel = JsonConvert.DeserializeObject<HamrahanGetTokenResponseViewModel>(value);
							if (hamrahanGetTokenResponseViewModel != null && hamrahanGetTokenResponseViewModel.isSuccess.GetValueOrDefault() && !string.IsNullOrWhiteSpace(hamrahanGetTokenResponseViewModel.token))
							{
								result = "Bearer " + hamrahanGetTokenResponseViewModel.token;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = "";
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHamrahanCompanyGroupsMult()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			int value3 = id;
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value4 = Hamrahan_GetToken();
			if (string.IsNullOrWhiteSpace(value4))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
			string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
			string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			if (!text2.EndsWith("api/"))
			{
				text2 += "api/";
			}
			text2 = text2 + "v" + text3 + "/";
			HttpClient httpClient = new HttpClient();
			string text5 = text2 + "CustomerGroup/company/" + text4;
			httpClient.BaseAddress = new Uri(text5);
			httpClient.DefaultRequestHeaders.Add("Authorization", value4);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
			if (result2.IsSuccessStatusCode)
			{
				string value5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value5))
				{
					value5 = value5.ClearHiddenCharacters();
				}
				if (string.IsNullOrWhiteSpace(value5))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<HamrahanCustomerGroupInfoViewModel> list = JsonConvert.DeserializeObject<List<HamrahanCustomerGroupInfoViewModel>>(value5);
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<HamrahanCustomerGroupInfoViewModel>((IEnumerable<HamrahanCustomerGroupInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<LkCrmCompanyGroupsMultiViewModel> list2 = new List<LkCrmCompanyGroupsMultiViewModel>();
				foreach (HamrahanCustomerGroupInfoViewModel item2 in list)
				{
					if (item2.rnGroupCustomer.GetValueOrDefault() != 0L)
					{
						LkCrmCompanyGroupsMultiViewModel item = new LkCrmCompanyGroupsMultiViewModel
						{
							CompanyGroupsMultiName = item2.groupName,
							LinkAccGroupMultiIdStr = item2.rnGroupCustomer.GetValueOrDefault().ToString()
						};
						list2.Add(item);
					}
				}
				if (list2 == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkCrmCompanyGroupsMultiViewModel>((IEnumerable<LkCrmCompanyGroupsMultiViewModel>)list2))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string companyGroupsMultiJson = JsonConvert.SerializeObject(list2);
				_dbLink.CRMspLkInsertUpdateCompanyGroupsMultiByJson(companyGroupsMultiJson, userId, value2, value3, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyGroupsMulti");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHamrahanCompanyType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			int value3 = id;
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value4 = Hamrahan_GetToken();
			if (string.IsNullOrWhiteSpace(value4))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
			string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
			string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			if (!text2.EndsWith("api/"))
			{
				text2 += "api/";
			}
			text2 = text2 + "v" + text3 + "/";
			HttpClient httpClient = new HttpClient();
			string text5 = text2 + "CustomerGroup/company/" + text4;
			httpClient.BaseAddress = new Uri(text5);
			httpClient.DefaultRequestHeaders.Add("Authorization", value4);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
			if (result2.IsSuccessStatusCode)
			{
				string value5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value5))
				{
					value5 = value5.ClearHiddenCharacters();
				}
				if (string.IsNullOrWhiteSpace(value5))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<HamrahanCustomerGroupInfoViewModel> list = JsonConvert.DeserializeObject<List<HamrahanCustomerGroupInfoViewModel>>(value5);
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<HamrahanCustomerGroupInfoViewModel>((IEnumerable<HamrahanCustomerGroupInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<LkCompanyTypeInfoViewModel> list2 = new List<LkCompanyTypeInfoViewModel>();
				foreach (HamrahanCustomerGroupInfoViewModel item2 in list)
				{
					if (item2.rnGroupCustomer.GetValueOrDefault() != 0L)
					{
						LkCompanyTypeInfoViewModel item = new LkCompanyTypeInfoViewModel
						{
							CompanyTypeName = item2.groupName + ((!string.IsNullOrWhiteSpace(item2.groupCode)) ? (" (" + item2.groupCode + ")") : ""),
							LinkAccCmpTypeIdStr = item2.rnGroupCustomer.GetValueOrDefault().ToString()
						};
						list2.Add(item);
					}
				}
				if (list2 == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkCompanyTypeInfoViewModel>((IEnumerable<LkCompanyTypeInfoViewModel>)list2))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string cmpTypeJson = JsonConvert.SerializeObject(list2);
				_dbLink.CRMspLkInsertUpdateCompanyTypeByJson(cmpTypeJson, userId, value2, value3, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyType");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHamrahanDeliveryTerm()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value3 = Hamrahan_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
			string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
			string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			if (!text2.EndsWith("api/"))
			{
				text2 += "api/";
			}
			text2 = text2 + "v" + text3 + "/";
			HttpClient httpClient = new HttpClient();
			string text5 = text2 + "DefineDeliverySite/company/" + text4;
			httpClient.BaseAddress = new Uri(text5);
			httpClient.DefaultRequestHeaders.Add("Authorization", value3);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
			if (result2.IsSuccessStatusCode)
			{
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				if (string.IsNullOrWhiteSpace(value4))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<HamrahanDeliverySiteInfoViewModel> list = JsonConvert.DeserializeObject<List<HamrahanDeliverySiteInfoViewModel>>(value4);
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<HamrahanDeliverySiteInfoViewModel>((IEnumerable<HamrahanDeliverySiteInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<LkWSDeliveryTermInfoViewModel> list2 = new List<LkWSDeliveryTermInfoViewModel>();
				foreach (HamrahanDeliverySiteInfoViewModel item2 in list)
				{
					if (item2.recNo.GetValueOrDefault() != 0L)
					{
						LkWSDeliveryTermInfoViewModel item = new LkWSDeliveryTermInfoViewModel
						{
							DeliveryTerm = item2.siteName,
							LinkAccDeliveryTermIdStr = item2.recNo.GetValueOrDefault().ToString()
						};
						list2.Add(item);
					}
				}
				if (list2 == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSDeliveryTermInfoViewModel>((IEnumerable<LkWSDeliveryTermInfoViewModel>)list2))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string deliveryTermJson = JsonConvert.SerializeObject(list2);
				_dbLink.CRMspLkWSInsertUpdateDeliveryTermByJson(deliveryTermJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliveryTerms");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHamrahanSaleCenter()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value3 = Hamrahan_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
			string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
			string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			if (!text2.EndsWith("api/"))
			{
				text2 += "api/";
			}
			text2 = text2 + "v" + text3 + "/";
			HttpClient httpClient = new HttpClient();
			string text5 = text2 + "DefineSaleCenter/company/" + text4;
			httpClient.BaseAddress = new Uri(text5);
			httpClient.DefaultRequestHeaders.Add("Authorization", value3);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
			if (result2.IsSuccessStatusCode)
			{
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				if (string.IsNullOrWhiteSpace(value4))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<HamrahanSaleCenterInfoViewModel> list = JsonConvert.DeserializeObject<List<HamrahanSaleCenterInfoViewModel>>(value4);
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<HamrahanSaleCenterInfoViewModel>((IEnumerable<HamrahanSaleCenterInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<LkWSSaleCenterInfoViewModel> list2 = new List<LkWSSaleCenterInfoViewModel>();
				foreach (HamrahanSaleCenterInfoViewModel item in list)
				{
					if (item.recNo.GetValueOrDefault() != 0L)
					{
						LkWSSaleCenterInfoViewModel lkWSSaleCenterInfoViewModel = new LkWSSaleCenterInfoViewModel
						{
							SaleCenterName = item.nameFormal,
							LinkAccSaleCenterIdStr = item.recNo.GetValueOrDefault().ToString()
						};
						HamrahanLinkAccDataViewModel value5 = new HamrahanLinkAccDataViewModel
						{
							refFormal = 0L,
							rnGroupFormal = item.groupFormal.GetValueOrDefault()
						};
						lkWSSaleCenterInfoViewModel.LinkAccData = "[" + JsonConvert.SerializeObject(value5) + "]";
						list2.Add(lkWSSaleCenterInfoViewModel);
					}
				}
				if (list2 == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSSaleCenterInfoViewModel>((IEnumerable<LkWSSaleCenterInfoViewModel>)list2))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string saleCenterJson = JsonConvert.SerializeObject(list2);
				_dbLink.CRMspLkWSInsertUpdateSaleCenterByJson(saleCenterJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSSaleCenters");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHamrahanOrderGroup()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value3 = Hamrahan_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
			string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
			string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			if (!text2.EndsWith("api/"))
			{
				text2 += "api/";
			}
			text2 = text2 + "v" + text3 + "/";
			HttpClient httpClient = new HttpClient();
			string text5 = text2 + "CustomerGroup/company/" + text4;
			httpClient.BaseAddress = new Uri(text5);
			httpClient.DefaultRequestHeaders.Add("Authorization", value3);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			new StringContent("", Encoding.UTF8, "application/json");
			HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
			if (result2.IsSuccessStatusCode)
			{
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				if (string.IsNullOrWhiteSpace(value4))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<HamrahanCustomerGroupInfoViewModel> list = JsonConvert.DeserializeObject<List<HamrahanCustomerGroupInfoViewModel>>(value4);
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<HamrahanCustomerGroupInfoViewModel>((IEnumerable<HamrahanCustomerGroupInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				List<LkWSOrderGroupInfoViewModel> list2 = new List<LkWSOrderGroupInfoViewModel>();
				foreach (HamrahanCustomerGroupInfoViewModel item2 in list)
				{
					if (item2.rnGroupCustomer.GetValueOrDefault() != 0L)
					{
						LkWSOrderGroupInfoViewModel item = new LkWSOrderGroupInfoViewModel
						{
							OrderGroupName = item2.groupName,
							LinkAccGroupIdStr = item2.rnGroupCustomer.GetValueOrDefault().ToString()
						};
						list2.Add(item);
					}
				}
				if (list2 == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSOrderGroupInfoViewModel>((IEnumerable<LkWSOrderGroupInfoViewModel>)list2))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string orderGroupJson = JsonConvert.SerializeObject(list2);
				_dbLink.CRMspLkWSInsertUpdateOrderGroupsByJson(orderGroupJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderGroups");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdPayType()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int value = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserId : 0);
			List<WSspSelectActiveOrderPaymentTypes_Result> list2 = Enumerable.ToList<WSspSelectActiveOrderPaymentTypes_Result>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)_dbI.WSspSelectActiveOrderPaymentTypes(lCID, result, value));
			list.AddRange(Enumerable.Select<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>((IEnumerable<WSspSelectActiveOrderPaymentTypes_Result>)list2, (Func<WSspSelectActiveOrderPaymentTypes_Result, SelectListItem>)((WSspSelectActiveOrderPaymentTypes_Result item) => new SelectListItem
			{
				Text = item.ordpayType,
				Value = item.OrderPaymentTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccHamrahanSettingDetails_Result> list = new List<CRMspSelectLinkAccHamrahanSettingDetails_Result>();
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				List<SelectListItem> list2 = new List<SelectListItem>();
				if (objType == "OrdPayType")
				{
					list2 = GetHamrahanBankAccountList();
				}
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				_dbLink.CRMspInsertLinkAccHamrahanSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				list = Enumerable.ToList<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)_dbLink.CRMspSelectLinkAccHamrahanSettingDetails(0, objId, objType, lCID, result));
				foreach (CRMspSelectLinkAccHamrahanSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.PartTitle ?? "") == "DocumentDateType")
					{
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingPayDocDate;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingPayImportDate;
						}
					}
					else if ((item.PartTitle ?? "") == "DRNAccountBank" && list2 != null && !string.IsNullOrWhiteSpace(item.PartValue) && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list2))
					{
						SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == item.PartValue));
						if (selectListItem != null && !string.IsNullOrWhiteSpace(selectListItem.Text))
						{
							item.PartValue = selectListItem.Text;
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEditDetail(string objType = "", int objId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccHamrahanSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHamrahanSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSettingDetails_Result>)_dbLink.CRMspSelectLinkAccHamrahanSettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccHamrahanSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass19_1 _003C_003Ec__DisplayClass19_ = new _003C_003Ec__DisplayClass19_1();
					_003C_003Ec__DisplayClass19_.item = enumerator.Current;
					DbSet<CrmLinkAccHamrahanSettingDetails_Lang> crmLinkAccHamrahanSettingDetails_Lang = _dbTbl.CrmLinkAccHamrahanSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHamrahanSettingDetails_Lang), "c");
					List<CrmLinkAccHamrahanSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccHamrahanSettingDetails_Lang>((IEnumerable<CrmLinkAccHamrahanSettingDetails_Lang>)Queryable.Where<CrmLinkAccHamrahanSettingDetails_Lang>((IQueryable<CrmLinkAccHamrahanSettingDetails_Lang>)crmLinkAccHamrahanSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccHamrahanSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccHamrahanSettingDetails> crmLinkAccHamrahanSettingDetails = _dbTbl.CrmLinkAccHamrahanSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccHamrahanSettingDetails), "c");
					CrmLinkAccHamrahanSettingDetails crmLinkAccHamrahanSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccHamrahanSettingDetails>(Queryable.Where<CrmLinkAccHamrahanSettingDetails>((IQueryable<CrmLinkAccHamrahanSettingDetails>)crmLinkAccHamrahanSettingDetails, Expression.Lambda<Func<CrmLinkAccHamrahanSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass19_, typeof(_003C_003Ec__DisplayClass19_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (list3 != null)
					{
						list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccHamrahanSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccHamrahanSettingDetails_Lang>)list3, (Func<CrmLinkAccHamrahanSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccHamrahanSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccHamrahanSettingDetails2 != null)
					{
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccHamrahanSettingDetails2.Description,
							LanguageId = result
						});
					}
					text = _003C_003Ec__DisplayClass19_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass19_.item.LinkAccHamrahanSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass19_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass19_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass19_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass19_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass19_.item.LinkAccHamrahanSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass19_.item.PartTitle;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
			}
			if (objType == "OrdPayType")
			{
				base.ViewBag.BankAccount = GetHamrahanBankAccountList();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectTypeTitle = text;
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettingDetails(int objId, string objType, string settingDetail)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_015f: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				List<CrmLinkAccSettingDetailsViewModel> list = new List<CrmLinkAccSettingDetailsViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsViewModel>>(settingDetail);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				string text = "";
				string text2 = "";
				bool flag = true;
				if (list != null && flag && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
				{
					foreach (CrmLinkAccSettingDetailsViewModel item in list)
					{
						int accSdId = item.AccSdId;
						string text3 = item.PartValue ?? "";
						string text4 = item.PartField ?? "";
						List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item.Desc_Lang))
						{
							list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item.Desc_Lang);
						}
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = item.Desc,
							LanguageId = lCID
						});
						string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3))
						{
							foreach (CommonMultiLanguageViewModel item2 in list3)
							{
								text2 = text2 + "[AccSdId=" + accSdId + ",Desc=" + item2.Value + ",LangId=" + item2.LanguageId + ",]|";
							}
						}
						text = text + "[AccSdId=" + accSdId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
					}
					_dbLink.CRMspUpdateLinkAccHamrahanSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetDefaultLinkAccSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				List<CRMspSelectLinkAccHamrahanSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHamrahanSetting_Result>((IEnumerable<CRMspSelectLinkAccHamrahanSetting_Result>)_dbLink.CRMspSelectLinkAccHamrahanSetting(0, objType, currLangID, result));
				if (list2 != null)
				{
					using List<CRMspSelectLinkAccHamrahanSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass21_1 _003C_003Ec__DisplayClass21_ = new _003C_003Ec__DisplayClass21_1();
						_003C_003Ec__DisplayClass21_.item = enumerator.Current;
						DbSet<CrmLinkAccHamrahanSetting_Lang> crmLinkAccHamrahanSetting_Lang = _dbTbl.CrmLinkAccHamrahanSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHamrahanSetting_Lang), "c");
						List<CrmLinkAccHamrahanSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccHamrahanSetting_Lang>((IEnumerable<CrmLinkAccHamrahanSetting_Lang>)Queryable.Where<CrmLinkAccHamrahanSetting_Lang>((IQueryable<CrmLinkAccHamrahanSetting_Lang>)crmLinkAccHamrahanSetting_Lang, Expression.Lambda<Func<CrmLinkAccHamrahanSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass21_, typeof(_003C_003Ec__DisplayClass21_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccHamrahanSetting> crmLinkAccHamrahanSetting = _dbTbl.CrmLinkAccHamrahanSetting;
						val = Expression.Parameter(typeof(CrmLinkAccHamrahanSetting), "c");
						CrmLinkAccHamrahanSetting crmLinkAccHamrahanSetting2 = Queryable.FirstOrDefault<CrmLinkAccHamrahanSetting>(Queryable.Where<CrmLinkAccHamrahanSetting>((IQueryable<CrmLinkAccHamrahanSetting>)crmLinkAccHamrahanSetting, Expression.Lambda<Func<CrmLinkAccHamrahanSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass21_, typeof(_003C_003Ec__DisplayClass21_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccHamrahanSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccHamrahanSetting_Lang>)list3, (Func<CrmLinkAccHamrahanSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccHamrahanSetting_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccHamrahanSetting2.Description,
							LanguageId = result
						});
						CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass21_.item.LinkAccHamrahanSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass21_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass21_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass21_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass21_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass21_.item.PartLabelTitle;
						crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
						crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
						list.Add(crmLinkAccSettingOtherLanguageViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<SelectListItem> GetHamrahanBankAccountList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string value = Hamrahan_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
				if (hamrahanSetting != null)
				{
					string text = hamrahanSetting.HamrahanApiAddress ?? "";
					string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
					string text3 = hamrahanSetting.HamrahanCompanyId ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
					{
						if (!text.EndsWith("/"))
						{
							text += "/";
						}
						if (!text.EndsWith("api/"))
						{
							text += "api/";
						}
						text = text + "v" + text2 + "/";
						HttpClient httpClient = new HttpClient();
						string text4 = text + "BankAccount/company/" + text3;
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							if (!string.IsNullOrWhiteSpace(value2))
							{
								List<HamrahanBankAccountInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanBankAccountInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanBankAccountInfoViewModel>((IEnumerable<HamrahanBankAccountInfoViewModel>)list2))
								{
									list.AddRange(Enumerable.Select<HamrahanBankAccountInfoViewModel, SelectListItem>((IEnumerable<HamrahanBankAccountInfoViewModel>)list2, (Func<HamrahanBankAccountInfoViewModel, SelectListItem>)((HamrahanBankAccountInfoViewModel item) => new SelectListItem
									{
										Text = (item.numberAccount ?? ""),
										Value = item.accountBankRecNo.GetValueOrDefault().ToString(),
										Selected = false
									})));
								}
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
