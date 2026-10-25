using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Products.Controllers;

public class ExportExcelController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	[AjaxOnly]
	public string UpdateSelectorStatus(int recId, int mode)
	{
		string text = "";
		try
		{
			bool value = mode == 1;
			if (recId > 0)
			{
				_db.WSspUpdateSelectUnSelectProductImportFromExcelFields(recId, value);
				return "1|" + Messages.msgSuccessAction;
			}
			return "-1|" + Messages.ErrorNotFound;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return "-1|" + Messages.msgErrorRunFunction;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdExportExcel")]
	public ActionResult Login()
	{
		base.ViewBag.IsBuying = VersionBuyer.ProductExportExcel;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdExportExcel")]
	[HttpPost]
	[AllowAnonymous]
	[ValidateAntiForgeryToken]
	public ActionResult Login(LoginViewModel login)
	{
		base.ViewBag.IsBuying = VersionBuyer.ProductImportExcel;
		try
		{
			if (UserLogin.CurrentUser == null)
			{
				base.ViewBag.Error = Messages.ErrorNotAccess;
				return View(login);
			}
			if (base.ModelState.IsValid)
			{
				string text = new BaseInfo().ConvertMd5(login.Password).ToLower();
				CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
				if (!(login.UserName == currentUser.UserName) || !(text == currentUser.Password))
				{
					base.ViewBag.Error = Messages.msgErrorPasswordIsWrong;
				}
				else
				{
					base.ViewBag.Successful = "True";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(login);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdExportExcel")]
	public ActionResult Index(int sgId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductImportFromExcelFields_Result> list = new List<WSspSelectProductImportFromExcelFields_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldList = list;
		base.ViewBag.PrdSecondGroupId = sgId;
		CommonTreeViewItemViewModel model = new CommonTreeViewItemViewModel
		{
			Id = sgId.ToString(),
			Text = ""
		};
		return View(model);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdExportExcel")]
	[HttpPost]
	public ActionResult Index(CommonTreeViewItemViewModel model)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspSelectProductImportFromExcelFields_Result> list = new List<WSspSelectProductImportFromExcelFields_Result>();
		try
		{
			list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FieldList = list;
		base.ViewBag.PrdSecondGroupId = model.Id;
		int.TryParse(model.Id, out var result2);
		Export2File(result2);
		return View(model);
	}

	public static object GetPropValue(object src, string propName)
	{
		try
		{
			return src.GetType().GetProperty(propName).GetValue(src, null);
		}
		catch
		{
			return "";
		}
	}

	public void Export2File(int gid)
	{
		//IL_0b3a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b55: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<WSspSelectProductImportFromExcelFields_Result> list = Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>(Enumerable.Where<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)Enumerable.ToList<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)_db.WSspSelectProductImportFromExcelFields(lCID, result)), (Func<WSspSelectProductImportFromExcelFields_Result, bool>)((WSspSelectProductImportFromExcelFields_Result c) => c.IsActive.GetValueOrDefault() && c.Selector.GetValueOrDefault())));
			if (!Enumerable.Any<WSspSelectProductImportFromExcelFields_Result>((IEnumerable<WSspSelectProductImportFromExcelFields_Result>)list))
			{
				return;
			}
			List<WSspSelectProducts_Result> list2 = new List<WSspSelectProducts_Result>();
			list2 = (VersionBuyer.ProductExportExcel ? Enumerable.ToList<WSspSelectProducts_Result>(Enumerable.Where<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result)), (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result c) => c.PrdGroupID == gid))) : Enumerable.ToList<WSspSelectProducts_Result>(Enumerable.Take<WSspSelectProducts_Result>(Enumerable.Where<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result)), (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result c) => c.PrdGroupID == gid)), 2)));
			List<WSspSelectProductFirstGroup_Result> list3 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			List<WSspSelectProductSecondGroup_Result> list4 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)_db.WSspSelectProductSecondGroup(0, lCID, result));
			if (!Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list2))
			{
				return;
			}
			List<WSspSelectProductColor_Result> list5 = Enumerable.ToList<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)_db.WSspSelectProductColor(lCID, result));
			List<WSspSelectProductPriceGroup_Result> list6 = Enumerable.ToList<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)_db.WSspSelectProductPriceGroup(lCID, result));
			List<WSspSelectProductCostGroup_Result> list7 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			List<WSspSelectProductUnits_Result> list8 = Enumerable.ToList<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result));
			List<WSspSelectCurrencyUnits_Result> list9 = Enumerable.ToList<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)_db.WSspSelectCurrencyUnits(lCID, result));
			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.ProductExportExcelPropertiesTitle);
			int num = 0;
			int num2 = 1;
			foreach (WSspSelectProductImportFromExcelFields_Result item in list)
			{
				num++;
				excelWorksheet.Cells[num2, num].Value = item.FieldCaption;
			}
			foreach (WSspSelectProducts_Result itemProduct in list2)
			{
				WSspSelectProductPrice_Result wSspSelectProductPrice_Result = Enumerable.LastOrDefault<WSspSelectProductPrice_Result>((IEnumerable<WSspSelectProductPrice_Result>)Enumerable.ToList<WSspSelectProductPrice_Result>((IEnumerable<WSspSelectProductPrice_Result>)Enumerable.OrderBy<WSspSelectProductPrice_Result, string>(Enumerable.Where<WSspSelectProductPrice_Result>((IEnumerable<WSspSelectProductPrice_Result>)Enumerable.ToList<WSspSelectProductPrice_Result>((IEnumerable<WSspSelectProductPrice_Result>)_db.WSspSelectProductPrice(lCID, result)), (Func<WSspSelectProductPrice_Result, bool>)((WSspSelectProductPrice_Result c) => c.PrdId == itemProduct.ProductID)), (Func<WSspSelectProductPrice_Result, string>)((WSspSelectProductPrice_Result c) => c.DocDate))));
				WSspSelectProductCost_Result wSspSelectProductCost_Result = Enumerable.LastOrDefault<WSspSelectProductCost_Result>((IEnumerable<WSspSelectProductCost_Result>)Enumerable.ToList<WSspSelectProductCost_Result>((IEnumerable<WSspSelectProductCost_Result>)Enumerable.OrderBy<WSspSelectProductCost_Result, string>(Enumerable.Where<WSspSelectProductCost_Result>((IEnumerable<WSspSelectProductCost_Result>)Enumerable.ToList<WSspSelectProductCost_Result>((IEnumerable<WSspSelectProductCost_Result>)_db.WSspSelectProductCost(lCID, result)), (Func<WSspSelectProductCost_Result, bool>)((WSspSelectProductCost_Result c) => c.PrdId == itemProduct.ProductID)), (Func<WSspSelectProductCost_Result, string>)((WSspSelectProductCost_Result c) => c.DocDate))));
				num2++;
				num = 0;
				foreach (WSspSelectProductImportFromExcelFields_Result item2 in list)
				{
					object obj = null;
					num++;
					switch (item2.GroupNum)
					{
					case 1:
						switch (item2.FieldName)
						{
						case "PrdColorId":
							obj = GetPropValue(itemProduct, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var prdColorId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)list5, (Func<WSspSelectProductColor_Result, bool>)((WSspSelectProductColor_Result c) => c.ProductColorID == prdColorId)) ? (Enumerable.FirstOrDefault<WSspSelectProductColor_Result>((IEnumerable<WSspSelectProductColor_Result>)list5, (Func<WSspSelectProductColor_Result, bool>)((WSspSelectProductColor_Result c) => c.ProductColorID == prdColorId)).Color + ": " + prdColorId) : prdColorId.ToString());
							}
							break;
						case "PrdUnitId":
							obj = GetPropValue(itemProduct, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var prdUnitId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list8, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result c) => c.ProductUnitID == prdUnitId)) ? (Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list8, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result c) => c.ProductUnitID == prdUnitId)).Unit + ": " + prdUnitId) : prdUnitId.ToString());
							}
							break;
						case "PrdSecondGroupId":
							obj = GetPropValue(itemProduct, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var prdSecondGroupId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)list4, (Func<WSspSelectProductSecondGroup_Result, bool>)((WSspSelectProductSecondGroup_Result c) => c.PrdSecondGroupID == prdSecondGroupId)) ? (Enumerable.FirstOrDefault<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)list4, (Func<WSspSelectProductSecondGroup_Result, bool>)((WSspSelectProductSecondGroup_Result c) => c.PrdSecondGroupID == prdSecondGroupId)).SGName + ": " + prdSecondGroupId) : prdSecondGroupId.ToString());
							}
							break;
						case "PrdFirstGroupId":
							obj = GetPropValue(itemProduct, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var prdFirstGroupId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)list3, (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == prdFirstGroupId)) ? (Enumerable.FirstOrDefault<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)list3, (Func<WSspSelectProductFirstGroup_Result, bool>)((WSspSelectProductFirstGroup_Result c) => c.PrdFirstGroupID == prdFirstGroupId)).FGName + ": " + prdFirstGroupId) : prdFirstGroupId.ToString());
							}
							break;
						default:
							excelWorksheet.Cells[num2, num].Value = GetPropValue(itemProduct, item2.FieldName);
							break;
						}
						break;
					case 2:
						if (wSspSelectProductPrice_Result == null)
						{
							break;
						}
						switch (item2.FieldName)
						{
						case "ProductPriceGroupId":
							obj = GetPropValue(wSspSelectProductPrice_Result, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var productPriceGroupId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)list6, (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result c) => c.ProductPriceGroupID == productPriceGroupId)) ? (Enumerable.FirstOrDefault<WSspSelectProductPriceGroup_Result>((IEnumerable<WSspSelectProductPriceGroup_Result>)list6, (Func<WSspSelectProductPriceGroup_Result, bool>)((WSspSelectProductPriceGroup_Result c) => c.ProductPriceGroupID == productPriceGroupId)).ProductPriceGroupName + ": " + productPriceGroupId) : productPriceGroupId.ToString());
							}
							break;
						case "DocDate":
							obj = GetPropValue(wSspSelectProductPrice_Result, item2.FieldName);
							if (obj != null)
							{
								string text2 = obj.ToString();
								if (text2 != "")
								{
									excelWorksheet.Cells[num2, num].Value = PersianDate.GetFormatetdDate(text2);
								}
							}
							break;
						case "CurrencyUnitId":
							obj = GetPropValue(wSspSelectProductPrice_Result, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var currencyUnitId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)list9, (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result c) => c.CurrencyUnitID == currencyUnitId)) ? (Enumerable.FirstOrDefault<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)list9, (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result c) => c.CurrencyUnitID == currencyUnitId)).CurrencyUnit + ": " + currencyUnitId) : currencyUnitId.ToString());
							}
							break;
						default:
							excelWorksheet.Cells[num2, num].Value = GetPropValue(wSspSelectProductPrice_Result, item2.FieldName);
							break;
						}
						break;
					case 3:
						if (wSspSelectProductCost_Result == null)
						{
							break;
						}
						switch (item2.FieldName)
						{
						case "ProductCostGroupId":
							obj = GetPropValue(wSspSelectProductCost_Result, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var productCostGroupId);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)list7, (Func<WSspSelectProductCostGroup_Result, bool>)((WSspSelectProductCostGroup_Result c) => c.ProductCostGroupID == productCostGroupId)) ? (Enumerable.FirstOrDefault<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)list7, (Func<WSspSelectProductCostGroup_Result, bool>)((WSspSelectProductCostGroup_Result c) => c.ProductCostGroupID == productCostGroupId)).ProductCostGroupName + ": " + productCostGroupId) : productCostGroupId.ToString());
							}
							break;
						case "DocDate":
							obj = GetPropValue(wSspSelectProductCost_Result, item2.FieldName);
							if (obj != null)
							{
								string text = obj.ToString();
								if (text != "")
								{
									excelWorksheet.Cells[num2, num].Value = PersianDate.GetFormatetdDate(text);
								}
							}
							break;
						case "CurrencyUnitId":
							obj = GetPropValue(wSspSelectProductCost_Result, item2.FieldName);
							if (obj != null)
							{
								int.TryParse(obj.ToString(), out var currencyUnitId2);
								excelWorksheet.Cells[num2, num].Value = (Enumerable.Any<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)list9, (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result c) => c.CurrencyUnitID == currencyUnitId2)) ? (Enumerable.FirstOrDefault<WSspSelectCurrencyUnits_Result>((IEnumerable<WSspSelectCurrencyUnits_Result>)list9, (Func<WSspSelectCurrencyUnits_Result, bool>)((WSspSelectCurrencyUnits_Result c) => c.CurrencyUnitID == currencyUnitId2)).CurrencyUnit + ": " + currencyUnitId2) : currencyUnitId2.ToString());
							}
							break;
						default:
							excelWorksheet.Cells[num2, num].Value = GetPropValue(wSspSelectProductCost_Result, item2.FieldName);
							break;
						}
						break;
					default:
						excelWorksheet.Cells[num2, num].Value = item2.FieldCaption;
						break;
					}
				}
			}
			using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
			{
				excelRange.Style.Font.Bold = true;
				excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
				excelRange.Style.Font.Color.SetColor(Color.White);
			}
			excelPackage.Workbook.Properties.Title = Labels.ProductExportExcelPropertiesTitle;
			excelPackage.Workbook.Properties.Company = Labels.ProductExportExcelPropertiesCompany;
			excelPackage.SaveAs(base.Response.OutputStream);
			base.Response.Buffer = true;
			base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
			base.Response.ContentType = "application/ms-excel";
			base.Response.Charset = "";
			base.Response.Flush();
			base.Response.End();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}
}
