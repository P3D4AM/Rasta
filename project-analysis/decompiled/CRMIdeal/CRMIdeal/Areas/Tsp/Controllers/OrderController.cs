using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.Classes.Helper.Tsp;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using Elmah;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.Tsp.Controllers;

public class OrderController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	[LoginAuthorize]
	public ActionResult Index(int position, int ordId = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 1:
			text = "frmOrder";
			text2 = "actTspTransfer";
			break;
		case 2:
			text = "frmOrderIndicator";
			text2 = "actTspTransfer";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		try
		{
			TSPspSelectSetting_Result tSPspSelectSetting_Result = Enumerable.FirstOrDefault<TSPspSelectSetting_Result>((IEnumerable<TSPspSelectSetting_Result>)_dbI.TSPspSelectSetting(lCID, result));
			if (tSPspSelectSetting_Result != null)
			{
				int.TryParse(tSPspSelectSetting_Result.TspSendDateType.ToString(), out result2);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspSendDateType = result2;
		GetOrderOpr();
		base.ViewBag.Position = position;
		base.ViewBag.OrdId = ordId;
		GetTspTob();
		return View();
	}

	public List<TSPspSelectOrder_Result> GetList(int ordId = 0, int pageNumber = 1, int pageSize = 100, int tspCmpTob = 0, string modeSearch = "0", string txtSearch = "", int mode = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TSPspSelectOrder_Result> list = new List<TSPspSelectOrder_Result>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			list = Enumerable.ToList<TSPspSelectOrder_Result>((IEnumerable<TSPspSelectOrder_Result>)_dbI.TSPspSelectOrder(ordId, userId, pageNumber, pageSize, lCID, result, tspCmpTob, modeSearch, txtSearch, mode));
			if (list == null || !Enumerable.Any<TSPspSelectOrder_Result>((IEnumerable<TSPspSelectOrder_Result>)list))
			{
				list = new List<TSPspSelectOrder_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public JsonResult GetResultList(int ordId = 0, int pageNumber = 1, int pageSize = 100, int tspCmpTob = 0, string modeSearch = "0", string txtSearch = "", int mode = 0)
	{
		//IL_0184: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		TSPSelectOrderListViewModel tSPSelectOrderListViewModel = new TSPSelectOrderListViewModel();
		tSPSelectOrderListViewModel.ResultList = new List<TSPspSelectOrder_Result>();
		tSPSelectOrderListViewModel.IsFind = false;
		tSPSelectOrderListViewModel.Message = "";
		tSPSelectOrderListViewModel.TotalPage = 0L;
		try
		{
			tSPSelectOrderListViewModel.ResultList = GetList(ordId, pageNumber, pageSize, tspCmpTob, modeSearch, txtSearch, mode);
			if (tSPSelectOrderListViewModel.ResultList != null && Enumerable.Any<TSPspSelectOrder_Result>((IEnumerable<TSPspSelectOrder_Result>)tSPSelectOrderListViewModel.ResultList))
			{
				tSPSelectOrderListViewModel.IsFind = true;
				foreach (TSPspSelectOrder_Result result4 in tSPSelectOrderListViewModel.ResultList)
				{
					result4.ordDate = (result4.ordDateTime.HasValue ? result4.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					result4.TspOrdSendDatePersian = (result4.TspOrdSendDate.HasValue ? result4.TspOrdSendDate.Value.ToString("yyyy/MM/dd") : "");
					result4.TspOrdLastEditDatePersian = (result4.TspOrdLastEditDate.HasValue ? result4.TspOrdLastEditDate.Value.ToString("yyyy/MM/dd") : "");
					if (!string.IsNullOrWhiteSpace(result4.TspOrdMessage))
					{
						List<TspOrdMessageViewModel> list = new JavaScriptSerializer().Deserialize<List<TspOrdMessageViewModel>>(result4.TspOrdMessage);
						if (list != null && Enumerable.Any<TspOrdMessageViewModel>((IEnumerable<TspOrdMessageViewModel>)list))
						{
							list = Enumerable.ToList<TspOrdMessageViewModel>((IEnumerable<TspOrdMessageViewModel>)Enumerable.OrderByDescending<TspOrdMessageViewModel, DateTime?>((IEnumerable<TspOrdMessageViewModel>)list, (Func<TspOrdMessageViewModel, DateTime?>)((TspOrdMessageViewModel m) => m.MsgDate)));
							foreach (TspOrdMessageViewModel item in list)
							{
								item.MsgDatePersian = (item.MsgDate.HasValue ? item.MsgDate.Value.ToString("yyyy/MM/dd") : "");
							}
							result4.TspOrdMessage = JsonConvert.SerializeObject(Enumerable.ToList<TspOrdMessageViewModel>((IEnumerable<TspOrdMessageViewModel>)list));
						}
					}
					int result2 = 0;
					int.TryParse(result4.TspCmpTob.ToString(), out result2);
					switch (result2)
					{
					case 1:
						result4.TspCmpTobTitle = Labels.cmpTspCmpTobI;
						break;
					case 2:
						result4.TspCmpTobTitle = Labels.cmpTspCmpTobII;
						break;
					case 3:
						result4.TspCmpTobTitle = Labels.cmpTspCmpTobIII;
						break;
					case 4:
						result4.TspCmpTobTitle = Labels.cmpTspCmpTobIV;
						break;
					case 5:
						result4.TspCmpTobTitle = Labels.cmpTspCmpTobV;
						break;
					}
				}
				TSPspSelectOrder_Result tSPspSelectOrder_Result = Enumerable.FirstOrDefault<TSPspSelectOrder_Result>((IEnumerable<TSPspSelectOrder_Result>)tSPSelectOrderListViewModel.ResultList);
				long result3 = 0L;
				if (tSPspSelectOrder_Result != null)
				{
					long.TryParse(tSPspSelectOrder_Result.AllPage.ToString(), out result3);
				}
				tSPSelectOrderListViewModel.TotalPage = result3;
			}
			else
			{
				tSPSelectOrderListViewModel.ResultList = new List<TSPspSelectOrder_Result>();
				tSPSelectOrderListViewModel.Message = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			tSPSelectOrderListViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(tSPSelectOrderListViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmTspTransfer", ActionName = "actSend,actInquiry,actCancellation,actCorrective")]
	[AjaxOnly]
	public JsonResult SendOrInquery(string records, int reqType, string sendDate, string cancelDate)
	{
		//IL_00b7: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<TSPRowSelectedViewModel> list = new List<TSPRowSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<TSPRowSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<TSPRowSelectedViewModel>(Enumerable.Where<TSPRowSelectedViewModel>((IEnumerable<TSPRowSelectedViewModel>)list, (Func<TSPRowSelectedViewModel, bool>)((TSPRowSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			if (string.IsNullOrWhiteSpace(sendDate))
			{
				sendDate = DateTime.Now.ToString("yyyy/MM/dd");
			}
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			string text2 = "";
			if (string.IsNullOrWhiteSpace(sendDate))
			{
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspTransferSendDate),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			try
			{
				string text3 = DateTime.Now.ToString("HH:mm:ss");
				text2 = PersianDate.GetFormatetdDate(sendDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text2 + " " + text3, new PersianCulture());
					sendDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text2 + " " + text3, new CultureInfo("ar-SA"));
					sendDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text2 + " " + text3, new CultureInfo("en-US"));
					sendDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				dateTime2 = dateTime;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = string.Format(Messages.ErrorInFormat, Labels.TspTransferSendDate),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			if (reqType == 3)
			{
				if (string.IsNullOrWhiteSpace(cancelDate))
				{
					data = 0;
					data2 = new CommonResultViewModel<int>
					{
						Data = data,
						Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspTransferCancelDate),
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data2, JsonRequestBehavior.AllowGet);
				}
				try
				{
					string text4 = DateTime.Now.ToString("HH:mm:ss");
					text2 = PersianDate.GetFormatetdDate(cancelDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text2 + " " + text4, new PersianCulture());
						cancelDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text2 + " " + text4, new CultureInfo("ar-SA"));
						cancelDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text2 + " " + text4, new CultureInfo("en-US"));
						cancelDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					dateTime2 = dateTime;
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					data = 0;
					data2 = new CommonResultViewModel<int>
					{
						Data = data,
						Message = string.Format(Messages.ErrorInFormat, Labels.TspTransferCancelDate),
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data2, JsonRequestBehavior.AllowGet);
				}
			}
			List<TSPRowErrorViewModel> list2 = new List<TSPRowErrorViewModel>();
			if (list != null && Enumerable.Any<TSPRowSelectedViewModel>((IEnumerable<TSPRowSelectedViewModel>)list))
			{
				int num = 0;
				int count = list.Count;
				switch (reqType)
				{
				case 1:
				case 3:
				case 4:
				case 5:
				case 11:
					foreach (TSPRowSelectedViewModel item3 in list)
					{
						CommonResultViewModel<int> commonResultViewModel2 = TspTax.SendOrder(item3.Id, dateTime2, reqType);
						if (commonResultViewModel2 != null && commonResultViewModel2.Status != CommonResultStatusViewModel.Success)
						{
							long value3 = 0L;
							string ordDate2 = "";
							DateTime value4 = DateTime.Now;
							string orderOpr2 = "";
							string companyName2 = "";
							TSPspSelectOrderById_Result tSPspSelectOrderById_Result2 = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)_dbI.TSPspSelectOrderById(item3.Id, lCID, result));
							if (tSPspSelectOrderById_Result2 != null)
							{
								value3 = tSPspSelectOrderById_Result2.ordNumber;
								ordDate2 = tSPspSelectOrderById_Result2.ordDate;
								value4 = tSPspSelectOrderById_Result2.ordDateTime ?? DateTime.Now;
								orderOpr2 = tSPspSelectOrderById_Result2.OrderOpr;
								companyName2 = tSPspSelectOrderById_Result2.CompanyName;
							}
							TSPRowErrorViewModel item2 = new TSPRowErrorViewModel
							{
								OrderID = item3.Id,
								ErrorMessage = ((!string.IsNullOrWhiteSpace(commonResultViewModel2.Message)) ? commonResultViewModel2.Message : Messages.msgErrorSendInfo),
								ordNumber = value3,
								ordDate = ordDate2,
								ordDateTime = value4,
								OrderOpr = orderOpr2,
								CompanyName = companyName2
							};
							list2.Add(item2);
						}
						num++;
						int count3 = num * 100 / count;
						ProgressHub.SendMessage("ok", count3, userId);
					}
					break;
				case 2:
					foreach (TSPRowSelectedViewModel item4 in list)
					{
						CommonResultViewModel<int> commonResultViewModel = TspTax.InquiryOrder(item4.Id);
						if (commonResultViewModel != null && commonResultViewModel.Status != CommonResultStatusViewModel.Success)
						{
							long value = 0L;
							string ordDate = "";
							DateTime value2 = DateTime.Now;
							string orderOpr = "";
							string companyName = "";
							TSPspSelectOrderById_Result tSPspSelectOrderById_Result = Enumerable.FirstOrDefault<TSPspSelectOrderById_Result>((IEnumerable<TSPspSelectOrderById_Result>)_dbI.TSPspSelectOrderById(item4.Id, lCID, result));
							if (tSPspSelectOrderById_Result != null)
							{
								value = tSPspSelectOrderById_Result.ordNumber;
								ordDate = tSPspSelectOrderById_Result.ordDate;
								value2 = tSPspSelectOrderById_Result.ordDateTime ?? DateTime.Now;
								orderOpr = tSPspSelectOrderById_Result.OrderOpr;
								companyName = tSPspSelectOrderById_Result.CompanyName;
							}
							TSPRowErrorViewModel item = new TSPRowErrorViewModel
							{
								OrderID = item4.Id,
								ErrorMessage = ((!string.IsNullOrWhiteSpace(commonResultViewModel.Message)) ? commonResultViewModel.Message : Messages.msgErrorSendInfo),
								ordNumber = value,
								ordDate = ordDate,
								ordDateTime = value2,
								OrderOpr = orderOpr,
								CompanyName = companyName
							};
							list2.Add(item);
						}
						num++;
						int count2 = num * 100 / count;
						ProgressHub.SendMessage("ok", count2, userId);
					}
					break;
				default:
					text = string.Format(Messages.msgErrorIsNotSpecified, Labels.TspTransferSendOrInquiryInfo);
					break;
				}
			}
			else
			{
				text = Messages.msgErrorNotSelectedItem;
			}
			string text5 = "";
			if (!string.IsNullOrWhiteSpace(text5))
			{
				text = Messages.msgNotCompeleteSuccessAction;
				text = text + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					data = 0;
					data2 = new CommonResultViewModel<int>
					{
						Data = data,
						Message = text,
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data2, JsonRequestBehavior.AllowGet);
				}
				text = Messages.msgOperationCompleted;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public string GetFileError(List<TSPRowErrorViewModel> res)
	{
		//IL_0456: Unknown result type (might be due to invalid IL or missing references)
		//IL_0471: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		Guid.NewGuid().ToString();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<TSPRowErrorViewModel>((IEnumerable<TSPRowErrorViewModel>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.TspTransferExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.TspTransferListOrdOpr, "");
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.TspTransferListOrdNumber, "");
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.TspTransferListOrdDate, "");
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.TspTransferListOrdCompany, "");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.TspTransferListErrorDesc;
				foreach (TSPRowErrorViewModel re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.OrderOpr ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.ordNumber.ToString();
					re.ordDate = (re.ordDateTime.HasValue ? re.ordDateTime.Value.ToString("yyyy/MM/dd") : "");
					num++;
					excelWorksheet.Cells[num2, num].Value = re.ordDate ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string text2 = re.ErrorMessage ?? "";
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 = text2.Replace("<br>", "\n").Replace("<br>", "\n");
						if (text2.StartsWith(","))
						{
							text2 = text2.TrimStart(new char[1] { ',' });
						}
						if (text2.EndsWith(","))
						{
							text2 = text2.TrimEnd(new char[1] { ',' });
						}
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = text2;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportTSPErrorInfo\\" + userId;
				string text4 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text3 + "\\" + text4;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text3);
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
					if (System.IO.Directory.Exists(text3))
					{
						System.IO.Directory.Delete(text3);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text3))
				{
					System.IO.Directory.CreateDirectory(text3);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text3);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.TspTransferExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.TspTransferExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportTSPErrorInfo/" + userId + "/" + text4;
					text = text.Replace("~/", "/");
					text = (text.StartsWith("/") ? text : ("/" + text));
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetOrderOpr()
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
		base.ViewBag.OrderOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTspTob()
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
			list.Add(new SelectListItem
			{
				Text = Labels.SelectItem1,
				Value = "",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobI,
				Value = "1",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobII,
				Value = "2",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobIII,
				Value = "3",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobIV,
				Value = "4",
				Selected = false
			});
			list.Add(new SelectListItem
			{
				Text = Labels.cmpTspCmpTobV,
				Value = "5",
				Selected = false
			});
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TspTobList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ChangeTspOrdStatus(int ordId, string ordStatus)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			string text2 = "";
			text2 = TspTax.CreateTspOrdMessage("", "", Messages.msgOperationCompleted, isError: false);
			_dbI.TSPspUpdateOrder(ordId, null, null, null, null, null, null, null, null, null, ordStatus, text2, appType, null, null);
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			text = Messages.msgOperationCompleted;
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	public JsonResult UpdateTspResultFromExce()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		CommonReturnResultViewModel commonReturnResultViewModel = new CommonReturnResultViewModel
		{
			IsDone = true,
			Message = "",
			Tag = null
		};
		if (((NameObjectCollectionBase)base.Request.Files).Count > 0)
		{
			try
			{
				_ = DateTime.Now;
				object[,] array = null;
				int num = 0;
				int num2 = 0;
				HttpFileCollectionBase files = base.Request.Files;
				if (files != null && ((NameObjectCollectionBase)files).Count > 0)
				{
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
					List<TspOrdIdentifyFromExcelViewModel> list = new List<TspOrdIdentifyFromExcelViewModel>();
					if (num2 > 0)
					{
						object[] array2 = new object[num];
						for (int i = 1; i < num2; i++)
						{
							string text = "";
							string text2 = "";
							for (int j = 0; j < num; j++)
							{
								string text3 = "";
								string text4 = "";
								array2[j] = array[i, j];
								text3 = ((array[0, j] == null) ? "" : array[0, j].ToString());
								text4 = ((array2[j] == null) ? "" : array2[j].ToString());
								if (string.IsNullOrWhiteSpace(text4) || string.IsNullOrWhiteSpace(text3))
								{
									continue;
								}
								text4 = text4.Trim();
								if (!string.IsNullOrWhiteSpace(text4))
								{
									switch (text3)
									{
									case "شماره مالیاتی":
									case "شماره مالیاتی صورتحساب":
									case "شماره مالیاتی صورت حساب":
									case "شماره مالیاتی صورت\u200cحساب":
										text = text4;
										break;
									}
									switch (text3)
									{
									case "وضعیت":
									case "وضعیت صورتحساب":
									case "وضعیت صورت حساب":
									case "وضعیت صورت\u200cحساب":
										text2 = text4;
										break;
									}
								}
							}
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2))
							{
								TspOrdIdentifyFromExcelViewModel item = new TspOrdIdentifyFromExcelViewModel
								{
									TspOrdIdentify = text,
									StatusResult = text2,
									IsSend = false
								};
								list.Add(item);
							}
						}
						if (list != null)
						{
							if (Enumerable.Any<TspOrdIdentifyFromExcelViewModel>((IEnumerable<TspOrdIdentifyFromExcelViewModel>)list))
							{
								DateTime now = DateTime.Now;
								DateTime value = now;
								string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
								short.Parse(Financial.Get().Id.ToString());
								short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
								string appType = Configuration.AppType;
								_ = UserLogin.CurrentUser.UserId;
								string tspOrdIdentifyJson = JsonConvert.SerializeObject(Enumerable.ToList<TspOrdIdentifyFromExcelViewModel>((IEnumerable<TspOrdIdentifyFromExcelViewModel>)list));
								List<TSPspUpdateOrderStatusByJson_Result> list2 = Enumerable.ToList<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)_dbI.TSPspUpdateOrderStatusByJson(tspOrdIdentifyJson, value, registerDatePersian, appType));
								int num3 = 0;
								int num4 = 0;
								if (list2 != null && Enumerable.Any<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list2))
								{
									if (Enumerable.FirstOrDefault<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list2, (Func<TSPspUpdateOrderStatusByJson_Result, bool>)((TSPspUpdateOrderStatusByJson_Result m) => m.TspOrdIdentify == "ERROR")) != null)
									{
										commonReturnResultViewModel.IsDone = false;
										commonReturnResultViewModel.Message = Messages.msgErrorRunFunction;
									}
									else
									{
										num4 = Enumerable.Count<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list2);
										List<TSPspUpdateOrderStatusByJson_Result> list3 = Enumerable.ToList<TSPspUpdateOrderStatusByJson_Result>(Enumerable.Where<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list2, (Func<TSPspUpdateOrderStatusByJson_Result, bool>)((TSPspUpdateOrderStatusByJson_Result m) => m.IsSend.GetValueOrDefault())));
										if (list3 != null && Enumerable.Any<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list3))
										{
											num3 = Enumerable.Count<TSPspUpdateOrderStatusByJson_Result>((IEnumerable<TSPspUpdateOrderStatusByJson_Result>)list3);
										}
										commonReturnResultViewModel.IsDone = true;
									}
								}
								if (commonReturnResultViewModel.IsDone)
								{
									commonReturnResultViewModel.Message = Messages.msgOperationCompleted + "<br>" + string.Format(Messages.msgUpdateTspResultFromExcel, num3.ToString(), num4.ToString());
								}
							}
							else
							{
								commonReturnResultViewModel.IsDone = false;
								commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
							}
						}
						else
						{
							commonReturnResultViewModel.IsDone = false;
							commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
						}
					}
					else
					{
						commonReturnResultViewModel.IsDone = false;
						commonReturnResultViewModel.Message = Messages.msgErrorInReadInfo;
					}
				}
				else
				{
					commonReturnResultViewModel.IsDone = false;
					commonReturnResultViewModel.Message = Messages.msgErrorNotFilePath;
				}
			}
			catch (IndexOutOfRangeException e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorOrderImportExcelNotEqualColumnsByExcel;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				commonReturnResultViewModel.IsDone = false;
				commonReturnResultViewModel.Message = Messages.msgErrorLoadingInfoEntered + "\n" + ex.Message;
			}
		}
		return Json(commonReturnResultViewModel, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SetTspOrdFieldsNull(int ordId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			_dbI.TSPspUpdateOrder(ordId, "IsNull", "IsNull", null, null, "IsNull", null, "IsNull", "IsNull", "IsNull", "IsNull", "IsNull", appType, null, -1);
			if (!string.IsNullOrWhiteSpace(text))
			{
				data = 0;
				data2 = new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			text = Messages.msgOperationCompleted;
			commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult ActCheckOrderBeforeSendTsp(string records, int reqType, string sendDate, string cancelDate)
	{
		//IL_00ba: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<TSPRowSelectedViewModel> list = new List<TSPRowSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<TSPRowSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<TSPRowSelectedViewModel>(Enumerable.Where<TSPRowSelectedViewModel>((IEnumerable<TSPRowSelectedViewModel>)list, (Func<TSPRowSelectedViewModel, bool>)((TSPRowSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			if (string.IsNullOrWhiteSpace(sendDate))
			{
				sendDate = DateTime.Now.ToString("yyyy/MM/dd");
			}
			DateTime dateTime = default(DateTime);
			DateTime dateTime2 = default(DateTime);
			string text3 = "";
			if (string.IsNullOrWhiteSpace(sendDate))
			{
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspTransferSendDate),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			try
			{
				string text4 = DateTime.Now.ToString("HH:mm:ss");
				text3 = PersianDate.GetFormatetdDate(sendDate.Replace("/", ""));
				switch (lCID)
				{
				case 1065:
					dateTime = DateTime.Parse(text3 + " " + text4, new PersianCulture());
					sendDate = dateTime.ToString("yyyyMMdd");
					break;
				case 1025:
					dateTime = DateTime.Parse(text3 + " " + text4, new CultureInfo("ar-SA"));
					sendDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				default:
					dateTime = DateTime.Parse(text3 + " " + text4, new CultureInfo("en-US"));
					sendDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
					break;
				}
				dateTime2 = dateTime;
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
				text = "";
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = string.Format(Messages.ErrorInFormat, Labels.TspTransferSendDate),
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (reqType == 3)
			{
				if (string.IsNullOrWhiteSpace(cancelDate))
				{
					text = "";
					data = new CommonResultViewModel<string>
					{
						Data = text,
						Message = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.TspTransferCancelDate),
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data, JsonRequestBehavior.AllowGet);
				}
				try
				{
					string text5 = DateTime.Now.ToString("HH:mm:ss");
					text3 = PersianDate.GetFormatetdDate(cancelDate.Replace("/", ""));
					switch (lCID)
					{
					case 1065:
						dateTime = DateTime.Parse(text3 + " " + text5, new PersianCulture());
						cancelDate = dateTime.ToString("yyyyMMdd");
						break;
					case 1025:
						dateTime = DateTime.Parse(text3 + " " + text5, new CultureInfo("ar-SA"));
						cancelDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					default:
						dateTime = DateTime.Parse(text3 + " " + text5, new CultureInfo("en-US"));
						cancelDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						break;
					}
					dateTime2 = dateTime;
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
					text = "";
					data = new CommonResultViewModel<string>
					{
						Data = text,
						Message = string.Format(Messages.ErrorInFormat, Labels.TspTransferCancelDate),
						Status = CommonResultStatusViewModel.Error
					};
					return Json(data, JsonRequestBehavior.AllowGet);
				}
			}
			List<TSPRowErrorViewModel> list2 = new List<TSPRowErrorViewModel>();
			int num = 0;
			if (list != null && Enumerable.Any<TSPRowSelectedViewModel>((IEnumerable<TSPRowSelectedViewModel>)list))
			{
				num = list.Count;
				switch (reqType)
				{
				case 1:
				case 3:
				case 4:
				case 5:
				case 11:
					foreach (TSPRowSelectedViewModel item in list)
					{
						List<TSPRowErrorViewModel> list3 = TspTax.CheckOrderBeforeSendTsp(item.Id, dateTime2, reqType);
						if (list3 == null || !Enumerable.Any<TSPRowErrorViewModel>((IEnumerable<TSPRowErrorViewModel>)list3))
						{
							continue;
						}
						foreach (TSPRowErrorViewModel item2 in list3)
						{
							if (item2.OrderID.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(item2.ErrorMessage))
							{
								list2.Add(item2);
							}
						}
					}
					break;
				case 2:
					text2 = "";
					break;
				default:
					text2 = string.Format(Messages.msgErrorIsNotSpecified, Labels.TspTransferSendOrInquiryInfo);
					break;
				}
			}
			else
			{
				text2 = Messages.msgErrorNotSelectedItem;
			}
			string text6 = "";
			if (list2 != null && Enumerable.Any<TSPRowErrorViewModel>((IEnumerable<TSPRowErrorViewModel>)list2))
			{
				text = "-1";
				text6 = GetFileError(list2);
			}
			else
			{
				text = "1";
			}
			if (!string.IsNullOrWhiteSpace(text6))
			{
				text = "-1";
				string text7 = "";
				text7 = ((num != 1) ? Messages.msgErrorConfirmSendOrdsWithError : Messages.msgErrorConfirmSendOrdWithError);
				string arg = "<br><a href='" + text6 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				text2 = string.Format(text7, arg);
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "0";
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text2 = Messages.msgOperationCompleted;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			text2 = Messages.msgErrorRunFunction + "<br>" + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
