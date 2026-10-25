using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using Elmah;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.ImportExcel.Controllers;

public class HomeController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Index(string sysPartKey = "")
	{
		base.ViewBag.SystemParts = JsonConvert.SerializeObject(VersionBuyerList.GetImportExcel(sysPartKey));
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public List<CRMspSelectImportExcelFields_Result> SelectImportExcelFieldsList(int systemPartId = 0)
	{
		List<CRMspSelectImportExcelFields_Result> result = new List<CRMspSelectImportExcelFields_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectImportExcelFields_Result> list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)_dbI.CRMspSelectImportExcelFields(systemPartId, lCID, result2));
			if (list != null)
			{
				if (!Center.HaveModule)
				{
					switch (systemPartId)
					{
					case 140:
						list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>(Enumerable.Where<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName != "UserCIds" && x.FieldName != "UserCenterCode")));
						break;
					case 10:
						list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>(Enumerable.Where<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName != "cmpCId" && x.FieldName != "prsCId" && x.FieldName != "prjCId" && x.FieldName != "cnvsCId")));
						list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>(Enumerable.Where<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName != "cmpCenterCode" && x.FieldName != "prsCenterCode" && x.FieldName != "prjCenterCode" && x.FieldName != "cnvsCenterCode")));
						break;
					}
				}
				if (systemPartId == 10)
				{
					bool flag = true;
					List<CRMspSelectLinkAccSettingDBAll_Result> list2 = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingDBAll();
					if (list2 != null && list2.Count > 0 && Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBAll_Result>((IEnumerable<CRMspSelectLinkAccSettingDBAll_Result>)list2, (Func<CRMspSelectLinkAccSettingDBAll_Result, bool>)((CRMspSelectLinkAccSettingDBAll_Result x) => x.LinkAccSystemId > -1)) != null)
					{
						flag = false;
					}
					if (flag)
					{
						list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>(Enumerable.Where<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.FieldName != "LinkAccSettingDBId" && x.FieldName != "cmpLinkAccCode")));
					}
				}
				result = list;
			}
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	[HttpPost]
	[LoginAuthorize]
	public string SelectImportExcelFields(int systemPartId = 0)
	{
		string value = "";
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectImportExcelFieldGroups_Result> list = Enumerable.ToList<CRMspSelectImportExcelFieldGroups_Result>((IEnumerable<CRMspSelectImportExcelFieldGroups_Result>)_dbI.CRMspSelectImportExcelFieldGroups(systemPartId, lCID, result));
			if (list != null)
			{
				text = JsonConvert.SerializeObject(list);
			}
			value = JsonConvert.SerializeObject(SelectImportExcelFieldsList(systemPartId));
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return JsonConvert.SerializeObject(new SelectListItem
		{
			Text = text,
			Value = value
		});
	}

	[LoginAuthorize]
	public ActionResult GenerateExcelWithSelectedFields(int systemPartId = 0)
	{
		//IL_013e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0159: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string viewName = "";
		try
		{
			List<CRMspSelectImportExcelFields_Result> list = SelectImportExcelFieldsList(systemPartId);
			if (list != null)
			{
				list = Enumerable.ToList<CRMspSelectImportExcelFields_Result>(Enumerable.Where<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list, (Func<CRMspSelectImportExcelFields_Result, bool>)((CRMspSelectImportExcelFields_Result x) => x.Selector.GetValueOrDefault())));
			}
			if (list != null && Enumerable.Any<CRMspSelectImportExcelFields_Result>((IEnumerable<CRMspSelectImportExcelFields_Result>)list))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OrderImportExcelPropertiesTitle);
				int num = 0;
				foreach (CRMspSelectImportExcelFields_Result item in list)
				{
					num++;
					excelWorksheet.Cells[1, num].Value = item.FieldCaption;
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OrderImportExcelPropertiesTitle;
				excelPackage.SaveAs(base.Response.OutputStream);
				base.Response.Buffer = true;
				base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
				base.Response.ContentType = "application/ms-excel";
				base.Response.Charset = "";
				base.Response.Flush();
				base.Response.End();
			}
			else
			{
				viewName = string.Format(Messages.msgErrorIsNotSelectedItem, Labels.Column);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View(viewName);
	}

	[HttpPost]
	[LoginAuthorize]
	public bool UpdateImportExcelSelectedFields(int systemPartId = 0, int id = 0, bool state = false, bool isAll = false, int groupId = 0)
	{
		bool result = false;
		try
		{
			_dbI.CRMspUpdateImportExcelSelectedFields(systemPartId, id, state, isAll: isAll, groupId: groupId);
			result = true;
		}
		catch (Exception ex)
		{
			Public.InsExceptToElmah(ex);
		}
		return result;
	}

	public ActionResult UploadFile(HttpPostedFileBase attachFileUrlUpload)
	{
		CommonSelectListItemViewModel commonSelectListItemViewModel = new CommonSelectListItemViewModel();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			_ = DateTime.Now;
			object[,] array = null;
			int num = 0;
			int num2 = 0;
			byte[] buffer = new byte[base.Request.ContentLength];
			base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
			using ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream);
			ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
			num = excelWorksheet.Dimension.End.Column;
			num2 = excelWorksheet.Dimension.End.Row;
			array = new object[num2, num];
			array = (object[,])excelWorksheet.Cells.Value;
			if (num2 > 3000)
			{
				commonSelectListItemViewModel.Message = string.Format(Labels.ImportExcelUploadFileHasMoreRecThan, "3000");
				num2 = 3000;
			}
			object[,] array2 = new object[num2, num];
			for (int i = 0; i < num2; i++)
			{
				for (int j = 0; j < num; j++)
				{
					array2[i, j] = array[i, j];
				}
			}
			array = array2;
			commonSelectListItemViewModel.Value = JsonConvert.SerializeObject(array);
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			commonSelectListItemViewModel.Message = ex.Message;
		}
		return Content(JsonConvert.SerializeObject(commonSelectListItemViewModel));
	}

	private void FinishXlsJob(string FilePath = "")
	{
		try
		{
			if (System.IO.File.Exists(FilePath))
			{
				System.IO.File.Delete(FilePath);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
	}

	[LoginAuthorize]
	public ActionResult SaveErrorsAsExcel(string js = "")
	{
		if (!string.IsNullOrWhiteSpace(js))
		{
			List<ImpExcelErrors> list = JsonConvert.DeserializeObject<List<ImpExcelErrors>>(js);
			using ExcelPackage excelPackage = new ExcelPackage(new FileInfo("CRM-ImportExcelErrors.xls"));
			if (!Enumerable.Any<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets, (Func<ExcelWorksheet, bool>)((ExcelWorksheet ar) => ar.Name == "Errors")))
			{
				excelPackage.Workbook.Worksheets.Add("Errors");
			}
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets["Errors"];
			excelWorksheet.Cells[1, 1].Value = "Row";
			excelWorksheet.Cells[1, 2].Value = "Col";
			excelWorksheet.Cells[1, 3].Value = "Data";
			excelWorksheet.Cells[1, 4].Value = "Reason";
			int num = 2;
			foreach (ImpExcelErrors item in list)
			{
				excelWorksheet.Cells[num, 1].Value = item.Row;
				excelWorksheet.Cells[num, 2].Value = item.ColName;
				excelWorksheet.Cells[num, 3].Value = item.Data;
				excelWorksheet.Cells[num, 4].Value = item.Reason;
				num++;
			}
			excelPackage.SaveAs(base.Response.OutputStream);
			base.Response.Buffer = true;
			base.Response.AddHeader("content-disposition", "attachment; filename=CRM-ImportExcelErrors.xls");
			base.Response.ContentType = "application/ms-excel";
			base.Response.Charset = "";
			base.Response.Flush();
			base.Response.End();
		}
		return View();
	}

	[HttpPost]
	[LoginAuthorize]
	public string GetCentersHelpList()
	{
		List<SelectListItem> actives_SelectListItem = Center.GetActives_SelectListItem();
		foreach (SelectListItem item in actives_SelectListItem)
		{
			item.Text = item.Text + " ( " + item.Value + " )";
		}
		return JsonConvert.SerializeObject(actives_SelectListItem);
	}

	[HttpPost]
	[LoginAuthorize]
	public int GetDayOfWeekNum(string dtPersian = "", bool sqlFormat = false)
	{
		bool sqlFormat2 = sqlFormat;
		return DateTimeClass.GetDayOfWeekNum(dtPersian, null, sqlFormat2);
	}
}
