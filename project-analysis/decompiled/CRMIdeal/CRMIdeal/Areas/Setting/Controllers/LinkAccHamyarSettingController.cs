using System;
using System.Collections.Generic;
using System.Data.Entity;
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

public class LinkAccHamyarSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass18_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpEntities _dbSp = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		GetOrdPayType();
		GetCmpGroupsIII();
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
		List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
		try
		{
			int value = 21;
			int value2 = -1;
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, lCID, result, value, value2, null));
				CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider hamyarProvider = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false);
				List<SelectListItem> moadiType = hamyarProvider.GetMoadiType();
				List<LkCrmCompanyGroupsIIIViewModel> vahed = hamyarProvider.GetVahed();
				foreach (CRMspSelectLinkAccSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.ObjectType ?? "") == "Setting" && ((item.PartTitle ?? "") == "ApiKey" || (item.PartTitle ?? "") == "ApiPassword"))
					{
						item.PartValue = "******";
					}
					else if ((item.ObjectType ?? "") == "Company" && ((item.PartTitle ?? "") == "LegalMoadiType" || (item.PartTitle ?? "") == "RealMoadiType"))
					{
						SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)moadiType, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.PartValue));
						if (selectListItem != null)
						{
							item.PartValue = selectListItem.Text;
						}
					}
					else if ((item.ObjectType ?? "") == "Company" && (item.PartTitle ?? "") == "NoeVahed")
					{
						LkCrmCompanyGroupsIIIViewModel lkCrmCompanyGroupsIIIViewModel = Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)vahed, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.LinkAccId == item.PartValue));
						if (lkCrmCompanyGroupsIIIViewModel != null)
						{
							item.PartValue = lkCrmCompanyGroupsIIIViewModel.LinkAccName;
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
			int value = 21;
			int value2 = -1;
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objectType, currLangID, result, value, value2, null));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccSettingId;
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
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
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
			List<CrmLinkAccSettingViewModel> list2 = new List<CrmLinkAccSettingViewModel>();
			foreach (CrmLinkAccSettingViewModel item2 in list)
			{
				int accSettimgId = item2.AccSettimgId;
				string partValue = item2.PartValue ?? "";
				string partField = item2.PartField ?? "";
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(item2.Desc_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item2.Desc_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = item2.Desc,
					LanguageId = lCID
				});
				string desc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
				if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
				{
					foreach (CommonMultiLanguageViewModel item3 in list4)
					{
						text2 = text2 + "[AccSettimgId=" + accSettimgId + ",Desc=" + item3.Value + ",LangId=" + item3.LanguageId + ",]|";
					}
				}
				CrmLinkAccSettingViewModel item = new CrmLinkAccSettingViewModel
				{
					AccSettimgId = accSettimgId,
					PartField = partField,
					PartValue = partValue,
					Desc = desc
				};
				list2.Add(item);
			}
			if (list2 != null && Enumerable.Any<CrmLinkAccSettingViewModel>((IEnumerable<CrmLinkAccSettingViewModel>)list2))
			{
				text = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingViewModel>((IEnumerable<CrmLinkAccSettingViewModel>)list2));
			}
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 1);
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

	public string GetToken()
	{
		string text = "";
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamyarSettingViewModel hamyarSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamyarSetting();
			if (hamyarSetting != null)
			{
				string text2 = hamyarSetting.ApiAddress ?? "";
				string value = hamyarSetting.ApiKey ?? "";
				string text3 = hamyarSetting.ApiUsername ?? "";
				string text4 = hamyarSetting.ApiPassword ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text2.EndsWith("/"))
					{
						text2 += "/";
					}
					string text5 = text2 + "api/Auth/login";
					HttpClient httpClient = new HttpClient();
					httpClient.BaseAddress = new Uri(text5);
					httpClient.DefaultRequestHeaders.Add("X-API-KEY", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent(JsonConvert.SerializeObject(new HamyarTokenViewModel
					{
						username = text3,
						password = text4
					}), Encoding.UTF8, "application/json");
					HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
					httpResponseMessage = httpClient.PostAsync(text5, content).Result;
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
								text = hamyarAPIResponseViewModel.data.accessToken ?? "";
								if (!string.IsNullOrWhiteSpace(text))
								{
									text = "Bearer " + text;
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
			text = "";
		}
		return text;
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpKindFromLinkAcc()
	{
		return JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetMoadiType());
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCmpGroupsIIIFromLinkAcc()
	{
		List<SelectListItem> value = new List<SelectListItem>();
		List<LkCrmCompanyGroupsIIIViewModel> vahed = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetVahed();
		if (vahed != null)
		{
			value = Enumerable.ToList<SelectListItem>(Enumerable.Select<LkCrmCompanyGroupsIIIViewModel, SelectListItem>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)vahed, (Func<LkCrmCompanyGroupsIIIViewModel, SelectListItem>)((LkCrmCompanyGroupsIIIViewModel x) => new SelectListItem
			{
				Text = x.LinkAccName,
				Value = x.LinkAccId
			})));
		}
		return JsonConvert.SerializeObject(value);
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
	public List<SelectListItem> GetCmpGroupsIII()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectCompanyGroupsIII_Result> companyGroupsIII = CRMIdeal.Classes.Helper.Company.GetCompanyGroupsIII();
		if (companyGroupsIII != null)
		{
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)companyGroupsIII, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result x) => new SelectListItem
			{
				Text = x.GroupIIIName,
				Value = x.CompanyGroupIIIID.ToString()
			})));
		}
		base.ViewBag.CmpGroupsIIIList = list;
		return list;
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
		int value = 21;
		int value2 = -1;
		List<CRMspSelectLinkAccSettingDetails_Result> list = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value5 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				List<LkCrmCompanyGroupsIIIViewModel> vahed = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetVahed();
				_dbLink.CRMspInsertLinkAccSettingDetails(objId, objType, userId, value3, value4, value5, registerDatePersian, appType, result, value, value2);
				list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, lCID, result, value, value2));
				foreach (CRMspSelectLinkAccSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.PartTitle ?? "") == "PaymentDateType")
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
					if ((item.PartTitle ?? "") == "PaymentType")
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.HamyarLinkAccSettingPordPayType_Naghdi;
							break;
						case "2":
							item.PartValue = Labels.HamyarLinkAccSettingPordPayType_NoNaghdi;
							break;
						case "3":
							item.PartValue = Labels.HamyarLinkAccSettingPordPayType_Naghdi_And_NoNaghdi;
							break;
						case "4":
							item.PartValue = Labels.HamyarLinkAccSettingPordPayType_Credit;
							break;
						}
					}
					if ((item.PartTitle ?? "") == "NoeVahed" && vahed != null)
					{
						LkCrmCompanyGroupsIIIViewModel lkCrmCompanyGroupsIIIViewModel = Enumerable.FirstOrDefault<LkCrmCompanyGroupsIIIViewModel>((IEnumerable<LkCrmCompanyGroupsIIIViewModel>)vahed, (Func<LkCrmCompanyGroupsIIIViewModel, bool>)((LkCrmCompanyGroupsIIIViewModel x) => x.LinkAccId == item.PartValue));
						if (lkCrmCompanyGroupsIIIViewModel != null)
						{
							item.PartValue = lkCrmCompanyGroupsIIIViewModel.LinkAccName;
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
		int value = 21;
		int value2 = -1;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, currLangID, result, value, value2));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass16_1 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_1();
					_003C_003Ec__DisplayClass16_.item = enumerator.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass16_, typeof(_003C_003Ec__DisplayClass16_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass16_, typeof(_003C_003Ec__DisplayClass16_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
					if (list3 != null)
					{
						list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list3, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					text = _003C_003Ec__DisplayClass16_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass16_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass16_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass16_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass16_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass16_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass16_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass16_.item.PartTitle;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					crmLinkAccSettingDetailsLanguageViewModel.ObjectType = _003C_003Ec__DisplayClass16_.item.ObjectType;
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
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
					_dbLink.CRMspUpdateLinkAccSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
		int value = 21;
		int value2 = -1;
		List<CrmLinkAccSettingOtherLanguageViewModel> list = new List<CrmLinkAccSettingOtherLanguageViewModel>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, currLangID, result, value, value2, null));
				if (list2 != null)
				{
					using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass18_1 _003C_003Ec__DisplayClass18_ = new _003C_003Ec__DisplayClass18_1();
						_003C_003Ec__DisplayClass18_.item = enumerator.Current;
						DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
						List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass18_, typeof(_003C_003Ec__DisplayClass18_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
						val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
						CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass18_, typeof(_003C_003Ec__DisplayClass18_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSetting_Lang>)list3, (Func<CrmLinkAccSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSetting_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSetting2.Description,
							LanguageId = result
						});
						CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass18_.item.LinkAccSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass18_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass18_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass18_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass18_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass18_.item.PartLabelTitle;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
