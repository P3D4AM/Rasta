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

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class ChangePriceInItemController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actChangePriceInPordItems")]
	public ActionResult Index(int pordId)
	{
		base.ViewBag.PreOrderId = pordId;
		return View();
	}

	public ActionResult PreOrderItemsList_Read([DataSourceRequest] DataSourceRequest request, int pordId)
	{
		List<WSspSelectPreOrderItems_Result> enumerable = new List<WSspSelectPreOrderItems_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			enumerable = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(pordId, lCID, result));
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
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actChangePriceInPordItems")]
	public string ActChangePrice(int pordId, string itemIds, decimal amount = 0m, decimal pricePercent = 0m, int mode = 1)
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
			if (!UserLogin.IsUserAccess("frmPreOrder", "actChangePriceInPordItems", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (pordId > 0 && !string.IsNullOrEmpty(itemIds) && itemIds != ",")
			{
				if (PreOrder.IsFixed(pordId))
				{
					return Messages.msgErrorNotActiveProd;
				}
				if (PreOrder.IsSentToLinkAccByAction(pordId))
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
				_dbI.WSspChangePriceInPreOrderItems(pordId, mode, itemIds, amount, pricePercent, userId, id, value2, value, registerDatePersian, appType, objectParameter);
				if (int.Parse(objectParameter.Value.ToString()) > 0)
				{
					return PreOrder.CalcAndSetPreOrderAmounts(pordId) ? "" : Messages.msgErrorInCalculation;
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
