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
using CRMIdeal.LinkPayvast;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Setting.Controllers;

public class LinkAccPayvastSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CRMspSelectLinkAccPayvastSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CRMspSelectLinkAccPayvastSettingDetails_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		SelectProductPriceGroupList();
		SelectProductCostGroupList();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccPayvastSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccPayvastSetting_Result> list = new List<CRMspSelectLinkAccPayvastSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)_dbLink.CRMspSelectLinkAccPayvastSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccPayvastSetting_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.PartValue) && item.LinkAccPayvastSettingId == 2)
					{
						item.PartValue = "**********";
					}
				}
				foreach (CRMspSelectLinkAccPayvastSetting_Result item2 in list)
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
			List<CRMspSelectLinkAccPayvastSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccPayvastSetting_Result>((IEnumerable<CRMspSelectLinkAccPayvastSetting_Result>)_dbLink.CRMspSelectLinkAccPayvastSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccPayvastSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
					_003C_003Ec__DisplayClass5_.item = enumerator.Current;
					DbSet<CrmLinkAccPayvastSetting_Lang> crmLinkAccPayvastSetting_Lang = _dbTbl.CrmLinkAccPayvastSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccPayvastSetting_Lang), "c");
					List<CrmLinkAccPayvastSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccPayvastSetting_Lang>((IEnumerable<CrmLinkAccPayvastSetting_Lang>)Queryable.Where<CrmLinkAccPayvastSetting_Lang>((IQueryable<CrmLinkAccPayvastSetting_Lang>)crmLinkAccPayvastSetting_Lang, Expression.Lambda<Func<CrmLinkAccPayvastSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccPayvastSetting> crmLinkAccPayvastSetting = _dbTbl.CrmLinkAccPayvastSetting;
					val = Expression.Parameter(typeof(CrmLinkAccPayvastSetting), "c");
					CrmLinkAccPayvastSetting crmLinkAccPayvastSetting2 = Queryable.FirstOrDefault<CrmLinkAccPayvastSetting>(Queryable.Where<CrmLinkAccPayvastSetting>((IQueryable<CrmLinkAccPayvastSetting>)crmLinkAccPayvastSetting, Expression.Lambda<Func<CrmLinkAccPayvastSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccPayvastSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccPayvastSetting_Lang>)list3, (Func<CrmLinkAccPayvastSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccPayvastSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccPayvastSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass5_.item.LinkAccPayvastSettingId;
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
			_dbLink.CRMspUpdateLinkAccPayvastSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
		List<CRMspSelectLinkAccPayvastSettingDetails_Result> list = new List<CRMspSelectLinkAccPayvastSettingDetails_Result>();
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
				_dbLink.CRMspInsertLinkAccPayvastSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				list = Enumerable.ToList<CRMspSelectLinkAccPayvastSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccPayvastSettingDetails_Result>)_dbLink.CRMspSelectLinkAccPayvastSettingDetails(0, objId, objType, lCID, result));
				foreach (CRMspSelectLinkAccPayvastSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccPayvastSettingId == 11)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceI;
							break;
						case "2":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceII;
							break;
						case "3":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceIII;
							break;
						case "4":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceIV;
							break;
						case "5":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceV;
							break;
						case "6":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceVI;
							break;
						case "7":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceVII;
							break;
						case "8":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceVIII;
							break;
						case "9":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceIX;
							break;
						case "10":
							item.PartValue = Labels.OtherSystemsPayvastProductPriceX;
							break;
						}
					}
					if (item.LinkAccPayvastSettingId == 12)
					{
						switch (item.PartValue)
						{
						case "1":
							item.PartValue = Labels.OtherSystemsPayvastProductCostI;
							break;
						case "2":
							item.PartValue = Labels.OtherSystemsPayvastProductCostII;
							break;
						case "3":
							item.PartValue = Labels.OtherSystemsPayvastProductCostIII;
							break;
						case "4":
							item.PartValue = Labels.OtherSystemsPayvastProductCostIV;
							break;
						case "5":
							item.PartValue = Labels.OtherSystemsPayvastProductCostV;
							break;
						case "6":
							item.PartValue = Labels.OtherSystemsPayvastProductCostVI;
							break;
						case "7":
							item.PartValue = Labels.OtherSystemsPayvastProductCostVII;
							break;
						case "8":
							item.PartValue = Labels.OtherSystemsPayvastProductCostVIII;
							break;
						case "9":
							item.PartValue = Labels.OtherSystemsPayvastProductCostIX;
							break;
						case "10":
							item.PartValue = Labels.OtherSystemsPayvastProductCostX;
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
		base.ViewBag.ObjectId = objId;
		base.ViewBag.ObjectType = objType;
		string text = "";
		List<CrmLinkAccSettingDetailsLanguageViewModel> list = new List<CrmLinkAccSettingDetailsLanguageViewModel>();
		try
		{
			List<CRMspSelectLinkAccPayvastSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccPayvastSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccPayvastSettingDetails_Result>)_dbLink.CRMspSelectLinkAccPayvastSettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccPayvastSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
					_003C_003Ec__DisplayClass8_.item = enumerator.Current;
					DbSet<CrmLinkAccPayvastSettingDetails_Lang> crmLinkAccPayvastSettingDetails_Lang = _dbTbl.CrmLinkAccPayvastSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccPayvastSettingDetails_Lang), "c");
					List<CrmLinkAccPayvastSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccPayvastSettingDetails_Lang>((IEnumerable<CrmLinkAccPayvastSettingDetails_Lang>)Queryable.Where<CrmLinkAccPayvastSettingDetails_Lang>((IQueryable<CrmLinkAccPayvastSettingDetails_Lang>)crmLinkAccPayvastSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccPayvastSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccPayvastSettingDetails> crmLinkAccPayvastSettingDetails = _dbTbl.CrmLinkAccPayvastSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccPayvastSettingDetails), "c");
					CrmLinkAccPayvastSettingDetails crmLinkAccPayvastSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccPayvastSettingDetails>(Queryable.Where<CrmLinkAccPayvastSettingDetails>((IQueryable<CrmLinkAccPayvastSettingDetails>)crmLinkAccPayvastSettingDetails, Expression.Lambda<Func<CrmLinkAccPayvastSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccPayvastSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccPayvastSettingDetails_Lang>)list3, (Func<CrmLinkAccPayvastSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccPayvastSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccPayvastSettingDetails2.Description,
						LanguageId = result
					});
					text = _003C_003Ec__DisplayClass8_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass8_.item.LinkAccPayvastSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass8_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass8_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass8_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass8_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass8_.item.LinkAccPayvastSettingId;
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
				_dbLink.CRMspUpdateLinkAccPayvastSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
			result = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result2));
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

	public List<WSspSelectProductCostGroup_Result> SelectProductCostGroup()
	{
		List<WSspSelectProductCostGroup_Result> result = new List<WSspSelectProductCostGroup_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<SelectListItem> SelectProductCostGroupList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectProductCostGroup_Result> list2 = SelectProductCostGroup();
			if (list2 != null)
			{
				foreach (WSspSelectProductCostGroup_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Value = item2.ProductCostGroupID.ToString(),
						Text = item2.ProductCostGroupName,
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
		base.ViewBag.ProductCostGroupList = list;
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetPayvastCompanyType()
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
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<CRMspSelectCompanyTypesWithAccLinkField_Result> list = SelectCompanyTypesWithAccLinkField(withLinkAccCmpTypeIdStr: true, lCID, result);
			new List<KyanCompanyGroupsInfoViewModel>();
			CustomerType[] customerTypes = new AccountingServiceSoapClient().GetCustomerTypes();
			if (customerTypes == null)
			{
				string text2 = Messages.msgErrorRunFunction + Messages.errorInReadingSetting;
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			List<LkCompanyTypeInfoViewModel> list2 = new List<LkCompanyTypeInfoViewModel>();
			CustomerType[] array = customerTypes;
			foreach (CustomerType item in array)
			{
				LkCompanyTypeInfoViewModel lkCompanyTypeInfoViewModel = new LkCompanyTypeInfoViewModel();
				lkCompanyTypeInfoViewModel.CompanyTypeName = item.Name ?? "";
				lkCompanyTypeInfoViewModel.LinkAccCmpTypeIdStr = item.Code.ToString();
				CRMspSelectCompanyTypesWithAccLinkField_Result cRMspSelectCompanyTypesWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyTypesWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCompanyTypesWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyTypesWithAccLinkField_Result>)list, (Func<CRMspSelectCompanyTypesWithAccLinkField_Result, bool>)((CRMspSelectCompanyTypesWithAccLinkField_Result x) => x.CompanyTypeName == item.Name)));
				if (cRMspSelectCompanyTypesWithAccLinkField_Result != null)
				{
					lkCompanyTypeInfoViewModel.CompanyTypeID = cRMspSelectCompanyTypesWithAccLinkField_Result.CompanyTypeID;
				}
				list2.Add(lkCompanyTypeInfoViewModel);
			}
			if (list2 == null || !Enumerable.Any<LkCompanyTypeInfoViewModel>((IEnumerable<LkCompanyTypeInfoViewModel>)list2))
			{
				return Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			string json = JsonConvert.SerializeObject(list2);
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			CRMLinkSpEntities dbLink = _dbLink;
			int? userId2 = userId;
			short? month = value3;
			int? fPId = id;
			short? year = value2;
			DateTime? registerDate = value;
			string appType2 = appType;
			dbLink.CRMspLkInsertUpdateCompanyTypes(json, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter);
			if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
			{
				return text + "<br>" + objectParameter.Value.ToString();
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmCompanyType");
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

	public List<CRMspSelectCompanyTypesWithAccLinkField_Result> SelectCompanyTypesWithAccLinkField(bool withLinkAccCmpTypeIdStr = true, int currLangID = 1065, int defaultLanguageID = 1065)
	{
		List<CRMspSelectCompanyTypesWithAccLinkField_Result> result = new List<CRMspSelectCompanyTypesWithAccLinkField_Result>();
		try
		{
			result = Enumerable.ToList<CRMspSelectCompanyTypesWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyTypesWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyTypesWithAccLinkField(withLinkAccCmpTypeIdStr, currLangID, defaultLanguageID));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		base.Dispose(disposing);
	}
}
