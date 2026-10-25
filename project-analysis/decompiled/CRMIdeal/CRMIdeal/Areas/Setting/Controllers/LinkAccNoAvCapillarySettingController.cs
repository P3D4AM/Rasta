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
using CRM.OtherWebServices.LinkNoAvaranCapillary;
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

public class LinkAccNoAvCapillarySettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass13_1
	{
		public CRMspSelectLinkAccSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_3
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
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
		int value = 18;
		int value2 = -1;
		List<CRMspSelectLinkAccSetting_Result> list = new List<CRMspSelectLinkAccSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objType, lCID, result, value, value2, null));
				foreach (CRMspSelectLinkAccSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.ObjectType ?? "") == "Product" && (item.PartTitle ?? "") == "PrdLinkedField")
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

	[AjaxOnly]
	public JsonResult GetOtherPartLinkAccSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 18;
		int value2 = -1;
		CrmLinkAccNoAvaranCapillarySettingOtherPartViewModel crmLinkAccNoAvaranCapillarySettingOtherPartViewModel = new CrmLinkAccNoAvaranCapillarySettingOtherPartViewModel();
		crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSetting = new CRMspSelectLinkAccSetting_Result();
		crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, null, lCID, result, value, value2, null));
			if (list != null)
			{
				int result2 = 0;
				crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSetting = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrderOpr" && (m.PartTitle ?? "") == "PordOprFieldLinkTokindFactor")));
				if (crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSetting == null)
				{
					crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSetting = new CRMspSelectLinkAccSetting_Result();
				}
				else
				{
					int.TryParse(crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSetting.PartValue, out result2);
				}
				int result3 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrderOpr" && (m.PartTitle ?? "") == "PordOprkindFactor")));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result3);
				}
				crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "PreOrderOpr", lCID, result, value, value2));
				if (crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails == null)
				{
					crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails = new List<CRMspSelectLinkAccSettingDetails_Result>();
				}
				if (crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails != null)
				{
					if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails))
					{
						switch (result2)
						{
						case 1:
						{
							List<SelectListItem> preOrderOprList = GetPreOrderOprList();
							if (preOrderOprList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList))
							{
								break;
							}
							foreach (SelectListItem item5 in preOrderOprList)
							{
								int pordOprId = 0;
								int.TryParse(item5.Value, out pordOprId);
								if (pordOprId == 0)
								{
									continue;
								}
								bool flag2 = false;
								if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)) != null)
								{
									flag2 = true;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)) != null)
									{
										Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)).ObjectTypeTitle = item5.Text ?? "";
									}
								}
								if (!flag2)
								{
									CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result3,
										ObjectId = pordOprId,
										PartTitle = "PordOprkindFactor",
										ObjectTypeTitle = (item5.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails.Add(item2);
								}
							}
							break;
						}
						case 2:
						{
							List<SelectListItem> preOrderTypeList = GetPreOrderTypeList();
							if (preOrderTypeList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList))
							{
								break;
							}
							foreach (SelectListItem item6 in preOrderTypeList)
							{
								int pordTypeId = 0;
								int.TryParse(item6.Value, out pordTypeId);
								if (pordTypeId == 0)
								{
									continue;
								}
								bool flag = false;
								if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)) != null)
								{
									flag = true;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)) != null)
									{
										Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)).ObjectTypeTitle = item6.Text ?? "";
									}
								}
								if (!flag)
								{
									CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result3,
										ObjectId = pordTypeId,
										PartTitle = "PordOprkindFactor",
										ObjectTypeTitle = (item6.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails.Add(item);
								}
							}
							break;
						}
						}
					}
					else
					{
						switch (result2)
						{
						case 1:
						{
							List<SelectListItem> preOrderOprList2 = GetPreOrderOprList();
							if (preOrderOprList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList2))
							{
								break;
							}
							foreach (SelectListItem item7 in preOrderOprList2)
							{
								int result5 = 0;
								int.TryParse(item7.Value, out result5);
								if (result5 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item4 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result3,
										ObjectId = result5,
										PartTitle = "PordOprkindFactor",
										ObjectTypeTitle = (item7.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails.Add(item4);
								}
							}
							break;
						}
						case 2:
						{
							List<SelectListItem> preOrderTypeList2 = GetPreOrderTypeList();
							if (preOrderTypeList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList2))
							{
								break;
							}
							foreach (SelectListItem item8 in preOrderTypeList2)
							{
								int result4 = 0;
								int.TryParse(item8.Value, out result4);
								if (result4 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item3 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result3,
										ObjectId = result4,
										PartTitle = "PordOprkindFactor",
										ObjectTypeTitle = (item8.Text ?? ""),
										ObjectType = "PreOrderOpr"
									};
									crmLinkAccNoAvaranCapillarySettingOtherPartViewModel.PordOprkindFactorSettingDetails.Add(item3);
								}
							}
							break;
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
		JsonResult jsonResult = Json(crmLinkAccNoAvaranCapillarySettingOtherPartViewModel, JsonRequestBehavior.AllowGet);
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
			int value = 18;
			int value2 = -1;
			List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, objectType, currLangID, result, value, value2, null));
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
					CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
					crmLinkAccSettingOtherLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingOtherLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass8_.item.PartTitle;
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
		int value = 18;
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
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if ((item.PartTitle ?? "") == "PayDateType" || (item.PartTitle ?? "") == "PayDateFirstType" || (item.PartTitle ?? "") == "DateRasType" || (item.PartTitle ?? "") == "PayCheckDateType")
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
					else if ((item.PartTitle ?? "") == "PayKindSabt")
					{
						switch (item.PartValue)
						{
						case "0":
							item.PartValue = Labels.LinkAccSettingChqeue;
							break;
						case "1":
							item.PartValue = Labels.LinkAccSettingDeposit;
							break;
						case "2":
							item.PartValue = Labels.LinkAccSettingCash;
							break;
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
		int value = 18;
		int value2 = -1;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			if (objType == "PreOrderOpr")
			{
				int result2 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", currLangID, result, value, value2, "PordOprFieldLinkTokindFactor"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
					int result3 = 0;
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result3);
					CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
					{
						LinkAccSettingDetailId = -1 * result3,
						LinkAccSettingId = result3,
						ObjectId = result3,
						PartTitle = "PordOprFieldLinkTokindFactor",
						ObjectType = "PreOrderOpr",
						PartValue = result2.ToString()
					};
					list2.Add(item);
				}
			}
			else
			{
				list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, currLangID, result, value, value2));
			}
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass11_1 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_1();
					_003C_003Ec__DisplayClass11_.item = enumerator.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass11_, typeof(_003C_003Ec__DisplayClass11_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass11_, typeof(_003C_003Ec__DisplayClass11_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
					text = _003C_003Ec__DisplayClass11_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass11_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass11_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass11_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass11_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass11_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass11_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass11_.item.PartTitle;
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
				}
			}
			else
			{
				_ = objType == "PreOrderOpr";
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
		//IL_0073: Unknown result type (might be due to invalid IL or missing references)
		//IL_0271: Unknown result type (might be due to invalid IL or missing references)
		//IL_0650: Unknown result type (might be due to invalid IL or missing references)
		//IL_0476: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 18;
		int value2 = -1;
		string result = "1";
		try
		{
			if (objId != 0 && !string.IsNullOrEmpty(objType))
			{
				List<CrmLinkAccSettingDetailsViewModel> list = new List<CrmLinkAccSettingDetailsViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<CrmLinkAccSettingDetailsViewModel>>(settingDetail);
				DateTime now = DateTime.Now;
				int userId = UserLogin.CurrentUser.UserId;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
				DateTime value5 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				string appType = Configuration.AppType;
				string text = "";
				string text2 = "";
				bool flag = true;
				if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list) && objType.ToLower() == "preorderopr")
				{
					List<CRMspSelectLinkAccSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", lCID, defLangID, value, value2, ""));
					int result2 = 0;
					int pordOrdPordOprFieldLinkTokindFactorSettingId = 0;
					if (list2 != null)
					{
						CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list2, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordOprkindFactor"));
						if (cRMspSelectLinkAccSetting_Result != null)
						{
							int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
						}
						CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list2, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordOprFieldLinkTokindFactor"));
						if (cRMspSelectLinkAccSetting_Result2 != null)
						{
							int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out pordOrdPordOprFieldLinkTokindFactorSettingId);
						}
					}
					flag = false;
					CrmLinkAccSettingDetailsViewModel crmLinkAccSettingDetailsViewModel = Enumerable.FirstOrDefault<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => (m.PartTitle ?? "") == "PordOprFieldLinkTokindFactor" && m.AccSdId == -1 * pordOrdPordOprFieldLinkTokindFactorSettingId));
					if (crmLinkAccSettingDetailsViewModel != null)
					{
						string text3 = "";
						string text4 = "";
						int num = pordOrdPordOprFieldLinkTokindFactorSettingId;
						string text5 = crmLinkAccSettingDetailsViewModel.PartValue ?? "";
						string text6 = crmLinkAccSettingDetailsViewModel.PartField ?? "";
						List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(crmLinkAccSettingDetailsViewModel.Desc_Lang))
						{
							list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(crmLinkAccSettingDetailsViewModel.Desc_Lang);
						}
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetailsViewModel.Desc,
							LanguageId = lCID
						});
						string text7 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
						{
							foreach (CommonMultiLanguageViewModel item in list4)
							{
								text4 = text4 + "[AccSettimgId=" + num + ",Desc=" + item.Value + ",LangId=" + item.LanguageId + ",]|";
							}
						}
						text3 = text3 + "[AccSettimgId=" + num + ",PartField=" + text6 + ",PartValue=" + text5 + ",Desc=" + text7 + ",]|";
						_dbLink.CRMspUpdateLinkAccSetting(text3, text4, userId, value3, value4, value5, registerDatePersian, appType, defLangID, 0);
					}
					list = Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>(Enumerable.Where<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => m.AccSdId != -1 * pordOrdPordOprFieldLinkTokindFactorSettingId)));
					if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
					{
						foreach (CrmLinkAccSettingDetailsViewModel item2 in list)
						{
							List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
							if (!string.IsNullOrEmpty(item2.Desc_Lang))
							{
								list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item2.Desc_Lang);
							}
							list5.Add(new CommonMultiLanguageViewModel
							{
								Value = item2.Desc,
								LanguageId = lCID
							});
							string desc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
							string desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							item2.Desc = desc;
							item2.Desc_Lang = desc_Lang;
						}
						string objectJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list));
						_dbLink.CRMspInsertUpdateLinkAccSettingDetails(objType, objectJson, false, result2.ToString(), true, pordOrdPordOprFieldLinkTokindFactorSettingId.ToString(), userId, value3, value4, value5, registerDatePersian, appType, defLangID, value, value2);
					}
				}
				if (list != null && flag && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
				{
					foreach (CrmLinkAccSettingDetailsViewModel item3 in list)
					{
						int accSdId = item3.AccSdId;
						string text8 = item3.PartValue ?? "";
						string text9 = item3.PartField ?? "";
						List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(item3.Desc_Lang))
						{
							list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(item3.Desc_Lang);
						}
						list6.Add(new CommonMultiLanguageViewModel
						{
							Value = item3.Desc,
							LanguageId = lCID
						});
						string text10 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7))
						{
							foreach (CommonMultiLanguageViewModel item4 in list7)
							{
								text2 = text2 + "[AccSdId=" + accSdId + ",Desc=" + item4.Value + ",LangId=" + item4.LanguageId + ",]|";
							}
						}
						text = text + "[AccSdId=" + accSdId + ",PartField=" + text9 + ",PartValue=" + text8 + ",Desc=" + text10 + ",]|";
					}
					_dbLink.CRMspUpdateLinkAccSettingDetails(objId, objType, text, text2, userId, value3, value4, value5, registerDatePersian, appType, defLangID);
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
		int value = 18;
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
						_003C_003Ec__DisplayClass13_1 _003C_003Ec__DisplayClass13_ = new _003C_003Ec__DisplayClass13_1();
						_003C_003Ec__DisplayClass13_.item = enumerator.Current;
						DbSet<CrmLinkAccSetting_Lang> crmLinkAccSetting_Lang = _dbTbl.CrmLinkAccSetting_Lang;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSetting_Lang), "c");
						List<CrmLinkAccSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccSetting_Lang>((IEnumerable<CrmLinkAccSetting_Lang>)Queryable.Where<CrmLinkAccSetting_Lang>((IQueryable<CrmLinkAccSetting_Lang>)crmLinkAccSetting_Lang, Expression.Lambda<Func<CrmLinkAccSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmLinkAccSetting> crmLinkAccSetting = _dbTbl.CrmLinkAccSetting;
						val = Expression.Parameter(typeof(CrmLinkAccSetting), "c");
						CrmLinkAccSetting crmLinkAccSetting2 = Queryable.FirstOrDefault<CrmLinkAccSetting>(Queryable.Where<CrmLinkAccSetting>((IQueryable<CrmLinkAccSetting>)crmLinkAccSetting, Expression.Lambda<Func<CrmLinkAccSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass13_, typeof(_003C_003Ec__DisplayClass13_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
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
						crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass13_.item.LinkAccSettingId;
						crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass13_.item.PartField;
						crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass13_.item.PartValue;
						crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass13_.item.PartTitle;
						crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass13_.item.PartDescription;
						crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass13_.item.PartLabelTitle;
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

	public JsonResult GetPordOprFieldLinkTokindFactorList(int pordOprFieldLinkTokindFactor)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 18;
		int value2 = -1;
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			List<CRMspSelectLinkAccSettingDetails_Result> list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			int result2 = 0;
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = new CRMspSelectLinkAccSetting_Result();
			List<CRMspSelectLinkAccSetting_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "PreOrderOpr", currLangID, result, value, value2, ""));
			int result3 = 0;
			int result4 = 0;
			if (list4 != null)
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list4, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordOprkindFactor"));
				if (cRMspSelectLinkAccSetting_Result2 != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result2.LinkAccSettingId.ToString(), out result3);
				}
				cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list4, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.PartTitle ?? "") == "PordOprFieldLinkTokindFactor"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result4);
				}
			}
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				int.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
			}
			if (result2 == pordOprFieldLinkTokindFactor)
			{
				list3 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "PreOrderOpr", currLangID, result, value, value2));
			}
			if (list3 == null)
			{
				list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			}
			if (list3 != null)
			{
				if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3))
				{
					switch (pordOprFieldLinkTokindFactor)
					{
					case 1:
					{
						List<SelectListItem> preOrderOprList = GetPreOrderOprList();
						if (preOrderOprList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList))
						{
							break;
						}
						foreach (SelectListItem item5 in preOrderOprList)
						{
							int pordOprId = 0;
							int.TryParse(item5.Value, out pordOprId);
							if (pordOprId == 0)
							{
								continue;
							}
							bool flag2 = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordOprId)).PartLabelTitle = item5.Text ?? "";
								flag2 = true;
							}
							if (!flag2)
							{
								CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = pordOprId,
									PartTitle = "PordOprkindFactor",
									ObjectTypeTitle = (item5.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item5.Text ?? "")
								};
								list3.Add(item2);
							}
						}
						break;
					}
					case 2:
					{
						List<SelectListItem> preOrderTypeList = GetPreOrderTypeList();
						if (preOrderTypeList == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList))
						{
							break;
						}
						foreach (SelectListItem item6 in preOrderTypeList)
						{
							int pordTypeId = 0;
							int.TryParse(item6.Value, out pordTypeId);
							if (pordTypeId == 0)
							{
								continue;
							}
							bool flag = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == pordTypeId)).PartLabelTitle = item6.Text ?? "";
								flag = true;
							}
							if (!flag)
							{
								CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = pordTypeId,
									PartTitle = "PordOprkindFactor",
									ObjectTypeTitle = (item6.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item6.Text ?? "")
								};
								list3.Add(item);
							}
						}
						break;
					}
					}
				}
				else
				{
					switch (pordOprFieldLinkTokindFactor)
					{
					case 1:
					{
						List<SelectListItem> preOrderOprList2 = GetPreOrderOprList();
						if (preOrderOprList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderOprList2))
						{
							break;
						}
						foreach (SelectListItem item7 in preOrderOprList2)
						{
							int result6 = 0;
							int.TryParse(item7.Value, out result6);
							if (result6 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item4 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = result6,
									PartTitle = "PordOprkindFactor",
									ObjectTypeTitle = (item7.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item7.Text ?? "")
								};
								list3.Add(item4);
							}
						}
						break;
					}
					case 2:
					{
						List<SelectListItem> preOrderTypeList2 = GetPreOrderTypeList();
						if (preOrderTypeList2 == null || !Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)preOrderTypeList2))
						{
							break;
						}
						foreach (SelectListItem item8 in preOrderTypeList2)
						{
							int result5 = 0;
							int.TryParse(item8.Value, out result5);
							if (result5 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item3 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result3,
									ObjectId = result5,
									PartTitle = "PordOprkindFactor",
									ObjectTypeTitle = (item8.Text ?? ""),
									ObjectType = "PreOrderOpr",
									PartLabelTitle = (item8.Text ?? "")
								};
								list3.Add(item3);
							}
						}
						break;
					}
					}
				}
				list2.AddRange(list3);
			}
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccSettingDetails_Result>.Enumerator enumerator2 = list2.GetEnumerator();
				while (enumerator2.MoveNext())
				{
					_003C_003Ec__DisplayClass14_3 _003C_003Ec__DisplayClass14_ = new _003C_003Ec__DisplayClass14_3();
					_003C_003Ec__DisplayClass14_.item = enumerator2.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list5 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass14_, typeof(_003C_003Ec__DisplayClass14_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
					if (list5 != null)
					{
						list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list5, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list6.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass14_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass14_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass14_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass14_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass14_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass14_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.ObjectId = _003C_003Ec__DisplayClass14_.item.ObjectId.GetValueOrDefault();
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
					list.Add(crmLinkAccSettingDetailsLanguageViewModel);
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetNoAvCapillaryPrdUnit()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				return Messages.errorInReadingSetting + "|";
			}
			string value3 = new CommercialSoapClient().ReadFromUnit();
			if (!string.IsNullOrWhiteSpace(value3))
			{
				value3 = value3.ClearHiddenCharacters();
			}
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
			}
			List<NoAvaranCapillaryProductUnitInfoViewModel> list = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProductUnitInfoViewModel>>(value3);
			List<LkWSProductUnitInfoViewModel> list2 = new List<LkWSProductUnitInfoViewModel>();
			if (list == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			if (Enumerable.Any<NoAvaranCapillaryProductUnitInfoViewModel>((IEnumerable<NoAvaranCapillaryProductUnitInfoViewModel>)list))
			{
				foreach (NoAvaranCapillaryProductUnitInfoViewModel item2 in list)
				{
					LkWSProductUnitInfoViewModel item = new LkWSProductUnitInfoViewModel
					{
						Unit = item2.Name,
						UnitLinkAccUnitIdStr = item2.id.GetValueOrDefault().ToString()
					};
					list2.Add(item);
				}
			}
			if (list2 == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			if (!Enumerable.Any<LkWSProductUnitInfoViewModel>((IEnumerable<LkWSProductUnitInfoViewModel>)list2))
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string unitJson = JsonConvert.SerializeObject(list2);
			_dbLink.CRMspLkWSInsertUpdateProductUnitByJson(unitJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
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
	public string GetNoAvCapillaryPayCondition()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting == null)
			{
				return Messages.errorInReadingSetting + "|";
			}
			if (string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				return Messages.errorInReadingSetting + "|";
			}
			string value3 = new CommercialSoapClient().ReadFromKindSale();
			if (!string.IsNullOrWhiteSpace(value3))
			{
				value3 = value3.ClearHiddenCharacters();
			}
			if (string.IsNullOrWhiteSpace(value3))
			{
				return Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
			}
			List<NoAvaranCapillaryProductUnitInfoViewModel> list = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProductUnitInfoViewModel>>(value3);
			List<LkWSPayConditionInfoViewModel> list2 = new List<LkWSPayConditionInfoViewModel>();
			if (list == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			if (Enumerable.Any<NoAvaranCapillaryProductUnitInfoViewModel>((IEnumerable<NoAvaranCapillaryProductUnitInfoViewModel>)list))
			{
				foreach (NoAvaranCapillaryProductUnitInfoViewModel item2 in list)
				{
					LkWSPayConditionInfoViewModel item = new LkWSPayConditionInfoViewModel
					{
						PayCondition = item2.Name,
						LinkAccPayConditionIdStr = item2.id.GetValueOrDefault().ToString()
					};
					list2.Add(item);
				}
			}
			if (list2 == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			if (!Enumerable.Any<LkWSPayConditionInfoViewModel>((IEnumerable<LkWSPayConditionInfoViewModel>)list2))
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			string payConditionJson = JsonConvert.SerializeObject(list2);
			_dbLink.CRMspLkWSInsertUpdatePayConditionByJson(payConditionJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				text = text + "<br>" + objectParameter.Value.ToString();
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPayCondition");
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

	public List<SelectListItem> GetNoAvaranCapillaryCompanyList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromComany("", "", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryNoAvCompanyInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryNoAvCompanyInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryNoAvCompanyInfoViewModel>((IEnumerable<NoAvaranCapillaryNoAvCompanyInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryNoAvCompanyInfoViewModel item in list2)
							{
								item.id = item.id;
								item.NameCmp = item.NameCmp.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryNoAvCompanyInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryNoAvCompanyInfoViewModel>)list2, (Func<NoAvaranCapillaryNoAvCompanyInfoViewModel, SelectListItem>)((NoAvaranCapillaryNoAvCompanyInfoViewModel item) => new SelectListItem
							{
								Text = (item.NameCmp ?? ""),
								Value = item.id.GetValueOrDefault().ToString(),
								Selected = false
							})));
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

	public List<SelectListItem> GetNoAvaranCapillaryZoneList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string value = new CommercialSoapClient().GetZoneList();
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryZoneInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryZoneInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryZoneInfoViewModel>((IEnumerable<NoAvaranCapillaryZoneInfoViewModel>)list2))
					{
						foreach (NoAvaranCapillaryZoneInfoViewModel item in list2)
						{
							item.id = item.id;
							item.Sharh = item.Sharh.TrimEnd(new char[1] { ' ' });
						}
						list.AddRange(Enumerable.Select<NoAvaranCapillaryZoneInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryZoneInfoViewModel>)list2, (Func<NoAvaranCapillaryZoneInfoViewModel, SelectListItem>)((NoAvaranCapillaryZoneInfoViewModel item) => new SelectListItem
						{
							Text = item.Sharh + " (" + item.Code.GetValueOrDefault() + ")",
							Value = item.id.GetValueOrDefault().ToString(),
							Selected = false
						})));
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

	public List<SelectListItem> GetNoAvaranCapillaryRouteList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string value = new CommercialSoapClient().GetRouteList();
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryRouteInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryRouteInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryRouteInfoViewModel>((IEnumerable<NoAvaranCapillaryRouteInfoViewModel>)list2))
					{
						foreach (NoAvaranCapillaryRouteInfoViewModel item in list2)
						{
							item.id = item.id;
							item.Sharh = item.Sharh.TrimEnd(new char[1] { ' ' });
						}
						list.AddRange(Enumerable.Select<NoAvaranCapillaryRouteInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryRouteInfoViewModel>)list2, (Func<NoAvaranCapillaryRouteInfoViewModel, SelectListItem>)((NoAvaranCapillaryRouteInfoViewModel item) => new SelectListItem
						{
							Text = item.Sharh + " (" + item.Code.GetValueOrDefault() + ")",
							Value = item.id.GetValueOrDefault().ToString(),
							Selected = false
						})));
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

	public List<SelectListItem> GetNoAvaranCapillaryPartList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string value = new CommercialSoapClient().GetPartList();
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryPartInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryPartInfoViewModel>>(value);
					if (list2 != null && Enumerable.Any<NoAvaranCapillaryPartInfoViewModel>((IEnumerable<NoAvaranCapillaryPartInfoViewModel>)list2))
					{
						foreach (NoAvaranCapillaryPartInfoViewModel item in list2)
						{
							item.Id = item.Id;
							item.Dis = item.Dis.TrimEnd(new char[1] { ' ' });
						}
						list.AddRange(Enumerable.Select<NoAvaranCapillaryPartInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryPartInfoViewModel>)list2, (Func<NoAvaranCapillaryPartInfoViewModel, SelectListItem>)((NoAvaranCapillaryPartInfoViewModel item) => new SelectListItem
						{
							Text = item.Dis + " (" + item.Part.GetValueOrDefault() + ")",
							Value = item.Id.GetValueOrDefault().ToString(),
							Selected = false
						})));
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

	public List<SelectListItem> GetPreOrderOprList()
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
			List<WSspSelectPreOrderOpr_Result> list2 = Enumerable.ToList<WSspSelectPreOrderOpr_Result>((IEnumerable<WSspSelectPreOrderOpr_Result>)_db.WSspSelectPreOrderOpr(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectPreOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderOpr_Result>)list2, (Func<WSspSelectPreOrderOpr_Result, SelectListItem>)((WSspSelectPreOrderOpr_Result item) => new SelectListItem
				{
					Text = item.PreOrderOpr,
					Value = item.PreOrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetPreOrderTypeList()
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
			List<WSspSelectPreOrderTypes_Result> list2 = PreOrder.SelectPreOrderTypes();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectPreOrderTypes_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderTypes_Result>)list2, (Func<WSspSelectPreOrderTypes_Result, SelectListItem>)((WSspSelectPreOrderTypes_Result item) => new SelectListItem
				{
					Text = item.PreOrderType,
					Value = item.PreOrderTypeId.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
