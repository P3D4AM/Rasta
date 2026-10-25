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

public class LinkAccArpaSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccArpaSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpEntities _dbSp = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccArpaSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccArpaSetting_Result> list = new List<CRMspSelectLinkAccArpaSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)_dbLink.CRMspSelectLinkAccArpaSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccArpaSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccArpaSettingId == 3)
					{
						item.PartValue = "******";
					}
					else if (item.LinkAccArpaSettingId == 4)
					{
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
					else if (item.LinkAccArpaSettingId == 6)
					{
						int result2 = 0;
						int.TryParse(item.PartValue, out result2);
						WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(result2, lCID, result));
						if (wSspSelectCurrencyUnitsWithId_Result != null)
						{
							item.PartValue = wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit ?? "";
						}
						else
						{
							item.PartValue = "";
						}
					}
					else
					{
						if (item.LinkAccArpaSettingId != 8)
						{
							continue;
						}
						List<SelectListItem> list2 = SelectConversationStatusGroups();
						if (list2 != null)
						{
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list2, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.PartValue));
							if (selectListItem != null)
							{
								item.PartValue = selectListItem.Text ?? "";
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
			List<CRMspSelectLinkAccArpaSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccArpaSetting_Result>((IEnumerable<CRMspSelectLinkAccArpaSetting_Result>)_dbLink.CRMspSelectLinkAccArpaSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccArpaSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccArpaSetting_Lang> crmLinkAccArpaSetting_Lang = _dbTbl.CrmLinkAccArpaSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccArpaSetting_Lang), "c");
					List<CrmLinkAccArpaSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccArpaSetting_Lang>((IEnumerable<CrmLinkAccArpaSetting_Lang>)Queryable.Where<CrmLinkAccArpaSetting_Lang>((IQueryable<CrmLinkAccArpaSetting_Lang>)crmLinkAccArpaSetting_Lang, Expression.Lambda<Func<CrmLinkAccArpaSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccArpaSetting> crmLinkAccArpaSetting = _dbTbl.CrmLinkAccArpaSetting;
					val = Expression.Parameter(typeof(CrmLinkAccArpaSetting), "c");
					CrmLinkAccArpaSetting crmLinkAccArpaSetting2 = Queryable.FirstOrDefault<CrmLinkAccArpaSetting>(Queryable.Where<CrmLinkAccArpaSetting>((IQueryable<CrmLinkAccArpaSetting>)crmLinkAccArpaSetting, Expression.Lambda<Func<CrmLinkAccArpaSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccArpaSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccArpaSetting_Lang>)list3, (Func<CrmLinkAccArpaSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccArpaSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccArpaSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccArpaSettingId;
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
		if (objectType == "CmpProject")
		{
			base.ViewBag.StatusGroupslist = SelectConversationStatusGroups();
		}
		if (objectType == "Order")
		{
			base.ViewBag.CurrencyUnitList = GetCurrencyUnit();
		}
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
				_dbLink.CRMspUpdateLinkAccArpaSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetArpaPrdUnit()
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
			string value3 = Arpa_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = arpaSetting.ArpaServerAddress ?? "";
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
			{
				text2 += "serv/";
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				HttpClient httpClient = new HttpClient();
				string text3 = text2 + "api/GetUnits";
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", value3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				ArpaProductUnitResponseViewModel arpaProductUnitResponseViewModel = JsonConvert.DeserializeObject<ArpaProductUnitResponseViewModel>(value4);
				if (arpaProductUnitResponseViewModel == null)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				List<LkWSProductUnitInfoViewModel> list = new List<LkWSProductUnitInfoViewModel>();
				if (arpaProductUnitResponseViewModel.data == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (Enumerable.Any<ArpaProductUnitInfoViewModel>((IEnumerable<ArpaProductUnitInfoViewModel>)arpaProductUnitResponseViewModel.data))
				{
					foreach (ArpaProductUnitInfoViewModel datum in arpaProductUnitResponseViewModel.data)
					{
						LkWSProductUnitInfoViewModel item = new LkWSProductUnitInfoViewModel
						{
							Unit = datum.UnitName,
							UnitLinkAccUnitIdStr = datum.UnitID
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSProductUnitInfoViewModel>((IEnumerable<LkWSProductUnitInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string unitJson = JsonConvert.SerializeObject(list);
				_dbLink.CRMspLkWSInsertUpdateProductUnitByJson(unitJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
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
	public string GetArpaCmpType()
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
			short value3 = short.Parse(id.ToString());
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value4 = Arpa_GetToken();
			if (string.IsNullOrWhiteSpace(value4))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = arpaSetting.ArpaServerAddress ?? "";
			string defUserGroupId = arpaSetting.DefUserGroupId;
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
			{
				text2 += "serv/";
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				string text3 = "";
				if (!string.IsNullOrWhiteSpace(defUserGroupId))
				{
					text3 = text3 + "?UserGroupID=" + defUserGroupId;
				}
				HttpClient httpClient = new HttpClient();
				string text4 = text2 + "api/GetBusinessCategory" + text3;
				httpClient.BaseAddress = new Uri(text4);
				httpClient.DefaultRequestHeaders.Add("Authorization", value4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				string value5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value5))
				{
					value5 = value5.ClearHiddenCharacters();
				}
				ArpaBusinessCategoryResponseViewModel arpaBusinessCategoryResponseViewModel = JsonConvert.DeserializeObject<ArpaBusinessCategoryResponseViewModel>(value5);
				if (arpaBusinessCategoryResponseViewModel == null)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				List<LkCompanyTypeInfoViewModel> list = new List<LkCompanyTypeInfoViewModel>();
				if (arpaBusinessCategoryResponseViewModel.data == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (Enumerable.Any<ArpaBusinessCategoryInfoViewModel>((IEnumerable<ArpaBusinessCategoryInfoViewModel>)arpaBusinessCategoryResponseViewModel.data))
				{
					foreach (ArpaBusinessCategoryInfoViewModel datum in arpaBusinessCategoryResponseViewModel.data)
					{
						LkCompanyTypeInfoViewModel item = new LkCompanyTypeInfoViewModel
						{
							CompanyTypeName = datum.BusinessCategoryName,
							LinkAccCmpTypeIdStr = datum.BusinessCategoryID
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkCompanyTypeInfoViewModel>((IEnumerable<LkCompanyTypeInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string cmpTypeJson = JsonConvert.SerializeObject(list);
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
	public string GetArpaDeliveryTerm()
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
			string value3 = Arpa_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = arpaSetting.ArpaServerAddress ?? "";
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
			{
				text2 += "serv/";
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				HttpClient httpClient = new HttpClient();
				string text3 = text2 + "api/GetTransportations";
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", value3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				ArpaDeliveryTermResponseViewModel arpaDeliveryTermResponseViewModel = JsonConvert.DeserializeObject<ArpaDeliveryTermResponseViewModel>(value4);
				if (arpaDeliveryTermResponseViewModel == null)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				List<LkWSDeliveryTermInfoViewModel> list = new List<LkWSDeliveryTermInfoViewModel>();
				if (arpaDeliveryTermResponseViewModel.data == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (Enumerable.Any<ArpaDeliveryTermInfoViewModel>((IEnumerable<ArpaDeliveryTermInfoViewModel>)arpaDeliveryTermResponseViewModel.data))
				{
					foreach (ArpaDeliveryTermInfoViewModel datum in arpaDeliveryTermResponseViewModel.data)
					{
						LkWSDeliveryTermInfoViewModel item = new LkWSDeliveryTermInfoViewModel
						{
							DeliveryTerm = datum.TransportationDesc,
							LinkAccDeliveryTermIdStr = datum.TransportationID
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSDeliveryTermInfoViewModel>((IEnumerable<LkWSDeliveryTermInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string deliveryTermJson = JsonConvert.SerializeObject(list);
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
	public string GetArpaSaleCenter()
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
			string value3 = Arpa_GetToken();
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = arpaSetting.ArpaServerAddress ?? "";
			string defUserGroupId = arpaSetting.DefUserGroupId;
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
			{
				text2 += "serv/";
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				string text3 = "";
				if (!string.IsNullOrWhiteSpace(defUserGroupId))
				{
					text3 = text3 + "?UserGroupID=" + defUserGroupId;
				}
				HttpClient httpClient = new HttpClient();
				string text4 = text2 + "api/GetDepartments" + text3;
				httpClient.BaseAddress = new Uri(text4);
				httpClient.DefaultRequestHeaders.Add("Authorization", value3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				string value4 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value4))
				{
					value4 = value4.ClearHiddenCharacters();
				}
				ArpaSaleCenterResponseViewModel arpaSaleCenterResponseViewModel = JsonConvert.DeserializeObject<ArpaSaleCenterResponseViewModel>(value4);
				if (arpaSaleCenterResponseViewModel == null)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				List<LkWSSaleCenterInfoViewModel> list = new List<LkWSSaleCenterInfoViewModel>();
				if (arpaSaleCenterResponseViewModel.data == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (Enumerable.Any<ArpaSaleCenterInfoViewModel>((IEnumerable<ArpaSaleCenterInfoViewModel>)arpaSaleCenterResponseViewModel.data))
				{
					foreach (ArpaSaleCenterInfoViewModel datum in arpaSaleCenterResponseViewModel.data)
					{
						LkWSSaleCenterInfoViewModel item = new LkWSSaleCenterInfoViewModel
						{
							SaleCenterName = datum.DName,
							LinkAccSaleCenterIdStr = datum.DepartmentID
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSSaleCenterInfoViewModel>((IEnumerable<LkWSSaleCenterInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string saleCenterJson = JsonConvert.SerializeObject(list);
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
	public string GetArpaSettlementType()
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
			short value3 = short.Parse(id.ToString());
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			string value4 = Arpa_GetToken();
			if (string.IsNullOrWhiteSpace(value4))
			{
				return Messages.msgErrorReceivingToken + "|";
			}
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = arpaSetting.ArpaServerAddress ?? "";
			if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
			{
				text2 += "serv/";
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				HttpClient httpClient = new HttpClient();
				string text3 = text2 + "api/GetSettlements";
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", value4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
				HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
				if (!result2.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				string value5 = result2.Content.ReadAsStringAsync().Result;
				if (!string.IsNullOrWhiteSpace(value5))
				{
					value5 = value5.ClearHiddenCharacters();
				}
				ArpaSettlementTypeResponseViewModel arpaSettlementTypeResponseViewModel = JsonConvert.DeserializeObject<ArpaSettlementTypeResponseViewModel>(value5);
				if (arpaSettlementTypeResponseViewModel == null)
				{
					return Messages.msgErrorRunFunction + " (get list from arpa) ";
				}
				List<LkWSSettlementTypeInfoViewModel> list = new List<LkWSSettlementTypeInfoViewModel>();
				if (arpaSettlementTypeResponseViewModel.data == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (Enumerable.Any<ArpaSettlementTypeInfoViewModel>((IEnumerable<ArpaSettlementTypeInfoViewModel>)arpaSettlementTypeResponseViewModel.data))
				{
					foreach (ArpaSettlementTypeInfoViewModel datum in arpaSettlementTypeResponseViewModel.data)
					{
						LkWSSettlementTypeInfoViewModel item = new LkWSSettlementTypeInfoViewModel
						{
							Name = datum.SettlementName,
							LinkAccSettlementTypeIdStr = datum.SettlementID
						};
						list.Add(item);
					}
				}
				if (list == null)
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				if (!Enumerable.Any<LkWSSettlementTypeInfoViewModel>((IEnumerable<LkWSSettlementTypeInfoViewModel>)list))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				string settlementTypeJson = JsonConvert.SerializeObject(list);
				_dbLink.CRMspLkWSInsertUpdateSettlementTypeByJson(settlementTypeJson, userId, value2, value3, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSSettlementType");
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

	public string Arpa_GetToken()
	{
		string text = "";
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
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
					HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text5, content).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(result2))
						{
							text = result2 ?? "";
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

	public List<SelectListItem> SelectConversationStatusGroups()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_dbSp.CRMspSelectConversationStatusGroups(lCID, result));
			if (list2 != null)
			{
				foreach (CRMspSelectConversationStatusGroups_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ConversationStatusGroupID.ToString(),
						Text = item2.ConversationStatusGroup,
						Selected = false
					};
					list.Add(item);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetCurrencyUnit()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCurrencyUnits_Result> list2 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCurrencyUnits_Result, SelectListItem>((IEnumerable<WSspSelectCurrencyUnits_Result>)list2, (Func<WSspSelectCurrencyUnits_Result, SelectListItem>)((WSspSelectCurrencyUnits_Result item) => new SelectListItem
			{
				Text = item.CurrencyUnit,
				Value = item.CurrencyUnitID.ToString(),
				Selected = false
			})));
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
