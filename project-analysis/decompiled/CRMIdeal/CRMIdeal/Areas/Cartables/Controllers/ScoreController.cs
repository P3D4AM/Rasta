using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.GSD.Globalization;
using Newtonsoft.Json;

namespace CRMIdeal.Areas.Cartables.Controllers;

public class ScoreController : Controller
{
	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private const int ScoreLinkTypeId = 31;

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actcScore")]
	public ActionResult Index()
	{
		IncDate();
		return View();
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByMonthUserScore_Result> ProjectProductHistoryByMonthUserScore(string date = "")
	{
		List<CRMspChartProjectProductHistoryByMonthUserScore_Result> result = new List<CRMspChartProjectProductHistoryByMonthUserScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByMonthUserScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByMonthUserScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByMonthUserScore_Result>)_dbI.CRMspChartProjectProductHistoryByMonthUserScore(UserLogin.CurrentUser.UserId, value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByMonthUserScoreJs(string date = "")
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByMonthUserScore(date));
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByMonthPrdScore_Result> ProjectProductHistoryByMonthPrdScore(string date = "", int selectedUserId = 0)
	{
		List<CRMspChartProjectProductHistoryByMonthPrdScore_Result> result = new List<CRMspChartProjectProductHistoryByMonthPrdScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByMonthPrdScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByMonthPrdScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByMonthPrdScore_Result>)_dbI.CRMspChartProjectProductHistoryByMonthPrdScore(UserLogin.CurrentUser.UserId, selectedUserId, value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByMonthPrdScoreJs(string date = "", int selectedUserId = 0)
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByMonthPrdScore(date, selectedUserId));
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByDayUserScore_Result> ProjectProductHistoryByDayUserScore(string date = "", int userId = 0)
	{
		List<CRMspChartProjectProductHistoryByDayUserScore_Result> result = new List<CRMspChartProjectProductHistoryByDayUserScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByDayUserScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByDayUserScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByDayUserScore_Result>)_dbI.CRMspChartProjectProductHistoryByDayUserScore(UserLogin.CurrentUser.UserId, value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByDayUserScoreJs(string date = "", int userId = 0)
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByDayUserScore(date, userId));
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByDayPrdScore_Result> ProjectProductHistoryByDayPrdScore(string date = "", int userId = 0)
	{
		List<CRMspChartProjectProductHistoryByDayPrdScore_Result> result = new List<CRMspChartProjectProductHistoryByDayPrdScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByDayPrdScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByDayPrdScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByDayPrdScore_Result>)_dbI.CRMspChartProjectProductHistoryByDayPrdScore(UserLogin.CurrentUser.UserId, userId, value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByDayPrdScoreJs(string date = "", int userId = 0)
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByDayPrdScore(date, userId));
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByDayProductsScore_Result> ProjectProductHistoryByDayProductsScore(string date = "")
	{
		List<CRMspChartProjectProductHistoryByDayProductsScore_Result> result = new List<CRMspChartProjectProductHistoryByDayProductsScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByDayProductsScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByDayProductsScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByDayProductsScore_Result>)_dbI.CRMspChartProjectProductHistoryByDayProductsScore(value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByDayProductsScoreJs(string date = "")
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByDayProductsScore(date));
	}

	[LoginAuthorize]
	public List<CRMspChartProjectProductHistoryByMonthProductsScore_Result> ProjectProductHistoryByMonthProductsScore(string date = "")
	{
		List<CRMspChartProjectProductHistoryByMonthProductsScore_Result> result = new List<CRMspChartProjectProductHistoryByMonthProductsScore_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					value = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			List<CRMspChartProjectProductHistoryByMonthProductsScore_Result> list = Enumerable.ToList<CRMspChartProjectProductHistoryByMonthProductsScore_Result>((IEnumerable<CRMspChartProjectProductHistoryByMonthProductsScore_Result>)_dbI.CRMspChartProjectProductHistoryByMonthProductsScore(value, 31, lCID, result2));
			if (list != null)
			{
				result = list;
			}
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return result;
	}

	[LoginAuthorize]
	public string ProjectProductHistoryByMonthProductsScoreJs(string date = "")
	{
		return JsonConvert.SerializeObject(ProjectProductHistoryByMonthProductsScore(date));
	}

	[LoginAuthorize]
	public string IncDate(string date = "", int inc = 1)
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
			DateTime dateTime = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(date))
			{
				try
				{
					date = PersianDate.GetFormatetdDate(date.Replace("/", ""));
					dateTime = lCID switch
					{
						1065 => DateTime.Parse(date + " 00:00:00", new PersianCulture()), 
						1025 => DateTime.Parse(date + " 00:00:00", new CultureInfo("ar-SA")), 
						_ => DateTime.Parse(date + " 00:00:00", new CultureInfo("en-US")), 
					};
				}
				catch (Exception ex)
				{
					Public.InsExceptToElmah(ex);
				}
			}
			string text = dateTime.AddDays(-1 * inc).ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "PriorDate",
				Value = text
			});
			base.ViewBag.PriorDate = text;
			string text2 = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDate",
				Value = text2
			});
			base.ViewBag.CurrDate = text2;
			string text3 = dateTime.ToString("dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateDayNum",
				Value = text3
			});
			base.ViewBag.CurrDateDayNum = text3;
			string text4 = dateTime.ToString("MM", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateMonthNum",
				Value = text4
			});
			base.ViewBag.CurrDateMonthNum = text4;
			string text5 = dateTime.ToString("MMM", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateMonthName",
				Value = text5
			});
			base.ViewBag.CurrDateMonthName = text5;
			string text6 = dateTime.ToString("yyyy", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "CurrDateYear",
				Value = text6
			});
			base.ViewBag.CurrDateYear = text6;
			string text7 = dateTime.AddDays(inc).ToString("yyyy/MM/dd", new PersianCulture());
			list.Add(new SelectListItem
			{
				Text = "NextDate",
				Value = text7
			});
			base.ViewBag.NextDate = text7;
		}
		catch (Exception ex2)
		{
			Public.InsExceptToElmah(ex2);
		}
		return JsonConvert.SerializeObject(list);
	}
}
