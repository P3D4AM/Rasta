using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Orders.Controllers;

public class OrderItemsValidityController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actShowValidityItems")]
	public ActionResult Index(int ordId)
	{
		base.ViewBag.OrderId = ordId;
		base.ViewBag.CompanyOrdersJs = GetOrderItemsValidityJs(ordId);
		return View();
	}

	public List<WSspSelectOrderItemsValidity_Result> GetOrderItemsValidity(int ordId)
	{
		List<WSspSelectOrderItemsValidity_Result> result = new List<WSspSelectOrderItemsValidity_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectOrderItemsValidity_Result> list = Enumerable.ToList<WSspSelectOrderItemsValidity_Result>((IEnumerable<WSspSelectOrderItemsValidity_Result>)_dbI.WSspSelectOrderItemsValidity(ordId, lCID, result2));
			if (list != null)
			{
				foreach (WSspSelectOrderItemsValidity_Result item in list)
				{
					item.ordDatePersian = (item.ordDate.HasValue ? item.ordDate?.ToString("yyyy/MM/dd") : "");
				}
				result = list;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public string GetOrderItemsValidityJs(int ordId)
	{
		return JsonConvert.SerializeObject(GetOrderItemsValidity(ordId));
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
