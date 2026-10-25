using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class InternalMessageDefineDefaultContextController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public int defContextid;

		public int currLangId;

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}

		internal bool _003CInsertEdit_003Eb__58(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__59(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangId;
		}

		internal bool _003CInsertEdit_003Eb__60(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_1
	{
		public CrmInternalMessageDefaultContext intmsgText;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass4_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass4_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__62(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__63(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__64(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__65(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__66(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__67(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__68(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__69(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__70(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__71(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__72(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__73(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__74(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__75(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__76(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__77(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__78(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__79(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__80(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__81(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__82(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__83(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__84(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__85(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__86(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__87(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__88(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__89(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__90(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__91(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmInternalMessageNew", ActionName = "actGotoDefaultContext")]
	public ActionResult Index(string currentTab = "A1")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.currentTab = currentTab;
		CRMspSelectInternalMessageDefaultContext_Result cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
		try
		{
			cRMspSelectInternalMessageDefaultContext_Result = Enumerable.FirstOrDefault<CRMspSelectInternalMessageDefaultContext_Result>((IEnumerable<CRMspSelectInternalMessageDefaultContext_Result>)_db.CRMspSelectInternalMessageDefaultContext(UserLogin.CurrentUser.UserId, lCID, result)) ?? new CRMspSelectInternalMessageDefaultContext_Result();
			if (cRMspSelectInternalMessageDefaultContext_Result != null)
			{
				if (string.IsNullOrEmpty(cRMspSelectInternalMessageDefaultContext_Result.AppType))
				{
					cRMspSelectInternalMessageDefaultContext_Result.AppType = Configuration.AppType;
				}
				cRMspSelectInternalMessageDefaultContext_Result.AppType = Configuration.GetAppType(cRMspSelectInternalMessageDefaultContext_Result.AppType);
				string text = cRMspSelectInternalMessageDefaultContext_Result.FirstRegisterUser ?? "";
				_ = cRMspSelectInternalMessageDefaultContext_Result.FirstRegisterDate;
				string text2 = cRMspSelectInternalMessageDefaultContext_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectInternalMessageDefaultContext_Result.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = cRMspSelectInternalMessageDefaultContext_Result.EditUser ?? "";
				_ = cRMspSelectInternalMessageDefaultContext_Result.RegisterDate;
				string text4 = cRMspSelectInternalMessageDefaultContext_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				cRMspSelectInternalMessageDefaultContext_Result.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + cRMspSelectInternalMessageDefaultContext_Result.AppType + ")  (" + text4 + ")";
			}
			else
			{
				cRMspSelectInternalMessageDefaultContext_Result = new CRMspSelectInternalMessageDefaultContext_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(cRMspSelectInternalMessageDefaultContext_Result);
	}

	[DynamicAuthorize(ControllerName = "frmInternalMessageNew", ActionName = "actGotoDefaultContext")]
	public ActionResult InsertEdit(int defContextid)
	{
		_003C_003Ec__DisplayClass3_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass3_0();
		CS_0024_003C_003E8__locals0.defContextid = defContextid;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangId = Thread.CurrentThread.CurrentCulture.LCID;
		CrmInternalMessageDefaultContextLanguageViewModel model = new CrmInternalMessageDefaultContextLanguageViewModel();
		try
		{
			DbSet<CrmInternalMessageDefaultContext_Lang> crmInternalMessageDefaultContext_Lang = _dbTbl.CrmInternalMessageDefaultContext_Lang;
			ParameterExpression val = Expression.Parameter(typeof(CrmInternalMessageDefaultContext_Lang), "c");
			List<CrmInternalMessageDefaultContext_Lang> list = Enumerable.ToList<CrmInternalMessageDefaultContext_Lang>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)Queryable.Where<CrmInternalMessageDefaultContext_Lang>((IQueryable<CrmInternalMessageDefaultContext_Lang>)crmInternalMessageDefaultContext_Lang, Expression.Lambda<Func<CrmInternalMessageDefaultContext_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			CrmInternalMessageDefaultContext crmInternalMessageDefaultContext = _dbTbl.CrmInternalMessageDefaultContext.Find(CS_0024_003C_003E8__locals0.defContextid);
			DateTime now = DateTime.Now;
			if (crmInternalMessageDefaultContext == null)
			{
				crmInternalMessageDefaultContext = new CrmInternalMessageDefaultContext();
				crmInternalMessageDefaultContext.UserId = UserLogin.CurrentUser.UserId;
				crmInternalMessageDefaultContext.Year1 = short.Parse(Financial.Get().Id.ToString());
				crmInternalMessageDefaultContext.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				crmInternalMessageDefaultContext.RegisterDate = now;
				crmInternalMessageDefaultContext.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				crmInternalMessageDefaultContext.InternalMessageDefaultContextId = CS_0024_003C_003E8__locals0.defContextid;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col1,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col1,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col2,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col2,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col3,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col3,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col4,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col4,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col5,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col5,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col6,
				LanguageId = item.LanguageID
			})));
			list7.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col6,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col7,
				LanguageId = item.LanguageID
			})));
			list8.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col7,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col8,
				LanguageId = item.LanguageID
			})));
			list9.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col8,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col9,
				LanguageId = item.LanguageID
			})));
			list10.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col9,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col10,
				LanguageId = item.LanguageID
			})));
			list11.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col10,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col11,
				LanguageId = item.LanguageID
			})));
			list12.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col11,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col12,
				LanguageId = item.LanguageID
			})));
			list13.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col12,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col13,
				LanguageId = item.LanguageID
			})));
			list14.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col13,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col14,
				LanguageId = item.LanguageID
			})));
			list15.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col14,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list16 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmInternalMessageDefaultContext_Lang>)list, (Func<CrmInternalMessageDefaultContext_Lang, CommonMultiLanguageViewModel>)((CrmInternalMessageDefaultContext_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.Col15,
				LanguageId = item.LanguageID
			})));
			list16.Add(new CommonMultiLanguageViewModel
			{
				Value = crmInternalMessageDefaultContext.Col15,
				LanguageId = result
			});
			model = new CrmInternalMessageDefaultContextLanguageViewModel
			{
				AppType = crmInternalMessageDefaultContext.AppType,
				LanguageID = crmInternalMessageDefaultContext.LanguageID,
				UserId = crmInternalMessageDefaultContext.UserId,
				GUId = crmInternalMessageDefaultContext.GUId,
				FirstRegisterDate = crmInternalMessageDefaultContext.FirstRegisterDate,
				RegisterDate = crmInternalMessageDefaultContext.RegisterDate,
				RegisterDatePersian = crmInternalMessageDefaultContext.RegisterDatePersian,
				Month1 = crmInternalMessageDefaultContext.Month1,
				Year1 = crmInternalMessageDefaultContext.Year1,
				FirstRegisterDatePersian = crmInternalMessageDefaultContext.FirstRegisterDatePersian,
				FirstRegisterUserId = crmInternalMessageDefaultContext.FirstRegisterUserId,
				InternalMessageDefaultContextId = crmInternalMessageDefaultContext.InternalMessageDefaultContextId,
				Col1 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col1_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col2_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col3_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col4_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col5_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col6 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col6_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col7_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col8 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col8_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col9 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col9_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col10 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col10_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col11 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col11_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col12 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col12_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col13 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col13_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col14 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col14_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId)))),
				Col15 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangId)).Value : ""),
				Col15_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list16, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangId))))
			};
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	[DynamicAuthorize(ControllerName = "frmInternalMessageNew", ActionName = "actGotoDefaultContext")]
	public ActionResult InsertEdit(CrmInternalMessageDefaultContextLanguageViewModel model)
	{
		//IL_007b: Unknown result type (might be due to invalid IL or missing references)
		//IL_00c0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0105: Unknown result type (might be due to invalid IL or missing references)
		//IL_014a: Unknown result type (might be due to invalid IL or missing references)
		//IL_018f: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0219: Unknown result type (might be due to invalid IL or missing references)
		//IL_025e: Unknown result type (might be due to invalid IL or missing references)
		//IL_02a3: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Unknown result type (might be due to invalid IL or missing references)
		//IL_032d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0372: Unknown result type (might be due to invalid IL or missing references)
		//IL_03b7: Unknown result type (might be due to invalid IL or missing references)
		//IL_03fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_0441: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangId);
		if (defLangId <= 0)
		{
			defLangId = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		try
		{
			if (base.ModelState.IsValid)
			{
				List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col1_Lang))
				{
					list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col1_Lang);
				}
				list.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col1,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col2_Lang))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col2_Lang);
				}
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col2,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col3_Lang))
				{
					list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col3_Lang);
				}
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col3,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col4_Lang))
				{
					list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col4_Lang);
				}
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col4,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col5_Lang))
				{
					list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col5_Lang);
				}
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col5,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list6 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col6_Lang))
				{
					list6 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col6_Lang);
				}
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col6,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list7 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col7_Lang))
				{
					list7 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col7_Lang);
				}
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col7,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list8 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col8_Lang))
				{
					list8 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col8_Lang);
				}
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col8,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list9 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col9_Lang))
				{
					list9 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col9_Lang);
				}
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col9,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list10 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col10_Lang))
				{
					list10 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col10_Lang);
				}
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col10,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list11 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col11_Lang))
				{
					list11 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col11_Lang);
				}
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col11,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list12 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col12_Lang))
				{
					list12 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col12_Lang);
				}
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col12,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list13 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col13_Lang))
				{
					list13 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col13_Lang);
				}
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col13,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list14 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col14_Lang))
				{
					list14 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col14_Lang);
				}
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col14,
					LanguageId = lCID
				});
				List<CommonMultiLanguageViewModel> list15 = new List<CommonMultiLanguageViewModel>();
				if (!string.IsNullOrEmpty(model.Col15_Lang))
				{
					list15 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(model.Col15_Lang);
				}
				list15.Add(new CommonMultiLanguageViewModel
				{
					Value = model.Col15,
					LanguageId = lCID
				});
				DateTime now = DateTime.Now;
				bool flag = false;
				if (num == 0)
				{
					_003C_003Ec__DisplayClass4_1 _003C_003Ec__DisplayClass4_ = new _003C_003Ec__DisplayClass4_1();
					if (model.InternalMessageDefaultContextId == 0)
					{
						flag = true;
						_003C_003Ec__DisplayClass4_.intmsgText = new CrmInternalMessageDefaultContext();
						_003C_003Ec__DisplayClass4_.intmsgText.UserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass4_.intmsgText.Year1 = short.Parse(Financial.Get().Id.ToString());
						_003C_003Ec__DisplayClass4_.intmsgText.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass4_.intmsgText.RegisterDate = now;
						_003C_003Ec__DisplayClass4_.intmsgText.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass4_.intmsgText.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass4_.intmsgText.FirstRegisterDate = now;
						_003C_003Ec__DisplayClass4_.intmsgText.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass4_.intmsgText.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass4_.intmsgText.GUId = Guid.NewGuid();
						_003C_003Ec__DisplayClass4_.intmsgText.ContextUserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass4_.intmsgText.LanguageID = defLangId;
						_003C_003Ec__DisplayClass4_.intmsgText.Col1 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col4 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col6 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col7 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col8 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col9 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col10 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col11 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col12 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col13 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col14 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col15 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_dbTbl.CrmInternalMessageDefaultContext.Add(_003C_003Ec__DisplayClass4_.intmsgText);
					}
					else
					{
						flag = false;
						_003C_003Ec__DisplayClass4_.intmsgText = _dbTbl.CrmInternalMessageDefaultContext.Find(model.InternalMessageDefaultContextId);
						_003C_003Ec__DisplayClass4_.intmsgText.UserId = UserLogin.CurrentUser.UserId;
						_003C_003Ec__DisplayClass4_.intmsgText.Year1 = short.Parse(Financial.Get().Id.ToString());
						_003C_003Ec__DisplayClass4_.intmsgText.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						_003C_003Ec__DisplayClass4_.intmsgText.RegisterDate = now;
						_003C_003Ec__DisplayClass4_.intmsgText.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						_003C_003Ec__DisplayClass4_.intmsgText.AppType = Configuration.AppType;
						_003C_003Ec__DisplayClass4_.intmsgText.Col1 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col2 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col3 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col4 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col5 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col6 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col7 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col8 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col9 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col10 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col11 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col12 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col13 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col14 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_003C_003Ec__DisplayClass4_.intmsgText.Col15 = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangId)).Value : null);
						_dbTbl.Entry(_003C_003Ec__DisplayClass4_.intmsgText).State = EntityState.Modified;
					}
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != defLangId))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass4_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass4_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass4_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							CrmInternalMessageDefaultContext_Lang crmInternalMessageDefaultContext_Lang;
							if (flag)
							{
								crmInternalMessageDefaultContext_Lang = new CrmInternalMessageDefaultContext_Lang();
								crmInternalMessageDefaultContext_Lang.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
								crmInternalMessageDefaultContext_Lang.InternalMessageDefaultContextId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.intmsgText.InternalMessageDefaultContextId;
							}
							else
							{
								DbSet<CrmInternalMessageDefaultContext_Lang> crmInternalMessageDefaultContext_Lang2 = _dbTbl.CrmInternalMessageDefaultContext_Lang;
								ParameterExpression val = Expression.Parameter(typeof(CrmInternalMessageDefaultContext_Lang), "c");
								crmInternalMessageDefaultContext_Lang = Queryable.FirstOrDefault<CrmInternalMessageDefaultContext_Lang>((IQueryable<CrmInternalMessageDefaultContext_Lang>)crmInternalMessageDefaultContext_Lang2, Expression.Lambda<Func<CrmInternalMessageDefaultContext_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass4_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmInternalMessageDefaultContext_Lang == null)
								{
									flag = true;
									crmInternalMessageDefaultContext_Lang = new CrmInternalMessageDefaultContext_Lang();
									crmInternalMessageDefaultContext_Lang.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
									crmInternalMessageDefaultContext_Lang.InternalMessageDefaultContextId = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.intmsgText.InternalMessageDefaultContextId;
								}
							}
							if (crmInternalMessageDefaultContext_Lang != null)
							{
								crmInternalMessageDefaultContext_Lang.Col1 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col2 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col3 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col4 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col5 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col6 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col7 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col8 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col9 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col10 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col11 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col12 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col13 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col14 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								crmInternalMessageDefaultContext_Lang.Col15 = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								if (flag)
								{
									_dbTbl.CrmInternalMessageDefaultContext_Lang.Add(crmInternalMessageDefaultContext_Lang);
								}
								else
								{
									_dbTbl.Entry(crmInternalMessageDefaultContext_Lang).State = EntityState.Modified;
								}
								_dbTbl.SaveChanges();
							}
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmInternalMessageDefaultContext", UserLogin.CurrentUser.UserId);
					base.ViewBag.SuccessfullcnvsDefContextEdit = Messages.frmFormBaseEditSuccessFulMessage;
				}
			}
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
			text = Messages.frmErrorMessage;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.frmErrorMessage;
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(model);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
