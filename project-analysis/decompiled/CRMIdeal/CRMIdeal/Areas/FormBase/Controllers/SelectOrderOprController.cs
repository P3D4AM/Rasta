using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectOrderOprController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public ActionResult Index(string positionName, int ordOprId = 0, string selectedOrderOprIds = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			base.ViewBag.PositionName = positionName;
			base.ViewBag.OrdOprId = ordOprId;
			base.ViewBag.SelectedOrderOprIds = selectedOrderOprIds;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr(string positionName, int ordOprId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString()
				})));
			}
			if (list == null)
			{
				list = new List<SelectListItem>();
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
