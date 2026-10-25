using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.IO;
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
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Costsheets.Controllers;

public class CostsheetController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	[DynamicAuthorize(ControllerName = "frmCostsheet", ActionName = "actctshShow")]
	public ActionResult Index(int ctshId)
	{
		base.ViewBag.CtshId = ctshId;
		return View();
	}

	[AjaxOnly]
	public JsonResult GetCostsheet(int ctshId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentCostSheetViewModel currentCostSheetViewModel = new CurrentCostSheetViewModel();
		currentCostSheetViewModel.Costsheet = new WSspSelectCostSheetsById_Result();
		currentCostSheetViewModel.Footer = new WSspReturnCostSheetSumFooter_Result();
		try
		{
			WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)_db.WSspSelectCostSheetsById(ctshId, lCID, result));
			if (wSspSelectCostSheetsById_Result != null)
			{
				currentCostSheetViewModel.IsFind = true;
				currentCostSheetViewModel.Message = "";
				_ = wSspSelectCostSheetsById_Result.ctshDate;
				wSspSelectCostSheetsById_Result.ctshDatePersian = wSspSelectCostSheetsById_Result.ctshDate.ToString("yyyy/MM/dd");
				wSspSelectCostSheetsById_Result.ctshVerifiedDatePersian = (wSspSelectCostSheetsById_Result.ctshVerifiedDate.HasValue ? wSspSelectCostSheetsById_Result.ctshVerifiedDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : null);
				_ = wSspSelectCostSheetsById_Result.FirstRegisterDate;
				wSspSelectCostSheetsById_Result.FirstRegisterDatePersian = wSspSelectCostSheetsById_Result.FirstRegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				_ = wSspSelectCostSheetsById_Result.RegisterDate;
				wSspSelectCostSheetsById_Result.RegisterDatePersian = wSspSelectCostSheetsById_Result.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
				if (string.IsNullOrEmpty(wSspSelectCostSheetsById_Result.AppType))
				{
					wSspSelectCostSheetsById_Result.AppType = Configuration.AppType;
				}
				wSspSelectCostSheetsById_Result.AppType = Configuration.GetAppType(wSspSelectCostSheetsById_Result.AppType);
				wSspSelectCostSheetsById_Result.FirstRegisterUser = wSspSelectCostSheetsById_Result.FirstRegisterUser ?? "";
				wSspSelectCostSheetsById_Result.EditUser = wSspSelectCostSheetsById_Result.EditUser ?? "";
				wSspSelectCostSheetsById_Result.FirstRegisterUser = wSspSelectCostSheetsById_Result.FirstRegisterUser + " (" + wSspSelectCostSheetsById_Result.FirstRegisterDatePersian + ")";
				string text = (string.IsNullOrEmpty(wSspSelectCostSheetsById_Result.AppType) ? "" : (" (" + Labels.AppType + ": " + wSspSelectCostSheetsById_Result.AppType + ") "));
				WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result2 = wSspSelectCostSheetsById_Result;
				wSspSelectCostSheetsById_Result2.EditUser = wSspSelectCostSheetsById_Result2.EditUser + text + "(" + wSspSelectCostSheetsById_Result.RegisterDatePersian + ")";
				wSspSelectCostSheetsById_Result.ctshVerifier = wSspSelectCostSheetsById_Result.ctshVerifier ?? "";
				wSspSelectCostSheetsById_Result.ctshVerifier = wSspSelectCostSheetsById_Result.ctshVerifier + " (" + wSspSelectCostSheetsById_Result.ctshVerifiedDatePersian + ")";
				if (wSspSelectCostSheetsById_Result.PreOrderId.HasValue)
				{
					WSspReturnPreOrderFromCostSheet_Result wSspReturnPreOrderFromCostSheet_Result = Enumerable.FirstOrDefault<WSspReturnPreOrderFromCostSheet_Result>((IEnumerable<WSspReturnPreOrderFromCostSheet_Result>)_db.WSspReturnPreOrderFromCostSheet(wSspSelectCostSheetsById_Result.ctshCmpProjectId, lCID, result));
					if (wSspReturnPreOrderFromCostSheet_Result != null && wSspSelectCostSheetsById_Result.PreOrderId == wSspSelectCostSheetsById_Result.PreOrderId)
					{
						wSspSelectCostSheetsById_Result.PreOrderId = wSspReturnPreOrderFromCostSheet_Result.PreOrderID;
						string text2 = "";
						_ = wSspReturnPreOrderFromCostSheet_Result.pordNumber;
						text2 += wSspReturnPreOrderFromCostSheet_Result.pordNumber;
						if (wSspReturnPreOrderFromCostSheet_Result.pordNumberRevision.HasValue)
						{
							text2 += 45u + wSspReturnPreOrderFromCostSheet_Result.pordNumberRevision;
						}
						string text3 = (wSspReturnPreOrderFromCostSheet_Result.pordDateTime.HasValue ? (" (" + Labels.ctshPordInfoDate + ": " + wSspReturnPreOrderFromCostSheet_Result.pordDateTime.Value.ToString("yyyy/MM/dd") + ")") : "");
						string text4 = "";
						if (wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnitId.HasValue)
						{
							bool result2 = false;
							WSspSelectCurrencyUnitsWithId_Result wSspSelectCurrencyUnitsWithId_Result = Enumerable.FirstOrDefault<WSspSelectCurrencyUnitsWithId_Result>((IEnumerable<WSspSelectCurrencyUnitsWithId_Result>)_db.WSspSelectCurrencyUnitsWithId(wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnitId, lCID, result));
							if (wSspSelectCurrencyUnitsWithId_Result != null)
							{
								bool.TryParse(wSspSelectCurrencyUnitsWithId_Result.IsDecimal.ToString(), out result2);
							}
							text4 = (result2 ? (" (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N2}" + " " + wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit + ")") : (" (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N0}" + " " + wSspSelectCurrencyUnitsWithId_Result.CurrencyUnit + ")"));
						}
						else
						{
							text4 = " (" + Labels.ctshPordInfoTotalAmount + ": " + $"{wSspReturnPreOrderFromCostSheet_Result.pordTotalAmount.GetValueOrDefault():N2}" + " " + wSspReturnPreOrderFromCostSheet_Result.pordCurrencyUnit + ")";
						}
						if (!string.IsNullOrEmpty(wSspReturnPreOrderFromCostSheet_Result.pordNumRef))
						{
							text2 = wSspReturnPreOrderFromCostSheet_Result.pordNumRef;
						}
						wSspSelectCostSheetsById_Result.PreOrderInfo = text2 + text3 + text4;
					}
				}
				currentCostSheetViewModel.Costsheet = wSspSelectCostSheetsById_Result;
				currentCostSheetViewModel.CtshCurrentId = wSspSelectCostSheetsById_Result.CostSheetId;
				currentCostSheetViewModel.Footer = Enumerable.FirstOrDefault<WSspReturnCostSheetSumFooter_Result>((IEnumerable<WSspReturnCostSheetSumFooter_Result>)_db.WSspReturnCostSheetSumFooter(wSspSelectCostSheetsById_Result.CostSheetId));
			}
			else
			{
				currentCostSheetViewModel.IsFind = false;
				currentCostSheetViewModel.Message = Messages.ErrorNotFound;
				currentCostSheetViewModel.Costsheet = null;
				currentCostSheetViewModel.CtshCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentCostSheetViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentCostSheetViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentCostSheetViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ActionResult _PartialCostSheetItems(int ctshId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetItems_Result> model = new List<WSspSelectCostSheetItems_Result>();
		try
		{
			model = Enumerable.ToList<WSspSelectCostSheetItems_Result>((IEnumerable<WSspSelectCostSheetItems_Result>)_db.WSspSelectCostSheetItems(ctshId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	public ActionResult _PartialCostSheetFieldValues(int ctshId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetDyFieldValues_Result> model = new List<WSspSelectCostSheetDyFieldValues_Result>();
		try
		{
			model = Enumerable.ToList<WSspSelectCostSheetDyFieldValues_Result>((IEnumerable<WSspSelectCostSheetDyFieldValues_Result>)_db.WSspSelectCostSheetDyFieldValues(ctshId, lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return PartialView(model);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actprdDelete")]
	public string ActCtshItemDelete(int ctshItemId, int ctshId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actprdDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshItemId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetItems(ctshItemId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
					CalculateCostShee(ctshId);
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actdyFieldValDelete")]
	public string ActCtshDyFieldValueDelete(int ctshValId, int ctshId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actdyFieldValDelete", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshValId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetDyFieldValues(ctshValId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
					CalculateCostShee(ctshId);
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	public void CalculateCostShee(int ctshId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int id = Financial.Get().Id;
			int userId = UserLogin.CurrentUser.UserId;
			_db.WSspCalculateCostSheet(ctshId, userId, value, registerDatePersian, id, value2, appType);
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

	[AjaxOnly]
	public string UpdateCostSheetItem(int ctshItemId, int ctshId, double? ctshIQuantity = null, double? ctshIWeight = null, decimal? ctshICost = null, double? ctshIRoundRate = null, double? ctshILength = null, double? ctshIWidth = null)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (ctshItemId > 0)
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				CRMSpEntities db = _db;
				int? costSheetId = ctshId;
				int? costSheetItemId = ctshItemId;
				int? userId2 = userId;
				int? fPId = id;
				short? month = value2;
				DateTime? registerDate = value;
				string registerDatePersian = text;
				string appType2 = appType;
				db.WSspUpdateCostSheetItemById(costSheetId, costSheetItemId, ctshIQuantity, ctshIWeight, ctshICost, ctshIRoundRate, userId2, fPId, month, registerDate, registerDatePersian, appType2, ctshILength, ctshIWidth);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actPostAndUpdate")]
	public string UpdateCostSheet(int ctshId, string valDetails)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actPostAndUpdate", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0 && !string.IsNullOrEmpty(valDetails))
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id2 = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				List<CostsheetIdKeyValueViewModel> list = new List<CostsheetIdKeyValueViewModel>();
				if (!string.IsNullOrEmpty(valDetails))
				{
					list = new JavaScriptSerializer().Deserialize<List<CostsheetIdKeyValueViewModel>>(valDetails);
				}
				if (Enumerable.Any<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list))
				{
					foreach (CostsheetIdKeyValueViewModel item in list)
					{
						if (item.IsUsed.HasValue && item.IsUsed != false)
						{
							continue;
						}
						string id = item.Id;
						int type = item.Type;
						_ = item.Tag;
						string value3 = item.Value;
						int result3 = 0;
						int.TryParse(id, out result3);
						switch (type)
						{
						case 1:
						{
							List<CostsheetIdKeyValueViewModel> list2 = Enumerable.ToList<CostsheetIdKeyValueViewModel>(Enumerable.Where<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Id == id)));
							if (Enumerable.Any<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2))
							{
								double result5 = 0.0;
								double result6 = 0.0;
								decimal result7 = default(decimal);
								string text2 = "";
								string text3 = "";
								string text4 = "";
								double result8 = 0.0;
								double result9 = 0.0;
								string text5 = "";
								string text6 = "";
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "A"));
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel2 = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "B"));
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel3 = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "C"));
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel4 = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "AA"));
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel5 = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "AAA"));
								if (costsheetIdKeyValueViewModel != null)
								{
									text3 = costsheetIdKeyValueViewModel.Value;
								}
								if (costsheetIdKeyValueViewModel2 != null)
								{
									text2 = costsheetIdKeyValueViewModel2.Value;
								}
								if (costsheetIdKeyValueViewModel3 != null)
								{
									text4 = costsheetIdKeyValueViewModel3.Value;
								}
								if (costsheetIdKeyValueViewModel4 != null)
								{
									text5 = costsheetIdKeyValueViewModel4.Value;
								}
								if (costsheetIdKeyValueViewModel5 != null)
								{
									text6 = costsheetIdKeyValueViewModel5.Value;
								}
								if (!string.IsNullOrEmpty(text3))
								{
									double.TryParse(text3, out result6);
								}
								if (!string.IsNullOrEmpty(text2))
								{
									double.TryParse(text2, out result5);
								}
								if (!string.IsNullOrEmpty(text4))
								{
									decimal.TryParse(text4, out result7);
								}
								if (!string.IsNullOrEmpty(text5))
								{
									double.TryParse(text5, out result8);
								}
								if (!string.IsNullOrEmpty(text6))
								{
									double.TryParse(text6, out result9);
								}
								double result10 = 0.0;
								string text7 = "";
								CostsheetIdKeyValueViewModel costsheetIdKeyValueViewModel6 = Enumerable.FirstOrDefault<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list2, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Tag == "I"));
								if (costsheetIdKeyValueViewModel6 != null)
								{
									text7 = costsheetIdKeyValueViewModel6.Value;
								}
								if (!string.IsNullOrEmpty(text7))
								{
									double.TryParse(text7, out result10);
								}
								_db.WSspUpdateCostSheetItemById(ctshId, result3, (!string.IsNullOrEmpty(text2)) ? new double?(result5) : null, (!string.IsNullOrEmpty(text3)) ? new double?(result6) : null, (!string.IsNullOrEmpty(text4)) ? new decimal?(result7) : null, userId: userId, fPId: id2, month1: value2, registerDate: value, registerDatePersian: text, appType: appType, ctshIRoundRate: (!string.IsNullOrEmpty(text7)) ? new double?(result10) : null, ctshILength: (!string.IsNullOrEmpty(text5)) ? new double?(result8) : null, ctshIWidth: (!string.IsNullOrEmpty(text6)) ? new double?(result9) : null);
								Enumerable.ToList<CostsheetIdKeyValueViewModel>(Enumerable.Select<CostsheetIdKeyValueViewModel, CostsheetIdKeyValueViewModel>(Enumerable.Where<CostsheetIdKeyValueViewModel>((IEnumerable<CostsheetIdKeyValueViewModel>)list, (Func<CostsheetIdKeyValueViewModel, bool>)((CostsheetIdKeyValueViewModel m) => m.Id == id)), (Func<CostsheetIdKeyValueViewModel, CostsheetIdKeyValueViewModel>)delegate(CostsheetIdKeyValueViewModel c)
								{
									c.IsUsed = true;
									return c;
								}));
							}
							break;
						}
						case 2:
						{
							decimal result4 = default(decimal);
							if (!string.IsNullOrEmpty(value3))
							{
								decimal.TryParse(value3, out result4);
							}
							_db.WSspUpdateCostSheetDyFieldValues(ctshId, result3, (!string.IsNullOrEmpty(value3)) ? new decimal?(result4) : null, null, userId, id2, value2, value, text, appType);
							item.IsUsed = true;
							break;
						}
						}
					}
				}
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actInsertDefaultDyFields")]
	public ActionResult AddCtshDyFieldTitle()
	{
		GetDyFieldGroups();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actInsertDefaultDyFields")]
	public string ActAddCtshDyFieldTitle(int ctshId, int groupId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actInsertDefaultDyFields", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0 && groupId > 0)
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspInsertCostSheetDyFieldValues(ctshId, groupId, userId, id, value2, value, registerDatePersian, appType, result2);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetDyFieldGroups()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<WSspSelectCostSheetDyFieldGroups_Result> list2 = Enumerable.ToList<WSspSelectCostSheetDyFieldGroups_Result>((IEnumerable<WSspSelectCostSheetDyFieldGroups_Result>)_db.WSspSelectCostSheetDyFieldGroups(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCostSheetDyFieldGroups_Result, SelectListItem>((IEnumerable<WSspSelectCostSheetDyFieldGroups_Result>)list2, (Func<WSspSelectCostSheetDyFieldGroups_Result, SelectListItem>)((WSspSelectCostSheetDyFieldGroups_Result item) => new SelectListItem
			{
				Text = (item.ctshDyFieldGroupName ?? ""),
				Value = item.CostSheetDyFieldGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actAddProduct")]
	public ActionResult SearchProduct()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult CostSheetProducts_Read([DataSourceRequest] DataSourceRequest request, int ctshPrjId, string val)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSearchCostSheetProducts_Result> enumerable = new List<WSspSearchCostSheetProducts_Result>();
		try
		{
			if (ctshPrjId > 0)
			{
				enumerable = Enumerable.ToList<WSspSearchCostSheetProducts_Result>((IEnumerable<WSspSearchCostSheetProducts_Result>)_db.WSspSearchCostSheetProducts(ctshPrjId, val, lCID, result));
			}
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
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actAddProduct")]
	public string ActAddCtshItemByPrdIds(int ctshId, string prdIds, int prjId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actAddProduct", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0 && !string.IsNullOrEmpty(prdIds) && prdIds != ",")
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspInsertCostSheetItems(ctshId, prjId, prdIds, userId, id, value2, value, registerDatePersian, appType, result2);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actSetMarkUpFormula")]
	public ActionResult UpdateMarkUpFormula()
	{
		GetFieldsForMarkupFormula();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actSetMarkUpFormula")]
	public string UpdateCostSheetMarkup(int ctshId, string formula)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actSetMarkUpFormula", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspUpdateCostSheetMarkup(ctshId, formula, userId, id, value2, value, registerDatePersian, appType);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actdyFieldValFormulaEdit")]
	public ActionResult UpdateCtshDyFieldValueFormula(int valId, int fieldId, int ctshDyFieldGroupId)
	{
		GetFields(fieldId, ctshDyFieldGroupId);
		base.ViewBag.FieldValueId = valId;
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actdyFieldValFormulaEdit")]
	public string ActUpdateCtshDyFieldValueFormula(int ctshId, int valId, string formula)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actdyFieldValFormulaEdit", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (valId > 0)
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspUpdateCostSheetDyFieldValues(ctshId, valId, null, formula, userId, id, value2, value, registerDatePersian, appType);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetFieldsForMarkupFormula()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string ctshConstantValueText = Labels.ctshConstantValueText;
			string ctshFormulaText = Labels.ctshFormulaText;
			List<WSspSelectCostSheetDyFieldTitle_Result> list2 = Enumerable.ToList<WSspSelectCostSheetDyFieldTitle_Result>((IEnumerable<WSspSelectCostSheetDyFieldTitle_Result>)_db.WSspSelectCostSheetDyFieldTitle(0, ctshConstantValueText, ctshFormulaText, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCostSheetDyFieldTitle_Result, SelectListItem>((IEnumerable<WSspSelectCostSheetDyFieldTitle_Result>)list2, (Func<WSspSelectCostSheetDyFieldTitle_Result, SelectListItem>)((WSspSelectCostSheetDyFieldTitle_Result item) => new SelectListItem
			{
				Text = (item.ctshDyFieldTitle ?? ""),
				Value = "[#" + item.ctshDyFieldTitleForFormula + "#]",
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetFields(int fieldId, int ctshDyFieldGroupId)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			string ctshConstantValueText = Labels.ctshConstantValueText;
			string ctshFormulaText = Labels.ctshFormulaText;
			List<WSspSelectCostSheetDyFieldTitleForFormula_Result> list2 = Enumerable.ToList<WSspSelectCostSheetDyFieldTitleForFormula_Result>((IEnumerable<WSspSelectCostSheetDyFieldTitleForFormula_Result>)_db.WSspSelectCostSheetDyFieldTitleForFormula(ctshDyFieldGroupId, fieldId, ctshConstantValueText, ctshFormulaText, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectCostSheetDyFieldTitleForFormula_Result, SelectListItem>((IEnumerable<WSspSelectCostSheetDyFieldTitleForFormula_Result>)list2, (Func<WSspSelectCostSheetDyFieldTitleForFormula_Result, SelectListItem>)((WSspSelectCostSheetDyFieldTitleForFormula_Result item) => new SelectListItem
			{
				Text = (item.ctshDyFieldTitle ?? ""),
				Value = "[#" + item.ctshDyFieldTitleForFormula + "#]",
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DyFieldsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string CostSheetVerify(int ctshId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actVerifyCostsheet", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (ctshId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				_ = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_db.WSspCostSheetVerify(ctshId, userId, value, registerDatePersian);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public string CostSheetVerifyExit(int ctshId)
	{
		string result = "";
		CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
		if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actExitFromIsFix", currentUser))
		{
			return Messages.DoNotHaveAccess;
		}
		try
		{
			if (ctshId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short.Parse(now.ToString("MM", new PersianCulture()));
				_ = Configuration.AppType;
				_ = Financial.Get().Id;
				_ = UserLogin.CurrentUser.UserId;
				_db.WSspCostSheetVerifyExit(ctshId, value, registerDatePersian);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetSuggestedBuyOrdert(int ctshItemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectCostSheetItemSuggestedBuyOrder_Result> list = new List<WSspSelectCostSheetItemSuggestedBuyOrder_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectCostSheetItemSuggestedBuyOrder_Result>((IEnumerable<WSspSelectCostSheetItemSuggestedBuyOrder_Result>)_db.WSspSelectCostSheetItemSuggestedBuyOrder(ctshItemId, lCID, result));
			if (Enumerable.Any<WSspSelectCostSheetItemSuggestedBuyOrder_Result>((IEnumerable<WSspSelectCostSheetItemSuggestedBuyOrder_Result>)list))
			{
				foreach (WSspSelectCostSheetItemSuggestedBuyOrder_Result item in list)
				{
					item.bordDate = (item.bordDateTime.HasValue ? item.bordDateTime.Value.ToString("yyyy/MM/dd") : null);
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
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actDeleteAllDyFieldValue")]
	public string DeleteAllDyFieldValue(int ctshId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actDeleteAllDyFieldValue", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetDyFieldValuesByCtshId(ctshId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
					CalculateCostShee(ctshId);
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actDeleteAllItems")]
	public string DeleteAllItems(int ctshId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actDeleteAllItems", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.WSspDeleteCostSheetItemsByCtshId(ctshId));
					if (mct_Result != null && mct_Result.Result > 0)
					{
						result = "";
					}
					else if (mct_Result != null && mct_Result.Result == 0)
					{
						result = Messages.RedundancyMessage;
					}
					CalculateCostShee(ctshId);
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					result = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					result = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
				}
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = Messages.msgErrorRunFunction;
		}
		return result;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actDeleteAllCtshWithItemsAndValues")]
	public string DeleteAllCtshWithItemsAndValues(int ctshId)
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
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actDeleteAllCtshWithItemsAndValues", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				try
				{
					if (Costsheet.IsFixed(ctshId))
					{
						return Messages.msgErrorCtshNotEditable;
					}
					WSspDeleteCostSheetWithItemsAndFieldValues_Result wSspDeleteCostSheetWithItemsAndFieldValues_Result = Enumerable.FirstOrDefault<WSspDeleteCostSheetWithItemsAndFieldValues_Result>((IEnumerable<WSspDeleteCostSheetWithItemsAndFieldValues_Result>)_db.WSspDeleteCostSheetWithItemsAndFieldValues(ctshId));
					text = ((wSspDeleteCostSheetWithItemsAndFieldValues_Result == null) ? Messages.msgErrorRunFunction : ((wSspDeleteCostSheetWithItemsAndFieldValues_Result.Result > 0) ? "" : ((wSspDeleteCostSheetWithItemsAndFieldValues_Result.Result == 0) ? Messages.RedundancyMessage : ((wSspDeleteCostSheetWithItemsAndFieldValues_Result.Result == -1) ? (Messages.RedundancyMessage + "<br>" + string.Format(Messages.msgErrorCtshUsedInBord, wSspDeleteCostSheetWithItemsAndFieldValues_Result.RecordNumber.GetValueOrDefault().ToString())) : ((wSspDeleteCostSheetWithItemsAndFieldValues_Result.Result != -2) ? Messages.RedundancyMessage : (Messages.RedundancyMessage + "<br>" + string.Format(Messages.msgErrorCtshUsedInPord, wSspDeleteCostSheetWithItemsAndFieldValues_Result.RecordNumber.GetValueOrDefault().ToString())))))));
					CalculateCostShee(ctshId);
				}
				catch (DbEntityValidationException e)
				{
					ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
					text = Messages.RedundancyMessage;
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					text = Messages.msgErrorCommunicateWithServer + "<br><p style=text-align:left;>" + ex.Message + "</p>";
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
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actGetCtshItemExcelFile")]
	public string GetCtshItemExcelFile(int ctshId, bool isShowAllColumns = true)
	{
		//IL_0997: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b2: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actGetCtshItemExcelFile", UserLogin.CurrentUser))
			{
				return "0|" + Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				string text2 = "";
				string text3 = "";
				string text4 = "";
				WSspSelectCostSheetsById_Result wSspSelectCostSheetsById_Result = Enumerable.FirstOrDefault<WSspSelectCostSheetsById_Result>((IEnumerable<WSspSelectCostSheetsById_Result>)_db.WSspSelectCostSheetsById(ctshId, lCID, result2));
				if (wSspSelectCostSheetsById_Result != null)
				{
					text2 = (string.IsNullOrWhiteSpace(wSspSelectCostSheetsById_Result.ctshSrcCurrencyUnit) ? "" : (" (" + wSspSelectCostSheetsById_Result.ctshSrcCurrencyUnit + ")"));
					text3 = (string.IsNullOrWhiteSpace(wSspSelectCostSheetsById_Result.ctshDestCurrencyUnit) ? "" : (" (" + wSspSelectCostSheetsById_Result.ctshDestCurrencyUnit + ")"));
					text4 = (wSspSelectCostSheetsById_Result.ctshMarkup.HasValue ? wSspSelectCostSheetsById_Result.ctshMarkup.ToString() : "");
				}
				List<WSspSelectCostSheetItems_Result> list = Enumerable.ToList<WSspSelectCostSheetItems_Result>((IEnumerable<WSspSelectCostSheetItems_Result>)_db.WSspSelectCostSheetItems(ctshId, lCID, result2));
				if (list != null && Enumerable.Any<WSspSelectCostSheetItems_Result>((IEnumerable<WSspSelectCostSheetItems_Result>)list))
				{
					ExcelPackage excelPackage = new ExcelPackage();
					ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.CtshExcelPropertiesTitle);
					int num = 0;
					int num2 = 1;
					num++;
					excelWorksheet.Cells[num2, num].Value = Labels.Row;
					num++;
					excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListProduct;
					if (isShowAllColumns)
					{
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListPrdGroup;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListWeight;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListLength;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListWidth;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListQuantity;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListCost + text2;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListTotalCost + text2;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListDesctCurrencyCost + text3;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListDesctCurrencyTotalCost + text3;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListMarkup;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListPrice + text3;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListRoundRate;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListPriceRounded + text3;
						num++;
						excelWorksheet.Cells[num2, num].Value = Labels.CtshItemListTotalPrice + text3;
					}
					int num3 = 1;
					foreach (WSspSelectCostSheetItems_Result item in list)
					{
						num2++;
						num = 0;
						num++;
						excelWorksheet.Cells[num2, num].Value = num3.ToString();
						num++;
						excelWorksheet.Cells[num2, num].Value = item.CostSheetProduct ?? "";
						if (isShowAllColumns)
						{
							num++;
							excelWorksheet.Cells[num2, num].Value = item.ctshPrdGroup ?? "";
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIWeight.HasValue ? item.ctshIWeight.ToString() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshILength.HasValue ? item.ctshILength.ToString() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIWidth.HasValue ? item.ctshIWidth.ToString() : "");
							num++;
							ExcelRange excelRange = excelWorksheet.Cells[num2, num];
							_ = item.ctshIQuantity;
							excelRange.Value = item.ctshIQuantity.ToString();
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshICost.HasValue ? item.ctshICost.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshITotalCost.HasValue ? item.ctshITotalCost.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIDesctCurrencyCost.HasValue ? item.ctshIDesctCurrencyCost.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIDesctCurrencyTotalCost.HasValue ? item.ctshIDesctCurrencyTotalCost.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = text4 ?? "";
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIPrice.HasValue ? item.ctshIPrice.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIRoundRate.HasValue ? item.ctshIRoundRate.ToString() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshIPriceRounded.HasValue ? item.ctshIPriceRounded.ToString().FormatForPrice() : "");
							num++;
							excelWorksheet.Cells[num2, num].Value = (item.ctshITotalPrice.HasValue ? item.ctshITotalPrice.ToString().FormatForPrice() : "");
						}
						num3++;
					}
					string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Costsheets\\" + userId;
					string text6 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
					string path = text5 + "\\" + text6;
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text5);
						FileInfo[] files = directoryInfo.GetFiles();
						for (int i = 0; i < files.Length; i++)
						{
							files[i].Delete();
						}
						DirectoryInfo[] directories = directoryInfo.GetDirectories();
						for (int i = 0; i < directories.Length; i++)
						{
							directories[i].Delete(recursive: true);
						}
						if (System.IO.Directory.Exists(text5))
						{
							System.IO.Directory.Delete(text5);
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					if (!System.IO.Directory.Exists(text5))
					{
						System.IO.Directory.CreateDirectory(text5);
						CRM.General.IO.Directory.SetFullControlForEveryOne(text5);
					}
					using (ExcelRange excelRange2 = excelWorksheet.Cells[1, 1, 1, num])
					{
						excelRange2.Style.Font.Bold = true;
						excelRange2.Style.Fill.PatternType = ExcelFillStyle.Solid;
						excelRange2.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
						excelRange2.Style.Font.Color.SetColor(Color.White);
					}
					excelPackage.Workbook.Properties.Title = Labels.CtshExcelPropertiesTitle;
					excelPackage.Workbook.Properties.Company = Labels.CtshExcelPropertiesCompany;
					Stream stream = System.IO.File.Create(path);
					excelPackage.SaveAs(stream);
					stream.Close();
					if (System.IO.File.Exists(path))
					{
						text = Configuration.HostTempFilesPath + "/Costsheets/" + userId + "/" + text6;
						text = text.Replace("~/", "/");
						text = (text.StartsWith("/") ? text : ("/" + text));
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						result = "1|" + text;
					}
				}
				else
				{
					result = "0|" + Messages.ErrorNotFound;
				}
			}
			else
			{
				result = "0|" + Messages.ErrorNotFound;
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			result = "0|" + Messages.msgErrorRunFunction;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actSetMarkUpSumFormula")]
	public ActionResult UpdateMarkUpSumFormula()
	{
		GetFieldsForMarkupFormula();
		return View();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmCostsheetDetails", ActionName = "actSetMarkUpSumFormula")]
	public string UpdateCostSheetMarkupSum(int ctshId, string formula)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (!UserLogin.IsUserAccess("frmCostsheetDetails", "actSetMarkUpSumFormula", UserLogin.CurrentUser))
			{
				return Messages.ErrorNotAccess;
			}
			if (ctshId > 0)
			{
				if (Costsheet.IsFixed(ctshId))
				{
					return Messages.msgErrorCtshNotEditable;
				}
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				int id = Financial.Get().Id;
				int userId = UserLogin.CurrentUser.UserId;
				_dbI.WSspUpdateCostSheetMarkupSum(ctshId, formula, userId, id, value2, value, registerDatePersian, appType);
				CalculateCostShee(ctshId);
			}
			else
			{
				result = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = Messages.msgErrorRunFunction + "<br>" + ex.Message;
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
