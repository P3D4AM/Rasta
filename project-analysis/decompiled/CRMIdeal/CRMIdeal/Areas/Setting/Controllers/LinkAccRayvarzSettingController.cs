using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
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
using OfficeOpenXml;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccRayvarzSettingController : Controller
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
	private sealed class _003C_003Ec__DisplayClass31_2
	{
		public CRMspSelectLinkAccSettingDetails_Result item;
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
		GetOrderOpr();
		GetOrdPayType();
		GetPreOrderObj(0);
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
			int value = 23;
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
					else if ((item.ObjectType ?? "") == "CmpProject" && (item.PartTitle ?? "") == "DefPrjCvnsStatusGroupId")
					{
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
					else
					{
						if (!((item.ObjectType ?? "") == "CmpAccountRemain") || !((item.PartTitle ?? "") == "CmpAccountRemainMode"))
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
							string text = "";
							string[] array = item.PartValue.Split(new char[1] { '-' });
							if (array != null && array.Length != 0)
							{
								string[] array2 = array;
								foreach (string text2 in array2)
								{
									if (string.IsNullOrWhiteSpace(text2))
									{
										continue;
									}
									string text3 = "";
									if (text2.ToLower() == "optfactor")
									{
										text3 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptFactor;
									}
									else if (text2.ToLower() == "optrequest")
									{
										text3 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptRequest;
									}
									else if (text2.ToLower() == "optissue")
									{
										text3 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptIssue;
									}
									else if (text2.ToLower() == "chksalertrn")
									{
										text3 = Labels.OtherSystemsLinkedRayvazAccountRemainModeChkSaleRtrn;
									}
									if (!string.IsNullOrWhiteSpace(text3))
									{
										if (!string.IsNullOrWhiteSpace(text))
										{
											text += ",";
										}
										text += text3;
									}
								}
							}
							item.PartValue = text;
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
			int value = 23;
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
			if (objectType == "OrderOpr" || objectType == "PreOrderOpr")
			{
				base.ViewBag.LinkAccSalesType = GetRayvarzSalesTypeList();
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
	public string UpdateLinkAccSetting(string setting, string objType, bool cmpAccFromLink = false)
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
			if (objType.ToLower() == "cmpaccountremain")
			{
				CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
				if (crmsysSetting != null)
				{
					crmsysSetting.CmpAccFromLink = cmpAccFromLink;
					crmsysSetting.UserId = UserLogin.CurrentUser.UserId;
					crmsysSetting.RegisterDate = DateTime.Now;
					crmsysSetting.Year1 = short.Parse(Financial.Get().Id.ToString());
					crmsysSetting.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
					crmsysSetting.AppType = Configuration.AppType;
					_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					SysSeting.Update();
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmsysSetting");
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
	public JsonResult GetSelectLinkAccSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 23;
		int value2 = -1;
		List<CRMspSelectLinkAccSettingDetails_Result> list = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			List<SelectListItem> list2 = new List<SelectListItem>();
			if (objType == "OrderOpr" || objType == "PreOrderOpr")
			{
				list2 = GetRayvarzSalesTypeList();
			}
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
					if (!string.IsNullOrWhiteSpace(item.PartValue) && ((item.PartTitle ?? "") == "OrdSalesTypeId" || (item.PartTitle ?? "") == "PordSalesTypeId") && list2 != null && !string.IsNullOrWhiteSpace(item.PartValue) && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list2))
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

	[AjaxOnly]
	public JsonResult GetSelectLinkAccSettingDetailsByObjType(int objId = 0, string objType = "", string objTypeI = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmLinkAccSettingDetailsInfoViewModel crmLinkAccSettingDetailsInfoViewModel = new CrmLinkAccSettingDetailsInfoViewModel();
		crmLinkAccSettingDetailsInfoViewModel.ListInfo = new List<CRMspSelectLinkAccSettingDetails_Result>();
		crmLinkAccSettingDetailsInfoViewModel.ListInfoI = new List<CRMspSelectLinkAccSettingDetails_Result>();
		int value = 23;
		int value2 = -1;
		try
		{
			DateTime now = DateTime.Now;
			int userId = UserLogin.CurrentUser.UserId;
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
			DateTime value5 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			if (objId != 0)
			{
				if (!string.IsNullOrWhiteSpace(objType))
				{
					_dbLink.CRMspInsertLinkAccSettingDetails(objId, objType, userId, value3, value4, value5, registerDatePersian, appType, result, value, value2);
					List<CRMspSelectLinkAccSettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objType, lCID, result, value, value2));
					if (list != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list))
					{
						foreach (CRMspSelectLinkAccSettingDetails_Result item in list)
						{
							item.AppType = item.PartValue;
							if (string.IsNullOrWhiteSpace(item.PartValue) || (!((item.PartTitle ?? "") == "DetailDateType") && !((item.PartTitle ?? "") == "HeaderDateType")))
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
						crmLinkAccSettingDetailsInfoViewModel.ListInfo = list;
					}
				}
				if (!string.IsNullOrWhiteSpace(objTypeI))
				{
					_dbLink.CRMspInsertLinkAccSettingDetails(objId, objTypeI, userId, value3, value4, value5, registerDatePersian, appType, result, value, value2);
					List<CRMspSelectLinkAccSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, objId, objTypeI, lCID, result, value, value2));
					if (list2 != null && Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list2))
					{
						foreach (CRMspSelectLinkAccSettingDetails_Result item2 in list2)
						{
							item2.AppType = item2.PartValue;
							if (string.IsNullOrWhiteSpace(item2.PartValue) || (!((item2.PartTitle ?? "") == "DetailDateType") && !((item2.PartTitle ?? "") == "HeaderDateType")))
							{
								continue;
							}
							string partValue = item2.PartValue;
							if (!(partValue == "1"))
							{
								if (partValue == "2")
								{
									item2.PartValue = Labels.LinkAccSettingPayDocDate;
								}
							}
							else
							{
								item2.PartValue = Labels.LinkAccSettingPayImportDate;
							}
						}
						crmLinkAccSettingDetailsInfoViewModel.ListInfoI = list2;
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmLinkAccSettingDetailsInfoViewModel, JsonRequestBehavior.AllowGet);
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
		int value = 23;
		int value2 = -1;
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			if (objType == "SaleCenter")
			{
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "SaleCenter", currLangID, result, value, value2, "SaleCenterAccCode"));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int result2 = 0;
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
					CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
					{
						LinkAccSettingDetailId = -1 * result2,
						LinkAccSettingId = result2,
						ObjectId = result2,
						PartTitle = "SaleCenterAccCode",
						ObjectType = "SaleCenter",
						PartValue = "0"
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
			if (objType == "OrderOpr" || objType == "PreOrderOpr")
			{
				base.ViewBag.LinkAccSalesType = GetRayvarzSalesTypeList();
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
		//IL_03c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e8: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 23;
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
				if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list) && objType.ToLower() == "salecenter")
				{
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "SaleCenter", lCID, defLangID, value, value2, "SaleCenterAccCode"));
					int saleCenterAccCodeSettingId = 0;
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out saleCenterAccCodeSettingId);
					}
					flag = false;
					list = Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>(Enumerable.Where<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list, (Func<CrmLinkAccSettingDetailsViewModel, bool>)((CrmLinkAccSettingDetailsViewModel m) => m.AccSdId != -1 * saleCenterAccCodeSettingId)));
					if (list != null && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
					{
						foreach (CrmLinkAccSettingDetailsViewModel item in list)
						{
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
							string desc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
							string desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
							item.Desc = desc;
							item.Desc_Lang = desc_Lang;
						}
						string objectJson = JsonConvert.SerializeObject(Enumerable.ToList<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list));
						_dbLink.CRMspInsertUpdateLinkAccSettingDetails(objType, objectJson, false, saleCenterAccCodeSettingId.ToString(), true, "", userId, value3, value4, value5, registerDatePersian, appType, defLangID, value, value2);
					}
				}
				if (list != null && flag && Enumerable.Any<CrmLinkAccSettingDetailsViewModel>((IEnumerable<CrmLinkAccSettingDetailsViewModel>)list))
				{
					foreach (CrmLinkAccSettingDetailsViewModel item2 in list)
					{
						int accSdId = item2.AccSdId;
						string text3 = item2.PartValue ?? "";
						string text4 = item2.PartField ?? "";
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
						string text5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : "");
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID)));
						if (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4))
						{
							foreach (CommonMultiLanguageViewModel item3 in list4)
							{
								text2 = text2 + "[AccSdId=" + accSdId + ",Desc=" + item3.Value + ",LangId=" + item3.LanguageId + ",]|";
							}
						}
						text = text + "[AccSdId=" + accSdId + ",PartField=" + text4 + ",PartValue=" + text3 + ",Desc=" + text5 + ",]|";
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
		int value = 23;
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

	[AjaxOnly]
	public JsonResult GetOtherPartLinkAccSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int value = 23;
		int value2 = -1;
		CrmLinkAccRayvarzSettingOtherPartViewModel crmLinkAccRayvarzSettingOtherPartViewModel = new CrmLinkAccRayvarzSettingOtherPartViewModel();
		crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccRayvarzSettingOtherPartViewModel.PrdCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccFromLink = false;
		crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart = new List<CRMspSelectLinkAccSetting_Result>();
		crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart = new List<CRMspSelectLinkAccSettingDetails_Result>();
		try
		{
			List<CRMspSelectLinkAccSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, null, lCID, result, value, value2, null));
			if (list != null)
			{
				crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "CmpAccountRemain")));
				if (crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart == null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				if (crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart))
				{
					foreach (CRMspSelectLinkAccSetting_Result item3 in crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccountRemainPart)
					{
						string text = item3.PartValue;
						if (string.IsNullOrWhiteSpace(text))
						{
							continue;
						}
						if ((item3.ObjectType ?? "") == "CmpAccountRemain" && (item3.PartTitle ?? "") == "CmpAccountRemainMode")
						{
							if (!string.IsNullOrWhiteSpace(text))
							{
								string text2 = "";
								string[] array = text.Split(new char[1] { '-' });
								if (array != null && array.Length != 0)
								{
									string[] array2 = array;
									foreach (string text3 in array2)
									{
										if (string.IsNullOrWhiteSpace(text3))
										{
											continue;
										}
										string text4 = "";
										if (text3.ToLower() == "optfactor")
										{
											text4 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptFactor;
										}
										else if (text3.ToLower() == "optrequest")
										{
											text4 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptRequest;
										}
										else if (text3.ToLower() == "optissue")
										{
											text4 = Labels.OtherSystemsLinkedRayvazAccountRemainModeOptIssue;
										}
										else if (text3.ToLower() == "chksalertrn")
										{
											text4 = Labels.OtherSystemsLinkedRayvazAccountRemainModeChkSaleRtrn;
										}
										if (!string.IsNullOrWhiteSpace(text4))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += ",";
											}
											text2 += text4;
										}
									}
								}
								text = text2;
							}
							else
							{
								text = "";
							}
							item3.PartValue = text;
						}
						else
						{
							if (!((item3.PartTitle ?? "") == "CmpAccountRemainCriterion"))
							{
								continue;
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								if (text.ToLower() == "1")
								{
									text = Labels.OtherSystemsTotalRemain;
								}
								else if (text.ToLower() == "2")
								{
									text = Labels.OtherSystemsDebtor + " + " + Labels.OtherSystemsCreditor;
								}
								else if (text.ToLower() == "3")
								{
									text = Labels.OtherSystemsDebtor;
								}
								else if (text.ToLower() == "4")
								{
									text = Labels.OtherSystemsCreditor;
								}
							}
							else
							{
								text = "";
							}
							item3.PartValue = text;
						}
					}
				}
				crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PreOrder")));
				if (crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart == null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				if (crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart))
				{
					foreach (CRMspSelectLinkAccSetting_Result item4 in crmLinkAccRayvarzSettingOtherPartViewModel.PreOrderPart)
					{
						string text5 = item4.PartValue;
						if (string.IsNullOrWhiteSpace(text5) || !((item4.ObjectType ?? "") == "PreOrder") || !((item4.PartTitle ?? "") == "PordLinkedToAccApiMode"))
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(text5))
						{
							if (text5.ToLower() == "1")
							{
								text5 = Labels.OtherSystemsLinkedRayvazSendModeApiIssue + " (SalesJournal)";
							}
							else if (text5.ToLower() == "2")
							{
								text5 = Labels.OtherSystemsLinkedRayvazSendModeApiProforma + " (Proforma)";
							}
						}
						else
						{
							text5 = "";
						}
						item4.PartValue = text5;
					}
				}
				crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "Order")));
				if (crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart == null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				if (crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart != null && Enumerable.Any<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart))
				{
					foreach (CRMspSelectLinkAccSetting_Result item5 in crmLinkAccRayvarzSettingOtherPartViewModel.OrderPart)
					{
						string text6 = item5.PartValue;
						if (string.IsNullOrWhiteSpace(text6) || !((item5.ObjectType ?? "") == "Order") || !((item5.PartTitle ?? "") == "OrdLinkedToAccApiMode"))
						{
							continue;
						}
						if (!string.IsNullOrWhiteSpace(text6))
						{
							if (text6.ToLower() == "1")
							{
								text6 = Labels.OtherSystemsLinkedRayvazSendModeApiIssue + " (SalesJournal)";
							}
							else if (text6.ToLower() == "2")
							{
								text6 = Labels.OtherSystemsLinkedRayvazSendModeApiProforma + " (Proforma)";
							}
						}
						else
						{
							text6 = "";
						}
						item5.PartValue = text6;
					}
				}
				crmLinkAccRayvarzSettingOtherPartViewModel.PrdCodeSettingPart = Enumerable.ToList<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "PrdCode")));
				if (crmLinkAccRayvarzSettingOtherPartViewModel.PrdCodeSettingPart == null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.PrdCodeSettingPart = new List<CRMspSelectLinkAccSetting_Result>();
				}
				int result2 = 0;
				CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>(Enumerable.Where<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)list, (Func<CRMspSelectLinkAccSetting_Result, bool>)((CRMspSelectLinkAccSetting_Result m) => (m.ObjectType ?? "") == "SaleCenter" && (m.PartTitle ?? "") == "SaleCenterAccCode")));
				if (cRMspSelectLinkAccSetting_Result != null)
				{
					int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
				}
				crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "SaleCenter", lCID, result, value, value2));
				if (crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart == null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart = new List<CRMspSelectLinkAccSettingDetails_Result>();
				}
				if (crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart != null)
				{
					if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart))
					{
						List<SelectListItem> saleCentersList = GetSaleCentersList();
						if (saleCentersList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)saleCentersList))
						{
							foreach (SelectListItem item6 in saleCentersList)
							{
								int saleCenterId = 0;
								int.TryParse(item6.Value, out saleCenterId);
								if (saleCenterId != 0)
								{
									bool flag = false;
									if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == saleCenterId)) != null)
									{
										flag = true;
									}
									if (!flag)
									{
										CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
										{
											LinkAccSettingDetailId = -1,
											LinkAccSettingId = result2,
											ObjectId = saleCenterId,
											PartTitle = "SaleCenterAccCode",
											ObjectTypeTitle = (item6.Text ?? ""),
											ObjectType = "SaleCenter",
											PartLabelTitle = (item6.Text ?? "")
										};
										crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart.Add(item);
									}
								}
							}
						}
					}
					else
					{
						List<SelectListItem> saleCentersList2 = GetSaleCentersList();
						if (saleCentersList2 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)saleCentersList2))
						{
							foreach (SelectListItem item7 in saleCentersList2)
							{
								int result3 = 0;
								int.TryParse(item7.Value, out result3);
								if (result3 != 0)
								{
									CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
									{
										LinkAccSettingDetailId = -1,
										LinkAccSettingId = result2,
										ObjectId = result3,
										PartTitle = "SaleCenterAccCode",
										ObjectTypeTitle = (item7.Text ?? ""),
										ObjectType = "SaleCenter",
										PartLabelTitle = (item7.Text ?? "")
									};
									crmLinkAccRayvarzSettingOtherPartViewModel.SaleCenterPart.Add(item2);
								}
							}
						}
					}
				}
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					crmLinkAccRayvarzSettingOtherPartViewModel.CmpAccFromLink = cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(crmLinkAccRayvarzSettingOtherPartViewModel, JsonRequestBehavior.AllowGet);
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
		base.ViewBag.RetOrdPayTypeList = list;
		base.ViewBag.PordPayTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPreOrderObj(int mode)
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
			switch (mode)
			{
			case 1:
				list = GetPreOrderOprList();
				break;
			case 2:
				list = GetPreOrderTypeList();
				break;
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PreOrderObjList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
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

	[AjaxOnly]
	public JsonResult GetSaleCenters()
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
			list = GetSaleCentersList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetSaleCentersList()
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
			List<WSspSelectSaleCenters_Result> list2 = Enumerable.ToList<WSspSelectSaleCenters_Result>((IEnumerable<WSspSelectSaleCenters_Result>)_db.WSspSelectSaleCenters(lCID, result));
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectSaleCenters_Result, SelectListItem>((IEnumerable<WSspSelectSaleCenters_Result>)list2, (Func<WSspSelectSaleCenters_Result, SelectListItem>)((WSspSelectSaleCenters_Result item) => new SelectListItem
				{
					Text = item.SaleCenterName,
					Value = item.SaleCenterId.ToString(),
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetRayvarzCompanyGroups()
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
			List<LkCrmCompanyGroupsViewModel> customerGroup = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetCustomerGroup();
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
	public string GetRayvarzCompanyTypes()
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
			List<LkCompanyTypeInfoViewModel> salesType = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetSalesType();
			if (salesType == null)
			{
				return Messages.msgErrorRunFunction + " (list is empty) ";
			}
			CRMIdeal.Classes.Helper.OtherSystems.SyncCrmCompanyTypes(salesType);
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

	public JsonResult UpdateFileExcelForLinkedProvince()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel
		{
			IsDone = true,
			Message = "",
			Tag = null
		};
		if (((NameObjectCollectionBase)base.Request.Files).Count > 0)
		{
			try
			{
				_ = DateTime.Now;
				object[,] array = null;
				int num = 0;
				int num2 = 0;
				HttpFileCollectionBase files = base.Request.Files;
				if (files != null && ((NameObjectCollectionBase)files).Count > 0)
				{
					byte[] buffer = new byte[base.Request.ContentLength];
					base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
					using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
					{
						ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
						num = excelWorksheet.Dimension.End.Column;
						num2 = excelWorksheet.Dimension.End.Row;
						array = new object[num2, num];
						array = (object[,])excelWorksheet.Cells.Value;
					}
					List<LkProvinceInfoViewModel> list = new List<LkProvinceInfoViewModel>();
					if (num2 > 0)
					{
						object[] array2 = new object[num];
						for (int i = 1; i < num2; i++)
						{
							string text = "";
							string text2 = "";
							for (int j = 0; j < num; j++)
							{
								string text3 = "";
								string text4 = "";
								array2[j] = array[i, j];
								text3 = ((array[0, j] == null) ? "" : array[0, j].ToString());
								text4 = ((array2[j] == null) ? "" : array2[j].ToString());
								if (string.IsNullOrWhiteSpace(text4) || string.IsNullOrWhiteSpace(text3))
								{
									continue;
								}
								text3 = text3.Replace("\r", "").Replace("\n", "");
								text4 = text4.Trim();
								if (!string.IsNullOrWhiteSpace(text4))
								{
									if (text3.ToLower() == "provincename")
									{
										text = text4;
									}
									if (text3.ToLower() == "province")
									{
										text2 = text4;
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
							{
								LkProvinceInfoViewModel item = new LkProvinceInfoViewModel
								{
									Province = text,
									LinkAccProvinceIdStr = text2
								};
								list.Add(item);
							}
						}
						if (list != null)
						{
							if (Enumerable.Any<LkProvinceInfoViewModel>((IEnumerable<LkProvinceInfoViewModel>)list))
							{
								string text5 = CRMIdeal.Classes.Helper.OtherSystems.SyncProvince(list);
								if (!string.IsNullOrWhiteSpace(text5))
								{
									commonReturnResultViewModel.IsDone = false;
									commonReturnResultViewModel.Message = text5;
								}
								else
								{
									commonReturnResultViewModel.IsDone = true;
									commonReturnResultViewModel.Message = "";
								}
							}
							else
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
							}
						}
						else
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
						}
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
					}
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorNotFilePath;
				}
			}
			catch (IndexOutOfRangeException e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorOrderImportExcelNotEqualColumnsByExcel;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEntered + "\n" + ex.Message;
			}
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public JsonResult UpdateFileExcelForLinkedCity()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel
		{
			IsDone = true,
			Message = "",
			Tag = null
		};
		if (((NameObjectCollectionBase)base.Request.Files).Count > 0)
		{
			try
			{
				_ = DateTime.Now;
				object[,] array = null;
				int num = 0;
				int num2 = 0;
				HttpFileCollectionBase files = base.Request.Files;
				if (files != null && ((NameObjectCollectionBase)files).Count > 0)
				{
					byte[] buffer = new byte[base.Request.ContentLength];
					base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
					using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
					{
						ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
						num = excelWorksheet.Dimension.End.Column;
						num2 = excelWorksheet.Dimension.End.Row;
						array = new object[num2, num];
						array = (object[,])excelWorksheet.Cells.Value;
					}
					List<LkCityInfoViewModel> list = new List<LkCityInfoViewModel>();
					if (num2 > 0)
					{
						object[] array2 = new object[num];
						for (int i = 1; i < num2; i++)
						{
							string text = "";
							string text2 = "";
							string text3 = "";
							for (int j = 0; j < num; j++)
							{
								string text4 = "";
								string text5 = "";
								array2[j] = array[i, j];
								text4 = ((array[0, j] == null) ? "" : array[0, j].ToString());
								text5 = ((array2[j] == null) ? "" : array2[j].ToString());
								if (string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text4))
								{
									continue;
								}
								text4 = text4.Replace("\r", "").Replace("\n", "");
								text5 = text5.Trim();
								if (!string.IsNullOrWhiteSpace(text5))
								{
									if (text4.ToLower() == "countyname")
									{
										text = text5;
									}
									if (text4.ToLower() == "county")
									{
										text2 = text5;
									}
									if (text4.ToLower() == "province")
									{
										text3 = text5;
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
							{
								int result2 = 0;
								int.TryParse(text3, out result2);
								LkCityInfoViewModel item = new LkCityInfoViewModel
								{
									City = text,
									LinkAccCityIdStr = text2,
									ProvinceId = result2
								};
								list.Add(item);
							}
						}
						if (list != null)
						{
							if (Enumerable.Any<LkCityInfoViewModel>((IEnumerable<LkCityInfoViewModel>)list))
							{
								string text6 = CRMIdeal.Classes.Helper.OtherSystems.SyncCity(list);
								if (!string.IsNullOrWhiteSpace(text6))
								{
									commonReturnResultViewModel.IsDone = false;
									commonReturnResultViewModel.Message = text6;
								}
								else
								{
									commonReturnResultViewModel.IsDone = true;
									commonReturnResultViewModel.Message = "";
								}
							}
							else
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
							}
						}
						else
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
						}
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
					}
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorNotFilePath;
				}
			}
			catch (IndexOutOfRangeException e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorOrderImportExcelNotEqualColumnsByExcel;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEntered + "\n" + ex.Message;
			}
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetRayvarzPrdUnits()
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
			List<LkWSProductUnitInfoViewModel> productUnits = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetProductUnits();
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

	public List<SelectListItem> GetRayvarzSalesTypeList()
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
			list = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetSalesTypeList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetSaleCenterAccCodeList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		int value = -1;
		int value2 = 23;
		try
		{
			List<CRMspSelectLinkAccSettingDetails_Result> list2 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			List<CRMspSelectLinkAccSettingDetails_Result> list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "SaleCenter", currLangID, result, value2, value, "SaleCenterAccCode"));
			int result2 = 0;
			if (cRMspSelectLinkAccSetting_Result != null)
			{
				int.TryParse(cRMspSelectLinkAccSetting_Result.LinkAccSettingId.ToString(), out result2);
			}
			list3 = Enumerable.ToList<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)_dbLink.CRMspSelectLinkAccSettingDetails(0, 0, "SaleCenter", currLangID, result, value2, value));
			if (list3 == null)
			{
				list3 = new List<CRMspSelectLinkAccSettingDetails_Result>();
			}
			if (list3 != null)
			{
				if (Enumerable.Any<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3))
				{
					List<SelectListItem> saleCentersList = GetSaleCentersList();
					if (saleCentersList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)saleCentersList))
					{
						foreach (SelectListItem item3 in saleCentersList)
						{
							int saleCenterId = 0;
							int.TryParse(item3.Value, out saleCenterId);
							if (saleCenterId == 0)
							{
								continue;
							}
							bool flag = false;
							if (Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == saleCenterId)) != null)
							{
								Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccSettingDetails_Result, bool>)((CRMspSelectLinkAccSettingDetails_Result m) => m.ObjectId.GetValueOrDefault() == saleCenterId)).PartLabelTitle = item3.Text ?? "";
								flag = true;
							}
							if (!flag)
							{
								CRMspSelectLinkAccSettingDetails_Result item = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result2,
									ObjectId = saleCenterId,
									PartTitle = "SaleCenterAccCode",
									ObjectTypeTitle = (item3.Text ?? ""),
									ObjectType = "SaleCenter",
									PartLabelTitle = (item3.Text ?? "")
								};
								list3.Add(item);
							}
						}
					}
				}
				else
				{
					List<SelectListItem> saleCentersList2 = GetSaleCentersList();
					if (saleCentersList2 != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)saleCentersList2))
					{
						foreach (SelectListItem item4 in saleCentersList2)
						{
							int result3 = 0;
							int.TryParse(item4.Value, out result3);
							if (result3 != 0)
							{
								CRMspSelectLinkAccSettingDetails_Result item2 = new CRMspSelectLinkAccSettingDetails_Result
								{
									LinkAccSettingDetailId = -1,
									LinkAccSettingId = result2,
									ObjectId = result3,
									PartTitle = "SaleCenterAccCode",
									ObjectTypeTitle = (item4.Text ?? ""),
									ObjectType = "SaleCenter",
									PartLabelTitle = (item4.Text ?? "")
								};
								list3.Add(item2);
							}
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
					_003C_003Ec__DisplayClass31_2 _003C_003Ec__DisplayClass31_ = new _003C_003Ec__DisplayClass31_2();
					_003C_003Ec__DisplayClass31_.item = enumerator2.Current;
					DbSet<CrmLinkAccSettingDetails_Lang> crmLinkAccSettingDetails_Lang = _dbTbl.CrmLinkAccSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccSettingDetails_Lang), "c");
					List<CrmLinkAccSettingDetails_Lang> list4 = Enumerable.ToList<CrmLinkAccSettingDetails_Lang>((IEnumerable<CrmLinkAccSettingDetails_Lang>)Queryable.Where<CrmLinkAccSettingDetails_Lang>((IQueryable<CrmLinkAccSettingDetails_Lang>)crmLinkAccSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass31_, typeof(_003C_003Ec__DisplayClass31_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccSettingDetails> crmLinkAccSettingDetails = _dbTbl.CrmLinkAccSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccSettingDetails), "c");
					CrmLinkAccSettingDetails crmLinkAccSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccSettingDetails>(Queryable.Where<CrmLinkAccSettingDetails>((IQueryable<CrmLinkAccSettingDetails>)crmLinkAccSettingDetails, Expression.Lambda<Func<CrmLinkAccSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass31_, typeof(_003C_003Ec__DisplayClass31_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
					if (list4 != null)
					{
						list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccSettingDetails_Lang>)list4, (Func<CrmLinkAccSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
						{
							Value = itemI.Description,
							LanguageId = itemI.LanguageID
						})));
					}
					if (crmLinkAccSettingDetails2 != null)
					{
						list5.Add(new CommonMultiLanguageViewModel
						{
							Value = crmLinkAccSettingDetails2.Description,
							LanguageId = result
						});
					}
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass31_.item.LinkAccSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass31_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass31_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass31_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass31_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass31_.item.LinkAccSettingId;
					crmLinkAccSettingDetailsLanguageViewModel.ObjectId = _003C_003Ec__DisplayClass31_.item.ObjectId.GetValueOrDefault();
					crmLinkAccSettingDetailsLanguageViewModel.Description = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
					crmLinkAccSettingDetailsLanguageViewModel.Description_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
