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

namespace CRMIdeal.Areas.Orders.Controllers;

public class IssueDraftController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actIssueDraft")]
	public ActionResult Index(int orderId, int orderOprId)
	{
		WSspReturnOrderOprInfoByOprId_Result wSspReturnOrderOprInfoByOprId_Result = new WSspReturnOrderOprInfoByOprId_Result();
		base.ViewBag.OrderId = orderId;
		base.ViewBag.OrderOprId = orderOprId;
		base.ViewBag.RecordCount = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<int?> list = Enumerable.ToList<int?>((IEnumerable<int?>)_db.WSfnReturnOrderItemsWareHouseCnt(orderId));
			if (list != null && !VersionBuyer.IssueMultiDraftFromOrd)
			{
				int result2 = 0;
				int.TryParse(list.Count.ToString(), out result2);
				if (result2 > 1)
				{
					return null;
				}
			}
			if (orderId > 0)
			{
				wSspReturnOrderOprInfoByOprId_Result = Enumerable.FirstOrDefault<WSspReturnOrderOprInfoByOprId_Result>((IEnumerable<WSspReturnOrderOprInfoByOprId_Result>)Enumerable.ToList<WSspReturnOrderOprInfoByOprId_Result>((IEnumerable<WSspReturnOrderOprInfoByOprId_Result>)_db.WSspReturnOrderOprInfoByOprId(orderOprId, lCID, result)));
				if (wSspReturnOrderOprInfoByOprId_Result == null)
				{
					wSspReturnOrderOprInfoByOprId_Result = new WSspReturnOrderOprInfoByOprId_Result();
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
		FillDropdownIssueDraft(orderId);
		base.ViewBag.IsBuying = VersionBuyer.WareHouse;
		return View(wSspReturnOrderOprInfoByOprId_Result);
	}

	private void FillDropdownIssueDraft(int ordId = 0)
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
			WSspSelectOrderItems_Result ordItem = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(ordId, lCID, result));
			if (ordItem != null)
			{
				if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list) && ordItem.ordIWHId.HasValue && Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == ordItem.ordIWHId.ToString())) != null)
				{
					Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem m) => m.Value == ordItem.ordIWHId.ToString())).Selected = true;
				}
			}
			else if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
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
		base.ViewBag.WareHousesList = list;
	}

	[AjaxOnly]
	public string GetDraftControl(int orderId)
	{
		string result = "-1";
		if (orderId > 0)
		{
			try
			{
				result = "msgErrorNotFindWarehouseDraftForOrder".OrderMessages();
				WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result = new WSspReturnDraftFromOrder_Result();
				string text = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDraftFromOrder_Result> list = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)_db.WSspReturnDraftFromOrder(orderId, lCID, result2));
				if (list != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list))
				{
					wSspReturnDraftFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list);
					if (list.Count > 1)
					{
						foreach (WSspReturnDraftFromOrder_Result item in list)
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
					wSspReturnDraftFromOrder_Result = null;
				}
				if (wSspReturnDraftFromOrder_Result != null)
				{
					wSspReturnDraftFromOrder_Result.DocDate = (wSspReturnDraftFromOrder_Result.DocDateTime.HasValue ? wSspReturnDraftFromOrder_Result.DocDateTime.Value.ToString("yyyyMMdd") : wSspReturnDraftFromOrder_Result.DocDate);
					WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result2 = wSspReturnDraftFromOrder_Result;
					_ = wSspReturnDraftFromOrder_Result.RegisterDate;
					wSspReturnDraftFromOrder_Result2.RegisterDatePersian = wSspReturnDraftFromOrder_Result.RegisterDate.ToString("yyyyMMdd");
					if (string.IsNullOrEmpty(text))
					{
						text = wSspReturnDraftFromOrder_Result.DocNumber.ToString();
					}
					result = Messages.msgIssueDraftFormOrderOfType + " " + wSspReturnDraftFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormOrderWithNumber + " " + text + "\r\n" + Messages.msgIssueDraftFormOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDraftFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDraftFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormOrderByUser + " " + wSspReturnDraftFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormOrderBeenIissued + "|" + wSspReturnDraftFromOrder_Result.DocID + "|" + wSspReturnDraftFromOrder_Result.OprType;
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
	public string Send2ServerDraft(int orderId, string dateSelect, int whid, string valDetails)
	{
		//IL_010d: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (orderId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int result3 = 0;
				if (UserLogin.CurrentUser != null)
				{
					int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
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
					foreach (DocIdKeyValueViewModel item2 in list)
					{
						string id = item2.Id;
						_ = item2.Type;
						_ = item2.Tag;
						string value = item2.Value;
						int result4 = 0;
						int.TryParse(id, out result4);
						double result5 = 0.0;
						double.TryParse(value, out result5);
						if (result5 > 0.0)
						{
							text = text + result4 + "," + result5 + "|";
						}
					}
				}
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(orderId, lCID, result2));
				if (wSspSelectOrderById_Result != null)
				{
					int result6 = 0;
					int.TryParse(wSspSelectOrderById_Result.ordStatusId.ToString(), out result6);
					if (result6 == 4)
					{
						result = "MOJ|" + "msgErrorIssueDraftForCanceledOrd".OrderMessages();
						return result;
					}
				}
				result = "msgErrorNotFindWarehouseDraftForOrder".OrderMessages();
				WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result = new WSspReturnDraftFromOrder_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result7);
				if (result7 <= 0)
				{
					result7 = 1065;
				}
				int lCID2 = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnDraftFromOrder_Result> list2 = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)_db.WSspReturnDraftFromOrder(orderId, lCID2, result7));
				if (list2 != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list2))
				{
					wSspReturnDraftFromOrder_Result = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list2);
					if (list2.Count > 1)
					{
						foreach (WSspReturnDraftFromOrder_Result item3 in list2)
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
					wSspReturnDraftFromOrder_Result = null;
				}
				mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspCheckOrderHaveDraft(orderId));
				int result8 = 0;
				if (mct_I_Result != null)
				{
					int.TryParse(mct_I_Result.Result.ToString(), out result8);
					if (result8 == 0)
					{
						wSspReturnDraftFromOrder_Result = null;
					}
				}
				if (wSspReturnDraftFromOrder_Result != null && result8 == 1)
				{
					if (string.IsNullOrEmpty(text2))
					{
						text2 = wSspReturnDraftFromOrder_Result.DocNumber.ToString();
					}
					result = "1|" + Labels.Error + " !!\r\n" + Messages.msgIssueDraftFormOrderOfType + " " + wSspReturnDraftFromOrder_Result.Opr + "\r\n" + Messages.msgIssueDraftFormOrderWithNumber + " " + text2 + "\r\n" + Messages.msgIssueDraftFormOrderDate + " " + PersianDate.GetFormatetdDate(wSspReturnDraftFromOrder_Result.DocDate) + "\r\n" + Messages.msgIssueDraftFormOrderInDate + " " + PersianDate.GetFormatetdDate(wSspReturnDraftFromOrder_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueDraftFormOrderByUser + " " + wSspReturnDraftFromOrder_Result.UserName + "\r\n" + Messages.msgIssueDraftFormOrderBeenIissued + "|" + wSspReturnDraftFromOrder_Result.DocID + "|" + wSspReturnDraftFromOrder_Result.OprType;
				}
				else
				{
					if (UserLogin.IsUserAccess("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStock", UserLogin.CurrentUser))
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
							WSspSelectOrderById_Result wSspSelectOrderById_Result2 = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(orderId, lCID2, result7));
							if (wSspSelectOrderById_Result2 != null)
							{
								cmpId = wSspSelectOrderById_Result2.ordCompanyId;
							}
							List<WSspSelectOrderItems_Result> list3 = Enumerable.ToList<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)_db.WSspSelectOrderItems(orderId, lCID2, result7));
							List<WSspSelectOrderItems_Result> list4 = new List<WSspSelectOrderItems_Result>();
							if (list3 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3) && list != null && Enumerable.Any<DocIdKeyValueViewModel>((IEnumerable<DocIdKeyValueViewModel>)list))
							{
								foreach (DocIdKeyValueViewModel item4 in list)
								{
									string id2 = item4.Id;
									_ = item4.Type;
									_ = item4.Tag;
									string value2 = item4.Value;
									int objId = 0;
									int.TryParse(id2, out objId);
									double result9 = 0.0;
									double.TryParse(value2, out result9);
									WSspSelectOrderItems_Result linkAccitem = Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list3, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.OrderItemID == objId));
									if (linkAccitem == null || result9 == 0.0)
									{
										continue;
									}
									bool flag3 = true;
									if (Enumerable.FirstOrDefault<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list4, (Func<WSspSelectOrderItems_Result, bool>)((WSspSelectOrderItems_Result m) => m.ordIPrdId == linkAccitem.ordIPrdId && m.ordIWHId == linkAccitem.ordIWHId && (m.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (m.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && m.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())) != null)
									{
										flag3 = false;
										foreach (WSspSelectOrderItems_Result item5 in list4)
										{
											if (item5.ordIPrdId == linkAccitem.ordIPrdId && item5.ordIWHId == linkAccitem.ordIWHId && (item5.ordILinkAccWHIdStr ?? "") == (linkAccitem.ordILinkAccWHIdStr ?? "") && (item5.ordITracing ?? "") == (linkAccitem.ordITracing ?? "") && item5.ordILinkAccSettingDBId.GetValueOrDefault() == linkAccitem.ordILinkAccSettingDBId.GetValueOrDefault())
											{
												item5.ordIQuantity = item5.ordIQuantity.GetValueOrDefault() + result9;
											}
										}
									}
									if (flag3)
									{
										WSspSelectOrderItems_Result item = new WSspSelectOrderItems_Result
										{
											OrderItemID = linkAccitem.OrderItemID,
											ordIQuantity = result9,
											ordIPrice = linkAccitem.ordIPrice,
											ordIPrdPriceGroupID = linkAccitem.ordIPrdPriceGroupID,
											ordIPrdId = linkAccitem.ordIPrdId,
											ordIWHId = linkAccitem.ordIWHId,
											ordILinkAccWHIdStr = linkAccitem.ordILinkAccWHIdStr,
											ordITracing = linkAccitem.ordITracing,
											ordILinkAccSettingDBId = linkAccitem.ordILinkAccSettingDBId,
											ordIDescriptionI = linkAccitem.ordIDescriptionI,
											PrdName = linkAccitem.PrdName
										};
										list4.Add(item);
									}
								}
							}
							if (list4 != null && Enumerable.Any<WSspSelectOrderItems_Result>((IEnumerable<WSspSelectOrderItems_Result>)list4))
							{
								foreach (WSspSelectOrderItems_Result item6 in list4)
								{
									if (item6 == null)
									{
										continue;
									}
									double valueOrDefault = item6.ordIQuantity.GetValueOrDefault();
									ProductController productController = new ProductController();
									string text3 = "";
									item6.ordITracing = ConvertCharacter.DecodeTracing(item6.ordITracing);
									switch (num)
									{
									case 3:
									{
										decimal prdPrice = default(decimal);
										double prdQuantity = 0.0;
										productController.TarazGetPrdQuantityAndPrice(item6.ordIPrdId, cmpId, item6.ordIWHId.GetValueOrDefault(), 0, ref prdPrice, ref prdQuantity, "pord", 0);
										text3 = prdQuantity.ToString();
										break;
									}
									case 4:
										text3 = productController.HolooGetPrdQuantity(item6.ordIPrdId, item6.ordILinkAccSettingDBId.GetValueOrDefault());
										break;
									case 6:
										text3 = productController.KyanGetPrdQuantity(item6.ordIPrdId, item6.ordIWHId.GetValueOrDefault());
										break;
									case 7:
										text3 = productController.PayvastGetPrdQuantity(item6.ordIPrdId, item6.ordIWHId.GetValueOrDefault());
										break;
									case 11:
										text3 = productController.ShomaranGetPrdQuantity(item6.ordIPrdId, item6.ordIWHId.GetValueOrDefault(), item6.ordILinkAccWHIdStr ?? "", item6.ordITracing ?? "", item6.ordIDescriptionI ?? "");
										break;
									case 12:
										text3 = productController.LinkAccGetPrdQuantity(num, item6.ordIPrdId, item6.ordIWHId.GetValueOrDefault(), item6.ordILinkAccWHIdStr ?? "", item6.ordITracing ?? "");
										break;
									default:
										text3 = productController.LinkAccGetPrdQuantity(num, item6.ordIPrdId, item6.ordIWHId.GetValueOrDefault(), item6.ordILinkAccWHIdStr ?? "", item6.ordITracing ?? "");
										break;
									}
									double result10 = 0.0;
									if (string.IsNullOrEmpty(text3))
									{
										continue;
									}
									if (text3 == Labels.frmError)
									{
										text3 = "0";
									}
									if (text3 != Labels.frmError)
									{
										double.TryParse(text3, out result10);
										if (result10 < valueOrDefault)
										{
											flag2 = true;
											result = "MOJ|" + Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + item6.PrdName;
											return result;
										}
										flag2 = true;
									}
								}
							}
						}
						if (!flag2)
						{
							WSspControlOrderItemsStock_Result wSspControlOrderItemsStock_Result = Enumerable.FirstOrDefault<WSspControlOrderItemsStock_Result>((IEnumerable<WSspControlOrderItemsStock_Result>)_db.WSspControlOrderItemsStock(orderId, lCID, result2, text, result3));
							if (wSspControlOrderItemsStock_Result != null)
							{
								result = "MOJ|" + Messages.msgIssueDraftFormOrderImpossibilityIissued + "\r\n" + Messages.msgIssueDraftFormOrderLackInventory + "\r\n" + wSspControlOrderItemsStock_Result.PrdName;
								return result;
							}
						}
					}
					if (UserLogin.IsUserAccess("frmIssueDraftFromOrder", "actCanNotIssueDraftWithNoStockFromSold", UserLogin.CurrentUser))
					{
						string ordItemJson = "";
						string ordItemListStr = "";
						if (!string.IsNullOrWhiteSpace(text))
						{
							ordItemListStr = text;
						}
						string text4 = "";
						text4 = Order.ControlOrderItemsSoldStock(orderId, 1, "", ordItemJson, ordItemListStr);
						if (!string.IsNullOrWhiteSpace(text4))
						{
							result = "MOJ|" + text4;
							return result;
						}
					}
					if (dateSelect != null)
					{
						dateSelect = dateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					DateTime dateTime = default(DateTime);
					string text5 = "";
					try
					{
						if (!string.IsNullOrEmpty(dateSelect))
						{
							text5 = PersianDate.GetFormatetdDate(dateSelect.Replace("/", ""));
							dateSelect = lCID switch
							{
								1065 => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
								1025 => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
								_ => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
							};
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					DateTime now = DateTime.Now;
					ObjectParameter objectParameter = new ObjectParameter("insertedDraftID", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("insertedDraftNumber", 0);
					_db.WSspIssueDraftFromOrder(orderId, dateSelect, UserLogin.CurrentUser.UserId, short.Parse(now.ToString("MM", new PersianCulture())), Financial.Get().Id, whid, now.ToString("yyyyMMdd", new PersianCulture()), Configuration.AppType, objectParameter, objectParameter2, result2, text, (result3 != 0) ? new int?(result3) : null);
					int num2 = (int)objectParameter.Value;
					int num3 = (int)objectParameter2.Value;
					string text6 = "";
					WSspReturnDraftFromOrder_Result wSspReturnDraftFromOrder_Result2 = new WSspReturnDraftFromOrder_Result();
					List<WSspReturnDraftFromOrder_Result> list5 = Enumerable.ToList<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)_db.WSspReturnDraftFromOrder(orderId, lCID2, result7));
					text2 = "";
					if (list5 != null && Enumerable.Any<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list5))
					{
						wSspReturnDraftFromOrder_Result2 = Enumerable.LastOrDefault<WSspReturnDraftFromOrder_Result>((IEnumerable<WSspReturnDraftFromOrder_Result>)list5);
						if (list5.Count > 1)
						{
							foreach (WSspReturnDraftFromOrder_Result item7 in list5)
							{
								text2 = text2 + item7.DocNumber + ",";
								text6 = text6 + item7.DocID + ",";
							}
							if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrEmpty(text6) && text6.EndsWith(","))
							{
								text6 = text6.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnDraftFromOrder_Result2 = null;
					}
					if (wSspReturnDraftFromOrder_Result2 != null)
					{
						if (string.IsNullOrEmpty(text2))
						{
							text2 = wSspReturnDraftFromOrder_Result2.DocNumber.ToString();
						}
						if (UserLogin.IsUserAccess("frmIssueDraftFromOrder", "actAutoReferDocToOrdReferUserAfterIssue", UserLogin.CurrentUser))
						{
							Doc.ReferDocToOrdReferUser(text6, 0);
						}
						result = "2|" + num2 + "|" + text2 + "|" + wSspReturnDraftFromOrder_Result2.OprType;
					}
					else
					{
						result = "2|" + num2 + "|" + num3 + "|1";
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

	public ActionResult _PartialOrderItems(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectOrderItemsWithDocItemQuantity_Result> model = new List<WSspSelectOrderItemsWithDocItemQuantity_Result>();
		try
		{
			model = Enumerable.ToList<WSspSelectOrderItemsWithDocItemQuantity_Result>((IEnumerable<WSspSelectOrderItemsWithDocItemQuantity_Result>)_dbI.WSspSelectOrderItemsWithDocItemQuantity(ordId, lCID, result));
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
		List<WSspReturnDocForSaleOrder_Result> list = new List<WSspReturnDocForSaleOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)_db.WSspReturnDocForSaleOrder(ordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnDocForSaleOrder_Result>((IEnumerable<WSspReturnDocForSaleOrder_Result>)list))
			{
				foreach (WSspReturnDocForSaleOrder_Result item in list)
				{
					item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.Info = string.Format(Labels.OrdIssueDraftInfo, item.DocOpr ?? "", item.DocNumber.ToString(), item.DocDate);
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
