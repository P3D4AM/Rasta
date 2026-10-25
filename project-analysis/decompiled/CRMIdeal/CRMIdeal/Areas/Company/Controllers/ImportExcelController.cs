using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Company.Controllers;

public class ImportExcelController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public const string EXCEL_SHEET_NAME = "CrmIdeal";

	private CmpExcelFieldsList exFields = new CmpExcelFieldsList();

	private const string DFAULT_EXCEL_SHEET_NAME = "CrmIdeal";

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCmpImportExcel")]
	public ActionResult Index()
	{
		base.ViewBag.IsBuying = VersionBuyer.CmpImportExcel;
		return View(GetAllFields());
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

	public ActionResult _PartialSelectFields()
	{
		SelectPersonTitleHelp();
		return PartialView("_PartialSelectFields", GetAllFields());
	}

	public bool UpdateSelectedFields(int id = 0, bool status = false)
	{
		bool result = false;
		try
		{
			if (id == 0)
			{
				result = false;
			}
			else
			{
				_db.CRMspUpdateImportFromExcelFieldsSelector(id, status);
				result = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool UpdateSelectedFieldsAll(int groupNum = 0, bool Status = false)
	{
		if (groupNum != 0)
		{
			try
			{
				_db.CRMspUpdateImportFromExcelFieldsSelectorAll(groupNum, Status);
				return true;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				return false;
			}
		}
		return false;
	}

	public JsonResult SelectPersonTitleHelp()
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
			List<CRMspSelectPersonTitle_Result> list2 = Enumerable.ToList<CRMspSelectPersonTitle_Result>((IEnumerable<CRMspSelectPersonTitle_Result>)_db.CRMspSelectPersonTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonTitle_Result, SelectListItem>((IEnumerable<CRMspSelectPersonTitle_Result>)list2, (Func<CRMspSelectPersonTitle_Result, SelectListItem>)((CRMspSelectPersonTitle_Result item) => new SelectListItem
			{
				Text = item.PersonTitle + " (" + item.PersonTitleID + ")",
				Value = item.PersonTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PersonTitleHelp = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public ActionResult GenerateExcelWithSelectedFields()
	{
		//IL_0119: Unknown result type (might be due to invalid IL or missing references)
		//IL_0134: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspSelectImportFromExcelFieldsWithSelected_Result> list = Enumerable.ToList<CRMspSelectImportFromExcelFieldsWithSelected_Result>((IEnumerable<CRMspSelectImportFromExcelFieldsWithSelected_Result>)_db.CRMspSelectImportFromExcelFieldsWithSelected(lCID, result));
			if (Enumerable.Any<CRMspSelectImportFromExcelFieldsWithSelected_Result>((IEnumerable<CRMspSelectImportFromExcelFieldsWithSelected_Result>)list))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add("CrmIdeal");
				int num = 0;
				foreach (CRMspSelectImportFromExcelFieldsWithSelected_Result item in list)
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
				excelPackage.Workbook.Properties.Title = Labels.CmpImportExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.CmpImportExcelPropertiesCompany;
				excelPackage.SaveAs(base.Response.OutputStream);
				base.Response.Buffer = true;
				base.Response.AddHeader("content-disposition", "attachment; filename=CRM-Ideal.xls");
				base.Response.ContentType = "application/ms-excel";
				base.Response.Charset = "";
				base.Response.Flush();
				base.Response.End();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	private CmpExcelFieldsList GetAllFields()
	{
		List<CmpImportFromExcelFieldsViewModel> list = new List<CmpImportFromExcelFieldsViewModel>();
		List<CmpImportUserSelectedFieldsViewModel> list2 = new List<CmpImportUserSelectedFieldsViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			foreach (CRMspSelectImportFromExcelFields_Result item in _db.CRMspSelectImportFromExcelFields(lCID, result))
			{
				CmpImportFromExcelFieldsViewModel cmpImportFromExcelFieldsViewModel = new CmpImportFromExcelFieldsViewModel();
				cmpImportFromExcelFieldsViewModel.Id = item.Id;
				cmpImportFromExcelFieldsViewModel.FieldName = item.FieldName;
				cmpImportFromExcelFieldsViewModel.FieldCaption = item.FieldCaption;
				cmpImportFromExcelFieldsViewModel.FieldType = item.FieldType;
				cmpImportFromExcelFieldsViewModel.FieldWidth = item.FieldWidth.GetValueOrDefault();
				cmpImportFromExcelFieldsViewModel.GroupNum = item.GroupNum.GetValueOrDefault();
				cmpImportFromExcelFieldsViewModel.IsActive = item.IsActive.GetValueOrDefault();
				cmpImportFromExcelFieldsViewModel.Selector = item.Selector.GetValueOrDefault();
				cmpImportFromExcelFieldsViewModel.HaveSearch = item.HaveSearch.GetValueOrDefault();
				if (item.Selector.GetValueOrDefault())
				{
					CmpImportUserSelectedFieldsViewModel cmpImportUserSelectedFieldsViewModel = new CmpImportUserSelectedFieldsViewModel();
					cmpImportUserSelectedFieldsViewModel.Id = item.Id;
					cmpImportUserSelectedFieldsViewModel.FieldName = item.FieldName;
					cmpImportUserSelectedFieldsViewModel.FieldCaption = item.FieldCaption;
					cmpImportUserSelectedFieldsViewModel.FieldType = item.FieldType;
					cmpImportUserSelectedFieldsViewModel.FieldWidth = item.FieldWidth.GetValueOrDefault();
					cmpImportUserSelectedFieldsViewModel.GroupNum = item.GroupNum.GetValueOrDefault();
					cmpImportUserSelectedFieldsViewModel.IsActive = item.IsActive.GetValueOrDefault();
					cmpImportUserSelectedFieldsViewModel.Selector = item.Selector.GetValueOrDefault();
					cmpImportUserSelectedFieldsViewModel.HaveSearch = item.HaveSearch.GetValueOrDefault();
					list2.Add(cmpImportUserSelectedFieldsViewModel);
				}
				list.Add(cmpImportFromExcelFieldsViewModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		exFields.ImportFromExcelFieldsList = list;
		exFields.UserSelectedFieldsList = list2;
		return exFields;
	}

	private bool DeleteImportedExcelData()
	{
		try
		{
			mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspDeleteImportFromExcel());
			if (mct_Result != null)
			{
				if (mct_Result.Result == 1)
				{
					return true;
				}
				return false;
			}
			return false;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCmpImportExcel")]
	public ActionResult _PartialImportExcel(int withDelete = 0)
	{
		if (withDelete == 1)
		{
			DeleteImportedExcelData();
		}
		return PartialView("_PartialImportExcel", GetAllFields());
	}

	public ActionResult ImportedExcel_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<CRMspSelectImportFromExcel_Result> enumerable = new List<CRMspSelectImportFromExcel_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspSelectImportFromExcel_Result>((IEnumerable<CRMspSelectImportFromExcel_Result>)_db.CRMspSelectImportFromExcel());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult UserSelectedFields_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<CmpImportUserSelectedFieldsViewModel> enumerable = new List<CmpImportUserSelectedFieldsViewModel>();
		try
		{
			enumerable = Enumerable.ToList<CmpImportUserSelectedFieldsViewModel>((IEnumerable<CmpImportUserSelectedFieldsViewModel>)GetAllFields().UserSelectedFieldsList);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public ActionResult UploadFile(HttpPostedFileBase attachFileUrlUpload, string BBrBa = "", int ColumnsType = 2, int BankId = 0, string ColumnsFormat = "", char sep = ',')
	{
		string filePath = "";
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DeleteImportedExcelData();
			if (!VersionBuyer.CmpImportExcel)
			{
				int result2 = 0;
				int.TryParse(SysSeting.Get().CmpImpUsedCount.ToString(), out result2);
				if (result2 >= 1)
				{
					text = string.Format(Messages.ImportExcelBuyModuleWithCount, "5");
					FinishXlsJob(filePath);
					return Content(text);
				}
			}
			_ = DateTime.Now;
			object[,] array = null;
			int num = 0;
			int num2 = 0;
			byte[] buffer = new byte[base.Request.ContentLength];
			base.Request.InputStream.Read(buffer, 0, Convert.ToInt32(base.Request.ContentLength));
			using (ExcelPackage excelPackage = new ExcelPackage(base.Request.InputStream))
			{
				ExcelWorksheet excelWorksheet = Enumerable.First<ExcelWorksheet>((IEnumerable<ExcelWorksheet>)excelPackage.Workbook.Worksheets);
				num = excelWorksheet.Dimension.End.Column;
				num2 = excelWorksheet.Dimension.End.Row;
				array = new object[num2, num];
				array = (object[,])excelWorksheet.Cells.Value;
			}
			List<CmpImportUserSelectedFieldsViewModel> userSelectedFieldsList = GetAllFields().UserSelectedFieldsList;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			int num3 = 0;
			string text5 = "";
			string text6 = "";
			string text7 = "";
			try
			{
				List<string> list = Enumerable.ToList<string>((IEnumerable<string>)"cmpEffectiveDateTime,prsBirthDateTime,prsMarriageDateTime,prjRemindDateTime,cnvsRemindDateTime,cnvsRemindDateTimeForAllarm".Split(new char[1] { ',' }));
				List<string> list2 = Enumerable.ToList<string>((IEnumerable<string>)"cmpEffectiveDatePersian,prsBirthDate,prsMarriageDate,prjRemindDate,cnvsRemindDate,cnvsRemindDateForAllarm".Split(new char[1] { ',' }));
				foreach (CmpImportUserSelectedFieldsViewModel item in userSelectedFieldsList)
				{
					text5 = ((!string.IsNullOrWhiteSpace(text5)) ? (text5 + ", " + item.FieldName) : (text5 + item.FieldName));
					List<string> list3 = Enumerable.ToList<string>((IEnumerable<string>)text5.Replace(" ", "").Trim().Split(new char[1] { ',' }));
					if (list2.IndexOf(item.FieldName) >= 0)
					{
						int index = list2.IndexOf(item.FieldName);
						string text8 = list[index];
						if (list3.IndexOf(text8) < 0)
						{
							text5 = ((!string.IsNullOrWhiteSpace(text5)) ? (text5 + ", " + text8) : (text5 + text8));
						}
					}
				}
				text5 = ((!string.IsNullOrWhiteSpace(text5)) ? (text5 + ", Selector") : (text5 + "Selector"));
				object[] array2 = new object[userSelectedFieldsList.Count];
				int num4 = 0;
				int num5 = 1;
				string text9 = "";
				for (int i = 1; i < num2; i++)
				{
					int num6 = 0;
					for (num6 = 0; num6 < num; num6++)
					{
						string ExcelCurrCol = "";
						string text10 = "";
						array2[num6] = array[i, num6];
						ExcelCurrCol = ((array[0, num6] == null) ? "" : array[0, num6].ToString());
						text10 = ((array2[num6] == null) ? "NULL" : array2[num6].ToString());
						CmpImportUserSelectedFieldsViewModel cmpImportUserSelectedFieldsViewModel = Enumerable.FirstOrDefault<CmpImportUserSelectedFieldsViewModel>(Enumerable.Where<CmpImportUserSelectedFieldsViewModel>((IEnumerable<CmpImportUserSelectedFieldsViewModel>)userSelectedFieldsList, (Func<CmpImportUserSelectedFieldsViewModel, bool>)((CmpImportUserSelectedFieldsViewModel x) => x.FieldCaption == ExcelCurrCol)));
						text2 = cmpImportUserSelectedFieldsViewModel.FieldCaption ?? "NULL";
						text3 = cmpImportUserSelectedFieldsViewModel.FieldName ?? "NULL";
						text4 = cmpImportUserSelectedFieldsViewModel.FieldType ?? "NULL";
						num3 = cmpImportUserSelectedFieldsViewModel.FieldWidth;
						if (text10 == "NULL" || string.IsNullOrWhiteSpace(text10))
						{
							text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", NULL") : (text7 + "NULL"));
							if (list2.IndexOf(text3) >= 0)
							{
								text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", NULL") : (text7 + "NULL"));
							}
							continue;
						}
						if (text4.ToLower().Contains("int"))
						{
							if (Enumerable.All<char>((IEnumerable<char>)((array2[num6] == null) ? "NULL" : array2[num6].ToString()), (Func<char, bool>)char.IsDigit))
							{
								string text11 = ((text10 == null) ? "" : text10.ToString());
								if (string.IsNullOrWhiteSpace(text11))
								{
									text11 = "NULL";
								}
								text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", " + text11) : (text7 + text11));
								continue;
							}
							text = string.Format(Messages.msgErrorImportExcelIntType, num5.ToString(), text2);
							FinishXlsJob(filePath);
							return Content(text);
						}
						if (text4.ToLower().Contains("bit"))
						{
							if (!bool.TryParse(text10, out var result3))
							{
								text = string.Format(Messages.msgErrorImportExcelBoolType, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							text7 = ((!string.IsNullOrWhiteSpace(text7)) ? ((!result3) ? (text7 + ", 0") : (text7 + ", 1")) : ((!result3) ? (text7 + "0") : (text7 + "1")));
							continue;
						}
						if (text4.ToLower().Contains("datetime"))
						{
							string text12 = text10;
							if (!DateTime.TryParse(text12, out var _))
							{
								text = string.Format(Messages.msgErrorImportExcelDatetimeType, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", '" + text12 + "'") : (text7 + "'" + text12 + "'"));
							continue;
						}
						string text13 = text10.Replace("'", "''").Trim();
						if (text13.Length > num3)
						{
							text = string.Format(Messages.msgErrorImportExcelDataLength, num5.ToString(), text2);
							FinishXlsJob(filePath);
							return Content(text);
						}
						if ((text3.Contains("Tel") && !text3.Contains("Desc")) || (text3.Contains("Mobile") && !text3.Contains("Desc")) || (text3.Contains("Fax") && !text3.Contains("Desc")) || (text3.Contains("National") && !text3.Contains("Desc")) || (text3.Contains("Economic") && !text3.Contains("Desc")) || (text3.Contains("cmpRegistrationNumber") && !text3.Contains("Desc")))
						{
							if (Enumerable.All<char>((IEnumerable<char>)text13, (Func<char, bool>)char.IsDigit))
							{
								text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", '" + text13 + "'") : (text7 + "'" + text13 + "'"));
								continue;
							}
							if (text3.Contains("Tel"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							if (text3.Contains("Mobile"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							if (text3.Contains("Fax"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							if (text3.Contains("National"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							if (text3.Contains("Economic"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							if (text3.Contains("cmpRegistrationNumber"))
							{
								text = string.Format(Messages.msgErrorImportExcelIsNotDigit, num5.ToString(), text2);
								FinishXlsJob(filePath);
								return Content(text);
							}
							continue;
						}
						if (list2.IndexOf(text3) >= 0)
						{
							DateTime dateTime = default(DateTime);
							string text14 = "";
							try
							{
								if (!string.IsNullOrEmpty(text13))
								{
									text14 = PersianDate.GetFormatetdDate(text13.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										dateTime = DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
										text13 = dateTime.ToString("yyyyMMdd");
										break;
									case 1025:
										dateTime = DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
										text13 = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										dateTime = DateTime.Parse(text14 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
										text13 = dateTime.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
							}
							if (text13 != null)
							{
								text13 = text13.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
							text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", '" + text13 + "'") : (text7 + "'" + text13 + "'"));
							string text15 = "";
							text15 = (string.IsNullOrEmpty(text13) ? "NULL" : ("'" + dateTime.ToString(new CultureInfo("en-US")) + "'"));
							text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", " + text15) : (text7 + text15));
							continue;
						}
						if (text3 == "cmpCoordinateLastDatePersian" || text3 == "FirstRegisterDatePersian")
						{
							DateTime dateTime2 = default(DateTime);
							string text16 = "";
							try
							{
								if (!string.IsNullOrEmpty(text13))
								{
									text16 = PersianDate.GetFormatetdDate(text13.Replace("/", ""));
									text13 = lCID switch
									{
										1065 => DateTime.Parse(text16 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
										1025 => DateTime.Parse(text16 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
										_ => DateTime.Parse(text16 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
									};
								}
							}
							catch (Exception e2)
							{
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
							if (text13 != null)
							{
								text13 = text13.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
						}
						text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", '" + text13 + "'") : (text7 + "'" + text13 + "'"));
					}
					text7 = ((!string.IsNullOrWhiteSpace(text7)) ? (text7 + ", 1") : (text7 + "1"));
					text6 = ((!string.IsNullOrWhiteSpace(text6)) ? (text6 + "\n UNION ALL \nSELECT   " + text7) : (text6 + "\n SELECT  " + text7));
					text7 = "";
					num4++;
					num5++;
					if (num4 < 1500)
					{
						continue;
					}
					try
					{
						if (!string.IsNullOrWhiteSpace(text6))
						{
							text9 = $"INSERT INTO CrmImportFromExcel ({text5}) {text6}";
							_db.Database.ExecuteSqlCommand(text9);
							num4 = 0;
							text6 = "";
						}
					}
					catch (Exception ex)
					{
						ErrorSignal.FromCurrentContext().Raise(ex);
						FinishXlsJob(filePath);
						return Content(ex.Message);
					}
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(text6))
					{
						text9 = $"INSERT INTO CrmImportFromExcel ({text5}) {text6}";
						_db.Database.ExecuteSqlCommand(text9);
						num4 = 0;
						text6 = "";
					}
				}
				catch (Exception ex2)
				{
					ErrorSignal.FromCurrentContext().Raise(ex2);
					FinishXlsJob(filePath);
					return Content(ex2.Message);
				}
			}
			catch (Exception ex3)
			{
				ErrorSignal.FromCurrentContext().Raise(ex3);
				FinishXlsJob(filePath);
				return Content(ex3.Message);
			}
			FinishXlsJob(filePath);
			return Content("");
		}
		catch (Exception ex4)
		{
			ErrorSignal.FromCurrentContext().Raise(ex4);
			FinishXlsJob(filePath);
			return Content(ex4.Message);
		}
	}

	public bool CleanImportedExcelData(string cleanFieldsOption = "")
	{
		try
		{
			if (!string.IsNullOrWhiteSpace(cleanFieldsOption))
			{
				mct_Result mct_Result = Enumerable.FirstOrDefault<mct_Result>((IEnumerable<mct_Result>)_db.CRMspClearImportFromExcel(cleanFieldsOption));
				if (mct_Result != null)
				{
					if (mct_Result.Result == 1)
					{
						return true;
					}
					return false;
				}
				return false;
			}
			return true;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return false;
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCmpImportExcel")]
	public ActionResult _PartialRequiredFields()
	{
		SelectCmpTitle();
		SelectCmpPresentation();
		SelectCmpType();
		SelectCountry();
		SelectProvince();
		SelectCity();
		SelectFirstGroup();
		SelectSubGroup();
		SelectGroupII();
		SelectGroupIII();
		SelectGroupIV();
		SelectReferUser();
		SelectPrsJobs();
		SelectPrsDepartmants();
		SelectCnvsStatusGroup();
		SelectPrjGroups();
		SelectPrjGrade();
		SelectPrjPriority();
		SelectPrjStartUser();
		SelectCnvsTopic();
		SelectCnvsUsers();
		SelectCnvsReferUsers();
		SelectCnvsStatus();
		SelectCnvsPriority();
		return PartialView("_PartialRequiredFields");
	}

	public JsonResult SelectCmpTitle()
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
			List<CRMspSelectCompanyTitle_Result> list2 = Enumerable.ToList<CRMspSelectCompanyTitle_Result>((IEnumerable<CRMspSelectCompanyTitle_Result>)_db.CRMspSelectCompanyTitle(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyTitle_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTitle_Result>)list2, (Func<CRMspSelectCompanyTitle_Result, SelectListItem>)((CRMspSelectCompanyTitle_Result item) => new SelectListItem
			{
				Text = item.CompanyTitle,
				Value = item.CompanyTitleID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCmpTitles = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCmpPresentation()
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
			List<CRMspSelectCompanyPresentation_Result> list2 = Enumerable.ToList<CRMspSelectCompanyPresentation_Result>((IEnumerable<CRMspSelectCompanyPresentation_Result>)_db.CRMspSelectCompanyPresentation(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentation_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentation_Result>)list2, (Func<CRMspSelectCompanyPresentation_Result, SelectListItem>)((CRMspSelectCompanyPresentation_Result item) => new SelectListItem
			{
				Text = item.Presentation,
				Value = item.CompanyPresentationID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCmpPresentation = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCmpType()
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
			List<CRMspSelectCompanyType_Result> list2 = Enumerable.ToList<CRMspSelectCompanyType_Result>((IEnumerable<CRMspSelectCompanyType_Result>)_db.CRMspSelectCompanyType(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyType_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyType_Result>)list2, (Func<CRMspSelectCompanyType_Result, SelectListItem>)((CRMspSelectCompanyType_Result item) => new SelectListItem
			{
				Text = item.CompanyTypeName,
				Value = item.CompanyTypeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCmpType = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCountry()
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
			List<CRMspSelectCountry_Result> list2 = Enumerable.ToList<CRMspSelectCountry_Result>((IEnumerable<CRMspSelectCountry_Result>)_db.CRMspSelectCountry(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCountry_Result, SelectListItem>((IEnumerable<CRMspSelectCountry_Result>)list2, (Func<CRMspSelectCountry_Result, SelectListItem>)((CRMspSelectCountry_Result item) => new SelectListItem
			{
				Text = item.Country,
				Value = item.CountryID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCountry = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectProvince(int countryId = 0)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyProvince_Result> list2 = Enumerable.ToList<CRMspSelectCompanyProvince_Result>((IEnumerable<CRMspSelectCompanyProvince_Result>)_db.CRMspSelectCompanyProvince(UserLogin.CurrentUser.UserId, countryId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyProvince_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyProvince_Result>)list2, (Func<CRMspSelectCompanyProvince_Result, SelectListItem>)((CRMspSelectCompanyProvince_Result item) => new SelectListItem
			{
				Text = item.Province,
				Value = item.ProvinceID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstProvince = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCity(int provinceId = 0)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyCity_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCity_Result>((IEnumerable<CRMspSelectCompanyCity_Result>)_db.CRMspSelectCompanyCity(UserLogin.CurrentUser.UserId, provinceId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyCity_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyCity_Result>)list2, (Func<CRMspSelectCompanyCity_Result, SelectListItem>)((CRMspSelectCompanyCity_Result item) => new SelectListItem
			{
				Text = item.City,
				Value = item.CityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCity = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectFirstGroup()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroup_Result>((IEnumerable<CRMspSelectCompanyGroup_Result>)_db.CRMspSelectCompanyGroup(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroup_Result>)list2, (Func<CRMspSelectCompanyGroup_Result, SelectListItem>)((CRMspSelectCompanyGroup_Result item) => new SelectListItem
			{
				Text = item.GroupName,
				Value = item.CompanyGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstFirstGroup = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectSubGroup(int firstGroupId = 0)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanySubGroup_Result> list2 = Enumerable.ToList<CRMspSelectCompanySubGroup_Result>((IEnumerable<CRMspSelectCompanySubGroup_Result>)_db.CRMspSelectCompanySubGroup(UserLogin.CurrentUser.UserId, firstGroupId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroup_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroup_Result>)list2, (Func<CRMspSelectCompanySubGroup_Result, SelectListItem>)((CRMspSelectCompanySubGroup_Result item) => new SelectListItem
			{
				Text = item.SubGroupName,
				Value = item.CompanySubGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstSubGroup = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectGroupII()
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
			List<CRMspSelectCompanyGroupsII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsII_Result>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)_db.CRMspSelectCompanyGroupsII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsII_Result>)list2, (Func<CRMspSelectCompanyGroupsII_Result, SelectListItem>)((CRMspSelectCompanyGroupsII_Result item) => new SelectListItem
			{
				Text = item.GroupIIName,
				Value = item.CompanyGroupIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstGroupsII = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectGroupIII()
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
			List<CRMspSelectCompanyGroupsIII_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIII_Result>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)_db.CRMspSelectCompanyGroupsIII(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIII_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIII_Result>)list2, (Func<CRMspSelectCompanyGroupsIII_Result, SelectListItem>)((CRMspSelectCompanyGroupsIII_Result item) => new SelectListItem
			{
				Text = item.GroupIIIName,
				Value = item.CompanyGroupIIIID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstGroupsIII = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectGroupIV()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyGroupsIV_Result> list2 = Enumerable.ToList<CRMspSelectCompanyGroupsIV_Result>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)_db.CRMspSelectCompanyGroupsIV(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIV_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIV_Result>)list2, (Func<CRMspSelectCompanyGroupsIV_Result, SelectListItem>)((CRMspSelectCompanyGroupsIV_Result item) => new SelectListItem
			{
				Text = item.GroupIVName,
				Value = item.CompanyGroupIVID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstGroupsIV = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectReferUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectCompanyReferUsers_Result> list2 = Enumerable.ToList<CRMspSelectCompanyReferUsers_Result>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)_db.CRMspSelectCompanyReferUsers(UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectCompanyReferUsers_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyReferUsers_Result>)list2, (Func<CRMspSelectCompanyReferUsers_Result, SelectListItem>)((CRMspSelectCompanyReferUsers_Result item) => new SelectListItem
			{
				Text = item.USER,
				Value = item.UserId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstReferUser = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrsJobs()
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
			List<CRMspSelectPersonJobs_Result> list2 = Enumerable.ToList<CRMspSelectPersonJobs_Result>((IEnumerable<CRMspSelectPersonJobs_Result>)_db.CRMspSelectPersonJobs(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonJobs_Result, SelectListItem>((IEnumerable<CRMspSelectPersonJobs_Result>)list2, (Func<CRMspSelectPersonJobs_Result, SelectListItem>)((CRMspSelectPersonJobs_Result item) => new SelectListItem
			{
				Text = item.Jobs,
				Value = item.PersonJobID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstPrsJobs = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrsDepartmants()
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
			List<CRMspSelectPersonDepartments_Result> list2 = Enumerable.ToList<CRMspSelectPersonDepartments_Result>((IEnumerable<CRMspSelectPersonDepartments_Result>)_db.CRMspSelectPersonDepartments(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectPersonDepartments_Result, SelectListItem>((IEnumerable<CRMspSelectPersonDepartments_Result>)list2, (Func<CRMspSelectPersonDepartments_Result, SelectListItem>)((CRMspSelectPersonDepartments_Result item) => new SelectListItem
			{
				Text = item.PersonDepartment,
				Value = item.PersonDepartmentId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstPrsDepartments = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsStatusGroup()
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
			List<CRMspSelectActiveConversationStatusGroups_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatusGroups_Result>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)_dbI.CRMspSelectActiveConversationStatusGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatusGroups_Result>)list2, (Func<CRMspSelectActiveConversationStatusGroups_Result, SelectListItem>)((CRMspSelectActiveConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCnvsStatusGroups = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrjGroups()
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
			List<CRMspSelectProjectGroups_Result> list2 = Enumerable.ToList<CRMspSelectProjectGroups_Result>((IEnumerable<CRMspSelectProjectGroups_Result>)_db.CRMspSelectProjectGroups(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGroups_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGroups_Result>)list2, (Func<CRMspSelectProjectGroups_Result, SelectListItem>)((CRMspSelectProjectGroups_Result item) => new SelectListItem
			{
				Text = item.ProjectGroup,
				Value = item.ProjectGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstPrjGroups = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrjGrade()
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
			List<CRMspSelectProjectGrade_Result> list2 = Enumerable.ToList<CRMspSelectProjectGrade_Result>((IEnumerable<CRMspSelectProjectGrade_Result>)_db.CRMspSelectProjectGrade(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectGrade_Result, SelectListItem>((IEnumerable<CRMspSelectProjectGrade_Result>)list2, (Func<CRMspSelectProjectGrade_Result, SelectListItem>)((CRMspSelectProjectGrade_Result item) => new SelectListItem
			{
				Text = item.ProjectGrade,
				Value = item.ProjectGradeID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstPrjGrades = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrjPriority()
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
			List<CRMspSelectProjectPriority_Result> list2 = Enumerable.ToList<CRMspSelectProjectPriority_Result>((IEnumerable<CRMspSelectProjectPriority_Result>)_db.CRMspSelectProjectPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectProjectPriority_Result, SelectListItem>((IEnumerable<CRMspSelectProjectPriority_Result>)list2, (Func<CRMspSelectProjectPriority_Result, SelectListItem>)((CRMspSelectProjectPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ProjectPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstPrjPriority = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectPrjStartUser()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 11, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
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
		base.ViewBag.lstPrjStartUsers = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsTopic()
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
			List<CRMspSelectConversationTopics_Result> list2 = Enumerable.ToList<CRMspSelectConversationTopics_Result>((IEnumerable<CRMspSelectConversationTopics_Result>)_db.CRMspSelectConversationTopics(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationTopics_Result, SelectListItem>((IEnumerable<CRMspSelectConversationTopics_Result>)list2, (Func<CRMspSelectConversationTopics_Result, SelectListItem>)((CRMspSelectConversationTopics_Result item) => new SelectListItem
			{
				Text = item.Topic,
				Value = item.ConversationTopicsID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCnvsTopics = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 8, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
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
		base.ViewBag.lstCnvsUsers = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsReferUsers()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<CRMspSelectUserForLinkedType_Result> list2 = Enumerable.ToList<CRMspSelectUserForLinkedType_Result>((IEnumerable<CRMspSelectUserForLinkedType_Result>)_db.CRMspSelectUserForLinkedType(UserLogin.CurrentUser.UserId, 7, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForLinkedType_Result, SelectListItem>((IEnumerable<CRMspSelectUserForLinkedType_Result>)list2, (Func<CRMspSelectUserForLinkedType_Result, SelectListItem>)((CRMspSelectUserForLinkedType_Result item) => new SelectListItem
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
		base.ViewBag.lstCnvsReferUsers = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsStatus(int groupId = 0)
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
			List<CRMspSelectActiveConversationStatus_Result> list2 = Enumerable.ToList<CRMspSelectActiveConversationStatus_Result>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)_dbI.CRMspSelectActiveConversationStatus(groupId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectActiveConversationStatus_Result, SelectListItem>((IEnumerable<CRMspSelectActiveConversationStatus_Result>)list2, (Func<CRMspSelectActiveConversationStatus_Result, SelectListItem>)((CRMspSelectActiveConversationStatus_Result item) => new SelectListItem
			{
				Text = item.Status,
				Value = item.ConversationStatusID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCnvsStatus = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult SelectCnvsPriority()
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
			List<CRMspSelectConversationPriority_Result> list2 = Enumerable.ToList<CRMspSelectConversationPriority_Result>((IEnumerable<CRMspSelectConversationPriority_Result>)_db.CRMspSelectConversationPriority(lCID, result));
			list.AddRange(Enumerable.Select<CRMspSelectConversationPriority_Result, SelectListItem>((IEnumerable<CRMspSelectConversationPriority_Result>)list2, (Func<CRMspSelectConversationPriority_Result, SelectListItem>)((CRMspSelectConversationPriority_Result item) => new SelectListItem
			{
				Text = item.Priority,
				Value = item.ConversationPriorityID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.lstCnvsPriority = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actCmpImportExcel")]
	public ActionResult _PartialFinalImport()
	{
		return PartialView(GetAllFields());
	}

	public ActionResult FinalImport_Read([DataSourceRequest] DataSourceRequest request)
	{
		List<CRMspSelectImportFromExcel_Result> enumerable = new List<CRMspSelectImportFromExcel_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspSelectImportFromExcel_Result>((IEnumerable<CRMspSelectImportFromExcel_Result>)_db.CRMspSelectImportFromExcel());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request));
	}

	public string ImportFromExcelMultiRec(int cmpSelect = 0, int prsSelect = 0, int prjSelect = 0, int cnvsSelect = 0, int? cmpTitle = null, int? cmpPresentation = null, int? cmpType = null, int? cmpCountry = null, int? cmpProvince = null, int? cmpCity = null, int? cmpFirstGroup = null, int? cmpSubGroup = null, int? cmpGroupII = null, int? cmpGroupIII = null, int? cmpGroupIV = null, string cmpDate = null, int? cmpReferUser = null, int? cmpPrsJobs = null, int? cmpPrsDepartments = null, int? cnvsStatusGroup = null, int? prjGroup = null, int? prjGrade = null, int? prjPriority = null, int? prjStarterUser = null, string prjStartDate = null, int? prjStartDay = null, string prjStartTime = null, string cnvsDate = null, string cnvsDay = null, string cnvsTime = null, int? cnvsTopic = null, int? cnvsUser = null, int? cnvsReferUser = null, int? cnvsStatus = null, string cnvsRemindDate = null, string cnvsRemindTime = null, string cnvsRemindDateForAllarm = null, int? cnvsPriority = null, bool chkDupCmpName = false, bool chkDupCmpTel = false, bool chkDupCmpNationalCode = false, bool chkDupCmpEconomicCode = false, bool chkDupCmpCode = false, bool chkDupCmpNumber = false, bool chkDupCmpMobile = false, bool chkDupCmpEmail = false, bool chkDupPrsLName = false, bool chkDupPrsTel = false, bool chkDupPrsMobile = false, bool chkDupPrsNationalCode = false, string cmpReferMultiUsers = "", bool isUsedCmpReferUserInCnvsUserAndReferUser = false)
	{
		string text = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int? centerId = null;
		if (UserLogin.CurrentUser != null)
		{
			centerId = UserLogin.CurrentUser.UserLastCId;
		}
		bool value = cmpSelect > 0;
		bool value2 = prsSelect > 0;
		bool value3 = prjSelect > 0;
		bool value4 = cnvsSelect > 0;
		if (cmpSelect > 0)
		{
			if (cmpCountry <= 0 || !cmpCountry.HasValue)
			{
				text = Messages.CmpImpPlsSelectACountry;
			}
			else if (cmpProvince <= 0 || !cmpProvince.HasValue)
			{
				text = Messages.CmpImpPlsSelectAProvince;
			}
			else if (cmpCity <= 0 || !cmpCity.HasValue)
			{
				text = Messages.CmpImpPlsSelectACity;
			}
			else if (string.IsNullOrWhiteSpace(cmpDate))
			{
				text = Messages.CmpImpSelectARegisterDate;
			}
			else if (cmpReferUser <= 0 || !cmpReferUser.HasValue)
			{
				text = Messages.CmpImpSelectAReferUser;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			if (!string.IsNullOrWhiteSpace(cmpDate))
			{
				DateTime dateTime = default(DateTime);
				string text2 = "";
				try
				{
					if (!string.IsNullOrEmpty(cmpDate))
					{
						text2 = PersianDate.GetFormatetdDate(cmpDate.Replace("/", ""));
						cmpDate = lCID switch
						{
							1065 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
							1025 => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
							_ => DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
						};
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
					return Messages.WrongDateTime;
				}
				if (cmpDate != null)
				{
					cmpDate = cmpDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
		}
		if (prsSelect > 0 && !string.IsNullOrWhiteSpace(text))
		{
			return text;
		}
		if (prjSelect > 0)
		{
			if ((cnvsStatusGroup <= 0 && cnvsStatusGroup.GetValueOrDefault() != -10) || !cnvsStatusGroup.HasValue)
			{
				text = Messages.CmpImpSelectAProjectStatus;
			}
			else if (prjGroup <= 0 || !prjGroup.HasValue)
			{
				text = Messages.CmpImpSelectAGroupProject;
			}
			else if (prjStarterUser <= 0 || !prjStarterUser.HasValue)
			{
				text = Messages.CmpImpSelectAProjectStarterUser;
			}
			else if (string.IsNullOrWhiteSpace(prjStartDate))
			{
				text = Messages.CmpImpSelectARegisterDate;
			}
			else if (prjStartDay <= 0 || !prjStartDay.HasValue)
			{
				text = Messages.CmpImpSelectAProjectStartDay;
			}
			else if (string.IsNullOrWhiteSpace(prjStartTime))
			{
				text = Messages.CmpImpSelectAProjectStartTime;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			if (!string.IsNullOrWhiteSpace(prjStartDate))
			{
				DateTime dateTime2 = default(DateTime);
				string text3 = "";
				try
				{
					if (!string.IsNullOrEmpty(prjStartDate))
					{
						text3 = PersianDate.GetFormatetdDate(prjStartDate.Replace("/", ""));
						prjStartDate = lCID switch
						{
							1065 => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
							1025 => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
							_ => DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
						};
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					return Messages.WrongDateTime;
				}
				if (prjStartDate != null)
				{
					prjStartDate = prjStartDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
		}
		if (cnvsSelect > 0)
		{
			if (string.IsNullOrWhiteSpace(cnvsDate))
			{
				text = Messages.CmpImpSelectAConversationDate;
			}
			else if (string.IsNullOrWhiteSpace(cnvsDay))
			{
				text = Messages.CmpImpSelectAConversationDay;
			}
			else if (string.IsNullOrWhiteSpace(cnvsTime))
			{
				text = Messages.CmpImpSelectAConversationTime;
			}
			else if ((cnvsTopic <= 0 && cnvsTopic.GetValueOrDefault() != -10) || !cnvsTopic.HasValue)
			{
				text = Messages.CmpImpSelectAConversationTopic;
			}
			else if (cnvsUser <= 0 || !cnvsUser.HasValue)
			{
				text = Messages.CmpImpSelectAConversationUser;
			}
			else if (cnvsReferUser <= 0 || !cnvsReferUser.HasValue)
			{
				text = Messages.CmpImpSelectAConversationReferUser;
			}
			else if ((cnvsStatus <= 0 && cnvsStatus.GetValueOrDefault() != -10) || !cnvsStatus.HasValue)
			{
				text = Messages.CmpImpSelectAConversationStatus;
			}
			if (!string.IsNullOrWhiteSpace(text))
			{
				return text;
			}
			if (!string.IsNullOrWhiteSpace(cnvsDate))
			{
				DateTime dateTime3 = default(DateTime);
				string text4 = "";
				try
				{
					if (!string.IsNullOrEmpty(cnvsDate))
					{
						text4 = PersianDate.GetFormatetdDate(cnvsDate.Replace("/", ""));
						cnvsDate = lCID switch
						{
							1065 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
							1025 => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
							_ => DateTime.Parse(text4 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
						};
					}
				}
				catch (Exception e3)
				{
					ErrorSignal.FromCurrentContext().Raise(e3);
					return Messages.WrongDateTime;
				}
				if (cnvsDate != null)
				{
					cnvsDate = cnvsDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			if (!string.IsNullOrWhiteSpace(cnvsRemindDate))
			{
				DateTime dateTime4 = default(DateTime);
				string text5 = "";
				try
				{
					if (!string.IsNullOrEmpty(cnvsRemindDate))
					{
						text5 = PersianDate.GetFormatetdDate(cnvsRemindDate.Replace("/", ""));
						cnvsRemindDate = lCID switch
						{
							1065 => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
							1025 => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
							_ => DateTime.Parse(text5 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
						};
					}
				}
				catch (Exception e4)
				{
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Messages.WrongDateTime;
				}
				if (cnvsRemindDate != null)
				{
					cnvsRemindDate = cnvsRemindDate.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
			if (!string.IsNullOrWhiteSpace(cnvsRemindDateForAllarm))
			{
				DateTime dateTime5 = default(DateTime);
				string text6 = "";
				try
				{
					if (!string.IsNullOrEmpty(cnvsRemindDateForAllarm))
					{
						text6 = PersianDate.GetFormatetdDate(cnvsRemindDateForAllarm.Replace("/", ""));
						cnvsRemindDateForAllarm = lCID switch
						{
							1065 => DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyyMMdd"), 
							1025 => DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA")).ToString("yyyyMMdd", new PersianCulture()), 
							_ => DateTime.Parse(text6 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US")).ToString("yyyyMMdd", new PersianCulture()), 
						};
					}
				}
				catch (Exception e5)
				{
					ErrorSignal.FromCurrentContext().Raise(e5);
					return Messages.WrongDateTime;
				}
				if (cnvsRemindDateForAllarm != null)
				{
					cnvsRemindDateForAllarm = cnvsRemindDateForAllarm.Replace("/", "").Replace("-", "").Replace("_", "")
						.Replace(".", "")
						.Replace(",", "")
						.Replace("\\", "");
				}
			}
		}
		if (string.IsNullOrWhiteSpace(text))
		{
			string text7 = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			int userId = UserLogin.CurrentUser.UserId;
			short value5 = short.Parse(Financial.Get().Id.ToString());
			short value6 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			try
			{
				CRMSpEntities db = _db;
				bool? cmpSelect2 = value;
				bool? prsSelect2 = value2;
				bool? prjSelect2 = value3;
				bool? cnvsSelect2 = value4;
				string importDate = cmpDate;
				int? cmpCountryId = cmpCountry;
				int? cmpProvinceId = cmpProvince;
				int? cmpCityId = cmpCity;
				int? cmpReferUserId = cmpReferUser;
				int? prsJobId = cmpPrsJobs;
				int? prjGroupId = prjGroup;
				int? prjcnvsStatusGroupId = cnvsStatusGroup;
				string prjStartDate2 = prjStartDate;
				int? prjStartDay2 = prjStartDay;
				int? prjStarterUserId = prjStarterUser;
				string cnvsDate2 = cnvsDate;
				int? cnvsTopicId = cnvsTopic;
				int? cnvsUserId = cnvsUser;
				int? cnvsReferUserId = cnvsReferUser;
				int? cnvsStatusId = cnvsStatus;
				int? cnvsPriorityId = cnvsPriority;
				string cnvsRemindDate2 = cnvsRemindDate;
				string cnvsRemindDateForAllarm2 = cnvsRemindDateForAllarm;
				bool? checkDupCmpName = chkDupCmpName;
				bool? checkDupCmpTel = chkDupCmpTel;
				bool? checkDupCmpNationalCode = chkDupCmpNationalCode;
				bool? checkDupCmpEconomicCode = chkDupCmpEconomicCode;
				bool? checkDupCmpCode = chkDupCmpCode;
				bool? checkDupCmpNumber = chkDupCmpNumber;
				bool? checkDupCmpMobile = chkDupCmpMobile;
				bool? checkDupCmpEmail = chkDupCmpEmail;
				bool? checkDupPrsLName = chkDupPrsLName;
				bool? checkDupPrsMobile = chkDupPrsMobile;
				bool? checkDupPrsTel = chkDupPrsTel;
				bool? checkDupPrsNationalCode = chkDupPrsNationalCode;
				string registerDatePersian = text7;
				db.CrmspImportFromExcelMultiRec(cmpSelect2, prsSelect2, prjSelect2, cnvsSelect2, importDate, cmpTitle, cmpFirstGroup, cmpSubGroup, cmpGroupII, cmpGroupIII, cmpGroupIV, cmpType, cmpPresentation, cmpCountryId, cmpProvinceId, cmpCityId, cmpReferUserId, userId, userId, value5, value6, registerDatePersian, prsJobId, cmpPrsDepartments, null, prjGrade, prjPriority, prjGroupId, prjcnvsStatusGroupId, prjStartDate2, prjStartDay2, prjStartTime, prjStarterUserId, cnvsDate2, cnvsDay, cnvsTime, cnvsTopicId, cnvsUserId, cnvsReferUserId, cnvsStatusId, cnvsPriorityId, cnvsRemindDate2, cnvsRemindTime, cnvsRemindDateForAllarm2, appType, result, checkDupCmpName, checkDupCmpTel, checkDupCmpNationalCode, checkDupCmpEconomicCode, checkDupCmpCode, checkDupCmpNumber, checkDupCmpMobile, checkDupCmpEmail, checkDupPrsLName, checkDupPrsMobile, checkDupPrsTel, checkDupPrsNationalCode, cmpReferMultiUsers, isUsedCmpReferUserInCnvsUserAndReferUser, centerId);
				if (!VersionBuyer.CmpImportExcel)
				{
					int result2 = 0;
					int.TryParse(SysSeting.Get().CmpImpUsedCount.ToString(), out result2);
					CrmsysSetting crmsysSetting = Queryable.FirstOrDefault<CrmsysSetting>((IQueryable<CrmsysSetting>)_dbTbl.CrmsysSetting);
					if (crmsysSetting != null)
					{
						crmsysSetting.CmpImpUsedCount = result2 + 1;
						_dbTbl.Entry(crmsysSetting).State = EntityState.Modified;
						_dbTbl.SaveChanges();
						SysSeting.Update();
					}
				}
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				text = ex.Message;
			}
		}
		return text;
	}

	public string DeleteImportExcelFromCrm()
	{
		string text = "";
		try
		{
			_db.CRMspDeleteImportExcelFromCrm();
			return "";
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			return ex.Message;
		}
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
