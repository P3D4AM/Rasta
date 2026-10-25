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

public class DistributeDiscountController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDistributeDiscountToOrdItems")]
	public ActionResult Index(int ordId, string disCodeJs = "")
	{
		base.ViewBag.OrderId = ordId;
		base.ViewBag.DisCodeJs = disCodeJs;
		return View();
	}

	public ActionResult OrderItemsList_Read([DataSourceRequest] DataSourceRequest request, int ordId)
	{
		List<WSspSelectOrderItemsByNotInSumAndNoDis_Result> enumerable = new List<WSspSelectOrderItemsByNotInSumAndNoDis_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			enumerable = Enumerable.ToList<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, lCID, result));
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
	[DynamicAuthorize(ControllerName = "frmOrder", ActionName = "actDistributeDiscountToOrdItems")]
	public string ActDistributeDiscount(int ordId, string itemIds, decimal discount = 0m, decimal discountPercent = 0m, bool addToDiscount = false, int discountCodeId = 0)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!UserLogin.IsUserAccess("frmOrder", "actDistributeDiscountToOrdItems", UserLogin.CurrentUser))
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
				_db.WSspDistributeDiscountToOrderItems(ordId, itemIds, discount, discountPercent, userId, id, value2, value, registerDatePersian, appType, objectParameter, addToDiscount, discountCodeId, result2);
				if (int.Parse(objectParameter.Value.ToString()) > 0)
				{
					bool autoCalcPriceNoChangeDiscount = discount > 0m;
					return Order.CalcAndSetOrderAmounts(ordId, autoCalcPriceNoChangeDiscount) ? "" : Messages.msgErrorInCalculation;
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

	[AjaxOnly]
	public JsonResult AddDiscountCode(string disCode, int ordId)
	{
		CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> commonResultViewModel = new CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result>();
		commonResultViewModel.Data = new WSspSelectDiscountCodeByDisCode_Result();
		commonResultViewModel.Message = "";
		commonResultViewModel.Status = CommonResultStatusViewModel.Fail;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result));
			if (wSspSelectOrderById_Result == null)
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.ErrorNotFound;
			}
			else
			{
				CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> commonResultViewModel2 = CRMIdeal.Classes.Helper.DiscountCode.CheckDiscountCodeToUse(disCode, wSspSelectOrderById_Result.ordCompanyId, lCID, result);
				if (commonResultViewModel2.Status != CommonResultStatusViewModel.Success)
				{
					commonResultViewModel.Status = commonResultViewModel2.Status;
					commonResultViewModel.Message = commonResultViewModel2.Message;
				}
				else
				{
					List<WSspSelectOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, lCID, result));
					if (list == null || Enumerable.FirstOrDefault<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectOrderItemsByNotInSumAndNoDis_Result x) => x.ordIDiscountCodeId > 0)) != null)
					{
						commonResultViewModel.Status = CommonResultStatusViewModel.Error;
						commonResultViewModel.Message = Messages.msgErrorCannotAddSecondDisCode;
					}
					else
					{
						_ = wSspSelectOrderById_Result.CompanyName;
						WSspSelectDiscountCodeByDisCode_Result data = commonResultViewModel2.Data;
						if (data == null)
						{
							commonResultViewModel.Status = CommonResultStatusViewModel.Error;
							commonResultViewModel.Message = Messages.msgErrorDisCodeIncorrect;
						}
						else
						{
							string arg = data.DisPrdName ?? "";
							int disPrdId = 0;
							int.TryParse(data.DisPrdId.ToString(), out disPrdId);
							bool flag = true;
							if (disPrdId != 0 && Enumerable.FirstOrDefault<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectOrderItemsByNotInSumAndNoDis_Result m) => m.ordIPrdId == disPrdId)) == null)
							{
								flag = false;
							}
							if (flag)
							{
								commonResultViewModel.Data = data;
								commonResultViewModel.Status = CommonResultStatusViewModel.Success;
								commonResultViewModel.Message = "";
							}
							else
							{
								commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg, "lblOrd".OrderLabels());
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonResultViewModel.Status = CommonResultStatusViewModel.Error;
			commonResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult AddDiscountCode_Old(string disCode, int ordId)
	{
		CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> commonResultViewModel = new CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result>();
		commonResultViewModel.Data = new WSspSelectDiscountCodeByDisCode_Result();
		commonResultViewModel.Message = "";
		commonResultViewModel.Status = CommonResultStatusViewModel.Fail;
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
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(ordId, lCID, result));
			if (wSspSelectOrderById_Result != null)
			{
				List<WSspSelectOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectOrderItemsByNotInSumAndNoDis(ordId, false, false, lCID, result));
				if (list != null && Enumerable.FirstOrDefault<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectOrderItemsByNotInSumAndNoDis_Result x) => x.ordIDiscountCodeId > 0)) != null)
				{
					commonResultViewModel.Status = CommonResultStatusViewModel.Error;
					commonResultViewModel.Message = Messages.msgErrorCannotAddSecondDisCode;
				}
				else
				{
					string arg = wSspSelectOrderById_Result.CompanyName ?? "";
					if (!string.IsNullOrWhiteSpace(disCode))
					{
						WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)_dbI.WSspSelectDiscountCodeByDisCode(disCode, lCID, result));
						if (wSspSelectDiscountCodeByDisCode_Result != null)
						{
							if (!wSspSelectDiscountCodeByDisCode_Result.DisCmpId.HasValue)
							{
								List<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result> list2 = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>)_dbII.WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId(wSspSelectOrderById_Result.ordCompanyId, wSspSelectDiscountCodeByDisCode_Result.DiscountCodeId, lCID, result));
								if (list2 != null && Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>)list2).Count > 0)
								{
									commonResultViewModel.Status = CommonResultStatusViewModel.Error;
									commonResultViewModel.Message = Messages.DiscountCodeUsedBeforeForThisCompany;
									wSspSelectDiscountCodeByDisCode_Result = null;
								}
							}
							if (wSspSelectDiscountCodeByDisCode_Result != null)
							{
								string arg2 = wSspSelectDiscountCodeByDisCode_Result.DisPrdName ?? "";
								int ordCompanyId = wSspSelectOrderById_Result.ordCompanyId;
								int result3 = 0;
								int.TryParse(wSspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
								if (result3 == 0 || result3 == ordCompanyId)
								{
									_ = wSspSelectDiscountCodeByDisCode_Result.DisExpDate;
									string s = wSspSelectDiscountCodeByDisCode_Result.DisExpDate.ToString("yyyyMMdd");
									string s2 = DateTime.Now.ToString("yyyyMMdd");
									if (long.Parse(s) >= long.Parse(s2))
									{
										int result4 = 0;
										int.TryParse(wSspSelectDiscountCodeByDisCode_Result.DisUseCnt.ToString(), out result4);
										int result5 = 0;
										int.TryParse(wSspSelectDiscountCodeByDisCode_Result.UsedCount.ToString(), out result5);
										if (result4 > result5)
										{
											int disPrdId = 0;
											int.TryParse(wSspSelectDiscountCodeByDisCode_Result.DisPrdId.ToString(), out disPrdId);
											bool flag = true;
											if (disPrdId != 0 && list != null && Enumerable.FirstOrDefault<WSspSelectOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectOrderItemsByNotInSumAndNoDis_Result m) => m.ordIPrdId == disPrdId)) == null)
											{
												flag = false;
											}
											if (flag)
											{
												double result6 = 0.0;
												double.TryParse(wSspSelectDiscountCodeByDisCode_Result.ScoreRate.ToString(), out result6);
												bool flag2 = true;
												if (result6 != 0.0)
												{
													double result7 = 0.0;
													double result8 = 0.0;
													CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(ordCompanyId, result2));
													if (cRMspReturnSumCompanyScores_Result != null)
													{
														double.TryParse(cRMspReturnSumCompanyScores_Result.SumScores.ToString(), out result7);
														double.TryParse(cRMspReturnSumCompanyScores_Result.SumUsableScores.ToString(), out result8);
													}
													if (result6 > result8)
													{
														flag2 = false;
													}
												}
												if (flag2)
												{
													commonResultViewModel.Data = wSspSelectDiscountCodeByDisCode_Result;
													commonResultViewModel.Status = CommonResultStatusViewModel.Success;
													commonResultViewModel.Message = "";
												}
												else
												{
													commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeNoScoreMin, result6.ToString());
												}
											}
											else
											{
												commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg2, "lblOrd".OrderLabels());
											}
										}
										else
										{
											commonResultViewModel.Message = Messages.msgErrorDisCodeUsedBefore;
										}
									}
									else
									{
										commonResultViewModel.Message = Messages.msgErrorDisCodeExpired;
									}
								}
								else
								{
									commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeUnUsableForCmp, arg);
								}
							}
						}
						else
						{
							commonResultViewModel.Status = CommonResultStatusViewModel.Error;
							commonResultViewModel.Message = Messages.msgErrorDisCodeIncorrect;
						}
					}
					else
					{
						commonResultViewModel.Status = CommonResultStatusViewModel.Error;
						commonResultViewModel.Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.DistributeDiscountCode);
					}
				}
			}
			else
			{
				commonResultViewModel.Status = CommonResultStatusViewModel.Error;
				commonResultViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			commonResultViewModel.Status = CommonResultStatusViewModel.Error;
			commonResultViewModel.Message = Messages.msgErrorRunFunction;
		}
		JsonResult jsonResult = Json(commonResultViewModel, JsonRequestBehavior.AllowGet);
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
