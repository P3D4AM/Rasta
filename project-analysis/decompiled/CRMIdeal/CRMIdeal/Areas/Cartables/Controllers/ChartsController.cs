using System;
using System.Collections.Generic;
using System.Globalization;
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
using CRMIdeal.GSD.Globalization;
using Elmah;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class ChartsController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private CRMSpIIEntities _dbII = new CRMSpIIEntities();

	private CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public CrmReportChartViewModel ChrtLst = new CrmReportChartViewModel();

	public ChartsWidthViewModel ChrtWidth = new ChartsWidthViewModel();

	public int ChartDefaultWidth = 330;

	public int CategoriesPerPage = 10;

	[AjaxOnly]
	public ActionResult _PartialChartDailyActivity()
	{
		base.ViewBag.usrAccessDailyChart = GetAccessDailyChartAllUsers();
		base.ViewBag.UserChartDailyActivity = GetUserChart(2);
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyActivity")]
	public JsonResult DrawChartDailyActivityOld(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ChartViewModel<int, int> data = new ChartViewModel<int, int>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string chartCmpTitleLangEidtText = Labels.ChartCmpTitleLangEidtText;
			string cNVSTitle_Lang = "+50%";
			string chartCmpTitleLangText = Labels.ChartCmpTitleLangText;
			string chartCnvsTitleLangText = Labels.ChartCnvsTitleLangText;
			string chartPordTitleLangText = Labels.ChartPordTitleLangText;
			string ordTitle_Lang = "ChartOrdTitleLangText".OrderLabels();
			string chartSmsTitleLangText = Labels.ChartSmsTitleLangText;
			string chartRsmsTitleLangText = Labels.ChartRsmsTitleLangText;
			string chartEmlTitleLangText = Labels.ChartEmlTitleLangText;
			string chartLtrTitleLangText = Labels.ChartLtrTitleLangText;
			string chartRltrTitleLangText = Labels.ChartRltrTitleLangText;
			string chartICallTitleLangText = Labels.ChartICallTitleLangText;
			string chartOCallTitleLangText = Labels.ChartOCallTitleLangText;
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			List<CRMspChartCmpEditCNVSPowerful_Result> list = Enumerable.ToList<CRMspChartCmpEditCNVSPowerful_Result>((IEnumerable<CRMspChartCmpEditCNVSPowerful_Result>)_db.CRMspChartCmpEditCNVSPowerful(value, value2, usrId, lCID, result, chartCmpTitleLangEidtText, cNVSTitle_Lang, result2));
			List<CRMspChartDailyActivity_Result> list2 = Enumerable.ToList<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)_db.CRMspChartDailyActivity(value, value2, usrId, lCID, result, chartCmpTitleLangText, chartCnvsTitleLangText, chartPordTitleLangText, ordTitle_Lang, chartSmsTitleLangText, chartRsmsTitleLangText, chartEmlTitleLangText, chartLtrTitleLangText, chartRltrTitleLangText, chartICallTitleLangText, chartOCallTitleLangText, result2));
			List<SeriesViewModel<int>> list3 = new List<SeriesViewModel<int>>();
			List<SeriesColorViewModel<int>> list4 = new List<SeriesColorViewModel<int>>();
			List<SeriesDataViewModel<int>> seriesData = new List<SeriesDataViewModel<int>>();
			string[] array = new string[Enumerable.Count<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)list2)];
			new Random();
			int num = 0;
			foreach (CRMspChartDailyActivity_Result item5 in list2)
			{
				array.SetValue(item5.Title, num);
				num++;
			}
			if (list2 != null && Enumerable.Any<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)list2))
			{
				int num2 = 0;
				foreach (CRMspChartDailyActivity_Result item in list2)
				{
					array.SetValue(item.TitleLang, num2);
					num2++;
					SeriesViewModel<int> item2 = new SeriesViewModel<int>
					{
						name = item.TitleLang,
						y = item.Cnt.GetValueOrDefault()
					};
					list3.Add(item2);
					Thread.Sleep(100);
					string color = $"#{new Random((int)DateTime.Now.Ticks).Next(16777216):X6}";
					SeriesColorViewModel<int> item3 = new SeriesColorViewModel<int>
					{
						name = item.TitleLang,
						y = item.Cnt.GetValueOrDefault(),
						color = color
					};
					list4.Add(item3);
					CRMspChartCmpEditCNVSPowerful_Result cRMspChartCmpEditCNVSPowerful_Result = Enumerable.FirstOrDefault<CRMspChartCmpEditCNVSPowerful_Result>((IEnumerable<CRMspChartCmpEditCNVSPowerful_Result>)list, (Func<CRMspChartCmpEditCNVSPowerful_Result, bool>)((CRMspChartCmpEditCNVSPowerful_Result m) => m.Type == item.Type && m.Ord == item.Ord));
					if (cRMspChartCmpEditCNVSPowerful_Result != null)
					{
						string name = ((cRMspChartCmpEditCNVSPowerful_Result.Type == "Cmp") ? cRMspChartCmpEditCNVSPowerful_Result.TitleLang : (item.TitleLang + "(" + cRMspChartCmpEditCNVSPowerful_Result.TitleLang + ")"));
						SeriesColorViewModel<int> item4 = new SeriesColorViewModel<int>
						{
							name = name,
							y = cRMspChartCmpEditCNVSPowerful_Result.cnt.GetValueOrDefault(),
							color = color
						};
						list4.Add(item4);
					}
				}
				data = new ChartViewModel<int, int>
				{
					Title = Labels.ChartDailyActivitTitle,
					subTitle = "",
					XAxisCategories = array,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = list3,
					SeriesData = seriesData,
					SeriesColor = list4
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyActivity")]
	public JsonResult DrawChartDailyActivity(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		KendoChartViewModel<ChartDailyActivityKendoViewModel> data = new KendoChartViewModel<ChartDailyActivityKendoViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string chartCmpTitleLangEidtText = Labels.ChartCmpTitleLangEidtText;
			string cNVSTitle_Lang = "+50%";
			string chartCmpTitleLangText = Labels.ChartCmpTitleLangText;
			string chartCnvsTitleLangText = Labels.ChartCnvsTitleLangText;
			string chartPordTitleLangText = Labels.ChartPordTitleLangText;
			string ordTitle_Lang = "ChartOrdTitleLangText".OrderLabels();
			string chartSmsTitleLangText = Labels.ChartSmsTitleLangText;
			string chartRsmsTitleLangText = Labels.ChartRsmsTitleLangText;
			string chartEmlTitleLangText = Labels.ChartEmlTitleLangText;
			string chartLtrTitleLangText = Labels.ChartLtrTitleLangText;
			string chartRltrTitleLangText = Labels.ChartRltrTitleLangText;
			string chartICallTitleLangText = Labels.ChartICallTitleLangText;
			string chartOCallTitleLangText = Labels.ChartOCallTitleLangText;
			string chartFInternalTitleLangText = Labels.ChartFInternalTitleLangText;
			string chartFMobileTitleLangText = Labels.ChartFMobileTitleLangText;
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
			List<CRMspChartCmpEditCNVSPowerful_Result> list = Enumerable.ToList<CRMspChartCmpEditCNVSPowerful_Result>((IEnumerable<CRMspChartCmpEditCNVSPowerful_Result>)_db.CRMspChartCmpEditCNVSPowerful(value, value2, usrId, lCID, result, chartCmpTitleLangEidtText, cNVSTitle_Lang, result2));
			List<CRMspChartDailyActivity_Result> list2 = Enumerable.ToList<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)_dbI.CRMspChartDailyActivity(value, value2, usrId, lCID, result, chartCmpTitleLangText, chartCnvsTitleLangText, chartPordTitleLangText, ordTitle_Lang, chartSmsTitleLangText, chartRsmsTitleLangText, chartEmlTitleLangText, chartLtrTitleLangText, chartRltrTitleLangText, chartICallTitleLangText, chartOCallTitleLangText, chartFInternalTitleLangText, chartFMobileTitleLangText, result2));
			List<ChartDailyActivityKendoViewModel> list3 = new List<ChartDailyActivityKendoViewModel>();
			string[] array = new string[Enumerable.Count<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)list2)];
			new Random();
			int num = 0;
			foreach (CRMspChartDailyActivity_Result item4 in list2)
			{
				array.SetValue(item4.TitleLang, num);
				num++;
			}
			if (list2 != null && Enumerable.Any<CRMspChartDailyActivity_Result>((IEnumerable<CRMspChartDailyActivity_Result>)list2))
			{
				int num2 = 0;
				foreach (CRMspChartDailyActivity_Result item in list2)
				{
					Thread.Sleep(100);
					string color = $"#{new Random((int)DateTime.Now.Ticks).Next(16777216):X6}";
					ChartDailyActivityKendoViewModel item2 = new ChartDailyActivityKendoViewModel
					{
						Title = item.TitleLang,
						Cnt = item.Cnt.GetValueOrDefault(),
						Ord = item.Ord.GetValueOrDefault(),
						VisibleInLegend = true,
						Color = color,
						CategoryField = item.TitleLang
					};
					list3.Add(item2);
					CRMspChartCmpEditCNVSPowerful_Result cRMspChartCmpEditCNVSPowerful_Result = Enumerable.FirstOrDefault<CRMspChartCmpEditCNVSPowerful_Result>((IEnumerable<CRMspChartCmpEditCNVSPowerful_Result>)list, (Func<CRMspChartCmpEditCNVSPowerful_Result, bool>)((CRMspChartCmpEditCNVSPowerful_Result m) => m.Type == item.Type && m.Ord == item.Ord));
					if (cRMspChartCmpEditCNVSPowerful_Result != null)
					{
						ChartDailyActivityKendoViewModel item3 = new ChartDailyActivityKendoViewModel
						{
							Title = cRMspChartCmpEditCNVSPowerful_Result.TitleLang,
							Cnt = cRMspChartCmpEditCNVSPowerful_Result.cnt.GetValueOrDefault(),
							Ord = cRMspChartCmpEditCNVSPowerful_Result.Ord.GetValueOrDefault(),
							VisibleInLegend = false,
							Color = color,
							CategoryField = item.TitleLang
						};
						list3.Add(item3);
					}
					num2++;
				}
				data = new KendoChartViewModel<ChartDailyActivityKendoViewModel>
				{
					Title = Labels.ChartDailyActivitTitle,
					subTitle = "",
					XAxisCategories = array,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = list3
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialChartDailyOrders()
	{
		base.ViewBag.usrAccessSaleChartInDailyOrd = GetAccessSaleChartAllUsers();
		base.ViewBag.UserChartDailyOrder = GetUserChart(16);
		base.ViewBag.HorizontalFields = GetHorizontalFields();
		base.ViewBag.VerticalModes = GetVerticalModes();
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyOrders")]
	public JsonResult DrawChartDailyOrdersOld(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ChartViewModel<decimal, int> data = new ChartViewModel<decimal, int>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			List<CRMspChartDailyOrders_Result> list = Enumerable.ToList<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)_db.CRMspChartDailyOrders(value, value2, usrId));
			List<CRMspChartDailyOrders_Result> list2 = Enumerable.ToList<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)_db.CRMspChartDailyOrders(value.AddYears(-1), value2.AddYears(-1), usrId));
			if (Enumerable.Any<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list) && Enumerable.Any<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list2))
			{
				List<SeriesDataColorViewModel<decimal>> list3 = new List<SeriesDataColorViewModel<decimal>>();
				List<SeriesDataColorViewModel<int>> list4 = new List<SeriesDataColorViewModel<int>>();
				string[] array = new string[Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list)];
				decimal[] array2 = new decimal[Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list)];
				decimal[] array3 = new decimal[Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list)];
				int[] array4 = new int[Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list)];
				int[] array5 = new int[Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list)];
				for (int i = 0; i < Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list); i++)
				{
					if (lCID == 1065)
					{
						array.SetValue(list[i].PDay, i);
					}
					else
					{
						array.SetValue(list[i].MDay.ToString(), i);
					}
					array4.SetValue(list[i].ordCnt, i);
					array5.SetValue(list2[i].ordCnt, i);
					array2.SetValue(list[i].ordAmnt, i);
					array3.SetValue(list2[i].ordAmnt, i);
				}
				list4.Add(new SeriesDataColorViewModel<int>
				{
					name = value.ToString("yyyy"),
					data = array4,
					color = "#800000"
				});
				list4.Add(new SeriesDataColorViewModel<int>
				{
					name = value.AddYears(-1).ToString("yyyy"),
					data = array5,
					color = "#FECB99"
				});
				list3.Add(new SeriesDataColorViewModel<decimal>
				{
					name = value.ToString("yyyy"),
					data = array2,
					color = "#800000"
				});
				list3.Add(new SeriesDataColorViewModel<decimal>
				{
					name = value.AddYears(-1).ToString("yyyy"),
					data = array3,
					color = "#FECB99"
				});
				data = new ChartViewModel<decimal, int>
				{
					Title = "ChartDailyOrdersCntTitle".OrderLabels(),
					subTitle = "",
					XAxisCategories = array,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = null,
					SeriesData = null,
					SeriesDataLineColor = list4,
					SeriesDataColumnColor = list3
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyOrders")]
	public JsonResult DrawChartDailyOrders(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		KendoChartViewModel<ChartDailyOrderKendoViewModel> data = new KendoChartViewModel<ChartDailyOrderKendoViewModel>();
		try
		{
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
			List<CRMspChartDailyOrders_Result> list = Enumerable.ToList<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)_db.CRMspChartDailyOrders(value, value2, usrId));
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				string s = fDate.Replace("/", "").Substring(0, 4);
				string text = string.Concat(str1: fDate.Replace("/", "").Substring(4, 4), str0: (long.Parse(s) - 1).ToString());
				value3 = ((lCID != 1065) ? value.AddYears(-1) : DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				}));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				string s2 = tDate.Replace("/", "").Substring(0, 4);
				string text2 = tDate.Replace("/", "").Substring(4, 4);
				string text3 = tDate.Replace("/", "").Substring(4, 2);
				string s3 = tDate.Replace("/", "").Substring(6, 2);
				long num = long.Parse(s2) - 1;
				string text4 = num + text2;
				if (lCID == 1065)
				{
					try
					{
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					catch (Exception)
					{
						text4 = num + text3 + (int.Parse(s3) - 1);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					value4 = value2.AddYears(-1);
				}
			}
			List<CRMspChartDailyOrders_Result> list2 = Enumerable.ToList<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)_db.CRMspChartDailyOrders(value3, value4, usrId));
			List<ChartDailyOrderKendoViewModel> list3 = new List<ChartDailyOrderKendoViewModel>();
			if (Enumerable.Any<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list) && Enumerable.Any<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list2))
			{
				int num2 = Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list);
				int num3 = Enumerable.Count<CRMspChartDailyOrders_Result>((IEnumerable<CRMspChartDailyOrders_Result>)list2);
				int num4 = ((num2 > num3) ? num2 : num3);
				string[] xAxisCategories = new string[num4];
				for (int i = 0; i < num4; i++)
				{
					int result2 = 0;
					if (lCID == 1065)
					{
						int.TryParse(list[i].PDay, out result2);
					}
					else
					{
						int.TryParse(list[i].MDay.ToString(), out result2);
					}
					string text5 = ((result2 >= 0 && result2 < 10) ? ("0" + result2) : result2.ToString());
					if (i >= num2)
					{
						ChartDailyOrderKendoViewModel item = new ChartDailyOrderKendoViewModel
						{
							Day = text5,
							Cnt = 0,
							Amnt = 0m,
							VisibleInLegend = true,
							Color = "#D65700",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item);
					}
					else
					{
						ChartDailyOrderKendoViewModel item2 = new ChartDailyOrderKendoViewModel
						{
							Day = text5,
							Cnt = list[i].ordCnt.GetValueOrDefault(),
							Amnt = list[i].ordAmnt.GetValueOrDefault(),
							VisibleInLegend = true,
							Color = "#D65700",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item2);
					}
					if (i >= num3)
					{
						ChartDailyOrderKendoViewModel item3 = new ChartDailyOrderKendoViewModel
						{
							Day = text5,
							Cnt = 0,
							Amnt = 0m,
							VisibleInLegend = false,
							Color = "#F0C2A2",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item3);
					}
					else
					{
						ChartDailyOrderKendoViewModel item4 = new ChartDailyOrderKendoViewModel
						{
							Day = text5,
							Cnt = list2[i].ordCnt.GetValueOrDefault(),
							Amnt = list2[i].ordAmnt.GetValueOrDefault(),
							VisibleInLegend = false,
							Color = "#F0C2A2",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item4);
					}
				}
				data = new KendoChartViewModel<ChartDailyOrderKendoViewModel>
				{
					Title = "ChartDailyOrdersCntTitle".OrderLabels(),
					subTitle = "",
					XAxisCategories = xAxisCategories,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = list3
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult _PartialChartMonthlyOrders()
	{
		base.ViewBag.usrAccessSaleChartInMonthlyOrd = GetAccessSaleChartAllUsers();
		base.ViewBag.UserChartMonthlyOrd = GetUserChart(16);
		base.ViewBag.GroupFields = GetGroupFields();
		return PartialView();
	}

	[HttpGet]
	public ActionResult ChartMonthlyOrdersInfo(string fDate, string tDate, int? userId, string selectedValue = "", int? groupFieldKey = null, string groupFieldValues = null)
	{
		fDate = fDate.Replace("-", "/");
		tDate = tDate.Replace("-", "/");
		groupFieldValues = ((!string.IsNullOrEmpty(groupFieldValues)) ? groupFieldValues.Replace("-", ",") : null);
		base.ViewBag.FromDate = fDate;
		base.ViewBag.ToDate = tDate;
		base.ViewBag.SelectedValue = selectedValue;
		base.ViewBag.UserId = userId;
		base.ViewBag.GroupFieldKey = groupFieldKey;
		base.ViewBag.GroupFieldValues = groupFieldValues;
		return View();
	}

	[HttpPost]
	public JsonResult GetMonthlyOrdersGridData(string fDate, string tDate, int? userId, string selectedValue = "", int pageNumber = 1, int pageSize = 30, int? groupFieldKey = null, string groupFieldValues = null)
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<DateTime> firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime, dateTime2, lCID);
			string firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
			CRMSpIIIEntities dbIII = _dbIII;
			DateTime? fDate2 = dateTime;
			DateTime? tDate2 = dateTime2;
			int? currUserId = UserLogin.CurrentUser.UserId;
			int? centerId = result2;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			int? pageNumber2 = pageNumber;
			int? pageSize2 = pageSize;
			List<CRMspChartMonthlyOrdersInfo_Result> list = Enumerable.ToList<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)dbIII.CRMspChartMonthlyOrdersInfo(firstDayOfMonths2, fDate2, tDate2, selectedValue, userId, currUserId, centerId, groupFieldKey, groupFieldValues, languageID, defaultLanguageID, pageNumber2, pageSize2));
			CultureInfo cultureInfo = new CultureInfo(lCID);
			Calendar calendar = cultureInfo.Calendar;
			string[] monthNames = cultureInfo.DateTimeFormat.MonthNames;
			foreach (CRMspChartMonthlyOrdersInfo_Result item in list)
			{
				item.OrderDateStr = (item.OrderDate.HasValue ? DateTimeClass.GetLocalDate(item.OrderDate).Value.ToString("yyyy/MM/dd") : "");
				if (!string.IsNullOrEmpty(item.DateValue))
				{
					DateTime time = DateTime.ParseExact(item.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
					int month = calendar.GetMonth(time);
					int year = calendar.GetYear(time);
					item.DateText = $"{monthNames[month - 1]} {year}";
				}
			}
			int totalCount = ((Enumerable.Count<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list) > 0) ? Enumerable.FirstOrDefault<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list).TotalCount.GetValueOrDefault() : 0);
			var data = Enumerable.Select((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list, (CRMspChartMonthlyOrdersInfo_Result c) => new
			{
				OrderId = c.OrderId,
				OrderNumber = c.OrderNumber,
				OrderDate = c.OrderDateStr,
				OrderTotalAmount = c.OrderTotalAmount,
				OprType = c.OprType,
				XLabelText = c.DateText,
				GroupFieldText = c.GroupFieldText,
				GroupFieldValue = c.GroupFieldValue,
				FilteredProductAmount = c.FilteredProductAmount,
				FilteredProductCount = c.FilteredProductCount,
				OrderTotalDiscount = c.OrderTotalDiscount,
				FilteredProductDiscount = c.FilteredProductDiscount
			});
			return Json(new { data, totalCount }, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				data = new object[0],
				totalCount = 0
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessMonthlyOrders")]
	public JsonResult DrawChartMonthlyOrders(string fDate, string tDate, int userId, int? groupFieldKey = null, string groupFieldValues = null)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<object> list = new List<object>();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (dateTime > dateTime2)
			{
				string msgErrorChartInvalidDateRangeOrder = Messages.msgErrorChartInvalidDateRangeOrder;
				return Json(new
				{
					message = msgErrorChartInvalidDateRangeOrder
				}, JsonRequestBehavior.AllowGet);
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			List<DateTime> firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime, dateTime2, lCID);
			string firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
			List<CRMspChartMonthlyOrders_Result> list2 = Enumerable.ToList<CRMspChartMonthlyOrders_Result>((IEnumerable<CRMspChartMonthlyOrders_Result>)_db.CRMspChartMonthlyOrders(dateTime, dateTime2, userId, firstDayOfMonths2, null, UserLogin.CurrentUser.UserId, result2, lCID, result, groupFieldKey, groupFieldValues));
			foreach (CRMspChartMonthlyOrders_Result item in list2)
			{
				item.SaleOrderCount = item.SaleOrderCount.GetValueOrDefault();
				item.ReturnOrderCount = item.ReturnOrderCount.GetValueOrDefault();
				item.NetOrderCount = item.NetOrderCount.GetValueOrDefault();
				item.SaleOrderAmount = item.SaleOrderAmount.GetValueOrDefault();
				item.ReturnOrderAmount = item.ReturnOrderAmount.GetValueOrDefault();
				item.NetOrderAmount = item.NetOrderAmount.GetValueOrDefault();
				item.NetOrderDiscountAmount = item.NetOrderDiscountAmount.GetValueOrDefault();
			}
			CultureInfo cultureInfo = new CultureInfo(lCID);
			Calendar calendar = cultureInfo.Calendar;
			string[] monthNames = cultureInfo.DateTimeFormat.MonthNames;
			foreach (CRMspChartMonthlyOrders_Result item2 in list2)
			{
				if (!string.IsNullOrEmpty(item2.DateValue))
				{
					DateTime time = DateTime.ParseExact(item2.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
					int month = calendar.GetMonth(time);
					int year = calendar.GetYear(time);
					item2.DateText = $"{monthNames[month - 1]} {year}";
				}
			}
			DateTime dateTime3 = dateTime2;
			DateTime dateTime4 = dateTime;
			if (!string.IsNullOrEmpty(fDate))
			{
				string s = fDate.Replace("/", "").Substring(0, 4);
				string text = string.Concat(str1: fDate.Replace("/", "").Substring(4, 4), str0: (long.Parse(s) - 1).ToString());
				dateTime4 = ((lCID != 1065) ? dateTime.AddYears(-1) : DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				}));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				string s2 = tDate.Replace("/", "").Substring(0, 4);
				string text2 = tDate.Replace("/", "").Substring(4, 4);
				string text3 = tDate.Replace("/", "").Substring(4, 2);
				string s3 = tDate.Replace("/", "").Substring(6, 2);
				long num = long.Parse(s2) - 1;
				string text4 = num + text2;
				if (lCID == 1065)
				{
					try
					{
						dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					catch (Exception)
					{
						text4 = num + text3 + (int.Parse(s3) - 1);
						dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					dateTime3 = dateTime2.AddYears(-1);
				}
			}
			firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime4, dateTime3, lCID);
			firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
			List<CRMspChartMonthlyOrders_Result> list3 = Enumerable.ToList<CRMspChartMonthlyOrders_Result>((IEnumerable<CRMspChartMonthlyOrders_Result>)_db.CRMspChartMonthlyOrders(dateTime4, dateTime3, userId, firstDayOfMonths2, null, UserLogin.CurrentUser.UserId, result2, lCID, result, groupFieldKey, groupFieldValues));
			foreach (CRMspChartMonthlyOrders_Result item3 in list3)
			{
				item3.SaleOrderCount = item3.SaleOrderCount.GetValueOrDefault();
				item3.ReturnOrderCount = item3.ReturnOrderCount.GetValueOrDefault();
				item3.NetOrderCount = item3.NetOrderCount.GetValueOrDefault();
				item3.SaleOrderAmount = item3.SaleOrderAmount.GetValueOrDefault();
				item3.ReturnOrderAmount = item3.ReturnOrderAmount.GetValueOrDefault();
				item3.NetOrderAmount = item3.NetOrderAmount.GetValueOrDefault();
				item3.NetOrderDiscountAmount = item3.NetOrderDiscountAmount.GetValueOrDefault();
			}
			foreach (CRMspChartMonthlyOrders_Result item4 in list3)
			{
				if (!string.IsNullOrEmpty(item4.DateValue))
				{
					DateTime time2 = DateTime.ParseExact(item4.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
					int month2 = calendar.GetMonth(time2);
					int year2 = calendar.GetYear(time2);
					item4.DateText = $"{monthNames[month2 - 1]} {year2}";
				}
			}
			list.AddRange(Enumerable.Select((IEnumerable<CRMspChartMonthlyOrders_Result>)list2, (CRMspChartMonthlyOrders_Result c) => new
			{
				XLabelValue = c.DateValue,
				XLabelText = c.DateText,
				SaleOrderCount = c.SaleOrderCount,
				ReturnOrderCount = c.ReturnOrderCount,
				NetOrderCount = c.NetOrderCount,
				SaleOrderAmount = c.SaleOrderAmount,
				ReturnOrderAmount = c.ReturnOrderAmount,
				NetOrderAmount = c.NetOrderAmount,
				NetOrderDiscountAmount = c.NetOrderDiscountAmount,
				GroupFieldText = c.GroupFieldText,
				GroupFieldValue = c.GroupFieldValue,
				IsCurrentYear = true
			}));
			list.AddRange(Enumerable.Select((IEnumerable<CRMspChartMonthlyOrders_Result>)list3, (CRMspChartMonthlyOrders_Result c) => new
			{
				XLabelValue = c.DateValue,
				XLabelText = c.DateText,
				SaleOrderCount = c.SaleOrderCount,
				ReturnOrderCount = c.ReturnOrderCount,
				NetOrderCount = c.NetOrderCount,
				SaleOrderAmount = c.SaleOrderAmount,
				ReturnOrderAmount = c.ReturnOrderAmount,
				NetOrderAmount = c.NetOrderAmount,
				NetOrderDiscountAmount = c.NetOrderDiscountAmount,
				GroupFieldText = c.GroupFieldText,
				GroupFieldValue = c.GroupFieldValue,
				IsCurrentYear = false
			}));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			chartData = list
		}, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public ActionResult _PartialChartDailyPreOrders()
	{
		base.ViewBag.usrAccessSaleChartInDailyPord = GetAccessSaleChartAllUsers();
		base.ViewBag.UserChartDailyPord = GetUserChart(15);
		return PartialView();
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyPreOrders")]
	public JsonResult DrawChartDailyPreOrdersOld(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ChartViewModel<decimal, int> data = new ChartViewModel<decimal, int>();
		try
		{
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", (lCID == 1065) ? new PersianCulture() : new CultureInfo("en-US"));
			}
			List<CRMspChartDailyPreOrders_Result> list = Enumerable.ToList<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)_db.CRMspChartDailyPreOrders(value, value2, usrId));
			List<CRMspChartDailyPreOrders_Result> list2 = Enumerable.ToList<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)_db.CRMspChartDailyPreOrders(value.AddYears(-1), value2.AddYears(-1), usrId));
			if (Enumerable.Any<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list) && Enumerable.Any<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list2))
			{
				List<SeriesDataColorViewModel<decimal>> list3 = new List<SeriesDataColorViewModel<decimal>>();
				List<SeriesDataColorViewModel<int>> list4 = new List<SeriesDataColorViewModel<int>>();
				string[] array = new string[Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list)];
				decimal[] array2 = new decimal[Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list)];
				decimal[] array3 = new decimal[Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list)];
				int[] array4 = new int[Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list)];
				int[] array5 = new int[Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list)];
				for (int i = 0; i < Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list); i++)
				{
					if (lCID == 1065)
					{
						array.SetValue(list[i].PDay, i);
					}
					else
					{
						array.SetValue(list[i].MDay.ToString(), i);
					}
					array4.SetValue(list[i].pordCnt, i);
					array5.SetValue(list2[i].pordCnt, i);
					array2.SetValue(list[i].ordAmnt, i);
					array3.SetValue(list2[i].ordAmnt, i);
				}
				list4.Add(new SeriesDataColorViewModel<int>
				{
					name = value.ToString("yyyy"),
					data = array4,
					color = "#800000"
				});
				list4.Add(new SeriesDataColorViewModel<int>
				{
					name = value.AddYears(-1).ToString("yyyy"),
					data = array5,
					color = "#FECB99"
				});
				list3.Add(new SeriesDataColorViewModel<decimal>
				{
					name = value.ToString("yyyy"),
					data = array2,
					color = "#800000"
				});
				list3.Add(new SeriesDataColorViewModel<decimal>
				{
					name = value.AddYears(-1).ToString("yyyy"),
					data = array3,
					color = "#FECB99"
				});
				data = new ChartViewModel<decimal, int>
				{
					Title = Labels.ChartDailyPreOrdersCntTitle,
					subTitle = "",
					XAxisCategories = array,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = null,
					SeriesData = null,
					SeriesDataLineColor = list4,
					SeriesDataColumnColor = list3
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyPreOrders")]
	public JsonResult DrawChartDailyPreOrders(int usrId, string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		KendoChartViewModel<ChartDailyPreOrderKendoViewModel> data = new KendoChartViewModel<ChartDailyPreOrderKendoViewModel>();
		try
		{
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
			List<CRMspChartDailyPreOrders_Result> list = Enumerable.ToList<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)_db.CRMspChartDailyPreOrders(value, value2, usrId));
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				string s = fDate.Replace("/", "").Substring(0, 4);
				string text = string.Concat(str1: fDate.Replace("/", "").Substring(4, 4), str0: (long.Parse(s) - 1).ToString());
				value3 = ((lCID != 1065) ? value.AddYears(-1) : DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				}));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				string s2 = tDate.Replace("/", "").Substring(0, 4);
				string text2 = tDate.Replace("/", "").Substring(4, 4);
				string text3 = tDate.Replace("/", "").Substring(4, 2);
				string s3 = tDate.Replace("/", "").Substring(6, 2);
				long num = long.Parse(s2) - 1;
				string text4 = num + text2;
				if (lCID == 1065)
				{
					try
					{
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					catch (Exception)
					{
						text4 = num + text3 + (int.Parse(s3) - 1);
						value4 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					value4 = value2.AddYears(-1);
				}
			}
			List<CRMspChartDailyPreOrders_Result> list2 = Enumerable.ToList<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)_db.CRMspChartDailyPreOrders(value3, value4, usrId));
			List<ChartDailyPreOrderKendoViewModel> list3 = new List<ChartDailyPreOrderKendoViewModel>();
			if (Enumerable.Any<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list) && Enumerable.Any<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list2))
			{
				int num2 = Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list);
				int num3 = Enumerable.Count<CRMspChartDailyPreOrders_Result>((IEnumerable<CRMspChartDailyPreOrders_Result>)list2);
				int num4 = ((num2 > num3) ? num2 : num3);
				string[] xAxisCategories = new string[num4];
				for (int i = 0; i < num4; i++)
				{
					int result2 = 0;
					if (lCID == 1065)
					{
						int.TryParse(list[i].PDay, out result2);
					}
					else
					{
						int.TryParse(list[i].MDay.ToString(), out result2);
					}
					string text5 = ((result2 >= 0 && result2 < 10) ? ("0" + result2) : result2.ToString());
					if (i >= num2)
					{
						ChartDailyPreOrderKendoViewModel item = new ChartDailyPreOrderKendoViewModel
						{
							Day = text5,
							Cnt = 0,
							Amnt = 0m,
							VisibleInLegend = true,
							Color = "#D65700",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item);
					}
					else
					{
						ChartDailyPreOrderKendoViewModel item2 = new ChartDailyPreOrderKendoViewModel
						{
							Day = text5,
							Cnt = list[i].pordCnt.GetValueOrDefault(),
							Amnt = list[i].ordAmnt.GetValueOrDefault(),
							VisibleInLegend = true,
							Color = "#D65700",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item2);
					}
					if (i >= num3)
					{
						ChartDailyPreOrderKendoViewModel item3 = new ChartDailyPreOrderKendoViewModel
						{
							Day = text5,
							Cnt = 0,
							Amnt = 0m,
							VisibleInLegend = false,
							Color = "#F0C2A2",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item3);
					}
					else
					{
						ChartDailyPreOrderKendoViewModel item4 = new ChartDailyPreOrderKendoViewModel
						{
							Day = text5,
							Cnt = list2[i].pordCnt.GetValueOrDefault(),
							Amnt = list2[i].ordAmnt.GetValueOrDefault(),
							VisibleInLegend = false,
							Color = "#F0C2A2",
							Ord = result2,
							CategoryField = text5
						};
						list3.Add(item4);
					}
				}
				data = new KendoChartViewModel<ChartDailyPreOrderKendoViewModel>
				{
					Title = "ChartDailyOrdersCntTitle".OrderLabels(),
					subTitle = "",
					XAxisCategories = xAxisCategories,
					XAxisTitle = "",
					YAxisTitle = "",
					YAxisTooltipValueSuffix = "",
					Series = list3
				};
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public bool GetAccessDailyChartAllUsers()
	{
		bool result = false;
		try
		{
			CRMspChartUserAccess_Result cRMspChartUserAccess_Result = Enumerable.FirstOrDefault<CRMspChartUserAccess_Result>((IEnumerable<CRMspChartUserAccess_Result>)_db.CRMspChartUserAccess(UserLogin.CurrentUser.UserId));
			if (cRMspChartUserAccess_Result != null)
			{
				result = cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessDailyChrtAllUsers != false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public bool GetAccessSaleChartAllUsers()
	{
		bool result = false;
		try
		{
			CRMspChartUserAccess_Result cRMspChartUserAccess_Result = Enumerable.FirstOrDefault<CRMspChartUserAccess_Result>((IEnumerable<CRMspChartUserAccess_Result>)_db.CRMspChartUserAccess(UserLogin.CurrentUser.UserId));
			if (cRMspChartUserAccess_Result != null)
			{
				result = cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers.HasValue && cRMspChartUserAccess_Result.UserAccessSaleChrtAllUsers != false;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public List<SelectListItem> GetUserChart(int linkType)
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
			List<CRMspSelectUserForCnvsReferToUser_Result> list2 = Enumerable.ToList<CRMspSelectUserForCnvsReferToUser_Result>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)_db.CRMspSelectUserForCnvsReferToUser(UserLogin.CurrentUser.UserId, linkType, 0, lCID, result, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>((IEnumerable<CRMspSelectUserForCnvsReferToUser_Result>)list2, (Func<CRMspSelectUserForCnvsReferToUser_Result, SelectListItem>)((CRMspSelectUserForCnvsReferToUser_Result item) => new SelectListItem
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
		return list;
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actChrtAccessDailyOrders")]
	public JsonResult DrawChartDailyExtraOrders(string fDate, int userId, string tDate, short horizontalField = 1, short verticalMode = 1, string selectedValues = "", int pageSize = 30, int? groupFieldKey = 0, string groupFieldValues = "", string conditionsJson = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<object> list = new List<object>();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (dateTime > dateTime2)
			{
				string msgErrorChartInvalidDateRangeOrder = Messages.msgErrorChartInvalidDateRangeOrder;
				return Json(new
				{
					message = msgErrorChartInvalidDateRangeOrder
				}, JsonRequestBehavior.AllowGet);
			}
			DateTime dateTime3 = dateTime2;
			DateTime dateTime4 = dateTime;
			if (!string.IsNullOrEmpty(fDate))
			{
				string s = fDate.Replace("/", "").Substring(0, 4);
				string text = string.Concat(str1: fDate.Replace("/", "").Substring(4, 4), str0: (long.Parse(s) - 1).ToString());
				dateTime4 = ((lCID != 1065) ? dateTime.AddYears(-1) : DateTime.Parse(PersianDate.GetFormatetdDate(text.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				}));
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				string s2 = tDate.Replace("/", "").Substring(0, 4);
				string text2 = tDate.Replace("/", "").Substring(4, 4);
				string text3 = tDate.Replace("/", "").Substring(4, 2);
				string s3 = tDate.Replace("/", "").Substring(6, 2);
				long num = long.Parse(s2) - 1;
				string text4 = num + text2;
				if (lCID == 1065)
				{
					try
					{
						dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
					catch (Exception)
					{
						text4 = num + text3 + (int.Parse(s3) - 1);
						dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(text4.Replace("/", "")) + " 23:59:59", lCID switch
						{
							1025 => new CultureInfo("ar-SA"), 
							1065 => new PersianCulture(), 
							_ => new CultureInfo("en-US"), 
						});
					}
				}
				else
				{
					dateTime3 = dateTime2.AddYears(-1);
				}
			}
			if (horizontalField == 1 && dateTime2.AddYears(-1) > dateTime)
			{
				string msgErrorChartInvalidDateRangeMaxOneYear = Messages.msgErrorChartInvalidDateRangeMaxOneYear;
				return Json(new
				{
					message = msgErrorChartInvalidDateRangeMaxOneYear
				}, JsonRequestBehavior.AllowGet);
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (horizontalField != 21)
			{
				CRMSpIIEntities dbII = _dbII;
				short? horizontalField2 = horizontalField;
				short? verticalMode2 = verticalMode;
				DateTime? fDate2 = dateTime;
				DateTime? tDate2 = dateTime2;
				int? userId2 = userId;
				int? currUserId = UserLogin.CurrentUser.UserId;
				int? centerId = result2;
				int? languageID = lCID;
				int? defaultLanguageID = result;
				List<CRMspChartDailyOrdersExtra_Result> list2 = Enumerable.ToList<CRMspChartDailyOrdersExtra_Result>((IEnumerable<CRMspChartDailyOrdersExtra_Result>)dbII.CRMspChartDailyOrdersExtra(horizontalField2, verticalMode2, selectedValues, fDate2, tDate2, groupFieldKey, groupFieldValues, conditionsJson, userId2, currUserId, centerId, languageID, defaultLanguageID));
				if (horizontalField == 1)
				{
					foreach (CRMspChartDailyOrdersExtra_Result item in list2)
					{
						DateTime dateTime5 = DateTime.ParseExact(item.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
						item.XLabelText = ((item.XLabelText != null) ? dateTime5.ToString("yyyy/MM/dd") : "");
					}
				}
				foreach (CRMspChartDailyOrdersExtra_Result item2 in list2)
				{
					item2.YSaleOrderLabelText = item2.YSaleOrderLabelText.GetValueOrDefault();
					item2.YReturnOrderLabelText = item2.YReturnOrderLabelText.GetValueOrDefault();
					item2.YNetOrderLabelText = item2.YNetOrderLabelText.GetValueOrDefault();
					if (item2.XLabelValue == null)
					{
						item2.XLabelText = Labels.LblNoValue;
						item2.XLabelValue = "-1000";
					}
				}
				CRMSpIIEntities dbII2 = _dbII;
				short? horizontalField3 = horizontalField;
				short? verticalMode3 = verticalMode;
				DateTime? fDate3 = dateTime4;
				DateTime? tDate3 = dateTime3;
				defaultLanguageID = userId;
				languageID = UserLogin.CurrentUser.UserId;
				centerId = result2;
				currUserId = lCID;
				userId2 = result;
				List<CRMspChartDailyOrdersExtra_Result> list3 = Enumerable.ToList<CRMspChartDailyOrdersExtra_Result>((IEnumerable<CRMspChartDailyOrdersExtra_Result>)dbII2.CRMspChartDailyOrdersExtra(horizontalField3, verticalMode3, selectedValues, fDate3, tDate3, groupFieldKey, groupFieldValues, conditionsJson, defaultLanguageID, languageID, centerId, currUserId, userId2));
				if (horizontalField == 1)
				{
					foreach (CRMspChartDailyOrdersExtra_Result item3 in list3)
					{
						DateTime dateTime6 = DateTime.ParseExact(item3.XLabelText, "yyyy-MM-dd", CultureInfo.InvariantCulture);
						item3.XLabelText = ((item3.XLabelText != null) ? dateTime6.ToString("yyyy/MM/dd") : "");
					}
				}
				foreach (CRMspChartDailyOrdersExtra_Result item4 in list3)
				{
					item4.YSaleOrderLabelText = item4.YSaleOrderLabelText.GetValueOrDefault();
					item4.YReturnOrderLabelText = item4.YReturnOrderLabelText.GetValueOrDefault();
					item4.YNetOrderLabelText = item4.YNetOrderLabelText.GetValueOrDefault();
					if (item4.XLabelValue == null)
					{
						item4.XLabelText = Labels.LblNoValue;
					}
				}
				list.AddRange(Enumerable.Select((IEnumerable<CRMspChartDailyOrdersExtra_Result>)list2, (CRMspChartDailyOrdersExtra_Result c) => new
				{
					XLabelText = c.XLabelText,
					XLabelValue = c.XLabelValue,
					YSaleOrderLabelText = c.YSaleOrderLabelText,
					YReturnOrderLabelText = c.YReturnOrderLabelText,
					YNetOrderLabelText = c.YNetOrderLabelText,
					IsCurrentYear = true
				}));
				list.AddRange(Enumerable.Select((IEnumerable<CRMspChartDailyOrdersExtra_Result>)list3, (CRMspChartDailyOrdersExtra_Result c) => new
				{
					XLabelText = c.XLabelText,
					XLabelValue = c.XLabelValue,
					YSaleOrderLabelText = c.YSaleOrderLabelText,
					YReturnOrderLabelText = c.YReturnOrderLabelText,
					YNetOrderLabelText = c.YNetOrderLabelText,
					IsCurrentYear = false
				}));
			}
			else
			{
				List<DateTime> firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime, dateTime2, lCID);
				string firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
				List<CRMspChartMonthlyOrders_Result> list4 = Enumerable.ToList<CRMspChartMonthlyOrders_Result>((IEnumerable<CRMspChartMonthlyOrders_Result>)_db.CRMspChartMonthlyOrders(dateTime, dateTime2, userId, firstDayOfMonths2, null, UserLogin.CurrentUser.UserId, result2, lCID, result, groupFieldKey, groupFieldValues));
				foreach (CRMspChartMonthlyOrders_Result item5 in list4)
				{
					item5.SaleOrderCount = item5.SaleOrderCount.GetValueOrDefault();
					item5.ReturnOrderCount = item5.ReturnOrderCount.GetValueOrDefault();
					item5.NetOrderCount = item5.NetOrderCount.GetValueOrDefault();
					item5.SaleOrderAmount = item5.SaleOrderAmount.GetValueOrDefault();
					item5.ReturnOrderAmount = item5.ReturnOrderAmount.GetValueOrDefault();
					item5.NetOrderAmount = item5.NetOrderAmount.GetValueOrDefault();
					item5.NetOrderDiscountAmount = item5.NetOrderDiscountAmount.GetValueOrDefault();
				}
				CultureInfo cultureInfo = new CultureInfo(lCID);
				Calendar calendar = cultureInfo.Calendar;
				string[] monthNames = cultureInfo.DateTimeFormat.MonthNames;
				foreach (CRMspChartMonthlyOrders_Result item6 in list4)
				{
					if (!string.IsNullOrEmpty(item6.DateValue))
					{
						DateTime time = DateTime.ParseExact(item6.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
						int month = calendar.GetMonth(time);
						int year = calendar.GetYear(time);
						item6.DateText = $"{monthNames[month - 1]} {year}";
					}
				}
				firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime4, dateTime3, lCID);
				firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
				List<CRMspChartMonthlyOrders_Result> list5 = Enumerable.ToList<CRMspChartMonthlyOrders_Result>((IEnumerable<CRMspChartMonthlyOrders_Result>)_db.CRMspChartMonthlyOrders(dateTime4, dateTime3, userId, firstDayOfMonths2, null, UserLogin.CurrentUser.UserId, result2, lCID, result, groupFieldKey, groupFieldValues));
				foreach (CRMspChartMonthlyOrders_Result item7 in list5)
				{
					item7.SaleOrderCount = item7.SaleOrderCount.GetValueOrDefault();
					item7.ReturnOrderCount = item7.ReturnOrderCount.GetValueOrDefault();
					item7.NetOrderCount = item7.NetOrderCount.GetValueOrDefault();
					item7.SaleOrderAmount = item7.SaleOrderAmount.GetValueOrDefault();
					item7.ReturnOrderAmount = item7.ReturnOrderAmount.GetValueOrDefault();
					item7.NetOrderAmount = item7.NetOrderAmount.GetValueOrDefault();
					item7.NetOrderDiscountAmount = item7.NetOrderDiscountAmount.GetValueOrDefault();
				}
				foreach (CRMspChartMonthlyOrders_Result item8 in list5)
				{
					if (!string.IsNullOrEmpty(item8.DateValue))
					{
						DateTime time2 = DateTime.ParseExact(item8.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
						int month2 = calendar.GetMonth(time2);
						int year2 = calendar.GetYear(time2);
						item8.DateText = $"{monthNames[month2 - 1]} {year2}";
					}
				}
				list.AddRange(Enumerable.Select((IEnumerable<CRMspChartMonthlyOrders_Result>)list4, (CRMspChartMonthlyOrders_Result c) => new
				{
					XLabelValue = c.DateValue,
					XLabelText = c.DateText,
					YSaleOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.SaleOrderAmount : c.SaleOrderCount),
					YReturnOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.ReturnOrderAmount : c.ReturnOrderCount),
					YNetOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.NetOrderAmount : c.NetOrderCount),
					IsCurrentYear = true
				}));
				list.AddRange(Enumerable.Select((IEnumerable<CRMspChartMonthlyOrders_Result>)list5, (CRMspChartMonthlyOrders_Result c) => new
				{
					XLabelValue = c.DateValue,
					XLabelText = c.DateText,
					YSaleOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.SaleOrderAmount : c.SaleOrderCount),
					YReturnOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.ReturnOrderAmount : c.ReturnOrderCount),
					YNetOrderLabelText = ((verticalMode == 1 || verticalMode == 1) ? c.NetOrderAmount : c.NetOrderCount),
					IsCurrentYear = false
				}));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			chartData = list
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpGet]
	public ActionResult ChartDailyOrdersInfo(string fDate, int userId, string tDate, short horizontalField = 1, short verticalMode = 1, string selectedValues = "")
	{
		fDate = fDate.Replace("-", "/");
		tDate = tDate.Replace("-", "/");
		base.ViewBag.FromDate = fDate;
		base.ViewBag.ToDate = tDate;
		base.ViewBag.HorizontalField = horizontalField;
		base.ViewBag.VerticalMode = verticalMode;
		base.ViewBag.SelectedValues = selectedValues;
		base.ViewBag.UserId = userId;
		return View();
	}

	[HttpPost]
	public JsonResult GetDailyOrdersGridData(string fDate, int userId, string tDate, short horizontalField = 1, short verticalMode = 1, string selectedValues = "", int pageNumber = 1, int pageSize = 30, int groupFieldKey = 0, string groupFieldValues = "", string conditionsJson = "")
	{
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			string groupFieldValues2;
			if (horizontalField != 21)
			{
				CRMSpIIIEntities dbIII = _dbIII;
				short? horizontalField2 = horizontalField;
				short? verticalMode2 = verticalMode;
				DateTime? fDate2 = dateTime;
				DateTime? tDate2 = dateTime2;
				int? userId2 = userId;
				int? currUserId = UserLogin.CurrentUser.UserId;
				int? centerId = result2;
				int? languageID = lCID;
				int? defaultLanguageID = result;
				int? pageNumber2 = pageNumber;
				int? pageSize2 = pageSize;
				int? groupFieldKey2 = groupFieldKey;
				groupFieldValues2 = groupFieldValues;
				List<CRMspChartDailyOrdersExtraInfo_Result> list = Enumerable.ToList<CRMspChartDailyOrdersExtraInfo_Result>((IEnumerable<CRMspChartDailyOrdersExtraInfo_Result>)dbIII.CRMspChartDailyOrdersExtraInfo(horizontalField2, verticalMode2, selectedValues, conditionsJson, fDate2, tDate2, groupFieldKey2, groupFieldValues2, userId2, currUserId, centerId, languageID, defaultLanguageID, pageNumber2, pageSize2));
				foreach (CRMspChartDailyOrdersExtraInfo_Result item in list)
				{
					if (item.XLabelValue == null)
					{
						item.XLabelText = Labels.LblNoValue;
					}
					item.OrderDateStr = (item.OrderDate.HasValue ? DateTimeClass.GetLocalDate(item.OrderDate).Value.ToString("yyyy/MM/dd") : "");
				}
				int totalCount = ((Enumerable.Count<CRMspChartDailyOrdersExtraInfo_Result>((IEnumerable<CRMspChartDailyOrdersExtraInfo_Result>)list) > 0) ? Enumerable.FirstOrDefault<CRMspChartDailyOrdersExtraInfo_Result>((IEnumerable<CRMspChartDailyOrdersExtraInfo_Result>)list).TotalCount.GetValueOrDefault() : 0);
				var data = Enumerable.Select((IEnumerable<CRMspChartDailyOrdersExtraInfo_Result>)list, (CRMspChartDailyOrdersExtraInfo_Result c) => new
				{
					OrderId = c.OrderId,
					OrderNumber = c.OrderNumber,
					OrderDate = c.OrderDateStr,
					OrderTotalAmount = c.OrderTotalAmount,
					OprType = c.OprType,
					FilteredProductAmount = c.FilteredProductAmount,
					FilteredProductCount = c.FilteredProductCount,
					XLabelText = c.XLabelText
				});
				return Json(new { data, totalCount }, JsonRequestBehavior.AllowGet);
			}
			List<DateTime> firstDayOfMonths = DateTimeClass.GetFirstDayOfMonths(dateTime, dateTime2, lCID);
			string firstDayOfMonths2 = string.Join(",", Enumerable.Select<DateTime, string>((IEnumerable<DateTime>)firstDayOfMonths, (Func<DateTime, string>)((DateTime d) => d.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))));
			CRMSpIIIEntities dbIII2 = _dbIII;
			groupFieldValues2 = selectedValues;
			List<CRMspChartMonthlyOrdersInfo_Result> list2 = Enumerable.ToList<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)dbIII2.CRMspChartMonthlyOrdersInfo(fDate: dateTime, tDate: dateTime2, selectedValue: groupFieldValues2, userId: userId, currUserId: UserLogin.CurrentUser.UserId, centerId: result2, languageID: lCID, defaultLanguageID: result, pageNumber: pageNumber, pageSize: pageSize, firstDayOfMonths: firstDayOfMonths2, groupFieldKey: groupFieldKey, groupFieldValues: groupFieldValues));
			CultureInfo cultureInfo = new CultureInfo(lCID);
			Calendar calendar = cultureInfo.Calendar;
			string[] monthNames = cultureInfo.DateTimeFormat.MonthNames;
			foreach (CRMspChartMonthlyOrdersInfo_Result item2 in list2)
			{
				item2.OrderDateStr = (item2.OrderDate.HasValue ? DateTimeClass.GetLocalDate(item2.OrderDate).Value.ToString("yyyy/MM/dd") : "");
				if (!string.IsNullOrEmpty(item2.DateValue))
				{
					DateTime time = DateTime.ParseExact(item2.DateValue, "yyyy-MM-dd", CultureInfo.InvariantCulture);
					int month = calendar.GetMonth(time);
					int year = calendar.GetYear(time);
					item2.DateText = $"{monthNames[month - 1]} {year}";
				}
			}
			int totalCount2 = ((Enumerable.Count<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list2) > 0) ? Enumerable.FirstOrDefault<CRMspChartMonthlyOrdersInfo_Result>((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list2).TotalCount.GetValueOrDefault() : 0);
			var data2 = Enumerable.Select((IEnumerable<CRMspChartMonthlyOrdersInfo_Result>)list2, (CRMspChartMonthlyOrdersInfo_Result c) => new
			{
				OrderId = c.OrderId,
				OrderNumber = c.OrderNumber,
				OrderDate = c.OrderDateStr,
				OrderTotalAmount = c.OrderTotalAmount,
				OprType = c.OprType,
				XLabelText = c.DateText
			});
			return Json(new
			{
				data = data2,
				totalCount = totalCount2
			}, JsonRequestBehavior.AllowGet);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Json(new
			{
				data = new object[0],
				totalCount = 0
			}, JsonRequestBehavior.AllowGet);
		}
	}

	[AjaxOnly]
	public ActionResult _PartialChartDashboard()
	{
		SelectCmpCountWithRegInWsOrder("", canLoad: false);
		SelectCmpCountWithCountry(canLoad: false);
		SelectCmpCountWithProvince(canLoad: false);
		SelectCmpCountWithCity(canLoad: false);
		SelectCmpCountWithPresentation(canLoad: false);
		SelectCmpCountWithType(canLoad: false);
		SelectCmpCountWithMultiGroups(canLoad: false);
		SelectCmpCountWithTitle(canLoad: false);
		SelectCmpCountWithGroupI(canLoad: false);
		SelectCmpCountWithGroupII(canLoad: false);
		SelectCmpCountWithGroupIII(canLoad: false);
		SelectCmpCountWithGroupIV(canLoad: false);
		SelectCmpPrsCountWithJob(canLoad: false);
		SelectPrsCountWithDepartemant(canLoad: false);
		SelectCmpPrsCountWithSexAndMarriage(canLoad: false);
		SelectCmpPrsCountWithEducation(canLoad: false);
		SelectCmpPrsCountWithType(canLoad: false);
		SelectCmpPrsCountWithTitle(canLoad: false);
		SelectCmpPrsCountWithBirthday(canLoad: false);
		SelectCmpPrjCountWithTitle(canLoad: false);
		SelectCmpPrjCountWithCnvsStatusGroup(canLoad: false);
		SelectCmpPrjCountWithGroup(canLoad: false);
		SelectCmpPrjCountWithGrade(canLoad: false);
		SelectCmpPrjCountWithPriority(canLoad: false);
		SelectCnvsCountWithTopic(canLoad: false);
		SelectCnvsCountWithStatusAndGroup(canLoad: false);
		ChrtLst.ChrtWidth = ChrtWidth;
		return PartialView(ChrtLst);
	}

	public List<CrmReportCmpCountRegInWsOrderViewModel> SelectCmpCountWithRegInWsOrder(string dt = "", bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithRegInWsOrder = new List<CrmReportCmpCountRegInWsOrderViewModel>();
		ChrtWidth.ChrtCmpCountWithRegInWsOrderWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
				if (result <= 0)
				{
					result = 1065;
				}
				_ = Thread.CurrentThread.CurrentCulture.LCID;
				DateTime now = DateTime.Now;
				List<CRMspChartCompanyCountRegInWsOrder_Result> list = Enumerable.ToList<CRMspChartCompanyCountRegInWsOrder_Result>((IEnumerable<CRMspChartCompanyCountRegInWsOrder_Result>)_db.CRMspChartCompanyCountRegInWsOrder(now));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithRegInWsOrderWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountRegInWsOrder_Result item in list)
					{
						CrmReportCmpCountRegInWsOrderViewModel crmReportCmpCountRegInWsOrderViewModel = new CrmReportCmpCountRegInWsOrderViewModel();
						crmReportCmpCountRegInWsOrderViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountRegInWsOrderViewModel.RegInWsOrder = item.CmpInWsOrderCount.GetValueOrDefault();
						if (item.Ord == 100)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.ToDay;
						}
						else if (item.Ord == 90)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.Yesterday;
						}
						else if (item.Ord == 80)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.CurrMonth;
						}
						else if (item.Ord == 70)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.PriorMonth;
						}
						else if (item.Ord == 60)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.CurrYear;
						}
						else if (item.Ord == 50)
						{
							crmReportCmpCountRegInWsOrderViewModel.Ord = Labels.PriorYear;
						}
						ChrtLst.ChrtCmpCountWithRegInWsOrder.Add(crmReportCmpCountRegInWsOrderViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithRegInWsOrder;
	}

	[AjaxOnly]
	public JsonResult jsSelectCmpCountWithRegInWsOrder(string dt = "")
	{
		JsonResult jsonResult = Json(SelectCmpCountWithRegInWsOrder(dt), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCountryViewModel> SelectCmpCountWithCountry(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithCountry = new List<CrmReportCmpCountWithCountryViewModel>();
		ChrtWidth.ChrtCmpCountWithCountryWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCountry_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCountry_Result>((IEnumerable<CRMspChartCompanyCountWithCountry_Result>)_db.CRMspChartCompanyCountWithCountry(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithCountryWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCountry_Result item in list)
					{
						CrmReportCmpCountWithCountryViewModel crmReportCmpCountWithCountryViewModel = new CrmReportCmpCountWithCountryViewModel();
						crmReportCmpCountWithCountryViewModel.Id = item.Id.GetValueOrDefault();
						crmReportCmpCountWithCountryViewModel.Name = item.Name;
						crmReportCmpCountWithCountryViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCountryViewModel.RegInWsOrder = item.WsOrderCount.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithCountry.Add(crmReportCmpCountWithCountryViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithCountry;
	}

	public JsonResult jsSelectCmpCountWithCountry()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithCountry(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithProvinceViewModel> SelectCmpCountWithProvince(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithProvince = new List<CrmReportCmpCountWithProvinceViewModel>();
		ChrtWidth.ChrtCmpCountWithProvinceWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithProvince_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithProvince_Result>((IEnumerable<CRMspChartCompanyCountWithProvince_Result>)_db.CRMspChartCompanyCountWithProvince(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithProvinceWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithProvince_Result item in list)
					{
						CrmReportCmpCountWithProvinceViewModel crmReportCmpCountWithProvinceViewModel = new CrmReportCmpCountWithProvinceViewModel();
						crmReportCmpCountWithProvinceViewModel.Id = item.Id.GetValueOrDefault();
						crmReportCmpCountWithProvinceViewModel.Name = item.Name;
						crmReportCmpCountWithProvinceViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithProvinceViewModel.RegInWsOrder = item.WsOrderCount.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithProvince.Add(crmReportCmpCountWithProvinceViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithProvince;
	}

	[AjaxOnly]
	public JsonResult jsSelectCmpCountWithProvince()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithProvince(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCityViewModel> SelectCmpCountWithCity(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithCity = new List<CrmReportCmpCountWithCityViewModel>();
		ChrtWidth.ChrtCmpCountWithCityWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCity_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCity_Result>((IEnumerable<CRMspChartCompanyCountWithCity_Result>)_db.CRMspChartCompanyCountWithCity(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithCityWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCity_Result item in list)
					{
						CrmReportCmpCountWithCityViewModel crmReportCmpCountWithCityViewModel = new CrmReportCmpCountWithCityViewModel();
						crmReportCmpCountWithCityViewModel.Id = item.Id.GetValueOrDefault();
						crmReportCmpCountWithCityViewModel.Name = item.Name;
						crmReportCmpCountWithCityViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCityViewModel.RegInWsOrder = item.WsOrderCount.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithCity.Add(crmReportCmpCountWithCityViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithCity;
	}

	[AjaxOnly]
	public JsonResult jsSelectCmpCountWithCity()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithCity(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithPresentationViewModel> SelectCmpCountWithPresentation(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithPresentation = new List<CrmReportCmpCountWithPresentationViewModel>();
		ChrtWidth.ChrtCmpCountWithPresentationWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithPresentation_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithPresentation_Result>((IEnumerable<CRMspChartCompanyCountWithPresentation_Result>)_db.CRMspChartCompanyCountWithPresentation(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithPresentationWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithPresentation_Result item in list)
					{
						CrmReportCmpCountWithPresentationViewModel crmReportCmpCountWithPresentationViewModel = new CrmReportCmpCountWithPresentationViewModel();
						crmReportCmpCountWithPresentationViewModel.Id = item.cmpPresentationId.GetValueOrDefault();
						crmReportCmpCountWithPresentationViewModel.Title = item.PresentationTitle;
						crmReportCmpCountWithPresentationViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithPresentationViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithPresentation.Add(crmReportCmpCountWithPresentationViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithPresentation;
	}

	[AjaxOnly]
	public JsonResult jsSelectCmpCountWithPresentation()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithPresentation(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpTypeViewModel> SelectCmpCountWithType(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithType = new List<CrmReportCmpCountWithCmpTypeViewModel>();
		ChrtWidth.ChrtCmpCountWithTypeWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpType_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpType_Result>((IEnumerable<CRMspChartCompanyCountWithCmpType_Result>)_db.CRMspChartCompanyCountWithCmpType(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithTypeWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpType_Result item in list)
					{
						CrmReportCmpCountWithCmpTypeViewModel crmReportCmpCountWithCmpTypeViewModel = new CrmReportCmpCountWithCmpTypeViewModel();
						crmReportCmpCountWithCmpTypeViewModel.Id = item.cmpTypeId.GetValueOrDefault();
						crmReportCmpCountWithCmpTypeViewModel.Title = item.CmpType;
						crmReportCmpCountWithCmpTypeViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpTypeViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithType.Add(crmReportCmpCountWithCmpTypeViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithType;
	}

	public JsonResult jsSelectCmpCountWithType()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithType(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithMultiGroupsViewModel> SelectCmpCountWithMultiGroups(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithMultiGroups = new List<CrmReportCmpCountWithMultiGroupsViewModel>();
		ChrtWidth.ChrtCmpCountWithMultiGroupsWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpMultiGroups_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpMultiGroups_Result>((IEnumerable<CRMspChartCompanyCountWithCmpMultiGroups_Result>)_db.CRMspChartCompanyCountWithCmpMultiGroups(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithMultiGroupsWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpMultiGroups_Result item in list)
					{
						CrmReportCmpCountWithMultiGroupsViewModel crmReportCmpCountWithMultiGroupsViewModel = new CrmReportCmpCountWithMultiGroupsViewModel();
						crmReportCmpCountWithMultiGroupsViewModel.Id = item.CompanyGroupsMultiID;
						crmReportCmpCountWithMultiGroupsViewModel.Title = item.CompanyMultiGroupsTitle;
						crmReportCmpCountWithMultiGroupsViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithMultiGroupsViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithMultiGroups.Add(crmReportCmpCountWithMultiGroupsViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithMultiGroups;
	}

	public JsonResult jsSelectCmpCountWithMultiGroups()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithMultiGroups(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpTitleViewModel> SelectCmpCountWithTitle(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithTitle = new List<CrmReportCmpCountWithCmpTitleViewModel>();
		ChrtWidth.ChrtCmpCountWithTitleWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpTitle_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpTitle_Result>((IEnumerable<CRMspChartCompanyCountWithCmpTitle_Result>)_db.CRMspChartCompanyCountWithCmpTitle(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithTitleWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpTitle_Result item in list)
					{
						CrmReportCmpCountWithCmpTitleViewModel crmReportCmpCountWithCmpTitleViewModel = new CrmReportCmpCountWithCmpTitleViewModel();
						crmReportCmpCountWithCmpTitleViewModel.Id = item.cmpTitleId.GetValueOrDefault();
						crmReportCmpCountWithCmpTitleViewModel.Title = item.Title;
						crmReportCmpCountWithCmpTitleViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpTitleViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithTitle.Add(crmReportCmpCountWithCmpTitleViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithTitle;
	}

	public JsonResult jsSelectCmpCountWithTitle()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithTitle(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpGroupIViewModel> SelectCmpCountWithGroupI(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithGroupI = new List<CrmReportCmpCountWithCmpGroupIViewModel>();
		ChrtWidth.ChrtCmpCountWithGroupIWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpGroupI_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpGroupI_Result>((IEnumerable<CRMspChartCompanyCountWithCmpGroupI_Result>)_db.CRMspChartCompanyCountWithCmpGroupI(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithGroupIWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpGroupI_Result item in list)
					{
						CrmReportCmpCountWithCmpGroupIViewModel crmReportCmpCountWithCmpGroupIViewModel = new CrmReportCmpCountWithCmpGroupIViewModel();
						crmReportCmpCountWithCmpGroupIViewModel.Id = item.cmpGroupId.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIViewModel.Title = item.CmpGroup;
						crmReportCmpCountWithCmpGroupIViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithGroupI.Add(crmReportCmpCountWithCmpGroupIViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithGroupI;
	}

	public JsonResult jsSelectCmpCountWithGroupI()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithGroupI(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpGroupIIViewModel> SelectCmpCountWithGroupII(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithGroupII = new List<CrmReportCmpCountWithCmpGroupIIViewModel>();
		ChrtWidth.ChrtCmpCountWithGroupIIWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpGroupII_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpGroupII_Result>((IEnumerable<CRMspChartCompanyCountWithCmpGroupII_Result>)_db.CRMspChartCompanyCountWithCmpGroupII(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithGroupIIWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpGroupII_Result item in list)
					{
						CrmReportCmpCountWithCmpGroupIIViewModel crmReportCmpCountWithCmpGroupIIViewModel = new CrmReportCmpCountWithCmpGroupIIViewModel();
						crmReportCmpCountWithCmpGroupIIViewModel.Id = item.cmpGroupIdII.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIIViewModel.Title = item.CmpGroup.Replace("\n", " ") ?? "";
						crmReportCmpCountWithCmpGroupIIViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIIViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithGroupII.Add(crmReportCmpCountWithCmpGroupIIViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithGroupII;
	}

	public JsonResult jsSelectCmpCountWithGroupII()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithGroupII(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpGroupIIIViewModel> SelectCmpCountWithGroupIII(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithGroupIII = new List<CrmReportCmpCountWithCmpGroupIIIViewModel>();
		ChrtWidth.ChrtCmpCountWithGroupIIIWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpGroupIII_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpGroupIII_Result>((IEnumerable<CRMspChartCompanyCountWithCmpGroupIII_Result>)_db.CRMspChartCompanyCountWithCmpGroupIII(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithGroupIIIWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpGroupIII_Result item in list)
					{
						CrmReportCmpCountWithCmpGroupIIIViewModel crmReportCmpCountWithCmpGroupIIIViewModel = new CrmReportCmpCountWithCmpGroupIIIViewModel();
						crmReportCmpCountWithCmpGroupIIIViewModel.Id = item.cmpGroupIdIII.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIIIViewModel.Title = item.CmpGroup;
						crmReportCmpCountWithCmpGroupIIIViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIIIViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithGroupIII.Add(crmReportCmpCountWithCmpGroupIIIViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithGroupIII;
	}

	public JsonResult jsSelectCmpCountWithGroupIII()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithGroupIII(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpCountWithCmpGroupIVViewModel> SelectCmpCountWithGroupIV(bool canLoad = true)
	{
		ChrtLst.ChrtCmpCountWithGroupIV = new List<CrmReportCmpCountWithCmpGroupIVViewModel>();
		ChrtWidth.ChrtCmpCountWithGroupIVWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyCountWithCmpGroupIV_Result> list = Enumerable.ToList<CRMspChartCompanyCountWithCmpGroupIV_Result>((IEnumerable<CRMspChartCompanyCountWithCmpGroupIV_Result>)_db.CRMspChartCompanyCountWithCmpGroupIV(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpCountWithGroupIVWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyCountWithCmpGroupIV_Result item in list)
					{
						CrmReportCmpCountWithCmpGroupIVViewModel crmReportCmpCountWithCmpGroupIVViewModel = new CrmReportCmpCountWithCmpGroupIVViewModel();
						crmReportCmpCountWithCmpGroupIVViewModel.Id = item.cmpGroupIdIV.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIVViewModel.Title = item.CmpGroup;
						crmReportCmpCountWithCmpGroupIVViewModel.Count = item.CmpCount.GetValueOrDefault();
						crmReportCmpCountWithCmpGroupIVViewModel.RegInWsOrder = item.CmpRegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpCountWithGroupIV.Add(crmReportCmpCountWithCmpGroupIVViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpCountWithGroupIV;
	}

	public JsonResult jsSelectCmpCountWithGroupIV()
	{
		JsonResult jsonResult = Json(SelectCmpCountWithGroupIV(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithJobViewModel> SelectCmpPrsCountWithJob(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithJob = new List<CrmReportCmpPrsCountWithJobViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithJobWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountJob_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountJob_Result>((IEnumerable<CRMspChartCompanyPersonCountJob_Result>)_db.CRMspChartCompanyPersonCountJob(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithJobWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountJob_Result item in list)
					{
						CrmReportCmpPrsCountWithJobViewModel crmReportCmpPrsCountWithJobViewModel = new CrmReportCmpPrsCountWithJobViewModel();
						crmReportCmpPrsCountWithJobViewModel.Id = item.prsJobId.GetValueOrDefault();
						crmReportCmpPrsCountWithJobViewModel.Title = item.Title;
						crmReportCmpPrsCountWithJobViewModel.Count = item.PrsCount.GetValueOrDefault();
						crmReportCmpPrsCountWithJobViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrsCountWithJob.Add(crmReportCmpPrsCountWithJobViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithJob;
	}

	public JsonResult jsSelectCmpPrsCountWithJob()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithJob(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithDepartemantViewModel> SelectPrsCountWithDepartemant(bool canLoad = true)
	{
		ChrtLst.ChrtPrsCountWithDepartemant = new List<CrmReportCmpPrsCountWithDepartemantViewModel>();
		ChrtWidth.ChrtPrsCountWithDepartemantWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountDepartemant_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountDepartemant_Result>((IEnumerable<CRMspChartCompanyPersonCountDepartemant_Result>)_db.CRMspChartCompanyPersonCountDepartemant(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtPrsCountWithDepartemantWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountDepartemant_Result item in list)
					{
						CrmReportCmpPrsCountWithDepartemantViewModel crmReportCmpPrsCountWithDepartemantViewModel = new CrmReportCmpPrsCountWithDepartemantViewModel();
						crmReportCmpPrsCountWithDepartemantViewModel.Id = item.prsDepartmentId.GetValueOrDefault();
						crmReportCmpPrsCountWithDepartemantViewModel.Title = item.CmpPersonTitle;
						crmReportCmpPrsCountWithDepartemantViewModel.Count = item.CmpPersonCount.GetValueOrDefault();
						crmReportCmpPrsCountWithDepartemantViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtPrsCountWithDepartemant.Add(crmReportCmpPrsCountWithDepartemantViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtPrsCountWithDepartemant;
	}

	public JsonResult jsSelectPrsCountWithDepartemant()
	{
		JsonResult jsonResult = Json(SelectPrsCountWithDepartemant(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountSexWithMarriageViewModel> SelectCmpPrsCountWithSexAndMarriage(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithSexAndMarriage = new List<CrmReportCmpPrsCountSexWithMarriageViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithSexAndMarriageWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountSexWithMarriage_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountSexWithMarriage_Result>((IEnumerable<CRMspChartCompanyPersonCountSexWithMarriage_Result>)_db.CRMspChartCompanyPersonCountSexWithMarriage(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithSexAndMarriageWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountSexWithMarriage_Result item in list)
					{
						CrmReportCmpPrsCountSexWithMarriageViewModel crmReportCmpPrsCountSexWithMarriageViewModel = new CrmReportCmpPrsCountSexWithMarriageViewModel();
						crmReportCmpPrsCountSexWithMarriageViewModel.Sex = item.Sex.GetValueOrDefault();
						crmReportCmpPrsCountSexWithMarriageViewModel.Marriage = item.Married.GetValueOrDefault();
						crmReportCmpPrsCountSexWithMarriageViewModel.Ord = item.ord;
						ChrtLst.ChrtCmpPrsCountWithSexAndMarriage.Add(crmReportCmpPrsCountSexWithMarriageViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithSexAndMarriage;
	}

	public JsonResult jsSelectCmpPrsCountWithSexAndMarriage()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithSexAndMarriage(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithEducationViewModel> SelectCmpPrsCountWithEducation(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithEducation = new List<CrmReportCmpPrsCountWithEducationViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithEducationWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountEducation_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountEducation_Result>((IEnumerable<CRMspChartCompanyPersonCountEducation_Result>)_db.CRMspChartCompanyPersonCountEducation(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithEducationWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountEducation_Result item in list)
					{
						CrmReportCmpPrsCountWithEducationViewModel crmReportCmpPrsCountWithEducationViewModel = new CrmReportCmpPrsCountWithEducationViewModel();
						crmReportCmpPrsCountWithEducationViewModel.Id = item.prsEducationId.GetValueOrDefault();
						crmReportCmpPrsCountWithEducationViewModel.Title = item.Title;
						crmReportCmpPrsCountWithEducationViewModel.Count = item.PrsCount.GetValueOrDefault();
						crmReportCmpPrsCountWithEducationViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrsCountWithEducation.Add(crmReportCmpPrsCountWithEducationViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithEducation;
	}

	public JsonResult jsSelectCmpPrsCountWithEducation()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithEducation(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithTypeViewModel> SelectCmpPrsCountWithType(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithType = new List<CrmReportCmpPrsCountWithTypeViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithTypeWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountType_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountType_Result>((IEnumerable<CRMspChartCompanyPersonCountType_Result>)_db.CRMspChartCompanyPersonCountType(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithTypeWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountType_Result item in list)
					{
						CrmReportCmpPrsCountWithTypeViewModel crmReportCmpPrsCountWithTypeViewModel = new CrmReportCmpPrsCountWithTypeViewModel();
						crmReportCmpPrsCountWithTypeViewModel.Id = item.prsTypeId.GetValueOrDefault();
						crmReportCmpPrsCountWithTypeViewModel.Title = item.Title;
						crmReportCmpPrsCountWithTypeViewModel.Count = item.PrsCount.GetValueOrDefault();
						crmReportCmpPrsCountWithTypeViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrsCountWithType.Add(crmReportCmpPrsCountWithTypeViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithType;
	}

	public JsonResult jsSelectCmpPrsCountWithType()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithType(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithTitleViewModel> SelectCmpPrsCountWithTitle(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithTitle = new List<CrmReportCmpPrsCountWithTitleViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithTitleWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyPersonCountTitle_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountTitle_Result>((IEnumerable<CRMspChartCompanyPersonCountTitle_Result>)_db.CRMspChartCompanyPersonCountTitle(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithTitleWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountTitle_Result item in list)
					{
						CrmReportCmpPrsCountWithTitleViewModel crmReportCmpPrsCountWithTitleViewModel = new CrmReportCmpPrsCountWithTitleViewModel();
						crmReportCmpPrsCountWithTitleViewModel.Id = item.prsTitleId.GetValueOrDefault();
						crmReportCmpPrsCountWithTitleViewModel.Title = item.Title;
						crmReportCmpPrsCountWithTitleViewModel.Count = item.PrsCount.GetValueOrDefault();
						crmReportCmpPrsCountWithTitleViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrsCountWithTitle.Add(crmReportCmpPrsCountWithTitleViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithTitle;
	}

	public JsonResult jsSelectCmpPrsCountWithTitle()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithTitle(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrsCountWithBirthdayViewModel> SelectCmpPrsCountWithBirthday(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrsCountWithBirthday = new List<CrmReportCmpPrsCountWithBirthdayViewModel>();
		ChrtWidth.ChrtCmpPrsCountWithBirthdayWidth = ChartDefaultWidth;
		try
		{
			if (canLoad)
			{
				DateTime now = DateTime.Now;
				List<CRMspChartCompanyPersonCountBirthday_Result> list = Enumerable.ToList<CRMspChartCompanyPersonCountBirthday_Result>((IEnumerable<CRMspChartCompanyPersonCountBirthday_Result>)_db.CRMspChartCompanyPersonCountBirthday(now));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrsCountWithBirthdayWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyPersonCountBirthday_Result item in list)
					{
						CrmReportCmpPrsCountWithBirthdayViewModel crmReportCmpPrsCountWithBirthdayViewModel = new CrmReportCmpPrsCountWithBirthdayViewModel();
						crmReportCmpPrsCountWithBirthdayViewModel.BithMonth = item.BithMonth.GetValueOrDefault();
						crmReportCmpPrsCountWithBirthdayViewModel.Ord = item.ord;
						ChrtLst.ChrtCmpPrsCountWithBirthday.Add(crmReportCmpPrsCountWithBirthdayViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrsCountWithBirthday;
	}

	public JsonResult jsSelectCmpPrsCountWithBirthday()
	{
		JsonResult jsonResult = Json(SelectCmpPrsCountWithBirthday(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpPrjCountWithTitleViewModel> SelectCmpPrjCountWithTitle(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrjCountWithTitle = new List<CrmReportCmpPrjCountWithTitleViewModel>();
		ChrtWidth.ChrtCmpPrjCountWithTitleWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyProjectCountWithTitle_Result> list = Enumerable.ToList<CRMspChartCompanyProjectCountWithTitle_Result>((IEnumerable<CRMspChartCompanyProjectCountWithTitle_Result>)_db.CRMspChartCompanyProjectCountWithTitle(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrjCountWithTitleWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyProjectCountWithTitle_Result item in list)
					{
						CrmReportCmpPrjCountWithTitleViewModel crmReportCmpPrjCountWithTitleViewModel = new CrmReportCmpPrjCountWithTitleViewModel();
						crmReportCmpPrjCountWithTitleViewModel.Title = item.prjTitle;
						crmReportCmpPrjCountWithTitleViewModel.Count = item.CmpProjectCount.GetValueOrDefault();
						crmReportCmpPrjCountWithTitleViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrjCountWithTitle.Add(crmReportCmpPrjCountWithTitleViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrjCountWithTitle;
	}

	public JsonResult jsSelectCmpPrjCountWithTitle()
	{
		JsonResult jsonResult = Json(SelectCmpPrjCountWithTitle(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpProjectCountWithCnvsStatusGroupViewModel> SelectCmpPrjCountWithCnvsStatusGroup(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrjCountWithCnvsStatusGroup = new List<CrmReportCmpProjectCountWithCnvsStatusGroupViewModel>();
		ChrtWidth.ChrtCmpPrjCountWithCnvsStatusGroupWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyProjectCountWithPrjCnvsStatusGroup_Result> list = Enumerable.ToList<CRMspChartCompanyProjectCountWithPrjCnvsStatusGroup_Result>((IEnumerable<CRMspChartCompanyProjectCountWithPrjCnvsStatusGroup_Result>)_db.CRMspChartCompanyProjectCountWithPrjCnvsStatusGroup(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrjCountWithCnvsStatusGroupWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyProjectCountWithPrjCnvsStatusGroup_Result item in list)
					{
						CrmReportCmpProjectCountWithCnvsStatusGroupViewModel crmReportCmpProjectCountWithCnvsStatusGroupViewModel = new CrmReportCmpProjectCountWithCnvsStatusGroupViewModel();
						crmReportCmpProjectCountWithCnvsStatusGroupViewModel.Id = item.prjcnvsStatusGroupId.GetValueOrDefault();
						crmReportCmpProjectCountWithCnvsStatusGroupViewModel.Title = item.ConversationStatusGroup;
						crmReportCmpProjectCountWithCnvsStatusGroupViewModel.Count = item.CmpProjectCount.GetValueOrDefault();
						crmReportCmpProjectCountWithCnvsStatusGroupViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrjCountWithCnvsStatusGroup.Add(crmReportCmpProjectCountWithCnvsStatusGroupViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrjCountWithCnvsStatusGroup;
	}

	public JsonResult jsSelectCmpPrjCountWithCnvsStatusGroup()
	{
		JsonResult jsonResult = Json(SelectCmpPrjCountWithCnvsStatusGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpProjectCountWithGroupViewModel> SelectCmpPrjCountWithGroup(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrjCountWithGroup = new List<CrmReportCmpProjectCountWithGroupViewModel>();
		ChrtWidth.ChrtCmpPrjCountWithGroupWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyProjectCountWithGroup_Result> list = Enumerable.ToList<CRMspChartCompanyProjectCountWithGroup_Result>((IEnumerable<CRMspChartCompanyProjectCountWithGroup_Result>)_db.CRMspChartCompanyProjectCountWithGroup(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrjCountWithGroupWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyProjectCountWithGroup_Result item in list)
					{
						CrmReportCmpProjectCountWithGroupViewModel crmReportCmpProjectCountWithGroupViewModel = new CrmReportCmpProjectCountWithGroupViewModel();
						crmReportCmpProjectCountWithGroupViewModel.Id = item.prjGroupId.GetValueOrDefault();
						crmReportCmpProjectCountWithGroupViewModel.Title = item.PrjGroupTitle;
						crmReportCmpProjectCountWithGroupViewModel.Count = item.CmpProjectCount.GetValueOrDefault();
						crmReportCmpProjectCountWithGroupViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrjCountWithGroup.Add(crmReportCmpProjectCountWithGroupViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrjCountWithGroup;
	}

	public JsonResult jsSelectCmpPrjCountWithGroup()
	{
		JsonResult jsonResult = Json(SelectCmpPrjCountWithGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpProjectCountWithGradeViewModel> SelectCmpPrjCountWithGrade(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrjCountWithGrade = new List<CrmReportCmpProjectCountWithGradeViewModel>();
		ChrtWidth.ChrtCmpPrjCountWithGradeWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyProjectCountWithGrade_Result> list = Enumerable.ToList<CRMspChartCompanyProjectCountWithGrade_Result>((IEnumerable<CRMspChartCompanyProjectCountWithGrade_Result>)_db.CRMspChartCompanyProjectCountWithGrade(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrjCountWithGradeWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyProjectCountWithGrade_Result item in list)
					{
						CrmReportCmpProjectCountWithGradeViewModel crmReportCmpProjectCountWithGradeViewModel = new CrmReportCmpProjectCountWithGradeViewModel();
						crmReportCmpProjectCountWithGradeViewModel.Id = item.prjGradeId.GetValueOrDefault();
						crmReportCmpProjectCountWithGradeViewModel.Title = item.PrjGradeTitle;
						crmReportCmpProjectCountWithGradeViewModel.Count = item.CmpProjectCount.GetValueOrDefault();
						crmReportCmpProjectCountWithGradeViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrjCountWithGrade.Add(crmReportCmpProjectCountWithGradeViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrjCountWithGrade;
	}

	public JsonResult jsSelectCmpPrjCountWithGrade()
	{
		JsonResult jsonResult = Json(SelectCmpPrjCountWithGrade(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpProjectCountWithPriorityViewModel> SelectCmpPrjCountWithPriority(bool canLoad = true)
	{
		ChrtLst.ChrtCmpPrjCountWithPriority = new List<CrmReportCmpProjectCountWithPriorityViewModel>();
		ChrtWidth.ChrtCmpPrjCountWithPriorityWidth = ChartDefaultWidth;
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
				List<CRMspChartCompanyProjectCountWithPriority_Result> list = Enumerable.ToList<CRMspChartCompanyProjectCountWithPriority_Result>((IEnumerable<CRMspChartCompanyProjectCountWithPriority_Result>)_db.CRMspChartCompanyProjectCountWithPriority(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCmpPrjCountWithPriorityWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartCompanyProjectCountWithPriority_Result item in list)
					{
						CrmReportCmpProjectCountWithPriorityViewModel crmReportCmpProjectCountWithPriorityViewModel = new CrmReportCmpProjectCountWithPriorityViewModel();
						crmReportCmpProjectCountWithPriorityViewModel.Id = item.prjPriorityId.GetValueOrDefault();
						crmReportCmpProjectCountWithPriorityViewModel.Title = item.PrjPriorityTitle;
						crmReportCmpProjectCountWithPriorityViewModel.Count = item.CmpProjectCount.GetValueOrDefault();
						crmReportCmpProjectCountWithPriorityViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCmpPrjCountWithPriority.Add(crmReportCmpProjectCountWithPriorityViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCmpPrjCountWithPriority;
	}

	public JsonResult jsSelectCmpPrjCountWithPriority()
	{
		JsonResult jsonResult = Json(SelectCmpPrjCountWithPriority(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpConversationCountWithTopicViewModel> SelectCnvsCountWithTopic(bool canLoad = true)
	{
		ChrtLst.ChrtCnvsCountWithTopic = new List<CrmReportCmpConversationCountWithTopicViewModel>();
		ChrtWidth.ChrtCnvsCountWithTopicWidth = ChartDefaultWidth;
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
				List<CRMspChartConversationCountWithTopic_Result> list = Enumerable.ToList<CRMspChartConversationCountWithTopic_Result>((IEnumerable<CRMspChartConversationCountWithTopic_Result>)_db.CRMspChartConversationCountWithTopic(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCnvsCountWithTopicWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartConversationCountWithTopic_Result item in list)
					{
						CrmReportCmpConversationCountWithTopicViewModel crmReportCmpConversationCountWithTopicViewModel = new CrmReportCmpConversationCountWithTopicViewModel();
						crmReportCmpConversationCountWithTopicViewModel.Id = item.cnvsTopicId.GetValueOrDefault();
						crmReportCmpConversationCountWithTopicViewModel.Title = item.Topic;
						crmReportCmpConversationCountWithTopicViewModel.Count = item.CnvsCount.GetValueOrDefault();
						crmReportCmpConversationCountWithTopicViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						ChrtLst.ChrtCnvsCountWithTopic.Add(crmReportCmpConversationCountWithTopicViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCnvsCountWithTopic;
	}

	public JsonResult jsSelectCnvsCountWithTopic()
	{
		JsonResult jsonResult = Json(SelectCnvsCountWithTopic(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CrmReportCmpConversationCountWithStatusAndGroupViewModel> SelectCnvsCountWithStatusAndGroup(bool canLoad = true)
	{
		ChrtLst.ChrtCnvsCountWithStatusAndGroup = new List<CrmReportCmpConversationCountWithStatusAndGroupViewModel>();
		ChrtWidth.ChrtCnvsCountWithStatusAndGroupWidth = ChartDefaultWidth;
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
				List<CRMspChartConversationCountWithStatusAndGroup_Result> list = Enumerable.ToList<CRMspChartConversationCountWithStatusAndGroup_Result>((IEnumerable<CRMspChartConversationCountWithStatusAndGroup_Result>)_db.CRMspChartConversationCountWithStatusAndGroup(lCID, result));
				if (list != null)
				{
					if (list.Count > 10)
					{
						ChrtWidth.ChrtCnvsCountWithStatusAndGroupWidth = list.Count / CategoriesPerPage * ChartDefaultWidth;
					}
					foreach (CRMspChartConversationCountWithStatusAndGroup_Result item in list)
					{
						CrmReportCmpConversationCountWithStatusAndGroupViewModel crmReportCmpConversationCountWithStatusAndGroupViewModel = new CrmReportCmpConversationCountWithStatusAndGroupViewModel();
						crmReportCmpConversationCountWithStatusAndGroupViewModel.Id = item.cnvsStatusId.GetValueOrDefault();
						crmReportCmpConversationCountWithStatusAndGroupViewModel.Title = item.StatusTitle;
						crmReportCmpConversationCountWithStatusAndGroupViewModel.Count = item.CnvsCount.GetValueOrDefault();
						crmReportCmpConversationCountWithStatusAndGroupViewModel.RegInWsOrder = item.RegInWsOrder.GetValueOrDefault();
						crmReportCmpConversationCountWithStatusAndGroupViewModel.Ord = item.Ord;
						ChrtLst.ChrtCnvsCountWithStatusAndGroup.Add(crmReportCmpConversationCountWithStatusAndGroupViewModel);
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return ChrtLst.ChrtCnvsCountWithStatusAndGroup;
	}

	public JsonResult jsSelectCnvsCountWithStatusAndGroup()
	{
		JsonResult jsonResult = Json(SelectCnvsCountWithStatusAndGroup(), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<SelectListItem> GetHorizontalFields()
	{
		List<SelectListItem> list = new List<SelectListItem>();
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
			list.Add(new SelectListItem
			{
				Text = Labels.Daily,
				Value = "1",
				Selected = true
			});
			list.Add(new SelectListItem
			{
				Text = Labels.Monthly,
				Value = "21",
				Selected = true
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordReferUserId,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpCityId,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpProvinceId,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordProjectId,
				Value = "5",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupId,
				Value = "6",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdII,
				Value = "7",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdIII,
				Value = "8",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdIV,
				Value = "9",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTypeId,
				Value = "10",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpPresentationId,
				Value = "11",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprID,
				Value = "12",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordGroupId,
				Value = "13",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordStatusId,
				Value = "14",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordSettlementTypeId,
				Value = "15",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordDeliveryTermId,
				Value = "16",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordCurrencyUnitId,
				Value = "17",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdFirstGroup,
				Value = "18",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdSecondGroup,
				Value = "19",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.Product,
				Value = "20",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<SelectListItem> GetVerticalModes()
	{
		List<SelectListItem> list = new List<SelectListItem>();
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
			list.Add(new SelectListItem
			{
				Text = Labels.DailyExtraChart_VerticalAxiosOrderAmount,
				Value = "1",
				Selected = true
			});
			list.Add(new SelectListItem
			{
				Text = Labels.DailyExtraChart_VerticalAxiosOrderCount,
				Value = "3",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetHorizontalFieldRecords(int horizontalField = 1)
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
			_ = Labels.None;
			_ = Labels.HaveNot;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = UserLogin.CurrentUser.UserId;
			switch (horizontalField)
			{
			case 2:
			{
				List<CRMspRpt_SelectCmpReferUser_Result> list10 = Enumerable.ToList<CRMspRpt_SelectCmpReferUser_Result>((IEnumerable<CRMspRpt_SelectCmpReferUser_Result>)_dbII.CRMspRpt_SelectCmpReferUser(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpReferUser_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpReferUser_Result>)list10, (Func<CRMspRpt_SelectCmpReferUser_Result, SelectListItem>)((CRMspRpt_SelectCmpReferUser_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 3:
			{
				List<CRMspRpt_SelectCmpCity_Result> list13 = Enumerable.ToList<CRMspRpt_SelectCmpCity_Result>((IEnumerable<CRMspRpt_SelectCmpCity_Result>)_dbII.CRMspRpt_SelectCmpCity(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpCity_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpCity_Result>)list13, (Func<CRMspRpt_SelectCmpCity_Result, SelectListItem>)((CRMspRpt_SelectCmpCity_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 4:
			{
				List<CRMspRpt_SelectCmpProvince_Result> list6 = Enumerable.ToList<CRMspRpt_SelectCmpProvince_Result>((IEnumerable<CRMspRpt_SelectCmpProvince_Result>)_dbII.CRMspRpt_SelectCmpProvince(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpProvince_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpProvince_Result>)list6, (Func<CRMspRpt_SelectCmpProvince_Result, SelectListItem>)((CRMspRpt_SelectCmpProvince_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 5:
			{
				List<CRMspRpt_SelectCmpProject_Result> list3 = Enumerable.ToList<CRMspRpt_SelectCmpProject_Result>((IEnumerable<CRMspRpt_SelectCmpProject_Result>)_dbII.CRMspRpt_SelectCmpProject(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpProject_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpProject_Result>)list3, (Func<CRMspRpt_SelectCmpProject_Result, SelectListItem>)((CRMspRpt_SelectCmpProject_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 6:
			{
				List<CRMspRpt_SelectCmpGroup_Result> list15 = Enumerable.ToList<CRMspRpt_SelectCmpGroup_Result>((IEnumerable<CRMspRpt_SelectCmpGroup_Result>)_dbII.CRMspRpt_SelectCmpGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroup_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroup_Result>)list15, (Func<CRMspRpt_SelectCmpGroup_Result, SelectListItem>)((CRMspRpt_SelectCmpGroup_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 7:
			{
				List<CRMspRpt_SelectCmpGroupII_Result> list12 = Enumerable.ToList<CRMspRpt_SelectCmpGroupII_Result>((IEnumerable<CRMspRpt_SelectCmpGroupII_Result>)_dbII.CRMspRpt_SelectCmpGroupII(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupII_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupII_Result>)list12, (Func<CRMspRpt_SelectCmpGroupII_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupII_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 8:
			{
				List<CRMspRpt_SelectCmpGroupIII_Result> list4 = Enumerable.ToList<CRMspRpt_SelectCmpGroupIII_Result>((IEnumerable<CRMspRpt_SelectCmpGroupIII_Result>)_dbII.CRMspRpt_SelectCmpGroupIII(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupIII_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupIII_Result>)list4, (Func<CRMspRpt_SelectCmpGroupIII_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupIII_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 9:
			{
				List<CRMspRpt_SelectCmpGroupIV_Result> list16 = Enumerable.ToList<CRMspRpt_SelectCmpGroupIV_Result>((IEnumerable<CRMspRpt_SelectCmpGroupIV_Result>)_dbII.CRMspRpt_SelectCmpGroupIV(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupIV_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupIV_Result>)list16, (Func<CRMspRpt_SelectCmpGroupIV_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupIV_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 10:
			{
				List<CRMspRpt_SelectCmpType_Result> list9 = Enumerable.ToList<CRMspRpt_SelectCmpType_Result>((IEnumerable<CRMspRpt_SelectCmpType_Result>)_dbII.CRMspRpt_SelectCmpType(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpType_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpType_Result>)list9, (Func<CRMspRpt_SelectCmpType_Result, SelectListItem>)((CRMspRpt_SelectCmpType_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 11:
			{
				List<CRMspRpt_SelectCmpPresentation_Result> list7 = Enumerable.ToList<CRMspRpt_SelectCmpPresentation_Result>((IEnumerable<CRMspRpt_SelectCmpPresentation_Result>)_dbII.CRMspRpt_SelectCmpPresentation(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpPresentation_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpPresentation_Result>)list7, (Func<CRMspRpt_SelectCmpPresentation_Result, SelectListItem>)((CRMspRpt_SelectCmpPresentation_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 12:
			{
				List<CRMspRpt_SelectOrderOpr_Result> list17 = Enumerable.ToList<CRMspRpt_SelectOrderOpr_Result>((IEnumerable<CRMspRpt_SelectOrderOpr_Result>)_dbII.CRMspRpt_SelectOrderOpr(lCID, result, userId));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderOpr_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderOpr_Result>)list17, (Func<CRMspRpt_SelectOrderOpr_Result, SelectListItem>)((CRMspRpt_SelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 13:
			{
				List<CRMspRpt_SelectOrderGroup_Result> list14 = Enumerable.ToList<CRMspRpt_SelectOrderGroup_Result>((IEnumerable<CRMspRpt_SelectOrderGroup_Result>)_dbII.CRMspRpt_SelectOrderGroup(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderGroup_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderGroup_Result>)list14, (Func<CRMspRpt_SelectOrderGroup_Result, SelectListItem>)((CRMspRpt_SelectOrderGroup_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 14:
			{
				List<CRMspRpt_SelectOrderStatus_Result> list11 = Enumerable.ToList<CRMspRpt_SelectOrderStatus_Result>((IEnumerable<CRMspRpt_SelectOrderStatus_Result>)_dbII.CRMspRpt_SelectOrderStatus(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderStatus_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderStatus_Result>)list11, (Func<CRMspRpt_SelectOrderStatus_Result, SelectListItem>)((CRMspRpt_SelectOrderStatus_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 15:
			{
				List<CRMspRpt_SelectSettlementType_Result> list8 = Enumerable.ToList<CRMspRpt_SelectSettlementType_Result>((IEnumerable<CRMspRpt_SelectSettlementType_Result>)_dbII.CRMspRpt_SelectSettlementType(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectSettlementType_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectSettlementType_Result>)list8, (Func<CRMspRpt_SelectSettlementType_Result, SelectListItem>)((CRMspRpt_SelectSettlementType_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 16:
			{
				List<CRMspRpt_SelectDeliveryTerm_Result> list5 = Enumerable.ToList<CRMspRpt_SelectDeliveryTerm_Result>((IEnumerable<CRMspRpt_SelectDeliveryTerm_Result>)_dbII.CRMspRpt_SelectDeliveryTerm(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectDeliveryTerm_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectDeliveryTerm_Result>)list5, (Func<CRMspRpt_SelectDeliveryTerm_Result, SelectListItem>)((CRMspRpt_SelectDeliveryTerm_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 17:
			{
				List<CRMspRpt_SelectCurrencyUnit_Result> list2 = Enumerable.ToList<CRMspRpt_SelectCurrencyUnit_Result>((IEnumerable<CRMspRpt_SelectCurrencyUnit_Result>)_dbII.CRMspRpt_SelectCurrencyUnit(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCurrencyUnit_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCurrencyUnit_Result>)list2, (Func<CRMspRpt_SelectCurrencyUnit_Result, SelectListItem>)((CRMspRpt_SelectCurrencyUnit_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	public List<SelectListItem> GetGroupFields()
	{
		List<SelectListItem> list = new List<SelectListItem>();
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "0",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordReferUserId,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpCityId,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpProvinceId,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupId,
				Value = "6",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdII,
				Value = "7",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdIII,
				Value = "8",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpGroupIdIV,
				Value = "9",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTypeId,
				Value = "10",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpPresentationId,
				Value = "11",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.OrderOprID,
				Value = "12",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordGroupId,
				Value = "13",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordStatusId,
				Value = "14",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordSettlementTypeId,
				Value = "15",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordDeliveryTermId,
				Value = "16",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.ordCurrencyUnitId,
				Value = "17",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdFirstGroup,
				Value = "18",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.PrdSecondGroup,
				Value = "19",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.Product,
				Value = "20",
				Selected = false
			});
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public string GetGroupFieldRecords(int groupFieldKey = 1)
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
			_ = Labels.None;
			_ = Labels.HaveNot;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int userId = UserLogin.CurrentUser.UserId;
			switch (groupFieldKey)
			{
			case 2:
			{
				List<CRMspRpt_SelectCmpReferUser_Result> list10 = Enumerable.ToList<CRMspRpt_SelectCmpReferUser_Result>((IEnumerable<CRMspRpt_SelectCmpReferUser_Result>)_dbII.CRMspRpt_SelectCmpReferUser(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpReferUser_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpReferUser_Result>)list10, (Func<CRMspRpt_SelectCmpReferUser_Result, SelectListItem>)((CRMspRpt_SelectCmpReferUser_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 3:
			{
				List<CRMspRpt_SelectCmpCity_Result> list13 = Enumerable.ToList<CRMspRpt_SelectCmpCity_Result>((IEnumerable<CRMspRpt_SelectCmpCity_Result>)_dbII.CRMspRpt_SelectCmpCity(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpCity_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpCity_Result>)list13, (Func<CRMspRpt_SelectCmpCity_Result, SelectListItem>)((CRMspRpt_SelectCmpCity_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 4:
			{
				List<CRMspRpt_SelectCmpProvince_Result> list6 = Enumerable.ToList<CRMspRpt_SelectCmpProvince_Result>((IEnumerable<CRMspRpt_SelectCmpProvince_Result>)_dbII.CRMspRpt_SelectCmpProvince(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpProvince_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpProvince_Result>)list6, (Func<CRMspRpt_SelectCmpProvince_Result, SelectListItem>)((CRMspRpt_SelectCmpProvince_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 5:
			{
				List<CRMspRpt_SelectCmpProject_Result> list3 = Enumerable.ToList<CRMspRpt_SelectCmpProject_Result>((IEnumerable<CRMspRpt_SelectCmpProject_Result>)_dbII.CRMspRpt_SelectCmpProject(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpProject_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpProject_Result>)list3, (Func<CRMspRpt_SelectCmpProject_Result, SelectListItem>)((CRMspRpt_SelectCmpProject_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 6:
			{
				List<CRMspRpt_SelectCmpGroup_Result> list15 = Enumerable.ToList<CRMspRpt_SelectCmpGroup_Result>((IEnumerable<CRMspRpt_SelectCmpGroup_Result>)_dbII.CRMspRpt_SelectCmpGroup(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroup_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroup_Result>)list15, (Func<CRMspRpt_SelectCmpGroup_Result, SelectListItem>)((CRMspRpt_SelectCmpGroup_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 7:
			{
				List<CRMspRpt_SelectCmpGroupII_Result> list12 = Enumerable.ToList<CRMspRpt_SelectCmpGroupII_Result>((IEnumerable<CRMspRpt_SelectCmpGroupII_Result>)_dbII.CRMspRpt_SelectCmpGroupII(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupII_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupII_Result>)list12, (Func<CRMspRpt_SelectCmpGroupII_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupII_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 8:
			{
				List<CRMspRpt_SelectCmpGroupIII_Result> list4 = Enumerable.ToList<CRMspRpt_SelectCmpGroupIII_Result>((IEnumerable<CRMspRpt_SelectCmpGroupIII_Result>)_dbII.CRMspRpt_SelectCmpGroupIII(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupIII_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupIII_Result>)list4, (Func<CRMspRpt_SelectCmpGroupIII_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupIII_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 9:
			{
				List<CRMspRpt_SelectCmpGroupIV_Result> list16 = Enumerable.ToList<CRMspRpt_SelectCmpGroupIV_Result>((IEnumerable<CRMspRpt_SelectCmpGroupIV_Result>)_dbII.CRMspRpt_SelectCmpGroupIV(userId, lCID, result, result2));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpGroupIV_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpGroupIV_Result>)list16, (Func<CRMspRpt_SelectCmpGroupIV_Result, SelectListItem>)((CRMspRpt_SelectCmpGroupIV_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 10:
			{
				List<CRMspRpt_SelectCmpType_Result> list9 = Enumerable.ToList<CRMspRpt_SelectCmpType_Result>((IEnumerable<CRMspRpt_SelectCmpType_Result>)_dbII.CRMspRpt_SelectCmpType(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpType_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpType_Result>)list9, (Func<CRMspRpt_SelectCmpType_Result, SelectListItem>)((CRMspRpt_SelectCmpType_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 11:
			{
				List<CRMspRpt_SelectCmpPresentation_Result> list7 = Enumerable.ToList<CRMspRpt_SelectCmpPresentation_Result>((IEnumerable<CRMspRpt_SelectCmpPresentation_Result>)_dbII.CRMspRpt_SelectCmpPresentation(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCmpPresentation_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCmpPresentation_Result>)list7, (Func<CRMspRpt_SelectCmpPresentation_Result, SelectListItem>)((CRMspRpt_SelectCmpPresentation_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 12:
			{
				List<CRMspRpt_SelectOrderOpr_Result> list17 = Enumerable.ToList<CRMspRpt_SelectOrderOpr_Result>((IEnumerable<CRMspRpt_SelectOrderOpr_Result>)_dbII.CRMspRpt_SelectOrderOpr(lCID, result, userId));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderOpr_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderOpr_Result>)list17, (Func<CRMspRpt_SelectOrderOpr_Result, SelectListItem>)((CRMspRpt_SelectOrderOpr_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 13:
			{
				List<CRMspRpt_SelectOrderGroup_Result> list14 = Enumerable.ToList<CRMspRpt_SelectOrderGroup_Result>((IEnumerable<CRMspRpt_SelectOrderGroup_Result>)_dbII.CRMspRpt_SelectOrderGroup(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderGroup_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderGroup_Result>)list14, (Func<CRMspRpt_SelectOrderGroup_Result, SelectListItem>)((CRMspRpt_SelectOrderGroup_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 14:
			{
				List<CRMspRpt_SelectOrderStatus_Result> list11 = Enumerable.ToList<CRMspRpt_SelectOrderStatus_Result>((IEnumerable<CRMspRpt_SelectOrderStatus_Result>)_dbII.CRMspRpt_SelectOrderStatus(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectOrderStatus_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectOrderStatus_Result>)list11, (Func<CRMspRpt_SelectOrderStatus_Result, SelectListItem>)((CRMspRpt_SelectOrderStatus_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 15:
			{
				List<CRMspRpt_SelectSettlementType_Result> list8 = Enumerable.ToList<CRMspRpt_SelectSettlementType_Result>((IEnumerable<CRMspRpt_SelectSettlementType_Result>)_dbII.CRMspRpt_SelectSettlementType(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectSettlementType_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectSettlementType_Result>)list8, (Func<CRMspRpt_SelectSettlementType_Result, SelectListItem>)((CRMspRpt_SelectSettlementType_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 16:
			{
				List<CRMspRpt_SelectDeliveryTerm_Result> list5 = Enumerable.ToList<CRMspRpt_SelectDeliveryTerm_Result>((IEnumerable<CRMspRpt_SelectDeliveryTerm_Result>)_dbII.CRMspRpt_SelectDeliveryTerm(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectDeliveryTerm_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectDeliveryTerm_Result>)list5, (Func<CRMspRpt_SelectDeliveryTerm_Result, SelectListItem>)((CRMspRpt_SelectDeliveryTerm_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			case 17:
			{
				List<CRMspRpt_SelectCurrencyUnit_Result> list2 = Enumerable.ToList<CRMspRpt_SelectCurrencyUnit_Result>((IEnumerable<CRMspRpt_SelectCurrencyUnit_Result>)_dbII.CRMspRpt_SelectCurrencyUnit(lCID, result));
				list.AddRange(Enumerable.Select<CRMspRpt_SelectCurrencyUnit_Result, SelectListItem>((IEnumerable<CRMspRpt_SelectCurrencyUnit_Result>)list2, (Func<CRMspRpt_SelectCurrencyUnit_Result, SelectListItem>)((CRMspRpt_SelectCurrencyUnit_Result item) => new SelectListItem
				{
					Text = item.Text,
					Value = item.Value.ToString(),
					Selected = false
				})));
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return JsonConvert.SerializeObject(list);
	}

	public ActionResult ShowProductTree(int maxLevel, string selectedIds)
	{
		base.ViewBag.MaxLevel = maxLevel;
		base.ViewBag.SelectedIds = selectedIds;
		return View();
	}

	public ActionResult LoadProductTree(int? mode, int? prdKind, int? prdInActive, int? cmpId, int? prjId, int? level, int maxLevel, int? parentId, int? productId, int pageNumber = 1, int pageSize = 20, string textSearch = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<WSspProductsTreeByLevel_Result> data = new List<WSspProductsTreeByLevel_Result>();
		try
		{
			if (productId.HasValue && productId != 0)
			{
				textSearch = "";
			}
			textSearch = textSearch.Trim();
			parentId = ((parentId.HasValue && parentId.GetValueOrDefault() == -1) ? new int?(0) : parentId);
			data = Enumerable.ToList<WSspProductsTreeByLevel_Result>((IEnumerable<WSspProductsTreeByLevel_Result>)_dbII.WSspProductsTreeByLevel(mode, lCID, result, prdKind, prdInActive, cmpId, prjId, level, textSearch, maxLevel, parentId, productId, pageSize, pageNumber));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	public ActionResult ConditionSelectItems()
	{
		return View();
	}

	[HttpPost]
	public ActionResult GetConditionScopeRecords(int conditionCriterionId = 1, int userId = 0, int pageNumber = 1, int pageSize = 30, int? provinceId = 0, int? countryId = 0, int? companyGroupId = 0, string searchKeyword = "", int? productFirstGroupId = 0, int? productSecondGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		int totalCount = 0;
		try
		{
			_ = Labels.None;
			_ = Labels.HaveNot;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			switch (conditionCriterionId)
			{
			case 2:
			{
				CRMSpIIIEntities dbIII = _dbIII;
				int? pageNumber3 = pageNumber;
				int? pageSize3 = pageSize;
				int? userId3 = userId;
				List<CRMspSelectCityWithPaging_Result> list7 = Enumerable.ToList<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)dbIII.CRMspSelectCityWithPaging(pageNumber3, pageSize3, lCID, result, userId3, result2, provinceId, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCityWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7, (Func<CRMspSelectCityWithPaging_Result, SelectListItem>)((CRMspSelectCityWithPaging_Result item) => new SelectListItem
				{
					Text = item.CityName,
					Value = item.CityID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7) ? Enumerable.FirstOrDefault<CRMspSelectCityWithPaging_Result>((IEnumerable<CRMspSelectCityWithPaging_Result>)list7).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 3:
			{
				List<CRMspSelectProvinceWithPaging_Result> list4 = Enumerable.ToList<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)_dbIII.CRMspSelectProvinceWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword, countryId: countryId));
				list.AddRange(Enumerable.Select<CRMspSelectProvinceWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4, (Func<CRMspSelectProvinceWithPaging_Result, SelectListItem>)((CRMspSelectProvinceWithPaging_Result item) => new SelectListItem
				{
					Text = item.ProvinceName,
					Value = item.ProvinceID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4) ? Enumerable.FirstOrDefault<CRMspSelectProvinceWithPaging_Result>((IEnumerable<CRMspSelectProvinceWithPaging_Result>)list4).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 4:
			{
				List<CRMspSelectCompanyGroupsWithPaging_Result> list18 = Enumerable.ToList<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsWithPaging(pageNumber, pageSize, userId: userId, languageID: lCID, defaultLanguageID: result, centerId: result2, searchTerm: searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18, (Func<CRMspSelectCompanyGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupName,
					Value = item.CompanyGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsWithPaging_Result>)list18).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 5:
			{
				List<CRMspSelectCompanyGroupsIIWithPaging_Result> list9 = Enumerable.ToList<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9, (Func<CRMspSelectCompanyGroupsIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIName,
					Value = item.CompanyGroupIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithPaging_Result>)list9).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 6:
			{
				List<CRMspSelectCompanyGroupsIIIWithPaging_Result> list6 = Enumerable.ToList<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIIIWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6, (Func<CRMspSelectCompanyGroupsIIIWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIIIWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIIIName,
					Value = item.CompanyGroupIIIID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIIWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIIIWithPaging_Result>)list6).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 7:
			{
				List<CRMspSelectCompanyGroupsIVWithPaging_Result> list15 = Enumerable.ToList<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)_dbIII.CRMspSelectCompanyGroupsIVWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15, (Func<CRMspSelectCompanyGroupsIVWithPaging_Result, SelectListItem>)((CRMspSelectCompanyGroupsIVWithPaging_Result item) => new SelectListItem
				{
					Text = item.GroupIVName,
					Value = item.CompanyGroupIVID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15) ? Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIVWithPaging_Result>((IEnumerable<CRMspSelectCompanyGroupsIVWithPaging_Result>)list15).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 8:
			{
				List<CRMspSelectCompanySubGroupsWithPaging_Result> list16 = Enumerable.ToList<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)_dbIII.CRMspSelectCompanySubGroupsWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword, companyGroupId));
				list.AddRange(Enumerable.Select<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16, (Func<CRMspSelectCompanySubGroupsWithPaging_Result, SelectListItem>)((CRMspSelectCompanySubGroupsWithPaging_Result item) => new SelectListItem
				{
					Text = item.SubGroupName,
					Value = item.CompanySubGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16) ? Enumerable.FirstOrDefault<CRMspSelectCompanySubGroupsWithPaging_Result>((IEnumerable<CRMspSelectCompanySubGroupsWithPaging_Result>)list16).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 9:
			{
				List<CRMspSelectCompanyTypesWithPaging_Result> list11 = Enumerable.ToList<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)_dbIII.CRMspSelectCompanyTypesWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11, (Func<CRMspSelectCompanyTypesWithPaging_Result, SelectListItem>)((CRMspSelectCompanyTypesWithPaging_Result item) => new SelectListItem
				{
					Text = item.CompanyTypeName,
					Value = item.CompanyTypeID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11) ? Enumerable.FirstOrDefault<CRMspSelectCompanyTypesWithPaging_Result>((IEnumerable<CRMspSelectCompanyTypesWithPaging_Result>)list11).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 10:
			{
				List<CRMspSelectCompanyPresentationsWithPaging_Result> list12 = Enumerable.ToList<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)_dbIII.CRMspSelectCompanyPresentationsWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12, (Func<CRMspSelectCompanyPresentationsWithPaging_Result, SelectListItem>)((CRMspSelectCompanyPresentationsWithPaging_Result item) => new SelectListItem
				{
					Text = item.Presentation,
					Value = item.CompanyPresentationID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12) ? Enumerable.FirstOrDefault<CRMspSelectCompanyPresentationsWithPaging_Result>((IEnumerable<CRMspSelectCompanyPresentationsWithPaging_Result>)list12).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 11:
			{
				List<WSspSelectProductFirstGroupWithPaging_Result> list5 = Enumerable.ToList<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)_dbIII.WSspSelectProductFirstGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5, (Func<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>)((WSspSelectProductFirstGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.FGName,
					Value = item.PrdFirstGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5) ? Enumerable.FirstOrDefault<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list5).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 12:
			{
				List<WSspSelectProductSecondGroupWithPaging_Result> list10 = Enumerable.ToList<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)_dbIII.WSspSelectProductSecondGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10, (Func<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>)((WSspSelectProductSecondGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.SGName,
					Value = item.PrdSecondGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10) ? Enumerable.FirstOrDefault<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list10).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 13:
			{
				List<WSspSelectProductWithPaging_Result> list17 = Enumerable.ToList<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)_dbIII.WSspSelectProductWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId, productSecondGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductWithPaging_Result>)list17, (Func<WSspSelectProductWithPaging_Result, SelectListItem>)((WSspSelectProductWithPaging_Result item) => new SelectListItem
				{
					Text = item.PrdName,
					Value = item.ProductID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list17) ? Enumerable.FirstOrDefault<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list17).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 14:
			{
				List<WSspSelectOrderOprWithPaging_Result> list13 = Enumerable.ToList<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)_dbIII.WSspSelectOrderOprWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderOprWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13, (Func<WSspSelectOrderOprWithPaging_Result, SelectListItem>)((WSspSelectOrderOprWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.OrderOprID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13) ? Enumerable.FirstOrDefault<WSspSelectOrderOprWithPaging_Result>((IEnumerable<WSspSelectOrderOprWithPaging_Result>)list13).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 15:
			{
				List<WSspSelectOrderGroupWithPaging_Result> list3 = Enumerable.ToList<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)_dbIII.WSspSelectOrderGroupWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3, (Func<WSspSelectOrderGroupWithPaging_Result, SelectListItem>)((WSspSelectOrderGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderGroupName,
					Value = item.OrderGroupId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3) ? Enumerable.FirstOrDefault<WSspSelectOrderGroupWithPaging_Result>((IEnumerable<WSspSelectOrderGroupWithPaging_Result>)list3).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 16:
			{
				List<WSspSelectOrderStatusWithPaging_Result> list14 = Enumerable.ToList<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)_dbIII.WSspSelectOrderStatusWithPaging(pageNumber, pageSize, lCID, result, userId, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectOrderStatusWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14, (Func<WSspSelectOrderStatusWithPaging_Result, SelectListItem>)((WSspSelectOrderStatusWithPaging_Result item) => new SelectListItem
				{
					Text = item.OrderStatus,
					Value = item.OrderStatusId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14) ? Enumerable.FirstOrDefault<WSspSelectOrderStatusWithPaging_Result>((IEnumerable<WSspSelectOrderStatusWithPaging_Result>)list14).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 17:
			{
				List<WSspSelectDeliveryTermWithPaging_Result> list8 = Enumerable.ToList<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)_dbIII.WSspSelectDeliveryTermWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8, (Func<WSspSelectDeliveryTermWithPaging_Result, SelectListItem>)((WSspSelectDeliveryTermWithPaging_Result item) => new SelectListItem
				{
					Text = item.DeliveryTerm,
					Value = item.DeliveryTermId.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8) ? Enumerable.FirstOrDefault<WSspSelectDeliveryTermWithPaging_Result>((IEnumerable<WSspSelectDeliveryTermWithPaging_Result>)list8).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 18:
			{
				List<WSspSelectSettlementTypeWithPaging_Result> list2 = Enumerable.ToList<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)_dbIII.WSspSelectSettlementTypeWithPaging(pageNumber, pageSize, lCID, result, userId, result2, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2, (Func<WSspSelectSettlementTypeWithPaging_Result, SelectListItem>)((WSspSelectSettlementTypeWithPaging_Result item) => new SelectListItem
				{
					Text = item.Name,
					Value = item.Id.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2) ? Enumerable.FirstOrDefault<WSspSelectSettlementTypeWithPaging_Result>((IEnumerable<WSspSelectSettlementTypeWithPaging_Result>)list2).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			Data = list,
			TotalCount = totalCount
		}, JsonRequestBehavior.AllowGet);
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
