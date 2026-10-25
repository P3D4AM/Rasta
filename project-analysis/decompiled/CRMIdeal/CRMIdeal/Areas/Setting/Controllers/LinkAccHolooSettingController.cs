using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccHolooSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
	{
		public CRMspSelectLinkAccHolooSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CRMspSelectLinkAccHolooSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index_Old()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		GetLinkAccHolooDatabases();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccHolooSetting_Old(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccHolooSetting_Result> list = new List<CRMspSelectLinkAccHolooSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>(Enumerable.Where<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, objType, lCID, result), (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId != 8 && m.LinkAccHolooSettingId != 9)));
				foreach (CRMspSelectLinkAccHolooSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccHolooSettingId == 4)
					{
						item.PartValue = "**********";
					}
					else if (item.LinkAccHolooSettingId == 6)
					{
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingHolooInvStockTotal;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingHolooInvStockRetail;
						}
					}
					else
					{
						if (item.LinkAccHolooSettingId != 7)
						{
							continue;
						}
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingHolooTaxCalculateTypeInDetails;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingHolooTaxCalculateTypeInHeader;
						}
					}
				}
				foreach (CRMspSelectLinkAccHolooSetting_Result item2 in list)
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

	[AjaxOnly]
	public JsonResult GetSelectLinkAccHolooSetting(string objType = "", int linkAccSettingDBId = 0)
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
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, lCID, result, 4, linkAccSettingDBId, null), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => m.PartTitle != "TaxPercent" && m.PartTitle != "DutyPercent")));
				foreach (CRMspSelectLinkAccSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.PartTitle == "Password")
					{
						item.PartValue = "**********";
					}
					else if (item.PartTitle == "PrdInvStockDisplayType")
					{
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingHolooInvStockTotal;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingHolooInvStockRetail;
						}
					}
					else if (item.PartTitle == "TaxCalculateType")
					{
						string partValue = item.PartValue;
						if (!(partValue == "1"))
						{
							if (partValue == "2")
							{
								item.PartValue = Labels.LinkAccSettingHolooTaxCalculateTypeInDetails;
							}
						}
						else
						{
							item.PartValue = Labels.LinkAccSettingHolooTaxCalculateTypeInHeader;
						}
					}
					else if (item.PartTitle == "CmpLinkedField")
					{
						string holoo = Labels.Holoo;
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = string.Format(Labels.OtherSystemsImListCmpCodeI, holoo);
							break;
						case "2":
							item.PartValue = Labels.prsMobile;
							break;
						case "3":
							item.PartValue = Labels.cmpNationalCode;
							break;
						case "4":
							item.PartValue = Labels.prsNationalCode;
							break;
						case "5":
							item.PartValue = Labels.prsMobile + " - $" + Labels.cmpNationalCode + " - $" + Labels.prsNationalCode;
							break;
						}
					}
					else
					{
						if (!(item.PartTitle == "DefPrjCvnsStatusGroupId"))
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
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
	public ActionResult InsertEdit_Old(string objectType)
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
			List<CRMspSelectLinkAccHolooSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>(Enumerable.Where<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, objectType, currLangID, result), (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId != 8 && m.LinkAccHolooSettingId != 9)));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccHolooSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
					_003C_003Ec__DisplayClass7_.item = enumerator.Current;
					DbSet<CrmLinkAccHolooSetting_Lang> crmLinkAccHolooSetting_Lang = _dbTbl.CrmLinkAccHolooSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHolooSetting_Lang), "c");
					List<CrmLinkAccHolooSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccHolooSetting_Lang>((IEnumerable<CrmLinkAccHolooSetting_Lang>)Queryable.Where<CrmLinkAccHolooSetting_Lang>((IQueryable<CrmLinkAccHolooSetting_Lang>)crmLinkAccHolooSetting_Lang, Expression.Lambda<Func<CrmLinkAccHolooSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccHolooSetting> crmLinkAccHolooSetting = _dbTbl.CrmLinkAccHolooSetting;
					val = Expression.Parameter(typeof(CrmLinkAccHolooSetting), "c");
					CrmLinkAccHolooSetting crmLinkAccHolooSetting2 = Queryable.FirstOrDefault<CrmLinkAccHolooSetting>(Queryable.Where<CrmLinkAccHolooSetting>((IQueryable<CrmLinkAccHolooSetting>)crmLinkAccHolooSetting, Expression.Lambda<Func<CrmLinkAccHolooSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccHolooSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccHolooSetting_Lang>)list3, (Func<CrmLinkAccHolooSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccHolooSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccHolooSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass7_.item.LinkAccHolooSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass7_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass7_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass7_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass7_.item.PartLabelTitle;
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

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actEdit")]
	public ActionResult InsertEdit(string objectType, int linkAccSettingDBId = 0)
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
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objectType, currLangID, result, 4, linkAccSettingDBId, null), (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => m.PartTitle != "TaxPercent" && m.PartTitle != "DutyPercent")));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
					_003C_003Ec__DisplayClass8_.item = enumerator.Current;
					DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
					List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
					val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Convert((Expression)(object)Expression.Constant((object)4, typeof(int)), typeof(int?))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass8_.item.LinkAccSettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass8_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass8_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass8_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass8_.item.PartLabelTitle;
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass8_.item.PartTitle;
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
		if (objectType == "CmpProject")
		{
			base.ViewBag.StatusGroupslist = SelectConversationStatusGroups();
		}
		return View(list);
	}

	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public string UpdateLinkAccSettin_Old(string setting, string objType)
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
			_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
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
			_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccHolooSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccHolooSettingDetails_Result> data = new List<CRMspSelectLinkAccHolooSettingDetails_Result>();
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
				_dbLink.CRMspInsertLinkAccHolooSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				data = Enumerable.ToList<CRMspSelectLinkAccHolooSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingDetails_Result>)_dbLink.CRMspSelectLinkAccHolooSettingDetails(0, objId, objType, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
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
			List<CRMspSelectLinkAccHolooSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHolooSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingDetails_Result>)_dbLink.CRMspSelectLinkAccHolooSettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccHolooSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_1();
					_003C_003Ec__DisplayClass12_.item = enumerator.Current;
					DbSet<CrmLinkAccHolooSettingDetails_Lang> crmLinkAccHolooSettingDetails_Lang = _dbTbl.CrmLinkAccHolooSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccHolooSettingDetails_Lang), "c");
					List<CrmLinkAccHolooSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccHolooSettingDetails_Lang>((IEnumerable<CrmLinkAccHolooSettingDetails_Lang>)Queryable.Where<CrmLinkAccHolooSettingDetails_Lang>((IQueryable<CrmLinkAccHolooSettingDetails_Lang>)crmLinkAccHolooSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccHolooSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccHolooSettingDetails> crmLinkAccHolooSettingDetails = _dbTbl.CrmLinkAccHolooSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccHolooSettingDetails), "c");
					CrmLinkAccHolooSettingDetails crmLinkAccHolooSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccHolooSettingDetails>(Queryable.Where<CrmLinkAccHolooSettingDetails>((IQueryable<CrmLinkAccHolooSettingDetails>)crmLinkAccHolooSettingDetails, Expression.Lambda<Func<CrmLinkAccHolooSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccHolooSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccHolooSettingDetails_Lang>)list3, (Func<CrmLinkAccHolooSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccHolooSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccHolooSettingDetails2.Description,
						LanguageId = result
					});
					text = _003C_003Ec__DisplayClass12_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass12_.item.LinkAccHolooSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass12_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass12_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass12_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass12_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass12_.item.LinkAccHolooSettingId;
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
				_dbLink.CRMspUpdateLinkAccHolooSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
	public string GetHolooPrdUnit_Old()
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
			List<CRMspSelectLinkAccHolooSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			string text2 = "";
			CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
			if (cRMspSelectLinkAccHolooSetting_Result != null)
			{
				text2 = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
			}
			string text3 = "";
			CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
			if (cRMspSelectLinkAccHolooSetting_Result2 != null)
			{
				text3 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
			}
			string text4 = "";
			CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
			if (cRMspSelectLinkAccHolooSetting_Result3 != null)
			{
				text4 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
			}
			string text5 = "";
			CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
			if (cRMspSelectLinkAccHolooSetting_Result4 != null)
			{
				text5 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
			}
			string value3 = "";
			if (string.IsNullOrWhiteSpace(text2) || string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text4) || string.IsNullOrWhiteSpace(text5))
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
			holooLoginViewModel.userinfo = new HolooUserInfoViewModel
			{
				dbname = text3,
				username = text4,
				userpass = text5
			};
			string text6 = "api/Login";
			HttpResponseMessage result2 = new HttpClient
			{
				Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
				BaseAddress = new Uri(text2 + text6),
				DefaultRequestHeaders = 
				{
					Accept = 
					{
						new MediaTypeWithQualityHeaderValue("application/json")
					}
				}
			}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text2 + text6).Result;
			if (result2.IsSuccessStatusCode)
			{
				HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (holooLoginResultViewModel == null)
				{
					return Messages.msgErrorRunFunction + "<br> Error in login";
				}
				if (holooLoginResultViewModel.Login == null)
				{
					return Messages.msgErrorRunFunction + "<br> Error in login";
				}
				if (!holooLoginResultViewModel.Login.State)
				{
					string msgErrorRunFunction = Messages.msgErrorRunFunction;
					string error = holooLoginResultViewModel.Login.Error;
					_ = holooLoginResultViewModel.Login.ErrorCode;
					return string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode);
				}
				value3 = holooLoginResultViewModel.Login.Token ?? "";
			}
			else
			{
				Exception e = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorRunFunction + "<br> Token is null|";
			}
			if (!string.IsNullOrWhiteSpace(value3))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text2);
				httpClient.DefaultRequestHeaders.Add("Authorization", value3);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "api/Unit";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					return Messages.msgErrorRunFunction + " (get list from Holoo) ";
				}
				string result4 = result3.Content.ReadAsStringAsync().Result;
				if (string.IsNullOrEmpty(result4))
				{
					return Messages.msgErrorRunFunction + " (list is empty) ";
				}
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkHolooWSInsertUpdateProductUnitsFromHoloo(result4, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, null);
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetHolooPrdUnit(int linkAccSettingDBId = 0)
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
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			string text2 = holooProvider.Authenticate();
			if (!string.IsNullOrEmpty(text2))
			{
				return text2;
			}
			return holooProvider.GetPrdUnit(linkAccSettingDBId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult LinkAccHolooSettingUser()
	{
		return View();
	}

	public List<CRMspSelectLinkAccHolooSettingUsers_Result> ListLinkAccHolooSettingUsers()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccHolooSettingUsers_Result> list = new List<CRMspSelectLinkAccHolooSettingUsers_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccHolooSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingUsers_Result>)_dbLink.CRMspSelectLinkAccHolooSettingUsers(0, 0, lCID, result));
			foreach (CRMspSelectLinkAccHolooSettingUsers_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				if (!string.IsNullOrWhiteSpace(item.Password))
				{
					item.Password = "******";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LinkAccHolooSettingUsers_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListLinkAccHolooSettingUsers()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListLinkAccHolooSettingUsers()
	{
		return Json(ListLinkAccHolooSettingUsers(), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult LinkAccSettingUser(int linkAccSettingDBId)
	{
		base.ViewBag.LinkAccSettingDBId = linkAccSettingDBId;
		return View();
	}

	public List<CRMspSelectLinkAccSettingUsers_Result> ListLinkAccSettingUsers(int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingUsers_Result> list = new List<CRMspSelectLinkAccSettingUsers_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(0, linkAccSettingDBId, 0, lCID, result));
			foreach (CRMspSelectLinkAccSettingUsers_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				if (!string.IsNullOrWhiteSpace(item.Password))
				{
					item.Password = "******";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LinkAccSettingUsers_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId)
	{
		return Json(((IEnumerable)ListLinkAccSettingUsers(linkAccSettingDBId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListLinkAccSettingUsers(int linkAccSettingDBId)
	{
		return Json(ListLinkAccSettingUsers(linkAccSettingDBId), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string ActDeleteLinkAccHolooSettingUser(int linkSettingUserId)
	{
		string text = "";
		try
		{
			if (linkSettingUserId > 0)
			{
				try
				{
					mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspDeleteLinkAccHolooSettingUser(linkSettingUserId));
					int result = 0;
					if (mct_Link_Result != null)
					{
						int.TryParse(mct_Link_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.msgErrorRunFunction;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public string ActDeleteLinkAccSettingUser(int linkSettingUserId)
	{
		string text = "";
		try
		{
			if (linkSettingUserId > 0)
			{
				try
				{
					mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspDeleteLinkAccSettingUser(linkSettingUserId));
					int result = 0;
					if (mct_Link_Result != null)
					{
						int.TryParse(mct_Link_Result.Result.ToString(), out result);
					}
					if (result == 1)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.msgErrorRunFunction;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Messages.frmErrorMessage;
		}
	}

	public ActionResult LinkAccHolooSettingUserInsertEdit(int linkAccHolooSettingUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccHolooSettingUsersLanguageViewModel crmLinkAccHolooSettingUsersLanguageViewModel = new CrmLinkAccHolooSettingUsersLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actSetting", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			if (linkAccHolooSettingUserId > 0)
			{
				CRMspSelectLinkAccHolooSettingUsers_Result cRMspSelectLinkAccHolooSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingUsers_Result>)_dbLink.CRMspSelectLinkAccHolooSettingUsers(linkAccHolooSettingUserId, 0, lCID, result));
				if (cRMspSelectLinkAccHolooSettingUsers_Result != null)
				{
					crmLinkAccHolooSettingUsersLanguageViewModel.LinkAccHolooSettingUserId = cRMspSelectLinkAccHolooSettingUsers_Result.LinkAccHolooSettingUserId;
					crmLinkAccHolooSettingUsersLanguageViewModel.CrmUserId = cRMspSelectLinkAccHolooSettingUsers_Result.CrmUserId;
					crmLinkAccHolooSettingUsersLanguageViewModel.UserName = cRMspSelectLinkAccHolooSettingUsers_Result.UserName;
					crmLinkAccHolooSettingUsersLanguageViewModel.Password = cRMspSelectLinkAccHolooSettingUsers_Result.Password;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmLinkAccHolooSettingUsersLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult LinkAccHolooSettingUserInsertEdit(CrmLinkAccHolooSettingUsersLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid && num == 0)
		{
			_ = DateTime.Now;
			try
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				short value3 = short.Parse(Financial.Get().Id.ToString());
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				if (model.LinkAccHolooSettingUserId > 0)
				{
					CRMspSelectLinkAccHolooSettingUsers_Result cRMspSelectLinkAccHolooSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingUsers_Result>)_dbLink.CRMspSelectLinkAccHolooSettingUsers(model.LinkAccHolooSettingUserId, 0, lCID, result));
					model.Password = ((!string.IsNullOrEmpty(model.Password)) ? model.Password : null);
					string text2 = ((!string.IsNullOrEmpty(model.Password)) ? XorCipher.EncryptByPrivateKey(model.Password) : null);
					if (!string.IsNullOrEmpty(cRMspSelectLinkAccHolooSettingUsers_Result.Password))
					{
						XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccHolooSettingUsers_Result.Password);
					}
					bool num2 = text2 == cRMspSelectLinkAccHolooSettingUsers_Result.Password;
					bool flag = model.Password == cRMspSelectLinkAccHolooSettingUsers_Result.Password;
					if (!num2 && !flag)
					{
						model.Password = text2;
					}
				}
				else
				{
					model.Password = ((!string.IsNullOrEmpty(model.Password)) ? XorCipher.EncryptByPrivateKey(model.Password) : null);
				}
				_dbLink.CRMspInsertUpdateLinkAccHolooSettingUsers(model.LinkAccHolooSettingUserId, model.CrmUserId, model.UserName, model.Password, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				if (result2 > 0)
				{
					if (model.LinkAccHolooSettingUserId <= 0)
					{
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					model.LinkAccHolooSettingUserId = result2;
				}
				else
				{
					switch (result2)
					{
					case 0:
						text = Messages.msgErrorRunFunction;
						break;
					case -10:
						text = string.Format(Messages.msgErrorDupLinkAccHolooSettingUsers, Labels.Holoo);
						break;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.msgErrorRunFunction;
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	public ActionResult LinkAccSettingUserInsertEdit(int linkAccSettingDBId, int linkAccSettingUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingUsersLanguageViewModel crmLinkAccSettingUsersLanguageViewModel = new CrmLinkAccSettingUsersLanguageViewModel();
		_ = DateTime.Now;
		base.ViewBag.LinkAccSettingDBId = linkAccSettingDBId;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actSetting", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			if (linkAccSettingUserId > 0)
			{
				CRMspSelectLinkAccSettingUsers_Result cRMspSelectLinkAccSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(linkAccSettingUserId, linkAccSettingDBId, 0, lCID, result));
				if (cRMspSelectLinkAccSettingUsers_Result != null)
				{
					crmLinkAccSettingUsersLanguageViewModel.LinkAccSettingUserId = cRMspSelectLinkAccSettingUsers_Result.LinkAccSettingUserId;
					crmLinkAccSettingUsersLanguageViewModel.CrmUserId = cRMspSelectLinkAccSettingUsers_Result.CrmUserId;
					crmLinkAccSettingUsersLanguageViewModel.UserName = cRMspSelectLinkAccSettingUsers_Result.UserName;
					crmLinkAccSettingUsersLanguageViewModel.Password = cRMspSelectLinkAccSettingUsers_Result.Password;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmLinkAccSettingUsersLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult LinkAccSettingUserInsertEdit(CrmLinkAccSettingUsersLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid && num == 0)
		{
			_ = DateTime.Now;
			try
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				short value3 = short.Parse(Financial.Get().Id.ToString());
				string appType = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("InsertedId", 0);
				if (model.LinkAccSettingUserId > 0)
				{
					CRMspSelectLinkAccSettingUsers_Result cRMspSelectLinkAccSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccSettingUsers_Result>)_dbLink.CRMspSelectLinkAccSettingUsers(model.LinkAccSettingUserId, model.LinkAccSettingDBId, 0, lCID, result));
					model.Password = ((!string.IsNullOrEmpty(model.Password)) ? model.Password : null);
					string text2 = ((!string.IsNullOrEmpty(model.Password)) ? XorCipher.EncryptByPrivateKey(model.Password) : null);
					if (!string.IsNullOrEmpty(cRMspSelectLinkAccSettingUsers_Result.Password))
					{
						XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccSettingUsers_Result.Password);
					}
					bool num2 = text2 == cRMspSelectLinkAccSettingUsers_Result.Password;
					bool flag = model.Password == cRMspSelectLinkAccSettingUsers_Result.Password;
					if (!num2 && !flag)
					{
						model.Password = text2;
					}
				}
				else
				{
					model.Password = ((!string.IsNullOrEmpty(model.Password)) ? XorCipher.EncryptByPrivateKey(model.Password) : null);
				}
				_dbLink.CRMspInsertUpdateLinkAccSettingUsers(model.LinkAccSettingUserId, model.LinkAccSettingDBId, model.CrmUserId, model.UserName, model.Password, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
				int result2 = 0;
				if (objectParameter != null && objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
				{
					int.TryParse(objectParameter.Value.ToString(), out result2);
				}
				if (result2 > 0)
				{
					if (model.LinkAccSettingUserId <= 0)
					{
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
					else
					{
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					model.LinkAccSettingUserId = result2;
				}
				else
				{
					switch (result2)
					{
					case 0:
						text = Messages.msgErrorRunFunction;
						break;
					case -10:
						text = string.Format(Messages.msgErrorDupLinkAccHolooSettingUsers, Labels.Holoo);
						break;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.msgErrorRunFunction;
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		base.ViewBag.LinkAccSettingDBId = model.LinkAccSettingDBId;
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetCrmUser()
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
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, 0));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.UserId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpGet]
	[AjaxOnly]
	public JsonResult GetLinkAccHolooSettingUserPassword(int linkAccHolooSettingUserId, string inputPassword, int mode)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectLinkAccHolooSettingUsers_Result cRMspSelectLinkAccHolooSettingUsers_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSettingUsers_Result>((IEnumerable<CRMspSelectLinkAccHolooSettingUsers_Result>)_dbLink.CRMspSelectLinkAccHolooSettingUsers(linkAccHolooSettingUserId, 0, lCID, result));
		string obj = ((!string.IsNullOrEmpty(inputPassword)) ? XorCipher.EncryptByPrivateKey(inputPassword) : null);
		string text = ((!string.IsNullOrEmpty(cRMspSelectLinkAccHolooSettingUsers_Result.Password)) ? XorCipher.DecryptByPrivateKey(cRMspSelectLinkAccHolooSettingUsers_Result.Password) : null);
		bool num = obj == cRMspSelectLinkAccHolooSettingUsers_Result.Password;
		bool flag = inputPassword == cRMspSelectLinkAccHolooSettingUsers_Result.Password;
		if (!num && !flag)
		{
			return Json(new
			{
				data = inputPassword
			}, JsonRequestBehavior.AllowGet);
		}
		return Json(new
		{
			data = ((mode == 1) ? text : cRMspSelectLinkAccHolooSettingUsers_Result.Password)
		}, JsonRequestBehavior.AllowGet);
	}

	public List<CRMspSelectLinkAccSettingDB_Result> GetLinkAccHolooDatabases()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectLinkAccSettingDB_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, null, lCID, result));
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list2, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
			{
				Text = item.LinkAccSettingDbTitle,
				Value = item.LinkAccSettingDBId.ToString(),
				Selected = false
			})));
		}
		base.ViewBag.LinkAccSettingDBList = list;
		return list2;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult ShowLinkAccSettingDB()
	{
		return View();
	}

	public List<CRMspSelectLinkAccSettingDB_Result> ListLinkAccSettingDB()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingDB_Result> list = new List<CRMspSelectLinkAccSettingDB_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(linkAccSettingDBId: 0, linkAccSystemId: 4, languageID: lCID, defaultLanguageID: result));
			foreach (CRMspSelectLinkAccSettingDB_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult LinkAccSettingDB_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListLinkAccSettingDB()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListLinkAccSettingDB()
	{
		return Json(ListLinkAccSettingDB(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public string ActDeActiveLinkAccSettingDB(int linkAccSettingDbId)
	{
		string text = "";
		try
		{
			if (linkAccSettingDbId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					_dbLink.CRMspUpdateLinkAccSettingDBIsActive(linkAccSettingDbId, false, userId, value3, value2, value, registerDatePersian, appType);
					return "1";
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction;
		}
	}

	public ActionResult InsertEditLinkAccSettingDB(int linkAccSettingDbId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingDBLanguageViewModel crmLinkAccSettingDBLanguageViewModel = new CrmLinkAccSettingDBLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			if (!UserLogin.IsUserAccess("frmMain", "actSetting", UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			CRMspSelectLinkAccSettingDB_Result cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
			if (linkAccSettingDbId == 0)
			{
				cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
				cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId = 0;
				cRMspSelectLinkAccSettingDB_Result.LinkAccSystemId = 4;
				base.ViewBag.LinkAccSettingDBList = new List<SelectListItem>();
			}
			else
			{
				cRMspSelectLinkAccSettingDB_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(linkAccSettingDBId: linkAccSettingDbId, linkAccSystemId: 4, languageID: lCID, defaultLanguageID: result));
				if (cRMspSelectLinkAccSettingDB_Result == null)
				{
					cRMspSelectLinkAccSettingDB_Result = new CRMspSelectLinkAccSettingDB_Result();
					cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId = 0;
					cRMspSelectLinkAccSettingDB_Result.LinkAccSystemId = 4;
				}
			}
			crmLinkAccSettingDBLanguageViewModel = new CrmLinkAccSettingDBLanguageViewModel
			{
				LinkAccSettingDBId = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDBId,
				LinkAccSettingDbTitle = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDbTitle,
				LinkAccSettingDbName = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingDbName,
				IsActive = cRMspSelectLinkAccSettingDB_Result.IsActive,
				OrderView = cRMspSelectLinkAccSettingDB_Result.OrderView,
				LinkAccSettingServerName = cRMspSelectLinkAccSettingDB_Result.LinkAccSettingServerName
			};
			if (crmLinkAccSettingDBLanguageViewModel.LinkAccSettingDBId == 0)
			{
				int maxAccDbCount = Configuration.MaxAccDbCount;
				List<SelectListItem> linkAccSettingDB = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(4);
				if (linkAccSettingDB != null)
				{
					int num = Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)linkAccSettingDB);
					if (num != 0 && maxAccDbCount <= num)
					{
						base.ViewBag.ErrActiveDbCnt = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Holoo, maxAccDbCount.ToString());
					}
				}
				crmLinkAccSettingDBLanguageViewModel.OrderView = 10;
				List<CRMspSelectLinkAccSettingDB_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, 0, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list))
				{
					CRMspSelectLinkAccSettingDB_Result cRMspSelectLinkAccSettingDB_Result2 = Enumerable.LastOrDefault<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list);
					if (cRMspSelectLinkAccSettingDB_Result2 != null)
					{
						crmLinkAccSettingDBLanguageViewModel.OrderView = cRMspSelectLinkAccSettingDB_Result2.OrderView.GetValueOrDefault() + 10;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(crmLinkAccSettingDBLanguageViewModel);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmsysSetting", ActionName = "actPost")]
	public ActionResult InsertEditLinkAccSettingDB(CrmLinkAccSettingDBLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		base.ModelState.Remove("LinkAccSettingServerName");
		GetLinkAccHolooDatabases();
		if (base.ModelState.IsValid)
		{
			if (model.LinkAccSettingDBId == 0)
			{
				int maxAccDbCount = Configuration.MaxAccDbCount;
				List<SelectListItem> linkAccSettingDB = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(4);
				if (linkAccSettingDB != null)
				{
					int num2 = Enumerable.Count<SelectListItem>((IEnumerable<SelectListItem>)linkAccSettingDB);
					if (num2 != 0 && maxAccDbCount <= num2)
					{
						text = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Holoo, maxAccDbCount.ToString());
						base.ViewBag.ErrActiveDbCnt = string.Format(Messages.msgErrorNotsaveMoreThanLinkAccSettingDB, Labels.Holoo, maxAccDbCount.ToString());
						num++;
					}
				}
			}
			if (string.IsNullOrWhiteSpace(model.LinkAccSettingDbName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.LinkAccSettingDbName) + "<br/>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(model.LinkAccSettingDbTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.LinkAccSettingDbTitle) + "<br/>";
				num++;
			}
			if (num == 0)
			{
				_ = DateTime.Now;
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					short value3 = short.Parse(Financial.Get().Id.ToString());
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					if (model.LinkAccSettingDBId > 0)
					{
						_dbLink.CRMspUpdateLinkAccSettingDB(model.LinkAccSettingDBId, model.OrderView, model.LinkAccSettingDbTitle, userId, value3, value2, value, registerDatePersian, appType);
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						ObjectParameter objectParameter = new ObjectParameter("insertedLinkAccSettingDBId", typeof(int));
						ObjectParameter objectParameter2 = new ObjectParameter("errorCode", typeof(int));
						_dbLink.CRMspInsertLinkAccSettingDB(4, model.LinkAccSettingDbName, true, model.OrderView, model.LinkAccSettingDbTitle, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter, objectParameter2, model.LinkAccSettingServerName);
						int result2 = 0;
						if (objectParameter != null && objectParameter.Value != null)
						{
							int.TryParse(objectParameter.Value.ToString(), out result2);
						}
						int result3 = 0;
						if (objectParameter2 != null && objectParameter2.Value != null)
						{
							int.TryParse(objectParameter2.Value.ToString(), out result3);
						}
						if (result2 != 0)
						{
							model.LinkAccSettingDBId = result2;
							base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
						}
						else
						{
							if (result3 == -1)
							{
								text = Messages.msgErrorRunFunction;
							}
							if (result3 == -2)
							{
								text = Messages.msgErrorNotPossibleSaveDupDatabase;
							}
						}
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (!string.IsNullOrWhiteSpace(text))
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetLinkAccSettingDBActive()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(4);
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
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
			List<CRMspSelectConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result));
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		base.Dispose(disposing);
	}
}
