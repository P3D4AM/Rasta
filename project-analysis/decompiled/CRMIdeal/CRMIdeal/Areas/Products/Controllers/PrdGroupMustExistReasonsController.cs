using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Products.Controllers;

public class PrdGroupMustExistReasonsController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass5_0
	{
		public int reasonId;
	}

	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actShowPrdGroupMustExistReasons")]
	public ActionResult Index(int fgId)
	{
		base.ViewBag.FGroupId = fgId;
		GetReasonGroups();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetReasonGroups()
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
			List<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result> list2 = Enumerable.ToList<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result>)_db.WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll(lCID, result, Labels.All));
			list.AddRange(Enumerable.Select<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result, SelectListItem>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result>)list2, (Func<WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result, SelectListItem>)((WSspSelectPreOrderPrdGroupMustExistReasonGroupsWithAll_Result item) => new SelectListItem
			{
				Text = item.PrdGroupMustExistReasonGroupTitle,
				Value = item.PrdGroupMustExistReasonGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ReasonGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult PrdGroupMustExistReasons_Read([DataSourceRequest] DataSourceRequest request, int prdFirstGroupId, int reasonGroupId, string fDate, string tDate)
	{
		List<WSspSelectPreOrderPrdGroupMustExistReasons_Result> enumerable = new List<WSspSelectPreOrderPrdGroupMustExistReasons_Result>();
		try
		{
			if (prdFirstGroupId > 0 && !string.IsNullOrEmpty(fDate) && !string.IsNullOrEmpty(tDate))
			{
				DateTime value = DateTime.Parse(fDate);
				fDate = fDate.Replace("/", "");
				DateTime value2 = DateTime.Parse(tDate);
				tDate = tDate.Replace("/", "");
				if (Thread.CurrentThread.CurrentCulture.LCID != 1065)
				{
					tDate = value2.ToString("yyyyMMdd", new PersianCulture());
					fDate = value.ToString("yyyyMMdd", new PersianCulture());
				}
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				enumerable = Enumerable.ToList<WSspSelectPreOrderPrdGroupMustExistReasons_Result>((IEnumerable<WSspSelectPreOrderPrdGroupMustExistReasons_Result>)_db.WSspSelectPreOrderPrdGroupMustExistReasons(prdFirstGroupId, reasonGroupId, fDate, tDate, value, value2, lCID, result));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string DeletePrdGroupMustExistReasons(int reasonId)
	{
		_003C_003Ec__DisplayClass5_0 _003C_003Ec__DisplayClass5_ = new _003C_003Ec__DisplayClass5_0();
		_003C_003Ec__DisplayClass5_.reasonId = reasonId;
		string text = "";
		try
		{
			if (!UserLogin.IsUserAccess("frmShowPrdGroupMustExistReasons", "actDeleteReason"))
			{
				return Messages.NotAccessToPage;
			}
			DbSet<WSPreOrderPrdGroupMustExistReasons> wSPreOrderPrdGroupMustExistReasons = _dbTbl.WSPreOrderPrdGroupMustExistReasons;
			ParameterExpression val = Expression.Parameter(typeof(WSPreOrderPrdGroupMustExistReasons), "m");
			if (Queryable.FirstOrDefault<WSPreOrderPrdGroupMustExistReasons>((IQueryable<WSPreOrderPrdGroupMustExistReasons>)wSPreOrderPrdGroupMustExistReasons, Expression.Lambda<Func<WSPreOrderPrdGroupMustExistReasons, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass5_, typeof(_003C_003Ec__DisplayClass5_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })) != null)
			{
				try
				{
					if (Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_db.WSspDeletePreOrderPrdGroupMustExistReasons(_003C_003Ec__DisplayClass5_.reasonId)).GetValueOrDefault() > 0)
					{
						return "1";
					}
					return Messages.RedundancyMessage;
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					return Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					return Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			return Messages.frmErrorMessage + " - " + ex2.Message;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
