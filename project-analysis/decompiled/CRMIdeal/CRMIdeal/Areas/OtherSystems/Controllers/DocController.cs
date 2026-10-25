using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Objects;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvanran_II;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using CRMIdeal.LinkPayvast;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using NR.Shygun.WS.ClientModel;
using NR.Shygun.WS.ClientModel.GeneralModels;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class DocController : Controller
{
	public class ThreadHub
	{
		public class ThreadHubObj
		{
			public bool? IsDone { get; set; }

			public string message { get; set; }

			public int? Percent { get; set; }

			public DateTime RegDate { get; set; }
		}

		private static List<ThreadHubObj> lstThreads = new List<ThreadHubObj>();

		public static int GetLastIndex()
		{
			return lstThreads.Count - 1;
		}

		public static ThreadHubObj GetThreadResult(int indx = -1)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				return lstThreads[indx];
			}
			return null;
		}

		public static void SetThreadResult(int indx = -1, int percent = 0, string message = null, bool? isDone = null)
		{
			if (indx != -1 && lstThreads.Count - 1 >= indx)
			{
				if (isDone.HasValue)
				{
					lstThreads[indx].IsDone = isDone;
				}
				if (percent != -1)
				{
					lstThreads[indx].Percent = percent;
				}
				if (message != null)
				{
					lstThreads[indx].message = message;
				}
			}
		}

		public static int AddThread(int percent = 0, string message = null, bool? isDone = null)
		{
			for (int i = 0; i < lstThreads.Count; i++)
			{
				if (lstThreads[i] != null && lstThreads[i].RegDate.AddHours(6.0) <= DateTime.Now)
				{
					lstThreads[i] = null;
				}
			}
			lstThreads.Add(new ThreadHubObj
			{
				IsDone = isDone,
				message = message,
				Percent = percent,
				RegDate = DateTime.Now
			});
			return GetLastIndex();
		}

		public static void ClearThreads(bool forceEmpty = false)
		{
			if (lstThreads.Count == Enumerable.ToList<ThreadHubObj>(Enumerable.Where<ThreadHubObj>((IEnumerable<ThreadHubObj>)lstThreads, (Func<ThreadHubObj, bool>)((ThreadHubObj x) => x == null))).Count)
			{
				lstThreads.Clear();
			}
			if (forceEmpty)
			{
				lstThreads.Clear();
			}
		}

		public static void RemoveThread(int indx = -1, bool autoEmpty = false)
		{
			if (indx != -1)
			{
				lstThreads[indx] = null;
			}
			if (autoEmpty)
			{
				ClearThreads();
			}
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_0
	{
		public int docId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_1
	{
		public WSspSelectDocById_Result doc;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass42_3
	{
		public WSspSelectDocItems_Result docI;

		internal bool _003CShygunActSendToAcc_003Eb__2(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == docI.WHId;
		}

		internal bool _003CShygunActSendToAcc_003Eb__3(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == docI.PrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_1
	{
		public LkDocInfoViewModel doc;

		internal bool _003CShygunExportInfo_003Eb__4(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == doc.WHIdI;
		}

		internal bool _003CShygunExportInfo_003Eb__5(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == doc.WHId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_2
	{
		public WSspSelectDocItems_Result docI;

		internal bool _003CShygunExportInfo_003Eb__6(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == docI.WHId;
		}

		internal bool _003CShygunExportInfo_003Eb__7(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == docI.PrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass43_3
	{
		public int Id;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass53_0
	{
		public int docId;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_1
	{
		public LkDocInfoViewModel doc;

		internal bool _003CShygunIIExportInfo_003Eb__4(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == doc.WHIdI;
		}

		internal bool _003CShygunIIExportInfo_003Eb__5(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == doc.WHId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_2
	{
		public WSspSelectDocItems_Result docI;

		internal bool _003CShygunIIExportInfo_003Eb__6(WSspSelectWareHouse_Result x)
		{
			return x.WareHouseID == docI.WHId;
		}

		internal bool _003CShygunIIExportInfo_003Eb__7(WSspSelectProductWithAccLinkField_Result x)
		{
			return x.ProductID == docI.PrdId;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass73_3
	{
		public int Id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _db_I = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult SepImportDoc(int sepDocType, int crmDocType)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actImportFromAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actImportFromAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actImportFromAcc";
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
		GetDocOpr(crmDocType);
		GetReferUser();
		GetCrmFinancialPeriod();
		base.ViewBag.SepDocType = sepDocType;
		base.ViewBag.CrmDocType = crmDocType;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult SepDoc_Read([DataSourceRequest] DataSourceRequest request, int sepDocType, int sepInventoryType, bool sepInvIsReturn, int pageNumber, string fDate = "", string tDate = "", int value = 0, string sepStockId = "", string sepDestinationStockId = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepDocViewModel> list = new List<SepDocViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectDocFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectDocFromSep_Result>((IEnumerable<CRMspLkSepWSSelectDocFromSep_Result>)_dbLink.CRMspLkSepWSSelectDocFromSep(sepDocType, sepInventoryType, sepInvIsReturn, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, sepStockId, sepDestinationStockId, linkAccSettingDBId)))
			{
				SepDocViewModel item = new SepDocViewModel
				{
					InventoryId = item2.InventoryId,
					Stock = item2.Stock,
					DestinationStock = item2.DestinationStock,
					Customer = item2.Customer,
					Number = item2.Number,
					Date = item2.Date,
					DatePersian = (item2.Date.HasValue ? item2.Date.Value.ToString("yyyy/MM/dd") : ""),
					ItemCount = item2.ItemCount,
					DocId = item2.DocId,
					RowNumber = item2.RowNumber,
					AllPage = item2.AllPage,
					StockWHId = item2.StockWHId,
					DestinationStockWHId = item2.DestinationStockWHId
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepImportInfo(string records, int referUserId, int sepDocType, int sepInventoryType, bool sepInvIsReturn, int docOprId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, bool addOrderFromAcc = false, bool addBordPayment = false, int sepStockId = 0, int sepDestinationStockId = 0, int wHId = 0, int wHIdI = 0, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepImportInfoAsync(records, referUserId, sepDocType, sepInventoryType, sepInvIsReturn, docOprId, pageNumber, fDate, tDate, value, isUsedCmpReferUserId, crmFPId, addOrderFromAcc, addBordPayment, sepStockId, sepDestinationStockId, wHId, wHIdI, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepImportInfoAsync(string records, int referUserId, int sepDocType, int sepInventoryType, bool sepInvIsReturn, int docOprId, int pageNumber, string fDate = "", string tDate = "", int value = 0, bool isUsedCmpReferUserId = false, int crmFPId = 0, bool addOrderFromAcc = false, bool addBordPayment = false, int sepStockId = 0, int sepDestinationStockId = 0, int wHId = 0, int wHIdI = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
	{
		//IL_01c4: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		pagesCnt = ((pagesCnt <= 0) ? 1 : pagesCnt);
		int num2 = pagesCnt;
		int num3 = 0;
		pageNumber = 1;
		int userId = UserLogin.CurrentUser.UserId;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = DateTime.Now;
			_ = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				}
			}
			if (crmFPId == 0)
			{
				crmFPId = Financial.Get().Id;
			}
			if (list != null)
			{
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
					num3 = 0;
					new List<CRMspLkSepWSExportOrder_Result>();
					foreach (OtherSystemSelectedViewModel item in list)
					{
						ObjectParameter insertedDocId = new ObjectParameter("insertedDocId", 0);
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						cRMLinkSpEntities.CRMspLkSepWSIssueDocFromSep(item.Id, sepDocType, docOprId, userId, value3, value2, registerDatePersian, appType, result, insertedDocId, objectParameter, referUserId, isUsedCmpReferUserId, crmFPId, addOrderFromAcc, addBordPayment, (wHId != 0) ? new int?(wHId) : null, (wHIdI != 0) ? new int?(wHIdI) : null, linkAccSettingDBId, centerId);
						string text2 = "";
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += "<br>";
							}
							text2 += objectParameter.Value.ToString();
							if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("No Items", StringComparison.Ordinal) >= 0)
							{
								text2 = text2.Replace("No Items", "");
								text2 = text2.Replace(",,", "");
								text2 = text2 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblWarehouseSheet);
								text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
								text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
							}
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							num = 0;
							text = text + text2 + "<br>";
						}
						else
						{
							num = 1;
						}
						bool? isDone = null;
						if (num == 1)
						{
							num3++;
							int num4 = num3 * 100 / num2;
							if (num4 >= 100)
							{
								num4 = 100;
								isDone = true;
							}
							ThreadHub.SetThreadResult(indx, num4, "", isDone);
							continue;
						}
						num3++;
						int num5 = num3 * 100 / num2;
						string message = text;
						if (num5 >= 100)
						{
							num5 = 100;
							message = text;
							isDone = false;
						}
						ThreadHub.SetThreadResult(indx, num5, message, isDone);
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
					num3++;
					int percent = 100;
					string message2 = text;
					ThreadHub.SetThreadResult(indx, percent, message2, false);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent2 = 100;
				string message3 = text;
				ThreadHub.SetThreadResult(indx, percent2, message3, false);
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception)
		{
			num = 0;
			num3++;
			int percent3 = 100;
			string msgErrorRunFunction = Messages.msgErrorRunFunction;
			ThreadHub.SetThreadResult(indx, percent3, msgErrorRunFunction, false);
		}
		finally
		{
			cRMLinkSpEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepImportDocList(string records, int totalPage, int sepDocType, int sepInventoryType, bool sepInvIsReturn, string fDate = "", string tDate = "", int value = 0, string sepStockId = "", string sepDestinationStockId = "", int linkAccSettingDBId = 0)
	{
		//IL_0249: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int value2 = 500 * totalPage;
			int value3 = 1;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkSepWSSelectDocFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectDocFromSep_Result>((IEnumerable<CRMspLkSepWSSelectDocFromSep_Result>)_dbLink.CRMspLkSepWSSelectDocFromSep(sepDocType, sepInventoryType, sepInvIsReturn, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, sepStockId, sepDestinationStockId, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.InventoryId.GetValueOrDefault(),
					Selected = !item2.DocId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					foreach (OtherSystemSelectedViewModel item3 in list2)
					{
						foreach (OtherSystemSelectedViewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
							}
						}
					}
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

	[LoginAuthorize]
	public ActionResult SepExportDoc(int sepDocType, int crmDocType, int position = 0)
	{
		string text = "";
		string text2 = "";
		switch (position)
		{
		case 0:
			switch (crmDocType)
			{
			case 1:
				text = "frmDoc";
				text2 = "actExportToAcc";
				break;
			case 2:
				text = "frmDraft";
				text2 = "actExportToAcc";
				break;
			case 3:
				text = "frmWareHouseMovement";
				text2 = "actExportToAcc";
				break;
			default:
				return RedirectToAction("Login", "Account", (object)new
				{
					area = "",
					d = DateTime.Now
				});
			}
			break;
		case 1:
			text = "frmDocLinkAccDetails";
			text2 = "actAddLinkDocToAcc";
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
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		GetDocOpr(crmDocType);
		base.ViewBag.SepDocType = sepDocType;
		base.ViewBag.CrmDocType = crmDocType;
		base.ViewBag.Position = position;
		GetCrmWareHouse();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult SepExportDoc_Read([DataSourceRequest] DataSourceRequest request, int docOprId, int pageNumber, string fDate = "", string tDate = "", int value = 0, int wHId = 0, int wHIdI = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepDocViewModel> list = new List<SepDocViewModel>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel sepidarModules = CRMIdeal.Classes.Helper.OtherSystems.GetSepidarModules(linkAccSettingDBId);
			bool result3 = false;
			if (sepidarModules != null)
			{
				bool.TryParse(sepidarModules.SepNotHaveDocModule.ToString(), out result3);
			}
			foreach (CRMspLkSepWSSelectDoc_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectDoc_Result>((IEnumerable<CRMspLkSepWSSelectDoc_Result>)_dbLink.CRMspLkSepWSSelectDoc(UserLogin.CurrentUser.UserId, docOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, wHId, wHIdI, linkAccSettingDBId, result2)))
			{
				SepDocViewModel item = new SepDocViewModel
				{
					DocLinkAccDocId = ((!result3) ? item2.DocLinkAccDocId : item2.DocLinkAccVoucherId),
					Company = ((!string.IsNullOrEmpty(item2.CompanyName)) ? item2.CompanyName : "") + ((!string.IsNullOrEmpty(item2.CompanyPerson)) ? (" - " + item2.CompanyPerson) : ""),
					DocNumber = item2.DocNumber,
					Date = item2.DocDateTime,
					DatePersian = (item2.DocDateTime.HasValue ? item2.DocDateTime.Value.ToString("yyyy/MM/dd") : ""),
					Stock = item2.WrhsName,
					DestinationStock = item2.WrhsNameI,
					ItemCount = 0,
					DocId = item2.DocID,
					RowNumber = item2.RowNumber,
					AllPage = item2.AllPage
				};
				list.Add(item);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepExportInfo(int sepFiscalYearRef, string records, int sepUserId, int docOprId, int sepInventoryType, int sepDocType, bool sepInvIsReturn, bool sendOrderToAcc, bool sendOrdPayToAcc, int pageNumber, string fDate = "", string tDate = "", int value = 0, int wHId = 0, int wHIdI = 0, int sepStockId = 0, int sepDestinationStockId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, bool sendPreOrderToAcc = false, bool sendPordPayToAcc = false, bool sendOrdCommToAcc = false)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepExportInfoAsync(sepFiscalYearRef, records, sepUserId, docOprId, sepInventoryType, sepDocType, sepInvIsReturn, sendOrderToAcc, sendOrdPayToAcc, pageNumber, fDate, tDate, value, wHId, wHIdI, sepStockId, sepDestinationStockId, linkAccSettingDBId, pagesCnt, indx, sendPreOrderToAcc, sendPordPayToAcc, sendOrdCommToAcc);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepExportInfoAsync(int sepFiscalYearRef, string records, int sepUserId, int docOprId, int sepInventoryType, int sepDocType, bool sepInvIsReturn, bool sendOrderToAcc, bool sendOrdPayToAcc, int pageNumber, string fDate = "", string tDate = "", int value = 0, int wHId = 0, int wHIdI = 0, int sepStockId = 0, int sepDestinationStockId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0, bool sendPreOrderToAcc = false, bool sendPordPayToAcc = false, bool sendOrdCommToAcc = false)
	{
		//IL_01a3: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		pagesCnt = ((pagesCnt <= 0) ? 1 : pagesCnt);
		int num2 = pagesCnt;
		int num3 = 0;
		pageNumber = 1;
		int userId = UserLogin.CurrentUser.UserId;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			_ = DateTime.Now;
			_ = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				}
			}
			if (list != null)
			{
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
					num3 = 0;
					new List<CRMspLkSepWSExportOrder_Result>();
					{
						foreach (OtherSystemSelectedViewModel item in list)
						{
							CRMspLkWSSelectDocById_Result cRMspLkWSSelectDocById_Result = Enumerable.FirstOrDefault<CRMspLkWSSelectDocById_Result>((IEnumerable<CRMspLkWSSelectDocById_Result>)cRMLinkSpEntities.CRMspLkWSSelectDocById(item.Id, lCID, result));
							if (cRMspLkWSSelectDocById_Result != null)
							{
								string errorMessage = "";
								if (!Doc.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
								{
									text = text + errorMessage + "<br>";
									num = 0;
								}
								else
								{
									ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
									ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
									ObjectParameter objectParameter2 = new ObjectParameter("docNumebr", typeof(long));
									cRMLinkSpEntities.CRMspLkSepWSIssueDoc(item.Id, sepInventoryType, sepDocType, sendPreOrderToAcc, sendOrderToAcc, sepInvIsReturn, null, sepFiscalYearRef, userId, appType, insertedId, objectParameter2, objectParameter, sepUserId, sendPordPayToAcc, sendOrdPayToAcc, (sepStockId != 0) ? new int?(sepStockId) : null, (sepDestinationStockId != 0) ? new int?(sepDestinationStockId) : null, linkAccSettingDBId, sendOrdCommToAcc);
									string text2 = "";
									if (objectParameter.Value != null)
									{
										if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
										{
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text2 += "<br>";
											}
											text2 += objectParameter.Value.ToString();
											if (!string.IsNullOrWhiteSpace(text2) && text2.IndexOf("No Items", StringComparison.Ordinal) >= 0)
											{
												text2 = text2.Replace("No Items", "");
												text2 = text2.Replace(",,", "");
												text2 = text2 + "," + string.Format(Messages.msgErrorNotHaveItems, Labels.lblWarehouseSheet);
												text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
												text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
											}
											string text3 = "";
											if (objectParameter2.Value != null)
											{
												text3 = objectParameter2.Value.ToString() ?? "";
												if (text3 != "-3")
												{
													cRMspLkWSSelectDocById_Result.DocLinkAccDocNumber = text3;
												}
											}
										}
										else
										{
											string text4 = "";
											if (objectParameter2.Value != null)
											{
												text4 = objectParameter2.Value.ToString() ?? "";
												if (text4 != "-3")
												{
													cRMspLkWSSelectDocById_Result.DocLinkAccDocNumber = text4;
												}
											}
										}
									}
									else
									{
										string text5 = "";
										if (objectParameter2.Value != null)
										{
											text5 = objectParameter2.Value.ToString() ?? "";
											if (text5 != "-3")
											{
												cRMspLkWSSelectDocById_Result.DocLinkAccDocNumber = text5;
											}
										}
									}
									if (!string.IsNullOrWhiteSpace(text2))
									{
										num = 0;
										if (text2.IndexOf("Financially incorrect", StringComparison.Ordinal) >= 0)
										{
											text2 = text2.Replace("Financially incorrect,", "");
											text2 = text2.Replace("Financially incorrect<br>Financially incorrect", "");
											text2 = text2.Replace("Financially incorrect", "");
											text2 = text2.Replace(",,", "");
											text2 = text2 + "," + Messages.msgErrorfinancialYearWrong;
											text2 = text2.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
											text2 = text2.TrimStart(new char[1] { ',' }).TrimEnd(new char[1] { ',' });
										}
										text = text + text2 + "<br>";
									}
									else
									{
										num = 1;
									}
								}
							}
							else
							{
								num = 1;
							}
							bool? isDone = null;
							if (num == 1)
							{
								num3++;
								int num4 = num3 * 100 / num2;
								if (num4 >= 100)
								{
									num4 = 100;
									isDone = true;
								}
								ThreadHub.SetThreadResult(indx, num4, "", isDone);
								continue;
							}
							num3++;
							int num5 = num3 * 100 / num2;
							string message = text;
							if (num5 >= 100)
							{
								num5 = 100;
								message = text;
								isDone = false;
							}
							ThreadHub.SetThreadResult(indx, num5, message, isDone);
						}
						return;
					}
				}
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent = 100;
				string message2 = text;
				ThreadHub.SetThreadResult(indx, percent, message2, false);
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent2 = 100;
				string message3 = text;
				ThreadHub.SetThreadResult(indx, percent2, message3, false);
			}
		}
		catch (Exception)
		{
			num = 0;
			num3++;
			int percent3 = 100;
			string msgErrorRunFunction = Messages.msgErrorRunFunction;
			ThreadHub.SetThreadResult(indx, percent3, msgErrorRunFunction, false);
		}
		finally
		{
			cRMLinkSpEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepExportDocList(string records, int totalPage, int docOprId, string fDate = "", string tDate = "", int value = 0, int wHId = 0, int wHIdI = 0, int linkAccSettingDBId = 0)
	{
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int value2 = 500 * totalPage;
			int value3 = 1;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			CRMIdeal.Classes.Helper.OtherSystems.SepidarHaveModulesViewModel sepidarModules = CRMIdeal.Classes.Helper.OtherSystems.GetSepidarModules(linkAccSettingDBId);
			bool result3 = false;
			if (sepidarModules != null)
			{
				bool.TryParse(sepidarModules.SepNotHaveDocModule.ToString(), out result3);
			}
			foreach (CRMspLkSepWSSelectDoc_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectDoc_Result>((IEnumerable<CRMspLkSepWSSelectDoc_Result>)_dbLink.CRMspLkSepWSSelectDoc(UserLogin.CurrentUser.UserId, docOprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, wHId, wHIdI, linkAccSettingDBId, result2)))
			{
				item2.DocLinkAccDocId = ((!result3) ? item2.DocLinkAccDocId : item2.DocLinkAccVoucherId);
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.DocID.GetValueOrDefault(),
					Selected = !item2.DocLinkAccDocId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					foreach (OtherSystemSelectedViewModel item3 in list2)
					{
						foreach (OtherSystemSelectedViewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
							}
						}
					}
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

	[LoginAuthorize]
	public ActionResult SepDocLinkAccDetails(int docId, int crmDocType)
	{
		base.ViewBag.DocId = docId;
		base.ViewBag.CrmDocType = crmDocType;
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actDocLinkAccDetails";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actDraftLinkAccDetails";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actDocLinkAccDetails";
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
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetDocLinkAccDetails(int docId, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepDocLinkAccDetailsViewModel sepDocLinkAccDetailsViewModel = new SepDocLinkAccDetailsViewModel();
		sepDocLinkAccDetailsViewModel.DocInfo = new CRMspLkSepWSSelectDocByDocId_Result();
		sepDocLinkAccDetailsViewModel.DocItems = new List<CRMspLkSepWSSelectDocItemsByDocId_Result>();
		sepDocLinkAccDetailsViewModel.IsFind = false;
		try
		{
			if (docId != 0)
			{
				sepDocLinkAccDetailsViewModel.DocInfo = Enumerable.FirstOrDefault<CRMspLkSepWSSelectDocByDocId_Result>((IEnumerable<CRMspLkSepWSSelectDocByDocId_Result>)_dbLink.CRMspLkSepWSSelectDocByDocId(docId, lCID, result, linkAccSettingDBId));
				if (sepDocLinkAccDetailsViewModel.DocInfo != null)
				{
					sepDocLinkAccDetailsViewModel.IsFind = true;
					sepDocLinkAccDetailsViewModel.DocInfo.DocDate = (sepDocLinkAccDetailsViewModel.DocInfo.DocDateTime.HasValue ? sepDocLinkAccDetailsViewModel.DocInfo.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
					sepDocLinkAccDetailsViewModel.DocInfo.SepDocDatePersian = (sepDocLinkAccDetailsViewModel.DocInfo.SepDocDate.HasValue ? sepDocLinkAccDetailsViewModel.DocInfo.SepDocDate.Value.ToString("yyyy/MM/dd") : "");
					sepDocLinkAccDetailsViewModel.DocInfo.DocOpr = ((!string.IsNullOrWhiteSpace(sepDocLinkAccDetailsViewModel.DocInfo.DocOpr)) ? sepDocLinkAccDetailsViewModel.DocInfo.DocOpr : Labels.OtherSystemsDoc) + " (" + sepDocLinkAccDetailsViewModel.DocInfo.DocNumber + ")";
					sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccFirstTransferDateStr = (sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccFirstTransferDate.HasValue ? sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccLastTransferDateStr = (sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccLastTransferDate.HasValue ? sepDocLinkAccDetailsViewModel.DocInfo.DocLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepDocLinkAccDetailsViewModel.DocItems = Enumerable.ToList<CRMspLkSepWSSelectDocItemsByDocId_Result>((IEnumerable<CRMspLkSepWSSelectDocItemsByDocId_Result>)_dbLink.CRMspLkSepWSSelectDocItemsByDocId(docId, lCID, result, linkAccSettingDBId));
					if (sepDocLinkAccDetailsViewModel.DocItems != null && Enumerable.Any<CRMspLkSepWSSelectDocItemsByDocId_Result>((IEnumerable<CRMspLkSepWSSelectDocItemsByDocId_Result>)sepDocLinkAccDetailsViewModel.DocItems))
					{
						foreach (CRMspLkSepWSSelectDocItemsByDocId_Result docItem in sepDocLinkAccDetailsViewModel.DocItems)
						{
							docItem.PrdQtyNoFCR = docItem.PrdQtyNoFCR.GetValueOrDefault();
							docItem.DocILinkAccFirstTransferDateStr = (docItem.DocILinkAccFirstTransferDate.HasValue ? docItem.DocILinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
							docItem.DocILinkAccLastTransferDateStr = (docItem.DocILinkAccLastTransferDate.HasValue ? docItem.DocILinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						}
					}
					else
					{
						sepDocLinkAccDetailsViewModel.DocItems = new List<CRMspLkSepWSSelectDocItemsByDocId_Result>();
					}
				}
				else
				{
					sepDocLinkAccDetailsViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				sepDocLinkAccDetailsViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			sepDocLinkAccDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(sepDocLinkAccDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SepDeleteDocInfo(int docId, int docItemId, int mode, int position, int linkAccSettingDBId)
	{
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			string actionName = "";
			switch (position)
			{
			case 1:
				actionName = "actDelLinkDocInAcc";
				break;
			case 2:
				actionName = "actDelLinkDocInCrm";
				break;
			case 11:
				actionName = "actDelLinkDocItemInAcc";
				break;
			case 12:
				actionName = "actDelLinkDocItemInCrm";
				break;
			}
			if (!UserLogin.IsUserAccess("frmDocLinkAccDetails", actionName, currentUser))
			{
				text = "";
				text2 = Messages.ErrorNotAccess;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				data = new CommonResultViewModel<string>
				{
					Data = text,
					Message = text2,
					Status = commonResultStatusViewModel
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (docId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text3 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int id = Financial.Get().Id;
				int userId = currentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				CRMLinkSpEntities dbLink = _dbLink;
				int? docId2 = docId;
				int? docItemId2 = docItemId;
				int? crmUserId = userId;
				int? month = value2;
				int? fPId = id;
				DateTime? registerDate = value;
				string registerDatePersian = text3;
				string appType2 = appType;
				ObjectParameter errorMessage = objectParameter;
				dbLink.CRMspLkSepWSDeleteDocInfoFromSep(docId2, docItemId2, mode, crmUserId, month, fPId, registerDate, registerDatePersian, appType2, errorMessage, linkAccSettingDBId);
				if (objectParameter.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						text2 = objectParameter.Value.ToString();
						if (mode == 1)
						{
							text2 = text2 + "<br>" + Messages.RedundancyMessage;
						}
					}
					else
					{
						text2 = "";
					}
				}
				else
				{
					text2 = "";
				}
			}
			else
			{
				text2 = Messages.ErrorNotFound;
			}
			if (!string.IsNullOrWhiteSpace(text2))
			{
				text = "0";
				text2 = Messages.msgErrorRunFunction + "<br>" + text2;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
			else
			{
				text = "1";
				text2 = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "0";
			text2 = Messages.msgErrorRunFunction + " " + ex.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		data = new CommonResultViewModel<string>
		{
			Data = text,
			Message = text2,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult NoAvImportDoc(int docType, int crmDocType)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actImportFromAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actImportFromAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actImportFromAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvImportDoc_Read([DataSourceRequest] DataSourceRequest request, int docType, string comDbName, string whDbName, int kindDraft, int noAvCodeStore, int pageNumber, string fDate = "", string tDate = "", int value = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SepDocViewModel> list = new List<SepDocViewModel>();
		try
		{
			int value2 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			DateTime value3 = DateTime.Now;
			DateTime value4 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkNoAvWSSelectDocFromNoAv_Result item in (IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)Enumerable.OrderBy<CRMspLkNoAvWSSelectDocFromNoAv_Result, long?>((IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)Enumerable.ToList<CRMspLkNoAvWSSelectDocFromNoAv_Result>((IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)_dbLink.CRMspLkNoAvWSSelectDocFromNoAv(docType, comDbName, whDbName, kindDraft, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, noAvCodeStore)), (Func<CRMspLkNoAvWSSelectDocFromNoAv_Result, long?>)((CRMspLkNoAvWSSelectDocFromNoAv_Result m) => m.RowNumber)))
			{
				SepDocViewModel sepDocViewModel = new SepDocViewModel
				{
					InventoryId = ((docType == 1) ? new int?((item.DocNumber != null) ? int.Parse(item.DocNumber) : 0) : item.Id),
					Stock = (item.StoreName ?? ""),
					DestinationStock = (item.RecStoreName ?? ""),
					Customer = (item.Customer ?? ""),
					Number = ((item.DocNumber != null) ? int.Parse(item.DocNumber) : 0),
					DatePersian = (item.DocDATE ?? ""),
					DocId = item.DocId,
					RowNumber = item.RowNumber,
					AllPage = item.AllPage
				};
				if (lCID != 1065 && !string.IsNullOrEmpty(item.DocDATE))
				{
					sepDocViewModel.DatePersian = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.DocDATE.Replace("/", ""))).ToString("yyyy/MM/dd");
				}
				list.Add(sepDocViewModel);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult NoAvImportInfo(string records, int docType, string comDbName, string whDbName, int kindDraft, int docOprId, int noAvCodeStore, int pageNumber, string fDate = "", string tDate = "", int value = 0)
	{
		//IL_01c2: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int value4 = 500;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime value5 = DateTime.Now;
			DateTime value6 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value6 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			string text3 = "";
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					foreach (OtherSystemSelectedViewModel item in list)
					{
						if (item.Selected)
						{
							text3 = text3 + item.Id + ",";
						}
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			CRMLinkSpEntities dbLink = _dbLink;
			int? noAvDocType = docType;
			int? noAvKindDraft = kindDraft;
			int? docOprId2 = docOprId;
			DateTime? fDate2 = ((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value5) : null);
			DateTime? tDATE = ((!string.IsNullOrEmpty(tDate)) ? new DateTime?(value6) : null);
			int? docNumber = value;
			int? pageNumber2 = pageNumber;
			int? pageSize = value4;
			int? userId2 = userId;
			int? month = value3;
			int? fPId = id;
			DateTime? registerDate = value2;
			string registerDatePersian = text2;
			string appType2 = appType;
			int? defLanguageID = result;
			ObjectParameter errorMessage = objectParameter;
			dbLink.CRMspLkNoAvWSImportDoc(noAvDocType, comDbName, whDbName, noAvKindDraft, docOprId2, fDate2, tDATE, docNumber, text3, pageNumber2, pageSize, userId2, month, fPId, registerDate, registerDatePersian, appType2, defLanguageID, errorMessage, noAvCodeStore, centerId);
			if (objectParameter.Value != null)
			{
				if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
				{
					num = 0;
					text = objectParameter.Value.ToString();
					commonResultStatusViewModel = CommonResultStatusViewModel.Error;
				}
				else
				{
					num = 1;
					text = Messages.msgSuccessAction;
					commonResultStatusViewModel = CommonResultStatusViewModel.Success;
				}
			}
			else
			{
				num = 1;
				text = Messages.msgSuccessAction;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.FOMsgErrorDoneOperation,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvImportDocList(string records, int totalPage, int docType, string comDbName, string whDbName, int kindDraft, int noAvCodeStore, string fDate = "", string tDate = "", int value = 0)
	{
		//IL_0291: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int value2 = 500 * totalPage;
			int value3 = 1;
			DateTime value4 = DateTime.Now;
			DateTime value5 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value4 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value5 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			foreach (CRMspLkNoAvWSSelectDocFromNoAv_Result item2 in (IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)Enumerable.OrderBy<CRMspLkNoAvWSSelectDocFromNoAv_Result, long?>((IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)Enumerable.ToList<CRMspLkNoAvWSSelectDocFromNoAv_Result>((IEnumerable<CRMspLkNoAvWSSelectDocFromNoAv_Result>)_dbLink.CRMspLkNoAvWSSelectDocFromNoAv(docType, comDbName, whDbName, kindDraft, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, noAvCodeStore)), (Func<CRMspLkNoAvWSSelectDocFromNoAv_Result, long?>)((CRMspLkNoAvWSSelectDocFromNoAv_Result m) => m.RowNumber)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = ((docType == 1 || docType == 3) ? new int?((item2.DocNumber != null) ? int.Parse(item2.DocNumber) : 0) : item2.Id).GetValueOrDefault(),
					Selected = !item2.DocId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					foreach (OtherSystemSelectedViewModel item3 in list2)
					{
						foreach (OtherSystemSelectedViewModel item4 in list)
						{
							if (item4.Row == item3.Row)
							{
								item4.Selected = item3.Selected;
							}
						}
					}
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
	public JsonResult GetNoAvDatabase(string dbName)
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
			List<CRMspLkNoAvSelectDbNames_Result> list2 = Enumerable.ToList<CRMspLkNoAvSelectDbNames_Result>((IEnumerable<CRMspLkNoAvSelectDbNames_Result>)_dbLink.CRMspLkNoAvSelectDbNames(dbName));
			list.AddRange(Enumerable.Select<CRMspLkNoAvSelectDbNames_Result, SelectListItem>((IEnumerable<CRMspLkNoAvSelectDbNames_Result>)list2, (Func<CRMspLkNoAvSelectDbNames_Result, SelectListItem>)((CRMspLkNoAvSelectDbNames_Result item) => new SelectListItem
			{
				Text = item.name,
				Value = item.name,
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DatabaseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvStore(string dbName)
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
			List<mct_CRMspLkNoAvSelectStore_Result> list2 = Enumerable.ToList<mct_CRMspLkNoAvSelectStore_Result>((IEnumerable<mct_CRMspLkNoAvSelectStore_Result>)_dbLink.mfi_CRMspLkNoAvSelectStore(dbName));
			list.AddRange(Enumerable.Select<mct_CRMspLkNoAvSelectStore_Result, SelectListItem>((IEnumerable<mct_CRMspLkNoAvSelectStore_Result>)list2, (Func<mct_CRMspLkNoAvSelectStore_Result, SelectListItem>)((mct_CRMspLkNoAvSelectStore_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.Code.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StoreList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetWareHouse()
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
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
			if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)list))
			{
				list[0].Selected = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompany(string value = "")
	{
		List<CRMspMainSearchWeb_Result> data = new List<CRMspMainSearchWeb_Result>();
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
			data = Enumerable.ToList<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_db_I.CRMspMainSearchWeb(value, UserLogin.CurrentUser.UserId, 1, lCID, result, ",1000,1,2,3,8,9,11,12,14,17,20,21,22,", result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCompanyPerson(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyPersons_Result> list = new List<CRMspSelectCompanyPersons_Result>();
		try
		{
			List<CRMspSelectCompanyPersons_Result> list2 = CRMIdeal.Classes.Helper.Company.SelectCompanyPersons(cmpId);
			list.Add(new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = -1,
				PersonName = Labels.SelectedListDefValue
			});
			list.AddRange(Enumerable.Select<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>((IEnumerable<CRMspSelectCompanyPersons_Result>)list2, (Func<CRMspSelectCompanyPersons_Result, CRMspSelectCompanyPersons_Result>)((CRMspSelectCompanyPersons_Result item) => new CRMspSelectCompanyPersons_Result
			{
				CompanyPersonID = item.CompanyPersonID,
				PersonName = item.PersonTitleName
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetProject(int cmpId)
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
			List<CRMspSelectCrmProjectBycmpAndUser_Result> list2 = Enumerable.ToList<CRMspSelectCrmProjectBycmpAndUser_Result>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)_db.CRMspSelectCrmProjectBycmpAndUser(cmpId, UserLogin.CurrentUser.UserId, lCID, result, result2));
			list.Add(new SelectListItem
			{
				Text = Labels.SelectedListDefValue,
				Value = "-1",
				Selected = true
			});
			list.AddRange(Enumerable.Select<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>((IEnumerable<CRMspSelectCrmProjectBycmpAndUser_Result>)list2, (Func<CRMspSelectCrmProjectBycmpAndUser_Result, SelectListItem>)((CRMspSelectCrmProjectBycmpAndUser_Result item) => new SelectListItem
			{
				Text = item.prjTitle,
				Value = item.ProjectID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ProjectList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult NoAvIssueDocFirstQtyPeriod()
	{
		GetDocOpr(1);
		GetWareHouse();
		return View();
	}

	[AjaxOnly]
	public string ActNoAvIssueDocFirstQtyPeriod(int docOprId, int whId, int cmpId, int prsId, int prjId, string comDbName, string whDbName, int noAvCodeStore)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDoc", "actImportFromAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			ObjectParameter objectParameter = new ObjectParameter("insertedDocId", 0);
			ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
			_dbLink.CRMspLkNoAvWSIssueDocFirstQtyPeriodFromNoAv(docOprId, whId, cmpId, prsId, prjId, comDbName, whDbName, noAvCodeStore, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, objectParameter2, centerId);
			if (objectParameter2.Value != null)
			{
				if (!string.IsNullOrEmpty(objectParameter2.Value.ToString()))
				{
					text = objectParameter2.Value.ToString();
				}
				else
				{
					string text2 = "";
					if (objectParameter.Value != null)
					{
						text2 = objectParameter.Value.ToString() ?? "";
					}
					text = "1|" + text2;
				}
			}
			else
			{
				string text3 = "";
				if (objectParameter.Value != null)
				{
					text3 = objectParameter.Value.ToString() ?? "";
				}
				text = "1|" + text3;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[LoginAuthorize]
	public ActionResult NoAvIIImportDoc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actImportFromAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actImportFromAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actImportFromAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		GetWrhsLinked(withWrhsLinkAccWhId: false, withWrhsLinkAccWhCode: true);
		GetUserLinked(withLinkAccUserIdStr: false, withLinkAccUserCode: true);
		GetCrmFinancialPeriod();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvIIImportDoc_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string noavUserId = "", string noavWhId = "", int crmFPId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<NoAvaranIIDocInfoViewModel> list = new List<NoAvaranIIDocInfoViewModel>();
		try
		{
			string text = new ServiceSoapClient().ReadFromInputDateRange(fDate, tDate, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("[") >= 0)
			{
				List<NoAvaranIIDocInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranIIDocInfoViewModel>>(text);
				if (list2 != null)
				{
					List<CRMspLkNoAvIIWSSelectDoc_Result> list3 = Enumerable.ToList<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)_dbLink.CRMspLkNoAvIIWSSelectDoc(crmFPId, lCID, result));
					int num = 1;
					foreach (NoAvaranIIDocInfoViewModel item in list2)
					{
						if (list.FindIndex((NoAvaranIIDocInfoViewModel x) => x.Doc_No == item.Doc_No) >= 0)
						{
							continue;
						}
						NoAvaranIIDocInfoViewModel doc = new NoAvaranIIDocInfoViewModel();
						doc.Doc_No = item.Doc_No;
						doc.Store = item.Store;
						doc.Doc_date = item.Doc_date;
						doc.Conf_Quan = item.Conf_Quan;
						doc.Cost = item.Cost;
						doc.Price = item.Price;
						doc.Quan2 = item.Quan2;
						doc.Quan3 = item.Quan3;
						doc.Shop_Code = item.Shop_Code;
						doc.Shop_Name = item.Shop_Name;
						doc.Code = item.Code;
						doc.KalaNAme = item.KalaNAme;
						doc.Unitname = item.Unitname;
						doc.SourceName = item.SourceName;
						string text2 = item.Doc_date;
						DateTime doc_DateTime = default(DateTime);
						string text3 = "";
						try
						{
							if (!string.IsNullOrEmpty(text2))
							{
								text3 = PersianDate.GetFormatetdDate(text2.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									text2 = doc_DateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									text2 = doc_DateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									text2 = doc_DateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							base.ViewBag.Error = Messages.WrongDateTime;
						}
						if (text2 != null)
						{
							text2 = text2.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						doc.Doc_DatePersian = text2;
						doc.Doc_DateTime = doc_DateTime;
						if (list3 != null && Enumerable.Any<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list3))
						{
							CRMspLkNoAvIIWSSelectDoc_Result cRMspLkNoAvIIWSSelectDoc_Result = Enumerable.FirstOrDefault<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list3, (Func<CRMspLkNoAvIIWSSelectDoc_Result, bool>)((CRMspLkNoAvIIWSSelectDoc_Result m) => m.DocLinkAccDocNumber == doc.Doc_No));
							if (cRMspLkNoAvIIWSSelectDoc_Result != null)
							{
								doc.DocId = cRMspLkNoAvIIWSSelectDoc_Result.DocID;
							}
						}
						doc.RowNumber = num;
						list.Add(doc);
						num++;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get list from NoAvII) ");
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult NoAvIIImportInfo(string records = "", string fDate = "", string tDate = "", int docOprId = 0, string noavUserId = "", string noavWhId = "", int crmFPId = 0)
	{
		//IL_00e5: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<NoAvaranIIDocInfoViewModel> list3 = new List<NoAvaranIIDocInfoViewModel>();
			string text2 = new ServiceSoapClient().ReadFromInputDateRange(fDate, tDate, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				if (text2.IndexOf("[") >= 0)
				{
					List<NoAvaranIIDocInfoViewModel> list4 = JsonConvert.DeserializeObject<List<NoAvaranIIDocInfoViewModel>>(text2);
					if (list4 != null)
					{
						List<CRMspLkNoAvIIWSSelectDoc_Result> list5 = Enumerable.ToList<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)_dbLink.CRMspLkNoAvIIWSSelectDoc(crmFPId, lCID, result));
						foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
						{
							if (list3.FindIndex((NoAvaranIIDocInfoViewModel f) => f.Doc_No == SelectedRowitem.Id) >= 0)
							{
								continue;
							}
							foreach (NoAvaranIIDocInfoViewModel item in Enumerable.ToList<NoAvaranIIDocInfoViewModel>(Enumerable.Where<NoAvaranIIDocInfoViewModel>((IEnumerable<NoAvaranIIDocInfoViewModel>)list4, (Func<NoAvaranIIDocInfoViewModel, bool>)((NoAvaranIIDocInfoViewModel w) => w.Doc_No == SelectedRowitem.Id))))
							{
								if (list5 != null && Enumerable.Any<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list5))
								{
									CRMspLkNoAvIIWSSelectDoc_Result cRMspLkNoAvIIWSSelectDoc_Result = Enumerable.FirstOrDefault<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list5, (Func<CRMspLkNoAvIIWSSelectDoc_Result, bool>)((CRMspLkNoAvIIWSSelectDoc_Result m) => m.DocLinkAccDocNumber == item.Doc_No));
									if (cRMspLkNoAvIIWSSelectDoc_Result != null)
									{
										item.DocLinkAccCode = cRMspLkNoAvIIWSSelectDoc_Result.DocLinkAccDocNumber;
									}
								}
								if (!string.IsNullOrWhiteSpace(item.Doc_date))
								{
									item.Doc_DateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.Doc_date.Replace("/", "")) + " 23:59:59", lCID switch
									{
										1025 => new CultureInfo("ar-SA"), 
										1065 => new PersianCulture(), 
										_ => new CultureInfo("en-US"), 
									});
									item.Doc_DatePersian = item.Doc_DateTime.ToString("yyyyMMdd", new PersianCulture());
									item.Doc_Time = item.Doc_DateTime.ToString("hh:mm:ss", new PersianCulture());
								}
								list3.Add(item);
							}
						}
					}
					else
					{
						string text3 = Messages.msgErrorRunFunction + " (get list from NoAvII) ";
						Exception e = new Exception(text3);
						ErrorSignal.FromCurrentContext().Raise(e);
						text = text3;
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + text2 + ") ";
				}
			}
			if (list3 != null && Enumerable.Any<NoAvaranIIDocInfoViewModel>((IEnumerable<NoAvaranIIDocInfoViewModel>)list3))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkNoAvIIWSIssueDocFromNoAvII(json, docOprId, 0, userId, value2, crmFPId, result2, value, registerDatePersian, appType, result, objectParameter, centerId);
				if (objectParameter.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
					{
						text = text + "<br>" + objectParameter.Value.ToString();
					}
					else
					{
						int count = 100;
						ProgressHub.SendMessage("ok", count, userId);
					}
				}
				else
				{
					int count2 = 100;
					ProgressHub.SendMessage("ok", count2, userId);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetNoAvIIImportDocList(string records, string fDate = "", string tDate = "", string noavUserId = "", string noavWhId = "", int crmFPId = 0)
	{
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		List<NoAvaranIIDocInfoViewModel> list2 = new List<NoAvaranIIDocInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			string text = new ServiceSoapClient().ReadFromInputDateRange(fDate, tDate, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("[") >= 0)
			{
				List<NoAvaranIIDocInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranIIDocInfoViewModel>>(text);
				if (list3 != null)
				{
					List<CRMspLkNoAvIIWSSelectDoc_Result> list4 = Enumerable.ToList<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)_dbLink.CRMspLkNoAvIIWSSelectDoc(crmFPId, lCID, result));
					int num = 1;
					foreach (NoAvaranIIDocInfoViewModel item in list3)
					{
						if (list2.FindIndex((NoAvaranIIDocInfoViewModel x) => x.Doc_No == item.Doc_No) >= 0)
						{
							continue;
						}
						NoAvaranIIDocInfoViewModel doc = new NoAvaranIIDocInfoViewModel();
						doc.Doc_No = item.Doc_No;
						doc.Store = item.Store;
						doc.Doc_date = item.Doc_date;
						doc.Conf_Quan = item.Conf_Quan;
						doc.Cost = item.Cost;
						doc.Price = item.Price;
						doc.Quan2 = item.Quan2;
						doc.Quan3 = item.Quan3;
						doc.Shop_Code = item.Shop_Code;
						doc.Shop_Name = item.Shop_Name;
						doc.Code = item.Code;
						doc.KalaNAme = item.KalaNAme;
						doc.Unitname = item.Unitname;
						doc.SourceName = item.SourceName;
						string text2 = item.Doc_date;
						DateTime doc_DateTime = default(DateTime);
						string text3 = "";
						try
						{
							if (!string.IsNullOrEmpty(text2))
							{
								text3 = PersianDate.GetFormatetdDate(text2.Replace("/", ""));
								switch (lCID)
								{
								case 1065:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
									text2 = doc_DateTime.ToString("yyyyMMdd");
									break;
								case 1025:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
									text2 = doc_DateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								default:
									doc_DateTime = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
									text2 = doc_DateTime.ToString("yyyyMMdd", new PersianCulture());
									break;
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							base.ViewBag.Error = Messages.WrongDateTime;
						}
						if (text2 != null)
						{
							text2 = text2.Replace("/", "").Replace("-", "").Replace("_", "")
								.Replace(".", "")
								.Replace(",", "")
								.Replace("\\", "");
						}
						doc.Doc_DatePersian = text2;
						doc.Doc_DateTime = doc_DateTime;
						if (list4 != null && Enumerable.Any<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list4))
						{
							CRMspLkNoAvIIWSSelectDoc_Result cRMspLkNoAvIIWSSelectDoc_Result = Enumerable.FirstOrDefault<CRMspLkNoAvIIWSSelectDoc_Result>((IEnumerable<CRMspLkNoAvIIWSSelectDoc_Result>)list4, (Func<CRMspLkNoAvIIWSSelectDoc_Result, bool>)((CRMspLkNoAvIIWSSelectDoc_Result m) => m.DocLinkAccDocNumber == doc.Doc_No));
							if (cRMspLkNoAvIIWSSelectDoc_Result != null)
							{
								doc.DocId = cRMspLkNoAvIIWSSelectDoc_Result.DocID;
							}
						}
						doc.RowNumber = num;
						list2.Add(doc);
						num++;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.msgErrorRunFunction + " (get list from NoAvII) ");
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			foreach (NoAvaranIIDocInfoViewModel item3 in list2)
			{
				OtherSystemSelectedVIiewModel item2 = new OtherSystemSelectedVIiewModel
				{
					Row = item3.RowNumber,
					Id = (item3.Doc_No ?? "0"),
					Selected = (item3.DocId == 0)
				};
				list.Add(item2);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list5 = new List<OtherSystemSelectedVIiewModel>();
				list5 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list5))
				{
					foreach (OtherSystemSelectedVIiewModel item4 in list5)
					{
						foreach (OtherSystemSelectedVIiewModel item5 in list)
						{
							if (item5.Row == item4.Row)
							{
								item5.Selected = item4.Selected;
							}
						}
					}
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[LoginAuthorize]
	public ActionResult NoAvIIIssueDocFirstQtyPeriod()
	{
		string actionName = "actImportFromAcc";
		if (!UserLogin.IsUserAccess("frmDoc", actionName, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		GetDocOpr(1);
		GetWareHouse();
		GetUserLinked(withLinkAccUserIdStr: false, withLinkAccUserCode: true);
		return View();
	}

	[AjaxOnly]
	public string ActNoAvIIIssueDocFirstQtyPeriod(int docOprId, int whId, int cmpId, int prsId, int prjId, string noavUserId = "")
	{
		string result = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmDoc", "actImportFromAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			string text = "";
			WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
			List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, languageID: lCID, defaultLanguageID: result2, withWrhsLinkAccWareHouses: false));
			if (list != null)
			{
				wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
			}
			if (wSspSelectWareHouseWithAccLinkField_Result != null)
			{
				text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode ?? "";
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				return string.Format(Messages.msgErrorIsNotFound, string.Format(Labels.OtherSystemsAccWarehouse, Labels.NoAvaranII));
			}
			List<NoAvaranIIDocFirstQtyPeriodInfoViewModel> list2 = new List<NoAvaranIIDocFirstQtyPeriodInfoViewModel>();
			string text2 = new ServiceSoapClient().ReadFromAvalDoreh(text, string.Empty, noavUserId);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				if (text2.IndexOf("[") < 0)
				{
					return Messages.msgErrorRunProcedure + "<br>" + text2;
				}
				list2 = JsonConvert.DeserializeObject<List<NoAvaranIIDocFirstQtyPeriodInfoViewModel>>(text2);
			}
			if (list2 != null && Enumerable.Any<NoAvaranIIDocFirstQtyPeriodInfoViewModel>((IEnumerable<NoAvaranIIDocFirstQtyPeriodInfoViewModel>)list2))
			{
				string itemJson = JsonConvert.SerializeObject(list2);
				ObjectParameter objectParameter = new ObjectParameter("insertedDocId", 0);
				ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkNoAvIIWSIssueDocFirstQtyPeriodFromNoAvII(itemJson, docOprId, whId, cmpId, prsId, prjId, userId, value2, id, value, registerDatePersian, appType, result2, objectParameter, objectParameter2, centerId);
				if (objectParameter2.Value != null)
				{
					if (!string.IsNullOrEmpty(objectParameter2.Value.ToString()))
					{
						result = objectParameter2.Value.ToString();
					}
					else
					{
						string text3 = "";
						if (objectParameter.Value != null)
						{
							text3 = objectParameter.Value.ToString() ?? "";
						}
						result = "1|" + text3;
					}
				}
				else
				{
					string text4 = "";
					if (objectParameter.Value != null)
					{
						text4 = objectParameter.Value.ToString() ?? "";
					}
					result = "1|" + text4;
				}
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Messages.msgErrorRunFunction + "|";
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult ShygunImportDoc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actImportFromAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actImportFromAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actImportFromAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	public ShygunDocInfoViewModelObjects GetShygunDocList(int docOprType = 1, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		//IL_09e9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ee: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunDocInfoViewModelObjects shygunDocInfoViewModelObjects = new ShygunDocInfoViewModelObjects();
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
			List<ShygunDocInfoViewModel> list = new List<ShygunDocInfoViewModel>();
			List<WSspSelectDocWithAccLinkField_Result> list2 = SelectDocWithAccLinkField(docOprType, withDocLinkAccCode: false, withDocLinkAccCodeId: false, withDocLinkAccDocId: false, withDocLinkAccDocIdStr: true, withDocLinkAccDocNumber: true);
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			DomainInvoiceHeader domainInvoiceHeader = new DomainInvoiceHeader();
			domainInvoiceHeader.InvoiceDate.From = dateTime.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceDate.To = dateTime2.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceType.From = fOrderType.ToString();
			domainInvoiceHeader.InvoiceType.To = tOrderType.ToString();
			domainInvoiceHeader.Printed.From = fPrinted.ToString();
			domainInvoiceHeader.Printed.To = tPrinted.ToString();
			domainInvoiceHeader.InvoiceNumber.From = ((fNumber == "0" || string.IsNullOrWhiteSpace(fNumber)) ? "" : fNumber);
			domainInvoiceHeader.InvoiceNumber.To = ((tNumber == "0" || string.IsNullOrWhiteSpace(tNumber)) ? "" : tNumber);
			string text = shygunSetting.IP;
			if (string.IsNullOrWhiteSpace(text))
			{
				Exception e = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			HttpClient httpClient = new HttpClient();
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text2 = "api/Invoice/Get";
			text2 = text2 + "?RowStart=" + fromRec + "&RowCount=" + recCount;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvParamViewModel
			{
				Config = shygunSetting.conf,
				Domain = domainInvoiceHeader,
				StartVersion = "0"
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(text2, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvResultViewModel shygunApiGetInvResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetInvResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (shygunApiGetInvResultViewModel != null && shygunApiGetInvResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel>)shygunApiGetInvResultViewModel.Result))
				{
					foreach (CRMIdeal.Classes.Helper.OtherSystems.ShygunInvoiceViewModel item in shygunApiGetInvResultViewModel.Result)
					{
						ShygunDocInfoViewModel shygunDocInfoViewModel = new ShygunDocInfoViewModel();
						shygunDocInfoViewModel.InvTyp = item.InvTyp;
						shygunDocInfoViewModel.InvNo = item.InvNo;
						shygunDocInfoViewModel.AccountGuId = item.AccountGuId;
						shygunDocInfoViewModel.JobCostingGuId = item.JobCostingGuId;
						shygunDocInfoViewModel.InvDescription = item.InvDescription;
						shygunDocInfoViewModel.InvDate = item.InvDate;
						shygunDocInfoViewModel.InvPayDue = item.InvPayDue;
						shygunDocInfoViewModel.AccountNumber = item.AccountNumber;
						shygunDocInfoViewModel.AccountName = item.AccountName;
						shygunDocInfoViewModel.JobCostingNumber = item.JobCostingNumber;
						shygunDocInfoViewModel.JobCostingName = item.JobCostingName;
						shygunDocInfoViewModel.CurrencyAbb1 = item.CurrencyAbb1;
						shygunDocInfoViewModel.SAccountGuId = item.SAccountGuId;
						shygunDocInfoViewModel.SJobGuId = item.SJobGuId;
						shygunDocInfoViewModel.bijak = item.bijak;
						shygunDocInfoViewModel.GuId = item.GuId;
						if (item.CreatedDate.HasValue)
						{
							shygunDocInfoViewModel.CreatedDate = item.CreatedDate;
							shygunDocInfoViewModel.CreatedDatePersian = (item.CreatedDate ?? DateTime.Now).ToString("yyyy/MM/dd", new PersianCulture());
						}
						else
						{
							shygunDocInfoViewModel.CreatedDate = null;
							shygunDocInfoViewModel.CreatedDatePersian = "";
						}
						shygunDocInfoViewModel.GeneralRef = item.GeneralRef;
						shygunDocInfoViewModel.SAccountNumber = item.SAccountNumber;
						shygunDocInfoViewModel.SJobNumber = item.SJobNumber;
						shygunDocInfoViewModel.DiscountPercent = item.DiscountPercent;
						shygunDocInfoViewModel.DiscAmount = item.DiscAmount;
						shygunDocInfoViewModel.DepartmentNumber = item.DepartmentNumber;
						shygunDocInfoViewModel.ST1Number = item.ST1Number;
						shygunDocInfoViewModel.ST1GuId = item.ST1GuId;
						shygunDocInfoViewModel.ST2Number = item.ST2Number;
						shygunDocInfoViewModel.ST2GuId = item.ST2GuId;
						shygunDocInfoViewModel.AtfNumber = item.AtfNumber;
						shygunDocInfoViewModel.AtfGuId = item.AtfGuId;
						item.InvNo.ToString();
						string InvGuId = item.GuId.ToString();
						WSspSelectDocWithAccLinkField_Result wSspSelectDocWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list2, (Func<WSspSelectDocWithAccLinkField_Result, bool>)((WSspSelectDocWithAccLinkField_Result x) => x.DocLinkAccDocIdStr == InvGuId));
						if (wSspSelectDocWithAccLinkField_Result != null && wSspSelectDocWithAccLinkField_Result.DocID > 0)
						{
							shygunDocInfoViewModel.DocId = wSspSelectDocWithAccLinkField_Result.DocID;
						}
						List<ShygunDocBodyInfoViewModel> list3 = new List<ShygunDocBodyInfoViewModel>();
						shygunDocInfoViewModel.BodyCount = 0;
						if (item.Body != null && item.Body.Count > 0)
						{
							foreach (InvoiceBody item2 in item.Body)
							{
								ShygunDocBodyInfoViewModel shygunDocBodyInfoViewModel = new ShygunDocBodyInfoViewModel();
								shygunDocBodyInfoViewModel.InvNo = shygunDocInfoViewModel.InvNo;
								shygunDocBodyInfoViewModel.InvGuId = shygunDocInfoViewModel.GuId;
								shygunDocBodyInfoViewModel.LineItemId = item2.LineItemId;
								shygunDocBodyInfoViewModel.InvHeaderId = item2.InvHeaderId;
								shygunDocBodyInfoViewModel.LineItemOrder = item2.LineItemOrder;
								shygunDocBodyInfoViewModel.ItemNumber = item2.ItemNumber;
								shygunDocBodyInfoViewModel.STNumber = item2.STNumber;
								shygunDocBodyInfoViewModel.STDesc = item2.STDesc;
								shygunDocBodyInfoViewModel.STGuId = item2.STGuId;
								shygunDocBodyInfoViewModel.ItemGuId = item2.ItemGuId;
								shygunDocBodyInfoViewModel.Quan = item2.Quan;
								shygunDocBodyInfoViewModel.Quan2 = item2.Quan2;
								shygunDocBodyInfoViewModel.Price = item2.Price;
								shygunDocBodyInfoViewModel.Price2 = item2.Price2;
								shygunDocBodyInfoViewModel.Amount = item2.Amount;
								shygunDocBodyInfoViewModel.AmortizePercent = item2.AmortizePercent;
								shygunDocBodyInfoViewModel.LineDiscAmount = item2.LineDiscAmount;
								shygunDocBodyInfoViewModel.LineDiscPer = item2.LineDiscPer;
								shygunDocBodyInfoViewModel.LineItemDesc = item2.LineItemDesc;
								shygunDocBodyInfoViewModel.ReturnRial = item2.ReturnRial;
								shygunDocBodyInfoViewModel.OrderRemain1 = item2.OrderRemain1;
								shygunDocBodyInfoViewModel.OrderRemain2 = item2.OrderRemain2;
								shygunDocBodyInfoViewModel.FinalOrderQuan = item2.FinalOrderQuan;
								shygunDocBodyInfoViewModel.FinalOrderQuan2 = item2.FinalOrderQuan2;
								shygunDocBodyInfoViewModel.AccountName = shygunDocInfoViewModel.AccountName;
								shygunDocBodyInfoViewModel.AccountNumber = shygunDocInfoViewModel.AccountNumber;
								shygunDocBodyInfoViewModel.AccountGuId = shygunDocInfoViewModel.AccountGuId;
								shygunDocBodyInfoViewModel.DocId = shygunDocInfoViewModel.DocId;
								shygunDocBodyInfoViewModel.RowNumber = list3.Count + 1;
								list3.Add(shygunDocBodyInfoViewModel);
							}
							shygunDocInfoViewModel.BodyCount = list3.Count;
						}
						shygunDocInfoViewModel.Body = list3;
						List<ShygunDocExpenseViewModel> list4 = new List<ShygunDocExpenseViewModel>();
						shygunDocInfoViewModel.ExpenseCount = 0;
						if (item.Expense != null && item.Expense.Count > 0)
						{
							foreach (InvoiceExpense item3 in item.Expense)
							{
								ShygunDocExpenseViewModel shygunDocExpenseViewModel = new ShygunDocExpenseViewModel();
								shygunDocExpenseViewModel.InvExpRowId = item3.InvExpRowId;
								shygunDocExpenseViewModel.InvExpRowOrder = item3.InvExpRowOrder;
								shygunDocExpenseViewModel.InvHeaderId = item3.InvHeaderId;
								shygunDocExpenseViewModel.AccountGuId = item3.AccountGuId;
								shygunDocExpenseViewModel.JobCostingGuId = item3.JobCostingGuId;
								shygunDocExpenseViewModel.AccountNumber = item3.AccountNumber;
								shygunDocExpenseViewModel.AccountName = item3.AccountName;
								shygunDocExpenseViewModel.JobCostingNumber = item3.JobCostingNumber;
								shygunDocExpenseViewModel.InvExpRowDesc = item3.InvExpRowDesc;
								shygunDocExpenseViewModel.InvExpRowAmount = item3.InvExpRowAmount;
								shygunDocExpenseViewModel.SecondAccountNumber = item3.SecondAccountNumber;
								shygunDocExpenseViewModel.SecondAccountName = item3.SecondAccountName;
								shygunDocExpenseViewModel.SecondJobCostingGuId = item3.SecondJobCostingGuId;
								shygunDocExpenseViewModel.SecondAccountGuId = item3.SecondAccountGuId;
								shygunDocExpenseViewModel.SecondJobCostingNumber = item3.SecondJobCostingNumber;
								shygunDocExpenseViewModel.FixCostType = item3.FixCostType;
								shygunDocExpenseViewModel.DocId = shygunDocInfoViewModel.DocId;
								shygunDocExpenseViewModel.InvGuId = shygunDocInfoViewModel.GuId;
								shygunDocExpenseViewModel.RowNumber = list4.Count + 1;
								list4.Add(shygunDocExpenseViewModel);
							}
							shygunDocInfoViewModel.ExpenseCount = list4.Count;
						}
						shygunDocInfoViewModel.Expense = list4;
						shygunDocInfoViewModel.RowNumber = list.Count + 1;
						list.Add(shygunDocInfoViewModel);
					}
				}
			}
			else
			{
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				Exception e2 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			shygunDocInfoViewModelObjects.lst = list;
			shygunDocInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunDocInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return shygunDocInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunImportDoc_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		List<ShygunDocInfoViewModel> list = new List<ShygunDocInfoViewModel>();
		ShygunDocInfoViewModelObjects shygunDocList = GetShygunDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount);
		if (shygunDocList != null)
		{
			list = shygunDocList.lst;
			if (list != null && Enumerable.Any<ShygunDocInfoViewModel>((IEnumerable<ShygunDocInfoViewModel>)list))
			{
				foreach (ShygunDocInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.InvDate))
					{
						DateTime dateTime = default(DateTime);
						item.InvDate = item.InvDate.Replace("-", "/");
						item.InvDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy/MM/dd");
					}
				}
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunImportDocList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunDocInfoViewModel item2 in GetShygunDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.GuId.ToString(),
					Selected = (item2.DocId <= 0)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunImportInfo(string records, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int oprId = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunDocInfoViewModel> list3 = new List<ShygunDocInfoViewModel>();
			List<ShygunDocInfoViewModel> lst = GetShygunDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst;
			if (list != null)
			{
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list)
				{
					ShygunDocInfoViewModel shygunDocInfoViewModel = Enumerable.FirstOrDefault<ShygunDocInfoViewModel>(Enumerable.Where<ShygunDocInfoViewModel>((IEnumerable<ShygunDocInfoViewModel>)lst, (Func<ShygunDocInfoViewModel, bool>)((ShygunDocInfoViewModel w) => w.GuId.ToString() == SelectedRowitem.Id)));
					if (shygunDocInfoViewModel != null)
					{
						list3.Add(shygunDocInfoViewModel);
					}
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from Shygun) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			if (list3 != null && Enumerable.Any<ShygunDocInfoViewModel>((IEnumerable<ShygunDocInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list4 = new CompanyController().SelectCompanyWithAccLinkField(withLinkAccCode: true);
				CRMLinkSpEntities dbLink = _dbLink;
				bool? flag = true;
				List<WSspSelectWareHouseWithAccLinkField_Result> list5 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)dbLink.WSspSelectWareHouseWithAccLinkField(false, flag, false, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: false));
				ObjectResult<WSspSelectOrderWithAccLinkField_Result> objectResult = _dbLink.WSspSelectOrderWithAccLinkField(withOrdLinkAccCode: false, withOrdLinkAccCodeId: false, withOrdLinkAccOrderId: false, withOrdLinkAccOrderIdStr: false, withOrdLinkAccOrderNumber: true, withOrdLinkAccVoucherId: false, withOrdLinkAccVoucherNumber: false, languageID: lCID, defaultLanguageID: result, linkAccSettingDBId: null);
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				foreach (ShygunDocInfoViewModel item in list3)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCode == item.AccountNumber));
					if ((cRMspSelectCompanyWithAccLinkField_Result == null || cRMspSelectCompanyWithAccLinkField_Result.CompanyID <= 0) && docOprType != 3)
					{
						text = Messages.CompanyNotFound;
						continue;
					}
					int value4 = 0;
					int num2 = 0;
					if (item.Body != null && item.BodyCount > 0)
					{
						foreach (ShygunDocBodyInfoViewModel bd in item.Body)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == bd.STNumber));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								value4 = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							}
							else
							{
								text = text + Messages.msgErrorDocItemIsEmpty + " | ";
							}
						}
					}
					else
					{
						text = Messages.msgErrorDocItemIsEmpty;
					}
					if (docOprType == 3)
					{
						WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == item.ST1Number));
						if (wSspSelectWareHouseWithAccLinkField_Result2 != null && wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID > 0)
						{
							num2 = wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID;
						}
						else
						{
							text = text + string.Format(Messages.msgErrorImportOtherSystemFieldIsNull, Labels.OtherSystemImportMovementWHId) + " | ";
						}
						wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == item.ST2Number));
						if (wSspSelectWareHouseWithAccLinkField_Result2 != null && wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID > 0)
						{
							num2 = wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID;
						}
						else
						{
							text = text + string.Format(Messages.msgErrorImportOtherSystemFieldIsNull, Labels.OtherSystemImportMovementWHIdI) + " | ";
						}
					}
					string InvNo = item.InvNo.ToString();
					Enumerable.FirstOrDefault<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)objectResult, (Func<WSspSelectOrderWithAccLinkField_Result, bool>)((WSspSelectOrderWithAccLinkField_Result x) => x.ordLinkAccOrderNumber == InvNo));
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					DateTime now2 = DateTime.Now;
					string text3 = "";
					now2 = (string.IsNullOrWhiteSpace(item.InvDate) ? (item.CreatedDate ?? DateTime.Now) : DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate.Replace("-", "/")) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None));
					text3 = now2.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedId", 0);
					_dbLink.CRMspLkShygunWSInsertUpdateDoc(shygunSetting.DefPrjTitle, shygunSetting.DefPrjCvnsStatusGroupId, InvNo, item.DocId, oprId, null, null, null, item.InvDescription, 0, value4, null, null, null, null, null, null, item.bijak, null, (num2 > 0) ? new int?(num2) : null, cRMspSelectCompanyWithAccLinkField_Result.CompanyID, null, null, null, null, null, null, item.GuId.ToString(), item.InvNo.ToString(), null, null, null, text3, now2, userId, value3, id, value2, value, registerDatePersian, appType, lCID, result, objectParameter2, objectParameter, (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture()), (item.CreatedDate ?? DateTime.Now).ToString("hh:MM:ss"), item.CreatedDate ?? DateTime.Now, userId, centerId);
					if (objectParameter2 == null || string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()) || objectParameter2.Value.ToString() == "0")
					{
						text = text + "<br>" + Messages.msgErrorInsertDocNotSuccess;
						continue;
					}
					int result2 = 0;
					int.TryParse(objectParameter2.Value.ToString(), out result2);
					if (item.BodyCount <= 0)
					{
						continue;
					}
					foreach (ShygunDocBodyInfoViewModel item2 in item.Body)
					{
						item2.DocId = result2;
					}
					string json = JsonConvert.SerializeObject(item.Body);
					_dbLink.CRMspLkShygunWSInsertUpdateDocItems(json, shygunSetting.DefPrjTitle, shygunSetting.DefPrjCvnsStatusGroupId, userId, value3, value2, id, value, registerDatePersian, appType, lCID, result, objectParameter);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text = text + "<br>" + objectParameter.Value.ToString();
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[LoginAuthorize]
	public ActionResult ShygunExportDoc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actExportToAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actExportToAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actExportToAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunExportDoc_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		List<LkDocInfoViewModel> list = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
		if (list != null && Enumerable.Any<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list))
		{
			foreach (LkDocInfoViewModel item in list)
			{
				item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string ShygunActSendToAcc(int docId, string records, bool checkAction = true, int DocType = 1)
	{
		_003C_003Ec__DisplayClass42_0 _003C_003Ec__DisplayClass42_ = new _003C_003Ec__DisplayClass42_0();
		_003C_003Ec__DisplayClass42_.docId = docId;
		int num = -1;
		switch (DocType)
		{
		case 1:
			num = 5;
			break;
		case 2:
			num = 4;
			break;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectProductWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<WSspSelectWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			List<Invoice> list3 = new List<Invoice>();
			if (_003C_003Ec__DisplayClass42_.docId > 0)
			{
				_003C_003Ec__DisplayClass42_1 _003C_003Ec__DisplayClass42_2 = new _003C_003Ec__DisplayClass42_1();
				_003C_003Ec__DisplayClass42_2.doc = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_db_I.WSspSelectDocById(_003C_003Ec__DisplayClass42_.docId, lCID, result));
				if (_003C_003Ec__DisplayClass42_2.doc != null && _003C_003Ec__DisplayClass42_2.doc.DocID > 0)
				{
					string errorMessage = "";
					if (!Doc.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass42_.docId, ref errorMessage))
					{
						text = text + "<br>" + errorMessage;
						return text;
					}
					if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass42_2.doc.DocLinkAccDocNumber))
					{
						ShygunDocInfoViewModelObjects shygunDocList = GetShygunDocList(1, _003C_003Ec__DisplayClass42_2.doc.DocDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass42_2.doc.DocDateTime?.ToString("yyyy/MM/dd"), _003C_003Ec__DisplayClass42_2.doc.DocLinkAccDocNumber, _003C_003Ec__DisplayClass42_2.doc.DocLinkAccDocNumber, num, num);
						if (shygunDocList != null && shygunDocList.lst != null && shygunDocList.lst.Count > 0)
						{
							int InvNo = 0;
							int.TryParse(_003C_003Ec__DisplayClass42_2.doc.DocLinkAccDocNumber, out InvNo);
							ShygunDocInfoViewModel shygunDocInfoViewModel = Enumerable.FirstOrDefault<ShygunDocInfoViewModel>((IEnumerable<ShygunDocInfoViewModel>)shygunDocList.lst, (Func<ShygunDocInfoViewModel, bool>)((ShygunDocInfoViewModel x) => x.InvNo == InvNo));
							if (shygunDocInfoViewModel != null && shygunDocInfoViewModel.InvNo > 0)
							{
								text = text + string.Format(Messages.msgErrorDocAlreadyExistsInAccLink, _003C_003Ec__DisplayClass42_2.doc.DocNumber.ToString(), Labels.Shygun) + "|";
							}
						}
					}
					else
					{
						DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
						ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
						WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_2, typeof(_003C_003Ec__DisplayClass42_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSDoc2 != null)
						{
							_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
							wSDoc2.DocLinkAccCode = null;
							wSDoc2.DocLinkAccCodeId = null;
							wSDoc2.DocLinkAccDocId = null;
							wSDoc2.DocLinkAccDocIdStr = null;
							wSDoc2.DocLinkAccDocNumber = null;
							wSDoc2.DocLinkAccVoucherId = null;
							wSDoc2.DocLinkAccVoucherNumber = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					if (string.IsNullOrWhiteSpace(text))
					{
						CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass42_2.doc.CompanyId.GetValueOrDefault());
						if (companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
						{
							text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.Shygun);
						}
						else
						{
							Invoice invoice = new Invoice();
							invoice.AccountNumber = companyById.cmpLinkAccCode;
							invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
							invoice.InvTyp = num;
							invoice.GuId = _003C_003Ec__DisplayClass42_2.doc.GUId;
							invoice.UpdateKind = ActionType.insert;
							if (_003C_003Ec__DisplayClass42_2.doc.DocDateTime.HasValue)
							{
								invoice.InvDate = _003C_003Ec__DisplayClass42_2.doc.DocDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
							}
							if (_003C_003Ec__DisplayClass42_2.doc.FirstRegisterDate.HasValue)
							{
								invoice.CreatedDate = _003C_003Ec__DisplayClass42_2.doc.FirstRegisterDate;
							}
							List<InvoiceBody> list4 = new List<InvoiceBody>();
							List<WSspSelectDocItems_Result> list5 = Enumerable.ToList<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)_db.WSspSelectDocItems(_003C_003Ec__DisplayClass42_.docId, lCID, result));
							if (list5 != null && string.IsNullOrWhiteSpace(text))
							{
								using List<WSspSelectDocItems_Result>.Enumerator enumerator = list5.GetEnumerator();
								while (enumerator.MoveNext())
								{
									_003C_003Ec__DisplayClass42_3 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass42_3();
									CS_0024_003C_003E8__locals1.docI = enumerator.Current;
									WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list2, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.docI.WHId));
									if (wSspSelectWareHouse_Result == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr))
									{
										text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectWareHouse_Result.WrhsName ?? "", Labels.Shygun);
									}
									WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals1.docI.PrdId));
									if (wSspSelectProductWithAccLinkField_Result == null || string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
									{
										text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.Shygun);
									}
									if (string.IsNullOrWhiteSpace(text))
									{
										InvoiceBody invoiceBody = new InvoiceBody();
										invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
										invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
										double num2 = CS_0024_003C_003E8__locals1.docI.Quantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.docI.FCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals1.docI.FCRI.GetValueOrDefault(1.0);
										invoiceBody.Quan = ((num2 > 0.0) ? decimal.Parse(num2.ToString()) : 0m);
										invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals1.docI.Description;
										invoiceBody.STGuId = Guid.Parse(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr);
										invoiceBody.STDesc = wSspSelectWareHouse_Result.WrhsName;
										invoiceBody.GuId = Guid.NewGuid();
										invoiceBody.UpdateKind = ActionType.insert;
										DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
										ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "x");
										WSDocItems wSDocItems2 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass42_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (wSDocItems2 != null)
										{
											_dbTbl.Entry(wSDocItems2).State = EntityState.Modified;
											wSDocItems2.DocILinkAccItemIdStr = invoiceBody.GuId.ToString();
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
										list4.Add(invoiceBody);
									}
								}
							}
							invoice.Body = list4;
							list3.Add(invoice);
						}
					}
				}
			}
			if (list3 != null && list3.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunSetting.IP, shygunSetting.conf, list3).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					text = putResults.Result[0].ErrorMessage;
					if (string.IsNullOrWhiteSpace(text))
					{
						DbSet<WSDoc> wSDoc3 = _dbTbl.WSDoc;
						ParameterExpression val = Expression.Parameter(typeof(WSDoc), "m");
						WSDoc wSDoc4 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc3, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass42_, typeof(_003C_003Ec__DisplayClass42_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSDoc4 != null)
						{
							_dbTbl.Entry(wSDoc4).State = EntityState.Modified;
							wSDoc4.DocLinkAccDocNumber = putResults.Result[0].Number;
							wSDoc4.DocLinkAccCode = putResults.Result[0].GuId;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
						else
						{
							text = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsDoc + "|";
						}
					}
				}
				else
				{
					text += putResults.ErrorMessage;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunExportInfo(string records, int oprId, string fDate, string tDate, int value, int DocType = 1, int currentItemId = 0)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		int num = -1;
		switch (DocType)
		{
		case 1:
			num = 5;
			break;
		case 2:
			num = 4;
			break;
		case 3:
			num = 10;
			break;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			string text2 = "";
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
			List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<WSspSelectWareHouse_Result> list4 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			List<Invoice> list5 = new List<Invoice>();
			if (list != null)
			{
				foreach (OtherSystemSelectedViewModel item in list)
				{
					_003C_003Ec__DisplayClass43_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass43_1();
					CS_0024_003C_003E8__locals1.doc = Enumerable.FirstOrDefault<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list2, (Func<LkDocInfoViewModel, bool>)((LkDocInfoViewModel x) => x.DocID == item.Id));
					if (CS_0024_003C_003E8__locals1.doc == null || CS_0024_003C_003E8__locals1.doc.DocID <= 0)
					{
						continue;
					}
					string errorMessage = "";
					if (!Doc.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
					{
						text = text + "<br>" + errorMessage;
						continue;
					}
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr))
					{
						ShygunDocInfoViewModelObjects shygunDocList = GetShygunDocList(1, CS_0024_003C_003E8__locals1.doc.DocDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.doc.DocDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.doc.DocLinkAccDocNumber, CS_0024_003C_003E8__locals1.doc.DocLinkAccDocNumber, num, num);
						if (shygunDocList != null && shygunDocList.lst == null && !Enumerable.Any<ShygunDocInfoViewModel>((IEnumerable<ShygunDocInfoViewModel>)shygunDocList.lst))
						{
							DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
							ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
							WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDoc2 != null)
							{
								_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
								wSDoc2.DocLinkAccCode = null;
								wSDoc2.DocLinkAccDocNumber = null;
								wSDoc2.DocLinkAccDocIdStr = null;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
						}
					}
					else
					{
						DbSet<WSDoc> wSDoc3 = _dbTbl.WSDoc;
						ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
						WSDoc wSDoc4 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc3, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass43_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSDoc4 != null)
						{
							_dbTbl.Entry(wSDoc4).State = EntityState.Modified;
							wSDoc4.DocLinkAccCode = null;
							wSDoc4.DocLinkAccDocNumber = null;
							wSDoc4.DocLinkAccDocIdStr = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals1.doc.CompanyId.GetValueOrDefault());
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					if ((companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) && DocType != 3)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.Shygun);
						continue;
					}
					Invoice invoice = new Invoice();
					if (DocType != 3)
					{
						invoice.AccountNumber = companyById.cmpLinkAccCode;
						invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
					}
					else
					{
						invoice.AccountNumber = shygunSetting.DocMovementAccountNumber;
						invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(shygunSetting.DocMovementAccountGUId)) ? Guid.Parse(shygunSetting.DocMovementAccountGUId) : Guid.NewGuid());
					}
					invoice.InvTyp = num;
					invoice.GuId = CS_0024_003C_003E8__locals1.doc.GUId;
					invoice.InvDescription = CS_0024_003C_003E8__locals1.doc.Description ?? "";
					WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.doc.WHIdI));
					if ((wSspSelectWareHouse_Result == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr)) && DocType == 3)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, CS_0024_003C_003E8__locals1.doc.WHI ?? "", Labels.Shygun);
					}
					WSspSelectWareHouse_Result wSspSelectWareHouse_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.doc.WHId));
					if (wSspSelectWareHouse_Result2 == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr))
					{
						text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, CS_0024_003C_003E8__locals1.doc.WH ?? "", Labels.Shygun);
					}
					invoice.ST1Number = wSspSelectWareHouse_Result2.WrhsLinkAccWhCode;
					invoice.ST1GuId = Guid.Parse(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr);
					if (wSspSelectWareHouse_Result2 != null && DocType == 3)
					{
						invoice.ST1Number = wSspSelectWareHouse_Result.WrhsLinkAccWhCode;
						invoice.ST1GuId = Guid.Parse(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr);
						invoice.ST2Number = wSspSelectWareHouse_Result2.WrhsLinkAccWhCode;
						invoice.ST2GuId = Guid.Parse(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr);
					}
					invoice.UpdateKind = ActionType.insert;
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr))
					{
						invoice.GuId = Guid.Parse(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr);
						invoice.UpdateKind = ActionType.insertOrUpdate;
					}
					if (CS_0024_003C_003E8__locals1.doc.DocDateTime.HasValue)
					{
						invoice.InvDate = CS_0024_003C_003E8__locals1.doc.DocDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
					}
					if (CS_0024_003C_003E8__locals1.doc.FirstRegisterDate.HasValue)
					{
						invoice.CreatedDate = CS_0024_003C_003E8__locals1.doc.FirstRegisterDate;
					}
					List<InvoiceBody> list6 = new List<InvoiceBody>();
					List<WSspSelectDocItems_Result> list7 = Enumerable.ToList<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)_db.WSspSelectDocItems(CS_0024_003C_003E8__locals1.doc.DocID, lCID, result));
					if (list7 != null && string.IsNullOrWhiteSpace(text))
					{
						using List<WSspSelectDocItems_Result>.Enumerator enumerator2 = list7.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass43_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass43_2();
							CS_0024_003C_003E8__locals2.docI = enumerator2.Current;
							WSspSelectWareHouse_Result wSspSelectWareHouse_Result3 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals2.docI.WHId));
							if (wSspSelectWareHouse_Result3 == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result3.WrhsLinkAccWhIdStr))
							{
								text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectWareHouse_Result3.WrhsName ?? "", Labels.Shygun);
							}
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals2.docI.PrdId));
							if (wSspSelectProductWithAccLinkField_Result == null || string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
							{
								text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.Shygun);
							}
							if (string.IsNullOrWhiteSpace(text))
							{
								InvoiceBody invoiceBody = new InvoiceBody();
								invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
								invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
								double num2 = CS_0024_003C_003E8__locals2.docI.Quantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.docI.FCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.docI.FCRI.GetValueOrDefault(1.0);
								invoiceBody.Quan = ((num2 > 0.0) ? decimal.Parse(num2.ToString()) : 0m);
								invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals2.docI.Description;
								invoiceBody.STGuId = Guid.Parse(wSspSelectWareHouse_Result3.WrhsLinkAccWhIdStr);
								invoiceBody.STDesc = wSspSelectWareHouse_Result3.WrhsName;
								invoiceBody.ItemDescription = CS_0024_003C_003E8__locals2.docI.Description ?? "";
								invoiceBody.GuId = Guid.NewGuid();
								invoiceBody.UpdateKind = ActionType.insert;
								if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals2.docI.DocILinkAccItemIdStr))
								{
									invoiceBody.GuId = Guid.Parse(CS_0024_003C_003E8__locals2.docI.DocILinkAccItemIdStr);
									invoiceBody.UpdateKind = ActionType.insertOrUpdate;
								}
								DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
								ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "x");
								WSDocItems wSDocItems2 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass43_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSDocItems2 != null)
								{
									_dbTbl.Entry(wSDocItems2).State = EntityState.Modified;
									wSDocItems2.DocILinkAccItemIdStr = invoiceBody.GuId.ToString();
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
								list6.Add(invoiceBody);
							}
						}
					}
					invoice.Body = list6;
					list5.Add(invoice);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 += ",";
					}
					text2 += CS_0024_003C_003E8__locals1.doc.DocID;
				}
			}
			if (list5 != null && list5.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunSetting.IP, shygunSetting.conf, list5).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					string[] array = text2.Split(new char[1] { ',' });
					for (int i = 0; i < array.Length; i++)
					{
						text = putResults.Result[i].ErrorMessage;
						if (string.IsNullOrWhiteSpace(text))
						{
							_003C_003Ec__DisplayClass43_3 _003C_003Ec__DisplayClass43_ = new _003C_003Ec__DisplayClass43_3();
							_003C_003Ec__DisplayClass43_.Id = 0;
							int.TryParse(array[i], out _003C_003Ec__DisplayClass43_.Id);
							DbSet<WSDoc> wSDoc5 = _dbTbl.WSDoc;
							ParameterExpression val = Expression.Parameter(typeof(WSDoc), "m");
							WSDoc wSDoc6 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc5, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass43_, typeof(_003C_003Ec__DisplayClass43_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDoc6 != null)
							{
								_dbTbl.Entry(wSDoc6).State = EntityState.Modified;
								wSDoc6.DocLinkAccDocNumber = putResults.Result[i].Number;
								wSDoc6.DocLinkAccDocIdStr = putResults.Result[i].GuId;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
							else
							{
								text = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsDoc + "|";
							}
						}
					}
				}
				else
				{
					text += putResults.ErrorMessage;
				}
			}
			if (!string.IsNullOrEmpty(text))
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.FOMsgErrorDoneOperation,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunExportDocList(int oprId, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
			int num = 1;
			foreach (LkDocInfoViewModel item2 in list2)
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = num,
					Id = item2.DocID,
					Selected = string.IsNullOrEmpty(item2.DocLinkAccDocIdStr)
				};
				list.Add(item);
				num++;
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

	[LoginAuthorize]
	public ActionResult ShygunManageDocLinkAcc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actManageDocLinkAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actManageDraftLinkAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actManageDocLinkAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[HttpPost]
	public JsonResult ShygunDeleteImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageDocLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkShygunWSDeleteLinkedDoc_Result> list3 = Enumerable.ToList<CRMspLkShygunWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedDoc_Result>)_dbLink.CRMspLkShygunWSDeleteLinkedDoc(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedDoc_Result>)list3))
				{
					text = "error";
					text5 = GetFileShygunNotDeletedImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
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

	public string GetFileShygunNotDeletedImportedInfo(List<CRMspLkShygunWSDeleteLinkedDoc_Result> res)
	{
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunWSDeleteLinkedDoc_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListDocNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListDocNumber + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunWSDeleteLinkedDoc_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocLinkAccDocNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text3;
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

	public List<LkDocInfoViewModel> SelectDocExport(int oprId = 0, string fDate = "", string tDate = "", int docNumber = 0, int currentItemId = 0)
	{
		List<LkDocInfoViewModel> list = new List<LkDocInfoViewModel>();
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
			List<CRMspLkWSSelectDoc_Result> list2 = Enumerable.ToList<CRMspLkWSSelectDoc_Result>((IEnumerable<CRMspLkWSSelectDoc_Result>)_dbLink.CRMspLkWSSelectDoc(oprId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value2) : null, docNumber, UserLogin.CurrentUser.UserId, lCID, result, result2, currentItemId));
			int num = 1;
			if (list2 != null)
			{
				foreach (CRMspLkWSSelectDoc_Result item in list2)
				{
					LkDocInfoViewModel lkDocInfoViewModel = new LkDocInfoViewModel();
					lkDocInfoViewModel.DocID = item.DocID;
					lkDocInfoViewModel.OprId = item.OprId;
					lkDocInfoViewModel.DocNumber = item.DocNumber;
					if (!string.IsNullOrWhiteSpace(item.DocDate))
					{
						lkDocInfoViewModel.DocDate = item.DocDateTime?.ToString("yyyy/MM/dd", new PersianCulture());
						lkDocInfoViewModel.DocDateTime = item.DocDateTime;
					}
					else
					{
						lkDocInfoViewModel.DocDate = null;
						lkDocInfoViewModel.DocDateTime = null;
					}
					lkDocInfoViewModel.SenderId = item.SenderId;
					lkDocInfoViewModel.SenderName = item.SenderName;
					lkDocInfoViewModel.FactorNumber = item.FactorNumber;
					lkDocInfoViewModel.Description = item.Description;
					lkDocInfoViewModel.IsFix = item.IsFix;
					lkDocInfoViewModel.WHId = item.WHId;
					lkDocInfoViewModel.WH = item.WH;
					lkDocInfoViewModel.WHIdI = item.WHIdI;
					lkDocInfoViewModel.WHI = item.WHI;
					lkDocInfoViewModel.SendAddress = item.SendAddress;
					lkDocInfoViewModel.DriverName = item.DriverName;
					lkDocInfoViewModel.DriverTel = item.DriverTel;
					lkDocInfoViewModel.FreightName = item.FreightName;
					lkDocInfoViewModel.BijakNumber = item.BijakNumber;
					lkDocInfoViewModel.CarNumber = item.CarNumber;
					lkDocInfoViewModel.cmpTitle = item.cmpTitle;
					lkDocInfoViewModel.DocNumRef = item.DocNumRef;
					lkDocInfoViewModel.OrderId = item.OrderId;
					lkDocInfoViewModel.BuyOrderId = item.BuyOrderId;
					lkDocInfoViewModel.CompanyId = item.CompanyId;
					lkDocInfoViewModel.Company = item.Company;
					lkDocInfoViewModel.CompanyPersonId = item.CompanyPersonId;
					lkDocInfoViewModel.CompanyPerson = item.CompanyPerson;
					lkDocInfoViewModel.ProjectId = item.ProjectId;
					lkDocInfoViewModel.Project = item.Project;
					lkDocInfoViewModel.FirstRegisterUserId = item.FirstRegisterUserId;
					lkDocInfoViewModel.FirstRegisterUser = item.FirstRegisterUser;
					lkDocInfoViewModel.UserId = item.UserId;
					lkDocInfoViewModel.EditUser = item.EditUser;
					lkDocInfoViewModel.Month1 = item.Month1;
					lkDocInfoViewModel.FPId = item.FPId;
					lkDocInfoViewModel.RegisterDate = item.RegisterDate;
					lkDocInfoViewModel.RegisterDatePersian = item.RegisterDate.ToString("yyyy/MM/dd", new PersianCulture());
					if (!string.IsNullOrWhiteSpace(lkDocInfoViewModel.FirstRegisterDatePersian))
					{
						lkDocInfoViewModel.FirstRegisterDate = item.FirstRegisterDate;
						lkDocInfoViewModel.FirstRegisterDatePersian = item.FirstRegisterDate?.ToString("yyyy/MM/dd", new PersianCulture());
					}
					else
					{
						lkDocInfoViewModel.FirstRegisterDate = null;
						lkDocInfoViewModel.FirstRegisterDatePersian = null;
					}
					lkDocInfoViewModel.AppType = item.AppType;
					lkDocInfoViewModel.LanguageID = item.LanguageID;
					lkDocInfoViewModel.DocLinkAccCodeId = item.DocLinkAccCodeId;
					lkDocInfoViewModel.DocLinkAccCode = item.DocLinkAccCode;
					lkDocInfoViewModel.DocLinkAccDocId = item.DocLinkAccDocId;
					lkDocInfoViewModel.DocLinkAccDocIdStr = item.DocLinkAccDocIdStr;
					lkDocInfoViewModel.DocLinkAccDocNumber = item.DocLinkAccDocNumber;
					lkDocInfoViewModel.DocLinkAccVoucherId = item.DocLinkAccVoucherId;
					lkDocInfoViewModel.DocLinkAccVoucherNumber = item.DocLinkAccVoucherNumber;
					lkDocInfoViewModel.GUId = item.GUId;
					lkDocInfoViewModel.RowNumber = num;
					list.Add(lkDocInfoViewModel);
					num++;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public List<WSspSelectDocWithAccLinkField_Result> SelectDocWithAccLinkField(int docOprType = 1, bool withDocLinkAccCode = false, bool withDocLinkAccCodeId = false, bool withDocLinkAccDocId = false, bool withDocLinkAccDocIdStr = false, bool withDocLinkAccDocNumber = false, bool withDocLinkAccVoucherId = false, bool withDocLinkAccVoucherNumber = false)
	{
		List<WSspSelectDocWithAccLinkField_Result> result = new List<WSspSelectDocWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)_dbLink.WSspSelectDocWithAccLinkField(docOprType, withDocLinkAccCode: withDocLinkAccCode, withDocLinkAccCodeId: withDocLinkAccCodeId, withDocLinkAccDocId: withDocLinkAccDocId, withDocLinkAccDocIdStr: withDocLinkAccDocIdStr, withDocLinkAccDocNumber: withDocLinkAccDocNumber, withDocLinkAccVoucherId: withDocLinkAccVoucherId, withDocLinkAccVoucherNumber: withDocLinkAccVoucherNumber, languageID: lCID, defaultLanguageID: result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[LoginAuthorize]
	public ActionResult PayvastImportDoc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actImportFromAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actImportFromAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actImportFromAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[LoginAuthorize]
	public ActionResult PayvastExportDoc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actExportToAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actExportToAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actExportToAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult PayvastExportDoc_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", int value = 0)
	{
		return Json(((IEnumerable)SelectDocExport(oprId, fDate, tDate, value)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string PayvastActSendToAcc(int docId, bool checkAction = true, int docType = 1)
	{
		_003C_003Ec__DisplayClass53_0 _003C_003Ec__DisplayClass53_ = new _003C_003Ec__DisplayClass53_0();
		_003C_003Ec__DisplayClass53_.docId = docId;
		int type = 0;
		switch (docType)
		{
		case 1:
			type = 0;
			break;
		case 2:
			type = 1000;
			break;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectWareHouse_Result> list = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			if (_003C_003Ec__DisplayClass53_.docId > 0)
			{
				WSspSelectDocById_Result doc = Enumerable.FirstOrDefault<WSspSelectDocById_Result>((IEnumerable<WSspSelectDocById_Result>)_db_I.WSspSelectDocById(_003C_003Ec__DisplayClass53_.docId, lCID, result));
				if (doc != null && doc.DocID > 0)
				{
					string errorMessage = "";
					if (!Doc.SendToLinkAccNeedVerify(_003C_003Ec__DisplayClass53_.docId, ref errorMessage))
					{
						text = text + "<br>" + errorMessage;
						return text;
					}
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(doc.CompanyId.GetValueOrDefault());
					WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == doc.WHId));
					if (companyById == null || companyById.cmpLinkAccCustomerId.GetValueOrDefault() <= 0)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.Payvast);
					}
					else if (wSspSelectWareHouse_Result == null || wSspSelectWareHouse_Result.WrhsLinkAccWhId.GetValueOrDefault() <= 0)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, doc.WH, Labels.Payvast);
					}
					else
					{
						AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
						PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
						int num = accountingServiceSoapClient.CreateReceiptOrder(type, doc.DocDateTime ?? DateTime.Now, -1, wSspSelectWareHouse_Result.WrhsLinkAccWhId.GetValueOrDefault(), doc.Description, payvastSetting.PayvastAccountId, "", "", "", "", "", companyById.cmpLinkAccCustomerId.GetValueOrDefault(), payvastSetting.PayvastUsername, payvastSetting.PayvastPassword);
						if (num > 0)
						{
							List<WSspSelectDocItems_Result> list2 = Enumerable.ToList<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)_db.WSspSelectDocItems(doc.DocID, lCID, result));
							List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(true, true, false, lCID, result));
							List<WSspSelectProductUnitWithAccLinkField_Result> list4 = Enumerable.ToList<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)_dbLink.WSspSelectProductUnitWithAccLinkField(true, false, lCID, result));
							if (list2 != null)
							{
								foreach (WSspSelectDocItems_Result item in list2)
								{
									WSspSelectProductWithAccLinkField_Result prd = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdId == item.PrdId));
									if (prd == null || prd.PrdLinkAccPrdId.GetValueOrDefault() <= 0)
									{
										text = text + "</br>" + string.Format(Messages.msgErrorProductNotFoundInAccLink, item.prdName, Labels.Payvast);
										continue;
									}
									WSspSelectProductUnitWithAccLinkField_Result wSspSelectProductUnitWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list4, (Func<WSspSelectProductUnitWithAccLinkField_Result, bool>)((WSspSelectProductUnitWithAccLinkField_Result x) => x.ProductUnitID == prd.PrdUnitId));
									if (wSspSelectProductUnitWithAccLinkField_Result == null || wSspSelectProductUnitWithAccLinkField_Result.UnitLinkAccUnitId.GetValueOrDefault() <= 0)
									{
										text += "واحد کالا در سیستم حسابداری یافت نشد";
										continue;
									}
									int receiptOrderArticleId = accountingServiceSoapClient.AddReceiptOrderArticle(num, prd.PrdLinkAccPrdId.GetValueOrDefault(), 0m, wSspSelectProductUnitWithAccLinkField_Result.UnitLinkAccUnitId.GetValueOrDefault(), 0, 0m, payvastSetting.PayvastAccountId, "", "", "", "", "", item.Description ?? "");
									List<WSspSelectDocItemSerials_Result> list5 = Enumerable.ToList<WSspSelectDocItemSerials_Result>((IEnumerable<WSspSelectDocItemSerials_Result>)_db.WSspSelectDocItemSerials(item.DocItemID, lCID, result));
									if (list5 == null)
									{
										continue;
									}
									foreach (WSspSelectDocItemSerials_Result item2 in list5)
									{
										accountingServiceSoapClient.AddReceiptOrderSerial(num, receiptOrderArticleId, item2.Serial, item2.ExpDate ?? DateTime.Now);
									}
								}
							}
							AddMethodsResult addMethodsResult = accountingServiceSoapClient.CommitReceiptOrder(num, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now));
							if (addMethodsResult != null && addMethodsResult.Id > 0)
							{
								DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
								ParameterExpression val = Expression.Parameter(typeof(WSDoc), "m");
								WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass53_, typeof(_003C_003Ec__DisplayClass53_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (doc != null)
								{
									_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
									wSDoc2.DocLinkAccDocId = addMethodsResult.Id;
									wSDoc2.DocLinkAccDocIdStr = addMethodsResult.Id.ToString();
									wSDoc2.DocLinkAccDocNumber = addMethodsResult.Number.ToString();
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
								else
								{
									text = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsDoc + "|";
								}
							}
						}
						else
						{
							text += "</br>خطا در درخواست ثبت اولیه برگه انبار";
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult PayvastExportInfo(string records, int oprId, string fDate, string tDate, int value, int docType = 1)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
		if (docType != 1)
		{
			_ = 2;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			if (list != null && list.Count > 0)
			{
				foreach (OtherSystemSelectedViewModel item in list)
				{
					text += PayvastActSendToAcc(item.Id, checkAction: true, docType);
				}
			}
			if (!string.IsNullOrEmpty(text))
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.FOMsgErrorDoneOperation,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPayvastExportDocList(int oprId, string fDate = "", string tDate = "", int value = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value);
			int num = 1;
			foreach (LkDocInfoViewModel item2 in list2)
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = num,
					Id = item2.DocID,
					Selected = string.IsNullOrEmpty(item2.DocLinkAccDocNumber)
				};
				list.Add(item);
				num++;
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
	public JsonResult GetDocOpr(int oprType)
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
			List<WSspSelectDocOprByoprType_Result> list2 = Enumerable.ToList<WSspSelectDocOprByoprType_Result>((IEnumerable<WSspSelectDocOprByoprType_Result>)_db.WSspSelectDocOprByoprType(oprType, lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectDocOprByoprType_Result, SelectListItem>((IEnumerable<WSspSelectDocOprByoprType_Result>)list2, (Func<WSspSelectDocOprByoprType_Result, SelectListItem>)((WSspSelectDocOprByoprType_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.DocOprID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.DocOprList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepSaleType(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectSaleType_Result> list2 = Enumerable.ToList<CRMspLkSepSelectSaleType_Result>((IEnumerable<CRMspLkSepSelectSaleType_Result>)_dbLink.CRMspLkSepSelectSaleType(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectSaleType_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectSaleType_Result>)list2, (Func<CRMspLkSepSelectSaleType_Result, SelectListItem>)((CRMspLkSepSelectSaleType_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.SaleTypeId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepSaleTypeList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepFiscalYear(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectFiscalYear_Result> list2 = Enumerable.ToList<CRMspLkSepSelectFiscalYear_Result>((IEnumerable<CRMspLkSepSelectFiscalYear_Result>)_dbLink.CRMspLkSepSelectFiscalYear(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectFiscalYear_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectFiscalYear_Result>)list2, (Func<CRMspLkSepSelectFiscalYear_Result, SelectListItem>)((CRMspLkSepSelectFiscalYear_Result item) => new SelectListItem
			{
				Text = item.Title,
				Value = item.FiscalYearId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepSepFiscalYearList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetReferUser()
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
		base.ViewBag.ReferUserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepUser(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectUser_Result> list2 = Enumerable.ToList<CRMspLkSepSelectUser_Result>((IEnumerable<CRMspLkSepSelectUser_Result>)_dbLink.CRMspLkSepSelectUser(linkAccSettingDBId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLkSepSelectUser_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectUser_Result>)list2, (Func<CRMspLkSepSelectUser_Result, SelectListItem>)((CRMspLkSepSelectUser_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.UserID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCrmFinancialPeriod()
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
			List<WSspSelectFinancialPeriod_Result> list2 = Enumerable.ToList<WSspSelectFinancialPeriod_Result>((IEnumerable<WSspSelectFinancialPeriod_Result>)Enumerable.OrderByDescending<WSspSelectFinancialPeriod_Result, int>((IEnumerable<WSspSelectFinancialPeriod_Result>)_db.WSspSelectFinancialPeriod(), (Func<WSspSelectFinancialPeriod_Result, int>)((WSspSelectFinancialPeriod_Result m) => m.ID)));
			list.AddRange(Enumerable.Select<WSspSelectFinancialPeriod_Result, SelectListItem>((IEnumerable<WSspSelectFinancialPeriod_Result>)list2, (Func<WSspSelectFinancialPeriod_Result, SelectListItem>)((WSspSelectFinancialPeriod_Result item) => new SelectListItem
			{
				Text = item.Name,
				Value = item.ID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmFinancialPeriodList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetWrhsLinked(bool withWrhsLinkAccWhId = false, bool withWrhsLinkAccWhCode = false, bool withWrhsLinkAccWhIdStr = false, bool withWrhsLinkAccWareHouses = false)
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
			List<WSspSelectWareHouseWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(withWrhsLinkAccWhId, withWrhsLinkAccWhCode, withWrhsLinkAccWhIdStr, withWrhsLinkAccWareHouses, lCID, result));
			if (list2 != null && Enumerable.Any<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2))
			{
				if (withWrhsLinkAccWhId)
				{
					list.AddRange(Enumerable.Select<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>)((WSspSelectWareHouseWithAccLinkField_Result item) => new SelectListItem
					{
						Text = item.WrhsName,
						Value = item.WrhsLinkAccWhId.ToString(),
						Selected = false
					})));
				}
				else if (withWrhsLinkAccWhIdStr)
				{
					list.AddRange(Enumerable.Select<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>)((WSspSelectWareHouseWithAccLinkField_Result item) => new SelectListItem
					{
						Text = item.WrhsName,
						Value = item.WrhsLinkAccWhIdStr,
						Selected = false
					})));
				}
				else if (withWrhsLinkAccWhCode)
				{
					list.AddRange(Enumerable.Select<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list2, (Func<WSspSelectWareHouseWithAccLinkField_Result, SelectListItem>)((WSspSelectWareHouseWithAccLinkField_Result item) => new SelectListItem
					{
						Text = item.WrhsName,
						Value = item.WrhsLinkAccWhCode,
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.WrhsLinkedToAccList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetUserLinked(bool withLinkAccUserIdStr = false, bool withLinkAccUserCode = false)
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
			List<CRMspSelectUsersWithAccLinkField_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(withLinkAccUserIdStr, withLinkAccUserCode, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2))
			{
				if (withLinkAccUserIdStr)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersWithAccLinkField_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, SelectListItem>)((CRMspSelectUsersWithAccLinkField_Result item) => new SelectListItem
					{
						Text = item.FullName,
						Value = item.LinkAccUserIdStr,
						Selected = false
					})));
				}
				else if (withLinkAccUserCode)
				{
					list.AddRange(Enumerable.Select<CRMspSelectUsersWithAccLinkField_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list2, (Func<CRMspSelectUsersWithAccLinkField_Result, SelectListItem>)((CRMspSelectUsersWithAccLinkField_Result item) => new SelectListItem
					{
						Text = item.FullName,
						Value = item.LinkAccUserCode,
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.UserLinkedToAccList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCrmWareHouse()
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
			List<WSspSelectActiveWareHouse_Result> list2 = CRMIdeal.Classes.Helper.Warehouse.SelectActiveWareHouse();
			list.AddRange(Enumerable.Select<WSspSelectActiveWareHouse_Result, SelectListItem>((IEnumerable<WSspSelectActiveWareHouse_Result>)list2, (Func<WSspSelectActiveWareHouse_Result, SelectListItem>)((WSspSelectActiveWareHouse_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CrmWareHouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetSepStock(int linkAccSettingDBId)
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
			List<CRMspLkSepSelectStock_Result> list2 = Enumerable.ToList<CRMspLkSepSelectStock_Result>((IEnumerable<CRMspLkSepSelectStock_Result>)_dbLink.CRMspLkSepSelectStock(linkAccSettingDBId, lCID, result));
			if (list2 != null && Enumerable.Any<CRMspLkSepSelectStock_Result>((IEnumerable<CRMspLkSepSelectStock_Result>)list2))
			{
				list.AddRange(Enumerable.Select<CRMspLkSepSelectStock_Result, SelectListItem>((IEnumerable<CRMspLkSepSelectStock_Result>)list2, (Func<CRMspLkSepSelectStock_Result, SelectListItem>)((CRMspLkSepSelectStock_Result item) => new SelectListItem
				{
					Text = item.Title,
					Value = item.StockID.ToString(),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SepStockList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetCrmActiveWareHouseByLinkAccData(int linkAccSystemId, int linkAccSettingDBId, bool isAccLinked)
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
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			int num = 0;
			int result2 = 0;
			if (currentUser != null)
			{
				if (num == 0)
				{
					num = currentUser.UserId;
				}
				if (result2 == 0)
				{
					int.TryParse(currentUser.UserLastCId.ToString(), out result2);
				}
			}
			List<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result> list2 = Enumerable.ToList<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result>((IEnumerable<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result>)_dbLink.CRMspLKWSSelectActiveWareHouseByLinkAccData(num, result2, linkAccSystemId, linkAccSettingDBId, isAccLinked, lCID, result));
			list.AddRange(Enumerable.Select<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result, SelectListItem>((IEnumerable<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result>)list2, (Func<CRMspLKWSSelectActiveWareHouseByLinkAccData_Result, SelectListItem>)((CRMspLKWSSelectActiveWareHouseByLinkAccData_Result item) => new SelectListItem
			{
				Text = item.WrhsName,
				Value = item.WareHouseID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	public string GetSepStockJson(int linkAccSettingDBId)
	{
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkSepSelectStock_Result> list = Enumerable.ToList<CRMspLkSepSelectStock_Result>((IEnumerable<CRMspLkSepSelectStock_Result>)_dbLink.CRMspLkSepSelectStock(linkAccSettingDBId, lCID, result2));
			if (list != null)
			{
				result = JsonConvert.SerializeObject(Enumerable.ToList<nComboBoxListItem>(Enumerable.Select<CRMspLkSepSelectStock_Result, nComboBoxListItem>((IEnumerable<CRMspLkSepSelectStock_Result>)list, (Func<CRMspLkSepSelectStock_Result, nComboBoxListItem>)((CRMspLkSepSelectStock_Result item) => new nComboBoxListItem
				{
					Text = item.Title,
					Value = item.StockID.ToString(),
					Selected = false
				}))));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public ShygunIIDocInfoViewModelObjects GetShygunIIDocList(int docOprType = 1, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int fromRec = 0, int recCount = 20)
	{
		//IL_09fa: Unknown result type (might be due to invalid IL or missing references)
		//IL_09ff: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunIIDocInfoViewModelObjects shygunIIDocInfoViewModelObjects = new ShygunIIDocInfoViewModelObjects();
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
			List<ShygunIIDocInfoViewModel> list = new List<ShygunIIDocInfoViewModel>();
			List<WSspSelectDocWithAccLinkField_Result> list2 = SelectDocWithAccLinkField(docOprType, withDocLinkAccCode: false, withDocLinkAccCodeId: false, withDocLinkAccDocId: false, withDocLinkAccDocIdStr: true, withDocLinkAccDocNumber: true);
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainInvoiceHeader domainInvoiceHeader = new DomainInvoiceHeader();
			domainInvoiceHeader.InvoiceDate.From = dateTime.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceDate.To = dateTime2.ToString("yyyy/MM/dd");
			domainInvoiceHeader.InvoiceNumber.From = ((fNumber == "0" || string.IsNullOrWhiteSpace(fNumber)) ? "" : fNumber);
			domainInvoiceHeader.InvoiceNumber.To = ((tNumber == "0" || string.IsNullOrWhiteSpace(tNumber)) ? "" : tNumber);
			domainInvoiceHeader.InvoiceType.From = fOrderType.ToString();
			domainInvoiceHeader.InvoiceType.To = tOrderType.ToString();
			domainInvoiceHeader.Printed.From = fPrinted.ToString();
			domainInvoiceHeader.Printed.To = tPrinted.ToString();
			string text = shygunIISetting.IP;
			if (string.IsNullOrWhiteSpace(text))
			{
				Exception e = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			if (!text.EndsWith("/"))
			{
				text += "/";
			}
			HttpClient httpClient = new HttpClient();
			httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
			httpClient.BaseAddress = new Uri(text);
			httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			string text2 = "api/Invoice/Get";
			text2 = text2 + "?RowStart=" + fromRec + "&RowCount=" + recCount;
			HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvParamViewModel
			{
				Config = shygunIISetting.conf,
				Domain = domainInvoiceHeader,
				StartVersion = "0"
			}), Encoding.UTF8, "application/json");
			HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
			httpResponseMessage = httpClient.PostAsync(text2, content).Result;
			if (httpResponseMessage.IsSuccessStatusCode)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvResultViewModel shygunIIApiGetInvResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetInvResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
				if (shygunIIApiGetInvResultViewModel != null && shygunIIApiGetInvResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel>)shygunIIApiGetInvResultViewModel.Result))
				{
					foreach (CRMIdeal.Classes.Helper.OtherSystems.ShygunIIInvoiceViewModel item in shygunIIApiGetInvResultViewModel.Result)
					{
						ShygunIIDocInfoViewModel shygunIIDocInfoViewModel = new ShygunIIDocInfoViewModel();
						shygunIIDocInfoViewModel.InvTyp = item.InvTyp;
						shygunIIDocInfoViewModel.InvNo = item.InvNo;
						shygunIIDocInfoViewModel.AccountGuId = item.AccountGuId;
						shygunIIDocInfoViewModel.JobCostingGuId = item.JobCostingGuId;
						shygunIIDocInfoViewModel.InvDescription = item.InvDescription;
						shygunIIDocInfoViewModel.InvDate = item.InvDate;
						shygunIIDocInfoViewModel.InvPayDue = item.InvPayDue;
						shygunIIDocInfoViewModel.AccountNumber = item.AccountNumber;
						shygunIIDocInfoViewModel.AccountName = item.AccountName;
						shygunIIDocInfoViewModel.JobCostingNumber = item.JobCostingNumber;
						shygunIIDocInfoViewModel.JobCostingName = item.JobCostingName;
						shygunIIDocInfoViewModel.CurrencyAbb1 = item.CurrencyAbb1;
						shygunIIDocInfoViewModel.SAccountGuId = item.SAccountGuId;
						shygunIIDocInfoViewModel.SJobGuId = item.SJobGuId;
						shygunIIDocInfoViewModel.bijak = item.bijak;
						shygunIIDocInfoViewModel.GuId = item.GuId;
						if (item.CreatedDate.HasValue)
						{
							shygunIIDocInfoViewModel.CreatedDate = item.CreatedDate;
							shygunIIDocInfoViewModel.CreatedDatePersian = (item.CreatedDate ?? DateTime.Now).ToString("yyyy/MM/dd", new PersianCulture());
						}
						else
						{
							shygunIIDocInfoViewModel.CreatedDate = null;
							shygunIIDocInfoViewModel.CreatedDatePersian = "";
						}
						shygunIIDocInfoViewModel.GeneralRef = item.GeneralRef;
						shygunIIDocInfoViewModel.SAccountNumber = item.SAccountNumber;
						shygunIIDocInfoViewModel.SJobNumber = item.SJobNumber;
						shygunIIDocInfoViewModel.DiscountPercent = item.DiscountPercent;
						shygunIIDocInfoViewModel.DiscAmount = item.DiscAmount;
						shygunIIDocInfoViewModel.DepartmentNumber = item.DepartmentNumber;
						shygunIIDocInfoViewModel.ST1Number = item.ST1Number;
						shygunIIDocInfoViewModel.ST1GuId = item.ST1GuId;
						shygunIIDocInfoViewModel.ST2Number = item.ST2Number;
						shygunIIDocInfoViewModel.ST2GuId = item.ST2GuId;
						shygunIIDocInfoViewModel.AtfNumber = item.AtfNumber;
						shygunIIDocInfoViewModel.AtfGuId = item.AtfGuId;
						item.InvNo.ToString();
						string InvGuId = item.GuId.ToString();
						WSspSelectDocWithAccLinkField_Result wSspSelectDocWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list2, (Func<WSspSelectDocWithAccLinkField_Result, bool>)((WSspSelectDocWithAccLinkField_Result x) => x.DocLinkAccDocIdStr == InvGuId));
						if (wSspSelectDocWithAccLinkField_Result != null && wSspSelectDocWithAccLinkField_Result.DocID > 0)
						{
							shygunIIDocInfoViewModel.DocId = wSspSelectDocWithAccLinkField_Result.DocID;
						}
						List<ShygunIIDocBodyInfoViewModel> list3 = new List<ShygunIIDocBodyInfoViewModel>();
						shygunIIDocInfoViewModel.BodyCount = 0;
						if (item.Body != null && item.Body.Count > 0)
						{
							foreach (InvoiceBody item2 in item.Body)
							{
								ShygunIIDocBodyInfoViewModel shygunIIDocBodyInfoViewModel = new ShygunIIDocBodyInfoViewModel();
								shygunIIDocBodyInfoViewModel.InvNo = shygunIIDocInfoViewModel.InvNo;
								shygunIIDocBodyInfoViewModel.InvGuId = shygunIIDocInfoViewModel.GuId;
								shygunIIDocBodyInfoViewModel.LineItemId = item2.LineItemId;
								shygunIIDocBodyInfoViewModel.InvHeaderId = item2.InvHeaderId;
								shygunIIDocBodyInfoViewModel.LineItemOrder = item2.LineItemOrder;
								shygunIIDocBodyInfoViewModel.ItemNumber = item2.ItemNumber;
								shygunIIDocBodyInfoViewModel.STNumber = item2.STNumber;
								shygunIIDocBodyInfoViewModel.STDesc = item2.STDesc;
								shygunIIDocBodyInfoViewModel.STGuId = item2.STGuId;
								shygunIIDocBodyInfoViewModel.ItemGuId = item2.ItemGuId;
								shygunIIDocBodyInfoViewModel.Quan = item2.Quan;
								shygunIIDocBodyInfoViewModel.Quan2 = item2.Quan2;
								shygunIIDocBodyInfoViewModel.Price = item2.Price;
								shygunIIDocBodyInfoViewModel.Price2 = item2.Price2;
								shygunIIDocBodyInfoViewModel.Amount = item2.Amount;
								shygunIIDocBodyInfoViewModel.AmortizePercent = item2.AmortizePercent;
								shygunIIDocBodyInfoViewModel.LineDiscAmount = item2.LineDiscAmount;
								shygunIIDocBodyInfoViewModel.LineDiscPer = item2.LineDiscPer;
								shygunIIDocBodyInfoViewModel.LineItemDesc = item2.LineItemDesc;
								shygunIIDocBodyInfoViewModel.ReturnRial = item2.ReturnRial;
								shygunIIDocBodyInfoViewModel.OrderRemain1 = item2.OrderRemain1;
								shygunIIDocBodyInfoViewModel.OrderRemain2 = item2.OrderRemain2;
								shygunIIDocBodyInfoViewModel.FinalOrderQuan = item2.FinalOrderQuan;
								shygunIIDocBodyInfoViewModel.FinalOrderQuan2 = item2.FinalOrderQuan2;
								shygunIIDocBodyInfoViewModel.AccountName = shygunIIDocInfoViewModel.AccountName;
								shygunIIDocBodyInfoViewModel.AccountNumber = shygunIIDocInfoViewModel.AccountNumber;
								shygunIIDocBodyInfoViewModel.AccountGuId = shygunIIDocInfoViewModel.AccountGuId;
								shygunIIDocBodyInfoViewModel.DocId = shygunIIDocInfoViewModel.DocId;
								shygunIIDocBodyInfoViewModel.RowNumber = list3.Count + 1;
								list3.Add(shygunIIDocBodyInfoViewModel);
							}
							shygunIIDocInfoViewModel.BodyCount = list3.Count;
						}
						shygunIIDocInfoViewModel.Body = list3;
						List<ShygunIIDocExpenseViewModel> list4 = new List<ShygunIIDocExpenseViewModel>();
						shygunIIDocInfoViewModel.ExpenseCount = 0;
						if (item.Expense != null && item.Expense.Count > 0)
						{
							foreach (InvoiceExpense item3 in item.Expense)
							{
								ShygunIIDocExpenseViewModel shygunIIDocExpenseViewModel = new ShygunIIDocExpenseViewModel();
								shygunIIDocExpenseViewModel.InvExpRowId = item3.InvExpRowId;
								shygunIIDocExpenseViewModel.InvExpRowOrder = item3.InvExpRowOrder;
								shygunIIDocExpenseViewModel.InvHeaderId = item3.InvHeaderId;
								shygunIIDocExpenseViewModel.AccountGuId = item3.AccountGuId;
								shygunIIDocExpenseViewModel.JobCostingGuId = item3.JobCostingGuId;
								shygunIIDocExpenseViewModel.AccountNumber = item3.AccountNumber;
								shygunIIDocExpenseViewModel.AccountName = item3.AccountName;
								shygunIIDocExpenseViewModel.JobCostingNumber = item3.JobCostingNumber;
								shygunIIDocExpenseViewModel.InvExpRowDesc = item3.InvExpRowDesc;
								shygunIIDocExpenseViewModel.InvExpRowAmount = item3.InvExpRowAmount;
								shygunIIDocExpenseViewModel.SecondAccountNumber = item3.SecondAccountNumber;
								shygunIIDocExpenseViewModel.SecondAccountName = item3.SecondAccountName;
								shygunIIDocExpenseViewModel.SecondJobCostingGuId = item3.SecondJobCostingGuId;
								shygunIIDocExpenseViewModel.SecondAccountGuId = item3.SecondAccountGuId;
								shygunIIDocExpenseViewModel.SecondJobCostingNumber = item3.SecondJobCostingNumber;
								shygunIIDocExpenseViewModel.FixCostType = item3.FixCostType;
								shygunIIDocExpenseViewModel.DocId = shygunIIDocInfoViewModel.DocId;
								shygunIIDocExpenseViewModel.InvGuId = shygunIIDocInfoViewModel.GuId;
								shygunIIDocExpenseViewModel.RowNumber = list4.Count + 1;
								list4.Add(shygunIIDocExpenseViewModel);
							}
							shygunIIDocInfoViewModel.ExpenseCount = list4.Count;
						}
						shygunIIDocInfoViewModel.Expense = list4;
						shygunIIDocInfoViewModel.RowNumber = list.Count + 1;
						list.Add(shygunIIDocInfoViewModel);
					}
				}
			}
			else
			{
				HttpStatusCode statusCode = httpResponseMessage.StatusCode;
				Exception e2 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			shygunIIDocInfoViewModelObjects.lst = list;
			shygunIIDocInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunIIDocInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return shygunIIDocInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunIIImportDoc_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		List<ShygunIIDocInfoViewModel> list = new List<ShygunIIDocInfoViewModel>();
		ShygunIIDocInfoViewModelObjects shygunIIDocList = GetShygunIIDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount);
		if (shygunIIDocList != null)
		{
			list = shygunIIDocList.lst;
			if (list != null && Enumerable.Any<ShygunIIDocInfoViewModel>((IEnumerable<ShygunIIDocInfoViewModel>)list))
			{
				foreach (ShygunIIDocInfoViewModel item in list)
				{
					if (!string.IsNullOrWhiteSpace(item.InvDate))
					{
						DateTime dateTime = default(DateTime);
						item.InvDate = item.InvDate.Replace("-", "/");
						item.InvDate = DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None).ToString("yyyy/MM/dd");
					}
				}
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIImportDocList(string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunIIDocInfoViewModel item2 in GetShygunIIDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.GuId.ToString(),
					Selected = (item2.DocId <= 0)
				};
				list.Add(item);
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

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIImportInfo(string records, string fDate = "", string tDate = "", string fNumber = "0", string tNumber = "0", int fOrderType = 5, int tOrderType = 5, int fPrinted = 0, int tPrinted = 0, int oprId = 0, int docOprType = 1, int fromRec = 0, int recCount = 20)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunIIDocInfoViewModel> list3 = new List<ShygunIIDocInfoViewModel>();
			List<ShygunIIDocInfoViewModel> lst = GetShygunIIDocList(docOprType, fDate, tDate, fNumber, tNumber, fOrderType, tOrderType, fPrinted, tPrinted, fromRec, recCount).lst;
			if (list != null)
			{
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list)
				{
					ShygunIIDocInfoViewModel shygunIIDocInfoViewModel = Enumerable.FirstOrDefault<ShygunIIDocInfoViewModel>(Enumerable.Where<ShygunIIDocInfoViewModel>((IEnumerable<ShygunIIDocInfoViewModel>)lst, (Func<ShygunIIDocInfoViewModel, bool>)((ShygunIIDocInfoViewModel w) => w.GuId.ToString() == SelectedRowitem.Id)));
					if (shygunIIDocInfoViewModel != null)
					{
						list3.Add(shygunIIDocInfoViewModel);
					}
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from ShygunII) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			if (list3 != null && Enumerable.Any<ShygunIIDocInfoViewModel>((IEnumerable<ShygunIIDocInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list4 = new CompanyController().SelectCompanyWithAccLinkField(withLinkAccCode: true);
				CRMLinkSpEntities dbLink = _dbLink;
				bool? flag = true;
				List<WSspSelectWareHouseWithAccLinkField_Result> list5 = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)dbLink.WSspSelectWareHouseWithAccLinkField(false, flag, false, languageID: lCID, defaultLanguageID: result, withWrhsLinkAccWareHouses: false));
				ObjectResult<WSspSelectOrderWithAccLinkField_Result> objectResult = _dbLink.WSspSelectOrderWithAccLinkField(withOrdLinkAccCode: false, withOrdLinkAccCodeId: false, withOrdLinkAccOrderId: false, withOrdLinkAccOrderIdStr: false, withOrdLinkAccOrderNumber: true, withOrdLinkAccVoucherId: false, withOrdLinkAccVoucherNumber: false, languageID: lCID, defaultLanguageID: result, linkAccSettingDBId: null);
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				foreach (ShygunIIDocInfoViewModel item in list3)
				{
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCode == item.JobCostingNumber));
					if ((cRMspSelectCompanyWithAccLinkField_Result == null || cRMspSelectCompanyWithAccLinkField_Result.CompanyID <= 0) && docOprType != 3)
					{
						text = Messages.CompanyNotFound;
						continue;
					}
					int value4 = 0;
					int num2 = 0;
					if (item.Body != null && item.BodyCount > 0)
					{
						foreach (ShygunIIDocBodyInfoViewModel bd in item.Body)
						{
							WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == bd.STNumber));
							if (wSspSelectWareHouseWithAccLinkField_Result != null && wSspSelectWareHouseWithAccLinkField_Result.WareHouseID > 0)
							{
								value4 = wSspSelectWareHouseWithAccLinkField_Result.WareHouseID;
							}
							else
							{
								text = text + Messages.msgErrorDocItemIsEmpty + " | ";
							}
						}
					}
					else
					{
						text = Messages.msgErrorDocItemIsEmpty;
					}
					if (docOprType == 3)
					{
						WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == item.ST1Number));
						if (wSspSelectWareHouseWithAccLinkField_Result2 != null && wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID > 0)
						{
							num2 = wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID;
						}
						else
						{
							text = text + string.Format(Messages.msgErrorImportOtherSystemFieldIsNull, Labels.OtherSystemImportMovementWHId) + " | ";
						}
						wSspSelectWareHouseWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list5, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result x) => x.WrhsLinkAccWhCode == item.ST2Number));
						if (wSspSelectWareHouseWithAccLinkField_Result2 != null && wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID > 0)
						{
							num2 = wSspSelectWareHouseWithAccLinkField_Result2.WareHouseID;
						}
						else
						{
							text = text + string.Format(Messages.msgErrorImportOtherSystemFieldIsNull, Labels.OtherSystemImportMovementWHIdI) + " | ";
						}
					}
					string InvNo = item.InvNo.ToString();
					Enumerable.FirstOrDefault<WSspSelectOrderWithAccLinkField_Result>((IEnumerable<WSspSelectOrderWithAccLinkField_Result>)objectResult, (Func<WSspSelectOrderWithAccLinkField_Result, bool>)((WSspSelectOrderWithAccLinkField_Result x) => x.ordLinkAccOrderNumber == InvNo));
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					DateTime now2 = DateTime.Now;
					string text3 = "";
					now2 = (string.IsNullOrWhiteSpace(item.InvDate) ? (item.CreatedDate ?? DateTime.Now) : DateTime.Parse(PersianDate.GetFormatetdDate(item.InvDate.Replace("-", "/")) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None));
					text3 = now2.ToString("yyyyMMdd", new PersianCulture());
					ObjectParameter objectParameter2 = new ObjectParameter("InsertedId", 0);
					_dbLink.CRMspLkShygunIIWSInsertUpdateDoc(shygunIISetting.DefPrjTitle, shygunIISetting.DefPrjCvnsStatusGroupId, InvNo, item.DocId, oprId, null, null, null, item.InvDescription, 0, value4, null, null, null, null, null, null, item.bijak, null, (num2 > 0) ? new int?(num2) : null, cRMspSelectCompanyWithAccLinkField_Result.CompanyID, null, null, null, null, null, null, item.GuId.ToString(), item.InvNo.ToString(), null, null, null, text3, now2, userId, value3, id, value2, value, registerDatePersian, appType, lCID, result, objectParameter2, objectParameter, (item.CreatedDate ?? DateTime.Now).ToString("yyyyMMdd", new PersianCulture()), (item.CreatedDate ?? DateTime.Now).ToString("hh:MM:ss"), item.CreatedDate ?? DateTime.Now, userId, centerId);
					if (objectParameter2 == null || string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()) || objectParameter2.Value.ToString() == "0")
					{
						text = text + "<br>" + Messages.msgErrorInsertDocNotSuccess;
						continue;
					}
					int result2 = 0;
					int.TryParse(objectParameter2.Value.ToString(), out result2);
					if (item.BodyCount <= 0)
					{
						continue;
					}
					foreach (ShygunIIDocBodyInfoViewModel item2 in item.Body)
					{
						item2.DocId = result2;
					}
					string json = JsonConvert.SerializeObject(item.Body);
					_dbLink.CRMspLkShygunIIWSInsertUpdateDocItems(json, shygunIISetting.DefPrjTitle, shygunIISetting.DefPrjCvnsStatusGroupId, userId, value3, value2, id, value, registerDatePersian, appType, lCID, result, objectParameter);
					if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text = text + "<br>" + objectParameter.Value.ToString();
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
				ProgressHub.SendMessage(text, 0, userId);
			}
			else
			{
				text = Messages.msgSuccessAction;
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductFirstGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductSecondGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCostGroup");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductCost");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WsWareHouse");
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunIIExportDoc_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		List<LkDocInfoViewModel> list = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
		if (list != null && Enumerable.Any<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list))
		{
			foreach (LkDocInfoViewModel item in list)
			{
				item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIExportInfo(string records, int oprId, string fDate, string tDate, int value, int DocType = 1, int currentItemId = 0)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		int num = -1;
		switch (DocType)
		{
		case 1:
			num = 5;
			break;
		case 2:
			num = 4;
			break;
		case 3:
			num = 10;
			break;
		}
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			_ = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			string text2 = "";
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
			List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
			List<WSspSelectWareHouse_Result> list4 = CRMIdeal.Classes.Helper.Warehouse.SelectWareHouse();
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			string text3 = "";
			if (shygunIISetting != null)
			{
				switch (DocType)
				{
				case 1:
					if (string.IsNullOrWhiteSpace(shygunIISetting.DocAccountGuId) || string.IsNullOrWhiteSpace(shygunIISetting.DocAccountNumber))
					{
						text3 = (string.IsNullOrWhiteSpace(shygunIISetting.DocAccountNumberFieldTitle) ? Messages.errorInReadingSetting : string.Format(Messages.msgErrorIsNotEntered, shygunIISetting.DocAccountNumberFieldTitle));
					}
					break;
				case 2:
					if (string.IsNullOrWhiteSpace(shygunIISetting.DraftAccountGuId) || string.IsNullOrWhiteSpace(shygunIISetting.DraftAccountNumber))
					{
						text3 = (string.IsNullOrWhiteSpace(shygunIISetting.DraftAccountNumberFieldTitle) ? Messages.errorInReadingSetting : string.Format(Messages.msgErrorIsNotEntered, shygunIISetting.DraftAccountNumberFieldTitle));
					}
					break;
				case 3:
					if (string.IsNullOrWhiteSpace(shygunIISetting.WrhsMovementAccountGuId) || string.IsNullOrWhiteSpace(shygunIISetting.WrhsMovementAccountNumber))
					{
						text3 = (string.IsNullOrWhiteSpace(shygunIISetting.WrhsMovementAccountNumberFieldTitle) ? Messages.errorInReadingSetting : string.Format(Messages.msgErrorIsNotEntered, shygunIISetting.WrhsMovementAccountNumberFieldTitle));
					}
					break;
				}
			}
			else
			{
				text3 = Messages.errorInReadingSetting;
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				data2 = new CommonResultViewModel<int>
				{
					Data = 0,
					Message = text3,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			List<Invoice> list5 = new List<Invoice>();
			if (list != null)
			{
				foreach (OtherSystemSelectedViewModel item in list)
				{
					_003C_003Ec__DisplayClass73_1 CS_0024_003C_003E8__locals1 = new _003C_003Ec__DisplayClass73_1();
					CS_0024_003C_003E8__locals1.doc = Enumerable.FirstOrDefault<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list2, (Func<LkDocInfoViewModel, bool>)((LkDocInfoViewModel x) => x.DocID == item.Id));
					if (CS_0024_003C_003E8__locals1.doc == null || CS_0024_003C_003E8__locals1.doc.DocID <= 0)
					{
						continue;
					}
					string errorMessage = "";
					if (!Doc.SendToLinkAccNeedVerify(item.Id, ref errorMessage))
					{
						text = text + "<br>" + errorMessage;
						continue;
					}
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr))
					{
						ShygunIIDocInfoViewModelObjects shygunIIDocList = GetShygunIIDocList(1, CS_0024_003C_003E8__locals1.doc.DocDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.doc.DocDateTime?.ToString("yyyy/MM/dd"), CS_0024_003C_003E8__locals1.doc.DocLinkAccDocNumber, CS_0024_003C_003E8__locals1.doc.DocLinkAccDocNumber, num, num);
						if (shygunIIDocList != null && shygunIIDocList.lst == null && !Enumerable.Any<ShygunIIDocInfoViewModel>((IEnumerable<ShygunIIDocInfoViewModel>)shygunIIDocList.lst))
						{
							DbSet<WSDoc> wSDoc = _dbTbl.WSDoc;
							ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
							WSDoc wSDoc2 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass73_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDoc2 != null)
							{
								_dbTbl.Entry(wSDoc2).State = EntityState.Modified;
								wSDoc2.DocLinkAccCode = null;
								wSDoc2.DocLinkAccDocNumber = null;
								wSDoc2.DocLinkAccDocIdStr = null;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
						}
					}
					else
					{
						DbSet<WSDoc> wSDoc3 = _dbTbl.WSDoc;
						ParameterExpression val = Expression.Parameter(typeof(WSDoc), "x");
						WSDoc wSDoc4 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc3, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals1, typeof(_003C_003Ec__DisplayClass73_1)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
						if (wSDoc4 != null)
						{
							_dbTbl.Entry(wSDoc4).State = EntityState.Modified;
							wSDoc4.DocLinkAccCode = null;
							wSDoc4.DocLinkAccDocNumber = null;
							wSDoc4.DocLinkAccDocIdStr = null;
							_dbTbl.Configuration.ValidateOnSaveEnabled = false;
							_dbTbl.SaveChanges();
							_dbTbl.Configuration.ValidateOnSaveEnabled = true;
						}
					}
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(CS_0024_003C_003E8__locals1.doc.CompanyId.GetValueOrDefault());
					if (!string.IsNullOrWhiteSpace(text))
					{
						continue;
					}
					if ((companyById == null || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) && DocType != 3)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorCompanyNotFoundInAccLink, companyById.cmpName, Labels.ShygunII);
						continue;
					}
					Invoice invoice = new Invoice();
					_ = CS_0024_003C_003E8__locals1.doc.DocNumber;
					invoice.InvNo = int.Parse(CS_0024_003C_003E8__locals1.doc.DocNumber.ToString());
					switch (DocType)
					{
					case 1:
						invoice.AccountNumber = shygunIISetting.DocAccountNumber;
						invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(shygunIISetting.DocAccountGuId)) ? Guid.Parse(shygunIISetting.DocAccountGuId) : Guid.NewGuid());
						break;
					case 2:
						invoice.AccountNumber = shygunIISetting.DraftAccountNumber;
						invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(shygunIISetting.DraftAccountGuId)) ? Guid.Parse(shygunIISetting.DraftAccountGuId) : Guid.NewGuid());
						break;
					case 3:
						invoice.AccountNumber = shygunIISetting.WrhsMovementAccountNumber;
						invoice.AccountGuId = ((!string.IsNullOrWhiteSpace(shygunIISetting.WrhsMovementAccountGuId)) ? Guid.Parse(shygunIISetting.WrhsMovementAccountGuId) : Guid.NewGuid());
						break;
					}
					if (DocType != 3)
					{
						invoice.JobCostingNumber = companyById.cmpLinkAccCode;
						invoice.JobCostingGuId = ((!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr)) ? Guid.Parse(companyById.cmpLinkAccCustomerIdStr) : Guid.NewGuid());
					}
					invoice.InvTyp = num;
					invoice.GuId = CS_0024_003C_003E8__locals1.doc.GUId;
					invoice.InvDescription = CS_0024_003C_003E8__locals1.doc.Description ?? "";
					WSspSelectWareHouse_Result wSspSelectWareHouse_Result = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.doc.WHIdI));
					if ((wSspSelectWareHouse_Result == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr)) && DocType == 3)
					{
						text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, CS_0024_003C_003E8__locals1.doc.WHI ?? "", Labels.ShygunII);
					}
					WSspSelectWareHouse_Result wSspSelectWareHouse_Result2 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals1.doc.WHId));
					if (wSspSelectWareHouse_Result2 == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr))
					{
						text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, CS_0024_003C_003E8__locals1.doc.WH ?? "", Labels.ShygunII);
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						data2 = new CommonResultViewModel<int>
						{
							Data = 0,
							Message = text,
							Status = CommonResultStatusViewModel.Error
						};
						return Json(data2, JsonRequestBehavior.AllowGet);
					}
					invoice.ST1Number = wSspSelectWareHouse_Result2.WrhsLinkAccWhCode;
					invoice.ST1GuId = Guid.Parse(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr);
					if (wSspSelectWareHouse_Result2 != null && DocType == 3)
					{
						invoice.ST1Number = wSspSelectWareHouse_Result.WrhsLinkAccWhCode;
						invoice.ST1GuId = Guid.Parse(wSspSelectWareHouse_Result.WrhsLinkAccWhIdStr);
						invoice.ST2Number = wSspSelectWareHouse_Result2.WrhsLinkAccWhCode;
						invoice.ST2GuId = Guid.Parse(wSspSelectWareHouse_Result2.WrhsLinkAccWhIdStr);
					}
					invoice.UpdateKind = ActionType.insert;
					if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr))
					{
						invoice.GuId = Guid.Parse(CS_0024_003C_003E8__locals1.doc.DocLinkAccDocIdStr);
						invoice.UpdateKind = ActionType.insertOrUpdate;
					}
					if (CS_0024_003C_003E8__locals1.doc.DocDateTime.HasValue)
					{
						invoice.InvDate = CS_0024_003C_003E8__locals1.doc.DocDateTime.Value.ToString("yyyyMMdd", new CultureInfo("en-US"));
					}
					if (CS_0024_003C_003E8__locals1.doc.FirstRegisterDate.HasValue)
					{
						invoice.CreatedDate = CS_0024_003C_003E8__locals1.doc.FirstRegisterDate;
					}
					List<InvoiceBody> list6 = new List<InvoiceBody>();
					List<WSspSelectDocItems_Result> list7 = Enumerable.ToList<WSspSelectDocItems_Result>((IEnumerable<WSspSelectDocItems_Result>)_db.WSspSelectDocItems(CS_0024_003C_003E8__locals1.doc.DocID, lCID, result));
					if (list7 != null && string.IsNullOrWhiteSpace(text))
					{
						using List<WSspSelectDocItems_Result>.Enumerator enumerator2 = list7.GetEnumerator();
						while (enumerator2.MoveNext())
						{
							_003C_003Ec__DisplayClass73_2 CS_0024_003C_003E8__locals2 = new _003C_003Ec__DisplayClass73_2();
							CS_0024_003C_003E8__locals2.docI = enumerator2.Current;
							WSspSelectWareHouse_Result wSspSelectWareHouse_Result3 = Enumerable.FirstOrDefault<WSspSelectWareHouse_Result>((IEnumerable<WSspSelectWareHouse_Result>)list4, (Func<WSspSelectWareHouse_Result, bool>)((WSspSelectWareHouse_Result x) => x.WareHouseID == CS_0024_003C_003E8__locals2.docI.WHId));
							if (wSspSelectWareHouse_Result3 == null || string.IsNullOrWhiteSpace(wSspSelectWareHouse_Result3.WrhsLinkAccWhIdStr))
							{
								text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectWareHouse_Result3.WrhsName ?? "", Labels.ShygunII);
							}
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == CS_0024_003C_003E8__locals2.docI.PrdId));
							if (wSspSelectProductWithAccLinkField_Result == null || string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
							{
								text = text + "<br>" + string.Format(Messages.msgErrorWareHouseNotFoundInAccLink, wSspSelectProductWithAccLinkField_Result.PrdName ?? "", Labels.ShygunII);
							}
							if (string.IsNullOrWhiteSpace(text))
							{
								InvoiceBody invoiceBody = new InvoiceBody();
								invoiceBody.ItemNumber = wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdCode;
								invoiceBody.ItemGuId = Guid.Parse(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr);
								double num2 = CS_0024_003C_003E8__locals2.docI.Quantity.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.docI.FCR.GetValueOrDefault(1.0) * CS_0024_003C_003E8__locals2.docI.FCRI.GetValueOrDefault(1.0);
								invoiceBody.Quan = ((num2 > 0.0) ? decimal.Parse(num2.ToString()) : 0m);
								invoiceBody.LineItemDesc = CS_0024_003C_003E8__locals2.docI.Description;
								invoiceBody.STGuId = Guid.Parse(wSspSelectWareHouse_Result3.WrhsLinkAccWhIdStr);
								invoiceBody.STDesc = wSspSelectWareHouse_Result3.WrhsName;
								invoiceBody.ItemDescription = CS_0024_003C_003E8__locals2.docI.Description ?? "";
								invoiceBody.GuId = Guid.NewGuid();
								invoiceBody.UpdateKind = ActionType.insert;
								if (!string.IsNullOrWhiteSpace(CS_0024_003C_003E8__locals2.docI.DocILinkAccItemIdStr))
								{
									invoiceBody.GuId = Guid.Parse(CS_0024_003C_003E8__locals2.docI.DocILinkAccItemIdStr);
									invoiceBody.UpdateKind = ActionType.insertOrUpdate;
								}
								DbSet<WSDocItems> wSDocItems = _dbTbl.WSDocItems;
								ParameterExpression val = Expression.Parameter(typeof(WSDocItems), "x");
								WSDocItems wSDocItems2 = Queryable.FirstOrDefault<WSDocItems>((IQueryable<WSDocItems>)wSDocItems, Expression.Lambda<Func<WSDocItems, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals2, typeof(_003C_003Ec__DisplayClass73_2)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (wSDocItems2 != null)
								{
									_dbTbl.Entry(wSDocItems2).State = EntityState.Modified;
									wSDocItems2.DocILinkAccItemIdStr = invoiceBody.GuId.ToString();
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
								list6.Add(invoiceBody);
							}
						}
					}
					invoice.Body = list6;
					list5.Add(invoice);
					if (!string.IsNullOrWhiteSpace(text2))
					{
						text2 += ",";
					}
					text2 += CS_0024_003C_003E8__locals1.doc.DocID;
				}
			}
			if (list5 != null && list5.Count > 0 && string.IsNullOrWhiteSpace(text))
			{
				PutResults putResults = new WebServiePutInvoice(shygunIISetting.IP, shygunIISetting.conf, list5).PutOperation();
				if (string.IsNullOrWhiteSpace(putResults.ErrorMessage))
				{
					string[] array = text2.Split(new char[1] { ',' });
					for (int i = 0; i < array.Length; i++)
					{
						text = putResults.Result[i].ErrorMessage;
						if (string.IsNullOrWhiteSpace(text))
						{
							_003C_003Ec__DisplayClass73_3 _003C_003Ec__DisplayClass73_ = new _003C_003Ec__DisplayClass73_3();
							_003C_003Ec__DisplayClass73_.Id = 0;
							int.TryParse(array[i], out _003C_003Ec__DisplayClass73_.Id);
							DbSet<WSDoc> wSDoc5 = _dbTbl.WSDoc;
							ParameterExpression val = Expression.Parameter(typeof(WSDoc), "m");
							WSDoc wSDoc6 = Queryable.FirstOrDefault<WSDoc>((IQueryable<WSDoc>)wSDoc5, Expression.Lambda<Func<WSDoc, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass73_, typeof(_003C_003Ec__DisplayClass73_3)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
							if (wSDoc6 != null)
							{
								_dbTbl.Entry(wSDoc6).State = EntityState.Modified;
								wSDoc6.DocLinkAccDocNumber = putResults.Result[i].Number;
								wSDoc6.DocLinkAccDocIdStr = putResults.Result[i].GuId;
								_dbTbl.Configuration.ValidateOnSaveEnabled = false;
								_dbTbl.SaveChanges();
								_dbTbl.Configuration.ValidateOnSaveEnabled = true;
							}
							else
							{
								text = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsDoc + "|";
							}
						}
					}
				}
				else
				{
					text += putResults.ErrorMessage;
				}
			}
			if (!string.IsNullOrEmpty(text))
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			data2 = new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.FOMsgErrorDoneOperation,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIExportDocList(int oprId, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
			int num = 1;
			foreach (LkDocInfoViewModel item2 in list2)
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = num,
					Id = item2.DocID,
					Selected = string.IsNullOrEmpty(item2.DocLinkAccDocIdStr)
				};
				list.Add(item);
				num++;
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

	[LoginAuthorize]
	public ActionResult ShygunIIManageDocLinkAcc(int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actManageDocLinkAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actManageDraftLinkAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actManageDocLinkAcc";
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
		GetDocOpr(crmDocType);
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		return View();
	}

	[HttpPost]
	public JsonResult ShygunIIDeleteImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageDocLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkShygunIIWSDeleteLinkedDoc_Result> list3 = Enumerable.ToList<CRMspLkShygunIIWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedDoc_Result>)_dbLink.CRMspLkShygunIIWSDeleteLinkedDoc(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunIIWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedDoc_Result>)list3))
				{
					text = "error";
					text5 = GetFileShygunIINotDeletedImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
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

	public string GetFileShygunIINotDeletedImportedInfo(List<CRMspLkShygunIIWSDeleteLinkedDoc_Result> res)
	{
		//IL_0343: Unknown result type (might be due to invalid IL or missing references)
		//IL_035e: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunIIWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkShygunIIWSDeleteLinkedDoc_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListDocNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListDocNumber + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIIWSDeleteLinkedDoc_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocLinkAccDocNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
				string text3 = "CRM-Ideal-" + DateTime.Now.ToString("dd-MM-yyyy-hh-mm-ss") + ".xls";
				string path = text2 + "\\" + text3;
				try
				{
					DirectoryInfo directoryInfo = new DirectoryInfo(text2);
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
					if (System.IO.Directory.Exists(text2))
					{
						System.IO.Directory.Delete(text2);
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				if (!System.IO.Directory.Exists(text2))
				{
					System.IO.Directory.CreateDirectory(text2);
					CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
				}
				using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
				{
					excelRange.Style.Font.Bold = true;
					excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
					excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
					excelRange.Style.Font.Color.SetColor(Color.White);
				}
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text3;
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

	public LkDocInfoViewModelObjects GetNoAvaranCapillaryDocList(int docOprType = 1, string fDate = "", string tDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkDocInfoViewModelObjects lkDocInfoViewModelObjects = new LkDocInfoViewModelObjects();
		List<LkWSDocInfoViewModel> list = new List<LkWSDocInfoViewModel>();
		List<LkWSDocItemsInfoViewModel> list2 = new List<LkWSDocItemsInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
			{
				string date = "";
				string date2 = "";
				try
				{
					DateTime now = DateTime.Now;
					DateTime now2 = DateTime.Now;
					if (!string.IsNullOrWhiteSpace(fDate))
					{
						fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						date = (lCID switch
						{
							1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
							1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
							_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
						}).ToString("yyyy/MM/dd", new PersianCulture());
					}
					if (!string.IsNullOrEmpty(tDate))
					{
						tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
							.Replace(" ", "")
							.Replace("_", "");
						date2 = (lCID switch
						{
							1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
							1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
							_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
						}).ToString("yyyy/MM/dd", new PersianCulture());
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				string value = new CommercialSoapClient().ViewOutput(date, date2);
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<NoAvaranCapillaryDocInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryDocInfoViewModel>>(value);
					if (list3 != null && Enumerable.Any<NoAvaranCapillaryDocInfoViewModel>((IEnumerable<NoAvaranCapillaryDocInfoViewModel>)list3))
					{
						List<WSspSelectDocWithAccLinkField_Result> list4 = SelectDocWithAccLinkField(docOprType, withDocLinkAccCode: false, withDocLinkAccCodeId: false, withDocLinkAccDocId: false, withDocLinkAccDocIdStr: true, withDocLinkAccDocNumber: true);
						int num = 1;
						foreach (NoAvaranCapillaryDocInfoViewModel item in list3)
						{
							bool flag = false;
							if (list != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list) && Enumerable.FirstOrDefault<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list, (Func<LkWSDocInfoViewModel, bool>)((LkWSDocInfoViewModel m) => m.DocLinkAccDocNumber == item.DOC_NO.GetValueOrDefault().ToString())) != null)
							{
								flag = true;
							}
							if (flag)
							{
								continue;
							}
							LkWSDocInfoViewModel vmDoc = new LkWSDocInfoViewModel();
							vmDoc.DocDate = item.DOC_DATE;
							DateTime dateTime = default(DateTime);
							if (!string.IsNullOrWhiteSpace(item.DOC_DATE))
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.DOC_DATE.Replace("/", "")) + " 00:00:00", new PersianCulture());
								vmDoc.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								vmDoc.DocDateTime = dateTime;
							}
							vmDoc.DocLinkAccDocIdStr = item.DOC_NO.GetValueOrDefault().ToString();
							vmDoc.DocLinkAccDocNumber = item.DOC_NO.GetValueOrDefault().ToString();
							vmDoc.cmpLinkAccCode = item.SHOP_CODE ?? "";
							vmDoc.cmpName = item.ShopName ?? "";
							vmDoc.WrhsLinkAccWhIdStr = item.STORE.GetValueOrDefault().ToString();
							vmDoc.WrhsName = item.StoreName ?? "";
							List<NoAvaranCapillaryDocInfoViewModel> list5 = Enumerable.ToList<NoAvaranCapillaryDocInfoViewModel>(Enumerable.Where<NoAvaranCapillaryDocInfoViewModel>((IEnumerable<NoAvaranCapillaryDocInfoViewModel>)list3, (Func<NoAvaranCapillaryDocInfoViewModel, bool>)((NoAvaranCapillaryDocInfoViewModel m) => m.DOC_NO == item.DOC_NO)));
							if (list5 != null && Enumerable.Any<NoAvaranCapillaryDocInfoViewModel>((IEnumerable<NoAvaranCapillaryDocInfoViewModel>)list5))
							{
								foreach (NoAvaranCapillaryDocInfoViewModel item2 in list5)
								{
									LkWSDocItemsInfoViewModel lkWSDocItemsInfoViewModel = new LkWSDocItemsInfoViewModel();
									lkWSDocItemsInfoViewModel.DocLinkAccDocIdStr = item.DOC_NO.GetValueOrDefault().ToString();
									lkWSDocItemsInfoViewModel.DocLinkAccDocNumber = item.DOC_NO.GetValueOrDefault().ToString();
									lkWSDocItemsInfoViewModel.PrdName = item2.KalaName;
									lkWSDocItemsInfoViewModel.PrdLinkAccPrdCode = item2.CODE;
									lkWSDocItemsInfoViewModel.Unit = item2.UnitName;
									lkWSDocItemsInfoViewModel.Quantity = item2.OUT_QUAN.GetValueOrDefault(1.0);
									lkWSDocItemsInfoViewModel.Description = item2.SHARH;
									lkWSDocItemsInfoViewModel.DocILinkAccItemIdStr = item.IdNumber.GetValueOrDefault().ToString();
									list2.Add(lkWSDocItemsInfoViewModel);
								}
							}
							vmDoc.RowNumber = num;
							if (list4 != null && Enumerable.Any<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list4))
							{
								WSspSelectDocWithAccLinkField_Result wSspSelectDocWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list4, (Func<WSspSelectDocWithAccLinkField_Result, bool>)((WSspSelectDocWithAccLinkField_Result x) => x.DocLinkAccDocIdStr == vmDoc.DocLinkAccDocIdStr));
								if (wSspSelectDocWithAccLinkField_Result != null)
								{
									if (!string.IsNullOrWhiteSpace(wSspSelectDocWithAccLinkField_Result.DocLinkAccDocIdStr))
									{
										vmDoc.DocID = wSspSelectDocWithAccLinkField_Result.DocID;
									}
								}
								else
								{
									vmDoc.DocID = 0;
								}
							}
							list.Add(vmDoc);
							num++;
						}
					}
				}
			}
			lkDocInfoViewModelObjects.lst = list;
			lkDocInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkDocInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkDocInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkDocInfoViewModelObjects;
	}

	public LkDocInfoViewModelObjects GetNilramDocList(int docOprType = 1, string fDate = "", string tDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkDocInfoViewModelObjects lkDocInfoViewModelObjects = new LkDocInfoViewModelObjects();
		List<LkWSDocInfoViewModel> list = new List<LkWSDocInfoViewModel>();
		List<LkWSDocItemsInfoViewModel> list2 = new List<LkWSDocItemsInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
			if (nilramSetting != null)
			{
				string text = nilramSetting.ApiAddress ?? "";
				string value = nilramSetting.ApiToken ?? "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(value))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					string text2 = "null";
					string text3 = "null";
					DateTime.Now.ToString("yyyy", new PersianCulture());
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fDate))
						{
							fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							now = lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							};
							text2 = now.ToString("yyyy-MM-dd", new PersianCulture());
							now.ToString("yyyy", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(tDate))
						{
							tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text3 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(tDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					HttpClient httpClient = new HttpClient();
					string text4 = text + "MSTK_H/" + text2 + "/" + text3;
					httpClient.BaseAddress = new Uri(text4);
					httpClient.DefaultRequestHeaders.Add("Access-Token", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.GetAsync(text4).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value2 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							value2 = value2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value2))
						{
							List<NilramDocInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NilramDocInfoViewModel>>(value2);
							if (list3 != null && Enumerable.Any<NilramDocInfoViewModel>((IEnumerable<NilramDocInfoViewModel>)list3))
							{
								List<WSspSelectDocWithAccLinkField_Result> list4 = SelectDocWithAccLinkField(docOprType, withDocLinkAccCode: false, withDocLinkAccCodeId: false, withDocLinkAccDocId: false, withDocLinkAccDocIdStr: true);
								List<CRMspSelectCompanyWithAccLinkField_Result> list5 = new CompanyController().SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
								int num = 1;
								foreach (NilramDocInfoViewModel item in list3)
								{
									bool flag = true;
									if (list != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list))
									{
										LkWSDocInfoViewModel lkWSDocInfoViewModel = Enumerable.FirstOrDefault<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list, (Func<LkWSDocInfoViewModel, bool>)((LkWSDocInfoViewModel m) => m.DocLinkAccDocIdStr == item.id.GetValueOrDefault().ToString()));
										if (lkWSDocInfoViewModel != null && !string.IsNullOrWhiteSpace(lkWSDocInfoViewModel.DocLinkAccDocIdStr))
										{
											flag = false;
										}
									}
									if (!flag)
									{
										continue;
									}
									LkWSDocInfoViewModel vmDoc = new LkWSDocInfoViewModel();
									vmDoc.DocDate = item.t_ins_dte;
									DateTime dateTime = default(DateTime);
									if (!string.IsNullOrWhiteSpace(item.t_ins_dte))
									{
										dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.t_ins_dte.Replace("/", "")) + " 00:00:00", new PersianCulture());
										vmDoc.DocDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
										vmDoc.DocDateTime = dateTime;
									}
									vmDoc.DocLinkAccDocIdStr = item.id.GetValueOrDefault().ToString();
									vmDoc.DocLinkAccDocNumber = item.t_h_no.GetValueOrDefault().ToString();
									if (item.pur_id.GetValueOrDefault() != 0L)
									{
										vmDoc.cmpLinkAccCustomerIdStr = item.pur_id.GetValueOrDefault().ToString();
									}
									if (list5 != null && !string.IsNullOrWhiteSpace(vmDoc.cmpLinkAccCustomerIdStr) && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5))
									{
										CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list5, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerIdStr == vmDoc.cmpLinkAccCustomerIdStr));
										if (cRMspSelectCompanyWithAccLinkField_Result != null)
										{
											vmDoc.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
											vmDoc.cmpName = cRMspSelectCompanyWithAccLinkField_Result.CompanyName ?? "";
											vmDoc.cmpLinkAccCode = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCode;
										}
									}
									if (string.IsNullOrWhiteSpace(vmDoc.cmpName))
									{
										vmDoc.cmpName = string.Format(Labels.OtherSystemsItemNotLinked, Labels.lblCmp);
										if (!string.IsNullOrWhiteSpace(vmDoc.cmpLinkAccCustomerIdStr))
										{
											LkWSDocInfoViewModel lkWSDocInfoViewModel2 = vmDoc;
											lkWSDocInfoViewModel2.cmpName = lkWSDocInfoViewModel2.cmpName + " (" + vmDoc.cmpLinkAccCustomerIdStr + ")";
										}
									}
									List<NilramDocInfoViewModel> list6 = Enumerable.ToList<NilramDocInfoViewModel>((IEnumerable<NilramDocInfoViewModel>)Enumerable.OrderBy<NilramDocInfoViewModel, int>(Enumerable.Where<NilramDocInfoViewModel>((IEnumerable<NilramDocInfoViewModel>)list3, (Func<NilramDocInfoViewModel, bool>)((NilramDocInfoViewModel m) => m.id.GetValueOrDefault() == item.id.GetValueOrDefault())), (Func<NilramDocInfoViewModel, int>)((NilramDocInfoViewModel m) => m.t_radif.GetValueOrDefault())));
									string text5 = "";
									if (list6 != null && Enumerable.Any<NilramDocInfoViewModel>((IEnumerable<NilramDocInfoViewModel>)list6))
									{
										foreach (NilramDocInfoViewModel item2 in list6)
										{
											LkWSDocItemsInfoViewModel lkWSDocItemsInfoViewModel = new LkWSDocItemsInfoViewModel();
											lkWSDocItemsInfoViewModel.DocLinkAccDocIdStr = vmDoc.DocLinkAccDocIdStr;
											lkWSDocItemsInfoViewModel.DocLinkAccDocNumber = vmDoc.DocLinkAccDocNumber;
											lkWSDocItemsInfoViewModel.PrdLinkAccPrdCode = item2.t_stk_gds;
											lkWSDocItemsInfoViewModel.Quantity = item2.t_h_qty.GetValueOrDefault(1.0);
											if (string.IsNullOrWhiteSpace(text5))
											{
												text5 = item2.t_stk_no;
											}
											list2.Add(lkWSDocItemsInfoViewModel);
										}
									}
									vmDoc.WrhsLinkAccWhCode = text5;
									vmDoc.RowNumber = num;
									if (list4 != null && Enumerable.Any<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list4))
									{
										WSspSelectDocWithAccLinkField_Result wSspSelectDocWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectDocWithAccLinkField_Result>((IEnumerable<WSspSelectDocWithAccLinkField_Result>)list4, (Func<WSspSelectDocWithAccLinkField_Result, bool>)((WSspSelectDocWithAccLinkField_Result x) => x.DocLinkAccDocIdStr == vmDoc.DocLinkAccDocIdStr));
										if (wSspSelectDocWithAccLinkField_Result != null)
										{
											if (!string.IsNullOrWhiteSpace(wSspSelectDocWithAccLinkField_Result.DocLinkAccDocIdStr))
											{
												vmDoc.DocID = wSspSelectDocWithAccLinkField_Result.DocID;
											}
										}
										else
										{
											vmDoc.DocID = 0;
										}
									}
									list.Add(vmDoc);
									num++;
								}
							}
						}
					}
				}
			}
			lkDocInfoViewModelObjects.lst = list;
			lkDocInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkDocInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			lkDocInfoViewModelObjects.lstItems = list2;
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkDocInfoViewModelObjects;
	}

	[LoginAuthorize]
	public ActionResult ManageDocLinkAcc(int linkAccSystemId, int docType = 1, int crmDocType = 1)
	{
		string text = "";
		string text2 = "";
		switch (crmDocType)
		{
		case 1:
			text = "frmDoc";
			text2 = "actManageDocLinkAcc";
			break;
		case 2:
			text = "frmDraft";
			text2 = "actManageDraftLinkAcc";
			break;
		case 3:
			text = "frmWareHouseMovement";
			text2 = "actManageDocLinkAcc";
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
		GetDocOpr(crmDocType);
		GetCrmWareHouse();
		base.ViewBag.DocType = docType;
		base.ViewBag.CrmDocType = crmDocType;
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ManageImportDoc_Read([DataSourceRequest] DataSourceRequest request, int linkAccSystemId, int docOprType = 1, string fDate = "", string tDate = "", string records = "")
	{
		//IL_0160: Unknown result type (might be due to invalid IL or missing references)
		List<LkWSDocInfoViewModel> list = new List<LkWSDocInfoViewModel>();
		List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
		OtherSystemSelectedVIiewModel item2 = new OtherSystemSelectedVIiewModel
		{
			Row = 0L,
			Id = "0",
			Selected = false
		};
		list2.Add(item2);
		switch (linkAccSystemId)
		{
		case 18:
		{
			LkDocInfoViewModelObjects noAvaranCapillaryDocList = GetNoAvaranCapillaryDocList(docOprType, fDate, tDate);
			if (noAvaranCapillaryDocList != null)
			{
				list = noAvaranCapillaryDocList.lst;
			}
			break;
		}
		case 20:
		{
			LkDocInfoViewModelObjects nilramDocList = GetNilramDocList(docOprType, fDate, tDate);
			if (nilramDocList != null)
			{
				list = nilramDocList.lst;
			}
			break;
		}
		}
		if (list == null)
		{
			list = new List<LkWSDocInfoViewModel>();
		}
		else if (Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list))
		{
			foreach (LkWSDocInfoViewModel item4 in list)
			{
				item4.DocDate = (item4.DocDateTime.HasValue ? item4.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
				OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
				{
					Row = item4.RowNumber,
					Id = (item4.DocLinkAccDocIdStr ?? "0"),
					Selected = (item4.DocID <= 0)
				};
				list2.Add(item3);
			}
			if (list2 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (list3 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item in list3)
						{
							if (Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Row == item.Row)) != null)
							{
								Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Row == item.Row)).Selected = item.Selected;
							}
						}
					}
				}
				int num = 0;
				if (request != null)
				{
					int page = request.Page;
					int pageSize = request.PageSize;
					if (page > 1)
					{
						num = page * pageSize - pageSize;
					}
				}
				string listItemRecords = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2));
				if (Enumerable.Count<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list) >= num && list[num] != null)
				{
					list[num].ListItemRecords = listItemRecords;
				}
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageImportDocList(string records, int linkAccSystemId, int docOprType = 1, string fDate = "", string tDate = "")
	{
		//IL_00d8: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			List<LkWSDocInfoViewModel> list2 = new List<LkWSDocInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 18:
			{
				LkDocInfoViewModelObjects noAvaranCapillaryDocList = GetNoAvaranCapillaryDocList(docOprType, fDate, tDate);
				if (noAvaranCapillaryDocList != null)
				{
					list2 = noAvaranCapillaryDocList.lst;
				}
				break;
			}
			case 20:
			{
				LkDocInfoViewModelObjects nilramDocList = GetNilramDocList(docOprType, fDate, tDate);
				if (nilramDocList != null)
				{
					list2 = nilramDocList.lst;
				}
				break;
			}
			}
			if (list2 != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list2))
			{
				foreach (LkWSDocInfoViewModel item2 in list2)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item2.RowNumber,
						Id = (item2.DocLinkAccDocIdStr ?? "0"),
						Selected = (item2.DocID <= 0)
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list3)
						{
							foreach (OtherSystemSelectedVIiewModel item4 in list)
							{
								if (item4.Row == item3.Row)
								{
									item4.Selected = item3.Selected;
								}
							}
						}
					}
				}
			}
			else
			{
				list = new List<OtherSystemSelectedVIiewModel>();
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

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ManageDocImportInfo(string records, int linkAccSystemId, int docOprId = 0, int whId = 0, string fDate = "", string tDate = "", int docOprType = 1, int whIdI = 0)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0743: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			string prjTitle = "";
			int value4 = 0;
			List<LkWSDocInfoViewModel> list3 = new List<LkWSDocInfoViewModel>();
			List<LkWSDocItemsInfoViewModel> list4 = new List<LkWSDocItemsInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 18:
			{
				LkDocInfoViewModelObjects noAvaranCapillaryDocList = GetNoAvaranCapillaryDocList(docOprType, fDate, tDate);
				if (noAvaranCapillaryDocList != null)
				{
					List<LkWSDocInfoViewModel> lst2 = noAvaranCapillaryDocList.lst;
					if (lst2 != null)
					{
						if (Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)lst2))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item in list)
								{
									LkWSDocInfoViewModel lkWSDocInfoViewModel2 = Enumerable.FirstOrDefault<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)lst2, (Func<LkWSDocInfoViewModel, bool>)((LkWSDocInfoViewModel x) => x.DocLinkAccDocIdStr == item.Id));
									if (lkWSDocInfoViewModel2 != null)
									{
										list3.Add(lkWSDocInfoViewModel2);
									}
								}
							}
							List<LkWSDocItemsInfoViewModel> lstItems2 = noAvaranCapillaryDocList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list3) && lstItems2 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)lstItems2))
							{
								foreach (LkWSDocInfoViewModel ord in list3)
								{
									List<LkWSDocItemsInfoViewModel> list6 = Enumerable.ToList<LkWSDocItemsInfoViewModel>(Enumerable.Where<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)lstItems2, (Func<LkWSDocItemsInfoViewModel, bool>)((LkWSDocItemsInfoViewModel m) => m.DocLinkAccDocIdStr == ord.DocLinkAccDocIdStr)));
									if (list6 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list6))
									{
										list4.AddRange(list6);
									}
								}
							}
						}
						else
						{
							string text5 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e4 = new Exception(text5);
							ErrorSignal.FromCurrentContext().Raise(e4);
							text = text5;
						}
					}
					else
					{
						string text6 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e5 = new Exception(text6);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text6;
					}
				}
				else
				{
					string text7 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e6 = new Exception(text7);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text7;
				}
				CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
				if (noAvaranCapillarySetting != null)
				{
					prjTitle = noAvaranCapillarySetting.DefPrjTitle;
					value4 = noAvaranCapillarySetting.DefPrjCvnsStatusGroupId;
				}
				break;
			}
			case 20:
			{
				LkDocInfoViewModelObjects nilramDocList = GetNilramDocList(docOprType, fDate, tDate);
				if (nilramDocList != null)
				{
					List<LkWSDocInfoViewModel> lst = nilramDocList.lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)lst))
						{
							if (list != null)
							{
								foreach (OtherSystemSelectedVIiewModel item2 in list)
								{
									LkWSDocInfoViewModel lkWSDocInfoViewModel = Enumerable.FirstOrDefault<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)lst, (Func<LkWSDocInfoViewModel, bool>)((LkWSDocInfoViewModel x) => x.DocLinkAccDocIdStr == item2.Id));
									if (lkWSDocInfoViewModel != null)
									{
										list3.Add(lkWSDocInfoViewModel);
									}
								}
							}
							List<LkWSDocItemsInfoViewModel> lstItems = nilramDocList.lstItems;
							if (list3 != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list3) && lstItems != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)lstItems))
							{
								foreach (LkWSDocInfoViewModel ord2 in list3)
								{
									List<LkWSDocItemsInfoViewModel> list5 = Enumerable.ToList<LkWSDocItemsInfoViewModel>(Enumerable.Where<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)lstItems, (Func<LkWSDocItemsInfoViewModel, bool>)((LkWSDocItemsInfoViewModel m) => m.DocLinkAccDocIdStr == ord2.DocLinkAccDocIdStr)));
									if (list5 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list5))
									{
										list4.AddRange(list5);
									}
								}
							}
						}
						else
						{
							string text2 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
							Exception e = new Exception(text2);
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text2;
						}
					}
					else
					{
						string text3 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
						Exception e2 = new Exception(text3);
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = text3;
					}
				}
				else
				{
					string text4 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
					Exception e3 = new Exception(text4);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = text4;
				}
				CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
				if (nilramSetting != null)
				{
					prjTitle = nilramSetting.DefPrjTitle;
					value4 = nilramSetting.DefPrjCvnsStatusGroupId;
				}
				break;
			}
			}
			int result2 = 0;
			if (list3 != null && Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list3) && string.IsNullOrWhiteSpace(text))
			{
				int num2;
				int num3 = (num2 = Enumerable.Count<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list3));
				_ = new long[num3];
				int num4 = 100;
				int num5 = num3 / num4;
				int num6 = num3 % num4;
				int num7 = 0;
				int num8 = num4;
				if (num6 != 0)
				{
					num5++;
				}
				for (int i = 0; i < num5; i++)
				{
					if (i == num5 - 1 && num6 != 0)
					{
						num8 = num6;
					}
					List<LkWSDocInfoViewModel> list7 = new List<LkWSDocInfoViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list7.Add(list3[num7]);
					}
					if (list7 == null || !Enumerable.Any<LkWSDocInfoViewModel>((IEnumerable<LkWSDocInfoViewModel>)list7))
					{
						continue;
					}
					string docJson = JsonConvert.SerializeObject(list7);
					List<LkWSDocItemsInfoViewModel> list8 = new List<LkWSDocItemsInfoViewModel>();
					foreach (LkWSDocInfoViewModel doc in list7)
					{
						if (list4 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list4))
						{
							List<LkWSDocItemsInfoViewModel> list9 = Enumerable.ToList<LkWSDocItemsInfoViewModel>(Enumerable.Where<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list4, (Func<LkWSDocItemsInfoViewModel, bool>)((LkWSDocItemsInfoViewModel m) => (m.DocLinkAccDocIdStr ?? "") == (doc.DocLinkAccDocIdStr ?? "") && (m.DocLinkAccDocNumber ?? "") == (doc.DocLinkAccDocNumber ?? ""))));
							if (list9 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list9))
							{
								list8.AddRange(list9);
							}
						}
					}
					string docItemJson = "";
					if (list8 != null && Enumerable.Any<LkWSDocItemsInfoViewModel>((IEnumerable<LkWSDocItemsInfoViewModel>)list8))
					{
						docItemJson = JsonConvert.SerializeObject(list8);
					}
					ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
					mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkWSIssueOrUpdateDocByJson(linkAccSystemId, docOprId, whId, (whIdI == 0) ? null : new int?(docOprId), docJson, docItemJson, value4, prjTitle, userId, id, value2, value3, value, registerDatePersian, appType, lCID, result, objectParameter, centerId));
					string text8 = "";
					if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
					{
						text8 = objectParameter.Value.ToString();
						if (!string.IsNullOrWhiteSpace(text8))
						{
							string[] array = text8.Split(new char[1] { '|' });
							if (array != null)
							{
								if (array.Length > 1)
								{
									if (array[0] == "0")
									{
										string text9 = array[1];
										if (!string.IsNullOrWhiteSpace(text9))
										{
											List<LkErrorInfoViewModel> list10 = new JavaScriptSerializer().Deserialize<List<LkErrorInfoViewModel>>(text9);
											if (list10 != null && Enumerable.Any<LkErrorInfoViewModel>((IEnumerable<LkErrorInfoViewModel>)list10))
											{
												foreach (LkErrorInfoViewModel item3 in list10)
												{
													string text10 = "";
													if (!string.IsNullOrWhiteSpace(item3.Type))
													{
														if (item3.Type == "1")
														{
															text10 = Messages.msgerrorOtherSystemNotFindDocCmp;
															text10 = string.Format(text10, item3.Extra ?? "", item3.Number ?? "", "CRM");
														}
														else if (item3.Type == "2")
														{
															text10 = Messages.msgErrorOtherSystemNotDefineDocItems;
														}
														else if (item3.Type == "3")
														{
															text10 = Messages.msgerrorOtherSystemNotFindPrd;
															text10 = string.Format(text10, item3.Extra ?? "", item3.Number ?? "", "CRM");
														}
														else if (item3.Type == "4")
														{
															text10 = Messages.msgerrorOtherSystemNotFindDocItem;
															text10 = string.Format(text10, item3.Number ?? "");
														}
														else if (item3.Type == "5")
														{
															text10 = Messages.msgerrorOtherSystemNotInsertDocPrs;
															text10 = string.Format(text10, item3.Number ?? "");
														}
														else if (item3.Type == "6")
														{
															text10 = Messages.msgerrorOtherSystemNotInsertDocPrj;
															text10 = string.Format(text10, item3.Number ?? "");
														}
														else if (item3.Type == "7")
														{
															text10 = Messages.msgerrorOtherSystemNotInsertDoc;
															text10 = string.Format(text10, item3.Number ?? "");
														}
														else if (item3.Type == "8")
														{
															text10 = Messages.msgerrorOtherSystemNotInsertDocItems;
															text10 = string.Format(text10, item3.Number ?? "");
														}
													}
													if (!string.IsNullOrWhiteSpace(text10))
													{
														text = text + "<br>" + text10;
													}
												}
											}
										}
									}
								}
								else if (!string.IsNullOrWhiteSpace(array[0]))
								{
									text = text + "<br>" + array[0];
								}
							}
						}
					}
					if (mct_Link_Result != null)
					{
						int.TryParse(mct_Link_Result.Result.ToString(), out result2);
					}
					int num9 = num7 * 100 / num2;
					if (num9 >= 100)
					{
						num9 = 100;
					}
					ProgressHub.SendMessage("ok", num9, userId);
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (result2 == 0)
			{
				if (!string.IsNullOrWhiteSpace(text))
				{
					num = 0;
					commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					ProgressHub.SendMessage(text, 0, userId);
				}
				else
				{
					num = 0;
					commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
					ProgressHub.SendMessage(Messages.msgErrorRunFunction, 0, userId);
				}
			}
			else
			{
				text = (string.IsNullOrWhiteSpace(text) ? "" : (Messages.msgOperationCompleted + "<br>" + Labels.Error + ":<br>" + text));
				num = 1;
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
		}
		data = new CommonResultViewModel<int>
		{
			Data = num,
			Message = text,
			Status = commonResultStatusViewModel
		};
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ManageExportDoc_Read([DataSourceRequest] DataSourceRequest request, int oprId = 0, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		List<LkDocInfoViewModel> list = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
		if (list != null && Enumerable.Any<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list))
		{
			foreach (LkDocInfoViewModel item in list)
			{
				item.DocDate = (item.DocDateTime.HasValue ? item.DocDateTime.Value.ToString("yyyy/MM/dd") : "");
			}
		}
		if (list == null)
		{
			list = new List<LkDocInfoViewModel>();
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageExportDocList(string records, int oprId, string fDate = "", string tDate = "", int value = 0, int currentItemId = 0)
	{
		//IL_009e: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<LkDocInfoViewModel> list2 = SelectDocExport(oprId, fDate, tDate, value, currentItemId);
			if (list2 != null && Enumerable.Any<LkDocInfoViewModel>((IEnumerable<LkDocInfoViewModel>)list2))
			{
				foreach (LkDocInfoViewModel item2 in list2)
				{
					OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
					{
						Row = item2.RowNumber,
						Id = item2.DocID,
						Selected = string.IsNullOrEmpty(item2.DocLinkAccDocIdStr)
					};
					list.Add(item);
				}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list3 = new List<OtherSystemSelectedVIiewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list3))
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list3)
						{
							foreach (OtherSystemSelectedViewModel item4 in list)
							{
								if (item4.Row == item3.Row)
								{
									item4.Selected = item3.Selected;
								}
							}
						}
					}
				}
			}
			else
			{
				list = new List<OtherSystemSelectedViewModel>();
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

	[DynamicAuthorize(ControllerName = "frmManageDocLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ManageDocExportInfo(string records, int oprId, string fDate, string tDate, int value, int docType = 1, int currentItemId = 0)
	{
		//IL_00e9: Unknown result type (might be due to invalid IL or missing references)
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
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (list != null)
				{
					list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
				}
			}
			text = "";
			int num = 0;
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					num = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num2 = 0;
					foreach (OtherSystemSelectedViewModel item in list2)
					{
						_ = item;
						string text2 = "";
						_ = 18;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								if (!string.IsNullOrWhiteSpace(array[1]))
								{
									num2++;
									int count = num2 * 100 / num;
									ProgressHub.SendMessage("ok", count, userId);
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorRunFunction;
									num2++;
									int count2 = num2 * 100 / num;
									ProgressHub.SendMessage(Messages.msgErrorRunFunction, count2, userId);
								}
							}
							else
							{
								text = text + "<br>" + array[0];
								num2++;
								int count3 = num2 * 100 / num;
								ProgressHub.SendMessage(array[0], count3, userId);
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorRunFunction;
						}
					}
				}
				else
				{
					text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				}
			}
			if (!string.IsNullOrEmpty(text))
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
			text = "";
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

	[HttpPost]
	public JsonResult DeleteDocImportedInfo(string records)
	{
		//IL_00c4: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		string text2 = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageDocLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(records))
			{
				text3 = text3 + Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				if (!string.IsNullOrWhiteSpace(records))
				{
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						list = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
					}
				}
			}
			string text4 = "";
			if (list == null && !Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			else
			{
				foreach (OtherSystemSelectedVIiewModel item in list)
				{
					text4 = text4 + item.Id + ",";
				}
			}
			if (string.IsNullOrWhiteSpace(text4))
			{
				text3 = Messages.msgErrorNotSelectedItem + "<br>";
				num++;
			}
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkWSDeleteLinkedDoc_Result> list3 = Enumerable.ToList<CRMspLkWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkWSDeleteLinkedDoc_Result>)_dbLink.CRMspLkWSDeleteLinkedDoc(result2, text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkWSDeleteLinkedDoc_Result>)list3))
				{
					text = "error";
					text5 = GetFileNotDeletedDocImportedInfo(list3);
				}
				if (!string.IsNullOrWhiteSpace(text5))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text5 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
				}
				else
				{
					text2 = Messages.msgSuccessAction;
				}
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			else
			{
				text = "";
				text2 = text3;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = "";
			data = new CommonResultViewModel<string>
			{
				Data = text,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data, JsonRequestBehavior.AllowGet);
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

	public string GetFileNotDeletedDocImportedInfo(List<CRMspLkWSDeleteLinkedDoc_Result> res)
	{
		//IL_037b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0396: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkWSDeleteLinkedDoc_Result>((IEnumerable<CRMspLkWSDeleteLinkedDoc_Result>)res))
			{
				int result2 = 0;
				string text2 = "";
				CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
				if (cRMspSelectCrmsysSetting_Result != null)
				{
					int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
				}
				text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = string.Format(Labels.OtherSystemsImListDocNumber, "CRM");
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsImListDocNumber + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkWSDeleteLinkedDoc_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.DocLinkAccDocNumber ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.CompanyName ?? "";
					string redundancyMessage = Messages.RedundancyMessage;
					num++;
					excelWorksheet.Cells[num2, num].Value = redundancyMessage;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccNotDeletedInfo\\" + userId;
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
				excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
				excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
				Stream stream = System.IO.File.Create(path);
				excelPackage.SaveAs(stream);
				stream.Close();
				if (System.IO.File.Exists(path))
				{
					text = Configuration.HostTempFilesPath + "/ReportLinkAccNotDeletedInfo/" + userId + "/" + text4;
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

	[HttpPost]
	[LoginAuthorize]
	public string GetLinkAccThreadResult(int indx = -1)
	{
		ThreadHub.ThreadHubObj threadResult = ThreadHub.GetThreadResult(indx);
		if (threadResult.IsDone.GetValueOrDefault() || threadResult.IsDone == false)
		{
			ThreadHub.RemoveThread(indx, autoEmpty: true);
		}
		return JsonConvert.SerializeObject(threadResult);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbLink.Dispose();
		_db_I.Dispose();
		base.Dispose(disposing);
	}
}
