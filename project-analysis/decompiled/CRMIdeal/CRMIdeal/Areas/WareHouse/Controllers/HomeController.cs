using System;
using System.Collections;
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

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class HomeController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass3_0
	{
		public CRMspSelectSystemCrmProject_Result sysProject;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass6_0
	{
		public int id;

		public int currLangID;

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

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__12(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__14(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public WsWareHouseLanguageViewModel vm;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__13;

		public Func<Languages, bool> _003C_003E9__35;

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

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__13(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__35(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_1
	{
		public WsWareHouse model;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_2
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass7_1 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__15(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actwhDefineWareHouse")]
	public ActionResult Index()
	{
		int result = 0;
		string text = Enumerable.FirstOrDefault<string>((IEnumerable<string>)Enumerable.ToList<string>((IEnumerable<string>)_db.WSspSelectWHCnt()));
		if (text != null)
		{
			int.TryParse(text, out result);
		}
		int maxCountWarehouse = Configuration.MaxCountWarehouse;
		if (maxCountWarehouse != result)
		{
			try
			{
				_003C_003Ec__DisplayClass3_0 _003C_003Ec__DisplayClass3_ = new _003C_003Ec__DisplayClass3_0();
				_003C_003Ec__DisplayClass3_.sysProject = Enumerable.FirstOrDefault<CRMspSelectSystemCrmProject_Result>((IEnumerable<CRMspSelectSystemCrmProject_Result>)_db.CRMspSelectSystemCrmProject());
				if (_003C_003Ec__DisplayClass3_.sysProject != null)
				{
					DbSet<Projects> projects = _dbTbl.Projects;
					ParameterExpression val = Expression.Parameter(typeof(Projects), "c");
					Projects projects2 = Queryable.FirstOrDefault<Projects>((IQueryable<Projects>)projects, Expression.Lambda<Func<Projects, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass3_, typeof(_003C_003Ec__DisplayClass3_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					if (projects2 != null)
					{
						projects2.Value = maxCountWarehouse.ToString();
						_dbTbl.Entry(projects2).State = EntityState.Modified;
						_dbTbl.Configuration.ValidateOnSaveEnabled = false;
						_dbTbl.SaveChanges();
						_dbTbl.Configuration.ValidateOnSaveEnabled = true;
					}
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			result = maxCountWarehouse;
		}
		base.ViewBag.Cnt = result;
		return View();
	}

	public ActionResult WareHouseList_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<WSspSelectWareHouse_Result> list = new List<WSspSelectWareHouse_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(0, -1);
			if (list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list))
			{
				foreach (WSspSelectWareHouse_Result item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.WrhsLinkAccWhCode))
					{
						item.WrhsLinkAccWhCode = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccCodeWithComa(3, item.WrhsLinkAccWhCode);
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
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actDelete")]
	public string RemoveWareHouse(int id)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.id = id;
		string result = "";
		try
		{
			if (_003C_003Ec__DisplayClass5_.id > 0)
			{
				DbSet<WsWareHouse> wsWareHouse = _dbTbl.WsWareHouse;
				ParameterExpression val = Expression.Parameter(typeof(WsWareHouse), "c");
				if (Queryable.FirstOrDefault<WsWareHouse>((IQueryable<WsWareHouse>)wsWareHouse, Expression.Lambda<Func<WsWareHouse, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
				{
					try
					{
						mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)Enumerable.ToList<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteWsWareHouse(_003C_003Ec__DisplayClass5_.id)));
						if (mct_Result != null && mct_Result.Result > 0)
						{
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
							result = "1";
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
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			result = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int id = 0)
	{
		_003C_003Ec__DisplayClass6_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass6_0();
		CS_0024_003C_003E8__locals0.id = id;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		WsWareHouseLanguageViewModel wsWareHouseLanguageViewModel = new WsWareHouseLanguageViewModel();
		GetWrhsUsers();
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
		if (CS_0024_003C_003E8__locals0.id > 0)
		{
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actEdit"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DbSet<WsWareHouse_Lang> wsWareHouse_Lang = _dbTbl.WsWareHouse_Lang;
			ParameterExpression val = Expression.Parameter(typeof(WsWareHouse_Lang), "c");
			List<WsWareHouse_Lang> list = Enumerable.ToList<WsWareHouse_Lang>((IEnumerable<WsWareHouse_Lang>)Queryable.Where<WsWareHouse_Lang>((IQueryable<WsWareHouse_Lang>)wsWareHouse_Lang, Expression.Lambda<Func<WsWareHouse_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
			DbSet<WsWareHouse> wsWareHouse = _dbTbl.WsWareHouse;
			val = Expression.Parameter(typeof(WsWareHouse), "c");
			WsWareHouse wsWareHouse2 = Queryable.FirstOrDefault<WsWareHouse>((IQueryable<WsWareHouse>)wsWareHouse, Expression.Lambda<Func<WsWareHouse, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass6_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (wsWareHouse2 == null)
			{
				base.ViewBag.Error = Messages.ErrorNotFound;
				return null;
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WsWareHouse_Lang, CommonMultiLanguageViewModel>((IEnumerable<WsWareHouse_Lang>)list, (Func<WsWareHouse_Lang, CommonMultiLanguageViewModel>)((WsWareHouse_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.WrhsName,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = wsWareHouse2.WrhsName,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WsWareHouse_Lang, CommonMultiLanguageViewModel>((IEnumerable<WsWareHouse_Lang>)list, (Func<WsWareHouse_Lang, CommonMultiLanguageViewModel>)((WsWareHouse_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.WrhsAddress,
				LanguageId = item.LanguageID
			})));
			list3.Add(new CommonMultiLanguageViewModel
			{
				Value = wsWareHouse2.WrhsAddress,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WsWareHouse_Lang, CommonMultiLanguageViewModel>((IEnumerable<WsWareHouse_Lang>)list, (Func<WsWareHouse_Lang, CommonMultiLanguageViewModel>)((WsWareHouse_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.WrhsArea,
				LanguageId = item.LanguageID
			})));
			list4.Add(new CommonMultiLanguageViewModel
			{
				Value = wsWareHouse2.WrhsArea,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WsWareHouse_Lang, CommonMultiLanguageViewModel>((IEnumerable<WsWareHouse_Lang>)list, (Func<WsWareHouse_Lang, CommonMultiLanguageViewModel>)((WsWareHouse_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.WrhsPerson,
				LanguageId = item.LanguageID
			})));
			list5.Add(new CommonMultiLanguageViewModel
			{
				Value = wsWareHouse2.WrhsPerson,
				LanguageId = result
			});
			List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<WsWareHouse_Lang, CommonMultiLanguageViewModel>((IEnumerable<WsWareHouse_Lang>)list, (Func<WsWareHouse_Lang, CommonMultiLanguageViewModel>)((WsWareHouse_Lang item) => new CommonMultiLanguageViewModel
			{
				Value = item.WrhsDescription,
				LanguageId = item.LanguageID
			})));
			list6.Add(new CommonMultiLanguageViewModel
			{
				Value = wsWareHouse2.WrhsDescription,
				LanguageId = result
			});
			wsWareHouseLanguageViewModel = new WsWareHouseLanguageViewModel
			{
				WareHouseID = wsWareHouse2.WareHouseID,
				WrhsCode = wsWareHouse2.WrhsCode,
				WrhsPreTel = wsWareHouse2.WrhsPreTel,
				WrhsTel = wsWareHouse2.WrhsTel,
				WrhsTelSecond = wsWareHouse2.WrhsTelSecond,
				WrhsTelThird = wsWareHouse2.WrhsTelThird,
				WrhsFax = wsWareHouse2.WrhsFax,
				WrhsFaxSecond = wsWareHouse2.WrhsFaxSecond,
				IsFix = wsWareHouse2.IsFix,
				UserId = wsWareHouse2.UserId,
				Month1 = wsWareHouse2.Month1,
				FPId = wsWareHouse2.FPId,
				RegisterDate = wsWareHouse2.RegisterDate,
				RegisterDatePersian = wsWareHouse2.RegisterDatePersian,
				GUId = wsWareHouse2.GUId,
				AppType = wsWareHouse2.AppType,
				LanguageID = wsWareHouse2.LanguageID,
				FirstRegisterUserId = wsWareHouse2.FirstRegisterUserId,
				FirstRegisterDatePersian = wsWareHouse2.FirstRegisterDatePersian,
				FirstRegisterDate = wsWareHouse2.FirstRegisterDate,
				WrhsName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				WrhsName_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				WrhsAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				WrhsAddress_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				WrhsArea = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				WrhsArea_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				WrhsPerson = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				WrhsPerson_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				WrhsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				WrhsDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				WrhsDeActive = wsWareHouse2.WrhsDeActive,
				OrderView = wsWareHouse2.OrderView,
				WrhsUserId = wsWareHouse2.WrhsUserId,
				WrhsLinkAccWhCode = wsWareHouse2.WrhsLinkAccWhCode,
				WrhsLinkAccWhId = wsWareHouse2.WrhsLinkAccWhId,
				WrhsLinkAccWareHouses = wsWareHouse2.WrhsLinkAccWareHouses,
				WrhsLinkAccWhIdStr = wsWareHouse2.WrhsLinkAccWhIdStr,
				WrhsLinkAccWhName = wsWareHouse2.WrhsLinkAccWhName,
				WrhsLinkAccData = wsWareHouse2.WrhsLinkAccData
			};
		}
		else
		{
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actInsert"))
			{
				base.ViewBag.Error = Messages.NotAccessToPage;
				return null;
			}
			DateTime now = DateTime.Now;
			wsWareHouseLanguageViewModel = new WsWareHouseLanguageViewModel
			{
				FirstRegisterUserId = UserLogin.CurrentUser.UserId,
				UserId = UserLogin.CurrentUser.UserId,
				RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				RegisterDate = now,
				FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture()),
				FirstRegisterDate = now,
				AppType = Configuration.AppType
			};
		}
		SetRegisterInfo(wsWareHouseLanguageViewModel);
		return View(wsWareHouseLanguageViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actPost")]
	[ValidateAntiForgeryToken]
	public ActionResult InsertEdit(WsWareHouseLanguageViewModel vm)
	{
		//IL_0103: Unknown result type (might be due to invalid IL or missing references)
		//IL_0157: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ab: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ff: Unknown result type (might be due to invalid IL or missing references)
		//IL_0253: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass7_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass7_0();
		CS_0024_003C_003E8__locals0.vm = vm;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		GetWrhsUsers();
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
		List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsName_Lang))
		{
			list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WrhsName_Lang);
		}
		list.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.WrhsName,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsAddress_Lang))
		{
			list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WrhsAddress_Lang);
		}
		list2.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.WrhsAddress,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list3 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsArea_Lang))
		{
			list3 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WrhsArea_Lang);
		}
		list3.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.WrhsArea,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list4 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsPerson_Lang))
		{
			list4 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WrhsPerson_Lang);
		}
		list4.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.WrhsPerson,
			LanguageId = lCID
		});
		List<CommonMultiLanguageViewModel> list5 = new List<CommonMultiLanguageViewModel>();
		if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsDescription_Lang))
		{
			list5 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.vm.WrhsDescription_Lang);
		}
		list5.Add(new CommonMultiLanguageViewModel
		{
			Value = CS_0024_003C_003E8__locals0.vm.WrhsDescription,
			LanguageId = lCID
		});
		try
		{
			int? wrhsCId = null;
			if (UserLogin.CurrentUser != null)
			{
				wrhsCId = UserLogin.CurrentUser.UserLastCId;
			}
			if (string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.vm.WrhsName))
			{
				base.ViewBag.Error = Messages.CheckWrhsName + "<br/>";
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.vm.WrhsName, list))
			{
				base.ViewBag.Error = Messages.CheckWrhsNameLang + "<br/>";
				return View(CS_0024_003C_003E8__locals0.vm);
			}
			if (CS_0024_003C_003E8__locals0.vm.WareHouseID <= 0)
			{
				int result2 = 0;
				string text = Configuration.MaxCountWarehouse.ToString();
				if (text != null)
				{
					int.TryParse(text, out result2);
				}
				if (result2 == 0)
				{
					result2 = 1;
				}
				if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault() >= result2)
				{
					base.ViewBag.Error = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result2 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
					return View(CS_0024_003C_003E8__locals0.vm);
				}
			}
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				_003C_003Ec__DisplayClass7_1 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_1();
				_003C_003Ec__DisplayClass7_.model = new WsWareHouse();
				if (CS_0024_003C_003E8__locals0.vm.WareHouseID > 0)
				{
					DbSet<WsWareHouse> wsWareHouse = _dbTbl.WsWareHouse;
					ParameterExpression val = Expression.Parameter(typeof(WsWareHouse), "c");
					_003C_003Ec__DisplayClass7_.model = Queryable.FirstOrDefault<WsWareHouse>((IQueryable<WsWareHouse>)wsWareHouse, Expression.Lambda<Func<WsWareHouse, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
					bool result3 = false;
					bool result4 = false;
					bool.TryParse(_003C_003Ec__DisplayClass7_.model.WrhsDeActive.ToString(), out result3);
					bool.TryParse(CS_0024_003C_003E8__locals0.vm.WrhsDeActive.ToString(), out result4);
					if (result3 && !result4)
					{
						int result5 = 0;
						string text2 = Configuration.MaxCountWarehouse.ToString();
						if (text2 != null)
						{
							int.TryParse(text2, out result5);
						}
						if (result5 == 0)
						{
							result5 = 1;
						}
						if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.WSspReturnActiveWareHouseCount()).GetValueOrDefault() + 1 > result5)
						{
							base.ViewBag.Error = Messages.msgErrorInDefinitionIllegalwarehouse1 + " " + result5 + " " + Messages.msgErrorInDefinitionIllegalwarehouse2;
							return View(CS_0024_003C_003E8__locals0.vm);
						}
					}
				}
				_003C_003Ec__DisplayClass7_.model.UserId = UserLogin.CurrentUser.UserId;
				DateTime now = DateTime.Now;
				_003C_003Ec__DisplayClass7_.model.RegisterDate = now;
				_003C_003Ec__DisplayClass7_.model.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				_003C_003Ec__DisplayClass7_.model.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
				_003C_003Ec__DisplayClass7_.model.AppType = Configuration.AppType;
				_003C_003Ec__DisplayClass7_.model.WrhsCode = CS_0024_003C_003E8__locals0.vm.WrhsCode;
				_003C_003Ec__DisplayClass7_.model.WrhsPreTel = CS_0024_003C_003E8__locals0.vm.WrhsPreTel;
				_003C_003Ec__DisplayClass7_.model.WrhsTel = CS_0024_003C_003E8__locals0.vm.WrhsTel;
				_003C_003Ec__DisplayClass7_.model.WrhsTelSecond = CS_0024_003C_003E8__locals0.vm.WrhsTelSecond;
				_003C_003Ec__DisplayClass7_.model.WrhsTelThird = CS_0024_003C_003E8__locals0.vm.WrhsTelThird;
				_003C_003Ec__DisplayClass7_.model.WrhsFax = CS_0024_003C_003E8__locals0.vm.WrhsFax;
				_003C_003Ec__DisplayClass7_.model.WrhsFaxSecond = CS_0024_003C_003E8__locals0.vm.WrhsFaxSecond;
				_003C_003Ec__DisplayClass7_.model.IsFix = CS_0024_003C_003E8__locals0.vm.IsFix;
				_003C_003Ec__DisplayClass7_.model.WrhsName = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WrhsAddress = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WrhsArea = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WrhsPerson = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WrhsDescription = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
				_003C_003Ec__DisplayClass7_.model.WrhsDeActive = CS_0024_003C_003E8__locals0.vm.WrhsDeActive;
				_003C_003Ec__DisplayClass7_.model.WrhsUserId = CS_0024_003C_003E8__locals0.vm.WrhsUserId;
				if (VersionBuyer.LinkAcc && string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass7_.model.WrhsLinkAccWhIdStr) && _003C_003Ec__DisplayClass7_.model.WrhsLinkAccWhId.GetValueOrDefault() == 0 && string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass7_.model.WrhsLinkAccWareHouses))
				{
					_003C_003Ec__DisplayClass7_.model.WrhsLinkAccWhCode = CS_0024_003C_003E8__locals0.vm.WrhsLinkAccWhCode;
				}
				_003C_003Ec__DisplayClass7_.model.OrderView = CS_0024_003C_003E8__locals0.vm.OrderView;
				if (_003C_003Ec__DisplayClass7_.model.WareHouseID > 0)
				{
					_dbTbl.Entry(_003C_003Ec__DisplayClass7_.model).State = EntityState.Modified;
					_dbTbl.SaveChanges();
					using (List<Languages>.Enumerator enumerator = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
					{
						while (enumerator.MoveNext())
						{
							_003C_003Ec__DisplayClass7_2 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass7_2();
							CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass7_;
							CS_0024_003C_003E8__locals1.lang = enumerator.Current;
							DbSet<WsWareHouse_Lang> wsWareHouse_Lang = _dbTbl.WsWareHouse_Lang;
							ParameterExpression val = Expression.Parameter(typeof(WsWareHouse_Lang), "c");
							WsWareHouse_Lang wsWareHouse_Lang2 = Queryable.FirstOrDefault<WsWareHouse_Lang>((IQueryable<WsWareHouse_Lang>)wsWareHouse_Lang, Expression.Lambda<Func<WsWareHouse_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass7_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wsWareHouse_Lang2 != null)
							{
								wsWareHouse_Lang2.WrhsName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wsWareHouse_Lang2.WrhsAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wsWareHouse_Lang2.WrhsArea = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wsWareHouse_Lang2.WrhsPerson = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								wsWareHouse_Lang2.WrhsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
								_dbTbl.Entry(wsWareHouse_Lang2).State = EntityState.Modified;
								_dbTbl.SaveChanges();
								continue;
							}
							wsWareHouse_Lang2 = new WsWareHouse_Lang();
							wsWareHouse_Lang2.LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID;
							wsWareHouse_Lang2.WareHouseID = CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1.model.WareHouseID;
							wsWareHouse_Lang2.WrhsName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wsWareHouse_Lang2.WrhsAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wsWareHouse_Lang2.WrhsArea = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wsWareHouse_Lang2.WrhsPerson = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							wsWareHouse_Lang2.WrhsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
							_dbTbl.WsWareHouse_Lang.Add(wsWareHouse_Lang2);
							_dbTbl.SaveChanges();
						}
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
					base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
				}
				else
				{
					_003C_003Ec__DisplayClass7_.model.FPId = Financial.Get().Id;
					_003C_003Ec__DisplayClass7_.model.GUId = Guid.NewGuid();
					_003C_003Ec__DisplayClass7_.model.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
					_003C_003Ec__DisplayClass7_.model.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					_003C_003Ec__DisplayClass7_.model.FirstRegisterDate = now;
					_003C_003Ec__DisplayClass7_.model.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
					_003C_003Ec__DisplayClass7_.model.WrhsCId = wrhsCId;
					_dbTbl.WsWareHouse.Add(_003C_003Ec__DisplayClass7_.model);
					_dbTbl.SaveChanges();
					foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
					{
						WsWareHouse_Lang wsWareHouse_Lang3 = new WsWareHouse_Lang();
						wsWareHouse_Lang3.LanguageID = lang.LanguageID;
						wsWareHouse_Lang3.WareHouseID = _003C_003Ec__DisplayClass7_.model.WareHouseID;
						wsWareHouse_Lang3.WrhsName = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wsWareHouse_Lang3.WrhsAddress = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wsWareHouse_Lang3.WrhsArea = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wsWareHouse_Lang3.WrhsPerson = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						wsWareHouse_Lang3.WrhsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null);
						_dbTbl.WsWareHouse_Lang.Add(wsWareHouse_Lang3);
						_dbTbl.SaveChanges();
					}
					if (_003C_003Ec__DisplayClass7_.model.WareHouseID > 0)
					{
						DateTime value = now;
						string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						int id = Financial.Get().Id;
						short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
						string appType = Configuration.AppType;
						int userId = UserLogin.CurrentUser.UserId;
						_db.WSspInsertWareHouseUserPermissionForAllUsers(_003C_003Ec__DisplayClass7_.model.WareHouseID, userId, id, value2, value, registerDatePersian, appType, CS_0024_003C_003E8__locals0.defLangID);
					}
					CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
					base.ViewBag.Successfull = Messages.frmFormBaseInsertSuccessFulMessage;
				}
				CS_0024_003C_003E8__locals0.vm.UserId = _003C_003Ec__DisplayClass7_.model.UserId;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterUserId = _003C_003Ec__DisplayClass7_.model.FirstRegisterUserId;
				CS_0024_003C_003E8__locals0.vm.RegisterDate = _003C_003Ec__DisplayClass7_.model.RegisterDate;
				CS_0024_003C_003E8__locals0.vm.FirstRegisterDate = _003C_003Ec__DisplayClass7_.model.FirstRegisterDate;
				CS_0024_003C_003E8__locals0.vm.AppType = _003C_003Ec__DisplayClass7_.model.AppType;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		SetRegisterInfo(CS_0024_003C_003E8__locals0.vm);
		return View(CS_0024_003C_003E8__locals0.vm);
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

	public void SetRegisterInfo(WsWareHouseLanguageViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			string text3 = "";
			string text4 = "";
			string text5 = (model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId).ToString();
			_ = model.UserId;
			List<CRMspSelectUsersByIds_Result> list = CRMIdeal.Classes.Helper.User.SelectUsersByIds(text5 + "," + model.UserId);
			if (Enumerable.Any<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list))
			{
				model.FirstRegisterUserId = model.FirstRegisterUserId ?? UserLogin.CurrentUser.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.FirstRegisterUserId));
				text3 = ((cRMspSelectUsersByIds_Result != null) ? (cRMspSelectUsersByIds_Result.LName + ((cRMspSelectUsersByIds_Result.FName != null) ? (" " + cRMspSelectUsersByIds_Result.FName) : "")) : "");
				WsWareHouseLanguageViewModel wsWareHouseLanguageViewModel = model;
				_ = model.UserId;
				wsWareHouseLanguageViewModel.UserId = model.UserId;
				CRMspSelectUsersByIds_Result cRMspSelectUsersByIds_Result2 = Enumerable.FirstOrDefault<CRMspSelectUsersByIds_Result>((IEnumerable<CRMspSelectUsersByIds_Result>)list, (Func<CRMspSelectUsersByIds_Result, bool>)((CRMspSelectUsersByIds_Result c) => c.UserId == model.UserId));
				text4 = ((cRMspSelectUsersByIds_Result2 != null) ? (cRMspSelectUsersByIds_Result2.LName + ((cRMspSelectUsersByIds_Result2.FName != null) ? (" " + cRMspSelectUsersByIds_Result2.FName) : "")) : "");
			}
			string text6 = (model.FirstRegisterDate.HasValue ? model.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
			_ = model.RegisterDate;
			string text7 = model.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
			if (string.IsNullOrEmpty(model.AppType))
			{
				model.AppType = Configuration.AppType;
			}
			string text8 = Labels.AppType + ": " + Configuration.GetAppType(model.AppType);
			text = Labels.frmFirstRegisterUser + ": " + text3 + " (" + text6 + ")";
			text2 = Labels.frmRegisterUser + ": " + text4 + " (" + text8 + ") (" + text7 + ")";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FirstRegisterInfo = text;
		base.ViewBag.EditInfo = text2;
	}

	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actSetUserPermission")]
	public ActionResult WrhsUserPermissions(int whId)
	{
		base.ViewBag.WhId = whId;
		return View();
	}

	public ActionResult _PartialWrhsUserPermission(int whId)
	{
		GetUserList(whId);
		base.ViewBag.PermissionType = GetPermissionsType(whId);
		return PartialView();
	}

	public int GetPermissionsType(int whId)
	{
		int result = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouseUserPermissionsByWhId_Result> list = Enumerable.ToList<WSspSelectWareHouseUserPermissionsByWhId_Result>((IEnumerable<WSspSelectWareHouseUserPermissionsByWhId_Result>)_db.WSspSelectWareHouseUserPermissionsByWhId(whId, lCID, result2));
			if (list != null && Enumerable.Any<WSspSelectWareHouseUserPermissionsByWhId_Result>((IEnumerable<WSspSelectWareHouseUserPermissionsByWhId_Result>)list))
			{
				result = ((Enumerable.FirstOrDefault<WSspSelectWareHouseUserPermissionsByWhId_Result>((IEnumerable<WSspSelectWareHouseUserPermissionsByWhId_Result>)list, (Func<WSspSelectWareHouseUserPermissionsByWhId_Result, bool>)((WSspSelectWareHouseUserPermissionsByWhId_Result m) => !m.CrmUserId.HasValue)) != null) ? 1 : 2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetUserList(int whId)
	{
		List<MultiGroupItem> list = new List<MultiGroupItem>();
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
			foreach (WSspSelectActiveUsersForWrhsPermission_Result item2 in Enumerable.ToList<WSspSelectActiveUsersForWrhsPermission_Result>((IEnumerable<WSspSelectActiveUsersForWrhsPermission_Result>)_db.WSspSelectActiveUsersForWrhsPermission(whId, lCID, result, result2)))
			{
				MultiGroupItem item = new MultiGroupItem
				{
					title = item2.FullName,
					ischeck = (item2.UserHasPermission > 0),
					id = item2.UserId
				};
				list.Add(item);
			}
			base.ViewBag.UserList = list;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actSetUserPermission")]
	public string InsertWrhsUserPermissionForAllUsers(int whId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
			if (list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectWareHouse_Result>(Enumerable.Where<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result m) => !m.WrhsDeActive.HasValue || m.WrhsDeActive == false)));
			}
			int num = ((list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list)) ? Enumerable.Count<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list) : 0);
			if (!VersionBuyer.WareHouseUserPermission && num > 1)
			{
				return Messages.VersionBuyWithoutCount;
			}
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actSetUserPermission"))
			{
				return Messages.NotAccessToPage;
			}
			text = DeleteWrhsUserPermissionsByWhId(whId);
			if (text == "1")
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				int id = Financial.Get().Id;
				short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspInsertWareHouseUserPermissionForAllUsers(whId, userId, id, value2, value, registerDatePersian, appType, result);
				text = "1";
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return text;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actSetUserPermission")]
	public string DeleteWrhsUserPermissionsByWhId(int whId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
			if (list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectWareHouse_Result>(Enumerable.Where<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result m) => !m.WrhsDeActive.HasValue || m.WrhsDeActive == false)));
			}
			int num = ((list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list)) ? Enumerable.Count<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list) : 0);
			if (!VersionBuyer.WareHouseUserPermission && num > 1)
			{
				return Messages.VersionBuyWithoutCount;
			}
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actSetUserPermission"))
			{
				return Messages.NotAccessToPage;
			}
			_db.WSspDeleteWareHouseUserPermissionsByWhId(whId);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actSetUserPermission")]
	public string InsertWrhsUserPermissionForUsers(int whId, string crmUserIds)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
			if (list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectWareHouse_Result>(Enumerable.Where<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result m) => !m.WrhsDeActive.HasValue || m.WrhsDeActive == false)));
			}
			int num = ((list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list)) ? Enumerable.Count<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list) : 0);
			if (!VersionBuyer.WareHouseUserPermission && num > 1)
			{
				return Messages.VersionBuyWithoutCount;
			}
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actSetUserPermission"))
			{
				return Messages.NotAccessToPage;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			_db.WSspInsertWareHouseUserPermissionForUsers(whId, crmUserIds, userId, id, value2, value, registerDatePersian, appType, result);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineWareHouse", ActionName = "actSetUserPermission")]
	public string DeleteWrhsUserPermissionsForUsers(int whId, string crmUserIds)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse(-1, -1);
			if (list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list))
			{
				list = Enumerable.ToList<WSspSelectWareHouse_Result>(Enumerable.Where<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result m) => !m.WrhsDeActive.HasValue || m.WrhsDeActive == false)));
			}
			int num = ((list != null && Enumerable.Any<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list)) ? Enumerable.Count<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list) : 0);
			if (!VersionBuyer.WareHouseUserPermission && num > 1)
			{
				return Messages.VersionBuyWithoutCount;
			}
			if (!UserLogin.IsUserAccess("frmDefineWareHouse", "actSetUserPermission"))
			{
				return Messages.NotAccessToPage;
			}
			_db.WSspDeleteWareHouseUserPermissionsForUsers(whId, crmUserIds);
			return "1";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	[AjaxOnly]
	public JsonResult GetWrhsUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectActiveUsers_Result> list2 = Enumerable.ToList<CRMspSelectActiveUsers_Result>((IEnumerable<CRMspSelectActiveUsers_Result>)_db.CRMspSelectActiveUsers(lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectActiveUsers_Result, SelectListItem>((IEnumerable<CRMspSelectActiveUsers_Result>)list2, (Func<CRMspSelectActiveUsers_Result, SelectListItem>)((CRMspSelectActiveUsers_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WrhsUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
