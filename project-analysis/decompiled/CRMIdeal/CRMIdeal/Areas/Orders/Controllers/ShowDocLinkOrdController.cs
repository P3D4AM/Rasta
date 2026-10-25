using System;
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
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.Orders.Controllers;

public class ShowDocLinkOrdController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actShowDocLinkOrd")]
	public ActionResult Index(int ordId)
	{
		base.ViewBag.OrderId = ordId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetDocLinkOrd(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		DocLinkOrdViewModel docLinkOrdViewModel = new DocLinkOrdViewModel();
		docLinkOrdViewModel.OrderInfo = new WSspSelectOrderById_Result();
		docLinkOrdViewModel.OrderItems = new List<WSspSelectOrderItems_Result>();
		docLinkOrdViewModel.Docs = new List<WSspReturnDocForSaleOrder_Result>();
		docLinkOrdViewModel.DocItems = new List<WSspReturnDocItemsForSaleOrderItems_Result>();
		docLinkOrdViewModel.IsFind = false;
		try
		{
			if (ordId != 0)
			{
				docLinkOrdViewModel.OrderInfo = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result));
				if (docLinkOrdViewModel.OrderInfo != null)
				{
					docLinkOrdViewModel.IsFind = true;
					docLinkOrdViewModel.OrderInfo.ordDate = (docLinkOrdViewModel.OrderInfo.ordDateTime.HasValue ? docLinkOrdViewModel.OrderInfo.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					docLinkOrdViewModel.OrderInfo.AppType = ((!string.IsNullOrWhiteSpace(docLinkOrdViewModel.OrderInfo.OrderOpr)) ? docLinkOrdViewModel.OrderInfo.OrderOpr : "lblOrd".OrderLabels()) + " (" + docLinkOrdViewModel.OrderInfo.ordNumber + ")";
					docLinkOrdViewModel.OrderInfo.ordCurrencyUnitIsDecimal = docLinkOrdViewModel.OrderInfo.ordCurrencyUnitIsDecimal.GetValueOrDefault();
					docLinkOrdViewModel.OrderItems = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result));
					if (docLinkOrdViewModel.OrderItems == null)
					{
						docLinkOrdViewModel.OrderItems = new List<WSspSelectOrderItems_Result>();
					}
					docLinkOrdViewModel.Docs = Enumerable.ToList<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)_db.WSspReturnDocForSaleOrder(ordId, lCID, result));
					if (docLinkOrdViewModel.Docs != null)
					{
						if (Enumerable.Any<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)docLinkOrdViewModel.Docs))
						{
							foreach (WSspReturnDocForSaleOrder_Result doc in docLinkOrdViewModel.Docs)
							{
								doc.DocDate = (doc.DocDateTime.HasValue ? doc.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
								doc.DocOpr = doc.DocNumber + " - " + ((!string.IsNullOrWhiteSpace(doc.DocOpr)) ? doc.DocOpr : Labels.lblWarehouseSheet) + " (" + doc.DocDate + ")";
							}
						}
					}
					else
					{
						docLinkOrdViewModel.Docs = new List<WSspReturnDocForSaleOrder_Result>();
					}
					docLinkOrdViewModel.DocItems = Enumerable.ToList<WSspReturnDocItemsForSaleOrderItems_Result>((IEnumerable<WSspReturnDocItemsForSaleOrderItems_Result>)_dbII.WSspReturnDocItemsForSaleOrderItems(ordId, lCID, result));
					if (docLinkOrdViewModel.DocItems != null)
					{
						if (Enumerable.Any<WSspReturnDocItemsForSaleOrderItems_Result>((IEnumerable<WSspReturnDocItemsForSaleOrderItems_Result>)docLinkOrdViewModel.DocItems))
						{
							foreach (WSspReturnDocItemsForSaleOrderItems_Result docItem in docLinkOrdViewModel.DocItems)
							{
								docItem.DocDate = (docItem.DocDateTime.HasValue ? docItem.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
								docItem.OprName = docItem.DocNumber + " - " + ((!string.IsNullOrWhiteSpace(docItem.OprName)) ? docItem.OprName : Labels.lblWarehouseSheet) + " (" + docItem.DocDate + ")";
							}
						}
					}
					else
					{
						docLinkOrdViewModel.DocItems = new List<WSspReturnDocItemsForSaleOrderItems_Result>();
					}
				}
				else
				{
					docLinkOrdViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				docLinkOrdViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			docLinkOrdViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(docLinkOrdViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult ActDeleteDocLinkOrd(int position, int ordId, int docId, int ordItemId, int docItemId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int value = 1;
			string actionName = "";
			switch (position)
			{
			case 1:
				actionName = "actDeleteDocLink";
				value = 1;
				break;
			case 2:
				value = 2;
				actionName = "actDeleteDocLinkAll";
				break;
			case 3:
				actionName = "actDeleteDocItemLink";
				value = 1;
				break;
			case 4:
				actionName = "actDeleteDocItemLinkAll";
				value = 2;
				break;
			}
			if (!UserLogin.IsUserAccess("frmShowDocLinkOrd", actionName, currentUser))
			{
				text = "";
				text2 = Messages.ErrorNotAccess;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = text2,
					Status = commonResultStatusViewModel
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (ordId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value2 = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value3 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				_ = Financial.Get().Id;
				int userId = currentUser.UserId;
				new ObjectParameter("ErrorMessage", "");
				mct_II_Result mct_II_Result = new mct_II_Result();
				switch (position)
				{
				case 1:
				case 2:
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteDocLinkOrder(value, ordId, docId, userId, value3, value2, registerDatePersian, appType));
					break;
				case 3:
				case 4:
					mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspDeleteDocItemLinkOrderItem(value, ordItemId, docItemId, userId, value3, value2, registerDatePersian, appType));
					break;
				}
				int result2 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result2);
				}
				text2 = ((result2 <= 0) ? Messages.msgErrorRunFunction : "");
			}
			else
			{
				text2 = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "0";
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text = "1";
				text2 = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "0";
			text2 = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
