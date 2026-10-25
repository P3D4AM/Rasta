using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
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
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.OtherWebServices.LinkNoAvanran_II;
using CRM.OtherWebServices.LinkNoAvaranCapillary;
using CRM.Resources;
using CRMIdeal.Areas.Setting.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using CRMIdeal.Hubs;
using CRMIdeal.LinkKyan;
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

public class ProductController : Controller
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

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	public static HttpContext context = HttpContext.Current;

	[JsonIgnore]
	private string JsonRender;

	public ActionResult SepPrdSendToAcc(int prdId, int position = 0)
	{
		string formName = "frmProducts";
		string actionName = "actSendToAcc";
		if (position == 1)
		{
			formName = "frmPrdLinkAccDetails";
			actionName = "actAddLinkPrdToAcc";
		}
		if (!UserLogin.IsUserAccess(formName, actionName, UserLogin.CurrentUser))
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
	public string SepActSendToAcc(int prdId, int position = 0, int linkAccSettingDBId = 0, bool sepCanChangeInvoiceFee = true, bool sepCanChangeInvoiceDiscount = true, bool useCrmPrdCode = false, bool useCrmPrdCodeInError = false)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			string formName = "frmProducts";
			string actionName = "actSendToAcc";
			if (position == 1)
			{
				formName = "frmPrdLinkAccDetails";
				actionName = "actAddLinkPrdToAcc";
			}
			if (!UserLogin.IsUserAccess(formName, actionName, currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				if (Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result)) != null)
				{
					ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("accPrdCode", "");
					_dbLink.CRMspLkSepWSInsertUpdateProduct(prdId, 0, UserLogin.CurrentUser.UserId, Configuration.AppType, insertedId, objectParameter2, objectParameter, linkAccSettingDBId, sepCanChangeInvoiceFee, sepCanChangeInvoiceDiscount, useCrmPrdCode, useCrmPrdCodeInError);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							return objectParameter.Value.ToString();
						}
						string text2 = "";
						if (objectParameter2.Value != null)
						{
							text2 = objectParameter2.Value.ToString() ?? "";
						}
						return "1|" + text2;
					}
					string text3 = "";
					if (objectParameter2.Value != null)
					{
						text3 = objectParameter2.Value.ToString() ?? "";
					}
					return "1|" + text3;
				}
				return Messages.ErrorNotFound + "|";
			}
			return Messages.ErrorNotFound + "|";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction + "|";
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult SepImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult SepProduct_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "", string fromPrdCode = "", string toPrdCode = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkSepWSSelectProductFromSep_Result> enumerable = new List<CRMspLkSepWSSelectProductFromSep_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkSepWSSelectProductFromSep_Result>((IEnumerable<CRMspLkSepWSSelectProductFromSep_Result>)_dbLink.CRMspLkSepWSSelectProductFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, fromPrdCode, toPrdCode, linkAccSettingDBId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepImportInfo(string records, int prdGroupId, int prdPriceGroupId, int pageNumber, string fDate = "", string tDate = "", string value = "", string sepSaleTypes = "", string fromPrdCode = "", string toPrdCode = "", int linkAccSettingDBId = 0, int pagesCnt = 0, bool useSepPrdCode = false, bool canDupPrdCode = false, bool useSepPrdCodeInError = false)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepImportInfoAsync(records, prdGroupId, prdPriceGroupId, pageNumber, fDate, tDate, value, sepSaleTypes, fromPrdCode, toPrdCode, linkAccSettingDBId, pagesCnt, indx, canDupPrdCode: canDupPrdCode, useSepPrdCode: useSepPrdCode, useSepPrdCodeInError: useSepPrdCodeInError);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepImportInfoAsync(string records, int prdGroupId, int prdPriceGroupId, int pageNumber, string fDate = "", string tDate = "", string value = "", string sepSaleTypes = "", string fromPrdCode = "", string toPrdCode = "", int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0, bool useSepPrdCode = false, bool canDupPrdCode = false, bool useSepPrdCodeInError = false)
	{
		//IL_01c5: Unknown result type (might be due to invalid IL or missing references)
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
			int id = Financial.Get().Id;
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
			if (!string.IsNullOrEmpty(sepSaleTypes))
			{
				sepSaleTypes = sepSaleTypes.Replace("|", ",");
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
						ObjectParameter insertedPrdId = new ObjectParameter("insertedPrdId", 0);
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						cRMLinkSpEntities.CRMspLkSepWSInsertUpdateProductFromSep(item.Id, prdGroupId, prdPriceGroupId, userId, value3, id, value2, registerDatePersian, appType, result, insertedPrdId, objectParameter, sepSaleTypes, linkAccSettingDBId, centerId, canDupPrdCode, useSepPrdCode, useSepPrdCodeInError);
						string text2 = "";
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							if (!string.IsNullOrWhiteSpace(text2))
							{
								text2 += "<br>";
							}
							text2 += objectParameter.Value.ToString();
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
	public JsonResult GetSepImportProductList(string records, int totalPage, string fDate = "", string tDate = "", string value = "", string fromPrdCode = "", string toPrdCode = "", int linkAccSettingDBId = 0)
	{
		//IL_022d: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepWSSelectProductFromSep_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectProductFromSep_Result>((IEnumerable<CRMspLkSepWSSelectProductFromSep_Result>)_dbLink.CRMspLkSepWSSelectProductFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, fromPrdCode, toPrdCode, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.ItemID.GetValueOrDefault(),
					Selected = !item2.ProductId.HasValue
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actExportToAcc")]
	public ActionResult SepExportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult SepExportProduct_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0, int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkSepWSSelectProduct_Result> list = new List<CRMspLkSepWSSelectProduct_Result>();
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
			list = Enumerable.ToList<CRMspLkSepWSSelectProduct_Result>((IEnumerable<CRMspLkSepWSSelectProduct_Result>)_dbLink.CRMspLkSepWSSelectProduct((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, fgId, sgId, pageNumber, value2, lCID, result, linkAccSettingDBId));
			foreach (CRMspLkSepWSSelectProduct_Result item in list)
			{
				item.PrdName = ((!string.IsNullOrEmpty(item.PrdFGroupName)) ? item.PrdFGroupName : "") + ((!string.IsNullOrEmpty(item.PrdSGroupName)) ? (" - " + item.PrdSGroupName) : "") + ((!string.IsNullOrEmpty(item.PrdName)) ? (" - " + item.PrdName) : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepExportInfo(string records, int pageNumber, int prdPriceGroupId, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, bool sepCanChangeInvoiceFee = true, bool sepCanChangeInvoiceDiscount = true, bool useCrmPrdCode = false, bool useCrmPrdCodeInError = false)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepExportInfoAsync(records, pageNumber, prdPriceGroupId, fDate, tDate, value, fgId, sgId, linkAccSettingDBId, pagesCnt, indx, sepCanChangeInvoiceFee, sepCanChangeInvoiceDiscount, useCrmPrdCode, useCrmPrdCodeInError);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepExportInfoAsync(string records, int pageNumber, int prdPriceGroupId, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0, bool sepCanChangeInvoiceFee = true, bool sepCanChangeInvoiceDiscount = true, bool useCrmPrdCode = false, bool useCrmPrdCodeInError = false)
	{
		//IL_01aa: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CRMLinkSpEntities cRMLinkSpEntities = new CRMLinkSpEntities();
		CRMSpEntities cRMSpEntities = new CRMSpEntities();
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
							if (Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)cRMSpEntities.WSspSelectProductsWithId(item.Id, lCID, result)) != null)
							{
								ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
								ObjectParameter accPrdCode = new ObjectParameter("accPrdCode", "");
								cRMLinkSpEntities.CRMspLkSepWSInsertUpdateProduct(item.Id, prdPriceGroupId, userId, appType, insertedId, accPrdCode, objectParameter, linkAccSettingDBId, sepCanChangeInvoiceFee, sepCanChangeInvoiceDiscount, useCrmPrdCode, useCrmPrdCodeInError);
								string text2 = "";
								if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
								{
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 += "<br>";
									}
									text2 += objectParameter.Value.ToString();
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
			cRMSpEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepExportProductList(string records, int totalPage, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0, int linkAccSettingDBId = 0)
	{
		//IL_0237: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepWSSelectProduct_Result item2 in Enumerable.ToList<CRMspLkSepWSSelectProduct_Result>((IEnumerable<CRMspLkSepWSSelectProduct_Result>)_dbLink.CRMspLkSepWSSelectProduct((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, fgId, sgId, value3, value2, lCID, result, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.ProductID.GetValueOrDefault(),
					Selected = !item2.PrdLinkAccPrdId.HasValue
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
	public JsonResult ListSepSaleType(string parameters, string extra = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CommonMultiSelectorViewModel> data = new List<CommonMultiSelectorViewModel>();
		try
		{
			string[] arrSelected = extra.Split(new char[1] { '|' });
			int result2 = 0;
			if (!string.IsNullOrWhiteSpace(parameters))
			{
				int.TryParse(parameters, out result2);
			}
			data = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<CRMspLkSepSelectSaleType_Result>)Enumerable.ToList<CRMspLkSepSelectSaleType_Result>((IEnumerable<CRMspLkSepSelectSaleType_Result>)_dbLink.CRMspLkSepSelectSaleType(result2, lCID, result)), (CRMspLkSepSelectSaleType_Result item) => new
			{
				item = item,
				sel = Array.Exists(arrSelected, (string element) => element == item.SaleTypeId.ToString())
			}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
			{
				Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.SaleTypeId.ToString()),
				Name = _003C_003Eh__TransparentIdentifier0.item.Title,
				Selected = _003C_003Eh__TransparentIdentifier0.sel
			}));
		}
		catch (DbEntityValidationException e)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)e);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return Json(data, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actLinkPrdWithAcc")]
	public ActionResult SepLinkedProduct()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "PrdLinkAccPrdCode";
		base.ViewBag.SyncField = text;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[HttpPost]
	public JsonResult ActSepLinkedProduct(string syncField, int mode, int linkAccSettingDBId)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LinkedProductWithAccViewModel> list = new List<LinkedProductWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmProducts", "actLinkPrdWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			if (num == 0)
			{
				JsonConvert.SerializeObject(Enumerable.ToList<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list));
				string text4 = "";
				text = "";
				List<CRMspLkSepWSLinkedProduct_Result> list2 = Enumerable.ToList<CRMspLkSepWSLinkedProduct_Result>((IEnumerable<CRMspLkSepWSLinkedProduct_Result>)_dbLink.CRMspLkSepWSLinkedProduct(syncField, mode, lCID, result, linkAccSettingDBId));
				if (list2 != null && Enumerable.Any<CRMspLkSepWSLinkedProduct_Result>((IEnumerable<CRMspLkSepWSLinkedProduct_Result>)list2))
				{
					text = "error";
					text4 = GetFileSepLinkedProduct(list2);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
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

	public string GetFileSepLinkedProduct(List<CRMspLkSepWSLinkedProduct_Result> res)
	{
		//IL_0489: Unknown result type (might be due to invalid IL or missing references)
		//IL_04a4: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkSepWSLinkedProduct_Result>((IEnumerable<CRMspLkSepWSLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.Sepidar + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkSepWSLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
					num++;
					string value = "";
					if (re.Type.HasValue)
					{
						if (re.Type.GetValueOrDefault() == 1)
						{
							value = Labels.Sepidar;
						}
						else if (re.Type.GetValueOrDefault() == 2)
						{
							value = "CRM";
						}
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorPrdNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupPrdLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupPrdCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorPrdNotInLinkAcc, Labels.Sepidar);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text3;
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actPrdLinkAccDetails")]
	public ActionResult SepPrdLinkAccDetails(int prdId)
	{
		base.ViewBag.PrdId = prdId;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetPrdLinkAccDetails(int prdId, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepPrdLinkAccDetailsViewModel sepPrdLinkAccDetailsViewModel = new SepPrdLinkAccDetailsViewModel();
		sepPrdLinkAccDetailsViewModel.ProductInfo = new CRMspLkSepWSSelectProductById_Result();
		sepPrdLinkAccDetailsViewModel.IsFind = false;
		try
		{
			if (prdId != 0)
			{
				sepPrdLinkAccDetailsViewModel.ProductInfo = Enumerable.FirstOrDefault<CRMspLkSepWSSelectProductById_Result>((IEnumerable<CRMspLkSepWSSelectProductById_Result>)_dbLink.CRMspLkSepWSSelectProductById(prdId, lCID, result, linkAccSettingDBId));
				if (sepPrdLinkAccDetailsViewModel.ProductInfo != null)
				{
					sepPrdLinkAccDetailsViewModel.IsFind = true;
					sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccFirstTransferDateStr = (sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccFirstTransferDate.HasValue ? sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccLastTransferDateStr = (sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccLastTransferDate.HasValue ? sepPrdLinkAccDetailsViewModel.ProductInfo.PrdLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				else
				{
					sepPrdLinkAccDetailsViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				sepPrdLinkAccDetailsViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			sepPrdLinkAccDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(sepPrdLinkAccDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SepDeleteProductInfo(int prdId, int mode, int position, int linkAccSettingDBId)
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
				actionName = "actDelLinkPrdInAcc";
				break;
			case 2:
				actionName = "actDelLinkPrdInCrm";
				break;
			}
			if (!UserLogin.IsUserAccess("frmPrdLinkAccDetails", actionName, currentUser))
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
			if (prdId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short.Parse(Financial.Get().Id.ToString());
				int id = Financial.Get().Id;
				int userId = currentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkSepWSDeleteProductInfoFromSep(prdId, userId, value2, id, value, registerDatePersian, appType, objectParameter, mode, linkAccSettingDBId);
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSendToAcc")]
	public ActionResult NoAvPrdSendToAcc()
	{
		GetPrdPriceGroup();
		return View();
	}

	[AjaxOnly]
	public string NoAvActSendToAcc(int prdId, string comDbName, string whDbName, int codeStore, int prdPriceGroupId)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmProducts", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				if (Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result)) != null)
				{
					ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("insertedCode", "");
					_dbLink.CRMspLkNoAvWSInsertUpdateProduct(prdId, prdPriceGroupId, codeStore, comDbName, whDbName, UserLogin.CurrentUser.UserId, Configuration.AppType, insertedId, objectParameter2, objectParameter);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							return objectParameter.Value.ToString();
						}
						string text2 = "";
						if (objectParameter2.Value != null)
						{
							text2 = objectParameter2.Value.ToString() ?? "";
						}
						return "1|" + text2;
					}
					string text3 = "";
					if (objectParameter2.Value != null)
					{
						text3 = objectParameter2.Value.ToString() ?? "";
					}
					return "1|" + text3;
				}
				return Messages.ErrorNotFound + "|";
			}
			return Messages.ErrorNotFound + "|";
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction + "|";
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actExportToAcc")]
	public ActionResult NoAvExportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvExportProduct_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkNoAvWSSelectProduct_Result> list = new List<CRMspLkNoAvWSSelectProduct_Result>();
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
			list = Enumerable.ToList<CRMspLkNoAvWSSelectProduct_Result>((IEnumerable<CRMspLkNoAvWSSelectProduct_Result>)_dbLink.CRMspLkNoAvWSSelectProduct((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, fgId, sgId, pageNumber, value2, lCID, result));
			foreach (CRMspLkNoAvWSSelectProduct_Result item in list)
			{
				item.PrdName = ((!string.IsNullOrEmpty(item.PrdFGroupName)) ? item.PrdFGroupName : "") + ((!string.IsNullOrEmpty(item.PrdSGroupName)) ? (" - " + item.PrdSGroupName) : "") + ((!string.IsNullOrEmpty(item.PrdName)) ? (" - " + item.PrdName) : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult NoAvExportInfo(string records, string comDbName, string whDbName, int codeStore, int pageNumber, int prdPriceGroupId, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		//IL_01a0: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			_ = Financial.Get().Id;
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
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
			string text2 = "";
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
							text2 = text2 + item.Id + ",";
						}
					}
				}
			}
			ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
			CRMLinkSpEntities dbLink = _dbLink;
			int? prdPriceGroupId2 = prdPriceGroupId;
			int? noAvCodeStore = codeStore;
			DateTime? fDate2 = ((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null);
			DateTime? tDATE = ((!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null);
			int? firstGroupId = fgId;
			int? secondGroupId = sgId;
			int? pageNumber2 = pageNumber;
			int? pageSize = value2;
			int? userId2 = userId;
			string appType2 = appType;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			ObjectParameter errorMessage = objectParameter;
			dbLink.CRMspLkNoAvWSExportProduct(prdPriceGroupId2, comDbName, whDbName, noAvCodeStore, fDate2, tDATE, value, text2, firstGroupId, secondGroupId, pageNumber2, pageSize, userId2, appType2, languageID, defaultLanguageID, errorMessage);
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
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
	public JsonResult GetNoAvExportProductList(string records, int totalPage, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		//IL_0228: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkNoAvWSSelectProduct_Result item2 in Enumerable.ToList<CRMspLkNoAvWSSelectProduct_Result>((IEnumerable<CRMspLkNoAvWSSelectProduct_Result>)_dbLink.CRMspLkNoAvWSSelectProduct((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, fgId, sgId, value3, value2, lCID, result)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.ProductID,
					Selected = !item2.PrdLinkAccPrdId.HasValue
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult TarazImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult TarazProduct_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string value = "", string code = "")
	{
		//IL_0729: Unknown result type (might be due to invalid IL or missing references)
		//IL_072e: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<TarazProductsViewModel> list = new List<TarazProductsViewModel>();
		try
		{
			int num = 200;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list2 != null)
			{
				string text = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
				if (cRMspSelectLinkAccTarazSetting_Result != null)
				{
					text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				string text3 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
				if (cRMspSelectLinkAccTarazSetting_Result2 != null)
				{
					text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
				if (cRMspSelectLinkAccTarazSetting_Result3 != null)
				{
					text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
				}
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
				if (cRMspSelectLinkAccTarazSetting_Result4 != null)
				{
					text2 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
						tarazGetAuthViewModel.username = text3;
						tarazGetAuthViewModel.password = text4;
						string text5 = "tws/authenticate";
						HttpResponseMessage result2 = new HttpClient
						{
							Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
							BaseAddress = new Uri(text + text5),
							DefaultRequestHeaders = 
							{
								Accept = 
								{
									new MediaTypeWithQualityHeaderValue("application/json")
								}
							}
						}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
						if (result2.IsSuccessStatusCode)
						{
							TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
							{
								text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text2;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							else
							{
								Exception e = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						else
						{
							string text6 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
							TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (tarazExceptionViewModel != null)
							{
								string[] obj = new string[6]
								{
									text6,
									" [",
									tarazExceptionViewModel.error,
									(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
									null,
									null
								};
								_ = tarazExceptionViewModel.status;
								obj[4] = " code:" + tarazExceptionViewModel.status;
								obj[5] = "]";
								text6 = string.Concat(obj);
							}
							Exception e2 = new Exception(text6);
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						Exception e3 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string text7 = "";
						if (!string.IsNullOrEmpty(value))
						{
							text7 = "&goodsDesc=" + value;
						}
						if (!string.IsNullOrEmpty(code))
						{
							text7 = "&goodsCode=" + code;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", text2);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "tws/inv/goods?pageNumber=" + pageNumber + "&recordCount=" + num + text7;
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							List<TarazGoodsViewModel> list3 = JsonConvert.DeserializeObject<List<TarazGoodsViewModel>>(result3.Content.ReadAsStringAsync().Result);
							if (list3 != null)
							{
								List<WSspSelectProducts_Result> list4 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
								int num2 = ((pageNumber == 1) ? 1 : ((pageNumber - 1) * num + 1));
								foreach (TarazGoodsViewModel item in list3)
								{
									TarazProductsViewModel tarazProductsViewModel = new TarazProductsViewModel();
									tarazProductsViewModel.UNITID = item.unitID;
									tarazProductsViewModel.UNITDESC = item.unitDesc;
									tarazProductsViewModel.GOODSID = item.goodsID;
									tarazProductsViewModel.GOODSDESC = item.goodsDesc;
									tarazProductsViewModel.GOODSCODE = item.fullGoodsCode;
									tarazProductsViewModel.BARCODE = item.barCode;
									string goodId = "";
									if (tarazProductsViewModel.GOODSID.HasValue)
									{
										goodId = tarazProductsViewModel.GOODSID.ToString();
									}
									if (list4 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4))
									{
										WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == goodId));
										if (wSspSelectProducts_Result != null)
										{
											tarazProductsViewModel.ProductId = wSspSelectProducts_Result.ProductID;
										}
									}
									tarazProductsViewModel.RowNumber = num2;
									tarazProductsViewModel.AllPage = pageNumber + 1;
									list.Add(tarazProductsViewModel);
									num2++;
								}
							}
						}
						else
						{
							string text8 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
							HttpStatusCode statusCode = result3.StatusCode;
							if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting4 != null)
								{
									crmLinkAccTarazSetting4.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							else
							{
								TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
								if (tarazExceptionViewModel2 != null)
								{
									_ = tarazExceptionViewModel2.status;
									if (tarazExceptionViewModel2.status == 401)
									{
										DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
										ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
										CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmLinkAccTarazSetting6 != null)
										{
											crmLinkAccTarazSetting6.PartValue = "";
											_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
											_dbTbl.Configuration.ValidateOnSaveEnabled = false;
											_dbTbl.SaveChanges();
											_dbTbl.Configuration.ValidateOnSaveEnabled = true;
										}
									}
									string[] obj2 = new string[6]
									{
										text8,
										" [",
										tarazExceptionViewModel2.error,
										(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
										null,
										null
									};
									_ = tarazExceptionViewModel2.status;
									obj2[4] = " code:" + tarazExceptionViewModel2.status;
									obj2[5] = "]";
									text8 = string.Concat(obj2);
								}
							}
							Exception e4 = new Exception(text8);
							ErrorSignal.FromCurrentContext().Raise(e4);
						}
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
					ErrorSignal.FromCurrentContext().Raise(e5);
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
				ErrorSignal.FromCurrentContext().Raise(e6);
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult TarazImportInfo(string records, int prdFGroupId, int prdGroupId, int prdPriceGroupId, int pageNumber, int totalPage, string value = "", string code = "")
	{
		//IL_00f2: Unknown result type (might be due to invalid IL or missing references)
		//IL_0893: Unknown result type (might be due to invalid IL or missing references)
		//IL_0898: Unknown result type (might be due to invalid IL or missing references)
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
			int num2 = 200;
			pageNumber = ((pageNumber <= 0) ? 1 : pageNumber);
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			string text3 = "";
			List<OtherSystemSelectedIViewModel> list = new List<OtherSystemSelectedIViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedIViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list))
				{
					foreach (OtherSystemSelectedIViewModel item2 in list)
					{
						if (item2.Selected)
						{
							text3 = text3 + item2.Id + ",";
						}
					}
				}
			}
			List<TarazProductsViewModel> list2 = new List<TarazProductsViewModel>();
			List<CRMspSelectLinkAccTarazSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list3 != null)
			{
				string text4 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
				if (cRMspSelectLinkAccTarazSetting_Result != null)
				{
					text4 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
				}
				string text5 = "";
				string text6 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
				if (cRMspSelectLinkAccTarazSetting_Result2 != null)
				{
					text6 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
				}
				string text7 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
				if (cRMspSelectLinkAccTarazSetting_Result3 != null)
				{
					text7 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
				}
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
				if (cRMspSelectLinkAccTarazSetting_Result4 != null)
				{
					text5 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text6) && !string.IsNullOrWhiteSpace(text7))
				{
					if (!text4.EndsWith("/"))
					{
						text4 += "/";
					}
					if (string.IsNullOrWhiteSpace(text5))
					{
						TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
						tarazGetAuthViewModel.username = text6;
						tarazGetAuthViewModel.password = text7;
						string text8 = "tws/authenticate";
						HttpResponseMessage result2 = new HttpClient
						{
							Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
							BaseAddress = new Uri(text4 + text8),
							DefaultRequestHeaders = 
							{
								Accept = 
								{
									new MediaTypeWithQualityHeaderValue("application/json")
								}
							}
						}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text4 + text8).Result;
						if (result2.IsSuccessStatusCode)
						{
							TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
							{
								text5 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text5;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							else
							{
								string text9 = Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ";
								Exception e = new Exception(text9);
								ErrorSignal.FromCurrentContext().Raise(e);
								text = text9;
							}
						}
						else
						{
							string text10 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
							TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (tarazExceptionViewModel != null)
							{
								string[] obj = new string[6]
								{
									text10,
									" [",
									tarazExceptionViewModel.error,
									(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
									null,
									null
								};
								_ = tarazExceptionViewModel.status;
								obj[4] = " code:" + tarazExceptionViewModel.status;
								obj[5] = "]";
								text10 = string.Concat(obj);
							}
							Exception e2 = new Exception(text10);
							ErrorSignal.FromCurrentContext().Raise(e2);
							text = text10;
						}
					}
					if (string.IsNullOrWhiteSpace(text5))
					{
						string text11 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
						Exception e3 = new Exception(text11);
						ErrorSignal.FromCurrentContext().Raise(e3);
						text = text11;
					}
					if (!string.IsNullOrWhiteSpace(text5))
					{
						string text12 = "";
						if (!string.IsNullOrEmpty(value))
						{
							text12 = "&goodsDesc=" + value;
						}
						if (!string.IsNullOrEmpty(code))
						{
							text12 = "&goodsCode=" + code;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", text5);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						while (pageNumber <= totalPage)
						{
							string requestUri = "tws/inv/goods?pageNumber=" + pageNumber + "&recordCount=" + num2 + text12;
							HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
							if (result3.IsSuccessStatusCode)
							{
								List<TarazGoodsViewModel> list4 = JsonConvert.DeserializeObject<List<TarazGoodsViewModel>>(result3.Content.ReadAsStringAsync().Result);
								if (list4 != null)
								{
									List<WSspSelectProducts_Result> list5 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
									int num3 = ((pageNumber == 1) ? 1 : ((pageNumber - 1) * num2 + 1));
									foreach (TarazGoodsViewModel item3 in list4)
									{
										TarazProductsViewModel tarazProductsViewModel = new TarazProductsViewModel();
										tarazProductsViewModel.UNITID = item3.unitID;
										tarazProductsViewModel.UNITDESC = item3.unitDesc;
										tarazProductsViewModel.GOODSID = item3.goodsID;
										tarazProductsViewModel.GOODSDESC = item3.goodsDesc;
										tarazProductsViewModel.GOODSCODE = item3.fullGoodsCode;
										tarazProductsViewModel.BARCODE = item3.barCode;
										tarazProductsViewModel.createDate = item3.createDate;
										tarazProductsViewModel.modifyDate = item3.modifyDate;
										tarazProductsViewModel.latinDesc = item3.latinDesc;
										tarazProductsViewModel.minQuantity = item3.minQuantity;
										tarazProductsViewModel.maxQuantity = item3.maxQuantity;
										string goodId = "";
										if (tarazProductsViewModel.GOODSID.HasValue)
										{
											goodId = tarazProductsViewModel.GOODSID.ToString();
										}
										if (list5 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5))
										{
											WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == goodId));
											if (wSspSelectProducts_Result != null)
											{
												tarazProductsViewModel.ProductId = wSspSelectProducts_Result.ProductID;
											}
										}
										tarazProductsViewModel.RowNumber = num3;
										tarazProductsViewModel.AllPage = pageNumber + 1;
										list2.Add(tarazProductsViewModel);
										num3++;
									}
								}
							}
							else
							{
								string text13 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
								HttpStatusCode statusCode = result3.StatusCode;
								if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
								{
									DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
									ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
									CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmLinkAccTarazSetting4 != null)
									{
										crmLinkAccTarazSetting4.PartValue = "";
										_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
										_dbTbl.Configuration.ValidateOnSaveEnabled = false;
										_dbTbl.SaveChanges();
										_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									}
								}
								else
								{
									TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
									if (tarazExceptionViewModel2 != null)
									{
										_ = tarazExceptionViewModel2.status;
										if (tarazExceptionViewModel2.status == 401)
										{
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
											ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting6 != null)
											{
												crmLinkAccTarazSetting6.PartValue = "";
												_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
										}
										string[] obj2 = new string[6]
										{
											text13,
											" [",
											tarazExceptionViewModel2.error,
											(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
											null,
											null
										};
										_ = tarazExceptionViewModel2.status;
										obj2[4] = " code:" + tarazExceptionViewModel2.status;
										obj2[5] = "]";
										text13 = string.Concat(obj2);
									}
								}
								Exception e4 = new Exception(text13);
								ErrorSignal.FromCurrentContext().Raise(e4);
								text = text13;
								pageNumber = totalPage + 1;
							}
							pageNumber++;
						}
					}
				}
				else
				{
					string text14 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
					Exception e5 = new Exception(text14);
					ErrorSignal.FromCurrentContext().Raise(e5);
					text = text14;
				}
			}
			else
			{
				string text15 = Messages.errorInReadingSetting + " (tarazSamaneh) ";
				Exception e6 = new Exception(text15);
				ErrorSignal.FromCurrentContext().Raise(e6);
				text = text15;
			}
			if (list2 != null && Enumerable.Any<TarazProductsViewModel>((IEnumerable<TarazProductsViewModel>)list2))
			{
				text = "";
				int num4 = 0;
				if (Enumerable.Any<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list))
				{
					List<OtherSystemSelectedIViewModel> list6 = Enumerable.ToList<OtherSystemSelectedIViewModel>(Enumerable.Where<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list, (Func<OtherSystemSelectedIViewModel, bool>)((OtherSystemSelectedIViewModel m) => m.Selected)));
					if (Enumerable.Any<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list6) && list6 != null)
					{
						num4 = Enumerable.Count<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list6);
						int num5 = 0;
						foreach (OtherSystemSelectedIViewModel item in list6)
						{
							TarazProductsViewModel tarazProductsViewModel2 = Enumerable.FirstOrDefault<TarazProductsViewModel>((IEnumerable<TarazProductsViewModel>)list2, (Func<TarazProductsViewModel, bool>)((TarazProductsViewModel m) => m.GOODSID == item.Id));
							if (tarazProductsViewModel2 == null)
							{
								continue;
							}
							DateTime? createDate = tarazProductsViewModel2.createDate;
							string text16 = (tarazProductsViewModel2.createDate.HasValue ? tarazProductsViewModel2.createDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							DateTime? modifyDate = tarazProductsViewModel2.modifyDate;
							string text17 = (tarazProductsViewModel2.modifyDate.HasValue ? tarazProductsViewModel2.modifyDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							string latinDesc = tarazProductsViewModel2.latinDesc;
							int? num6 = (int)(tarazProductsViewModel2.minQuantity.HasValue ? tarazProductsViewModel2.minQuantity.Value : 0);
							int? num7 = (int)(tarazProductsViewModel2.maxQuantity.HasValue ? tarazProductsViewModel2.maxQuantity.Value : 0);
							DateTime? unitCreateDate = tarazProductsViewModel2.unitCreateDate;
							string text18 = (tarazProductsViewModel2.unitCreateDate.HasValue ? tarazProductsViewModel2.unitCreateDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							DateTime? unitModifyDate = tarazProductsViewModel2.unitModifyDate;
							string text19 = (tarazProductsViewModel2.unitModifyDate.HasValue ? tarazProductsViewModel2.unitModifyDate.Value.ToString("yyyyMMdd", new PersianCulture()) : "");
							ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
							ObjectParameter objectParameter2 = new ObjectParameter("insertedPrdId", "0");
							_dbLink.CRMspLkTarazWSInsertUpdateProductFromTaraz(tarazProductsViewModel2.GOODSID, tarazProductsViewModel2.GOODSDESC, tarazProductsViewModel2.GOODSCODE, tarazProductsViewModel2.BARCODE, tarazProductsViewModel2.PRICE, tarazProductsViewModel2.UNITID, tarazProductsViewModel2.UNITDESC, tarazProductsViewModel2.STOREID, tarazProductsViewModel2.STORENAME, tarazProductsViewModel2.STORECODE, prdFirstGroupId: prdFGroupId, prdSecondGroupId: prdGroupId, prdPriceGroupId: prdPriceGroupId, userId: userId, month1: value3, fPId: id, registerDate: value2, registerDatePersian: text2, appType: appType, defLanguageID: result, insertedPrdId: objectParameter2, errorMessage: objectParameter, tarazGoodsCreateDate: string.IsNullOrEmpty(text16) ? null : createDate, tarazGoodsCreateDatePersian: text16, tarazGoodsLatinDesc: latinDesc, tarazGoodsMaxQuantity: (num7 != 0) ? num7 : null, tarazGoodsMinQuantity: (num6 != 0) ? num6 : null, tarazGoodsModifyDate: string.IsNullOrEmpty(text17) ? null : modifyDate, tarazGoodsModifyDatePersian: text17, tarazUnitCreateDate: string.IsNullOrEmpty(text18) ? null : unitCreateDate, tarazUnitCreateDatePersian: text18, tarazUnitModifyDate: string.IsNullOrEmpty(text19) ? null : unitModifyDate, tarazUnitModifyDatePersian: text19, centerId: centerId);
							if (objectParameter.Value != null)
							{
								if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
								{
									text = text + "<br>" + objectParameter.Value.ToString();
								}
								else if (objectParameter2.Value != null)
								{
									int result4 = 0;
									int.TryParse(objectParameter2.Value.ToString(), out result4);
									if (result4 > 0)
									{
										num5++;
										int count = num5 * 100 / num4;
										ProgressHub.SendMessage("ok", count, userId);
									}
								}
							}
							else if (objectParameter2.Value != null)
							{
								int result5 = 0;
								int.TryParse(objectParameter2.Value.ToString(), out result5);
								if (result5 > 0)
								{
									num5++;
									int count2 = num5 * 100 / num4;
									ProgressHub.SendMessage("ok", count2, userId);
								}
							}
						}
					}
					else
					{
						text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
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

	[AjaxOnly]
	public JsonResult GetTarazImportProductList(string records, int totalPage, string value = "", string code = "")
	{
		//IL_0a86: Unknown result type (might be due to invalid IL or missing references)
		//IL_073b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0740: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedIViewModel> list = new List<OtherSystemSelectedIViewModel>();
		List<TarazProductsViewModel> list2 = new List<TarazProductsViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			totalPage = ((totalPage <= 0) ? 1 : totalPage);
			int num = 200;
			int i = 1;
			List<CRMspSelectLinkAccTarazSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
			if (list3 != null)
			{
				string text = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
				if (cRMspSelectLinkAccTarazSetting_Result != null)
				{
					text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				string text3 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
				if (cRMspSelectLinkAccTarazSetting_Result2 != null)
				{
					text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
				if (cRMspSelectLinkAccTarazSetting_Result3 != null)
				{
					text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
				}
				CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
				if (cRMspSelectLinkAccTarazSetting_Result4 != null)
				{
					text2 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
				}
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
						tarazGetAuthViewModel.username = text3;
						tarazGetAuthViewModel.password = text4;
						string text5 = "tws/authenticate";
						HttpResponseMessage result2 = new HttpClient
						{
							Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
							BaseAddress = new Uri(text + text5),
							DefaultRequestHeaders = 
							{
								Accept = 
								{
									new MediaTypeWithQualityHeaderValue("application/json")
								}
							}
						}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
						if (result2.IsSuccessStatusCode)
						{
							TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
							{
								text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text2;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							else
							{
								Exception e = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
								ErrorSignal.FromCurrentContext().Raise(e);
							}
						}
						else
						{
							string text6 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
							TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
							if (tarazExceptionViewModel != null)
							{
								string[] obj = new string[6]
								{
									text6,
									" [",
									tarazExceptionViewModel.error,
									(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
									null,
									null
								};
								_ = tarazExceptionViewModel.status;
								obj[4] = " code:" + tarazExceptionViewModel.status;
								obj[5] = "]";
								text6 = string.Concat(obj);
							}
							Exception e2 = new Exception(text6);
							ErrorSignal.FromCurrentContext().Raise(e2);
						}
					}
					if (string.IsNullOrWhiteSpace(text2))
					{
						Exception e3 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
						ErrorSignal.FromCurrentContext().Raise(e3);
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string text7 = "";
						if (!string.IsNullOrEmpty(value))
						{
							text7 = "&goodsDesc=" + value;
						}
						if (!string.IsNullOrEmpty(code))
						{
							text7 = "&goodsCode=" + code;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", text2);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						for (; i <= totalPage; i++)
						{
							string requestUri = "tws/inv/goods?pageNumber=" + i + "&recordCount=" + num + text7;
							HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
							if (result3.IsSuccessStatusCode)
							{
								List<TarazGoodsViewModel> list4 = JsonConvert.DeserializeObject<List<TarazGoodsViewModel>>(result3.Content.ReadAsStringAsync().Result);
								if (list4 == null)
								{
									continue;
								}
								List<WSspSelectProducts_Result> list5 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
								int num2 = ((i == 1) ? 1 : ((i - 1) * num + 1));
								foreach (TarazGoodsViewModel item2 in list4)
								{
									TarazProductsViewModel tarazProductsViewModel = new TarazProductsViewModel();
									tarazProductsViewModel.UNITID = item2.unitID;
									tarazProductsViewModel.UNITDESC = item2.unitDesc;
									tarazProductsViewModel.GOODSID = item2.goodsID;
									tarazProductsViewModel.GOODSDESC = item2.goodsDesc;
									tarazProductsViewModel.GOODSCODE = item2.fullGoodsCode;
									tarazProductsViewModel.BARCODE = item2.barCode;
									string goodId = "";
									if (tarazProductsViewModel.GOODSID.HasValue)
									{
										goodId = tarazProductsViewModel.GOODSID.ToString();
									}
									if (list5 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5))
									{
										WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == goodId));
										if (wSspSelectProducts_Result != null)
										{
											tarazProductsViewModel.ProductId = wSspSelectProducts_Result.ProductID;
										}
									}
									tarazProductsViewModel.RowNumber = num2;
									tarazProductsViewModel.AllPage = i + 1;
									list2.Add(tarazProductsViewModel);
									num2++;
								}
								continue;
							}
							string text8 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
							HttpStatusCode statusCode = result3.StatusCode;
							if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
							{
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting4 != null)
								{
									crmLinkAccTarazSetting4.PartValue = "";
									_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (tarazExceptionViewModel2 != null)
							{
								_ = tarazExceptionViewModel2.status;
								if (tarazExceptionViewModel2.status == 401)
								{
									DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
									ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
									CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
									if (crmLinkAccTarazSetting6 != null)
									{
										crmLinkAccTarazSetting6.PartValue = "";
										_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
										_dbTbl.Configuration.ValidateOnSaveEnabled = false;
										_dbTbl.SaveChanges();
										_dbTbl.Configuration.ValidateOnSaveEnabled = true;
									}
								}
								string[] obj2 = new string[6]
								{
									text8,
									" [",
									tarazExceptionViewModel2.error,
									(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
									null,
									null
								};
								_ = tarazExceptionViewModel2.status;
								obj2[4] = " code:" + tarazExceptionViewModel2.status;
								obj2[5] = "]";
								text8 = string.Concat(obj2);
							}
							Exception e4 = new Exception(text8);
							ErrorSignal.FromCurrentContext().Raise(e4);
							i = totalPage + 1;
						}
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
					ErrorSignal.FromCurrentContext().Raise(e5);
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
				ErrorSignal.FromCurrentContext().Raise(e6);
			}
			foreach (TarazProductsViewModel item3 in list2)
			{
				OtherSystemSelectedIViewModel item = new OtherSystemSelectedIViewModel
				{
					Row = item3.RowNumber.GetValueOrDefault(),
					Id = item3.GOODSID.GetValueOrDefault(),
					Selected = !item3.ProductId.HasValue
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedIViewModel> list6 = new List<OtherSystemSelectedIViewModel>();
				list6 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedIViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedIViewModel>((IEnumerable<OtherSystemSelectedIViewModel>)list6))
				{
					foreach (OtherSystemSelectedIViewModel item4 in list6)
					{
						foreach (OtherSystemSelectedIViewModel item5 in list)
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
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string TarazGetPrdQuantityAndPrice(int prdId, int cmpId, int whId, int prdPriceGroupId, ref decimal prdPrice, ref double prdQuantity, string CrmOrdType = "pord", int? currUserId = 0)
	{
		//IL_0b79: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b7e: Unknown result type (might be due to invalid IL or missing references)
		int value = 0;
		if (currUserId.GetValueOrDefault() == 0)
		{
			value = UserLogin.CurrentUser.UserId;
		}
		string result = "";
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
		if (result2 <= 0)
		{
			result2 = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			if (cmpId <= 0)
			{
				Exception e = new Exception(Messages.ErrorNotFound + "(company)");
				ErrorSignal.FromCurrentContext().Raise(e);
				result = Labels.frmError;
			}
			else if (prdId <= 0)
			{
				Exception e2 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e2);
				result = Labels.frmError;
			}
			else if (whId <= 0)
			{
				Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
				ErrorSignal.FromCurrentContext().Raise(e3);
				result = Labels.frmError;
			}
			else
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result != null)
				{
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
						List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, false, lCID, result2));
						if (list != null)
						{
							wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
						}
						if (wSspSelectWareHouseWithAccLinkField_Result != null)
						{
							if (!string.IsNullOrEmpty(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								if (!string.IsNullOrEmpty(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
								{
									if (!string.IsNullOrEmpty(companyById.cmpLinkAccCustomerIdStr))
									{
										List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result2));
										if (list2 != null)
										{
											string text = "";
											CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
											if (cRMspSelectLinkAccTarazSetting_Result != null)
											{
												text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
											}
											string text2 = "";
											string text3 = "";
											CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
											if (cRMspSelectLinkAccTarazSetting_Result2 != null)
											{
												text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
											}
											string text4 = "";
											CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
											if (cRMspSelectLinkAccTarazSetting_Result3 != null)
											{
												text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
											}
											CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
											if (cRMspSelectLinkAccTarazSetting_Result4 != null)
											{
												text2 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
											}
											if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
											{
												if (!text.EndsWith("/"))
												{
													text += "/";
												}
												if (string.IsNullOrWhiteSpace(text2))
												{
													TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
													tarazGetAuthViewModel.username = text3;
													tarazGetAuthViewModel.password = text4;
													string text5 = "tws/authenticate";
													HttpResponseMessage result3 = new HttpClient
													{
														Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
														BaseAddress = new Uri(text + text5),
														DefaultRequestHeaders = 
														{
															Accept = 
															{
																new MediaTypeWithQualityHeaderValue("application/json")
															}
														}
													}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
													if (result3.IsSuccessStatusCode)
													{
														TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result3.Content.ReadAsStringAsync().Result);
														if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
														{
															text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
															DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
															ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
															CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
															if (crmLinkAccTarazSetting2 != null)
															{
																crmLinkAccTarazSetting2.PartValue = text2;
																_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
																_dbTbl.Configuration.ValidateOnSaveEnabled = false;
																_dbTbl.SaveChanges();
																_dbTbl.Configuration.ValidateOnSaveEnabled = true;
															}
														}
														else
														{
															Exception e4 = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
															ErrorSignal.FromCurrentContext().Raise(e4);
															result = Labels.frmError;
														}
													}
													else
													{
														string text6 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
														TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
														if (tarazExceptionViewModel != null)
														{
															string[] obj = new string[6]
															{
																text6,
																" [",
																tarazExceptionViewModel.error,
																(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
																null,
																null
															};
															_ = tarazExceptionViewModel.status;
															obj[4] = " code:" + tarazExceptionViewModel.status;
															obj[5] = "]";
															text6 = string.Concat(obj);
														}
														Exception e5 = new Exception(text6);
														ErrorSignal.FromCurrentContext().Raise(e5);
														result = Labels.frmError;
													}
												}
												if (string.IsNullOrWhiteSpace(text2))
												{
													Exception e6 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
													ErrorSignal.FromCurrentContext().Raise(e6);
													result = Labels.frmError;
												}
												string text7 = "";
												if (prdPriceGroupId == 0)
												{
													List<CRMspSelectLinkAccTarazSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "PrdPriceGroup", lCID, result2));
													string s = "";
													if (list3 != null)
													{
														CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 7));
														if (cRMspSelectLinkAccTarazSetting_Result5 != null)
														{
															s = cRMspSelectLinkAccTarazSetting_Result5.PartValue ?? "";
														}
													}
													int.TryParse(s, out prdPriceGroupId);
												}
												WSspSelectProductPriceGroupById_Result wSspSelectProductPriceGroupById_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceGroupById_Result>((IEnumerable<WSspSelectProductPriceGroupById_Result>)_db.WSspSelectProductPriceGroupById(prdPriceGroupId, lCID, result2));
												if (wSspSelectProductPriceGroupById_Result != null)
												{
													text7 = wSspSelectProductPriceGroupById_Result.LinkAccPrdPriceGroupIdStr ?? "";
												}
												if (string.IsNullOrEmpty(text7))
												{
													Exception e7 = new Exception(Messages.ErrorNotFound + "(Not found the product price group is not in Taraz");
													ErrorSignal.FromCurrentContext().Raise(e7);
													result = Labels.frmError;
													return result;
												}
												if (!string.IsNullOrWhiteSpace(text2))
												{
													string text8 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
													HttpClient httpClient = new HttpClient();
													httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
													httpClient.BaseAddress = new Uri(text);
													httpClient.DefaultRequestHeaders.Add("Authorization", text2);
													httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
													string text9 = "6001";
													List<CRMspSelectLinkAccTarazSetting_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "VoucherType", lCID, result2));
													if (list4 != null)
													{
														string text10 = "";
														CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list4, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 10));
														if (cRMspSelectLinkAccTarazSetting_Result6 != null)
														{
															text10 = cRMspSelectLinkAccTarazSetting_Result6.PartValue ?? "";
														}
														if (!string.IsNullOrEmpty(text10))
														{
															text9 = text10;
														}
													}
													if (string.IsNullOrEmpty(text9))
													{
														text9 = "6001";
													}
													string requestUri = "tws/sale/goods?voucherDate=" + text8 + "&voucherTypeID=" + text9 + "&customerID=" + companyById.cmpLinkAccCustomerIdStr + "&goodsCode=" + wSspSelectProductsWithId_Result.PrdLinkAccPrdCode + "&paymentWayID=" + text7 + "&storeID=" + wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
													HttpResponseMessage result4 = httpClient.GetAsync(requestUri).Result;
													if (result4.IsSuccessStatusCode)
													{
														List<TarazSaleGoodsViewModel> list5 = JsonConvert.DeserializeObject<List<TarazSaleGoodsViewModel>>(result4.Content.ReadAsStringAsync().Result);
														if (list5 == null)
														{
															Exception e8 = new Exception(Messages.msgErrorRunFunction + " (not find prodcut information from Taraz or find more one than) ");
															ErrorSignal.FromCurrentContext().Raise(e8);
															return Labels.frmError;
														}
														long prdLinkAccPrdIdStr = 0L;
														long.TryParse(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr, out prdLinkAccPrdIdStr);
														TarazSaleGoodsViewModel tarazSaleGoodsViewModel = Enumerable.FirstOrDefault<TarazSaleGoodsViewModel>((IEnumerable<TarazSaleGoodsViewModel>)list5, (Func<TarazSaleGoodsViewModel, bool>)((TarazSaleGoodsViewModel m) => m.goodsID == prdLinkAccPrdIdStr));
														if (tarazSaleGoodsViewModel == null)
														{
															Exception e9 = new Exception(Messages.msgErrorRunFunction + " (not find prodcut information from Taraz or find more one than) ");
															ErrorSignal.FromCurrentContext().Raise(e9);
															return Labels.frmError;
														}
														prdPrice = tarazSaleGoodsViewModel.price.GetValueOrDefault();
														prdQuantity = tarazSaleGoodsViewModel.remain.GetValueOrDefault();
														if (prdPrice > 0m && prdPriceGroupId > 0 && prdId > 0)
														{
															DateTime now = DateTime.Now;
															DateTime value2 = now;
															string text11 = now.ToString("yyyyMMdd", new PersianCulture());
															int id = Financial.Get().Id;
															short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
															string appType = Configuration.AppType;
															decimal valueOrDefault = tarazSaleGoodsViewModel.goodsDiscountPercent.GetValueOrDefault();
															decimal valueOrDefault2 = tarazSaleGoodsViewModel.goodsDiscountPrice.GetValueOrDefault();
															_db.WSspInsertProductPrice(prdPriceGroupId, prdId, text11, value2, null, prdPrice, null, null, null, null, (valueOrDefault == 0m) ? null : new decimal?(valueOrDefault), (valueOrDefault2 == 0m) ? null : new decimal?(valueOrDefault2), null, null, null, value, value3, id, value2, text11, appType, result2);
															CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
															CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
														}
														result = "";
													}
													else
													{
														string text12 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
														HttpStatusCode statusCode = result4.StatusCode;
														if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
														{
															DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
															ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
															CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
															if (crmLinkAccTarazSetting4 != null)
															{
																crmLinkAccTarazSetting4.PartValue = "";
																_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
																_dbTbl.Configuration.ValidateOnSaveEnabled = false;
																_dbTbl.SaveChanges();
																_dbTbl.Configuration.ValidateOnSaveEnabled = true;
															}
														}
														TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result4.Content.ReadAsStringAsync().Result);
														if (tarazExceptionViewModel2 != null)
														{
															_ = tarazExceptionViewModel2.status;
															if (tarazExceptionViewModel2.status == 401)
															{
																DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
																ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
																CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
																if (crmLinkAccTarazSetting6 != null)
																{
																	crmLinkAccTarazSetting6.PartValue = "";
																	_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
																	_dbTbl.Configuration.ValidateOnSaveEnabled = false;
																	_dbTbl.SaveChanges();
																	_dbTbl.Configuration.ValidateOnSaveEnabled = true;
																}
															}
															string[] obj2 = new string[6]
															{
																text12,
																" [",
																tarazExceptionViewModel2.error,
																(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
																null,
																null
															};
															_ = tarazExceptionViewModel2.status;
															obj2[4] = " code:" + tarazExceptionViewModel2.status;
															obj2[5] = "]";
															text12 = string.Concat(obj2);
														}
														Exception e10 = new Exception(text12);
														ErrorSignal.FromCurrentContext().Raise(e10);
														result = Labels.frmError;
													}
												}
											}
											else
											{
												Exception e11 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
												ErrorSignal.FromCurrentContext().Raise(e11);
												result = Labels.frmError;
											}
										}
										else
										{
											Exception e12 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
											ErrorSignal.FromCurrentContext().Raise(e12);
											result = Labels.frmError;
										}
									}
									else
									{
										Exception e13 = new Exception(Messages.ErrorNotFound + "(This company by name " + companyById.CompanyName + " is not in Taraz");
										ErrorSignal.FromCurrentContext().Raise(e13);
										result = Labels.frmError;
									}
								}
								else
								{
									Exception e14 = new Exception(Messages.ErrorNotFound + "(This product by name " + wSspSelectProductsWithId_Result.PrdName + " not have code");
									ErrorSignal.FromCurrentContext().Raise(e14);
									result = Labels.frmError;
								}
							}
							else
							{
								Exception e15 = new Exception(Messages.ErrorNotFound + "(This warehouse by name " + wSspSelectWareHouseWithAccLinkField_Result.WrhsName + " not have code");
								ErrorSignal.FromCurrentContext().Raise(e15);
								result = Labels.frmError;
							}
						}
						else
						{
							Exception e16 = new Exception(Messages.ErrorNotFound + "(warehouse)");
							ErrorSignal.FromCurrentContext().Raise(e16);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e17 = new Exception(Messages.ErrorNotFound + "(company)");
						ErrorSignal.FromCurrentContext().Raise(e17);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e18 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e18);
					result = Labels.frmError;
				}
			}
		}
		catch (Exception e19)
		{
			ErrorSignal.FromCurrentContext().Raise(e19);
		}
		return result;
	}

	public JsonResult TarazGetPrdUnit(int prdId)
	{
		//IL_0aec: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af1: Unknown result type (might be due to invalid IL or missing references)
		List<WSProductUnitsListViewModel> list = new List<WSProductUnitsListViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId <= 0)
			{
				Exception e = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			else
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					if (!string.IsNullOrEmpty(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
					{
						List<CRMspSelectLinkAccTarazSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
						if (list2 != null)
						{
							string text = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
							if (cRMspSelectLinkAccTarazSetting_Result != null)
							{
								text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
							}
							string text2 = "";
							string text3 = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
							if (cRMspSelectLinkAccTarazSetting_Result2 != null)
							{
								text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
							}
							string text4 = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
							if (cRMspSelectLinkAccTarazSetting_Result3 != null)
							{
								text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
							}
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list2, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
							if (cRMspSelectLinkAccTarazSetting_Result4 != null)
							{
								text2 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
							}
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text.EndsWith("/"))
								{
									text += "/";
								}
								if (string.IsNullOrWhiteSpace(text2))
								{
									TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
									tarazGetAuthViewModel.username = text3;
									tarazGetAuthViewModel.password = text4;
									string text5 = "tws/authenticate";
									HttpResponseMessage result2 = new HttpClient
									{
										Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
										BaseAddress = new Uri(text + text5),
										DefaultRequestHeaders = 
										{
											Accept = 
											{
												new MediaTypeWithQualityHeaderValue("application/json")
											}
										}
									}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
									if (result2.IsSuccessStatusCode)
									{
										TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
										if (!string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
										{
											text2 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
											ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting2 != null)
											{
												crmLinkAccTarazSetting2.PartValue = text2;
												_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
										}
										else
										{
											Exception e2 = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
											ErrorSignal.FromCurrentContext().Raise(e2);
										}
									}
									else
									{
										string text6 = Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ";
										TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
										if (tarazExceptionViewModel != null)
										{
											string[] obj = new string[6]
											{
												text6,
												" [",
												tarazExceptionViewModel.error,
												(!string.IsNullOrEmpty(tarazExceptionViewModel.message)) ? (" -" + tarazExceptionViewModel.message) : "",
												null,
												null
											};
											_ = tarazExceptionViewModel.status;
											obj[4] = " code:" + tarazExceptionViewModel.status;
											obj[5] = "]";
											text6 = string.Concat(obj);
										}
										Exception e3 = new Exception(text6);
										ErrorSignal.FromCurrentContext().Raise(e3);
									}
								}
								if (string.IsNullOrWhiteSpace(text2))
								{
									Exception e4 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
									ErrorSignal.FromCurrentContext().Raise(e4);
								}
								if (!string.IsNullOrWhiteSpace(text2))
								{
									DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
									HttpClient httpClient = new HttpClient();
									httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Add("Authorization", text2);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "tws/inv/goods/" + wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr + "/goodsunits";
									HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
									if (result3.IsSuccessStatusCode)
									{
										List<TarazGoodsUnitsViewModel> list3 = JsonConvert.DeserializeObject<List<TarazGoodsUnitsViewModel>>(result3.Content.ReadAsStringAsync().Result);
										if (list3 != null)
										{
											List<WSspSelectProductUnits_Result> list4 = Enumerable.ToList<WSspSelectProductUnits_Result>(Enumerable.Where<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => (m.UnitLinkAccUnitIdStr ?? "") != "")));
											if (list4 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list4))
											{
												string otherSystemsFCR = Labels.OtherSystemsFCR;
												foreach (TarazGoodsUnitsViewModel item3 in list3)
												{
													long tUnitId = item3.unitID.GetValueOrDefault();
													WSspSelectProductUnits_Result wSspSelectProductUnits_Result = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list4, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => (m.UnitLinkAccUnitIdStr ?? "") == tUnitId.ToString()));
													if (wSspSelectProductUnits_Result != null)
													{
														WSProductUnitsListViewModel wSProductUnitsListViewModel = new WSProductUnitsListViewModel();
														wSProductUnitsListViewModel.ProductUnitID = wSspSelectProductUnits_Result.ProductUnitID;
														wSProductUnitsListViewModel.Unit = wSspSelectProductUnits_Result.Unit + " (" + otherSystemsFCR + "= " + item3.computeValue.GetValueOrDefault(1.0) + ")";
														wSProductUnitsListViewModel.QuantityInUnit = wSspSelectProductUnits_Result.QuantityInUnit;
														wSProductUnitsListViewModel.UnitEn = wSspSelectProductUnits_Result.UnitEn + " (" + otherSystemsFCR + "= " + item3.computeValue.GetValueOrDefault(1.0) + ")";
														wSProductUnitsListViewModel.FCR = item3.computeValue.GetValueOrDefault(1.0);
														wSProductUnitsListViewModel.FCRI = null;
														WSProductUnitsListViewModel item = wSProductUnitsListViewModel;
														list.Add(item);
														continue;
													}
													DateTime now = DateTime.Now;
													string text7 = now.ToString("yyyyMMdd", new PersianCulture());
													short value = short.Parse(now.ToString("MM", new PersianCulture()));
													string appType = Configuration.AppType;
													int id = Financial.Get().Id;
													int userId = UserLogin.CurrentUser.UserId;
													ObjectParameter objectParameter = new ObjectParameter("insertedUnitId", 0);
													ObjectParameter objectParameter2 = new ObjectParameter("errorMessage", "");
													_dbLink.CRMspLkTarazWSInsertUpdateProductUnitFromTaraz(tUnitId, item3.unitDesc ?? "", now, text7, now, text7, userId, value, id, now, text7, appType, result, objectParameter, objectParameter2);
													if (objectParameter2.Value != null && !string.IsNullOrWhiteSpace(objectParameter2.Value.ToString()))
													{
														Exception e5 = new Exception(Messages.msgErrorRunFunction + " " + objectParameter2.Value.ToString());
														ErrorSignal.FromCurrentContext().Raise(e5);
													}
													if (objectParameter.Value != null)
													{
														int result4 = 0;
														int.TryParse(objectParameter.Value.ToString(), out result4);
														if (result4 > 0)
														{
															list4 = Enumerable.ToList<WSspSelectProductUnits_Result>(Enumerable.Where<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)_db.WSspSelectProductUnits(lCID, result), (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => (m.UnitLinkAccUnitIdStr ?? "") != "")));
															if (list4 != null && Enumerable.Any<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list4))
															{
																wSspSelectProductUnits_Result = Enumerable.FirstOrDefault<WSspSelectProductUnits_Result>((IEnumerable<WSspSelectProductUnits_Result>)list4, (Func<WSspSelectProductUnits_Result, bool>)((WSspSelectProductUnits_Result m) => (m.UnitLinkAccUnitIdStr ?? "") == tUnitId.ToString()));
																if (wSspSelectProductUnits_Result != null)
																{
																	WSProductUnitsListViewModel wSProductUnitsListViewModel = new WSProductUnitsListViewModel();
																	wSProductUnitsListViewModel.ProductUnitID = wSspSelectProductUnits_Result.ProductUnitID;
																	wSProductUnitsListViewModel.Unit = wSspSelectProductUnits_Result.Unit + " (" + otherSystemsFCR + "= " + item3.computeValue.GetValueOrDefault(1.0) + ")";
																	wSProductUnitsListViewModel.QuantityInUnit = wSspSelectProductUnits_Result.QuantityInUnit;
																	wSProductUnitsListViewModel.UnitEn = wSspSelectProductUnits_Result.UnitEn + " (" + otherSystemsFCR + "= " + item3.computeValue.GetValueOrDefault(1.0) + ")";
																	wSProductUnitsListViewModel.FCR = item3.computeValue.GetValueOrDefault(1.0);
																	wSProductUnitsListViewModel.FCRI = null;
																	WSProductUnitsListViewModel item2 = wSProductUnitsListViewModel;
																	list.Add(item2);
																}
															}
														}
													}
													CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductUnits");
												}
											}
										}
										else
										{
											Exception e6 = new Exception(Messages.msgErrorRunFunction + " (not find prodcut unit information from Taraz) ");
											ErrorSignal.FromCurrentContext().Raise(e6);
										}
									}
									else
									{
										string text8 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
										HttpStatusCode statusCode = result3.StatusCode;
										if (((object)(HttpStatusCode)(ref statusCode)).ToString() == "Unauthorized")
										{
											DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting3 = _dbTbl.CrmLinkAccTarazSetting;
											ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
											CrmLinkAccTarazSetting crmLinkAccTarazSetting4 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting3, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmLinkAccTarazSetting4 != null)
											{
												crmLinkAccTarazSetting4.PartValue = "";
												_dbTbl.Entry(crmLinkAccTarazSetting4).State = EntityState.Modified;
												_dbTbl.Configuration.ValidateOnSaveEnabled = false;
												_dbTbl.SaveChanges();
												_dbTbl.Configuration.ValidateOnSaveEnabled = true;
											}
										}
										TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result3.Content.ReadAsStringAsync().Result);
										if (tarazExceptionViewModel2 != null)
										{
											_ = tarazExceptionViewModel2.status;
											if (tarazExceptionViewModel2.status == 401)
											{
												DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting5 = _dbTbl.CrmLinkAccTarazSetting;
												ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
												CrmLinkAccTarazSetting crmLinkAccTarazSetting6 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting5, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
												if (crmLinkAccTarazSetting6 != null)
												{
													crmLinkAccTarazSetting6.PartValue = "";
													_dbTbl.Entry(crmLinkAccTarazSetting6).State = EntityState.Modified;
													_dbTbl.Configuration.ValidateOnSaveEnabled = false;
													_dbTbl.SaveChanges();
													_dbTbl.Configuration.ValidateOnSaveEnabled = true;
												}
											}
											string[] obj2 = new string[6]
											{
												text8,
												" [",
												tarazExceptionViewModel2.error,
												(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
												null,
												null
											};
											_ = tarazExceptionViewModel2.status;
											obj2[4] = " code:" + tarazExceptionViewModel2.status;
											obj2[5] = "]";
											text8 = string.Concat(obj2);
										}
										Exception e7 = new Exception(text8);
										ErrorSignal.FromCurrentContext().Raise(e7);
									}
								}
							}
							else
							{
								Exception e8 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
								ErrorSignal.FromCurrentContext().Raise(e8);
							}
						}
						else
						{
							Exception e9 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
							ErrorSignal.FromCurrentContext().Raise(e9);
						}
					}
					else
					{
						Exception e10 = new Exception(Messages.ErrorNotFound + "(This product by name " + wSspSelectProductsWithId_Result.PrdName + " not have code");
						ErrorSignal.FromCurrentContext().Raise(e10);
					}
				}
				else
				{
					Exception e11 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e11);
				}
			}
		}
		catch (Exception e12)
		{
			ErrorSignal.FromCurrentContext().Raise(e12);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspSelectLinkAccSettingDB_Result> GetLinkAccHolooDatabases()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		List<CRMspSelectLinkAccSettingDB_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccSettingDB_Result>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)_dbLink.CRMspSelectLinkAccSettingDB(4, null, lCID, result));
		if (list2 != null)
		{
			list.AddRange(Enumerable.Select<CRMspSelectLinkAccSettingDB_Result, SelectListItem>((IEnumerable<CRMspSelectLinkAccSettingDB_Result>)list2, (Func<CRMspSelectLinkAccSettingDB_Result, SelectListItem>)((CRMspSelectLinkAccSettingDB_Result item) => new SelectListItem
			{
				Text = item.LinkAccSettingDbTitle,
				Value = item.LinkAccSettingDBId.ToString(),
				Selected = false
			})));
		}
		base.ViewBag.LinkAccSettingDBList = list;
		return list2;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult HolooImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		GetLinkAccHolooDatabases();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult HolooImportProduct_Read_Old([DataSourceRequest] DataSourceRequest request, string mGroupErpCode = "", string sGroupErpCode = "", string code = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<HolooProductInfoViewModel> list = new List<HolooProductInfoViewModel>();
		try
		{
			List<CRMspSelectLinkAccHolooSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list2 != null)
			{
				string text = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text3 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				string value = "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text2,
						username = text3,
						userpass = text4
					};
					string text5 = "api/Login";
					HttpResponseMessage result2 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text + text5),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
					if (result2.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (holooLoginResultViewModel != null)
						{
							if (holooLoginResultViewModel.Login != null)
							{
								if (holooLoginResultViewModel.Login.State)
								{
									value = holooLoginResultViewModel.Login.Token ?? "";
								}
								else
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
							else
							{
								Exception e2 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
						}
						else
						{
							Exception e3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					if (string.IsNullOrWhiteSpace(value))
					{
						Exception e5 = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						string text6 = "";
						if (!string.IsNullOrEmpty(code))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "code=" + code;
						}
						if (!string.IsNullOrEmpty(mGroupErpCode))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "maingrouperpcode=" + mGroupErpCode;
						}
						if (!string.IsNullOrEmpty(sGroupErpCode))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "sidegrouperpcode=" + sGroupErpCode;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/Product" + text6;
						httpClient.Timeout = new TimeSpan(0, 2, 0);
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooProductListViewModel != null)
							{
								List<WSspSelectProducts_Result> list3 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
								int num = 1;
								if (holooProductListViewModel.product != null)
								{
									foreach (HolooProductInfoViewModel item in holooProductListViewModel.product)
									{
										HolooProductInfoViewModel prd = new HolooProductInfoViewModel();
										prd.Code = item.Code;
										prd.Name = item.Name;
										prd.ErpCode = item.ErpCode;
										if (list3 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list3))
										{
											WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list3, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == prd.ErpCode));
											if (wSspSelectProducts_Result != null)
											{
												prd.ProductId = wSspSelectProducts_Result.ProductID;
											}
										}
										prd.RowNumber = num;
										list.Add(prd);
										num++;
									}
								}
							}
							else
							{
								Exception e6 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
								ErrorSignal.FromCurrentContext().Raise(e6);
							}
						}
						else
						{
							Exception e7 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
							ErrorSignal.FromCurrentContext().Raise(e7);
						}
					}
				}
				else
				{
					Exception e8 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e8);
				}
			}
			else
			{
				Exception e9 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e9);
			}
		}
		catch (Exception e10)
		{
			ErrorSignal.FromCurrentContext().Raise(e10);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult HolooImportProduct_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId, string mGroupErpCode = "", string sGroupErpCode = "", string code = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<HolooProductInfoViewModel> list = new List<HolooProductInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
			}
			string errorMessage = "";
			string text = "";
			if (!string.IsNullOrEmpty(code))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "code=" + code;
			}
			if (!string.IsNullOrEmpty(mGroupErpCode))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "maingrouperpcode=" + mGroupErpCode;
			}
			if (!string.IsNullOrEmpty(sGroupErpCode))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "sidegrouperpcode=" + sGroupErpCode;
			}
			holooProvider.ImportProduct(text, lCID, result, ref errorMessage, ref list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult HolooImportInfo_Old(string records, int linkAccSettingDBId, int prdFGroupId, int prdGroupId, int prdCostGroupId, bool isUseHolooPrdGroup, string mGroupErpCode = "", string sGroupErpCode = "", string code = "", bool isGetPrdCost = false)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
		//IL_072f: Unknown result type (might be due to invalid IL or missing references)
		//IL_073c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0741: Unknown result type (might be due to invalid IL or missing references)
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
			List<HolooProductInfoViewModel> list3 = new List<HolooProductInfoViewModel>();
			List<CRMspSelectLinkAccHolooSetting_Result> list4 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list4 != null)
			{
				string text2 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list4, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text2 = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text3 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list4, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list4, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text5 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list4, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text5 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				string value3 = "";
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5))
				{
					if (!text2.EndsWith("/"))
					{
						text2 += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text3,
						username = text4,
						userpass = text5
					};
					string text6 = "api/Login";
					HttpResponseMessage result2 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text2 + text6),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text2 + text6).Result;
					if (result2.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (holooLoginResultViewModel != null)
						{
							if (holooLoginResultViewModel.Login != null)
							{
								if (holooLoginResultViewModel.Login.State)
								{
									value3 = holooLoginResultViewModel.Login.Token ?? "";
								}
								else
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									string text7 = string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode);
									Exception e = new Exception(text7);
									ErrorSignal.FromCurrentContext().Raise(e);
									text = text7;
								}
							}
							else
							{
								string text8 = Messages.msgErrorRunFunction + "<br> Error in login";
								Exception e2 = new Exception(text8);
								ErrorSignal.FromCurrentContext().Raise(e2);
								text = text8;
							}
						}
						else
						{
							string text9 = Messages.msgErrorRunFunction + "<br> Error in login";
							Exception e3 = new Exception(text9);
							ErrorSignal.FromCurrentContext().Raise(e3);
							text = text9;
						}
					}
					else
					{
						string text10 = Messages.msgErrorRunFunction + "<br> Error in login";
						Exception e4 = new Exception(text10);
						ErrorSignal.FromCurrentContext().Raise(e4);
						text = text10;
					}
					if (string.IsNullOrWhiteSpace(value3))
					{
						string text11 = Messages.msgErrorRunFunction + "<br> Token is null";
						Exception e5 = new Exception(text11);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text11;
					}
					if (!string.IsNullOrWhiteSpace(value3))
					{
						string text12 = "";
						if (!string.IsNullOrEmpty(code))
						{
							text12 += ((text12.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text12 = text12 + "code=" + code;
						}
						if (!string.IsNullOrEmpty(mGroupErpCode))
						{
							text12 += ((text12.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text12 = text12 + "maingrouperpcode=" + mGroupErpCode;
						}
						if (!string.IsNullOrEmpty(sGroupErpCode))
						{
							text12 += ((text12.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text12 = text12 + "sidegrouperpcode=" + sGroupErpCode;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.Add("Authorization", value3);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/Product" + text12;
						httpClient.Timeout = new TimeSpan(0, 2, 0);
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooProductListViewModel != null)
							{
								List<WSspSelectProducts_Result> list5 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
								if (holooProductListViewModel.product != null)
								{
									foreach (HolooProductInfoViewModel item in holooProductListViewModel.product)
									{
										if (list2 == null || Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Id == item.ErpCode)) == null)
										{
											continue;
										}
										if (list5 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5))
										{
											WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == item.ErpCode));
											if (wSspSelectProducts_Result != null)
											{
												item.ProductId = wSspSelectProducts_Result.ProductID;
											}
										}
										list3.Add(item);
									}
								}
							}
							else
							{
								string text13 = Messages.msgErrorRunFunction + " (get list from Holoo) ";
								Exception e6 = new Exception(text13);
								ErrorSignal.FromCurrentContext().Raise(e6);
								text = text13;
							}
						}
						else
						{
							string msgErrorRunFunction2 = Messages.msgErrorRunFunction;
							_ = result3.StatusCode;
							HttpStatusCode statusCode = result3.StatusCode;
							string text14 = string.Concat(msgErrorRunFunction2, " (get list from Holoo) ", " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString());
							Exception e7 = new Exception(text14);
							ErrorSignal.FromCurrentContext().Raise(e7);
							text = text14;
						}
					}
				}
				else
				{
					string errorInReadingSetting = Messages.errorInReadingSetting;
					Exception e8 = new Exception(errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e8);
					text = errorInReadingSetting;
				}
			}
			else
			{
				string errorInReadingSetting2 = Messages.errorInReadingSetting;
				Exception e9 = new Exception(errorInReadingSetting2);
				ErrorSignal.FromCurrentContext().Raise(e9);
				text = errorInReadingSetting2;
			}
			if (list3 != null && Enumerable.Any<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list3))
			{
				text = "";
				int num2;
				int num3 = (num2 = Enumerable.Count<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list3));
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
					List<HolooProductInfoViewModel> list6 = new List<HolooProductInfoViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list6.Add(list3[num7]);
					}
					if (list6 == null || !Enumerable.Any<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list6))
					{
						continue;
					}
					string holooProductJson = JsonConvert.SerializeObject(list6);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkHolooWSInsertUpdateProductsFromHoloo(holooProductJson, isUseHolooPrdGroup, prdFGroupId, prdGroupId, null, prdCostGroupId, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, isGetPrdCost, centerId, linkAccSettingDBId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
							continue;
						}
						int num9 = num7 * 100 / num2;
						if (num9 >= 100)
						{
							num9 = 100;
						}
						ProgressHub.SendMessage("ok", num9, userId);
					}
					else
					{
						int num10 = num7 * 100 / num2;
						if (num10 >= 100)
						{
							num10 = 100;
						}
						ProgressHub.SendMessage("ok", num10, userId);
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
		catch (Exception e10)
		{
			ErrorSignal.FromCurrentContext().Raise(e10);
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

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult HolooImportInfo(string records, int linkAccSettingDBId, int prdFGroupId, int prdGroupId, int prdCostGroupId, bool isUseHolooPrdGroup, string mGroupErpCode = "", string sGroupErpCode = "", string code = "", bool isGetPrdCost = false)
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
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
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			List<OtherSystemSelectedVIiewModel> selectedRow = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					selectedRow = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<HolooProductInfoViewModel> list2 = new List<HolooProductInfoViewModel>();
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			string text2 = holooProvider.Authenticate();
			if (!string.IsNullOrEmpty(text2))
			{
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			string errorMessage = "";
			string text3 = "";
			if (!string.IsNullOrEmpty(code))
			{
				text3 += ((text3.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text3 = text3 + "code=" + code;
			}
			if (!string.IsNullOrEmpty(mGroupErpCode))
			{
				text3 += ((text3.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text3 = text3 + "maingrouperpcode=" + mGroupErpCode;
			}
			if (!string.IsNullOrEmpty(sGroupErpCode))
			{
				text3 += ((text3.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text3 = text3 + "sidegrouperpcode=" + sGroupErpCode;
			}
			holooProvider.ImportProductInfo(text3, lCID, result, selectedRow, ref errorMessage, ref list2);
			if (list2 != null && Enumerable.Any<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list2))
			{
				text = "";
				int num2;
				int num3 = (num2 = Enumerable.Count<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list2));
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
					List<HolooProductInfoViewModel> list3 = new List<HolooProductInfoViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list3.Add(list2[num7]);
					}
					if (list3 == null || !Enumerable.Any<HolooProductInfoViewModel>((IEnumerable<HolooProductInfoViewModel>)list3))
					{
						continue;
					}
					string value3 = JsonConvert.SerializeObject(list3);
					value3 = value3.ClearHiddenCharacters();
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkHolooWSInsertUpdateProductsFromHoloo(value3, isUseHolooPrdGroup, prdFGroupId, prdGroupId, null, prdCostGroupId, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, isGetPrdCost, centerId, linkAccSettingDBId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
							continue;
						}
						int num9 = num7 * 100 / num2;
						if (num9 >= 100)
						{
							num9 = 100;
						}
						ProgressHub.SendMessage("ok", num9, userId);
					}
					else
					{
						int num10 = num7 * 100 / num2;
						if (num10 >= 100)
						{
							num10 = 100;
						}
						ProgressHub.SendMessage("ok", num10, userId);
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

	[AjaxOnly]
	public JsonResult GetHolooImportProductList_Old(string records, string mGroupErpCode = "", string sGroupErpCode = "", string code = "")
	{
		//IL_078f: Unknown result type (might be due to invalid IL or missing references)
		//IL_068b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0698: Unknown result type (might be due to invalid IL or missing references)
		//IL_069d: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		List<HolooProductInfoViewModel> list2 = new List<HolooProductInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<CRMspSelectLinkAccHolooSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list3 != null)
			{
				string text = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text3 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				string value = "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text2,
						username = text3,
						userpass = text4
					};
					string text5 = "api/Login";
					HttpResponseMessage result2 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text + text5),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
					if (result2.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (holooLoginResultViewModel != null)
						{
							if (holooLoginResultViewModel.Login != null)
							{
								if (holooLoginResultViewModel.Login.State)
								{
									value = holooLoginResultViewModel.Login.Token ?? "";
								}
								else
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
							else
							{
								Exception e2 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
						}
						else
						{
							Exception e3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					if (string.IsNullOrWhiteSpace(value))
					{
						Exception e5 = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						string text6 = "";
						if (!string.IsNullOrEmpty(code))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "code=" + code;
						}
						if (!string.IsNullOrEmpty(mGroupErpCode))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "maingrouperpcode=" + mGroupErpCode;
						}
						if (!string.IsNullOrEmpty(sGroupErpCode))
						{
							text6 += ((text6.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
							text6 = text6 + "sidegrouperpcode=" + sGroupErpCode;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/Product" + text6;
						httpClient.Timeout = new TimeSpan(0, 2, 0);
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooProductListViewModel != null)
							{
								List<WSspSelectProducts_Result> list4 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
								int num = 1;
								if (holooProductListViewModel.product != null)
								{
									foreach (HolooProductInfoViewModel item2 in holooProductListViewModel.product)
									{
										HolooProductInfoViewModel prd = new HolooProductInfoViewModel();
										prd.Code = item2.Code;
										prd.Name = item2.Name;
										prd.ErpCode = item2.ErpCode;
										if (list4 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4))
										{
											WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdIdStr == prd.ErpCode));
											if (wSspSelectProducts_Result != null)
											{
												prd.ProductId = wSspSelectProducts_Result.ProductID;
											}
										}
										prd.RowNumber = num;
										list2.Add(prd);
										num++;
									}
								}
							}
							else
							{
								Exception e6 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
								ErrorSignal.FromCurrentContext().Raise(e6);
							}
						}
						else
						{
							string msgErrorRunFunction2 = Messages.msgErrorRunFunction;
							_ = result3.StatusCode;
							HttpStatusCode statusCode = result3.StatusCode;
							Exception e7 = new Exception(string.Concat(msgErrorRunFunction2, " (get list from Holoo) ", " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString()));
							ErrorSignal.FromCurrentContext().Raise(e7);
						}
					}
				}
				else
				{
					Exception e8 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e8);
				}
			}
			else
			{
				Exception e9 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e9);
			}
			foreach (HolooProductInfoViewModel item3 in list2)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item3.RowNumber.GetValueOrDefault(),
					Id = (item3.ErpCode ?? "0"),
					Selected = !item3.ProductId.HasValue
				};
				list.Add(item);
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
		catch (Exception e10)
		{
			ErrorSignal.FromCurrentContext().Raise(e10);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetHolooImportProductList(string records, int linkAccSettingDBId, string mGroupErpCode = "", string sGroupErpCode = "", string code = "")
	{
		//IL_01ea: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		List<HolooProductInfoViewModel> list2 = new List<HolooProductInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return Json(list, JsonRequestBehavior.AllowGet);
			}
			string errorMessage = "";
			string text = "";
			if (!string.IsNullOrEmpty(code))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "code=" + code;
			}
			if (!string.IsNullOrEmpty(mGroupErpCode))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "maingrouperpcode=" + mGroupErpCode;
			}
			if (!string.IsNullOrEmpty(sGroupErpCode))
			{
				text += ((text.IndexOf("?", StringComparison.Ordinal) >= 0) ? "&" : "?");
				text = text + "sidegrouperpcode=" + sGroupErpCode;
			}
			holooProvider.GetHolooImportProductList(text, lCID, result, ref errorMessage, ref list2);
			foreach (HolooProductInfoViewModel item2 in list2)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = (item2.ErpCode ?? "0"),
					Selected = !item2.ProductId.HasValue
				};
				list.Add(item);
			}
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetHolooPrdMainGroup_Old()
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
			List<CRMspSelectLinkAccHolooSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list2 != null)
			{
				string text = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text3 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				string value = "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text2,
						username = text3,
						userpass = text4
					};
					string text5 = "api/Login";
					HttpResponseMessage result2 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text + text5),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
					if (result2.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (holooLoginResultViewModel != null)
						{
							if (holooLoginResultViewModel.Login != null)
							{
								if (holooLoginResultViewModel.Login.State)
								{
									value = holooLoginResultViewModel.Login.Token ?? "";
								}
								else
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
							else
							{
								Exception e2 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
						}
						else
						{
							Exception e3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					if (string.IsNullOrWhiteSpace(value))
					{
						Exception e5 = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/MainGroup";
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooProductMainGroupViewModel holooProductMainGroupViewModel = JsonConvert.DeserializeObject<HolooProductMainGroupViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooProductMainGroupViewModel != null)
							{
								if (holooProductMainGroupViewModel.mainGroup != null)
								{
									foreach (HolooProductMainGroupListViewModel item in holooProductMainGroupViewModel.mainGroup)
									{
										SelectListItem selectListItem = new SelectListItem();
										selectListItem.Text = item.Name ?? "";
										selectListItem.Value = item.ErpCode;
										selectListItem.Selected = false;
										list.Add(selectListItem);
									}
								}
								else
								{
									Exception e6 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
									ErrorSignal.FromCurrentContext().Raise(e6);
								}
							}
							else
							{
								Exception e7 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
								ErrorSignal.FromCurrentContext().Raise(e7);
							}
						}
						else
						{
							Exception e8 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
							ErrorSignal.FromCurrentContext().Raise(e8);
						}
					}
				}
				else
				{
					Exception e9 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e9);
				}
			}
			else
			{
				Exception e10 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e10);
			}
		}
		catch (Exception e11)
		{
			ErrorSignal.FromCurrentContext().Raise(e11);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetHolooPrdMainGroup(int linkAccSettingDBId)
	{
		List<SelectListItem> listItems = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return Json(listItems, JsonRequestBehavior.AllowGet);
			}
			string errorMessage = "";
			holooProvider.GetPrdMainGroup(ref listItems, ref errorMessage);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(listItems, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetHolooPrdSideGroup_Old(string mGroupErpCode)
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
			List<CRMspSelectLinkAccHolooSetting_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list2 != null)
			{
				string text = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text2 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text3 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list2, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				string value = "";
				if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					if (!text.EndsWith("/"))
					{
						text += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text2,
						username = text3,
						userpass = text4
					};
					string text5 = "api/Login";
					HttpResponseMessage result2 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text + text5),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text5).Result;
					if (result2.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result2.Content.ReadAsStringAsync().Result);
						if (holooLoginResultViewModel != null)
						{
							if (holooLoginResultViewModel.Login != null)
							{
								if (holooLoginResultViewModel.Login.State)
								{
									value = holooLoginResultViewModel.Login.Token ?? "";
								}
								else
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e);
								}
							}
							else
							{
								Exception e2 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
								ErrorSignal.FromCurrentContext().Raise(e2);
							}
						}
						else
						{
							Exception e3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
							ErrorSignal.FromCurrentContext().Raise(e3);
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
						ErrorSignal.FromCurrentContext().Raise(e4);
					}
					if (string.IsNullOrWhiteSpace(value))
					{
						Exception e5 = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
						ErrorSignal.FromCurrentContext().Raise(e5);
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/SideGroup";
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooProductSideGroupViewModel holooProductSideGroupViewModel = JsonConvert.DeserializeObject<HolooProductSideGroupViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooProductSideGroupViewModel != null)
							{
								if (holooProductSideGroupViewModel.sideGroup != null)
								{
									List<HolooProductSideGroupListViewModel> list3 = Enumerable.ToList<HolooProductSideGroupListViewModel>(Enumerable.Where<HolooProductSideGroupListViewModel>((IEnumerable<HolooProductSideGroupListViewModel>)holooProductSideGroupViewModel.sideGroup, (Func<HolooProductSideGroupListViewModel, bool>)((HolooProductSideGroupListViewModel m) => m.MainErpCode == mGroupErpCode)));
									if (list3 != null)
									{
										foreach (HolooProductSideGroupListViewModel item in list3)
										{
											SelectListItem selectListItem = new SelectListItem();
											selectListItem.Text = item.Name ?? "";
											selectListItem.Value = item.ErpCode;
											selectListItem.Selected = false;
											list.Add(selectListItem);
										}
									}
								}
								else
								{
									Exception e6 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
									ErrorSignal.FromCurrentContext().Raise(e6);
								}
							}
							else
							{
								Exception e7 = new Exception(Messages.msgErrorRunFunction + " (list is empty) ");
								ErrorSignal.FromCurrentContext().Raise(e7);
							}
						}
						else
						{
							Exception e8 = new Exception(Messages.msgErrorRunFunction + " (get list from Holoo) ");
							ErrorSignal.FromCurrentContext().Raise(e8);
						}
					}
				}
				else
				{
					Exception e9 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e9);
				}
			}
			else
			{
				Exception e10 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e10);
			}
		}
		catch (Exception e11)
		{
			ErrorSignal.FromCurrentContext().Raise(e11);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetHolooPrdSideGroup(string mGroupErpCode, int linkAccSettingDBId)
	{
		List<SelectListItem> listItems = new List<SelectListItem>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return Json(listItems, JsonRequestBehavior.AllowGet);
			}
			string errorMessage = "";
			holooProvider.GetHolooPrdSideGroup(mGroupErpCode, ref listItems, ref errorMessage);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(listItems, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string HolooGetPrdQuantity_Old(int prdId)
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
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result != null)
				{
					if (!string.IsNullOrEmpty(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
					{
						List<CRMspSelectLinkAccHolooSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result2));
						if (list != null)
						{
							string text = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
							if (cRMspSelectLinkAccHolooSetting_Result != null)
							{
								text = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
							}
							string text2 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
							if (cRMspSelectLinkAccHolooSetting_Result2 != null)
							{
								text2 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
							}
							string text3 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
							if (cRMspSelectLinkAccHolooSetting_Result3 != null)
							{
								text3 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
							}
							string text4 = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
							if (cRMspSelectLinkAccHolooSetting_Result4 != null)
							{
								text4 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
							}
							string s = "";
							CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 6));
							if (cRMspSelectLinkAccHolooSetting_Result5 != null)
							{
								s = cRMspSelectLinkAccHolooSetting_Result5.PartValue ?? "";
							}
							string text5 = "";
							if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
							{
								if (!text.EndsWith("/"))
								{
									text += "/";
								}
								HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
								holooLoginViewModel.userinfo = new HolooUserInfoViewModel
								{
									dbname = text2,
									username = text3,
									userpass = text4
								};
								string text6 = "api/Login";
								HttpResponseMessage result3 = new HttpClient
								{
									Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
									BaseAddress = new Uri(text + text6),
									DefaultRequestHeaders = 
									{
										Accept = 
										{
											new MediaTypeWithQualityHeaderValue("application/json")
										}
									}
								}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text + text6).Result;
								if (!result3.IsSuccessStatusCode)
								{
									Exception e = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e);
									return Labels.frmError;
								}
								HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result3.Content.ReadAsStringAsync().Result);
								if (holooLoginResultViewModel == null)
								{
									Exception e2 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e2);
									return Labels.frmError;
								}
								if (holooLoginResultViewModel.Login == null)
								{
									Exception e3 = new Exception(Messages.msgErrorRunFunction + "<br> Error in login");
									ErrorSignal.FromCurrentContext().Raise(e3);
									return Labels.frmError;
								}
								if (!holooLoginResultViewModel.Login.State)
								{
									string msgErrorRunFunction = Messages.msgErrorRunFunction;
									string error = holooLoginResultViewModel.Login.Error;
									_ = holooLoginResultViewModel.Login.ErrorCode;
									Exception e4 = new Exception(string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode));
									ErrorSignal.FromCurrentContext().Raise(e4);
									return Labels.frmError;
								}
								text5 = holooLoginResultViewModel.Login.Token ?? "";
								if (string.IsNullOrWhiteSpace(text5))
								{
									Exception e5 = new Exception(Messages.msgErrorRunFunction + "<br> Token is null");
									ErrorSignal.FromCurrentContext().Raise(e5);
									return Labels.frmError;
								}
								if (!string.IsNullOrWhiteSpace(text5))
								{
									string text7 = "?code=" + wSspSelectProductsWithId_Result.PrdLinkAccPrdCode;
									if (!string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.FGLinkAccGroupIdStr))
									{
										text7 = text7 + "&maingrouperpcode=" + wSspSelectProductsWithId_Result.FGLinkAccGroupIdStr;
									}
									if (!string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.SGLinkAccGroupIdStr))
									{
										text7 = text7 + "&sidegrouperpcode=" + wSspSelectProductsWithId_Result.SGLinkAccGroupIdStr;
									}
									HttpClient httpClient = new HttpClient();
									httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Add("Authorization", text5);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "api/Product" + text7;
									HttpResponseMessage result4 = httpClient.GetAsync(requestUri).Result;
									if (!result4.IsSuccessStatusCode)
									{
										Exception e6 = new Exception(Messages.msgErrorRunFunction + " (get product information from Holoo) ");
										ErrorSignal.FromCurrentContext().Raise(e6);
										return Labels.frmError;
									}
									HolooProductListViewModel holooProductListViewModel = JsonConvert.DeserializeObject<HolooProductListViewModel>(result4.Content.ReadAsStringAsync().Result);
									if (holooProductListViewModel == null)
									{
										Exception e7 = new Exception(Messages.msgErrorRunFunction + " (get product information from Holoo) ");
										ErrorSignal.FromCurrentContext().Raise(e7);
										return Labels.frmError;
									}
									if (holooProductListViewModel.product != null)
									{
										if (holooProductListViewModel.product.Count != 1)
										{
											Exception e8 = new Exception(Messages.msgErrorRunFunction + " (not find prodcut information from Holoo or find more one than) ");
											ErrorSignal.FromCurrentContext().Raise(e8);
											return Labels.frmError;
										}
										double valueOrDefault = holooProductListViewModel.product[0].Few.GetValueOrDefault();
										double valueOrDefault2 = holooProductListViewModel.product[0].fewspd.GetValueOrDefault();
										int result5 = 0;
										int.TryParse(s, out result5);
										result = ((result5 != 1) ? valueOrDefault.ToString() : valueOrDefault2.ToString());
									}
								}
							}
							else
							{
								Exception e9 = new Exception(Messages.errorInReadingSetting);
								ErrorSignal.FromCurrentContext().Raise(e9);
								result = Labels.frmError;
							}
						}
						else
						{
							Exception e10 = new Exception(Messages.errorInReadingSetting);
							ErrorSignal.FromCurrentContext().Raise(e10);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e11 = new Exception(Messages.ErrorNotFound + "(This product by name " + wSspSelectProductsWithId_Result.PrdName + " not have code");
						ErrorSignal.FromCurrentContext().Raise(e11);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e12 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e12);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e13 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e13);
				result = Labels.frmError;
			}
		}
		catch (Exception e14)
		{
			ErrorSignal.FromCurrentContext().Raise(e14);
			result = Labels.frmError;
		}
		return result;
	}

	public string HolooGetPrdQuantity(int prdId, int linkAccSettingDBId = 0)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
			if (prdId > 0)
			{
				if (linkAccSettingDBId == 0)
				{
					string prdLinkAccPrdCode = wSspSelectProductsWithId_Result.PrdLinkAccPrdCode;
					PrdLinkAccDataViewModel prdLinkAccDataViewModel = Enumerable.FirstOrDefault<PrdLinkAccDataViewModel>((IEnumerable<PrdLinkAccDataViewModel>)((!string.IsNullOrEmpty(prdLinkAccPrdCode)) ? JsonConvert.DeserializeObject<List<PrdLinkAccDataViewModel>>(prdLinkAccPrdCode) : new List<PrdLinkAccDataViewModel>()), (Func<PrdLinkAccDataViewModel, bool>)((PrdLinkAccDataViewModel x) => x.DBId.HasValue && x.DBId != 0));
					if (prdLinkAccDataViewModel != null)
					{
						linkAccSettingDBId = prdLinkAccDataViewModel.DBId.Value;
					}
				}
				if (wSspSelectProductsWithId_Result != null && linkAccSettingDBId != 0)
				{
					CRMspLkHolooSelectProductWithLinkAccFields_Result cRMspLkHolooSelectProductWithLinkAccFields_Result = Enumerable.FirstOrDefault<CRMspLkHolooSelectProductWithLinkAccFields_Result>((IEnumerable<CRMspLkHolooSelectProductWithLinkAccFields_Result>)_dbLink.CRMspLkHolooSelectProductWithLinkAccFields(prdId, linkAccSettingDBId));
					CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
					string text2 = holooProvider.Authenticate();
					if (!string.IsNullOrEmpty(text2))
					{
						return text2;
					}
					if (!string.IsNullOrEmpty(cRMspLkHolooSelectProductWithLinkAccFields_Result.Code))
					{
						int prdInvStockDisplayType = holooProvider.PrdInvStockDisplayType;
						string errorMessage = "";
						text = holooProvider.GetPrdQuantity(cRMspLkHolooSelectProductWithLinkAccFields_Result, prdInvStockDisplayType.ToString(), ref errorMessage);
						if (!string.IsNullOrEmpty(errorMessage))
						{
							text = errorMessage;
						}
					}
					else
					{
						Exception e = new Exception(Messages.ErrorNotFound + "(This product not have code");
						ErrorSignal.FromCurrentContext().Raise(e);
						text = Labels.frmError;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e2);
					text = Labels.frmError;
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e3);
				text = Labels.frmError;
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			text = Labels.frmError;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult NoAvIIImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		GetWrhsLinked(withWrhsLinkAccWhId: false, withWrhsLinkAccWhCode: true);
		GetUserLinked(withLinkAccUserIdStr: false, withLinkAccUserCode: true);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvIIImportProduct_Read([DataSourceRequest] DataSourceRequest request, string name = "", string code = "", string noavUserId = "", string noavWhId = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<NoAvaranIIProductInfoViewModel> list = new List<NoAvaranIIProductInfoViewModel>();
		try
		{
			string text = new ServiceSoapClient().ReadFromMaterial(name, code, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("[") >= 0)
			{
				List<NoAvaranIIProductInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranIIProductInfoViewModel>>(text);
				if (list2 != null)
				{
					List<WSspSelectProducts_Result> list3 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
					int num = 1;
					foreach (NoAvaranIIProductInfoViewModel item in list2)
					{
						NoAvaranIIProductInfoViewModel prd = new NoAvaranIIProductInfoViewModel();
						prd.KalaNAme = item.KalaNAme;
						prd.Code = item.Code;
						prd.Store = item.Store;
						prd.Quan = item.Quan;
						prd.Cost = item.Cost;
						prd.PriceHaraji = item.PriceHaraji;
						prd.PriceOmdeh = item.PriceOmdeh;
						prd.Sel_Price = item.Sel_Price;
						prd.In_Price = item.In_Price;
						prd.Tech_NoM = item.Tech_NoM;
						prd.CodeBazargani = item.CodeBazargani;
						prd.ParentCode = item.ParentCode;
						prd.DisLatin = item.DisLatin;
						if (list3 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list3))
						{
							WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list3, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdCode == prd.Code));
							if (wSspSelectProducts_Result != null)
							{
								prd.ProductId = wSspSelectProducts_Result.ProductID;
							}
						}
						prd.RowNumber = num;
						list.Add(prd);
						num++;
					}
				}
				else
				{
					Exception e = new Exception(Messages.msgErrorRunFunction + " (get list from NoAvII) ");
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult NoAvIIImportInfo(string records, int prdFGroupId, int prdSGroupId, int prdPriceGroupId, int prdCostGroupId, string name = "", string code = "", string noavUserId = "", string noavWhId = "")
	{
		//IL_00d3: Unknown result type (might be due to invalid IL or missing references)
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
			List<NoAvaranIIProductInfoViewModel> list3 = new List<NoAvaranIIProductInfoViewModel>();
			string text2 = new ServiceSoapClient().ReadFromMaterial(name, code, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text2))
			{
				if (text2.IndexOf("[") >= 0)
				{
					List<NoAvaranIIProductInfoViewModel> list4 = JsonConvert.DeserializeObject<List<NoAvaranIIProductInfoViewModel>>(text2);
					if (list4 != null)
					{
						List<WSspSelectProducts_Result> list5 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
						foreach (NoAvaranIIProductInfoViewModel item in list4)
						{
							if (list2 == null || Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Id == item.Code)) == null)
							{
								continue;
							}
							if (list5 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5))
							{
								WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list5, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdCode == item.Code));
								if (wSspSelectProducts_Result != null)
								{
									item.ProductId = wSspSelectProducts_Result.ProductID;
								}
							}
							list3.Add(item);
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
			if (list3 != null && Enumerable.Any<NoAvaranIIProductInfoViewModel>((IEnumerable<NoAvaranIIProductInfoViewModel>)list3))
			{
				text = "";
				string noAvIIProductJson = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkNoAvIIWSInsertUpdateProductsFromNoAvII(noAvIIProductJson, prdFGroupId, prdSGroupId, prdPriceGroupId, prdCostGroupId, userId, value2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
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
	public JsonResult GetNoAvIIImportProductList(string records, string name = "", string code = "", string noavUserId = "", string noavWhId = "")
	{
		//IL_02ff: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		List<NoAvaranIIProductInfoViewModel> list2 = new List<NoAvaranIIProductInfoViewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			string text = new ServiceSoapClient().ReadFromMaterial(name, code, noavWhId, noavUserId);
			if (!string.IsNullOrWhiteSpace(text) && text.IndexOf("[") >= 0)
			{
				List<NoAvaranIIProductInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NoAvaranIIProductInfoViewModel>>(text);
				if (list3 != null)
				{
					List<WSspSelectProducts_Result> list4 = Enumerable.ToList<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)_db.WSspSelectProducts(lCID, result));
					int num = 1;
					foreach (NoAvaranIIProductInfoViewModel item2 in list3)
					{
						NoAvaranIIProductInfoViewModel prd = new NoAvaranIIProductInfoViewModel();
						prd.KalaNAme = item2.KalaNAme;
						prd.Code = item2.Code;
						prd.Store = item2.Store;
						prd.Quan = item2.Quan;
						prd.Cost = item2.Cost;
						prd.PriceHaraji = item2.PriceHaraji;
						prd.PriceOmdeh = item2.PriceOmdeh;
						prd.Sel_Price = item2.Sel_Price;
						prd.In_Price = item2.In_Price;
						prd.Tech_NoM = item2.Tech_NoM;
						prd.CodeBazargani = item2.CodeBazargani;
						prd.ParentCode = item2.ParentCode;
						prd.DisLatin = item2.DisLatin;
						if (list4 != null && Enumerable.Any<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4))
						{
							WSspSelectProducts_Result wSspSelectProducts_Result = Enumerable.FirstOrDefault<WSspSelectProducts_Result>((IEnumerable<WSspSelectProducts_Result>)list4, (Func<WSspSelectProducts_Result, bool>)((WSspSelectProducts_Result m) => m.PrdLinkAccPrdCode == prd.Code));
							if (wSspSelectProducts_Result != null)
							{
								prd.ProductId = wSspSelectProducts_Result.ProductID;
							}
						}
						prd.RowNumber = num;
						list2.Add(prd);
						num++;
					}
				}
				else
				{
					Exception e = new Exception(Messages.msgErrorRunFunction + " (get list from NoAvII) ");
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			foreach (NoAvaranIIProductInfoViewModel item3 in list2)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item3.RowNumber.GetValueOrDefault(),
					Id = (item3.Code ?? "0"),
					Selected = !item3.ProductId.HasValue
				};
				list.Add(item);
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
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ValidationSoapHeader GetKyanToken()
	{
		string tokenAUT = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			CRMspSelectLinkAccKyanSetting_Result cRMspSelectLinkAccKyanSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccKyanSetting_Result>((IEnumerable<CRMspSelectLinkAccKyanSetting_Result>)_dbLink.CRMspSelectLinkAccKyanSetting(1, "Setting", lCID, result));
			if (cRMspSelectLinkAccKyanSetting_Result != null)
			{
				tokenAUT = cRMspSelectLinkAccKyanSetting_Result.PartValue ?? "";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return new ValidationSoapHeader
		{
			TokenAUT = tokenAUT
		};
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult KyanImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		return View();
	}

	public KyanProductInfoViewModelObjects GetKyanProductList(string fDate, string tDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		KyanProductInfoViewModelObjects kyanProductInfoViewModelObjects = new KyanProductInfoViewModelObjects();
		List<KyanProductInfoViewModel> list = new List<KyanProductInfoViewModel>();
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
			KyanOnlineSaleServiceSoapClient kyanOnlineSaleServiceSoapClient = new KyanOnlineSaleServiceSoapClient();
			ValidationSoapHeader kyanToken = GetKyanToken();
			if (kyanToken != null)
			{
				if (!string.IsNullOrEmpty(kyanToken.TokenAUT))
				{
					ResponseDataOfitm itemList = kyanOnlineSaleServiceSoapClient.GetItemList(kyanToken, null, (!string.IsNullOrEmpty(fDate)) ? dateTime.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : string.Empty, (!string.IsNullOrEmpty(tDate)) ? dateTime2.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : string.Empty);
					if (itemList != null && itemList.ResponseMessage.ToString().ToLower().Contains("success") && Enumerable.Count<itm>((IEnumerable<itm>)itemList.ResponseResult) > 0)
					{
						long num = 1L;
						List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, true, false, lCID, result));
						itm[] responseResult = itemList.ResponseResult;
						foreach (itm item in responseResult)
						{
							KyanProductInfoViewModel kyanProductInfoViewModel = new KyanProductInfoViewModel();
							kyanProductInfoViewModel.ItemDescription = item.ItemDescription;
							kyanProductInfoViewModel.itmBrcd = item.itmBrcd;
							kyanProductInfoViewModel.itmCreateDate = item.itmCreateDate;
							kyanProductInfoViewModel.itmID = item.itmID;
							kyanProductInfoViewModel.itmName = item.itmName;
							kyanProductInfoViewModel.itmPrice = item.itmPrice;
							kyanProductInfoViewModel.itmQuantity = item.itmQuantity;
							kyanProductInfoViewModel.itmRsGrpPrice = item.itmRsGrpPrice;
							kyanProductInfoViewModel.itmRsGrpTempPrice = item.itmRsGrpTempPrice;
							kyanProductInfoViewModel.itmTempPrice = item.itmTempPrice;
							kyanProductInfoViewModel.POSDepartmentID = item.POSDepartmentID;
							kyanProductInfoViewModel.POSDepartmentName = item.POSDepartmentName;
							kyanProductInfoViewModel.serials = item.serials;
							kyanProductInfoViewModel.Taxable = item.Taxable;
							kyanProductInfoViewModel.UserPrice = item.UserPrice;
							kyanProductInfoViewModel.RowNumber = num;
							if (list2.FindIndex((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId == item.itmID) > 0)
							{
								WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>(Enumerable.Where<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId == item.itmID)));
								kyanProductInfoViewModel.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
							}
							if (!string.IsNullOrWhiteSpace(item.itmCreateDate))
							{
								if (item.itmCreateDate.Length > 8)
								{
									DateTime result2 = DateTime.Now;
									DateTime.TryParse(item.itmCreateDate.ToString(), new CultureInfo("en-US"), DateTimeStyles.None, out result2);
									kyanProductInfoViewModel.itmCreateDate_Datetime = result2;
									kyanProductInfoViewModel.itmCreateDate_Persian = result2.ToString("yyyyMMdd", new PersianCulture());
								}
								else
								{
									string s = string.Concat(string.Concat(item.itmCreateDate.Substring(0, 4) + "/", item.itmCreateDate.Substring(4, 2), "/"), item.itmCreateDate.Substring(6, 2), " 00:00:01");
									DateTime result3 = DateTime.Now;
									DateTime.TryParse(s, new CultureInfo("en-US"), DateTimeStyles.None, out result3);
									kyanProductInfoViewModel.itmCreateDate_Datetime = result3;
									kyanProductInfoViewModel.itmCreateDate_Persian = result3.ToString("yyyyMMdd", new PersianCulture());
								}
							}
							list.Add(kyanProductInfoViewModel);
							num++;
						}
					}
					kyanProductInfoViewModelObjects.lst = list;
					kyanProductInfoViewModelObjects.FilteredLst = list;
					kyanProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
					kyanProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
				}
				else
				{
					Exception e = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e);
				}
			}
			else
			{
				Exception e2 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return kyanProductInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult KyanImportProduct_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "")
	{
		return Json(((IEnumerable)GetKyanProductList(fDate, tDate).lst).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult KyanImportInfo(string records, int prdFGroupId, int prdSGroupId, int prdPriceGroupId, int prdCostGroupId, string fDate = "", string tDate = "")
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
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
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<KyanProductInfoViewModel> list3 = new List<KyanProductInfoViewModel>();
			List<KyanProductInfoViewModel> lst = GetKyanProductList(fDate, tDate).lst;
			if (lst != null)
			{
				List<WSspSelectProductWithAccLinkField_Result> list4 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, true, false, lCID, result));
				foreach (KyanProductInfoViewModel item in lst)
				{
					if (list2 == null || Enumerable.FirstOrDefault<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Id == item.itmID.ToString())) == null)
					{
						continue;
					}
					if (list4 != null && Enumerable.Any<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list4))
					{
						WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list4, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId == item.itmID));
						if (wSspSelectProductWithAccLinkField_Result != null)
						{
							item.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
						}
					}
					list3.Add(item);
				}
			}
			else
			{
				string text2 = Messages.msgErrorRunFunction + " (get list from Kyan) ";
				Exception e = new Exception(text2);
				ErrorSignal.FromCurrentContext().Raise(e);
				text = text2;
			}
			if (list3 != null && Enumerable.Any<KyanProductInfoViewModel>((IEnumerable<KyanProductInfoViewModel>)list3))
			{
				text = "";
				string text3 = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkKyanWSInsertUpdateProductsFromKyan(text3, prdFGroupId, prdSGroupId, prdPriceGroupId, prdCostGroupId, userId, year1: value2, month1: value3, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, errorMessage: objectParameter, centerId: centerId);
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
	public JsonResult GetKyanImportProductList(string records, string fDate = "", string tDate = "")
	{
		//IL_008e: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (KyanProductInfoViewModel item2 in GetKyanProductList(fDate, tDate).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.itmID.ToString(),
					Selected = (item2.ProductId <= 0)
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					foreach (OtherSystemSelectedVIiewModel item3 in list2)
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string KyanGetPrdQuantity(int prdId, int whId)
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result != null)
				{
					if (string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdFirstBarcode))
					{
						Exception e = new Exception(Messages.ErrorNotFound + "(BarCode)");
						ErrorSignal.FromCurrentContext().Raise(e);
						return Labels.frmError;
					}
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, false, lCID, result));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (!wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhId.HasValue)
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in kyan)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						int valueOrDefault = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhId.GetValueOrDefault();
						string text2 = wSspSelectProductsWithId_Result.PrdFirstBarcode ?? "";
						KyanOnlineSaleServiceSoapClient kyanOnlineSaleServiceSoapClient = new KyanOnlineSaleServiceSoapClient();
						ValidationSoapHeader kyanToken = GetKyanToken();
						if (kyanToken != null)
						{
							if (!string.IsNullOrEmpty(kyanToken.TokenAUT))
							{
								int[] array = new int[1];
								string[] array2 = new string[1];
								array[0] = valueOrDefault;
								array2[0] = text2;
								ResponseDataOfItemStock2 itemsQuantityListInventoryWithBarcode = kyanOnlineSaleServiceSoapClient.GetItemsQuantityListInventoryWithBarcode(kyanToken, null, array, array2);
								if (itemsQuantityListInventoryWithBarcode != null && itemsQuantityListInventoryWithBarcode.ResponseMessage.ToString().ToLower().Contains("success"))
								{
									if (itemsQuantityListInventoryWithBarcode.ResponseResult != null)
									{
										ItemStock2 itemStock = Enumerable.FirstOrDefault<ItemStock2>((IEnumerable<ItemStock2>)itemsQuantityListInventoryWithBarcode.ResponseResult);
										if (itemStock != null)
										{
											return itemStock.Quantity.ToString() ?? "0";
										}
										return "0";
									}
									return "0";
								}
								return "0";
							}
							Exception e3 = new Exception(Messages.errorInReadingSetting + " (not find token)");
							ErrorSignal.FromCurrentContext().Raise(e3);
							return Labels.frmError;
						}
						Exception e4 = new Exception(Messages.errorInReadingSetting + " (not find token)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						return Labels.frmError;
					}
					Exception e5 = new Exception(Messages.ErrorNotFound + "(warehouse)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					return Labels.frmError;
				}
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				return Labels.frmError;
			}
			Exception e7 = new Exception(Messages.ErrorNotFound + "(product)");
			ErrorSignal.FromCurrentContext().Raise(e7);
			return Labels.frmError;
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			return Labels.frmError;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult PayvastImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		return View();
	}

	public PayvastProductInfoViewModelObjects GetPayvastProductList(string selectedDate)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		PayvastProductInfoViewModelObjects payvastProductInfoViewModelObjects = new PayvastProductInfoViewModelObjects();
		List<PayvastProductInfoViewModel> list = new List<PayvastProductInfoViewModel>();
		try
		{
			DateTime selectedDate2 = DateTime.Now;
			if (!string.IsNullOrEmpty(selectedDate))
			{
				selectedDate = DateTime.Parse(PersianDate.GetFormatetdDate(selectedDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				}).ToString(new CultureInfo("en-US"));
				selectedDate2 = DateTime.Parse(selectedDate, new CultureInfo("en-US"));
			}
			AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
			PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
			Merchandise[] merchandiseList = accountingServiceSoapClient.GetMerchandiseList(payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(selectedDate2), -1);
			if (merchandiseList != null && Enumerable.Count<Merchandise>((IEnumerable<Merchandise>)merchandiseList) > 0)
			{
				long num = 1L;
				List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, true, false, lCID, result));
				Merchandise[] array = merchandiseList;
				foreach (Merchandise item in array)
				{
					if (payvastSetting.PayvastPrdCodeLength != -1 && item.Code.Length != payvastSetting.PayvastPrdCodeLength)
					{
						continue;
					}
					PayvastProductInfoViewModel payvastProductInfoViewModel = new PayvastProductInfoViewModel();
					payvastProductInfoViewModel.Id = item.Id;
					payvastProductInfoViewModel.Name = item.Name;
					payvastProductInfoViewModel.EnglishName = item.EnglishName;
					payvastProductInfoViewModel.FiscalPeriod = item.FiscalPeriod;
					payvastProductInfoViewModel.Barcode = item.Barcode;
					payvastProductInfoViewModel.Code = item.Code;
					payvastProductInfoViewModel.IranCode = item.IranCode;
					payvastProductInfoViewModel.TechnicalCode = item.TechnicalCode;
					payvastProductInfoViewModel.UnitId = item.UnitId;
					payvastProductInfoViewModel.Unit = item.Unit;
					payvastProductInfoViewModel.RowNumber = num;
					payvastProductInfoViewModel.RowNumber = num;
					if (list2.FindIndex((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId == item.Id) > 0)
					{
						WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>(Enumerable.Where<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId == item.Id)));
						payvastProductInfoViewModel.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
					}
					list.Add(payvastProductInfoViewModel);
					num++;
				}
			}
			payvastProductInfoViewModelObjects.lst = list;
			payvastProductInfoViewModelObjects.FilteredLst = list;
			payvastProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			payvastProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception)
		{
			Exception e = new Exception(Messages.msgErrorRunFunction + " (get products list from Payvast) ");
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return payvastProductInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult PayvastImportProduct_Read([DataSourceRequest] DataSourceRequest request, string SelectedDate = "")
	{
		return Json(((IEnumerable)GetPayvastProductList(SelectedDate).lst).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult PayvastImportInfo(string records, int prdFGroupId, int prdSGroupId, string selectedDate = "")
	{
		//IL_00ed: Unknown result type (might be due to invalid IL or missing references)
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
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<PayvastProductInfoViewModel> list3 = new List<PayvastProductInfoViewModel>();
			AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
			PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
			List<PayvastProductInfoViewModel> lst = GetPayvastProductList(selectedDate).lst;
			MerchandisePrice[] merchandisePriceList = accountingServiceSoapClient.GetMerchandisePriceList(0, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now), DateTime.Now, payvastSetting.PayvastUsername, payvastSetting.PayvastPassword);
			MerchandisePrice[] merchandisePriceList2 = accountingServiceSoapClient.GetMerchandisePriceList(1, CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now), DateTime.Now, payvastSetting.PayvastUsername, payvastSetting.PayvastPassword);
			if (list2 != null && list2.Count > 0 && lst != null && lst.Count > 0)
			{
				List<WSspSelectProductWithAccLinkField_Result> list4 = SelectProductWithAccLinkField(withPrdLinkAccPrdCode: false, withPrdLinkAccPrdId: true, withPrdLinkAccPrdIdStr: false, lCID, result);
				foreach (OtherSystemSelectedVIiewModel item in list2)
				{
					PayvastProductInfoViewModel CurrentRow = Enumerable.FirstOrDefault<PayvastProductInfoViewModel>(Enumerable.Where<PayvastProductInfoViewModel>((IEnumerable<PayvastProductInfoViewModel>)lst, (Func<PayvastProductInfoViewModel, bool>)((PayvastProductInfoViewModel x) => x.Id.ToString() == item.Id)));
					if (CurrentRow == null)
					{
						continue;
					}
					PayvastProductInfoViewModel payvastProductInfoViewModel = new PayvastProductInfoViewModel();
					payvastProductInfoViewModel.Id = CurrentRow.Id;
					payvastProductInfoViewModel.Name = CurrentRow.Name;
					payvastProductInfoViewModel.EnglishName = CurrentRow.EnglishName;
					payvastProductInfoViewModel.FiscalPeriod = CurrentRow.FiscalPeriod;
					payvastProductInfoViewModel.Barcode = CurrentRow.Barcode;
					payvastProductInfoViewModel.Code = CurrentRow.Code;
					payvastProductInfoViewModel.IranCode = CurrentRow.IranCode;
					payvastProductInfoViewModel.TechnicalCode = CurrentRow.TechnicalCode;
					payvastProductInfoViewModel.UnitId = CurrentRow.UnitId;
					payvastProductInfoViewModel.Unit = CurrentRow.Unit;
					WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list4, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdId.ToString() == item.Id));
					if (wSspSelectProductWithAccLinkField_Result != null)
					{
						payvastProductInfoViewModel.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
					}
					else
					{
						payvastProductInfoViewModel.ProductId = 0;
					}
					if (merchandisePriceList != null)
					{
						MerchandisePrice merchandisePrice = Enumerable.FirstOrDefault<MerchandisePrice>((IEnumerable<MerchandisePrice>)merchandisePriceList, (Func<MerchandisePrice, bool>)((MerchandisePrice x) => x.Code == CurrentRow.Code));
						if (merchandisePrice != null)
						{
							payvastProductInfoViewModel.ProductPrice = merchandisePrice.Price_1;
							if (merchandisePrice.Price_1 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceI = merchandisePrice.Price_1;
							}
							if (merchandisePrice.Price_2 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceII = merchandisePrice.Price_2;
							}
							if (merchandisePrice.Price_3 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceIII = merchandisePrice.Price_3;
							}
							if (merchandisePrice.Price_4 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceIV = merchandisePrice.Price_4;
							}
							if (merchandisePrice.Price_5 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceV = merchandisePrice.Price_5;
							}
							if (merchandisePrice.Price_6 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceVI = merchandisePrice.Price_6;
							}
							if (merchandisePrice.Price_7 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceVII = merchandisePrice.Price_7;
							}
							if (merchandisePrice.Price_8 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceVIII = merchandisePrice.Price_8;
							}
							if (merchandisePrice.Price_9 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceIX = merchandisePrice.Price_9;
							}
							if (merchandisePrice.Price_10 > 0.0)
							{
								payvastProductInfoViewModel.ProductPriceX = merchandisePrice.Price_10;
							}
						}
					}
					else
					{
						payvastProductInfoViewModel.ProductPrice = 0.0;
						payvastProductInfoViewModel.ProductPriceI = 0.0;
						payvastProductInfoViewModel.ProductPriceII = 0.0;
						payvastProductInfoViewModel.ProductPriceIII = 0.0;
						payvastProductInfoViewModel.ProductPriceIV = 0.0;
						payvastProductInfoViewModel.ProductPriceV = 0.0;
						payvastProductInfoViewModel.ProductPriceVI = 0.0;
						payvastProductInfoViewModel.ProductPriceVII = 0.0;
						payvastProductInfoViewModel.ProductPriceVIII = 0.0;
						payvastProductInfoViewModel.ProductPriceIX = 0.0;
						payvastProductInfoViewModel.ProductPriceX = 0.0;
					}
					if (merchandisePriceList2 != null)
					{
						MerchandisePrice merchandisePrice2 = Enumerable.FirstOrDefault<MerchandisePrice>((IEnumerable<MerchandisePrice>)merchandisePriceList2, (Func<MerchandisePrice, bool>)((MerchandisePrice x) => x.Code == CurrentRow.Code));
						if (merchandisePrice2 != null)
						{
							if (merchandisePrice2.Price_1 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostI = merchandisePrice2.Price_1;
							}
							if (merchandisePrice2.Price_2 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostII = merchandisePrice2.Price_2;
							}
							if (merchandisePrice2.Price_3 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostIII = merchandisePrice2.Price_3;
							}
							if (merchandisePrice2.Price_4 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostIV = merchandisePrice2.Price_4;
							}
							if (merchandisePrice2.Price_5 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostV = merchandisePrice2.Price_5;
							}
							if (merchandisePrice2.Price_6 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostVI = merchandisePrice2.Price_6;
							}
							if (merchandisePrice2.Price_7 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostVII = merchandisePrice2.Price_7;
							}
							if (merchandisePrice2.Price_8 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostVIII = merchandisePrice2.Price_8;
							}
							if (merchandisePrice2.Price_9 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostIX = merchandisePrice2.Price_9;
							}
							if (merchandisePrice2.Price_10 > 0.0)
							{
								payvastProductInfoViewModel.ProductCostX = merchandisePrice2.Price_10;
							}
						}
					}
					else
					{
						payvastProductInfoViewModel.ProductCostI = 0.0;
						payvastProductInfoViewModel.ProductCostII = 0.0;
						payvastProductInfoViewModel.ProductCostIII = 0.0;
						payvastProductInfoViewModel.ProductCostIV = 0.0;
						payvastProductInfoViewModel.ProductCostV = 0.0;
						payvastProductInfoViewModel.ProductCostVI = 0.0;
						payvastProductInfoViewModel.ProductCostVII = 0.0;
						payvastProductInfoViewModel.ProductCostVIII = 0.0;
						payvastProductInfoViewModel.ProductCostIX = 0.0;
						payvastProductInfoViewModel.ProductCostX = 0.0;
					}
					list3.Add(payvastProductInfoViewModel);
				}
			}
			if (list3 != null && Enumerable.Any<PayvastProductInfoViewModel>((IEnumerable<PayvastProductInfoViewModel>)list3))
			{
				text = "";
				string text2 = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkPayvastWSInsertUpdateProductsFromPayvast(text2, prdFGroupId, prdSGroupId, userId, year1: value2, month1: value3, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, errorMessage: objectParameter, centerId: centerId);
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
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
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
	public JsonResult GetPayvastImportProductList(string selectedDate = "")
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (PayvastProductInfoViewModel item2 in GetPayvastProductList(selectedDate).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.Id.ToString(),
					Selected = (item2.ProductId <= 0)
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

	[AjaxOnly]
	public string PayvastGetPrdQuantity(int prdId, int whId)
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
			if (prdId > 0)
			{
				WSspSelectProductWithAccLinkField_Result prd = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, true, true, lCID, result2), (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.ProductID == prdId));
				if (prd != null && prd.PrdLinkAccPrdId >= 0)
				{
					WSspSelectWareHouseWithAccLinkField_Result wrhs = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, false, lCID, result2));
					if (list != null)
					{
						wrhs = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wrhs != null)
					{
						if (!wrhs.WrhsLinkAccWhId.HasValue)
						{
							Exception e = new Exception(Messages.ErrorNotFound + "(warehouse in Payvast)");
							ErrorSignal.FromCurrentContext().Raise(e);
							result = Labels.frmError;
						}
						else
						{
							AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
							PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
							CRMIdeal.LinkPayvast.Stock[] stockList = accountingServiceSoapClient.GetStockList(CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now), DateTime.Now, payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, includeProforma: false);
							if (stockList != null)
							{
								CRMIdeal.LinkPayvast.Stock stock = Enumerable.FirstOrDefault<CRMIdeal.LinkPayvast.Stock>((IEnumerable<CRMIdeal.LinkPayvast.Stock>)stockList, (Func<CRMIdeal.LinkPayvast.Stock, bool>)((CRMIdeal.LinkPayvast.Stock x) => x.MerchandiseId == prd.PrdLinkAccPrdId && x.StockRoomId == wrhs.WrhsLinkAccWhId));
								result = ((stock == null) ? "0" : stock.Amount.ToString());
							}
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e4 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e4);
				result = Labels.frmError;
			}
		}
		catch (Exception e5)
		{
			ErrorSignal.FromCurrentContext().Raise(e5);
			result = Labels.frmError;
		}
		return result;
	}

	public List<WSspSelectProductWithAccLinkField_Result> SelectProductWithAccLinkField(bool withPrdLinkAccPrdCode = true, bool withPrdLinkAccPrdId = true, bool withPrdLinkAccPrdIdStr = true, int languageID = 1065, int defaultLanguageID = 1065)
	{
		List<WSspSelectProductWithAccLinkField_Result> result = new List<WSspSelectProductWithAccLinkField_Result>();
		try
		{
			result = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(withPrdLinkAccPrdCode, withPrdLinkAccPrdId, withPrdLinkAccPrdIdStr, languageID, defaultLanguageID));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<WSspSelectProductUnitWithAccLinkField_Result> SelectProductUnitWithAccLinkField(bool withUnitLinkAccUnitId = true, bool withUnitLinkAccUnitIdStr = true, int languageID = 1065, int defaultLanguageID = 1065)
	{
		List<WSspSelectProductUnitWithAccLinkField_Result> result = new List<WSspSelectProductUnitWithAccLinkField_Result>();
		try
		{
			result = Enumerable.ToList<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)_dbLink.WSspSelectProductUnitWithAccLinkField(withUnitLinkAccUnitId, withUnitLinkAccUnitIdStr, languageID, defaultLanguageID));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	public List<CRMspLkWSSelectProduct_Result> SelectProducts(string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		List<CRMspLkWSSelectProduct_Result> list = new List<CRMspLkWSSelectProduct_Result>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			if (!string.IsNullOrEmpty(fDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tDate))
			{
				value3 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			list = Enumerable.ToList<CRMspLkWSSelectProduct_Result>((IEnumerable<CRMspLkWSSelectProduct_Result>)_dbLink.CRMspLkWSSelectProduct((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value3) : null, value, fgId, sgId, lCID, result));
			foreach (CRMspLkWSSelectProduct_Result item in list)
			{
				item.PrdName = ((!string.IsNullOrEmpty(item.PrdFGroupName)) ? item.PrdFGroupName : "") + ((!string.IsNullOrEmpty(item.PrdSGroupName)) ? (" - " + item.PrdSGroupName) : "") + ((!string.IsNullOrEmpty(item.PrdName)) ? (" - " + item.PrdName) : "");
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult ExportProduct_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		return Json(((IEnumerable)SelectProducts(fDate, tDate, value, fgId, sgId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public List<WSspSelectProductsSecondGroupWithAccLinkField_Result> SelectProductsSecondGroupWithAccLinkField(bool withLinkAccGroupId = false, bool withLinkAccGroupCode = false, bool withLinkAccGroupIdStr = false, bool withLinkAccGroups = false)
	{
		List<WSspSelectProductsSecondGroupWithAccLinkField_Result> result = new List<WSspSelectProductsSecondGroupWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: withLinkAccGroupId, withLinkAccGroupCode: withLinkAccGroupCode, withLinkAccGroupIdStr: withLinkAccGroupIdStr, withLinkAccGroups: withLinkAccGroups, languageID: lCID, defaultLanguageID: result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actImportFromAcc")]
	public ActionResult ShygunImportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		return View();
	}

	public ShygunProductInfoViewModelObjects GetShygunProductList(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		//IL_01d8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01df: Expected O, but got Unknown
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunProductInfoViewModelObjects shygunProductInfoViewModelObjects = new ShygunProductInfoViewModelObjects();
		List<ShygunProductInfoViewModel> list = new List<ShygunProductInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			DomainItem domainItem = new DomainItem();
			if (string.IsNullOrWhiteSpace(fCode) || fCode.Trim() == "0")
			{
				fCode = "";
			}
			if (string.IsNullOrWhiteSpace(tCode) || tCode.Trim() == "0")
			{
				tCode = "";
			}
			domainItem.ItemCode.From = fCode.Trim();
			domainItem.ItemCode.To = tCode.Trim();
			domainItem.ItemGuId.From = string.Empty;
			domainItem.ItemGuId.To = string.Empty;
			domainItem.Sort.From = string.Empty;
			int rowStart = ((fromRec > 0) ? fromRec : 0);
			int rowCount = ((recCount >= 100) ? 100 : recCount);
			DataTable dataTableObject = new WebServiceGetItem(shygunSetting.IP, shygunSetting.conf, domainItem, rowStart, rowCount).GetDataTableObject(out JsonRender);
			if (dataTableObject != null && Enumerable.Count<DataRow>((IEnumerable<DataRow>)dataTableObject.Select()) > 0)
			{
				int num = 1;
				List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(true, false, true, false, lCID, result));
				foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
				{
					DataRow val = item;
					ShygunProductInfoViewModel vm = new ShygunProductInfoViewModel();
					vm.ItemCode = val["ItemCode"].ToString();
					vm.ItemDesc = val["ItemDesc"].ToString();
					vm.Itembarcode = val["Itembarcode"].ToString();
					if (val["ItemGroupNumber"] != null)
					{
						vm.ItemGroupNumber = val["ItemGroupNumber"].ToString();
					}
					if (val["ItemGroupName"] != null)
					{
						vm.ItemGroupName = val["ItemGroupName"].ToString();
					}
					if (val["ItemGroupGuId"] != null)
					{
						vm.ItemGroupGuId = val["ItemGroupGuId"].ToString();
					}
					vm.DefaultRowDiscount = decimal.Parse(string.IsNullOrWhiteSpace(val["DefaultRowDiscount"].ToString()) ? "0" : "0");
					vm.CInactive = bool.Parse(string.IsNullOrWhiteSpace(val["CInactive"].ToString()) ? "false" : "false");
					vm.ItemInfo = val["ItemInfo"].ToString();
					vm.Coef3 = decimal.Parse(string.IsNullOrWhiteSpace(val["Coef3"].ToString()) ? "0" : "0");
					vm.Location = val["Location"].ToString();
					vm.ItemTechdata = val["ItemTechdata"].ToString();
					vm.DefaultAnbarNumber = val["DefaultAnbarNumber"].ToString();
					vm.Weight = decimal.Parse(string.IsNullOrWhiteSpace(val["Weight"].ToString()) ? "0" : "0");
					vm.Content = decimal.Parse(string.IsNullOrWhiteSpace(val["Content"].ToString()) ? "0" : "0");
					vm.Unit1Name = val["Unit1Name"].ToString();
					vm.Unit2Name = val["Unit2Name"].ToString();
					vm.MinIn = decimal.Parse(string.IsNullOrWhiteSpace(val["MinIn"].ToString()) ? "0" : "0");
					vm.MaxIn = decimal.Parse(string.IsNullOrWhiteSpace(val["MaxIn"].ToString()) ? "0" : "0");
					vm.PCost = decimal.Parse(string.IsNullOrWhiteSpace(val["PCost"].ToString()) ? "0" : "0");
					vm.Commquan = bool.Parse(string.IsNullOrWhiteSpace(val["Commquan"].ToString()) ? "false" : "false");
					if (val["price1"] != null)
					{
						vm.price1 = decimal.Parse(string.IsNullOrWhiteSpace(val["price1"].ToString()) ? "0" : val["price1"].ToString());
					}
					else
					{
						vm.price1 = 0m;
					}
					if (val["price2"] != null)
					{
						vm.price2 = decimal.Parse(string.IsNullOrWhiteSpace(val["price2"].ToString()) ? "0" : val["price2"].ToString());
					}
					else
					{
						vm.price2 = 0m;
					}
					if (val["price3"] != null)
					{
						vm.price3 = decimal.Parse(string.IsNullOrWhiteSpace(val["price3"].ToString()) ? "0" : val["price3"].ToString());
					}
					else
					{
						vm.price3 = 0m;
					}
					if (val["price4"] != null)
					{
						vm.price4 = decimal.Parse(string.IsNullOrWhiteSpace(val["price4"].ToString()) ? "0" : val["price4"].ToString());
					}
					else
					{
						vm.price4 = 0m;
					}
					if (val["price5"] != null)
					{
						vm.price5 = decimal.Parse(string.IsNullOrWhiteSpace(val["price5"].ToString()) ? "0" : val["price5"].ToString());
					}
					else
					{
						vm.price5 = 0m;
					}
					vm.Itembarcode02 = val["Itembarcode02"].ToString();
					vm.GuId = val["GuId"].ToString();
					vm.RowNumber = num;
					WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => m.PrdLinkAccPrdIdStr == vm.GuId));
					if (wSspSelectProductWithAccLinkField_Result != null)
					{
						vm.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
					}
					if (!string.IsNullOrWhiteSpace(vm.ItemGroupGuId))
					{
						if (shygunSetting.PrdGroupSyncTypeId == 1)
						{
							IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result> enumerable = Enumerable.Where<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => (x.SGLinkAccGroupIdStr ?? "").ToString() == vm.ItemGroupGuId));
							if (enumerable != null && Enumerable.Count<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable) == 1)
							{
								vm.CrmGroupId = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable).PrdSecondGroupID;
								vm.CrmGroupName = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable).SGName ?? "";
							}
						}
						else if (shygunSetting.PrdGroupSyncTypeId != 2)
						{
						}
					}
					else if (!string.IsNullOrWhiteSpace(vm.ItemGroupNumber))
					{
						if (shygunSetting.PrdGroupSyncTypeId == 1)
						{
							IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result> enumerable2 = Enumerable.Where<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => (x.SGLinkAccGroupCode ?? "").ToString() == vm.ItemGroupNumber));
							if (enumerable2 != null && Enumerable.Count<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable2) == 1)
							{
								vm.CrmGroupId = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable2).PrdSecondGroupID;
								vm.CrmGroupName = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable2).SGName ?? "";
							}
						}
						else
						{
							_ = shygunSetting.PrdGroupSyncTypeId;
							_ = 2;
						}
					}
					switch (syncType)
					{
					case 0:
						list.Add(vm);
						num++;
						continue;
					case 1:
						if (vm.CrmGroupId > 0)
						{
							list.Add(vm);
							num++;
							continue;
						}
						break;
					}
					if (syncType == 2 && vm.CrmGroupId <= 0)
					{
						list.Add(vm);
						num++;
					}
				}
			}
			shygunProductInfoViewModelObjects.lst = list;
			shygunProductInfoViewModelObjects.FilteredLst = list;
			shygunProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return shygunProductInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunImportProduct_Read([DataSourceRequest] DataSourceRequest request, string fCode = "0", string tCode = "0", string prdGroupNumber = "", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		ShygunProductInfoViewModelObjects shygunProductList = GetShygunProductList(fCode, tCode, fromRec, recCount, syncType);
		List<ShygunProductInfoViewModel> list = new List<ShygunProductInfoViewModel>();
		if (shygunProductList != null && shygunProductList.lst != null && shygunProductList.lst.Count > 0)
		{
			list = shygunProductList.lst;
			if (!string.IsNullOrWhiteSpace(prdGroupNumber))
			{
				list = Enumerable.ToList<ShygunProductInfoViewModel>(Enumerable.Where<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)list, (Func<ShygunProductInfoViewModel, bool>)((ShygunProductInfoViewModel x) => x.ItemGroupNumber == prdGroupNumber)));
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunImportInfo(string records, string fCode = "0", string tCode = "0", int firstGroup = 0, int secondGroup = 0, int fromRec = 0, int recCount = 100, bool importWithPrice = false, int syncType = 0)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
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
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunProductInfoViewModel> list3 = new List<ShygunProductInfoViewModel>();
			List<ShygunProductInfoViewModel> lst = GetShygunProductList(fCode, tCode, fromRec, recCount, syncType).lst;
			if (lst != null)
			{
				foreach (OtherSystemSelectedVIiewModel item in list2)
				{
					ShygunProductInfoViewModel shygunProductInfoViewModel = Enumerable.FirstOrDefault<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)lst, (Func<ShygunProductInfoViewModel, bool>)((ShygunProductInfoViewModel x) => x.ItemCode == item.Id));
					if (shygunProductInfoViewModel != null)
					{
						list3.Add(shygunProductInfoViewModel);
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
			if (list3 != null && Enumerable.Any<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)list3))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				text = "";
				string text3 = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkShygunWSInsertUpdateProductsFromShygun(text3, shygunSetting.PrdGroupSyncTypeId, firstGroup, secondGroup, userId, year1: value2, month1: value3, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, errorMessage: objectParameter, importWithPrice: importWithPrice, centerId: centerId);
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
	public JsonResult GetShygunImportProductList(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunProductInfoViewModel item2 in GetShygunProductList(fCode, tCode, fromRec, recCount, syncType).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.ItemCode.ToString(),
					Selected = (item2.ProductId <= 0)
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

	[AjaxOnly]
	public JsonResult CreateShygunPrdGroups(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		foreach (ShygunProductInfoViewModel i in GetShygunProductList(fCode, tCode, fromRec, recCount, syncType).lst)
		{
			if (Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.ItemGroupGuId))) == null)
			{
				list.Add(new SelectListItem
				{
					Text = i.ItemGroupName,
					Value = i.ItemGroupGuId,
					Selected = false
				});
			}
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actExportToAcc")]
	public ActionResult ShygunExportProduct()
	{
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public string ShygunActSendToAcc(int prdId = 0, bool SendToAccWithPrdPrice = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<Item> list = new List<Item>();
			WSspSelectProductsWithId_Result rec = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
			if (prdId > 0 && rec != null)
			{
				string text3 = "";
				string text4 = "";
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list2 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
				string itemGroupNumber = "";
				Guid result2 = default(Guid);
				if (rec != null)
				{
					if (shygunSetting.PrdGroupSyncTypeId == 1)
					{
						WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
						if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null)
						{
							if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode))
							{
								text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
							}
							else
							{
								itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode ?? "";
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr))
								{
									Guid.TryParse(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr, out result2);
								}
							}
						}
						else
						{
							text = Messages.msgErrorNotSelectPrdLinkAccGroup;
						}
					}
					else if (shygunSetting.PrdGroupSyncTypeId == 2)
					{
						if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
						{
							itemGroupNumber = rec.PrdLinkAccPrdGroupIdStr ?? "";
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result2 != null)
							{
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups))
								{
									itemGroupNumber = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups), (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == rec.PrdLinkAccPrdGroupIdStr)).Code;
									if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
									{
										Guid.TryParse(rec.PrdLinkAccPrdGroupIdStr, out result2);
									}
								}
								else
								{
									text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
								}
							}
							else
							{
								text = Messages.msgErrorNotSelectPrdLinkAccGroup;
							}
						}
						else
						{
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result3 != null)
							{
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode))
								{
									itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode ?? "";
									if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupIdStr))
									{
										Guid.TryParse(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupIdStr, out result2);
									}
								}
								else
								{
									text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
								}
							}
							else
							{
								text = Messages.msgErrorNotSelectPrdLinkAccGroup;
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						return text;
					}
					decimal result3 = default(decimal);
					decimal result4 = default(decimal);
					decimal result5 = default(decimal);
					decimal result6 = default(decimal);
					decimal result7 = default(decimal);
					if (SendToAccWithPrdPrice)
					{
						List<CRMspSelectLinkAccShygunSettingDetails_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccShygunSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunSettingDetails(0, 0, "ProductPrice", lCID, result), (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => !string.IsNullOrWhiteSpace(x.PartValue))));
						if (list3 != null && list3.Count > 0)
						{
							if (result3 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "1"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result.Price.ToString(), out result3);
									}
								}
							}
							if (result4 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "2"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result2 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result2 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result2.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result2 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result2.Price.ToString(), out result4);
									}
								}
							}
							if (result5 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "3"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result3 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result3 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result3.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result3 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result3.Price.ToString(), out result5);
									}
								}
							}
							if (result6 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "4"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result4 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result4 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result4.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result4 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result4.Price.ToString(), out result6);
									}
								}
							}
							if (result7 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "5"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result5 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result5 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result5.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result5 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result5.Price.ToString(), out result7);
									}
								}
							}
						}
					}
					Item item = new Item();
					item.ItemCode = string.Empty;
					item.ItemDesc = rec.PrdName;
					item.ItemGroupGuId = result2;
					item.ItemGroupNumber = itemGroupNumber;
					item.Unit1Name = rec.PrdUnit ?? "";
					item.Unit2Name = string.Empty;
					item.Location = rec.PrdLocation ?? "";
					item.price1 = result3;
					item.price2 = result4;
					item.price3 = result5;
					item.price4 = result6;
					item.price5 = result7;
					item.Itembarcode = rec.PrdBarCode ?? "";
					if (string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdIdStr))
					{
						item.UpdateKind = ActionType.insert;
					}
					else
					{
						item.UpdateKind = ActionType.update;
						item.GuId = Guid.Parse(rec.PrdLinkAccPrdIdStr);
					}
					list.Add(item);
					if (!string.IsNullOrWhiteSpace(text3))
					{
						text3 += ",";
					}
					text3 += rec.ProductID;
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 += ",";
					}
					text4 += rec.PrdCode.ToString();
				}
				if (list != null && list.Count > 0)
				{
					PutResults putResults = new WebServiePutItem(shygunSetting.IP, shygunSetting.conf, list).PutOperation();
					if (string.IsNullOrWhiteSpace(putResults.Result[0].ErrorMessage))
					{
						_dbLink.CRMspUpdateProductWithAccLinkField(prdId, null, putResults.Result[0].Number.ToString(), putResults.Result[0].GuId.ToString(), userId, value2, id, value, registerDatePersian, appType);
					}
					string errorMessage = putResults.ErrorMessage;
					text2 = (string.IsNullOrEmpty(errorMessage) ? ("1|" + putResults.Result[0].Number.ToString()) : (text2 + "|" + errorMessage));
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "|" + ex.Message;
		}
		return text2;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunExportInfo(string records, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<Item> list = new List<Item>();
			List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					string text = "";
					string text2 = "";
					List<OtherSystemSelectedViewModel> list3 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
					CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
					List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list4 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
					foreach (OtherSystemSelectedViewModel item2 in list3)
					{
						WSspSelectProductsWithId_Result rec = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(item2.Id, lCID, result));
						string itemGroupNumber = "";
						Guid result2 = default(Guid);
						if (rec == null)
						{
							continue;
						}
						if (shygunSetting.PrdGroupSyncTypeId == 1)
						{
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result == null)
							{
								data = 0;
								message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
								status = CommonResultStatusViewModel.Error;
								continue;
							}
							if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode))
							{
								data = 0;
								message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
								status = CommonResultStatusViewModel.Error;
								continue;
							}
							itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode ?? "";
							if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr))
							{
								Guid.TryParse(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupIdStr, out result2);
							}
						}
						else if (shygunSetting.PrdGroupSyncTypeId == 2)
						{
							if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
							{
								itemGroupNumber = rec.PrdLinkAccPrdGroupIdStr ?? "";
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result2 == null)
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups))
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								itemGroupNumber = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups), (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == rec.PrdLinkAccPrdGroupIdStr)).Code;
								if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
								{
									Guid.TryParse(rec.PrdLinkAccPrdGroupIdStr, out result2);
								}
							}
							else
							{
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result3 == null)
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode))
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode ?? "";
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupIdStr))
								{
									Guid.TryParse(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupIdStr, out result2);
								}
							}
						}
						decimal result3 = default(decimal);
						decimal result4 = default(decimal);
						decimal result5 = default(decimal);
						decimal result6 = default(decimal);
						decimal result7 = default(decimal);
						List<CRMspSelectLinkAccShygunSettingDetails_Result> list5 = Enumerable.ToList<CRMspSelectLinkAccShygunSettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunSettingDetails(0, 0, "ProductPrice", lCID, result), (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => !string.IsNullOrWhiteSpace(x.PartValue))));
						if (list5 != null && list5.Count > 0)
						{
							if (result3 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "1"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result.Price.ToString(), out result3);
									}
								}
							}
							if (result4 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "2"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result2 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result2 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result2.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result2 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result2.Price.ToString(), out result4);
									}
								}
							}
							if (result5 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "3"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result3 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result3 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result3.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result3 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result3.Price.ToString(), out result5);
									}
								}
							}
							if (result6 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "4"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result4 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result4 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result4.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result4 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result4.Price.ToString(), out result6);
									}
								}
							}
							if (result7 <= 0m)
							{
								CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.PartValue == "5"));
								if (cRMspSelectLinkAccShygunSettingDetails_Result5 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result5 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunSettingDetails_Result5.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result5 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result5.Price.ToString(), out result7);
									}
								}
							}
						}
						Item item = new Item();
						item.ItemCode = string.Empty;
						item.ItemDesc = rec.PrdName;
						item.ItemGroupGuId = result2;
						item.ItemGroupNumber = itemGroupNumber;
						item.Unit1Name = rec.PrdUnit ?? "";
						item.Unit2Name = string.Empty;
						item.Location = rec.PrdLocation ?? "";
						item.price1 = result3;
						item.price2 = result4;
						item.price3 = result5;
						item.price4 = result6;
						item.price5 = result7;
						item.Itembarcode = rec.PrdBarCode ?? "";
						if (string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdIdStr))
						{
							item.UpdateKind = ActionType.insert;
						}
						else
						{
							item.UpdateKind = ActionType.update;
							item.GuId = Guid.Parse(rec.PrdLinkAccPrdIdStr);
						}
						list.Add(item);
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ",";
						}
						text += rec.ProductID;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ",";
						}
						text2 += rec.PrdCode.ToString();
					}
					if (list != null && list.Count > 0)
					{
						PutResults putResults = new WebServiePutItem(shygunSetting.IP, shygunSetting.conf, list).PutOperation();
						string text3 = putResults.ErrorMessage;
						string[] array = text.Split(new char[1] { ',' });
						string[] array2 = text2.Split(new char[1] { ',' });
						for (int i = 0; i < list.Count; i++)
						{
							int result8 = 0;
							int.TryParse(array[i], out result8);
							_ = array2[i];
							if (string.IsNullOrWhiteSpace(putResults.Result[i].ErrorMessage))
							{
								_dbLink.CRMspUpdateProductWithAccLinkField(result8, null, (putResults.Result[i].Number ?? "").ToString(), putResults.Result[i].GuId.ToString(), userId, value3, id, value2, registerDatePersian, appType);
							}
							else
							{
								text3 = text3 + putResults.Result[i].ErrorMessage + "|";
							}
						}
						if (!string.IsNullOrEmpty(text3))
						{
							data = 0;
							message = text3.ToString();
							status = CommonResultStatusViewModel.Error;
						}
						else
						{
							data = 1;
							message = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
					}
				}
			}
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
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunExportProductList(string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkWSSelectProduct_Result item in SelectProducts(fDate, tDate, value, fgId, sgId))
			{
				OtherSystemSelectedViewModel otherSystemSelectedViewModel = new OtherSystemSelectedViewModel();
				otherSystemSelectedViewModel.Row = item.RowNumber.GetValueOrDefault();
				otherSystemSelectedViewModel.Id = item.ProductID;
				if (string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr))
				{
					otherSystemSelectedViewModel.Selected = true;
				}
				else
				{
					otherSystemSelectedViewModel.Selected = false;
				}
				list.Add(otherSystemSelectedViewModel);
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
			new List<LinkedProductWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShygunDeleteLinkedProduct_Result> list3 = Enumerable.ToList<CRMspLkShygunDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunDeleteLinkedProduct_Result>)_dbLink.CRMspLkShygunDeleteLinkedProduct(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunDeleteLinkedProduct_Result>)list3))
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

	public string GetFileShygunNotDeletedImportedInfo(List<CRMspLkShygunDeleteLinkedProduct_Result> res)
	{
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunDeleteLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunDeleteLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actLinkPrdWithAcc")]
	public ActionResult ShygunLinkedProduct()
	{
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SyncField = shygunSetting.PrdLinkedField;
		return View();
	}

	[HttpPost]
	public JsonResult ActShygunLinkedProduct(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LinkedProductWithAccViewModel> list = new List<LinkedProductWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actLinkPrdWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			bool flag = true;
			fromRec = 0;
			recCount = 100;
			while (flag)
			{
				ShygunProductInfoViewModelObjects shygunProductList = GetShygunProductList("0", "0", fromRec, recCount);
				if (shygunProductList == null)
				{
					flag = false;
					continue;
				}
				if (shygunProductList.lst == null || !Enumerable.Any<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)shygunProductList.lst))
				{
					flag = false;
					continue;
				}
				foreach (ShygunProductInfoViewModel item2 in shygunProductList.lst)
				{
					LinkedProductWithAccViewModel item = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item2.ItemCode,
						PrdLinkAccPrdIdStr = item2.GuId,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = item2.ItemDesc
					};
					list.Add(item);
				}
				fromRec += ((fromRec > 0) ? 100 : 101);
			}
			if (list == null || !Enumerable.Any<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListPrdInLinkAccIsEmpty, Labels.Shygun) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list));
				string text4 = "";
				text = "";
				List<CRMspLkShygunWSLinkedProduct_Result> list2 = Enumerable.ToList<CRMspLkShygunWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunWSLinkedProduct_Result>)_dbLink.CRMspLkShygunWSLinkedProduct(itemJson, syncField, mode, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspLkShygunWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunWSLinkedProduct_Result>)list2))
				{
					text = "error";
					text4 = GetFileShygunLinkedProduct(list2);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
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

	public string GetFileShygunLinkedProduct(List<CRMspLkShygunWSLinkedProduct_Result> res)
	{
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkShygunWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunWSLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunWSLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
					num++;
					string value = "";
					_ = re.Type;
					if (re.Type == 1)
					{
						value = Labels.Shygun;
					}
					else if (re.Type == 2)
					{
						value = "CRM";
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorPrdNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupPrdLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupPrdCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorPrdNotInLinkAcc, Labels.Shygun);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text3;
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actManagePrdLinkAcc")]
	public ActionResult ShygunManagePrdLinkAcc()
	{
		GetShygunProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
		base.ViewBag.SGSyncTypeId = shygunSetting.PrdGroupSyncTypeId;
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetShygunProductGroup()
	{
		//IL_0181: Unknown result type (might be due to invalid IL or missing references)
		//IL_0188: Expected O, but got Unknown
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
			flag = true;
			while (flag)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunSetting.IP, shygunSetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 0"));
					if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
					{
						foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
						{
							DataRow val2 = item;
							LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
							vm.SGName = val2["GroupName"].ToString();
							vm.SGName = val2["ParentGroupName"].ToString() + " - " + val2["GroupName"].ToString();
							vm.SGLinkAccGroupIdStr = val2["GroupGuId"].ToString();
							vm.SGLinkAccGroupCode = val2["GroupNumber"].ToString();
							if (list3 != null)
							{
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
								{
									vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
								}
							}
							list.Add(vm);
							list2.Add(new SelectListItem
							{
								Value = vm.SGLinkAccGroupIdStr,
								Text = vm.SGName,
								Selected = false
							});
						}
					}
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lkProductSecondGroupListViewModel.lst = list;
			lkProductSecondGroupListViewModel.lstSelectListItem = list2;
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccProductSecondGroupList = lkProductSecondGroupListViewModel;
		base.ViewBag.LinkAccProductSecondGroupListlst = lkProductSecondGroupListViewModel.lst;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public string ShygunGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
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
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Shygun)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string value = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									value = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(value) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								value = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(value))
							{
								CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
								if (shygunSetting != null)
								{
									DomainItemRemain domainItemRemain = new DomainItemRemain();
									domainItemRemain.ItemGuID.In = new string[1];
									domainItemRemain.ItemGuID.In[0] = wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr;
									domainItemRemain.StockGuID.In = new string[1];
									domainItemRemain.StockGuID.In[0] = value;
									string text = shygunSetting.IP;
									if (string.IsNullOrWhiteSpace(text))
									{
										Exception e3 = new Exception(Messages.errorInReadingSetting);
										ErrorSignal.FromCurrentContext().Raise(e3);
									}
									if (!text.EndsWith("/"))
									{
										text += "/";
									}
									HttpClient obj = new HttpClient
									{
										BaseAddress = new Uri(text),
										DefaultRequestHeaders = 
										{
											Accept = 
											{
												new MediaTypeWithQualityHeaderValue("application/json")
											}
										}
									};
									string requestUri = "api/Item/GetRemain";
									HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunApiParamViewModel<DomainItemRemain>
									{
										Config = shygunSetting.conf,
										Domain = domainItemRemain,
										StartVersion = "0"
									}), Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
									httpResponseMessage = obj.PostAsync(requestUri, content).Result;
									if (httpResponseMessage.IsSuccessStatusCode)
									{
										string value2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(value2))
										{
											CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetItemGetRemainResultViewModel shygunApiGetItemGetRemainResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunApiGetItemGetRemainResultViewModel>(value2);
											if (shygunApiGetItemGetRemainResultViewModel != null && shygunApiGetItemGetRemainResultViewModel.Result != null && Enumerable.Any<CRMIdeal.Classes.Helper.OtherSystems.ShygunItemGetRemainViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunItemGetRemainViewModel>)shygunApiGetItemGetRemainResultViewModel.Result))
											{
												CRMIdeal.Classes.Helper.OtherSystems.ShygunItemGetRemainViewModel shygunItemGetRemainViewModel = Enumerable.FirstOrDefault<CRMIdeal.Classes.Helper.OtherSystems.ShygunItemGetRemainViewModel>((IEnumerable<CRMIdeal.Classes.Helper.OtherSystems.ShygunItemGetRemainViewModel>)shygunApiGetItemGetRemainResultViewModel.Result);
												if (shygunItemGetRemainViewModel != null)
												{
													result = shygunItemGetRemainViewModel.Quantity1.GetValueOrDefault().ToString();
												}
											}
										}
									}
								}
							}
							else
							{
								Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e4);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e5 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e5);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e6);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e7 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e7);
				result = Labels.frmError;
			}
		}
		catch (Exception e8)
		{
			ErrorSignal.FromCurrentContext().Raise(e8);
			result = Labels.frmError;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetProductSecondGroup()
	{
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<CRMspLkWSSelectProductSecondGroup_Result> list = Enumerable.ToList<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)_dbLink.CRMspLkWSSelectProductSecondGroup(0, lCID, result));
			if (list != null && Enumerable.Any<CRMspLkWSSelectProductSecondGroup_Result>((IEnumerable<CRMspLkWSSelectProductSecondGroup_Result>)list))
			{
				List<LkProductSecondGroupInfoViewModel> list2 = new List<LkProductSecondGroupInfoViewModel>();
				List<SelectListItem> list3 = new List<SelectListItem>();
				foreach (CRMspLkWSSelectProductSecondGroup_Result item in list)
				{
					list2.Add(new LkProductSecondGroupInfoViewModel
					{
						PrdSecondGroupID = item.PrdSecondGroupID,
						FirstGroupId = item.FirstGroupId,
						SGCode = item.SGCode,
						SGName = item.FulName,
						SGLinkAccGroupId = item.SGLinkAccGroupId,
						SGLinkAccGroupCode = item.SGLinkAccGroupCode,
						SGLinkAccGroupIdStr = item.SGLinkAccGroupIdStr,
						SGLinkAccGroupName = item.SGLinkAccGroupName
					});
					list3.Add(new SelectListItem
					{
						Value = item.PrdSecondGroupID.ToString(),
						Text = item.FulName,
						Selected = false
					});
				}
				lkProductSecondGroupListViewModel.lst = list2;
				lkProductSecondGroupListViewModel.lstSelectListItem = list3;
			}
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.ProductSecondGroupList = lkProductSecondGroupListViewModel;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public ShygunProductInfoViewModelObjects GetShygunIIProductList(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		//IL_01cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_01d6: Expected O, but got Unknown
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunProductInfoViewModelObjects shygunProductInfoViewModelObjects = new ShygunProductInfoViewModelObjects();
		List<ShygunProductInfoViewModel> list = new List<ShygunProductInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainItem domainItem = new DomainItem();
			int result2 = 0;
			int.TryParse(fCode, out result2);
			if (result2 <= 0)
			{
				fCode = "";
			}
			int result3 = 0;
			int.TryParse(tCode, out result3);
			if (result3 <= 0)
			{
				tCode = "";
			}
			domainItem.ItemCode.From = fCode;
			domainItem.ItemCode.To = tCode;
			domainItem.ItemGuId.From = string.Empty;
			domainItem.ItemGuId.To = string.Empty;
			domainItem.Sort.From = string.Empty;
			int rowStart = ((fromRec > 0) ? fromRec : 0);
			int rowCount = ((recCount >= 100) ? 100 : recCount);
			DataTable dataTableObject = new WebServiceGetItem(shygunIISetting.IP, shygunIISetting.conf, domainItem, rowStart, rowCount).GetDataTableObject(out JsonRender);
			if (dataTableObject != null && Enumerable.Count<DataRow>((IEnumerable<DataRow>)dataTableObject.Select()) > 0)
			{
				dataTableObject = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(ItemGroupNumber, '') <> ''"));
				int num = 1;
				List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(true, false, true, false, lCID, result));
				foreach (DataRow item in (InternalDataCollectionBase)dataTableObject.Rows)
				{
					DataRow val = item;
					ShygunProductInfoViewModel vm = new ShygunProductInfoViewModel();
					vm.ItemCode = val["ItemCode"].ToString();
					vm.ItemDesc = val["ItemDesc"].ToString();
					vm.Itembarcode = val["Itembarcode"].ToString();
					vm.ItemGroupNumber = val["ItemGroupNumber"].ToString();
					vm.ItemGroupName = val["ItemGroupName"].ToString();
					vm.ItemGroupGuId = val["ItemGroupGuId"].ToString();
					vm.DefaultRowDiscount = decimal.Parse(string.IsNullOrWhiteSpace(val["DefaultRowDiscount"].ToString()) ? "0" : "0");
					vm.CInactive = bool.Parse(string.IsNullOrWhiteSpace(val["CInactive"].ToString()) ? "false" : "false");
					vm.ItemInfo = val["ItemInfo"].ToString();
					vm.Coef3 = decimal.Parse(string.IsNullOrWhiteSpace(val["Coef3"].ToString()) ? "0" : "0");
					vm.ItemTechdata = val["ItemTechdata"].ToString();
					vm.DefaultAnbarNumber = val["DefaultAnbarNumber"].ToString();
					vm.Weight = decimal.Parse(string.IsNullOrWhiteSpace(val["Weight"].ToString()) ? "0" : "0");
					vm.Content = decimal.Parse(string.IsNullOrWhiteSpace(val["Content"].ToString()) ? "0" : "0");
					vm.Unit1Name = val["Unit1Name"].ToString();
					vm.Unit2Name = val["Unit2Name"].ToString();
					vm.MinIn = decimal.Parse(string.IsNullOrWhiteSpace(val["MinIn"].ToString()) ? "0" : "0");
					vm.MaxIn = decimal.Parse(string.IsNullOrWhiteSpace(val["MaxIn"].ToString()) ? "0" : "0");
					vm.PCost = decimal.Parse(string.IsNullOrWhiteSpace(val["PCost"].ToString()) ? "0" : "0");
					vm.Commquan = bool.Parse(string.IsNullOrWhiteSpace(val["Commquan"].ToString()) ? "false" : "false");
					if (val["price1"] != null)
					{
						vm.price1 = decimal.Parse(string.IsNullOrWhiteSpace(val["price1"].ToString()) ? "0" : val["price1"].ToString());
					}
					else
					{
						vm.price1 = 0m;
					}
					if (val["price2"] != null)
					{
						vm.price2 = decimal.Parse(string.IsNullOrWhiteSpace(val["price2"].ToString()) ? "0" : val["price2"].ToString());
					}
					else
					{
						vm.price2 = 0m;
					}
					if (val["price3"] != null)
					{
						vm.price3 = decimal.Parse(string.IsNullOrWhiteSpace(val["price3"].ToString()) ? "0" : val["price3"].ToString());
					}
					else
					{
						vm.price3 = 0m;
					}
					if (val["price4"] != null)
					{
						vm.price4 = decimal.Parse(string.IsNullOrWhiteSpace(val["price4"].ToString()) ? "0" : val["price4"].ToString());
					}
					else
					{
						vm.price4 = 0m;
					}
					if (val["price5"] != null)
					{
						vm.price5 = decimal.Parse(string.IsNullOrWhiteSpace(val["price5"].ToString()) ? "0" : val["price5"].ToString());
					}
					else
					{
						vm.price5 = 0m;
					}
					vm.Itembarcode02 = val["Itembarcode02"].ToString();
					vm.GuId = val["GuId"].ToString();
					vm.RowNumber = num;
					WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result m) => (m.PrdLinkAccPrdIdStr ?? "").ToLower() == vm.GuId.ToLower()));
					if (wSspSelectProductWithAccLinkField_Result != null)
					{
						vm.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
					}
					if (!string.IsNullOrWhiteSpace(vm.ItemGroupNumber))
					{
						if (shygunIISetting.PrdGroupSyncTypeId == 1)
						{
							IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result> enumerable = Enumerable.Where<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => (x.SGLinkAccGroupCode ?? "").ToString() == vm.ItemGroupNumber));
							if (enumerable != null && Enumerable.Count<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable) == 1)
							{
								vm.CrmGroupId = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable).PrdSecondGroupID;
								vm.CrmGroupName = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>(enumerable).SGName ?? "";
							}
						}
						else
						{
							_ = shygunIISetting.PrdGroupSyncTypeId;
							_ = 2;
						}
					}
					switch (syncType)
					{
					case 0:
						list.Add(vm);
						num++;
						continue;
					case 1:
						if (vm.CrmGroupId > 0)
						{
							list.Add(vm);
							num++;
							continue;
						}
						break;
					}
					if (syncType == 2 && vm.CrmGroupId <= 0)
					{
						list.Add(vm);
						num++;
					}
				}
			}
			shygunProductInfoViewModelObjects.lst = list;
			shygunProductInfoViewModelObjects.FilteredLst = list;
			shygunProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			shygunProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return shygunProductInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunIIImportProduct_Read([DataSourceRequest] DataSourceRequest request, string fCode = "0", string tCode = "0", string prdGroupNumber = "", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		ShygunProductInfoViewModelObjects shygunIIProductList = GetShygunIIProductList(fCode, tCode, fromRec, recCount, syncType);
		List<ShygunProductInfoViewModel> list = new List<ShygunProductInfoViewModel>();
		if (shygunIIProductList != null && shygunIIProductList.lst != null && shygunIIProductList.lst.Count > 0)
		{
			list = shygunIIProductList.lst;
			if (!string.IsNullOrWhiteSpace(prdGroupNumber))
			{
				list = Enumerable.ToList<ShygunProductInfoViewModel>(Enumerable.Where<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)list, (Func<ShygunProductInfoViewModel, bool>)((ShygunProductInfoViewModel x) => x.ItemGroupNumber == prdGroupNumber)));
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIImportInfo(string records, string fCode = "0", string tCode = "0", int firstGroup = 0, int secondGroup = 0, int fromRec = 0, int recCount = 100, bool importWithPrice = false, int syncType = 0)
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
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
			List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedVIiewModel>(Enumerable.Where<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list, (Func<OtherSystemSelectedVIiewModel, bool>)((OtherSystemSelectedVIiewModel m) => m.Selected)));
				}
			}
			List<ShygunProductInfoViewModel> list3 = new List<ShygunProductInfoViewModel>();
			List<ShygunProductInfoViewModel> lst = GetShygunIIProductList(fCode, tCode, fromRec, recCount, syncType).lst;
			if (lst != null)
			{
				foreach (OtherSystemSelectedVIiewModel item in list2)
				{
					ShygunProductInfoViewModel shygunProductInfoViewModel = Enumerable.FirstOrDefault<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)lst, (Func<ShygunProductInfoViewModel, bool>)((ShygunProductInfoViewModel x) => x.GuId == item.Id));
					if (shygunProductInfoViewModel != null)
					{
						list3.Add(shygunProductInfoViewModel);
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
			if (list3 != null && Enumerable.Any<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)list3))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				text = "";
				string text3 = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				_dbLink.CRMspLkShygunIIWSInsertUpdateProductsFromShygunII(text3, shygunIISetting.PrdGroupSyncTypeId, firstGroup, secondGroup, userId, year1: value2, month1: value3, fPId: id, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, languageID: result, errorMessage: objectParameter, importWithPrice: importWithPrice, centerId: centerId);
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
	public JsonResult GetShygunIIImportProductList(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunProductInfoViewModel item2 in GetShygunIIProductList(fCode, tCode, fromRec, recCount, syncType).lst)
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = item2.GuId.ToString(),
					Selected = (item2.ProductId <= 0)
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

	[AjaxOnly]
	public JsonResult CreateShygunIIPrdGroups(string fCode = "0", string tCode = "0", int fromRec = 0, int recCount = 100, int syncType = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		foreach (ShygunProductInfoViewModel i in GetShygunIIProductList(fCode, tCode, fromRec, recCount, syncType).lst)
		{
			if (Enumerable.FirstOrDefault<SelectListItem>(Enumerable.Where<SelectListItem>((IEnumerable<SelectListItem>)list, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == i.ItemGroupNumber))) == null)
			{
				list.Add(new SelectListItem
				{
					Text = i.ItemGroupName,
					Value = i.ItemGroupNumber,
					Selected = false
				});
			}
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public string ShygunIIActSendToAcc(int prdId = 0, bool SendToAccWithPrdPrice = false, bool isSendPrdGroupToAcc = false)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<Item> list = new List<Item>();
			string text3 = "";
			WSspSelectProductsWithId_Result rec = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
			if (prdId > 0 && rec != null)
			{
				string text4 = "";
				string text5 = "";
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list2 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
				string itemGroupNumber = "";
				if (rec != null)
				{
					if (isSendPrdGroupToAcc)
					{
						string text6 = ShygunIISendPrdGroupToAcc(rec.ProductID);
						if (!string.IsNullOrWhiteSpace(text6))
						{
							return text2 + "|" + text6;
						}
						list2 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
					}
					if (shygunIISetting.PrdGroupSyncTypeId == 1)
					{
						WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
						if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null)
						{
							if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode))
							{
								text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
							}
							else
							{
								itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode ?? "";
							}
						}
						else
						{
							text = Messages.msgErrorNotSelectPrdLinkAccGroup;
						}
					}
					else if (shygunIISetting.PrdGroupSyncTypeId == 2)
					{
						if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
						{
							itemGroupNumber = rec.PrdLinkAccPrdGroupIdStr ?? "";
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result2 != null)
							{
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups))
								{
									itemGroupNumber = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups), (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == rec.PrdLinkAccPrdGroupIdStr)).Code;
								}
								else
								{
									text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
								}
							}
							else
							{
								text = Messages.msgErrorNotSelectPrdLinkAccGroup;
							}
						}
						else
						{
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list2, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result3 != null)
							{
								if (!string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode))
								{
									itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode ?? "";
								}
								else
								{
									text = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc;
								}
							}
							else
							{
								text = Messages.msgErrorNotSelectPrdLinkAccGroup;
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						return text;
					}
					decimal result2 = default(decimal);
					decimal result3 = default(decimal);
					decimal result4 = default(decimal);
					decimal result5 = default(decimal);
					decimal result6 = default(decimal);
					if (SendToAccWithPrdPrice)
					{
						List<CRMspSelectLinkAccShygunIISettingDetails_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, 0, "ProductPrice", lCID, result), (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => !string.IsNullOrWhiteSpace(x.PartValue))));
						if (list3 != null && list3.Count > 0)
						{
							if (result2 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "1"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result.Price.ToString(), out result2);
									}
								}
							}
							if (result3 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "2"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result2 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result2 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result2.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result2 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result2.Price.ToString(), out result3);
									}
								}
							}
							if (result4 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "3"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result3 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result3 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result3.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result3 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result3.Price.ToString(), out result4);
									}
								}
							}
							if (result5 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "4"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result4 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result4 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result4.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result4 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result4.Price.ToString(), out result5);
									}
								}
							}
							if (result6 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list3, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "5"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result5 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result5 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result5.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result5 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result5.Price.ToString(), out result6);
									}
								}
							}
						}
					}
					Item item = new Item();
					item.ItemCode = rec.PrdCode;
					item.ItemDesc = rec.PrdName;
					item.ItemGroupNumber = itemGroupNumber;
					item.Unit1Name = rec.PrdUnit ?? "";
					item.Unit2Name = string.Empty;
					item.price1 = result2;
					item.price2 = result3;
					item.price3 = result4;
					item.price4 = result5;
					item.price5 = result6;
					item.Itembarcode = rec.PrdBarCode ?? "";
					if (string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdIdStr))
					{
						item.UpdateKind = ActionType.insert;
					}
					else
					{
						item.UpdateKind = ActionType.update;
						item.GuId = Guid.Parse(rec.PrdLinkAccPrdIdStr);
					}
					list.Add(item);
					if (!string.IsNullOrWhiteSpace(text4))
					{
						text4 += ",";
					}
					text4 += rec.ProductID;
					if (!string.IsNullOrWhiteSpace(text5))
					{
						text5 += ",";
					}
					text5 += rec.PrdCode.ToString();
				}
				if (list != null && list.Count > 0)
				{
					PutResults putResults = new WebServiePutItem(shygunIISetting.IP, shygunIISetting.conf, list).PutOperation();
					string text7 = "";
					if (string.IsNullOrWhiteSpace(putResults.Result[0].ErrorMessage))
					{
						text7 = putResults.Result[0].Number.ToString();
						_dbLink.CRMspUpdateProductWithAccLinkField(prdId, null, text7, putResults.Result[0].GuId.ToString(), userId, value2, id, value, registerDatePersian, appType);
					}
					text3 += putResults.ErrorMessage;
					text2 = (string.IsNullOrEmpty(text3) ? ("1|" + text7) : (text2 + "|" + text3));
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text2 = "|" + ex.Message;
		}
		return text2;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIExportInfo(string records, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0, bool isSendPrdGroupToAcc = false)
	{
		//IL_00da: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data2;
		try
		{
			DateTime now = DateTime.Now;
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = ((UserLogin.CurrentUser != null) ? UserLogin.CurrentUser.UserLastCId : null);
			List<Item> list = new List<Item>();
			List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
				{
					string text = "";
					string text2 = "";
					List<OtherSystemSelectedViewModel> list3 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected && x.Id > 0)));
					CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
					List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list4 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
					string text3 = "";
					foreach (OtherSystemSelectedViewModel item2 in list3)
					{
						WSspSelectProductsWithId_Result rec = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(item2.Id, lCID, result));
						string itemGroupNumber = "";
						if (rec == null)
						{
							continue;
						}
						if (isSendPrdGroupToAcc)
						{
							string text4 = ShygunIISendPrdGroupToAcc(rec.ProductID);
							if (!string.IsNullOrWhiteSpace(text4))
							{
								text3 = text3 + text4 + "|";
							}
							list4 = SelectProductsSecondGroupWithAccLinkField(withLinkAccGroupId: false, withLinkAccGroupCode: false, withLinkAccGroupIdStr: true, withLinkAccGroups: true);
						}
						if (shygunIISetting.PrdGroupSyncTypeId == 1)
						{
							WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
							if (wSspSelectProductsSecondGroupWithAccLinkField_Result == null)
							{
								data = 0;
								message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
								status = CommonResultStatusViewModel.Error;
								continue;
							}
							if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode))
							{
								data = 0;
								message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
								status = CommonResultStatusViewModel.Error;
								continue;
							}
							itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result.SGLinkAccGroupCode ?? "";
						}
						else if (shygunIISetting.PrdGroupSyncTypeId == 2)
						{
							if (!string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdGroupIdStr))
							{
								itemGroupNumber = rec.PrdLinkAccPrdGroupIdStr ?? "";
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result2 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result2 == null)
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups))
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								itemGroupNumber = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectProductsSecondGroupWithAccLinkField_Result2.SGLinkAccGroups), (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel x) => x.Id == rec.PrdLinkAccPrdGroupIdStr)).Code;
							}
							else
							{
								WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result3 = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list4, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.PrdSecondGroupID == rec.PrdGroupID));
								if (wSspSelectProductsSecondGroupWithAccLinkField_Result3 == null)
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdLinkAccGroup + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								if (string.IsNullOrWhiteSpace(wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode))
								{
									data = 0;
									message = Messages.msgErrorNotSelectPrdGroupNotLinkedWithAcc + "[ " + rec.PrdName + " | " + rec.PrdCode + " ]";
									status = CommonResultStatusViewModel.Error;
									continue;
								}
								itemGroupNumber = wSspSelectProductsSecondGroupWithAccLinkField_Result3.SGLinkAccGroupCode ?? "";
							}
						}
						decimal result2 = default(decimal);
						decimal result3 = default(decimal);
						decimal result4 = default(decimal);
						decimal result5 = default(decimal);
						decimal result6 = default(decimal);
						List<CRMspSelectLinkAccShygunIISettingDetails_Result> list5 = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>(Enumerable.Where<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, 0, "ProductPrice", lCID, result), (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => !string.IsNullOrWhiteSpace(x.PartValue))));
						if (list5 != null && list5.Count > 0)
						{
							if (result2 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "1"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result.Price.ToString(), out result2);
									}
								}
							}
							if (result3 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "2"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result2 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result2 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result2.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result2 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result2.Price.ToString(), out result3);
									}
								}
							}
							if (result4 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "3"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result3 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result3 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result3.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result3 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result3.Price.ToString(), out result4);
									}
								}
							}
							if (result5 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "4"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result4 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result4 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result4.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result4 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result4.Price.ToString(), out result5);
									}
								}
							}
							if (result6 <= 0m)
							{
								CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list5, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result x) => x.PartValue == "5"));
								if (cRMspSelectLinkAccShygunIISettingDetails_Result5 != null)
								{
									WSspSelectProductPriceByPrdAndGroup_Result wSspSelectProductPriceByPrdAndGroup_Result5 = Enumerable.FirstOrDefault<WSspSelectProductPriceByPrdAndGroup_Result>((IEnumerable<WSspSelectProductPriceByPrdAndGroup_Result>)_db.WSspSelectProductPriceByPrdAndGroup(rec.ProductID, cRMspSelectLinkAccShygunIISettingDetails_Result5.ObjectId, lCID, result, centerId));
									if (wSspSelectProductPriceByPrdAndGroup_Result5 != null)
									{
										decimal.TryParse(wSspSelectProductPriceByPrdAndGroup_Result5.Price.ToString(), out result6);
									}
								}
							}
						}
						Item item = new Item();
						item.ItemCode = rec.PrdCode;
						item.ItemDesc = rec.PrdName;
						item.ItemGroupNumber = itemGroupNumber;
						item.Unit1Name = rec.PrdUnit ?? "";
						item.Unit2Name = string.Empty;
						item.price1 = result2;
						item.price2 = result3;
						item.price3 = result4;
						item.price4 = result5;
						item.price5 = result6;
						item.Itembarcode = rec.PrdBarCode ?? "";
						if (string.IsNullOrWhiteSpace(rec.PrdLinkAccPrdIdStr))
						{
							item.UpdateKind = ActionType.insert;
						}
						else
						{
							item.UpdateKind = ActionType.update;
							item.GuId = Guid.Parse(rec.PrdLinkAccPrdIdStr);
						}
						list.Add(item);
						if (!string.IsNullOrWhiteSpace(text))
						{
							text += ",";
						}
						text += rec.ProductID;
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text2 += ",";
						}
						text2 += rec.PrdCode.ToString();
					}
					if (list != null && list.Count > 0)
					{
						PutResults putResults = new WebServiePutItem(shygunIISetting.IP, shygunIISetting.conf, list).PutOperation();
						text3 += putResults.ErrorMessage;
						string[] array = text.Split(new char[1] { ',' });
						string[] array2 = text2.Split(new char[1] { ',' });
						for (int i = 0; i < list.Count; i++)
						{
							int result7 = 0;
							int.TryParse(array[i], out result7);
							_ = array2[i];
							if (string.IsNullOrWhiteSpace(putResults.Result[i].ErrorMessage))
							{
								_dbLink.CRMspUpdateProductWithAccLinkField(result7, null, putResults.Result[i].Number.ToString(), putResults.Result[i].GuId.ToString(), userId, value3, id, value2, registerDatePersian, appType);
							}
							else
							{
								text3 = text3 + putResults.Result[i].ErrorMessage + "|";
							}
						}
						if (!string.IsNullOrEmpty(text3))
						{
							data = 0;
							message = text3.ToString();
							status = CommonResultStatusViewModel.Error;
						}
						else
						{
							data = 1;
							message = Messages.msgSuccessAction;
							status = CommonResultStatusViewModel.Success;
						}
					}
				}
			}
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
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunIIExportProduct_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		return Json(((IEnumerable)SelectProducts(fDate, tDate, value, fgId, sgId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetShygunIIExportProductList(string records, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkWSSelectProduct_Result item in SelectProducts(fDate, tDate, value, fgId, sgId))
			{
				OtherSystemSelectedViewModel otherSystemSelectedViewModel = new OtherSystemSelectedViewModel();
				otherSystemSelectedViewModel.Row = item.RowNumber.GetValueOrDefault();
				otherSystemSelectedViewModel.Id = item.ProductID;
				if (string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr))
				{
					otherSystemSelectedViewModel.Selected = true;
				}
				else
				{
					otherSystemSelectedViewModel.Selected = false;
				}
				list.Add(otherSystemSelectedViewModel);
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
			new List<LinkedProductWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShygunIIDeleteLinkedProduct_Result> list3 = Enumerable.ToList<CRMspLkShygunIIDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedProduct_Result>)_dbLink.CRMspLkShygunIIDeleteLinkedProduct(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunIIDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedProduct_Result>)list3))
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

	public string GetFileShygunIINotDeletedImportedInfo(List<CRMspLkShygunIIDeleteLinkedProduct_Result> res)
	{
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunIIDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIIDeleteLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actLinkPrdWithAcc")]
	public ActionResult ShygunIILinkedProduct()
	{
		CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
		base.ViewBag.SyncField = shygunIISetting.PrdLinkedField;
		return View();
	}

	[HttpPost]
	public JsonResult ActShygunIILinkedProduct(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LinkedProductWithAccViewModel> list = new List<LinkedProductWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actLinkPrdWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			bool flag = true;
			fromRec = 0;
			recCount = 100;
			while (flag)
			{
				ShygunProductInfoViewModelObjects shygunIIProductList = GetShygunIIProductList("0", "0", fromRec, recCount);
				if (shygunIIProductList == null)
				{
					flag = false;
					continue;
				}
				if (shygunIIProductList.lst == null || !Enumerable.Any<ShygunProductInfoViewModel>((IEnumerable<ShygunProductInfoViewModel>)shygunIIProductList.lst))
				{
					flag = false;
					continue;
				}
				foreach (ShygunProductInfoViewModel item2 in shygunIIProductList.lst)
				{
					LinkedProductWithAccViewModel item = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item2.ItemCode,
						PrdLinkAccPrdIdStr = item2.GuId,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = item2.ItemDesc
					};
					list.Add(item);
				}
				fromRec += ((fromRec > 0) ? 100 : 101);
			}
			if (list == null || !Enumerable.Any<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListPrdInLinkAccIsEmpty, Labels.ShygunII) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list));
				string text4 = "";
				text = "";
				List<CRMspLkShygunIIWSLinkedProduct_Result> list2 = Enumerable.ToList<CRMspLkShygunIIWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIWSLinkedProduct_Result>)_dbLink.CRMspLkShygunIIWSLinkedProduct(itemJson, syncField, mode, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspLkShygunIIWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIWSLinkedProduct_Result>)list2))
				{
					text = "error";
					text4 = GetFileShygunIILinkedProduct(list2);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
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

	public string GetFileShygunIILinkedProduct(List<CRMspLkShygunIIWSLinkedProduct_Result> res)
	{
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkShygunIIWSLinkedProduct_Result>((IEnumerable<CRMspLkShygunIIWSLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIIWSLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
					num++;
					string value = "";
					_ = re.Type;
					if (re.Type == 1)
					{
						value = Labels.ShygunII;
					}
					else if (re.Type == 2)
					{
						value = "CRM";
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorPrdNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupPrdLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupPrdCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorPrdNotInLinkAcc, Labels.ShygunII);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text3;
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

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actManagePrdLinkAcc")]
	public ActionResult ShygunIIManagePrdLinkAcc()
	{
		GetShygunIIProductGroup();
		GetProductSecondGroup();
		CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
		base.ViewBag.SGSyncTypeId = shygunIISetting.PrdGroupSyncTypeId;
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetShygunIIProductGroup()
	{
		//IL_01b1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b8: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b6: Expected O, but got Unknown
		LkProductSecondGroupListViewModel lkProductSecondGroupListViewModel = new LkProductSecondGroupListViewModel();
		lkProductSecondGroupListViewModel.lst = new List<LkProductSecondGroupInfoViewModel>();
		lkProductSecondGroupListViewModel.lstSelectListItem = new List<SelectListItem>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductSecondGroupInfoViewModel> list = new List<LkProductSecondGroupInfoViewModel>();
		List<SelectListItem> list2 = new List<SelectListItem>();
		bool flag = true;
		int num = 0;
		int rowCount = 100;
		try
		{
			while (flag)
			{
				List<WSspSelectProductsSecondGroupWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)_dbLink.WSspSelectProductsSecondGroupWithAccLinkField(false, false, true, false, 0, 0));
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				DomainItemGroup domainItemGroup = new DomainItemGroup();
				domainItemGroup.GroupNumber.From = string.Empty;
				domainItemGroup.GroupNumber.To = string.Empty;
				domainItemGroup.Sort.From = string.Empty;
				DataTable dataTableObject = new WebServiceGetItemGroup(shygunIISetting.IP, shygunIISetting.conf, domainItemGroup, num, rowCount).GetDataTableObject(out JsonRender);
				if (dataTableObject != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0)
				{
					List<DataRow> list4 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
					if (list4 != null && Enumerable.Any<DataRow>((IEnumerable<DataRow>)list4) && Enumerable.Count<DataRow>((IEnumerable<DataRow>)list4) > 0)
					{
						DataTable val = DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("isnull(IsMainGroup, 0) = 1"));
						if (val != null && ((InternalDataCollectionBase)val.Rows).Count > 0)
						{
							foreach (DataRow item in (InternalDataCollectionBase)val.Rows)
							{
								DataRow val2 = item;
								string text = "";
								text = (string.IsNullOrWhiteSpace(val2["GroupGuId"].ToString()) ? "" : val2["GroupGuId"].ToString());
								if (!string.IsNullOrWhiteSpace(val2["GroupName"].ToString()))
								{
									val2["GroupName"].ToString();
								}
								if (string.IsNullOrWhiteSpace(text))
								{
									continue;
								}
								List<DataRow> list5 = Enumerable.ToList<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + val2["GroupGuId"].ToString() + "'"));
								if (list5 == null || list5.Count <= 0)
								{
									continue;
								}
								foreach (DataRow item2 in (InternalDataCollectionBase)DataTableExtensions.CopyToDataTable<DataRow>((IEnumerable<DataRow>)dataTableObject.Select("[ParentGroupGuId] = '" + val2["GroupGuId"].ToString() + "'")).Rows)
								{
									DataRow val3 = item2;
									LkProductSecondGroupInfoViewModel vm = new LkProductSecondGroupInfoViewModel();
									vm.SGName = val3["GroupName"].ToString();
									vm.SGName = val3["ParentGroupName"].ToString() + " - " + val3["GroupName"].ToString();
									vm.SGLinkAccGroupIdStr = val3["GroupGuId"].ToString();
									vm.SGLinkAccGroupCode = val3["GroupNumber"].ToString();
									if (list3 != null)
									{
										WSspSelectProductsSecondGroupWithAccLinkField_Result wSspSelectProductsSecondGroupWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductsSecondGroupWithAccLinkField_Result>((IEnumerable<WSspSelectProductsSecondGroupWithAccLinkField_Result>)list3, (Func<WSspSelectProductsSecondGroupWithAccLinkField_Result, bool>)((WSspSelectProductsSecondGroupWithAccLinkField_Result x) => x.SGLinkAccGroupIdStr == vm.SGLinkAccGroupIdStr));
										if (wSspSelectProductsSecondGroupWithAccLinkField_Result != null && wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID != 0)
										{
											vm.PrdSecondGroupID = wSspSelectProductsSecondGroupWithAccLinkField_Result.PrdSecondGroupID;
										}
									}
									list.Add(vm);
									list2.Add(new SelectListItem
									{
										Value = vm.SGLinkAccGroupIdStr,
										Text = vm.SGName,
										Selected = false
									});
								}
							}
						}
						else
						{
							flag = false;
						}
					}
					lkProductSecondGroupListViewModel.lst = list;
					lkProductSecondGroupListViewModel.lstSelectListItem = list2;
				}
				else
				{
					flag = false;
				}
				num += ((num > 0) ? 100 : 101);
			}
			lkProductSecondGroupListViewModel.isDone = true;
			lkProductSecondGroupListViewModel.Message = "";
		}
		catch (Exception ex)
		{
			lkProductSecondGroupListViewModel.isDone = false;
			lkProductSecondGroupListViewModel.Message = "Error: " + ex.Message;
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		base.ViewBag.LinkAccProductSecondGroupList = lkProductSecondGroupListViewModel;
		base.ViewBag.LinkAccProductSecondGroupListlst = lkProductSecondGroupListViewModel.lst;
		JsonResult jsonResult = Json(lkProductSecondGroupListViewModel.lst, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public string ShygunIISendPrdGroupToAcc(int prdId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			if (prdId != 0)
			{
				CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
				WSspSelectProductGroupLinkAccFieldByPrdId_Result wSspSelectProductGroupLinkAccFieldByPrdId_Result = Enumerable.FirstOrDefault<WSspSelectProductGroupLinkAccFieldByPrdId_Result>((IEnumerable<WSspSelectProductGroupLinkAccFieldByPrdId_Result>)_dbLink.WSspSelectProductGroupLinkAccFieldByPrdId(prdId, lCID, result));
				if (wSspSelectProductGroupLinkAccFieldByPrdId_Result != null)
				{
					if (string.IsNullOrWhiteSpace(wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupIdStr))
					{
						List<ItemGroupPutModel> list = new List<ItemGroupPutModel>();
						ItemGroupPutModel item = new ItemGroupPutModel
						{
							GroupName = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGName ?? ""),
							GroupNumber = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGCode ?? ""),
							IsMainGroup = true,
							GuId = Guid.NewGuid(),
							UpdateKind = ActionType.insert
						};
						list.Add(item);
						PutResults putResults = new WebServiePutItemGroup(shygunIISetting.IP, shygunIISetting.conf, list).PutOperation();
						if (string.IsNullOrWhiteSpace(putResults.Result[0].ErrorMessage))
						{
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupIdStr = putResults.Result[0].GuId.ToString();
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupCode = putResults.Result[0].Number.ToString();
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupName = wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGName;
							_dbLink.CRMspUpdateProductFirstGroupWithLinkAccField(wSspSelectProductGroupLinkAccFieldByPrdId_Result.PrdFGroupId, 0, wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupCode, wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupIdStr, wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupName, userId, value2, id, value, registerDatePersian, appType);
						}
						string errorMessage = putResults.ErrorMessage;
						if (!string.IsNullOrEmpty(errorMessage))
						{
							text += errorMessage;
						}
					}
					if (!string.IsNullOrWhiteSpace(wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupIdStr) && string.IsNullOrWhiteSpace(wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroups))
					{
						List<ItemGroupPutModel> list2 = new List<ItemGroupPutModel>();
						ItemGroupPutModel item2 = new ItemGroupPutModel
						{
							GroupName = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGName ?? ""),
							GroupNumber = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGCode ?? ""),
							IsMainGroup = false,
							ParentGroupGuId = Guid.Parse(wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupIdStr),
							ParentGroupNumber = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.FGLinkAccGroupCode ?? ""),
							UpdateKind = ActionType.insert,
							GuId = Guid.NewGuid()
						};
						list2.Add(item2);
						PutResults putResults2 = new WebServiePutItemGroup(shygunIISetting.IP, shygunIISetting.conf, list2).PutOperation();
						if (string.IsNullOrWhiteSpace(putResults2.Result[0].ErrorMessage))
						{
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupIdStr = putResults2.Result[0].GuId.ToString();
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupCode = putResults2.Result[0].Number.ToString();
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupName = wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGName;
							CommonWithIdStrViewModel value3 = new CommonWithIdStrViewModel
							{
								Id = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupIdStr ?? ""),
								Name = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupName ?? ""),
								Code = (wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupCode ?? ""),
								Extra = wSspSelectProductGroupLinkAccFieldByPrdId_Result.PrdGroupID.ToString(),
								Selected = false
							};
							wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroups = JsonConvert.SerializeObject(value3);
							_dbLink.CRMspUpdateProductSecondGroupWithLinkAccField(wSspSelectProductGroupLinkAccFieldByPrdId_Result.PrdGroupID, 0, wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupCode, wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupIdStr, wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroupName, wSspSelectProductGroupLinkAccFieldByPrdId_Result.SGLinkAccGroups, userId, value2, id, value, registerDatePersian, appType);
						}
						string errorMessage2 = putResults2.ErrorMessage;
						if (!string.IsNullOrEmpty(errorMessage2))
						{
							text += errorMessage2;
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
			}
			else
			{
				text = Messages.ErrorNotFound;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			text = ex.Message;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actManagePrdLinkAcc")]
	public ActionResult ShomaranManagePrdLinkAcc()
	{
		GetPrdFgroup();
		GetPrdGroup();
		return View();
	}

	public List<CRMspLkShomaranSelectProducts_Result> GetShomaranProductList(string prdFGName = "", string prdSGName = "", string prdName = "", string fromPrdCode = "", string toPrdCode = "", int pageNumber = 1, int pageSize = 100)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkShomaranSelectProducts_Result> list = new List<CRMspLkShomaranSelectProducts_Result>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			list = Enumerable.ToList<CRMspLkShomaranSelectProducts_Result>((IEnumerable<CRMspLkShomaranSelectProducts_Result>)_dbLink.CRMspLkShomaranSelectProducts(fromPrdCode, toPrdCode, prdFGName, prdSGName, prdName, pageNumber, pageSize, lCID, result));
			if (list == null)
			{
				list = new List<CRMspLkShomaranSelectProducts_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShomaranImportProduct_Read([DataSourceRequest] DataSourceRequest request, string prdFGName = "", string prdSGName = "", string prdName = "", string fromPrdCode = "", string toPrdCode = "", int pageNumber = 1, int pageSize = 100)
	{
		List<CRMspLkShomaranSelectProducts_Result> shomaranProductList = GetShomaranProductList(prdFGName, prdSGName, prdName, fromPrdCode, toPrdCode, pageNumber, pageSize);
		return Json(((IEnumerable)shomaranProductList).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShomaranImportInfo(string records, int prdGroupId, bool addToPrdGroup = false)
	{
		//IL_00d0: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
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
			short.Parse(Financial.Get().Id.ToString());
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
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
			if (list2 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
			{
				string selectedPrds = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2));
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkShomaranWSImportProduct(selectedPrds, prdGroupId, addToPrdGroup, userId, value2, id, value, registerDatePersian, appType, result, objectParameter);
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
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
	public JsonResult GetShomaranImportProductList(string prdFGName = "", string prdSGName = "", string prdName = "", string fromPrdCode = "", string toPrdCode = "", int pageNumber = 1, int pageSize = 100)
	{
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (CRMspLkShomaranSelectProducts_Result shomaranProduct in GetShomaranProductList(prdFGName, prdSGName, prdName, fromPrdCode, toPrdCode, pageNumber, pageSize))
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = shomaranProduct.RowNumber.GetValueOrDefault(),
					Id = shomaranProduct.PARTNO,
					Selected = (shomaranProduct.ProductId <= 0)
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

	[HttpPost]
	public JsonResult ShomaranDeleteImportedInfo(string records)
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
			new List<LinkedProductWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShomaranDeleteLinkedProduct_Result> list3 = Enumerable.ToList<CRMspLkShomaranDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedProduct_Result>)_dbLink.CRMspLkShomaranDeleteLinkedProduct(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShomaranDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedProduct_Result>)list3))
				{
					text = "error";
					text5 = GetFileShomaranNotDeletedImportedInfo(list3);
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

	public string GetFileShomaranNotDeletedImportedInfo(List<CRMspLkShomaranDeleteLinkedProduct_Result> res)
	{
		//IL_0330: Unknown result type (might be due to invalid IL or missing references)
		//IL_034b: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShomaranDeleteLinkedProduct_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.Shomaran + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShomaranDeleteLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actLinkPrdWithAcc")]
	public ActionResult ShomaranLinkedProduct()
	{
		CRMIdeal.Classes.Helper.OtherSystems.ShomaranSettingViewModel shomaranSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShomaranSetting();
		base.ViewBag.SyncField = shomaranSetting.PrdLinkedField;
		return View();
	}

	[HttpPost]
	public JsonResult ActShomaranLinkedProduct(string syncField, int mode)
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LinkedProductWithAccViewModel> list = new List<LinkedProductWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actLinkPrdWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			if (num == 0)
			{
				JsonConvert.SerializeObject(Enumerable.ToList<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list));
				string text4 = "";
				text = "";
				List<CRMspLkShomaranWSLinkedProduct_Result> list2 = Enumerable.ToList<CRMspLkShomaranWSLinkedProduct_Result>((IEnumerable<CRMspLkShomaranWSLinkedProduct_Result>)_dbLink.CRMspLkShomaranWSLinkedProduct(syncField, mode, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspLkShomaranWSLinkedProduct_Result>((IEnumerable<CRMspLkShomaranWSLinkedProduct_Result>)list2))
				{
					text = "error";
					text4 = GetFileShomaranLinkedProduct(list2);
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text4 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
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

	public string GetFileShomaranLinkedProduct(List<CRMspLkShomaranWSLinkedProduct_Result> res)
	{
		//IL_046d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0488: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			if (res != null && Enumerable.Any<CRMspLkShomaranWSLinkedProduct_Result>((IEnumerable<CRMspLkShomaranWSLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + Labels.Shomaran + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShomaranWSLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
					num++;
					string value = "";
					_ = re.Type;
					if (re.Type == 1)
					{
						value = Labels.Shomaran;
					}
					else if (re.Type == 2)
					{
						value = "CRM";
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result2 = 0;
					int.TryParse(re.ErrorType.ToString(), out result2);
					switch (result2)
					{
					case 0:
						value2 = Messages.msgErrorPrdNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupPrdLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupPrdCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorPrdNotInLinkAcc, Labels.Shomaran);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text2 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text3;
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
	public string ShomaranGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", string tracing = "", string sefaresh = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			tracing = ConvertCharacter.DecodeTracing(tracing);
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Shomaran)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						List<CRMspLkShomaranReturnProductQuantity_Result> list2 = Enumerable.ToList<CRMspLkShomaranReturnProductQuantity_Result>((IEnumerable<CRMspLkShomaranReturnProductQuantity_Result>)_dbLink.CRMspLkShomaranReturnProductQuantity(prdId, whId, linkAccWhId, tracing, sefaresh, lCID, result));
						decimal num = default(decimal);
						if (list2 != null && Enumerable.Any<CRMspLkShomaranReturnProductQuantity_Result>((IEnumerable<CRMspLkShomaranReturnProductQuantity_Result>)list2))
						{
							foreach (CRMspLkShomaranReturnProductQuantity_Result item in list2)
							{
								num += item.sumaount.GetValueOrDefault();
							}
						}
						return num.ToString();
					}
					Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					return Labels.frmError;
				}
				Exception e4 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e4);
				return Labels.frmError;
			}
			Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
			ErrorSignal.FromCurrentContext().Raise(e5);
			return Labels.frmError;
		}
		catch (Exception e6)
		{
			ErrorSignal.FromCurrentContext().Raise(e6);
			return Labels.frmError;
		}
	}

	[AjaxOnly]
	public JsonResult GetPrdGroup(int fgId = 0)
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
			List<WSspSelectWSProductSecondGroup_Result> list2 = new List<WSspSelectWSProductSecondGroup_Result>();
			if (fgId == 0)
			{
				list2 = Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, 0));
			}
			else if (fgId > 0)
			{
				list2 = Enumerable.ToList<WSspSelectWSProductSecondGroup_Result>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)_db.WSspSelectWSProductSecondGroup(lCID, result, fgId));
			}
			list.AddRange(Enumerable.Select<WSspSelectWSProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectWSProductSecondGroup_Result>)list2, (Func<WSspSelectWSProductSecondGroup_Result, SelectListItem>)((WSspSelectWSProductSecondGroup_Result item) => new SelectListItem
			{
				Text = item.SGName,
				Value = item.PrdSecondGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdFgroup()
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
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdFGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdPriceGroup()
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
		base.ViewBag.PrdPriceGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetPrdCostGroup()
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
			List<WSspSelectProductCostGroup_Result> list2 = Enumerable.ToList<WSspSelectProductCostGroup_Result>((IEnumerable<WSspSelectProductCostGroup_Result>)_db.WSspSelectProductCostGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductCostGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductCostGroup_Result>)list2, (Func<WSspSelectProductCostGroup_Result, SelectListItem>)((WSspSelectProductCostGroup_Result item) => new SelectListItem
			{
				Text = item.ProductCostGroupName,
				Value = item.ProductCostGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.PrdCostGroupList = list;
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

	public ArpaProductInfoViewModelObjects GetArpaProductList(string arpaUserGroupId = "", string itemCategoryCodes = "", string itemCode = "", string fromCreationDate = "", string fromModificationDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ArpaProductInfoViewModelObjects arpaProductInfoViewModelObjects = new ArpaProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				DateTime dateTime = default(DateTime);
				string text = "";
				try
				{
					if (!string.IsNullOrWhiteSpace(fromCreationDate))
					{
						text = PersianDate.GetFormatetdDate(fromCreationDate.Replace("/", ""));
						fromCreationDate = (lCID switch
						{
							1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
						}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				try
				{
					if (!string.IsNullOrWhiteSpace(fromModificationDate))
					{
						text = PersianDate.GetFormatetdDate(fromModificationDate.Replace("/", ""));
						fromModificationDate = (lCID switch
						{
							1065 => DateTime.Parse(text + " 00:00:00", new PersianCulture()), 
							1025 => DateTime.Parse(text + " 00:00:00", new CultureInfo("ar-SA")), 
							_ => DateTime.Parse(text + " 00:00:00", new CultureInfo("en-US")), 
						}).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
					}
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text2 = arpaSetting.ArpaServerAddress ?? "";
					if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
					{
						text2 += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text2))
					{
						string text3 = "";
						if (!string.IsNullOrWhiteSpace(arpaUserGroupId))
						{
							text3 = "?UserGroupID=" + arpaUserGroupId;
						}
						if (!string.IsNullOrWhiteSpace(itemCategoryCodes))
						{
							text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
							text3 = text3 + "ItemCategoryCode=" + itemCategoryCodes;
						}
						if (!string.IsNullOrWhiteSpace(itemCode))
						{
							text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
							text3 = text3 + "ItemCode=" + itemCode;
						}
						if (!string.IsNullOrWhiteSpace(fromCreationDate))
						{
							text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
							text3 = text3 + "FromCreationDate=" + fromCreationDate;
						}
						if (!string.IsNullOrWhiteSpace(fromModificationDate))
						{
							text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
							text3 = text3 + "FromModificationDate=" + fromModificationDate;
						}
						HttpClient httpClient = new HttpClient();
						string text4 = text2 + "api/GetItem" + text3;
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaProductResponseViewModel arpaProductResponseViewModel = JsonConvert.DeserializeObject<ArpaProductResponseViewModel>(value2);
							if (arpaProductResponseViewModel != null && arpaProductResponseViewModel.data != null && Enumerable.Any<ArpaProductInfoViewModel>((IEnumerable<ArpaProductInfoViewModel>)arpaProductResponseViewModel.data))
							{
								List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
								List<ArpaProductGroupInfoViewModel> arpaItemCategoryList = GetArpaItemCategoryList();
								int num = 1;
								foreach (ArpaProductInfoViewModel item in arpaProductResponseViewModel.data)
								{
									if (arpaItemCategoryList != null && !string.IsNullOrWhiteSpace(item.ItemCategoryID))
									{
										ArpaProductGroupInfoViewModel arpaProductGroupInfoViewModel = Enumerable.FirstOrDefault<ArpaProductGroupInfoViewModel>((IEnumerable<ArpaProductGroupInfoViewModel>)arpaItemCategoryList, (Func<ArpaProductGroupInfoViewModel, bool>)((ArpaProductGroupInfoViewModel x) => x.ItemCategoryID == item.ItemCategoryID));
										if (arpaProductGroupInfoViewModel != null)
										{
											item.ItemCategoryName = arpaProductGroupInfoViewModel.ItemCategoryName;
											item.ItemCategoryCode = arpaProductGroupInfoViewModel.ItemCategoryCode;
										}
									}
									LkProductInfoViewModel lkProductInfoViewModel = new LkProductInfoViewModel();
									lkProductInfoViewModel.PrdLinkAccPrdIdStr = item.ItemID;
									lkProductInfoViewModel.PrdLinkAccPrdCode = item.ItemCode;
									lkProductInfoViewModel.PrdName = item.ItemName;
									lkProductInfoViewModel.PrdLatinName = item.ItemLatinName;
									lkProductInfoViewModel.PrdDescription = item.ItemNote;
									lkProductInfoViewModel.PrdModel = item.TechnicalNumber ?? "";
									if (!string.IsNullOrWhiteSpace(item.IsActive))
									{
										int result3 = 0;
										int.TryParse(item.IsActive, out result3);
										if (result3 == 1)
										{
											lkProductInfoViewModel.PrdInActive = false;
										}
										else
										{
											lkProductInfoViewModel.PrdInActive = true;
										}
									}
									if (!string.IsNullOrWhiteSpace(item.ItemType))
									{
										int result4 = 0;
										int.TryParse(item.ItemType, out result4);
										if (result4 == 1)
										{
											lkProductInfoViewModel.PrdKind = 2;
										}
										else
										{
											lkProductInfoViewModel.PrdKind = 1;
										}
									}
									else
									{
										lkProductInfoViewModel.PrdKind = 1;
									}
									if (!string.IsNullOrWhiteSpace(item.UnitsRatio))
									{
										double result5 = 0.0;
										double.TryParse(item.UnitsRatio, out result5);
										if (result5 != 0.0)
										{
											lkProductInfoViewModel.PrdUnitIRate = result5;
										}
									}
									lkProductInfoViewModel.Unit = item.MjUnitName;
									lkProductInfoViewModel.UnitI = item.MnUnitName;
									if (!string.IsNullOrWhiteSpace(item.SalePrice))
									{
										decimal result6 = default(decimal);
										decimal.TryParse(item.SalePrice, out result6);
										if (result6 != 0m)
										{
											lkProductInfoViewModel.Price = result6;
										}
									}
									if (!string.IsNullOrWhiteSpace(item.LastPurchasePrice))
									{
										decimal result7 = default(decimal);
										decimal.TryParse(item.LastPurchasePrice, out result7);
										if (result7 != 0m)
										{
											lkProductInfoViewModel.Cost = result7;
										}
									}
									lkProductInfoViewModel.SGLinkAccGroupIdStr = item.ItemCategoryID;
									lkProductInfoViewModel.SGName = item.ItemCategoryName;
									lkProductInfoViewModel.SGLinkAccGroupCode = item.ItemCategoryCode;
									lkProductInfoViewModel.RowNumber = num;
									WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == item.ItemID));
									if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
									{
										lkProductInfoViewModel.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
									}
									else
									{
										lkProductInfoViewModel.ProductId = 0;
									}
									list.Add(lkProductInfoViewModel);
									num++;
								}
							}
						}
					}
				}
			}
			arpaProductInfoViewModelObjects.lst = list;
			arpaProductInfoViewModelObjects.FilteredLst = list;
			arpaProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			arpaProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		return arpaProductInfoViewModelObjects;
	}

	public List<LkProductPriceInfoViewModel> GetArpaProductPriceList(string arpaPriceLevelId = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductPriceInfoViewModel> list = new List<LkProductPriceInfoViewModel>();
		try
		{
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					string text2 = arpaSetting.DefUserGroupId;
					if (string.IsNullOrWhiteSpace(text2))
					{
						text2 = "0";
					}
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						string text3 = "";
						if (!string.IsNullOrWhiteSpace(arpaPriceLevelId))
						{
							text3 = "?PriceLevelID=" + arpaPriceLevelId;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
							text3 = text3 + "UserGroupID=" + text2;
						}
						HttpClient httpClient = new HttpClient();
						string text4 = text + "api/GetItemByPriceLevelID" + text3;
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaProductPriceResponseViewModel arpaProductPriceResponseViewModel = JsonConvert.DeserializeObject<ArpaProductPriceResponseViewModel>(value2);
							if (arpaProductPriceResponseViewModel != null && arpaProductPriceResponseViewModel.data != null && Enumerable.Any<ArpaProductPriceInfoViewModel>((IEnumerable<ArpaProductPriceInfoViewModel>)arpaProductPriceResponseViewModel.data))
							{
								List<CommonMultiSelectorViewModel> arpaProdcutPriceLevelList = GetArpaProdcutPriceLevelList();
								string productPriceGroupName = "";
								if (arpaProdcutPriceLevelList != null)
								{
									int prdpriceGId = 0;
									int.TryParse(arpaPriceLevelId, out prdpriceGId);
									CommonMultiSelectorViewModel commonMultiSelectorViewModel = Enumerable.FirstOrDefault<CommonMultiSelectorViewModel>((IEnumerable<CommonMultiSelectorViewModel>)arpaProdcutPriceLevelList, (Func<CommonMultiSelectorViewModel, bool>)((CommonMultiSelectorViewModel x) => x.Id == prdpriceGId));
									if (commonMultiSelectorViewModel != null)
									{
										productPriceGroupName = commonMultiSelectorViewModel.Name ?? "";
									}
								}
								int num = 1;
								foreach (ArpaProductPriceInfoViewModel datum in arpaProductPriceResponseViewModel.data)
								{
									LkProductPriceInfoViewModel lkProductPriceInfoViewModel = new LkProductPriceInfoViewModel();
									lkProductPriceInfoViewModel.Price = datum.PriceAmount.GetValueOrDefault();
									if (lkProductPriceInfoViewModel.Price <= 1m)
									{
										lkProductPriceInfoViewModel.Price = datum.SalePrice.GetValueOrDefault();
									}
									lkProductPriceInfoViewModel.PrdLinkAccPrdCode = datum.ItemCode;
									lkProductPriceInfoViewModel.PrdLinkAccPrdIdStr = datum.ItemID;
									lkProductPriceInfoViewModel.PrdId = 0;
									lkProductPriceInfoViewModel.ProductPriceGroupName = productPriceGroupName;
									lkProductPriceInfoViewModel.LinkAccPrdPriceGroupIdStr = arpaPriceLevelId;
									list.Add(lkProductPriceInfoViewModel);
									num++;
								}
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
		return list;
	}

	public string Arpa_GetToken()
	{
		string text = "";
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				string text2 = arpaSetting.ArpaServerAddress ?? "";
				string text3 = arpaSetting.ArpaUserName ?? "";
				string text4 = arpaSetting.ArpaPassword ?? "";
				if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("serv/"))
				{
					text2 += "serv/";
				}
				if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
				{
					HttpClient httpClient = new HttpClient();
					string text5 = string.Format(text2 + "token/GetServiceToken?username={0}&password={1}", text3, text4);
					httpClient.BaseAddress = new Uri(text5);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result = httpClient.PostAsync(text5, content).Result;
					if (result.IsSuccessStatusCode)
					{
						string result2 = result.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(result2))
						{
							text = result2 ?? "";
							if (!string.IsNullOrWhiteSpace(text))
							{
								text = "Bearer " + text;
							}
						}
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = "";
		}
		return text;
	}

	[AjaxOnly]
	public List<ArpaProductGroupInfoViewModel> GetArpaItemCategoryList()
	{
		List<ArpaProductGroupInfoViewModel> list = new List<ArpaProductGroupInfoViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					string defUserGroupId = arpaSetting.DefUserGroupId;
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						string text2 = "";
						if (!string.IsNullOrWhiteSpace(defUserGroupId))
						{
							text2 = text2 + "?UserGroupID=" + defUserGroupId;
						}
						HttpClient httpClient = new HttpClient();
						string text3 = text + "api/GetItemCategory" + text2;
						httpClient.BaseAddress = new Uri(text3);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text3, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaProductGroupResponseViewModel arpaProductGroupResponseViewModel = JsonConvert.DeserializeObject<ArpaProductGroupResponseViewModel>(value2);
							if (arpaProductGroupResponseViewModel != null && arpaProductGroupResponseViewModel.data != null && Enumerable.Any<ArpaProductGroupInfoViewModel>((IEnumerable<ArpaProductGroupInfoViewModel>)arpaProductGroupResponseViewModel.data))
							{
								int num = 1;
								foreach (ArpaProductGroupInfoViewModel datum in arpaProductGroupResponseViewModel.data)
								{
									datum.RowNumber = num;
									list.Add(datum);
									num++;
								}
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetArpaItemCategories()
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
			List<ArpaProductGroupInfoViewModel> arpaItemCategoryList = GetArpaItemCategoryList();
			if (arpaItemCategoryList != null && Enumerable.Any<ArpaProductGroupInfoViewModel>((IEnumerable<ArpaProductGroupInfoViewModel>)arpaItemCategoryList))
			{
				list.AddRange(Enumerable.Select<ArpaProductGroupInfoViewModel, SelectListItem>((IEnumerable<ArpaProductGroupInfoViewModel>)arpaItemCategoryList, (Func<ArpaProductGroupInfoViewModel, SelectListItem>)((ArpaProductGroupInfoViewModel item) => new SelectListItem
				{
					Text = (item.ItemCategoryName ?? ""),
					Value = (item.ItemCategoryID ?? ""),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ArpaItemCategoriesList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetArpaProdcutPriceLevel(string parameters = "", string extra = "")
	{
		List<CommonMultiSelectorViewModel> list = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			list = GetArpaProdcutPriceLevelList(parameters, extra);
			if (list == null)
			{
				list = new List<CommonMultiSelectorViewModel>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<CommonMultiSelectorViewModel> GetArpaProdcutPriceLevelList(string parameters = "", string extra = "")
	{
		List<CommonMultiSelectorViewModel> result = new List<CommonMultiSelectorViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						HttpClient httpClient = new HttpClient();
						string text2 = text + "api/GetPriceLevels";
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result3 = httpClient.PostAsync(text2, content).Result;
						if (result3.IsSuccessStatusCode)
						{
							string value2 = result3.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaProductPriceGroupResponseViewModel arpaProductPriceGroupResponseViewModel = JsonConvert.DeserializeObject<ArpaProductPriceGroupResponseViewModel>(value2);
							if (arpaProductPriceGroupResponseViewModel != null && arpaProductPriceGroupResponseViewModel.data != null && Enumerable.Any<ArpaProductPriceGroupInfoViewModel>((IEnumerable<ArpaProductPriceGroupInfoViewModel>)arpaProductPriceGroupResponseViewModel.data))
							{
								foreach (ArpaProductPriceGroupInfoViewModel datum in arpaProductPriceGroupResponseViewModel.data)
								{
									datum.PriceLevelID = datum.PriceLevelID.TrimEnd(new char[1] { ' ' });
									datum.PriceLevelCaption = datum.PriceLevelCaption.TrimEnd(new char[1] { ' ' });
								}
								string[] arrSelected = extra.Split(new char[1] { '|' });
								result = Enumerable.ToList<CommonMultiSelectorViewModel>(Enumerable.Select(Enumerable.Select((IEnumerable<ArpaProductPriceGroupInfoViewModel>)arpaProductPriceGroupResponseViewModel.data, (ArpaProductPriceGroupInfoViewModel item) => new
								{
									item = item,
									sel = Array.Exists(arrSelected, (string element) => element == (item.PriceLevelID ?? "0"))
								}), _003C_003Eh__TransparentIdentifier0 => new CommonMultiSelectorViewModel
								{
									Id = int.Parse(_003C_003Eh__TransparentIdentifier0.item.PriceLevelID ?? "0"),
									Name = _003C_003Eh__TransparentIdentifier0.item.PriceLevelCaption,
									Selected = _003C_003Eh__TransparentIdentifier0.sel
								}));
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
		return result;
	}

	[AjaxOnly]
	public JsonResult GetArpaUserGroup()
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
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						HttpClient httpClient = new HttpClient();
						string text2 = text + "api/GetUserGroup";
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaUserGroupResponseViewModel arpaUserGroupResponseViewModel = JsonConvert.DeserializeObject<ArpaUserGroupResponseViewModel>(value2);
							if (arpaUserGroupResponseViewModel != null && arpaUserGroupResponseViewModel.data != null && Enumerable.Any<ArpaUserGroupViewModel>((IEnumerable<ArpaUserGroupViewModel>)arpaUserGroupResponseViewModel.data))
							{
								foreach (ArpaUserGroupViewModel datum in arpaUserGroupResponseViewModel.data)
								{
									datum.UserGroupID = datum.UserGroupID.TrimEnd(new char[1] { ' ' });
									datum.UserGroupName = datum.UserGroupName.TrimEnd(new char[1] { ' ' });
								}
								list.AddRange(Enumerable.Select<ArpaUserGroupViewModel, SelectListItem>((IEnumerable<ArpaUserGroupViewModel>)arpaUserGroupResponseViewModel.data, (Func<ArpaUserGroupViewModel, SelectListItem>)((ArpaUserGroupViewModel item) => new SelectListItem
								{
									Text = (item.UserGroupName ?? ""),
									Value = (item.UserGroupID ?? ""),
									Selected = false
								})));
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
		base.ViewBag.ArpaUserGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public List<ArpaProductAIGroupInfoViewModel> GetArpaItemIAGroupsList()
	{
		List<ArpaProductAIGroupInfoViewModel> list = new List<ArpaProductAIGroupInfoViewModel>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string value = Arpa_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
				if (arpaSetting != null)
				{
					string text = arpaSetting.ArpaServerAddress ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
					{
						text += "serv/";
					}
					if (!string.IsNullOrWhiteSpace(text))
					{
						HttpClient httpClient = new HttpClient();
						string text2 = text + "api/GetIAGroups";
						httpClient.BaseAddress = new Uri(text2);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.PostAsync(text2, content).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							ArpaProductAIGroupResponseViewModel arpaProductAIGroupResponseViewModel = JsonConvert.DeserializeObject<ArpaProductAIGroupResponseViewModel>(value2);
							if (arpaProductAIGroupResponseViewModel != null && arpaProductAIGroupResponseViewModel.data != null && Enumerable.Any<ArpaProductAIGroupInfoViewModel>((IEnumerable<ArpaProductAIGroupInfoViewModel>)arpaProductAIGroupResponseViewModel.data))
							{
								int num = 1;
								foreach (ArpaProductAIGroupInfoViewModel datum in arpaProductAIGroupResponseViewModel.data)
								{
									datum.RowNumber = num;
									list.Add(datum);
									num++;
								}
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetArpaItemIAGroups()
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
			List<ArpaProductAIGroupInfoViewModel> arpaItemIAGroupsList = GetArpaItemIAGroupsList();
			if (arpaItemIAGroupsList != null && Enumerable.Any<ArpaProductAIGroupInfoViewModel>((IEnumerable<ArpaProductAIGroupInfoViewModel>)arpaItemIAGroupsList))
			{
				list.AddRange(Enumerable.Select<ArpaProductAIGroupInfoViewModel, SelectListItem>((IEnumerable<ArpaProductAIGroupInfoViewModel>)arpaItemIAGroupsList, (Func<ArpaProductAIGroupInfoViewModel, SelectListItem>)((ArpaProductAIGroupInfoViewModel item) => new SelectListItem
				{
					Text = (item.IAGroupName ?? ""),
					Value = (item.IAGroupID ?? ""),
					Selected = false
				})));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ArpaItemIAGroupsList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public string ArpaActSendToAcc(int prdId, string linkAccPrdGroupId, string linkAccPrdGroupAccId)
	{
		string text = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					int id = Financial.Get().Id;
					WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
					if (wSspSelectProductsWithId_Result != null)
					{
						ArpaItemIEViewModel arpaItemIEViewModel = new ArpaItemIEViewModel();
						arpaItemIEViewModel.ItemName = wSspSelectProductsWithId_Result.PrdName;
						arpaItemIEViewModel.ItemCode = "";
						arpaItemIEViewModel.ItemCategoryID = linkAccPrdGroupId;
						arpaItemIEViewModel.IAGroupID = linkAccPrdGroupAccId;
						arpaItemIEViewModel.TechnicalNumber = wSspSelectProductsWithId_Result.PrdModel ?? "";
						arpaItemIEViewModel.UnitID = "";
						int prdUnitId = 0;
						int.TryParse(wSspSelectProductsWithId_Result.PrdUnitId.ToString(), out prdUnitId);
						if (prdUnitId != 0)
						{
							List<WSspSelectProductUnitWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)_dbLink.WSspSelectProductUnitWithAccLinkField(false, true, lCID, result));
							if (list != null && Enumerable.Any<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list))
							{
								WSspSelectProductUnitWithAccLinkField_Result wSspSelectProductUnitWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductUnitWithAccLinkField_Result>((IEnumerable<WSspSelectProductUnitWithAccLinkField_Result>)list, (Func<WSspSelectProductUnitWithAccLinkField_Result, bool>)((WSspSelectProductUnitWithAccLinkField_Result m) => m.ProductUnitID == prdUnitId));
								if (wSspSelectProductUnitWithAccLinkField_Result != null)
								{
									arpaItemIEViewModel.UnitID = wSspSelectProductUnitWithAccLinkField_Result.UnitLinkAccUnitIdStr ?? "";
								}
							}
						}
						arpaItemIEViewModel.IsProduct = "1";
						if (wSspSelectProductsWithId_Result.PrdKind.GetValueOrDefault(1) == 2)
						{
							arpaItemIEViewModel.IsProduct = "0";
						}
						if (string.IsNullOrWhiteSpace(arpaItemIEViewModel.UnitID))
						{
							arpaItemIEViewModel.UnitID = null;
						}
						string text2 = "api/PostItem";
						bool flag = true;
						if (!string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
						{
							text = string.Format(Messages.msgErrorNotReSendPrdToOtherSystem, wSspSelectProductsWithId_Result.PrdName ?? "", wSspSelectProductsWithId_Result.PrdCode ?? "", Labels.Arpa) + "|";
							return text;
						}
						string value3 = Arpa_GetToken();
						if (!string.IsNullOrWhiteSpace(value3))
						{
							CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
							if (arpaSetting != null)
							{
								string text3 = arpaSetting.ArpaServerAddress ?? "";
								if (!string.IsNullOrWhiteSpace(text3) && !text3.EndsWith("serv/"))
								{
									text3 += "serv/";
								}
								if (!string.IsNullOrWhiteSpace(text3))
								{
									HttpClient httpClient = new HttpClient();
									string text4 = text3 + text2;
									httpClient.BaseAddress = new Uri(text4);
									httpClient.DefaultRequestHeaders.Add("Authorization", value3);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									HttpContent content = new StringContent(JsonConvert.SerializeObject(arpaItemIEViewModel).Replace("\"UnitID\":null,", "").Replace("\"UnitID\":null", "")
										.Replace(",,", ",")
										.Replace(",}", "}")
										.Replace("{,", "{"), Encoding.UTF8, "application/json");
									HttpResponseMessage result2 = httpClient.PostAsync(text4, content).Result;
									if (result2.IsSuccessStatusCode)
									{
										string text5 = result2.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(text5))
										{
											text5 = text5.ClearHiddenCharacters();
											if (text5.IndexOf("}{", StringComparison.Ordinal) >= 0)
											{
												string[] array = Regex.Split(text5, "}{");
												if (array != null && array.Length > 1)
												{
													string text6 = array[0];
													if (!string.IsNullOrWhiteSpace(text6))
													{
														if (!text6.EndsWith("}"))
														{
															text6 += "}";
														}
														ArpaItemIEResponseViewModel arpaItemIEResponseViewModel = JsonConvert.DeserializeObject<ArpaItemIEResponseViewModel>(text6);
														if (arpaItemIEResponseViewModel != null)
														{
															bool result3 = false;
															bool.TryParse(arpaItemIEResponseViewModel.status.ToString(), out result3);
															if (result3)
															{
																string text7 = array[1];
																if (!string.IsNullOrWhiteSpace(text7) && !text6.StartsWith("{"))
																{
																	text7 = "{" + text7;
																	text5 = text7;
																}
															}
															else
															{
																text5 = text6;
															}
														}
													}
												}
											}
										}
										ArpaItemIEResponseViewModel arpaItemIEResponseViewModel2 = JsonConvert.DeserializeObject<ArpaItemIEResponseViewModel>(text5);
										if (arpaItemIEResponseViewModel2 != null)
										{
											if (!string.IsNullOrWhiteSpace(arpaItemIEResponseViewModel2.error))
											{
												text = text + "<br>" + arpaItemIEResponseViewModel2.error + "|";
											}
											else if (flag)
											{
												if (arpaItemIEResponseViewModel2.data != null)
												{
													string text8 = arpaItemIEResponseViewModel2.data.ItemCode ?? "";
													string text9 = arpaItemIEResponseViewModel2.data.ItemID ?? "";
													if (!string.IsNullOrWhiteSpace(text8) && !string.IsNullOrWhiteSpace(text9))
													{
														_dbLink.CRMspUpdateProductWithAccLinkField(prdId, null, text8, text9, userId, value2, id, value, registerDatePersian, appType);
														text = "1|" + text8;
													}
													else
													{
														text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
													}
												}
												else
												{
													text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
												}
											}
											else
											{
												bool result4 = false;
												bool.TryParse(arpaItemIEResponseViewModel2.status.ToString(), out result4);
												text = ((!result4) ? (text + "<br>" + Messages.msgErrorCommunicateWithServer + "|") : ("1|" + wSspSelectProductsWithId_Result.PrdLinkAccPrdCode));
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
										}
									}
									else
									{
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
									}
								}
								else
								{
									text = text + "<br>" + Messages.errorInReadingSetting + "|";
								}
							}
							else
							{
								text = text + "<br>" + Messages.errorInReadingSetting + "|";
							}
						}
						else
						{
							text = text + "<br>" + Messages.msgErrorReceivingToken + "|";
						}
					}
					else
					{
						text = Messages.ErrorNotFound + "|";
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message;
				}
			}
			else
			{
				text = Messages.ErrorNotFound + "|";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Messages.msgErrorRunFunction + "|";
		}
		return text;
	}

	[AjaxOnly]
	public string ArpaGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
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
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Arpa)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								linkWhId = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								string value = Arpa_GetToken();
								if (!string.IsNullOrWhiteSpace(value))
								{
									CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
									if (arpaSetting != null)
									{
										string text = arpaSetting.ArpaServerAddress ?? "";
										string text2 = arpaSetting.DefUserGroupId;
										if (string.IsNullOrWhiteSpace(text2))
										{
											text2 = "0";
										}
										if (!string.IsNullOrWhiteSpace(text) && !text.EndsWith("serv/"))
										{
											text += "serv/";
										}
										if (!string.IsNullOrWhiteSpace(text))
										{
											string text3 = "?ItemCode=" + wSspSelectProductsWithId_Result.PrdLinkAccPrdCode;
											if (!string.IsNullOrWhiteSpace(text2))
											{
												text3 = (string.IsNullOrWhiteSpace(text3) ? "?" : (text3 + "&"));
												text3 = text3 + "UserGroupID=" + text2;
											}
											HttpClient httpClient = new HttpClient();
											string text4 = text + "api/GetStockByDetails" + text3;
											httpClient.BaseAddress = new Uri(text4);
											httpClient.DefaultRequestHeaders.Add("Authorization", value);
											httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
											HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
											HttpResponseMessage result3 = httpClient.PostAsync(text4, content).Result;
											if (result3.IsSuccessStatusCode)
											{
												string value2 = result3.Content.ReadAsStringAsync().Result;
												if (!string.IsNullOrWhiteSpace(value2))
												{
													value2 = value2.ClearHiddenCharacters();
												}
												ArpaProductQuantityResponseViewModel arpaProductQuantityResponseViewModel = JsonConvert.DeserializeObject<ArpaProductQuantityResponseViewModel>(value2);
												if (arpaProductQuantityResponseViewModel != null && arpaProductQuantityResponseViewModel.data != null && Enumerable.Any<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data))
												{
													ArpaProductQuantityInfoViewModel arpaProductQuantityInfoViewModel = Enumerable.FirstOrDefault<ArpaProductQuantityInfoViewModel>((IEnumerable<ArpaProductQuantityInfoViewModel>)arpaProductQuantityResponseViewModel.data, (Func<ArpaProductQuantityInfoViewModel, bool>)((ArpaProductQuantityInfoViewModel m) => m.StockAreaID == linkWhId));
													decimal num = default(decimal);
													if (arpaProductQuantityInfoViewModel != null)
													{
														num = arpaProductQuantityInfoViewModel.Qty.GetValueOrDefault();
													}
													result = num.ToString();
												}
											}
										}
									}
								}
							}
							else
							{
								Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = Labels.frmError;
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = Labels.frmError;
		}
		return result;
	}

	public HamrahanProductInfoViewModelObjects GetHamrahanProductList(string fiscalYear = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		HamrahanProductInfoViewModelObjects hamrahanProductInfoViewModelObjects = new HamrahanProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			string value = new LinkAccHamrahanSettingController().Hamrahan_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
				if (hamrahanSetting != null)
				{
					string text = hamrahanSetting.HamrahanApiAddress ?? "";
					string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
					string text3 = hamrahanSetting.HamrahanCompanyId ?? "";
					string text4 = hamrahanSetting.HamrahanCurrentFiscalYear ?? "";
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
					{
						if (!text.EndsWith("/"))
						{
							text += "/";
						}
						if (!text.EndsWith("api/"))
						{
							text += "api/";
						}
						text = text + "v" + text2 + "/";
						if (string.IsNullOrWhiteSpace(fiscalYear))
						{
							fiscalYear = text4;
						}
						HttpClient httpClient = new HttpClient();
						string text5 = text + "CellarPlaceValue/company/" + text3 + "/fiscalyear/" + fiscalYear;
						httpClient.BaseAddress = new Uri(text5);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.GetAsync(text5).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							if (!string.IsNullOrWhiteSpace(value2))
							{
								List<HamrahanProductInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanProductInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanProductInfoViewModel>((IEnumerable<HamrahanProductInfoViewModel>)list2))
								{
									List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
									int num = 1;
									foreach (HamrahanProductInfoViewModel item in list2)
									{
										bool flag = true;
										if (list != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list))
										{
											LkProductInfoViewModel lkProductInfoViewModel = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel m) => m.PrdLinkAccPrdIdStr == item.rnObject.GetValueOrDefault().ToString()));
											if (lkProductInfoViewModel != null && !string.IsNullOrWhiteSpace(lkProductInfoViewModel.PrdLinkAccPrdIdStr))
											{
												flag = false;
											}
										}
										if (flag)
										{
											LkProductInfoViewModel lkProductInfoViewModel2 = new LkProductInfoViewModel();
											lkProductInfoViewModel2.PrdLinkAccPrdIdStr = item.rnObject.GetValueOrDefault().ToString();
											lkProductInfoViewModel2.PrdLinkAccPrdCode = item.codeObject;
											lkProductInfoViewModel2.PrdName = item.nameObject;
											lkProductInfoViewModel2.PrdKind = 1;
											if (item.rnScruple.GetValueOrDefault() != 0L)
											{
												lkProductInfoViewModel2.UnitLinkAccUnitIdStr = item.rnScruple.GetValueOrDefault().ToString();
												lkProductInfoViewModel2.Unit = item.nameScruple;
											}
											lkProductInfoViewModel2.RowNumber = num;
											WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == item.rnObject.GetValueOrDefault().ToString()));
											if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
											{
												lkProductInfoViewModel2.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
											}
											else
											{
												lkProductInfoViewModel2.ProductId = 0;
											}
											list.Add(lkProductInfoViewModel2);
											num++;
										}
									}
								}
							}
						}
					}
				}
			}
			hamrahanProductInfoViewModelObjects.lst = list;
			hamrahanProductInfoViewModelObjects.FilteredLst = list;
			hamrahanProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			hamrahanProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return hamrahanProductInfoViewModelObjects;
	}

	public HamrahanProductInfoViewModelObjects GetHamrahanProductListByGroup(int prdGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		HamrahanProductInfoViewModelObjects hamrahanProductInfoViewModelObjects = new HamrahanProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			string value = new LinkAccHamrahanSettingController().Hamrahan_GetToken();
			if (!string.IsNullOrWhiteSpace(value))
			{
				CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
				if (hamrahanSetting != null)
				{
					string text = hamrahanSetting.HamrahanApiAddress ?? "";
					string text2 = hamrahanSetting.HamrahanApiVersion ?? "";
					string text3 = hamrahanSetting.HamrahanCompanyId ?? "";
					_ = hamrahanSetting.HamrahanCurrentFiscalYear;
					if (!string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3))
					{
						if (!text.EndsWith("/"))
						{
							text += "/";
						}
						if (!text.EndsWith("api/"))
						{
							text += "api/";
						}
						text = text + "v" + text2 + "/";
						HttpClient httpClient = new HttpClient();
						string text4 = text + "DefineObject/company/" + text3 + "/rngroup/" + prdGroupId;
						httpClient.BaseAddress = new Uri(text4);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
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
								List<HamrahanProductInfoByGroupViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanProductInfoByGroupViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanProductInfoByGroupViewModel>((IEnumerable<HamrahanProductInfoByGroupViewModel>)list2))
								{
									List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
									int num = 1;
									foreach (HamrahanProductInfoByGroupViewModel item in list2)
									{
										LkProductInfoViewModel lkProductInfoViewModel = new LkProductInfoViewModel();
										lkProductInfoViewModel.PrdLinkAccPrdIdStr = item.recNo.GetValueOrDefault().ToString();
										lkProductInfoViewModel.PrdLinkAccPrdCode = item.codeObject;
										lkProductInfoViewModel.PrdName = item.nameObject;
										lkProductInfoViewModel.PrdKind = 1;
										lkProductInfoViewModel.Unit = item.nameScruple;
										lkProductInfoViewModel.RowNumber = num;
										WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == item.recNo.GetValueOrDefault().ToString()));
										if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
										{
											lkProductInfoViewModel.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
										}
										else
										{
											lkProductInfoViewModel.ProductId = 0;
										}
										list.Add(lkProductInfoViewModel);
										num++;
									}
								}
							}
						}
					}
				}
			}
			hamrahanProductInfoViewModelObjects.lst = list;
			hamrahanProductInfoViewModelObjects.FilteredLst = list;
			hamrahanProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			hamrahanProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return hamrahanProductInfoViewModelObjects;
	}

	[AjaxOnly]
	public JsonResult GetHamrahanPrdGrouos()
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
			LkProductSecondGroupInfoViewModelObjects hamrahanProductGroupList = new ProductGroupController().GetHamrahanProductGroupList();
			if (hamrahanProductGroupList != null)
			{
				List<LkProductSecondGroupInfoViewModel> lst = hamrahanProductGroupList.lst;
				if (lst != null && Enumerable.Any<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkProductSecondGroupInfoViewModel, SelectListItem>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst, (Func<LkProductSecondGroupInfoViewModel, SelectListItem>)((LkProductSecondGroupInfoViewModel item) => new SelectListItem
					{
						Text = (item.SGName ?? ""),
						Value = (item.SGLinkAccGroupIdStr ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.HamrahanPrdGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string HamrahanGetPrdQuantity(int prdId, int whId, string linkAccWhId = "", int prdPriceGroupId = 0, int currUserId = 0)
	{
		//IL_03ca: Unknown result type (might be due to invalid IL or missing references)
		//IL_03d1: Expected O, but got Unknown
		//IL_0470: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Unknown result type (might be due to invalid IL or missing references)
		//IL_0482: Unknown result type (might be due to invalid IL or missing references)
		//IL_048c: Invalid comparison between Unknown and I4
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int value = 0;
			if (currUserId == 0)
			{
				value = UserLogin.CurrentUser.UserId;
			}
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Hamrahan)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								linkWhId = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
							{
								string text = new LinkAccHamrahanSettingController().Hamrahan_GetToken();
								if (!string.IsNullOrWhiteSpace(text))
								{
									CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
									if (hamrahanSetting != null)
									{
										string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
										string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
										string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
										string s = hamrahanSetting.HamrahanApiUserId ?? "";
										string s2 = hamrahanSetting.HamrahanCurrencyUnit ?? "";
										int result3 = 0;
										int.TryParse(text4, out result3);
										int result4 = 0;
										int.TryParse(s, out result4);
										int result5 = 0;
										int.TryParse(s2, out result5);
										if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4))
										{
											if (!text2.EndsWith("/"))
											{
												text2 += "/";
											}
											if (!text2.EndsWith("api/"))
											{
												text2 += "api/";
											}
											text2 = text2 + "v" + text3 + "/";
											int num = 0;
											num = wSspSelectProductsWithId_Result.PrdKind.GetValueOrDefault();
											string text5 = text2 + "CellarPlaceValue/Object";
											string text6 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
											string value2 = "{\"company\":" + result3 + ",\"userID\":" + result4 + ",\"refSaleCenter\":0,\"refSaleMethod\":0,\"kindOfService\":" + num + ",\"refProcess\":0,\"documentDate\":\"" + text6 + "\",\"codeObject\":\"" + wSspSelectProductsWithId_Result.PrdLinkAccPrdCode + "\",\"qty\":1.0,\"rnValuta\":0,\"refGroupCustomer\":0,\"refCustomer\":0}";
											HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text5);
											((NameValueCollection)((WebRequest)val).Headers).Add("Authorization", text);
											((WebRequest)val).ContentType = "application/json; charset=utf-8";
											((WebRequest)val).Method = "GET";
											val.Accept = "application/json";
											object value3 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
											value3.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value3, false);
											using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
											{
												streamWriter.Write(value2);
											}
											HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
											StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
											if ((int)val2.StatusCode == 200)
											{
												string value4 = streamReader.ReadToEnd();
												if (!string.IsNullOrWhiteSpace(value4))
												{
													value4 = value4.ClearHiddenCharacters();
												}
												if (!string.IsNullOrWhiteSpace(value4))
												{
													List<HamrahanProductQtyInfoViewModel> list3 = JsonConvert.DeserializeObject<List<HamrahanProductQtyInfoViewModel>>(value4);
													if (list3 != null && Enumerable.Any<HamrahanProductQtyInfoViewModel>((IEnumerable<HamrahanProductQtyInfoViewModel>)list3))
													{
														HamrahanProductQtyInfoViewModel hamrahanProductQtyInfoViewModel = Enumerable.FirstOrDefault<HamrahanProductQtyInfoViewModel>((IEnumerable<HamrahanProductQtyInfoViewModel>)list3, (Func<HamrahanProductQtyInfoViewModel, bool>)((HamrahanProductQtyInfoViewModel m) => m.rnPhysical.GetValueOrDefault().ToString() == linkWhId));
														if (hamrahanProductQtyInfoViewModel != null)
														{
															result = hamrahanProductQtyInfoViewModel.cellarValue.GetValueOrDefault().ToString();
															decimal valueOrDefault = hamrahanProductQtyInfoViewModel.rate.GetValueOrDefault();
															if (valueOrDefault > 0m && prdPriceGroupId > 0 && prdId > 0)
															{
																DateTime now = DateTime.Now;
																DateTime value5 = now;
																string text7 = now.ToString("yyyyMMdd", new PersianCulture());
																int id = Financial.Get().Id;
																short value6 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
																string appType = Configuration.AppType;
																_db.WSspInsertProductPrice(prdPriceGroupId, prdId, text7, value5, null, valueOrDefault, null, null, null, null, null, null, null, null, null, value, value6, id, value5, text7, appType, result2);
																CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPriceGroup");
																CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProductPrice");
															}
														}
													}
												}
											}
										}
									}
								}
							}
							else
							{
								Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = Labels.frmError;
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = Labels.frmError;
		}
		return result;
	}

	public LkProductInfoViewModelObjects GetNoAvaranCapillaryProductList(string fromDate = "", string toDate = "", string linkAccPrdGroupId = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string uDate = "";
					string uDate2 = "";
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fromDate))
						{
							fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							uDate = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy/MM/dd", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(toDate))
						{
							toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							uDate2 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy/MM/dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					string value = new CommercialSoapClient().ReadFromCode(text, linkAccPrdGroupId, uDate, uDate2);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryListProductViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryListProductViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryListProductViewModel>((IEnumerable<NoAvaranCapillaryListProductViewModel>)list2))
						{
							List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
							int num = 1;
							foreach (NoAvaranCapillaryListProductViewModel item4 in list2)
							{
								NoAvaranCapillaryProductInfoViewModel x2 = item4.x;
								if (x2 != null)
								{
									LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
									vmPrd.PrdLinkAccPrdIdStr = x2.id.GetValueOrDefault().ToString();
									vmPrd.PrdLinkAccPrdCode = x2.CodeKala;
									vmPrd.PrdName = x2.NameKala;
									if (x2.CodeStore.HasValue)
									{
										vmPrd.PrdModel = x2.CodeStore.GetValueOrDefault().ToString();
									}
									vmPrd.PrdKind = 1;
									if (x2.KindRadif.GetValueOrDefault() != 0)
									{
										vmPrd.PrdKind = 2;
									}
									if (string.IsNullOrWhiteSpace(x2.NameVahed) && !string.IsNullOrWhiteSpace(item4.NameVahed))
									{
										x2.NameVahed = item4.NameVahed;
									}
									if (x2.Unit1.GetValueOrDefault(-1L) != -1)
									{
										vmPrd.UnitLinkAccUnitIdStr = x2.Unit1.GetValueOrDefault().ToString();
										vmPrd.Unit = x2.NameVahed;
									}
									if (item4.idpacking.GetValueOrDefault(-1L) != -1)
									{
										vmPrd.UnitLinkAccUnitIdStrI = item4.idpacking.GetValueOrDefault().ToString();
										vmPrd.UnitI = item4.PackingName;
									}
									if (item4.Amount.GetValueOrDefault() != 0.0)
									{
										vmPrd.PrdUnitIRate = item4.Amount.GetValueOrDefault();
									}
									if (item4.Weight.GetValueOrDefault() != 0.0)
									{
										vmPrd.PrdWeight = item4.Weight.GetValueOrDefault();
									}
									vmPrd.RowNumber = num;
									WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
									if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
									{
										vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
									}
									else
									{
										vmPrd.ProductId = 0;
									}
									vmPrd.PriceList = new List<LkProductPriceInfoViewModel>();
									if (x2.Amount1.GetValueOrDefault() != 0m)
									{
										LkProductPriceInfoViewModel item = new LkProductPriceInfoViewModel
										{
											ProductPriceGroupName = "لیست قیمت اول",
											PrdLinkAccPrdCode = vmPrd.PrdLinkAccPrdCode,
											PrdLinkAccPrdIdStr = vmPrd.PrdLinkAccPrdIdStr,
											Price = x2.Amount1.GetValueOrDefault(),
											PrdId = vmPrd.ProductId
										};
										vmPrd.PriceList.Add(item);
									}
									if (x2.Amount2.GetValueOrDefault() != 0m)
									{
										LkProductPriceInfoViewModel item2 = new LkProductPriceInfoViewModel
										{
											ProductPriceGroupName = "لیست قیمت دوم",
											PrdLinkAccPrdCode = vmPrd.PrdLinkAccPrdCode,
											PrdLinkAccPrdIdStr = vmPrd.PrdLinkAccPrdIdStr,
											Price = x2.Amount2.GetValueOrDefault(),
											PrdId = vmPrd.ProductId
										};
										vmPrd.PriceList.Add(item2);
									}
									if (x2.Amount3.GetValueOrDefault() != 0m)
									{
										LkProductPriceInfoViewModel item3 = new LkProductPriceInfoViewModel
										{
											ProductPriceGroupName = "لیست قیمت سوم",
											PrdLinkAccPrdCode = vmPrd.PrdLinkAccPrdCode,
											PrdLinkAccPrdIdStr = vmPrd.PrdLinkAccPrdIdStr,
											Price = x2.Amount3.GetValueOrDefault(),
											PrdId = vmPrd.ProductId
										};
										vmPrd.PriceList.Add(item3);
									}
									list.Add(vmPrd);
									num++;
								}
							}
						}
					}
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkProductInfoViewModelObjects;
	}

	public JsonResult GetNoAvaranCapillaryPrdGrouos()
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
			LkProductSecondGroupInfoViewModelObjects noAvaranCapillaryProductGroupList = new ProductGroupController().GetNoAvaranCapillaryProductGroupList();
			if (noAvaranCapillaryProductGroupList != null)
			{
				List<LkProductSecondGroupInfoViewModel> lst = noAvaranCapillaryProductGroupList.lst;
				if (lst != null && Enumerable.Any<LkProductSecondGroupInfoViewModel>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkProductSecondGroupInfoViewModel, SelectListItem>((IEnumerable<LkProductSecondGroupInfoViewModel>)lst, (Func<LkProductSecondGroupInfoViewModel, SelectListItem>)((LkProductSecondGroupInfoViewModel item) => new SelectListItem
					{
						Text = (item.SGName ?? ""),
						Value = (item.SGLinkAccGroupIdStr ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.NoAvaranCapillaryPrdGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string NoAvaranCapillaryGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
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
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in NoAvaran)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string text = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									text = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
								if (noAvaranCapillarySetting != null && !string.IsNullOrWhiteSpace(noAvaranCapillarySetting.ApiUserId ?? ""))
								{
									int result3 = 0;
									int.TryParse(text.ToString(), out result3);
									string text2 = new CommercialSoapClient().GetQuanKala("0", "0", wSspSelectProductsWithId_Result.PrdLinkAccPrdCode, text);
									if (!string.IsNullOrWhiteSpace(text2))
									{
										text2 = text2.ClearHiddenCharacters();
									}
									if (!string.IsNullOrWhiteSpace(text2) && text2.ToLower() != "null")
									{
										NoAvaranCapillaryProductQuantityInfoViewModel noAvaranCapillaryProductQuantityInfoViewModel = JsonConvert.DeserializeObject<NoAvaranCapillaryProductQuantityInfoViewModel>(text2);
										if (noAvaranCapillaryProductQuantityInfoViewModel != null)
										{
											result = noAvaranCapillaryProductQuantityInfoViewModel.quan.GetValueOrDefault().ToString();
										}
									}
								}
							}
							else
							{
								Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = Labels.frmError;
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = Labels.frmError;
		}
		return result;
	}

	public LkProductInfoViewModelObjects GetRahkaranRetailProductList(string cookieVal, int fromRec = 0, int recCount = 0, string itemCode = "", string itemName = "", bool getPrice = true)
	{
		//IL_01c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_01cf: Expected O, but got Unknown
		//IL_026e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0273: Unknown result type (might be due to invalid IL or missing references)
		//IL_0280: Unknown result type (might be due to invalid IL or missing references)
		//IL_028a: Invalid comparison between Unknown and I4
		//IL_04c7: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ce: Expected O, but got Unknown
		//IL_056d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0572: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			if (!string.IsNullOrWhiteSpace(cookieVal))
			{
				string text = new LinkAccRahkaranRetailSettingController().Rahkaran_GetCooKie(cookieVal);
				if (!string.IsNullOrWhiteSpace(text))
				{
					CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
					if (rahkaranRetailSetting != null)
					{
						string text2 = rahkaranRetailSetting.ApiAddress ?? "";
						if (!string.IsNullOrWhiteSpace(text2) && !text2.EndsWith("/"))
						{
							text2 += "/";
						}
						if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text))
						{
							string text3 = "";
							if (!string.IsNullOrWhiteSpace(itemName))
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "name=" + itemName;
							}
							if (!string.IsNullOrWhiteSpace(itemCode))
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "code=" + itemCode;
							}
							if (fromRec != 0)
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "from=" + fromRec;
							}
							if (recCount != 0)
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "numberOfRecords=" + recCount;
							}
							if (!string.IsNullOrWhiteSpace(text3))
							{
								text3 = "?" + text3;
							}
							string text4 = text2 + "Retail/eSalesApi/ESalesService.svc/products" + text3;
							string value = "";
							HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text4);
							((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text);
							((WebRequest)val).ContentType = "application/json; charset=utf-8";
							((WebRequest)val).Method = "GET";
							val.Accept = "application/json";
							object value2 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
							value2.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
							using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
							{
								streamWriter.Write(value);
							}
							HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
							StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
							if ((int)val2.StatusCode == 200)
							{
								string value3 = streamReader.ReadToEnd();
								if (!string.IsNullOrWhiteSpace(value3))
								{
									value3 = value3.ClearHiddenCharacters();
								}
								if (!string.IsNullOrWhiteSpace(value3))
								{
									RahkaranRetailProductResponseViewModel rahkaranRetailProductResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailProductResponseViewModel>(value3);
									if (rahkaranRetailProductResponseViewModel != null && rahkaranRetailProductResponseViewModel.result != null && Enumerable.Any<RahkaranRetailProductInfoViewModel>((IEnumerable<RahkaranRetailProductInfoViewModel>)rahkaranRetailProductResponseViewModel.result))
									{
										List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
										int num = 1;
										foreach (RahkaranRetailProductInfoViewModel item in rahkaranRetailProductResponseViewModel.result)
										{
											LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
											vmPrd.PrdLinkAccPrdIdStr = item.id.GetValueOrDefault().ToString();
											vmPrd.PrdLinkAccPrdCode = item.code;
											vmPrd.PrdName = item.name;
											vmPrd.PrdDescription = item.specification;
											vmPrd.PrdKind = 1;
											if (item.units != null && Enumerable.Any<RahkaranRetailProductUnitInfoViewModel>((IEnumerable<RahkaranRetailProductUnitInfoViewModel>)item.units))
											{
												RahkaranRetailProductUnitInfoViewModel rahkaranRetailProductUnitInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailProductUnitInfoViewModel>((IEnumerable<RahkaranRetailProductUnitInfoViewModel>)item.units, (Func<RahkaranRetailProductUnitInfoViewModel, bool>)((RahkaranRetailProductUnitInfoViewModel m) => m.isDefault.GetValueOrDefault()));
												if (rahkaranRetailProductUnitInfoViewModel != null && rahkaranRetailProductUnitInfoViewModel.id.GetValueOrDefault() != 0L)
												{
													vmPrd.UnitLinkAccUnitIdStr = rahkaranRetailProductUnitInfoViewModel.id.GetValueOrDefault().ToString();
													vmPrd.Unit = rahkaranRetailProductUnitInfoViewModel.name;
												}
											}
											if (getPrice)
											{
												text4 = text2 + "Services/Retail/ESales.svc/price";
												value = "{\"customerId\":0,\"currencyId\":0,\"retailShopId\":0,\"date\":\"" + DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("en-US")) + "\",\"salesAreaId\":0,\"items\":[{\"itemId\":0,\"productId\":" + item.id.GetValueOrDefault() + ",\"unitId\":0,\"quantity\":0}]}";
												val = (HttpWebRequest)WebRequest.Create(text4);
												((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text);
												((WebRequest)val).ContentType = "application/json; charset=utf-8";
												((WebRequest)val).Method = "POST";
												val.Accept = "application/json";
												value2 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
												value2.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
												using (StreamWriter streamWriter2 = new StreamWriter(((WebRequest)val).GetRequestStream()))
												{
													streamWriter2.Write(value);
												}
												HttpWebResponse val3 = (HttpWebResponse)((WebRequest)val).GetResponse();
												streamReader = new StreamReader(((WebResponse)val3).GetResponseStream());
												if ((int)val3.StatusCode == 200)
												{
													string value4 = streamReader.ReadToEnd();
													if (!string.IsNullOrWhiteSpace(value4))
													{
														value4 = value4.ClearHiddenCharacters();
													}
													if (!string.IsNullOrWhiteSpace(value4))
													{
														RahkaranRetailProductPriceResponseViewModel rahkaranRetailProductPriceResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailProductPriceResponseViewModel>(value4);
														if (rahkaranRetailProductPriceResponseViewModel != null && rahkaranRetailProductPriceResponseViewModel.result != null && Enumerable.Any<RahkaranRetailProductPriceInfoViewModel>((IEnumerable<RahkaranRetailProductPriceInfoViewModel>)rahkaranRetailProductPriceResponseViewModel.result))
														{
															RahkaranRetailProductPriceInfoViewModel rahkaranRetailProductPriceInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailProductPriceInfoViewModel>((IEnumerable<RahkaranRetailProductPriceInfoViewModel>)rahkaranRetailProductPriceResponseViewModel.result);
															if (rahkaranRetailProductPriceInfoViewModel != null)
															{
																vmPrd.Price = rahkaranRetailProductPriceInfoViewModel.fee.GetValueOrDefault();
																vmPrd.Dicount = rahkaranRetailProductPriceInfoViewModel.discount.GetValueOrDefault();
															}
														}
													}
												}
											}
											vmPrd.RowNumber = num;
											WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
											if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
											{
												vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
											}
											else
											{
												vmPrd.ProductId = 0;
											}
											list.Add(vmPrd);
											num++;
										}
									}
								}
							}
						}
					}
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductInfoViewModelObjects;
	}

	[AjaxOnly]
	public string RahkaranRetailGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
	{
		//IL_02e1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Expected O, but got Unknown
		//IL_0387: Unknown result type (might be due to invalid IL or missing references)
		//IL_038c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0399: Unknown result type (might be due to invalid IL or missing references)
		//IL_03a3: Invalid comparison between Unknown and I4
		string result = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Rahkaran)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string text = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									text = commonWithIdStrViewModel.Id;
								}
							}
							if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
							{
								text = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
							}
							if (!string.IsNullOrWhiteSpace(text))
							{
								CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
								if (rahkaranRetailSetting != null)
								{
									string text2 = rahkaranRetailSetting.ApiCookie ?? "";
									if (!string.IsNullOrWhiteSpace(text2))
									{
										string text3 = new LinkAccRahkaranRetailSettingController().Rahkaran_GetCooKie(text2);
										if (!string.IsNullOrWhiteSpace(text3))
										{
											string text4 = rahkaranRetailSetting.ApiAddress ?? "";
											if (!string.IsNullOrWhiteSpace(text4) && !text4.EndsWith("/"))
											{
												text4 += "/";
											}
											if (!string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text3))
											{
												string text5 = text4 + "Services/Retail/ESales.svc/remaining";
												string value = "{\"productId\":" + (wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr ?? "0") + ",\"storeId\":" + text + ",\"dateTime\":\"" + DateTime.Now.ToString("yyyy/MM/dd", new CultureInfo("en-US")) + "\"}";
												HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text5);
												((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text3);
												((WebRequest)val).ContentType = "application/json; charset=utf-8";
												((WebRequest)val).Method = "POST";
												val.Accept = "application/json";
												object value2 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
												value2.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value2, false);
												using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
												{
													streamWriter.Write(value);
												}
												HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
												StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
												if ((int)val2.StatusCode == 200)
												{
													string value3 = streamReader.ReadToEnd();
													if (!string.IsNullOrWhiteSpace(value3))
													{
														value3 = value3.ClearHiddenCharacters();
													}
													if (!string.IsNullOrWhiteSpace(value3))
													{
														RahkaranRetailProductRemainingResponseViewModel rahkaranRetailProductRemainingResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailProductRemainingResponseViewModel>(value3);
														if (rahkaranRetailProductRemainingResponseViewModel != null && rahkaranRetailProductRemainingResponseViewModel.result.HasValue)
														{
															result = rahkaranRetailProductRemainingResponseViewModel.result.GetValueOrDefault().ToString();
														}
													}
												}
											}
										}
									}
								}
							}
							else
							{
								Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = Labels.frmError;
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = Labels.frmError;
		}
		return result;
	}

	public LkProductInfoViewModelObjects GetNilramProductList(string itemCode = "", string linkAccWrhs = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
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
					if (string.IsNullOrWhiteSpace(itemCode))
					{
						itemCode = "null";
					}
					if (string.IsNullOrWhiteSpace(linkAccWrhs))
					{
						linkAccWrhs = "null";
					}
					HttpClient httpClient = new HttpClient();
					string text2 = text + "MSTK_UNIT_KALA/" + linkAccWrhs + "/" + itemCode;
					httpClient.BaseAddress = new Uri(text2);
					httpClient.DefaultRequestHeaders.Add("Access-Token", value);
					httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					new StringContent("", Encoding.UTF8, "application/json");
					HttpResponseMessage result2 = httpClient.GetAsync(text2).Result;
					if (result2.IsSuccessStatusCode)
					{
						string value2 = result2.Content.ReadAsStringAsync().Result;
						if (!string.IsNullOrWhiteSpace(value2))
						{
							value2 = value2.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(value2))
						{
							List<NilramProductsInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramProductsInfoViewModel>>(value2);
							if (list2 != null && Enumerable.Any<NilramProductsInfoViewModel>((IEnumerable<NilramProductsInfoViewModel>)list2))
							{
								List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
								int num = 1;
								foreach (NilramProductsInfoViewModel item in list2)
								{
									bool flag = true;
									if (list != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list))
									{
										LkProductInfoViewModel lkProductInfoViewModel = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel m) => m.PrdLinkAccPrdIdStr == item.id.GetValueOrDefault().ToString()));
										if (lkProductInfoViewModel != null && !string.IsNullOrWhiteSpace(lkProductInfoViewModel.PrdLinkAccPrdIdStr))
										{
											flag = false;
										}
									}
									if (flag)
									{
										LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
										vmPrd.PrdLinkAccPrdIdStr = item.id.GetValueOrDefault().ToString();
										vmPrd.PrdLinkAccPrdCode = item.t_stk_gds;
										vmPrd.PrdName = item.name_kala;
										vmPrd.PrdKind = 1;
										if (!string.IsNullOrWhiteSpace(item.t_unit))
										{
											vmPrd.UnitLinkAccUnitIdStr = item.t_unit;
											vmPrd.Unit = item.unit_NAME;
										}
										vmPrd.RowNumber = num;
										WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
										if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
										{
											vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
										}
										else
										{
											vmPrd.ProductId = 0;
										}
										list.Add(vmPrd);
										num++;
									}
								}
							}
						}
					}
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductInfoViewModelObjects;
	}

	public List<LkProductPriceInfoViewModel> GetNilramProductPriceList(string itemCode = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductPriceInfoViewModel> list = new List<LkProductPriceInfoViewModel>();
		try
		{
			if (!string.IsNullOrWhiteSpace(itemCode))
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
						string text2 = DateTime.Now.ToString("yyyy-MM-dd", new PersianCulture());
						HttpClient httpClient = new HttpClient();
						string text3 = text + "SALE_PRICE/null/" + itemCode + "/" + text2;
						httpClient.BaseAddress = new Uri(text3);
						httpClient.DefaultRequestHeaders.Add("Access-Token", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						new StringContent("", Encoding.UTF8, "application/json");
						HttpResponseMessage result2 = httpClient.GetAsync(text3).Result;
						if (result2.IsSuccessStatusCode)
						{
							string value2 = result2.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrWhiteSpace(value2))
							{
								value2 = value2.ClearHiddenCharacters();
							}
							if (!string.IsNullOrWhiteSpace(value2))
							{
								List<NilramProductPriceInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramProductPriceInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<NilramProductPriceInfoViewModel>((IEnumerable<NilramProductPriceInfoViewModel>)list2))
								{
									int num = 1;
									foreach (NilramProductPriceInfoViewModel item in list2)
									{
										LkProductPriceInfoViewModel lkProductPriceInfoViewModel = new LkProductPriceInfoViewModel();
										lkProductPriceInfoViewModel.Price = item.STANDARD_PRICE.GetValueOrDefault();
										lkProductPriceInfoViewModel.PrdLinkAccPrdCode = item.T_STK_GDS;
										lkProductPriceInfoViewModel.PrdLinkAccPrdIdStr = "";
										lkProductPriceInfoViewModel.PrdId = 0;
										lkProductPriceInfoViewModel.ProductPriceGroupName = item.NAME;
										lkProductPriceInfoViewModel.LinkAccPrdPriceGroupIdStr = item.CODE;
										if (!string.IsNullOrWhiteSpace(item.T_DATE))
										{
											item.T_DATE = item.T_DATE.Replace("/", "").Replace("-", "").Replace("\\", "")
												.Replace(" ", "")
												.Replace("_", "");
											DateTime dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(item.T_DATE) + " 00:00:00");
											DateTime dateTime2 = dateTime;
											lkProductPriceInfoViewModel.DocDate = dateTime2.ToString("yyyyMMdd", new PersianCulture());
											lkProductPriceInfoViewModel.DocDateTime = dateTime;
										}
										list.Add(lkProductPriceInfoViewModel);
										num++;
									}
								}
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetNilramWarehouse()
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
			WarehouseInfoViewModelObjects nilramWareHouseList = new WarehouseController().GetNilramWareHouseList();
			if (nilramWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = nilramWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkWareHouseInfoViewModel, SelectListItem>((IEnumerable<LkWareHouseInfoViewModel>)lst, (Func<LkWareHouseInfoViewModel, SelectListItem>)((LkWareHouseInfoViewModel item) => new SelectListItem
					{
						Text = (item.WrhsName ?? ""),
						Value = (item.WrhsLinkAccWhCode ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.NilramWarehouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string NilramGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
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
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result prd = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result2));
				if (prd == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					result = Labels.frmError;
				}
				if (prd != null && !string.IsNullOrWhiteSpace(prd.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result2));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Nilram)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							result = Labels.frmError;
						}
						else
						{
							List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
							string linkWhId = "";
							if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
							{
								CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
								if (commonWithIdStrViewModel != null)
								{
									linkWhId = commonWithIdStrViewModel.Code;
								}
							}
							if (string.IsNullOrWhiteSpace(linkWhId) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
							{
								linkWhId = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode;
							}
							if (!string.IsNullOrWhiteSpace(linkWhId))
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
										HttpClient httpClient = new HttpClient();
										string text2 = text + "MOJODI_KALA/" + linkWhId + "/" + prd.PrdLinkAccPrdCode;
										httpClient.BaseAddress = new Uri(text2);
										httpClient.DefaultRequestHeaders.Add("Access-Token", value);
										httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
										new StringContent("", Encoding.UTF8, "application/json");
										HttpResponseMessage result3 = httpClient.GetAsync(text2).Result;
										if (result3.IsSuccessStatusCode)
										{
											string value2 = result3.Content.ReadAsStringAsync().Result;
											if (!string.IsNullOrWhiteSpace(value2))
											{
												value2 = value2.ClearHiddenCharacters();
											}
											if (!string.IsNullOrWhiteSpace(value2))
											{
												List<NilramProductQuantityInfoViewModel> list3 = JsonConvert.DeserializeObject<List<NilramProductQuantityInfoViewModel>>(value2);
												if (list3 != null && Enumerable.Any<NilramProductQuantityInfoViewModel>((IEnumerable<NilramProductQuantityInfoViewModel>)list3))
												{
													NilramProductQuantityInfoViewModel nilramProductQuantityInfoViewModel = Enumerable.FirstOrDefault<NilramProductQuantityInfoViewModel>((IEnumerable<NilramProductQuantityInfoViewModel>)list3, (Func<NilramProductQuantityInfoViewModel, bool>)((NilramProductQuantityInfoViewModel m) => (m.T_STK_NO ?? "") == linkWhId && (m.T_STK_GDS ?? "") == prd.PrdLinkAccPrdCode));
													if (nilramProductQuantityInfoViewModel != null)
													{
														result = nilramProductQuantityInfoViewModel.T_CUR_QTY.GetValueOrDefault().ToString();
													}
												}
											}
										}
									}
								}
							}
							else
							{
								Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
								ErrorSignal.FromCurrentContext().Raise(e3);
								result = Labels.frmError;
							}
						}
					}
					else
					{
						Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e4);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e5);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e6);
				result = Labels.frmError;
			}
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			result = Labels.frmError;
		}
		return result;
	}

	public LkProductInfoViewModelObjects GetRahkaranInternalSalesProductList(string fromDate = "", string toDate = "", string linkAccWrhs = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			string fromDate2 = "";
			string toDate2 = "";
			try
			{
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					fromDate2 = "\\/Date(" + ((DateTimeOffset)(lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					})).ToUnixTimeMilliseconds() + "+0330)\\/";
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					toDate2 = "\\/Date(" + ((DateTimeOffset)(lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					})).ToUnixTimeMilliseconds() + "+0330)\\/";
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			long result2 = 0L;
			if (!string.IsNullOrWhiteSpace(linkAccWrhs))
			{
				long.TryParse(linkAccWrhs, out result2);
			}
			string value = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetProductList(fromDate2, toDate2, result2);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RahkaranInternalSalesProductResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesProductResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RahkaranInternalSalesProductResponseViewModel>((IEnumerable<RahkaranInternalSalesProductResponseViewModel>)list2))
					{
						List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
						int num = 1;
						foreach (RahkaranInternalSalesProductResponseViewModel item in list2)
						{
							if (item == null)
							{
								continue;
							}
							LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
							vmPrd.PrdLinkAccPrdIdStr = item.id ?? "";
							vmPrd.PrdLinkAccPrdId = int.Parse(item.partRef ?? "0");
							vmPrd.PrdLinkAccPrdCode = item.number;
							vmPrd.PrdName = item.name;
							vmPrd.PrdLatinName = item.partLatinName;
							vmPrd.PrdDescription = item.partTechnicalSpecification;
							if (!string.IsNullOrWhiteSpace(item.stateTitle) && item.stateTitle != "فعال")
							{
								vmPrd.PrdInActive = true;
							}
							vmPrd.PrdKind = 1;
							if (item.units != null && Enumerable.Any<RahkaranInternalSalesProductUnitInfoViewModel>((IEnumerable<RahkaranInternalSalesProductUnitInfoViewModel>)item.units))
							{
								string defaultUnitRef = item.defaultUnitRef;
								RahkaranInternalSalesProductUnitInfoViewModel rahkaranInternalSalesProductUnitInfoViewModel = new RahkaranInternalSalesProductUnitInfoViewModel();
								rahkaranInternalSalesProductUnitInfoViewModel = (string.IsNullOrWhiteSpace(defaultUnitRef) ? Enumerable.FirstOrDefault<RahkaranInternalSalesProductUnitInfoViewModel>((IEnumerable<RahkaranInternalSalesProductUnitInfoViewModel>)item.units, (Func<RahkaranInternalSalesProductUnitInfoViewModel, bool>)((RahkaranInternalSalesProductUnitInfoViewModel m) => !m.isInActive.GetValueOrDefault())) : Enumerable.FirstOrDefault<RahkaranInternalSalesProductUnitInfoViewModel>((IEnumerable<RahkaranInternalSalesProductUnitInfoViewModel>)item.units, (Func<RahkaranInternalSalesProductUnitInfoViewModel, bool>)((RahkaranInternalSalesProductUnitInfoViewModel m) => (m.unitRef ?? "0") == defaultUnitRef)));
								if (rahkaranInternalSalesProductUnitInfoViewModel != null && (rahkaranInternalSalesProductUnitInfoViewModel.unitRef ?? "0") != "0")
								{
									vmPrd.UnitLinkAccUnitIdStr = rahkaranInternalSalesProductUnitInfoViewModel.unitRef ?? "0";
								}
							}
							vmPrd.RowNumber = num;
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
							if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
							{
								vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
							}
							else
							{
								vmPrd.ProductId = 0;
							}
							list.Add(vmPrd);
							num++;
						}
					}
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkProductInfoViewModelObjects;
	}

	[AjaxOnly]
	public JsonResult GetRahkaranInternalSalesWarehouse()
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
			WarehouseInfoViewModelObjects rahkaranInternalSalesWareHouseList = new WarehouseController().GetRahkaranInternalSalesWareHouseList();
			if (rahkaranInternalSalesWareHouseList != null)
			{
				List<LkWareHouseInfoViewModel> lst = rahkaranInternalSalesWareHouseList.lst;
				if (lst != null && Enumerable.Any<LkWareHouseInfoViewModel>((IEnumerable<LkWareHouseInfoViewModel>)lst))
				{
					list.AddRange(Enumerable.Select<LkWareHouseInfoViewModel, SelectListItem>((IEnumerable<LkWareHouseInfoViewModel>)lst, (Func<LkWareHouseInfoViewModel, SelectListItem>)((LkWareHouseInfoViewModel item) => new SelectListItem
					{
						Text = (item.WrhsName ?? ""),
						Value = (item.WrhsLinkAccWhIdStr ?? ""),
						Selected = false
					})));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.RahkaranInternalSalesWarehouseList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string RahkaranInternalSalesGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Rahkaran)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						string text2 = "";
						if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
						{
							CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
							if (commonWithIdStrViewModel != null)
							{
								text2 = commonWithIdStrViewModel.Id;
								if (string.IsNullOrWhiteSpace(text2))
								{
									text2 = commonWithIdStrViewModel.Code;
								}
							}
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr))
						{
							text2 = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhIdStr;
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
						{
							text2 = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							long result2 = 0L;
							long.TryParse(text2, out result2);
							long result3 = 0L;
							long.TryParse(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr, out result3);
							return new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().GetPrdQuqntity(result3, result2).ToString();
						}
						Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e3);
						return Labels.frmError;
					}
					Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Labels.frmError;
				}
				Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e5);
				return Labels.frmError;
			}
			Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
			ErrorSignal.FromCurrentContext().Raise(e6);
			return Labels.frmError;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return Labels.frmError;
		}
	}

	public LkProductInfoViewModelObjects GetRayvarzProductList(string fromDate = "", string toDate = "", int linkAccPageNum = 0, string linkAccPrdGroupId = "", string itemCode = "", string itemKind = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			string fromDate2 = "";
			string toDate2 = "";
			try
			{
				DateTime now = DateTime.Now;
				DateTime now2 = DateTime.Now;
				if (!string.IsNullOrWhiteSpace(fromDate))
				{
					fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					fromDate2 = (lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
					}).ToString("yyyyMMdd", new PersianCulture());
				}
				if (!string.IsNullOrEmpty(toDate))
				{
					toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					toDate2 = (lCID switch
					{
						1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
						1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
						_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
					}).ToString("yyyyMMdd", new PersianCulture());
				}
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
			string value = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetProductList(fromDate2, toDate2, linkAccPageNum, linkAccPrdGroupId, itemCode, itemKind);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RayvarzProductResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzProductResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RayvarzProductResponseViewModel>((IEnumerable<RayvarzProductResponseViewModel>)list2))
					{
						List<WSspSelectProductWithAccLinkField_Result> list3 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
						int num = 1;
						foreach (RayvarzProductResponseViewModel item in list2)
						{
							if (item == null)
							{
								continue;
							}
							LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
							vmPrd.PrdLinkAccPrdIdStr = item.itemDataId ?? "";
							vmPrd.PrdLinkAccPrdCode = item.itemDataId ?? "";
							vmPrd.PrdName = item.name;
							vmPrd.PrdLatinName = item.nameEN;
							vmPrd.PrdDescription = item.technicalNo;
							int result2 = 0;
							int.TryParse(item.isInactive.ToString(), out result2);
							if (result2 == 1)
							{
								vmPrd.PrdInActive = true;
							}
							vmPrd.PrdKind = 1;
							int result3 = 0;
							int.TryParse(item.isService.ToString(), out result3);
							if (result3 == 1)
							{
								vmPrd.PrdKind = 2;
							}
							if (!string.IsNullOrWhiteSpace(item.salesBulkUnitId))
							{
								vmPrd.Unit = item.salesBulkUnit ?? "";
								item.salesBulkUnitId = item.salesBulkUnitId.Trim(new char[1] { ' ' });
								vmPrd.UnitLinkAccUnitIdStr = item.salesBulkUnitId ?? "";
								if (string.IsNullOrWhiteSpace(vmPrd.Unit))
								{
									vmPrd.Unit = vmPrd.UnitLinkAccUnitIdStr;
								}
							}
							if (!string.IsNullOrWhiteSpace(item.salesPieceUnitId))
							{
								vmPrd.UnitI = item.salesPieceUnit ?? "";
								item.salesPieceUnitId = item.salesPieceUnitId.Trim(new char[1] { ' ' });
								vmPrd.UnitLinkAccUnitIdStrI = item.salesPieceUnitId ?? "";
								if (string.IsNullOrWhiteSpace(vmPrd.UnitI))
								{
									vmPrd.UnitI = vmPrd.UnitLinkAccUnitIdStrI;
								}
							}
							if (item.salesBulkToPieceConvertRate.HasValue)
							{
								vmPrd.PrdUnitIRate = item.salesBulkToPieceConvertRate.GetValueOrDefault();
							}
							if (!string.IsNullOrWhiteSpace(item.unitId))
							{
								vmPrd.UnitII = item.unit ?? "";
								item.unitId = item.unitId.Trim(new char[1] { ' ' });
								vmPrd.UnitLinkAccUnitIdStrII = item.unitId ?? "";
								if (string.IsNullOrWhiteSpace(vmPrd.UnitII))
								{
									vmPrd.UnitII = vmPrd.UnitLinkAccUnitIdStrII;
								}
							}
							if (item.salesBulkToInventoryConvertRate.HasValue)
							{
								vmPrd.PrdUnitIIRate = item.salesBulkToInventoryConvertRate.GetValueOrDefault();
							}
							vmPrd.RowNumber = num;
							WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list3, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
							if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
							{
								vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
							}
							else
							{
								vmPrd.ProductId = 0;
							}
							list.Add(vmPrd);
							num++;
						}
					}
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkProductInfoViewModelObjects;
	}

	public List<LkProductPriceInfoViewModel> GetRayvarzProductPriceList(string itemId = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkProductPriceInfoViewModel> result2 = new List<LkProductPriceInfoViewModel>();
		try
		{
			if (!string.IsNullOrWhiteSpace(itemId))
			{
				result2 = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetPrdPrice(itemId);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public string RayvarzGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in Rayvarz)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						string text2 = "";
						if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
						{
							CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
							if (commonWithIdStrViewModel != null)
							{
								text2 = commonWithIdStrViewModel.Code;
							}
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
						{
							text2 = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							return new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetPrdQuqntity(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr, text2).ToString();
						}
						Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e3);
						return Labels.frmError;
					}
					Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Labels.frmError;
				}
				Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e5);
				return Labels.frmError;
			}
			Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
			ErrorSignal.FromCurrentContext().Raise(e6);
			return Labels.frmError;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return Labels.frmError;
		}
	}

	public LkProductInfoViewModelObjects GetArianSystemProductList(int linkAccPageNum = 0, int recCount = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkProductInfoViewModelObjects lkProductInfoViewModelObjects = new LkProductInfoViewModelObjects();
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
		try
		{
			List<ArianSystemProductResponseViewModel> productList = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetProductList(linkAccPageNum, recCount);
			if (productList != null && Enumerable.Any<ArianSystemProductResponseViewModel>((IEnumerable<ArianSystemProductResponseViewModel>)productList))
			{
				List<WSspSelectProductWithAccLinkField_Result> list2 = Enumerable.ToList<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)_dbLink.WSspSelectProductWithAccLinkField(false, false, true, lCID, result));
				int num = 1;
				foreach (ArianSystemProductResponseViewModel item in productList)
				{
					if (item == null)
					{
						continue;
					}
					LkProductInfoViewModel vmPrd = new LkProductInfoViewModel();
					vmPrd.PrdLinkAccPrdIdStr = item.ServiceGoodsId.GetValueOrDefault().ToString();
					vmPrd.PrdLinkAccPrdCode = item.ServiceGoodsCode ?? "";
					vmPrd.PrdName = item.ServiceGoodsDesc;
					vmPrd.PrdKind = 1;
					if (item.UnitID.GetValueOrDefault() != 0)
					{
						vmPrd.Unit = item.UnitDesc ?? "";
						vmPrd.UnitLinkAccUnitIdStr = item.UnitID.GetValueOrDefault().ToString();
						if (string.IsNullOrWhiteSpace(vmPrd.Unit))
						{
							vmPrd.Unit = vmPrd.UnitLinkAccUnitIdStr;
						}
					}
					vmPrd.RowNumber = num;
					WSspSelectProductWithAccLinkField_Result wSspSelectProductWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectProductWithAccLinkField_Result>((IEnumerable<WSspSelectProductWithAccLinkField_Result>)list2, (Func<WSspSelectProductWithAccLinkField_Result, bool>)((WSspSelectProductWithAccLinkField_Result x) => x.PrdLinkAccPrdIdStr == vmPrd.PrdLinkAccPrdIdStr));
					if (wSspSelectProductWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductWithAccLinkField_Result.PrdLinkAccPrdIdStr))
					{
						vmPrd.ProductId = wSspSelectProductWithAccLinkField_Result.ProductID;
					}
					else
					{
						vmPrd.ProductId = 0;
					}
					list.Add(vmPrd);
					num++;
				}
			}
			lkProductInfoViewModelObjects.lst = list;
			lkProductInfoViewModelObjects.FilteredLst = list;
			lkProductInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkProductInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkProductInfoViewModelObjects;
	}

	[AjaxOnly]
	public string ArianSystemGetPrdQuantity(int prdId, int whId, string linkAccWhId = "")
	{
		string text = "";
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (prdId > 0)
			{
				WSspSelectProductsWithId_Result wSspSelectProductsWithId_Result = Enumerable.FirstOrDefault<WSspSelectProductsWithId_Result>((IEnumerable<WSspSelectProductsWithId_Result>)_db.WSspSelectProductsWithId(prdId, lCID, result));
				if (wSspSelectProductsWithId_Result == null)
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(product)");
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Labels.frmError;
				}
				if (wSspSelectProductsWithId_Result != null && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdIdStr) && !string.IsNullOrWhiteSpace(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode))
				{
					WSspSelectWareHouseWithAccLinkField_Result wSspSelectWareHouseWithAccLinkField_Result = new WSspSelectWareHouseWithAccLinkField_Result();
					List<WSspSelectWareHouseWithAccLinkField_Result> list = Enumerable.ToList<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)_dbLink.WSspSelectWareHouseWithAccLinkField(false, false, false, true, lCID, result));
					if (list != null)
					{
						wSspSelectWareHouseWithAccLinkField_Result = Enumerable.FirstOrDefault<WSspSelectWareHouseWithAccLinkField_Result>((IEnumerable<WSspSelectWareHouseWithAccLinkField_Result>)list, (Func<WSspSelectWareHouseWithAccLinkField_Result, bool>)((WSspSelectWareHouseWithAccLinkField_Result m) => m.WareHouseID == whId));
					}
					if (wSspSelectWareHouseWithAccLinkField_Result != null)
					{
						if (string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses))
						{
							Exception e2 = new Exception(Messages.ErrorNotFound + "(warehouse in ArianSystem)");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						List<CommonWithIdStrViewModel> list2 = JsonConvert.DeserializeObject<List<CommonWithIdStrViewModel>>(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWareHouses);
						string text2 = "";
						if (list2 != null && Enumerable.Any<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2))
						{
							CommonWithIdStrViewModel commonWithIdStrViewModel = Enumerable.FirstOrDefault<CommonWithIdStrViewModel>((IEnumerable<CommonWithIdStrViewModel>)list2, (Func<CommonWithIdStrViewModel, bool>)((CommonWithIdStrViewModel m) => m.Id == linkAccWhId));
							if (commonWithIdStrViewModel != null)
							{
								text2 = commonWithIdStrViewModel.Code;
							}
						}
						if (string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode))
						{
							text2 = wSspSelectWareHouseWithAccLinkField_Result.WrhsLinkAccWhCode;
						}
						if (!string.IsNullOrWhiteSpace(text2))
						{
							return new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetPrdQuqntity(wSspSelectProductsWithId_Result.PrdLinkAccPrdCode, text2).ToString();
						}
						Exception e3 = new Exception(Messages.ErrorNotFound + "(warehouse)");
						ErrorSignal.FromCurrentContext().Raise(e3);
						return Labels.frmError;
					}
					Exception e4 = new Exception(Messages.ErrorNotFound + "(warehouse)");
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Labels.frmError;
				}
				Exception e5 = new Exception(Messages.ErrorNotFound + "(product)");
				ErrorSignal.FromCurrentContext().Raise(e5);
				return Labels.frmError;
			}
			Exception e6 = new Exception(Messages.ErrorNotFound + "(product)");
			ErrorSignal.FromCurrentContext().Raise(e6);
			return Labels.frmError;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return Labels.frmError;
		}
	}

	[DynamicAuthorize(ControllerName = "frmProducts", ActionName = "actManagePrdLinkAcc")]
	public ActionResult ManagePrdLinkAcc(int linkAccSystemId)
	{
		switch (linkAccSystemId)
		{
		case 12:
			GetArpaUserGroup();
			GetArpaItemCategories();
			GetArpaItemIAGroups();
			break;
		case 17:
		{
			GetHamrahanPrdGrouos();
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				string text = hamrahanSetting.HamrahanCurrentFiscalYear ?? "";
				base.ViewBag.HamrahanCurrentFiscalYear = text;
			}
			break;
		}
		case 18:
			GetNoAvaranCapillaryPrdGrouos();
			break;
		case 20:
			GetNilramWarehouse();
			break;
		case 22:
			GetRahkaranInternalSalesWarehouse();
			break;
		}
		GetPrdFgroup();
		GetPrdGroup();
		GetPrdPriceGroup();
		GetPrdCostGroup();
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ManageImportProduct_Read([DataSourceRequest] DataSourceRequest request, int linkAccSystemId, string arpaUserGroupId = "", string itemCategoryCodes = "", string itemCode = "", string fromCreationDate = "", string fromModificationDate = "", int hamrahanPrdGroupId = 0, string fromDate = "", string toDate = "", int fromRec = 0, int recCount = 0, string cookieVal = "", string itemName = "", string linkAccWrhs = "", string linkAccPrdGroupId = "", int linkAccPageNum = 0, string records = "", string itemKind = "")
	{
		//IL_0203: Unknown result type (might be due to invalid IL or missing references)
		List<LkProductInfoViewModel> list = new List<LkProductInfoViewModel>();
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
		case 12:
		{
			ArpaProductInfoViewModelObjects arpaProductList = GetArpaProductList(arpaUserGroupId, itemCategoryCodes, itemCode, fromCreationDate, fromModificationDate);
			if (arpaProductList != null)
			{
				list = arpaProductList.lst;
			}
			break;
		}
		case 17:
		{
			HamrahanProductInfoViewModelObjects hamrahanProductListByGroup = GetHamrahanProductListByGroup(hamrahanPrdGroupId);
			if (hamrahanProductListByGroup != null)
			{
				list = hamrahanProductListByGroup.lst;
			}
			break;
		}
		case 18:
		{
			LkProductInfoViewModelObjects noAvaranCapillaryProductList = GetNoAvaranCapillaryProductList(fromDate, toDate, linkAccPrdGroupId);
			if (noAvaranCapillaryProductList != null)
			{
				list = noAvaranCapillaryProductList.lst;
			}
			break;
		}
		case 19:
		{
			LkProductInfoViewModelObjects rahkaranRetailProductList = GetRahkaranRetailProductList(cookieVal, fromRec, recCount, itemCode, itemName);
			if (rahkaranRetailProductList != null)
			{
				list = rahkaranRetailProductList.lst;
			}
			break;
		}
		case 20:
		{
			LkProductInfoViewModelObjects nilramProductList = GetNilramProductList(itemCode, linkAccWrhs);
			if (nilramProductList != null)
			{
				list = nilramProductList.lst;
			}
			break;
		}
		case 22:
		{
			LkProductInfoViewModelObjects rahkaranInternalSalesProductList = GetRahkaranInternalSalesProductList(fromDate, toDate, linkAccWrhs);
			if (rahkaranInternalSalesProductList != null)
			{
				list = rahkaranInternalSalesProductList.lst;
			}
			break;
		}
		case 23:
		{
			LkProductInfoViewModelObjects rayvarzProductList = GetRayvarzProductList(fromDate, toDate, linkAccPageNum, linkAccPrdGroupId, itemCode, itemKind);
			if (rayvarzProductList != null)
			{
				list = rayvarzProductList.lst;
			}
			break;
		}
		case 25:
		{
			LkProductInfoViewModelObjects arianSystemProductList = GetArianSystemProductList(linkAccPageNum, recCount);
			if (arianSystemProductList != null)
			{
				list = arianSystemProductList.lst;
			}
			break;
		}
		}
		if (list == null)
		{
			list = new List<LkProductInfoViewModel>();
		}
		if (list != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list))
		{
			foreach (LkProductInfoViewModel item4 in list)
			{
				OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
				{
					Row = item4.RowNumber,
					Id = (item4.PrdLinkAccPrdIdStr ?? "0"),
					Selected = (item4.ProductId <= 0)
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
				if (Enumerable.Count<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list) >= num && list[num] != null)
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
	public JsonResult GetManageImportProductList(string records, int linkAccSystemId, string arpaUserGroupId = "", string itemCategoryCodes = "", string itemCode = "", string fromCreationDate = "", string fromModificationDate = "", int hamrahanPrdGroupId = 0, string fromDate = "", string toDate = "", int fromRec = 0, int recCount = 0, string cookieVal = "", string itemName = "", string linkAccWrhs = "", string linkAccPrdGroupId = "", int linkAccPageNum = 0, string itemKind = "")
	{
		//IL_051d: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			switch (linkAccSystemId)
			{
			case 12:
			{
				ArpaProductInfoViewModelObjects arpaProductList = GetArpaProductList(arpaUserGroupId, itemCategoryCodes, itemCode, fromCreationDate, fromModificationDate);
				if (arpaProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst5 = arpaProductList.lst;
				if (lst5 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item9 in lst5)
				{
					OtherSystemSelectedVIiewModel item5 = new OtherSystemSelectedVIiewModel
					{
						Row = item9.RowNumber,
						Id = (item9.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item9.ProductId <= 0)
					};
					list.Add(item5);
				}
				break;
			}
			case 17:
			{
				HamrahanProductInfoViewModelObjects hamrahanProductListByGroup = GetHamrahanProductListByGroup(hamrahanPrdGroupId);
				if (hamrahanProductListByGroup == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst2 = hamrahanProductListByGroup.lst;
				if (lst2 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item10 in lst2)
				{
					OtherSystemSelectedVIiewModel item2 = new OtherSystemSelectedVIiewModel
					{
						Row = item10.RowNumber,
						Id = (item10.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item10.ProductId <= 0)
					};
					list.Add(item2);
				}
				break;
			}
			case 18:
			{
				LkProductInfoViewModelObjects noAvaranCapillaryProductList = GetNoAvaranCapillaryProductList(fromDate, toDate, linkAccPrdGroupId);
				if (noAvaranCapillaryProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst6 = noAvaranCapillaryProductList.lst;
				if (lst6 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item11 in lst6)
				{
					OtherSystemSelectedVIiewModel item6 = new OtherSystemSelectedVIiewModel
					{
						Row = item11.RowNumber,
						Id = (item11.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item11.ProductId <= 0)
					};
					list.Add(item6);
				}
				break;
			}
			case 19:
			{
				LkProductInfoViewModelObjects rahkaranRetailProductList = GetRahkaranRetailProductList(cookieVal, fromRec, recCount, itemCode, itemName);
				if (rahkaranRetailProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst8 = rahkaranRetailProductList.lst;
				if (lst8 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item12 in lst8)
				{
					OtherSystemSelectedVIiewModel item8 = new OtherSystemSelectedVIiewModel
					{
						Row = item12.RowNumber,
						Id = (item12.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item12.ProductId <= 0)
					};
					list.Add(item8);
				}
				break;
			}
			case 20:
			{
				LkProductInfoViewModelObjects nilramProductList = GetNilramProductList(itemCode, linkAccWrhs);
				if (nilramProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst3 = nilramProductList.lst;
				if (lst3 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item13 in lst3)
				{
					OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
					{
						Row = item13.RowNumber,
						Id = (item13.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item13.ProductId <= 0)
					};
					list.Add(item3);
				}
				break;
			}
			case 22:
			{
				LkProductInfoViewModelObjects rahkaranInternalSalesProductList = GetRahkaranInternalSalesProductList(fromDate, toDate, linkAccWrhs);
				if (rahkaranInternalSalesProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst7 = rahkaranInternalSalesProductList.lst;
				if (lst7 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item14 in lst7)
				{
					OtherSystemSelectedVIiewModel item7 = new OtherSystemSelectedVIiewModel
					{
						Row = item14.RowNumber,
						Id = (item14.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item14.ProductId <= 0)
					};
					list.Add(item7);
				}
				break;
			}
			case 23:
			{
				LkProductInfoViewModelObjects rayvarzProductList = GetRayvarzProductList(fromDate, toDate, linkAccPageNum, linkAccPrdGroupId, itemCode, itemKind);
				if (rayvarzProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst4 = rayvarzProductList.lst;
				if (lst4 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item15 in lst4)
				{
					OtherSystemSelectedVIiewModel item4 = new OtherSystemSelectedVIiewModel
					{
						Row = item15.RowNumber,
						Id = (item15.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item15.ProductId <= 0)
					};
					list.Add(item4);
				}
				break;
			}
			case 25:
			{
				LkProductInfoViewModelObjects arianSystemProductList = GetArianSystemProductList(linkAccPageNum, recCount);
				if (arianSystemProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst = arianSystemProductList.lst;
				if (lst == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item16 in lst)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item16.RowNumber,
						Id = (item16.PrdLinkAccPrdIdStr ?? "0"),
						Selected = (item16.ProductId <= 0)
					};
					list.Add(item);
				}
				break;
			}
			}
			if (list != null)
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
					list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
					if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
					{
						foreach (OtherSystemSelectedVIiewModel item17 in list2)
						{
							foreach (OtherSystemSelectedVIiewModel item18 in list)
							{
								if (item18.Row == item17.Row)
								{
									item18.Selected = item17.Selected;
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ManagePrdImportInfo(string records, int linkAccSystemId, int prdFgId = 0, int prdSgId = 0, bool importWithPrice = false, int prdCostGroupId = 0, int prdPriceGroupId = 0, string arpaUserGroupId = "", string itemCategoryCodes = "", string itemCode = "", string fromCreationDate = "", string fromModificationDate = "", string arpaProductPriceLevelsb = "", int hamrahanPrdGroupId = 0, string fromDate = "", string toDate = "", int fromRec = 0, int recCount = 0, string cookieVal = "", string itemName = "", string linkAccWrhs = "", string linkAccPrdGroupId = "", int linkAccPageNum = 0, bool useAccPrdCode = false, bool canSaveDupCrmPrdCode = false, bool useAccPrdCodeInError = false, string itemKind = "")
	{
		//IL_00ec: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		CommonResultViewModel<int> data;
		try
		{
			int? num2 = null;
			if (UserLogin.CurrentUser != null)
			{
				num2 = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string text2 = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short value2 = short.Parse(Financial.Get().Id.ToString());
			short value3 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
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
			List<LkProductInfoViewModel> list3 = new List<LkProductInfoViewModel>();
			List<LkProductPriceInfoViewModel> list4 = new List<LkProductPriceInfoViewModel>();
			switch (linkAccSystemId)
			{
			case 12:
			{
				ArpaProductInfoViewModelObjects arpaProductList = GetArpaProductList(arpaUserGroupId, itemCategoryCodes, itemCode, fromCreationDate, fromModificationDate);
				if (arpaProductList != null)
				{
					List<LkProductInfoViewModel> lst3 = arpaProductList.lst;
					if (lst3 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst3))
						{
							if (list2 != null)
							{
								foreach (OtherSystemSelectedVIiewModel item6 in list2)
								{
									LkProductInfoViewModel lkProductInfoViewModel3 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst3, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item6.Id));
									if (lkProductInfoViewModel3 != null)
									{
										list3.Add(lkProductInfoViewModel3);
									}
								}
							}
						}
						else
						{
							string text9 = Messages.msgErrorRunFunction + " (get list from Apra) ";
							Exception e7 = new Exception(text9);
							ErrorSignal.FromCurrentContext().Raise(e7);
							text = text9;
						}
					}
					else
					{
						string text10 = Messages.msgErrorRunFunction + " (get list from Apra) ";
						Exception e8 = new Exception(text10);
						ErrorSignal.FromCurrentContext().Raise(e8);
						text = text10;
					}
				}
				else
				{
					string text11 = Messages.msgErrorRunFunction + " (get list from Apra) ";
					Exception e9 = new Exception(text11);
					ErrorSignal.FromCurrentContext().Raise(e9);
					text = text11;
				}
				if (!importWithPrice || string.IsNullOrWhiteSpace(arpaProductPriceLevelsb))
				{
					break;
				}
				string[] array = arpaProductPriceLevelsb.Split(new char[1] { '|' });
				if (array == null)
				{
					break;
				}
				string[] array2 = array;
				foreach (string text12 in array2)
				{
					if (!string.IsNullOrWhiteSpace(text12))
					{
						List<LkProductPriceInfoViewModel> list6 = new List<LkProductPriceInfoViewModel>();
						list6 = GetArpaProductPriceList(text12);
						if (list6 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list6))
						{
							list4.AddRange(list6);
						}
					}
				}
				break;
			}
			case 17:
			{
				HamrahanProductInfoViewModelObjects hamrahanProductListByGroup = GetHamrahanProductListByGroup(hamrahanPrdGroupId);
				if (hamrahanProductListByGroup != null)
				{
					List<LkProductInfoViewModel> lst4 = hamrahanProductListByGroup.lst;
					if (lst4 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst4))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item5 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel4 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst4, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item5.Id));
								if (lkProductInfoViewModel4 != null)
								{
									list3.Add(lkProductInfoViewModel4);
								}
							}
						}
						else
						{
							string text13 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
							Exception e10 = new Exception(text13);
							ErrorSignal.FromCurrentContext().Raise(e10);
							text = text13;
						}
					}
					else
					{
						string text14 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
						Exception e11 = new Exception(text14);
						ErrorSignal.FromCurrentContext().Raise(e11);
						text = text14;
					}
				}
				else
				{
					string text15 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
					Exception e12 = new Exception(text15);
					ErrorSignal.FromCurrentContext().Raise(e12);
					text = text15;
				}
				break;
			}
			case 18:
			{
				LkProductInfoViewModelObjects noAvaranCapillaryProductList = GetNoAvaranCapillaryProductList(fromDate, toDate, linkAccPrdGroupId);
				if (noAvaranCapillaryProductList != null)
				{
					List<LkProductInfoViewModel> lst6 = noAvaranCapillaryProductList.lst;
					if (lst6 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst6))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item3 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel6 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst6, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item3.Id));
								if (lkProductInfoViewModel6 != null)
								{
									list3.Add(lkProductInfoViewModel6);
									if (lkProductInfoViewModel6.Price != 0m)
									{
										LkProductPriceInfoViewModel lkProductPriceInfoViewModel = new LkProductPriceInfoViewModel();
										lkProductPriceInfoViewModel.Price = lkProductInfoViewModel6.Price;
										lkProductPriceInfoViewModel.PrdLinkAccPrdCode = lkProductInfoViewModel6.PrdLinkAccPrdIdStr;
										lkProductPriceInfoViewModel.PrdLinkAccPrdIdStr = lkProductInfoViewModel6.PrdLinkAccPrdIdStr;
										lkProductPriceInfoViewModel.PrdId = lkProductInfoViewModel6.ProductId;
										list4.Add(lkProductPriceInfoViewModel);
									}
									if (lkProductInfoViewModel6.PriceList != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)lkProductInfoViewModel6.PriceList))
									{
										list4.AddRange(lkProductInfoViewModel6.PriceList);
									}
								}
							}
						}
						else
						{
							string text19 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e16 = new Exception(text19);
							ErrorSignal.FromCurrentContext().Raise(e16);
							text = text19;
						}
					}
					else
					{
						string text20 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e17 = new Exception(text20);
						ErrorSignal.FromCurrentContext().Raise(e17);
						text = text20;
					}
				}
				else
				{
					string text21 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e18 = new Exception(text21);
					ErrorSignal.FromCurrentContext().Raise(e18);
					text = text21;
				}
				break;
			}
			case 19:
			{
				LkProductInfoViewModelObjects rahkaranRetailProductList = GetRahkaranRetailProductList(cookieVal, fromRec, recCount, itemCode, itemName);
				if (rahkaranRetailProductList != null)
				{
					List<LkProductInfoViewModel> lst7 = rahkaranRetailProductList.lst;
					if (lst7 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst7))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item2 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel7 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst7, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item2.Id));
								if (lkProductInfoViewModel7 != null)
								{
									list3.Add(lkProductInfoViewModel7);
									if (lkProductInfoViewModel7.Price != 0m)
									{
										LkProductPriceInfoViewModel lkProductPriceInfoViewModel2 = new LkProductPriceInfoViewModel();
										lkProductPriceInfoViewModel2.Price = lkProductInfoViewModel7.Price;
										lkProductPriceInfoViewModel2.Dicount = lkProductInfoViewModel7.Dicount;
										lkProductPriceInfoViewModel2.DicountPercent = lkProductInfoViewModel7.DicountPercent;
										lkProductPriceInfoViewModel2.PrdLinkAccPrdCode = lkProductInfoViewModel7.PrdLinkAccPrdIdStr;
										lkProductPriceInfoViewModel2.PrdLinkAccPrdIdStr = lkProductInfoViewModel7.PrdLinkAccPrdIdStr;
										lkProductPriceInfoViewModel2.PrdId = lkProductInfoViewModel7.ProductId;
										list4.Add(lkProductPriceInfoViewModel2);
									}
								}
							}
						}
						else
						{
							string text22 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
							Exception e19 = new Exception(text22);
							ErrorSignal.FromCurrentContext().Raise(e19);
							text = text22;
						}
					}
					else
					{
						string text23 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
						Exception e20 = new Exception(text23);
						ErrorSignal.FromCurrentContext().Raise(e20);
						text = text23;
					}
				}
				else
				{
					string text24 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
					Exception e21 = new Exception(text24);
					ErrorSignal.FromCurrentContext().Raise(e21);
					text = text24;
				}
				break;
			}
			case 20:
			{
				LkProductInfoViewModelObjects nilramProductList = GetNilramProductList(itemCode, linkAccWrhs);
				if (nilramProductList != null)
				{
					List<LkProductInfoViewModel> lst5 = nilramProductList.lst;
					if (lst5 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst5))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item4 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel5 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst5, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item4.Id));
								if (lkProductInfoViewModel5 == null)
								{
									continue;
								}
								list3.Add(lkProductInfoViewModel5);
								if (!importWithPrice)
								{
									continue;
								}
								List<LkProductPriceInfoViewModel> list7 = new List<LkProductPriceInfoViewModel>();
								list7 = GetNilramProductPriceList(lkProductInfoViewModel5.PrdLinkAccPrdCode ?? "");
								if (list7 == null || !Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list7))
								{
									continue;
								}
								foreach (LkProductPriceInfoViewModel item9 in list7)
								{
									item9.PrdLinkAccPrdIdStr = lkProductInfoViewModel5.PrdLinkAccPrdIdStr;
								}
								list4.AddRange(list7);
							}
						}
						else
						{
							string text16 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
							Exception e13 = new Exception(text16);
							ErrorSignal.FromCurrentContext().Raise(e13);
							text = text16;
						}
					}
					else
					{
						string text17 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
						Exception e14 = new Exception(text17);
						ErrorSignal.FromCurrentContext().Raise(e14);
						text = text17;
					}
				}
				else
				{
					string text18 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
					Exception e15 = new Exception(text18);
					ErrorSignal.FromCurrentContext().Raise(e15);
					text = text18;
				}
				break;
			}
			case 22:
			{
				LkProductInfoViewModelObjects rahkaranInternalSalesProductList = GetRahkaranInternalSalesProductList(fromDate, toDate, linkAccWrhs);
				if (rahkaranInternalSalesProductList != null)
				{
					List<LkProductInfoViewModel> lst8 = rahkaranInternalSalesProductList.lst;
					if (lst8 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst8))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel8 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst8, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item.Id));
								if (lkProductInfoViewModel8 != null)
								{
									list3.Add(lkProductInfoViewModel8);
								}
							}
						}
						else
						{
							string text25 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
							Exception e22 = new Exception(text25);
							ErrorSignal.FromCurrentContext().Raise(e22);
							text = text25;
						}
					}
					else
					{
						string text26 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
						Exception e23 = new Exception(text26);
						ErrorSignal.FromCurrentContext().Raise(e23);
						text = text26;
					}
				}
				else
				{
					string text27 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
					Exception e24 = new Exception(text27);
					ErrorSignal.FromCurrentContext().Raise(e24);
					text = text27;
				}
				break;
			}
			case 23:
			{
				LkProductInfoViewModelObjects rayvarzProductList = GetRayvarzProductList(fromDate, toDate, linkAccPageNum, linkAccPrdGroupId, itemCode, itemKind);
				if (rayvarzProductList != null)
				{
					List<LkProductInfoViewModel> lst2 = rayvarzProductList.lst;
					if (lst2 != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst2))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item7 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel2 = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst2, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item7.Id));
								if (lkProductInfoViewModel2 == null)
								{
									continue;
								}
								list3.Add(lkProductInfoViewModel2);
								if (!importWithPrice)
								{
									continue;
								}
								List<LkProductPriceInfoViewModel> list5 = new List<LkProductPriceInfoViewModel>();
								list5 = GetRayvarzProductPriceList(lkProductInfoViewModel2.PrdLinkAccPrdIdStr ?? "");
								if (list5 == null || !Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list5))
								{
									continue;
								}
								foreach (LkProductPriceInfoViewModel item10 in list5)
								{
									item10.PrdLinkAccPrdIdStr = lkProductInfoViewModel2.PrdLinkAccPrdIdStr;
									item10.PrdLinkAccPrdCode = lkProductInfoViewModel2.PrdLinkAccPrdCode;
								}
								list4.AddRange(list5);
							}
						}
						else
						{
							string text6 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
							Exception e4 = new Exception(text6);
							ErrorSignal.FromCurrentContext().Raise(e4);
							text = text6;
						}
					}
					else
					{
						string text7 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
						Exception e5 = new Exception(text7);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text7;
					}
				}
				else
				{
					string text8 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
					Exception e6 = new Exception(text8);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text8;
				}
				break;
			}
			case 25:
			{
				LkProductInfoViewModelObjects arianSystemProductList = GetArianSystemProductList(linkAccPageNum, recCount);
				if (arianSystemProductList != null)
				{
					List<LkProductInfoViewModel> lst = arianSystemProductList.lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item8 in list2)
							{
								LkProductInfoViewModel lkProductInfoViewModel = Enumerable.FirstOrDefault<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst, (Func<LkProductInfoViewModel, bool>)((LkProductInfoViewModel x) => x.PrdLinkAccPrdIdStr == item8.Id));
								if (lkProductInfoViewModel != null)
								{
									list3.Add(lkProductInfoViewModel);
								}
							}
						}
						else
						{
							string text3 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
							Exception e = new Exception(text3);
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text3;
						}
					}
					else
					{
						string text4 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
						Exception e2 = new Exception(text4);
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = text4;
					}
				}
				else
				{
					string text5 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
					Exception e3 = new Exception(text5);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = text5;
				}
				break;
			}
			}
			List<LkProductPriceInfoViewModel> list8 = new List<LkProductPriceInfoViewModel>();
			if (importWithPrice && list4 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list4) && list3 != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list3))
			{
				foreach (LkProductInfoViewModel prditem in list3)
				{
					List<LkProductPriceInfoViewModel> list9 = Enumerable.ToList<LkProductPriceInfoViewModel>(Enumerable.Where<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list4, (Func<LkProductPriceInfoViewModel, bool>)((LkProductPriceInfoViewModel m) => m.PrdLinkAccPrdIdStr == prditem.PrdLinkAccPrdIdStr)));
					if (list9 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list9))
					{
						list8.AddRange(list9);
					}
				}
			}
			if (list3 != null && Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list3))
			{
				text = "";
				int num3;
				int num4 = (num3 = Enumerable.Count<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list3));
				_ = new long[num4];
				int num5 = 100;
				int num6 = num4 / num5;
				int num7 = num4 % num5;
				int num8 = 0;
				int num9 = num5;
				if (num7 != 0)
				{
					num6++;
				}
				for (int j = 0; j < num6; j++)
				{
					if (j == num6 - 1 && num7 != 0)
					{
						num9 = num7;
					}
					List<LkProductInfoViewModel> list10 = new List<LkProductInfoViewModel>();
					for (int k = 0; k < num9; k++)
					{
						num8 = j * num5 + k;
						list10.Add(list3[num8]);
					}
					if (list10 == null || !Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)list10))
					{
						continue;
					}
					string text28 = JsonConvert.SerializeObject(list10);
					string text29 = "";
					if (list8 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list8))
					{
						List<LkProductPriceInfoViewModel> list11 = new List<LkProductPriceInfoViewModel>();
						foreach (LkProductInfoViewModel linkaccPrd in list10)
						{
							List<LkProductPriceInfoViewModel> list12 = Enumerable.ToList<LkProductPriceInfoViewModel>(Enumerable.Where<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list8, (Func<LkProductPriceInfoViewModel, bool>)((LkProductPriceInfoViewModel m) => (m.PrdLinkAccPrdIdStr ?? "") == (linkaccPrd.PrdLinkAccPrdIdStr ?? "") && (m.PrdLinkAccPrdCode ?? "") == (linkaccPrd.PrdLinkAccPrdCode ?? ""))));
							if (list12 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list12))
							{
								list11.AddRange(list12);
							}
						}
						if (list11 != null && Enumerable.Any<LkProductPriceInfoViewModel>((IEnumerable<LkProductPriceInfoViewModel>)list11))
						{
							text29 = JsonConvert.SerializeObject(list11);
						}
					}
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					_dbLink.CRMspLkWSInsertUpdateProducts(linkAccSystemId, text28, text29, prdFgId, prdSgId, importWithPrice, prdPriceGroupId, prdCostGroupId, userId, value3, value2, id, value, text2, appType, result, objectParameter, "12,17,18,19,20,22,23,25", num2, useAccPrdCode: useAccPrdCode, canDupPrdCode: canSaveDupCrmPrdCode, useAccPrdCodeInError: useAccPrdCodeInError);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
							continue;
						}
						int num10 = num8 * 100 / num3;
						if (num10 >= 100)
						{
							num10 = 100;
						}
						ProgressHub.SendMessage("ok", num10, userId);
					}
					else
					{
						int num11 = num8 * 100 / num3;
						if (num11 >= 100)
						{
							num11 = 100;
						}
						ProgressHub.SendMessage("ok", num11, userId);
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
		catch (Exception e25)
		{
			ErrorSignal.FromCurrentContext().Raise(e25);
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ManageExportProduct_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		return Json(((IEnumerable)SelectProducts(fDate, tDate, value, fgId, sgId)).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetManageExportProductList(string records, string fDate = "", string tDate = "", string value = "", int fgId = 0, int sgId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkWSSelectProduct_Result item in SelectProducts(fDate, tDate, value, fgId, sgId))
			{
				OtherSystemSelectedViewModel otherSystemSelectedViewModel = new OtherSystemSelectedViewModel();
				otherSystemSelectedViewModel.Row = item.RowNumber.GetValueOrDefault();
				otherSystemSelectedViewModel.Id = item.ProductID;
				if (string.IsNullOrWhiteSpace(item.PrdLinkAccPrdIdStr))
				{
					otherSystemSelectedViewModel.Selected = true;
				}
				else
				{
					otherSystemSelectedViewModel.Selected = false;
				}
				list.Add(otherSystemSelectedViewModel);
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ManagePrdExportInfo(string records, string linkAccPrdGroupId, string linkAccPrdGroupAccId)
	{
		//IL_00fe: Unknown result type (might be due to invalid IL or missing references)
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
			int result2 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			if (result2 == 12)
			{
				_ = Labels.Arpa;
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			text = "";
			int num = 0;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			text = "";
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					num = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num2 = 0;
					foreach (OtherSystemSelectedViewModel item in list2)
					{
						string text2 = "";
						if (result2 == 12)
						{
							text2 = ArpaActSendToAcc(item.Id, linkAccPrdGroupId, linkAccPrdGroupAccId);
						}
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

	[DynamicAuthorize(ControllerName = "frmManagePrdLinkAcc", ActionName = "actLinkPrdWithAcc")]
	public ActionResult LinkedProductLinkAcc(int linkAccSystemId)
	{
		string text = "";
		switch (linkAccSystemId)
		{
		case 12:
		{
			CRMIdeal.Classes.Helper.OtherSystems.ArpaSettingViewModel arpaSetting = CRMIdeal.Classes.Helper.OtherSystems.GetArpaSetting();
			if (arpaSetting != null)
			{
				text = arpaSetting.PrdLinkedField;
			}
			break;
		}
		case 17:
		{
			CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
			if (hamrahanSetting != null)
			{
				text = hamrahanSetting.PrdLinkedField;
			}
			break;
		}
		case 18:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				text = noAvaranCapillarySetting.PrdLinkedField;
			}
			break;
		}
		case 19:
		{
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
			if (rahkaranRetailSetting != null)
			{
				text = rahkaranRetailSetting.PrdLinkedField;
			}
			break;
		}
		case 20:
		{
			CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
			if (nilramSetting != null)
			{
				text = nilramSetting.PrdLinkedField;
			}
			break;
		}
		case 22:
			text = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider().PrdLinkedField;
			break;
		case 23:
			text = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().PrdLinkedField;
			break;
		case 25:
			text = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().PrdLinkedField;
			break;
		}
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		base.ViewBag.SyncField = text;
		return View();
	}

	[HttpPost]
	public JsonResult ActLinkedProductAcc(string syncField, int mode, string cookieVal = "")
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
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			List<LinkedProductWithAccViewModel> list = new List<LinkedProductWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actLinkPrdWithAcc", UserLogin.CurrentUser))
			{
				text3 = text3 + Messages.ErrorNotAccess + "<br>";
				num++;
			}
			if (string.IsNullOrWhiteSpace(syncField))
			{
				text3 = text3 + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.OtherSystemsLinkedField) + "<br>";
				num++;
			}
			int result2 = 0;
			string text4 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			text4 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			switch (result2)
			{
			case 12:
			{
				ArpaProductInfoViewModelObjects arpaProductList = GetArpaProductList();
				if (arpaProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst2 = arpaProductList.lst;
				if (lst2 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item10 in lst2)
				{
					LinkedProductWithAccViewModel item2 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item10.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item10.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item10.PrdName ?? "")
					};
					list.Add(item2);
				}
				break;
			}
			case 17:
			{
				HamrahanProductInfoViewModelObjects hamrahanProductList = GetHamrahanProductList();
				if (hamrahanProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst7 = hamrahanProductList.lst;
				if (lst7 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item11 in lst7)
				{
					LinkedProductWithAccViewModel item7 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item11.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item11.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item11.PrdName ?? "")
					};
					list.Add(item7);
				}
				break;
			}
			case 18:
			{
				LkProductInfoViewModelObjects noAvaranCapillaryProductList = GetNoAvaranCapillaryProductList();
				if (noAvaranCapillaryProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst4 = noAvaranCapillaryProductList.lst;
				if (lst4 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item12 in lst4)
				{
					LinkedProductWithAccViewModel item4 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item12.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item12.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item12.PrdName ?? "")
					};
					list.Add(item4);
				}
				break;
			}
			case 19:
			{
				LkProductInfoViewModelObjects rahkaranRetailProductList = GetRahkaranRetailProductList(cookieVal, 0, 0, "", "", getPrice: false);
				if (rahkaranRetailProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst6 = rahkaranRetailProductList.lst;
				if (lst6 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item13 in lst6)
				{
					LinkedProductWithAccViewModel item6 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item13.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item13.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item13.PrdName ?? "")
					};
					list.Add(item6);
				}
				break;
			}
			case 20:
			{
				LkProductInfoViewModelObjects nilramProductList = GetNilramProductList();
				if (nilramProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst8 = nilramProductList.lst;
				if (lst8 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item14 in lst8)
				{
					LinkedProductWithAccViewModel item8 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = 0,
						PrdLinkAccPrdCode = item14.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item14.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item14.PrdName ?? "")
					};
					list.Add(item8);
				}
				break;
			}
			case 22:
			{
				LkProductInfoViewModelObjects rahkaranInternalSalesProductList = GetRahkaranInternalSalesProductList();
				if (rahkaranInternalSalesProductList == null)
				{
					break;
				}
				List<LkProductInfoViewModel> lst5 = rahkaranInternalSalesProductList.lst;
				if (lst5 == null)
				{
					break;
				}
				foreach (LkProductInfoViewModel item15 in lst5)
				{
					LinkedProductWithAccViewModel item5 = new LinkedProductWithAccViewModel
					{
						PrdLinkAccPrdId = item15.PrdLinkAccPrdId,
						PrdLinkAccPrdCode = item15.PrdLinkAccPrdCode,
						PrdLinkAccPrdIdStr = item15.PrdLinkAccPrdIdStr,
						PrdLinkAccPrdGroupIdStr = "",
						PrdName = (item15.PrdName ?? "")
					};
					list.Add(item5);
				}
				break;
			}
			case 23:
			{
				int num3 = 0;
				while (num3 >= 0)
				{
					LkProductInfoViewModelObjects rayvarzProductList = GetRayvarzProductList("", "", num3);
					if (rayvarzProductList != null)
					{
						List<LkProductInfoViewModel> lst3 = rayvarzProductList.lst;
						if (lst3 != null)
						{
							if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst3))
							{
								foreach (LkProductInfoViewModel item16 in lst3)
								{
									LinkedProductWithAccViewModel item3 = new LinkedProductWithAccViewModel
									{
										PrdLinkAccPrdId = item16.PrdLinkAccPrdId,
										PrdLinkAccPrdCode = item16.PrdLinkAccPrdCode,
										PrdLinkAccPrdIdStr = item16.PrdLinkAccPrdIdStr,
										PrdLinkAccPrdGroupIdStr = "",
										PrdName = (item16.PrdName ?? "")
									};
									list.Add(item3);
								}
								num3++;
							}
							else
							{
								num3 = -1;
							}
						}
						else
						{
							num3 = -1;
						}
					}
					else
					{
						num3 = -1;
					}
				}
				break;
			}
			case 25:
			{
				int num2 = 0;
				while (num2 >= 0)
				{
					LkProductInfoViewModelObjects arianSystemProductList = GetArianSystemProductList(num2, 2000);
					if (arianSystemProductList != null)
					{
						List<LkProductInfoViewModel> lst = arianSystemProductList.lst;
						if (lst != null)
						{
							if (Enumerable.Any<LkProductInfoViewModel>((IEnumerable<LkProductInfoViewModel>)lst))
							{
								foreach (LkProductInfoViewModel item17 in lst)
								{
									LinkedProductWithAccViewModel item = new LinkedProductWithAccViewModel
									{
										PrdLinkAccPrdId = item17.PrdLinkAccPrdId,
										PrdLinkAccPrdCode = item17.PrdLinkAccPrdCode,
										PrdLinkAccPrdIdStr = item17.PrdLinkAccPrdIdStr,
										PrdLinkAccPrdGroupIdStr = "",
										PrdName = (item17.PrdName ?? "")
									};
									list.Add(item);
								}
								num2++;
							}
							else
							{
								num2 = -1;
							}
						}
						else
						{
							num2 = -1;
						}
					}
					else
					{
						num2 = -1;
					}
				}
				break;
			}
			}
			if (list == null || !Enumerable.Any<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListPrdInLinkAccIsEmpty, text4) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text5 = "";
				text = "";
				List<CRMspLkWSLinkedProduct_Result> list2 = new List<CRMspLkWSLinkedProduct_Result>();
				int count = list.Count;
				int num4 = 1000;
				int num5 = count / num4;
				if (count % num4 != 0)
				{
					num5++;
				}
				for (int i = 0; i <= num5; i++)
				{
					List<LinkedProductWithAccViewModel> list3 = new List<LinkedProductWithAccViewModel>();
					for (int j = i * num4; j < i * num4 + num4 && j < count; j++)
					{
						LinkedProductWithAccViewModel item9 = new LinkedProductWithAccViewModel
						{
							PrdLinkAccPrdId = list[j].PrdLinkAccPrdId,
							PrdLinkAccPrdCode = list[j].PrdLinkAccPrdCode,
							PrdLinkAccPrdIdStr = list[j].PrdLinkAccPrdIdStr,
							PrdLinkAccPrdGroupIdStr = list[j].PrdLinkAccPrdGroupIdStr,
							PrdName = (list[j].PrdName ?? "")
						};
						list3.Add(item9);
					}
					if (Enumerable.Any<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list3))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedProductWithAccViewModel>((IEnumerable<LinkedProductWithAccViewModel>)list3));
						List<CRMspLkWSLinkedProduct_Result> list4 = Enumerable.ToList<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)_dbLink.CRMspLkWSLinkedProduct(result2, itemJson, syncField, mode, lCID, result));
						if (list4 != null && Enumerable.Any<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)list4))
						{
							list2.AddRange(list4);
						}
					}
				}
				if (list2 != null && Enumerable.Any<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)list2))
				{
					list2 = Enumerable.ToList<CRMspLkWSLinkedProduct_Result>(Enumerable.Distinct<CRMspLkWSLinkedProduct_Result>(Enumerable.Where<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)list2, (Func<CRMspLkWSLinkedProduct_Result, bool>)((CRMspLkWSLinkedProduct_Result m) => (m.PrdLinkAccPrdIdStr ?? "") == "" || m.Type.GetValueOrDefault() == 1))));
					if (list2 != null && Enumerable.Any<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)list2))
					{
						text = "error";
						text5 = GetFileLinkedProductAcc(list2);
					}
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
			CRMIdeal.Classes.Helper.User.UpdateUsersMobBaseInfo("WSProducts");
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

	public string GetFileLinkedProductAcc(List<CRMspLkWSLinkedProduct_Result> res)
	{
		//IL_04bb: Unknown result type (might be due to invalid IL or missing references)
		//IL_04d6: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			string text2 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (res != null && Enumerable.Any<CRMspLkWSLinkedProduct_Result>((IEnumerable<CRMspLkWSLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkWSLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
					num++;
					string value = "";
					if (re.Type.HasValue)
					{
						if (re.Type.GetValueOrDefault() == 1)
						{
							value = text2;
						}
						else if (re.Type.GetValueOrDefault() == 2)
						{
							value = "CRM";
						}
					}
					excelWorksheet.Cells[num2, num].Value = value;
					string value2 = "";
					int result3 = 0;
					int.TryParse(re.ErrorType.ToString(), out result3);
					switch (result3)
					{
					case 0:
						value2 = Messages.msgErrorPrdNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupPrdLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupPrdCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorPrdNotInLinkAcc, text2);
						break;
					}
					num++;
					excelWorksheet.Cells[num2, num].Value = value2;
				}
				string text3 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\ReportLinkAccLinked\\" + UserLogin.CurrentUser.UserId;
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
					text = Configuration.HostTempFilesPath + "/ReportLinkAccLinked/" + userId + "/" + text4;
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
	public JsonResult DeletePrdImportedInfo(string records)
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
			new List<LinkedProductWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManagePrdLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkDeleteLinkedProduct_Result> list3 = Enumerable.ToList<CRMspLkDeleteLinkedProduct_Result>((IEnumerable<CRMspLkDeleteLinkedProduct_Result>)_dbLink.CRMspLkDeleteLinkedProduct(result2, text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkDeleteLinkedProduct_Result>((IEnumerable<CRMspLkDeleteLinkedProduct_Result>)list3))
				{
					text = "error";
					text5 = GetFileNotDeletedPrdImportedInfo(list3);
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

	public string GetFileNotDeletedPrdImportedInfo(List<CRMspLkDeleteLinkedProduct_Result> res)
	{
		//IL_0368: Unknown result type (might be due to invalid IL or missing references)
		//IL_0383: Unknown result type (might be due to invalid IL or missing references)
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
			int result2 = 0;
			string text2 = "";
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
			}
			text2 = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			if (res != null && Enumerable.Any<CRMspLkDeleteLinkedProduct_Result>((IEnumerable<CRMspLkDeleteLinkedProduct_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListPrdName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListPrdLinkAccPrdCode + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkDeleteLinkedProduct_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdCode;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.PrdLinkAccPrdCode ?? "";
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

	[AjaxOnly]
	public string LinkAccGetPrdQuantity(int linkAccSystemId, int prdId, int whId, string linkAccWhId = "", string tracing = "", string sefaresh = "", int prdPriceGroupId = 0, int currUserId = 0)
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
			switch (linkAccSystemId)
			{
			case 12:
				text = ArpaGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 17:
				text = HamrahanGetPrdQuantity(prdId, whId, linkAccWhId, prdPriceGroupId, currUserId);
				break;
			case 18:
				text = NoAvaranCapillaryGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 19:
				text = RahkaranRetailGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 8:
				text = ShygunGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 20:
				text = NilramGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 22:
				text = RahkaranInternalSalesGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 23:
				text = RayvarzGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			case 25:
				text = ArianSystemGetPrdQuantity(prdId, whId, linkAccWhId);
				break;
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				text = "0";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Labels.frmError;
		}
		return text;
	}

	[AjaxOnly]
	public JsonResult GetPrdLinkAccSetting(int linkAccSystemId, int linkAccSettingDBId, int linkAccSettingId, string objectType, string partTitle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectLinkAccSettingBySystemId_Result> data = new List<CRMspSelectLinkAccSettingBySystemId_Result>();
		try
		{
			data = CRMIdeal.Classes.Helper.OtherSystems.SelectLinkAccSettingBySystemId(linkAccSystemId, linkAccSettingDBId, linkAccSettingId, objectType, partTitle);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
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
		base.Dispose(disposing);
	}
}
