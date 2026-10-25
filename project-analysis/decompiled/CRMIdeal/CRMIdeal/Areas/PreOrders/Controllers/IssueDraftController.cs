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
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.PreOrders.Controllers;

public class IssueDraftController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actIssueDraft")]
	public ActionResult Index(int pordId)
	{
		new WSspReturnOrderOprInfoByOprId_Result();
		base.ViewBag.PordId = pordId;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)_dbI.WSspReturnPreOrderItemsWareHouseCnt(pordId));
			if (list != null && !VersionBuyer.PordPlus)
			{
				int result2 = 0;
				int.TryParse(list.Count.ToString(), out result2);
				if (result2 > 1)
				{
					base.ViewBag.Error = Messages.msgErrorUseProductsWarehouseInPord;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		GetDocOpr();
		base.ViewBag.IsBuying = VersionBuyer.WareHouse;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetDocOpr()
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
			List<WSspSelectDocOprByoprType_Result> list2 = Enumerable.ToList<WSspSelectDocOprByoprType_Result>((IEnumerable<WSspSelectDocOprByoprType_Result>)_db.WSspSelectDocOprByoprType(2, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDocOprByoprType_Result, SelectListItem>((IEnumerable<WSspSelectDocOprByoprType_Result>)list2, (Func<WSspSelectDocOprByoprType_Result, SelectListItem>)((WSspSelectDocOprByoprType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.DocOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DocOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string DraftControl(int pordId)
	{
		string result = "-1";
		if (pordId > 0)
		{
			try
			{
				result = Messages.msgErrorNotFindWarehouseDraftForPreOrder;
				WSspReturnDocFromPreOrder_Result wSspReturnDocFromPreOrder_Result = new WSspReturnDocFromPreOrder_Result();
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDocFromPreOrder_Result> list = Enumerable.ToList<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)_dbI.WSspReturnDocFromPreOrder(pordId, lCID, result2));
				if (list != null && Enumerable.Any<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list))
				{
					wSspReturnDocFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list);
					if (list.Count > 1)
					{
						foreach (WSspReturnDocFromPreOrder_Result item in list)
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
					wSspReturnDocFromPreOrder_Result = null;
				}
				if (wSspReturnDocFromPreOrder_Result != null)
				{
					wSspReturnDocFromPreOrder_Result.DocDate = (wSspReturnDocFromPreOrder_Result.DocDateTime.HasValue ? wSspReturnDocFromPreOrder_Result.DocDateTime.Value.ToString("yyyyMMdd") : wSspReturnDocFromPreOrder_Result.DocDate);
					WSspReturnDocFromPreOrder_Result wSspReturnDocFromPreOrder_Result2 = wSspReturnDocFromPreOrder_Result;
					_ = wSspReturnDocFromPreOrder_Result.RegisterDate;
					wSspReturnDocFromPreOrder_Result2.RegisterDatePersian = wSspReturnDocFromPreOrder_Result.RegisterDate.ToString("yyyyMMdd");
					if (string.IsNullOrEmpty(text))
					{
						text = wSspReturnDocFromPreOrder_Result.DocNumber.ToString();
					}
					result = Messages.msgIssueDraftFormPreOrderOfType + " " + wSspReturnDocFromPreOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormPreOrderWithNumber + " " + text + "\r\n" + Messages.msgIssueDraftFormPreOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromPreOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormPreOrderByUser + " " + wSspReturnDocFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormPreOrderBeenIssued + "|" + wSspReturnDocFromPreOrder_Result.DocID + "|" + wSspReturnDocFromPreOrder_Result.OprType;
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

	public ActionResult _PartialPreOrderItems(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemsWithDocItemQuantity_Result> model = new List<WSspSelectPreOrderItemsWithDocItemQuantity_Result>();
		try
		{
			model = Enumerable.ToList<WSspSelectPreOrderItemsWithDocItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithDocItemQuantity_Result>)_dbI.WSspSelectPreOrderItemsWithDocItemQuantity(pordId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	public JsonResult GetDocInfo(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnDocFromPreOrder_Result> list = new List<WSspReturnDocFromPreOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)_dbI.WSspReturnDocFromPreOrder(pordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list))
			{
				foreach (WSspReturnDocFromPreOrder_Result item in list)
				{
					item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.Info = string.Format(Labels.PordIssueDraftInfo, item.Opr ?? "", item.DocNumber.ToString(), item.DocDate);
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

	[AjaxOnly]
	public string Send2ServerDraft(int pordId, int docOprId, string dateSelect, string valDetails)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		string text = "-1";
		if (pordId > 0)
		{
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
				if (!VersionBuyer.WareHouse)
				{
					DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
					ParameterExpression val = Expression.Parameter(typeof(WSDoc), "c");
					if (Queryable.Any<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						return "BV|" + Messages.VersionBuy;
					}
				}
				List<DocIdKeyValueViewModel> list = new List<DocIdKeyValueViewModel>();
				if (!string.IsNullOrEmpty(valDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<DocIdKeyValueViewModel>>(valDetails);
				}
				string text2 = "";
				List<DocIdKeyValueDblViewModel> list2 = new List<DocIdKeyValueDblViewModel>();
				string pordItemList = "";
				if (Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
				{
					foreach (DocIdKeyValueViewModel item3 in list)
					{
						string id = item3.Id;
						_ = item3.Type;
						_ = item3.Tag;
						string value = item3.Value;
						int result3 = 0;
						int.TryParse(id, out result3);
						double result4 = 0.0;
						double.TryParse(value, out result4);
						if (result4 > 0.0)
						{
							text2 = text2 + result3 + "," + result4 + "|";
							DocIdKeyValueDblViewModel item = new DocIdKeyValueDblViewModel
							{
								Id = result3,
								Value = result4
							};
							list2.Add(item);
						}
					}
				}
				if (list2 != null && Enumerable.Any<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2))
				{
					pordItemList = JsonConvert.SerializeObject(Enumerable.ToList<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2));
				}
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					int result5 = 0;
					int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result5);
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanIssueDraftFromExpirePord", UserLogin.CurrentUser) && (result5 == 4 || (wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime < DateTime.Now)))
					{
						return "MOJ|" + Messages.msgErrorIssueDraftForCanceledPord;
					}
				}
				text = Messages.msgErrorNotFindWarehouseDraftForPreOrder;
				WSspReturnDocFromPreOrder_Result wSspReturnDocFromPreOrder_Result = new WSspReturnDocFromPreOrder_Result();
				string text3 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result6);
				if (result6 <= 0)
				{
					result6 = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDocFromPreOrder_Result> list3 = Enumerable.ToList<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)_dbI.WSspReturnDocFromPreOrder(pordId, lCID2, result6));
				if (list3 != null && Enumerable.Any<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list3))
				{
					wSspReturnDocFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list3);
					if (list3.Count > 1)
					{
						foreach (WSspReturnDocFromPreOrder_Result item4 in list3)
						{
							text3 = text3 + item4.DocNumber + ",";
						}
						if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
						{
							text3 = text3.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnDocFromPreOrder_Result = null;
				}
				int result7 = 0;
				if (!UserLogin.IsUserAccess("frmIssueDraftFromPreOrder", "actIssueDraftWithDiffQty", UserLogin.CurrentUser))
				{
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspCheckPreOrderHaveDraft(pordId));
					if (mct_I_Result != null)
					{
						int.TryParse(mct_I_Result.Result.ToString(), out result7);
						if (result7 == 0)
						{
							wSspReturnDocFromPreOrder_Result = null;
						}
					}
				}
				if (wSspReturnDocFromPreOrder_Result != null && result7 == 1)
				{
					if (string.IsNullOrEmpty(text3))
					{
						text3 = wSspReturnDocFromPreOrder_Result.DocNumber.ToString();
					}
					text = "1|" + Labels.Error + " !!\r\n" + Messages.msgIssueDraftFormPreOrderOfType + " " + wSspReturnDocFromPreOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormPreOrderWithNumber + " " + text3 + "\r\n" + Messages.msgIssueDraftFormPreOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromPreOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormPreOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDocFromPreOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormPreOrderByUser + " " + wSspReturnDocFromPreOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormPreOrderBeenIssued + "|" + wSspReturnDocFromPreOrder_Result.DocID + "|" + wSspReturnDocFromPreOrder_Result.OprType;
				}
				else
				{
					if (UserLogin.IsUserAccess("frmIssueDraftFromPreOrder", "actCanNotIssueDraftWithNoStock", UserLogin.CurrentUser))
					{
						CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
						bool flag = false;
						int num = 0;
						bool flag2 = false;
						if (cRMspSelectCrmsysSetting_Result != null)
						{
							flag = ((cRMspSelectCrmsysSetting_Result.InvStockFromLink.HasValue && cRMspSelectCrmsysSetting_Result.InvStockFromLink.GetValueOrDefault()) ? true : false);
							num = cRMspSelectCrmsysSetting_Result.LinkAccSystemId.GetValueOrDefault();
						}
						if (flag && num > 0)
						{
							int cmpId = 0;
							if (wSspSelectPreOrderWithId_Result != null)
							{
								cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
							}
							List<WSspSelectPreOrderItems_Result> list4 = Enumerable.ToList<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)_db.WSspSelectPreOrderItems(pordId, lCID2, result6));
							List<WSspSelectPreOrderItems_Result> list5 = new List<WSspSelectPreOrderItems_Result>();
							if (list4 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list4) && list != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
							{
								foreach (DocIdKeyValueViewModel item5 in list)
								{
									string id2 = item5.Id;
									_ = item5.Type;
									_ = item5.Tag;
									string value2 = item5.Value;
									int objId = 0;
									int.TryParse(id2, out objId);
									double result8 = 0.0;
									double.TryParse(value2, out result8);
									WSspSelectPreOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list4, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.PreOrderItemID == objId));
									if (linkAccitem == null || result8 == 0.0)
									{
										continue;
									}
									int num2 = linkAccitem.PrdKind.GetValueOrDefault(1);
									if (num2 == 0)
									{
										num2 = 1;
									}
									if (num2 != 1)
									{
										continue;
									}
									bool flag3 = true;
									if (Enumerable.FirstOrDefault<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list5, (Func<WSspSelectPreOrderItems_Result, bool>)((WSspSelectPreOrderItems_Result m) => m.pordIPrdId == linkAccitem.pordIPrdId && m.pordIWHId == linkAccitem.pordIWHId && (m.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (m.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && m.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag3 = false;
										foreach (WSspSelectPreOrderItems_Result item6 in list5)
										{
											if (item6.pordIPrdId == linkAccitem.pordIPrdId && item6.pordIWHId == linkAccitem.pordIWHId && (item6.pordILinkAccWHIdStr ?? "") == (linkAccitem.pordILinkAccWHIdStr ?? "") && (item6.pordITracing ?? "") == (linkAccitem.pordITracing ?? "") && item6.pordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.pordILinkAccSettingDBId.GetValueOrDefault())
											{
												item6.pordIQuantity = item6.pordIQuantity.GetValueOrDefault() + result8;
											}
										}
									}
									if (flag3)
									{
										WSspSelectPreOrderItems_Result item2 = new WSspSelectPreOrderItems_Result
										{
											PreOrderItemID = linkAccitem.PreOrderItemID,
											pordIQuantity = result8,
											pordIPrice = linkAccitem.pordIPrice,
											pordIPrdPriceGroupID = linkAccitem.pordIPrdPriceGroupID,
											pordIPrdId = linkAccitem.pordIPrdId,
											pordIWHId = linkAccitem.pordIWHId,
											pordILinkAccWHIdStr = linkAccitem.pordILinkAccWHIdStr,
											pordITracing = linkAccitem.pordITracing,
											pordILinkAccSettingDBId = linkAccitem.pordILinkAccSettingDBId,
											pordIDescriptionI = linkAccitem.pordIDescriptionI,
											PrdName = linkAccitem.PrdName
										};
										list5.Add(item2);
									}
								}
							}
							if (list5 != null && Enumerable.Any<WSspSelectPreOrderItems_Result>((IEnumerable<WSspSelectPreOrderItems_Result>)list5))
							{
								foreach (WSspSelectPreOrderItems_Result item7 in list5)
								{
									if (item7 == null)
									{
										continue;
									}
									double valueOrDefault = item7.pordIQuantity.GetValueOrDefault();
									ProductController productController = new ProductController();
									string text4 = "";
									switch (num)
									{
									case 3:
									{
										decimal prdPrice = default(decimal);
										double prdQuantity = 0.0;
										productController.TarazGetPrdQuantityAndPrice(item7.pordIPrdId, cmpId, item7.pordIWHId.GetValueOrDefault(), 0, ref prdPrice, ref prdQuantity, "pord", 0);
										text4 = prdQuantity.ToString();
										break;
									}
									case 4:
										text4 = productController.HolooGetPrdQuantity(item7.pordIPrdId, item7.pordILinkAccSettingDBId.GetValueOrDefault());
										break;
									case 6:
										text4 = productController.KyanGetPrdQuantity(item7.pordIPrdId, item7.pordIWHId.GetValueOrDefault());
										break;
									case 7:
										text4 = productController.PayvastGetPrdQuantity(item7.pordIPrdId, item7.pordIWHId.GetValueOrDefault());
										break;
									case 11:
										text4 = productController.ShomaranGetPrdQuantity(item7.pordIPrdId, item7.pordIWHId.GetValueOrDefault(), item7.pordILinkAccWHIdStr ?? "", item7.pordITracing ?? "", item7.pordIDescriptionI ?? "");
										break;
									case 12:
										text4 = productController.LinkAccGetPrdQuantity(num, item7.pordIPrdId, item7.pordIWHId.GetValueOrDefault(), item7.pordILinkAccWHIdStr ?? "", item7.pordITracing ?? "");
										break;
									default:
										text4 = productController.LinkAccGetPrdQuantity(num, item7.pordIPrdId, item7.pordIWHId.GetValueOrDefault(), item7.pordILinkAccWHIdStr ?? "", item7.pordITracing ?? "");
										break;
									}
									double result9 = 0.0;
									if (string.IsNullOrEmpty(text4))
									{
										continue;
									}
									if (text4 == Labels.frmError)
									{
										text4 = "0";
									}
									if (text4 != Labels.frmError)
									{
										double.TryParse(text4, out result9);
										if (result9 < valueOrDefault)
										{
											flag2 = true;
											return "MOJ|" + Messages.msgIssueDraftFormPreOrderImpossibilityIssued + "\r\n" + Messages.msgIssueDraftFormPreOrderLackInventory + "\r\n" + item7.PrdName;
										}
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							WSspControlPreOrderItemsStock_Result wSspControlPreOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlPreOrderItemsStock_Result>((IEnumerable<WSspControlPreOrderItemsStock_Result>)_db.WSspControlPreOrderItemsStock(pordId, lCID2, result6, pordItemList, result2));
							if (wSspControlPreOrderItemsStock_Result != null)
							{
								return "MOJ|" + Messages.msgIssueDraftFormPreOrderImpossibilityIssued + "\r\n" + Messages.msgIssueDraftFormPreOrderLackInventory + "\r\n" + wSspControlPreOrderItemsStock_Result.PrdName;
							}
						}
					}
					if (UserLogin.IsUserAccess("frmIssueDraftFromPreOrder", "actCanNotIssueDraftWithNoStockFromSold", UserLogin.CurrentUser))
					{
						string pordItemJson = "";
						if (list2 != null && Enumerable.Any<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2))
						{
							pordItemJson = JsonConvert.SerializeObject(Enumerable.ToList<DocIdKeyValueDblViewModel>((IEnumerable<DocIdKeyValueDblViewModel>)list2));
						}
						string text5 = "";
						text5 = PreOrder.ControlPreOrderItemsSoldStock(pordId, 4, "", pordItemJson);
						if (!string.IsNullOrWhiteSpace(text5))
						{
							return "MOJ|" + text5;
						}
					}
					if (dateSelect != null)
					{
						dateSelect = dateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					string docDate = "";
					DateTime value3 = default(DateTime);
					DateTime dateTime = default(DateTime);
					string text6 = "";
					try
					{
						if (!string.IsNullOrEmpty(dateSelect))
						{
							text6 = PersianDate.GetFormatetdDate(dateSelect.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								docDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								docDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value3 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						text = "-1";
					}
					DateTime now = DateTime.Now;
					DateTime value4 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id3 = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("InsertedDocId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedDocNumber", 0);
					mct_I_Result mct_I_Result2 = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspIssueDraftFromPreOrder(pordId, docOprId: docOprId, docDate: docDate, docDateTime: value3, pordItemList: pordItemList, userId: userId, month1: value5, fPId: id3, registerDate: value4, registerDatePersian: registerDatePersian, appType: appType, defaultLanguageID: result6, insertedDocId: objectParameter, insertedDocNumber: objectParameter2, centerId: (result2 != 0) ? new int?(result2) : null));
					int result10 = 0;
					if (mct_I_Result2 != null)
					{
						int.TryParse(mct_I_Result2.Result.ToString(), out result10);
					}
					int result11 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result11);
					}
					int result12 = 0;
					if (objectParameter2.Value != null)
					{
						int.TryParse(objectParameter2.Value.ToString(), out result12);
					}
					if (result10 <= 0)
					{
						return Messages.msgErrorRunFunction;
					}
					string text7 = "";
					WSspReturnDocFromPreOrder_Result wSspReturnDocFromPreOrder_Result2 = new WSspReturnDocFromPreOrder_Result();
					List<WSspReturnDocFromPreOrder_Result> list6 = Enumerable.ToList<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)_dbI.WSspReturnDocFromPreOrder(pordId, lCID2, result6));
					text3 = "";
					if (list6 != null && Enumerable.Any<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list6))
					{
						wSspReturnDocFromPreOrder_Result2 = Enumerable.LastOrDefault<WSspReturnDocFromPreOrder_Result>((IEnumerable<WSspReturnDocFromPreOrder_Result>)list6);
						if (list6.Count > 1)
						{
							foreach (WSspReturnDocFromPreOrder_Result item8 in list6)
							{
								text3 = text3 + item8.DocNumber + ",";
								text7 = text7 + item8.DocID + ",";
							}
							if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
							{
								text3 = text3.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrEmpty(text7) && text7.EndsWith(","))
							{
								text7 = text7.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnDocFromPreOrder_Result2 = null;
					}
					if (wSspReturnDocFromPreOrder_Result2 != null)
					{
						if (string.IsNullOrEmpty(text3))
						{
							text3 = wSspReturnDocFromPreOrder_Result2.DocNumber.ToString();
						}
						text = "2|" + result11 + "|" + text3 + "|" + wSspReturnDocFromPreOrder_Result2.OprType;
					}
					else
					{
						text = "2|" + result11 + "|" + result12 + "|1";
					}
					if (VersionBuyer.MoneyBag && result11 != 0 && !PreOrder.AddUserMoneyBagFormPord(pordId))
					{
						text = text + "|" + Messages.msgErrorSaveUserMnBg;
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				text = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return text;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
