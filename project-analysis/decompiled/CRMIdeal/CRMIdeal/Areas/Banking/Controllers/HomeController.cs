using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Banking.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass15_0
	{
		public int bankingBranchId;

		public int currLangID;

		internal bool _003CBranchInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_0
	{
		public CrmBankingBranchesLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		public Func<Languages, bool> _003C_003E9__21;

		internal bool _003CBranchInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CBranchInsertEdit_003Eb__21(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_1
	{
		public CrmBankingBranches branch;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass16_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass16_1 CS_0024_003C_003E8__locals1;

		internal bool _003CBranchInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CBranchInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass23_0
	{
		public int bankingAccountId;

		public int currLangID;

		internal bool _003CAccountsInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_0
	{
		public CrmBankingAccountsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CAccountsInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_1
	{
		public CrmBankingAccounts bankAcc;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass24_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass24_1 CS_0024_003C_003E8__locals1;

		internal bool _003CAccountsInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CAccountsInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public int bankId;

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

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public CrmBankingBanksLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		public Func<Languages, bool> _003C_003E9__15;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_1
	{
		public CrmBankingBanks bank;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass9_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

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

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineBankingBank")]
	public ActionResult Index()
	{
		return View();
	}

	public List<CRMspSelectBankingBanks_Result> ListBankingBank()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectBankingBanks_Result> list = new List<CRMspSelectBankingBanks_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectBankingBanks_Result>((IEnumerable<CRMspSelectBankingBanks_Result>)_dbI.CRMspSelectBankingBanks(lCID, result));
			foreach (CRMspSelectBankingBanks_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				item.FirstRegisterUser = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				string text4 = (item.RegisterDate.HasValue ? item.RegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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
	public ActionResult BankingBank_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListBankingBank()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListBankingBank()
	{
		return Json(ListBankingBank(), JsonRequestBehavior.AllowGet);
	}

	public ActionResult InsertEdit(int bankId = 0)
	{
		_003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_0();
		CS_0024_003C_003E8__locals0.bankId = bankId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmBankingBanksLanguageViewModel model = new CrmBankingBanksLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmBankingBanks_Lang> crmBankingBanks_Lang = _dbTbl.CrmBankingBanks_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmBankingBanks_Lang), "c");
			List<CrmBankingBanks_Lang> list = Enumerable.ToList<CrmBankingBanks_Lang>((IEnumerable<CrmBankingBanks_Lang>)Queryable.Where<CrmBankingBanks_Lang>((IQueryable<CrmBankingBanks_Lang>)crmBankingBanks_Lang, Expression.Lambda<Func<CrmBankingBanks_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			CrmBankingBanks crmBankingBanks = new CrmBankingBanks();
			if (CS_0024_003C_003E8__locals0.bankId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmBankingBanks = new CrmBankingBanks();
				crmBankingBanks.BankingBankID = 0;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmBankingBanks> crmBankingBanks2 = _dbTbl.CrmBankingBanks;
				val = Expression.Parameter(typeof(CrmBankingBanks), "m");
				crmBankingBanks = Queryable.FirstOrDefault<CrmBankingBanks>((IQueryable<CrmBankingBanks>)crmBankingBanks2, Expression.Lambda<Func<CrmBankingBanks, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmBankingBanks == null)
				{
					crmBankingBanks = new CrmBankingBanks();
					crmBankingBanks.BankingBankID = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingBanks_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingBanks_Lang>)list, (Func<CrmBankingBanks_Lang, CommonMultiLanguageViewModel>)((CrmBankingBanks_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.BankName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingBanks.BankName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingBanks_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingBanks_Lang>)list, (Func<CrmBankingBanks_Lang, CommonMultiLanguageViewModel>)((CrmBankingBanks_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.BankDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingBanks.BankDesc,
				LanguageId = result
			});
			model = new CrmBankingBanksLanguageViewModel
			{
				BankingBankID = crmBankingBanks.BankingBankID,
				Code = crmBankingBanks.Code,
				BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				BankName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				BankDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				BankDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult InsertEdit(CrmBankingBanksLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BankName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.BankName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BankDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BankDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.BankDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.BankName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.BankingBankName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.BankName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.BankingBankName) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass9_1 _003C_003Ec__DisplayClass9_ = new _003C_003Ec__DisplayClass9_1();
					_003C_003Ec__DisplayClass9_.bank = new CrmBankingBanks();
					if (CS_0024_003C_003E8__locals0.model.BankingBankID > 0)
					{
						DbSet<CrmBankingBanks> crmBankingBanks = _dbTbl.CrmBankingBanks;
						ParameterExpression val = Expression.Parameter(typeof(CrmBankingBanks), "m");
						_003C_003Ec__DisplayClass9_.bank = Queryable.FirstOrDefault<CrmBankingBanks>((IQueryable<CrmBankingBanks>)crmBankingBanks, Expression.Lambda<Func<CrmBankingBanks, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime value = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass9_.bank.UserId = userId;
					_003C_003Ec__DisplayClass9_.bank.RegisterDate = value;
					_003C_003Ec__DisplayClass9_.bank.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass9_.bank.Month1 = value2;
					_003C_003Ec__DisplayClass9_.bank.Year1 = value3;
					_003C_003Ec__DisplayClass9_.bank.AppType = appType;
					_003C_003Ec__DisplayClass9_.bank.Code = CS_0024_003C_003E8__locals0.model.Code;
					_003C_003Ec__DisplayClass9_.bank.BankName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass9_.bank.BankDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (CS_0024_003C_003E8__locals0.model.BankingBankID > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass9_.bank).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass9_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass9_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass9_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmBankingBanks_Lang> crmBankingBanks_Lang = _dbTbl.CrmBankingBanks_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmBankingBanks_Lang), "c");
								CrmBankingBanks_Lang crmBankingBanks_Lang2 = Queryable.FirstOrDefault<CrmBankingBanks_Lang>((IQueryable<CrmBankingBanks_Lang>)crmBankingBanks_Lang, Expression.Lambda<Func<CrmBankingBanks_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass9_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmBankingBanks_Lang2 != null)
								{
									crmBankingBanks_Lang2.BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmBankingBanks_Lang2.BankDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmBankingBanks_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmBankingBanks_Lang2 = new CrmBankingBanks_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									BankingBankID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.bank.BankingBankID,
									BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									BankDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingBanks_Lang.Add(crmBankingBanks_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBanks");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass9_.bank.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass9_.bank.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass9_.bank.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass9_.bank.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass9_.bank.GUId = Guid.NewGuid();
						_dbTbl.CrmBankingBanks.Add(_003C_003Ec__DisplayClass9_.bank);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass9_.bank.BankingBankID > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmBankingBanks_Lang entity = new CrmBankingBanks_Lang
								{
									LanguageID = lang.LanguageID,
									BankingBankID = _003C_003Ec__DisplayClass9_.bank.BankingBankID,
									BankName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									BankDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingBanks_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBanks");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActDelete(int bankId)
	{
		string text = "";
		try
		{
			if (bankId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteBankingBanks(bankId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				if (result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBanks");
					return "1";
				}
				return Messages.RedundancyMessage;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineBankingBranch")]
	public ActionResult Branch(int bankId = 0)
	{
		base.ViewBag.BankId = bankId;
		return View();
	}

	public List<CRMspSelectBankingBranches_Result> ListBankingBranch(int bankId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectBankingBranches_Result> list = new List<CRMspSelectBankingBranches_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectBankingBranches_Result>((IEnumerable<CRMspSelectBankingBranches_Result>)_dbI.CRMspSelectBankingBranches(bankId, lCID, result));
			foreach (CRMspSelectBankingBranches_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
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
	public ActionResult BankingBranch_Read([DataSourceRequest] DataSourceRequest request, int bankId = 0)
	{
		return Json(((IEnumerable)ListBankingBranch(bankId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListBankingBranch(int bankId = 0)
	{
		return Json(ListBankingBranch(bankId), JsonRequestBehavior.AllowGet);
	}

	public ActionResult BranchInsertEdit(int bankId, int bankingBranchId = 0)
	{
		_003C_003Ec__DisplayClass15_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass15_0();
		CS_0024_003C_003E8__locals0.bankingBranchId = bankingBranchId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmBankingBranchesLanguageViewModel model = new CrmBankingBranchesLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmBankingBranches_Lang> crmBankingBranches_Lang = _dbTbl.CrmBankingBranches_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmBankingBranches_Lang), "c");
			List<CrmBankingBranches_Lang> list = Enumerable.ToList<CrmBankingBranches_Lang>((IEnumerable<CrmBankingBranches_Lang>)Queryable.Where<CrmBankingBranches_Lang>((IQueryable<CrmBankingBranches_Lang>)crmBankingBranches_Lang, Expression.Lambda<Func<CrmBankingBranches_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			CrmBankingBranches crmBankingBranches = new CrmBankingBranches();
			if (CS_0024_003C_003E8__locals0.bankingBranchId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmBankingBranches = new CrmBankingBranches();
				crmBankingBranches.BankingBranchID = 0;
				crmBankingBranches.BankId = bankId;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actEdit", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmBankingBranches> crmBankingBranches2 = _dbTbl.CrmBankingBranches;
				val = Expression.Parameter(typeof(CrmBankingBranches), "m");
				crmBankingBranches = Queryable.FirstOrDefault<CrmBankingBranches>((IQueryable<CrmBankingBranches>)crmBankingBranches2, Expression.Lambda<Func<CrmBankingBranches, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass15_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmBankingBranches == null)
				{
					crmBankingBranches = new CrmBankingBranches();
					crmBankingBranches.BankingBranchID = 0;
					crmBankingBranches.BankId = bankId;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingBranches_Lang>)list, (Func<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>)((CrmBankingBranches_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.BranchName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingBranches.BranchName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingBranches_Lang>)list, (Func<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>)((CrmBankingBranches_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.BranchAddress,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingBranches.BranchAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingBranches_Lang>)list, (Func<CrmBankingBranches_Lang, CommonMultiLanguageViewModel>)((CrmBankingBranches_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.BranchDesc,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingBranches.BranchDesc,
				LanguageId = result
			});
			model = new CrmBankingBranchesLanguageViewModel
			{
				BankingBranchID = crmBankingBranches.BankingBranchID,
				BankId = crmBankingBranches.BankId,
				BranchCode = crmBankingBranches.BranchCode,
				BranchTel = crmBankingBranches.BranchTel,
				BranchTelII = crmBankingBranches.BranchTelII,
				BranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				BranchName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				BranchAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				BranchAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				BranchDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				BranchDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult BranchInsertEdit(CrmBankingBranchesLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		//IL_012f: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass16_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass16_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BranchName_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BranchName_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.BranchName,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BranchAddress_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BranchAddress_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.BranchAddress,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.BranchDesc_Lang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.BranchDesc_Lang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.BranchDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.BranchName))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.BankingBranchName) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.BranchName, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.BankingBranchName) + "<br>";
				num++;
			}
			if (CS_0024_003C_003E8__locals0.model.BankId == 0)
			{
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.BankingBranchBankId) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass16_1 _003C_003Ec__DisplayClass16_ = new _003C_003Ec__DisplayClass16_1();
					_003C_003Ec__DisplayClass16_.branch = new CrmBankingBranches();
					if (CS_0024_003C_003E8__locals0.model.BankingBranchID > 0)
					{
						DbSet<CrmBankingBranches> crmBankingBranches = _dbTbl.CrmBankingBranches;
						ParameterExpression val = Expression.Parameter(typeof(CrmBankingBranches), "m");
						_003C_003Ec__DisplayClass16_.branch = Queryable.FirstOrDefault<CrmBankingBranches>((IQueryable<CrmBankingBranches>)crmBankingBranches, Expression.Lambda<Func<CrmBankingBranches, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass16_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime registerDate = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass16_.branch.UserId = userId;
					_003C_003Ec__DisplayClass16_.branch.RegisterDate = registerDate;
					_003C_003Ec__DisplayClass16_.branch.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass16_.branch.Month1 = month;
					_003C_003Ec__DisplayClass16_.branch.Year1 = year;
					_003C_003Ec__DisplayClass16_.branch.AppType = appType;
					_003C_003Ec__DisplayClass16_.branch.BankId = CS_0024_003C_003E8__locals0.model.BankId;
					_003C_003Ec__DisplayClass16_.branch.BranchCode = CS_0024_003C_003E8__locals0.model.BranchCode;
					_003C_003Ec__DisplayClass16_.branch.BranchTel = CS_0024_003C_003E8__locals0.model.BranchTel;
					_003C_003Ec__DisplayClass16_.branch.BranchTelII = CS_0024_003C_003E8__locals0.model.BranchTelII;
					_003C_003Ec__DisplayClass16_.branch.BranchName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass16_.branch.BranchAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass16_.branch.BranchDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (CS_0024_003C_003E8__locals0.model.BankingBranchID > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass16_.branch).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass16_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass16_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass16_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmBankingBranches_Lang> crmBankingBranches_Lang = _dbTbl.CrmBankingBranches_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmBankingBranches_Lang), "c");
								CrmBankingBranches_Lang crmBankingBranches_Lang2 = Queryable.FirstOrDefault<CrmBankingBranches_Lang>((IQueryable<CrmBankingBranches_Lang>)crmBankingBranches_Lang, Expression.Lambda<Func<CrmBankingBranches_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass16_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmBankingBranches_Lang2 != null)
								{
									crmBankingBranches_Lang2.BranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmBankingBranches_Lang2.BranchAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmBankingBranches_Lang2.BranchDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmBankingBranches_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmBankingBranches_Lang2 = new CrmBankingBranches_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									BankingBranchID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.branch.BankingBranchID,
									BranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									BranchAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									BranchDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingBranches_Lang.Add(crmBankingBranches_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBranches");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass16_.branch.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass16_.branch.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass16_.branch.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass16_.branch.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass16_.branch.GUId = Guid.NewGuid();
						_dbTbl.CrmBankingBranches.Add(_003C_003Ec__DisplayClass16_.branch);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass16_.branch.BankingBranchID > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmBankingBranches_Lang entity = new CrmBankingBranches_Lang
								{
									LanguageID = lang.LanguageID,
									BankingBranchID = _003C_003Ec__DisplayClass16_.branch.BankingBranchID,
									BranchName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									BranchAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									BranchDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingBranches_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBranches");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActBranchDelete(int bankingBranchId)
	{
		string text = "";
		try
		{
			if (bankingBranchId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteBankingBranches(bankingBranchId));
				int result = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result);
				}
				if (result > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingBranches");
					return "1";
				}
				return Messages.RedundancyMessage;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.frmErrorMessage;
		}
	}

	[AjaxOnly]
	public JsonResult GetBankingBankLists()
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
			List<CRMspSelectBankingBanks_Result> list2 = Enumerable.ToList<CRMspSelectBankingBanks_Result>((IEnumerable<CRMspSelectBankingBanks_Result>)_dbI.CRMspSelectBankingBanks(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0"
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingBanks_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBanks_Result>)list2, (Func<CRMspSelectBankingBanks_Result, SelectListItem>)((CRMspSelectBankingBanks_Result item) => new SelectListItem
			{
				Text = (item.BankName ?? ""),
				Value = item.BankingBankID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineBankingAccount")]
	public ActionResult Accounts(int bankId = 0, int branchId = 0)
	{
		base.ViewBag.BankId = bankId;
		base.ViewBag.BranchId = branchId;
		return View();
	}

	public List<CRMspSelectBankingAccountsByBranchAndUserId_Result> ListBankingAccounts(int branchId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectBankingAccountsByBranchAndUserId_Result> list = new List<CRMspSelectBankingAccountsByBranchAndUserId_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)_dbII.CRMspSelectBankingAccountsByBranchAndUserId(branchId, 0, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectBankingAccountsByBranchAndUserId_Result>((IEnumerable<CRMspSelectBankingAccountsByBranchAndUserId_Result>)list))
			{
				foreach (CRMspSelectBankingAccountsByBranchAndUserId_Result item in list)
				{
					if (string.IsNullOrEmpty(item.AppType))
					{
						item.AppType = Configuration.AppType;
					}
					item.AppType = Configuration.GetAppType(item.AppType);
					string text = item.FirstRegisterUser ?? "";
					string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					item.FirstRegisterUser = text + " (" + text2 + ")";
					string text3 = item.EditUser ?? "";
					_ = item.RegisterDate;
					string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					item.EditUser = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				}
			}
			else
			{
				list = new List<CRMspSelectBankingAccountsByBranchAndUserId_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult BankingAccounts_Read([DataSourceRequest] DataSourceRequest request, int branchId = 0)
	{
		return Json(((IEnumerable)ListBankingAccounts(branchId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult GetListBankingAccounts(int branchId = 0)
	{
		return Json(ListBankingAccounts(branchId), JsonRequestBehavior.AllowGet);
	}

	public ActionResult AccountsInsertEdit(int bankId, int branchId, int bankingAccountId = 0)
	{
		_003C_003Ec__DisplayClass23_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass23_0();
		CS_0024_003C_003E8__locals0.bankingAccountId = bankingAccountId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmBankingAccountsLanguageViewModel model = new CrmBankingAccountsLanguageViewModel();
		_ = DateTime.Now;
		try
		{
			DbSet<CrmBankingAccounts_Lang> crmBankingAccounts_Lang = _dbTbl.CrmBankingAccounts_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts_Lang), "c");
			List<CrmBankingAccounts_Lang> list = Enumerable.ToList<CrmBankingAccounts_Lang>((IEnumerable<CrmBankingAccounts_Lang>)Queryable.Where<CrmBankingAccounts_Lang>((IQueryable<CrmBankingAccounts_Lang>)crmBankingAccounts_Lang, Expression.Lambda<Func<CrmBankingAccounts_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass23_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			CrmBankingAccounts crmBankingAccounts = new CrmBankingAccounts();
			if (CS_0024_003C_003E8__locals0.bankingAccountId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmBankingAccounts = new CrmBankingAccounts();
				crmBankingAccounts.BankingAccountID = 0;
				crmBankingAccounts.BankId = bankId;
				crmBankingAccounts.BranchId = branchId;
			}
			else
			{
				if (!UserLogin.IsUserAccess("frmMain", "actDefineUsers", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				DbSet<CrmBankingAccounts> crmBankingAccounts2 = _dbTbl.CrmBankingAccounts;
				val = Expression.Parameter(typeof(CrmBankingAccounts), "m");
				crmBankingAccounts = Queryable.FirstOrDefault<CrmBankingAccounts>((IQueryable<CrmBankingAccounts>)crmBankingAccounts2, Expression.Lambda<Func<CrmBankingAccounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass23_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmBankingAccounts == null)
				{
					crmBankingAccounts = new CrmBankingAccounts();
					crmBankingAccounts.BankingAccountID = 0;
					crmBankingAccounts.BankId = bankId;
					crmBankingAccounts.BranchId = branchId;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingAccounts_Lang>)list, (Func<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>)((CrmBankingAccounts_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.AccountTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingAccounts.AccountTitle,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmBankingAccounts_Lang>)list, (Func<CrmBankingAccounts_Lang, CommonMultiLanguageViewModel>)((CrmBankingAccounts_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.AccountDesc,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmBankingAccounts.AccountDesc,
				LanguageId = result
			});
			model = new CrmBankingAccountsLanguageViewModel
			{
				BankingAccountID = crmBankingAccounts.BankingAccountID,
				BranchId = crmBankingAccounts.BranchId,
				MasterId = crmBankingAccounts.MasterId,
				AccTypeId = crmBankingAccounts.AccTypeId,
				AccountNumber = crmBankingAccounts.AccountNumber,
				AccountType = crmBankingAccounts.AccountType,
				AccountOwner = crmBankingAccounts.AccountOwner,
				CrmUserId = crmBankingAccounts.CrmUserId,
				BankId = crmBankingAccounts.BankId,
				AccountShabaNumber = crmBankingAccounts.AccountShabaNumber,
				AccountCardNumber = crmBankingAccounts.AccountCardNumber,
				IsDefault = crmBankingAccounts.IsDefault,
				IsDefaultII = crmBankingAccounts.IsDefaultII,
				AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				AccountTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				AccountDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				MobHRMVisible = crmBankingAccounts.MobHRMVisible
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[ValidateAntiForgeryToken]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfoIDataEntry", ActionName = "actPost")]
	public ActionResult AccountsInsertEdit(CrmBankingAccountsLanguageViewModel model)
	{
		//IL_0087: Unknown result type (might be due to invalid IL or missing references)
		//IL_00db: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass24_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass24_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.AccountTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.AccountTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.AccountTitle,
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.AccountDesc_Lang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.AccountDesc_Lang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.AccountDesc,
				LanguageId = lCID
			});
			if (string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals0.model.AccountTitle))
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.BankingAccountTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.AccountTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.BankingAccountTitle) + "<br>";
				num++;
			}
			bool result = false;
			bool.TryParse(CS_0024_003C_003E8__locals0.model.IsDefault.ToString(), out result);
			if (result)
			{
				CRMspSelectUserBankingAccountIsDefault_Result cRMspSelectUserBankingAccountIsDefault_Result = Enumerable.FirstOrDefault<CRMspSelectUserBankingAccountIsDefault_Result>((IEnumerable<CRMspSelectUserBankingAccountIsDefault_Result>)_dbI.CRMspSelectUserBankingAccountIsDefault(CS_0024_003C_003E8__locals0.model.CrmUserId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectUserBankingAccountIsDefault_Result != null && cRMspSelectUserBankingAccountIsDefault_Result.BankingAccountID != CS_0024_003C_003E8__locals0.model.BankingAccountID)
				{
					string arg = cRMspSelectUserBankingAccountIsDefault_Result.AccountTitle ?? "";
					text = text + string.Format(Messages.msgErrorBankAccIsDefault, arg) + "<br>";
					num++;
				}
			}
			bool result2 = false;
			bool.TryParse(CS_0024_003C_003E8__locals0.model.IsDefaultII.ToString(), out result2);
			if (result2)
			{
				CRMspSelectUserBankingAccountIsDefaultII_Result cRMspSelectUserBankingAccountIsDefaultII_Result = Enumerable.FirstOrDefault<CRMspSelectUserBankingAccountIsDefaultII_Result>((IEnumerable<CRMspSelectUserBankingAccountIsDefaultII_Result>)_dbI.CRMspSelectUserBankingAccountIsDefaultII(CS_0024_003C_003E8__locals0.model.CrmUserId, lCID, CS_0024_003C_003E8__locals0.defLangID));
				if (cRMspSelectUserBankingAccountIsDefaultII_Result != null && cRMspSelectUserBankingAccountIsDefaultII_Result.BankingAccountID != CS_0024_003C_003E8__locals0.model.BankingAccountID)
				{
					string arg2 = cRMspSelectUserBankingAccountIsDefaultII_Result.AccountTitle ?? "";
					text = text + string.Format(Messages.msgErrorBankAccIsDefaultII, arg2) + "<br>";
					num++;
				}
			}
			if (CS_0024_003C_003E8__locals0.model.BranchId == 0)
			{
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.BankingAccountBranch) + "<br>";
				num++;
			}
			if (CS_0024_003C_003E8__locals0.model.AccTypeId == 0)
			{
				text = text + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.BankingAccountType) + "<br>";
				num++;
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					_003C_003Ec__DisplayClass24_1 _003C_003Ec__DisplayClass24_ = new _003C_003Ec__DisplayClass24_1();
					_003C_003Ec__DisplayClass24_.bankAcc = new CrmBankingAccounts();
					if (CS_0024_003C_003E8__locals0.model.BankingAccountID > 0)
					{
						DbSet<CrmBankingAccounts> crmBankingAccounts = _dbTbl.CrmBankingAccounts;
						ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts), "m");
						_003C_003Ec__DisplayClass24_.bankAcc = Queryable.FirstOrDefault<CrmBankingAccounts>((IQueryable<CrmBankingAccounts>)crmBankingAccounts, Expression.Lambda<Func<CrmBankingAccounts, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass24_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					}
					DateTime now2 = DateTime.Now;
					DateTime registerDate = now2;
					string registerDatePersian = now2.ToString("yyyyMMdd", new PersianCulture());
					short month = short.Parse(now2.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					_ = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					short year = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass24_.bankAcc.UserId = userId;
					_003C_003Ec__DisplayClass24_.bankAcc.RegisterDate = registerDate;
					_003C_003Ec__DisplayClass24_.bankAcc.RegisterDatePersian = registerDatePersian;
					_003C_003Ec__DisplayClass24_.bankAcc.Month1 = month;
					_003C_003Ec__DisplayClass24_.bankAcc.Year1 = year;
					_003C_003Ec__DisplayClass24_.bankAcc.AppType = appType;
					_003C_003Ec__DisplayClass24_.bankAcc.BranchId = CS_0024_003C_003E8__locals0.model.BranchId;
					_003C_003Ec__DisplayClass24_.bankAcc.MasterId = CS_0024_003C_003E8__locals0.model.MasterId;
					_003C_003Ec__DisplayClass24_.bankAcc.AccTypeId = CS_0024_003C_003E8__locals0.model.AccTypeId;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountNumber = CS_0024_003C_003E8__locals0.model.AccountNumber;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountType = CS_0024_003C_003E8__locals0.model.AccountType;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountOwner = CS_0024_003C_003E8__locals0.model.AccountOwner;
					_003C_003Ec__DisplayClass24_.bankAcc.CrmUserId = CS_0024_003C_003E8__locals0.model.CrmUserId;
					_003C_003Ec__DisplayClass24_.bankAcc.BankId = CS_0024_003C_003E8__locals0.model.BankId;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountShabaNumber = CS_0024_003C_003E8__locals0.model.AccountShabaNumber;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountCardNumber = CS_0024_003C_003E8__locals0.model.AccountCardNumber;
					_003C_003Ec__DisplayClass24_.bankAcc.IsDefault = CS_0024_003C_003E8__locals0.model.IsDefault;
					_003C_003Ec__DisplayClass24_.bankAcc.IsDefaultII = CS_0024_003C_003E8__locals0.model.IsDefaultII;
					_003C_003Ec__DisplayClass24_.bankAcc.AccountTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass24_.bankAcc.AccountDesc = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass24_.bankAcc.MobHRMVisible = CS_0024_003C_003E8__locals0.model.MobHRMVisible;
					if (CS_0024_003C_003E8__locals0.model.BankingAccountID > 0)
					{
						_dbTbl.Entry(_003C_003Ec__DisplayClass24_.bankAcc).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass24_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass24_2();
								CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass24_;
								CS_0024_003C_003E8__locals1.lang = enumerator.Current;
								DbSet<CrmBankingAccounts_Lang> crmBankingAccounts_Lang = _dbTbl.CrmBankingAccounts_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmBankingAccounts_Lang), "c");
								CrmBankingAccounts_Lang crmBankingAccounts_Lang2 = Queryable.FirstOrDefault<CrmBankingAccounts_Lang>((IQueryable<CrmBankingAccounts_Lang>)crmBankingAccounts_Lang, Expression.Lambda<Func<CrmBankingAccounts_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass24_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass24_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmBankingAccounts_Lang2 != null)
								{
									crmBankingAccounts_Lang2.AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									crmBankingAccounts_Lang2.AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmBankingAccounts_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								crmBankingAccounts_Lang2 = new CrmBankingAccounts_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
									BankingAccountID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.bankAcc.BankingAccountID,
									AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
									AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingAccounts_Lang.Add(crmBankingAccounts_Lang2);
								_dbTbl.SaveChanges();
							}
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
						base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
					}
					else
					{
						_003C_003Ec__DisplayClass24_.bankAcc.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						_003C_003Ec__DisplayClass24_.bankAcc.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass24_.bankAcc.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass24_.bankAcc.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass24_.bankAcc.GUId = Guid.NewGuid();
						_dbTbl.CrmBankingAccounts.Add(_003C_003Ec__DisplayClass24_.bankAcc);
						_dbTbl.SaveChanges();
						if (_003C_003Ec__DisplayClass24_.bankAcc.BankingAccountID > 0)
						{
							foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
							{
								CrmBankingAccounts_Lang entity = new CrmBankingAccounts_Lang
								{
									LanguageID = lang.LanguageID,
									BankingAccountID = _003C_003Ec__DisplayClass24_.bankAcc.BankingAccountID,
									AccountTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null),
									AccountDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
								};
								_dbTbl.CrmBankingAccounts_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						CS_0024_003C_003E8__locals0.model.BankingAccountID = _003C_003Ec__DisplayClass24_.bankAcc.BankingAccountID;
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Messages.msgErrorRunFunction;
				}
			}
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActAccountsDelete(int bankingAccountId)
	{
		string result = "";
		try
		{
			if (bankingAccountId > 0)
			{
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.CRMspDeleteBankingAccounts(bankingAccountId));
				int result2 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
				}
				if (result2 > 0)
				{
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmBankingAccounts");
					result = "1";
				}
				else if (result2 == 0)
				{
					result = Messages.RedundancyMessage;
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetBankingBrancheLists(int bankId)
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
			List<CRMspSelectBankingBranches_Result> list2 = Enumerable.ToList<CRMspSelectBankingBranches_Result>((IEnumerable<CRMspSelectBankingBranches_Result>)_dbI.CRMspSelectBankingBranches(bankId, lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0"
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingBranches_Result, SelectListItem>((IEnumerable<CRMspSelectBankingBranches_Result>)list2, (Func<CRMspSelectBankingBranches_Result, SelectListItem>)((CRMspSelectBankingBranches_Result item) => new SelectListItem
			{
				Text = (item.BranchName ?? ""),
				Value = item.BankingBranchID.ToString(),
				Selected = false
			})));
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
	public JsonResult GetBankingAccountTypeLists()
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
			List<CRMspSelectBankingAccountType_Result> list2 = Enumerable.ToList<CRMspSelectBankingAccountType_Result>((IEnumerable<CRMspSelectBankingAccountType_Result>)_dbI.CRMspSelectBankingAccountType(lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0"
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<CRMspSelectBankingAccountType_Result, SelectListItem>((IEnumerable<CRMspSelectBankingAccountType_Result>)list2, (Func<CRMspSelectBankingAccountType_Result, SelectListItem>)((CRMspSelectBankingAccountType_Result item) => new SelectListItem
			{
				Text = (item.AccountType ?? ""),
				Value = item.BankingAccountTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
