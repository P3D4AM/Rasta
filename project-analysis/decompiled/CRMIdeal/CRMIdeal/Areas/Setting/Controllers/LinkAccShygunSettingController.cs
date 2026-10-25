using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Globalization;
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
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccShygunSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_1
	{
		public CRMspSelectLinkAccShygunSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public CRMspSelectLinkAccShygunSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccShygunSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpEntities _dbSp = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[JsonIgnore]
	private string JsonRender;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		SelectProductPriceGroupList();
		GetcmpTypeList();
		GetOrdPayType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccShygunSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccShygunSetting_Result> list = new List<CRMspSelectLinkAccShygunSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)_dbLink.CRMspSelectLinkAccShygunSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccShygunSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccShygunSettingId == 3 || item.LinkAccShygunSettingId == 6)
					{
						item.PartValue = "**********";
					}
					else if (item.LinkAccShygunSettingId == 24)
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
					else if (item.LinkAccShygunSettingId == 14)
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
					else if (item.LinkAccShygunSettingId == 20)
					{
						item.PartValue = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)SelectConversationStatusGroups(), (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.PartValue)).Text ?? "";
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
			List<CRMspSelectLinkAccShygunSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)_dbLink.CRMspSelectLinkAccShygunSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccShygunSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccShygunSetting_Lang> crmLinkAccShygunSetting_Lang = _dbTbl.CrmLinkAccShygunSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting_Lang), "c");
					List<CrmLinkAccShygunSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccShygunSetting_Lang>((IEnumerable<CrmLinkAccShygunSetting_Lang>)Queryable.Where<CrmLinkAccShygunSetting_Lang>((IQueryable<CrmLinkAccShygunSetting_Lang>)crmLinkAccShygunSetting_Lang, Expression.Lambda<Func<CrmLinkAccShygunSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
					val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "c");
					CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>(Queryable.Where<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccShygunSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccShygunSetting_Lang>)list3, (Func<CrmLinkAccShygunSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccShygunSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccShygunSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccShygunSettingId;
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
		if (objectType == "Setting")
		{
			base.ViewBag.CurrencyUnitList = GetCurrencyUnit();
		}
		if (objectType == "OrdPayType")
		{
			base.ViewBag.ShygunPayTypeList = GetShygunPayTypeList();
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSetting(string setting, string objType)
	{
		//IL_005a: Unknown result type (might be due to invalid IL or missing references)
		//IL_012d: Unknown result type (might be due to invalid IL or missing references)
		//IL_038a: Unknown result type (might be due to invalid IL or missing references)
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
				if (!(item.PartTitle == "DocMovementAccountNumber"))
				{
					continue;
				}
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				if (!(shygunSetting.DocMovementAccountNumber != item.PartValue))
				{
					continue;
				}
				try
				{
					string text6 = "";
					string JsonResult = "";
					DomainAccount domainAccount = new DomainAccount();
					string startVersion = null;
					domainAccount.AccountNumber.From = item.PartValue;
					domainAccount.AccountNumber.To = item.PartValue;
					foreach (DataRow item3 in (InternalDataCollectionBase)new WebServiceGetAccount(shygunSetting.IP, shygunSetting.conf, domainAccount, 0, 20, startVersion).GetDataTableObject(out JsonResult).Rows)
					{
						new ShygunCompanyInfoViewModel();
						text6 = item3["GuId"].ToString();
					}
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text = text + "[AccSettimgId=" + shygunSetting.DocMovementAccountGUId_Id + ",PartField=,PartValue=" + text6 + ",Desc=,]|";
					}
					else
					{
						text = "";
						text2 = "";
						result = string.Format(Messages.msgErrorOtherSystemAuthFieldValue, Labels.Shygun, shygunSetting.DocMovementAccountNumber_PartLabelTitle);
					}
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = ex.Message;
				}
			}
			if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
			{
				_dbLink.CRMspUpdateLinkAccShygunSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = ex2.Message;
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

	[AjaxOnly]
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccShygunSettingDetails_Result> list = new List<CRMspSelectLinkAccShygunSettingDetails_Result>();
		try
		{
			if (objId > 0 && !string.IsNullOrEmpty(objType))
			{
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				_dbLink.CRMspInsertLinkAccShygunSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				list = Enumerable.ToList<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunSettingDetails(0, objId, objType, lCID, result));
				List<SelectListItem> list2 = new List<SelectListItem>();
				if (objType == "OrdPayType")
				{
					list2 = GetShygunPayTypeList();
				}
				foreach (CRMspSelectLinkAccShygunSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccShygunSettingId == 16)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.OtherSystemsShygunProductPriceI;
							break;
						case "2":
							item.PartValue = Labels.OtherSystemsShygunProductPriceII;
							break;
						case "3":
							item.PartValue = Labels.OtherSystemsShygunProductPriceIII;
							break;
						case "4":
							item.PartValue = Labels.OtherSystemsShygunProductPriceIV;
							break;
						case "5":
							item.PartValue = Labels.OtherSystemsShygunProductPriceV;
							break;
						}
					}
					else if ((item.PartTitle ?? "") == "VouchType")
					{
						string partValue = item.PartValue;
						if (!(partValue == "21"))
						{
							if (partValue == "22")
							{
								item.PartValue = Labels.LinkAccSettingPayPayment;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingPayReceive;
						}
					}
					else if ((item.PartTitle ?? "") == "VouchDateType")
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
					else if ((item.PartTitle ?? "") == "DueDateType")
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
					else if ((item.PartTitle ?? "") == "PayType" && list2 != null && !string.IsNullOrWhiteSpace(item.PartValue) && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list2))
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

	public List<WSspSelectProductPriceGroup_Result> SelectProductPriceGroup()
	{
		List<WSspSelectProductPriceGroup_Result> result = new List<WSspSelectProductPriceGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_dbSp.WSspSelectProductPriceGroup(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectProductPriceGroupList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductPriceGroup_Result> list2 = SelectProductPriceGroup();
			if (list2 != null)
			{
				foreach (WSspSelectProductPriceGroup_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ProductPriceGroupID.ToString(),
						Text = item2.ProductPriceGroupName,
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
		base.ViewBag.ProductPriceGroupList = list;
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actImportFGFromAcc")]
	public string GetProductFirstGroup(int fCode = 0, int tCode = 0)
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		//IL_010c: Expected O, but got Unknown
		string result = Messages.msgErrorRunFunction;
		try
		{
			bool flag = true;
			int num = 0;
			int rowCount = 100;
			while (flag)
			{
				List<LkProductFirstGroupInfoViewModel> list = new List<LkProductFirstGroupInfoViewModel>();
				List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = ((fCode <= 0) ? string.Empty : fCode.ToString());
				domainItemGroup.GroupNumber.To = ((tCode <= 0) ? string.Empty : tCode.ToString());
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && Enumerable.Count<DataRow>((IEnumerable<DataRow>)dataTableObject.Select()) > 0)
				{
					dataTableObject = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow row = item;
						LkProductFirstGroupInfoViewModel lkProductFirstGroupInfoViewModel = new LkProductFirstGroupInfoViewModel();
						if (!string.IsNullOrWhiteSpace(row["GroupNumber"].ToString()))
						{
							lkProductFirstGroupInfoViewModel.FGLinkAccGroupCode = row["GroupNumber"].ToString();
						}
						else
						{
							lkProductFirstGroupInfoViewModel.FGLinkAccGroupCode = null;
						}
						lkProductFirstGroupInfoViewModel.FGName = row["GroupName"].ToString();
						lkProductFirstGroupInfoViewModel.FGLinkAccGroupIdStr = row["GroupGuId"].ToString();
						if (!string.IsNullOrWhiteSpace(row["GroupGuId"].ToString()))
						{
							WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == row["GroupGuId"].ToString()));
							if (wSspSelectProductsFirstGroupWithAccLinkField_Result != null)
							{
								lkProductFirstGroupInfoViewModel.PrdFirstGroupID = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
							}
						}
						list.Add(lkProductFirstGroupInfoViewModel);
					}
				}
				else
				{
					flag = false;
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsFirstGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result2, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "1" : objectParameter.Value.ToString());
				}
				num += ((num > 0) ? 100 : 101);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProductGroup", ActionName = "actImportSGFromAcc")]
	public string GetProductSecondGroup(int fCode = 0, int tCode = 0)
	{
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0118: Expected O, but got Unknown
		string result = Messages.msgErrorRunFunction;
		try
		{
			bool flag = true;
			int num = 0;
			int rowCount = 100;
			while (flag)
			{
				List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
				List<WSspSelectProductsFirstGroupWithAccLinkField_Result> list2 = SelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true);
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = ((fCode <= 0) ? string.Empty : fCode.ToString());
				domainItemGroup.GroupNumber.To = ((tCode <= 0) ? string.Empty : tCode.ToString());
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && Enumerable.Count<DataRow>((IEnumerable<DataRow>)dataTableObject.Select()) > 0)
				{
					dataTableObject = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 0"));
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow row = item;
						LkProductSecondGroupInfoViewModel lkProductSecondGroupInfoViewModel = new LkProductSecondGroupInfoViewModel();
						if (string.IsNullOrWhiteSpace(row["GroupNumber"].ToString()))
						{
							continue;
						}
						string idStr = row["ParentGroupGuid"].ToString();
						WSspSelectProductsFirstGroupWithAccLinkField_Result wSspSelectProductsFirstGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsFirstGroupWithAccLinkField_Result, bool>)((WSspSelectProductsFirstGroupWithAccLinkField_Result x) => x.FGLinkAccGroupIdStr == idStr));
						if (wSspSelectProductsFirstGroupWithAccLinkField_Result == null)
						{
							continue;
						}
						lkProductSecondGroupInfoViewModel.FirstGroupId = wSspSelectProductsFirstGroupWithAccLinkField_Result.PrdFirstGroupID;
						if (!string.IsNullOrWhiteSpace(row["GroupNumber"].ToString()))
						{
							lkProductSecondGroupInfoViewModel.SGLinkAccGroupCode = row["GroupNumber"].ToString();
						}
						else
						{
							lkProductSecondGroupInfoViewModel.SGLinkAccGroupCode = null;
						}
						lkProductSecondGroupInfoViewModel.SGName = row["GroupName"].ToString();
						lkProductSecondGroupInfoViewModel.SGLinkAccGroupIdStr = row["GroupGuid"].ToString();
						if (!string.IsNullOrWhiteSpace(row["GroupGuid"].ToString()))
						{
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == row["GroupGuid"].ToString()));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null)
							{
								lkProductSecondGroupInfoViewModel.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
							}
						}
						list.Add(lkProductSecondGroupInfoViewModel);
					}
				}
				else
				{
					flag = false;
				}
				if (list != null && list.Count > 0)
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
					if (result2 <= 0)
					{
						result2 = 1065;
					}
					_ = Thread.CurrentThread.CurrentCulture.LCID;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					int id = Financial.Get().Id;
					short value2 = short.Parse(Financial.Get().Id.ToString());
					short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					int userId = UserLogin.CurrentUser.UserId;
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProductsSecondGroup(json, userId, value3, value2, id, value, registerDatePersian, appType, result2, objectParameter);
					result = ((objectParameter == null || string.IsNullOrWhiteSpace(objectParameter.Value.ToString())) ? "1" : objectParameter.Value.ToString());
				}
				num += ((num > 0) ? 100 : 101);
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Labels.Error + ": " + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actImportFromAcc")]
	public string GetWarehouse(string fNumber = "", string tNumber = "")
	{
		//IL_0193: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Expected O, but got Unknown
		string text = "";
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LkWareHouseInfoViewModel> list = new List<LkWareHouseInfoViewModel>();
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhCode: false, withWrhsLinkAccWhId: false, withWrhsLinkAccWhIdStr: true, withWrhsLinkAccWareHouses: false, languageID: 0, defaultLanguageID: 0));
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainStock domainStock = new DomainStock();
				domainStock.STNumber.From = fNumber;
				domainStock.STNumber.To = tNumber;
				string JsonResult;
				DataTable dataTableObject = new WebServiceGetStock(shygunSetting.IP, shygunSetting.conf, domainStock, num, rowCount).GetDataTableObject(out JsonResult);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
					{
						DataRow val = item;
						LkWareHouseInfoViewModel vm = new LkWareHouseInfoViewModel();
						vm.WrhsLinkAccWhCode = val[0].ToString();
						vm.WrhsName = val[1].ToString();
						vm.WrhsLinkAccWhIdStr = val[3].ToString();
						if (list2 != null)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhIdStr == vm.WrhsLinkAccWhIdStr));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								vm.WareHouseID = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							}
						}
						list.Add(vm);
					}
				}
				else
				{
					flag = false;
				}
				if (list.Count > 0)
				{
					string json = JsonConvert.SerializeObject(list);
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateWareHouse(json, userId, value2, id, value, registerDatePersian, appType, lCID, objectParameter, centerId);
					text = (string.IsNullOrWhiteSpace(objectParameter.Value.ToString()) ? "1" : (text + objectParameter.Value.ToString()));
				}
				num += ((num > 0) ? 100 : 101);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	public List<WSspSelectProductsFirstGroupWithAccLinkField_Result> SelectProductsFirstGroupWithAccLinkField(bool withLinkAccGroupId = false, bool withLinkAccGroupCode = false, bool withLinkAccGroupIdStr = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductsFirstGroupWithAccLinkField_Result> result2 = new List<WSspSelectProductsFirstGroupWithAccLinkField_Result>();
		try
		{
			result2 = Enumerable.ToList<WSspSelectProductsFirstGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsFirstGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsFirstGroupWithAccLinkField(withLinkAccGroupId: withLinkAccGroupId, withLinkAccGroupCode: withLinkAccGroupCode, withLinkAccGroupIdStr: withLinkAccGroupIdStr, languageID: lCID, defaultLanguageID: result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	public List<WSspSelectProductsSecondGroupWithAccLinkField_Result> SelectProductsSecondGroupWithAccLinkField(bool withLinkAccGroupId = false, bool withLinkAccGroupCode = false, bool withLinkAccGroupIdStr = false, bool withLinkAccGroups = false)
	{
		List<WSspSelectProductsSecondGroupWithAccLinkField_Result> result = new List<WSspSelectProductsSecondGroupWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: withLinkAccGroupId, withLinkAccGroupCode: withLinkAccGroupCode, withLinkAccGroupIdStr: withLinkAccGroupIdStr, withLinkAccGroups: withLinkAccGroups, languageID: lCID, defaultLanguageID: result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
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
			List<CRMspSelectLinkAccShygunSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunSettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccShygunSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass20_1 _003C_003Ec__DisplayClass20_ = new _003C_003Ec__DisplayClass20_1();
					_003C_003Ec__DisplayClass20_.item = enumerator.Current;
					DbSet<CrmLinkAccShygunSettingDetails_Lang> crmLinkAccShygunSettingDetails_Lang = _dbTbl.CrmLinkAccShygunSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSettingDetails_Lang), "c");
					List<CrmLinkAccShygunSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccShygunSettingDetails_Lang>((IEnumerable<CrmLinkAccShygunSettingDetails_Lang>)Queryable.Where<CrmLinkAccShygunSettingDetails_Lang>((IQueryable<CrmLinkAccShygunSettingDetails_Lang>)crmLinkAccShygunSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccShygunSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass20_, typeof(_003C_003Ec__DisplayClass20_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccShygunSettingDetails> crmLinkAccShygunSettingDetails = _dbTbl.CrmLinkAccShygunSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccShygunSettingDetails), "c");
					CrmLinkAccShygunSettingDetails crmLinkAccShygunSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccShygunSettingDetails>(Queryable.Where<CrmLinkAccShygunSettingDetails>((IQueryable<CrmLinkAccShygunSettingDetails>)crmLinkAccShygunSettingDetails, Expression.Lambda<Func<CrmLinkAccShygunSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass20_, typeof(_003C_003Ec__DisplayClass20_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccShygunSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccShygunSettingDetails_Lang>)list3, (Func<CrmLinkAccShygunSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccShygunSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccShygunSettingDetails2.Description,
						LanguageId = result
					});
					text = _003C_003Ec__DisplayClass20_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass20_.item.LinkAccShygunSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass20_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass20_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass20_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass20_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass20_.item.LinkAccShygunSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass20_.item.PartTitle;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ObjectTypeTitle = text;
		if (objType == "OrdPayType")
		{
			base.ViewBag.ShygunPayTypeList = GetShygunPayTypeList();
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettingDetails(int objId, string objType, string settingDetail)
	{
		//IL_006c: Unknown result type (might be due to invalid IL or missing references)
		//IL_013f: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string result = "1";
		try
		{
			if (objId > 0 && !string.IsNullOrEmpty(objType))
			{
				new List<CrmLinkAccSettingDetailsViewModel>();
				List<CrmLinkAccSettingDetailsViewModel> list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsViewModel>>(settingDetail);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value = short.Parse(Financial.Get().Id.ToString());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value3 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				string text = "";
				string text2 = "";
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
				_dbLink.CRMspUpdateLinkAccShygunSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
				List<CRMspSelectLinkAccShygunSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccShygunSetting_Result>((IEnumerable<CRMspSelectLinkAccShygunSetting_Result>)_dbLink.CRMspSelectLinkAccShygunSetting(0, objType, currLangID, result));
				if (list2 != null)
				{
					using List<CRMspSelectLinkAccShygunSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass22_1 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_1();
						_003C_003Ec__DisplayClass22_.item = enumerator.Current;
						DbSet<CrmLinkAccShygunSetting_Lang> crmLinkAccShygunSetting_Lang = _dbTbl.CrmLinkAccShygunSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccShygunSetting_Lang), "c");
						List<CrmLinkAccShygunSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccShygunSetting_Lang>((IEnumerable<CrmLinkAccShygunSetting_Lang>)Queryable.Where<CrmLinkAccShygunSetting_Lang>((IQueryable<CrmLinkAccShygunSetting_Lang>)crmLinkAccShygunSetting_Lang, Expression.Lambda<Func<CrmLinkAccShygunSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccShygunSetting> crmLinkAccShygunSetting = _dbTbl.CrmLinkAccShygunSetting;
						val = Expression.Parameter(typeof(CrmLinkAccShygunSetting), "c");
						CrmLinkAccShygunSetting crmLinkAccShygunSetting2 = Queryable.FirstOrDefault<CrmLinkAccShygunSetting>(Queryable.Where<CrmLinkAccShygunSetting>((IQueryable<CrmLinkAccShygunSetting>)crmLinkAccShygunSetting, Expression.Lambda<Func<CrmLinkAccShygunSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccShygunSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccShygunSetting_Lang>)list3, (Func<CrmLinkAccShygunSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccShygunSetting_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccShygunSetting2.Description,
							LanguageId = result
						});
						CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass22_.item.LinkAccShygunSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass22_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass22_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass22_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass22_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass22_.item.PartLabelTitle;
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

	[AjaxOnly]
	public JsonResult GetcmpTypeList()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_dbSp.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.cmpTypeList = list;
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

	public List<SelectListItem> GetShygunPayTypeList()
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
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			if (shygunSetting != null)
			{
				string text = shygunSetting.IP;
				if (string.IsNullOrWhiteSpace(text))
				{
					Exception e = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!text.EndsWith("/"))
				{
					text += "/";
				}
				HttpClient obj = new HttpClient
				{
					BaseAddress = new Uri(text),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				};
				string requestUri = "api/PayType/Get";
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunApiParamNoDomainViewModel
				{
					Config = shygunSetting.conf,
					StartVersion = "0"
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = obj.PostAsync(requestUri, content).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string value = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetPayTypeResultViewModel shygunApiGetPayTypeResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetPayTypeResultViewModel>(value);
						if (shygunApiGetPayTypeResultViewModel != null && shygunApiGetPayTypeResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel>)shygunApiGetPayTypeResultViewModel.Result))
						{
							list.AddRange(Enumerable.Select<CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel, SelectListItem>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel>)shygunApiGetPayTypeResultViewModel.Result, (Func<CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel, SelectListItem>)((CRMIdeal.Classes.Helper.OtherSystems.ShygunPayTypeViewModel item) => new SelectListItem
							{
								Text = (item.Name ?? ""),
								Value = item.TypeId.GetValueOrDefault().ToString(),
								Selected = false
							})));
						}
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetShygunSaleCenter()
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
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<LkWSSaleCenterInfoViewModel> list = new List<LkWSSaleCenterInfoViewModel>();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			if (shygunSetting != null)
			{
				string text2 = shygunSetting.IP;
				if (string.IsNullOrWhiteSpace(text2))
				{
					Exception e = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				HttpClient obj = new HttpClient
				{
					BaseAddress = new Uri(text2),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				};
				string requestUri = "api/Department/Get";
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunApiParamNoDomainViewModel
				{
					Config = shygunSetting.conf,
					StartVersion = "0"
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = obj.PostAsync(requestUri, content).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					string value = httpResponseMessage.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetDepartmentResultViewModel shygunApiGetDepartmentResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetDepartmentResultViewModel>(value);
						if (shygunApiGetDepartmentResultViewModel != null && shygunApiGetDepartmentResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunDepartmentViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunDepartmentViewModel>)shygunApiGetDepartmentResultViewModel.Result))
						{
							foreach (CRMIdeal.Classes.Helper.OtherSystems.ShygunDepartmentViewModel item in shygunApiGetDepartmentResultViewModel.Result)
							{
								LkWSSaleCenterInfoViewModel lkWSSaleCenterInfoViewModel = new LkWSSaleCenterInfoViewModel
								{
									SaleCenterName = (item.DepartmentName ?? ""),
									LinkAccSaleCenterIdStr = item.GuId
								};
								DateTime value2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", new CultureInfo("en-US")), new CultureInfo("en-US"));
								BaseInfoLinkAccDataViewModel value3 = new BaseInfoLinkAccDataViewModel
								{
									DBId = 0,
									Id = (item.GuId ?? ""),
									Code = (item.DepartmentNumber ?? ""),
									FTDate = value2,
									LTDate = value2
								};
								lkWSSaleCenterInfoViewModel.LinkAccData = "[" + JsonConvert.SerializeObject(value3) + "]";
								list.Add(lkWSSaleCenterInfoViewModel);
							}
						}
					}
				}
			}
			if (list == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSSaleCenters(list);
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction;
		}
		return text;
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
