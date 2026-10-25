using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Data.Objects;
using System.Globalization;
using System.Linq;
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

namespace CRMIdeal.Areas.WareHouse.Controllers;

public class IssueOrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	[LoginAuthorize]
	public ActionResult Index(int docId, int position, int pordId = 0)
	{
		base.ViewBag.DocId = docId;
		base.ViewBag.PordId = pordId;
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmDraft";
			text2 = "actIssueOrder";
			if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
			{
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			GetOrderOpr();
			GetOrderReferUsers();
			GetOrderPrintFormat();
			GetOrderDefSetting();
			GetOrdSetPementType();
			return View();
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		case 0:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
	}

	public ActionResult _PartialDocItems(int docId, int pordId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectDocItemsWithPordIPrice_Result> model = new List<WSspSelectDocItemsWithPordIPrice_Result>();
		base.ViewBag.PordId = pordId;
		GetProductPriceGroup();
		try
		{
			model = Enumerable.ToList<WSspSelectDocItemsWithPordIPrice_Result>((IEnumerable<WSspSelectDocItemsWithPordIPrice_Result>)_dbI.WSspSelectDocItemsWithPordIPrice(docId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	public string ControlOrder(int docId)
	{
		string result = "-1";
		if (docId > 0)
		{
			try
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
				if (result2 <= 0)
				{
					result2 = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				result = "msgErrorNotFindOrderForDoc".OrderMessages();
				WSspReturnOrderFromDoc_Result wSspReturnOrderFromDoc_Result = new WSspReturnOrderFromDoc_Result();
				string text = "";
				List<WSspReturnOrderFromDoc_Result> list = Enumerable.ToList<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)_dbI.WSspReturnOrderFromDoc(docId, lCID, result2));
				if (list != null && Enumerable.Any<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list))
				{
					wSspReturnOrderFromDoc_Result = Enumerable.LastOrDefault<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list);
					if (list.Count > 1)
					{
						foreach (WSspReturnOrderFromDoc_Result item in list)
						{
							text = text + item.ordNumber + ",";
						}
						if (!string.IsNullOrEmpty(text) && text.EndsWith(","))
						{
							text = text.TrimEnd(new char[1] { ',' });
						}
					}
				}
				else
				{
					wSspReturnOrderFromDoc_Result = null;
				}
				if (wSspReturnOrderFromDoc_Result != null)
				{
					wSspReturnOrderFromDoc_Result.ordDate = (wSspReturnOrderFromDoc_Result.ordDateTime.HasValue ? wSspReturnOrderFromDoc_Result.ordDateTime.Value.ToString("yyyyMMdd") : wSspReturnOrderFromDoc_Result.ordDate);
					WSspReturnOrderFromDoc_Result wSspReturnOrderFromDoc_Result2 = wSspReturnOrderFromDoc_Result;
					_ = wSspReturnOrderFromDoc_Result.RegisterDate;
					wSspReturnOrderFromDoc_Result2.RegisterDatePersian = wSspReturnOrderFromDoc_Result.RegisterDate.ToString("yyyyMMdd");
					if (string.IsNullOrWhiteSpace(text))
					{
						text = wSspReturnOrderFromDoc_Result.ordNumber.ToString();
					}
					result = Labels.Error + " !\r\n" + "msgIssueOrderFormDocWithNumber".OrderMessages() + " " + text + "\r\n" + Messages.msgIssueOrderFormDocDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromDoc_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormDocInDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromDoc_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormDocByUser + " " + wSspReturnOrderFromDoc_Result.UserName + "\r\n" + Messages.msgIssueOrderFormDocBeenIssued + "|" + wSspReturnOrderFromDoc_Result.OrderID;
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
	public string Send2ServerIssueOrder(string modelStr)
	{
		//IL_0099: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d8: Unknown result type (might be due to invalid IL or missing references)
		string text = "-1";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
			if (defLangID <= 0)
			{
				defLangID = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!VersionBuyer.Order)
			{
				return "BV|" + Messages.VersionBuy;
			}
			if (!string.IsNullOrWhiteSpace(modelStr))
			{
				IssueOrderFromDocViewModel issueOrderFromDocViewModel = new JavaScriptSerializer().Deserialize<IssueOrderFromDocViewModel>(modelStr);
				if (issueOrderFromDocViewModel != null)
				{
					DateTime dateTime = default(DateTime);
					string text2 = "";
					if (string.IsNullOrWhiteSpace(issueOrderFromDocViewModel.OrderDate))
					{
						return string.Format(Messages.msgErrorIsNotEnteredItem, "IssueOrderFromDocOrdDate".OrderLabels());
					}
					issueOrderFromDocViewModel.OrderDate = issueOrderFromDocViewModel.OrderDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
					try
					{
						if (!string.IsNullOrEmpty(issueOrderFromDocViewModel.OrderDate))
						{
							text2 = PersianDate.GetFormatetdDate(issueOrderFromDocViewModel.OrderDate.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								issueOrderFromDocViewModel.OrderDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								issueOrderFromDocViewModel.OrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								issueOrderFromDocViewModel.OrderDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							issueOrderFromDocViewModel.OrderDateTime = dateTime;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
						return string.Format(Messages.ErrorInFormat, "IssueOrderFromDocOrdDate".OrderLabels());
					}
					WSspReturnOrderFromDoc_Result wSspReturnOrderFromDoc_Result = new WSspReturnOrderFromDoc_Result();
					string text3 = "";
					List<WSspReturnOrderFromDoc_Result> list = Enumerable.ToList<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)_dbI.WSspReturnOrderFromDoc(issueOrderFromDocViewModel.DocId, lCID, defLangID));
					if (list != null && Enumerable.Any<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list))
					{
						wSspReturnOrderFromDoc_Result = Enumerable.LastOrDefault<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list);
						if (list.Count > 1)
						{
							foreach (WSspReturnOrderFromDoc_Result item in list)
							{
								text3 = text3 + item.ordNumber + ",";
							}
							if (!string.IsNullOrWhiteSpace(text3) && text3.EndsWith(","))
							{
								text3 = text3.TrimEnd(new char[1] { ',' });
							}
						}
					}
					else
					{
						wSspReturnOrderFromDoc_Result = null;
					}
					mct_II_Result mct_II_Result = Enumerable.FirstOrDefault<mct_II_Result>((IEnumerable<mct_II_Result>)_dbII.WSspCheckDocHaveOrder(issueOrderFromDocViewModel.DocId));
					int result = 0;
					if (mct_II_Result != null)
					{
						int.TryParse(mct_II_Result.Result.ToString(), out result);
						if (result == 0)
						{
							wSspReturnOrderFromDoc_Result = null;
						}
					}
					if (wSspReturnOrderFromDoc_Result != null && result == 1)
					{
						wSspReturnOrderFromDoc_Result.ordDate = (wSspReturnOrderFromDoc_Result.ordDateTime.HasValue ? wSspReturnOrderFromDoc_Result.ordDateTime.Value.ToString("yyyyMMdd") : wSspReturnOrderFromDoc_Result.ordDate);
						WSspReturnOrderFromDoc_Result wSspReturnOrderFromDoc_Result2 = wSspReturnOrderFromDoc_Result;
						_ = wSspReturnOrderFromDoc_Result.RegisterDate;
						wSspReturnOrderFromDoc_Result2.RegisterDatePersian = wSspReturnOrderFromDoc_Result.RegisterDate.ToString("yyyyMMdd");
						if (string.IsNullOrEmpty(text3))
						{
							text3 = wSspReturnOrderFromDoc_Result.ordNumber.ToString();
						}
						return Labels.Error + " !\r\n" + "msgIssueOrderFormDocWithNumber".OrderMessages() + " " + text3 + "\r\n" + Messages.msgIssueOrderFormDocDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromDoc_Result.ordDate) + "\r\n" + Messages.msgIssueOrderFormDocInDate + " " + PersianDate.GetFormatetdDate(wSspReturnOrderFromDoc_Result.RegisterDatePersian) + "\r\n" + Messages.msgIssueOrderFormDocByUser + " " + wSspReturnOrderFromDoc_Result.UserName + "\r\n" + Messages.msgIssueOrderFormDocBeenIssued + "|" + wSspReturnOrderFromDoc_Result.OrderID;
					}
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int id = Financial.Get().Id;
					int userId = UserLogin.CurrentUser.UserId;
					List<CommonMultiLanguageViewModel> list2 = new List<CommonMultiLanguageViewModel>();
					if (!string.IsNullOrEmpty(issueOrderFromDocViewModel.OrderNote_Lang))
					{
						list2 = new JavaScriptSerializer().Deserialize<List<CommonMultiLanguageViewModel>>(issueOrderFromDocViewModel.OrderNote_Lang);
					}
					list2.Add(new CommonMultiLanguageViewModel
					{
						Value = issueOrderFromDocViewModel.OrderNote,
						LanguageId = lCID
					});
					if (list2 != null && Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2))
					{
						issueOrderFromDocViewModel.OrderNote = ((Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)) != null) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == defLangID)).Value : null);
						issueOrderFromDocViewModel.OrderNote_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != defLangID))));
					}
					else
					{
						issueOrderFromDocViewModel.OrderNote = null;
						issueOrderFromDocViewModel.OrderNote_Lang = null;
					}
					if (issueOrderFromDocViewModel.OrderDefaultSettingId == 0)
					{
						issueOrderFromDocViewModel.OrderDefaultSettingId = null;
					}
					if (issueOrderFromDocViewModel.OrderSettlementTypeId == 0)
					{
						issueOrderFromDocViewModel.OrderSettlementTypeId = null;
					}
					ObjectParameter objectParameter = new ObjectParameter("InsertedOrderID", 0);
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedOrderNumber", typeof(long));
					mct_I_Result mct_I_Result = Enumerable.FirstOrDefault<mct_I_Result>((IEnumerable<mct_I_Result>)_dbI.WSspIssueOrderFromDoc(issueOrderFromDocViewModel.DocId, issueOrderFromDocViewModel.OrderDate, issueOrderFromDocViewModel.OrderDateTime, issueOrderFromDocViewModel.OrderOprId, issueOrderFromDocViewModel.OrderReferUserId, issueOrderFromDocViewModel.OrderPrintFormatID, issueOrderFromDocViewModel.OrderDefaultSettingId, issueOrderFromDocViewModel.OrderSettlementTypeId, issueOrderFromDocViewModel.OrderNote, issueOrderFromDocViewModel.OrderNote_Lang, issueOrderFromDocViewModel.OrderProjectId, issueOrderFromDocViewModel.DocItemList, userId, value2, id, value, registerDatePersian, appType, defLangID, objectParameter, objectParameter2, centerId));
					int result2 = 0;
					int.TryParse(mct_I_Result.Result.ToString(), out result2);
					int result3 = 0;
					if (objectParameter.Value != null)
					{
						int.TryParse(objectParameter.Value.ToString(), out result3);
					}
					long result4 = 0L;
					if (objectParameter2.Value != null)
					{
						long.TryParse(objectParameter2.Value.ToString(), out result4);
					}
					switch (result2)
					{
					case -1:
						text = string.Format("msgErrorIssueOrdFromDocHasOrd".OrderMessages(), result4.ToString());
						break;
					case -2:
						text = string.Format(Messages.msgErrorIssueOrdFromDocHasBord, result4.ToString());
						break;
					case -3:
						text = Messages.msgErrorIssueOrdFromDocNoItem;
						break;
					case 1:
						if (result3 > 0)
						{
							string text4 = "";
							WSspReturnOrderFromDoc_Result wSspReturnOrderFromDoc_Result3 = new WSspReturnOrderFromDoc_Result();
							List<WSspReturnOrderFromDoc_Result> list3 = Enumerable.ToList<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)_dbI.WSspReturnOrderFromDoc(issueOrderFromDocViewModel.DocId, lCID, defLangID));
							text3 = "";
							if (list3 != null && Enumerable.Any<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list3))
							{
								wSspReturnOrderFromDoc_Result3 = Enumerable.LastOrDefault<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list3);
								if (list3.Count > 0)
								{
									foreach (WSspReturnOrderFromDoc_Result item2 in list3)
									{
										text3 = text3 + item2.ordNumber + ",";
										text4 = text4 + item2.OrderID + ",";
										CRMSpIEntities dbI = _dbI;
										int? orderId = item2.OrderID;
										bool? calcAutoScoreInIssue = true;
										bool? calcAutoScoreInVerify = false;
										dbI.ScorespInsertAndCalcOrderScores(null, orderId, null, null, null, calcAutoScoreInIssue, calcAutoScoreInVerify, DateTime.Now, userId, value3, value2, value, registerDatePersian, appType, lCID, defLangID, null, true, centerId);
									}
									if (!string.IsNullOrEmpty(text3) && text3.EndsWith(","))
									{
										text3 = text3.TrimEnd(new char[1] { ',' });
									}
									if (!string.IsNullOrEmpty(text4) && text4.EndsWith(","))
									{
										text4 = text4.TrimEnd(new char[1] { ',' });
									}
								}
							}
							else
							{
								wSspReturnOrderFromDoc_Result3 = null;
							}
							if (wSspReturnOrderFromDoc_Result3 != null)
							{
								if (string.IsNullOrWhiteSpace(text3))
								{
									text3 = wSspReturnOrderFromDoc_Result3.ordNumber.ToString();
								}
								text = "1|" + result3 + "|" + text3;
							}
							else
							{
								text = "1|" + result3 + "|" + result4;
								CRMSpIEntities dbI2 = _dbI;
								int? orderId2 = result3;
								bool? calcAutoScoreInVerify = true;
								bool? calcAutoScoreInIssue = false;
								dbI2.ScorespInsertAndCalcOrderScores(null, orderId2, null, null, null, calcAutoScoreInVerify, calcAutoScoreInIssue, DateTime.Now, userId, value3, value2, value, registerDatePersian, appType, lCID, defLangID, null, true, centerId);
							}
						}
						else
						{
							text = Messages.msgErrorRunFunction;
						}
						break;
					default:
						text = Messages.msgErrorRunFunction;
						break;
					}
				}
				else
				{
					text = Messages.ErrorNotFound;
				}
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			text = Messages.msgErrorRunFunction;
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetOrderInfo(int docId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspReturnOrderFromDoc_Result> list = new List<WSspReturnOrderFromDoc_Result>();
		try
		{
			list = Enumerable.ToList<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)_dbI.WSspReturnOrderFromDoc(docId, lCID, result));
			if (list != null && Enumerable.Any<WSspReturnOrderFromDoc_Result>((IEnumerable<WSspReturnOrderFromDoc_Result>)list))
			{
				foreach (WSspReturnOrderFromDoc_Result item in list)
				{
					item.ordDate = (item.ordDateTime.HasValue ? item.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					item.RegisterDatePersian = item.OrderInfo;
					item.OrderInfo = string.Format(Labels.IssueOrderFromDocOrdInfo, item.OrderOpr ?? "", item.ordNumber.ToString(), item.ordDate);
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
	public JsonResult GetOrderOpr()
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
			List<WSspSelectOrderOpr_Result> list2 = Order.SelectOrderOpr();
			if (list2 != null)
			{
				list.AddRange(Enumerable.Select<WSspSelectOrderOpr_Result, SelectListItem>((IEnumerable<WSspSelectOrderOpr_Result>)list2, (Func<WSspSelectOrderOpr_Result, SelectListItem>)((WSspSelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderReferUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedTypeIsActive_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedTypeIsActive_Result>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)_dbI.CRMspSelectUserForLinkedTypeIsActive(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedTypeIsActive_Result>)list2, (Func<CRMspSelectUserForLinkedTypeIsActive_Result, SelectListItem>)((CRMspSelectUserForLinkedTypeIsActive_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.LinkedUserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderPrintFormat()
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
			List<spSelectPrintFormat_Result> list2 = CRMIdeal.Classes.Helper.PrintFormat.GetspPrintFortants(result2, 2);
			list.AddRange(Enumerable.Select<spSelectPrintFormat_Result, SelectListItem>((IEnumerable<spSelectPrintFormat_Result>)list2, (Func<spSelectPrintFormat_Result, SelectListItem>)((spSelectPrintFormat_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.PrintFormatID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdPrintFormatList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrderDefSetting()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int userId = UserLogin.CurrentUser.UserId;
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<WSspSelectOrderDefaultSettingUserAccess_Result> list2 = Enumerable.ToList<WSspSelectOrderDefaultSettingUserAccess_Result>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)_dbIII.WSspSelectOrderDefaultSettingUserAccess((short)1, userId, lCID, result));
			int? defSettingId = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.WSspSelectOrderDefaultSettingIsDefUserAccess((short)1, userId, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>((IEnumerable<WSspSelectOrderDefaultSettingUserAccess_Result>)list2, (Func<WSspSelectOrderDefaultSettingUserAccess_Result, SelectListItem>)((WSspSelectOrderDefaultSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.OrderSettingID.ToString(),
				Selected = (item.OrderSettingID == defSettingId.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ordDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetOrdSetPementType()
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
			List<WSspSettlementType_Result> list2 = Enumerable.ToList<WSspSettlementType_Result>((IEnumerable<WSspSettlementType_Result>)_db.WSspSettlementType(lCID, result));
			list.AddRange(Enumerable.Select<WSspSettlementType_Result, SelectListItem>((IEnumerable<WSspSettlementType_Result>)list2, (Func<WSspSettlementType_Result, SelectListItem>)((WSspSettlementType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.OrdSettlementTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProductPriceGroup()
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
			List<WSspSelectProductPriceGroup_Result> list2 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductPriceGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductPriceGroup_Result>)list2, (Func<WSspSelectProductPriceGroup_Result, SelectListItem>)((WSspSelectProductPriceGroup_Result item) => new SelectListItem
			{
				Text = item.ProductPriceGroupName,
				Value = item.ProductPriceGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProductPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
