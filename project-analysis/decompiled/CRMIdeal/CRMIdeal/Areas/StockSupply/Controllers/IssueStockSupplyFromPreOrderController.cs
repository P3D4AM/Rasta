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
using CRMIdeal.Areas.Products.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.StockSupply.Controllers;

public class IssueStockSupplyFromPreOrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actIssueStockSupply")]
	public ActionResult Index(int pordId)
	{
		base.ViewBag.PreOrderId = pordId;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			_ = 0;
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		GetStsupPrintFormat();
		base.ViewBag.IsBuying = VersionBuyer.StockSupply;
		return View();
	}

	public List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result> GetPreOrderItems(int pordId, bool addAllPrd = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result> list = new List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>();
		try
		{
			if (pordId > 0)
			{
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					int valueOrDefault = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
					List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result> list2 = Enumerable.ToList<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>)_dbII.WSspSelectPreOrderItemsWithStsupItemQuantity(pordId, lCID, result));
					if (list2 != null && Enumerable.Any<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>)list2))
					{
						new List<ReturnPrdQuantityViewModel>();
						foreach (WSspSelectPreOrderItemsWithStsupItemQuantity_Result item in list2)
						{
							ReturnPrdQuantityViewModel prdQuantity = GetPrdQuantity(item.pordIPrdId, pordId, item.pordIWHId.GetValueOrDefault(), item.pordIFCR.GetValueOrDefault(), item.pordIFCRI.GetValueOrDefault(), item.pordITracing ?? "", valueOrDefault, item.pordIPrdPriceGroupID.GetValueOrDefault(), "pord", item.pordILinkAccWHIdStr ?? "", item.pordIDescriptionI ?? "");
							if (prdQuantity != null)
							{
								item.ValidPordQuantity = prdQuantity.ValidpordQuantity;
								if (prdQuantity.PrdQuantity != null)
								{
									item.RemainedQuantity = prdQuantity.PrdQuantity.TracingRemainCount.GetValueOrDefault();
								}
								item.pordIRemainedQuantity = item.RemainedQuantity.GetValueOrDefault() - (item.pordIQuantity.GetValueOrDefault() - item.StockSupplyItemQuantity.GetValueOrDefault());
								if (addAllPrd)
								{
									list.Add(item);
								}
								else if (item.pordIRemainedQuantity < 0.0)
								{
									list.Add(item);
								}
							}
						}
					}
					if (list == null)
					{
						list = new List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>();
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult _PartialPreOrderItems(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result> list = new List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>();
		try
		{
			list = GetPreOrderItems(pordId);
			if (list == null)
			{
				list = new List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	public ReturnPrdQuantityViewModel GetPrdQuantity(int prdId, int pordId, int whId, double fcr, double fcrI, string tracing, int cmpId = 0, int prdPriceGroupId = 0, string crmOrdType = "pord", string linkAccWhId = "", string sefareshCode = "")
	{
		ReturnPrdQuantityViewModel result = new ReturnPrdQuantityViewModel();
		try
		{
			tracing = ConvertCharacter.DecodeTracing(tracing);
			result = new SearchController().ReturnPrdQuantityResult(prdId, pordId, whId, fcr, fcrI, tracing, cmpId, prdPriceGroupId, crmOrdType, linkAccWhId, sefareshCode, "StockSupply");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<WSspReturnStockSupplyFromPreOrder_Result> GetStockSupply(int pordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnStockSupplyFromPreOrder_Result> list = new List<WSspReturnStockSupplyFromPreOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)_dbII.WSspReturnStockSupplyFromPreOrder(pordId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)list))
			{
				foreach (WSspReturnStockSupplyFromPreOrder_Result item in list)
				{
					_ = item.stsupDateTime;
					item.stsupDate = item.stsupDateTime.ToString("yyyy/MM/dd");
					item.stsupInfo = string.Format(Labels.PordIssueStockSupplyInfo, item.stsupNumber.ToString(), item.stsupDate);
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetStockSupplyList(int pordId)
	{
		List<WSspReturnStockSupplyFromPreOrder_Result> data = new List<WSspReturnStockSupplyFromPreOrder_Result>();
		try
		{
			data = GetStockSupply(pordId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string IssueStockSupply(int pordId, string dateSelect, string valDetails, int? printFormatId = 0)
	{
		//IL_010c: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (pordId > 0)
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
				if (!VersionBuyer.StockSupply)
				{
					DbSet<WSStockSupply> wSStockSupply = _dbTbl.WSStockSupply;
					ParameterExpression val = Expression.Parameter(typeof(WSStockSupply), "c");
					if (Queryable.Any<WSStockSupply>((IQueryable<WSStockSupply>)wSStockSupply, Expression.Lambda<Func<WSStockSupply, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
					{
						return "BV|" + Messages.VersionBuy;
					}
				}
				List<StockSupplyIdKeyValueViewModel> list = new List<StockSupplyIdKeyValueViewModel>();
				if (!string.IsNullOrEmpty(valDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<StockSupplyIdKeyValueViewModel>>(valDetails);
				}
				string text = "";
				List<StockSupplyIdKeyValueDblViewModel> list2 = new List<StockSupplyIdKeyValueDblViewModel>();
				string pordItemList = "";
				if (Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
				{
					foreach (StockSupplyIdKeyValueViewModel item2 in list)
					{
						int result4 = 0;
						int.TryParse(item2.Id, out result4);
						double result5 = 0.0;
						double.TryParse(item2.Quantity, out result5);
						decimal result6 = default(decimal);
						decimal.TryParse(item2.Cost, out result6);
						if (result5 > 0.0)
						{
							text = text + result4 + "," + result5 + "|";
							StockSupplyIdKeyValueDblViewModel item = new StockSupplyIdKeyValueDblViewModel
							{
								Id = result4,
								Cost = ((result6 != 0m) ? new decimal?(result6) : null),
								Value = result5
							};
							list2.Add(item);
						}
					}
				}
				if (list2 != null && Enumerable.Any<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2))
				{
					pordItemList = JsonConvert.SerializeObject(Enumerable.ToList<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2));
				}
				WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result2));
				if (wSspSelectPreOrderWithId_Result != null)
				{
					int result7 = 0;
					int.TryParse(wSspSelectPreOrderWithId_Result.pordStatusId.ToString(), out result7);
					if (!UserLogin.IsUserAccess("frmPreOrder", "actCanIssueStockSupplyFromExpirePord", UserLogin.CurrentUser) && (result7 == 4 || (wSspSelectPreOrderWithId_Result.pordExpireDateTime.HasValue && wSspSelectPreOrderWithId_Result.pordExpireDateTime < DateTime.Now)))
					{
						return "MOJ|" + Messages.msgErrorIssueStockSupplyForCanceledPord;
					}
				}
				if (printFormatId.GetValueOrDefault() == 0)
				{
					printFormatId = null;
				}
				result = Messages.msgErrorNotFindStockSuppplyForPreOrder;
				WSspReturnStockSupplyFromPreOrder_Result wSspReturnStockSupplyFromPreOrder_Result = new WSspReturnStockSupplyFromPreOrder_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result8);
				if (result8 <= 0)
				{
					result8 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnStockSupplyFromPreOrder_Result> stockSupply = GetStockSupply(pordId);
				if (stockSupply != null && Enumerable.Any<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)stockSupply))
				{
					wSspReturnStockSupplyFromPreOrder_Result = Enumerable.LastOrDefault<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)stockSupply);
					if (stockSupply.Count > 1)
					{
						foreach (WSspReturnStockSupplyFromPreOrder_Result item3 in stockSupply)
						{
							text2 = text2 + item3.stsupNumber + ",";
						}
						if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnStockSupplyFromPreOrder_Result = null;
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckPreOrderHaveStockSupply(pordId));
				int result9 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result9);
					if (result9 == 0)
					{
						wSspReturnStockSupplyFromPreOrder_Result = null;
					}
				}
				if (wSspReturnStockSupplyFromPreOrder_Result != null && result9 == 1)
				{
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = wSspReturnStockSupplyFromPreOrder_Result.stsupNumber.ToString();
					}
					_ = wSspReturnStockSupplyFromPreOrder_Result.stsupDateTime;
					string text3 = wSspReturnStockSupplyFromPreOrder_Result.stsupDateTime.ToString("yyyy/MM/dd");
					string text4 = (wSspReturnStockSupplyFromPreOrder_Result.FirstRegisterDate.HasValue ? wSspReturnStockSupplyFromPreOrder_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					string text5 = string.Format(Messages.msgErrorStockSupplyIssuedForPreOrder, text2, text3, text4, wSspReturnStockSupplyFromPreOrder_Result.FirstRegisterUser ?? "");
					result = "1|" + Labels.Error + " !!\r\n" + text5 + "|" + wSspReturnStockSupplyFromPreOrder_Result.StockSupplyId + "|0";
				}
				else
				{
					List<WSspSelectPreOrderItemsWithStsupItemQuantity_Result> preOrderItems = GetPreOrderItems(pordId, addAllPrd: true);
					if (preOrderItems != null && list != null && Enumerable.Any<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>)preOrderItems) && Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
					{
						foreach (StockSupplyIdKeyValueViewModel item4 in list)
						{
							string id = item4.Id;
							_ = item4.Type;
							_ = item4.Tag;
							string value = item4.Value;
							int objId = 0;
							int.TryParse(id, out objId);
							double result10 = 0.0;
							double.TryParse(value, out result10);
							WSspSelectPreOrderItemsWithStsupItemQuantity_Result wSspSelectPreOrderItemsWithStsupItemQuantity_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>((IEnumerable<WSspSelectPreOrderItemsWithStsupItemQuantity_Result>)preOrderItems, (Func<WSspSelectPreOrderItemsWithStsupItemQuantity_Result, bool>)((WSspSelectPreOrderItemsWithStsupItemQuantity_Result m) => m.PreOrderItemID == objId));
							if (wSspSelectPreOrderItemsWithStsupItemQuantity_Result != null && wSspSelectPreOrderItemsWithStsupItemQuantity_Result.pordIRemainedQuantity.GetValueOrDefault() >= 0.0)
							{
								return "MOJ|" + Messages.msgErrorImpossibilityIssueStockSupplyFormPreOrder + "\r\n" + Messages.msgErrorIssueStockSupplyFormPreOrderHaveInventory + "\r\n" + wSspSelectPreOrderItemsWithStsupItemQuantity_Result.PrdName;
							}
						}
					}
					if (dateSelect != null)
					{
						dateSelect = dateSelect.Replace("/", "").Replace("-", "").Replace("_", "")
							.Replace(".", "")
							.Replace(",", "")
							.Replace("\\", "");
					}
					string stsupDate = "";
					DateTime value2 = default(DateTime);
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
								stsupDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								stsupDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								stsupDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value2 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					DateTime now = DateTime.Now;
					DateTime value3 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value4 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id2 = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("InsertedStockSupplyId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedStsupNumber", typeof(long));
					mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspIssueStockSupplyFromPreOrder(pordId, stsupDate, value2, pordItemList, userId, value4, id2, value3, registerDatePersian, appType, lCID, result8, objectParameter, objectParameter2, result3, printFormatId));
					int result11 = 0;
					if (mct_II_Result2 != null)
					{
						int.TryParse(mct_II_Result2.Result.ToString(), out result11);
					}
					int result12 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result12);
					}
					long result13 = 0L;
					if (objectParameter2.Value != null)
					{
						long.TryParse(objectParameter2.Value.ToString(), out result13);
					}
					if (result11 <= 0)
					{
						return Messages.msgErrorRunFunction;
					}
					string text7 = "";
					WSspReturnStockSupplyFromPreOrder_Result wSspReturnStockSupplyFromPreOrder_Result2 = new WSspReturnStockSupplyFromPreOrder_Result();
					stockSupply = GetStockSupply(pordId);
					text2 = "";
					if (stockSupply != null && Enumerable.Any<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)stockSupply))
					{
						wSspReturnStockSupplyFromPreOrder_Result2 = Enumerable.LastOrDefault<WSspReturnStockSupplyFromPreOrder_Result>((IEnumerable<WSspReturnStockSupplyFromPreOrder_Result>)stockSupply);
						if (stockSupply.Count > 1)
						{
							foreach (WSspReturnStockSupplyFromPreOrder_Result item5 in stockSupply)
							{
								text2 = text2 + item5.stsupNumber + ",";
								text7 = text7 + item5.StockSupplyId + ",";
							}
							if (!string.IsNullOrWhiteSpace(text2) && text2.EndsWith(","))
							{
								text2 = text2.TrimEnd(new char[1] { ',' });
							}
							if (!string.IsNullOrWhiteSpace(text7) && text7.EndsWith(","))
							{
								text7 = text7.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnStockSupplyFromPreOrder_Result2 = null;
					}
					if (wSspReturnStockSupplyFromPreOrder_Result2 != null)
					{
						if (string.IsNullOrWhiteSpace(text2))
						{
							text2 = wSspReturnStockSupplyFromPreOrder_Result2.stsupNumber.ToString();
						}
						result = "2|" + result12 + "|" + text2 + "|0";
					}
					else
					{
						result = "2|" + result12 + "|" + result13 + "|1";
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			}
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetStsupPrintFormat()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 82);
			if (list2 != null)
			{
				list = Enumerable.ToList<SelectListItem>(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
				{
					Text = item.Title,
					Value = item.PrintFormatID.ToString()
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.stsupPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
