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
using Newtonsoft.Json;

namespace CRMIdeal.Areas.StockSupply.Controllers;

public class IssueBuyOrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmStockSupply", ActionName = "actIssueBuyOrder")]
	public ActionResult Index(int stsupId, string parameters = "")
	{
		base.ViewBag.StockSupplyId = stsupId;
		string text = "";
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string[] array = parameters.Split(new char[1] { '|' });
			base.ViewBag.MyParameters = array;
			if (stsupId > 0 && Enumerable.FirstOrDefault<WSspSelectStockSupplyById_Result>((IEnumerable<WSspSelectStockSupplyById_Result>)_dbII.WSspSelectStockSupplyById(stsupId, lCID, result)) != null && num != 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(num);
				if (companyById != null)
				{
					text = companyById.cmpTitle ?? "";
					if (!string.IsNullOrWhiteSpace(text))
					{
						text += " ";
					}
					text += companyById.cmpName;
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
		base.ViewBag.IsBuying = VersionBuyer.BuyOrders;
		base.ViewBag.CmpId = num;
		base.ViewBag.PrsId = num2;
		base.ViewBag.PrjId = num3;
		base.ViewBag.CmpFullName = text;
		GetBordDefSetting();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetBordDefSetting()
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
			int userId = UserLogin.CurrentUser.UserId;
			List<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result> list2 = Enumerable.ToList<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)_dbII.WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic(userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>((IEnumerable<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result>)list2, (Func<WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result, SelectListItem>)((WSspSelectBuyOrderDefaultSettingByReferUserIdAndIsPublic_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.BuyOrderDefaultSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.bordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductCostGroup()
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
			List<WSspSelectProductCostGroup_Result> list2 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list2, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductCostGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result> GetStockSupplyItems(int stsupId, int cmpId = 0, bool addAllPrd = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result> list = new List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>();
		try
		{
			if (stsupId > 0)
			{
				List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result> list2 = Enumerable.ToList<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>)_dbII.WSspSelectStockSupplyItemsWithBordItemQuantity(stsupId, lCID, result));
				if (list2 != null && Enumerable.Any<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>)list2))
				{
					new List<ReturnPrdQuantityViewModel>();
					foreach (WSspSelectStockSupplyItemsWithBordItemQuantity_Result item in list2)
					{
						item.stsupIRemainedQuantity = item.stsupIQuantity - item.BuyOrderItemQuantity.GetValueOrDefault();
						if (addAllPrd)
						{
							list.Add(item);
						}
						else if (item.stsupIRemainedQuantity > 0.0)
						{
							list.Add(item);
						}
					}
				}
				if (list == null)
				{
					list = new List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>();
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult _PartialStockSupplyItems(int stsupId, int cmpId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result> list = new List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>();
		GetProductCostGroup();
		try
		{
			list = GetStockSupplyItems(stsupId, cmpId);
			if (list == null)
			{
				list = new List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(list);
	}

	public List<WSspReturnBuyOrderFromStockSupply_Result> GetBuyOrder(int stsupId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnBuyOrderFromStockSupply_Result> list = new List<WSspReturnBuyOrderFromStockSupply_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)_dbII.WSspReturnBuyOrderFromStockSupply(stsupId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)list))
			{
				foreach (WSspReturnBuyOrderFromStockSupply_Result item in list)
				{
					item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.bordInfo = string.Format(Labels.StsupIssueBuyOrderInfo, item.BuyOrderOpr ?? Labels.lblBOrd, item.bordNumber.ToString(), item.bordDate);
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
	public JsonResult GetBuyOrderList(int stsupId)
	{
		List<WSspReturnBuyOrderFromStockSupply_Result> data = new List<WSspReturnBuyOrderFromStockSupply_Result>();
		try
		{
			data = GetBuyOrder(stsupId);
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
	public string IssueBuyOrder(int stsupId, int cmpId, int prsId, int prjId, string dateSelect, string valDetails, int bordDefSettingId = 0)
	{
		//IL_00fd: Unknown result type (might be due to invalid IL or missing references)
		string result = "-1";
		if (stsupId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				int? centerId = null;
				if (UserLogin.CurrentUser != null)
				{
					centerId = UserLogin.CurrentUser.UserLastCId;
				}
				if (!VersionBuyer.BuyOrders)
				{
					DbSet<WSBuyOrder> wSBuyOrder = _dbTbl.WSBuyOrder;
					ParameterExpression val = Expression.Parameter(typeof(WSBuyOrder), "c");
					if (Queryable.Any<WSBuyOrder>((IQueryable<WSBuyOrder>)wSBuyOrder, Expression.Lambda<Func<WSBuyOrder, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val })))
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
				string stsupItemList = "";
				if (Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
				{
					foreach (StockSupplyIdKeyValueViewModel item2 in list)
					{
						string id = item2.Id;
						_ = item2.Type;
						_ = item2.Tag;
						string value = item2.Value;
						int result3 = 0;
						int.TryParse(id, out result3);
						double result4 = 0.0;
						double.TryParse(value, out result4);
						decimal result5 = default(decimal);
						int result6 = 0;
						decimal.TryParse(item2.Cost, out result5);
						int.TryParse(item2.CostGroupId, out result6);
						double result7 = 0.0;
						double.TryParse(item2.PriceCurrencyRate.ToString(), out result7);
						if (result4 > 0.0)
						{
							text = text + result3 + "," + result4 + "|";
							StockSupplyIdKeyValueDblViewModel item = new StockSupplyIdKeyValueDblViewModel
							{
								Id = result3,
								Value = result4,
								Cost = result5,
								CostGroupId = ((result6 != 0) ? new int?(result6) : null),
								PriceCurrencyRate = result7
							};
							list2.Add(item);
						}
					}
				}
				if (list2 != null && Enumerable.Any<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2))
				{
					stsupItemList = JsonConvert.SerializeObject(Enumerable.ToList<StockSupplyIdKeyValueDblViewModel>((IEnumerable<StockSupplyIdKeyValueDblViewModel>)list2));
				}
				WSspSelectStockSupplyById_Result wSspSelectStockSupplyById_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyById_Result>((IEnumerable<WSspSelectStockSupplyById_Result>)_dbII.WSspSelectStockSupplyById(stsupId, lCID, result2));
				if (wSspSelectStockSupplyById_Result != null)
				{
					bool result8 = false;
					bool.TryParse(wSspSelectStockSupplyById_Result.stsupIsCanceled.ToString(), out result8);
					if (result8)
					{
						return "MOJ|" + Messages.msgErrorIssueBuyOrderForCanceledStsup;
					}
				}
				result = Messages.msgErrorNotFindBuyOrderForStockSuppply;
				WSspReturnBuyOrderFromStockSupply_Result wSspReturnBuyOrderFromStockSupply_Result = new WSspReturnBuyOrderFromStockSupply_Result();
				string text2 = "";
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result9);
				if (result9 <= 0)
				{
					result9 = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				List<WSspReturnBuyOrderFromStockSupply_Result> buyOrder = GetBuyOrder(stsupId);
				if (buyOrder != null && Enumerable.Any<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)buyOrder))
				{
					wSspReturnBuyOrderFromStockSupply_Result = Enumerable.LastOrDefault<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)buyOrder);
					if (buyOrder.Count > 1)
					{
						foreach (WSspReturnBuyOrderFromStockSupply_Result item3 in buyOrder)
						{
							text2 = text2 + item3.bordNumber + ",";
						}
						if (!string.IsNullOrEmpty(text2) && text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnBuyOrderFromStockSupply_Result = null;
				}
				mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckStockSupplyHaveBuyOrder(stsupId));
				int result10 = 0;
				if (mct_II_Result != null)
				{
					int.TryParse(mct_II_Result.Result.ToString(), out result10);
					if (result10 == 0)
					{
						wSspReturnBuyOrderFromStockSupply_Result = null;
					}
				}
				if (wSspReturnBuyOrderFromStockSupply_Result != null && result10 == 1)
				{
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = wSspReturnBuyOrderFromStockSupply_Result.bordNumber.ToString();
					}
					string text3 = (wSspReturnBuyOrderFromStockSupply_Result.bordDateTime.HasValue ? wSspReturnBuyOrderFromStockSupply_Result.bordDateTime.Value.ToString("yyyy/MM/dd") : "");
					string text4 = (wSspReturnBuyOrderFromStockSupply_Result.FirstRegisterDate.HasValue ? wSspReturnBuyOrderFromStockSupply_Result.FirstRegisterDate.Value.ToString("yyyy/MM/dd") : "");
					string text5 = string.Format(Messages.msgErrorBuyOrderIssuedForStockSupply, text2, text3, text4, wSspReturnBuyOrderFromStockSupply_Result.FirstRegisterUser ?? "");
					result = "1|" + Labels.Error + " !!\r\n" + text5 + "|" + wSspReturnBuyOrderFromStockSupply_Result.BuyOrderID + "|0";
				}
				else
				{
					List<WSspSelectStockSupplyItemsWithBordItemQuantity_Result> stockSupplyItems = GetStockSupplyItems(stsupId, cmpId);
					if (stockSupplyItems != null && list != null && Enumerable.Any<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>)stockSupplyItems) && Enumerable.Any<StockSupplyIdKeyValueViewModel>((IEnumerable<StockSupplyIdKeyValueViewModel>)list))
					{
						foreach (StockSupplyIdKeyValueViewModel item4 in list)
						{
							string id2 = item4.Id;
							_ = item4.Type;
							_ = item4.Tag;
							string value2 = item4.Value;
							int objId = 0;
							int.TryParse(id2, out objId);
							double result11 = 0.0;
							double.TryParse(value2, out result11);
							WSspSelectStockSupplyItemsWithBordItemQuantity_Result wSspSelectStockSupplyItemsWithBordItemQuantity_Result = Enumerable.FirstOrDefault<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>((IEnumerable<WSspSelectStockSupplyItemsWithBordItemQuantity_Result>)stockSupplyItems, (Func<WSspSelectStockSupplyItemsWithBordItemQuantity_Result, bool>)((WSspSelectStockSupplyItemsWithBordItemQuantity_Result m) => m.StockSupplyItemId == objId));
							if (wSspSelectStockSupplyItemsWithBordItemQuantity_Result != null && result11 != 0.0 && wSspSelectStockSupplyItemsWithBordItemQuantity_Result.stsupIRemainedQuantity.GetValueOrDefault() <= 0.0)
							{
								return "MOJ|" + Messages.msgErrorImpossibilityIssueBuyOrderFormStockSupply + "\r\n" + Messages.msgErrorIssueBuyOrderFormStockSupplyHaveInventory + "\r\n" + wSspSelectStockSupplyItemsWithBordItemQuantity_Result.PrdName;
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
					string bordDate = "";
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
								bordDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								bordDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							value3 = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						result = "-1";
					}
					DateTime now = DateTime.Now;
					DateTime value4 = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value5 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(now.ToString("yyyy", new PersianCulture()));
					int userId = UserLogin.CurrentUser.UserId;
					int id3 = Financial.Get().Id;
					ObjectParameter objectParameter = new ObjectParameter("InsertedBuyOrderId", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedBordNumber", typeof(long));
					mct_II_Result mct_II_Result2 = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspIssueBuyOrderFromStockSupply(stsupId, bordDate, value3, stsupItemList, cmpId, prsId, prjId, bordDefSettingId, userId, value5, id3, value4, registerDatePersian, appType, lCID, result9, objectParameter, objectParameter2, centerId));
					int result12 = 0;
					if (mct_II_Result2 != null)
					{
						int.TryParse(mct_II_Result2.Result.ToString(), out result12);
					}
					int result13 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result13);
					}
					long result14 = 0L;
					if (objectParameter2.Value != null)
					{
						long.TryParse(objectParameter2.Value.ToString(), out result14);
					}
					if (result12 <= 0)
					{
						return Messages.msgErrorRunFunction;
					}
					string text7 = "";
					WSspReturnBuyOrderFromStockSupply_Result wSspReturnBuyOrderFromStockSupply_Result2 = new WSspReturnBuyOrderFromStockSupply_Result();
					buyOrder = GetBuyOrder(stsupId);
					text2 = "";
					if (buyOrder != null && Enumerable.Any<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)buyOrder))
					{
						wSspReturnBuyOrderFromStockSupply_Result2 = Enumerable.LastOrDefault<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)buyOrder);
						if (buyOrder.Count > 1)
						{
							foreach (WSspReturnBuyOrderFromStockSupply_Result item5 in buyOrder)
							{
								text2 = text2 + item5.bordNumber + ",";
								text7 = text7 + item5.BuyOrderID + ",";
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
						wSspReturnBuyOrderFromStockSupply_Result2 = null;
					}
					if (wSspReturnBuyOrderFromStockSupply_Result2 != null)
					{
						if (string.IsNullOrWhiteSpace(text2))
						{
							text2 = wSspReturnBuyOrderFromStockSupply_Result2.bordNumber.ToString();
						}
						result = "2|" + result13 + "|" + text2 + "|0";
					}
					else
					{
						result = "2|" + result13 + "|" + result14 + "|1";
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

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
