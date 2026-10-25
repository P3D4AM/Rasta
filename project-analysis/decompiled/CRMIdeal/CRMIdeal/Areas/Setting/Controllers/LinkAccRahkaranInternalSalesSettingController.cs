using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccRahkaranInternalSalesSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass12_1
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
		GetOrdSettlementType();
		GetPordPayCondition();
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
			int value = 22;
			int value2 = -1;
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, lCID, result, value, value2, null));
				foreach (CRMspSelectLinkAccSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.ObjectType ?? "") == "Setting" && (item.PartTitle ?? "") == "ApiPassword")
					{
						item.PartValue = "******";
					}
					else if ((item.ObjectType ?? "") == "Product" && (item.PartTitle ?? "") == "PrdLinkedField")
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
					else if ((item.ObjectType ?? "") == "Setting" && (item.PartTitle ?? "") == "DefCurrencyUnitId")
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
						if (!((item.ObjectType ?? "") == "CmpProject") || !((item.PartTitle ?? "") == "DefPrjCvnsStatusGroupId"))
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
			int value = 22;
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
		if (objectType == "CmpProject")
		{
			base.ViewBag.StatusGroupslist = SelectConversationStatusGroups();
		}
		if (objectType == "Setting")
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
				_dbLink.CRMspUpdateLinkAccSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID, 0);
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
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 22;
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
				_dbLink.CRMspInsertLinkAccSettingDetails(objId, objType, userId, value3, value4, value5, registerDatePersian, appType, result, value, value2);
				list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, lCID, result, value, value2));
				foreach (CRMspSelectLinkAccSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue) || (!((item.PartTitle ?? "") == "HeaderDateType") && !((item.PartTitle ?? "") == "DetailDateType")))
					{
						continue;
					}
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
		int value = 22;
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
					_003C_003Ec__DisplayClass10_1 _003C_003Ec__DisplayClass10_ = new _003C_003Ec__DisplayClass10_1();
					_003C_003Ec__DisplayClass10_.item = enumerator.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass10_, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
					text = _003C_003Ec__DisplayClass10_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass10_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass10_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass10_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass10_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass10_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass10_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass10_.item.PartTitle;
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
		if (objType == "PordPayCondition" || objType == "OrdSettlementType")
		{
			bool havePayCondition = false;
			GetRahkaranCashFlowFactors(ref havePayCondition);
			base.ViewBag.HavePayCondition = havePayCondition;
		}
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
		int value = 22;
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
						_003C_003Ec__DisplayClass12_1 _003C_003Ec__DisplayClass12_ = new _003C_003Ec__DisplayClass12_1();
						_003C_003Ec__DisplayClass12_.item = enumerator.Current;
						DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
						List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
						val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
						CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass12_, typeof(_003C_003Ec__DisplayClass12_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass12_.item.LinkAccSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass12_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass12_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass12_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass12_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass12_.item.PartLabelTitle;
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
	public JsonResult GetOrdSettlementType()
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
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdSettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPordPayCondition()
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
			List<WSspSelectPayCondition_Result> list2 = Enumerable.ToList<WSspSelectPayCondition_Result>((IEnumerable<WSspSelectPayCondition_Result>)_db.WSspSelectPayCondition(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectPayCondition_Result, SelectListItem>((IEnumerable<WSspSelectPayCondition_Result>)list2, (Func<WSspSelectPayCondition_Result, SelectListItem>)((WSspSelectPayCondition_Result item) => new SelectListItem
			{
				Text = item.PayCondition,
				Value = item.PayConditionID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PordPayConditionList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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
	public string GetRahkaranCompanyGroups()
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
			List<LkCrmCompanyGroupsViewModel> customerGroup = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetCustomerGroup();
			if (customerGroup == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmCompanyGroups(customerGroup);
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
	public string GetRahkaranCompanySubGroups()
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
			List<LkCrmCompanySubGroupsViewModel> customerSubGroup = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetCustomerSubGroup();
			if (customerSubGroup == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmCompanySubGroups(customerSubGroup);
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
	public string GetRahkaranPrdUnits()
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
			List<LkWSProductUnitInfoViewModel> productUnits = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetProductUnits();
			if (productUnits == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWsProductUnits(productUnits);
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
	public string GetRahkaranCurrencyUnit()
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
			List<LkWSCurrencyUnitInfoViewModel> allCurrencies = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllCurrencies();
			if (allCurrencies == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSCurrencyUnits(allCurrencies);
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
	public string GetRahkaranSaleCenter()
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
			List<LkWSSaleCenterInfoViewModel> salesOffices = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSalesOffices();
			if (salesOffices == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSSaleCenters(salesOffices);
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
	public string GetRahkaranPreOrderType()
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
			List<LkWSPreOrderTypesInfoViewModel> salesTypes = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSalesTypes();
			if (salesTypes == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSPreOrderTypes(salesTypes);
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
	public string GetRahkaranPreOrderOpr()
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
			List<LkWSPreOrderOprInfoViewModel> sPlants = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSPlants();
			if (sPlants == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSPreOrderOpr(sPlants);
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
	public string GetRahkaranOrderOpr()
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
			List<LkWSPreOrderTypesInfoViewModel> salesTypes = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSalesTypes();
			if (salesTypes == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			List<LkWSOrderOprInfoViewModel> list = new List<LkWSOrderOprInfoViewModel>();
			if (Enumerable.Any<LkWSPreOrderTypesInfoViewModel>((IEnumerable<LkWSPreOrderTypesInfoViewModel>)salesTypes))
			{
				foreach (LkWSPreOrderTypesInfoViewModel item2 in salesTypes)
				{
					LkWSOrderOprInfoViewModel item = new LkWSOrderOprInfoViewModel
					{
						Name = item2.PreOrderType,
						LinkAccOrderOprIdStr = item2.LinkAccPreOrderTypeIdStr
					};
					list.Add(item);
				}
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSOrderOpr(list);
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
	public string GetRahkaranOrderGroup()
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
			List<LkWSPreOrderOprInfoViewModel> sPlants = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSPlants();
			if (sPlants == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			List<LkWSOrderGroupInfoViewModel> list = new List<LkWSOrderGroupInfoViewModel>();
			if (Enumerable.Any<LkWSPreOrderOprInfoViewModel>((IEnumerable<LkWSPreOrderOprInfoViewModel>)sPlants))
			{
				foreach (LkWSPreOrderOprInfoViewModel item2 in sPlants)
				{
					LkWSOrderGroupInfoViewModel item = new LkWSOrderGroupInfoViewModel
					{
						OrderGroupName = item2.PreOrderOpr,
						LinkAccGroupIdStr = item2.LinkAccPreOrderOprIdStr
					};
					list.Add(item);
				}
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSOrderGroups(list);
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
	public string GetRahkaranSaleArea()
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
			List<LkWSSaleAreaInfoViewModel> salesAreas = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetSalesAreas();
			if (salesAreas == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSSaleAreas(salesAreas);
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
	public string GetRahkaranCashes()
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
			List<LKCrmCashesViewModel> allCashes = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllCashes();
			if (allCashes == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmCashes(allCashes);
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
	public string GetRahkaranBanks()
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
			List<LKCrmBankingBanksViewModel> allBanks = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllBanks();
			if (allBanks == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmBankingBanks(allBanks);
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
	public string GetRahkaranBankBranches()
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
			List<LKCrmBankingBranchesViewModel> allBankBranches = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllBankBranches();
			if (allBankBranches == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmBankingBranches(allBankBranches);
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
	public string GetRahkaranBankAccounts()
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
			List<LKCrmBankingAccountsViewModel> allBankAccounts = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllBankAccounts();
			if (allBankAccounts == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmBankingAccounts(allBankAccounts);
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
	public string GetRahkaranAccountingOperations()
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
			List<LKWSOrderPaymentGroupsIViewModel> allAccountingOperations = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllAccountingOperations();
			if (allAccountingOperations == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSOrderPaymentGroupsI(allAccountingOperations);
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
	public string GetRahkaranCashFlowFactors()
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
			List<LKWSOrderPaymentGroupsIIViewModel> allCashFlowFactors = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetAllCashFlowFactors();
			if (allCashFlowFactors == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncWSOrderPaymentGroupsII(allCashFlowFactors);
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

	public void GetRahkaranCashFlowFactors(ref bool havePayCondition)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<SelectListItem> paymentAgreement = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetPaymentAgreement();
			if (paymentAgreement != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)paymentAgreement))
			{
				base.ViewBag.PaymentAgreementList = paymentAgreement;
				havePayCondition = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
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
