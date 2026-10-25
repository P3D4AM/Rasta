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

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SalesFunnelStepsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_0
	{
		public CrmConversationStatusSalesFunnelStepsLanguageViewModel model;

		public int defLangID;

		public Func<Languages, bool> _003C_003E9__3;

		public Func<Languages, bool> _003C_003E9__11;

		internal bool _003CInsertEdit_003Eb__1(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__2(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__3(Languages c)
		{
			return c.LanguageID != defLangID;
		}

		internal bool _003CInsertEdit_003Eb__9(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__10(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == defLangID;
		}

		internal bool _003CInsertEdit_003Eb__11(Languages c)
		{
			return c.LanguageID != defLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass10_1
	{
		public Languages lang;

		public _003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals1;

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__6(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__7(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}

		internal bool _003CInsertEdit_003Eb__8(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == lang.LanguageID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass9_0
	{
		public int salesFunnelStepId;

		public int currLangID;

		internal bool _003CInsertEdit_003Eb__3(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__4(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CInsertEdit_003Eb__5(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actDefineCnvsSalesFunnelSteps")]
	public ActionResult Index()
	{
		return View();
	}

	public List<CRMspSelectConversationStatusSalesFunnelSteps_Result> ListSalesFunnelSteps()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectConversationStatusSalesFunnelSteps_Result> list = new List<CRMspSelectConversationStatusSalesFunnelSteps_Result>();
		try
		{
			list = Enumerable.ToList<CRMspSelectConversationStatusSalesFunnelSteps_Result>((IEnumerable<CRMspSelectConversationStatusSalesFunnelSteps_Result>)_dbII.CRMspSelectConversationStatusSalesFunnelSteps(lCID, result));
			foreach (CRMspSelectConversationStatusSalesFunnelSteps_Result item in list)
			{
				if (string.IsNullOrEmpty(item.AppType))
				{
					item.AppType = Configuration.AppType;
				}
				item.AppType = Configuration.GetAppType(item.AppType);
				string text = item.FirstRegisterUser ?? "";
				_ = item.FirstRegisterDate;
				string text2 = item.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.FirstRegisterDatePersian = text + " (" + text2 + ")";
				string text3 = item.EditUser ?? "";
				_ = item.RegisterDate;
				string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				item.RegisterDatePersian = text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
				item.SalesFunnelStepColor = Public.TColorToHex(item.SalesFunnelStepColor);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult SalesFunnelSteps_Read([DataSourceRequest] DataSourceRequest request)
	{
		return Json(((IEnumerable)ListSalesFunnelSteps()).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult SalesFunnelStepsList()
	{
		return Json(ListSalesFunnelSteps(), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actDelete")]
	public string ActDelete(int salesFunnelStepId)
	{
		string result = "";
		try
		{
			if (salesFunnelStepId > 0)
			{
				try
				{
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.CRMspDeleteConversationStatusSalesFunnelSteps(salesFunnelStepId));
					if (mct_II_Result != null && mct_II_Result.Result > 0)
					{
						result = "1";
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusSalesFunnelSteps");
					}
					else if (mct_II_Result != null && mct_II_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.msgErrorRunFunction;
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
			result = Messages.frmErrorMessage;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmDefineBaseInfo", ActionName = "actInsert,actEdit")]
	public ActionResult InsertEdit(int salesFunnelStepId = 0)
	{
		_003C_003Ec__DisplayClass9_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass9_0();
		CS_0024_003C_003E8__locals0.salesFunnelStepId = salesFunnelStepId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		DbSet<CrmConversationStatusSalesFunnelSteps> crmConversationStatusSalesFunnelSteps = _dbTbl.CrmConversationStatusSalesFunnelSteps;
		ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusSalesFunnelSteps), "c");
		List<CrmConversationStatusSalesFunnelSteps> list = Enumerable.ToList<CrmConversationStatusSalesFunnelSteps>((IEnumerable<CrmConversationStatusSalesFunnelSteps>)Queryable.Where<CrmConversationStatusSalesFunnelSteps>((IQueryable<CrmConversationStatusSalesFunnelSteps>)crmConversationStatusSalesFunnelSteps, Expression.Lambda<Func<CrmConversationStatusSalesFunnelSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
		CrmConversationStatusSalesFunnelStepsLanguageViewModel model = new CrmConversationStatusSalesFunnelStepsLanguageViewModel();
		_ = DateTime.Now;
		CrmConversationStatusSalesFunnelSteps crmConversationStatusSalesFunnelSteps2 = new CrmConversationStatusSalesFunnelSteps();
		GetConversationStatusGroups();
		try
		{
			if (CS_0024_003C_003E8__locals0.salesFunnelStepId == 0)
			{
				if (!UserLogin.IsUserAccess("frmDefineBaseInfo", "actInsert", UserLogin.CurrentUser))
				{
					return RedirectToAction("Login", "Account", (object)new
					{
						area = "",
						d = DateTime.Now
					});
				}
				crmConversationStatusSalesFunnelSteps2 = new CrmConversationStatusSalesFunnelSteps();
				crmConversationStatusSalesFunnelSteps2.SalesFunnelStepId = 0;
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
				DbSet<CrmConversationStatusSalesFunnelSteps> crmConversationStatusSalesFunnelSteps3 = _dbTbl.CrmConversationStatusSalesFunnelSteps;
				val = Expression.Parameter(typeof(CrmConversationStatusSalesFunnelSteps), "m");
				crmConversationStatusSalesFunnelSteps2 = Queryable.FirstOrDefault<CrmConversationStatusSalesFunnelSteps>((IQueryable<CrmConversationStatusSalesFunnelSteps>)crmConversationStatusSalesFunnelSteps3, Expression.Lambda<Func<CrmConversationStatusSalesFunnelSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass9_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
				if (crmConversationStatusSalesFunnelSteps2 == null)
				{
					crmConversationStatusSalesFunnelSteps2 = new CrmConversationStatusSalesFunnelSteps();
					crmConversationStatusSalesFunnelSteps2.SalesFunnelStepId = 0;
				}
			}
			List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmConversationStatusSalesFunnelSteps, CommonMultiLanguageViewModel>((IEnumerable<CrmConversationStatusSalesFunnelSteps>)list, (Func<CrmConversationStatusSalesFunnelSteps, CommonMultiLanguageViewModel>)((CrmConversationStatusSalesFunnelSteps item) => new CommonMultiLanguageViewModel
			{
				Value = item.SalesFunnelStepTitle,
				LanguageId = item.LanguageID
			})));
			list2.Add(new CommonMultiLanguageViewModel
			{
				Value = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepTitle,
				LanguageId = result
			});
			model = new CrmConversationStatusSalesFunnelStepsLanguageViewModel
			{
				SalesFunnelStepId = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepId,
				SalesFunnelStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
				SalesFunnelStepTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
				SalesFunnelStepColor = Public.TColorToHex(crmConversationStatusSalesFunnelSteps2.SalesFunnelStepColor),
				SalesFunnelStepStatusGroupId = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepStatusGroupId,
				SalesFunnelStepStatusIDs = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepStatusIDs,
				SalesFunnelStepOrder = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepOrder
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
	public ActionResult InsertEdit(CrmConversationStatusSalesFunnelStepsLanguageViewModel model)
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		_003C_003Ec__DisplayClass10_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass10_0();
		CS_0024_003C_003E8__locals0.model = model;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out CS_0024_003C_003E8__locals0.defLangID);
		if (CS_0024_003C_003E8__locals0.defLangID <= 0)
		{
			CS_0024_003C_003E8__locals0.defLangID = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		int num = 0;
		GetConversationStatusGroups();
		if (base.ModelState.IsValid)
		{
			List<CommonMultiLanguageViewModel> list = new List<CommonMultiLanguageViewModel>();
			if (!string.IsNullOrEmpty(CS_0024_003C_003E8__locals0.model.SalesFunnelStepTitle_Lang))
			{
				list = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(CS_0024_003C_003E8__locals0.model.SalesFunnelStepTitle_Lang);
			}
			list.Add(new CommonMultiLanguageViewModel
			{
				Value = CS_0024_003C_003E8__locals0.model.SalesFunnelStepTitle,
				LanguageId = lCID
			});
			if (CS_0024_003C_003E8__locals0.model.SalesFunnelStepTitle == null)
			{
				text = text + string.Format(Messages.ErrorEmpty, Labels.SalesFunnelStepTitle) + "<br/>";
				num++;
			}
			else if (!checkMultiLanguage(CS_0024_003C_003E8__locals0.model.SalesFunnelStepTitle, list))
			{
				text = text + string.Format(Messages.CheckFieldInLang, Labels.SalesFunnelStepTitle) + "<br>";
				num++;
			}
			List<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result> list2 = Enumerable.ToList<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result>((IEnumerable<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result>)_dbII.CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus(CS_0024_003C_003E8__locals0.model.SalesFunnelStepStatusIDs, CS_0024_003C_003E8__locals0.model.SalesFunnelStepId, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (list2 != null && Enumerable.Any<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result>((IEnumerable<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result>)list2))
			{
				num++;
				foreach (CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByStatus_Result item in list2)
				{
					text = text + string.Format(Messages.msgErrorDupCnvsStatusFunnelStepsStatus, item.Status ?? "", item.SalesFunnelStepTitle ?? "") + "<br/>";
				}
			}
			List<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result> list3 = Enumerable.ToList<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result>((IEnumerable<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result>)_dbII.CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder(CS_0024_003C_003E8__locals0.model.SalesFunnelStepOrder, CS_0024_003C_003E8__locals0.model.SalesFunnelStepId, lCID, CS_0024_003C_003E8__locals0.defLangID));
			if (list3 != null && Enumerable.Any<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result>((IEnumerable<CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result>)list3))
			{
				num++;
				foreach (CRMspCheckDuplicateCnvsStatusSalesFunnelStepsByOrder_Result item2 in list3)
				{
					text = text + string.Format(Messages.msgErrorDupCnvsStatusFunnelStepsOrder, item2.SalesFunnelStepTitle ?? "") + "<br/>";
				}
			}
			if (num == 0)
			{
				DateTime now = DateTime.Now;
				try
				{
					if (CS_0024_003C_003E8__locals0.model.SalesFunnelStepId > 0)
					{
						DbSet<CrmConversationStatusSalesFunnelSteps> crmConversationStatusSalesFunnelSteps = _dbTbl.CrmConversationStatusSalesFunnelSteps;
						ParameterExpression val = Expression.Parameter(typeof(CrmConversationStatusSalesFunnelSteps), "m");
						CrmConversationStatusSalesFunnelSteps crmConversationStatusSalesFunnelSteps2 = Queryable.FirstOrDefault<CrmConversationStatusSalesFunnelSteps>((IQueryable<CrmConversationStatusSalesFunnelSteps>)crmConversationStatusSalesFunnelSteps, Expression.Lambda<Func<CrmConversationStatusSalesFunnelSteps, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass10_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (crmConversationStatusSalesFunnelSteps2 != null)
						{
							crmConversationStatusSalesFunnelSteps2.UserId = UserLogin.CurrentUser.UserId;
							crmConversationStatusSalesFunnelSteps2.RegisterDate = now;
							crmConversationStatusSalesFunnelSteps2.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
							crmConversationStatusSalesFunnelSteps2.AppType = Configuration.AppType;
							crmConversationStatusSalesFunnelSteps2.Year1 = short.Parse(Financial.Get().Id.ToString());
							crmConversationStatusSalesFunnelSteps2.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
							crmConversationStatusSalesFunnelSteps2.SalesFunnelStepTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
							crmConversationStatusSalesFunnelSteps2.SalesFunnelStepStatusGroupId = CS_0024_003C_003E8__locals0.model.SalesFunnelStepStatusGroupId;
							crmConversationStatusSalesFunnelSteps2.SalesFunnelStepStatusIDs = CS_0024_003C_003E8__locals0.model.SalesFunnelStepStatusIDs;
							crmConversationStatusSalesFunnelSteps2.SalesFunnelStepOrder = CS_0024_003C_003E8__locals0.model.SalesFunnelStepOrder;
							crmConversationStatusSalesFunnelSteps2.SalesFunnelStepColor = Public.HexToColor(CS_0024_003C_003E8__locals0.model.SalesFunnelStepColor);
							_dbTbl.Entry(crmConversationStatusSalesFunnelSteps2).State = EntityState.Modified;
							_dbTbl.SaveChanges();
							using (List<Languages>.Enumerator enumerator3 = Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))).GetEnumerator())
							{
								while (enumerator3.MoveNext())
								{
									_003C_003Ec__DisplayClass10_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass10_1();
									CS_0024_003C_003E8__locals1.CS_0024_003C_003E8__locals1 = CS_0024_003C_003E8__locals0;
									CS_0024_003C_003E8__locals1.lang = enumerator3.Current;
									DbSet<CrmConversationStatusSalesFunnelSteps_Lang> crmConversationStatusSalesFunnelSteps_Lang = _dbTbl.CrmConversationStatusSalesFunnelSteps_Lang;
									val = Expression.Parameter(typeof(CrmConversationStatusSalesFunnelSteps_Lang), "c");
									CrmConversationStatusSalesFunnelSteps_Lang crmConversationStatusSalesFunnelSteps_Lang2 = Queryable.FirstOrDefault<CrmConversationStatusSalesFunnelSteps_Lang>((IQueryable<CrmConversationStatusSalesFunnelSteps_Lang>)crmConversationStatusSalesFunnelSteps_Lang, Expression.Lambda<Func<CrmConversationStatusSalesFunnelSteps_Lang, bool>>((Expression)(object)Expression.AndAlso((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass10_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmConversationStatusSalesFunnelSteps_Lang2 != null)
									{
										crmConversationStatusSalesFunnelSteps_Lang2.SalesFunnelStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null);
										_dbTbl.Entry(crmConversationStatusSalesFunnelSteps_Lang2).State = EntityState.Modified;
										_dbTbl.SaveChanges();
										continue;
									}
									CrmConversationStatusSalesFunnelSteps_Lang entity = new CrmConversationStatusSalesFunnelSteps_Lang
									{
										LanguageID = CS_0024_003C_003E8__locals1.lang.LanguageID,
										SalesFunnelStepId = crmConversationStatusSalesFunnelSteps2.SalesFunnelStepId,
										SalesFunnelStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals1.lang.LanguageID)).Value : null)
									};
									_dbTbl.CrmConversationStatusSalesFunnelSteps_Lang.Add(entity);
									_dbTbl.SaveChanges();
								}
							}
							CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusSalesFunnelSteps");
							base.ViewBag.Successfull = Messages.frmFormBaseEditSuccessFulMessage;
						}
						else
						{
							text = Messages.ErrorNotFound;
						}
					}
					else
					{
						CrmConversationStatusSalesFunnelSteps crmConversationStatusSalesFunnelSteps3 = new CrmConversationStatusSalesFunnelSteps();
						crmConversationStatusSalesFunnelSteps3.UserId = UserLogin.CurrentUser.UserId;
						crmConversationStatusSalesFunnelSteps3.RegisterDate = now;
						crmConversationStatusSalesFunnelSteps3.RegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmConversationStatusSalesFunnelSteps3.AppType = Configuration.AppType;
						crmConversationStatusSalesFunnelSteps3.Year1 = short.Parse(Financial.Get().Id.ToString());
						crmConversationStatusSalesFunnelSteps3.Month1 = short.Parse(now.ToString("MM", new PersianCulture()));
						crmConversationStatusSalesFunnelSteps3.LanguageID = CS_0024_003C_003E8__locals0.defLangID;
						crmConversationStatusSalesFunnelSteps3.FirstRegisterDate = now;
						crmConversationStatusSalesFunnelSteps3.FirstRegisterDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
						crmConversationStatusSalesFunnelSteps3.FirstRegisterUserId = UserLogin.CurrentUser.UserId;
						crmConversationStatusSalesFunnelSteps3.GUId = Guid.NewGuid();
						crmConversationStatusSalesFunnelSteps3.SalesFunnelStepTitle = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.defLangID)).Value : null);
						crmConversationStatusSalesFunnelSteps3.SalesFunnelStepStatusGroupId = CS_0024_003C_003E8__locals0.model.SalesFunnelStepStatusGroupId;
						crmConversationStatusSalesFunnelSteps3.SalesFunnelStepStatusIDs = CS_0024_003C_003E8__locals0.model.SalesFunnelStepStatusIDs;
						crmConversationStatusSalesFunnelSteps3.SalesFunnelStepOrder = CS_0024_003C_003E8__locals0.model.SalesFunnelStepOrder;
						crmConversationStatusSalesFunnelSteps3.SalesFunnelStepColor = Public.HexToColor(CS_0024_003C_003E8__locals0.model.SalesFunnelStepColor);
						_dbTbl.CrmConversationStatusSalesFunnelSteps.Add(crmConversationStatusSalesFunnelSteps3);
						_dbTbl.SaveChanges();
						foreach (Languages lang in Enumerable.ToList<Languages>(Enumerable.Where<Languages>((IEnumerable<Languages>)CRMIdeal.Cache.Setting.Language.Get(), (Func<Languages, bool>)((Languages c) => c.LanguageID != CS_0024_003C_003E8__locals0.defLangID))))
						{
							CrmConversationStatusSalesFunnelSteps_Lang entity2 = new CrmConversationStatusSalesFunnelSteps_Lang
							{
								LanguageID = lang.LanguageID,
								SalesFunnelStepId = crmConversationStatusSalesFunnelSteps3.SalesFunnelStepId,
								SalesFunnelStepTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == lang.LanguageID)).Value : null)
							};
							_dbTbl.CrmConversationStatusSalesFunnelSteps_Lang.Add(entity2);
							_dbTbl.SaveChanges();
						}
						CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("CrmConversationStatusSalesFunnelSteps");
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
		else
		{
			text = Messages.msgEnteredDataInvalid;
		}
		if (text != "")
		{
			base.ViewBag.Error = text;
		}
		return View(CS_0024_003C_003E8__locals0.model);
	}

	[AjaxOnly]
	public JsonResult GetConversationStatusGroups()
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
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2))
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
				{
					Text = item.ConversationStatusGroup,
					Value = item.ConversationStatusGroupID.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ConversationStatusGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetConversationStatuses(int groupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> data = new List<SelectListItem>();
		try
		{
			if (groupId != 0)
			{
				List<CRMspSelectConversationStatus_Result> list = Enumerable.ToList<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)_db.CRMspSelectConversationStatus(groupId, lCID, result));
				if (list != null && Enumerable.Any<CRMspSelectConversationStatus_Result>((IEnumerable<CRMspSelectConversationStatus_Result>)list))
				{
					data = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatus_Result>)list, (Func<CRMspSelectConversationStatus_Result, SelectListItem>)((CRMspSelectConversationStatus_Result item) => new SelectListItem
					{
						Text = item.Status,
						Value = item.ConversationStatusID.ToString()
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
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
}
