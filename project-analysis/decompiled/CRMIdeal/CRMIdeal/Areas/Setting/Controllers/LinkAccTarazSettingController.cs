using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
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

public class LinkAccTarazSettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_1
	{
		public CRMspSelectLinkAccTarazSetting_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CRMspSelectLinkAccTarazSettingDetails_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		GetCompanyType();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccTarazSetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccTarazSetting_Result> list = new List<CRMspSelectLinkAccTarazSetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, objType, lCID, result));
				foreach (CRMspSelectLinkAccTarazSetting_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue))
					{
						continue;
					}
					if (item.LinkAccTarazSettingId == 3)
					{
						item.PartValue = "**********";
					}
					else if (item.LinkAccTarazSettingId == 7)
					{
						item.PartValue = item.PartValueTitle;
					}
					else if (item.LinkAccTarazSettingId == 8 || item.LinkAccTarazSettingId == 9 || item.LinkAccTarazSettingId == 10)
					{
						if (!string.IsNullOrWhiteSpace(item.PartValue))
						{
							if (item.PartValue == "6001")
							{
								item.PartValue = Labels.OtherSystemsPreOrder;
							}
							else if (item.PartValue == "6004")
							{
								item.PartValue = Labels.OtherSystemsOrder;
							}
						}
					}
					else if (item.LinkAccTarazSettingId == 11 && !string.IsNullOrWhiteSpace(item.PartValue))
					{
						if (item.PartValue == "1")
						{
							item.PartValue = Labels.OtherSystemsIsRequired;
						}
						else if (item.PartValue == "0")
						{
							item.PartValue = Labels.OtherSystemsIsNotRequired;
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
			List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccTarazSetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass5_1 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_1();
					_003C_003Ec__DisplayClass5_.item = enumerator.Current;
					DbSet<CrmLinkAccTarazSetting_Lang> crmLinkAccTarazSetting_Lang = _dbTbl.CrmLinkAccTarazSetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting_Lang), "c");
					List<CrmLinkAccTarazSetting_Lang> list3 = Enumerable.ToList<CrmLinkAccTarazSetting_Lang>((IEnumerable<CrmLinkAccTarazSetting_Lang>)Queryable.Where<CrmLinkAccTarazSetting_Lang>((IQueryable<CrmLinkAccTarazSetting_Lang>)crmLinkAccTarazSetting_Lang, Expression.Lambda<Func<CrmLinkAccTarazSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
					val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "c");
					CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>(Queryable.Where<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccTarazSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccTarazSetting_Lang>)list3, (Func<CrmLinkAccTarazSetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccTarazSetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccTarazSetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass5_.item.LinkAccTarazSettingId;
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
			_dbLink.CRMspUpdateLinkAccTarazSetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetSelectLinkAccTarazSettingDetails(int objId = 0, string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccTarazSettingDetails_Result> list = new List<CRMspSelectLinkAccTarazSettingDetails_Result>();
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
				_dbLink.CRMspInsertLinkAccTarazSettingDetails(objId, objType, userId, value, value2, value3, registerDatePersian, appType, result);
				list = Enumerable.ToList<CRMspSelectLinkAccTarazSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccTarazSettingDetails_Result>)_dbLink.CRMspSelectLinkAccTarazSettingDetails(0, objId, objType, lCID, result));
				foreach (CRMspSelectLinkAccTarazSettingDetails_Result item in list)
				{
					if (string.IsNullOrWhiteSpace(item.PartValue) || item.LinkAccTarazSettingId != 4)
					{
						continue;
					}
					string partValue = item.PartValue;
					if (!(partValue == "1"))
					{
						if (partValue == "2")
						{
							item.PartValue = Labels.LinkAccSettingLegal;
						}
					}
					else
					{
						item.PartValue = Labels.LinkAccSettingIndividuals;
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
			List<CRMspSelectLinkAccTarazSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccTarazSettingDetails_Result>)_dbLink.CRMspSelectLinkAccTarazSettingDetails(0, objId, objType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccTarazSettingDetails_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
					_003C_003Ec__DisplayClass8_.item = enumerator.Current;
					DbSet<CrmLinkAccTarazSettingDetails_Lang> crmLinkAccTarazSettingDetails_Lang = _dbTbl.CrmLinkAccTarazSettingDetails_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSettingDetails_Lang), "c");
					List<CrmLinkAccTarazSettingDetails_Lang> list3 = Enumerable.ToList<CrmLinkAccTarazSettingDetails_Lang>((IEnumerable<CrmLinkAccTarazSettingDetails_Lang>)Queryable.Where<CrmLinkAccTarazSettingDetails_Lang>((IQueryable<CrmLinkAccTarazSettingDetails_Lang>)crmLinkAccTarazSettingDetails_Lang, Expression.Lambda<Func<CrmLinkAccTarazSettingDetails_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccTarazSettingDetails> crmLinkAccTarazSettingDetails = _dbTbl.CrmLinkAccTarazSettingDetails;
					val = Expression.Parameter(typeof(CrmLinkAccTarazSettingDetails), "c");
					CrmLinkAccTarazSettingDetails crmLinkAccTarazSettingDetails2 = Queryable.FirstOrDefault<CrmLinkAccTarazSettingDetails>(Queryable.Where<CrmLinkAccTarazSettingDetails>((IQueryable<CrmLinkAccTarazSettingDetails>)crmLinkAccTarazSettingDetails, Expression.Lambda<Func<CrmLinkAccTarazSettingDetails, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccTarazSettingDetails_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccTarazSettingDetails_Lang>)list3, (Func<CrmLinkAccTarazSettingDetails_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccTarazSettingDetails_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccTarazSettingDetails2.Description,
						LanguageId = result
					});
					text = _003C_003Ec__DisplayClass8_.item.ObjectTypeTitle ?? "";
					CrmLinkAccSettingDetailsLanguageViewModel crmLinkAccSettingDetailsLanguageViewModel = new CrmLinkAccSettingDetailsLanguageViewModel();
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingDetailId = _003C_003Ec__DisplayClass8_.item.LinkAccTarazSettingDetailId;
					crmLinkAccSettingDetailsLanguageViewModel.PartField = _003C_003Ec__DisplayClass8_.item.PartField;
					crmLinkAccSettingDetailsLanguageViewModel.PartValue = _003C_003Ec__DisplayClass8_.item.PartValue;
					crmLinkAccSettingDetailsLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass8_.item.PartDescription;
					crmLinkAccSettingDetailsLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass8_.item.PartLabelTitle;
					crmLinkAccSettingDetailsLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass8_.item.LinkAccTarazSettingId;
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
				_dbLink.CRMspUpdateLinkAccTarazSettingDetails(objId, objType, text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
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
	public JsonResult GetCompanyType()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CompanyTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductPriceGroup()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)Enumerable.ToList<WSspSelectProductPriceGroup_Result>(Enumerable.Where<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result), (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result m) => m.LinkAccPrdPriceGroupIdStr != null && m.LinkAccPrdPriceGroupIdStr != ""))), (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroupList = list;
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
	public string GetTarazStores()
	{
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
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
			int num = 200;
			int i = 1;
			int num2 = 100000;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<TarazWarehousesViewModel> list = new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list2 == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				for (; i <= num2; i++)
				{
					string requestUri = "tws/inv/stores?pageNumber=" + i + "&recordCount=" + num;
					HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
					if (result3.IsSuccessStatusCode)
					{
						List<TarazWarehousesViewModel> list3 = JsonConvert.DeserializeObject<List<TarazWarehousesViewModel>>(result3.Content.ReadAsStringAsync().Result);
						if (list3 != null && Enumerable.Any<TarazWarehousesViewModel>((IEnumerable<TarazWarehousesViewModel>)list3))
						{
							foreach (TarazWarehousesViewModel item2 in list3)
							{
								TarazWarehousesViewModel item = new TarazWarehousesViewModel
								{
									storeID = item2.storeID,
									storeName = item2.storeName,
									storeCode = item2.storeCode
								};
								list.Add(item);
							}
							if (Enumerable.Count<TarazWarehousesViewModel>((IEnumerable<TarazWarehousesViewModel>)list3) < num)
							{
								i = 100000;
							}
						}
						else
						{
							i = 100000;
						}
						continue;
					}
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text12;
					i = 100000;
					return text;
				}
			}
			if (list != null && Enumerable.Any<TarazWarehousesViewModel>((IEnumerable<TarazWarehousesViewModel>)list))
			{
				foreach (TarazWarehousesViewModel item3 in list)
				{
					long result4 = 0L;
					long.TryParse(item3.storeID.ToString(), out result4);
					if (result4 <= 0 || string.IsNullOrEmpty(item3.storeName))
					{
						continue;
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("insertedWhId", "0");
					_dbLink.CRMspLkTarazWSInsertUpdateWareHouseFromTaraz(result4, item3.storeName, item3.storeCode, userId, value2, id, value, registerDatePersian, appType, result, objectParameter2, objectParameter, centerId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
						}
						else if (objectParameter2.Value != null)
						{
							int result5 = 0;
							int.TryParse(objectParameter2.Value.ToString(), out result5);
							if (result5 == 0)
							{
								text = text + "<br>" + Messages.ErrorInformation + " (" + item3.storeName + ")";
							}
						}
					}
					else if (objectParameter2.Value != null)
					{
						int result6 = 0;
						int.TryParse(objectParameter2.Value.ToString(), out result6);
						if (result6 == 0)
						{
							text = text + "<br>" + Messages.ErrorInformation + " (" + item3.storeName + ")";
						}
					}
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazPaymentWay()
	{
		//IL_069e: Unknown result type (might be due to invalid IL or missing references)
		//IL_06a3: Unknown result type (might be due to invalid IL or missing references)
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
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "tws/pub/lookupdetails/paymentWay";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					return text12;
				}
				List<TarazPaymentWaysViewModel> list2 = JsonConvert.DeserializeObject<List<TarazPaymentWaysViewModel>>(result3.Content.ReadAsStringAsync().Result);
				if (list2 == null || !Enumerable.Any<TarazPaymentWaysViewModel>((IEnumerable<TarazPaymentWaysViewModel>)list2))
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				string tarazPaymentWayJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazWSInsertUpdateProductPriceGroupFromTaraz(tarazPaymentWayJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null)
				{
					text = (string.IsNullOrEmpty(objectParameter.Value.ToString()) ? "" : (text + "<br>" + objectParameter.Value.ToString()));
				}
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazMarketingMan()
	{
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "tws/sale/marketingmen";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					return text12;
				}
				List<TarazMarketingMenViewModel> list2 = JsonConvert.DeserializeObject<List<TarazMarketingMenViewModel>>(result3.Content.ReadAsStringAsync().Result);
				if (list2 == null || !Enumerable.Any<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list2))
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				if (Enumerable.Any<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list2))
				{
					list2 = Enumerable.ToList<TarazMarketingMenViewModel>(Enumerable.Where<TarazMarketingMenViewModel>((IEnumerable<TarazMarketingMenViewModel>)list2, (Func<TarazMarketingMenViewModel, bool>)((TarazMarketingMenViewModel m) => m.isActive.HasValue && m.isActive.GetValueOrDefault())));
				}
				string userJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazInsertUpdateUsersFromTaraz(userJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null)
				{
					text = (string.IsNullOrEmpty(objectParameter.Value.ToString()) ? "" : (text + "<br>" + objectParameter.Value.ToString()));
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazSeller()
	{
		//IL_0707: Unknown result type (might be due to invalid IL or missing references)
		//IL_070c: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "tws/sale/sellers";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					return text12;
				}
				List<TarazSellerViewModel> list2 = JsonConvert.DeserializeObject<List<TarazSellerViewModel>>(result3.Content.ReadAsStringAsync().Result);
				if (list2 == null || !Enumerable.Any<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list2))
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				if (Enumerable.Any<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list2))
				{
					list2 = Enumerable.ToList<TarazSellerViewModel>(Enumerable.Where<TarazSellerViewModel>((IEnumerable<TarazSellerViewModel>)list2, (Func<TarazSellerViewModel, bool>)((TarazSellerViewModel m) => m.isActive.HasValue && m.isActive.GetValueOrDefault())));
				}
				string userJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazInsertUpdateUsersFromTaraz(userJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null)
				{
					text = (string.IsNullOrEmpty(objectParameter.Value.ToString()) ? "" : (text + "<br>" + objectParameter.Value.ToString()));
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazSaleType()
	{
		//IL_0691: Unknown result type (might be due to invalid IL or missing references)
		//IL_0696: Unknown result type (might be due to invalid IL or missing references)
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
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				int num = 200;
				int i = 1;
				int num2 = 100000000;
				List<TarazSaleTypesViewModel> list2 = new List<TarazSaleTypesViewModel>();
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				for (; i <= num2; i++)
				{
					string requestUri = "tws/sale/saletypes?pageNumber=" + i + "&recordCount=" + num;
					HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
					if (result3.IsSuccessStatusCode)
					{
						List<TarazSaleTypesViewModel> list3 = JsonConvert.DeserializeObject<List<TarazSaleTypesViewModel>>(result3.Content.ReadAsStringAsync().Result);
						if (list3 != null && Enumerable.Any<TarazSaleTypesViewModel>((IEnumerable<TarazSaleTypesViewModel>)list3))
						{
							foreach (TarazSaleTypesViewModel item2 in list3)
							{
								TarazSaleTypesViewModel item = new TarazSaleTypesViewModel
								{
									saleTypeID = item2.saleTypeID,
									saleTypeCode = item2.saleTypeCode,
									saleTypeDesc = item2.saleTypeDesc
								};
								list2.Add(item);
							}
							if (Enumerable.Count<TarazSaleTypesViewModel>((IEnumerable<TarazSaleTypesViewModel>)list3) < num)
							{
								i = 100000000;
							}
						}
						else
						{
							i = 100000000;
						}
						continue;
					}
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text12;
					i = 100000000;
					return text;
				}
				if (!Enumerable.Any<TarazSaleTypesViewModel>((IEnumerable<TarazSaleTypesViewModel>)list2) || list2 == null)
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				string text14 = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazWSInsertUpdateOrderOprFromTaraz(text14, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						text = text + "<br>" + objectParameter.Value.ToString();
					}
					else
					{
						text = "";
						ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
						_dbLink.CRMspLkTarazWSInsertUpdatePreOrderTypesFromTaraz(text14, userId, value2, id, value, registerDatePersian, appType, result, objectParameter2);
						if (objectParameter2.Value != null)
						{
							text = (string.IsNullOrEmpty(objectParameter2.Value.ToString()) ? "" : (text + "<br>" + objectParameter2.Value.ToString()));
						}
					}
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSOrderOpr");
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSPreOrderTypes");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazSaleCenter()
	{
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
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
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "tws/sale/sdcenters/saleCenter";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					return text12;
				}
				List<TarazSdCentersViewModel> list2 = JsonConvert.DeserializeObject<List<TarazSdCentersViewModel>>(result3.Content.ReadAsStringAsync().Result);
				if (list2 == null || !Enumerable.Any<TarazSdCentersViewModel>((IEnumerable<TarazSdCentersViewModel>)list2))
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				string saleCenterJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazWSInsertUpdateSaleCenterFromTaraz(saleCenterJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null)
				{
					text = (string.IsNullOrEmpty(objectParameter.Value.ToString()) ? "" : (text + "<br>" + objectParameter.Value.ToString()));
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSSaleCenters");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetTarazDeliveryPlace()
	{
		//IL_06a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_06ab: Unknown result type (might be due to invalid IL or missing references)
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
			new List<TarazWarehousesViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list == null)
			{
				string text2 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			string text3 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
			if (cRMspSelectLinkAccTarazSetting_Result != null)
			{
				text3 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
			}
			string text4 = "";
			string text5 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
			if (cRMspSelectLinkAccTarazSetting_Result2 != null)
			{
				text5 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
			}
			string text6 = "";
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
			if (cRMspSelectLinkAccTarazSetting_Result3 != null)
			{
				text6 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
			}
			CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
			if (cRMspSelectLinkAccTarazSetting_Result4 != null)
			{
				text4 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
			}
			if (string.IsNullOrWhiteSpace(text3) || string.IsNullOrWhiteSpace(text5) || string.IsNullOrWhiteSpace(text6))
			{
				string text7 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e2 = new Exception(text7);
				ErrorSignal.FromCurrentContext().Raise(e2);
				return text7;
			}
			if (!text3.EndsWith("/"))
			{
				text3 += "/";
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
				tarazGetAuthViewModel.username = text5;
				tarazGetAuthViewModel.password = text6;
				string text8 = "tws/authenticate";
				HttpResponseMessage result2 = new HttpClient
				{
					Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
					BaseAddress = new Uri(text3 + text8),
					DefaultRequestHeaders = 
					{
						Accept = 
						{
							new MediaTypeWithQualityHeaderValue("application/json")
						}
					}
				}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text8).Result;
				if (!result2.IsSuccessStatusCode)
				{
					string text9 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
					TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
					if (tarazExceptionViewModel != null)
					{
						string[] obj = new string[6]
						{
							text9,
							" [",
							tarazExceptionViewModel.error,
							(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
							null,
							null
						};
						_ = tarazExceptionViewModel.status;
						obj[4] = " code:" + tarazExceptionViewModel.status;
						obj[5] = "]";
						text9 = string.Concat(obj);
					}
					Exception e3 = new Exception(text9);
					ErrorSignal.FromCurrentContext().Raise(e3);
					return text9;
				}
				TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
				if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
				{
					string text10 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
					Exception e4 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e4);
					return text10;
				}
				text4 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
				DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
				ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
				CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmLinkAccTarazSetting2 != null)
				{
					crmLinkAccTarazSetting2.PartValue = text4;
					_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
				Exception e5 = new Exception(text11);
				ErrorSignal.FromCurrentContext().Raise(e5);
				return text11;
			}
			if (!string.IsNullOrWhiteSpace(text4))
			{
				HttpClient httpClient = new HttpClient();
				httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
				httpClient.BaseAddress = new Uri(text3);
				httpClient.DefaultRequestHeaders.Add("Authorization", text4);
				httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				string requestUri = "tws/sale/sdcenters/deliveryCenter";
				HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
				if (!result3.IsSuccessStatusCode)
				{
					string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					HttpStatusCode statusCode = result3.StatusCode;
					if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
					{
						DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
						ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
						CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmLinkAccTarazSetting4 != null)
						{
							crmLinkAccTarazSetting4.PartValue = "";
							_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					else
					{
						TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
						if (tarazExceptionViewModel2 != null)
						{
							_ = tarazExceptionViewModel2.status;
							if (tarazExceptionViewModel2.status == 401)
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting6 != null)
								{
									crmLinkAccTarazSetting6.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							string[] obj2 = new string[6]
							{
								text12,
								" [",
								tarazExceptionViewModel2.error,
								(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
								null,
								null
							};
							_ = tarazExceptionViewModel2.status;
							obj2[4] = " code:" + tarazExceptionViewModel2.status;
							obj2[5] = "]";
							text12 = string.Concat(obj2);
						}
					}
					Exception e6 = new Exception(text12);
					ErrorSignal.FromCurrentContext().Raise(e6);
					return text12;
				}
				List<TarazSdCentersViewModel> list2 = JsonConvert.DeserializeObject<List<TarazSdCentersViewModel>>(result3.Content.ReadAsStringAsync().Result);
				if (list2 == null || !Enumerable.Any<TarazSdCentersViewModel>((IEnumerable<TarazSdCentersViewModel>)list2))
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
					Exception e7 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e7);
					return text13;
				}
				string deliveryTermJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkTarazWSInsertUpdateDeliveryTermFromTaraz(deliveryTermJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
				if (objectParameter.Value != null)
				{
					text = (string.IsNullOrEmpty(objectParameter.Value.ToString()) ? "" : (text + "<br>" + objectParameter.Value.ToString()));
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSDeliveryTerms");
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
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
