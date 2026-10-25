using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace CRMIdeal.Areas.Orders.Controllers;

public class ChangePriceInItemController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actChangePriceInOrdItems")]
	public ActionResult Index(int ordId)
	{
		base.ViewBag.OrderId = ordId;
		return View();
	}

	public ActionResult OrderItemsList_Read([DataSourceRequest] DataSourceRequest request, int ordId)
	{
		List<WSspSelectOrderItems_Result> enumerable = new List<WSspSelectOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			enumerable = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actChangePriceInOrdItems")]
	public string ActChangePrice(int ordId, string itemIds, decimal amount = 0m, decimal pricePercent = 0m, int mode = 1)
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
			if (!UserLogin.IsUserAccess("frmOrder", "actChangePriceInOrdItems", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ordId > 0 && !string.IsNullOrEmpty(itemIds) && itemIds != ",")
			{
				if (Order.IsFixed(ordId))
				{
					return "msgErrorNotActiveOrd".OrderMessages();
				}
				if (Order.IsSentToLinkAccByAction(ordId))
				{
					string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
					return string.Format(Messages.msgErrorUnableChangeInSentToLinkAcc, linkAccSystemTitle);
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				_dbI.WSspChangePriceInOrderItems(ordId, mode, itemIds, amount, pricePercent, userId, id, value2, value, registerDatePersian, appType, objectParameter);
				if (int.Parse(objectParameter.Value.ToString()) > 0)
				{
					return Order.CalcAndSetOrderAmounts(ordId) ? "" : Messages.msgErrorInCalculation;
				}
				return Messages.msgErrorRunFunction;
			}
			return Messages.ErrorNotFound;
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
