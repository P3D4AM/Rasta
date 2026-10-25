using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
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
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Cache.User;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class IssueOrderController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass17_0
	{
		public int Id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_0
	{
		public int id;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__7;

		internal bool _003CEditProjectTitle_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditProjectTitle_003Eb__7(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_1
	{
		public CrmProjects project;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass20_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass20_1 CS_0024_003C_003E8__locals1;

		internal bool _003CEditProjectTitle_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditProjectTitle_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_0
	{
		public int pordId;

		public int currLangID;

		internal bool _003CGetProjectTitleLang_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CGetProjectTitleLang_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass22_1
	{
		public CRMspSelectCrmProjectsById_Result prj;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass26_1
	{
		public CRMspSelectCrmProjectsById_Result currItem;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public CRMspSelectCompanyById_Result company;

		public int currLangID;

		internal bool _003CIndex_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CIndex_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public CmpInfoViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CIndex_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CIndex_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public CrmCompany cmp;

		public _003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public int idGrp;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals2;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals3;

		internal bool _003CIndex_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CIndex_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_0
	{
		public CmpInfoViewModel model;

		public int defLangID;

		public int currLangID;

		public Func<Languages, bool> _003C_003E9__5;

		internal bool _003CEditCompanyInfo_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditCompanyInfo_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CEditCompanyInfo_003Eb__5(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CEditCompanyInfo_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditCompanyInfo_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CEditCompanyInfo_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_1
	{
		public CrmCompany cmp;

		public CRMspSelectCompanyById_Result company;

		public _003C_003Ec__DisplayClass8_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_2
	{
		public int idGrp;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals2;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass8_3
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass8_1 CS_0024_003C_003E8__locals3;

		internal bool _003CEditCompanyInfo_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCompanyInfo_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCompanyInfo_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CEditCompanyInfo_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actIssueOrder")]
	public ActionResult Index(int cmpId, string cmpName, int pordId)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		if (result2 == 1)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		}
		FillDropdownIssueOrder();
		GetOrdDefSetting();
		GetOrdSetPementType();
		CompanyFullcombo(cmpId);
		GetProjectTitleLang(pordId);
		GetPrdOrdIssueSetting(pordId);
		GetPrdIssueOrdFromIndexed(pordId);
		CmpInfoViewModel model = new CmpInfoViewModel();
		CS_0024_003C_003E8__locals0.company = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
		if (CS_0024_003C_003E8__locals0.company != null)
		{
			string text = "|";
			List<CRMspSelectCompanyGroupsMulti_Result> list = Enumerable.ToList<CRMspSelectCompanyGroupsMulti_Result>((IEnumerable<CRMspSelectCompanyGroupsMulti_Result>)_db.CRMspSelectCompanyGroupsMulti(CS_0024_003C_003E8__locals0.currLangID, result));
			List<CommonDroupDownItemViewModel> list2 = new List<CommonDroupDownItemViewModel>();
			foreach (CRMspSelectCompanyGroupsMulti_Result item in list)
			{
				CommonDroupDownItemViewModel commonDroupDownItemViewModel = new CommonDroupDownItemViewModel
				{
					Text = item.CompanyGroupsMultiName,
					Value = item.CompanyGroupsMultiID.ToString(),
					Tag = false
				};
				if (Enumerable.FirstOrDefault<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)Enumerable.ToList<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)_db.CRMspCompanyCheckHaveMultiGroup(cmpId, item.CompanyGroupsMultiID))) != null)
				{
					commonDroupDownItemViewModel.Tag = true;
					text = text + "+" + commonDroupDownItemViewModel.Value + "|";
				}
				else
				{
					text = text + "-" + commonDroupDownItemViewModel.Value + "|";
				}
				list2.Add(commonDroupDownItemViewModel);
			}
			base.ViewBag.MultiGroups = list2;
			DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
			List<CrmCompany_Lang> list3 = Enumerable.ToList<CrmCompany_Lang>((IEnumerable<CrmCompany_Lang>)Queryable.Where<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
			val = Expression.Parameter(typeof(CrmCompany), "c");
			CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list3, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.cmpAddress,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = ((crmCompany2 != null) ? crmCompany2.cmpAddress : ""),
				LanguageId = result
			});
			model = new CmpInfoViewModel
			{
				pordId = pordId,
				CompanyID = CS_0024_003C_003E8__locals0.company.CompanyID,
				cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				cmpAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				cmpEconomicCode = CS_0024_003C_003E8__locals0.company.cmpEconomicCode,
				cmpGroupId = CS_0024_003C_003E8__locals0.company.cmpGroupId,
				cmpGroupIdII = CS_0024_003C_003E8__locals0.company.cmpGroupIdII,
				cmpGroupIdIII = CS_0024_003C_003E8__locals0.company.cmpGroupIdIII,
				cmpGroupIdIV = CS_0024_003C_003E8__locals0.company.cmpGroupIdIV,
				cmpName = CS_0024_003C_003E8__locals0.company.cmpName,
				cmpNationalCode = CS_0024_003C_003E8__locals0.company.cmpNationalCode,
				cmpRegistrationNumber = CS_0024_003C_003E8__locals0.company.cmpRegistrationNumber,
				cmpSubGroupId = CS_0024_003C_003E8__locals0.company.cmpSubGroupId,
				cmpTypeId = CS_0024_003C_003E8__locals0.company.cmpTypeId,
				cmpZipCode = CS_0024_003C_003E8__locals0.company.cmpZipCode,
				cmpEffectiveDatePersian = (CS_0024_003C_003E8__locals0.company.cmpEffectiveDateTime.HasValue ? CS_0024_003C_003E8__locals0.company.cmpEffectiveDateTime.Value.ToString("yyyy/MM/dd") : ""),
				MultiGroups = text
			};
		}
		base.ViewBag.IsBuying = VersionBuyer.Order;
		base.ViewBag.PreOrderFilesCount = SelectFilesDirectory(pordId).Count;
		bool haveOrd = false;
		bool flag = Order.CheckLastCompanyOrderHaveTax(cmpId, ref haveOrd);
		base.ViewBag.Taxable = flag;
		int num = 0;
		int num2 = 0;
		decimal num3 = default(decimal);
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
		if (cRMspSelectCrmsysSetting_Result2 != null)
		{
			try
			{
				string karaAfzarLockSerial = Configuration.KaraAfzarLockSerial;
				string text2 = cRMspSelectCrmsysSetting_Result2.LockSerial ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && text2 == karaAfzarLockSerial)
				{
					WSspSelectOrderItemsByPordIdAndManufacturerName_Result wSspSelectOrderItemsByPordIdAndManufacturerName_Result = Order.KaraAfzarGetChargeSmsOrdItem(pordId);
					if (wSspSelectOrderItemsByPordIdAndManufacturerName_Result != null)
					{
						num = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderId;
						num2 = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderItemID;
						num3 = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIPriceSum.GetValueOrDefault();
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		base.ViewBag.KaraAfzar_SmsPanelOrdId = num;
		base.ViewBag.KaraAfzar_SmsPanelOrdItemId = num2;
		base.ViewBag.KaraAfzar_SmsPanelOrdItemPriceSum = num3;
		return View(model);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmIssueOrderFromPreOrder", ActionName = "actCanChangeCompanyInfo")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(CmpInfoViewModel model)
	{
		//IL_0122: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out _003C_003Ec__DisplayClass7_.defLangID);
		if (_003C_003Ec__DisplayClass7_.defLangID <= 0)
		{
			_003C_003Ec__DisplayClass7_.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		if (result == 1)
		{
			base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		}
		try
		{
			if (base.ModelState.IsValid)
			{
				_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_2 = new _003C_003Ec__DisplayClass7_1();
				_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpAddress_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpAddress_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpAddress,
					LanguageId = lCID
				});
				DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
				ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "c");
				_003C_003Ec__DisplayClass7_2.cmp = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_2, typeof(_003C_003Ec__DisplayClass7_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (_003C_003Ec__DisplayClass7_2.cmp == null)
				{
					base.ViewBag.Error = Messages.ErrorNotFound;
				}
				else
				{
					int countError = 0;
					string text = CRMIdeal.Classes.Helper.Company.ChkBeforeSubmitCompany(_003C_003Ec__DisplayClass7_2.cmp, ref countError);
					if (countError > 0)
					{
						base.ViewBag.Error = text;
					}
					else
					{
						_003C_003Ec__DisplayClass7_2.cmp.UserId = UserLogin.CurrentUser.UserId;
						DateTime now = DateTime.Now;
						_003C_003Ec__DisplayClass7_2.cmp.RegisterDate = now;
						_003C_003Ec__DisplayClass7_2.cmp.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass7_2.cmp.Year1 = short.Parse(Financial.Get().Id.ToString());
						_003C_003Ec__DisplayClass7_2.cmp.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass7_2.cmp.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass7_2.cmp.cmpAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.defLangID)).Value : null);
						_003C_003Ec__DisplayClass7_2.cmp.cmpEconomicCode = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpEconomicCode;
						_003C_003Ec__DisplayClass7_2.cmp.cmpGroupId = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpGroupId;
						_003C_003Ec__DisplayClass7_2.cmp.cmpGroupIdII = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdII;
						_003C_003Ec__DisplayClass7_2.cmp.cmpGroupIdIII = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdIII;
						_003C_003Ec__DisplayClass7_2.cmp.cmpGroupIdIV = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdIV;
						_003C_003Ec__DisplayClass7_2.cmp.cmpNationalCode = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpNationalCode;
						_003C_003Ec__DisplayClass7_2.cmp.cmpRegistrationNumber = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpRegistrationNumber;
						_003C_003Ec__DisplayClass7_2.cmp.cmpSubGroupId = ((_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpSubGroupId == 0) ? null : _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpSubGroupId);
						_003C_003Ec__DisplayClass7_2.cmp.cmpTypeId = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpTypeId;
						_003C_003Ec__DisplayClass7_2.cmp.cmpZipCode = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpZipCode;
						if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpEffectiveDatePersian))
						{
							DateTime dateTime = default(DateTime);
							string text2 = "";
							try
							{
								text2 = PersianDate.GetFormatetdDate(_003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.cmpEffectiveDatePersian.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									_003C_003Ec__DisplayClass7_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									_003C_003Ec__DisplayClass7_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									_003C_003Ec__DisplayClass7_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
								_003C_003Ec__DisplayClass7_2.cmp.cmpEffectiveDateTime = dateTime;
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								base.ViewBag.Error = Messages.ErrorFormatDatePersian;
							}
						}
						_dbTbl.Entry(_003C_003Ec__DisplayClass7_2.cmp).State = EntityState.Modified;
						string[] array = _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.model.MultiGroups.Split(new char[1] { '|' });
						foreach (string text3 in array)
						{
							if (!(text3 != ""))
							{
								continue;
							}
							_003C_003Ec__DisplayClass7_2 _003C_003Ec__DisplayClass7_3 = new _003C_003Ec__DisplayClass7_2();
							_003C_003Ec__DisplayClass7_3.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass7_2;
							string text4 = text3.Substring(0, 1);
							_003C_003Ec__DisplayClass7_3.idGrp = 0;
							string text5 = text3;
							text5 = text5.Substring(1, text5.Length - 1);
							int.TryParse(text5, out _003C_003Ec__DisplayClass7_3.idGrp);
							if (_003C_003Ec__DisplayClass7_3.idGrp <= 0)
							{
								continue;
							}
							if (text4 == "+")
							{
								DbSet<CrmCompanyMultiGroups> crmCompanyMultiGroups = _dbTbl.CrmCompanyMultiGroups;
								val = Expression.Parameter(typeof(CrmCompanyMultiGroups), "c");
								CrmCompanyMultiGroups crmCompanyMultiGroups2 = Queryable.FirstOrDefault<CrmCompanyMultiGroups>((IQueryable<CrmCompanyMultiGroups>)crmCompanyMultiGroups, Expression.Lambda<Func<CrmCompanyMultiGroups, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_3, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_3, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompanyMultiGroups2 == null)
								{
									crmCompanyMultiGroups2 = new CrmCompanyMultiGroups();
									crmCompanyMultiGroups2.CompanyID = _003C_003Ec__DisplayClass7_3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.CompanyID;
									crmCompanyMultiGroups2.CompanyGroupsMultiID = _003C_003Ec__DisplayClass7_3.idGrp;
									crmCompanyMultiGroups2.UserId = UserLogin.CurrentUser.UserId;
									crmCompanyMultiGroups2.Year1 = short.Parse(Financial.Get().Id.ToString());
									crmCompanyMultiGroups2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
									crmCompanyMultiGroups2.RegisterDate = DateTime.Now;
									crmCompanyMultiGroups2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									crmCompanyMultiGroups2.AppType = Configuration.AppType;
									crmCompanyMultiGroups2.GUId = Guid.NewGuid();
									crmCompanyMultiGroups2.FirstRegisterDate = DateTime.Now;
									crmCompanyMultiGroups2.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
									crmCompanyMultiGroups2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
									crmCompanyMultiGroups2.LanguageID = _003C_003Ec__DisplayClass7_3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.defLangID;
									_dbTbl.CrmCompanyMultiGroups.Add(crmCompanyMultiGroups2);
								}
							}
							else if (text4 == "-")
							{
								DbSet<CrmCompanyMultiGroups> crmCompanyMultiGroups3 = _dbTbl.CrmCompanyMultiGroups;
								val = Expression.Parameter(typeof(CrmCompanyMultiGroups), "c");
								CrmCompanyMultiGroups crmCompanyMultiGroups4 = Queryable.FirstOrDefault<CrmCompanyMultiGroups>((IQueryable<CrmCompanyMultiGroups>)crmCompanyMultiGroups3, Expression.Lambda<Func<CrmCompanyMultiGroups, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_3, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_3, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompanyMultiGroups4 != null)
								{
									_dbTbl.CrmCompanyMultiGroups.Remove(crmCompanyMultiGroups4);
								}
							}
						}
						_dbTbl.SaveChanges();
						using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != _003C_003Ec__DisplayClass7_2.CS_0024_003C_003E8__locals1.defLangID))).GetEnumerator())
						{
							while (enumerator.MoveNext())
							{
								_003C_003Ec__DisplayClass7_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_3();
								CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass7_2;
								CS_0024_003C_003E8__locals0.lang = enumerator.Current;
								DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
								val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
								CrmCompany_Lang crmCompany_Lang2 = Queryable.FirstOrDefault<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmCompany_Lang2 != null)
								{
									crmCompany_Lang2.cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
									_dbTbl.Entry(crmCompany_Lang2).State = EntityState.Modified;
									_dbTbl.SaveChanges();
									continue;
								}
								CrmCompany_Lang entity = new CrmCompany_Lang
								{
									LanguageID = CS_0024_003C_003E8__locals0.lang.LanguageID,
									CompanyID = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.cmp.CompanyID,
									cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null),
									cmpName = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.cmp.cmpName
								};
								_dbTbl.CrmCompany_Lang.Add(entity);
								_dbTbl.SaveChanges();
							}
						}
						base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					}
				}
			}
		}
		catch (DbEntityValidationException e2)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			base.ViewBag.Error = Messages.frmErrorMessage;
		}
		FillDropdownIssueOrder();
		GetOrdDefSetting();
		GetOrdSetPementType();
		CompanyFullcombo(_003C_003Ec__DisplayClass7_.model.CompanyID);
		GetProjectTitleLang(_003C_003Ec__DisplayClass7_.model.pordId);
		List<CRMspSelectCompanyGroupsMulti_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsMulti_Result>((IEnumerable<CRMspSelectCompanyGroupsMulti_Result>)_db.CRMspSelectCompanyGroupsMulti(lCID, _003C_003Ec__DisplayClass7_.defLangID));
		List<CommonDroupDownItemViewModel> list3 = new List<CommonDroupDownItemViewModel>();
		foreach (CRMspSelectCompanyGroupsMulti_Result item in list2)
		{
			CommonDroupDownItemViewModel commonDroupDownItemViewModel = new CommonDroupDownItemViewModel
			{
				Text = item.CompanyGroupsMultiName,
				Value = item.CompanyGroupsMultiID.ToString(),
				Tag = false
			};
			if (Enumerable.FirstOrDefault<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)Enumerable.ToList<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)_db.CRMspCompanyCheckHaveMultiGroup(_003C_003Ec__DisplayClass7_.model.CompanyID, item.CompanyGroupsMultiID))) != null)
			{
				commonDroupDownItemViewModel.Tag = true;
			}
			list3.Add(commonDroupDownItemViewModel);
		}
		base.ViewBag.MultiGroups = list3;
		base.ViewBag.PreOrderFilesCount = SelectFilesDirectory(_003C_003Ec__DisplayClass7_.model.pordId).Count;
		return View(_003C_003Ec__DisplayClass7_.model);
	}

	[AjaxOnly]
	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmIssueOrderFromPreOrder", ActionName = "actCanChangeCompanyInfo")]
	public JsonResult EditCompanyInfo(CmpInfoViewModel model)
	{
		//IL_009d: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass8_0 _003C_003Ec__DisplayClass8_ = new _003C_003Ec__DisplayClass8_0();
		_003C_003Ec__DisplayClass8_.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out _003C_003Ec__DisplayClass8_.defLangID);
		if (_003C_003Ec__DisplayClass8_.defLangID <= 0)
		{
			_003C_003Ec__DisplayClass8_.defLangID = 1065;
		}
		_003C_003Ec__DisplayClass8_.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		commonReturnResultViewModel.MessageExtra = "";
		try
		{
			_003C_003Ec__DisplayClass8_1 _003C_003Ec__DisplayClass8_2 = new _003C_003Ec__DisplayClass8_1();
			_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass8_;
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpAddress_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpAddress_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpAddress,
				LanguageId = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID
			});
			DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "c");
			_003C_003Ec__DisplayClass8_2.cmp = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_2, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (_003C_003Ec__DisplayClass8_2.cmp != null)
			{
				int countError = 0;
				string text = CRMIdeal.Classes.Helper.Company.ChkBeforeSubmitCompany(_003C_003Ec__DisplayClass8_2.cmp, ref countError);
				if (countError > 0)
				{
					base.ViewBag.Error = text;
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = text;
				}
				else
				{
					CrmCompanyChangeHistoryFieldViewModel oldCmpInfo = new CrmCompanyChangeHistoryFieldViewModel();
					if (_003C_003Ec__DisplayClass8_2.cmp != null)
					{
						string companyMultiGroupIds = GetCompanyMultiGroupIds(_003C_003Ec__DisplayClass8_2.cmp.CompanyID);
						oldCmpInfo = new CrmCompanyChangeHistoryFieldViewModel
						{
							cmpGroupId = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupId,
							cmpSubGroupId = _003C_003Ec__DisplayClass8_2.cmp.cmpSubGroupId,
							cmpGroupIdII = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdII,
							cmpGroupIdIII = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIII,
							cmpGroupIdIV = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIV,
							cmpTypeId = _003C_003Ec__DisplayClass8_2.cmp.cmpTypeId,
							cmpPresentationId = _003C_003Ec__DisplayClass8_2.cmp.cmpPresentationId,
							cmpReferUserId = _003C_003Ec__DisplayClass8_2.cmp.cmpReferUserId,
							cmpSuppUserId = _003C_003Ec__DisplayClass8_2.cmp.cmpSuppUserId,
							cmpGroupsMultiIds = companyMultiGroupIds,
							cmpCampaignIds = _003C_003Ec__DisplayClass8_2.cmp.cmpCampaignIds
						};
					}
					_003C_003Ec__DisplayClass8_2.cmp.UserId = UserLogin.CurrentUser.UserId;
					DateTime now = DateTime.Now;
					_003C_003Ec__DisplayClass8_2.cmp.RegisterDate = now;
					_003C_003Ec__DisplayClass8_2.cmp.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass8_2.cmp.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass8_2.cmp.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass8_2.cmp.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass8_2.cmp.cmpAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.defLangID)).Value : null);
					_003C_003Ec__DisplayClass8_2.cmp.cmpEconomicCode = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpEconomicCode;
					_003C_003Ec__DisplayClass8_2.cmp.cmpGroupId = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpGroupId;
					_003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdII = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdII;
					_003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIII = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdIII;
					_003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIV = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpGroupIdIV;
					_003C_003Ec__DisplayClass8_2.cmp.cmpNationalCode = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpNationalCode;
					_003C_003Ec__DisplayClass8_2.cmp.cmpRegistrationNumber = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpRegistrationNumber;
					_003C_003Ec__DisplayClass8_2.cmp.cmpSubGroupId = ((_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpSubGroupId == 0) ? null : _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpSubGroupId);
					_003C_003Ec__DisplayClass8_2.cmp.cmpTypeId = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpTypeId;
					_003C_003Ec__DisplayClass8_2.cmp.cmpZipCode = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpZipCode;
					if (!string.IsNullOrEmpty(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpEffectiveDatePersian))
					{
						DateTime dateTime = default(DateTime);
						string text2 = "";
						try
						{
							text2 = PersianDate.GetFormatetdDate(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.cmpEffectiveDatePersian.Replace("/", ""));
							if (_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID == 1065)
							{
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								_003C_003Ec__DisplayClass8_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd");
							}
							else if (_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID == 1025)
							{
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								_003C_003Ec__DisplayClass8_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							else
							{
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								_003C_003Ec__DisplayClass8_2.cmp.cmpEffectiveDatePersian = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							_003C_003Ec__DisplayClass8_2.cmp.cmpEffectiveDateTime = dateTime;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							base.ViewBag.Error = Messages.ErrorFormatDatePersian;
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.ErrorFormatDatePersian;
						}
					}
					_003C_003Ec__DisplayClass8_2.cmp.cmpAddress = _003C_003Ec__DisplayClass8_2.cmp.cmpAddress.ArabicToPersian();
					_dbTbl.Entry(_003C_003Ec__DisplayClass8_2.cmp).State = EntityState.Modified;
					string[] array = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.MultiGroups.Split(new char[1] { '|' });
					foreach (string text3 in array)
					{
						if (!(text3 != ""))
						{
							continue;
						}
						_003C_003Ec__DisplayClass8_2 _003C_003Ec__DisplayClass8_3 = new _003C_003Ec__DisplayClass8_2();
						_003C_003Ec__DisplayClass8_3.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass8_2;
						string text4 = text3.Substring(0, 1);
						_003C_003Ec__DisplayClass8_3.idGrp = 0;
						string text5 = text3;
						text5 = text5.Substring(1, text5.Length - 1);
						int.TryParse(text5, out _003C_003Ec__DisplayClass8_3.idGrp);
						if (_003C_003Ec__DisplayClass8_3.idGrp <= 0)
						{
							continue;
						}
						if (text4 == "+")
						{
							DbSet<CrmCompanyMultiGroups> crmCompanyMultiGroups = _dbTbl.CrmCompanyMultiGroups;
							val = Expression.Parameter(typeof(CrmCompanyMultiGroups), "c");
							CrmCompanyMultiGroups crmCompanyMultiGroups2 = Queryable.FirstOrDefault<CrmCompanyMultiGroups>((IQueryable<CrmCompanyMultiGroups>)crmCompanyMultiGroups, Expression.Lambda<Func<CrmCompanyMultiGroups, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_3, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_3, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompanyMultiGroups2 == null)
							{
								crmCompanyMultiGroups2 = new CrmCompanyMultiGroups();
								crmCompanyMultiGroups2.CompanyID = _003C_003Ec__DisplayClass8_3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.model.CompanyID;
								crmCompanyMultiGroups2.CompanyGroupsMultiID = _003C_003Ec__DisplayClass8_3.idGrp;
								crmCompanyMultiGroups2.UserId = UserLogin.CurrentUser.UserId;
								crmCompanyMultiGroups2.Year1 = short.Parse(Financial.Get().Id.ToString());
								crmCompanyMultiGroups2.Month1 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
								crmCompanyMultiGroups2.RegisterDate = DateTime.Now;
								crmCompanyMultiGroups2.RegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								crmCompanyMultiGroups2.AppType = Configuration.AppType;
								crmCompanyMultiGroups2.GUId = Guid.NewGuid();
								crmCompanyMultiGroups2.FirstRegisterDate = DateTime.Now;
								crmCompanyMultiGroups2.FirstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
								crmCompanyMultiGroups2.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
								crmCompanyMultiGroups2.LanguageID = _003C_003Ec__DisplayClass8_3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.defLangID;
								_dbTbl.CrmCompanyMultiGroups.Add(crmCompanyMultiGroups2);
							}
						}
						else if (text4 == "-")
						{
							DbSet<CrmCompanyMultiGroups> crmCompanyMultiGroups3 = _dbTbl.CrmCompanyMultiGroups;
							val = Expression.Parameter(typeof(CrmCompanyMultiGroups), "c");
							CrmCompanyMultiGroups crmCompanyMultiGroups4 = Queryable.FirstOrDefault<CrmCompanyMultiGroups>((IQueryable<CrmCompanyMultiGroups>)crmCompanyMultiGroups3, Expression.Lambda<Func<CrmCompanyMultiGroups, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_3, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_3, typeof(_003C_003Ec__DisplayClass8_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompanyMultiGroups4 != null)
							{
								_dbTbl.CrmCompanyMultiGroups.Remove(crmCompanyMultiGroups4);
							}
						}
					}
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass8_3 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass8_3();
							CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass8_2;
							CS_0024_003C_003E8__locals0.lang = enumerator.Current;
							DbSet<CrmCompany_Lang> crmCompany_Lang = _dbTbl.CrmCompany_Lang;
							val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
							CrmCompany_Lang crmCompany_Lang2 = Queryable.FirstOrDefault<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass8_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmCompany_Lang2 != null)
							{
								crmCompany_Lang2.cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmCompany_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							CrmCompany_Lang entity = new CrmCompany_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals0.lang.LanguageID,
								CompanyID = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.cmp.CompanyID,
								cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.lang.LanguageID)).Value : null),
								cmpName = CS_0024_003C_003E8__locals0.CS_0024_003C_003E8__locals3.cmp.cmpName
							};
							_dbTbl.CrmCompany_Lang.Add(entity);
							_dbTbl.SaveChanges();
						}
					}
					string companyMultiGroupIds2 = GetCompanyMultiGroupIds(_003C_003Ec__DisplayClass8_2.cmp.CompanyID);
					CrmCompanyChangeHistoryFieldViewModel newCmpInfo = new CrmCompanyChangeHistoryFieldViewModel
					{
						cmpGroupId = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupId,
						cmpSubGroupId = _003C_003Ec__DisplayClass8_2.cmp.cmpSubGroupId,
						cmpGroupIdII = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdII,
						cmpGroupIdIII = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIII,
						cmpGroupIdIV = _003C_003Ec__DisplayClass8_2.cmp.cmpGroupIdIV,
						cmpTypeId = _003C_003Ec__DisplayClass8_2.cmp.cmpTypeId,
						cmpPresentationId = _003C_003Ec__DisplayClass8_2.cmp.cmpPresentationId,
						cmpReferUserId = _003C_003Ec__DisplayClass8_2.cmp.cmpReferUserId,
						cmpSuppUserId = _003C_003Ec__DisplayClass8_2.cmp.cmpSuppUserId,
						cmpGroupsMultiIds = companyMultiGroupIds2,
						cmpCampaignIds = _003C_003Ec__DisplayClass8_2.cmp.cmpCampaignIds
					};
					CRMIdeal.Classes.Helper.Company.InsertCompanyChangeHistory(_003C_003Ec__DisplayClass8_2.cmp.CompanyID, 2, oldCmpInfo, newCmpInfo);
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
					string text6 = "";
					string text7 = "";
					CmpInfoViewModel cmpInfoViewModel = new CmpInfoViewModel();
					_003C_003Ec__DisplayClass8_2.company = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.CompanyID);
					if (_003C_003Ec__DisplayClass8_2.company != null)
					{
						string text8 = "|";
						List<CRMspSelectCompanyGroupsMulti_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsMulti_Result>((IEnumerable<CRMspSelectCompanyGroupsMulti_Result>)_db.CRMspSelectCompanyGroupsMulti(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID, _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.defLangID));
						List<CommonDroupDownItemViewModel> list3 = new List<CommonDroupDownItemViewModel>();
						foreach (CRMspSelectCompanyGroupsMulti_Result item in list2)
						{
							CommonDroupDownItemViewModel commonDroupDownItemViewModel = new CommonDroupDownItemViewModel
							{
								Text = item.CompanyGroupsMultiName,
								Value = item.CompanyGroupsMultiID.ToString(),
								Tag = false
							};
							if (Enumerable.FirstOrDefault<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)Enumerable.ToList<CRMspCompanyCheckHaveMultiGroup_Result>((IEnumerable<CRMspCompanyCheckHaveMultiGroup_Result>)_db.CRMspCompanyCheckHaveMultiGroup(_003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.model.CompanyID, item.CompanyGroupsMultiID))) != null)
							{
								commonDroupDownItemViewModel.Tag = true;
								text8 = text8 + "+" + commonDroupDownItemViewModel.Value + "|";
							}
							else
							{
								text8 = text8 + "-" + commonDroupDownItemViewModel.Value + "|";
							}
							list3.Add(commonDroupDownItemViewModel);
						}
						if (list3 != null)
						{
							text7 = JsonConvert.SerializeObject(list3);
						}
						DbSet<CrmCompany_Lang> crmCompany_Lang3 = _dbTbl.CrmCompany_Lang;
						val = Expression.Parameter(typeof(CrmCompany_Lang), "c");
						List<CrmCompany_Lang> list4 = Enumerable.ToList<CrmCompany_Lang>((IEnumerable<CrmCompany_Lang>)Queryable.Where<CrmCompany_Lang>((IQueryable<CrmCompany_Lang>)crmCompany_Lang3, Expression.Lambda<Func<CrmCompany_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_2, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						DbSet<CrmCompany> crmCompany2 = _dbTbl.CrmCompany;
						val = Expression.Parameter(typeof(CrmCompany), "c");
						CrmCompany crmCompany3 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany2, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass8_2, typeof(_003C_003Ec__DisplayClass8_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompany_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompany_Lang>)list4, (Func<CrmCompany_Lang, CommonMultiLanguageViewModel>)((CrmCompany_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.cmpAddress,
							LanguageId = item.LanguageID
						})));
						list5.Add(new CommonMultiLanguageViewModel
						{
							Value = ((crmCompany3 != null) ? crmCompany3.cmpAddress : ""),
							LanguageId = _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.defLangID
						});
						cmpInfoViewModel = new CmpInfoViewModel
						{
							pordId = 0,
							CompanyID = _003C_003Ec__DisplayClass8_2.company.CompanyID,
							cmpAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID)).Value : ""),
							cmpAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != _003C_003Ec__DisplayClass8_2.CS_0024_003C_003E8__locals1.currLangID)))),
							cmpEconomicCode = _003C_003Ec__DisplayClass8_2.company.cmpEconomicCode,
							cmpGroupId = _003C_003Ec__DisplayClass8_2.company.cmpGroupId,
							cmpGroupIdII = _003C_003Ec__DisplayClass8_2.company.cmpGroupIdII,
							cmpGroupIdIII = _003C_003Ec__DisplayClass8_2.company.cmpGroupIdIII,
							cmpGroupIdIV = _003C_003Ec__DisplayClass8_2.company.cmpGroupIdIV,
							cmpName = _003C_003Ec__DisplayClass8_2.company.cmpName,
							cmpNationalCode = _003C_003Ec__DisplayClass8_2.company.cmpNationalCode,
							cmpRegistrationNumber = _003C_003Ec__DisplayClass8_2.company.cmpRegistrationNumber,
							cmpSubGroupId = _003C_003Ec__DisplayClass8_2.company.cmpSubGroupId,
							cmpTypeId = _003C_003Ec__DisplayClass8_2.company.cmpTypeId,
							cmpZipCode = _003C_003Ec__DisplayClass8_2.company.cmpZipCode,
							cmpEffectiveDatePersian = (_003C_003Ec__DisplayClass8_2.company.cmpEffectiveDateTime.HasValue ? _003C_003Ec__DisplayClass8_2.company.cmpEffectiveDateTime.Value.ToString("yyyy/MM/dd") : ""),
							MultiGroups = text8
						};
						if (cmpInfoViewModel != null)
						{
							text6 = JsonConvert.SerializeObject(cmpInfoViewModel);
						}
					}
					commonReturnResultViewModel.MessageExtra = text6 + "^@^CmpMultiGroup^@^" + text7;
					commonReturnResultViewModel.IsDone = true;
					commonReturnResultViewModel.Message = Messages.frmFormBaseInsertSuccessFulMessage;
				}
			}
			else
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (DbEntityValidationException e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e3)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e3);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	private void CompanyFullcombo(int cmpId)
	{
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
			List<SelectListItem> list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result)), (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
			base.ViewBag.cmpTypeList = list;
			List<SelectListItem> list2 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsByUserId_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsByUserId_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsByUserId_Result>((IEnumerable<CRMspSelectCompanyGroupsByUserId_Result>)_db.CRMspSelectCompanyGroupsByUserId(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroupsByUserId_Result, SelectListItem>)((CRMspSelectCompanyGroupsByUserId_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
			base.ViewBag.cmpGroupList = list2;
			List<SelectListItem> list3 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result)), (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
			base.ViewBag.cmpGroupIIList = list3;
			List<SelectListItem> list4 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result)), (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
			})));
			base.ViewBag.cmpGroupIIIList = list4;
			List<SelectListItem> list5 = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyGroupsIVByUserId_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIVByUserId_Result>)Enumerable.ToList<CRMspSelectCompanyGroupsIVByUserId_Result>((IEnumerable<CRMspSelectCompanyGroupsIVByUserId_Result>)_db.CRMspSelectCompanyGroupsIVByUserId(UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanyGroupsIVByUserId_Result, SelectListItem>)((CRMspSelectCompanyGroupsIVByUserId_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
			})));
			base.ViewBag.cmpGroupIVList = list5;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	private void FillDropdownIssueOrder()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<WSspSelectOrderOpr_Result> list = Order.SelectOrderOpr();
			List<SelectListItem> list2 = new List<SelectListItem>();
			if (list != null)
			{
				list2.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
			base.ViewBag.OrdOprList = list2;
			_ = Configuration.MaxCountOfOnlineUser;
			List<CRMspSelectUserForLinkedTypeIsActive_Result> list3 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(UserLogin.CurrentUser.UserId, 15, lCID, result, result2));
			List<SelectListItem> list4 = new List<SelectListItem>();
			list4.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list3, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
			base.ViewBag.OrdReferUserList = list4;
			List<spSelectPrintFormat_Result> list5 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			List<SelectListItem> list6 = new List<SelectListItem>();
			list6.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list5, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
			base.ViewBag.OrdPrintFormatList = list6;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[AjaxOnly]
	public JsonResult GetSubGroup(int gupId)
	{
		List<CrmDroupDownItem> data = new List<CrmDroupDownItem>();
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
			data = Enumerable.ToList<CrmDroupDownItem>(Enumerable.Select<CRMspSelectCompanySubGroupsByGroupAndUserId_Result, CrmDroupDownItem>((IEnumerable<CRMspSelectCompanySubGroupsByGroupAndUserId_Result>)Enumerable.ToList<CRMspSelectCompanySubGroupsByGroupAndUserId_Result>((IEnumerable<CRMspSelectCompanySubGroupsByGroupAndUserId_Result>)_db.CRMspSelectCompanySubGroupsByGroupAndUserId(gupId, UserLogin.CurrentUser.UserId, lCID, result, result2)), (Func<CRMspSelectCompanySubGroupsByGroupAndUserId_Result, CrmDroupDownItem>)((CRMspSelectCompanySubGroupsByGroupAndUserId_Result item) => new CrmDroupDownItem
			{
				text = item.SubGroupName,
				value = item.CompanySubGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdDefSetting(int? id = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			if (!id.HasValue)
			{
				id = UserLogin.CurrentUser.UserId;
			}
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list2 = Enumerable.ToList<WSspSelectOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectOrderDefaultSettingUserAccess((short)1, userId, lCID, result));
			int? defSettingId = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.WSspSelectOrderDefaultSettingIsDefUserAccess((short)1, userId, lCID, result));
			SelectListItem item2 = new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = true
			};
			list.Add(item2);
			list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString(),
				Selected = (item.OrderSettingID == defSettingId.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdSetPementType()
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
	public JsonResult GetPrdOrdIssueSetting(int pordId)
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
			List<WSspSelectProductOrdIssueByPordId_Result> list2 = Enumerable.ToList<WSspSelectProductOrdIssueByPordId_Result>((IEnumerable<WSspSelectProductOrdIssueByPordId_Result>)_dbI.WSspSelectProductOrdIssueByPordId(pordId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductOrdIssueByPordId_Result, SelectListItem>((IEnumerable<WSspSelectProductOrdIssueByPordId_Result>)list2, (Func<WSspSelectProductOrdIssueByPordId_Result, SelectListItem>)((WSspSelectProductOrdIssueByPordId_Result item) => new SelectListItem
			{
				Text = item.PrdName + ((!string.IsNullOrWhiteSpace(item.PrdCode)) ? (" (" + item.PrdCode + ")") : ""),
				Value = item.ProductID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdOrdIssueSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdIssueOrdFromIndexed(int pordId)
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
			List<WSspSelectProductIssueOrdFromIndexedByPordId_Result> list2 = Enumerable.ToList<WSspSelectProductIssueOrdFromIndexedByPordId_Result>((IEnumerable<WSspSelectProductIssueOrdFromIndexedByPordId_Result>)_dbI.WSspSelectProductIssueOrdFromIndexedByPordId(pordId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductIssueOrdFromIndexedByPordId_Result, SelectListItem>((IEnumerable<WSspSelectProductIssueOrdFromIndexedByPordId_Result>)list2, (Func<WSspSelectProductIssueOrdFromIndexedByPordId_Result, SelectListItem>)((WSspSelectProductIssueOrdFromIndexedByPordId_Result item) => new SelectListItem
			{
				Text = item.PrdName + ((!string.IsNullOrWhiteSpace(item.PrdCode)) ? (" (" + item.PrdCode + ")") : ""),
				Value = item.ProductID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdIssueOrdFromIndexedList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SetOrder(int preOrderId, string regDate, int ordOprId, int ordPrintFormatId, int ordReferUserId, int ordSettingId, string ordDescription, string ordDescriptionLang, int? ordSettlementTypeId = null, bool pordSendToAcc = true, bool ordSendToAcc = true, bool transferPreOrderFileToOrder = false, string selectedfilesDirectoryTypes = "", int linkAccFiscalYearId = 0, int linkAccUserId = 0, bool linkAccSendPordPayToAcc = false, bool linkAccSendOrdPayToAcc = false, int ordProjectId = 0, string valDetails = "", bool isTransferFreePay = false, bool isTransferFreeComm = false, bool addPrdValidity = false, string addPrdValidityPrjTitle = "", int ordCompanyPersonId = 0, int ordIssueSettingByPrdId = 0, int ordIssueIndexedByPrdId = 0, int linkAccSettingDBId = 0)
	{
		//IL_03bd: Unknown result type (might be due to invalid IL or missing references)
		//IL_05f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_17ca: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			int result = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
			}
			if (!VersionBuyer.Order)
			{
				DbSet<WSOrder> wSOrder = _dbTbl.WSOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSOrder), "c");
				if (Queryable.Any<WSOrder>((IQueryable<WSOrder>)wSOrder, Expression.Lambda<Func<WSOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.VersionBuy;
					commonReturnResultViewModel.Tag = "BV|";
					return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
				}
			}
			int num = 0;
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(preOrderId, lCID, defLangID));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				num = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
				if (wSspSelectPreOrderWithId_Result != null)
				{
					int result2 = 0;
					int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result2);
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanIssueOrderFromExpirePord", UserLogin.CurrentUser) && (result2 == 4 || (wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime < DateTime.Now)))
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorIssueOrderFormPordCanceled;
						commonReturnResultViewModel.Tag = "MOJ|";
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
				}
			}
			if (!UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actIssueTaxConflictInOrdOpr", UserLogin.CurrentUser))
			{
				bool flag = PreOrder.CheckCheckPreOrderHaveTax(preOrderId);
				WSspSelectOrderOprById_Result wSspSelectOrderOprById_Result = Enumerable.FirstOrDefault<WSspSelectOrderOprById_Result>((IEnumerable<WSspSelectOrderOprById_Result>)_dbI.WSspSelectOrderOprById(ordOprId, lCID, defLangID));
				if (wSspSelectOrderOprById_Result != null)
				{
					bool result3 = false;
					bool.TryParse(wSspSelectOrderOprById_Result.Taxable.ToString(), out result3);
					if (flag != result3)
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = "msgErrorOrderOprNoTaxable".OrderMessages();
						commonReturnResultViewModel.Tag = "Taxable|";
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
				}
			}
			CRMspSelectFoSetting_Result foSetting = CRMIdeal.Classes.Helper.Setting.GetFoSetting();
			if (foSetting != null)
			{
				bool result4 = false;
				bool.TryParse(foSetting.ShpUniqueSaleCenterParentInOrd.ToString(), out result4);
				if (result4)
				{
					ObjectParameter objectParameter = new ObjectParameter("Result", typeof(int));
					_dbII.WSspCheckPreOrderItemSaleCenterUnique(preOrderId, objectParameter);
					if (objectParameter != null && objectParameter.Value != null)
					{
						int result5 = 0;
						int.TryParse(objectParameter.Value.ToString(), out result5);
						if (result5 == 0)
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = "msgErrorNotIssueOrdByDifferentPordSaleCenter".OrderMessages();
							commonReturnResultViewModel.Tag = "Taxable|";
							return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
						}
					}
				}
			}
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			List<CrmProjectTitles_LangViewModel> list2 = new List<CrmProjectTitles_LangViewModel>();
			if (!string.IsNullOrWhiteSpace(addPrdValidityPrjTitle))
			{
				CRMspSelectProjectTitlesByVal_Result cRMspSelectProjectTitlesByVal_Result = Enumerable.FirstOrDefault<CRMspSelectProjectTitlesByVal_Result>((IEnumerable<CRMspSelectProjectTitlesByVal_Result>)_dbI.CRMspSelectProjectTitlesByVal(addPrdValidityPrjTitle, lCID, defLangID));
				if (cRMspSelectProjectTitlesByVal_Result != null)
				{
					if (!string.IsNullOrEmpty(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CrmProjectTitles_LangViewModel>>(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang);
					}
					list2.Add(new CrmProjectTitles_LangViewModel
					{
						CrmProjectTitlesLangID = 0,
						ProjectTitleID = cRMspSelectProjectTitlesByVal_Result.ProjectTitleID,
						LanguageID = lCID,
						ProjectTitle = cRMspSelectProjectTitlesByVal_Result.ProjectTitle,
						ProjectTitleDesc = cRMspSelectProjectTitlesByVal_Result.ProjectTitleDesc
					});
				}
			}
			if (list2 != null && Enumerable.Any<CrmProjectTitles_LangViewModel>((IEnumerable<CrmProjectTitles_LangViewModel>)list2))
			{
				foreach (CrmProjectTitles_LangViewModel item5 in list2)
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = item5.ProjectTitle,
						LanguageId = item5.LanguageID
					});
				}
			}
			addPrdValidityPrjTitle = ((!Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list)) ? "" : ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : ""));
			if (addPrdValidity && string.IsNullOrWhiteSpace(addPrdValidityPrjTitle))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.IssueOrdFromPordAddPrdValidityPrjTitle);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (ordIssueSettingByPrdId != 0 && num != 0)
			{
				WSspCheckHaveCmpProjectByOrdIssuePrdId_Result wSspCheckHaveCmpProjectByOrdIssuePrdId_Result = Enumerable.FirstOrDefault<WSspCheckHaveCmpProjectByOrdIssuePrdId_Result>((IEnumerable<WSspCheckHaveCmpProjectByOrdIssuePrdId_Result>)_dbI.WSspCheckHaveCmpProjectByOrdIssuePrdId(num, ordIssueSettingByPrdId, lCID, defLangID, result));
				if (wSspCheckHaveCmpProjectByOrdIssuePrdId_Result != null)
				{
					int result6 = 0;
					int.TryParse(wSspCheckHaveCmpProjectByOrdIssuePrdId_Result.ProjectId.ToString(), out result6);
					if (result6 == -2)
					{
						string arg = wSspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjTitleGroup + " " + wSspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjTitle + " " + wSspCheckHaveCmpProjectByOrdIssuePrdId_Result.PrdOrdIssuePrjPostFix;
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = string.Format("msgErrorNotIssueOrderNoProject".OrderMessages(), arg);
						commonReturnResultViewModel.Tag = "";
						return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
					}
				}
			}
			List<OrdIdKeyValueViewModel> list3 = new List<OrdIdKeyValueViewModel>();
			if (!string.IsNullOrEmpty(valDetails))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<OrdIdKeyValueViewModel>>(valDetails);
			}
			List<OrdIdKeyValueViewModel> list4 = new List<OrdIdKeyValueViewModel>();
			string pordItemList = "";
			if (Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list3))
			{
				foreach (OrdIdKeyValueViewModel item6 in list3)
				{
					int id = item6.Id;
					_ = item6.Type;
					string tag = item6.Tag;
					string valueStr = item6.ValueStr;
					int result7 = 0;
					int.TryParse(id.ToString(), out result7);
					double result8 = 0.0;
					string text = "";
					string text2 = "";
					decimal result9 = default(decimal);
					if (!(tag == "B"))
					{
						continue;
					}
					double.TryParse(valueStr.ToString(), out result8);
					OrdIdKeyValueViewModel ordIdKeyValueViewModel = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list3, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "D"));
					if (ordIdKeyValueViewModel != null)
					{
						text = ordIdKeyValueViewModel.ValueStr;
					}
					OrdIdKeyValueViewModel ordIdKeyValueViewModel2 = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list3, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "E"));
					if (ordIdKeyValueViewModel2 != null)
					{
						text2 = ordIdKeyValueViewModel2.ValueStr;
					}
					OrdIdKeyValueViewModel ordIdKeyValueViewModel3 = Enumerable.FirstOrDefault<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list3, (Func<OrdIdKeyValueViewModel, bool>)((OrdIdKeyValueViewModel m) => m.Id == id && m.Tag == "F"));
					if (ordIdKeyValueViewModel3 != null)
					{
						decimal.TryParse(ordIdKeyValueViewModel3.ValueStr, out result9);
					}
					if (!(result8 > 0.0))
					{
						continue;
					}
					DateTime dateTime = default(DateTime);
					string text3 = "";
					DateTime? validityExpireDate = default(DateTime);
					try
					{
						if (!string.IsNullOrWhiteSpace(text))
						{
							text3 = PersianDate.GetFormatetdDate(text.Replace("/", ""));
							text3 = (string.IsNullOrEmpty(text2) ? (text3 + " 00:00:00") : (text3 + " " + text2.Trim()));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text3, new PersianCulture());
								text = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text3, new CultureInfo("ar-SA"));
								text = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text3, new CultureInfo("en-US"));
								text = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							validityExpireDate = dateTime;
						}
						else
						{
							validityExpireDate = null;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (text != null)
					{
						text = text.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					OrdIdKeyValueViewModel item2 = new OrdIdKeyValueViewModel
					{
						Id = result7,
						Value = result8,
						ValidityExpireDate = validityExpireDate,
						ValidityExpireDatePersian = text,
						PrdAutoCalcRate = result9
					};
					list4.Add(item2);
				}
			}
			if (list4 != null && Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4))
			{
				pordItemList = JsonConvert.SerializeObject(Enumerable.ToList<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4));
			}
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				try
				{
					string karaAfzarLockSerial = Configuration.KaraAfzarLockSerial;
					string text4 = cRMspSelectCrmsysSetting_Result.LockSerial ?? "";
					if (!string.IsNullOrWhiteSpace(text4) && text4 == karaAfzarLockSerial)
					{
						string text5 = "";
						if (list4 != null && Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4))
						{
							foreach (OrdIdKeyValueViewModel item7 in list4)
							{
								int id2 = item7.Id;
								double value = item7.Value;
								int result10 = 0;
								int.TryParse(id2.ToString(), out result10);
								double result11 = 0.0;
								double.TryParse(value.ToString(), out result11);
								if (result10 != 0 && result11 != 0.0)
								{
									if (!string.IsNullOrWhiteSpace(text5))
									{
										text5 += ",";
									}
									text5 += result10;
								}
							}
						}
						if (Order.KaraAfzarGetChargeSmsPordItem(preOrderId, text5) != null)
						{
							string text6 = "";
							if (string.IsNullOrWhiteSpace(Order.KaraAfzarGetSmsPanelNumber(num)))
							{
								text6 = "msgErrorChargeSmsNotDefineNumberInIssueOrd".OrderMessages() + "<br>";
							}
							if (!string.IsNullOrWhiteSpace(text6))
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = text6;
								commonReturnResultViewModel.Tag = "SmsCharge|";
								return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
							}
						}
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			if (!PreOrder.IsFixed(preOrderId))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorToPordnotIsFixedBeNotIssueOrder;
				commonReturnResultViewModel.Tag = "";
			}
			else if (!PreOrder.IsVerified(preOrderId))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorToBeNotIssueOrder;
				commonReturnResultViewModel.Tag = "";
			}
			else
			{
				WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result = new WSspReturnOrderFromPreOrder_Result();
				string text7 = "";
				List<WSspReturnOrderFromPreOrder_Result> list5 = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(preOrderId, lCID, defLangID));
				if (list5 != null && Enumerable.Any<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list5))
				{
					wSspReturnOrderFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list5);
					if (list5.Count > 1)
					{
						foreach (WSspReturnOrderFromPreOrder_Result item8 in list5)
						{
							text7 = text7 + item8.ordNumber + ",";
						}
						if (!string.IsNullOrEmpty(text7) && text7.EndsWith(","))
						{
							text7 = text7.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromPreOrder_Result = null;
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspCheckPreOrderHaveOrder(preOrderId));
				int result12 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result12);
					if (result12 == 0)
					{
						wSspReturnOrderFromPreOrder_Result = null;
					}
				}
				if (wSspReturnOrderFromPreOrder_Result != null && result12 == 1)
				{
					commonReturnResultViewModel.IsDone = false;
					if (string.IsNullOrEmpty(text7))
					{
						text7 = wSspReturnOrderFromPreOrder_Result.ordNumber.ToString();
					}
					wSspReturnOrderFromPreOrder_Result.ordDate = ((!string.IsNullOrEmpty(wSspReturnOrderFromPreOrder_Result.ordDate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(wSspReturnOrderFromPreOrder_Result.ordDate.Replace("/", "")).Replace("/", "") : wSspReturnOrderFromPreOrder_Result.ordDate);
					WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result2 = wSspReturnOrderFromPreOrder_Result;
					_ = wSspReturnOrderFromPreOrder_Result.RegisterDate;
					wSspReturnOrderFromPreOrder_Result2.RegisterDatePersian = wSspReturnOrderFromPreOrder_Result.RegisterDate.ToString("yyyyMMdd");
					commonReturnResultViewModel.Message = Labels.Error + " !\r\n" + Messages.msgIssueOrderFormPreOrderWithNumber + " " + text7 + "\r\n" + Messages.msgIssueOrderFormPreOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromPreOrder_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormPreOrderByUser + " " + wSspReturnOrderFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueOrderFormPreOrderBeenIssued;
					commonReturnResultViewModel.Tag = wSspReturnOrderFromPreOrder_Result.OrderID + "|HaveOrd";
				}
				else
				{
					if (UserLogin.IsUserAccess("frmPreOrder", "actCanIssueOrderAfterPayFull", UserLogin.CurrentUser))
					{
						decimal result13 = default(decimal);
						WSspReturnSumPreOrderPay_Result wSspReturnSumPreOrderPay_Result = Enumerable.FirstOrDefault<WSspReturnSumPreOrderPay_Result>((IEnumerable<WSspReturnSumPreOrderPay_Result>)_db.WSspReturnSumPreOrderPay(preOrderId));
						if (wSspReturnSumPreOrderPay_Result != null)
						{
							decimal.TryParse(wSspReturnSumPreOrderPay_Result.RemainpordAmount.ToString(), out result13);
						}
						if (result13 > 0m)
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = "msgErrorUnableIssueOrdFromPordNotBeenFullySettled".OrderMessages();
							commonReturnResultViewModel.Tag = "PayFull|";
							return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
						}
					}
					if (UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actCanNotIssueOrderWithNoStock", UserLogin.CurrentUser))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result2 = SysSeting.Get();
						bool flag2 = false;
						int num2 = 0;
						bool flag3 = false;
						if (cRMspSelectCrmsysSetting_Result2 != null)
						{
							flag2 = ((cRMspSelectCrmsysSetting_Result2.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result2.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num2 = cRMspSelectCrmsysSetting_Result2.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag2 && num2 > 0)
						{
							List<WSspSelectPreOrderItems_Result> list6 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(preOrderId, lCID, defLangID));
							if (list4 == null)
							{
								list4 = new List<OrdIdKeyValueViewModel>();
							}
							if (!Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4) && list6 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list6))
							{
								foreach (WSspSelectPreOrderItems_Result item9 in list6)
								{
									OrdIdKeyValueViewModel item3 = new OrdIdKeyValueViewModel
									{
										Id = item9.PreOrderItemID,
										Value = item9.pordIQuantity.GetValueOrDefault()
									};
									list4.Add(item3);
								}
							}
							List<WSspSelectPreOrderItems_Result> list7 = new List<WSspSelectPreOrderItems_Result>();
							if (list6 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list6) && list4 != null && Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4))
							{
								foreach (OrdIdKeyValueViewModel item10 in list4)
								{
									int id3 = item10.Id;
									_ = item10.Type;
									_ = item10.Tag;
									double value2 = item10.Value;
									int objId = 0;
									int.TryParse(id3.ToString(), out objId);
									double result14 = 0.0;
									double.TryParse(value2.ToString(), out result14);
									WSspSelectPreOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list6, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID == objId));
									if (linkAccitem == null || result14 == 0.0)
									{
										continue;
									}
									int num3 = linkAccitem.PrdKind.GetValueOrDefault(1);
									if (num3 == 0)
									{
										num3 = 1;
									}
									if (num3 != 1)
									{
										continue;
									}
									bool flag4 = true;
									if (Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list7, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag4 = false;
										foreach (WSspSelectPreOrderItems_Result item11 in list7)
										{
											if (item11.pordIPrdId == linkAccitem.pordIPrdId && item11.pordIWHId == linkAccitem.pordIWHId && (item11.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (item11.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && item11.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())
											{
												item11.pordIQuantity = item11.pordIQuantity.GetValueOrDefault() + result14;
											}
										}
									}
									if (flag4)
									{
										WSspSelectPreOrderItems_Result item4 = new WSspSelectPreOrderItems_Result
										{
											PreOrderItemID = linkAccitem.PreOrderItemID,
											pordIQuantity = result14,
											pordIPrice = linkAccitem.pordIPrice,
											pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
											pordIPrdId = linkAccitem.pordIPrdId,
											pordIWHId = linkAccitem.pordIWHId,
											pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
											pordITracing = linkAccitem.pordITracing,
											pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
											pordIDescriptionI = linkAccitem.pordIDescriptionI,
											PrdName = linkAccitem.PrdName
										};
										list7.Add(item4);
									}
								}
							}
							if (list7 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list7))
							{
								foreach (WSspSelectPreOrderItems_Result item12 in list7)
								{
									if (item12 == null)
									{
										continue;
									}
									double valueOrDefault = item12.pordIQuantity.GetValueOrDefault();
									ProductController productController = new ProductController();
									string text8 = "";
									switch (num2)
									{
									case 3:
									{
										decimal prdPrice = default(decimal);
										double prdQuantity = 0.0;
										productController.TarazGetPrdQuantityAndPrice(item12.pordIPrdId, num, item12.pordIWHId.GetValueOrDefault(), 0, ref prdPrice, ref prdQuantity, "pord", 0);
										text8 = prdQuantity.ToString();
										break;
									}
									case 4:
										text8 = productController.HolooGetPrdQuantity(item12.pordIPrdId, item12.pordILinkAccSettingDBId.GetValueOrDefault());
										break;
									case 6:
										text8 = productController.KyanGetPrdQuantity(item12.pordIPrdId, item12.pordIWHId.GetValueOrDefault());
										break;
									case 7:
										text8 = productController.PayvastGetPrdQuantity(item12.pordIPrdId, item12.pordIWHId.GetValueOrDefault());
										break;
									case 11:
										text8 = productController.ShomaranGetPrdQuantity(item12.pordIPrdId, item12.pordIWHId.GetValueOrDefault(), item12.pordILinkAccWHIdStr ?? "", item12.pordITracing ?? "", item12.pordIDescriptionI ?? "");
										break;
									case 12:
										text8 = productController.LinkAccGetPrdQuantity(num2, item12.pordIPrdId, item12.pordIWHId.GetValueOrDefault(), item12.pordILinkAccWHIdStr ?? "", item12.pordITracing ?? "");
										break;
									default:
										text8 = productController.LinkAccGetPrdQuantity(num2, item12.pordIPrdId, item12.pordIWHId.GetValueOrDefault(), item12.pordILinkAccWHIdStr ?? "", item12.pordITracing ?? "");
										break;
									}
									double result15 = 0.0;
									if (string.IsNullOrEmpty(text8))
									{
										continue;
									}
									if (text8 == Labels.frmError)
									{
										text8 = "0";
									}
									if (text8 != Labels.frmError)
									{
										double.TryParse(text8, out result15);
										if (result15 < valueOrDefault)
										{
											flag3 = true;
											commonReturnResultViewModel.IsDone = false;
											commonReturnResultViewModel.Message = Messages.msgErrorUnableIssueOrderFormPreOrder + "\r\n" + Messages.msgErrorIssueOrderFormPreOrderLackInventory + "\r\n" + item12.PrdName;
											commonReturnResultViewModel.Tag = "MOJ|";
											return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
										}
										flag3 = true;
									}
								}
							}
						}
						if (!flag3)
						{
							WSspControlPreOrderItemsStock_Result wSspControlPreOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlPreOrderItemsStock_Result>((IEnumerable<WSspControlPreOrderItemsStock_Result>)_db.WSspControlPreOrderItemsStock(preOrderId, lCID, defLangID, pordItemList, result));
							if (wSspControlPreOrderItemsStock_Result != null)
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorUnableIssueOrderFormPreOrder + "\r\n" + Messages.msgErrorIssueOrderFormPreOrderLackInventory + "\r\n" + wSspControlPreOrderItemsStock_Result.PrdName;
								commonReturnResultViewModel.Tag = "MOJ|";
								return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
							}
						}
					}
					if (UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actCanNotIssueOrderWithNoStockFromSold", UserLogin.CurrentUser))
					{
						string pordItemJson = "";
						if (list4 != null && Enumerable.Any<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4))
						{
							pordItemJson = JsonConvert.SerializeObject(Enumerable.ToList<OrdIdKeyValueViewModel>((IEnumerable<OrdIdKeyValueViewModel>)list4));
						}
						string text9 = "";
						text9 = PreOrder.ControlPreOrderItemsSoldStock(preOrderId, 3, "", pordItemJson);
						if (!string.IsNullOrWhiteSpace(text9))
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = text9;
							commonReturnResultViewModel.Tag = "MOJ|";
							return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
						}
					}
					string formatetdDate = PersianDate.GetFormatetdDate(regDate.Replace("/", ""));
					regDate = lCID switch
					{
						1065 => DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd", new PersianCulture()), 
						1025 => DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
						_ => DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
					};
					DateTime now = DateTime.Now;
					ordDescription = ((ordDescription == "") ? null : ordDescription);
					if (!string.IsNullOrEmpty(ordDescriptionLang))
					{
						List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
						if (!string.IsNullOrEmpty(ordDescriptionLang))
						{
							list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(ordDescriptionLang);
						}
						list8.Add(new CommonMultiLanguageViewModel
						{
							Value = ordDescription,
							LanguageId = lCID
						});
						ordDescriptionLang = "";
						ordDescriptionLang = Enumerable.Aggregate<CommonMultiLanguageViewModel, string>((IEnumerable<CommonMultiLanguageViewModel>)list8, ordDescriptionLang, (Func<string, CommonMultiLanguageViewModel, string>)((string current, CommonMultiLanguageViewModel item) => current + "@LangID=" + item.LanguageId + ",%," + item.Value + "|"));
						ordDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
					}
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderID", typeof(int));
					ObjectParameter objectParameter3 = new ObjectParameter("insertedOrderNumber", typeof(long));
					int num4 = _db.WSspIssueOrderFromPreOrder(preOrderId, regDate, ordOprId, ordPrintFormatId, ordReferUserId, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, ordDescription, ordSettlementTypeId, ordSettingId, objectParameter2, objectParameter3, defLangID, ordDescriptionLang, ordProjectId, pordItemList, isTransferFreePay, isTransferFreeComm, ordCompanyPersonId, ordIssueSettingByPrdId, ordIssueIndexedByPrdId, result);
					string text10 = objectParameter2.Value.ToString();
					string text11 = objectParameter3.Value.ToString();
					if (num4 > 0)
					{
						string text12 = "";
						if (UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actAutoReferOrderToWrhsUserAfterIssue", UserLogin.CurrentUser))
						{
							Order.ReferOrderToWrhsUser(int.Parse(text10));
						}
						bool flag5 = UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actSendToAccPord", UserLogin.CurrentUser);
						bool flag6 = UserLogin.IsUserAccess("frmIssueOrderFromPreOrder", "actSendToAccOrd", UserLogin.CurrentUser);
						if (flag5 && !flag6 && VersionBuyer.LinkAcc)
						{
							if (pordSendToAcc)
							{
								ObjectParameter objectParameter4 = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter5 = new ObjectParameter("errorMessage", "");
								ObjectParameter objectParameter6 = new ObjectParameter("preOrderNumber", 0);
								_dbLink.CRMspLkSepWSIssuePreOrder(preOrderId, crmUserId: UserLogin.CurrentUser.UserId, appType: Configuration.AppType, insertedId: objectParameter4, preOrderNumber: objectParameter6, errorMessage: objectParameter5, sepFiscalYearRef: (linkAccFiscalYearId == 0) ? null : new int?(linkAccFiscalYearId), sepUserId: (linkAccUserId == 0) ? null : new int?(linkAccUserId), sendPordPayToAcc: linkAccSendPordPayToAcc, linkAccSettingDBId: linkAccSettingDBId);
								if (objectParameter5.Value != null && !string.IsNullOrEmpty(objectParameter5.Value.ToString()))
								{
									string text13 = objectParameter5.Value.ToString();
									if (!string.IsNullOrWhiteSpace(text13))
									{
										if (text13.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
										{
											text13 = text13.Replace("Financially incorrect in pordpayment", "");
											text13 = text13.Replace(",,", "");
											text13 = text13 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
											text13 = text13.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text13 = text13.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text13.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
										{
											text13 = text13.Replace("Financially incorrect,", "");
											text13 = text13.Replace(",,", "");
											text13 = text13 + ", (" + Labels.lblPOrd + ") " + Messages.msgErrorfinancialYearWrong;
											text13 = text13.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text13 = text13.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
									}
									if (!string.IsNullOrWhiteSpace(text13) && text13.IndexOf("No Items", StringComparison.Ordinal) >= 0)
									{
										text13 = text13.Replace("No Items", "");
										text13 = text13.Replace(",,", "");
										text13 = text13 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblPOrd);
										text13 = text13.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
										text13 = text13.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
									}
									text12 += text13;
								}
							}
						}
						else if (!flag5 && flag6 && VersionBuyer.LinkAcc)
						{
							if (ordSendToAcc)
							{
								int value3 = int.Parse(text10);
								ObjectParameter objectParameter7 = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter8 = new ObjectParameter("errorMessage", "");
								ObjectParameter objectParameter9 = new ObjectParameter("orderNumebr", 0);
								_dbLink.CRMspLkSepWSIssueOrder(value3, null, crmUserId: UserLogin.CurrentUser.UserId, appType: Configuration.AppType, sendPreOrderToAcc: false, insertedId: objectParameter7, orderNumebr: objectParameter9, errorMessage: objectParameter8, sepFiscalYearRef: (linkAccFiscalYearId == 0) ? null : new int?(linkAccFiscalYearId), sepUserId: (linkAccUserId == 0) ? null : new int?(linkAccUserId), sendPordPayToAcc: linkAccSendPordPayToAcc, sendOrdPayToAcc: linkAccSendOrdPayToAcc, linkAccSettingDBId: linkAccSettingDBId, sendDocToAcc: false, sepInventoryType: null, sepDocType: null, sepInvIsReturn: false, sendOrdCommToAcc: false);
								if (objectParameter8.Value != null && !string.IsNullOrEmpty(objectParameter8.Value.ToString()))
								{
									string text14 = objectParameter8.Value.ToString();
									if (!string.IsNullOrWhiteSpace(text14))
									{
										if (text14.IndexOf("Financially incorrect in pord", StringComparison.Ordinal) >= 0)
										{
											text14 = text14.Replace("Financially incorrect in pord", "");
											text14 = text14.Replace(",,", "");
											text14 = text14 + ",(" + Labels.lblPOrd + ") " + Messages.msgErrorfinancialYearWrong;
											text14 = text14.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text14 = text14.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text14.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
										{
											text14 = text14.Replace("Financially incorrect in pordpayment", "");
											text14 = text14.Replace(",,", "");
											text14 = text14 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
											text14 = text14.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text14 = text14.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text14.IndexOf("Financially incorrect in ordpayment", StringComparison.Ordinal) >= 0)
										{
											text14 = text14.Replace("Financially incorrect in ordpayment", "");
											text14 = text14.Replace(",,", "");
											text14 = text14 + ",(" + Labels.lblOrdPay + ") " + Messages.msgErrorfinancialYearWrong;
											text14 = text14.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text14 = text14.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text14.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
										{
											text14 = text14.Replace("Financially incorrect,", "");
											text14 = text14.Replace(",,", "");
											text14 = text14 + ", (" + Labels.lblOrd + ") " + Messages.msgErrorfinancialYearWrong;
											text14 = text14.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text14 = text14.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
									}
									if (!string.IsNullOrWhiteSpace(text14) && text14.IndexOf("No Items", StringComparison.Ordinal) >= 0)
									{
										text14 = text14.Replace("No Items", "");
										text14 = text14.Replace(",,", "");
										text14 = text14 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblOrdI);
										text14 = text14.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
										text14 = text14.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
									}
									text12 += text14;
								}
							}
						}
						else if (flag5 && flag6 && VersionBuyer.LinkAcc)
						{
							if (pordSendToAcc && !ordSendToAcc)
							{
								ObjectParameter objectParameter10 = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter11 = new ObjectParameter("errorMessage", "");
								ObjectParameter objectParameter12 = new ObjectParameter("preOrderNumber", 0);
								_dbLink.CRMspLkSepWSIssuePreOrder(preOrderId, crmUserId: UserLogin.CurrentUser.UserId, appType: Configuration.AppType, insertedId: objectParameter10, preOrderNumber: objectParameter12, errorMessage: objectParameter11, sepFiscalYearRef: (linkAccFiscalYearId == 0) ? null : new int?(linkAccFiscalYearId), sepUserId: (linkAccUserId == 0) ? null : new int?(linkAccUserId), sendPordPayToAcc: linkAccSendPordPayToAcc, linkAccSettingDBId: linkAccSettingDBId);
								if (objectParameter11.Value != null && !string.IsNullOrEmpty(objectParameter11.Value.ToString()))
								{
									string text15 = objectParameter11.Value.ToString();
									if (!string.IsNullOrWhiteSpace(text15))
									{
										if (text15.IndexOf("Financially incorrect in pord", StringComparison.Ordinal) >= 0)
										{
											text15 = text15.Replace("Financially incorrect in pord", "");
											text15 = text15.Replace(",,", "");
											text15 = text15 + ",(" + Labels.lblPOrd + ") " + Messages.msgErrorfinancialYearWrong;
											text15 = text15.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text15 = text15.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text15.IndexOf("Financially incorrect in pordpayment", StringComparison.Ordinal) >= 0)
										{
											text15 = text15.Replace("Financially incorrect in pordpayment", "");
											text15 = text15.Replace(",,", "");
											text15 = text15 + ",(" + Labels.lblPordPay + ") " + Messages.msgErrorfinancialYearWrong;
											text15 = text15.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text15 = text15.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text15.IndexOf("Financially incorrect in ordpayment", StringComparison.Ordinal) >= 0)
										{
											text15 = text15.Replace("Financially incorrect in ordpayment", "");
											text15 = text15.Replace(",,", "");
											text15 = text15 + ",(" + Labels.lblOrdPay + ") " + Messages.msgErrorfinancialYearWrong;
											text15 = text15.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text15 = text15.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										else if (text15.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
										{
											text15 = text15.Replace("Financially incorrect,", "");
											text15 = text15.Replace(",,", "");
											text15 = text15 + ", (" + Labels.lblOrd + ") " + Messages.msgErrorfinancialYearWrong;
											text15 = text15.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text15 = text15.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
									}
									if (!string.IsNullOrWhiteSpace(text15) && text15.IndexOf("No Items", StringComparison.Ordinal) >= 0)
									{
										text15 = text15.Replace("No Items", "");
										text15 = text15.Replace(",,", "");
										text15 = text15 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblPOrd);
										text15 = text15.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
										text15 = text15.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
									}
									text12 += text15;
								}
							}
							else if (ordSendToAcc && !pordSendToAcc)
							{
								int value4 = int.Parse(text10);
								ObjectParameter objectParameter13 = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter14 = new ObjectParameter("errorMessage", "");
								ObjectParameter objectParameter15 = new ObjectParameter("orderNumebr", 0);
								_dbLink.CRMspLkSepWSIssueOrder(value4, null, crmUserId: UserLogin.CurrentUser.UserId, appType: Configuration.AppType, sendPreOrderToAcc: false, insertedId: objectParameter13, orderNumebr: objectParameter15, errorMessage: objectParameter14, sepFiscalYearRef: (linkAccFiscalYearId == 0) ? null : new int?(linkAccFiscalYearId), sepUserId: (linkAccUserId == 0) ? null : new int?(linkAccUserId), sendPordPayToAcc: linkAccSendPordPayToAcc, sendOrdPayToAcc: linkAccSendOrdPayToAcc, linkAccSettingDBId: linkAccSettingDBId, sendDocToAcc: false, sepInventoryType: null, sepDocType: null, sepInvIsReturn: false, sendOrdCommToAcc: false);
								if (objectParameter14.Value != null && !string.IsNullOrEmpty(objectParameter14.Value.ToString()))
								{
									text12 += objectParameter14.Value.ToString();
									if (!string.IsNullOrWhiteSpace(text12) && text12.IndexOf("No Items", StringComparison.Ordinal) >= 0)
									{
										text12 = text12.Replace("No Items", "");
										text12 = text12.Replace(",,", "");
										text12 = text12 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblOrdI);
										text12 = text12.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
										text12 = text12.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
									}
								}
							}
							else if (ordSendToAcc && pordSendToAcc)
							{
								int value5 = int.Parse(text10);
								ObjectParameter objectParameter16 = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter17 = new ObjectParameter("errorMessage", "");
								ObjectParameter objectParameter18 = new ObjectParameter("orderNumebr", 0);
								_dbLink.CRMspLkSepWSIssueOrder(value5, null, crmUserId: UserLogin.CurrentUser.UserId, appType: Configuration.AppType, sendPreOrderToAcc: true, insertedId: objectParameter16, orderNumebr: objectParameter18, errorMessage: objectParameter17, sepFiscalYearRef: (linkAccFiscalYearId == 0) ? null : new int?(linkAccFiscalYearId), sepUserId: (linkAccUserId == 0) ? null : new int?(linkAccUserId), sendPordPayToAcc: linkAccSendPordPayToAcc, sendOrdPayToAcc: linkAccSendOrdPayToAcc, linkAccSettingDBId: linkAccSettingDBId, sendDocToAcc: false, sepInventoryType: null, sepDocType: null, sepInvIsReturn: false, sendOrdCommToAcc: false);
								if (objectParameter17.Value != null && !string.IsNullOrEmpty(objectParameter17.Value.ToString()))
								{
									text12 += objectParameter17.Value.ToString();
									if (!string.IsNullOrWhiteSpace(text12) && text12.IndexOf("No Items", StringComparison.Ordinal) >= 0)
									{
										text12 = text12.Replace("No Items", "");
										text12 = text12.Replace(",,", "");
										text12 = text12 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblOrdI);
										text12 = text12.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
										text12 = text12.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
									}
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text12) && transferPreOrderFileToOrder && preOrderId > 0 && !string.IsNullOrWhiteSpace(selectedfilesDirectoryTypes))
						{
							List<CRMspSelectFilesDirectory_Result> list9 = Files.SelectFilesDirectory("", "", "", "10", preOrderId.ToString(), "0", "0", false);
							List<SelectListItem> list10 = new List<SelectListItem>();
							string[] array = selectedfilesDirectoryTypes.Split(new char[1] { '|' });
							foreach (string text16 in array)
							{
								if (!string.IsNullOrWhiteSpace(text16))
								{
									string[] array2 = text16.Split(new char[1] { '=' });
									list10.Add(new SelectListItem
									{
										Text = array2[0],
										Value = array2[1]
									});
								}
							}
							int orderId4 = int.Parse(text10);
							if (list9 != null && list9.Count > 0)
							{
								foreach (CRMspSelectFilesDirectory_Result itm in list9)
								{
									SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list10, (Func<SelectListItem, bool>)((SelectListItem x) => x.Text == itm.FileDirectoryID.ToString()));
									if (selectListItem != null)
									{
										text12 += ftpCopyPordFilesToOrd(itm, orderId4, preOrderId, itm.FileDirectoryID, int.Parse(selectListItem.Value));
									}
								}
							}
						}
						if (!string.IsNullOrEmpty(text12))
						{
							text12 = text12 + Messages.msgErrorInSendToAcc + "</br>" + text12;
							commonReturnResultViewModel.IsDone = true;
							commonReturnResultViewModel.Message = text12;
							commonReturnResultViewModel.Tag = text10;
						}
						else
						{
							commonReturnResultViewModel.IsDone = true;
							commonReturnResultViewModel.Tag = text10;
							WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result3 = new WSspReturnOrderFromPreOrder_Result();
							List<WSspReturnOrderFromPreOrder_Result> list11 = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(preOrderId, lCID, defLangID));
							text7 = "";
							if (list11 != null && Enumerable.Any<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list11))
							{
								wSspReturnOrderFromPreOrder_Result3 = Enumerable.LastOrDefault<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list11);
								if (list11.Count > 1)
								{
									foreach (WSspReturnOrderFromPreOrder_Result item13 in list11)
									{
										text7 = text7 + item13.ordNumber + ",";
									}
									if (!string.IsNullOrEmpty(text7) && text7.EndsWith(","))
									{
										text7 = text7.TrimEnd(new char[1] { ',' });
									}
								}
							}
							else
							{
								wSspReturnOrderFromPreOrder_Result3 = null;
							}
							if (wSspReturnOrderFromPreOrder_Result3 != null)
							{
								if (string.IsNullOrEmpty(text7))
								{
									text7 = wSspReturnOrderFromPreOrder_Result3.ordNumber.ToString();
								}
								commonReturnResultViewModel.Message = Messages.msgIssueOrderFormPreOrderWasSuccessful + "\r\n" + Messages.msgIssueOrderFormPreOrderOrdNumber + " " + text7;
								commonReturnResultViewModel.MessageExtra = wSspReturnOrderFromPreOrder_Result3.OrderInfo ?? "";
								WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(wSspReturnOrderFromPreOrder_Result3.OrderID, lCID, defLangID));
								if (wSspSelectOrderById_Result != null)
								{
									commonReturnResultViewModel.MessageExtraIds = wSspSelectOrderById_Result.ordProjectId.GetValueOrDefault().ToString();
								}
								if (addPrdValidity && !string.IsNullOrWhiteSpace(addPrdValidityPrjTitle))
								{
									int result16 = 0;
									int.TryParse(text10, out result16);
									if (result16 > 0)
									{
										string msg = "";
										Order.AddProjectProductHistoryFromOrder(result16, addPrdValidity, addPrdValidityPrjTitle, ref msg);
										if (!string.IsNullOrWhiteSpace(msg))
										{
											commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "\r\n" + msg;
										}
									}
								}
							}
							else
							{
								commonReturnResultViewModel.Message = Messages.msgIssueOrderFormPreOrderWasSuccessful + "\r\n" + Messages.msgIssueOrderFormPreOrderOrdNumber + " " + text11;
								WSspReturnOrderFromPreOrder_Result wSspReturnOrderFromPreOrder_Result4 = Enumerable.FirstOrDefault<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(preOrderId, lCID, defLangID));
								if (wSspReturnOrderFromPreOrder_Result4 != null)
								{
									commonReturnResultViewModel.MessageExtra = wSspReturnOrderFromPreOrder_Result4.OrderInfo ?? "";
									WSspSelectOrderById_Result wSspSelectOrderById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(wSspReturnOrderFromPreOrder_Result4.OrderID, lCID, defLangID));
									if (wSspSelectOrderById_Result2 != null)
									{
										commonReturnResultViewModel.MessageExtraIds = wSspSelectOrderById_Result2.ordProjectId.GetValueOrDefault().ToString();
									}
								}
								if (addPrdValidity && !string.IsNullOrWhiteSpace(addPrdValidityPrjTitle))
								{
									int result17 = 0;
									int.TryParse(text10, out result17);
									if (result17 > 0)
									{
										string msg2 = "";
										Order.AddProjectProductHistoryFromOrder(result17, addPrdValidity, addPrdValidityPrjTitle, ref msg2);
										if (!string.IsNullOrWhiteSpace(msg2))
										{
											commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "\r\n" + msg2;
										}
									}
								}
							}
							DateTime value6 = now;
							string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							short value7 = short.Parse(now.ToString("MM", new PersianCulture()));
							string appType6 = Configuration.AppType;
							short value8 = short.Parse(Financial.Get().Id.ToString());
							int userId = UserLogin.CurrentUser.UserId;
							CRMSpIEntities dbI = _dbI;
							bool? calcAutoScoreInIssue = true;
							bool? calcAutoScoreInVerify = false;
							dbI.ScorespInsertAndCalcOrderScores(null, null, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, userId, value8, value7, value6, registerDatePersian, appType6, lCID, defLangID, null, true, result);
						}
						if (VersionBuyer.MoneyBag && commonReturnResultViewModel.IsDone && !PreOrder.AddUserMoneyBagFormPord(preOrderId))
						{
							commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "\r\n" + Messages.msgErrorSaveUserMnBg;
						}
						commonReturnResultViewModel.MessageExtraI = "";
						int num5 = 0;
						int num6 = 0;
						decimal num7 = default(decimal);
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result3 = SysSeting.Get();
						if (cRMspSelectCrmsysSetting_Result3 != null && commonReturnResultViewModel.IsDone)
						{
							string karaAfzarLockSerial2 = Configuration.KaraAfzarLockSerial;
							string text17 = cRMspSelectCrmsysSetting_Result3.LockSerial ?? "";
							if (!string.IsNullOrWhiteSpace(text17) && text17 == karaAfzarLockSerial2)
							{
								Order.KaraAfzarCreateDomainandUrlForMob(preOrderId);
								string newSmsUserName = "";
								Order.KaraAfzarCreateUsernameAndPasswordForSmsOrdItem(preOrderId, ref newSmsUserName);
								WSspSelectOrderItemsByPordIdAndManufacturerName_Result wSspSelectOrderItemsByPordIdAndManufacturerName_Result = Order.KaraAfzarGetChargeSmsOrdItem(preOrderId);
								if (wSspSelectOrderItemsByPordIdAndManufacturerName_Result != null)
								{
									num5 = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderId;
									num6 = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.OrderItemID;
									num7 = wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIPriceSum.GetValueOrDefault();
									if (!wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIDeliveryUserId.HasValue && !wSspSelectOrderItemsByPordIdAndManufacturerName_Result.ordIDeliveryDate.HasValue)
									{
										commonReturnResultViewModel.MessageExtraI = num5 + "|" + num6 + "|" + num7 + "|" + newSmsUserName;
									}
								}
							}
						}
						new PendingOperations().StartPendingOperations();
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = "msgErrorInIssueOrderFormPreOrder".OrderMessages();
						commonReturnResultViewModel.Tag = "";
					}
				}
			}
		}
		catch (DbEntityValidationException e3)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e3);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		catch (Exception e4)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e4);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	public string ftpCopyPordFilesToOrd(CRMspSelectFilesDirectory_Result PordFileDir, int orderId, int pordId, int currFileDirId, int selectedFileDirType)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DateTime now = DateTime.Now;
		DateTime value = now;
		string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
		int userId = UserLogin.CurrentUser.UserId;
		int id = Financial.Get().Id;
		short value2 = short.Parse(Financial.Get().Id.ToString());
		short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
		string appType = Configuration.AppType;
		if (PordFileDir != null && PordFileDir.FileDirectoryID > 0 && pordId > 0 && VersionBuyer.AttachFiles)
		{
			ObjectParameter objectParameter = new ObjectParameter("InsertedId", -1);
			_dbI.WSspTransferPreOrderFileToOrderOneToOne(PordFileDir.TypeOprObjectId, orderId, currFileDirId, selectedFileDirType, userId, id, value2, value3, value, registerDatePersian, appType, lCID, objectParameter);
			FilesManager filesManager = new FilesManager();
			FacadeFTP facadeFTP = new FacadeFTP(Configuration.FacadeFtp);
			string pathFtp = Configuration.PathFtp;
			string userNameFtp = Configuration.UserNameFtp;
			string passwordFtp = Configuration.PasswordFtp;
			bool usePassiveFtp = Configuration.UsePassiveFtp;
			string text2 = "";
			string text3 = "";
			if (!string.IsNullOrEmpty(PordFileDir.FilePath) && !string.IsNullOrEmpty(PordFileDir.FileName))
			{
				string[] array = PordFileDir.FileName.Split(new char[1] { '.' });
				string text4 = PordFileDir.FilePath.Replace(PordFileDir.FileName, "");
				text4 += (text4.EndsWith("/") ? "" : "/");
				string text5 = text4.Split(new char[1] { '/' })[^2];
				string text6 = text4.Replace(text5 + "/", "");
				string text7 = PordFileDir.FilePath.ToLower().Replace(Configuration.PathFtp.ToLower(), "");
				text7 = Configuration.MainDirectoryPath + PordFileDir.FolderName + "/" + PordFileDir.FileName;
				if (text7 != "")
				{
					text2 = filesManager.SetNameDirectory(UserLogin.CurrentUser.UserId);
					if (filesManager.CreateDirectory(text2))
					{
						text3 = HttpContext.Current.Server.MapPath(text2 + "/" + objectParameter.Value.ToString());
						if (!facadeFTP.Download(pathFtp, userNameFtp, passwordFtp, text3, text7, overwrite: true, usePassiveFtp))
						{
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo = new DirectoryInfo(text3);
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
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
							text3 = "";
							try
							{
								_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
					}
				}
				if (!string.IsNullOrEmpty(text3))
				{
					bool flag = facadeFTP.ExistsDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					if (!flag)
					{
						flag = facadeFTP.CreateDirectoryInFtp(pathFtp, userNameFtp, passwordFtp, text6, text5, usePassiveFtp);
					}
					if (flag)
					{
						string text8 = orderId + "-" + objectParameter.Value.ToString() + "." + array[^1];
						if (facadeFTP.UploadFtpFormTable(pathFtp, userNameFtp, passwordFtp, text4 + text8, text3, usePassiveFtp))
						{
							_003C_003Ec__DisplayClass17_0 _003C_003Ec__DisplayClass17_ = new _003C_003Ec__DisplayClass17_0();
							string text9 = Configuration.PathFtp + text4 + text8;
							string fileName = text8;
							_003C_003Ec__DisplayClass17_.Id = 0;
							int.TryParse(objectParameter.Value.ToString(), out _003C_003Ec__DisplayClass17_.Id);
							DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
							ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "m");
							CrmFilesDirectory crmFilesDirectory2 = Queryable.FirstOrDefault<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass17_, typeof(_003C_003Ec__DisplayClass17_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmFilesDirectory2 != null)
							{
								text9 = text9.Trim().Replace(Configuration.PathFtp, "");
								crmFilesDirectory2.FilePath = text9;
								crmFilesDirectory2.FileName = fileName;
								_dbTbl.Entry(crmFilesDirectory2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
							}
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo2 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo2.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo2.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
						else
						{
							Exception e2 = new Exception(Messages.msgErrorUploadingFileInFtp + "  -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = text + "|" + Messages.frmErrorInSendingFile;
							try
							{
								_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
							}
							catch (Exception e3)
							{
								ErrorSignal.FromCurrentContext().Raise(e3);
							}
							if (!string.IsNullOrEmpty(text3))
							{
								text3 = HttpContext.Current.Server.MapPath(text2 + "/");
								if (Directory.Exists(text3))
								{
									DirectoryInfo directoryInfo3 = new DirectoryInfo(text3);
									FileInfo[] files = directoryInfo3.GetFiles();
									for (int i = 0; i < files.Length; i++)
									{
										files[i].Delete();
									}
									DirectoryInfo[] directories = directoryInfo3.GetDirectories();
									for (int i = 0; i < directories.Length; i++)
									{
										directories[i].Delete(recursive: true);
									}
									if (Directory.Exists(text3))
									{
										Directory.Delete(text3);
									}
								}
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorUploadingFileInFtp + " -  hostname: " + Configuration.PathFtp + " ,username: " + Configuration.UserNameFtp + " ,destination: " + text6 + " ,directoryName: " + text5);
						ErrorSignal.FromCurrentContext().Raise(e4);
						text = text + "|" + Messages.frmErrorInSendingFile;
						try
						{
							_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
						}
						catch (Exception e5)
						{
							ErrorSignal.FromCurrentContext().Raise(e5);
						}
						if (!string.IsNullOrEmpty(text3))
						{
							text3 = HttpContext.Current.Server.MapPath(text2 + "/");
							if (Directory.Exists(text3))
							{
								DirectoryInfo directoryInfo4 = new DirectoryInfo(text3);
								FileInfo[] files = directoryInfo4.GetFiles();
								for (int i = 0; i < files.Length; i++)
								{
									files[i].Delete();
								}
								DirectoryInfo[] directories = directoryInfo4.GetDirectories();
								for (int i = 0; i < directories.Length; i++)
								{
									directories[i].Delete(recursive: true);
								}
								if (Directory.Exists(text3))
								{
									Directory.Delete(text3);
								}
							}
						}
					}
				}
				else
				{
					try
					{
						_db.CRMspDeleteCrmFilesDirectory(PordFileDir.FileDirectoryID);
					}
					catch (Exception e6)
					{
						ErrorSignal.FromCurrentContext().Raise(e6);
					}
					text = text + "|" + Messages.frmErrorInSendingFile;
				}
			}
		}
		return text;
	}

	public List<SelectListItem> SelectFileDirectoryTypeByOprId(int fileDirectoryTypeOprId = 20)
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
			List<CRMspSelectFileDirectoryTypeByOprId_Result> list2 = Enumerable.ToList<CRMspSelectFileDirectoryTypeByOprId_Result>((IEnumerable<CRMspSelectFileDirectoryTypeByOprId_Result>)_db.CRMspSelectFileDirectoryTypeByOprId(fileDirectoryTypeOprId, lCID, result));
			if (list2 != null && list2.Count > 0)
			{
				foreach (CRMspSelectFileDirectoryTypeByOprId_Result item2 in list2)
				{
					SelectListItem item = new SelectListItem
					{
						Text = item2.FileDirectoryType,
						Value = item2.FileDirectoryTypeID.ToString(),
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

	public List<CRMspSelectFilesDirectory_Result> SelectFilesDirectory(int preOrderId = 0)
	{
		List<CRMspSelectFilesDirectory_Result> result = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (preOrderId > 0)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				result = Files.SelectFilesDirectory("", "", "", "10", preOrderId.ToString(), "0", "0", false);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	[HttpPost]
	public JsonResult EditProjectTitle(int id, string title, string titleLang, string prjPostFix, string prjPostFixLang, string prjRemindDate, string prjTitleGroup, string prjTitleGroupLang)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0156: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass20_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass20_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		commonReturnResultViewModel.IsDone = false;
		DateTime now = DateTime.Now;
		int num = 0;
		try
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(titleLang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(titleLang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = title.Trim(),
				LanguageId = lCID
			});
			List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(prjPostFixLang))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(prjPostFixLang);
			}
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = prjPostFix.Trim(),
				LanguageId = lCID
			});
			if (title == null && title == "")
			{
				num++;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.CheckprjTitle + "<br/>";
			}
			else if (!checkMultiLanguage(title, list))
			{
				num++;
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.CheckprjTitleLang + "<br/>";
			}
			List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(prjTitleGroupLang))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(prjTitleGroupLang);
			}
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = prjTitleGroup.Trim(),
				LanguageId = lCID
			});
			DateTime value = default(DateTime);
			DateTime dateTime = default(DateTime);
			string text = "";
			if (!string.IsNullOrWhiteSpace(prjRemindDate))
			{
				try
				{
					text = PersianDate.GetFormatetdDate(prjRemindDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text + " 00:00:00", new PersianCulture());
						prjRemindDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA"));
						prjRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US"));
						prjRemindDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					value = dateTime;
					prjRemindDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					num++;
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = string.Format(Messages.ErrorInFormat, Labels.IssueOrderPrjRemindDate) + "<br/>";
				}
			}
			if (num == 0)
			{
				_003C_003Ec__DisplayClass20_1 _003C_003Ec__DisplayClass20_ = new _003C_003Ec__DisplayClass20_1();
				DbSet<CrmProjects> crmProjects = _dbTbl.CrmProjects;
				ParameterExpression val = Expression.Parameter(typeof(CrmProjects), "model");
				_003C_003Ec__DisplayClass20_.project = Queryable.FirstOrDefault<CrmProjects>((IQueryable<CrmProjects>)crmProjects, Expression.Lambda<Func<CrmProjects, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass20_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (_003C_003Ec__DisplayClass20_.project != null)
				{
					_003C_003Ec__DisplayClass20_.project.prjTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_003C_003Ec__DisplayClass20_.project.prjPostFix = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					if (!UserLogin.IsUserAccess("frmDefineProjects", "actNotCanEditprjRemindDate", UserLogin.CurrentUser))
					{
						_003C_003Ec__DisplayClass20_.project.prjRemindDate = prjRemindDate;
						_003C_003Ec__DisplayClass20_.project.prjRemindDateTime = ((!string.IsNullOrWhiteSpace(prjRemindDate)) ? new DateTime?(value) : null);
					}
					_003C_003Ec__DisplayClass20_.project.UserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass20_.project.Year1 = short.Parse(Financial.Get().Id.ToString());
					_003C_003Ec__DisplayClass20_.project.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
					_003C_003Ec__DisplayClass20_.project.RegisterDate = now;
					_003C_003Ec__DisplayClass20_.project.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass20_.project.AppType = Configuration.AppType;
					_003C_003Ec__DisplayClass20_.project.prjTitleGroup = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
					_dbTbl.Entry(_003C_003Ec__DisplayClass20_.project).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass20_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass20_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass20_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
							val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
							CrmProjects_Lang crmProjects_Lang2 = Queryable.FirstOrDefault<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass20_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass20_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (crmProjects_Lang2 != null)
							{
								crmProjects_Lang2.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmProjects_Lang2.prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(crmProjects_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							crmProjects_Lang2 = new CrmProjects_Lang
							{
								LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
								ProjectID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.project.ProjectID,
								prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null),
								prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmProjects_Lang.Add(crmProjects_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					commonReturnResultViewModel.IsDone = true;
					commonReturnResultViewModel.Message = Messages.prjProjectEditSuccessFulMessage;
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				commonReturnResultViewModel.IsDone = false;
			}
		}
		catch (DbEntityValidationException e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		catch (Exception e3)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e3);
			commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
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

	public void GetProjectTitleLang(int pordId)
	{
		_003C_003Ec__DisplayClass22_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass22_0();
		CS_0024_003C_003E8__locals0.pordId = pordId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		string text4 = "";
		string text5 = "";
		string text6 = "";
		try
		{
			if (CS_0024_003C_003E8__locals0.pordId > 0)
			{
				DbSet<WSPreOrder> wSPreOrder = _dbTbl.WSPreOrder;
				ParameterExpression val = Expression.Parameter(typeof(WSPreOrder), "c");
				WSPreOrder wSPreOrder2 = Queryable.FirstOrDefault<WSPreOrder>((IQueryable<WSPreOrder>)wSPreOrder, Expression.Lambda<Func<WSPreOrder, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass22_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (wSPreOrder2 != null)
				{
					_003C_003Ec__DisplayClass22_1 _003C_003Ec__DisplayClass22_ = new _003C_003Ec__DisplayClass22_1();
					_003C_003Ec__DisplayClass22_.prj = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(wSPreOrder2.pordProjectId, result, result));
					if (_003C_003Ec__DisplayClass22_.prj != null)
					{
						DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
						val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
						List<CrmProjects_Lang> list = Enumerable.ToList<CrmProjects_Lang>((IEnumerable<CrmProjects_Lang>)Queryable.Where<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass22_, typeof(_003C_003Ec__DisplayClass22_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
						List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjTitle,
							LanguageId = item.LanguageID
						})));
						list2.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass22_.prj.prjTitle,
							LanguageId = result
						});
						List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjPostFix,
							LanguageId = item.LanguageID
						})));
						list3.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass22_.prj.prjPostFix,
							LanguageId = result
						});
						text3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						text = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						text2 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
						text4 = (_003C_003Ec__DisplayClass22_.prj.prjRemindDateTime.HasValue ? _003C_003Ec__DisplayClass22_.prj.prjRemindDateTime.Value.ToString("yyyy/MM/dd") : "");
						List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
						{
							Value = item.prjTitleGroup,
							LanguageId = item.LanguageID
						})));
						list4.Add(new CommonMultiLanguageViewModel
						{
							Value = _003C_003Ec__DisplayClass22_.prj.prjTitleGroup,
							LanguageId = result
						});
						text6 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "");
						text5 = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID))));
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrjTitleLang = text;
		base.ViewBag.prjPostFix = text3;
		base.ViewBag.prjPostFixLang = text2;
		base.ViewBag.prjRemindDate = text4;
		base.ViewBag.PrjTitleGroupLang = text5;
		base.ViewBag.PrjTitleGroup = text6;
	}

	public ActionResult IssueOrderWithDesiredNumberItems(int pordId)
	{
		GetPrdOrdIssueSetting(pordId);
		GetPrdIssueOrdFromIndexed(pordId);
		return View();
	}

	public ActionResult _PartialPreOrderItems(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemsWithOrdItemQuantity_Result> list = new List<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>)_dbI.WSspSelectPreOrderItemsWithOrdItemQuantity(pordId, lCID, result));
			if (list != null)
			{
				if (Enumerable.Any<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>)list))
				{
					foreach (WSspSelectPreOrderItemsWithOrdItemQuantity_Result item in list)
					{
						item.pordIValidityExpireDatePersian = (item.pordIValidityExpireDate.HasValue ? item.pordIValidityExpireDate.Value.ToString("yyyy/MM/dd") : "");
						item.pordIQuantityDesc = (item.pordIValidityExpireDate.HasValue ? item.pordIValidityExpireDate.Value.ToString("HH:mm") : "");
					}
				}
			}
			else
			{
				list = new List<WSspSelectPreOrderItemsWithOrdItemQuantity_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	[AjaxOnly]
	public JsonResult GetOrderInfo(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnOrderFromPreOrder_Result> list = new List<WSspReturnOrderFromPreOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)_db.WSspReturnOrderFromPreOrder(pordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnOrderFromPreOrder_Result>((IEnumerable<WSspReturnOrderFromPreOrder_Result>)list))
			{
				foreach (WSspReturnOrderFromPreOrder_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.RegisterDatePersian = item.OrderInfo;
					item.OrderInfo = string.Format(Labels.PordIssueOrderInfo, item.OrderOpr ?? "", item.ordNumber.ToString(), item.ordDate);
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
	public JsonResult GetProjectInfo(int prjId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCmsProjectInfoViewModel currentCmsProjectInfoViewModel = new CurrentCmsProjectInfoViewModel();
		try
		{
			_003C_003Ec__DisplayClass26_1 _003C_003Ec__DisplayClass26_ = new _003C_003Ec__DisplayClass26_1();
			_003C_003Ec__DisplayClass26_.currItem = Enumerable.FirstOrDefault<CRMspSelectCrmProjectsById_Result>((IEnumerable<CRMspSelectCrmProjectsById_Result>)_db.CRMspSelectCrmProjectsById(prjId, result, result));
			if (_003C_003Ec__DisplayClass26_.currItem != null)
			{
				currentCmsProjectInfoViewModel.IsFind = true;
				currentCmsProjectInfoViewModel.Message = "";
				currentCmsProjectInfoViewModel.ProjectID = _003C_003Ec__DisplayClass26_.currItem.ProjectID;
				DbSet<CrmProjects_Lang> crmProjects_Lang = _dbTbl.CrmProjects_Lang;
				ParameterExpression val = Expression.Parameter(typeof(CrmProjects_Lang), "c");
				List<CrmProjects_Lang> list = Enumerable.ToList<CrmProjects_Lang>((IEnumerable<CrmProjects_Lang>)Queryable.Where<CrmProjects_Lang>((IQueryable<CrmProjects_Lang>)crmProjects_Lang, Expression.Lambda<Func<CrmProjects_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass26_, typeof(_003C_003Ec__DisplayClass26_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjTitle,
					LanguageId = item.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass26_.currItem.prjTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjPostFix,
					LanguageId = item.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass26_.currItem.prjPostFix,
					LanguageId = result
				});
				currentCmsProjectInfoViewModel.prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				currentCmsProjectInfoViewModel.prjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				currentCmsProjectInfoViewModel.prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				currentCmsProjectInfoViewModel.prjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
				currentCmsProjectInfoViewModel.prjRemindDate = (_003C_003Ec__DisplayClass26_.currItem.prjRemindDateTime.HasValue ? _003C_003Ec__DisplayClass26_.currItem.prjRemindDateTime.Value.ToString("yyyy/MM/dd") : "");
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmProjects_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmProjects_Lang>)list, (Func<CrmProjects_Lang, CommonMultiLanguageViewModel>)((CrmProjects_Lang item) => new CommonMultiLanguageViewModel
				{
					Value = item.prjTitleGroup,
					LanguageId = item.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = _003C_003Ec__DisplayClass26_.currItem.prjTitleGroup,
					LanguageId = result
				});
				currentCmsProjectInfoViewModel.prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == currLangID)).Value : "");
				currentCmsProjectInfoViewModel.prjTitleGroup_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != currLangID))));
			}
			else
			{
				currentCmsProjectInfoViewModel.IsFind = false;
				currentCmsProjectInfoViewModel.Message = Messages.ErrorNotFound;
				currentCmsProjectInfoViewModel.ProjectID = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCmsProjectInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCmsProjectInfoViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCmsProjectInfoViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string GetCompanyMultiGroupIds(int cmpId = 0)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectCompanyMultiGroups_Result> list = Enumerable.ToList<CRMspSelectCompanyMultiGroups_Result>((IEnumerable<CRMspSelectCompanyMultiGroups_Result>)_dbI.CRMspSelectCompanyMultiGroups(cmpId, lCID, result));
			if (list != null && Enumerable.Any<CRMspSelectCompanyMultiGroups_Result>((IEnumerable<CRMspSelectCompanyMultiGroups_Result>)list))
			{
				foreach (CRMspSelectCompanyMultiGroups_Result item in list)
				{
					int result2 = 0;
					int.TryParse(item.CompanyGroupsMultiID.ToString(), out result2);
					if (result2 != 0)
					{
						text = text + result2 + ",";
					}
				}
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				if (text.StartsWith(","))
				{
					text = text.TrimStart(new char[1] { ',' });
				}
				if (text.EndsWith(","))
				{
					text = text.TrimEnd(new char[1] { ',' });
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
		return text;
	}

	[AjaxOnly]
	public JsonResult GetProductOrdIssueSetting(int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectProductOrdIssueSetting_Result wSspSelectProductOrdIssueSetting_Result = new WSspSelectProductOrdIssueSetting_Result();
		try
		{
			wSspSelectProductOrdIssueSetting_Result = Enumerable.FirstOrDefault<WSspSelectProductOrdIssueSetting_Result>((IEnumerable<WSspSelectProductOrdIssueSetting_Result>)_dbI.WSspSelectProductOrdIssueSetting(prdId, lCID, result));
			if (wSspSelectProductOrdIssueSetting_Result == null)
			{
				wSspSelectProductOrdIssueSetting_Result = new WSspSelectProductOrdIssueSetting_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(wSspSelectProductOrdIssueSetting_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetProductIssueOrdFromIndexed(int prdId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		WSspSelectProductIssueOrdFromIndexed_Result wSspSelectProductIssueOrdFromIndexed_Result = new WSspSelectProductIssueOrdFromIndexed_Result();
		try
		{
			wSspSelectProductIssueOrdFromIndexed_Result = Enumerable.FirstOrDefault<WSspSelectProductIssueOrdFromIndexed_Result>((IEnumerable<WSspSelectProductIssueOrdFromIndexed_Result>)_dbI.WSspSelectProductIssueOrdFromIndexed(prdId, lCID, result));
			if (wSspSelectProductIssueOrdFromIndexed_Result == null)
			{
				wSspSelectProductIssueOrdFromIndexed_Result = new WSspSelectProductIssueOrdFromIndexed_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(wSspSelectProductIssueOrdFromIndexed_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult AddPrdValidityToPrjPrdH(int ordId, string prjTitle, string prjTitleLang)
	{
		//IL_01ac: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel();
		try
		{
			if (ordId == 0)
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSpecified, "lblOrd".OrderLabels());
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			if (string.IsNullOrWhiteSpace(prjTitle))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.lblOrdProject);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = Financial.Get().Id;
			_ = UserLogin.CurrentUser.UserId;
			short.Parse(Financial.Get().Id.ToString());
			now.AddSeconds(-7.0);
			short.Parse(now.ToString("yyyy", new PersianCulture()));
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			List<CrmProjectTitles_LangViewModel> list2 = new List<CrmProjectTitles_LangViewModel>();
			if (!string.IsNullOrWhiteSpace(prjTitle))
			{
				CRMspSelectProjectTitlesByVal_Result cRMspSelectProjectTitlesByVal_Result = Enumerable.FirstOrDefault<CRMspSelectProjectTitlesByVal_Result>((IEnumerable<CRMspSelectProjectTitlesByVal_Result>)_dbI.CRMspSelectProjectTitlesByVal(prjTitle, lCID, defLangID));
				if (cRMspSelectProjectTitlesByVal_Result != null)
				{
					if (!string.IsNullOrEmpty(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CrmProjectTitles_LangViewModel>>(cRMspSelectProjectTitlesByVal_Result.ProjectTitles_Lang);
					}
					list2.Add(new CrmProjectTitles_LangViewModel
					{
						CrmProjectTitlesLangID = 0,
						ProjectTitleID = cRMspSelectProjectTitlesByVal_Result.ProjectTitleID,
						LanguageID = lCID,
						ProjectTitle = cRMspSelectProjectTitlesByVal_Result.ProjectTitle,
						ProjectTitleDesc = cRMspSelectProjectTitlesByVal_Result.ProjectTitleDesc
					});
				}
			}
			if (list2 != null && Enumerable.Any<CrmProjectTitles_LangViewModel>((IEnumerable<CrmProjectTitles_LangViewModel>)list2))
			{
				foreach (CrmProjectTitles_LangViewModel item in list2)
				{
					list.Add(new CommonMultiLanguageViewModel
					{
						Value = item.ProjectTitle,
						LanguageId = item.LanguageID
					});
				}
			}
			string text = "";
			text = ((!Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list)) ? "" : ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : ""));
			if (string.IsNullOrWhiteSpace(text))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.IssueOrdFromPordAddPrdValidityPrjTitle);
				commonReturnResultViewModel.Tag = "";
				return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
			}
			string msg = "";
			Order.AddProjectProductHistoryFromOrder(ordId, addPrdValidity: true, text, ref msg);
			if (!string.IsNullOrWhiteSpace(msg))
			{
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = commonReturnResultViewModel.Message + "\r\n" + msg;
			}
			else
			{
				commonReturnResultViewModel.IsDone = true;
				commonReturnResultViewModel.Message = Messages.msgSuccessAction;
			}
			commonReturnResultViewModel.MessageExtra = "";
			commonReturnResultViewModel.Tag = "";
		}
		catch (DbEntityValidationException e)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			commonReturnResultViewModel.IsDone = false;
			ErrorSignal.FromCurrentContext().Raise(e2);
			commonReturnResultViewModel.Message = Messages.frmErrorMessage;
		}
		JsonResult jsonResult = Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
