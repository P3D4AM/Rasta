using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using CRMIdeal.LinkKyan;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccKyanSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CRMspSelectLinkAccKyanSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccKyanSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccKyanSetting_Result> list = new List<CRMspSelectLinkAccKyanSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccKyanSetting_Result>((IEnumerable<CRMspSelectLinkAccKyanSetting_Result>)_dbLink.CRMspSelectLinkAccKyanSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccKyanSetting_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.PartValue) && item.LinkAccKyanSettingId == 1)
					{
						item.PartValue = "**********";
					}
				}
				foreach (CRMspSelectLinkAccKyanSetting_Result item2 in list)
				{
					string.IsNullOrWhiteSpace(item2.PartValue);
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
			List<CRMspSelectLinkAccKyanSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccKyanSetting_Result>((IEnumerable<CRMspSelectLinkAccKyanSetting_Result>)_dbLink.CRMspSelectLinkAccKyanSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccKyanSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
					_003C_003Ec__DisplayClass5_.item = enumerator.Current;
					DbSet<CrmLinkAccKyanSetting_Lang> crmLinkAccKyanSetting_Lang = _dbTbl.CrmLinkAccKyanSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccKyanSetting_Lang), "c");
					List<CrmLinkAccKyanSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccKyanSetting_Lang>((IEnumerable<CrmLinkAccKyanSetting_Lang>)Queryable.Where<CrmLinkAccKyanSetting_Lang>((IQueryable<CrmLinkAccKyanSetting_Lang>)crmLinkAccKyanSetting_Lang, Expression.Lambda<Func<CrmLinkAccKyanSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccKyanSetting> crmLinkAccKyanSetting = _dbTbl.CrmLinkAccKyanSetting;
					val = Expression.Parameter(typeof(CrmLinkAccKyanSetting), "c");
					CrmLinkAccKyanSetting crmLinkAccKyanSetting2 = Queryable.FirstOrDefault<CrmLinkAccKyanSetting>(Queryable.Where<CrmLinkAccKyanSetting>((IQueryable<CrmLinkAccKyanSetting>)crmLinkAccKyanSetting, Expression.Lambda<Func<CrmLinkAccKyanSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccKyanSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccKyanSetting_Lang>)list3, (Func<CrmLinkAccKyanSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccKyanSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccKyanSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass5_.item.LinkAccKyanSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass5_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass5_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass5_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass5_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
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
			_dbLink.CRMspUpdateLinkAccKyanSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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

	public ValidationSoapHeader GetKyanToken()
	{
		string tokenAUT = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectLinkAccKyanSetting_Result cRMspSelectLinkAccKyanSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccKyanSetting_Result>((IEnumerable<CRMspSelectLinkAccKyanSetting_Result>)_dbLink.CRMspSelectLinkAccKyanSetting(1, "Setting", lCID, result));
			if (cRMspSelectLinkAccKyanSetting_Result != null)
			{
				tokenAUT = cRMspSelectLinkAccKyanSetting_Result.PartValue ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ValidationSoapHeader
		{
			TokenAUT = tokenAUT
		};
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetKyanInventories()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<KyanWareHouseInfoViewModel> list = new List<KyanWareHouseInfoViewModel>();
			KyanOnlineSaleServiceSoapClient kyanOnlineSaleServiceSoapClient = new KyanOnlineSaleServiceSoapClient();
			ValidationSoapHeader kyanToken = GetKyanToken();
			if (kyanToken == null)
			{
				string text2 = Messages.msgErrorRunFunction + Messages.errorInReadingSetting;
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			if (string.IsNullOrEmpty(kyanToken.TokenAUT))
			{
				string text3 = Messages.msgErrorRunFunction + Messages.errorInReadingSetting;
				Exception e2 = new Exception(text3);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text3;
			}
			ResponseDataOfInventory inventoriesList = kyanOnlineSaleServiceSoapClient.GetInventoriesList(kyanToken, null);
			if (inventoriesList == null || !inventoriesList.ResponseMessage.ToString().ToLower().Contains("success"))
			{
				string text4 = Messages.msgErrorRunFunction + " (get list from Kyan) ";
				Exception e3 = new Exception(text4);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return text4;
			}
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: true, withWrhsLinkAccWhIdStr: false, withWrhsLinkAccWareHouses: false, languageID: lCID, defaultLanguageID: result));
			int num = 1;
			Inventory[] responseResult = inventoriesList.ResponseResult;
			foreach (Inventory inventory in responseResult)
			{
				KyanWareHouseInfoViewModel doc = new KyanWareHouseInfoViewModel();
				doc.InventoryID = inventory.InventoryID;
				doc.RetailStoreID = inventory.RetailStoreID;
				doc.RetailStoreName = inventory.RetailStoreName;
				doc.RowNumber = num;
				if (list2 != null && Enumerable.Any<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WrhsLinkAccWhId == doc.RetailStoreID));
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						doc.WHId = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
					}
				}
				list.Add(doc);
				num++;
			}
			if (list != null && Enumerable.Any<KyanWareHouseInfoViewModel>((IEnumerable<KyanWareHouseInfoViewModel>)list))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkKyanWSInsertUpdateWareHouseFromKyan(json, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + Messages.ErrorInformation + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetKyanCompanyGroups()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<KyanCompanyGroupsInfoViewModel> list = new List<KyanCompanyGroupsInfoViewModel>();
			KyanOnlineSaleServiceSoapClient kyanOnlineSaleServiceSoapClient = new KyanOnlineSaleServiceSoapClient();
			ValidationSoapHeader kyanToken = GetKyanToken();
			if (kyanToken == null)
			{
				string text2 = Messages.msgErrorRunFunction + Messages.errorInReadingSetting;
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			if (string.IsNullOrEmpty(kyanToken.TokenAUT))
			{
				string text3 = Messages.msgErrorRunFunction + Messages.errorInReadingSetting;
				Exception e2 = new Exception(text3);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text3;
			}
			ResponseDataOfcustomerGroup customerGroup = kyanOnlineSaleServiceSoapClient.GetCustomerGroup(kyanToken, null);
			if (customerGroup == null || !customerGroup.ResponseMessage.ToString().ToLower().Contains("success"))
			{
				string text4 = Messages.msgErrorRunFunction + " (get list from Kyan) ";
				Exception e3 = new Exception(text4);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return text4;
			}
			List<CRMspSelectCompanyGroupsIIWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyGroupsIIWithAccLinkField(true, lCID, result));
			int num = 1;
			customerGroup[] responseResult = customerGroup.ResponseResult;
			foreach (customerGroup customerGroup2 in responseResult)
			{
				KyanCompanyGroupsInfoViewModel gr = new KyanCompanyGroupsInfoViewModel();
				gr.GroupID = customerGroup2.GroupID;
				gr.GroupName = customerGroup2.GroupName;
				gr.RowNumber = num;
				if (list2 != null && Enumerable.Any<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>)list2))
				{
					CRMspSelectCompanyGroupsIIWithAccLinkField_Result cRMspSelectCompanyGroupsIIWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyGroupsIIWithAccLinkField_Result, bool>)((CRMspSelectCompanyGroupsIIWithAccLinkField_Result m) => m.LinkAccCmpGroupIIIdStr == gr.GroupID.ToString()));
					if (cRMspSelectCompanyGroupsIIWithAccLinkField_Result != null)
					{
						gr.CompanyGroupIIID = cRMspSelectCompanyGroupsIIWithAccLinkField_Result.CompanyGroupIIID;
					}
				}
				list.Add(gr);
				num++;
			}
			if (list != null && Enumerable.Any<KyanCompanyGroupsInfoViewModel>((IEnumerable<KyanCompanyGroupsInfoViewModel>)list))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkKyanInsertUpdateCompanyGroupsIIFromKyan(json, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + Messages.ErrorInformation + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyGroupsII");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		base.Dispose(disposing);
	}
}
