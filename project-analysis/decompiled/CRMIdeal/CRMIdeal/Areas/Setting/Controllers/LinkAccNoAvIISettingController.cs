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
using CRM.OtherWebServices.LinkNoAvanran_II;
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

public class LinkAccNoAvIISettingController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CRMspSelectLinkAccNoAvIISetting_Result item;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	public ActionResult Index()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actSetting")]
	[AjaxOnly]
	public string GetNoAvIIStores()
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
			List<NoAvaranIIWareHouseInfoViewModel> list = new List<NoAvaranIIWareHouseInfoViewModel>();
			List<NoAvaranIIWareHouseInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranIIWareHouseInfoViewModel>>(new ServiceSoapClient().ReadFromStore());
			if (list2 == null)
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from NoAvII) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				return text2;
			}
			List<WSspSelectWareHouseWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, false, lCID, result));
			foreach (NoAvaranIIWareHouseInfoViewModel item in list2)
			{
				if (list3 != null && Enumerable.Any<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list3, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WrhsLinkAccWhCode == item.Store));
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						item.WHId = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
					}
				}
				list.Add(item);
			}
			if (list != null && Enumerable.Any<NoAvaranIIWareHouseInfoViewModel>((IEnumerable<NoAvaranIIWareHouseInfoViewModel>)list))
			{
				text = "";
				string noAvIIWareHouseJson = JsonConvert.SerializeObject(list);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkNoAvIIWSInsertUpdateWareHouseFromNoAvII(noAvIIWareHouseJson, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
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
	public string GetNoAvIIBazaryaban()
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			string text2 = "";
			string text3 = "";
			CRMspSelectLinkAccNoAvIISetting_Result cRMspSelectLinkAccNoAvIISetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)_dbLink.CRMspSelectLinkAccNoAvIISetting(2, "Setting", lCID, result));
			if (cRMspSelectLinkAccNoAvIISetting_Result != null)
			{
				text2 = cRMspSelectLinkAccNoAvIISetting_Result.PartValue ?? "";
				text3 = cRMspSelectLinkAccNoAvIISetting_Result.PartDescription ?? "";
			}
			else
			{
				Exception e = new Exception(Messages.errorInReadingSetting + " (noAvaran II) ");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (string.IsNullOrWhiteSpace(text2))
			{
				if (!string.IsNullOrWhiteSpace(text3))
				{
					text = string.Format(Messages.msgErrorIsNotSpecified, text3);
					Exception e2 = new Exception(Messages.msgErrorRunFunction + " (" + text + ") ");
					ErrorSignal.FromCurrentContext().Raise(e2);
					return text;
				}
				string text4 = Messages.msgErrorRunFunction + " (get list from NoAvII) ";
				Exception e3 = new Exception(text4);
				ErrorSignal.FromCurrentContext().Raise(e3);
				return text4;
			}
			List<NoAvaranIIUserInfoViewModel> list = JsonConvert.DeserializeObject<List<NoAvaranIIUserInfoViewModel>>(new ServiceSoapClient().ReadFromBazaryaban(string.Empty, text2));
			if (list == null)
			{
				string text5 = Messages.msgErrorRunFunction + " (get list from NoAvII) ";
				Exception e4 = new Exception(text5);
				ErrorSignal.FromCurrentContext().Raise(e4);
				return text5;
			}
			if (list != null && Enumerable.Any<NoAvaranIIUserInfoViewModel>((IEnumerable<NoAvaranIIUserInfoViewModel>)list))
			{
				text = "";
				string userJson = JsonConvert.SerializeObject(list);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkNoAvIIInsertUpdateUsersFromNoAvII(userJson, userId, value3, value2, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null && !string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					text = text + "<br>" + objectParameter.Value.ToString();
				}
				CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("Users");
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (string.IsNullOrEmpty(text))
			{
				text = "1";
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			text = Messages.msgErrorRunFunction;
		}
		return text;
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
	public JsonResult GetSelectLinkAccNoAvIISetting(string objType = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccNoAvIISetting_Result> list = new List<CRMspSelectLinkAccNoAvIISetting_Result>();
		try
		{
			if (!string.IsNullOrEmpty(objType))
			{
				list = Enumerable.ToList<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)_dbLink.CRMspSelectLinkAccNoAvIISetting(0, objType, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)list))
				{
					foreach (CRMspSelectLinkAccNoAvIISetting_Result item in list)
					{
						if (string.IsNullOrWhiteSpace(item.PartValue) || !(item.PartTitle == "DefPrjCvnsStatusGroupId"))
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
			List<CRMspSelectLinkAccNoAvIISetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccNoAvIISetting_Result>((IEnumerable<CRMspSelectLinkAccNoAvIISetting_Result>)_dbLink.CRMspSelectLinkAccNoAvIISetting(0, objectType, currLangID, result));
			if (list2 != null)
			{
				using List<CRMspSelectLinkAccNoAvIISetting_Result>.Enumerator enumerator = list2.GetEnumerator();
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_1();
					_003C_003Ec__DisplayClass8_.item = enumerator.Current;
					DbSet<CrmLinkAccNoAvIISetting_Lang> crmLinkAccNoAvIISetting_Lang = _dbTbl.CrmLinkAccNoAvIISetting_Lang;
					ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccNoAvIISetting_Lang), "c");
					List<CrmLinkAccNoAvIISetting_Lang> list3 = Enumerable.ToList<CrmLinkAccNoAvIISetting_Lang>((IEnumerable<CrmLinkAccNoAvIISetting_Lang>)Queryable.Where<CrmLinkAccNoAvIISetting_Lang>((IQueryable<CrmLinkAccNoAvIISetting_Lang>)crmLinkAccNoAvIISetting_Lang, Expression.Lambda<Func<CrmLinkAccNoAvIISetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					DbSet<CrmLinkAccNoAvIISetting> crmLinkAccNoAvIISetting = _dbTbl.CrmLinkAccNoAvIISetting;
					val = Expression.Parameter(typeof(CrmLinkAccNoAvIISetting), "c");
					CrmLinkAccNoAvIISetting crmLinkAccNoAvIISetting2 = Queryable.FirstOrDefault<CrmLinkAccNoAvIISetting>(Queryable.Where<CrmLinkAccNoAvIISetting>((IQueryable<CrmLinkAccNoAvIISetting>)crmLinkAccNoAvIISetting, Expression.Lambda<Func<CrmLinkAccNoAvIISetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmLinkAccNoAvIISetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmLinkAccNoAvIISetting_Lang>)list3, (Func<CrmLinkAccNoAvIISetting_Lang, CommonMultiLanguageViewModel>)((CrmLinkAccNoAvIISetting_Lang itemI) => new CommonMultiLanguageViewModel
					{
						Value = itemI.Description,
						LanguageId = itemI.LanguageID
					})));
					list4.Add(new CommonMultiLanguageViewModel
					{
						Value = crmLinkAccNoAvIISetting2.Description,
						LanguageId = result
					});
					CrmLinkAccSettingOtherLanguageViewModel crmLinkAccSettingOtherLanguageViewModel = new CrmLinkAccSettingOtherLanguageViewModel();
					crmLinkAccSettingOtherLanguageViewModel.LinkAccSettingId = _003C_003Ec__DisplayClass8_.item.LinkAccNoAvIISettingId;
					crmLinkAccSettingOtherLanguageViewModel.PartField = _003C_003Ec__DisplayClass8_.item.PartField;
					crmLinkAccSettingOtherLanguageViewModel.PartValue = _003C_003Ec__DisplayClass8_.item.PartValue;
					crmLinkAccSettingOtherLanguageViewModel.PartTitle = _003C_003Ec__DisplayClass8_.item.PartTitle;
					crmLinkAccSettingOtherLanguageViewModel.PartDescription = _003C_003Ec__DisplayClass8_.item.PartDescription;
					crmLinkAccSettingOtherLanguageViewModel.PartLabelTitle = _003C_003Ec__DisplayClass8_.item.PartLabelTitle;
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
			_dbLink.CRMspUpdateLinkAccNoAvIISetting(text, text2, userId, value, value2, value3, registerDatePersian, appType, defLangID);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
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
