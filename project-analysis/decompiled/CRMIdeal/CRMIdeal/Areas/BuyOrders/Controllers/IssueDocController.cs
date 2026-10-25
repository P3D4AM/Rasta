using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;

namespace CRMIdeal.Areas.BuyOrders.Controllers;

public class IssueDocController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmBuyOrder", ActionName = "actIssueDoc")]
	public ActionResult Index(int borderId, int borderOprId)
	{
		WSspReturnBuyOrderOprInfoByOprId_Result wSspReturnBuyOrderOprInfoByOprId_Result = new WSspReturnBuyOrderOprInfoByOprId_Result();
		base.ViewBag.OrderId = borderId;
		base.ViewBag.OrderOprId = borderOprId;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)_dbI.WSspReturnBuyOrderItemsWareHouseCnt(borderId));
			if (list != null && !VersionBuyer.BordPlus)
			{
				int result2 = 0;
				int.TryParse(list.Count.ToString(), out result2);
				if (result2 > 1)
				{
					return null;
				}
			}
			if (borderId > 0)
			{
				wSspReturnBuyOrderOprInfoByOprId_Result = Enumerable.FirstOrDefault<WSspReturnBuyOrderOprInfoByOprId_Result>((IEnumerable<WSspReturnBuyOrderOprInfoByOprId_Result>)_db.WSspReturnBuyOrderOprInfoByOprId(borderOprId, lCID, result));
				if (wSspReturnBuyOrderOprInfoByOprId_Result == null)
				{
					wSspReturnBuyOrderOprInfoByOprId_Result = new WSspReturnBuyOrderOprInfoByOprId_Result();
				}
			}
			GetWareHouse(borderId);
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		base.ViewBag.IsBuying = VersionBuyer.WareHouse;
		return View(wSspReturnBuyOrderOprInfoByOprId_Result);
	}

	[AjaxOnly]
	public JsonResult GetWareHouse(int bordId = 0)
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
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, SelectListItem>)((WSspSelectWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
			WSspSelectBuyOrderItems_Result bordItem = Enumerable.FirstOrDefault<WSspSelectBuyOrderItems_Result>((IEnumerable<WSspSelectBuyOrderItems_Result>)_db.WSspSelectBuyOrderItems(bordId, lCID, result));
			if (bordItem != null)
			{
				if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list) && bordItem.bordIWHId.HasValue && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == bordItem.bordIWHId.ToString())) != null)
				{
					Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == bordItem.bordIWHId.ToString())).Selected = true;
				}
			}
			else if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHousesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string GetDraftControl(int borderId)
	{
		string result = "-1";
		if (borderId > 0)
		{
			try
			{
				result = Messages.msgErrorNotFindWarehouseDocForBuyOrder;
				WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result = new WSspReturnDocFromOrder_Result();
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDocFromOrder_Result> list = Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)_db.WSspReturnDocFromOrder(borderId, lCID, result2));
				if (list != null && Enumerable.Any<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list))
				{
					wSspReturnDocFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list);
					if (list.Count > 1)
					{
						foreach (WSspReturnDocFromOrder_Result item in list)
						{
							text = text + item.DocNumber + ",";
						}
						if (!string.IsNullOrEmpty(text) && text.EndsWith(","))
						{
							text = text.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnDocFromOrder_Result = null;
				}
				if (wSspReturnDocFromOrder_Result != null)
				{
					wSspReturnDocFromOrder_Result.DocDate = (wSspReturnDocFromOrder_Result.DocDateTime.HasValue ? wSspReturnDocFromOrder_Result.DocDateTime.Value.ToString("yyyyMMdd") : wSspReturnDocFromOrder_Result.DocDate);
					WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result2 = wSspReturnDocFromOrder_Result;
					_ = wSspReturnDocFromOrder_Result.RegisterDate;
					wSspReturnDocFromOrder_Result2.RegisterDatePersian = wSspReturnDocFromOrder_Result.RegisterDate.ToString("yyyyMMdd");
					if (string.IsNullOrEmpty(text))
					{
						text = wSspReturnDocFromOrder_Result.DocNumber.ToString();
					}
					result = Messages.msgIssueDocFormBuyOrderOfType + " " + wSspReturnDocFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDocFormBuyOrderWithNumber + " " + text + "\r\n" + Messages.msgIssueDocFormBuyOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDocFormBuyOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDocFormBuyOrderByUser + " " + wSspReturnDocFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDocFormBuyOrderBeenIissued + "|" + wSspReturnDocFromOrder_Result.DocID + "|" + wSspReturnDocFromOrder_Result.OprType;
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
		}
		return result;
	}

	[AjaxOnly]
	public string Send2ServerDoc(int borderId, string dateSelect, int whid, string valDetails)
	{
		//IL_00d1: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (borderId > 0)
		{
			try
			{
				int result2 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
				}
				if (!VersionBuyer.WareHouse)
				{
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
					if (Queryable.Any<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						result = "BV|" + Messages.VersionBuy;
						return result;
					}
				}
				List<DocIdKeyValueViewModel> list = new List<DocIdKeyValueViewModel>();
				if (!string.IsNullOrEmpty(valDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<DocIdKeyValueViewModel>>(valDetails);
				}
				string text = "";
				if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
				{
					foreach (DocIdKeyValueViewModel item in list)
					{
						string id = item.Id;
						_ = item.Type;
						_ = item.Tag;
						string value = item.Value;
						int result3 = 0;
						int.TryParse(id, out result3);
						double result4 = 0.0;
						double.TryParse(value, out result4);
						if (result4 > 0.0)
						{
							text = text + result3 + "," + result4 + "|";
						}
					}
				}
				result = Messages.msgErrorNotFindWarehouseDocForBuyOrder;
				WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result = new WSspReturnDocFromOrder_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result5);
				if (result5 <= 0)
				{
					result5 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDocFromOrder_Result> list2 = Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)_db.WSspReturnDocFromOrder(borderId, lCID, result5));
				if (list2 != null && Enumerable.Any<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list2))
				{
					wSspReturnDocFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list2);
					if (list2.Count > 1)
					{
						foreach (WSspReturnDocFromOrder_Result item2 in list2)
						{
							text2 = text2 + item2.DocNumber + ",";
						}
						if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnDocFromOrder_Result = null;
				}
				int result6 = 0;
				if (!UserLogin.IsUserAccess("frmIssueDoctFromOrder", "actIssueDocWithDiffQty", UserLogin.CurrentUser))
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspCheckBuyOrderHaveDoc(borderId));
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result6);
						if (result6 == 0)
						{
							wSspReturnDocFromOrder_Result = null;
						}
					}
				}
				if (wSspReturnDocFromOrder_Result != null && result6 == 1)
				{
					if (string.IsNullOrEmpty(text2))
					{
						text2 = wSspReturnDocFromOrder_Result.DocNumber.ToString();
					}
					result = "1|" + Labels.Error + " !!\r\n" + Messages.msgIssueDocFormBuyOrderOfType + " " + wSspReturnDocFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDocFormBuyOrderWithNumber + " " + text2 + "\r\n" + Messages.msgIssueDocFormBuyOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDocFormBuyOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDocFormBuyOrderByUser + " " + wSspReturnDocFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDocFormBuyOrderBeenIissued + "|" + wSspReturnDocFromOrder_Result.DocID + "|" + wSspReturnDocFromOrder_Result.OprType;
				}
				else
				{
					int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result7);
					if (result7 <= 0)
					{
						result7 = 1065;
					}
					int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
					if (dateSelect != null)
					{
						dateSelect = dateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					DateTime dateTime = default(DateTime);
					string text3 = "";
					try
					{
						if (!string.IsNullOrEmpty(dateSelect))
						{
							text3 = PersianDate.GetFormatetdDate(dateSelect.Replace("/", ""));
							dateSelect = lCID2 switch
							{
								1065 => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
								1025 => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
								_ => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
							};
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					DateTime now = DateTime.Now;
					ObjectParameter objectParameter = new ObjectParameter("insertedDocID", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("insertedDocNumber", 0);
					_db.WSspIssueDocFromBuyOrder(borderId, dateSelect, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, whid, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, objectParameter, objectParameter2, result7, text, (result2 != 0) ? new int?(result2) : null);
					int num = (int)objectParameter.Value;
					int num2 = (int)objectParameter2.Value;
					WSspReturnDocFromOrder_Result wSspReturnDocFromOrder_Result2 = new WSspReturnDocFromOrder_Result();
					List<WSspReturnDocFromOrder_Result> list3 = Enumerable.ToList<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)_db.WSspReturnDocFromOrder(borderId, lCID, result5));
					text2 = "";
					if (list3 != null && Enumerable.Any<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list3))
					{
						wSspReturnDocFromOrder_Result2 = Enumerable.LastOrDefault<WSspReturnDocFromOrder_Result>((IEnumerable<WSspReturnDocFromOrder_Result>)list3);
						if (list3.Count > 1)
						{
							foreach (WSspReturnDocFromOrder_Result item3 in list3)
							{
								text2 = text2 + item3.DocNumber + ",";
							}
							if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnDocFromOrder_Result2 = null;
					}
					if (wSspReturnDocFromOrder_Result2 != null)
					{
						if (string.IsNullOrEmpty(text2))
						{
							text2 = wSspReturnDocFromOrder_Result2.DocNumber.ToString();
						}
						result = "2|" + num + "|" + text2 + "|" + wSspReturnDocFromOrder_Result2.OprType;
					}
					else
					{
						result = "2|" + num + "|" + num2 + "|1";
					}
				}
			}
			catch (DbEntityValidationException e2)
			{
				ErrorSignal.FromCurrentContext().Raise((Exception)(object)e2);
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
		}
		return result;
	}

	public ActionResult _PartialBuyOrderItems(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectBuyOrderItemsWithDocItemQuantity_Result> model = new List<WSspSelectBuyOrderItemsWithDocItemQuantity_Result>();
		try
		{
			model = Enumerable.ToList<WSspSelectBuyOrderItemsWithDocItemQuantity_Result>((IEnumerable<WSspSelectBuyOrderItemsWithDocItemQuantity_Result>)_dbI.WSspSelectBuyOrderItemsWithDocItemQuantity(ordId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	public JsonResult GetDocInfo(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnDocForBuyOrder_Result> list = new List<WSspReturnDocForBuyOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnDocForBuyOrder_Result>((IEnumerable<WSspReturnDocForBuyOrder_Result>)_db.WSspReturnDocForBuyOrder(ordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnDocForBuyOrder_Result>((IEnumerable<WSspReturnDocForBuyOrder_Result>)list))
			{
				foreach (WSspReturnDocForBuyOrder_Result item in list)
				{
					item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.Info = string.Format(Labels.BordIssueDocInfoDesc, item.DocOpr ?? "", item.DocNumber.ToString(), item.DocDate);
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
