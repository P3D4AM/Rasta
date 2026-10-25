using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Elmah;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Shop.Controllers;

public class PageViewerController : Controller
{
	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	public CRMShpPageViewerChartViewModel ChrtLst = new CRMShpPageViewerChartViewModel();

	public PageViewerChartsWidthViewModel ChrtWidth = new PageViewerChartsWidthViewModel();

	public int ChartDefaultWidth = 330;

	public int CategoriesPerPage = 10;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptShpPageViewer")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public ActionResult _PartialChartPageViewer(string fDate, string tDate)
	{
		SelectShpPageViewerChartDaily(fDate, tDate);
		SelectShpPageViewersWithOs(fDate, tDate);
		SelectShpPageViewersWithDeviceType(fDate, tDate);
		SelectShpPageViewersWithBrowser(fDate, tDate);
		SelectShpDailyPageViewersWithHour(fDate, tDate);
		SelectShpPageViewersWithReferer(fDate, tDate);
		ChrtLst.ChrtWidth = ChrtWidth;
		return PartialView(ChrtLst);
	}

	public List<CRMShpChartDailyPageViewersViewModel> SelectShpPageViewerChartDaily(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpPageViewerChartDaily = new List<CRMShpChartDailyPageViewersViewModel>();
		ChrtWidth.ChrtShpPageViewerChartDailyWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartDailyPageViewers_Result> list = Enumerable.ToList<CRMspShpChartDailyPageViewers_Result>((IEnumerable<CRMspShpChartDailyPageViewers_Result>)_dbI.CRMspShpChartDailyPageViewers(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpPageViewerChartDailyWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartDailyPageViewers_Result item in list)
					{
						CRMShpChartDailyPageViewersViewModel cRMShpChartDailyPageViewersViewModel = new CRMShpChartDailyPageViewersViewModel();
						cRMShpChartDailyPageViewersViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartDailyPageViewersViewModel.Day = (item.Miladidate.HasValue ? item.Miladidate.Value.ToString("yyyy/MM/dd") : "");
						ChrtLst.ChrtShpPageViewerChartDaily.Add(cRMShpChartDailyPageViewersViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpPageViewerChartDaily;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpPageViewerChartDaily(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpPageViewerChartDaily(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMShpChartPageViewersWithOsViewModel> SelectShpPageViewersWithOs(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpPageViewersWithOs = new List<CRMShpChartPageViewersWithOsViewModel>();
		ChrtWidth.ChrtShpPageViewersWithOsWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartPageViewersWithOs_Result> list = Enumerable.ToList<CRMspShpChartPageViewersWithOs_Result>((IEnumerable<CRMspShpChartPageViewersWithOs_Result>)_dbI.CRMspShpChartPageViewersWithOs(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpPageViewersWithOsWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartPageViewersWithOs_Result item in list)
					{
						CRMShpChartPageViewersWithOsViewModel cRMShpChartPageViewersWithOsViewModel = new CRMShpChartPageViewersWithOsViewModel();
						cRMShpChartPageViewersWithOsViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartPageViewersWithOsViewModel.Os = item.PageViewerOs ?? "";
						ChrtLst.ChrtShpPageViewersWithOs.Add(cRMShpChartPageViewersWithOsViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpPageViewersWithOs;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpPageViewersWithOs(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpPageViewersWithOs(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMShpChartPageViewersWithDeviceTypeViewModel> SelectShpPageViewersWithDeviceType(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpPageViewersWithDeviceType = new List<CRMShpChartPageViewersWithDeviceTypeViewModel>();
		ChrtWidth.ChrtShpPageViewersWithDeviceTypeWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartPageViewersWithDeviceType_Result> list = Enumerable.ToList<CRMspShpChartPageViewersWithDeviceType_Result>((IEnumerable<CRMspShpChartPageViewersWithDeviceType_Result>)_dbI.CRMspShpChartPageViewersWithDeviceType(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpPageViewersWithDeviceTypeWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartPageViewersWithDeviceType_Result item in list)
					{
						CRMShpChartPageViewersWithDeviceTypeViewModel cRMShpChartPageViewersWithDeviceTypeViewModel = new CRMShpChartPageViewersWithDeviceTypeViewModel();
						cRMShpChartPageViewersWithDeviceTypeViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartPageViewersWithDeviceTypeViewModel.DeviceType = item.PageViewerDeviceType ?? "";
						ChrtLst.ChrtShpPageViewersWithDeviceType.Add(cRMShpChartPageViewersWithDeviceTypeViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpPageViewersWithDeviceType;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpPageViewersWithDeviceType(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpPageViewersWithDeviceType(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMShpChartPageViewersWithBrowserViewModel> SelectShpPageViewersWithBrowser(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpPageViewersWithBrowser = new List<CRMShpChartPageViewersWithBrowserViewModel>();
		ChrtWidth.ChrtShpPageViewersWithBrowserWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartPageViewersWithBrowser_Result> list = Enumerable.ToList<CRMspShpChartPageViewersWithBrowser_Result>((IEnumerable<CRMspShpChartPageViewersWithBrowser_Result>)_dbI.CRMspShpChartPageViewersWithBrowser(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpPageViewersWithBrowserWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartPageViewersWithBrowser_Result item in list)
					{
						CRMShpChartPageViewersWithBrowserViewModel cRMShpChartPageViewersWithBrowserViewModel = new CRMShpChartPageViewersWithBrowserViewModel();
						cRMShpChartPageViewersWithBrowserViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartPageViewersWithBrowserViewModel.Browser = item.PageViewerBrowser ?? "";
						ChrtLst.ChrtShpPageViewersWithBrowser.Add(cRMShpChartPageViewersWithBrowserViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpPageViewersWithBrowser;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpPageViewersWithBrowser(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpPageViewersWithBrowser(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMShpChartDailyPageViewersWithHourViewModel> SelectShpDailyPageViewersWithHour(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpDailyPageViewersWithHour = new List<CRMShpChartDailyPageViewersWithHourViewModel>();
		ChrtWidth.ChrtShpDailyPageViewersWithHourWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartDailyPageViewersWithHour_Result> list = Enumerable.ToList<CRMspShpChartDailyPageViewersWithHour_Result>((IEnumerable<CRMspShpChartDailyPageViewersWithHour_Result>)_dbI.CRMspShpChartDailyPageViewersWithHour(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpDailyPageViewersWithHourWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartDailyPageViewersWithHour_Result item in list)
					{
						CRMShpChartDailyPageViewersWithHourViewModel cRMShpChartDailyPageViewersWithHourViewModel = new CRMShpChartDailyPageViewersWithHourViewModel();
						cRMShpChartDailyPageViewersWithHourViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartDailyPageViewersWithHourViewModel.Hour = item.Hours ?? "";
						ChrtLst.ChrtShpDailyPageViewersWithHour.Add(cRMShpChartDailyPageViewersWithHourViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpDailyPageViewersWithHour;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpDailyPageViewersWithHour(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpDailyPageViewersWithHour(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMShpChartPageViewersWithRefererViewModel> SelectShpPageViewersWithReferer(string fDate, string tDate, bool canLoad = true)
	{
		ChrtLst.ChrtShpPageViewersWithReferer = new List<CRMShpChartPageViewersWithRefererViewModel>();
		ChrtWidth.ChrtShpPageViewersWithRefererWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				int lCID = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime value = DateTime.Now;
				DateTime value2 = DateTime.Now;
				if (!string.IsNullOrEmpty(fDate))
				{
					value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				if (!string.IsNullOrEmpty(tDate))
				{
					value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
					{
						1025 => new CultureInfo("ar-SA"), 
						1065 => new PersianCulture(), 
						_ => new CultureInfo("en-US"), 
					});
				}
				_ = DateTime.Now;
				List<CRMspShpChartPageViewersWithReferer_Result> list = Enumerable.ToList<CRMspShpChartPageViewersWithReferer_Result>((IEnumerable<CRMspShpChartPageViewersWithReferer_Result>)_dbI.CRMspShpChartPageViewersWithReferer(value, value2));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtShpPageViewersWithRefererWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspShpChartPageViewersWithReferer_Result item in list)
					{
						CRMShpChartPageViewersWithRefererViewModel cRMShpChartPageViewersWithRefererViewModel = new CRMShpChartPageViewersWithRefererViewModel();
						cRMShpChartPageViewersWithRefererViewModel.Count = item.Cnt.GetValueOrDefault();
						cRMShpChartPageViewersWithRefererViewModel.Referer = item.PageViewerReferer ?? "";
						ChrtLst.ChrtShpPageViewersWithReferer.Add(cRMShpChartPageViewersWithRefererViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtShpPageViewersWithReferer;
	}

	[AjaxOnly]
	public JsonResult jsSelectShpPageViewersWithReferer(string fDate, string tDate)
	{
		JsonResult jsonResult = Json(SelectShpPageViewersWithReferer(fDate, tDate), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmShpPageViewersReport", ActionName = "actGetDetailExcelFile")]
	public string GetExcelFile(string fDate, string tDate)
	{
		//IL_05b8: Unknown result type (might be due to invalid IL or missing references)
		//IL_05d3: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
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
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<CRMspShpSelectPageViewers_Result> list = Enumerable.ToList<CRMspShpSelectPageViewers_Result>((IEnumerable<CRMspShpSelectPageViewers_Result>)_dbI.CRMspShpSelectPageViewers(value, value2, lCID, result2));
			if (list != null && Enumerable.Any<CRMspShpSelectPageViewers_Result>((IEnumerable<CRMspShpSelectPageViewers_Result>)list))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.ShpPageViewersExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerRegisterDate;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerIpAddress;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerDeviceType;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerOs;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerBrowser;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerReferer;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerPageViewed;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerCountryName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.ShpPageViewerCompany;
				foreach (CRMspShpSelectPageViewers_Result item in list)
				{
					num2++;
					num = 0;
					num++;
					ExcelRange excelRange = excelWorksheet.Cells[num2, num];
					_ = item.RegisterDate;
					excelRange.Value = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerIpAddress ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerDeviceType ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerOs ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerBrowser ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerReferer ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerPageViewed ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerCountryName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = item.PageViewerCompany ?? "";
				}
				string text = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ShopPageViewerReport\\" + userId;
				string text2 = "CRM-Ideal-" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
				string text3 = text + "\\" + text2;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text);
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
					if (System.IO.Directory.Exists(text))
					{
						System.IO.Directory.Delete(text);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text);
				}
				using (ExcelRange excelRange2 = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange2.Style.Font.Bold = true;
					excelRange2.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange2.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange2.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.ShpPageViewersExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.ShpPageViewersExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(text3);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(text3))
				{
					result = text3;
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return result;
	}

	protected override void Dispose(bool disposing)
	{
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
