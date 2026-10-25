using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.IO.FTP;
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
using Microsoft.Win32;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Fund.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public int id;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_0
	{
		public CrmFundLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__16;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_1
	{
		public CrmFund model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass11_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass11_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass21_0
	{
		public int fileId;

		public int currLangID;

		internal bool _003CFileInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public CrmFilesDirectoryLanguageViewModel model;

		public int defLangID;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__10;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__11;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__12;

		public Func<CommonMultiLanguageViewModel, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__14;

		public Func<Languages, bool> _003C_003E9__19;

		internal bool _003CFileInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__14(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CFileInsertEdit_003Eb__19(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public CrmFilesDirectory fileDir;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass22_1 CS_0024_003C_003E8__locals1;

		internal bool _003CFileInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CFileInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass27_0
	{
		public CRMspSelectFilesDirectory_Result item;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass29_0
	{
		public int groupId;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actFund")]
	public ActionResult Index()
	{
		GetUsers();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 20, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.All,
				Value = "-1",
				Selected = false
			});
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
			{
				Text = (item.UserName ?? ""),
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult Fund_Read([DataSourceRequest] DataSourceRequest request, int crmUserId, string fromDate, string toDate, int fundGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFund_Result> list = new List<CRMspSelectFund_Result>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			list = Enumerable.ToList<CRMspSelectFund_Result>((IEnumerable<CRMspSelectFund_Result>)_db.CRMspSelectFund(crmUserId, 0, UserLogin.CurrentUser.UserId, value, value2, languageID: lCID, defaultLanguageID: result, fundGroupId: fundGroupId));
			foreach (CRMspSelectFund_Result item in list)
			{
				_ = item.FundDate;
				item.FundDatePersian = item.FundDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FundVerifiedRegisterDateStr = (item.FundVerifiedRegisterDate.HasValue ? item.FundVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmFund", ActionName = "actDelete")]
	public string ActDelete(int fundId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmFund", "actDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (fundId > 0)
			{
				try
				{
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteFund(fundId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public void SetRegisterInfo(CrmFundLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				_ = model.FirstRegisterDate;
				string text = model.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	public void SetVerifyInfo(CrmFundLanguageViewModel model, ref string verifyInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null || !model.FundVerifierId.HasValue)
			{
				return;
			}
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FundVerifierId.ToString());
			if (list != null && Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FundVerifierId));
				if (cRMspSelectUsersByIds_Result != null)
				{
					verifyInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
					string text = (model.FundVerifiedRegisterDate.HasValue ? model.FundVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					verifyInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmFund", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int crmUserId, int id = 0)
	{
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		GetVerificationWorkFlows();
		CrmFundLanguageViewModel crmFundLanguageViewModel = new CrmFundLanguageViewModel();
		ParameterExpression val;
		try
		{
			if (CS_0024_003C_003E8__locals0.id > 0)
			{
				if (!UserLogin.IsUserAccess("frmFund", "actEdit"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmFund_Lang> crmFund_Lang = _dbTbl.CrmFund_Lang;
				val = Expression.Parameter(typeof(CrmFund_Lang), "c");
				List<CrmFund_Lang> list = Enumerable.ToList<CrmFund_Lang>((IEnumerable<CrmFund_Lang>)Queryable.Where<CrmFund_Lang>((IQueryable<CrmFund_Lang>)crmFund_Lang, Expression.Lambda<Func<CrmFund_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				DbSet<CrmFund> crmFund = _dbTbl.CrmFund;
				val = Expression.Parameter(typeof(CrmFund), "c");
				CrmFund crmFund2 = Queryable.FirstOrDefault<CrmFund>((IQueryable<CrmFund>)crmFund, Expression.Lambda<Func<CrmFund, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFund2 == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
					return null;
				}
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFund_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFund_Lang>)list, (Func<CrmFund_Lang, CommonMultiLanguageViewModel>)((CrmFund_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.FundDesc,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmFund2.FundDesc,
					LanguageId = result
				});
				CrmFundLanguageViewModel obj = new CrmFundLanguageViewModel
				{
					FundId = crmFund2.FundId,
					CrmUserId = crmFund2.CrmUserId,
					FundGroupId = crmFund2.FundGroupId,
					FundDate = crmFund2.FundDate
				};
				_ = crmFund2.FundDate;
				obj.FundDatePersian = crmFund2.FundDate.ToString("yyyy/MM/dd");
				obj.FundNumber = crmFund2.FundNumber;
				obj.FundCredit = crmFund2.FundCredit;
				obj.FundDebit = crmFund2.FundDebit;
				obj.FundRemain = crmFund2.FundRemain;
				obj.FundDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
				obj.FundDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
				obj.FundOrderView = crmFund2.FundOrderView;
				obj.FirstRegisterUserId = crmFund2.FirstRegisterUserId;
				obj.FirstRegisterDate = crmFund2.FirstRegisterDate;
				obj.FirstRegisterDatePersian = crmFund2.FirstRegisterDatePersian;
				obj.UserId = crmFund2.UserId;
				obj.Year1 = crmFund2.Year1;
				obj.Month1 = crmFund2.Month1;
				obj.RegisterDate = crmFund2.RegisterDate;
				obj.RegisterDatePersian = crmFund2.RegisterDatePersian;
				obj.GUId = crmFund2.GUId;
				obj.AppType = crmFund2.AppType;
				obj.LanguageID = crmFund2.LanguageID;
				obj.FundVerificationWorkFlowId = crmFund2.FundVerificationWorkFlowId;
				obj.FundIsVerified = crmFund2.FundIsVerified;
				obj.FundVerifiedRegisterDate = crmFund2.FundVerifiedRegisterDate;
				obj.FundVerifierId = crmFund2.FundVerifierId;
				crmFundLanguageViewModel = obj;
				List<CRMspSelectFilesDirectory_Result> list3 = Files.SelectFilesDirectory("0", "0", "0", "70", CS_0024_003C_003E8__locals0.id.ToString(), "0", "0", false);
				if (list3 != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list3))
				{
					base.ViewBag.HasFile = true;
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmFund", "actInsert"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DateTime now = DateTime.Now;
				long fundNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.CRMfnReturnFundNumber()", Array.Empty<object>())));
				crmFundLanguageViewModel = new CrmFundLanguageViewModel
				{
					CrmUserId = crmUserId,
					FundDate = now,
					FundDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					FirstRegisterUserId = UserLogin.CurrentUser.UserId,
					FirstRegisterDate = now,
					FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					UserId = UserLogin.CurrentUser.UserId,
					RegisterDate = now,
					RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
					FundNumber = fundNumber
				};
				base.ViewBag.IsBuying = VersionBuyer.Fund;
			}
		}
		catch (Exception)
		{
		}
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfo(crmFundLanguageViewModel, ref firstRegInfo, ref regInfo);
		crmFundLanguageViewModel.FirstRegisterUser = firstRegInfo;
		crmFundLanguageViewModel.EditUser = regInfo;
		string verifyInfo = "";
		SetVerifyInfo(crmFundLanguageViewModel, ref verifyInfo);
		crmFundLanguageViewModel.VerifierUser = verifyInfo;
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
		val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CountFile = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		return View(crmFundLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmFundDataEntry", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(CrmFundLanguageViewModel vm, HttpPostedFileBase fileSending)
	{
		//IL_0075: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass11_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass11_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetVerificationWorkFlows();
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FundDesc_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.FundDesc_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.FundDesc,
			LanguageId = lCID
		});
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		int? fileCId = null;
		if (num.GetValueOrDefault() != 0)
		{
			fileCId = num;
		}
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
		ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CountFile = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		long num2 = 0L;
		int sysPartId = 310;
		try
		{
			if (CS_0024_003C_003E8__locals0.vm.FundId <= 0 && !VersionBuyer.Fund)
			{
				DbSet<CrmFund> crmFund = _dbTbl.CrmFund;
				val = Expression.Parameter(typeof(CrmFund), "c");
				if (Queryable.Any<CrmFund>((IQueryable<CrmFund>)crmFund, Expression.Lambda<Func<CrmFund, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					base.ViewBag.Error = "BV|" + Messages.VersionBuy;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			bool flag;
			if (!CS_0024_003C_003E8__locals0.vm.FundCredit.HasValue && !CS_0024_003C_003E8__locals0.vm.FundDebit.HasValue)
			{
				base.ViewBag.Error = Messages.msgErrorIsEmptyFundCreditDebit;
			}
			else if (CS_0024_003C_003E8__locals0.vm.FundCredit.HasValue && CS_0024_003C_003E8__locals0.vm.FundDebit.HasValue)
			{
				base.ViewBag.Error = Messages.msgErrorspecifiedFundCreditOrDebit;
			}
			else
			{
				flag = false;
				if (CS_0024_003C_003E8__locals0.vm.FundId > 0)
				{
					List<CRMspSelectFilesDirectory_Result> list2 = Files.SelectFilesDirectory("0", "0", "0", "70", CS_0024_003C_003E8__locals0.vm.FundId.ToString(), "0", "0", false);
					if (list2 != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list2))
					{
						flag = true;
					}
				}
				if (fileSending == null || flag)
				{
					goto IL_05c8;
				}
				fileSending.ContentType.ToLower();
				string text = (((fileSending.FileName != null) ? Path.GetExtension(fileSending.FileName).ToLower() : "") ?? "").ToLower();
				text = text.Replace(".", "");
				if (Configuration.MaliciousFileExtensions.Contains(text))
				{
					base.ModelState.AddModelError("error", Messages.msgErrorFileIsExecuted);
					base.ViewBag.Error = Messages.msgErrorFileIsExecuted;
				}
				else
				{
					int num3 = 2097152;
					if (fileSending.ContentLength <= num3)
					{
						goto IL_05c8;
					}
					string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(fileSending.ContentLength);
					string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num3);
					string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
					base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2));
					base.ViewBag.Error = string.Format(msgErrorMessageMaxSizeFile, fileFormatByteSize, fileFormatByteSize2);
				}
			}
			goto end_IL_01a9;
			IL_05c8:
			DateTime dateTime = default(DateTime);
			string text2 = "";
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.FundDatePersian))
				{
					text2 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.vm.FundDatePersian.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
						CS_0024_003C_003E8__locals0.vm.FundDatePersian = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.vm.FundDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.vm.FundDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.vm.FundDate = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				base.ViewBag.Error = Messages.WrongDateTime;
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.FundDatePersian != null)
			{
				CS_0024_003C_003E8__locals0.vm.FundDatePersian = CS_0024_003C_003E8__locals0.vm.FundDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass11_1 _003C_003Ec__DisplayClass11_ = new _003C_003Ec__DisplayClass11_1();
				DateTime now = DateTime.Now;
				DateTime dateTime2 = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				short month = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short year = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				_003C_003Ec__DisplayClass11_.model = new CrmFund();
				if (CS_0024_003C_003E8__locals0.vm.FundId > 0)
				{
					DbSet<CrmFund> crmFund2 = _dbTbl.CrmFund;
					val = Expression.Parameter(typeof(CrmFund), "c");
					_003C_003Ec__DisplayClass11_.model = Queryable.FirstOrDefault<CrmFund>((IQueryable<CrmFund>)crmFund2, Expression.Lambda<Func<CrmFund, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass11_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				}
				bool flag2 = false;
				if (CS_0024_003C_003E8__locals0.vm.FundId == 0 || !_003C_003Ec__DisplayClass11_.model.FundIsVerified.HasValue || _003C_003Ec__DisplayClass11_.model.FundIsVerified == false)
				{
					_003C_003Ec__DisplayClass11_.model.CrmUserId = CS_0024_003C_003E8__locals0.vm.CrmUserId;
					_003C_003Ec__DisplayClass11_.model.FundGroupId = CS_0024_003C_003E8__locals0.vm.FundGroupId;
					if (CS_0024_003C_003E8__locals0.vm.FundId == 0 || CS_0024_003C_003E8__locals0.vm.FundDate.Date != _003C_003Ec__DisplayClass11_.model.FundDate.Date)
					{
						_003C_003Ec__DisplayClass11_.model.FundDate = CS_0024_003C_003E8__locals0.vm.FundDate;
						_003C_003Ec__DisplayClass11_.model.FundDatePersian = CS_0024_003C_003E8__locals0.vm.FundDatePersian;
					}
					_003C_003Ec__DisplayClass11_.model.FundNumber = CS_0024_003C_003E8__locals0.vm.FundNumber;
					_003C_003Ec__DisplayClass11_.model.FundCredit = CS_0024_003C_003E8__locals0.vm.FundCredit;
					_003C_003Ec__DisplayClass11_.model.FundDebit = CS_0024_003C_003E8__locals0.vm.FundDebit;
					decimal num4 = default(decimal);
					decimal result = default(decimal);
					decimal result2 = default(decimal);
					decimal.TryParse(_003C_003Ec__DisplayClass11_.model.FundCredit.ToString(), out result);
					decimal.TryParse(_003C_003Ec__DisplayClass11_.model.FundDebit.ToString(), out result2);
					decimal num5 = result2 - result;
					decimal result3 = default(decimal);
					if (CS_0024_003C_003E8__locals0.vm.FundId == 0)
					{
						CRMspReturnFundSumFooter_Result cRMspReturnFundSumFooter_Result = Enumerable.FirstOrDefault<CRMspReturnFundSumFooter_Result>((IEnumerable<CRMspReturnFundSumFooter_Result>)_db.CRMspReturnFundSumFooter(_003C_003Ec__DisplayClass11_.model.CrmUserId, 0, null, null, null));
						if (cRMspReturnFundSumFooter_Result != null)
						{
							decimal.TryParse(cRMspReturnFundSumFooter_Result.SumRem.ToString(), out result3);
						}
					}
					else
					{
						CRMspSelectPriorFund_Result cRMspSelectPriorFund_Result = Enumerable.FirstOrDefault<CRMspSelectPriorFund_Result>((IEnumerable<CRMspSelectPriorFund_Result>)_db.CRMspSelectPriorFund(_003C_003Ec__DisplayClass11_.model.CrmUserId, CS_0024_003C_003E8__locals0.vm.FundId));
						if (cRMspSelectPriorFund_Result != null)
						{
							decimal.TryParse(cRMspSelectPriorFund_Result.FundRemain.ToString(), out result3);
						}
					}
					num4 = result3 + num5;
					_003C_003Ec__DisplayClass11_.model.FundRemain = num4;
					_003C_003Ec__DisplayClass11_.model.FundDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass11_.model.FundOrderView = CS_0024_003C_003E8__locals0.vm.FundOrderView;
					_003C_003Ec__DisplayClass11_.model.FundVerificationWorkFlowId = CS_0024_003C_003E8__locals0.vm.FundVerificationWorkFlowId;
					flag2 = true;
				}
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (_003C_003Ec__DisplayClass11_.model.FundIsVerified.HasValue && _003C_003Ec__DisplayClass11_.model.FundIsVerified.Value && (!CS_0024_003C_003E8__locals0.vm.FundIsVerified.HasValue || !CS_0024_003C_003E8__locals0.vm.FundIsVerified.Value) && UserLogin.IsUserAccess("frmFund", "actExitFromIsVerify", currentUser))
				{
					flag2 = true;
				}
				if ((!_003C_003Ec__DisplayClass11_.model.FundIsVerified.HasValue || !_003C_003Ec__DisplayClass11_.model.FundIsVerified.Value) && CS_0024_003C_003E8__locals0.vm.FundIsVerified.HasValue && CS_0024_003C_003E8__locals0.vm.FundIsVerified.Value && !CS_0024_003C_003E8__locals0.vm.FundVerificationWorkFlowId.HasValue && UserLogin.IsUserAccess("frmFund", "actVerifyFund", currentUser))
				{
					flag2 = true;
				}
				if (flag2)
				{
					_003C_003Ec__DisplayClass11_.model.UserId = userId;
					_003C_003Ec__DisplayClass11_.model.Year1 = year;
					_003C_003Ec__DisplayClass11_.model.Month1 = month;
					_003C_003Ec__DisplayClass11_.model.RegisterDate = dateTime2;
					_003C_003Ec__DisplayClass11_.model.RegisterDatePersian = text3;
					_003C_003Ec__DisplayClass11_.model.AppType = appType;
				}
				if (_003C_003Ec__DisplayClass11_.model.FundId > 0)
				{
					long.TryParse(_003C_003Ec__DisplayClass11_.model.FundNumber.ToString(), out var result4);
					if (CheckDuplicateNumber(result4, _003C_003Ec__DisplayClass11_.model.FundId) > 0)
					{
						if (CS_0024_003C_003E8__locals0.vm.FundDatePersian != null)
						{
							CrmFundLanguageViewModel vm2 = CS_0024_003C_003E8__locals0.vm;
							_ = CS_0024_003C_003E8__locals0.vm.FundDate;
							vm2.FundDatePersian = ((lCID != 1065) ? CS_0024_003C_003E8__locals0.vm.FundDate.ToString("yyyyMMdd") : CS_0024_003C_003E8__locals0.vm.FundDatePersian.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", ""));
							CS_0024_003C_003E8__locals0.vm.FundDatePersian = DateTimeClass.ConvertDateWOSlashToSlash(CS_0024_003C_003E8__locals0.vm.FundDatePersian);
						}
						base.ViewBag.Error = Messages.FundNumberIsDuplicate;
						return View(CS_0024_003C_003E8__locals0.vm);
					}
					_dbTbl.Entry(_003C_003Ec__DisplayClass11_.model).State = EntityState.Modified;
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass11_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass11_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass11_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmFund_Lang> crmFund_Lang = _dbTbl.CrmFund_Lang;
							val = Expression.Parameter(typeof(CrmFund_Lang), "c");
							CrmFund_Lang crmFund_Lang2 = Queryable.FirstOrDefault<CrmFund_Lang>((IQueryable<CrmFund_Lang>)crmFund_Lang, Expression.Lambda<Func<CrmFund_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass11_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass11_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmFund_Lang2 != null)
							{
								crmFund_Lang2.FundDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmFund_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmFund_Lang2 = new CrmFund_Lang();
							crmFund_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							crmFund_Lang2.FundId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.FundId;
							crmFund_Lang2.FundDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.CrmFund_Lang.Add(crmFund_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					_db.CRMspReUpdateFundRemain(CS_0024_003C_003E8__locals0.vm.CrmUserId);
					if (_003C_003Ec__DisplayClass11_.model.FundIsVerified.HasValue && _003C_003Ec__DisplayClass11_.model.FundIsVerified.Value && (!CS_0024_003C_003E8__locals0.vm.FundIsVerified.HasValue || !CS_0024_003C_003E8__locals0.vm.FundIsVerified.Value) && UserLogin.IsUserAccess("frmFund", "actExitFromIsVerify", currentUser))
					{
						_dbII.CRMspFundExitFromVerify(_003C_003Ec__DisplayClass11_.model.FundId);
						flag2 = true;
					}
					if ((!_003C_003Ec__DisplayClass11_.model.FundIsVerified.HasValue || !_003C_003Ec__DisplayClass11_.model.FundIsVerified.Value) && CS_0024_003C_003E8__locals0.vm.FundIsVerified.HasValue && CS_0024_003C_003E8__locals0.vm.FundIsVerified.Value && !CS_0024_003C_003E8__locals0.vm.FundVerificationWorkFlowId.HasValue && UserLogin.IsUserAccess("frmFund", "actVerifyFund", currentUser))
					{
						_dbII.CRMspFundVerify(_003C_003Ec__DisplayClass11_.model.FundId, userId, text3);
						flag2 = true;
					}
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					bool flag3 = false;
					int num6 = 0;
					while (!flag3)
					{
						long fundNumber = Enumerable.FirstOrDefault<long>((IEnumerable<long>)Enumerable.ToList<long>(_db.Database.SqlQuery<long>($"Select dbo.CRMfnReturnFundNumber()", Array.Empty<object>())));
						_003C_003Ec__DisplayClass11_.model.FundNumber = fundNumber;
						num2 = _003C_003Ec__DisplayClass11_.model.FundNumber;
						flag3 = ReservedNumber.AddNumber(sysPartId, num2);
						num6++;
						if (num6 > 10)
						{
							break;
						}
					}
					_003C_003Ec__DisplayClass11_.model.FirstRegisterUserId = userId;
					_003C_003Ec__DisplayClass11_.model.FirstRegisterDate = dateTime2;
					_003C_003Ec__DisplayClass11_.model.FirstRegisterDatePersian = text3;
					_003C_003Ec__DisplayClass11_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass11_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_dbTbl.CrmFund.Add(_003C_003Ec__DisplayClass11_.model);
					_dbTbl.Configuration.ValidateOnSaveEnabled = false;
					_dbTbl.SaveChanges();
					_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					num2 = (ReservedNumber.RemoveNumber(sysPartId, num2) ? 0 : num2);
					if (_003C_003Ec__DisplayClass11_.model.FundId <= 0)
					{
						base.ViewBag.Error = Messages.msgErrorRunFunction;
					}
					else
					{
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmFund_Lang crmFund_Lang3 = new CrmFund_Lang();
							crmFund_Lang3.LanguageID = lang.LanguageID;
							crmFund_Lang3.FundId = _003C_003Ec__DisplayClass11_.model.FundId;
							crmFund_Lang3.FundDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
							_dbTbl.CrmFund_Lang.Add(crmFund_Lang3);
							_dbTbl.SaveChanges();
						}
						CS_0024_003C_003E8__locals0.vm.FundId = _003C_003Ec__DisplayClass11_.model.FundId;
						_db.CRMspReUpdateFundRemain(CS_0024_003C_003E8__locals0.vm.CrmUserId);
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				string firstRegInfo = "";
				string regInfo = "";
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass11_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.UserId = userId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass11_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = dateTime2;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDatePersian = _003C_003Ec__DisplayClass11_.model.FirstRegisterDatePersian;
				CS_0024_003C_003E8__locals0.vm.RegisterDatePersian = text3;
				CS_0024_003C_003E8__locals0.vm.AppType = appType;
				SetRegisterInfo(CS_0024_003C_003E8__locals0.vm, ref firstRegInfo, ref regInfo);
				string verifyInfo = "";
				SetVerifyInfo(CS_0024_003C_003E8__locals0.vm, ref verifyInfo);
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUser = firstRegInfo;
				CS_0024_003C_003E8__locals0.vm.EditUser = regInfo;
				if (CS_0024_003C_003E8__locals0.vm.FundId > 0 && !flag && fileSending != null)
				{
					string fileName = Path.GetFileName(fileSending.FileName);
					FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
					string text4 = CS_0024_003C_003E8__locals0.vm.CrmUserId.ToString();
					string text5 = Configuration.FundDirectoryPath + text4;
					string docTime = now.ToString("HH:mm:ss");
					CrmFilesDirectory crmFilesDirectory2 = new CrmFilesDirectory
					{
						FirstRegisterUserId = userId,
						FirstRegisterDate = dateTime2,
						FirstRegisterDatePersian = text3,
						LanguageID = CS_0024_003C_003E8__locals0.defLangID,
						UserId = userId,
						Year1 = year,
						Month1 = month,
						GUId = Guid.NewGuid(),
						RegisterDate = dateTime2,
						RegisterDatePersian = text3,
						DocDateTime = dateTime2,
						DocDate = text3,
						DocTime = docTime,
						DocDay = PersianDate.GetNumberWeekOfDay(now.ToString("yyyy/MM/dd", new PersianCulture())).ToString(),
						AppType = appType,
						FileDirectoryTypeId = -70,
						TypeOprObjectId = CS_0024_003C_003E8__locals0.vm.FundId,
						FolderName = text4,
						Title = fileName,
						OrderView = 5,
						FileCId = fileCId
					};
					_dbTbl.CrmFilesDirectory.Add(crmFilesDirectory2);
					_dbTbl.SaveChanges();
					string[] array = fileName.Split(new char[1] { '.' });
					string text6 = Configuration.MainDirectoryPath + text5 + "/";
					string text7 = text6 + (text6.EndsWith("/") ? "" : "/");
					string text8 = text7.Split(new char[1] { '/' })[^2];
					string text9 = text7.Replace(text8 + "/", "");
					bool flag4 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.FundDirectoryPath, Configuration.UsePassiveFtp);
					if (!flag4)
					{
						flag4 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, Configuration.MainDirectoryPath, Configuration.FundDirectoryPath, Configuration.UsePassiveFtp);
					}
					bool flag5 = facadeFTP.ExistsDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text9, text8, Configuration.UsePassiveFtp);
					if (!flag5)
					{
						flag5 = facadeFTP.CreateDirectoryInFtp(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text9, text8, Configuration.UsePassiveFtp);
					}
					if (flag5 && flag4)
					{
						string text10 = "";
						text10 = crmFilesDirectory2.TypeOprObjectId + "-" + crmFilesDirectory2.FileDirectoryID + "." + array[^1];
						string text11 = "";
						if (facadeFTP.Upload(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, text7 + text10, fileSending, Configuration.UsePassiveFtp))
						{
							text6 = Configuration.PathFtp + text7 + text10;
							text11 = text10;
							text6 = text6.Trim().Replace(Configuration.PathFtp, "");
							crmFilesDirectory2.FilePath = text6;
							crmFilesDirectory2.FileName = text11;
							crmFilesDirectory2.UserId = userId;
							crmFilesDirectory2.Year1 = year;
							crmFilesDirectory2.Month1 = month;
							crmFilesDirectory2.RegisterDate = now;
							crmFilesDirectory2.RegisterDatePersian = text3;
							_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							foreach (Languages item in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmFilesDirectory_Lang entity = new CrmFilesDirectory_Lang
								{
									LanguageID = item.LanguageID,
									FileDirectoryID = crmFilesDirectory2.FileDirectoryID,
									Title = fileName
								};
								_dbTbl.CrmFilesDirectory_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						else
						{
							Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text9 + " ,directoryName: " + text8);
							ErrorSignal.FromCurrentContext().Raise(e2);
							base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
							base.ViewBag.Error = Messages.frmErrorInSendingFile;
							try
							{
								_db.CRMspDeleteCrmFilesDirectory(crmFilesDirectory2.FileDirectoryID);
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text9 + " ,directoryName: " + text8);
						ErrorSignal.FromCurrentContext().Raise(e4);
						base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
						base.ViewBag.Error = Messages.frmErrorInSendingFile;
						try
						{
							_db.CRMspDeleteCrmFilesDirectory(crmFilesDirectory2.FileDirectoryID);
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
					}
				}
			}
			end_IL_01a9:;
		}
		catch (DbEntityValidationException e6)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e6);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		if (num2 != 0L)
		{
			ReservedNumber.RemoveNumber(sysPartId, num2);
		}
		CrmFundLanguageViewModel vm3 = CS_0024_003C_003E8__locals0.vm;
		_ = CS_0024_003C_003E8__locals0.vm.FundDate;
		vm3.FundDatePersian = CS_0024_003C_003E8__locals0.vm.FundDate.ToString("yyyy/MM/dd");
		return View(CS_0024_003C_003E8__locals0.vm);
	}

	public List<TreeViewItemModel> GetFundGroupNodeTree(List<CRMspSelectFundGroupsTree_Result> lstGroups, int? fGroupId)
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			List<CRMspSelectFundGroupsTree_Result> list2 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>(Enumerable.Where<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)lstGroups, (Func<CRMspSelectFundGroupsTree_Result, bool>)((CRMspSelectFundGroupsTree_Result m) => m.ParentId == fGroupId)));
			if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2))
			{
				foreach (CRMspSelectFundGroupsTree_Result item in list2)
				{
					TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
					treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FundGroupId.ToString()));
					treeViewItemModel.Id = item.FundGroupId.ToString();
					treeViewItemModel.Text = item.GroupName;
					treeViewItemModel.ImageUrl = "";
					List<TreeViewItemModel> fundGroupNodeTree = GetFundGroupNodeTree(lstGroups, item.FundGroupId);
					treeViewItemModel.Items = new List<TreeViewItemModel>(fundGroupNodeTree);
					list.Add(treeViewItemModel);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<TreeViewItemModel> GetFundGroupTree()
	{
		List<TreeViewItemModel> list = new List<TreeViewItemModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectFundGroupsTree_Result> list2 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)_db.CRMspSelectFundGroupsTree(0, lCID, result));
			if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2))
			{
				List<CRMspSelectFundGroupsTree_Result> list3 = Enumerable.ToList<CRMspSelectFundGroupsTree_Result>(Enumerable.Where<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list2, (Func<CRMspSelectFundGroupsTree_Result, bool>)((CRMspSelectFundGroupsTree_Result m) => m.ParentId == 0)));
				if (Enumerable.Any<CRMspSelectFundGroupsTree_Result>((IEnumerable<CRMspSelectFundGroupsTree_Result>)list3))
				{
					foreach (CRMspSelectFundGroupsTree_Result item in list3)
					{
						TreeViewItemModel treeViewItemModel = new TreeViewItemModel();
						treeViewItemModel.HtmlAttributes.Add(new KeyValuePair<string, string>("accesskey", item.FundGroupId.ToString()));
						treeViewItemModel.Id = item.FundGroupId.ToString();
						treeViewItemModel.Text = item.GroupName;
						treeViewItemModel.ImageUrl = "";
						List<TreeViewItemModel> fundGroupNodeTree = GetFundGroupNodeTree(list2, item.FundGroupId);
						treeViewItemModel.Items = new List<TreeViewItemModel>(fundGroupNodeTree);
						list.Add(treeViewItemModel);
					}
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult _PartialFundGroupTree()
	{
		try
		{
			base.ViewBag.FundGroupTree = GetFundGroupTree();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView();
	}

	[AjaxOnly]
	public JsonResult GetFundSumFooter(int crmUserId, string fDate = "", string tDate = "", int fundGroupId = 0)
	{
		CRMspReturnFundSumFooter_Result data = new CRMspReturnFundSumFooter_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			data = Enumerable.FirstOrDefault<CRMspReturnFundSumFooter_Result>((IEnumerable<CRMspReturnFundSumFooter_Result>)_db.CRMspReturnFundSumFooter(crmUserId, userId: UserLogin.CurrentUser.UserId, fDateTime: (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value) : null, tDateTime: (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value2) : null, fundGroupId: fundGroupId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmFund", ActionName = "actReUpdateFundRemain")]
	public string ActUpdateFundRemain(int crmUserId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmFund", "actReUpdateFundRemain", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (crmUserId > 0)
			{
				_db.CRMspReUpdateFundRemain(crmUserId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public long CheckDuplicateNumber(long fundNumber, int? currFundId)
	{
		if (!currFundId.HasValue)
		{
			currFundId = 0;
		}
		try
		{
			return Enumerable.FirstOrDefault<long>(_db.Database.SqlQuery<long>($"Select * from  dbo.CRMfnCheckDuplicateFundNumber({fundNumber}, {currFundId})", Array.Empty<object>()));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			return -1L;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			return -1L;
		}
	}

	[DynamicAuthorize(ControllerName = "frmFund", ActionName = "actShowFile")]
	public ActionResult ShowFiles(int fundId)
	{
		base.ViewBag.FundId = fundId;
		return View();
	}

	[AjaxOnly]
	public ActionResult FundFiles_Read([DataSourceRequest] DataSourceRequest request, int fundId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (fundId > 0)
			{
				list = Files.SelectFilesDirectory("", "", "", "70", fundId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						DateTime now = DateTime.Now;
						if (item.DocDateTime.HasValue)
						{
							item.DocDate = DateTime.Parse(item.DocDateTime.ToString()).ToString("yyyy/MM/dd");
						}
						else if (!string.IsNullOrEmpty(item.DocDate))
						{
							item.DocDate = PersianDate.GetFormatetdDate(item.DocDate);
						}
						if (!string.IsNullOrEmpty(item.DocDay))
						{
							item.DocDay = DateTimeClass.ConvertNumToDayeOfWeek(int.Parse(item.DocDay));
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public void SetRegisterInfoFile(CrmFilesDirectoryLanguageViewModel model, ref string firstRegInfo, ref string regInfo)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (model == null)
			{
				return;
			}
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(model.FirstRegisterUserId + "," + model.UserId);
			if (list == null || !Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				return;
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
			if (cRMspSelectUsersByIds_Result != null)
			{
				firstRegInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.LName)) ? cRMspSelectUsersByIds_Result.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result.FName)) ? (" " + cRMspSelectUsersByIds_Result.FName) : "");
				string text = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				firstRegInfo += ((!string.IsNullOrEmpty(text)) ? (" (" + text + ")") : "");
			}
			CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
			if (cRMspSelectUsersByIds_Result2 != null)
			{
				regInfo = ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.LName)) ? cRMspSelectUsersByIds_Result2.LName : "") + ((!string.IsNullOrEmpty(cRMspSelectUsersByIds_Result2.FName)) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "");
				_ = model.RegisterDate;
				string text2 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(model.AppType))
				{
					model.AppType = Configuration.AppType;
				}
				string text3 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
				regInfo = regInfo + " (" + text3 + ")" + ((!string.IsNullOrEmpty(text2)) ? (" (" + text2 + ")") : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[DynamicAuthorize(ControllerName = "frmShowFundFiles", ActionName = "actInsertFile,actEditFile")]
	public ActionResult FileInsertEdit(int fundId, int fileId = 0)
	{
		_003C_003Ec__DisplayClass21_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass21_0();
		CS_0024_003C_003E8__locals0.fileId = fileId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = Configuration.HostTempFilesPath + "/" + Configuration.TmpFileDirectoryPath + "/" + UserLogin.CurrentUser.UserId;
		string path = base.Server.MapPath(text);
		if (System.IO.Directory.Exists(path))
		{
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(path);
				FileInfo[] files = directoryInfo.GetFiles();
				for (int i = 0; i < files.Length; i++)
				{
					files[i].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int i = 0; i < directories.Length; i++)
				{
					directories[i].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(path))
				{
					System.IO.Directory.Delete(path);
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		CrmFilesDirectoryLanguageViewModel crmFilesDirectoryLanguageViewModel;
		ParameterExpression val;
		try
		{
			if (CS_0024_003C_003E8__locals0.fileId > 0)
			{
				if (!UserLogin.IsUserAccess("frmShowFundFiles", "actEditFile"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
				val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
				CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmFilesDirectory2 == null)
				{
					DateTime now = DateTime.Now;
					crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel
					{
						UserId = UserLogin.CurrentUser.UserId,
						Year1 = short.Parse(Financial.Get().Id.ToString()),
						Month1 = short.Parse(now.ToString("MM", new PersianCulture())),
						RegisterDate = now,
						RegisterDatePersian = now.ToString("yyyyMMdd"),
						DocDate = now.ToString("yyyyMMdd"),
						DocTime = now.ToString("HH:mm:ss"),
						DocDay = DefineDayeOfWeek(),
						FirstRegisterUserId = UserLogin.CurrentUser.UserId,
						FirstRegisterDate = now,
						AppTypeHelp = Configuration.AppType
					};
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					DbSet<CrmFilesDirectory_Lang> crmFilesDirectory_Lang = _dbTbl.CrmFilesDirectory_Lang;
					val = Expression.Parameter(typeof(CrmFilesDirectory_Lang), "c");
					List<CrmFilesDirectory_Lang> list = Enumerable.ToList<CrmFilesDirectory_Lang>((IEnumerable<CrmFilesDirectory_Lang>)Queryable.Where<CrmFilesDirectory_Lang>((IQueryable<CrmFilesDirectory_Lang>)crmFilesDirectory_Lang, Expression.Lambda<Func<CrmFilesDirectory_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass21_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
					List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFilesDirectory_Lang>)list, (Func<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>)((CrmFilesDirectory_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.Title,
						LanguageId = item.LanguageID
					})));
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = crmFilesDirectory2.Title,
						LanguageId = result
					});
					List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmFilesDirectory_Lang>)list, (Func<CrmFilesDirectory_Lang, CommonMultiLanguageViewModel>)((CrmFilesDirectory_Lang item) => new CommonMultiLanguageViewModel
					{
						Value = item.FileDesc,
						LanguageId = item.LanguageID
					})));
					list3.Add(new CommonMultiLanguageViewModel
					{
						Value = crmFilesDirectory2.FileDesc,
						LanguageId = result
					});
					crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel
					{
						MasterId = crmFilesDirectory2.MasterId,
						SubDetailId = crmFilesDirectory2.SubDetailId,
						LanguageID = crmFilesDirectory2.LanguageID,
						UserId = crmFilesDirectory2.UserId,
						AppType = crmFilesDirectory2.AppType,
						GUId = crmFilesDirectory2.GUId,
						RegisterDate = crmFilesDirectory2.RegisterDate,
						Month1 = crmFilesDirectory2.Month1,
						RegisterDatePersian = crmFilesDirectory2.RegisterDatePersian,
						Year1 = crmFilesDirectory2.Year1,
						FileDirectoryID = crmFilesDirectory2.FileDirectoryID,
						FileName = crmFilesDirectory2.FileName,
						DocDateTime = crmFilesDirectory2.DocDateTime,
						FilePath = crmFilesDirectory2.FilePath,
						TypeOprObjectId = crmFilesDirectory2.TypeOprObjectId,
						DocDate = crmFilesDirectory2.DocDate,
						DetailId = crmFilesDirectory2.DetailId,
						FileDirectoryTypeId = crmFilesDirectory2.FileDirectoryTypeId,
						FolderName = crmFilesDirectory2.FolderName,
						DocDay = crmFilesDirectory2.DocDay,
						CopyFromPath = crmFilesDirectory2.CopyFromPath,
						DocTime = crmFilesDirectory2.DocTime,
						Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Title_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
						FirstRegisterUserId = (crmFilesDirectory2.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId),
						FirstRegisterDate = crmFilesDirectory2.FirstRegisterDate,
						AppTypeHelp = crmFilesDirectory2.AppType,
						Desc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
						Desc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
					};
				}
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmShowFundFiles", "actInsertFile"))
				{
					base.ViewBag.Error = Messages.NotAccessToPage;
					return null;
				}
				_ = DateTime.Now;
				crmFilesDirectoryLanguageViewModel = new CrmFilesDirectoryLanguageViewModel();
				DateTime now2 = DateTime.Now;
				crmFilesDirectoryLanguageViewModel.UserId = UserLogin.CurrentUser.UserId;
				crmFilesDirectoryLanguageViewModel.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmFilesDirectoryLanguageViewModel.Month1 = short.Parse(now2.ToString("MM", new PersianCulture()));
				crmFilesDirectoryLanguageViewModel.RegisterDate = now2;
				crmFilesDirectoryLanguageViewModel.RegisterDatePersian = now2.ToString("yyyyMMdd");
				crmFilesDirectoryLanguageViewModel.DocDate = now2.ToString("yyyyMMdd");
				crmFilesDirectoryLanguageViewModel.DocTime = now2.ToString("HH:mm:ss");
				crmFilesDirectoryLanguageViewModel.DocDateTime = now2;
				crmFilesDirectoryLanguageViewModel.DocDay = DefineDayeOfWeek();
				crmFilesDirectoryLanguageViewModel.TypeOprObjectId = fundId;
				crmFilesDirectoryLanguageViewModel.FileDirectoryTypeId = -70;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.ViewBag.Error = ex.Message;
			return null;
		}
		GetDayList();
		string firstRegInfo = "";
		string regInfo = "";
		SetRegisterInfoFile(crmFilesDirectoryLanguageViewModel, ref firstRegInfo, ref regInfo);
		base.ViewBag.FirstRegisterUser = firstRegInfo;
		base.ViewBag.EditUser = regInfo;
		base.ViewBag.IsBuying = VersionBuyer.AttachFiles;
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory3 = _dbTbl.CrmFilesDirectory;
		val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory3, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		dynamic viewBag2 = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory4 = _dbTbl.CrmFilesDirectory;
		val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag2.CountFile = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory4, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		return View(crmFilesDirectoryLanguageViewModel);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmShowFundFiles", ActionName = "actInsertFile,actEditFile")]
	public ActionResult FileInsertEdit(CrmFilesDirectoryLanguageViewModel model, HttpPostedFileBase[] FileUrlUpload)
	{
		//IL_0202: Unknown result type (might be due to invalid IL or missing references)
		//IL_0256: Unknown result type (might be due to invalid IL or missing references)
		//IL_074b: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		int countError = 0;
		int? num = null;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserLastCId;
		}
		int? fileCId = null;
		if (num.GetValueOrDefault() != 0)
		{
			fileCId = num;
		}
		GetDayList();
		dynamic viewBag = base.ViewBag;
		DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
		ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
		viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		try
		{
			if (VersionBuyer.AttachFiles)
			{
				goto IL_01e9;
			}
			DbSet<CrmFilesDirectory> crmFilesDirectory2 = _dbTbl.CrmFilesDirectory;
			val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			if (!Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory2, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
			{
				goto IL_01e9;
			}
			text = "BV|" + Messages.VersionBuy;
			goto end_IL_0164;
			IL_1788:
			int userId;
			CS_0024_003C_003E8__locals0.model.UserId = userId;
			DateTime now;
			CS_0024_003C_003E8__locals0.model.RegisterDate = now;
			string text4;
			CS_0024_003C_003E8__locals0.model.RegisterDatePersian = text4;
			goto end_IL_0164;
			IL_01e9:
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Title_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Title_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Title,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.Desc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.Desc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.Desc,
				LanguageId = lCID
			});
			text = ChkBeforeSubmitFile(CS_0024_003C_003E8__locals0.model, list, list2, ref countError);
			DateTime dateTime = default(DateTime);
			string text5 = "";
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DocTime))
			{
				CS_0024_003C_003E8__locals0.model.DocTime = DateTime.Now.ToString("HH:mm:ss");
			}
			try
			{
				if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.DocDate))
				{
					text5 = PersianDate.GetFormatetdDate(CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new PersianCulture());
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new CultureInfo("ar-SA"));
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text5 + " " + CS_0024_003C_003E8__locals0.model.DocTime, new CultureInfo("en-US"));
						CS_0024_003C_003E8__locals0.model.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					CS_0024_003C_003E8__locals0.model.DocDateTime = dateTime;
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = Messages.msgErrorEnterCorrectDateFormat;
				countError++;
			}
			if (CS_0024_003C_003E8__locals0.model.DocDate != null)
			{
				CS_0024_003C_003E8__locals0.model.DocDate = CS_0024_003C_003E8__locals0.model.DocDate.Replace("/", "").Replace("-", "").Replace("_", "")
					.Replace(".", "")
					.Replace(",", "")
					.Replace("\\", "");
			}
			if (countError == 0)
			{
				if (!base.ModelState.IsValid)
				{
					base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
				}
				else
				{
					_003C_003Ec__DisplayClass22_1 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_1();
					now = DateTime.Now;
					text4 = now.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now.ToString("MM", new PersianCulture()));
					userId = UserLogin.CurrentUser.UserId;
					string appType = Configuration.AppType;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass22_.fileDir = new CrmFilesDirectory();
					if (CS_0024_003C_003E8__locals0.model.FileDirectoryID > 0)
					{
						DbSet<CrmFilesDirectory> crmFilesDirectory3 = _dbTbl.CrmFilesDirectory;
						val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
						_003C_003Ec__DisplayClass22_.fileDir = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory3, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass22_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					_003C_003Ec__DisplayClass22_.fileDir.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass22_.fileDir.UserId = userId;
					_003C_003Ec__DisplayClass22_.fileDir.Year1 = year;
					_003C_003Ec__DisplayClass22_.fileDir.Month1 = month;
					_003C_003Ec__DisplayClass22_.fileDir.Month1 = month;
					_003C_003Ec__DisplayClass22_.fileDir.RegisterDate = now;
					_003C_003Ec__DisplayClass22_.fileDir.RegisterDatePersian = text4;
					_003C_003Ec__DisplayClass22_.fileDir.AppType = appType;
					_003C_003Ec__DisplayClass22_.fileDir.DocDate = CS_0024_003C_003E8__locals0.model.DocDate;
					_003C_003Ec__DisplayClass22_.fileDir.DocDay = CS_0024_003C_003E8__locals0.model.DocDay;
					_003C_003Ec__DisplayClass22_.fileDir.DocTime = CS_0024_003C_003E8__locals0.model.DocTime;
					_003C_003Ec__DisplayClass22_.fileDir.DocDateTime = CS_0024_003C_003E8__locals0.model.DocDateTime;
					_003C_003Ec__DisplayClass22_.fileDir.FileDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (CS_0024_003C_003E8__locals0.model.FileDirectoryID == 0)
					{
						if (!UserLogin.IsUserAccess("frmShowFundFiles", "actInsertFile"))
						{
							text = Messages.NotAccessToPage;
						}
						else
						{
							List<CrmFilesDirectoryTemplate> list3 = new List<CrmFilesDirectoryTemplate>();
							if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.FilesPath))
							{
								list3 = new JavaScriptSerializer().Deserialize<List<CrmFilesDirectoryTemplate>>(CS_0024_003C_003E8__locals0.model.FilesPath);
								if (list3.Count > 0)
								{
									list3 = Enumerable.ToList<CrmFilesDirectoryTemplate>(Enumerable.Where<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3, (Func<CrmFilesDirectoryTemplate, bool>)((CrmFilesDirectoryTemplate x) => x.FileDirectoryTemplateID > 0)));
								}
							}
							if (list3 == null || Enumerable.Count<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3) <= 0)
							{
								text = Messages.msgErrorNoFileInNotSelect;
							}
							else
							{
								bool flag = false;
								int maxFileCount = Configuration.MaxFileCount;
								if (Enumerable.Count<CrmFilesDirectoryTemplate>((IEnumerable<CrmFilesDirectoryTemplate>)list3) > maxFileCount)
								{
									string msgErrorMessageMaxSizeFile = Messages.msgErrorMessageMaxSizeFile;
									base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile, maxFileCount));
									flag = true;
									text = string.Format(msgErrorMessageMaxSizeFile, maxFileCount) + "<br>";
								}
								else
								{
									foreach (CrmFilesDirectoryTemplate item3 in list3)
									{
										if (string.IsNullOrEmpty(item3.CopyFromPath))
										{
											continue;
										}
										string value = "";
										string text6 = ((item3.Title != null) ? Path.GetExtension(item3.Title).ToLower() : "");
										RegistryKey val2 = Registry.ClassesRoot.OpenSubKey(text6);
										if (val2 != null && val2.GetValue("Content Type") != null)
										{
											value = val2.GetValue("Content Type").ToString();
										}
										if (string.IsNullOrWhiteSpace(value))
										{
											value = Files.GetMimeType(text6);
										}
										string arg = item3.Title ?? "";
										if (!System.IO.File.Exists(item3.CopyFromPath))
										{
											string msgErrorFileDoesNotExist = Messages.msgErrorFileDoesNotExist;
											base.ModelState.AddModelError("error", string.Format(msgErrorFileDoesNotExist, arg));
											flag = true;
											text = text + string.Format(msgErrorFileDoesNotExist, arg) + "<br>";
											continue;
										}
										string text7 = (text6 ?? "").ToLower();
										text7 = text7.Replace(".", "");
										if (Configuration.MaliciousFileExtensions.Contains(text7))
										{
											base.ModelState.AddModelError("error", Messages.msgErrorFileIsExecuted);
											flag = true;
											text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + Messages.msgErrorFileIsExecuted + "<br>";
										}
										int num2 = Configuration.MaxFileSizeForUploadMb * 1024 * 1024;
										long length = new FileInfo(item3.CopyFromPath).Length;
										if (length > num2)
										{
											string fileFormatByteSize = CRM.General.IO.File.GetFileFormatByteSize(length);
											string fileFormatByteSize2 = CRM.General.IO.File.GetFileFormatByteSize(num2);
											string msgErrorMessageMaxSizeFile2 = Messages.msgErrorMessageMaxSizeFile;
											base.ModelState.AddModelError("error", string.Format(msgErrorMessageMaxSizeFile2, fileFormatByteSize, fileFormatByteSize2));
											flag = true;
											text = text + string.Format(Messages.msgErrorNotUploadFileByDue, arg) + string.Format(msgErrorMessageMaxSizeFile2, fileFormatByteSize, fileFormatByteSize2) + "<br>";
										}
										if (!flag)
										{
											continue;
										}
										goto end_IL_0164;
									}
									CRMspSelectFund_Result cRMspSelectFund_Result = Enumerable.FirstOrDefault<CRMspSelectFund_Result>((IEnumerable<CRMspSelectFund_Result>)_db.CRMspSelectFund(0, CS_0024_003C_003E8__locals0.model.TypeOprObjectId, UserLogin.CurrentUser.UserId, now, now, languageID: lCID, defaultLanguageID: CS_0024_003C_003E8__locals0.defLangID, fundGroupId: 0));
									if (cRMspSelectFund_Result != null)
									{
										if (list3 != null)
										{
											FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
											string pathFtp = Configuration.PathFtp;
											string userNameFtp = Configuration.UserNameFtp;
											string passwordFtp = Configuration.PasswordFtp;
											bool usePassiveFtp = Configuration.UsePassiveFtp;
											bool flag2 = true;
											foreach (CrmFilesDirectoryTemplate item4 in list3)
											{
												string text8 = "";
												string title = item4.Title;
												string text9 = cRMspSelectFund_Result.CrmUserId.ToString();
												string text10 = Configuration.FundDirectoryPath + text9;
												List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
												bool result = false;
												bool.TryParse(CS_0024_003C_003E8__locals0.model.IsUseSameTitle.ToString(), out result);
												if (list3 != null && !result && list3.Count > 1)
												{
													string title2 = item4.Title;
													if (!string.IsNullOrWhiteSpace(title2) && list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
													{
														foreach (CommonMultiLanguageViewModel item5 in list)
														{
															CommonMultiLanguageViewModel item = new CommonMultiLanguageViewModel
															{
																LanguageId = item5.LanguageId,
																Value = title2
															};
															list4.Add(item);
														}
													}
												}
												if ((list4 == null || !Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4)) && list != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list))
												{
													foreach (CommonMultiLanguageViewModel item6 in list)
													{
														CommonMultiLanguageViewModel item2 = new CommonMultiLanguageViewModel
														{
															LanguageId = item6.LanguageId,
															Value = item6.Value
														};
														list4.Add(item2);
													}
												}
												_003C_003Ec__DisplayClass22_.fileDir = new CrmFilesDirectory();
												_003C_003Ec__DisplayClass22_.fileDir.Title = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
												_003C_003Ec__DisplayClass22_.fileDir.UserId = userId;
												_003C_003Ec__DisplayClass22_.fileDir.Year1 = year;
												_003C_003Ec__DisplayClass22_.fileDir.Month1 = month;
												_003C_003Ec__DisplayClass22_.fileDir.Month1 = month;
												_003C_003Ec__DisplayClass22_.fileDir.RegisterDate = now;
												_003C_003Ec__DisplayClass22_.fileDir.RegisterDatePersian = text4;
												_003C_003Ec__DisplayClass22_.fileDir.AppType = appType;
												_003C_003Ec__DisplayClass22_.fileDir.DocDate = CS_0024_003C_003E8__locals0.model.DocDate;
												_003C_003Ec__DisplayClass22_.fileDir.DocDay = CS_0024_003C_003E8__locals0.model.DocDay;
												_003C_003Ec__DisplayClass22_.fileDir.DocTime = CS_0024_003C_003E8__locals0.model.DocTime;
												_003C_003Ec__DisplayClass22_.fileDir.DocDateTime = CS_0024_003C_003E8__locals0.model.DocDateTime;
												_003C_003Ec__DisplayClass22_.fileDir.TypeOprObjectId = CS_0024_003C_003E8__locals0.model.TypeOprObjectId;
												_003C_003Ec__DisplayClass22_.fileDir.FolderName = text9;
												_003C_003Ec__DisplayClass22_.fileDir.FileName = title;
												_003C_003Ec__DisplayClass22_.fileDir.GUId = Guid.NewGuid();
												_003C_003Ec__DisplayClass22_.fileDir.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
												_003C_003Ec__DisplayClass22_.fileDir.FirstRegisterUserId = userId;
												_003C_003Ec__DisplayClass22_.fileDir.FirstRegisterDatePersian = text4;
												_003C_003Ec__DisplayClass22_.fileDir.FirstRegisterDate = now;
												_003C_003Ec__DisplayClass22_.fileDir.FileDirectoryTypeId = -70;
												_003C_003Ec__DisplayClass22_.fileDir.FileCId = fileCId;
												_003C_003Ec__DisplayClass22_.fileDir.FileDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
												_dbTbl.CrmFilesDirectory.Add(_003C_003Ec__DisplayClass22_.fileDir);
												_dbTbl.SaveChanges();
												string[] array = title.Split(new char[1] { '.' });
												text8 = Configuration.MainDirectoryPath + text10 + "/";
												string text11 = text8 + (text8.EndsWith("/") ? "" : "/");
												string text12 = text11.Split(new char[1] { '/' })[^2];
												string text13 = text11.Replace(text12 + "/", "");
												bool flag3 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FundDirectoryPath, usePassiveFtp);
												if (!flag3)
												{
													flag3 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, Configuration.MainDirectoryPath, Configuration.FundDirectoryPath, usePassiveFtp);
												}
												bool flag4 = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text13, text12, usePassiveFtp);
												if (!flag4)
												{
													flag4 = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text13, text12, usePassiveFtp);
												}
												if (flag4 && flag3)
												{
													string text14 = "";
													text14 = _003C_003Ec__DisplayClass22_.fileDir.TypeOprObjectId + "-" + _003C_003Ec__DisplayClass22_.fileDir.FileDirectoryID + "." + array[^1];
													string text15 = "";
													if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text11 + text14, item4.CopyFromPath, usePassiveFtp))
													{
														text8 = pathFtp + text11 + text14;
														text15 = text14;
														text8 = text8.Trim().Replace(pathFtp, "");
														_003C_003Ec__DisplayClass22_.fileDir.FilePath = text8;
														_003C_003Ec__DisplayClass22_.fileDir.FileName = text15;
														_003C_003Ec__DisplayClass22_.fileDir.UserId = userId;
														_003C_003Ec__DisplayClass22_.fileDir.Year1 = year;
														_003C_003Ec__DisplayClass22_.fileDir.Month1 = month;
														_003C_003Ec__DisplayClass22_.fileDir.RegisterDate = now;
														_003C_003Ec__DisplayClass22_.fileDir.RegisterDatePersian = text4;
														_dbTbl.Entry(_003C_003Ec__DisplayClass22_.fileDir).State = EntityState.Modified;
														_dbTbl.SaveChanges();
														foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
														{
															CrmFilesDirectory_Lang crmFilesDirectory_Lang = new CrmFilesDirectory_Lang();
															crmFilesDirectory_Lang.LanguageID = lang.LanguageID;
															crmFilesDirectory_Lang.FileDirectoryID = _003C_003Ec__DisplayClass22_.fileDir.FileDirectoryID;
															crmFilesDirectory_Lang.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
															crmFilesDirectory_Lang.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
															_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang);
															_dbTbl.SaveChanges();
														}
														try
														{
															if (System.IO.File.Exists(item4.CopyFromPath))
															{
																System.IO.File.Delete(item4.CopyFromPath);
															}
														}
														catch (Exception e2)
														{
															ErrorSignal.FromCurrentContext().Raise(e2);
														}
														continue;
													}
													flag2 = false;
													Exception e3 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text13 + " ,directoryName: " + text12);
													ErrorSignal.FromCurrentContext().Raise(e3);
													base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
													text = Messages.frmErrorInSendingFile;
													try
													{
														_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass22_.fileDir.FileDirectoryID);
													}
													catch (Exception e4)
													{
														ErrorSignal.FromCurrentContext().Raise(e4);
													}
												}
												else
												{
													flag2 = false;
													Exception e5 = new Exception(Messages.msgErrorCreateFolderInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text13 + " ,directoryName: " + text12);
													ErrorSignal.FromCurrentContext().Raise(e5);
													base.ModelState.AddModelError("error", Messages.frmErrorInSendingFile);
													text = Messages.frmErrorInSendingFile;
													try
													{
														_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass22_.fileDir.FileDirectoryID);
													}
													catch (Exception e6)
													{
														ErrorSignal.FromCurrentContext().Raise(e6);
													}
												}
												goto end_IL_0164;
											}
											if (flag2)
											{
												base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
											}
										}
										goto IL_1788;
									}
									text = Messages.ErrorNotFound;
								}
							}
						}
					}
					else
					{
						if (UserLogin.IsUserAccess("frmShowFundFiles", "actEditFile"))
						{
							_dbTbl.Entry(_003C_003Ec__DisplayClass22_.fileDir).State = EntityState.Modified;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							using (List<Languages>.Enumerator enumerator3 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									_003C_003Ec__DisplayClass22_3 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass22_3();
									CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass22_;
									CS_0024_003C_003E8__locals2.lang = enumerator3.Current;
									DbSet<CrmFilesDirectory_Lang> crmFilesDirectory_Lang2 = _dbTbl.CrmFilesDirectory_Lang;
									val = Expression.Parameter(typeof(CrmFilesDirectory_Lang), "c");
									CrmFilesDirectory_Lang crmFilesDirectory_Lang3 = Queryable.FirstOrDefault<CrmFilesDirectory_Lang>((IQueryable<CrmFilesDirectory_Lang>)crmFilesDirectory_Lang2, Expression.Lambda<Func<CrmFilesDirectory_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass22_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass22_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmFilesDirectory_Lang3 != null)
									{
										crmFilesDirectory_Lang3.Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										crmFilesDirectory_Lang3.FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmFilesDirectory_Lang3).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									crmFilesDirectory_Lang3 = new CrmFilesDirectory_Lang
									{
										Title = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
										FileDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals2.lang.LanguageID)).Value : null),
										LanguageID = CS_0024_003C_003E8__locals2.lang.LanguageID,
										FileDirectoryID = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.fileDir.FileDirectoryID
									};
									_dbTbl.CrmFilesDirectory_Lang.Add(crmFilesDirectory_Lang3);
									_dbTbl.SaveChanges();
								}
							}
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
							goto IL_1788;
						}
						text = Messages.NotAccessToPage;
					}
				}
			}
			end_IL_0164:;
		}
		catch (DbEntityValidationException e7)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e7);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			base.ViewBag.Error = Messages.msgErrorRunFunction;
		}
		base.ViewBag.Error = text;
		text2 = "";
		text3 = "";
		SetRegisterInfoFile(CS_0024_003C_003E8__locals0.model, ref text2, ref text3);
		base.ViewBag.FirstRegisterUser = text2;
		base.ViewBag.EditUser = text3;
		return View(CS_0024_003C_003E8__locals0.model);
	}

	public string DefineDayeOfWeek()
	{
		return DateTime.Now.DayOfWeek.ToString() switch
		{
			"Saturday" => "7", 
			"Sunday" => "1", 
			"Monday" => "2", 
			"Tuesday" => "3", 
			"Wednesday" => "4", 
			"Thursday" => "5", 
			"Friday" => "6", 
			_ => null, 
		};
	}

	public void GetDayList()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		list.Add(new SelectListItem
		{
			Text = Labels.Saturday,
			Value = "7",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Sunday,
			Value = "1",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Monday,
			Value = "2",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Tuesday,
			Value = "3",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Wednesday,
			Value = "4",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Thursday,
			Value = "5",
			Selected = false
		});
		list.Add(new SelectListItem
		{
			Text = Labels.Friday,
			Value = "6",
			Selected = false
		});
		base.ViewBag.Dayslist = list;
	}

	public string ChkBeforeSubmitFile(CrmFilesDirectoryLanguageViewModel fileDir, List<CommonMultiLanguageViewModel> listModelObj_Title_Lang, List<CommonMultiLanguageViewModel> listModelObj_Desc_Lang, ref int countError)
	{
		string text = "";
		if (string.IsNullOrEmpty(fileDir.DocDate))
		{
			text += Messages.CheckFileEmptyDocDate;
			countError++;
		}
		if (string.IsNullOrEmpty(fileDir.DocDay))
		{
			text += Messages.CheckFileEmptyDocDay;
			countError++;
		}
		if (string.IsNullOrEmpty(fileDir.DocTime))
		{
			text += Messages.CheckFileEmptyDocTime;
			countError++;
		}
		if (fileDir.Title == null && fileDir.Title == "")
		{
			text = text + Messages.CheckTitle + "<br/>";
			countError++;
		}
		else if (!checkMultiLanguage(fileDir.Title, listModelObj_Title_Lang))
		{
			text = text + Messages.CheckTitleLang + "<br>";
			countError++;
		}
		if (!string.IsNullOrEmpty(fileDir.Desc) && !checkMultiLanguage(fileDir.Desc, listModelObj_Desc_Lang))
		{
			text = text + Messages.CheckTitleLang + "<br>";
			countError++;
		}
		if (!fileDir.FileDirectoryTypeId.HasValue || fileDir.FileDirectoryTypeId == 0)
		{
			text += Messages.CheckFileEmptyFileDirectoryTypeId;
			countError++;
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

	public string DeleteAllFiles(int fundId)
	{
		string result = "-1";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (fundId > 0)
			{
				list = Files.SelectFilesDirectory("", "", "", "70", fundId.ToString(), "0", "0", false);
				if (Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					using List<CRMspSelectFilesDirectory_Result>.Enumerator enumerator = list.GetEnumerator();
					while (enumerator.MoveNext())
					{
						_003C_003Ec__DisplayClass27_0 _003C_003Ec__DisplayClass27_ = new _003C_003Ec__DisplayClass27_0();
						_003C_003Ec__DisplayClass27_.item = enumerator.Current;
						DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
						ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
						CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass27_, typeof(_003C_003Ec__DisplayClass27_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmFilesDirectory2 != null)
						{
							string text = crmFilesDirectory2.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
							text = ((!text.Contains("/" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Configuration.IntmsgDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Configuration.KnlgTDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Configuration.DyDirectoryPath.ToLower().Replace("/", "") + "\\")) ? ((!text.Contains("/" + Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "/") && !text.Contains("\\" + Configuration.FundDirectoryPath.ToLower().Replace("/", "") + "\\")) ? (Configuration.MainDirectoryPath + crmFilesDirectory2.FolderName + "/" + crmFilesDirectory2.FileName) : (Configuration.MainDirectoryPath + Configuration.FundDirectoryPath + crmFilesDirectory2.FolderName + "/" + crmFilesDirectory2.FileName)) : (Configuration.MainDirectoryPath + Configuration.DyDirectoryPath + crmFilesDirectory2.FolderName + "/" + crmFilesDirectory2.FileName)) : (Configuration.MainDirectoryPath + Configuration.KnlgTDirectoryPath + crmFilesDirectory2.FolderName + "/" + crmFilesDirectory2.FileName)) : (Configuration.MainDirectoryPath + Configuration.IntmsgDirectoryPath + crmFilesDirectory2.FolderName + "/" + crmFilesDirectory2.FileName));
							FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
							string destination = text;
							if (facadeFTP.Delete(Configuration.PathFtp, Configuration.UserNameFtp, Configuration.PasswordFtp, crmFilesDirectory2.FileName, destination, Configuration.UsePassiveFtp))
							{
								_db.CRMspDeleteCrmFilesDirectory(_003C_003Ec__DisplayClass27_.item.FileDirectoryID);
							}
						}
					}
				}
				list = Files.SelectFilesDirectory("", "", "", "70", fundId.ToString(), "0", "0", false);
				if (!Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					result = Messages.frmDeleteSuccessMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ActionResult GetVerificationWorkFlows()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			foreach (WSspSelectVerificationWorkFlowWithObjectType_Result item in _db.WSspSelectVerificationWorkFlowWithObjectType(130, lCID, result))
			{
				list.Add(new SelectListItem
				{
					Value = item.VerificationWorkFlowId.ToString(),
					Text = item.VerificationWorkFlowTitle
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.VerificationWorkFlows = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult GetVerificationWorkFlowOfFundGroup(int groupId)
	{
		_003C_003Ec__DisplayClass29_0 _003C_003Ec__DisplayClass29_ = new _003C_003Ec__DisplayClass29_0();
		_003C_003Ec__DisplayClass29_.groupId = groupId;
		int num = 0;
		try
		{
			DbSet<CrmFundGroups> crmFundGroups = _dbTbl.CrmFundGroups;
			ParameterExpression val = Expression.Parameter(typeof(CrmFundGroups), "c");
			CrmFundGroups crmFundGroups2 = Queryable.FirstOrDefault<CrmFundGroups>(Queryable.Where<CrmFundGroups>((IQueryable<CrmFundGroups>)crmFundGroups, Expression.Lambda<Func<CrmFundGroups, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass29_, typeof(_003C_003Ec__DisplayClass29_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			if (crmFundGroups2 != null)
			{
				num = crmFundGroups2.GroupVerificationWorkFlowId.GetValueOrDefault();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(num, JsonRequestBehavior.AllowGet);
	}

	public ActionResult VerifyFund(int fundId)
	{
		CommonResultViewModel<int> commonResultViewModel = new CommonResultViewModel<int>();
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		try
		{
			CrmFund crmFund = _dbTbl.CrmFund.Find(fundId);
			if (!UserLogin.IsUserAccess("frmFund", "actVerifyFund", currentUser))
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (crmFund == null)
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.MsgErrorNotFound,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (crmFund.FundVerificationWorkFlowId.HasValue)
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.msgErrorFundHasVerificationWorkflow,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string registerDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_dbII.CRMspFundVerify(fundId, UserLogin.CurrentUser.UserId, registerDatePersian);
			commonResultViewModel = new CommonResultViewModel<int>
			{
				Data = 1,
				Message = Messages.msgSuccessFundIsVerified,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		commonResultViewModel = new CommonResultViewModel<int>
		{
			Data = 0,
			Message = Messages.MsgErrorDoneOperation,
			Status = CommonResultStatusViewModel.Error
		};
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult ExitFromVerifyFund(int fundId)
	{
		CommonResultViewModel<int> commonResultViewModel = new CommonResultViewModel<int>();
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		try
		{
			CrmFund crmFund = _dbTbl.CrmFund.Find(fundId);
			if (!UserLogin.IsUserAccess("frmFund", "actExitFromIsVerify", currentUser))
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (crmFund == null)
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.MsgErrorNotFound,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			_ = Configuration.AppType;
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_dbII.CRMspFundExitFromVerify(fundId);
			commonResultViewModel = new CommonResultViewModel<int>
			{
				Data = 1,
				Message = Messages.msgSuccessFundExitIsVerified,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		commonResultViewModel = new CommonResultViewModel<int>
		{
			Data = 0,
			Message = Messages.MsgErrorDoneOperation,
			Status = CommonResultStatusViewModel.Error
		};
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult FundNoVerified_Read([DataSourceRequest] DataSourceRequest request, int crmUserId, string fromDate, string toDate, int fundGroupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFundNoVerified_Result> list = new List<CRMspSelectFundNoVerified_Result>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fromDate))
			{
				fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			if (!string.IsNullOrEmpty(toDate))
			{
				toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
					.Replace(" ", "")
					.Replace("_", "");
				value2 = lCID switch
				{
					1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
					1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
					_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
				};
			}
			list = Enumerable.ToList<CRMspSelectFundNoVerified_Result>((IEnumerable<CRMspSelectFundNoVerified_Result>)_dbII.CRMspSelectFundNoVerified(crmUserId, 0, UserLogin.CurrentUser.UserId, value, value2, languageID: lCID, defaultLanguageID: result, fundGroupId: fundGroupId));
			foreach (CRMspSelectFundNoVerified_Result item in list)
			{
				_ = item.FundDate;
				item.FundDatePersian = item.FundDate.ToString("yyyy/MM/dd HH:mm:ss");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult MultiVerify()
	{
		GetUsers();
		return View();
	}

	public ActionResult MultiVerifyFunds(string fundIds)
	{
		CommonResultViewModel<int> commonResultViewModel = new CommonResultViewModel<int>();
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		try
		{
			if (!UserLogin.IsUserAccess("frmFund", "actFundMultiVerify", currentUser))
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.ErrorNotAccess,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (string.IsNullOrEmpty(fundIds))
			{
				commonResultViewModel = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = Messages.msgErrorNotSelectItem,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
			}
			_ = Configuration.AppType;
			_dbII.CRMspFundVerifyMulti(fundIds, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyyMMdd", new PersianCulture()));
			commonResultViewModel = new CommonResultViewModel<int>
			{
				Data = 1,
				Message = Messages.msgSuccessFundsIsVerified,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		commonResultViewModel = new CommonResultViewModel<int>
		{
			Data = 0,
			Message = Messages.MsgErrorDoneOperation,
			Status = CommonResultStatusViewModel.Error
		};
		return Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public ActionResult ShowDetails(int fundId, bool showVerificationWorkFlow = true)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectFund_Result cRMspSelectFund_Result = new CRMspSelectFund_Result();
		try
		{
			cRMspSelectFund_Result = Enumerable.FirstOrDefault<CRMspSelectFund_Result>((IEnumerable<CRMspSelectFund_Result>)_db.CRMspSelectFund(0, fundId, UserLogin.CurrentUser.UserId, null, null, 0, lCID, result));
			if (cRMspSelectFund_Result == null)
			{
				return View(cRMspSelectFund_Result);
			}
			CRMspSelectFund_Result cRMspSelectFund_Result2 = cRMspSelectFund_Result;
			_ = cRMspSelectFund_Result.FundDate;
			cRMspSelectFund_Result2.FundDatePersian = cRMspSelectFund_Result.FundDate.ToString("yyyy/MM/dd HH:mm:ss");
			CRMspSelectFund_Result cRMspSelectFund_Result3 = cRMspSelectFund_Result;
			_ = cRMspSelectFund_Result.FirstRegisterDate;
			cRMspSelectFund_Result3.FirstRegisterDatePersian = cRMspSelectFund_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			CRMspSelectFund_Result cRMspSelectFund_Result4 = cRMspSelectFund_Result;
			_ = cRMspSelectFund_Result.RegisterDate;
			cRMspSelectFund_Result4.RegisterDatePersian = cRMspSelectFund_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			cRMspSelectFund_Result.FundVerifiedRegisterDateStr = (cRMspSelectFund_Result.FundVerifiedRegisterDate.HasValue ? cRMspSelectFund_Result.FundVerifiedRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			if (cRMspSelectFund_Result.FileDirectoryId.HasValue && cRMspSelectFund_Result.FileDirectoryId > 0)
			{
				List<CRMspSelectFilesDirectory_Result> list = Files.SelectFilesDirectory("", "", "", "70", fundId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					base.ViewBag.FileName = list[0].FileName;
				}
			}
			base.ViewBag.ShowVerificationWorkFlow = showVerificationWorkFlow;
			return View(cRMspSelectFund_Result);
		}
		catch (Exception)
		{
			return View(cRMspSelectFund_Result);
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
