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

public class DistributeDiscountController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDistributeDiscountToPordItems")]
	public ActionResult Index(int pordId, string disCodeJs = "")
	{
		base.ViewBag.PreOrderId = pordId;
		base.ViewBag.DisCodeJs = disCodeJs;
		return View();
	}

	public ActionResult PreOrderItemsList_Read([DataSourceRequest] DataSourceRequest request, int pordId)
	{
		List<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result> enumerable = new List<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			enumerable = Enumerable.ToList<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, lCID, result));
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
	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actDistributeDiscountToPordItems")]
	public string ActDistributeDiscount(int pordId, string itemIds, decimal discount = 0m, decimal discountPercent = 0m, bool addToDiscount = false, int discountCodeId = 0)
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
			if (!UserLogin.IsUserAccess("frmPreOrder", "actDistributeDiscountToPordItems", UserLogin.CurrentUser))
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
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("Result", 0);
				_db.WSspDistributeDiscountToPreOrderItems(pordId, itemIds, discount, discountPercent, userId, id, value2, value, text2, appType, objectParameter, addToDiscount, discountCodeId: discountCodeId, centerId: result2);
				if (int.Parse(objectParameter.Value.ToString()) > 0)
				{
					bool autoCalcPriceNoChangeDiscount = discount > 0m;
					return PreOrder.CalcAndSetPreOrderAmounts(pordId, autoCalcPriceNoChangeDiscount) ? "" : Messages.msgErrorInCalculation;
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
	public JsonResult AddDiscountCode(string disCode, int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				CommonResultViewModel<WSspSelectDiscountCodeByDisCode_Result> commonResultViewModel2 = CRMIdeal.Classes.Helper.DiscountCode.CheckDiscountCodeToUse(disCode, wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault(), lCID, result);
				if (commonResultViewModel2.Status != CommonResultStatusViewModel.Success)
				{
					commonResultViewModel.Status = commonResultViewModel2.Status;
					commonResultViewModel.Message = commonResultViewModel2.Message;
				}
				else
				{
					List<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, lCID, result));
					if (list == null && Enumerable.FirstOrDefault<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectPreOrderItemsByNotInSumAndNoDis_Result x) => x.pordIDiscountCodeId > 0)) != null)
					{
						commonResultViewModel.Status = CommonResultStatusViewModel.Error;
						commonResultViewModel.Message = Messages.msgErrorCannotAddSecondDisCode;
					}
					else
					{
						_ = wSspSelectPreOrderWithId_Result.CompanyName;
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
							if (disPrdId != 0 && Enumerable.FirstOrDefault<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectPreOrderItemsByNotInSumAndNoDis_Result m) => m.pordIPrdId == disPrdId)) == null)
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
								commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg, Labels.lblPOrd);
							}
						}
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

	[AjaxOnly]
	public JsonResult AddDiscountCode_Old(string disCode, int pordId)
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
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(pordId, lCID, result));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				List<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result> list = Enumerable.ToList<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)_dbI.WSspSelectPreOrderItemsByNotInSumAndNoDis(pordId, false, false, lCID, result));
				if (list != null && Enumerable.FirstOrDefault<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectPreOrderItemsByNotInSumAndNoDis_Result x) => x.pordIDiscountCodeId > 0)) != null)
				{
					commonResultViewModel.Status = CommonResultStatusViewModel.Error;
					commonResultViewModel.Message = Messages.msgErrorCannotAddSecondDisCode;
				}
				else
				{
					string arg = wSspSelectPreOrderWithId_Result.CompanyName ?? "";
					if (!string.IsNullOrWhiteSpace(disCode))
					{
						WSspSelectDiscountCodeByDisCode_Result wSspSelectDiscountCodeByDisCode_Result = Enumerable.FirstOrDefault<WSspSelectDiscountCodeByDisCode_Result>((IEnumerable<WSspSelectDiscountCodeByDisCode_Result>)_dbI.WSspSelectDiscountCodeByDisCode(disCode, lCID, result));
						if (wSspSelectDiscountCodeByDisCode_Result != null)
						{
							if (!wSspSelectDiscountCodeByDisCode_Result.DisCmpId.HasValue)
							{
								List<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result> list2 = Enumerable.ToList<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>((IEnumerable<WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId_Result>)_dbII.WSspSelectDiscountCodeHistoryWithCmpIdAndDisCodeId(wSspSelectPreOrderWithId_Result.pordCompanyId, wSspSelectDiscountCodeByDisCode_Result.DiscountCodeId, lCID, result));
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
								int valueOrDefault = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
								int result3 = 0;
								int.TryParse(wSspSelectDiscountCodeByDisCode_Result.DisCmpId.ToString(), out result3);
								if (result3 == 0 || result3 == valueOrDefault)
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
											if (disPrdId != 0 && list != null && Enumerable.FirstOrDefault<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>((IEnumerable<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result>)list, (Func<WSspSelectPreOrderItemsByNotInSumAndNoDis_Result, bool>)((WSspSelectPreOrderItemsByNotInSumAndNoDis_Result m) => m.pordIPrdId == disPrdId)) == null)
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
													CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(valueOrDefault, result2));
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
												commonResultViewModel.Message = string.Format(Messages.msgErrorDisCodeItemNoPrd, arg2, Labels.lblPOrd);
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
