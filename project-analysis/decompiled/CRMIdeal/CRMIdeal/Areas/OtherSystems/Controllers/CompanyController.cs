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
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
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
using Microsoft.CSharp.RuntimeBinder;
using NR.Shygun.WS.ClientModel;
using NR.Shygun.WS.ClientModel.GeneralModels;
using NR.Shygun.WS.ClientSDK;
using NR.Shygun.WS.FilterDomains;
using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace CRMIdeal.Areas.OtherSystems.Controllers;

public class CompanyController : Controller
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
	private sealed class _003C_003Ec__DisplayClass123_0
	{
		public int defSettingId;

		public int currLangID;

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__16(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__17(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__18(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__19(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__20(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__21(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__22(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__23(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__24(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__25(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__26(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__27(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__28(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__29(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__30(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__31(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__32(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__33(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__34(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__35(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__36(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__37(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__38(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__39(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__40(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__41(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__42(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__43(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__44(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__45(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__46(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__47(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__48(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__49(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__50(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__51(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__52(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__53(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__54(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__55(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId != currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__56(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}

		internal bool _003CSelectCompanyQuickRegisterDefSetting_003Eb__57(CommonMultiLanguageViewModel c)
		{
			return c.LanguageId == currLangID;
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass35_0
	{
		public CRMspSelectCompanyById_Result cmp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass39_0
	{
		public CRMspSelectCompanyById_Result cmp;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass56_0
	{
		public int cmpId;
	}

	[CompilerGenerated]
	private static class _003C_003Eo__191
	{
		public static CallSite<Func<CallSite, object, object, object>> _003C_003Ep__0;

		public static CallSite<Func<CallSite, object, bool>> _003C_003Ep__1;

		public static CallSite<Func<CallSite, Type, int, object, CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider.SendCompany>> _003C_003Ep__2;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMLinkSpEntities _dbLink = new CRMLinkSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public int CrmCompanyKind_Legal;

	public int CrmCompanyKind_Real = 1;

	public int _PayvastCompany_RealId;

	public int _PayvastCompany_LegalId = 1;

	[JsonIgnore]
	private string JsonRender;

	private string lastShygunIIJobNumber = "";

	private int lastShygunIICmpTypeId;

	public ActionResult SepCmpSendToAcc(int cmpId, int position = 0)
	{
		string formName = "frmCompanyI";
		string actionName = "actSendToAcc";
		if (position == 1)
		{
			formName = "frmCmpLinkAccDetails";
			actionName = "actAddLinkCmpToAcc";
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
	public string SepActSendToAcc(int cmpId, int position = 0, int linkAccSettingDBId = 0, bool useCrmCmpCode = false)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			string formName = "frmCompanyI";
			string actionName = "actSendToAcc";
			if (position == 1)
			{
				formName = "frmCmpLinkAccDetails";
				actionName = "actAddLinkCmpToAcc";
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				if (CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId) != null)
				{
					ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("accCode", "");
					_dbLink.CRMspLkSepInsertUpdateCompany(cmpId, UserLogin.CurrentUser.UserId, Configuration.AppType, insertedId, objectParameter2, objectParameter, 0, linkAccSettingDBId, useCrmCmpCode);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public ActionResult SepImportCompany()
	{
		GetCmpReferUser();
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult SepCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkSepSelectCompanyFromSep_Result> enumerable = new List<CRMspLkSepSelectCompanyFromSep_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkSepSelectCompanyFromSep_Result>((IEnumerable<CRMspLkSepSelectCompanyFromSep_Result>)_dbLink.CRMspLkSepSelectCompanyFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepImportInfo(string records, int cmpReferUserId, int pageNumber, string fDate = "", string tDate = "", string value = "", bool updateCompnay = false, bool insertFromReceipt = false, bool insertFromPayment = false, int linkAccSettingDBId = 0, int pagesCnt = 0)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepImportInfoAsync(records, cmpReferUserId, pageNumber, fDate, tDate, value, updateCompnay, insertFromReceipt, insertFromPayment, linkAccSettingDBId, pagesCnt, indx);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepImportInfoAsync(string records, int cmpReferUserId, int pageNumber, string fDate = "", string tDate = "", string value = "", bool updateCompnay = false, bool insertFromReceipt = false, bool insertFromPayment = false, int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0)
	{
		//IL_0214: Unknown result type (might be due to invalid IL or missing references)
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
			short value3 = short.Parse(Financial.Get().Id.ToString());
			short value4 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
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
			if ((insertFromReceipt || insertFromPayment) && !VersionBuyer.MoneyBag)
			{
				num = 0;
				text = string.Format(Messages.VersionBuyModuleName, Labels.ModuleCmpMoneyBag);
				num2 = 0;
				num3++;
				int percent = 100;
				string message = text;
				ThreadHub.SetThreadResult(indx, percent, message, false);
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
			if (list != null && string.IsNullOrWhiteSpace(text))
			{
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					num2 = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
					num3 = 0;
					new List<CRMspLkSepWSExportOrder_Result>();
					{
						foreach (OtherSystemSelectedViewModel item in list)
						{
							ObjectParameter insertedCmpId = new ObjectParameter("insertedCmpId", 0);
							ObjectParameter insertedPrsId = new ObjectParameter("insertedPrsId", 0);
							ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
							cRMLinkSpEntities.CRMspLkSepInsertUpdateCompanyFromSep(item.Id, userId, value4, value3, value2, registerDatePersian, appType, result, insertedCmpId, insertedPrsId, objectParameter, cmpReferUserId, updateCompnay, insertFromReceipt, insertFromPayment, linkAccSettingDBId, centerId);
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
							string message2 = text;
							if (num5 >= 100)
							{
								num5 = 100;
								message2 = text;
								isDone = false;
							}
							ThreadHub.SetThreadResult(indx, num5, message2, isDone);
						}
						return;
					}
				}
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent2 = 100;
				string message3 = text;
				ThreadHub.SetThreadResult(indx, percent2, message3, false);
			}
			else if (string.IsNullOrWhiteSpace(text))
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
				num3++;
				int percent3 = 100;
				string message4 = text;
				ThreadHub.SetThreadResult(indx, percent3, message4, false);
			}
		}
		catch (Exception)
		{
			num = 0;
			num3++;
			int percent4 = 100;
			string msgErrorRunFunction = Messages.msgErrorRunFunction;
			ThreadHub.SetThreadResult(indx, percent4, msgErrorRunFunction, true);
		}
		finally
		{
			cRMLinkSpEntities?.Dispose();
		}
	}

	[AjaxOnly]
	public JsonResult GetSepImportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0)
	{
		//IL_0229: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepSelectCompanyFromSep_Result item2 in Enumerable.ToList<CRMspLkSepSelectCompanyFromSep_Result>((IEnumerable<CRMspLkSepSelectCompanyFromSep_Result>)_dbLink.CRMspLkSepSelectCompanyFromSep((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.PartyId.GetValueOrDefault(),
					Selected = !item2.CompanyId.HasValue
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult SepExportCompany()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult SepExportCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkSepSelectCompany_Result> enumerable = new List<CRMspLkSepSelectCompany_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkSepSelectCompany_Result>((IEnumerable<CRMspLkSepSelectCompany_Result>)_dbLink.CRMspLkSepSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, linkAccSettingDBId, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	public int SepExportInfo(string records, int sepUserId, int pageNumber, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0, int pagesCnt = 0, bool useCrmCmpCode = false)
	{
		int indx = -1;
		try
		{
			indx = ThreadHub.AddThread();
			new Thread((ThreadStart)delegate
			{
				SepExportInfoAsync(records, sepUserId, pageNumber, fDate, tDate, value, linkAccSettingDBId, pagesCnt, indx, useCrmCmpCode);
			}).Start();
		}
		catch (Exception ex)
		{
			ThreadHub.SetThreadResult(indx, 0, ex.Message, false);
			ErrorSignal.FromCurrentContext().Raise(ex);
		}
		return indx;
	}

	public void SepExportInfoAsync(string records, int sepUserId, int pageNumber, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0, int pagesCnt = 0, int indx = 0, bool useCrmCmpCode = false)
	{
		//IL_01b8: Unknown result type (might be due to invalid IL or missing references)
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
			short.Parse(Financial.Get().Id.ToString());
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
							if (CRMIdeal.Classes.Helper.Company.GetCompanyById(item.Id) != null)
							{
								ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
								ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
								ObjectParameter accCode = new ObjectParameter("accCode", "");
								cRMLinkSpEntities.CRMspLkSepInsertUpdateCompany(item.Id, userId, appType, insertedId, accCode, objectParameter, sepUserId, linkAccSettingDBId, useCrmCmpCode);
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
	public JsonResult GetSepExportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "", int linkAccSettingDBId = 0)
	{
		//IL_0269: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkSepSelectCompany_Result item2 in Enumerable.ToList<CRMspLkSepSelectCompany_Result>((IEnumerable<CRMspLkSepSelectCompany_Result>)_dbLink.CRMspLkSepSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, linkAccSettingDBId, result2)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID.GetValueOrDefault(),
					Selected = !item2.cmpLinkAccCustomerId.HasValue
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
	public string GetDefSepReferUser(int linkAccSettingDBId = 0)
	{
		string text = "";
		try
		{
			return CRMIdeal.Classes.Helper.OtherSystems.GetDefSepReferUserId(linkAccSettingDBId).ToString();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			return Messages.msgErrorRunFunction + "|";
		}
	}

	[AjaxOnly]
	public string SepGetCmpAccountingDetail(int cmpId, ref decimal linkAccRemain, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance, int linkAccSettingDBId)
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
			linkAccDebitBalance = -1m;
			linkAccCreditBalance = -1m;
			if (cmpId > 0)
			{
				if (CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId) != null)
				{
					ObjectParameter objectParameter = new ObjectParameter("payRemain", typeof(decimal));
					ObjectParameter objectParameter2 = new ObjectParameter("debitBalance", typeof(decimal));
					ObjectParameter objectParameter3 = new ObjectParameter("creditBalance", typeof(decimal));
					bool result2 = false;
					CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "CmpAccountRemain", lCID, result, 1, linkAccSettingDBId, "ShowCmpAccountingSummary"));
					if (cRMspSelectLinkAccSetting_Result != null)
					{
						bool.TryParse(cRMspSelectLinkAccSetting_Result.PartValue, out result2);
					}
					if (result2)
					{
						CRMspLkSepReturnCmpAccountingSummary_Result cRMspLkSepReturnCmpAccountingSummary_Result = Enumerable.FirstOrDefault<CRMspLkSepReturnCmpAccountingSummary_Result>((IEnumerable<CRMspLkSepReturnCmpAccountingSummary_Result>)_dbLink.CRMspLkSepReturnCmpAccountingSummary(cmpId, objectParameter, linkAccSettingDBId));
						if (cRMspLkSepReturnCmpAccountingSummary_Result != null)
						{
							decimal result3 = default(decimal);
							decimal.TryParse(cRMspLkSepReturnCmpAccountingSummary_Result.Remain.ToString(), out result3);
							linkAccRemain = result3;
							text = "";
						}
						else
						{
							linkAccRemain = default(decimal);
							text = "";
						}
					}
					else
					{
						string value = "";
						CRMspSelectLinkAccSetting_Result cRMspSelectLinkAccSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSetting_Result>((IEnumerable<CRMspSelectLinkAccSetting_Result>)_dbLink.CRMspSelectLinkAccSetting(0, "CmpAccountRemain", lCID, result, 1, linkAccSettingDBId, "CmpAccountRemainingAccCode"));
						if (cRMspSelectLinkAccSetting_Result2 != null)
						{
							value = cRMspSelectLinkAccSetting_Result2.PartValue ?? "";
						}
						if (!string.IsNullOrWhiteSpace(value))
						{
							_dbLink.CRMspLkSepReturnCmpAccountRemaining(cmpId, objectParameter, linkAccSettingDBId);
						}
						else
						{
							_dbLink.CRMspLkSepReturnCmpAccountRemainingInAccCode(cmpId, objectParameter, linkAccSettingDBId, objectParameter2, objectParameter3);
						}
						decimal result4 = default(decimal);
						if (objectParameter != null && objectParameter.Value != null)
						{
							decimal.TryParse(objectParameter.Value.ToString(), out result4);
						}
						linkAccRemain = result4;
						text = "";
						decimal result5 = -1m;
						if (objectParameter2 != null && objectParameter2.Value != null)
						{
							decimal.TryParse(objectParameter2.Value.ToString(), out result5);
						}
						linkAccDebitBalance = result5;
						decimal result6 = -1m;
						if (objectParameter3 != null && objectParameter3.Value != null)
						{
							decimal.TryParse(objectParameter3.Value.ToString(), out result6);
						}
						linkAccCreditBalance = result6;
					}
				}
				else
				{
					Exception e = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e);
					text = Labels.frmError;
				}
			}
			else
			{
				Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e2);
				text = Labels.frmError;
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			text = Labels.frmError;
		}
		return text;
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actLinkCmpWithAcc")]
	public ActionResult SepLinkedCompany()
	{
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[HttpPost]
	public JsonResult ActSepLinkedCompany(string syncField, int mode, int linkAccSettingDBId)
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
			new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actLinkCmpWithAcc", UserLogin.CurrentUser))
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
				string text4 = "";
				text = "";
				List<CRMspLkSepLinkedCompany_Result> list = new List<CRMspLkSepLinkedCompany_Result>();
				list = Enumerable.ToList<CRMspLkSepLinkedCompany_Result>((IEnumerable<CRMspLkSepLinkedCompany_Result>)_dbLink.CRMspLkSepLinkedCompany(syncField, mode, lCID, result, linkAccSettingDBId));
				if (list != null && Enumerable.Any<CRMspLkSepLinkedCompany_Result>((IEnumerable<CRMspLkSepLinkedCompany_Result>)list) && list != null && Enumerable.Any<CRMspLkSepLinkedCompany_Result>((IEnumerable<CRMspLkSepLinkedCompany_Result>)list))
				{
					text = "error";
					text4 = GetFileSepLinkedCompany(list);
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

	public string GetFileSepLinkedCompany(List<CRMspLkSepLinkedCompany_Result> res)
	{
		//IL_048f: Unknown result type (might be due to invalid IL or missing references)
		//IL_04aa: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkSepLinkedCompany_Result>((IEnumerable<CRMspLkSepLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.Sepidar + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkSepLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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
						value2 = Messages.msgErrorCmpNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupCmpLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupCmpCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorCmpNotInLinkAcc, Labels.Sepidar);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actCmpLinkAccDetails")]
	public ActionResult SepCmpLinkAccDetails(int cmpId)
	{
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.LinkAccSettingDBList = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDB(1);
		return View();
	}

	[AjaxOnly]
	public JsonResult GetCmpLinkAccDetails(int cmpId, int linkAccSettingDBId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		SepCmpLinkAccDetailsViewModel sepCmpLinkAccDetailsViewModel = new SepCmpLinkAccDetailsViewModel();
		sepCmpLinkAccDetailsViewModel.CompanyInfo = new CRMspLkSepSelectCompanyById_Result();
		sepCmpLinkAccDetailsViewModel.IsFind = false;
		try
		{
			if (cmpId != 0)
			{
				sepCmpLinkAccDetailsViewModel.CompanyInfo = Enumerable.FirstOrDefault<CRMspLkSepSelectCompanyById_Result>((IEnumerable<CRMspLkSepSelectCompanyById_Result>)_dbLink.CRMspLkSepSelectCompanyById(cmpId, lCID, result, linkAccSettingDBId));
				if (sepCmpLinkAccDetailsViewModel.CompanyInfo != null)
				{
					sepCmpLinkAccDetailsViewModel.IsFind = true;
					sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccFirstTransferDateStr = (sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccFirstTransferDate.HasValue ? sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccFirstTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
					sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccLastTransferDateStr = (sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccLastTransferDate.HasValue ? sepCmpLinkAccDetailsViewModel.CompanyInfo.cmpLinkAccLastTransferDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
				}
				else
				{
					sepCmpLinkAccDetailsViewModel.Message = Messages.ErrorNotFound;
				}
			}
			else
			{
				sepCmpLinkAccDetailsViewModel.Message = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			sepCmpLinkAccDetailsViewModel.Message = Messages.msgErrorRunFunction + "<br />" + ex.Message;
		}
		JsonResult jsonResult = Json(sepCmpLinkAccDetailsViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult SepDeleteCompanyInfo(int cmpId, int mode, int position, int linkAccSettingDBId)
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
				actionName = "actDelLinkCmpInAcc";
				break;
			case 2:
				actionName = "actDelLinkCmpInCrm";
				break;
			}
			if (!UserLogin.IsUserAccess("frmCmpLinkAccDetails", actionName, currentUser))
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
			if (cmpId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				_ = Financial.Get().Id;
				int userId = currentUser.UserId;
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkSepDeleteCompanyInfoFromSep(cmpId, userId, value2, value3, value, registerDatePersian, appType, objectParameter, mode, linkAccSettingDBId);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendToAcc")]
	public ActionResult NoAvCmpSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string ActSendToAcc(int cmpId, string dbName, int seflCompanyId, string whDbName)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser))
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				if (CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId) != null)
				{
					ObjectParameter insertedId = new ObjectParameter("insertedId", 0);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					ObjectParameter objectParameter2 = new ObjectParameter("insertedNumebr", "");
					_dbLink.CRMspLkNoAvInsertUpdateCompany(cmpId, UserLogin.CurrentUser.UserId, seflCompanyId, dbName, whDbName, Configuration.AppType, insertedId, objectParameter2, objectParameter);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult NoAvExportCompany()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvExportCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkNoAvSelectCompany_Result> enumerable = new List<CRMspLkNoAvSelectCompany_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkNoAvSelectCompany_Result>((IEnumerable<CRMspLkNoAvSelectCompany_Result>)_dbLink.CRMspLkNoAvSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult NoAvExportInfo(string records, string dbName, string whDbName, int seflCompanyId, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		//IL_01d9: Unknown result type (might be due to invalid IL or missing references)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
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
			int? noAvIdCompany = seflCompanyId;
			DateTime? fDate2 = ((!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null);
			DateTime? tDATE = ((!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null);
			int? pageNumber2 = pageNumber;
			int? pageSize = value2;
			int? userId2 = userId;
			string appType2 = appType;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			ObjectParameter errorMessage = objectParameter;
			dbLink.CRMspLkNoAvExportCompany(noAvIdCompany, dbName, whDbName, fDate2, tDATE, value, text2, pageNumber2, pageSize, userId2, appType2, languageID, defaultLanguageID, errorMessage, result2);
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
	public JsonResult GetNoAvExportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "")
	{
		//IL_025a: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkNoAvSelectCompany_Result item2 in Enumerable.ToList<CRMspLkNoAvSelectCompany_Result>((IEnumerable<CRMspLkNoAvSelectCompany_Result>)_dbLink.CRMspLkNoAvSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, result2)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = !item2.cmpLinkAccCustomerId.HasValue
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
	public JsonResult GetDatabase(string dbName)
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
	public JsonResult GetSelfCompany(string dbName)
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
			List<mct_CRMspLkNoAvSelectSelfCompany_Result> list2 = Enumerable.ToList<mct_CRMspLkNoAvSelectSelfCompany_Result>((IEnumerable<mct_CRMspLkNoAvSelectSelfCompany_Result>)_dbLink.mfi_CRMspLkNoAvSelectSelfCompany(dbName));
			list.AddRange(Enumerable.Select<mct_CRMspLkNoAvSelectSelfCompany_Result, SelectListItem>((IEnumerable<mct_CRMspLkNoAvSelectSelfCompany_Result>)list2, (Func<mct_CRMspLkNoAvSelectSelfCompany_Result, SelectListItem>)((mct_CRMspLkNoAvSelectSelfCompany_Result item) => new SelectListItem
			{
				Text = item.NameCmp + ((!string.IsNullOrWhiteSpace(item.FirstName) || !string.IsNullOrWhiteSpace(item.LastName)) ? (" (" + ((!string.IsNullOrWhiteSpace(item.FirstName)) ? (item.FirstName + " ") : "") + ((!string.IsNullOrWhiteSpace(item.LastName)) ? item.LastName : "") + ")") : ""),
				Value = item.id.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.SelfCompanyList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string TarazCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		//IL_0d8b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d90: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				_003C_003Ec__DisplayClass35_0 _003C_003Ec__DisplayClass35_ = new _003C_003Ec__DisplayClass35_0();
				_003C_003Ec__DisplayClass35_.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (_003C_003Ec__DisplayClass35_.cmp != null)
				{
					List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result));
					if (list != null)
					{
						string text2 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
						if (cRMspSelectLinkAccTarazSetting_Result != null)
						{
							text2 = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
						}
						string text3 = "";
						string text4 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
						if (cRMspSelectLinkAccTarazSetting_Result2 != null)
						{
							text4 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
						}
						string text5 = "";
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
						if (cRMspSelectLinkAccTarazSetting_Result3 != null)
						{
							text5 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
						}
						CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
						if (cRMspSelectLinkAccTarazSetting_Result4 != null)
						{
							text3 = cRMspSelectLinkAccTarazSetting_Result4.PartValue ?? "";
						}
						if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5))
						{
							if (!text2.EndsWith("/"))
							{
								text2 += "/";
							}
							if (string.IsNullOrWhiteSpace(text3))
							{
								TarazGetAuthViewModel tarazGetAuthViewModel = new TarazGetAuthViewModel();
								tarazGetAuthViewModel.username = text4;
								tarazGetAuthViewModel.password = text5;
								string text6 = "tws/authenticate";
								HttpResponseMessage result2 = new HttpClient
								{
									BaseAddress = new Uri(text2 + text6),
									DefaultRequestHeaders = 
									{
										Accept = 
										{
											new MediaTypeWithQualityHeaderValue("application/json")
										}
									}
								}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(tarazGetAuthViewModel), Encoding.UTF8, "application/json"), requestUri: text2 + text6).Result;
								if (!result2.IsSuccessStatusCode)
								{
									TarazExceptionViewModel tarazExceptionViewModel = JsonConvert.DeserializeObject<TarazExceptionViewModel>(result2.Content.ReadAsStringAsync().Result);
									if (tarazExceptionViewModel != null)
									{
										string[] obj = new string[5]
										{
											Messages.msgErrorRunFunction,
											"<br>",
											tarazExceptionViewModel.error,
											null,
											null
										};
										_ = tarazExceptionViewModel.status;
										obj[3] = " code:" + tarazExceptionViewModel.status;
										obj[4] = "|";
										return string.Concat(obj);
									}
									return Messages.msgErrorRunFunction + "|";
								}
								TarazGetAuthResultViewModel tarazGetAuthResultViewModel = JsonConvert.DeserializeObject<TarazGetAuthResultViewModel>(result2.Content.ReadAsStringAsync().Result);
								if (string.IsNullOrWhiteSpace(tarazGetAuthResultViewModel.token))
								{
									return Messages.msgErrorRunFunction + "|";
								}
								text3 = ((!string.IsNullOrEmpty(tarazGetAuthResultViewModel.type)) ? (tarazGetAuthResultViewModel.type + " ") : "Bearer ") + tarazGetAuthResultViewModel.token;
								DbSet<CrmLinkAccTarazSetting> crmLinkAccTarazSetting = _dbTbl.CrmLinkAccTarazSetting;
								ParameterExpression val = Expression.Parameter(typeof(CrmLinkAccTarazSetting), "m");
								CrmLinkAccTarazSetting crmLinkAccTarazSetting2 = Queryable.FirstOrDefault<CrmLinkAccTarazSetting>((IQueryable<CrmLinkAccTarazSetting>)crmLinkAccTarazSetting, Expression.Lambda<Func<CrmLinkAccTarazSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)6, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
								if (crmLinkAccTarazSetting2 != null)
								{
									crmLinkAccTarazSetting2.PartValue = text3;
									_dbTbl.Entry(crmLinkAccTarazSetting2).State = EntityState.Modified;
									_dbTbl.Configuration.ValidateOnSaveEnabled = false;
									_dbTbl.SaveChanges();
									_dbTbl.Configuration.ValidateOnSaveEnabled = true;
								}
							}
							if (string.IsNullOrWhiteSpace(text3))
							{
								return Messages.msgErrorRunFunction + "|";
							}
							TarazPersonInsertViewModel tarazPersonInsertViewModel = new TarazPersonInsertViewModel();
							tarazPersonInsertViewModel.accPerCom = new TarazAccPerComInsertViewModel();
							tarazPersonInsertViewModel.accPerComOther = new TarazAccPerComOtherInsertViewModel();
							bool flag = true;
							string text7 = "";
							if (_003C_003Ec__DisplayClass35_.cmp.cmpTypeId.HasValue)
							{
								List<CRMspSelectLinkAccTarazSettingDetails_Result> list2 = Enumerable.ToList<CRMspSelectLinkAccTarazSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccTarazSettingDetails_Result>)_dbLink.CRMspSelectLinkAccTarazSettingDetails(0, _003C_003Ec__DisplayClass35_.cmp.cmpTypeId, "CompanyType", lCID, result));
								if (list2 != null)
								{
									string text8 = "";
									CRMspSelectLinkAccTarazSettingDetails_Result cRMspSelectLinkAccTarazSettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccTarazSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccTarazSettingDetails_Result, bool>)((CRMspSelectLinkAccTarazSettingDetails_Result m) => m.LinkAccTarazSettingId == 4));
									if (cRMspSelectLinkAccTarazSettingDetails_Result != null)
									{
										text8 = cRMspSelectLinkAccTarazSettingDetails_Result.PartValue ?? "";
									}
									CRMspSelectLinkAccTarazSettingDetails_Result cRMspSelectLinkAccTarazSettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccTarazSettingDetails_Result>)list2, (Func<CRMspSelectLinkAccTarazSettingDetails_Result, bool>)((CRMspSelectLinkAccTarazSettingDetails_Result m) => m.LinkAccTarazSettingId == 5));
									if (cRMspSelectLinkAccTarazSettingDetails_Result2 != null)
									{
										text7 = cRMspSelectLinkAccTarazSettingDetails_Result2.PartValue ?? "";
									}
									if (!string.IsNullOrWhiteSpace(text8))
									{
										switch (int.Parse(text8))
										{
										case 1:
											flag = false;
											break;
										case 2:
											flag = true;
											break;
										}
									}
								}
								List<CRMspSelectLinkAccTarazSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Company", lCID, result));
								string text9 = "";
								string text10 = "";
								if (list3 != null && Enumerable.Any<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list3))
								{
									foreach (CRMspSelectLinkAccTarazSetting_Result item in list3)
									{
										if (item.PartTitle == "PerComTypeIDForLegal")
										{
											text9 = item.PartValue ?? "";
										}
										else if (item.PartTitle == "PerComTypeIDForReal")
										{
											text10 = item.PartValue ?? "";
										}
									}
								}
								if (string.IsNullOrWhiteSpace(text9))
								{
									text9 = "1";
								}
								if (string.IsNullOrWhiteSpace(text10))
								{
									text10 = "0";
								}
								if (!string.IsNullOrWhiteSpace(text7))
								{
									tarazPersonInsertViewModel.accPerCom.tafsiliTypeID = long.Parse(text7);
									tarazPersonInsertViewModel.accPerCom.perComAddress = ((!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpProvince)) ? _003C_003Ec__DisplayClass35_.cmp.cmpProvince : "") + ((!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpCity)) ? (" - " + _003C_003Ec__DisplayClass35_.cmp.cmpCity) : "") + ((!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpAddress)) ? (" - " + _003C_003Ec__DisplayClass35_.cmp.cmpAddress) : "");
									tarazPersonInsertViewModel.accPerComOther.percomTel = _003C_003Ec__DisplayClass35_.cmp.cmpTel;
									tarazPersonInsertViewModel.accPerCom.perComNameLatin = _003C_003Ec__DisplayClass35_.cmp.cmpNameEng ?? "";
									tarazPersonInsertViewModel.accPerComOther.isSaleCustomer = true;
									if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpLinkAccCode))
									{
										tarazPersonInsertViewModel.accPerComOther.customerCode = _003C_003Ec__DisplayClass35_.cmp.cmpLinkAccCode;
									}
									tarazPersonInsertViewModel.accPerComOther.preCityCode = _003C_003Ec__DisplayClass35_.cmp.cmpPreTel;
									tarazPersonInsertViewModel.accPerComOther.postalCode = _003C_003Ec__DisplayClass35_.cmp.cmpZipCode;
									tarazPersonInsertViewModel.accPerCom.perComCode = "1";
									CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(_003C_003Ec__DisplayClass35_.cmp.CompanyID, _003C_003Ec__DisplayClass35_.cmp.cmpMainPersonId.GetValueOrDefault());
									if (flag)
									{
										tarazPersonInsertViewModel.accPerCom.perComTypeID = text9;
										tarazPersonInsertViewModel.accPerCom.perComTitle = ((!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpTitle)) ? _003C_003Ec__DisplayClass35_.cmp.cmpTitle : "");
										tarazPersonInsertViewModel.accPerCom.perComFName = _003C_003Ec__DisplayClass35_.cmp.cmpName ?? "";
										tarazPersonInsertViewModel.accPerCom.perComLName = "";
										tarazPersonInsertViewModel.accPerComOther.nationalCode = _003C_003Ec__DisplayClass35_.cmp.cmpNationalCode ?? "";
										tarazPersonInsertViewModel.accPerComOther.economicCode = _003C_003Ec__DisplayClass35_.cmp.cmpEconomicCode ?? "";
										tarazPersonInsertViewModel.accPerComOther.zoneCode = _003C_003Ec__DisplayClass35_.cmp.cmpRegistrationNumber ?? "";
										if (companyPerson != null)
										{
											tarazPersonInsertViewModel.accPerComOther.percomMobile = companyPerson.prsMobile ?? "";
										}
									}
									else
									{
										tarazPersonInsertViewModel.accPerCom.perComTypeID = text10;
										if (companyPerson != null)
										{
											tarazPersonInsertViewModel.accPerCom.perComTitle = companyPerson.prsTitle ?? "";
											tarazPersonInsertViewModel.accPerCom.perComFName = companyPerson.prsFName ?? "";
											tarazPersonInsertViewModel.accPerCom.perComLName = companyPerson.prsLName ?? "";
											tarazPersonInsertViewModel.accPerCom.fatherName = companyPerson.prsFatherName ?? "";
											tarazPersonInsertViewModel.accPerComOther.nationalCode = companyPerson.prsNationalCode ?? "";
											tarazPersonInsertViewModel.accPerComOther.percomMobile = companyPerson.prsMobile ?? "";
										}
										else
										{
											text = Messages.msgErrorNoPrsRegisteredThisCmp + "|";
										}
									}
									if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass35_.cmp.cmpLinkAccCustomerIdStr))
									{
										tarazPersonInsertViewModel.PerComID = long.Parse(_003C_003Ec__DisplayClass35_.cmp.cmpLinkAccCustomerIdStr);
									}
									HttpClient httpClient = new HttpClient();
									httpClient.BaseAddress = new Uri(text2);
									httpClient.DefaultRequestHeaders.Add("Authorization", text3);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "tws/acc/percoms";
									HttpContent content2 = new StringContent(JsonConvert.SerializeObject(tarazPersonInsertViewModel), Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
									if (tarazPersonInsertViewModel.PerComID.HasValue)
									{
										requestUri = "tws/acc/percoms/" + tarazPersonInsertViewModel.PerComID;
										httpResponseMessage = httpClient.PutAsync(requestUri, content2).Result;
									}
									else
									{
										httpResponseMessage = httpClient.PostAsync(requestUri, content2).Result;
									}
									if (httpResponseMessage.IsSuccessStatusCode)
									{
										TarazPersonInsertResultViewModel tarazPersonInsertResultViewModel = JsonConvert.DeserializeObject<TarazPersonInsertResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
										if (tarazPersonInsertResultViewModel != null)
										{
											if (!tarazPersonInsertViewModel.PerComID.HasValue)
											{
												if (!tarazPersonInsertResultViewModel.perComID.HasValue)
												{
													return string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.TarazSamaneh) + "|";
												}
												tarazPersonInsertViewModel.PerComID = tarazPersonInsertResultViewModel.perComID;
											}
											DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
											ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
											CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass35_, typeof(_003C_003Ec__DisplayClass35_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
											if (crmCompany2 != null)
											{
												string text11 = tarazPersonInsertResultViewModel.perComCode;
												if (!string.IsNullOrWhiteSpace(text11))
												{
													text11 = Regex.Replace(text11, "\\s+", "");
												}
												string text12 = "";
												if (!string.IsNullOrEmpty(tarazPersonInsertResultViewModel.tafsiliCode))
												{
													text12 = tarazPersonInsertResultViewModel.tafsiliCode;
													if (!string.IsNullOrWhiteSpace(text12))
													{
														text12 = Regex.Replace(text12, "\\s+", "");
													}
												}
												text12 = (crmCompany2.cmpCode = ((!string.IsNullOrEmpty(text12)) ? text12 : text11));
												crmCompany2.cmpLinkAccCode = ((!string.IsNullOrEmpty(text11)) ? text11 : text12);
												crmCompany2.cmpLinkAccCustomerId = int.Parse(tarazPersonInsertResultViewModel.perComID.ToString());
												crmCompany2.cmpLinkAccCustomerIdStr = tarazPersonInsertResultViewModel.perComID.ToString();
												_dbTbl.Entry(crmCompany2).State = EntityState.Modified;
												_dbTbl.SaveChanges();
												string text14 = text12 ?? "";
												return "1|" + text14;
											}
											return Messages.msgErrorEditInfo + " " + Labels.OtherSystemsCompany + "|";
										}
										return Messages.msgErrorRunFunction + "|";
									}
									HttpStatusCode statusCode = httpResponseMessage.StatusCode;
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
										return Messages.msgErrorRunFunction + "|";
									}
									TarazExceptionViewModel tarazExceptionViewModel2 = JsonConvert.DeserializeObject<TarazExceptionViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
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
											Messages.msgErrorRunFunction,
											"<br>",
											tarazExceptionViewModel2.error,
											(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
											null,
											null
										};
										_ = tarazExceptionViewModel2.status;
										obj2[4] = " code:" + tarazExceptionViewModel2.status;
										obj2[5] = "|";
										return string.Concat(obj2);
									}
									return Messages.msgErrorRunFunction + "|";
								}
								return Messages.errorInReadingSetting + "|";
							}
							return string.Format(Messages.ErrorEmpty, Labels.LinkAccSettingCompanyType) + "|";
						}
						return Messages.errorInReadingSetting + "|";
					}
					return Messages.errorInReadingSetting + "|";
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

	[AjaxOnly]
	public string TarazGetCmpAccountingDetail(int cmpId, ref decimal remainCash, ref decimal remainChq)
	{
		//IL_067b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0680: Unknown result type (might be due to invalid IL or missing references)
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrEmpty(companyById.cmpLinkAccCustomerIdStr))
					{
						List<CRMspSelectLinkAccTarazSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)_dbLink.CRMspSelectLinkAccTarazSetting(0, "Setting", lCID, result2));
						if (list != null)
						{
							string text = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 1));
							if (cRMspSelectLinkAccTarazSetting_Result != null)
							{
								text = cRMspSelectLinkAccTarazSetting_Result.PartValue ?? "";
							}
							string text2 = "";
							string text3 = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 2));
							if (cRMspSelectLinkAccTarazSetting_Result2 != null)
							{
								text3 = cRMspSelectLinkAccTarazSetting_Result2.PartValue ?? "";
							}
							string text4 = "";
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 3));
							if (cRMspSelectLinkAccTarazSetting_Result3 != null)
							{
								text4 = cRMspSelectLinkAccTarazSetting_Result3.PartValue ?? "";
							}
							CRMspSelectLinkAccTarazSetting_Result cRMspSelectLinkAccTarazSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccTarazSetting_Result>((IEnumerable<CRMspSelectLinkAccTarazSetting_Result>)list, (Func<CRMspSelectLinkAccTarazSetting_Result, bool>)((CRMspSelectLinkAccTarazSetting_Result m) => m.LinkAccTarazSettingId == 6));
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
											Exception e = new Exception(Messages.msgErrorRunFunction + "  (authentication in tarazSamaneh) ");
											ErrorSignal.FromCurrentContext().Raise(e);
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
										Exception e2 = new Exception(text6);
										ErrorSignal.FromCurrentContext().Raise(e2);
										result = Labels.frmError;
									}
								}
								if (string.IsNullOrWhiteSpace(text2))
								{
									Exception e3 = new Exception(Messages.msgErrorRunFunction + " (authentication in tarazSamaneh) ");
									ErrorSignal.FromCurrentContext().Raise(e3);
									result = Labels.frmError;
								}
								if (!string.IsNullOrWhiteSpace(text2))
								{
									DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
									HttpClient httpClient = new HttpClient();
									httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Add("Authorization", text2);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "tws/sale/customers?customerID=" + companyById.cmpLinkAccCustomerIdStr;
									HttpResponseMessage result4 = httpClient.GetAsync(requestUri).Result;
									if (result4.IsSuccessStatusCode)
									{
										List<TarazSaleCustomerViewModel> list2 = JsonConvert.DeserializeObject<List<TarazSaleCustomerViewModel>>(result4.Content.ReadAsStringAsync().Result);
										if (list2 == null)
										{
											Exception e4 = new Exception(Messages.msgErrorRunFunction + " (not find customer information from Taraz or find more one than) ");
											ErrorSignal.FromCurrentContext().Raise(e4);
											return Labels.frmError;
										}
										long cmpLinkAccCustomerIdStr = 0L;
										long.TryParse(companyById.cmpLinkAccCustomerIdStr, out cmpLinkAccCustomerIdStr);
										TarazSaleCustomerViewModel tarazSaleCustomerViewModel = Enumerable.FirstOrDefault<TarazSaleCustomerViewModel>((IEnumerable<TarazSaleCustomerViewModel>)list2, (Func<TarazSaleCustomerViewModel, bool>)((TarazSaleCustomerViewModel m) => m.customerID == cmpLinkAccCustomerIdStr));
										if (tarazSaleCustomerViewModel == null)
										{
											Exception e5 = new Exception(Messages.msgErrorRunFunction + " (not find customer information from Taraz or find more one than) ");
											ErrorSignal.FromCurrentContext().Raise(e5);
											return Labels.frmError;
										}
										remainCash = tarazSaleCustomerViewModel.remainCash.GetValueOrDefault();
										remainChq = tarazSaleCustomerViewModel.remainChq.GetValueOrDefault();
										result = "";
									}
									else
									{
										string text7 = Messages.msgErrorRunFunction + " (get list from tarazSamaneh) ";
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
												text7,
												" [",
												tarazExceptionViewModel2.error,
												(!string.IsNullOrEmpty(tarazExceptionViewModel2.message)) ? (" -" + tarazExceptionViewModel2.message) : "",
												null,
												null
											};
											_ = tarazExceptionViewModel2.status;
											obj2[4] = " code:" + tarazExceptionViewModel2.status;
											obj2[5] = "]";
											text7 = string.Concat(obj2);
										}
										Exception e6 = new Exception(text7);
										ErrorSignal.FromCurrentContext().Raise(e6);
										result = Labels.frmError;
									}
								}
							}
							else
							{
								Exception e7 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
								ErrorSignal.FromCurrentContext().Raise(e7);
								result = Labels.frmError;
							}
						}
						else
						{
							Exception e8 = new Exception(Messages.errorInReadingSetting + " (tarazSamaneh) ");
							ErrorSignal.FromCurrentContext().Raise(e8);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e9 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in taraz");
						ErrorSignal.FromCurrentContext().Raise(e9);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e10 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e10);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e11 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e11);
				result = Labels.frmError;
			}
		}
		catch (Exception e12)
		{
			ErrorSignal.FromCurrentContext().Raise(e12);
			result = Labels.frmError;
		}
		return result;
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendToAcc")]
	public ActionResult HolooCmpSendToAcc()
	{
		GetLinkAccHolooDatabases();
		return View();
	}

	[AjaxOnly]
	public string HolooActCmpSendToAcc_Old(int cmpId, bool ispurchaser, bool isseller, int custtype, bool checkAction = true)
	{
		//IL_0e25: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e32: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e37: Unknown result type (might be due to invalid IL or missing references)
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				_003C_003Ec__DisplayClass39_0 _003C_003Ec__DisplayClass39_ = new _003C_003Ec__DisplayClass39_0();
				_003C_003Ec__DisplayClass39_.cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (_003C_003Ec__DisplayClass39_.cmp != null)
				{
					List<CRMspSelectLinkAccHolooSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
					if (list != null)
					{
						string text2 = "";
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
						if (cRMspSelectLinkAccHolooSetting_Result != null)
						{
							text2 = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
						}
						string text3 = "";
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
						if (cRMspSelectLinkAccHolooSetting_Result2 != null)
						{
							text3 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
						}
						string text4 = "";
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
						if (cRMspSelectLinkAccHolooSetting_Result3 != null)
						{
							text4 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
						}
						string text5 = "";
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
						if (cRMspSelectLinkAccHolooSetting_Result4 != null)
						{
							text5 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
						}
						bool result2 = false;
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 10));
						if (cRMspSelectLinkAccHolooSetting_Result5 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result5.PartValue))
						{
							bool.TryParse(cRMspSelectLinkAccHolooSetting_Result5.PartValue, out result2);
						}
						bool result3 = false;
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 11));
						if (cRMspSelectLinkAccHolooSetting_Result6 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result6.PartValue))
						{
							bool.TryParse(cRMspSelectLinkAccHolooSetting_Result6.PartValue, out result3);
						}
						bool result4 = false;
						CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 12));
						if (cRMspSelectLinkAccHolooSetting_Result7 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result7.PartValue))
						{
							bool.TryParse(cRMspSelectLinkAccHolooSetting_Result7.PartValue, out result4);
						}
						string text6 = "";
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
							string text7 = "api/Login";
							HttpResponseMessage result5 = new HttpClient
							{
								Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
								BaseAddress = new Uri(text2 + text7),
								DefaultRequestHeaders = 
								{
									Accept = 
									{
										new MediaTypeWithQualityHeaderValue("application/json")
									}
								}
							}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text2 + text7).Result;
							if (result5.IsSuccessStatusCode)
							{
								HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result5.Content.ReadAsStringAsync().Result);
								if (holooLoginResultViewModel != null)
								{
									if (holooLoginResultViewModel.Login != null)
									{
										if (holooLoginResultViewModel.Login.State)
										{
											text6 = holooLoginResultViewModel.Login.Token ?? "";
											if (string.IsNullOrWhiteSpace(text6))
											{
												return Messages.msgErrorRunFunction + "<br> Token is null|";
											}
											HolooCustomerInsertEditViewModel obj = new HolooCustomerInsertEditViewModel
											{
												custinfo = new List<HolooCustInfoIEViewModel>()
											};
											HolooCustInfoIEViewModel holooCustInfoIEViewModel = new HolooCustInfoIEViewModel
											{
												ispurchaser = ispurchaser,
												isseller = isseller,
												custtype = custtype
											};
											holooCustInfoIEViewModel.id = _003C_003Ec__DisplayClass39_.cmp.CompanyID.ToString();
											holooCustInfoIEViewModel.name = _003C_003Ec__DisplayClass39_.cmp.CompanyName ?? "";
											holooCustInfoIEViewModel.nationalid = _003C_003Ec__DisplayClass39_.cmp.cmpNationalCode ?? "";
											holooCustInfoIEViewModel.economicid = _003C_003Ec__DisplayClass39_.cmp.cmpEconomicCode ?? "";
											holooCustInfoIEViewModel.tel = _003C_003Ec__DisplayClass39_.cmp.cmpTel ?? "";
											holooCustInfoIEViewModel.fax = _003C_003Ec__DisplayClass39_.cmp.cmpFax ?? "";
											holooCustInfoIEViewModel.city = _003C_003Ec__DisplayClass39_.cmp.cmpCity ?? "";
											holooCustInfoIEViewModel.ostan = _003C_003Ec__DisplayClass39_.cmp.cmpProvince ?? "";
											holooCustInfoIEViewModel.zipcode = _003C_003Ec__DisplayClass39_.cmp.cmpZipCode ?? "";
											holooCustInfoIEViewModel.address = _003C_003Ec__DisplayClass39_.cmp.cmpAddress ?? "";
											if (_003C_003Ec__DisplayClass39_.cmp.cmpKind.GetValueOrDefault() == 1)
											{
												holooCustInfoIEViewModel.name = _003C_003Ec__DisplayClass39_.cmp.CompanyName + " - " + _003C_003Ec__DisplayClass39_.cmp.cmpMainPerson;
												if (_003C_003Ec__DisplayClass39_.cmp.cmpName == "شخص" || _003C_003Ec__DisplayClass39_.cmp.cmpName == Labels.lblPerson)
												{
													holooCustInfoIEViewModel.name = _003C_003Ec__DisplayClass39_.cmp.cmpMainPerson ?? "";
												}
												if (string.IsNullOrEmpty(holooCustInfoIEViewModel.name))
												{
													holooCustInfoIEViewModel.name = _003C_003Ec__DisplayClass39_.cmp.CompanyName + " - " + _003C_003Ec__DisplayClass39_.cmp.cmpMainPerson;
												}
												if (_003C_003Ec__DisplayClass39_.cmp.cmpMainPersonId.HasValue)
												{
													CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(_003C_003Ec__DisplayClass39_.cmp.cmpMainPersonId, lCID, result));
													if (cRMspSelectCompanyPersonsByID_Result != null)
													{
														holooCustInfoIEViewModel.nationalid = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
														holooCustInfoIEViewModel.mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
														holooCustInfoIEViewModel.email = cRMspSelectCompanyPersonsByID_Result.prsEmail ?? "";
													}
												}
											}
											else if (_003C_003Ec__DisplayClass39_.cmp.cmpMainPersonId.HasValue)
											{
												CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(_003C_003Ec__DisplayClass39_.cmp.cmpMainPersonId, lCID, result));
												if (cRMspSelectCompanyPersonsByID_Result2 != null)
												{
													holooCustInfoIEViewModel.mobile = cRMspSelectCompanyPersonsByID_Result2.prsMobile ?? "";
													holooCustInfoIEViewModel.email = cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? "";
												}
											}
											holooCustInfoIEViewModel.email = holooCustInfoIEViewModel.email ?? "";
											if (!string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass39_.cmp.cmpLinkAccCustomerIdStr))
											{
												holooCustInfoIEViewModel.erpcode = _003C_003Ec__DisplayClass39_.cmp.cmpLinkAccCustomerIdStr;
												holooCustInfoIEViewModel.name = "-1";
											}
											obj.custinfo.Add(holooCustInfoIEViewModel);
											HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> holooCustomerInsertEditIViewModel = new HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel>();
											holooCustomerInsertEditIViewModel.custinfo = new List<HolooCustInfoInsertViewModel>();
											HolooCustInfoInsertViewModel item = new HolooCustInfoInsertViewModel
											{
												id = holooCustInfoIEViewModel.id,
												name = holooCustInfoIEViewModel.name,
												ispurchaser = holooCustInfoIEViewModel.ispurchaser,
												isseller = holooCustInfoIEViewModel.isseller,
												custtype = holooCustInfoIEViewModel.custtype,
												nationalid = holooCustInfoIEViewModel.nationalid,
												economicid = holooCustInfoIEViewModel.economicid,
												tel = holooCustInfoIEViewModel.tel,
												mobile = holooCustInfoIEViewModel.mobile,
												fax = holooCustInfoIEViewModel.fax,
												city = holooCustInfoIEViewModel.city,
												ostan = holooCustInfoIEViewModel.ostan,
												email = holooCustInfoIEViewModel.email,
												zipcode = holooCustInfoIEViewModel.zipcode,
												address = holooCustInfoIEViewModel.address
											};
											holooCustomerInsertEditIViewModel.custinfo.Add(item);
											HttpClient httpClient = new HttpClient();
											httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
											httpClient.BaseAddress = new Uri(text2);
											httpClient.DefaultRequestHeaders.Add("Authorization", text6);
											httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
											string text8 = "api/Customer";
											string text9 = "";
											if (result2)
											{
												text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
												text9 += "allowDuplicateEco=true";
											}
											if (result3)
											{
												text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
												text9 += "allowDuplicateNatCode=true";
											}
											if (result4)
											{
												text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
												text9 += "allowDuplicateMobile=true";
											}
											text8 += text9;
											string text10 = JsonConvert.SerializeObject(obj);
											if (string.IsNullOrWhiteSpace(_003C_003Ec__DisplayClass39_.cmp.cmpLinkAccCustomerIdStr))
											{
												text10 = JsonConvert.SerializeObject(holooCustomerInsertEditIViewModel);
											}
											if (!string.IsNullOrEmpty(holooCustInfoIEViewModel.erpcode))
											{
												text10 = text10.Replace(",\"name\":\"-1\"", "");
											}
											HttpContent content2 = new StringContent(text10, Encoding.UTF8, "application/json");
											HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
											httpResponseMessage = (string.IsNullOrEmpty(holooCustInfoIEViewModel.erpcode) ? httpClient.PostAsync(text8, content2).Result : httpClient.PutAsync(text8, content2).Result);
											if (httpResponseMessage.IsSuccessStatusCode)
											{
												HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
												if (holooCustomerInsertEditResultViewModel != null)
												{
													if (holooCustomerInsertEditResultViewModel.Success != null)
													{
														if (string.IsNullOrEmpty(holooCustInfoIEViewModel.erpcode))
														{
															if (string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode))
															{
																return string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "|";
															}
															holooCustInfoIEViewModel.erpcode = holooCustomerInsertEditResultViewModel.Success.ErpCode;
														}
														DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
														ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
														CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Property((Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass39_, typeof(_003C_003Ec__DisplayClass39_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/)), (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
														if (crmCompany2 != null)
														{
															string code = holooCustomerInsertEditResultViewModel.Success.Code;
															code = (crmCompany2.cmpLinkAccCode = (crmCompany2.cmpCode = (string.IsNullOrWhiteSpace(holooCustomerInsertEditResultViewModel.Success.Code) ? crmCompany2.cmpLinkAccCode : Regex.Replace(holooCustomerInsertEditResultViewModel.Success.Code, "\\s+", ""))));
															crmCompany2.cmpLinkAccCustomerIdStr = holooCustomerInsertEditResultViewModel.Success.ErpCode;
															_dbTbl.Entry(crmCompany2).State = EntityState.Modified;
															_dbTbl.SaveChanges();
															string text13 = code ?? "";
															return "1|" + text13;
														}
														return Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
													}
													if (holooCustomerInsertEditResultViewModel.Failure != null)
													{
														string[] obj2 = new string[10]
														{
															Messages.msgErrorRunFunction,
															"<br>",
															Messages.msgErrorInSendToOtherSystem,
															" ",
															Labels.OtherSystemsCompany,
															"<br>",
															holooCustomerInsertEditResultViewModel.Failure.Error,
															"<br>",
															null,
															null
														};
														_ = holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
														obj2[8] = " code:" + holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
														obj2[9] = "|";
														return string.Concat(obj2);
													}
													return Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
												}
												return Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
											}
											string[] obj3 = new string[8]
											{
												Messages.msgErrorRunFunction,
												"<br>",
												Messages.msgErrorEditInfo,
												" ",
												Labels.OtherSystemsCompany,
												"<br>",
												null,
												null
											};
											_ = httpResponseMessage.StatusCode;
											HttpStatusCode statusCode = httpResponseMessage.StatusCode;
											obj3[6] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
											obj3[7] = "|";
											return string.Concat(obj3);
										}
										string[] obj4 = new string[5]
										{
											Messages.msgErrorRunFunction,
											"<br>",
											holooLoginResultViewModel.Login.Error,
											null,
											null
										};
										_ = holooLoginResultViewModel.Login.ErrorCode;
										obj4[3] = " code:" + holooLoginResultViewModel.Login.ErrorCode;
										obj4[4] = "|";
										return string.Concat(obj4);
									}
									return Messages.msgErrorRunFunction + "<br> Error in login|";
								}
								return Messages.msgErrorRunFunction + "<br> Error in login|";
							}
							return Messages.msgErrorRunFunction + "<br> Error in login|";
						}
						return Messages.errorInReadingSetting + "|";
					}
					return Messages.errorInReadingSetting + "|";
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

	[AjaxOnly]
	public string HolooActCmpSendToAcc(int cmpId, bool ispurchaser, bool isseller, int custtype, int linkAccSettingDBId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result = Enumerable.FirstOrDefault<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)_dbLink.CRMspLkHolooSelectCompanyByCmpIds($"{cmpId}", lCID, result, linkAccSettingDBId), (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result c) => c.CompanyID == cmpId));
				if (cRMspLkHolooSelectCompanyByCmpIds_Result != null)
				{
					CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
					string text2 = holooProvider.Authenticate();
					bool allowDuplicateEco = holooProvider.AllowDuplicateEco;
					bool allowDuplicateNatCode = holooProvider.AllowDuplicateNatCode;
					bool allowDuplicateMobile = holooProvider.AllowDuplicateMobile;
					if (!string.IsNullOrEmpty(text2))
					{
						return text2;
					}
					HolooCustomerInsertEditViewModel customerInfoReq = new HolooCustomerInsertEditViewModel();
					customerInfoReq.custinfo = new List<HolooCustInfoIEViewModel>();
					HolooCustInfoIEViewModel custinfo = new HolooCustInfoIEViewModel
					{
						ispurchaser = ispurchaser,
						isseller = isseller,
						custtype = custtype
					};
					custinfo.id = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyID.ToString();
					custinfo.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName ?? "";
					custinfo.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpNationalCode ?? "";
					custinfo.economicid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpEconomicCode ?? "";
					custinfo.tel = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpTel ?? "";
					custinfo.fax = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpFax ?? "";
					custinfo.city = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpCity ?? "";
					custinfo.ostan = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpProvince ?? "";
					custinfo.zipcode = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpZipCode ?? "";
					custinfo.address = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpAddress ?? "";
					if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpKind.GetValueOrDefault() == 1)
					{
						custinfo.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
						if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == "شخص" || cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == Labels.lblPerson)
						{
							custinfo.name = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson ?? "";
						}
						if (string.IsNullOrEmpty(custinfo.name))
						{
							custinfo.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
						}
						if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPersonId.HasValue)
						{
							CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPersonId, lCID, result));
							if (cRMspSelectCompanyPersonsByID_Result != null)
							{
								custinfo.nationalid = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
								custinfo.mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
								custinfo.email = cRMspSelectCompanyPersonsByID_Result.prsEmail ?? "";
							}
						}
					}
					else if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPersonId.HasValue)
					{
						CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPersonId, lCID, result));
						if (cRMspSelectCompanyPersonsByID_Result2 != null)
						{
							custinfo.mobile = cRMspSelectCompanyPersonsByID_Result2.prsMobile ?? "";
							custinfo.email = cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? "";
						}
					}
					custinfo.email = custinfo.email ?? "";
					if (!string.IsNullOrWhiteSpace(cRMspLkHolooSelectCompanyByCmpIds_Result.cmpLinkAccCustomerIdStr))
					{
						custinfo.erpcode = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpLinkAccCustomerIdStr;
						custinfo.name = "-1";
					}
					customerInfoReq.custinfo.Add(custinfo);
					HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> customerInfoReq_I = new HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel>();
					customerInfoReq_I.custinfo = new List<HolooCustInfoInsertViewModel>();
					HolooCustInfoInsertViewModel item = new HolooCustInfoInsertViewModel
					{
						id = custinfo.id,
						name = custinfo.name,
						ispurchaser = custinfo.ispurchaser,
						isseller = custinfo.isseller,
						custtype = custinfo.custtype,
						nationalid = custinfo.nationalid,
						economicid = custinfo.economicid,
						tel = custinfo.tel,
						mobile = custinfo.mobile,
						fax = custinfo.fax,
						city = custinfo.city,
						ostan = custinfo.ostan,
						email = custinfo.email,
						zipcode = custinfo.zipcode,
						address = custinfo.address
					};
					customerInfoReq_I.custinfo.Add(item);
					string errorMessage = "";
					string code = "";
					string text3 = "";
					if (allowDuplicateEco)
					{
						text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
						text3 += "allowDuplicateEco=true";
					}
					if (allowDuplicateNatCode)
					{
						text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
						text3 += "allowDuplicateNatCode=true";
					}
					if (allowDuplicateMobile)
					{
						text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
						text3 += "allowDuplicateMobile=true";
					}
					holooProvider.SendCmpToAcc(text3, ref errorMessage, ref code, ref custinfo, cRMspLkHolooSelectCompanyByCmpIds_Result, ref customerInfoReq_I, ref customerInfoReq, checkAction);
					if (!string.IsNullOrEmpty(errorMessage))
					{
						return errorMessage;
					}
					return "1|" + code;
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult HolooExportCompany()
	{
		GetLinkAccHolooDatabases();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult HolooExportCompany_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkHolooSelectCompany_Result> enumerable = new List<CRMspLkHolooSelectCompany_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkHolooSelectCompany_Result>((IEnumerable<CRMspLkHolooSelectCompany_Result>)_dbLink.CRMspLkHolooSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, result2, linkAccSettingDBId));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult HolooExportInfo_Old(string records, int linkAccSettingDBId, bool ispurchaser, bool isseller, int custtype, int totalPage)
	{
		//IL_00e6: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ffa: Unknown result type (might be due to invalid IL or missing references)
		//IL_1007: Unknown result type (might be due to invalid IL or missing references)
		//IL_100c: Unknown result type (might be due to invalid IL or missing references)
		//IL_17b6: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c3: Unknown result type (might be due to invalid IL or missing references)
		//IL_17c8: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int num = 0;
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Success;
		bool result2 = false;
		bool result3 = false;
		bool result4 = false;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			totalPage = ((totalPage > 0) ? totalPage : 0);
			text = "";
			int num2 = 0;
			string text2 = "";
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
					if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
					{
						foreach (OtherSystemSelectedViewModel item in list2)
						{
							if (item.Selected)
							{
								text2 = text2 + item.Id + ",";
							}
						}
					}
				}
			}
			string value = "";
			string text3 = "";
			List<CRMspSelectLinkAccHolooSetting_Result> list3 = Enumerable.ToList<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)_dbLink.CRMspSelectLinkAccHolooSetting(0, "Setting", lCID, result));
			if (list3 != null)
			{
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 1));
				if (cRMspSelectLinkAccHolooSetting_Result != null)
				{
					text3 = cRMspSelectLinkAccHolooSetting_Result.PartValue ?? "";
				}
				string text4 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 2));
				if (cRMspSelectLinkAccHolooSetting_Result2 != null)
				{
					text4 = cRMspSelectLinkAccHolooSetting_Result2.PartValue ?? "";
				}
				string text5 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 3));
				if (cRMspSelectLinkAccHolooSetting_Result3 != null)
				{
					text5 = cRMspSelectLinkAccHolooSetting_Result3.PartValue ?? "";
				}
				string text6 = "";
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 4));
				if (cRMspSelectLinkAccHolooSetting_Result4 != null)
				{
					text6 = cRMspSelectLinkAccHolooSetting_Result4.PartValue ?? "";
				}
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result5 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 10));
				if (cRMspSelectLinkAccHolooSetting_Result5 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result5.PartValue))
				{
					bool.TryParse(cRMspSelectLinkAccHolooSetting_Result5.PartValue, out result2);
				}
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result6 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 11));
				if (cRMspSelectLinkAccHolooSetting_Result6 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result6.PartValue))
				{
					bool.TryParse(cRMspSelectLinkAccHolooSetting_Result6.PartValue, out result3);
				}
				CRMspSelectLinkAccHolooSetting_Result cRMspSelectLinkAccHolooSetting_Result7 = Enumerable.FirstOrDefault<CRMspSelectLinkAccHolooSetting_Result>((IEnumerable<CRMspSelectLinkAccHolooSetting_Result>)list3, (Func<CRMspSelectLinkAccHolooSetting_Result, bool>)((CRMspSelectLinkAccHolooSetting_Result m) => m.LinkAccHolooSettingId == 12));
				if (cRMspSelectLinkAccHolooSetting_Result7 != null && !string.IsNullOrWhiteSpace(cRMspSelectLinkAccHolooSetting_Result7.PartValue))
				{
					bool.TryParse(cRMspSelectLinkAccHolooSetting_Result7.PartValue, out result4);
				}
				if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5) && !string.IsNullOrWhiteSpace(text6))
				{
					if (!text3.EndsWith("/"))
					{
						text3 += "/";
					}
					HolooLoginViewModel holooLoginViewModel = new HolooLoginViewModel();
					holooLoginViewModel.userinfo = new HolooUserInfoViewModel
					{
						dbname = text4,
						username = text5,
						userpass = text6
					};
					string text7 = "api/Login";
					HttpResponseMessage result5 = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text3 + text7),
						DefaultRequestHeaders = 
						{
							Accept = 
							{
								new MediaTypeWithQualityHeaderValue("application/json")
							}
						}
					}.PostAsync(content: new StringContent(JsonConvert.SerializeObject(holooLoginViewModel), Encoding.UTF8, "application/json"), requestUri: text3 + text7).Result;
					if (result5.IsSuccessStatusCode)
					{
						HolooLoginResultViewModel holooLoginResultViewModel = JsonConvert.DeserializeObject<HolooLoginResultViewModel>(result5.Content.ReadAsStringAsync().Result);
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
									text = string.Concat(msgErrorRunFunction, "<br>", error, " code:" + holooLoginResultViewModel.Login.ErrorCode);
								}
							}
							else
							{
								text = Messages.msgErrorRunFunction + "<br> Error in login";
							}
						}
						else
						{
							text = Messages.msgErrorRunFunction + "<br> Error in login";
						}
					}
					else
					{
						text = Messages.msgErrorRunFunction + "<br> Error in login";
					}
				}
				else
				{
					text = Messages.errorInReadingSetting;
				}
			}
			else
			{
				text = Messages.errorInReadingSetting;
			}
			if (string.IsNullOrWhiteSpace(value))
			{
				text = Messages.msgErrorRunFunction + "<br> Token is null";
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			List<CRMspLkHolooSelectCompanyByCmpIds_Result> list4 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)_dbLink.CRMspLkHolooSelectCompanyByCmpIds(text2, lCID, result, linkAccSettingDBId));
			if (list4 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4) && !string.IsNullOrEmpty(value))
			{
				num2 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4);
				List<CRMspLkHolooSelectCompanyByCmpIds_Result> list5 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>(Enumerable.Where<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4, (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result m) => m.cmpLinkAccCustomerIdStr == null || m.cmpLinkAccCustomerIdStr == "")));
				HttpStatusCode statusCode;
				if (list5 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list5))
				{
					int num3 = 200;
					int num4 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list5);
					int num5 = num4 / num3;
					int num6 = num4 % num3;
					if (num6 != 0)
					{
						num5++;
					}
					int num7 = 0;
					int num8 = num3;
					for (int i = 0; i < num5; i++)
					{
						HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> holooCustomerInsertEditIViewModel = new HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel>();
						holooCustomerInsertEditIViewModel.custinfo = new List<HolooCustInfoInsertViewModel>();
						num8 = ((i == num5 - 1 && num6 != 0) ? num6 : num3);
						for (int j = 0; j < num8; j++)
						{
							int index = i * num3 + j;
							CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result = list5[index];
							if (cRMspLkHolooSelectCompanyByCmpIds_Result == null)
							{
								continue;
							}
							HolooCustInfoInsertViewModel holooCustInfoInsertViewModel = new HolooCustInfoInsertViewModel
							{
								ispurchaser = ispurchaser,
								isseller = isseller,
								custtype = custtype
							};
							holooCustInfoInsertViewModel.id = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyID.ToString();
							holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName ?? "";
							holooCustInfoInsertViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpNationalCode ?? "";
							holooCustInfoInsertViewModel.economicid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpEconomicCode ?? "";
							holooCustInfoInsertViewModel.tel = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpTel ?? "";
							holooCustInfoInsertViewModel.fax = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpFax ?? "";
							holooCustInfoInsertViewModel.city = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpCity ?? "";
							holooCustInfoInsertViewModel.ostan = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpProvince ?? "";
							holooCustInfoInsertViewModel.zipcode = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpZipCode ?? "";
							holooCustInfoInsertViewModel.address = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpAddress ?? "";
							holooCustInfoInsertViewModel.mobile = cRMspLkHolooSelectCompanyByCmpIds_Result.prsMobile ?? "";
							holooCustInfoInsertViewModel.email = cRMspLkHolooSelectCompanyByCmpIds_Result.prsEmail ?? "";
							if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpKind.GetValueOrDefault() == 1)
							{
								holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
								if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == "شخص" || cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == Labels.lblPerson)
								{
									holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson ?? "";
								}
								if (string.IsNullOrEmpty(holooCustInfoInsertViewModel.name))
								{
									holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
								}
								holooCustInfoInsertViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result.prsNationalCode ?? "";
							}
							holooCustomerInsertEditIViewModel.custinfo.Add(holooCustInfoInsertViewModel);
						}
						if (holooCustomerInsertEditIViewModel.custinfo != null && Enumerable.Any<HolooCustInfoInsertViewModel>((IEnumerable<HolooCustInfoInsertViewModel>)holooCustomerInsertEditIViewModel.custinfo))
						{
							HttpClient httpClient = new HttpClient();
							httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
							httpClient.BaseAddress = new Uri(text3);
							httpClient.DefaultRequestHeaders.Add("Authorization", value);
							httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							string text8 = "api/Customer";
							string text9 = "";
							if (result2)
							{
								text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
								text9 += "allowDuplicateEco=true";
							}
							if (result3)
							{
								text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
								text9 += "allowDuplicateNatCode=true";
							}
							if (result4)
							{
								text9 = ((!string.IsNullOrWhiteSpace(text9)) ? (text9 + "&") : (text9 + "?"));
								text9 += "allowDuplicateMobile=true";
							}
							text8 += text9;
							HttpContent content2 = new StringContent(JsonConvert.SerializeObject(holooCustomerInsertEditIViewModel), Encoding.UTF8, "application/json");
							HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
							httpResponseMessage = httpClient.PostAsync(text8, content2).Result;
							if (httpResponseMessage.IsSuccessStatusCode)
							{
								string result6 = httpResponseMessage.Content.ReadAsStringAsync().Result;
								if (Enumerable.Count<HolooCustInfoInsertViewModel>((IEnumerable<HolooCustInfoInsertViewModel>)holooCustomerInsertEditIViewModel.custinfo) > 1)
								{
									HolooCustomersInsertEditResultViewModel holooCustomersInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomersInsertEditResultViewModel>(result6);
									if (holooCustomersInsertEditResultViewModel != null)
									{
										string text10 = "";
										if (holooCustomersInsertEditResultViewModel.Success != null)
										{
											foreach (HolooCustomerInsertEditSuccessResultViewModel item2 in holooCustomersInsertEditResultViewModel.Success)
											{
												if (string.IsNullOrEmpty(item2.ErpCode))
												{
													text = text + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
													continue;
												}
												text10 = text10 + "[CmpId=" + ((!string.IsNullOrEmpty(item2.Id)) ? item2.Id : "0") + "|,|LinkAccCode =" + ((!string.IsNullOrEmpty(item2.Code)) ? item2.Code : "") + "|,|LinkAccId=" + ((!string.IsNullOrEmpty(item2.ErpCode)) ? item2.ErpCode : "") + "|,|]@";
											}
											if (!string.IsNullOrEmpty(text10))
											{
												mct_Link_Result mct_Link_Result = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooUpdateCompanyLinkAccFields(text10, linkAccSettingDBId));
												if (mct_Link_Result != null && mct_Link_Result.Result <= 0)
												{
												}
											}
											else
											{
												text = text + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
											}
										}
										else if (holooCustomersInsertEditResultViewModel.Failure != null)
										{
											foreach (HolooCustomerInsertEditFailureResultViewModel item3 in holooCustomersInsertEditResultViewModel.Failure)
											{
												string[] obj = new string[11]
												{
													text,
													Messages.msgErrorRunFunction,
													"<br>",
													Messages.msgErrorInSendToOtherSystem,
													" ",
													Labels.OtherSystemsCompany,
													"<br>",
													item3.Error,
													"<br>",
													null,
													null
												};
												_ = item3.ErrorCode;
												obj[9] = " code:" + item3.ErrorCode;
												obj[10] = "<br>";
												text = string.Concat(obj);
											}
										}
										else
										{
											text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
										}
									}
									else
									{
										text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
									}
								}
								else
								{
									HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(result6);
									if (holooCustomerInsertEditResultViewModel != null)
									{
										string text11 = "";
										if (holooCustomerInsertEditResultViewModel.Success != null)
										{
											if (string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode))
											{
												text = text + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
											}
											else
											{
												text11 = text11 + "[CmpId=" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.Id)) ? holooCustomerInsertEditResultViewModel.Success.Id : "0") + "|,|LinkAccCode =" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.Code)) ? holooCustomerInsertEditResultViewModel.Success.Code : "") + "|,|LinkAccId=" + ((!string.IsNullOrEmpty(holooCustomerInsertEditResultViewModel.Success.ErpCode)) ? holooCustomerInsertEditResultViewModel.Success.ErpCode : "") + "|,|]@";
											}
											if (!string.IsNullOrEmpty(text11))
											{
												mct_Link_Result mct_Link_Result2 = Enumerable.FirstOrDefault<mct_Link_Result>((IEnumerable<mct_Link_Result>)_dbLink.CRMspLkHolooUpdateCompanyLinkAccFields(text11, linkAccSettingDBId));
												if (mct_Link_Result2 != null && mct_Link_Result2.Result <= 0)
												{
												}
											}
											else
											{
												text = text + string.Format(Messages.msgErrorOtherSystemsNotRegistered, Labels.OtherSystemsCompany, Labels.Holoo) + "<br>";
											}
										}
										else if (holooCustomerInsertEditResultViewModel.Failure != null)
										{
											string[] obj2 = new string[11]
											{
												text,
												Messages.msgErrorRunFunction,
												"<br>",
												Messages.msgErrorInSendToOtherSystem,
												" ",
												Labels.OtherSystemsCompany,
												"<br>",
												holooCustomerInsertEditResultViewModel.Failure.Error,
												"<br>",
												null,
												null
											};
											_ = holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
											obj2[9] = " code:" + holooCustomerInsertEditResultViewModel.Failure.ErrorCode;
											obj2[10] = "<br>";
											text = string.Concat(obj2);
										}
										else
										{
											text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
										}
									}
									else
									{
										text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
									}
								}
							}
							else
							{
								string[] obj3 = new string[8]
								{
									text,
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorEditInfo,
									" ",
									Labels.OtherSystemsCompany,
									"<br>",
									null
								};
								_ = httpResponseMessage.StatusCode;
								statusCode = httpResponseMessage.StatusCode;
								obj3[7] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
								text = string.Concat(obj3);
							}
						}
						num7 += num8;
						int count = num7 * 100 / num2;
						ProgressHub.SendMessage(string.IsNullOrEmpty(text) ? "ok" : text, count, userId);
					}
				}
				List<CRMspLkHolooSelectCompanyByCmpIds_Result> list6 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>(Enumerable.Where<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4, (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result m) => m.cmpLinkAccCustomerIdStr != null && m.cmpLinkAccCustomerIdStr != "")));
				if (list6 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list6))
				{
					int num9 = 200;
					int num10 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list6);
					int num11 = num10 / num9;
					int num12 = num10 % num9;
					if (num12 != 0)
					{
						num11++;
					}
					int num13 = 0;
					int num14 = num9;
					for (int k = 0; k < num11; k++)
					{
						HolooCustomerInsertEditViewModel holooCustomerInsertEditViewModel = new HolooCustomerInsertEditViewModel();
						holooCustomerInsertEditViewModel.custinfo = new List<HolooCustInfoIEViewModel>();
						num14 = ((k == num11 - 1 && num12 != 0) ? num12 : num9);
						for (int l = 0; l < num14; l++)
						{
							int index2 = k * num9 + l;
							CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result2 = list6[index2];
							if (cRMspLkHolooSelectCompanyByCmpIds_Result2 == null)
							{
								continue;
							}
							HolooCustInfoIEViewModel holooCustInfoIEViewModel = new HolooCustInfoIEViewModel
							{
								ispurchaser = ispurchaser,
								isseller = isseller,
								custtype = custtype
							};
							holooCustInfoIEViewModel.id = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyID.ToString();
							holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName ?? "";
							holooCustInfoIEViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpNationalCode ?? "";
							holooCustInfoIEViewModel.economicid = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpEconomicCode ?? "";
							holooCustInfoIEViewModel.tel = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpTel ?? "";
							holooCustInfoIEViewModel.fax = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpFax ?? "";
							holooCustInfoIEViewModel.city = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpCity ?? "";
							holooCustInfoIEViewModel.ostan = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpProvince ?? "";
							holooCustInfoIEViewModel.zipcode = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpZipCode ?? "";
							holooCustInfoIEViewModel.address = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpAddress ?? "";
							holooCustInfoIEViewModel.mobile = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsMobile ?? "";
							holooCustInfoIEViewModel.email = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsEmail ?? "";
							holooCustInfoIEViewModel.erpcode = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpLinkAccCustomerIdStr ?? "";
							if (cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpKind.GetValueOrDefault() == 1)
							{
								holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson;
								if (cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpName == "شخص" || cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpName == Labels.lblPerson)
								{
									holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson ?? "";
								}
								if (string.IsNullOrEmpty(holooCustInfoIEViewModel.name))
								{
									holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson;
								}
								holooCustInfoIEViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsNationalCode ?? "";
							}
							holooCustInfoIEViewModel.name = "-1";
							holooCustomerInsertEditViewModel.custinfo.Add(holooCustInfoIEViewModel);
						}
						if (holooCustomerInsertEditViewModel.custinfo != null && Enumerable.Any<HolooCustInfoIEViewModel>((IEnumerable<HolooCustInfoIEViewModel>)holooCustomerInsertEditViewModel.custinfo))
						{
							HttpClient httpClient2 = new HttpClient();
							httpClient2.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
							httpClient2.BaseAddress = new Uri(text3);
							httpClient2.DefaultRequestHeaders.Add("Authorization", value);
							httpClient2.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
							string text12 = "api/Customer";
							string text13 = "";
							if (result2)
							{
								text13 = ((!string.IsNullOrWhiteSpace(text13)) ? (text13 + "&") : (text13 + "?"));
								text13 += "allowDuplicateEco=true";
							}
							if (result3)
							{
								text13 = ((!string.IsNullOrWhiteSpace(text13)) ? (text13 + "&") : (text13 + "?"));
								text13 += "allowDuplicateNatCode=true";
							}
							if (result4)
							{
								text13 = ((!string.IsNullOrWhiteSpace(text13)) ? (text13 + "&") : (text13 + "?"));
								text13 += "allowDuplicateMobile=true";
							}
							text12 += text13;
							HttpContent content3 = new StringContent(JsonConvert.SerializeObject(holooCustomerInsertEditViewModel).Replace(",\"name\":\"-1\"", ""), Encoding.UTF8, "application/json");
							HttpResponseMessage httpResponseMessage2 = new HttpResponseMessage();
							httpResponseMessage2 = httpClient2.PutAsync(text12, content3).Result;
							if (httpResponseMessage2.IsSuccessStatusCode)
							{
								string result7 = httpResponseMessage2.Content.ReadAsStringAsync().Result;
								if (Enumerable.Count<HolooCustInfoIEViewModel>((IEnumerable<HolooCustInfoIEViewModel>)holooCustomerInsertEditViewModel.custinfo) > 1)
								{
									HolooCustomersInsertEditResultViewModel holooCustomersInsertEditResultViewModel2 = JsonConvert.DeserializeObject<HolooCustomersInsertEditResultViewModel>(result7);
									if (holooCustomersInsertEditResultViewModel2 != null)
									{
										if (holooCustomersInsertEditResultViewModel2.Failure != null)
										{
											foreach (HolooCustomerInsertEditFailureResultViewModel item4 in holooCustomersInsertEditResultViewModel2.Failure)
											{
												string[] obj4 = new string[11]
												{
													text,
													Messages.msgErrorRunFunction,
													"<br>",
													Messages.msgErrorInSendToOtherSystem,
													" ",
													Labels.OtherSystemsCompany,
													"<br>",
													item4.Error,
													"<br>",
													null,
													null
												};
												_ = item4.ErrorCode;
												obj4[9] = " code:" + item4.ErrorCode;
												obj4[10] = "<br>";
												text = string.Concat(obj4);
											}
										}
										else if (holooCustomersInsertEditResultViewModel2.Failure == null && holooCustomersInsertEditResultViewModel2.Success == null)
										{
											text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
										}
									}
									else
									{
										text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
									}
								}
								else
								{
									HolooCustomerInsertEditResultViewModel holooCustomerInsertEditResultViewModel2 = JsonConvert.DeserializeObject<HolooCustomerInsertEditResultViewModel>(result7);
									if (holooCustomerInsertEditResultViewModel2 != null)
									{
										if (holooCustomerInsertEditResultViewModel2.Failure != null)
										{
											string[] obj5 = new string[11]
											{
												text,
												Messages.msgErrorRunFunction,
												"<br>",
												Messages.msgErrorInSendToOtherSystem,
												" ",
												Labels.OtherSystemsCompany,
												"<br>",
												holooCustomerInsertEditResultViewModel2.Failure.Error,
												"<br>",
												null,
												null
											};
											_ = holooCustomerInsertEditResultViewModel2.Failure.ErrorCode;
											obj5[9] = " code:" + holooCustomerInsertEditResultViewModel2.Failure.ErrorCode;
											obj5[10] = "<br>";
											text = string.Concat(obj5);
										}
										else
										{
											text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
										}
									}
									else
									{
										text = text + Messages.msgErrorRunFunction + "<br>" + Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany;
									}
								}
							}
							else
							{
								string[] obj6 = new string[8]
								{
									text,
									Messages.msgErrorRunFunction,
									"<br>",
									Messages.msgErrorEditInfo,
									" ",
									Labels.OtherSystemsCompany,
									"<br>",
									null
								};
								_ = httpResponseMessage2.StatusCode;
								statusCode = httpResponseMessage2.StatusCode;
								obj6[7] = " code:" + ((object)(HttpStatusCode)(ref statusCode)).ToString();
								text = string.Concat(obj6);
							}
						}
						num13 += num14;
						int count2 = num13 * 100 / num2;
						ProgressHub.SendMessage(string.IsNullOrEmpty(text) ? "ok" : text, count2, userId);
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
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

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult HolooExportInfo(string records, bool ispurchaser, bool isseller, int custtype, int totalPage, int linkAccSettingDBId)
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
		bool flag = false;
		bool flag2 = false;
		bool flag3 = false;
		CommonResultViewModel<int> data;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			totalPage = ((totalPage > 0) ? totalPage : 0);
			text = "";
			int num2 = 0;
			string text2 = "";
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
				{
					list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
					if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
					{
						foreach (OtherSystemSelectedViewModel item in list2)
						{
							if (item.Selected)
							{
								text2 = text2 + item.Id + ",";
							}
						}
					}
				}
			}
			List<CRMspLkHolooSelectCompanyByCmpIds_Result> list3 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)_dbLink.CRMspLkHolooSelectCompanyByCmpIds(text2, lCID, result, linkAccSettingDBId));
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			string value = holooProvider.Authenticate();
			flag = holooProvider.AllowDuplicateEco;
			flag2 = holooProvider.AllowDuplicateNatCode;
			flag3 = holooProvider.AllowDuplicateMobile;
			if (!string.IsNullOrEmpty(value))
			{
				text = Messages.msgSuccessAction;
			}
			if (!string.IsNullOrEmpty(text))
			{
				num = 0;
				data = new CommonResultViewModel<int>
				{
					Data = num,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				};
				return Json(data, JsonRequestBehavior.AllowGet);
			}
			if (list3 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list3))
			{
				num2 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list3);
				List<CRMspLkHolooSelectCompanyByCmpIds_Result> list4 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>(Enumerable.Where<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list3, (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result m) => m.cmpLinkAccCustomerIdStr == null || m.cmpLinkAccCustomerIdStr == "")));
				if (list4 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4))
				{
					int num3 = 200;
					int num4 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list4);
					int num5 = num4 / num3;
					int num6 = num4 % num3;
					if (num6 != 0)
					{
						num5++;
					}
					int num7 = 0;
					int num8 = num3;
					for (int i = 0; i < num5; i++)
					{
						HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel> customerInfoReq = new HolooCustomerInsertEditIViewModel<HolooCustInfoInsertViewModel>();
						customerInfoReq.custinfo = new List<HolooCustInfoInsertViewModel>();
						num8 = ((i == num5 - 1 && num6 != 0) ? num6 : num3);
						for (int j = 0; j < num8; j++)
						{
							int index = i * num3 + j;
							CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result = list4[index];
							if (cRMspLkHolooSelectCompanyByCmpIds_Result == null)
							{
								continue;
							}
							HolooCustInfoInsertViewModel holooCustInfoInsertViewModel = new HolooCustInfoInsertViewModel
							{
								ispurchaser = ispurchaser,
								isseller = isseller,
								custtype = custtype
							};
							holooCustInfoInsertViewModel.id = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyID.ToString();
							holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName ?? "";
							holooCustInfoInsertViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpNationalCode ?? "";
							holooCustInfoInsertViewModel.economicid = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpEconomicCode ?? "";
							holooCustInfoInsertViewModel.tel = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpTel ?? "";
							holooCustInfoInsertViewModel.fax = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpFax ?? "";
							holooCustInfoInsertViewModel.city = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpCity ?? "";
							holooCustInfoInsertViewModel.ostan = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpProvince ?? "";
							holooCustInfoInsertViewModel.zipcode = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpZipCode ?? "";
							holooCustInfoInsertViewModel.address = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpAddress ?? "";
							holooCustInfoInsertViewModel.mobile = cRMspLkHolooSelectCompanyByCmpIds_Result.prsMobile ?? "";
							holooCustInfoInsertViewModel.email = cRMspLkHolooSelectCompanyByCmpIds_Result.prsEmail ?? "";
							if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpKind.GetValueOrDefault() == 1)
							{
								holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
								if (cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == "شخص" || cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName == Labels.lblPerson)
								{
									holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson ?? "";
								}
								if (string.IsNullOrEmpty(holooCustInfoInsertViewModel.name))
								{
									holooCustInfoInsertViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpMainPerson;
								}
								holooCustInfoInsertViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result.prsNationalCode ?? "";
							}
							customerInfoReq.custinfo.Add(holooCustInfoInsertViewModel);
						}
						if (customerInfoReq.custinfo != null && Enumerable.Any<HolooCustInfoInsertViewModel>((IEnumerable<HolooCustInfoInsertViewModel>)customerInfoReq.custinfo))
						{
							string errorMessage = "";
							string text3 = "";
							if (flag)
							{
								text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
								text3 += "allowDuplicateEco=true";
							}
							if (flag2)
							{
								text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
								text3 += "allowDuplicateNatCode=true";
							}
							if (flag3)
							{
								text3 = ((!string.IsNullOrWhiteSpace(text3)) ? (text3 + "&") : (text3 + "?"));
								text3 += "allowDuplicateMobile=true";
							}
							holooProvider.CompanyExportInfoInsert(text3, ref customerInfoReq, ref errorMessage);
							if (!string.IsNullOrEmpty(errorMessage))
							{
								text = errorMessage;
							}
						}
						num7 += num8;
						int count = num7 * 100 / num2;
						ProgressHub.SendMessage(string.IsNullOrEmpty(text) ? "ok" : text, count, userId);
					}
				}
				List<CRMspLkHolooSelectCompanyByCmpIds_Result> list5 = Enumerable.ToList<CRMspLkHolooSelectCompanyByCmpIds_Result>(Enumerable.Where<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list3, (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result m) => m.cmpLinkAccCustomerIdStr != null && m.cmpLinkAccCustomerIdStr != "")));
				if (list5 != null && Enumerable.Any<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list5))
				{
					int num9 = 200;
					int num10 = Enumerable.Count<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)list5);
					int num11 = num10 / num9;
					int num12 = num10 % num9;
					if (num12 != 0)
					{
						num11++;
					}
					int num13 = 0;
					int num14 = num9;
					for (int k = 0; k < num11; k++)
					{
						HolooCustomerInsertEditViewModel customerInfoReq2 = new HolooCustomerInsertEditViewModel();
						customerInfoReq2.custinfo = new List<HolooCustInfoIEViewModel>();
						num14 = ((k == num11 - 1 && num12 != 0) ? num12 : num9);
						for (int l = 0; l < num14; l++)
						{
							int index2 = k * num9 + l;
							CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result2 = list5[index2];
							if (cRMspLkHolooSelectCompanyByCmpIds_Result2 == null)
							{
								continue;
							}
							HolooCustInfoIEViewModel holooCustInfoIEViewModel = new HolooCustInfoIEViewModel
							{
								ispurchaser = ispurchaser,
								isseller = isseller,
								custtype = custtype
							};
							holooCustInfoIEViewModel.id = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyID.ToString();
							holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName ?? "";
							holooCustInfoIEViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpNationalCode ?? "";
							holooCustInfoIEViewModel.economicid = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpEconomicCode ?? "";
							holooCustInfoIEViewModel.tel = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpTel ?? "";
							holooCustInfoIEViewModel.fax = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpFax ?? "";
							holooCustInfoIEViewModel.city = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpCity ?? "";
							holooCustInfoIEViewModel.ostan = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpProvince ?? "";
							holooCustInfoIEViewModel.zipcode = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpZipCode ?? "";
							holooCustInfoIEViewModel.address = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpAddress ?? "";
							holooCustInfoIEViewModel.mobile = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsMobile ?? "";
							holooCustInfoIEViewModel.email = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsEmail ?? "";
							holooCustInfoIEViewModel.erpcode = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpLinkAccCustomerIdStr ?? "";
							if (cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpKind.GetValueOrDefault() == 1)
							{
								holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson;
								if (cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpName == "شخص" || cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpName == Labels.lblPerson)
								{
									holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson ?? "";
								}
								if (string.IsNullOrEmpty(holooCustInfoIEViewModel.name))
								{
									holooCustInfoIEViewModel.name = cRMspLkHolooSelectCompanyByCmpIds_Result2.CompanyName + " - " + cRMspLkHolooSelectCompanyByCmpIds_Result2.cmpMainPerson;
								}
								holooCustInfoIEViewModel.nationalid = cRMspLkHolooSelectCompanyByCmpIds_Result2.prsNationalCode ?? "";
							}
							holooCustInfoIEViewModel.name = "-1";
							customerInfoReq2.custinfo.Add(holooCustInfoIEViewModel);
						}
						if (customerInfoReq2.custinfo != null && Enumerable.Any<HolooCustInfoIEViewModel>((IEnumerable<HolooCustInfoIEViewModel>)customerInfoReq2.custinfo))
						{
							string errorMessage2 = "";
							string text4 = "";
							if (flag)
							{
								text4 = ((!string.IsNullOrWhiteSpace(text4)) ? (text4 + "&") : (text4 + "?"));
								text4 += "allowDuplicateEco=true";
							}
							if (flag2)
							{
								text4 = ((!string.IsNullOrWhiteSpace(text4)) ? (text4 + "&") : (text4 + "?"));
								text4 += "allowDuplicateNatCode=true";
							}
							if (flag3)
							{
								text4 = ((!string.IsNullOrWhiteSpace(text4)) ? (text4 + "&") : (text4 + "?"));
								text4 += "allowDuplicateMobile=true";
							}
							holooProvider.CompanyExportInfoEdit(text4, ref customerInfoReq2, ref errorMessage2);
							if (!string.IsNullOrEmpty(errorMessage2))
							{
								text = errorMessage2;
							}
						}
						num13 += num14;
						int count2 = num13 * 100 / num2;
						ProgressHub.SendMessage(string.IsNullOrEmpty(text) ? "ok" : text, count2, userId);
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.msgErrorNotSelectedItem + ")";
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
	public JsonResult GetHolooExportCompanyList(string records, int linkAccSettingDBId, int totalPage, string fDate = "", string tDate = "", string value = "")
	{
		//IL_0260: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkHolooSelectCompany_Result item2 in Enumerable.ToList<CRMspLkHolooSelectCompany_Result>((IEnumerable<CRMspLkHolooSelectCompany_Result>)_dbLink.CRMspLkHolooSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, result2, linkAccSettingDBId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = string.IsNullOrEmpty(item2.cmpLinkAccCustomerIdStr)
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public ActionResult HolooImportCompany()
	{
		GetCmpReferUser();
		GetLinkAccHolooDatabases();
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult HolooCompany_Read([DataSourceRequest] DataSourceRequest request, int linkAccSettingDBId, string fDate = "", string tDate = "", string value = "", string cmpNationalCode = "", string fEditDate = "", string tEditDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
			list = GetHolooCompanyList(linkAccSettingDBId, fDate, tDate, value, "", "", cmpNationalCode, fEditDate, tEditDate);
			if (list == null)
			{
				list = new List<LkCompanyAndPersonViewModel>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult HolooImportInfo(int linkAccSettingDBId, string records, int referUserId, string fDate = "", string tDate = "", string value = "", string cmpNationalCode = "", string fEditDate = "", string tEditDate = "", bool preventCompanyFieldsUpdate = false)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
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
			DateTime value2 = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
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
			List<LkCompanyAndPersonViewModel> list3 = new List<LkCompanyAndPersonViewModel>();
			List<LkCompanyAndPersonViewModel> holooCompanyList = GetHolooCompanyList(linkAccSettingDBId, fDate, tDate, value, "", "", cmpNationalCode, fEditDate, tEditDate);
			if (holooCompanyList != null)
			{
				List<LkCompanyAndPersonViewModel> list4 = holooCompanyList;
				if (list4 != null)
				{
					if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list4))
					{
						if (list2 != null)
						{
							foreach (OtherSystemSelectedVIiewModel item in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list4, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item.Id));
								if (lkCompanyAndPersonViewModel != null)
								{
									list3.Add(lkCompanyAndPersonViewModel);
								}
							}
						}
					}
					else
					{
						string text2 = Messages.msgErrorRunFunction + " (get list from Holoo) ";
						Exception e = new Exception(text2);
						ErrorSignal.FromCurrentContext().Raise(e);
						text = text2;
					}
				}
				else
				{
					string text3 = Messages.msgErrorRunFunction + " (get list from Holoo) ";
					Exception e2 = new Exception(text3);
					ErrorSignal.FromCurrentContext().Raise(e2);
					text = text3;
				}
			}
			else
			{
				string text4 = Messages.msgErrorRunFunction + " (get list from Holoo) ";
				Exception e3 = new Exception(text4);
				ErrorSignal.FromCurrentContext().Raise(e3);
				text = text4;
			}
			if (list3 != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list3))
			{
				text = "";
				int num2;
				int num3 = (num2 = Enumerable.Count<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list3));
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
					List<LkCompanyAndPersonViewModel> list5 = new List<LkCompanyAndPersonViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list5.Add(list3[num7]);
					}
					if (list5 == null)
					{
						continue;
					}
					if (num5 == 1 && num7 < num8)
					{
						num7 = num8;
					}
					if (!Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list5))
					{
						continue;
					}
					string value4 = JsonConvert.SerializeObject(list5);
					value4 = value4.ClearHiddenCharacters();
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					CRMLinkSpEntities dbLink = _dbLink;
					string cmpJson = value4;
					int? referUserId2 = referUserId;
					int? userId2 = userId;
					short? month = value3;
					int? fPId = id;
					short? year = result2;
					DateTime? registerDate = value2;
					string appType2 = appType;
					dbLink.CRMspLkHolooInsertUpdateCompanyByJson(cmpJson, referUserId2, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId, linkAccSettingDBId, preventCompanyFieldsUpdate);
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
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
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
	public JsonResult GetHolooImportCompanyList(int linkAccSettingDBId, string records, string fDate = "", string tDate = "", string value = "", string cmpNationalCode = "")
	{
		//IL_0102: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		try
		{
			List<LkCompanyAndPersonViewModel> list2 = new List<LkCompanyAndPersonViewModel>();
			list2 = GetHolooCompanyList(linkAccSettingDBId, fDate, tDate, value, "", "", cmpNationalCode);
			if (list2 == null)
			{
				list2 = new List<LkCompanyAndPersonViewModel>();
			}
			else if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list2))
			{
				foreach (LkCompanyAndPersonViewModel item2 in list2)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item2.RowNumber,
						Id = (item2.cmpLinkAccCustomerIdStr ?? ""),
						Selected = (item2.CompanyId == 0)
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
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(list, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<LkCompanyAndPersonViewModel> GetHolooCompanyList_Old(string fDate = "", string tDate = "", string code = "", string fCode = "", string tCode = "", string nationalid = "", string fEditDate = "", string tEditDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			DateTime dateTime3 = DateTime.Now;
			DateTime dateTime4 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fEditDate))
			{
				dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(fEditDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tEditDate))
			{
				dateTime4 = DateTime.Parse(PersianDate.GetFormatetdDate(tEditDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
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
						if (!string.IsNullOrWhiteSpace(code))
						{
							text6 = (string.IsNullOrWhiteSpace(text6) ? "?" : (text6 + "&"));
							text6 = text6 + "code=" + code;
						}
						if (!string.IsNullOrWhiteSpace(fCode) && !string.IsNullOrWhiteSpace(tCode))
						{
							text6 = (string.IsNullOrWhiteSpace(text6) ? "?" : (text6 + "&"));
							text6 = text6 + "code.from=" + fCode + "&code.to=" + tCode;
						}
						if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
						{
							text6 = (string.IsNullOrWhiteSpace(text6) ? "?" : (text6 + "&"));
							text6 = text6 + "cdate.from=" + dateTime.ToString("yyyy-MM-dd 00:00:00", new CultureInfo("en-US")) + "&cdate.to=" + dateTime2.ToString("yyyy-MM-dd 23:59:59", new CultureInfo("en-US"));
						}
						if (!string.IsNullOrWhiteSpace(fEditDate) && !string.IsNullOrWhiteSpace(tEditDate))
						{
							text6 = (string.IsNullOrWhiteSpace(text6) ? "?" : (text6 + "&"));
							text6 = text6 + "date.from=" + dateTime3.ToString("yyyy-MM-dd 00:00:00", new CultureInfo("en-US")) + "&date.to=" + dateTime4.ToString("yyyy-MM-dd 23:59:59", new CultureInfo("en-US"));
						}
						if (!string.IsNullOrWhiteSpace(nationalid))
						{
							text6 = (string.IsNullOrWhiteSpace(text6) ? "?" : (text6 + "&"));
							text6 = text6 + "nationalid=" + nationalid;
						}
						HttpClient httpClient = new HttpClient();
						httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
						httpClient.BaseAddress = new Uri(text);
						httpClient.DefaultRequestHeaders.Add("Authorization", value);
						httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
						string requestUri = "api/Customer" + text6;
						HttpResponseMessage result3 = httpClient.GetAsync(requestUri).Result;
						if (result3.IsSuccessStatusCode)
						{
							HolooCustomerListViewModel holooCustomerListViewModel = JsonConvert.DeserializeObject<HolooCustomerListViewModel>(result3.Content.ReadAsStringAsync().Result);
							if (holooCustomerListViewModel != null && holooCustomerListViewModel.Customer != null && Enumerable.Any<HolooCustomerInfoViewModel>((IEnumerable<HolooCustomerInfoViewModel>)holooCustomerListViewModel.Customer))
							{
								List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
								int num = 1;
								foreach (HolooCustomerInfoViewModel item in holooCustomerListViewModel.Customer)
								{
									LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
									lkCompanyAndPersonViewModel.cmpName = item.Name;
									lkCompanyAndPersonViewModel.cmpTel = item.Tel;
									lkCompanyAndPersonViewModel.cmpFax = item.Fax;
									lkCompanyAndPersonViewModel.cmpAddress = item.Address;
									lkCompanyAndPersonViewModel.cmpZipCode = item.ZipCode;
									lkCompanyAndPersonViewModel.cmpEconomicCode = item.EconomicId;
									lkCompanyAndPersonViewModel.cmpNationalCode = item.NationalId;
									lkCompanyAndPersonViewModel.cmpLinkAccCode = item.Code;
									lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = item.ErpCode;
									lkCompanyAndPersonViewModel.CityName = item.City;
									lkCompanyAndPersonViewModel.ProvinceName = item.Ostan;
									int result4 = 0;
									int.TryParse(item.type.ToString(), out result4);
									if (result4 != 1)
									{
										lkCompanyAndPersonViewModel.cmpKind = 0;
									}
									else
									{
										lkCompanyAndPersonViewModel.cmpKind = 1;
									}
									lkCompanyAndPersonViewModel.prsMobile = item.Mobile;
									lkCompanyAndPersonViewModel.prsEmail = item.Email;
									lkCompanyAndPersonViewModel.RowNumber = num;
									CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.ErpCode));
									if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
									{
										lkCompanyAndPersonViewModel.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
									}
									else
									{
										lkCompanyAndPersonViewModel.CompanyId = 0;
									}
									list.Add(lkCompanyAndPersonViewModel);
									num++;
								}
							}
						}
						else
						{
							Exception e6 = new Exception(Messages.msgErrorRunFunction + " (get customer information from Holoo) ");
							ErrorSignal.FromCurrentContext().Raise(e6);
						}
					}
				}
				else
				{
					Exception e7 = new Exception(Messages.errorInReadingSetting);
					ErrorSignal.FromCurrentContext().Raise(e7);
				}
			}
			else
			{
				Exception e8 = new Exception(Messages.errorInReadingSetting);
				ErrorSignal.FromCurrentContext().Raise(e8);
			}
		}
		catch (Exception e9)
		{
			ErrorSignal.FromCurrentContext().Raise(e9);
		}
		return list;
	}

	public List<LkCompanyAndPersonViewModel> GetHolooCompanyList(int linkAccSettingDBId, string fDate = "", string tDate = "", string code = "", string fCode = "", string tCode = "", string nationalid = "", string fEditDate = "", string tEditDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<LkCompanyAndPersonViewModel> listItems = new List<LkCompanyAndPersonViewModel>();
		try
		{
			DateTime dateTime = DateTime.Now;
			DateTime dateTime2 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fDate))
			{
				dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(fDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrWhiteSpace(tDate))
			{
				dateTime2 = DateTime.Parse(PersianDate.GetFormatetdDate(tDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			DateTime dateTime3 = DateTime.Now;
			DateTime dateTime4 = DateTime.Now;
			if (!string.IsNullOrWhiteSpace(fEditDate))
			{
				dateTime3 = DateTime.Parse(PersianDate.GetFormatetdDate(fEditDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(tEditDate))
			{
				dateTime4 = DateTime.Parse(PersianDate.GetFormatetdDate(tEditDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
			if (!string.IsNullOrEmpty(holooProvider.Authenticate()))
			{
				return listItems;
			}
			string text = "";
			if (!string.IsNullOrWhiteSpace(code))
			{
				text = (string.IsNullOrWhiteSpace(text) ? "?" : (text + "&"));
				text = text + "code=" + code;
			}
			if (!string.IsNullOrWhiteSpace(fCode) && !string.IsNullOrWhiteSpace(tCode))
			{
				text = (string.IsNullOrWhiteSpace(text) ? "?" : (text + "&"));
				text = text + "code.from=" + fCode + "&code.to=" + tCode;
			}
			if (!string.IsNullOrWhiteSpace(fDate) && !string.IsNullOrWhiteSpace(tDate))
			{
				text = (string.IsNullOrWhiteSpace(text) ? "?" : (text + "&"));
				text = text + "cdate.from=" + dateTime.ToString("yyyy-MM-dd 00:00:00", new CultureInfo("en-US")) + "&cdate.to=" + dateTime2.ToString("yyyy-MM-dd 23:59:59", new CultureInfo("en-US"));
			}
			if (!string.IsNullOrWhiteSpace(fEditDate) && !string.IsNullOrWhiteSpace(tEditDate))
			{
				text = (string.IsNullOrWhiteSpace(text) ? "?" : (text + "&"));
				text = text + "date.from=" + dateTime3.ToString("yyyy-MM-dd 00:00:00", new CultureInfo("en-US")) + "&date.to=" + dateTime4.ToString("yyyy-MM-dd 23:59:59", new CultureInfo("en-US"));
			}
			if (!string.IsNullOrWhiteSpace(nationalid))
			{
				text = (string.IsNullOrWhiteSpace(text) ? "?" : (text + "&"));
				text = text + "nationalid=" + nationalid;
			}
			holooProvider.HolooCompanyList(text, ref listItems, fDate, tDate, code, fCode, tCode, nationalid, fEditDate, tEditDate);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return listItems;
	}

	public bool HolooOrdCmpImportInfo(int linkAccSettingDBId, List<LkCompanyAndPersonViewModel> list, int cmpReferUserId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		bool result2 = false;
		string text = "";
		try
		{
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result3 = 0;
			short.TryParse(id.ToString(), out result3);
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (cmpReferUserId == 0)
			{
				cmpReferUserId = userId;
			}
			if (list != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list))
			{
				text = "";
				int num = Enumerable.Count<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list);
				_ = new long[num];
				int num2 = 100;
				int num3 = num / num2;
				int num4 = num % num2;
				int num5 = 0;
				int num6 = num2;
				if (num4 != 0)
				{
					num3++;
				}
				for (int i = 0; i < num3; i++)
				{
					if (i == num3 - 1 && num4 != 0)
					{
						num6 = num4;
					}
					List<LkCompanyAndPersonViewModel> list2 = new List<LkCompanyAndPersonViewModel>();
					for (int j = 0; j < num6; j++)
					{
						num5 = i * num2 + j;
						list2.Add(list[num5]);
					}
					if (list2 != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list2))
					{
						string cmpJson = JsonConvert.SerializeObject(list2);
						ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
						CRMLinkSpEntities dbLink = _dbLink;
						int? referUserId = cmpReferUserId;
						int? userId2 = userId;
						short? month = value2;
						int? fPId = id;
						short? year = result3;
						DateTime? registerDate = value;
						string appType2 = appType;
						dbLink.CRMspLkInsertUpdateCompanyByJson(cmpJson, referUserId, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
						if (objectParameter.Value != null && !string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
						{
							text = text + "<br>" + objectParameter.Value.ToString();
						}
					}
				}
			}
			else
			{
				text = Messages.msgErrorRunFunction + " (" + Messages.ErrorNotFound + ")";
			}
			if (string.IsNullOrWhiteSpace(text))
			{
				result2 = true;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public string HolooGetCmpAccountingDetail_old(int cmpId, int countDecimal = 0)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrEmpty(companyById.cmpLinkAccCode))
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
									string text7 = "?code=" + companyById.cmpLinkAccCode;
									HttpClient httpClient = new HttpClient();
									httpClient.Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout();
									httpClient.BaseAddress = new Uri(text);
									httpClient.DefaultRequestHeaders.Add("Authorization", text5);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string requestUri = "api/Customer" + text7;
									HttpResponseMessage result4 = httpClient.GetAsync(requestUri).Result;
									if (!result4.IsSuccessStatusCode)
									{
										Exception e6 = new Exception(Messages.msgErrorRunFunction + " (get customer information from Holoo) ");
										ErrorSignal.FromCurrentContext().Raise(e6);
										return Labels.frmError;
									}
									HolooCustomerListViewModel holooCustomerListViewModel = JsonConvert.DeserializeObject<HolooCustomerListViewModel>(result4.Content.ReadAsStringAsync().Result);
									if (holooCustomerListViewModel != null)
									{
										if (holooCustomerListViewModel.Customer != null)
										{
											if (holooCustomerListViewModel.Customer.Count != 1)
											{
												Exception e7 = new Exception(Messages.msgErrorRunFunction + " (not find customer information from Holoo or find more one than) ");
												ErrorSignal.FromCurrentContext().Raise(e7);
												return Labels.frmError;
											}
											decimal valueOrDefault = holooCustomerListViewModel.Customer[0].Mandeh.GetValueOrDefault();
											result = countDecimal switch
											{
												0 => $"{valueOrDefault:N0}", 
												-1 => valueOrDefault.ToString(), 
												_ => $"{valueOrDefault:N2}", 
											};
										}
										else
										{
											result = "0";
										}
									}
								}
							}
							else
							{
								Exception e8 = new Exception(Messages.errorInReadingSetting);
								ErrorSignal.FromCurrentContext().Raise(e8);
								result = Labels.frmError;
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
						Exception e10 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not have code");
						ErrorSignal.FromCurrentContext().Raise(e10);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e11 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e11);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e12 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e12);
				result = Labels.frmError;
			}
		}
		catch (Exception e13)
		{
			ErrorSignal.FromCurrentContext().Raise(e13);
			result = Labels.frmError;
		}
		return result;
	}

	[AjaxOnly]
	public string HolooGetCmpAccountingDetail(int linkAccSettingDBId, int cmpId, int countDecimal = 0)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspLkHolooSelectCompanyByCmpIds_Result cRMspLkHolooSelectCompanyByCmpIds_Result = Enumerable.FirstOrDefault<CRMspLkHolooSelectCompanyByCmpIds_Result>((IEnumerable<CRMspLkHolooSelectCompanyByCmpIds_Result>)_dbLink.CRMspLkHolooSelectCompanyByCmpIds($"{cmpId}", lCID, result2, linkAccSettingDBId), (Func<CRMspLkHolooSelectCompanyByCmpIds_Result, bool>)((CRMspLkHolooSelectCompanyByCmpIds_Result c) => c.CompanyID == cmpId));
				if (cRMspLkHolooSelectCompanyByCmpIds_Result != null)
				{
					if (!string.IsNullOrEmpty(cRMspLkHolooSelectCompanyByCmpIds_Result.cmpLinkAccCode))
					{
						CRMIdeal.Classes.Helper.OtherSystems.HolooProvider holooProvider = new CRMIdeal.Classes.Helper.OtherSystems.HolooProvider(linkAccSettingDBId);
						string text = holooProvider.Authenticate();
						if (!string.IsNullOrEmpty(text))
						{
							return text;
						}
						string errorMessage = "";
						string strParam = "?code=" + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpLinkAccCode;
						holooProvider.GetCmpAccountingDetail(strParam, countDecimal, ref errorMessage, ref result);
						if (!string.IsNullOrEmpty(errorMessage))
						{
							return errorMessage;
						}
					}
					else
					{
						Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + cRMspLkHolooSelectCompanyByCmpIds_Result.cmpName + " not have code");
						ErrorSignal.FromCurrentContext().Raise(e);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e3);
				result = Labels.frmError;
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			result = Labels.frmError;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendToAcc")]
	public ActionResult NoAvIICmpSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string NoAvIIActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		_003C_003Ec__DisplayClass56_0 _003C_003Ec__DisplayClass56_ = new _003C_003Ec__DisplayClass56_0();
		_003C_003Ec__DisplayClass56_.cmpId = cmpId;
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (_003C_003Ec__DisplayClass56_.cmpId > 0)
			{
				try
				{
					CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(_003C_003Ec__DisplayClass56_.cmpId);
					if (cmp != null)
					{
						string text2 = "";
						List<CRMspSelectUsersWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(false, true, lCID, result));
						if (list != null)
						{
							CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.UserId == cmp.cmpReferUserId));
							if (cRMspSelectUsersWithAccLinkField_Result == null)
							{
								text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundReferUserInAcc, cmp.cmpNumber.GetValueOrDefault().ToString(), Labels.NoAvaranII, cmp.ReferUser ?? "") + "|";
								return text;
							}
							string linkAccUserCode = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserCode;
							if (string.IsNullOrWhiteSpace(linkAccUserCode))
							{
								text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundReferUserInAcc, cmp.cmpNumber.GetValueOrDefault().ToString(), Labels.NoAvaranII, cRMspSelectUsersWithAccLinkField_Result.FullName ?? "") + "|";
								return text;
							}
							text2 = linkAccUserCode;
						}
						if (string.IsNullOrWhiteSpace(text2))
						{
							CRMspSelectUsersById_Result cRMspSelectUsersById_Result = CRMIdeal.Classes.Helper.User.SelectUsersById(cmp.cmpReferUserId);
							string arg = "";
							if (cRMspSelectUsersById_Result != null)
							{
								arg = cRMspSelectUsersById_Result.FullName ?? "";
							}
							text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundReferUserInAcc, cmp.cmpNumber.GetValueOrDefault().ToString(), Labels.NoAvaranII, arg) + "|";
							return text;
						}
						int result2 = 0;
						int.TryParse(cmp.cmpMainPersonId.ToString(), out result2);
						string text3 = "";
						string text4 = "";
						string text5 = "";
						string text6 = "";
						if (result2 > 0)
						{
							CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cmp.cmpMainPersonId, lCID, result));
							if (cRMspSelectCompanyPersonsByID_Result != null)
							{
								int.TryParse(cRMspSelectCompanyPersonsByID_Result.CompanyPersonID.ToString(), out result2);
								text3 = cRMspSelectCompanyPersonsByID_Result.prsFName;
								text4 = cRMspSelectCompanyPersonsByID_Result.prsLName;
								text5 = cRMspSelectCompanyPersonsByID_Result.prsMobile;
								text6 = cRMspSelectCompanyPersonsByID_Result.prsNationalCode;
							}
						}
						else
						{
							CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmp.CompanyID, lCID, result));
							if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
							{
								int.TryParse(cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID.ToString(), out result2);
								text4 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName;
								text4 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName;
								text5 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile;
								text6 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode;
							}
						}
						if (!string.IsNullOrWhiteSpace(cmp.cmpCode))
						{
							if (result2 > 0)
							{
								ServiceSoapClient serviceSoapClient = new ServiceSoapClient();
								string text7 = "";
								text7 = serviceSoapClient.InsertEditIntoShopKharid(cmp.cmpCode, cmp.CompanyName ?? "", text3 ?? cmp.CompanyName ?? "", text4 ?? "", cmp.cmpAddress ?? "", cmp.cmpEconomicCode ?? "", cmp.cmpPreTel + cmp.cmpTel, (cmp.cmpKind == 0) ? (cmp.cmpMobile ?? "") : (text5 ?? ""), "", "", "", "", "", "", (cmp.cmpKind.GetValueOrDefault() == 1) ? (text6 ?? "") : (cmp.cmpNationalCode ?? ""), text2);
								text = text7;
								if (!string.IsNullOrWhiteSpace(text7))
								{
									if (text7.ToLower().IndexOf("success") >= 0 || text7.ToLower().IndexOf("be edit") >= 0)
									{
										DbSet<CrmCompany> crmCompany = _dbTbl.CrmCompany;
										ParameterExpression val = Expression.Parameter(typeof(CrmCompany), "m");
										CrmCompany crmCompany2 = Queryable.FirstOrDefault<CrmCompany>((IQueryable<CrmCompany>)crmCompany, Expression.Lambda<Func<CrmCompany, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass56_, typeof(_003C_003Ec__DisplayClass56_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
										if (crmCompany2 != null)
										{
											crmCompany2.cmpLinkAccCode = cmp.cmpCode;
											_dbTbl.Entry(crmCompany2).State = EntityState.Modified;
											_dbTbl.SaveChanges();
											string text8 = cmp.cmpCode ?? "";
											text = "1|" + text8;
										}
										else
										{
											text = Messages.msgErrorInSendToOtherSystem + " " + Labels.OtherSystemsCompany + "|";
										}
									}
									else
									{
										text = Messages.msgErrorInSendToOtherSystem + "<br>" + text7 + "|";
									}
								}
								else
								{
									text = Messages.msgErrorRunFunction + "|";
								}
							}
							else
							{
								text = text + Messages.msgErrorPersonNotDefined + "|";
							}
						}
						else
						{
							text = text + string.Format(Messages.msgErrorIsNotEnteredItem, Labels.cmpCode) + "|";
						}
					}
				}
				catch (Exception ex)
				{
					text = text + "\n\nException: " + ex.Message + "|";
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult NoAvIIExportCompany()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult NoAvIIExportCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkNoAvIISelectCompany_Result> enumerable = new List<CRMspLkNoAvIISelectCompany_Result>();
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
			enumerable = Enumerable.ToList<CRMspLkNoAvIISelectCompany_Result>((IEnumerable<CRMspLkNoAvIISelectCompany_Result>)_dbLink.CRMspLkNoAvIISelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value3) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value4) : null, value, pageNumber, value2, lCID, result, result2));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult NoAvIIExportInfo(string records, int totalPage)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
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
			int userId = UserLogin.CurrentUser.UserId;
			totalPage = ((totalPage > 0) ? totalPage : 0);
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
						string text2 = NoAvIIActCmpSendToAcc(item.Id);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
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

	[AjaxOnly]
	public JsonResult GetNoAvIIExportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "")
	{
		//IL_025f: Unknown result type (might be due to invalid IL or missing references)
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
			foreach (CRMspLkNoAvIISelectCompany_Result item2 in Enumerable.ToList<CRMspLkNoAvIISelectCompany_Result>((IEnumerable<CRMspLkNoAvIISelectCompany_Result>)_dbLink.CRMspLkNoAvIISelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value4) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value5) : null, value, value3, value2, lCID, result, result2)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID.GetValueOrDefault(),
					Selected = string.IsNullOrEmpty(item2.cmpLinkAccCode)
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

	public List<CRMspLkSelectCompany_Result> GetCompanyList(string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		List<CRMspLkSelectCompany_Result> list = new List<CRMspLkSelectCompany_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			DateTime value2 = DateTime.Now;
			DateTime value3 = DateTime.Now;
			int userLastCId = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out userLastCId);
			}
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
			list = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)_dbLink.CRMspLkSelectCompany(UserLogin.CurrentUser.UserId, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value2) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value3) : null, value, 0, 0, lCID, result, userLastCId, currentItemId));
			if (list != null)
			{
				if (Enumerable.Count<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list, (Func<CRMspLkSelectCompany_Result, bool>)((CRMspLkSelectCompany_Result x) => !string.IsNullOrWhiteSpace(x.cmpLinkAccData))) > 0)
				{
					foreach (CRMspLkSelectCompany_Result item in list)
					{
						if (string.IsNullOrWhiteSpace(item.cmpLinkAccData))
						{
							continue;
						}
						List<LinkAccDataViewModel> list2 = JsonConvert.DeserializeObject<List<LinkAccDataViewModel>>(item.cmpLinkAccData);
						if (list2 == null)
						{
							continue;
						}
						List<LinkAccDataViewModel> list3 = Enumerable.ToList<LinkAccDataViewModel>(Enumerable.Where<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list2, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => !string.IsNullOrWhiteSpace(x.Id) || !string.IsNullOrWhiteSpace(x.Code))));
						if (Center.HaveModule)
						{
							list3 = Enumerable.ToList<LinkAccDataViewModel>(Enumerable.Where<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3, (Func<LinkAccDataViewModel, bool>)((LinkAccDataViewModel x) => x.CId == userLastCId)));
						}
						if (list3 == null)
						{
							continue;
						}
						LinkAccDataViewModel linkAccDataViewModel = Enumerable.FirstOrDefault<LinkAccDataViewModel>((IEnumerable<LinkAccDataViewModel>)list3);
						if (linkAccDataViewModel != null)
						{
							if (!string.IsNullOrWhiteSpace(linkAccDataViewModel.Id))
							{
								item.cmpLinkAccCustomerIdStr = linkAccDataViewModel.Id;
							}
							else if (!string.IsNullOrWhiteSpace(linkAccDataViewModel.Code))
							{
								item.cmpLinkAccCustomerIdStr = linkAccDataViewModel.Code;
							}
						}
					}
				}
				list = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)Enumerable.OrderBy<CRMspLkSelectCompany_Result, long?>((IEnumerable<CRMspLkSelectCompany_Result>)list, (Func<CRMspLkSelectCompany_Result, long?>)((CRMspLkSelectCompany_Result m) => m.RowNumber)));
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendToAcc")]
	public ActionResult KyanCmpSendToAcc()
	{
		return View();
	}

	[AjaxOnly]
	public string KyanActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string customerFirstName = "";
					string customerLastName = "";
					string text2 = "";
					string socialSecurityNumber = "";
					string text3 = "";
					string text4 = "";
					string address = "";
					CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (cmp != null)
					{
						int result2 = 0;
						string groupName = "";
						List<CRMspSelectCompanyGroupsIIWithAccLinkField_Result> list = Enumerable.ToList<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyGroupsIIWithAccLinkField(false, lCID, result));
						if (list != null && cmp.cmpGroupIdII.HasValue)
						{
							CRMspSelectCompanyGroupsIIWithAccLinkField_Result cRMspSelectCompanyGroupsIIWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyGroupsIIWithAccLinkField_Result>)list, (Func<CRMspSelectCompanyGroupsIIWithAccLinkField_Result, bool>)((CRMspSelectCompanyGroupsIIWithAccLinkField_Result m) => m.CompanyGroupIIID == cmp.cmpGroupIdII));
							if (cRMspSelectCompanyGroupsIIWithAccLinkField_Result != null)
							{
								string linkAccCmpGroupIIIdStr = cRMspSelectCompanyGroupsIIWithAccLinkField_Result.LinkAccCmpGroupIIIdStr;
								groupName = cRMspSelectCompanyGroupsIIWithAccLinkField_Result.GroupIIName ?? "";
								if (string.IsNullOrEmpty(linkAccCmpGroupIIIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundGroupInAcc, cmp.cmpNumber.ToString(), Labels.Kyan, cRMspSelectCompanyGroupsIIWithAccLinkField_Result.GroupIIName ?? "") + "|";
									return text;
								}
								int.TryParse(linkAccCmpGroupIIIdStr, out result2);
							}
						}
						object obj = cmp.cmpPreTel;
						if (obj == null)
						{
							obj = cmp.cmpTel ?? "";
							if (obj == null)
							{
								obj = "";
							}
						}
						string text5 = (string)obj;
						if (cmp.cmpKind == 0)
						{
							customerFirstName = cmp.CompanyName ?? "";
							customerLastName = cmp.CompanyName ?? "";
							socialSecurityNumber = cmp.cmpNationalCode;
							text3 = cmp.cmpMobile;
							text4 = cmp.cmpEmail;
							text2 = "";
							address = cmp.cmpCountry + "-" + cmp.cmpProvince + "-" + cmp.cmpCity + "-" + cmp.cmpAddress;
							if (cmp.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cmp.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result != null)
								{
									text3 = cRMspSelectCompanyPersonsByID_Result.prsMobile;
									text4 = cRMspSelectCompanyPersonsByID_Result.prsEmail;
								}
							}
						}
						else
						{
							CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cmp.cmpMainPersonId, lCID, result));
							if (cRMspSelectCompanyPersonsByID_Result2 != null)
							{
								customerFirstName = cRMspSelectCompanyPersonsByID_Result2.prsFName ?? cRMspSelectCompanyPersonsByID_Result2.prsLName;
								customerLastName = cRMspSelectCompanyPersonsByID_Result2.prsLName ?? "";
								socialSecurityNumber = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode;
								text3 = cRMspSelectCompanyPersonsByID_Result2.prsMobile;
								text4 = cRMspSelectCompanyPersonsByID_Result2.prsEmail;
								if (cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.HasValue)
								{
									text2 = DateTime.Parse(cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
								{
									customerFirstName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName ?? cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName;
									customerLastName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName;
									socialSecurityNumber = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode;
									text3 = cRMspSelectCompanyPersonsByID_Result2.prsMobile;
									text4 = cRMspSelectCompanyPersonsByID_Result2.prsEmail;
									text2 = "";
								}
								else
								{
									text = Messages.msgErrorNotDefinedCmpPerson + "|";
								}
							}
						}
						if (!cmp.cmpLinkAccCustomerId.HasValue || cmp.cmpLinkAccCustomerId <= 0)
						{
							ValidationSoapHeader kyanToken = GetKyanToken();
							if (kyanToken != null)
							{
								if (!string.IsNullOrEmpty(kyanToken.TokenAUT))
								{
									CRMIdeal.LinkKyan.Customer customer = new CRMIdeal.LinkKyan.Customer();
									customer.Address = address;
									customer.BirthDayDate = (string.IsNullOrWhiteSpace(text2) ? string.Empty : text2);
									customer.MemberID = cmp.CompanyID.ToString();
									customer.Credit = default(decimal);
									customer.customerFirstName = customerFirstName;
									customer.customerLastName = customerLastName;
									customer.Email = text4 ?? "";
									customer.Gender = -1;
									customer.GroupID = result2;
									customer.GroupName = groupName;
									customer.Note = cmp.cmpDescription ?? "";
									customer.Phone = ((!string.IsNullOrEmpty(text5)) ? text5 : (text3 ?? ""));
									customer.Point = default(decimal);
									customer.SocialSecurityNumber = socialSecurityNumber;
									customer.customerID = 0;
									ResponseDataOfString responseDataOfString = new KyanOnlineSaleServiceSoapClient().CreateCustomer(kyanToken, null, customer);
									text = responseDataOfString.ResponseMessage.ToString();
									if (!string.IsNullOrWhiteSpace(text))
									{
										int result3 = 0;
										int.TryParse(responseDataOfString.Responseresult.ToString(), out result3);
										if (text.ToLower().IndexOf("success") >= 0 && result3 > 0)
										{
											_dbLink.CRMspUpdateCompanyWithAccLinkField(cmpId, cmpLinkAccCode: result3.ToString(), cmpLinkAccCodeId: 0, cmpLinkAccCustomerId: result3, cmpLinkAccCustomerIdStr: "", userId: userId, month1: value2, year1: value3, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, cmpCode: result3.ToString(), cmpLinkAccData: "");
											string text6 = result3.ToString();
											text = "1|" + text6;
										}
										else
										{
											text = Messages.msgErrorInSendToOtherSystem + "<br>" + text + "|";
										}
									}
									else
									{
										text = Messages.msgErrorRunFunction + "|";
									}
								}
								else
								{
									text = Messages.errorInReadingSetting + "|";
								}
							}
							else
							{
								text = Messages.errorInReadingSetting + "|";
							}
						}
						else if (cmp.cmpLinkAccCustomerId.HasValue || cmp.cmpLinkAccCustomerId > 0)
						{
							ValidationSoapHeader kyanToken2 = GetKyanToken();
							if (kyanToken2 != null)
							{
								if (!string.IsNullOrEmpty(kyanToken2.TokenAUT))
								{
									CRMIdeal.LinkKyan.Customer customer2 = new CRMIdeal.LinkKyan.Customer();
									customer2.Address = address;
									customer2.BirthDayDate = (string.IsNullOrWhiteSpace(text2) ? string.Empty : text2);
									customer2.MemberID = cmp.CompanyID.ToString();
									customer2.Credit = default(decimal);
									customer2.customerFirstName = customerFirstName;
									customer2.customerLastName = customerLastName;
									customer2.Email = text4 ?? "";
									customer2.Gender = -1;
									customer2.GroupID = result2;
									customer2.GroupName = groupName;
									customer2.Note = cmp.cmpDescription ?? "";
									customer2.Phone = ((!string.IsNullOrEmpty(text5)) ? text5 : (text3 ?? ""));
									customer2.Point = default(decimal);
									customer2.SocialSecurityNumber = socialSecurityNumber;
									customer2.customerID = cmp.cmpLinkAccCustomerId.GetValueOrDefault();
									text = new KyanOnlineSaleServiceSoapClient().UpdateCustomerInfo(kyanToken2, null, customer2).ResponseMessage.ToString();
									string cmpLinkAccCode2 = cmp.cmpLinkAccCode;
									if (!string.IsNullOrWhiteSpace(text))
									{
										if (text.ToLower().Contains("success"))
										{
											CRMLinkSpEntities dbLink = _dbLink;
											int? companyId2 = cmpId;
											string cmpLinkAccCode3 = cmpLinkAccCode2 ?? "";
											dbLink.CRMspUpdateCompanyWithAccLinkField(companyId2, 0, cmpLinkAccCode3, cmp.cmpLinkAccCustomerId, "", userId, value2, value3, value, registerDatePersian, appType, cmpLinkAccCode2 ?? "", "");
											string text7 = cmpLinkAccCode2 ?? "";
											text = "1|" + text7;
										}
										else
										{
											text = Messages.msgErrorInSendToOtherSystem + "<br>" + text + "|";
										}
									}
									else
									{
										text = Messages.msgErrorRunFunction + "|";
									}
								}
								else
								{
									text = Messages.errorInReadingSetting + "|";
								}
							}
							else
							{
								text = Messages.errorInReadingSetting + "|";
							}
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult KyanExportCompany()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult KyanExportCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		List<CRMspLkSelectCompany_Result> enumerable = new List<CRMspLkSelectCompany_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult KyanExportInfo(string records, int totalPage)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
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
			int userId = UserLogin.CurrentUser.UserId;
			totalPage = ((totalPage > 0) ? totalPage : 0);
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
						string text2 = KyanActCmpSendToAcc(item.Id);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
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

	[AjaxOnly]
	public JsonResult GetKyanExportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "")
	{
		//IL_00a3: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkSelectCompany_Result item2 in Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = string.IsNullOrEmpty(item2.cmpLinkAccCustomerId.ToString())
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public ActionResult KyanImportCompany()
	{
		return View();
	}

	public KyanCompanyInfoViewModelObjects GetKyanCompanyList(string fDate = "", string tDate = "", int beginNumber = 0, int recordCount = 300)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		KyanCompanyInfoViewModelObjects kyanCompanyInfoViewModelObjects = new KyanCompanyInfoViewModelObjects();
		List<KyanCompanyInfoViewModel> list = new List<KyanCompanyInfoViewModel>();
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
			KyanOnlineSaleServiceSoapClient kyanOnlineSaleServiceSoapClient = new KyanOnlineSaleServiceSoapClient();
			ValidationSoapHeader kyanToken = GetKyanToken();
			if (kyanToken != null)
			{
				if (!string.IsNullOrEmpty(kyanToken.TokenAUT))
				{
					if (beginNumber != 0)
					{
						ResponseDataOfcustomerModel customerListWithPageRow = kyanOnlineSaleServiceSoapClient.GetCustomerListWithPageRow(kyanToken, null, (!string.IsNullOrEmpty(fDate)) ? new DateTime?(value) : null, (!string.IsNullOrEmpty(tDate)) ? new DateTime?(value2) : null, beginNumber, recordCount, 0);
						if (customerListWithPageRow != null && customerListWithPageRow.ResponseMessage.ToString().ToLower().Contains("success") && Enumerable.Count<customerModel>((IEnumerable<customerModel>)customerListWithPageRow.ResponseResult) > 0)
						{
							long num = 1L;
							List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: true);
							customerModel[] responseResult = customerListWithPageRow.ResponseResult;
							foreach (customerModel item2 in responseResult)
							{
								KyanCompanyInfoViewModel kyanCompanyInfoViewModel = new KyanCompanyInfoViewModel();
								kyanCompanyInfoViewModel.Address = item2.Address;
								kyanCompanyInfoViewModel.BirthDayDate = item2.BirthDayDate;
								kyanCompanyInfoViewModel.Credit = item2.Credit;
								kyanCompanyInfoViewModel.customerFirstName = item2.customerFirstName;
								kyanCompanyInfoViewModel.customerID = item2.customerID;
								kyanCompanyInfoViewModel.customerLastName = item2.customerLastName;
								kyanCompanyInfoViewModel.Email = item2.Email;
								kyanCompanyInfoViewModel.Gender = item2.Gender;
								kyanCompanyInfoViewModel.GroupID = item2.GroupID;
								kyanCompanyInfoViewModel.GroupName = item2.GroupName;
								kyanCompanyInfoViewModel.MemberID = item2.MemberID;
								kyanCompanyInfoViewModel.Note = item2.Note;
								kyanCompanyInfoViewModel.Phone = item2.Phone;
								kyanCompanyInfoViewModel.Point = item2.Point;
								kyanCompanyInfoViewModel.SocialSecurityNumber = item2.SocialSecurityNumber;
								kyanCompanyInfoViewModel.RowNumber = num;
								if (list2.FindIndex((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerId == item2.customerID) > 0)
								{
									CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerId == item2.customerID)));
									kyanCompanyInfoViewModel.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
								}
								list.Add(kyanCompanyInfoViewModel);
								num++;
							}
						}
					}
					else
					{
						ResponseDataOfCustomer customerList = kyanOnlineSaleServiceSoapClient.GetCustomerList(kyanToken, null, (!string.IsNullOrEmpty(fDate)) ? value.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : string.Empty, (!string.IsNullOrEmpty(tDate)) ? value2.ToString("yyyy-MM-dd", new CultureInfo("en-US")) : string.Empty);
						if (customerList != null && customerList.ResponseMessage.ToString().ToLower().Contains("success") && Enumerable.Count<CRMIdeal.LinkKyan.Customer>((IEnumerable<CRMIdeal.LinkKyan.Customer>)customerList.ResponseResult) > 0)
						{
							long num2 = 1L;
							List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: true);
							CRMIdeal.LinkKyan.Customer[] responseResult2 = customerList.ResponseResult;
							foreach (CRMIdeal.LinkKyan.Customer item in responseResult2)
							{
								KyanCompanyInfoViewModel kyanCompanyInfoViewModel2 = new KyanCompanyInfoViewModel();
								kyanCompanyInfoViewModel2.Address = item.Address;
								kyanCompanyInfoViewModel2.BirthDayDate = item.BirthDayDate;
								kyanCompanyInfoViewModel2.Credit = item.Credit;
								kyanCompanyInfoViewModel2.customerFirstName = item.customerFirstName;
								kyanCompanyInfoViewModel2.customerID = item.customerID;
								kyanCompanyInfoViewModel2.customerLastName = item.customerLastName;
								kyanCompanyInfoViewModel2.Email = item.Email;
								kyanCompanyInfoViewModel2.Gender = item.Gender;
								kyanCompanyInfoViewModel2.GroupID = item.GroupID;
								kyanCompanyInfoViewModel2.GroupName = item.GroupName;
								kyanCompanyInfoViewModel2.MemberID = item.MemberID;
								kyanCompanyInfoViewModel2.Note = item.Note;
								kyanCompanyInfoViewModel2.Phone = item.Phone;
								kyanCompanyInfoViewModel2.Point = item.Point;
								kyanCompanyInfoViewModel2.SocialSecurityNumber = item.SocialSecurityNumber;
								kyanCompanyInfoViewModel2.RowNumber = num2;
								if (list3.FindIndex((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerId == item.customerID) > 0)
								{
									CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerId == item.customerID)));
									kyanCompanyInfoViewModel2.CompanyId = cRMspSelectCompanyWithAccLinkField_Result2.CompanyID;
								}
								list.Add(kyanCompanyInfoViewModel2);
								num2++;
							}
						}
					}
					kyanCompanyInfoViewModelObjects.lst = list;
					kyanCompanyInfoViewModelObjects.FilteredLst = list;
					kyanCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
					kyanCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
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
		return kyanCompanyInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actShowInfo")]
	public ActionResult KyanCompany_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", int beginNumber = 0, int recordCount = 300)
	{
		List<KyanCompanyInfoViewModel> list = new List<KyanCompanyInfoViewModel>();
		KyanCompanyInfoViewModelObjects kyanCompanyList = GetKyanCompanyList(fDate, tDate, beginNumber, recordCount);
		if (kyanCompanyList != null)
		{
			list = kyanCompanyList.lst;
			foreach (KyanCompanyInfoViewModel item in list)
			{
				item.customerLastName = item.customerFirstName + " " + item.customerLastName;
			}
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmImportFromAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult KyanImportInfo(string records, string fDate = "", string tDate = "", int beginNumber = 0, int recordCount = 300)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
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
			List<KyanCompanyInfoViewModel> list3 = new List<KyanCompanyInfoViewModel>();
			List<KyanCompanyInfoViewModel> lst = GetKyanCompanyList(fDate, tDate, beginNumber, recordCount).lst;
			if (lst != null)
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list4 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: true);
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
				{
					foreach (KyanCompanyInfoViewModel item in Enumerable.ToList<KyanCompanyInfoViewModel>(Enumerable.Where<KyanCompanyInfoViewModel>((IEnumerable<KyanCompanyInfoViewModel>)lst, (Func<KyanCompanyInfoViewModel, bool>)((KyanCompanyInfoViewModel w) => w.customerID.ToString() == SelectedRowitem.Id))))
					{
						if (list4 != null && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4))
						{
							CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerId == item.customerID));
							if (cRMspSelectCompanyWithAccLinkField_Result != null)
							{
								item.customerID = cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerId.GetValueOrDefault();
							}
						}
						if (!string.IsNullOrWhiteSpace(item.BirthDayDate))
						{
							DateTime.Parse(item.BirthDayDate, new CultureInfo("en-US"));
							item.BirthDate_Persian = DateTime.Parse(item.BirthDayDate, new CultureInfo("en-US")).ToString("yyyyMMdd");
							string text2 = item.BirthDate_Persian;
							DateTime value3 = default(DateTime);
							string text3 = "";
							try
							{
								if (!string.IsNullOrEmpty(text2))
								{
									text3 = PersianDate.GetFormatetdDate(text2.Replace("/", ""));
									switch (lCID)
									{
									case 1065:
										value3 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
										text2 = value3.ToString("yyyyMMdd");
										break;
									case 1025:
										value3 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
										text2 = value3.ToString("yyyyMMdd", new PersianCulture());
										break;
									default:
										value3 = DateTime.Parse(text3 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
										text2 = value3.ToString("yyyyMMdd", new PersianCulture());
										break;
									}
								}
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								string text4 = Messages.msgErrorRunFunction + " (" + Messages.WrongDateTime + ")";
								Exception e2 = new Exception(text4);
								ErrorSignal.FromCurrentContext().Raise(e2);
								text = text4;
							}
							if (text2 != null)
							{
								text2 = text2.Replace("/", "").Replace("-", "").Replace("_", "")
									.Replace(".", "")
									.Replace(",", "")
									.Replace("\\", "");
							}
							item.BirthDate_DateTime = value3;
						}
						list3.Add(item);
					}
				}
			}
			else
			{
				string text5 = Messages.msgErrorRunFunction + " (get list from Kyan) ";
				Exception e3 = new Exception(text5);
				ErrorSignal.FromCurrentContext().Raise(e3);
				text = text5;
			}
			if (list3 != null && Enumerable.Any<KyanCompanyInfoViewModel>((IEnumerable<KyanCompanyInfoViewModel>)list3))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				CRMLinkSpEntities dbLink = _dbLink;
				int? userId2 = userId;
				short? month = value2;
				int? fPId = id;
				short? year = result2;
				DateTime? registerDate = value;
				string appType2 = appType;
				dbLink.CRMspLkKyanInsertUpdateCompany(json, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
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
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
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
	public JsonResult GetKyanImportCompanyList(string records, string fDate = "", string tDate = "", int beginNumber = 0, int recordCount = 300)
	{
		//IL_009c: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<KyanCompanyInfoViewModel> list2 = new List<KyanCompanyInfoViewModel>();
			KyanCompanyInfoViewModelObjects kyanCompanyList = GetKyanCompanyList(fDate, tDate, beginNumber, recordCount);
			if (kyanCompanyList != null)
			{
				list2 = kyanCompanyList.lst;
			}
			foreach (KyanCompanyInfoViewModel item2 in list2)
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber,
					Id = item2.customerID,
					Selected = (item2.CompanyId <= 0)
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedViewModel> list3 = new List<OtherSystemSelectedViewModel>();
				list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3))
				{
					foreach (OtherSystemSelectedViewModel item3 in list3)
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public string PayvastActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string text2 = "";
					string text3 = "";
					string text4 = "";
					DateTime registrationDate = DateTime.Now;
					DateTime registrationDate2 = DateTime.Now;
					string text5 = "";
					string registerationNumber = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string email = "";
					string address = "";
					int result2 = -1;
					string text10 = "";
					CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (cmp != null)
					{
						if (!cmp.cmpTypeId.HasValue)
						{
							text = string.Format(Messages.ErrorEmpty, Labels.cmpTypeId);
							return text;
						}
						CRMspSelectCompanyTypesWithAccLinkField_Result cRMspSelectCompanyTypesWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyTypesWithAccLinkField_Result>(Enumerable.Where<CRMspSelectCompanyTypesWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyTypesWithAccLinkField_Result>)SelectCompanyTypesWithAccLinkField(withLinkAccCmpTypeIdStr: true, lCID, result), (Func<CRMspSelectCompanyTypesWithAccLinkField_Result, bool>)((CRMspSelectCompanyTypesWithAccLinkField_Result x) => x.CompanyTypeID == cmp.cmpTypeId)));
						if (cRMspSelectCompanyTypesWithAccLinkField_Result == null)
						{
							text = string.Format(Messages.msgErrorInSendCompanyToAccLinkNotFoundCmpTypeInAcc, cmp.cmpNumber, Labels.Payvast);
							return text;
						}
						if (string.IsNullOrWhiteSpace(cRMspSelectCompanyTypesWithAccLinkField_Result.LinkAccCmpTypeIdStr))
						{
							text = string.Format(Messages.msgErrorInSendCompanyToAccLinkNotFoundCmpTypeInAcc, cmp.cmpNumber, Labels.Payvast);
							return text;
						}
						int.TryParse(cRMspSelectCompanyTypesWithAccLinkField_Result.LinkAccCmpTypeIdStr, out result2);
						if (cmp.cmpPreTel == null)
						{
							_ = cmp.cmpTel ?? "";
						}
						text10 = cmp.cmpEconomicCode ?? "";
						text6 = cmp.cmpZipCode ?? "";
						object obj = cmp.cmpPreTel;
						if (obj == null)
						{
							obj = cmp.cmpTel ?? "";
							if (obj == null)
							{
								obj = "";
							}
						}
						text7 = (string)obj;
						text9 = cmp.cmpFax ?? "";
						if (cmp.cmpKind == 0)
						{
							text2 = cmp.CompanyName ?? "";
							text3 = cmp.CompanyName ?? "";
							text4 = "";
							text5 = cmp.cmpNationalCode ?? "";
							text6 = cmp.cmpZipCode ?? "";
							object obj2 = cmp.cmpPreTel;
							if (obj2 == null)
							{
								obj2 = cmp.cmpTel ?? "";
								if (obj2 == null)
								{
									obj2 = "";
								}
							}
							text7 = (string)obj2;
							text9 = cmp.cmpFax ?? "";
							address = cmp.cmpCountry + "-" + cmp.cmpProvince + "-" + cmp.cmpCity + "-" + cmp.cmpAddress;
							registrationDate2 = cmp.FirstRegisterDate ?? DateTime.Now;
							if (cmp.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cmp.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result != null)
								{
									registerationNumber = cRMspSelectCompanyPersonsByID_Result.prsIdentityNumber ?? "";
									text8 = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
									email = cRMspSelectCompanyPersonsByID_Result.prsEmail;
									text4 = cRMspSelectCompanyPersonsByID_Result.prsFatherName ?? "";
								}
							}
						}
						else
						{
							CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(cmp.cmpMainPersonId, lCID, result));
							if (cRMspSelectCompanyPersonsByID_Result2 != null)
							{
								text2 = cRMspSelectCompanyPersonsByID_Result2.prsFName ?? cRMspSelectCompanyPersonsByID_Result2.prsLName;
								text3 = cRMspSelectCompanyPersonsByID_Result2.prsLName ?? "";
								text4 = cRMspSelectCompanyPersonsByID_Result2.prsFatherName ?? "";
								text5 = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode ?? "";
								registerationNumber = cRMspSelectCompanyPersonsByID_Result2.prsIdentityNumber ?? "";
								text8 = cRMspSelectCompanyPersonsByID_Result2.prsMobile ?? "";
								email = cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? "";
								if (!string.IsNullOrWhiteSpace(cRMspSelectCompanyPersonsByID_Result2.prsBirthDate))
								{
									registrationDate = cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime ?? DateTime.Now;
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result == null)
								{
									text = Messages.msgErrorNotDefinedCmpPerson + "|";
									return text;
								}
								text2 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName ?? cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName;
								text3 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName ?? "";
								text4 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName ?? "";
								text5 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode ?? "";
								registerationNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber ?? "";
								text8 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile ?? "";
								email = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail ?? "";
								if (!string.IsNullOrWhiteSpace(cRMspSelectCompanyPersonsByID_Result2.prsBirthDate))
								{
									registrationDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime ?? DateTime.Now;
								}
							}
						}
						AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
						PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
						if (cmp.cmpKind.GetValueOrDefault() == 1)
						{
							text = accountingServiceSoapClient.AddRealCustomer(CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now), text2, text3, cmp.cmpTitle ?? "", text5, text7, text9, text8, text4, registerationNumber, 0, registrationDate, "", text6, "", 0.0, email, address, "", payvastSetting.PayvastCustomerAccountId, payvastSetting.PayvastCustomerFloatingAccountId, result2, "", "", "", "", payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, 0, foreignNational: false, "", "", "", 0).ToString();
						}
						else
						{
							int payvastFPId = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastFPId(DateTime.Now);
							string name = text2;
							string title = cmp.cmpTitle ?? "";
							string nationalIdentiry = text5;
							string fax = text9;
							string cellPhone = text8;
							text = accountingServiceSoapClient.AddLegalCustomer(payvastFPId, name, title, nationalIdentiry, text7, fax, cellPhone, "", cmp.cmpRegistrationNumber ?? "", 0, registrationDate2, "", text6, text10, 0.0, email, address, "", payvastSetting.PayvastCustomerAccountId, payvastSetting.PayvastCustomerFloatingAccountId, result2, "", "", "", "", payvastSetting.PayvastUsername, payvastSetting.PayvastPassword, 0, foreignNational: false, "", "", "", 0, 0).ToString();
						}
						if (!string.IsNullOrWhiteSpace(text) && text != "0" && text != "-1")
						{
							int value4 = int.Parse(text);
							_dbLink.CRMspUpdateCompanyWithAccLinkField(cmpId, cmpLinkAccCode: value4.ToString(), cmpLinkAccCodeId: 0, cmpLinkAccCustomerId: value4, cmpLinkAccCustomerIdStr: value4.ToString(), userId: userId, month1: value2, year1: value3, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, cmpCode: value4.ToString(), cmpLinkAccData: "");
							string text11 = value4.ToString();
							text = "1|" + text11;
						}
						else
						{
							text = Messages.msgErrorRunFunction + "|";
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult PayvastExportCompany()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actShowInfo")]
	public ActionResult PayvastExportCompany_Read([DataSourceRequest] DataSourceRequest request, int pageNumber, string fDate = "", string tDate = "", string value = "")
	{
		List<CRMspLkSelectCompany_Result> enumerable = new List<CRMspLkSelectCompany_Result>();
		try
		{
			enumerable = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmExportToAcc", ActionName = "actSendToAcc")]
	[AjaxOnly]
	public JsonResult PayvastExportInfo(string records, int totalPage)
	{
		//IL_00c9: Unknown result type (might be due to invalid IL or missing references)
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
			int userId = UserLogin.CurrentUser.UserId;
			totalPage = ((totalPage > 0) ? totalPage : 0);
			text = "";
			int num = 0;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
				list = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Selected)));
			}
			text = "";
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				num = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list);
				int num2 = 0;
				foreach (OtherSystemSelectedViewModel item in list)
				{
					string text2 = PayvastActCmpSendToAcc(item.Id);
					if (!string.IsNullOrEmpty(text2))
					{
						string[] array = text2.Split(new char[1] { '|' });
						if (array == null)
						{
							continue;
						}
						if (array[0] == "1")
						{
							long result2 = 0L;
							long.TryParse(array[1], out result2);
							if (result2 > 0)
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
	public JsonResult GetPayvastExportCompanyList(string records, int totalPage, string fDate = "", string tDate = "", string value = "")
	{
		//IL_0025: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			List<CRMspLkSelectCompany_Result> list2 = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value));
			List<OtherSystemSelectedViewModel> list3 = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			foreach (CRMspLkSelectCompany_Result item in list2)
			{
				bool selected = true;
				if (item.cmpLinkAccCustomerId > 0)
				{
					selected = false;
				}
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3) && Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Row == item.RowNumber))) != null)
				{
					selected = Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel x) => x.Row == item.RowNumber)).Selected;
				}
				OtherSystemSelectedViewModel item2 = new OtherSystemSelectedViewModel
				{
					Row = item.RowNumber.GetValueOrDefault(),
					Id = item.CompanyID,
					Selected = selected
				};
				list.Add(item2);
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
	[LoginAuthorize]
	public string GetPayvastCompanyList(int fromId = 0, int toId = 0, string name = "", string fName = "", string lName = "", string title = "", string nationalCode = "", int type = -1, string accountId = "", string cellPhone = "", string address = "", string economyCode = "", int topCount = 1000, int isLinkedType = 1)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		lkCompanyViewModel lkCompanyViewModel = new lkCompanyViewModel();
		lkCompanyViewModel.CompanyList = new List<LkCompanyInfoViewModel>();
		try
		{
			List<CRMspSelectCompanyWithAccLinkField_Result> LinkedCompanies = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: true);
			AccountingServiceSoapClient accountingServiceSoapClient = new AccountingServiceSoapClient();
			PayvastSettingViewModel payvastSetting = CRMIdeal.Classes.Helper.OtherSystems.GetPayvastSetting();
			List<CRMIdeal.LinkPayvast.Customer> list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)accountingServiceSoapClient.GetAllCustomersInfo(payvastSetting.PayvastUsername, payvastSetting.PayvastPassword));
			lkCompanyViewModel.TotalCount = Enumerable.Count<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list);
			lkCompanyViewModel.FirstId = ((Enumerable.FirstOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list) != null) ? Enumerable.FirstOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list).Id : 0);
			lkCompanyViewModel.LastId = ((Enumerable.LastOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list) != null) ? Enumerable.LastOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list).Id : 0);
			list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Id > 0)));
			if (fromId > 0)
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Id >= fromId)));
			}
			if (toId > 0)
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Id <= toId)));
			}
			if (!string.IsNullOrWhiteSpace(name))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Name.Contains(name))));
			}
			if (!string.IsNullOrWhiteSpace(fName))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Forename.Contains(fName))));
			}
			if (!string.IsNullOrWhiteSpace(lName))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Surname.Contains(lName))));
			}
			if (!string.IsNullOrWhiteSpace(title))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Title.Contains(title))));
			}
			if (!string.IsNullOrWhiteSpace(nationalCode))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.NationalCode == nationalCode)));
			}
			if (type == CrmCompanyKind_Legal)
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.MainTypeCode == _PayvastCompany_LegalId)));
			}
			else if (type == CrmCompanyKind_Real)
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.MainTypeCode == _PayvastCompany_RealId)));
			}
			if (!string.IsNullOrWhiteSpace(accountId))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.AccountId == accountId)));
			}
			if (!string.IsNullOrWhiteSpace(cellPhone))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.CellPhone == cellPhone)));
			}
			if (!string.IsNullOrWhiteSpace(address))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.Address.Contains(address))));
			}
			if (!string.IsNullOrWhiteSpace(economyCode))
			{
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => x.EconomyCode == economyCode)));
			}
			switch (isLinkedType)
			{
			case 1:
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)LinkedCompanies, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result f) => f.cmpLinkAccCustomerId == x.Id)) == null)));
				break;
			case 2:
				list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Where<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, (Func<CRMIdeal.LinkPayvast.Customer, bool>)((CRMIdeal.LinkPayvast.Customer x) => Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)LinkedCompanies, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result f) => f.cmpLinkAccCustomerId == x.Id)) != null)));
				break;
			}
			list = Enumerable.ToList<CRMIdeal.LinkPayvast.Customer>(Enumerable.Take<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list, topCount));
			lkCompanyViewModel.PagingTotalCount = Enumerable.Count<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list);
			lkCompanyViewModel.PagingFirstId = ((Enumerable.FirstOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list) != null) ? Enumerable.FirstOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list).Id : 0);
			lkCompanyViewModel.PagingLastId = ((Enumerable.LastOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list) != null) ? Enumerable.LastOrDefault<CRMIdeal.LinkPayvast.Customer>((IEnumerable<CRMIdeal.LinkPayvast.Customer>)list).Id : 0);
			foreach (CRMIdeal.LinkPayvast.Customer c in list)
			{
				if (c.Id == 0)
				{
					continue;
				}
				LkCompanyInfoViewModel lkCompanyInfoViewModel = new LkCompanyInfoViewModel();
				lkCompanyInfoViewModel.PersonsList = new List<LkCompanyPersonInfoViewModel>();
				lkCompanyInfoViewModel.GUId = Guid.NewGuid();
				CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)LinkedCompanies, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerId == c.Id));
				if (cRMspSelectCompanyWithAccLinkField_Result != null)
				{
					lkCompanyInfoViewModel.CompanyID = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
					lkCompanyInfoViewModel.Selected = false;
				}
				else
				{
					lkCompanyInfoViewModel.CompanyID = 0;
					lkCompanyInfoViewModel.Selected = true;
				}
				int num = lkCompanyViewModel.CompanyList.FindIndex((LkCompanyInfoViewModel x) => x.CmpLinkAccCustomerId == c.Id);
				if (num == -1)
				{
					lkCompanyInfoViewModel.CmpLinkAccCustomerId = c.Id;
					lkCompanyInfoViewModel.CmpLinkAccCustomerIdStr = c.Id.ToString();
					lkCompanyInfoViewModel.CmpLinkAccCode = c.Id.ToString();
					lkCompanyInfoViewModel.CmpLinkAccCodeId = null;
					lkCompanyInfoViewModel.CmpCode = c.Id.ToString();
					if (c.MainTypeCode == _PayvastCompany_RealId)
					{
						lkCompanyInfoViewModel.CmpName = Labels.OtherSystemsCompanyNamePerson;
					}
					else
					{
						lkCompanyInfoViewModel.CmpName = c.Name;
					}
					lkCompanyInfoViewModel.CmpTitle = ((c.MainTypeCode == _PayvastCompany_LegalId) ? c.Title : "");
					lkCompanyInfoViewModel.CmpNationalCode = c.NationalCode;
					if (c.MainTypeCode == _PayvastCompany_RealId)
					{
						lkCompanyInfoViewModel.CmpKindId = CrmCompanyKind_Real;
						lkCompanyInfoViewModel.CmpKind = Labels.cmpKindReal;
					}
					else if (c.MainTypeCode == _PayvastCompany_LegalId)
					{
						lkCompanyInfoViewModel.CmpKindId = CrmCompanyKind_Legal;
						lkCompanyInfoViewModel.CmpKind = Labels.cmpKindLegal;
					}
					else
					{
						lkCompanyInfoViewModel.CmpKindId = CrmCompanyKind_Legal;
						lkCompanyInfoViewModel.CmpKind = Labels.cmpKindLegal;
					}
					string[] phoneParts = CRMIdeal.Classes.Helper.Company.GetPhoneParts(c.Phone);
					if (phoneParts[1] != "")
					{
						lkCompanyInfoViewModel.CmpPreTel = phoneParts[0];
						lkCompanyInfoViewModel.CmpTel = phoneParts[1];
						lkCompanyInfoViewModel.CmpTelUpTo = phoneParts[2];
					}
					phoneParts = CRMIdeal.Classes.Helper.Company.GetPhoneParts(c.CellPhone);
					if (!string.IsNullOrWhiteSpace(phoneParts[1]))
					{
						if (string.IsNullOrWhiteSpace(lkCompanyInfoViewModel.CmpTel))
						{
							lkCompanyInfoViewModel.CmpPreTel = phoneParts[0];
							lkCompanyInfoViewModel.CmpTel = phoneParts[1];
							lkCompanyInfoViewModel.CmpTelUpTo = phoneParts[2];
						}
						else
						{
							lkCompanyInfoViewModel.CmpPreTelII = phoneParts[0];
							lkCompanyInfoViewModel.CmpTelII = phoneParts[1];
							lkCompanyInfoViewModel.CmpTelUpToII = phoneParts[2];
						}
					}
					lkCompanyInfoViewModel.CmpFax = c.Fax;
					lkCompanyInfoViewModel.CmpEconomicCode = c.EconomyCode;
					lkCompanyInfoViewModel.CmpAddress = c.Address;
					lkCompanyInfoViewModel.CmpZipCode = c.PostalCode;
					lkCompanyInfoViewModel.CmpEmail = c.EMail;
					lkCompanyInfoViewModel.LkCountryIdStr = c.CountryCode;
					lkCompanyInfoViewModel.CmpCountry = c.CountryName;
					lkCompanyInfoViewModel.LkProvinceIdStr = c.ProvinceCode;
					lkCompanyInfoViewModel.CmpProvince = c.ProvinceName;
					lkCompanyInfoViewModel.LkpCityIdStr = c.CityCode;
					lkCompanyInfoViewModel.CmpCity = c.CityName;
				}
				else
				{
					lkCompanyInfoViewModel = lkCompanyViewModel.CompanyList[num];
				}
				LkCompanyPersonInfoViewModel lkCompanyPersonInfoViewModel = new LkCompanyPersonInfoViewModel();
				if (c.MainTypeCode == _PayvastCompany_LegalId)
				{
					lkCompanyPersonInfoViewModel.PrsLName = c.FatherName_CEO;
				}
				else
				{
					lkCompanyPersonInfoViewModel.PrsFName = c.Forename;
					lkCompanyPersonInfoViewModel.PrsLName = c.Surname;
				}
				if (string.IsNullOrWhiteSpace(lkCompanyPersonInfoViewModel.PrsLName))
				{
					lkCompanyPersonInfoViewModel.PrsLName = Labels.lblUnknown;
				}
				lkCompanyPersonInfoViewModel.PrsTitle = ((c.MainTypeCode == _PayvastCompany_RealId) ? c.Title : "");
				if (CRMIdeal.Classes.Helper.Company.CheckMobileFormat(c.CellPhone) != "")
				{
					lkCompanyPersonInfoViewModel.PrsMobile = c.CellPhone;
				}
				if (CRMIdeal.Classes.Helper.Company.CheckMobileFormat(c.Phone) != "")
				{
					if (string.IsNullOrWhiteSpace(lkCompanyPersonInfoViewModel.PrsMobile))
					{
						lkCompanyPersonInfoViewModel.PrsMobile = c.Phone;
					}
					else
					{
						LkCompanyInfoViewModel lkCompanyInfoViewModel2 = lkCompanyInfoViewModel;
						lkCompanyInfoViewModel2.CmpTelDesc = lkCompanyInfoViewModel2.CmpTelDesc + c.Phone + " ";
					}
				}
				if (c.MainTypeCode == _PayvastCompany_RealId)
				{
					lkCompanyPersonInfoViewModel.PrsFatherName = c.FatherName_CEO;
				}
				lkCompanyInfoViewModel.PersonsList.Add(lkCompanyPersonInfoViewModel);
				if (num != -1)
				{
					lkCompanyViewModel.CompanyList[num].PersonsList.Add(lkCompanyPersonInfoViewModel);
				}
				else
				{
					lkCompanyViewModel.CompanyList.Add(lkCompanyInfoViewModel);
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			lkCompanyViewModel.ErrorMessage = ex.Message;
		}
		return JsonConvert.SerializeObject(lkCompanyViewModel);
	}

	public List<CRMspSelectCompanyTypesWithAccLinkField_Result> SelectCompanyTypesWithAccLinkField(bool withLinkAccCmpTypeIdStr = true, int currLangID = 1065, int defaultLanguageID = 1065)
	{
		List<CRMspSelectCompanyTypesWithAccLinkField_Result> result = new List<CRMspSelectCompanyTypesWithAccLinkField_Result>();
		try
		{
			result = Enumerable.ToList<CRMspSelectCompanyTypesWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyTypesWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyTypesWithAccLinkField(withLinkAccCmpTypeIdStr, currLangID, defaultLanguageID));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public string ShygunActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						string text11 = companyById.cmpPreTel + companyById.cmpTel;
						string text12 = companyById.cmpPreTelII + companyById.cmpTelII;
						text9 = companyById.cmpFax;
						if (companyById.cmpKind == 0)
						{
							text2 = companyById.CompanyName ?? "";
							text3 = "";
							text5 = companyById.cmpNationalCode;
							text6 = companyById.cmpMobile;
							text7 = companyById.cmpEmail;
							text4 = "";
							text10 = companyById.cmpTitle;
							text8 = companyById.cmpCountry + "-" + companyById.cmpProvince + "-" + companyById.cmpCity + "-" + companyById.cmpAddress;
							if (companyById.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result != null)
								{
									text6 = cRMspSelectCompanyPersonsByID_Result.prsMobile;
									text7 = cRMspSelectCompanyPersonsByID_Result.prsEmail ?? cRMspSelectCompanyPersonsByID_Result.prsEmailII;
								}
							}
						}
						else
						{
							CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
							if (cRMspSelectCompanyPersonsByID_Result2 != null)
							{
								text2 = cRMspSelectCompanyPersonsByID_Result2.prsFName ?? "";
								text3 = cRMspSelectCompanyPersonsByID_Result2.prsLName ?? "";
								text5 = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode;
								text6 = cRMspSelectCompanyPersonsByID_Result2.prsMobile;
								text7 = cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? cRMspSelectCompanyPersonsByID_Result2.prsEmailII;
								text10 = cRMspSelectCompanyPersonsByID_Result2.prsTitle;
								if (cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.HasValue)
								{
									text4 = DateTime.Parse(cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
								{
									text2 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName ?? "";
									text3 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName;
									text5 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode;
									text6 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile;
									text7 = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail ?? cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII;
									text10 = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle;
									text4 = "";
									if (cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime.HasValue)
									{
										text4 = DateTime.Parse(cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
								else
								{
									text = Messages.msgErrorNotDefinedCmpPerson + "|";
								}
							}
						}
						string text13 = "";
						CRMspSelectLinkAccShygunSettingDetails_Result cRMspSelectLinkAccShygunSettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunSettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunSettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunSettingDetails(0, companyById.cmpTypeId, "CompanyType", lCID, result), (Func<CRMspSelectLinkAccShygunSettingDetails_Result, bool>)((CRMspSelectLinkAccShygunSettingDetails_Result x) => x.LinkAccShygunSetting == "CmpMoeinAccCode"));
						if (cRMspSelectLinkAccShygunSettingDetails_Result != null)
						{
							text13 = cRMspSelectLinkAccShygunSettingDetails_Result.PartValue;
						}
						else
						{
							text = string.Format(Messages.msgErrorShygunEmptyMoeinCode, companyById.cmpType) + "|";
						}
						CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
						if (string.IsNullOrWhiteSpace(text13))
						{
							text = string.Format(Messages.msgErrorShygunEmptyMoeinCode, companyById.cmpType) + "|";
						}
						else if (shygunSetting != null || !string.IsNullOrWhiteSpace(text13))
						{
							if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
							{
								List<Account> list = new List<Account>();
								Account account = new Account();
								new Account();
								account.AccountName = ((!string.IsNullOrWhiteSpace(text2)) ? (text2 + " ") : "") + text3;
								account.MoinNumber = text13;
								account.GuId = Guid.NewGuid();
								account.Imemo = companyById.cmpDescription;
								account.Tel1 = text11 ?? "";
								account.Tel2 = text12 ?? "";
								account.Add1 = text8 ?? "";
								account.Add2 = companyById.cmpAddressDesc ?? "";
								account.Email = text7 ?? "";
								account.Mobile = text6 ?? "";
								account.Fax = text9 ?? "";
								account.UpdateKind = ActionType.insert;
								account.AccountTypeId = 2;
								if (companyById.cmpKind == 0)
								{
									account.AccountTypeLaw = 2;
								}
								else if (companyById.cmpKind.GetValueOrDefault() == 1)
								{
									account.AccountTypeLaw = 1;
								}
								else
								{
									account.AccountTypeLaw = null;
								}
								account.BirthDay = text4 ?? "";
								account.Imemo = companyById.cmpDescription ?? "";
								account.mellicode = text5 ?? "";
								account.Title = text10 ?? "";
								account.Web = companyById.cmpWebSite ?? "";
								list.Add(account);
								PutResults putResults = new WebServiePutAccount(shygunSetting.IP, shygunSetting.conf, list).PutOperation();
								if (putResults != null && putResults.Result != null)
								{
									foreach (PutResult item in putResults.Result)
									{
										if (!string.IsNullOrWhiteSpace(item.ErrorMessage))
										{
											text = text + "<br>Error:" + item.ErrorMessage + "|";
										}
									}
									if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).GuId.ToString()))
									{
										_dbLink.CRMspUpdateCompanyWithAccLinkField(cmpId, cmpLinkAccCode: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).Number, cmpLinkAccCodeId: 0, cmpLinkAccCustomerId: null, cmpLinkAccCustomerIdStr: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).GuId, userId: userId, month1: value2, year1: value3, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, cmpCode: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).Number, cmpLinkAccData: "");
										companyById.CompanyID.ToString();
										text = "1|" + Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).Number.ToString();
									}
								}
							}
							else if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
							{
								List<Account> list2 = new List<Account>();
								Account account2 = new Account();
								new Account();
								account2.AccountName = ((!string.IsNullOrWhiteSpace(text2)) ? (text2 + " ") : "") + text3;
								account2.MoinNumber = text13;
								account2.GuId = Guid.Parse(companyById.cmpLinkAccCustomerIdStr);
								account2.Imemo = companyById.cmpDescription;
								account2.Tel1 = text11 ?? "";
								account2.Tel2 = text12 ?? "";
								account2.Add1 = text8 ?? "";
								account2.Add2 = companyById.cmpAddressDesc ?? "";
								account2.Email = text7 ?? "";
								account2.Mobile = text6 ?? "";
								account2.Fax = text9 ?? "";
								account2.UpdateKind = ActionType.update;
								account2.AccountTypeId = 2;
								if (companyById.cmpKind == 0)
								{
									account2.AccountTypeLaw = 2;
								}
								else if (companyById.cmpKind.GetValueOrDefault() == 1)
								{
									account2.AccountTypeLaw = 1;
								}
								else
								{
									account2.AccountTypeLaw = null;
								}
								account2.BirthDay = text4 ?? "";
								account2.Imemo = companyById.cmpDescription ?? "";
								account2.mellicode = text5 ?? "";
								account2.Title = text10 ?? "";
								account2.Web = companyById.cmpWebSite ?? "";
								list2.Add(account2);
								PutResults putResults2 = new WebServiePutAccount(shygunSetting.IP, shygunSetting.conf, list2).PutOperation();
								if (putResults2 != null && putResults2.Result != null)
								{
									foreach (PutResult item2 in putResults2.Result)
									{
										if (!string.IsNullOrWhiteSpace(item2.ErrorMessage))
										{
											text = text + "<br>" + text + "|";
										}
									}
									if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults2.Result).GuId.ToString()))
									{
										_dbLink.CRMspUpdateCompanyWithAccLinkField(cmpId, cmpLinkAccCode: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults2.Result).Number, cmpLinkAccCodeId: 0, cmpLinkAccCustomerId: null, cmpLinkAccCustomerIdStr: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults2.Result).GuId, userId: userId, month1: value2, year1: value3, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, cmpCode: Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults2.Result).Number, cmpLinkAccData: "");
										companyById.CompanyID.ToString();
										text = "1|" + Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults2.Result).Number.ToString();
									}
								}
								else
								{
									text = "<br>" + Messages.msgErrorEmptyResultFromServer + "|";
								}
							}
						}
						else
						{
							text = Messages.errorInReadingSetting + "|";
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actExportToAcc")]
	public ActionResult ShygunExportCompany()
	{
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunExportCompany_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		List<CRMspLkSelectCompany_Result> list = new List<CRMspLkSelectCompany_Result>();
		try
		{
			list = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value, currentItemId));
			if (list != null && Enumerable.Any<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list))
			{
				foreach (CRMspLkSelectCompany_Result item in list)
				{
					item.cmpTel = item.cmpPreTel + item.cmpTel;
					item.cmpTelII = item.cmpPreTelII + item.cmpTelII;
					item.cmpAddress = item.cmpCountry + "-" + item.cmpProvince + "-" + item.cmpCity + "-" + item.cmpAddress;
					item.PersonBirthDate = (item.PersonBirthDateTime.HasValue ? item.PersonBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunExportInfo(string records, int currentItemId = 0)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
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
						string text2 = ShygunActCmpSendToAcc(item.Id);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
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

	[AjaxOnly]
	public JsonResult GetShygunExportCompanyList(string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkSelectCompany_Result item2 in Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value, currentItemId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = string.IsNullOrWhiteSpace(item2.cmpLinkAccCustomerIdStr)
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public ActionResult ShygunImportCompany()
	{
		GetCmpReferUser();
		return View();
	}

	public ShygunCompanyInfoViewModelObjects GetShygunCompanyList(string fAccountCode = "", string tAccountCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunCompanyInfoViewModelObjects shygunCompanyInfoViewModelObjects = new ShygunCompanyInfoViewModelObjects();
		shygunCompanyInfoViewModelObjects.lst = new List<ShygunCompanyInfoViewModel>();
		shygunCompanyInfoViewModelObjects.FilteredLst = new List<ShygunCompanyInfoViewModel>();
		List<ShygunCompanyInfoViewModel> list = new List<ShygunCompanyInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
			DomainAccount domainAccount = new DomainAccount();
			string startVersion = null;
			domainAccount.AccountNumber.From = fAccountCode;
			domainAccount.AccountNumber.To = tAccountCode;
			int rowStart = ((fNum > 0) ? fNum : 0);
			int rowCount = ((tNum >= 100) ? 100 : tNum);
			WebServiceGetAccount webServiceGetAccount = new WebServiceGetAccount(shygunSetting.IP, shygunSetting.conf, domainAccount, rowStart, rowCount, startVersion);
			try
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				int num = 1;
				foreach (DataRow item in (InternalDataCollectionBase)webServiceGetAccount.GetDataTableObject(out JsonRender).Rows)
				{
					DataRow val = item;
					ShygunCompanyInfoViewModel vm = new ShygunCompanyInfoViewModel();
					vm.AccountNumber = val[0].ToString();
					vm.AccountTypeId = val[3].ToString();
					vm.AccountName = val[5].ToString();
					vm.Imemo = val[6].ToString();
					vm.Tel1 = val[16].ToString();
					vm.Tel2 = val[17].ToString();
					vm.Fax = val[18].ToString();
					vm.Email = val[19].ToString();
					vm.Web = val[20].ToString();
					vm.Add1 = val[21].ToString();
					vm.Add2 = val[22].ToString();
					vm.City = val[23].ToString();
					vm.State = val[24].ToString();
					vm.ZipCode = val[25].ToString();
					vm.Country = val[26].ToString();
					vm.TaxCode = val[27].ToString();
					vm.Mobile = val[30].ToString();
					vm.mellicode = val[33].ToString();
					vm.BirthDay = val[37].ToString();
					vm.LocationCode = val[53].ToString();
					vm.LocationName = val[54].ToString();
					vm.LocationLatitude = val[55].ToString();
					vm.GuId = val["GuId"].ToString();
					vm.RowNumber = num;
					CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.GuId));
					if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
					{
						vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
					}
					else
					{
						vm.CompanyId = 0;
					}
					list.Add(vm);
					num++;
				}
				shygunCompanyInfoViewModelObjects.lst = list;
				shygunCompanyInfoViewModelObjects.FilteredLst = list;
				shygunCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
				shygunCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			}
			catch (Exception e)
			{
				ErrorSignal.FromCurrentContext().Raise(e);
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return shygunCompanyInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunCompany_Read([DataSourceRequest] DataSourceRequest request, string fAccountCode = "", string tAccountCode = "", int fNum = 0, int tNum = 100)
	{
		List<ShygunCompanyInfoViewModel> enumerable = new List<ShygunCompanyInfoViewModel>();
		ShygunCompanyInfoViewModelObjects shygunCompanyList = GetShygunCompanyList(fAccountCode, tAccountCode, fNum, tNum);
		if (shygunCompanyList != null)
		{
			enumerable = shygunCompanyList.lst;
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunImportInfo(string records, int referUserId = 0, string fAccountCode = "", string tAccountCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
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
			List<ShygunCompanyInfoViewModel> list3 = new List<ShygunCompanyInfoViewModel>();
			List<ShygunCompanyInfoViewModel> lst = GetShygunCompanyList(fAccountCode, tAccountCode, fNum, tNum).lst;
			if (lst != null)
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list4 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
				{
					foreach (ShygunCompanyInfoViewModel item in Enumerable.ToList<ShygunCompanyInfoViewModel>(Enumerable.Where<ShygunCompanyInfoViewModel>((IEnumerable<ShygunCompanyInfoViewModel>)lst, (Func<ShygunCompanyInfoViewModel, bool>)((ShygunCompanyInfoViewModel w) => w.GuId == SelectedRowitem.Id))))
					{
						if (list4 != null && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4))
						{
							CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerIdStr == item.GuId));
							if (cRMspSelectCompanyWithAccLinkField_Result != null)
							{
								item.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
							}
						}
						list3.Add(item);
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
			if (list3 != null && Enumerable.Any<ShygunCompanyInfoViewModel>((IEnumerable<ShygunCompanyInfoViewModel>)list3))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				CRMLinkSpEntities dbLink = _dbLink;
				int? referUserId2 = referUserId;
				int? userId2 = userId;
				short? month = value2;
				int? fPId = id;
				short? year = result2;
				DateTime? registerDate = value;
				string appType2 = appType;
				dbLink.CRMspLkShygunInsertUpdateCompany(json, referUserId2, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
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
	public JsonResult GetShygunImportCompanyList(string records, string fAccountCode = "", string tAccountCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunCompanyInfoViewModel item2 in GetShygunCompanyList(fAccountCode, tAccountCode, fNum, tNum).lst)
			{
				string id = "";
				if (!string.IsNullOrWhiteSpace(item2.GuId))
				{
					id = item2.GuId ?? "0";
				}
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = id,
					Selected = (item2.CompanyId <= 0)
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actLinkCmpWithAcc")]
	public ActionResult ShygunLinkedCompany()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActShygunLinkedCompany(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			List<LinkedCompanyWithAccViewModel> list = new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actLinkCmpWithAcc", UserLogin.CurrentUser))
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
				ShygunCompanyInfoViewModelObjects shygunCompanyList = GetShygunCompanyList(string.Empty, string.Empty, fromRec, recCount);
				if (shygunCompanyList == null)
				{
					flag = false;
					continue;
				}
				if (shygunCompanyList.lst == null || !Enumerable.Any<ShygunCompanyInfoViewModel>((IEnumerable<ShygunCompanyInfoViewModel>)shygunCompanyList.lst))
				{
					flag = false;
					continue;
				}
				foreach (ShygunCompanyInfoViewModel item2 in shygunCompanyList.lst)
				{
					LinkedCompanyWithAccViewModel item = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item2.AccountNumber,
						cmpLinkAccCodeId = 0,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item2.GuId,
						cmpName = item2.AccountName
					};
					list.Add(item);
				}
				fromRec += ((fromRec > 0) ? 100 : 101);
			}
			if (list == null || !Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListCmpInLinkAccIsEmpty, Labels.Shygun) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list));
				string text4 = "";
				text = "";
				List<CRMspLkShygunLinkedCompany_Result> list2 = Enumerable.ToList<CRMspLkShygunLinkedCompany_Result>((IEnumerable<CRMspLkShygunLinkedCompany_Result>)_dbLink.CRMspLkShygunLinkedCompany(itemJson, syncField, mode, lCID, result));
				if (list2 != null && Enumerable.Any<CRMspLkShygunLinkedCompany_Result>((IEnumerable<CRMspLkShygunLinkedCompany_Result>)list2))
				{
					text = "error";
					text4 = GetFileShygunLinkedCompany(list2);
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

	public string GetFileShygunLinkedCompany(List<CRMspLkShygunLinkedCompany_Result> res)
	{
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunLinkedCompany_Result>((IEnumerable<CRMspLkShygunLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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
						value2 = Messages.msgErrorCmpNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupCmpLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupCmpCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorCmpNotInLinkAcc, Labels.Shygun);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc,actSendToAcc")]
	public ActionResult ShygunManageCmpLinkAcc()
	{
		GetCmpReferUser();
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
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShygunDeleteLinkedCompany_Result> list3 = Enumerable.ToList<CRMspLkShygunDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunDeleteLinkedCompany_Result>)_dbLink.CRMspLkShygunDeleteLinkedCompany(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunDeleteLinkedCompany_Result>)list3))
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

	public string GetFileShygunNotDeletedImportedInfo(List<CRMspLkShygunDeleteLinkedCompany_Result> res)
	{
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunDeleteLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.Shygun + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunDeleteLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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

	[AjaxOnly]
	public string ShygunCmpAccountingDetail(int cmpId, ref decimal remainAccount, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr) && !string.IsNullOrWhiteSpace(companyById.cmpLinkAccCode))
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunSettingViewModel shygunSetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunSetting();
						DomainStatementDetail domainStatementDetail = new DomainStatementDetail();
						string startVersion = null;
						string from = DateTime.Now.ToString("yyyy-MM-dd", new CultureInfo("en-US"));
						domainStatementDetail.Date.From = from;
						domainStatementDetail.AccountGuId.From = companyById.cmpLinkAccCustomerIdStr;
						domainStatementDetail.AccountGuId.To = companyById.cmpLinkAccCustomerIdStr;
						int rowStart = 0;
						int rowCount = 100;
						WebServiceGetClosingBalance webServiceGetClosingBalance = new WebServiceGetClosingBalance(shygunSetting.IP, shygunSetting.conf, domainStatementDetail, rowStart, rowCount, startVersion);
						try
						{
							if (webServiceGetClosingBalance != null)
							{
								DataTable dataTableObject = webServiceGetClosingBalance.GetDataTableObject(out JsonRender);
								if (dataTableObject != null && dataTableObject.Rows != null && ((InternalDataCollectionBase)dataTableObject.Rows).Count > 0 && dataTableObject.Rows[0] != null)
								{
									ShygunCompanyClosingBalanceViewModel shygunCompanyClosingBalanceViewModel = new ShygunCompanyClosingBalanceViewModel();
									DataRow val = dataTableObject.Rows[0];
									shygunCompanyClosingBalanceViewModel.AccountGuId = val["AccountGuId"].ToString();
									shygunCompanyClosingBalanceViewModel.AccountNumber = val["AccountNumber"].ToString();
									decimal result3 = default(decimal);
									decimal.TryParse(val["AmountDebit"].ToString(), out result3);
									decimal result4 = default(decimal);
									decimal.TryParse(val["AmountCredit"].ToString(), out result4);
									shygunCompanyClosingBalanceViewModel.AmountDebit = result3;
									shygunCompanyClosingBalanceViewModel.AmountCredit = result4;
									linkAccDebitBalance = result3;
									linkAccCreditBalance = result4;
									remainAccount = result4 - result3;
									result = "";
								}
							}
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in shygun");
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e4 = new Exception(Messages.ErrorNotFound + "(customer)");
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

	[AjaxOnly]
	public string ShygunIIActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string title = "";
					string jobName = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string mobile = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					string mellicode = "";
					string birthDay = "";
					string text11 = "";
					string email = "";
					string text12 = "";
					string text13 = "";
					string jobGroupNumber = "";
					string text14 = "";
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						text2 = companyById.cmpPreTel + companyById.cmpTel;
						text3 = companyById.cmpPreTelII + companyById.cmpTelII;
						text4 = companyById.cmpPreTel + companyById.cmpFax;
						text5 = companyById.cmpCountry ?? "";
						text6 = companyById.cmpProvince ?? "";
						text7 = companyById.cmpCity ?? "";
						text8 = companyById.cmpCountry + "-" + companyById.cmpProvince + "-" + companyById.cmpCity + "-" + companyById.cmpAddress;
						text9 = companyById.cmpAddressDesc ?? "";
						text10 = companyById.cmpZipCode ?? "";
						text11 = companyById.cmpWebSite ?? "";
						text12 = companyById.cmpDescription ?? "";
						text13 = companyById.cmpEconomicCode ?? "";
						if (companyById.cmpKind == 0)
						{
							jobName = companyById.CompanyName ?? "";
							mellicode = companyById.cmpNationalCode ?? "";
							title = companyById.cmpTitle ?? "";
							if (companyById.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result != null)
								{
									mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
									email = (cRMspSelectCompanyPersonsByID_Result.prsEmail ?? cRMspSelectCompanyPersonsByID_Result.prsEmailII) ?? "";
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
								{
									mobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile ?? "";
									email = (cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail ?? cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII) ?? "";
								}
							}
						}
						else if (companyById.cmpKind.GetValueOrDefault() == 1)
						{
							if (companyById.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result2 != null)
								{
									jobName = cRMspSelectCompanyPersonsByID_Result2.PersonName ?? "";
									mellicode = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode ?? "";
									mobile = cRMspSelectCompanyPersonsByID_Result2.prsMobile ?? "";
									email = (cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? cRMspSelectCompanyPersonsByID_Result2.prsEmailII) ?? "";
									title = cRMspSelectCompanyPersonsByID_Result2.prsTitle ?? "";
									if (cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.HasValue)
									{
										birthDay = DateTime.Parse(cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result2 != null)
								{
									jobName = cRMspSelectCompanyPersonTop1ByOrderView_Result2.PersonTitleName ?? "";
									mellicode = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsNationalCode ?? "";
									mobile = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsMobile ?? "";
									email = (cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsEmail ?? cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsEmailII) ?? "";
									title = cRMspSelectCompanyPersonTop1ByOrderView_Result2.PersonTitle ?? "";
									if (cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsBirthDateTime.HasValue)
									{
										birthDay = DateTime.Parse(cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
							}
						}
						CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
						if (shygunIISetting == null || string.IsNullOrWhiteSpace(shygunIISetting.IP))
						{
							text = Messages.errorInReadingSetting + "|";
							return text;
						}
						string text15 = "";
						if (!companyById.cmpTypeId.HasValue)
						{
							return string.Format(Messages.msgErrorIsNotSelectedItem, Labels.LinkAccSettingCompanyType) + "|";
						}
						List<CRMspSelectLinkAccShygunIISettingDetails_Result> list = Enumerable.ToList<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)_dbLink.CRMspSelectLinkAccShygunIISettingDetails(0, companyById.cmpTypeId, "CompanyType", lCID, result));
						string text16 = "";
						string text17 = "";
						if (list != null)
						{
							CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.LinkAccShygunIISettingId == 13));
							if (cRMspSelectLinkAccShygunIISettingDetails_Result != null)
							{
								jobGroupNumber = cRMspSelectLinkAccShygunIISettingDetails_Result.PartValue ?? "";
								text16 = cRMspSelectLinkAccShygunIISettingDetails_Result.PartDescription ?? "";
							}
							CRMspSelectLinkAccShygunIISettingDetails_Result cRMspSelectLinkAccShygunIISettingDetails_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccShygunIISettingDetails_Result>((IEnumerable<CRMspSelectLinkAccShygunIISettingDetails_Result>)list, (Func<CRMspSelectLinkAccShygunIISettingDetails_Result, bool>)((CRMspSelectLinkAccShygunIISettingDetails_Result m) => m.LinkAccShygunIISettingId == 14));
							if (cRMspSelectLinkAccShygunIISettingDetails_Result2 != null)
							{
								text15 = cRMspSelectLinkAccShygunIISettingDetails_Result2.PartValue ?? "";
								text17 = cRMspSelectLinkAccShygunIISettingDetails_Result2.PartDescription ?? "";
							}
						}
						if (string.IsNullOrWhiteSpace(jobGroupNumber))
						{
							string text18 = "";
							return string.Concat(str2: string.IsNullOrWhiteSpace(text16) ? (string.Format(Messages.msgErrorIsNotSelectedItem, Labels.LinkAccSettingCompanyType) + " (" + Labels.ShygunII + ") ") : string.Format(Messages.msgErrorIsNotSelectedItem, text16), str0: Messages.errorInReadingSetting, str1: "<br>", str3: "|");
						}
						if (string.IsNullOrWhiteSpace(text15))
						{
							string text19 = "";
							return string.Concat(str2: string.IsNullOrWhiteSpace(text17) ? (string.Format(Messages.msgErrorIsNotEntered, Labels.LinkAccSettingShygunCompanyTypeBeginNumber) + " (" + Labels.ShygunII + ") ") : string.Format(Messages.msgErrorIsNotEntered, text17), str0: Messages.errorInReadingSetting, str1: "<br>", str3: "|");
						}
						string cmpLinkAccCustomerIdStr = companyById.cmpLinkAccCustomerIdStr;
						if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccCode))
						{
							if (string.IsNullOrWhiteSpace(lastShygunIIJobNumber) || lastShygunIICmpTypeId != companyById.cmpTypeId)
							{
								bool flag = true;
								int num = 0;
								int tNum = 100;
								List<ShygunIICompanyInfoViewModel> list2 = new List<ShygunIICompanyInfoViewModel>();
								while (flag)
								{
									ShygunIICompanyInfoViewModelObjects shygunIICompanyList = GetShygunIICompanyList(string.Empty, string.Empty, num, tNum);
									if (shygunIICompanyList == null)
									{
										flag = false;
										continue;
									}
									if (shygunIICompanyList.lst == null || !Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIICompanyList.lst))
									{
										flag = false;
										continue;
									}
									list2.AddRange(shygunIICompanyList.lst);
									num += ((num > 0) ? 100 : 101);
								}
								if (list2 != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)list2))
								{
									ShygunIICompanyInfoViewModel shygunIICompanyInfoViewModel = Enumerable.LastOrDefault<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)Enumerable.ToList<ShygunIICompanyInfoViewModel>(Enumerable.Where<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)list2, (Func<ShygunIICompanyInfoViewModel, bool>)((ShygunIICompanyInfoViewModel m) => m.JobGroupNumber == jobGroupNumber))));
									if (shygunIICompanyInfoViewModel != null)
									{
										text14 = shygunIICompanyInfoViewModel.JobNo ?? "";
										if (!string.IsNullOrWhiteSpace(text14))
										{
											text14 = (long.Parse(text14) + 1).ToString();
										}
									}
								}
							}
							else
							{
								text14 = lastShygunIIJobNumber ?? "";
								if (!string.IsNullOrWhiteSpace(text14))
								{
									text14 = (long.Parse(text14) + 1).ToString();
								}
							}
							lastShygunIICmpTypeId = companyById.cmpTypeId.GetValueOrDefault();
							lastShygunIIJobNumber = text14;
							if (string.IsNullOrWhiteSpace(text14))
							{
								text14 = text15;
							}
						}
						else
						{
							text14 = companyById.cmpLinkAccCode;
						}
						List<Job> list3 = new List<Job>();
						Job job = new Job();
						job.JobGroupNumber = jobGroupNumber;
						job.Title = title;
						job.JobName = jobName;
						job.JobNumber = text14;
						job.Tel1 = text2;
						job.Tel2 = text3;
						job.Fax = text4;
						job.Mobile = mobile;
						job.Country = text5;
						job.State = text6;
						job.City = text7;
						job.Add1 = text8;
						job.Add2 = text9;
						job.ZipCode = text10;
						job.mellicode = mellicode;
						job.BirthDay = birthDay;
						job.Web = text11;
						job.Email = email;
						job.Imemo = text12;
						job.TaxCode = text13;
						if (companyById.cmpKind.GetValueOrDefault() == 0)
						{
							job.AccountTypeLaw = 2;
						}
						else if (companyById.cmpKind.GetValueOrDefault() == 1)
						{
							job.AccountTypeLaw = 1;
						}
						else
						{
							job.AccountTypeLaw = null;
						}
						if (string.IsNullOrWhiteSpace(cmpLinkAccCustomerIdStr))
						{
							job.GuId = Guid.NewGuid();
							job.UpdateKind = ActionType.insert;
						}
						else
						{
							job.GuId = Guid.Parse(cmpLinkAccCustomerIdStr);
							job.UpdateKind = ActionType.update;
						}
						list3.Add(job);
						PutResults putResults = new WebServiePutJob(shygunIISetting.IP, shygunIISetting.conf, list3).PutOperation();
						if (putResults != null && putResults.Result != null)
						{
							foreach (PutResult item in putResults.Result)
							{
								if (!string.IsNullOrWhiteSpace(item.ErrorMessage))
								{
									text = text + "<br>Error:" + item.ErrorMessage + "|";
								}
							}
							if (string.IsNullOrWhiteSpace(text) && !string.IsNullOrWhiteSpace(Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).GuId.ToString()))
							{
								string text20 = Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).Number ?? "";
								string cmpLinkAccCustomerIdStr2 = Enumerable.FirstOrDefault<PutResult>((IEnumerable<PutResult>)putResults.Result).GuId ?? "";
								CRMLinkSpEntities dbLink = _dbLink;
								int? companyId = cmpId;
								string cmpLinkAccCode = text20;
								dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, 0, cmpLinkAccCode, null, cmpLinkAccCustomerIdStr2, userId, value2, value3, value, registerDatePersian, appType, text20, "");
								text = "1|" + text20;
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ShygunIIExportCompany_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		List<CRMspLkSelectCompany_Result> list = new List<CRMspLkSelectCompany_Result>();
		try
		{
			list = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value));
			if (list != null && Enumerable.Any<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list))
			{
				foreach (CRMspLkSelectCompany_Result item in list)
				{
					item.cmpTel = item.cmpPreTel + item.cmpTel;
					item.cmpTelII = item.cmpPreTelII + item.cmpTelII;
					item.cmpAddress = item.cmpCountry + "-" + item.cmpProvince + "-" + item.cmpCity + "-" + item.cmpAddress;
					item.PersonBirthDate = (item.PersonBirthDateTime.HasValue ? item.PersonBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIExportInfo(string records, int currentItemId = 0)
	{
		//IL_00bf: Unknown result type (might be due to invalid IL or missing references)
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
						string text2 = ShygunIIActCmpSendToAcc(item.Id);
						if (!string.IsNullOrEmpty(text2))
						{
							string[] array = text2.Split(new char[1] { '|' });
							if (array == null)
							{
								continue;
							}
							if (array[0] == "1")
							{
								long result2 = 0L;
								long.TryParse(array[1], out result2);
								if (result2 > 0)
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
			lastShygunIIJobNumber = "";
			lastShygunIICmpTypeId = 0;
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
	public JsonResult GetShygunIIExportCompanyList(string records, string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		//IL_0093: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkSelectCompany_Result item2 in Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = string.IsNullOrWhiteSpace(item2.cmpLinkAccCustomerIdStr)
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

	public ShygunIICompanyInfoViewModelObjects GetShygunIICompanyList(string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_06db: Unknown result type (might be due to invalid IL or missing references)
		//IL_06e0: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		ShygunIICompanyInfoViewModelObjects shygunIICompanyInfoViewModelObjects = new ShygunIICompanyInfoViewModelObjects();
		shygunIICompanyInfoViewModelObjects.lst = new List<ShygunIICompanyInfoViewModel>();
		shygunIICompanyInfoViewModelObjects.FilteredLst = new List<ShygunIICompanyInfoViewModel>();
		List<ShygunIICompanyInfoViewModel> list = new List<ShygunIICompanyInfoViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.ShygunIISettingViewModel shygunIISetting = CRMIdeal.Classes.Helper.OtherSystems.GetShygunIISetting();
			DomainJob domainJob = new DomainJob();
			domainJob.JobCostingCode.From = fJobCode;
			domainJob.JobCostingCode.To = tJobCode;
			int num = ((fNum > 0) ? fNum : 0);
			int num2 = ((tNum >= 100) ? 100 : tNum);
			try
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				int num3 = 1;
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
				string text2 = "api/Job/Get";
				text2 = text2 + "?RowStart=" + num + "&RowCount=" + num2;
				HttpContent content = new StringContent(JsonConvert.SerializeObject(new CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobParamViewModel
				{
					Config = shygunIISetting.conf,
					Domain = domainJob,
					StartVersion = "0"
				}), Encoding.UTF8, "application/json");
				HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
				httpResponseMessage = httpClient.PostAsync(text2, content).Result;
				if (httpResponseMessage.IsSuccessStatusCode)
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel shygunIIApiGetJobResultViewModel = JsonConvert.DeserializeObject<CRMIdeal.Classes.Helper.OtherSystems.ShygunIIApiGetJobResultViewModel>(httpResponseMessage.Content.ReadAsStringAsync().Result);
					if (shygunIIApiGetJobResultViewModel != null && shygunIIApiGetJobResultViewModel.Result != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIIApiGetJobResultViewModel.Result))
					{
						foreach (ShygunIICompanyInfoViewModel item in shygunIIApiGetJobResultViewModel.Result)
						{
							ShygunIICompanyInfoViewModel vm = new ShygunIICompanyInfoViewModel();
							vm.JobNo = item.JobNo ?? "";
							vm.JobName = item.JobName ?? "";
							vm.JobDescription = item.JobDescription ?? "";
							vm.LendCover = item.LendCover;
							vm.DebtCover = item.DebtCover;
							vm.DebtCoverDoc = item.DebtCoverDoc;
							vm.CreditCoverDoc = item.CreditCoverDoc;
							vm.RemainAccount = item.RemainAccount;
							vm.Scode1Number = item.Scode1Number ?? "";
							vm.Scode2Number = item.Scode2Number ?? "";
							vm.JobScode1Number = item.JobScode1Number ?? "";
							vm.JobScode2Number = item.JobScode2Number ?? "";
							vm.JobCreate = item.JobCreate;
							vm.JobCreateStr = (vm.JobCreate.HasValue ? vm.JobCreate.Value.ToString("yyyy/MM/dd") : "");
							vm.DiscountLevel = item.DiscountLevel;
							vm.Telephone1 = item.Telephone1 ?? "";
							vm.Telephone2 = item.Telephone2 ?? "";
							vm.Fax = item.Fax ?? "";
							vm.Email = item.Email ?? "";
							vm.Web = item.Web ?? "";
							vm.Address1 = item.Address1 ?? "";
							vm.Address2 = item.Address2 ?? "";
							vm.City = item.City ?? "";
							vm.Province = item.Province ?? "";
							vm.ZipCode = item.ZipCode ?? "";
							vm.Country = item.Country ?? "";
							vm.EconomicCode = item.EconomicCode ?? "";
							vm.Tlx = item.Tlx ?? "";
							vm.Title = item.Title ?? "";
							vm.Mobile = item.Mobile ?? "";
							vm.BankNumber1 = item.BankNumber1 ?? "";
							vm.BankNumber2 = item.BankNumber2 ?? "";
							vm.MelliCode = item.MelliCode ?? "";
							vm.DefaultDiscountPer = item.DefaultDiscountPer;
							vm.JobGroupNumber = item.JobGroupNumber ?? "";
							vm.JobGroupName = item.JobGroupName ?? "";
							vm.GuId = item.GuId ?? "";
							vm.JobGroupGuId = item.JobGroupGuId ?? "";
							vm.RowNumber = num3;
							CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.GuId));
							if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
							{
								vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
							}
							else
							{
								vm.CompanyId = 0;
							}
							list.Add(vm);
							num3++;
						}
					}
				}
				else
				{
					HttpStatusCode statusCode = httpResponseMessage.StatusCode;
					Exception e2 = new Exception(((object)(HttpStatusCode)(ref statusCode)).ToString());
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
				shygunIICompanyInfoViewModelObjects.lst = list;
				shygunIICompanyInfoViewModelObjects.FilteredLst = list;
				shygunIICompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
				shygunIICompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
		}
		return shygunIICompanyInfoViewModelObjects;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShygunIICompany_Read([DataSourceRequest] DataSourceRequest request, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		List<ShygunIICompanyInfoViewModel> enumerable = new List<ShygunIICompanyInfoViewModel>();
		ShygunIICompanyInfoViewModelObjects shygunIICompanyList = GetShygunIICompanyList(fJobCode, tJobCode, fNum, tNum);
		if (shygunIICompanyList != null)
		{
			enumerable = shygunIICompanyList.lst;
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShygunIIImportInfo(string records, int referUserId = 0, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
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
			List<ShygunIICompanyInfoViewModel> list3 = new List<ShygunIICompanyInfoViewModel>();
			List<ShygunIICompanyInfoViewModel> lst = GetShygunIICompanyList(fJobCode, tJobCode, fNum, tNum).lst;
			if (lst != null)
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list4 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				foreach (OtherSystemSelectedVIiewModel SelectedRowitem in list2)
				{
					foreach (ShygunIICompanyInfoViewModel item in Enumerable.ToList<ShygunIICompanyInfoViewModel>(Enumerable.Where<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)lst, (Func<ShygunIICompanyInfoViewModel, bool>)((ShygunIICompanyInfoViewModel w) => w.GuId == SelectedRowitem.Id))))
					{
						if (list4 != null && Enumerable.Any<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4))
						{
							CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list4, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result m) => m.cmpLinkAccCustomerIdStr == item.GuId));
							if (cRMspSelectCompanyWithAccLinkField_Result != null)
							{
								item.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
							}
						}
						list3.Add(item);
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
			if (list3 != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)list3))
			{
				text = "";
				string json = JsonConvert.SerializeObject(list3);
				ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
				CRMLinkSpEntities dbLink = _dbLink;
				int? cmpReferUserId = referUserId;
				int? userId2 = userId;
				short? month = value2;
				int? fPId = id;
				short? year = result2;
				DateTime? registerDate = value;
				string appType2 = appType;
				dbLink.CRMspLkShygunIIInsertUpdateCompany(json, cmpReferUserId, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
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
	public JsonResult GetShygunIIImportCompanyList(string records, string fJobCode = "", string tJobCode = "", int fNum = 0, int tNum = 100)
	{
		//IL_00a9: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (ShygunIICompanyInfoViewModel item2 in GetShygunIICompanyList(fJobCode, tJobCode, fNum, tNum).lst)
			{
				string id = "";
				if (!string.IsNullOrWhiteSpace(item2.GuId))
				{
					id = item2.GuId ?? "0";
				}
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = item2.RowNumber,
					Id = id,
					Selected = (item2.CompanyId <= 0)
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actLinkCmpWithAcc")]
	public ActionResult ShygunIILinkedCompany()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActShygunIILinkedCompany(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			List<LinkedCompanyWithAccViewModel> list = new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actLinkCmpWithAcc", UserLogin.CurrentUser))
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
				ShygunIICompanyInfoViewModelObjects shygunIICompanyList = GetShygunIICompanyList(string.Empty, string.Empty, fromRec, recCount);
				if (shygunIICompanyList == null)
				{
					flag = false;
					continue;
				}
				if (shygunIICompanyList.lst == null || !Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIICompanyList.lst))
				{
					flag = false;
					continue;
				}
				foreach (ShygunIICompanyInfoViewModel item3 in shygunIICompanyList.lst)
				{
					LinkedCompanyWithAccViewModel item = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item3.JobNo,
						cmpLinkAccCodeId = 0,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item3.GuId,
						cmpName = item3.JobName
					};
					list.Add(item);
				}
				fromRec += ((fromRec > 0) ? 100 : 101);
			}
			if (list == null || !Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListCmpInLinkAccIsEmpty, Labels.ShygunII) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text4 = "";
				text = "";
				List<CRMspLkShygunIILinkedCompany_Result> list2 = new List<CRMspLkShygunIILinkedCompany_Result>();
				int count = list.Count;
				int num2 = 1000;
				int num3 = count / num2;
				if (count % num2 != 0)
				{
					num3++;
				}
				for (int i = 0; i <= num3; i++)
				{
					List<LinkedCompanyWithAccViewModel> list3 = new List<LinkedCompanyWithAccViewModel>();
					for (int j = i * num2; j < i * num2 + num2 && j < count; j++)
					{
						LinkedCompanyWithAccViewModel item2 = new LinkedCompanyWithAccViewModel
						{
							cmpLinkAccCode = list[j].cmpLinkAccCode,
							cmpLinkAccCodeId = 0,
							cmpLinkAccCustomerId = 0,
							cmpLinkAccCustomerIdStr = list[j].cmpLinkAccCustomerIdStr,
							cmpName = list[j].cmpName
						};
						list3.Add(item2);
					}
					if (Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list3))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list3));
						List<CRMspLkShygunIILinkedCompany_Result> list4 = Enumerable.ToList<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)_dbLink.CRMspLkShygunIILinkedCompany(itemJson, syncField, mode, lCID, result));
						if (list4 != null && Enumerable.Any<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)list4))
						{
							list2.AddRange(list4);
						}
					}
				}
				if (list2 != null && Enumerable.Any<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)list2))
				{
					list2 = Enumerable.ToList<CRMspLkShygunIILinkedCompany_Result>(Enumerable.Distinct<CRMspLkShygunIILinkedCompany_Result>(Enumerable.Where<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)list2, (Func<CRMspLkShygunIILinkedCompany_Result, bool>)((CRMspLkShygunIILinkedCompany_Result m) => (m.cmpLinkAccCustomerIdStr ?? "") == "" || m.Type == 1))));
					if (list2 != null && Enumerable.Any<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)list2))
					{
						text = "error";
						text4 = GetFileShygunIILinkedCompany(list2);
					}
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

	public string GetFileShygunIILinkedCompany(List<CRMspLkShygunIILinkedCompany_Result> res)
	{
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunIILinkedCompany_Result>((IEnumerable<CRMspLkShygunIILinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIILinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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
						value2 = Messages.msgErrorCmpNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupCmpLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupCmpCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorCmpNotInLinkAcc, Labels.ShygunII);
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc,actSendToAcc")]
	public ActionResult ShygunIIManageCmpLinkAcc()
	{
		GetCmpReferUser();
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
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShygunIIDeleteLinkedCompany_Result> list3 = Enumerable.ToList<CRMspLkShygunIIDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedCompany_Result>)_dbLink.CRMspLkShygunIIDeleteLinkedCompany(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShygunIIDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedCompany_Result>)list3))
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

	public string GetFileShygunIINotDeletedImportedInfo(List<CRMspLkShygunIIDeleteLinkedCompany_Result> res)
	{
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShygunIIDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShygunIIDeleteLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.ShygunII + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShygunIIDeleteLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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

	[AjaxOnly]
	public string ShygunIICmpAccountingDetail(int cmpId, ref decimal remainAccount)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (cmp != null)
				{
					if (!string.IsNullOrWhiteSpace(cmp.cmpLinkAccCustomerIdStr) && !string.IsNullOrWhiteSpace(cmp.cmpLinkAccCode))
					{
						ShygunIICompanyInfoViewModelObjects shygunIICompanyList = GetShygunIICompanyList(cmp.cmpLinkAccCode, cmp.cmpLinkAccCode);
						if (shygunIICompanyList != null)
						{
							if (shygunIICompanyList.lst != null && Enumerable.Any<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIICompanyList.lst))
							{
								ShygunIICompanyInfoViewModel shygunIICompanyInfoViewModel = Enumerable.FirstOrDefault<ShygunIICompanyInfoViewModel>((IEnumerable<ShygunIICompanyInfoViewModel>)shygunIICompanyList.lst, (Func<ShygunIICompanyInfoViewModel, bool>)((ShygunIICompanyInfoViewModel m) => m.GuId == cmp.cmpLinkAccCustomerIdStr));
								if (shygunIICompanyInfoViewModel != null)
								{
									remainAccount = shygunIICompanyInfoViewModel.RemainAccount.GetValueOrDefault();
									return "";
								}
								Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + cmp.cmpName + " not in shygunII");
								ErrorSignal.FromCurrentContext().Raise(e);
								return Labels.frmError;
							}
							Exception e2 = new Exception(Messages.ErrorNotFound + "(This customer by name " + cmp.cmpName + " not in shygunII");
							ErrorSignal.FromCurrentContext().Raise(e2);
							return Labels.frmError;
						}
						Exception e3 = new Exception(Messages.ErrorNotFound + "(This customer by name " + cmp.cmpName + " not in shygunII");
						ErrorSignal.FromCurrentContext().Raise(e3);
						return Labels.frmError;
					}
					Exception e4 = new Exception(Messages.ErrorNotFound + "(This customer by name " + cmp.cmpName + " not in shygunII");
					ErrorSignal.FromCurrentContext().Raise(e4);
					return Labels.frmError;
				}
				Exception e5 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e5);
				return Labels.frmError;
			}
			Exception e6 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e6);
			return Labels.frmError;
		}
		catch (Exception e7)
		{
			ErrorSignal.FromCurrentContext().Raise(e7);
			return Labels.frmError;
		}
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public ActionResult ImportCompany()
	{
		return View();
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actImportFromAcc")]
	public string CompanyImport(string js = "", string linkAccName = "", bool canUpdate = false)
	{
		string result = "";
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
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result3);
			if (result3 <= 0)
			{
				result3 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			if (!string.IsNullOrWhiteSpace(js))
			{
				ObjectParameter errorMessage = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkImportCompany(js, linkAccName, canUpdate, id, result2, value2, userId, value, registerDatePersian, appType, lCID, result3, errorMessage, centerId, XorCipher.PreparePublicKeyForSql());
			}
			else
			{
				result = Messages.msgErrorNotSelectedItem;
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			result = ex.Message;
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetCmpReferUser()
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
	public JsonResult GetCompanyQuickRegisterDefSetting()
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
			List<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result> list2 = Enumerable.ToList<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingUserAccess((short)2, UserLogin.CurrentUser.UserId, lCID, result));
			int? defaultSetting = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbIII.CRMspSelectCompanyQuickRegisterDefSettingIsDefUserAccess((short)2, UserLogin.CurrentUser.UserId, lCID, result));
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result, SelectListItem>((IEnumerable<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result>)list2, (Func<CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result, SelectListItem>)((CRMspSelectCompanyQuickRegisterDefSettingUserAccess_Result item) => new SelectListItem
			{
				Text = item.SettingTitle,
				Value = item.CompanyQuickRegisterDefSettingId.ToString(),
				Selected = (item.CompanyQuickRegisterDefSettingId == defaultSetting.GetValueOrDefault())
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.CmpDefSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult SelectCompanyQuickRegisterDefSetting(int defSettingId)
	{
		_003C_003Ec__DisplayClass123_0 CS_0024_003C_003E8__locals0 = new _003C_003Ec__DisplayClass123_0();
		CS_0024_003C_003E8__locals0.defSettingId = defSettingId;
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		CS_0024_003C_003E8__locals0.currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel();
		try
		{
			DbSet<CrmCompanyQuickRegisterDefSetting> crmCompanyQuickRegisterDefSetting = _dbTbl.CrmCompanyQuickRegisterDefSetting;
			ParameterExpression val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting), "c");
			CrmCompanyQuickRegisterDefSetting crmCompanyQuickRegisterDefSetting2 = Queryable.FirstOrDefault<CrmCompanyQuickRegisterDefSetting>((IQueryable<CrmCompanyQuickRegisterDefSetting>)crmCompanyQuickRegisterDefSetting, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass123_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (crmCompanyQuickRegisterDefSetting2 != null)
			{
				DbSet<CrmCompanyQuickRegisterDefSetting_Lang> crmCompanyQuickRegisterDefSetting_Lang = _dbTbl.CrmCompanyQuickRegisterDefSetting_Lang;
				val = Expression.Parameter(typeof(CrmCompanyQuickRegisterDefSetting_Lang), "c");
				List<CrmCompanyQuickRegisterDefSetting_Lang> list = Enumerable.ToList<CrmCompanyQuickRegisterDefSetting_Lang>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)Queryable.Where<CrmCompanyQuickRegisterDefSetting_Lang>((IQueryable<CrmCompanyQuickRegisterDefSetting_Lang>)crmCompanyQuickRegisterDefSetting_Lang, Expression.Lambda<Func<CrmCompanyQuickRegisterDefSetting_Lang, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)CS_0024_003C_003E8__locals0, typeof(_003C_003Ec__DisplayClass123_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val })));
				List<CommonMultiLanguageViewModel> list2 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.SettingTitle,
					LanguageId = myitem.LanguageID
				})));
				list2.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.SettingTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list3 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpActivityType,
					LanguageId = myitem.LanguageID
				})));
				list3.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpActivityType,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list4 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpSpecialPoint,
					LanguageId = myitem.LanguageID
				})));
				list4.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list5 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cmpDescription,
					LanguageId = myitem.LanguageID
				})));
				list5.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cmpDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list6 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prsSpecialPoint,
					LanguageId = myitem.LanguageID
				})));
				list6.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsSpecialPoint,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list7 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prsDescription,
					LanguageId = myitem.LanguageID
				})));
				list7.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prsDescription,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list8 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjTitle,
					LanguageId = myitem.LanguageID
				})));
				list8.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitle,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list9 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjDesc,
					LanguageId = myitem.LanguageID
				})));
				list9.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list10 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjPostFix,
					LanguageId = myitem.LanguageID
				})));
				list10.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjPostFix,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list11 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjSubject,
					LanguageId = myitem.LanguageID
				})));
				list11.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjSubject,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list12 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjTitleGroup,
					LanguageId = myitem.LanguageID
				})));
				list12.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjTitleGroup,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list13 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.prjDescI,
					LanguageId = myitem.LanguageID
				})));
				list13.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.prjDescI,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list14 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsDesc,
					LanguageId = myitem.LanguageID
				})));
				list14.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsDesc,
					LanguageId = result
				});
				List<CommonMultiLanguageViewModel> list15 = Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Select<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>((IEnumerable<CrmCompanyQuickRegisterDefSetting_Lang>)list, (Func<CrmCompanyQuickRegisterDefSetting_Lang, CommonMultiLanguageViewModel>)((CrmCompanyQuickRegisterDefSetting_Lang myitem) => new CommonMultiLanguageViewModel
				{
					Value = myitem.cnvsReferDesc,
					LanguageId = myitem.LanguageID
				})));
				list15.Add(new CommonMultiLanguageViewModel
				{
					Value = crmCompanyQuickRegisterDefSetting2.cnvsReferDesc,
					LanguageId = result
				});
				DateTime now = DateTime.Now;
				crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel = new CrmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel
				{
					CompanyQuickRegisterDefSettingId = crmCompanyQuickRegisterDefSetting2.CompanyQuickRegisterDefSettingId,
					cmpTitleId = crmCompanyQuickRegisterDefSetting2.cmpTitleId,
					cmpGroupId = crmCompanyQuickRegisterDefSetting2.cmpGroupId,
					cmpSubGroupId = crmCompanyQuickRegisterDefSetting2.cmpSubGroupId,
					cmpGroupIdII = crmCompanyQuickRegisterDefSetting2.cmpGroupIdII,
					cmpGroupIdIII = crmCompanyQuickRegisterDefSetting2.cmpGroupIdIII,
					cmpGroupIdIV = crmCompanyQuickRegisterDefSetting2.cmpGroupIdIV,
					cmpTypeId = crmCompanyQuickRegisterDefSetting2.cmpTypeId,
					cmpPresentationId = crmCompanyQuickRegisterDefSetting2.cmpPresentationId,
					cmpCityId = crmCompanyQuickRegisterDefSetting2.cmpCityId,
					cmpEffectiveDateIncDay = crmCompanyQuickRegisterDefSetting2.cmpEffectiveDateIncDay,
					cmpEffectiveDate = "",
					cmpKind = crmCompanyQuickRegisterDefSetting2.cmpKind,
					prsTitleId = crmCompanyQuickRegisterDefSetting2.prsTitleId,
					prsJobId = crmCompanyQuickRegisterDefSetting2.prsJobId,
					prsTypeId = crmCompanyQuickRegisterDefSetting2.prsTypeId,
					prsGroupId = crmCompanyQuickRegisterDefSetting2.prsGroupId,
					prsSexId = crmCompanyQuickRegisterDefSetting2.prsSexId,
					prsEducationId = crmCompanyQuickRegisterDefSetting2.prsEducationId,
					prsCityId = crmCompanyQuickRegisterDefSetting2.prsCityId,
					prsDepartmentId = crmCompanyQuickRegisterDefSetting2.prsDepartmentId,
					prjGradeId = crmCompanyQuickRegisterDefSetting2.prjGradeId,
					prjPriorityId = crmCompanyQuickRegisterDefSetting2.prjPriorityId,
					prjGroupId = crmCompanyQuickRegisterDefSetting2.prjGroupId,
					prjcnvsStatusGroupId = crmCompanyQuickRegisterDefSetting2.prjcnvsStatusGroupId,
					prjRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.prjRemindDateIncDay,
					prjRemindDate = "",
					prjFOCmpCanSee = (crmCompanyQuickRegisterDefSetting2.prjFOCmpCanSee.HasValue && crmCompanyQuickRegisterDefSetting2.prjFOCmpCanSee.GetValueOrDefault()),
					prjCategoryId = crmCompanyQuickRegisterDefSetting2.prjCategoryId,
					cnvsTopicId = crmCompanyQuickRegisterDefSetting2.cnvsTopicId,
					cnvsStatusId = crmCompanyQuickRegisterDefSetting2.cnvsStatusId,
					cnvsPriorityId = crmCompanyQuickRegisterDefSetting2.cnvsPriorityId,
					cnvsRemindDateIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateIncDay,
					cnvsRemindDate = "",
					cnvsRemindTime = crmCompanyQuickRegisterDefSetting2.cnvsRemindTime,
					cnvsRemindDateForAllarmIncDay = crmCompanyQuickRegisterDefSetting2.cnvsRemindDateForAllarmIncDay,
					cnvsRemindDateForAllarm = "",
					cnvsFOCmpCanSee = (crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.HasValue && crmCompanyQuickRegisterDefSetting2.cnvsFOCmpCanSee.GetValueOrDefault()),
					IsDefault = crmCompanyQuickRegisterDefSetting2.IsDefault,
					SettingTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					SettingTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list2, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpActivityType_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpActivityType = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list3, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpSpecialPoint_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list4, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cmpDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cmpDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list5, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsSpecialPoint_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prsSpecialPoint = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list6, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prsDescription_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prsDescription = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list7, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjTitle_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjTitle = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list8, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list9, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjPostFix_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjPostFix = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list10, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjSubject_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjSubject = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list11, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjTitleGroup_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjTitleGroup = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list12, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					prjDescI_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					prjDescI = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list13, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list14, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : ""),
					cnvsReferDesc_Lang = JsonConvert.SerializeObject(Enumerable.ToList<CommonMultiLanguageViewModel>(Enumerable.Where<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId != CS_0024_003C_003E8__locals0.currLangID)))),
					cnvsReferDesc = (Enumerable.Any<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)) ? Enumerable.FirstOrDefault<CommonMultiLanguageViewModel>((IEnumerable<CommonMultiLanguageViewModel>)list15, (Func<CommonMultiLanguageViewModel, bool>)((CommonMultiLanguageViewModel c) => c.LanguageId == CS_0024_003C_003E8__locals0.currLangID)).Value : "")
				};
				if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel != null)
				{
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDateIncDay.HasValue)
					{
						int result2 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDateIncDay.ToString(), out result2);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpEffectiveDate = now.AddDays(result2).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId.HasValue)
					{
						int result3 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId.ToString(), out result3);
						if (result3 != 0)
						{
							CRMspSelectCountryProvinceCityByCityId_Result cRMspSelectCountryProvinceCityByCityId_Result = Enumerable.FirstOrDefault<CRMspSelectCountryProvinceCityByCityId_Result>((IEnumerable<CRMspSelectCountryProvinceCityByCityId_Result>)_dbI.CRMspSelectCountryProvinceCityByCityId(result3, CS_0024_003C_003E8__locals0.currLangID, result));
							if (cRMspSelectCountryProvinceCityByCityId_Result != null)
							{
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCountry = cRMspSelectCountryProvinceCityByCityId_Result.Country ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCountryId = cRMspSelectCountryProvinceCityByCityId_Result.CountryId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpProvince = cRMspSelectCountryProvinceCityByCityId_Result.Province ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpProvinceId = cRMspSelectCountryProvinceCityByCityId_Result.ProvinceId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCity = crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCity ?? "";
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cmpCityId = cRMspSelectCountryProvinceCityByCityId_Result.CityID;
							}
						}
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId.HasValue)
					{
						int result4 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId.ToString(), out result4);
						if (result4 != 0)
						{
							CRMspSelectCountryProvinceCityByCityId_Result cRMspSelectCountryProvinceCityByCityId_Result2 = Enumerable.FirstOrDefault<CRMspSelectCountryProvinceCityByCityId_Result>((IEnumerable<CRMspSelectCountryProvinceCityByCityId_Result>)_dbI.CRMspSelectCountryProvinceCityByCityId(result4, CS_0024_003C_003E8__locals0.currLangID, result));
							if (cRMspSelectCountryProvinceCityByCityId_Result2 != null)
							{
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCountryId = cRMspSelectCountryProvinceCityByCityId_Result2.CountryId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsProvinceId = cRMspSelectCountryProvinceCityByCityId_Result2.ProvinceId;
								crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prsCityId = cRMspSelectCountryProvinceCityByCityId_Result2.CityID;
							}
						}
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDateIncDay.HasValue)
					{
						int result5 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDateIncDay.ToString(), out result5);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.prjRemindDate = now.AddDays(result5).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateIncDay.HasValue)
					{
						int result6 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateIncDay.ToString(), out result6);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDate = now.AddDays(result6).ToString("yyyy/MM/dd");
					}
					if (crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarmIncDay.HasValue)
					{
						int result7 = 0;
						int.TryParse(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarmIncDay.ToString(), out result7);
						crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel.cnvsRemindDateForAllarm = now.AddDays(result7).ToString("yyyy/MM/dd");
					}
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
		JsonResult jsonResult = Json(crmCompanyQuickRegisterDefSettingForInsertQuickLanguageViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetStatusGroups()
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
			list = Enumerable.ToList<SelectListItem>(Enumerable.Select<CRMspSelectConversationStatusGroups_Result, SelectListItem>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)Enumerable.ToList<CRMspSelectConversationStatusGroups_Result>((IEnumerable<CRMspSelectConversationStatusGroups_Result>)_db.CRMspSelectConversationStatusGroups(lCID, result)), (Func<CRMspSelectConversationStatusGroups_Result, SelectListItem>)((CRMspSelectConversationStatusGroups_Result item) => new SelectListItem
			{
				Text = item.ConversationStatusGroup,
				Value = item.ConversationStatusGroupID.ToString()
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.StatusGroupslist = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public JsonResult ProjectTitleFull(string valPrjTitle)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyProjectTitle_Result> list = new List<CRMspSelectCompanyProjectTitle_Result>();
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			valPrjTitle = valPrjTitle ?? "";
			list = Enumerable.ToList<CRMspSelectCompanyProjectTitle_Result>((IEnumerable<CRMspSelectCompanyProjectTitle_Result>)_db.CRMspSelectCompanyProjectTitle(valPrjTitle, UserLogin.CurrentUser.UserId, lCID, result, result2));
			foreach (CRMspSelectCompanyProjectTitle_Result item in list)
			{
				item.prjStatusGroup = item.prjStatusGroup ?? "";
				item.prjTitle = item.prjTitle ?? "";
				item.ProjectTitleGroupId = item.ProjectTitleGroupId.GetValueOrDefault();
				item.ProjectTitleGradeId = item.ProjectTitleGradeId.GetValueOrDefault();
				item.ProjectTitlePriorityId = item.ProjectTitlePriorityId.GetValueOrDefault();
				item.ProjectTitleDesc = item.ProjectTitleDesc ?? "";
				item.ProjectTitleStatusGroupId = item.ProjectTitleStatusGroupId.GetValueOrDefault();
				item.ProjectCategoryId = item.ProjectCategoryId.GetValueOrDefault();
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc,actSendToAcc")]
	public ActionResult ChamberCommerceManageCmpLinkAcc()
	{
		GetCmpReferUser();
		GetCompanyQuickRegisterDefSetting();
		GetStatusGroups();
		return View();
	}

	public ActionResult ChamberCommerceGenerateExcelFile()
	{
		//IL_00f3: Unknown result type (might be due to invalid IL or missing references)
		//IL_010e: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			ExcelPackage excelPackage = new ExcelPackage();
			ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
			int num = 0;
			num++;
			excelWorksheet.Cells[1, num].Value = Labels.ChamberCommerceCardNumber;
			excelWorksheet.Cells.Style.Numberformat.Format = "@";
			excelWorksheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
			excelWorksheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;
			using (ExcelRange excelRange = excelWorksheet.Cells[1, 1, 1, num])
			{
				excelRange.Style.Font.Bold = true;
				excelRange.Style.Fill.PatternType = ExcelFillStyle.Solid;
				excelRange.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
				excelRange.Style.Font.Color.SetColor(Color.White);
			}
			excelPackage.Workbook.Properties.Title = Labels.OtherSystemsExcelPropertiesTitle;
			excelPackage.Workbook.Properties.Company = Labels.OtherSystemsExcelPropertiesCompany;
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
		return View();
	}

	public ChamberCommerceCompanyInfoViewModel ChamberCommerceGetInfo(string cartNumber)
	{
		//IL_0581: Unknown result type (might be due to invalid IL or missing references)
		//IL_0586: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ChamberCommerceCompanyInfoViewModel chamberCommerceCompanyInfoViewModel = new ChamberCommerceCompanyInfoViewModel();
		try
		{
			string text = "";
			string value = "";
			string value2 = "";
			string text2 = "";
			chamberCommerceCompanyInfoViewModel.ErrorMessage = "";
			List<CRMspSelectLinkAccChamberCommerceSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)_dbLink.CRMspSelectLinkAccChamberCommerceSetting(0, "Setting", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "ApiAddress"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result != null)
				{
					text = cRMspSelectLinkAccChamberCommerceSetting_Result.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(text))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "UserName"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result2 != null)
				{
					value = cRMspSelectLinkAccChamberCommerceSetting_Result2.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result2.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "Password"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result3 != null)
				{
					value2 = cRMspSelectLinkAccChamberCommerceSetting_Result3.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value2))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result3.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "GetCardInfoUrlAddress"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result4 != null)
				{
					text2 = cRMspSelectLinkAccChamberCommerceSetting_Result4.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(text2))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result4.PartLabelTitle ?? "") + ", ";
					}
				}
			}
			else
			{
				chamberCommerceCompanyInfoViewModel.ErrorMessage = "-1";
			}
			if ((string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value2) || string.IsNullOrWhiteSpace(text2)) && string.IsNullOrWhiteSpace(chamberCommerceCompanyInfoViewModel.ErrorMessage))
			{
				chamberCommerceCompanyInfoViewModel.ErrorMessage = "-1";
			}
			if (!string.IsNullOrWhiteSpace(chamberCommerceCompanyInfoViewModel.ErrorMessage))
			{
				chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
				chamberCommerceCompanyInfoViewModel.HasConflict = true;
				if (chamberCommerceCompanyInfoViewModel.ErrorMessage != "-1")
				{
					if (chamberCommerceCompanyInfoViewModel.ErrorMessage.EndsWith(", "))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage.Substring(0, chamberCommerceCompanyInfoViewModel.ErrorMessage.Length - 2);
					}
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.errorInReadingSetting + " (" + chamberCommerceCompanyInfoViewModel.ErrorMessage + ")";
				}
				else
				{
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.errorInReadingSetting;
				}
				return chamberCommerceCompanyInfoViewModel;
			}
			if (!string.IsNullOrWhiteSpace(cartNumber))
			{
				try
				{
					HttpClient obj = new HttpClient
					{
						Timeout = CRMIdeal.Classes.Helper.OtherSystems.RestApiTimeout(),
						BaseAddress = new Uri(text),
						DefaultRequestHeaders = 
						{
							{ "userName", value },
							{ "password", value2 }
						}
					};
					text2 += cartNumber;
					HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
					httpResponseMessage = obj.GetAsync(text2).Result;
					if (httpResponseMessage.IsSuccessStatusCode)
					{
						string result2 = httpResponseMessage.Content.ReadAsStringAsync().Result;
						if (result2.IndexOf("{", StringComparison.Ordinal) >= 0)
						{
							ChamberCommerceCompanyInfoViewModel chamberCommerceCompanyInfoViewModel2 = JsonConvert.DeserializeObject<ChamberCommerceCompanyInfoViewModel>(result2);
							if (chamberCommerceCompanyInfoViewModel2 != null)
							{
								chamberCommerceCompanyInfoViewModel.OfficeTel = chamberCommerceCompanyInfoViewModel2.OfficeTel ?? "";
								chamberCommerceCompanyInfoViewModel.TradeCardIdWithCD = chamberCommerceCompanyInfoViewModel2.TradeCardIdWithCD ?? "";
								chamberCommerceCompanyInfoViewModel.FactoryTel = chamberCommerceCompanyInfoViewModel2.FactoryTel ?? "";
								chamberCommerceCompanyInfoViewModel.HomeTel = chamberCommerceCompanyInfoViewModel2.HomeTel ?? "";
								chamberCommerceCompanyInfoViewModel.WorkTel = chamberCommerceCompanyInfoViewModel2.WorkTel ?? "";
								chamberCommerceCompanyInfoViewModel.PersianCorporationName = chamberCommerceCompanyInfoViewModel2.PersianCorporationName ?? "";
								chamberCommerceCompanyInfoViewModel.PersianLastName = chamberCommerceCompanyInfoViewModel2.PersianLastName ?? "";
								chamberCommerceCompanyInfoViewModel.PersianFirstName = chamberCommerceCompanyInfoViewModel2.PersianFirstName ?? "";
								chamberCommerceCompanyInfoViewModel.CardNo = chamberCommerceCompanyInfoViewModel2.CardNo ?? "";
								chamberCommerceCompanyInfoViewModel.CardExpireDate = chamberCommerceCompanyInfoViewModel2.CardExpireDate ?? "";
								chamberCommerceCompanyInfoViewModel.StatusTitle = chamberCommerceCompanyInfoViewModel2.StatusTitle ?? "";
							}
							else
							{
								chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
								chamberCommerceCompanyInfoViewModel.HasConflict = true;
								chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.ErrorInformation;
							}
						}
						else
						{
							chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
							chamberCommerceCompanyInfoViewModel.HasConflict = true;
							chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.ErrorInformation + " (" + result2 + ")";
						}
					}
					else
					{
						chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
						chamberCommerceCompanyInfoViewModel.HasConflict = true;
						string errorInformation = Messages.ErrorInformation;
						HttpStatusCode statusCode = httpResponseMessage.StatusCode;
						chamberCommerceCompanyInfoViewModel.ErrorMessage = errorInformation + " (Code= " + ((object)(HttpStatusCode)(ref statusCode)).ToString() + ")";
					}
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
					chamberCommerceCompanyInfoViewModel.HasConflict = true;
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.msgErrorRunFunction + " (" + ex.Message + ")";
				}
			}
			else
			{
				chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
				chamberCommerceCompanyInfoViewModel.HasConflict = true;
				chamberCommerceCompanyInfoViewModel.ErrorMessage += string.Format(Messages.msgErrorIsNotEntered, Labels.ChamberCommerceCardNumber);
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
			chamberCommerceCompanyInfoViewModel.HasConflict = true;
			chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.msgErrorRunFunction + " (" + ex2.Message + ")";
		}
		return chamberCommerceCompanyInfoViewModel;
	}

	public ChamberCommerceCompanyInfoViewModel ChamberCommerceGetInfoForTest(string cartNumber)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ChamberCommerceCompanyInfoViewModel chamberCommerceCompanyInfoViewModel = new ChamberCommerceCompanyInfoViewModel();
		try
		{
			string value = "";
			string value2 = "";
			string value3 = "";
			string value4 = "";
			chamberCommerceCompanyInfoViewModel.ErrorMessage = "";
			List<CRMspSelectLinkAccChamberCommerceSetting_Result> list = Enumerable.ToList<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)_dbLink.CRMspSelectLinkAccChamberCommerceSetting(0, "Setting", lCID, result));
			if (list != null)
			{
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "ApiAddress"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result != null)
				{
					value = cRMspSelectLinkAccChamberCommerceSetting_Result.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "UserName"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result2 != null)
				{
					value2 = cRMspSelectLinkAccChamberCommerceSetting_Result2.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value2))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result2.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result3 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "Password"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result3 != null)
				{
					value3 = cRMspSelectLinkAccChamberCommerceSetting_Result3.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value3))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result3.PartLabelTitle ?? "") + ", ";
					}
				}
				CRMspSelectLinkAccChamberCommerceSetting_Result cRMspSelectLinkAccChamberCommerceSetting_Result4 = Enumerable.FirstOrDefault<CRMspSelectLinkAccChamberCommerceSetting_Result>((IEnumerable<CRMspSelectLinkAccChamberCommerceSetting_Result>)list, (Func<CRMspSelectLinkAccChamberCommerceSetting_Result, bool>)((CRMspSelectLinkAccChamberCommerceSetting_Result m) => m.PartTitle == "GetCardInfoUrlAddress"));
				if (cRMspSelectLinkAccChamberCommerceSetting_Result4 != null)
				{
					value4 = cRMspSelectLinkAccChamberCommerceSetting_Result4.PartValue ?? "";
					if (string.IsNullOrWhiteSpace(value4))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage + string.Format(Messages.msgErrorIsNotEntered, cRMspSelectLinkAccChamberCommerceSetting_Result4.PartLabelTitle ?? "") + ", ";
					}
				}
			}
			else
			{
				chamberCommerceCompanyInfoViewModel.ErrorMessage = "-1";
			}
			if ((string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(value2) || string.IsNullOrWhiteSpace(value3) || string.IsNullOrWhiteSpace(value4)) && string.IsNullOrWhiteSpace(chamberCommerceCompanyInfoViewModel.ErrorMessage))
			{
				chamberCommerceCompanyInfoViewModel.ErrorMessage = "-1";
			}
			if (!string.IsNullOrWhiteSpace(chamberCommerceCompanyInfoViewModel.ErrorMessage))
			{
				chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
				chamberCommerceCompanyInfoViewModel.HasConflict = true;
				if (chamberCommerceCompanyInfoViewModel.ErrorMessage != "-1")
				{
					if (chamberCommerceCompanyInfoViewModel.ErrorMessage.EndsWith(", "))
					{
						chamberCommerceCompanyInfoViewModel.ErrorMessage = chamberCommerceCompanyInfoViewModel.ErrorMessage.Substring(0, chamberCommerceCompanyInfoViewModel.ErrorMessage.Length - 2);
					}
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.errorInReadingSetting + " (" + chamberCommerceCompanyInfoViewModel.ErrorMessage + ")";
				}
				else
				{
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.errorInReadingSetting;
				}
				return chamberCommerceCompanyInfoViewModel;
			}
			if (!string.IsNullOrWhiteSpace(cartNumber))
			{
				try
				{
					chamberCommerceCompanyInfoViewModel.OfficeTel = "(031)(32757550)";
					chamberCommerceCompanyInfoViewModel.TradeCardIdWithCD = "7553775096904159";
					chamberCommerceCompanyInfoViewModel.FactoryTel = "";
					chamberCommerceCompanyInfoViewModel.HomeTel = "(031)(32757550)";
					chamberCommerceCompanyInfoViewModel.WorkTel = "";
					chamberCommerceCompanyInfoViewModel.PersianCorporationName = "بارمان همراه نقش جهان";
					chamberCommerceCompanyInfoViewModel.PersianLastName = "اکبريان تفاقي";
					chamberCommerceCompanyInfoViewModel.PersianFirstName = "سيدعلي";
					chamberCommerceCompanyInfoViewModel.CardNo = "14009472658";
					chamberCommerceCompanyInfoViewModel.CardExpireDate = "1401/09/25";
					chamberCommerceCompanyInfoViewModel.StatusTitle = "تاييد شده";
					chamberCommerceCompanyInfoViewModel.HasConflict = false;
					chamberCommerceCompanyInfoViewModel.ErrorMessage = "";
				}
				catch (Exception ex)
				{
					ErrorSignal.FromCurrentContext().Raise(ex);
					chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
					chamberCommerceCompanyInfoViewModel.HasConflict = true;
					chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.msgErrorRunFunction + " (" + ex.Message + ")";
				}
			}
			else
			{
				chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
				chamberCommerceCompanyInfoViewModel.HasConflict = true;
				chamberCommerceCompanyInfoViewModel.ErrorMessage += string.Format(Messages.msgErrorIsNotEntered, Labels.ChamberCommerceCardNumber);
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			chamberCommerceCompanyInfoViewModel.CardNo = cartNumber ?? "";
			chamberCommerceCompanyInfoViewModel.HasConflict = true;
			chamberCommerceCompanyInfoViewModel.ErrorMessage = Messages.msgErrorRunFunction + " (" + ex2.Message + ")";
		}
		return chamberCommerceCompanyInfoViewModel;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ChamberCommerceUploadExcelFile([DataSourceRequest] DataSourceRequest request)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>> commonResultViewModel = new CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>>();
		List<ChamberCommerceCompanyInfoViewModel> list = new List<ChamberCommerceCompanyInfoViewModel>();
		string text = "";
		CommonResultStatusViewModel commonResultStatusViewModel = CommonResultStatusViewModel.Fail;
		try
		{
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
			try
			{
				if (num2 > 100)
				{
					CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>> obj = new CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>>
					{
						Data = list,
						Message = string.Format(Messages.msgErrGetInfoFromExcelWithMoreThanMaxRecords, "100")
					};
					commonResultStatusViewModel = (obj.Status = CommonResultStatusViewModel.Error);
					commonResultViewModel = obj;
					JsonResult jsonResult = Json(((IEnumerable)new CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>>[1] { commonResultViewModel }).ToDataSourceResult(request));
					jsonResult.MaxJsonLength = int.MaxValue;
					return jsonResult;
				}
				int num3 = 1;
				object[] array2 = new object[num3];
				long num4 = 1L;
				for (int i = 1; i < num2; i++)
				{
					int num5 = 0;
					string cartNumberFromExcel = "";
					string text2 = "";
					string text3 = "";
					string text4 = "";
					string text5 = "";
					string text6 = "";
					string text7 = "";
					string text8 = "";
					string text9 = "";
					string text10 = "";
					string text11 = "";
					string cardExpireDateInCalture = "";
					string text12 = "";
					bool flag = false;
					string text13 = "";
					for (num5 = 0; num5 < num; num5++)
					{
						if (num5 < num3)
						{
							string text14 = "";
							array2[num5] = array[i, num5];
							if (array[0, num5] != null)
							{
								array[0, num5].ToString();
							}
							text14 = ((array2[num5] == null) ? "" : array2[num5].ToString());
							if (num5 == 0 && !string.IsNullOrWhiteSpace(text14))
							{
								cartNumberFromExcel = text14;
							}
						}
					}
					if (!string.IsNullOrWhiteSpace(cartNumberFromExcel) && list != null && Enumerable.FirstOrDefault<ChamberCommerceCompanyInfoViewModel>((IEnumerable<ChamberCommerceCompanyInfoViewModel>)list, (Func<ChamberCommerceCompanyInfoViewModel, bool>)((ChamberCommerceCompanyInfoViewModel m) => m.CardNo == cartNumberFromExcel)) != null)
					{
						text10 = cartNumberFromExcel;
						flag = true;
						text13 = text13 + string.Format(Messages.msgErrorItemDuplicate, Labels.ChamberCommerceListCardNo) + "|";
					}
					if (!string.IsNullOrEmpty(cartNumberFromExcel))
					{
						CRMspCheckDuplicatePrjPostFix_Result cRMspCheckDuplicatePrjPostFix_Result = Enumerable.FirstOrDefault<CRMspCheckDuplicatePrjPostFix_Result>((IEnumerable<CRMspCheckDuplicatePrjPostFix_Result>)_db.CRMspCheckDuplicatePrjPostFix(cartNumberFromExcel, 0, lCID, result));
						if (cRMspCheckDuplicatePrjPostFix_Result != null)
						{
							text10 = cartNumberFromExcel;
							flag = true;
							text13 = text13 + string.Format(Messages.CheckDuplicatePrjPostFix, cRMspCheckDuplicatePrjPostFix_Result.CompanyNumber.ToString(), cRMspCheckDuplicatePrjPostFix_Result.CompanyName ?? "") + "|";
						}
					}
					if (!flag)
					{
						if (!string.IsNullOrWhiteSpace(cartNumberFromExcel))
						{
							ChamberCommerceCompanyInfoViewModel chamberCommerceCompanyInfoViewModel = ChamberCommerceGetInfo(cartNumberFromExcel);
							if (chamberCommerceCompanyInfoViewModel != null)
							{
								text2 = chamberCommerceCompanyInfoViewModel.OfficeTel ?? "";
								text3 = chamberCommerceCompanyInfoViewModel.TradeCardIdWithCD ?? "";
								text4 = chamberCommerceCompanyInfoViewModel.FactoryTel ?? "";
								text5 = chamberCommerceCompanyInfoViewModel.HomeTel ?? "";
								text6 = chamberCommerceCompanyInfoViewModel.WorkTel ?? "";
								text7 = chamberCommerceCompanyInfoViewModel.PersianCorporationName ?? "";
								text8 = chamberCommerceCompanyInfoViewModel.PersianLastName ?? "";
								text9 = chamberCommerceCompanyInfoViewModel.PersianFirstName ?? "";
								text10 = chamberCommerceCompanyInfoViewModel.CardNo ?? "";
								text11 = chamberCommerceCompanyInfoViewModel.CardExpireDate ?? "";
								text12 = chamberCommerceCompanyInfoViewModel.StatusTitle ?? "";
								flag = chamberCommerceCompanyInfoViewModel.HasConflict;
								text13 = chamberCommerceCompanyInfoViewModel.ErrorMessage ?? "";
							}
							else
							{
								flag = true;
								text13 = Messages.ErrorInformation;
							}
						}
						else
						{
							text10 = cartNumberFromExcel;
							flag = true;
							text13 += string.Format(Messages.msgErrorIsNotEntered, Labels.ChamberCommerceCardNumber);
						}
					}
					if (string.IsNullOrWhiteSpace(text13))
					{
						DateTime dateTime = default(DateTime);
						if (!string.IsNullOrWhiteSpace(text11))
						{
							try
							{
								dateTime = DateTime.Parse(PersianDate.GetFormatetdDate(text11.Replace("/", "")) + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								cardExpireDateInCalture = dateTime.ToString("yyyy/MM/dd");
								text11 = dateTime.ToString("yyyyMMdd", new PersianCulture());
							}
							catch (Exception e)
							{
								ErrorSignal.FromCurrentContext().Raise(e);
								text10 = cartNumberFromExcel;
								flag = true;
								text13 = text13 + string.Format(Messages.ErrorInFormat, Labels.ChamberCommerceListCardExpireDate) + "|";
							}
						}
						if (string.IsNullOrWhiteSpace(text8))
						{
							text10 = cartNumberFromExcel;
							flag = true;
							text13 = text13 + string.Format(Messages.msgErrorIsNotEntered, Labels.ChamberCommerceListLastName) + "|";
						}
						if (!string.IsNullOrEmpty(text10))
						{
							CRMspCheckDuplicatePrjPostFix_Result cRMspCheckDuplicatePrjPostFix_Result2 = Enumerable.FirstOrDefault<CRMspCheckDuplicatePrjPostFix_Result>((IEnumerable<CRMspCheckDuplicatePrjPostFix_Result>)_db.CRMspCheckDuplicatePrjPostFix(text10, 0, lCID, result));
							if (cRMspCheckDuplicatePrjPostFix_Result2 != null)
							{
								text10 = cartNumberFromExcel;
								flag = true;
								text13 = text13 + string.Format(Messages.CheckDuplicatePrjPostFix, cRMspCheckDuplicatePrjPostFix_Result2.CompanyNumber.ToString(), cRMspCheckDuplicatePrjPostFix_Result2.CompanyName ?? "") + "|";
							}
						}
					}
					list.Add(new ChamberCommerceCompanyInfoViewModel
					{
						RowNumber = num4,
						OfficeTel = (text2 ?? ""),
						TradeCardIdWithCD = (text3 ?? ""),
						FactoryTel = (text4 ?? ""),
						HomeTel = (text5 ?? ""),
						WorkTel = (text6 ?? ""),
						PersianCorporationName = (text7 ?? ""),
						PersianLastName = (text8 ?? ""),
						PersianFirstName = (text9 ?? ""),
						CardNo = (text10 ?? ""),
						CardExpireDate = (text11 ?? ""),
						CardExpireDateInCalture = cardExpireDateInCalture,
						StatusTitle = (text12 ?? ""),
						HasConflict = flag,
						ErrorMessage = (text13 ?? ""),
						Selected = !flag
					});
					num4++;
				}
				text = "";
				commonResultStatusViewModel = CommonResultStatusViewModel.Success;
			}
			catch (Exception ex)
			{
				ErrorSignal.FromCurrentContext().Raise(ex);
				text = ex.Message;
				commonResultStatusViewModel = CommonResultStatusViewModel.Error;
			}
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			text = ex2.Message;
			commonResultStatusViewModel = CommonResultStatusViewModel.Error;
		}
		commonResultViewModel = new CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>>
		{
			Data = list,
			Message = text,
			Status = commonResultStatusViewModel
		};
		JsonResult jsonResult2 = Json(((IEnumerable)new CommonResultViewModel<List<ChamberCommerceCompanyInfoViewModel>>[1] { commonResultViewModel }).ToDataSourceResult(request));
		jsonResult2.MaxJsonLength = int.MaxValue;
		return jsonResult2;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ChamberCommerceImportInfo(string records, int referUserId, string prjTitle, int prjcnvsStatusGroupId, int cmpQuickRegisterDefSettingId)
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
			int? centerId = null;
			if (UserLogin.CurrentUser != null)
			{
				centerId = UserLogin.CurrentUser.UserLastCId;
			}
			DateTime now = DateTime.Now;
			DateTime value = now;
			string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
			int id = Financial.Get().Id;
			short result2 = 0;
			short.TryParse(id.ToString(), out result2);
			short value2 = short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			string appType = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			List<ChamberCommerceCompanyInfoViewModel> list = new List<ChamberCommerceCompanyInfoViewModel>();
			List<ChamberCommerceCompanyInfoViewModel> list2 = new List<ChamberCommerceCompanyInfoViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<ChamberCommerceCompanyInfoViewModel>>(records);
				if (Enumerable.Any<ChamberCommerceCompanyInfoViewModel>((IEnumerable<ChamberCommerceCompanyInfoViewModel>)list))
				{
					list2 = Enumerable.ToList<ChamberCommerceCompanyInfoViewModel>(Enumerable.Where<ChamberCommerceCompanyInfoViewModel>((IEnumerable<ChamberCommerceCompanyInfoViewModel>)list, (Func<ChamberCommerceCompanyInfoViewModel, bool>)((ChamberCommerceCompanyInfoViewModel m) => m.Selected && !m.HasConflict)));
				}
			}
			if (list2 != null && Enumerable.Any<ChamberCommerceCompanyInfoViewModel>((IEnumerable<ChamberCommerceCompanyInfoViewModel>)list2))
			{
				text = "";
				int num2 = 0;
				int count = list2.Count;
				foreach (ChamberCommerceCompanyInfoViewModel item in list2)
				{
					bool flag = true;
					DateTime dateTime = default(DateTime);
					string text2 = "";
					string cardExpireDate = item.CardExpireDate;
					string cardExpireDateInCalture = item.CardExpireDateInCalture;
					DateTime? cardExpireDateTime = null;
					if (!string.IsNullOrWhiteSpace(cardExpireDateInCalture))
					{
						try
						{
							text2 = PersianDate.GetFormatetdDate(cardExpireDateInCalture.Replace("/", ""));
							switch (lCID)
							{
							case 1065:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture());
								cardExpireDate = dateTime.ToString("yyyyMMdd");
								break;
							case 1025:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("ar-SA"));
								cardExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							default:
								dateTime = DateTime.Parse(text2 + " " + DateTime.Now.ToString("HH:mm:ss"), new CultureInfo("en-US"));
								cardExpireDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
								break;
							}
							cardExpireDateTime = dateTime;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							text = text + text + "<br>" + string.Format(Messages.ErrorInFormat, Labels.ChamberCommerceListCardExpireDate);
							flag = false;
						}
					}
					item.CardExpireDate = cardExpireDate;
					item.CardExpireDateInCalture = cardExpireDateInCalture;
					item.CardExpireDateTime = cardExpireDateTime;
					num2++;
					int count2 = num2 * 100 / count;
					if (!flag)
					{
						continue;
					}
					string json = JsonConvert.SerializeObject(item);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					CRMLinkSpEntities dbLink = _dbLink;
					int? cmpReferUserId = referUserId;
					int? prjcnvsStatusGroupId2 = prjcnvsStatusGroupId;
					int? cmpQuickRegisterDefSettingId2 = cmpQuickRegisterDefSettingId;
					int? userId2 = userId;
					short? month = value2;
					int? fPId = id;
					short? year = result2;
					DateTime? registerDate = value;
					string appType2 = appType;
					dbLink.CRMspLkChamberCommerceInsertCmpPrsPrj(json, cmpReferUserId, prjTitle, prjcnvsStatusGroupId2, cmpQuickRegisterDefSettingId2, userId2, fPId, year, month, registerDate, registerDatePersian, lCID, result, appType2, objectParameter, centerId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrEmpty(objectParameter.Value.ToString()))
						{
							string text3 = objectParameter.Value.ToString();
							if (text3.IndexOf("|DupPrjPosetFix|", StringComparison.Ordinal) >= 0)
							{
								string[] array = text3.Split(new string[1] { "|DupPrjPosetFix|" }, StringSplitOptions.None);
								if (array != null && Enumerable.Count<string>((IEnumerable<string>)array) == 3 && !string.IsNullOrEmpty(array[1]))
								{
									string[] array2 = array[1].Split(new char[1] { '|' });
									string newValue = "";
									if (array2 != null && Enumerable.Count<string>((IEnumerable<string>)array2) == 2)
									{
										newValue = string.Format(Messages.CheckDuplicatePrjPostFix, array2[1] ?? "", array2[0] ?? "");
									}
									text3 = text3.Replace("|DupPrjPosetFix|" + array[1] + "|DupPrjPosetFix|", newValue);
								}
								text = text + text + "<br>" + text3;
							}
							else
							{
								text = text + text + "<br>" + objectParameter.Value.ToString();
							}
						}
						else
						{
							ProgressHub.SendMessage("ok", count2, userId);
						}
					}
					else
					{
						ProgressHub.SendMessage("ok", count2, userId);
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
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			num = 0;
			data = new CommonResultViewModel<int>
			{
				Data = num,
				Message = Messages.msgErrorRunFunction + "<br>" + ex.Message,
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

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc,actSendToAcc")]
	public ActionResult ShomaranManageCmpLinkAcc()
	{
		GetCmpReferUser();
		return View();
	}

	public List<CRMspLkShomaranSelectCompany_Result> GetShomaranCompanyList(string cmpName = "", string fromCmpCode = "", string toCmpCode = "", int pageNumber = 1, int pageSize = 100)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspLkShomaranSelectCompany_Result> list = new List<CRMspLkShomaranSelectCompany_Result>();
		try
		{
			_ = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			now.ToString("yyyy/MM/dd HH:mm:ss");
			DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			list = Enumerable.ToList<CRMspLkShomaranSelectCompany_Result>((IEnumerable<CRMspLkShomaranSelectCompany_Result>)_dbLink.CRMspLkShomaranSelectCompany(fromCmpCode, toCmpCode, cmpName, pageNumber, pageSize, lCID, result));
			if (list == null)
			{
				list = new List<CRMspLkShomaranSelectCompany_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ShomaranCompany_Read([DataSourceRequest] DataSourceRequest request, string cmpName = "", string fromCmpCode = "", string toCmpCode = "", int pageNumber = 1, int pageSize = 100)
	{
		List<CRMspLkShomaranSelectCompany_Result> list = new List<CRMspLkShomaranSelectCompany_Result>();
		list = GetShomaranCompanyList(cmpName, fromCmpCode, toCmpCode, pageNumber, pageSize);
		if (list != null && Enumerable.Any<CRMspLkShomaranSelectCompany_Result>((IEnumerable<CRMspLkShomaranSelectCompany_Result>)list))
		{
			foreach (CRMspLkShomaranSelectCompany_Result item in list)
			{
				if (string.IsNullOrWhiteSpace(item.CNAME))
				{
					item.CNAME = item.NAME ?? "";
				}
				item.HMOBILE = item.HMOBILE ?? item.WMOBILE;
				if (!string.IsNullOrWhiteSpace(item.BIRTHDATE))
				{
					item.BIRTHDATE = DateTime.Parse(PersianDate.GetShamsi2Miladi(item.BIRTHDATE.Replace("/", ""))).ToString("yyyy/MM/dd");
				}
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ShomaranImportInfo(string records, int referUserId = 0)
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
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
			if (list2 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
			{
				text = "";
				string cmpSelected = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2));
				ObjectParameter objectParameter = new ObjectParameter("ErrorMessage", "");
				_dbLink.CRMspLkShomaranImportCompany(cmpSelected, referUserId, userId, value2, result2, id, value, registerDatePersian, appType, result, objectParameter, centerId);
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
	public JsonResult GetShomaranImportCompanyList(string records, string cmpName = "", string fromCmpCode = "", string toCmpCode = "", int pageNumber = 1, int pageSize = 100)
	{
		//IL_00a7: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			foreach (CRMspLkShomaranSelectCompany_Result shomaranCompany in GetShomaranCompanyList(cmpName, fromCmpCode, toCmpCode, pageNumber, pageSize))
			{
				OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
				{
					Row = shomaranCompany.RowNumber.GetValueOrDefault(),
					Id = shomaranCompany.CODE,
					Selected = (shomaranCompany.CompanyId <= 0)
				};
				list.Add(item);
			}
			if (!string.IsNullOrWhiteSpace(records))
			{
				List<OtherSystemSelectedVIiewModel> list2 = new List<OtherSystemSelectedVIiewModel>();
				list2 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedVIiewModel>>(records);
				if (Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
				{
					foreach (OtherSystemSelectedVIiewModel item2 in list2)
					{
						foreach (OtherSystemSelectedVIiewModel item3 in list)
						{
							if (item3.Row == item2.Row)
							{
								item3.Selected = item2.Selected;
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actLinkCmpWithAcc")]
	public ActionResult ShomaranLinkedCompany()
	{
		return View();
	}

	[HttpPost]
	public JsonResult ActShomaranLinkedCompany(string syncField, int mode, int fromRec = 0, int recCount = 100)
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
			new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actLinkCmpWithAcc", UserLogin.CurrentUser))
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
				string text4 = "";
				text = "";
				List<CRMspLkShomaranLinkedCompany_Result> list = Enumerable.ToList<CRMspLkShomaranLinkedCompany_Result>((IEnumerable<CRMspLkShomaranLinkedCompany_Result>)_dbLink.CRMspLkShomaranLinkedCompany(syncField, mode, lCID, result));
				if (list != null && Enumerable.Any<CRMspLkShomaranLinkedCompany_Result>((IEnumerable<CRMspLkShomaranLinkedCompany_Result>)list))
				{
					text = "error";
					text4 = GetFileShomaranLinkedCompany(list);
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

	public string GetFileShomaranLinkedCompany(List<CRMspLkShomaranLinkedCompany_Result> res)
	{
		//IL_0473: Unknown result type (might be due to invalid IL or missing references)
		//IL_048e: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShomaranLinkedCompany_Result>((IEnumerable<CRMspLkShomaranLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.Shomaran + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShomaranLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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
						value2 = Messages.msgErrorCmpNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupCmpLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupCmpCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorCmpNotInLinkAcc, Labels.Shomaran);
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
			new List<LinkedCompanyWithAccViewModel>();
			List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkShomaranDeleteLinkedCompany_Result> list3 = Enumerable.ToList<CRMspLkShomaranDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedCompany_Result>)_dbLink.CRMspLkShomaranDeleteLinkedCompany(text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkShomaranDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedCompany_Result>)list3))
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

	public string GetFileShomaranNotDeletedImportedInfo(List<CRMspLkShomaranDeleteLinkedCompany_Result> res)
	{
		//IL_033f: Unknown result type (might be due to invalid IL or missing references)
		//IL_035a: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkShomaranDeleteLinkedCompany_Result>((IEnumerable<CRMspLkShomaranDeleteLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + Labels.Shomaran + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkShomaranDeleteLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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

	[AjaxOnly]
	public string ArpaActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						ArpaBusinessIEViewModel arpaBusinessIEViewModel = new ArpaBusinessIEViewModel();
						int result2 = 0;
						int.TryParse(companyById.cmpTypeId.ToString(), out result2);
						if (result2 == 0)
						{
							text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(companyById.LinkAccCmpTypeIdStr))
						{
							text = string.Format(Messages.msgErrorOtherSystemsNotFindCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), Labels.Arpa, companyById.cmpType ?? "") + "|";
							return text;
						}
						arpaBusinessIEViewModel.BusinessCategoryId = companyById.LinkAccCmpTypeIdStr ?? "";
						arpaBusinessIEViewModel.PhoneNo = companyById.cmpPreTel + companyById.cmpTel;
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.PhoneNo))
						{
							arpaBusinessIEViewModel.PhoneNo = companyById.cmpPreTelII + companyById.cmpTelII;
						}
						arpaBusinessIEViewModel.Fax = companyById.cmpPreTel + companyById.cmpFax;
						arpaBusinessIEViewModel.FinCode = companyById.cmpEconomicCode ?? "";
						arpaBusinessIEViewModel.Address = companyById.cmpAddress ?? "";
						arpaBusinessIEViewModel.PostalCode = companyById.cmpZipCode ?? "";
						arpaBusinessIEViewModel.RegisterNumber = companyById.cmpRegistrationNumber ?? "";
						arpaBusinessIEViewModel.ProvinceId = companyById.LinkAccProvinceIdStr ?? "";
						arpaBusinessIEViewModel.CityId = companyById.LinkAccCityIdStr ?? "";
						if (companyById.cmpKind == 0)
						{
							arpaBusinessIEViewModel.BusName = companyById.CompanyName ?? "";
							arpaBusinessIEViewModel.NationalCode = companyById.cmpNationalCode ?? "";
							arpaBusinessIEViewModel.RealOrFinancial = "1";
							if (companyById.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result != null)
								{
									arpaBusinessIEViewModel.Mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
									arpaBusinessIEViewModel.Email = (cRMspSelectCompanyPersonsByID_Result.prsEmail ?? cRMspSelectCompanyPersonsByID_Result.prsEmailII) ?? "";
									arpaBusinessIEViewModel.Name = cRMspSelectCompanyPersonsByID_Result.prsFName ?? "";
									arpaBusinessIEViewModel.Family = cRMspSelectCompanyPersonsByID_Result.prsLName ?? "";
									arpaBusinessIEViewModel.IDNo = cRMspSelectCompanyPersonsByID_Result.prsIdentityNumber ?? "";
									if (cRMspSelectCompanyPersonsByID_Result.prsBirthDateTime.HasValue)
									{
										arpaBusinessIEViewModel.BirthDate = DateTime.Parse(cRMspSelectCompanyPersonsByID_Result.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
								{
									arpaBusinessIEViewModel.Mobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile ?? "";
									arpaBusinessIEViewModel.Email = (cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail ?? cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII) ?? "";
									arpaBusinessIEViewModel.Name = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName ?? "";
									arpaBusinessIEViewModel.Family = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName ?? "";
									arpaBusinessIEViewModel.IDNo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber ?? "";
									if (cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime.HasValue)
									{
										arpaBusinessIEViewModel.BirthDate = DateTime.Parse(cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
							}
						}
						else if (companyById.cmpKind.GetValueOrDefault() == 1)
						{
							arpaBusinessIEViewModel.RealOrFinancial = "0";
							if (companyById.cmpMainPersonId.HasValue)
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								if (cRMspSelectCompanyPersonsByID_Result2 != null)
								{
									arpaBusinessIEViewModel.Name = cRMspSelectCompanyPersonsByID_Result2.prsFName ?? "";
									arpaBusinessIEViewModel.Family = cRMspSelectCompanyPersonsByID_Result2.prsLName ?? "";
									arpaBusinessIEViewModel.BusName = cRMspSelectCompanyPersonsByID_Result2.PersonName ?? "";
									arpaBusinessIEViewModel.NationalCode = cRMspSelectCompanyPersonsByID_Result2.prsNationalCode ?? "";
									arpaBusinessIEViewModel.Mobile = cRMspSelectCompanyPersonsByID_Result2.prsMobile ?? "";
									arpaBusinessIEViewModel.Email = (cRMspSelectCompanyPersonsByID_Result2.prsEmail ?? cRMspSelectCompanyPersonsByID_Result2.prsEmailII) ?? "";
									arpaBusinessIEViewModel.IDNo = cRMspSelectCompanyPersonsByID_Result2.prsIdentityNumber ?? "";
									if (cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.HasValue)
									{
										arpaBusinessIEViewModel.BirthDate = DateTime.Parse(cRMspSelectCompanyPersonsByID_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd hh:mm:ss", new CultureInfo("en-US"));
									}
								}
							}
							else
							{
								CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result2 = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
								if (cRMspSelectCompanyPersonTop1ByOrderView_Result2 != null)
								{
									arpaBusinessIEViewModel.Name = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsFName ?? "";
									arpaBusinessIEViewModel.Family = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsLName ?? "";
									arpaBusinessIEViewModel.BusName = cRMspSelectCompanyPersonTop1ByOrderView_Result2.PersonName ?? "";
									arpaBusinessIEViewModel.NationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsNationalCode ?? "";
									arpaBusinessIEViewModel.Mobile = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsMobile ?? "";
									arpaBusinessIEViewModel.Email = (cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsEmail ?? cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsEmailII) ?? "";
									arpaBusinessIEViewModel.IDNo = cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsIdentityNumber ?? "";
									if (cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsBirthDateTime.HasValue)
									{
										arpaBusinessIEViewModel.BirthDate = DateTime.Parse(cRMspSelectCompanyPersonTop1ByOrderView_Result2.prsBirthDateTime.ToString()).ToString("yyyy-MM-dd", new CultureInfo("en-US"));
									}
								}
							}
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.BusName))
						{
							arpaBusinessIEViewModel.BusName = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.ProvinceId))
						{
							arpaBusinessIEViewModel.ProvinceId = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.CityId))
						{
							arpaBusinessIEViewModel.CityId = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Email))
						{
							arpaBusinessIEViewModel.Email = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Mobile))
						{
							arpaBusinessIEViewModel.Mobile = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.PhoneNo))
						{
							arpaBusinessIEViewModel.PhoneNo = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Name))
						{
							arpaBusinessIEViewModel.Name = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Family))
						{
							arpaBusinessIEViewModel.Family = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.NationalCode))
						{
							arpaBusinessIEViewModel.NationalCode = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.BirthDate))
						{
							arpaBusinessIEViewModel.BirthDate = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.RealOrFinancial))
						{
							arpaBusinessIEViewModel.RealOrFinancial = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Address))
						{
							arpaBusinessIEViewModel.Address = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.FinCode))
						{
							arpaBusinessIEViewModel.FinCode = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.PostalCode))
						{
							arpaBusinessIEViewModel.PostalCode = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.Fax))
						{
							arpaBusinessIEViewModel.Fax = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.IDNo))
						{
							arpaBusinessIEViewModel.IDNo = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.RegisterNumber))
						{
							arpaBusinessIEViewModel.RegisterNumber = null;
						}
						if (string.IsNullOrWhiteSpace(arpaBusinessIEViewModel.BusinessCategoryId))
						{
							arpaBusinessIEViewModel.BusinessCategoryId = null;
						}
						string text2 = "api/PostBusiness";
						bool flag = true;
						if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
						{
							arpaBusinessIEViewModel.BusinessID = null;
						}
						else
						{
							flag = false;
							arpaBusinessIEViewModel.BusinessID = companyById.cmpLinkAccCustomerIdStr;
							text2 = "api/PutBusiness";
						}
						string value4 = Arpa_GetToken();
						if (!string.IsNullOrWhiteSpace(value4))
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
									httpClient.DefaultRequestHeaders.Add("Authorization", value4);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									HttpContent content = new StringContent(JsonConvert.SerializeObject(arpaBusinessIEViewModel).Replace("\"BusinessID\":null,", "").Replace("\"BusinessID\":null", "")
										.Replace("\"BusName\":null,", "")
										.Replace("\"BusName\":null", "")
										.Replace("\"ProvinceId\":null,", "")
										.Replace("\"ProvinceId\":null", "")
										.Replace("\"CityId\":null,", "")
										.Replace("\"CityId\":null", "")
										.Replace("\"Email\":null,", "")
										.Replace("\"Email\":null", "")
										.Replace("\"Mobile\":null,", "")
										.Replace("\"Mobile\":null", "")
										.Replace("\"PhoneNo\":null,", "")
										.Replace("\"PhoneNo\":null", "")
										.Replace("\"Name\":null,", "")
										.Replace("\"Name\":null", "")
										.Replace("\"Family\":null,", "")
										.Replace("\"Family\":null", "")
										.Replace("\"NationalCode\":null,", "")
										.Replace("\"NationalCode\":null", "")
										.Replace("\"BirthDate\":null,", "")
										.Replace("\"BirthDate\":null", "")
										.Replace("\"RealOrFinancial\":null,", "")
										.Replace("\"RealOrFinancial\":null", "")
										.Replace("\"Address\":null,", "")
										.Replace("\"Address\":null", "")
										.Replace("\"FinCode\":null,", "")
										.Replace("\"FinCode\":null", "")
										.Replace("\"PostalCode\":null,", "")
										.Replace("\"PostalCode\":null", "")
										.Replace("\"Fax\":null,", "")
										.Replace("\"Fax\":null", "")
										.Replace("\"IDNo\":null,", "")
										.Replace("\"IDNo\":null", "")
										.Replace("\"RegisterNumber\":null,", "")
										.Replace("\"RegisterNumber\":null", "")
										.Replace("\"BusinessCategoryId\":null,", "")
										.Replace("\"BusinessCategoryId\":null", "")
										.Replace(",,", ",")
										.Replace(",}", "}")
										.Replace("{,", "{"), Encoding.UTF8, "application/json");
									HttpResponseMessage result3 = httpClient.PostAsync(text4, content).Result;
									if (result3.IsSuccessStatusCode)
									{
										string text5 = result3.Content.ReadAsStringAsync().Result;
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
														ArpaBusinessIEResponseViewModel arpaBusinessIEResponseViewModel = JsonConvert.DeserializeObject<ArpaBusinessIEResponseViewModel>(text6);
														if (arpaBusinessIEResponseViewModel != null)
														{
															bool result4 = false;
															bool.TryParse(arpaBusinessIEResponseViewModel.status.ToString(), out result4);
															if (result4)
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
										ArpaBusinessIEResponseViewModel arpaBusinessIEResponseViewModel2 = JsonConvert.DeserializeObject<ArpaBusinessIEResponseViewModel>(text5);
										if (arpaBusinessIEResponseViewModel2 != null)
										{
											if (!string.IsNullOrWhiteSpace(arpaBusinessIEResponseViewModel2.error))
											{
												text = text + "<br>" + arpaBusinessIEResponseViewModel2.error + "|";
											}
											else if (flag)
											{
												if (arpaBusinessIEResponseViewModel2.data != null)
												{
													string text8 = arpaBusinessIEResponseViewModel2.data.BusinessCode ?? "";
													string text9 = arpaBusinessIEResponseViewModel2.data.BusinessId ?? "";
													if (!string.IsNullOrWhiteSpace(text8) && !string.IsNullOrWhiteSpace(text9))
													{
														CRMLinkSpEntities dbLink = _dbLink;
														int? companyId = cmpId;
														string cmpLinkAccCode = text8;
														dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, 0, cmpLinkAccCode, null, text9, userId, value2, value3, value, registerDatePersian, appType, text8, "");
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
												bool result5 = false;
												bool.TryParse(arpaBusinessIEResponseViewModel2.status.ToString(), out result5);
												text = ((!result5) ? (text + "<br>" + Messages.msgErrorCommunicateWithServer + "|") : ("1|" + companyById.cmpLinkAccCode));
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

	public ArpaCompanyInfoViewModelObjects GetArpaCompanyList(string arpaUserGroupId = "", string mobileNo = "", string businessCode = "", bool getBaseInfoLinkAcc = true)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		ArpaCompanyInfoViewModelObjects arpaCompanyInfoViewModelObjects = new ArpaCompanyInfoViewModelObjects();
		arpaCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		arpaCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
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
						string text2 = "";
						if (!string.IsNullOrWhiteSpace(arpaUserGroupId))
						{
							text2 = "?UserGroupID=" + arpaUserGroupId;
						}
						if (!string.IsNullOrWhiteSpace(mobileNo))
						{
							text2 = (string.IsNullOrWhiteSpace(text2) ? "?" : (text2 + "&"));
							text2 = text2 + "MobileNo=" + mobileNo;
						}
						if (!string.IsNullOrWhiteSpace(businessCode))
						{
							text2 = (string.IsNullOrWhiteSpace(text2) ? "?" : (text2 + "&"));
							text2 = text2 + "BusinessCode=" + businessCode;
						}
						bool flag = false;
						string text3 = "";
						string requestUri = text + "api/GetBusiness" + text2;
						using (HttpClient httpClient = new HttpClient())
						{
							using HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, requestUri);
							httpClient.Timeout = TimeSpan.FromMinutes(5.0);
							httpRequestMessage.Headers.TryAddWithoutValidation("Authorization", value);
							HttpResponseMessage result2 = httpClient.SendAsync(httpRequestMessage).Result;
							text3 = result2.Content.ReadAsStringAsync().Result;
							if (result2.IsSuccessStatusCode && !string.IsNullOrWhiteSpace(text3))
							{
								flag = true;
							}
							if (!string.IsNullOrWhiteSpace(text3) && text3.IndexOf("Fatal error", StringComparison.Ordinal) >= 0)
							{
								text3 = "";
								flag = false;
							}
						}
						if (flag)
						{
							if (!string.IsNullOrWhiteSpace(text3))
							{
								text3 = text3.ClearHiddenCharacters();
							}
							ArpaBusinessResponseViewModel arpaBusinessResponseViewModel = JsonConvert.DeserializeObject<ArpaBusinessResponseViewModel>(text3);
							if (arpaBusinessResponseViewModel != null && arpaBusinessResponseViewModel.data != null && Enumerable.Any<ArpaBusinessInfoViewModel>((IEnumerable<ArpaBusinessInfoViewModel>)arpaBusinessResponseViewModel.data))
							{
								List<CRMspSelectCompanyWithAccLinkField_Result> list2 = new List<CRMspSelectCompanyWithAccLinkField_Result>();
								List<SelectListItem> list3 = new List<SelectListItem>();
								List<SelectListItem> list4 = new List<SelectListItem>();
								List<SelectListItem> list5 = new List<SelectListItem>();
								List<ArpaUserInfoViewModel> list6 = new List<ArpaUserInfoViewModel>();
								if (getBaseInfoLinkAcc)
								{
									list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
									list3 = GetArpaBusinessCategoryList();
									list4 = GetArpaProvinceList();
									list5 = GetArpaCityList();
									list6 = GetArpaReferUserList();
								}
								int num = 1;
								foreach (ArpaBusinessInfoViewModel item in arpaBusinessResponseViewModel.data)
								{
									LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
									lkCompanyAndPersonViewModel.cmpName = item.BusinessName;
									lkCompanyAndPersonViewModel.cmpNameEng = item.LatinName;
									lkCompanyAndPersonViewModel.cmpActivityType = item.BusinessActivity;
									lkCompanyAndPersonViewModel.cmpPreTel = item.PerCityCode;
									lkCompanyAndPersonViewModel.cmpTel = item.PhoneNo;
									lkCompanyAndPersonViewModel.cmpFax = item.Fax;
									lkCompanyAndPersonViewModel.cmpAddress = item.Address;
									lkCompanyAndPersonViewModel.cmpZipCode = item.PostalCode;
									lkCompanyAndPersonViewModel.cmpWebSite = item.WebSite;
									lkCompanyAndPersonViewModel.cmpDescription = item.BusDescription;
									lkCompanyAndPersonViewModel.cmpRegistrationNumber = item.RegisterNumber;
									lkCompanyAndPersonViewModel.cmpEconomicCode = item.FinCode;
									lkCompanyAndPersonViewModel.cmpNationalCode = item.NationalCode;
									lkCompanyAndPersonViewModel.cmpLinkAccCode = item.BusinessCode;
									lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = item.BusinessID;
									lkCompanyAndPersonViewModel.cmpKind = 1;
									if (!string.IsNullOrWhiteSpace(item.RealOrFinancial))
									{
										int result3 = 0;
										int.TryParse(item.RealOrFinancial.ToString(), out result3);
										if (result3 == 0)
										{
											lkCompanyAndPersonViewModel.cmpKind = 1;
										}
										else
										{
											lkCompanyAndPersonViewModel.cmpKind = 0;
										}
									}
									lkCompanyAndPersonViewModel.prsLName = item.Family;
									lkCompanyAndPersonViewModel.prsFName = item.Name;
									lkCompanyAndPersonViewModel.prsMobile = item.Mobile;
									lkCompanyAndPersonViewModel.prsEmail = item.Email;
									lkCompanyAndPersonViewModel.prsIdentityNumber = item.IDNo;
									lkCompanyAndPersonViewModel.prsFatherName = item.FatherName;
									lkCompanyAndPersonViewModel.prsBirthPlace = item.BirthPlace;
									if (!string.IsNullOrWhiteSpace(item.BirthDate))
									{
										switch (lCID)
										{
										case 1065:
										{
											DateTime dateTime4 = DateTime.Parse(item.BirthDate, new CultureInfo("en-US"));
											DateTime dateTime2 = dateTime4;
											lkCompanyAndPersonViewModel.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
											lkCompanyAndPersonViewModel.prsBirthDateTime = dateTime4;
											break;
										}
										case 1025:
										{
											DateTime dateTime3 = DateTime.Parse(item.BirthDate, new CultureInfo("en-US"));
											DateTime dateTime2 = dateTime3;
											lkCompanyAndPersonViewModel.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											lkCompanyAndPersonViewModel.prsBirthDateTime = dateTime3;
											break;
										}
										default:
										{
											DateTime dateTime = DateTime.Parse(item.BirthDate, new CultureInfo("en-US"));
											DateTime dateTime2 = dateTime;
											lkCompanyAndPersonViewModel.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											lkCompanyAndPersonViewModel.prsBirthDateTime = dateTime;
											break;
										}
										}
									}
									lkCompanyAndPersonViewModel.RowNumber = num;
									CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.BusinessID));
									if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
									{
										lkCompanyAndPersonViewModel.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
									}
									else
									{
										lkCompanyAndPersonViewModel.CompanyId = 0;
									}
									if (list3 != null && !string.IsNullOrWhiteSpace(item.BusinessCategoryID))
									{
										SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list3, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.BusinessCategoryID));
										if (selectListItem != null)
										{
											lkCompanyAndPersonViewModel.LinkAccCmpTypeIdStr = selectListItem.Value;
											lkCompanyAndPersonViewModel.CmpTypeTitle = selectListItem.Text;
										}
									}
									if (list4 != null && !string.IsNullOrWhiteSpace(item.ProvinceID))
									{
										SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list4, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.ProvinceID));
										if (selectListItem2 != null)
										{
											lkCompanyAndPersonViewModel.LinkAccProvinceIdStr = selectListItem2.Value;
											lkCompanyAndPersonViewModel.ProvinceName = selectListItem2.Text;
										}
									}
									if (list5 != null && !string.IsNullOrWhiteSpace(item.CityID))
									{
										SelectListItem selectListItem3 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)list5, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == item.CityID));
										if (selectListItem3 != null)
										{
											lkCompanyAndPersonViewModel.LinkAccCityIdStr = selectListItem3.Value;
											lkCompanyAndPersonViewModel.CityName = selectListItem3.Text;
										}
									}
									if (list6 != null && !string.IsNullOrWhiteSpace(item.RepresentorID))
									{
										ArpaUserInfoViewModel arpaUserInfoViewModel = Enumerable.FirstOrDefault<ArpaUserInfoViewModel>((IEnumerable<ArpaUserInfoViewModel>)list6, (Func<ArpaUserInfoViewModel, bool>)((ArpaUserInfoViewModel x) => x.RepresentorID == item.RepresentorID));
										if (arpaUserInfoViewModel != null)
										{
											lkCompanyAndPersonViewModel.cmpReferLinkAccUserIdStr = arpaUserInfoViewModel.RepresentorID;
											lkCompanyAndPersonViewModel.cmpReferLinkAccUserCode = arpaUserInfoViewModel.RepresentorCode;
											lkCompanyAndPersonViewModel.cmpReferLName = arpaUserInfoViewModel.RepresentorName;
										}
									}
									list.Add(lkCompanyAndPersonViewModel);
									num++;
								}
							}
						}
					}
				}
			}
			arpaCompanyInfoViewModelObjects.lst = list;
			arpaCompanyInfoViewModelObjects.FilteredLst = list;
			arpaCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			arpaCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return arpaCompanyInfoViewModelObjects;
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

	public List<SelectListItem> GetArpaUserGroupList()
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetArpaUserGroup()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = GetArpaUserGroupList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ArpaUserGroupList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetArpaBusinessCategoryList()
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
						string text3 = text + "api/GetBusinessCategory" + text2;
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
							ArpaBusinessCategoryResponseViewModel arpaBusinessCategoryResponseViewModel = JsonConvert.DeserializeObject<ArpaBusinessCategoryResponseViewModel>(value2);
							if (arpaBusinessCategoryResponseViewModel != null && arpaBusinessCategoryResponseViewModel.data != null && Enumerable.Any<ArpaBusinessCategoryInfoViewModel>((IEnumerable<ArpaBusinessCategoryInfoViewModel>)arpaBusinessCategoryResponseViewModel.data))
							{
								foreach (ArpaBusinessCategoryInfoViewModel datum in arpaBusinessCategoryResponseViewModel.data)
								{
									datum.BusinessCategoryID = datum.BusinessCategoryID.TrimEnd(new char[1] { ' ' });
									datum.BusinessCategoryName = datum.BusinessCategoryName.TrimEnd(new char[1] { ' ' });
								}
								list.AddRange(Enumerable.Select<ArpaBusinessCategoryInfoViewModel, SelectListItem>((IEnumerable<ArpaBusinessCategoryInfoViewModel>)arpaBusinessCategoryResponseViewModel.data, (Func<ArpaBusinessCategoryInfoViewModel, SelectListItem>)((ArpaBusinessCategoryInfoViewModel item) => new SelectListItem
								{
									Text = (item.BusinessCategoryName ?? ""),
									Value = (item.BusinessCategoryID ?? ""),
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
		return list;
	}

	[AjaxOnly]
	public JsonResult GetArpaBusinessCategory()
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			list = GetArpaBusinessCategoryList();
			if (list == null)
			{
				list = new List<SelectListItem>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.ArpaBusinessCategoryList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	public List<SelectListItem> GetArpaProvinceList()
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
						string text2 = text + "api/GetProvince";
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
							ArpaProvinceResponseViewModel arpaProvinceResponseViewModel = JsonConvert.DeserializeObject<ArpaProvinceResponseViewModel>(value2);
							if (arpaProvinceResponseViewModel != null && arpaProvinceResponseViewModel.data != null && Enumerable.Any<ArpaProvinceInfoViewModel>((IEnumerable<ArpaProvinceInfoViewModel>)arpaProvinceResponseViewModel.data))
							{
								foreach (ArpaProvinceInfoViewModel datum in arpaProvinceResponseViewModel.data)
								{
									datum.ProvinceID = datum.ProvinceID.TrimEnd(new char[1] { ' ' });
									datum.ProvinceName = datum.ProvinceName.TrimEnd(new char[1] { ' ' });
								}
								list.AddRange(Enumerable.Select<ArpaProvinceInfoViewModel, SelectListItem>((IEnumerable<ArpaProvinceInfoViewModel>)arpaProvinceResponseViewModel.data, (Func<ArpaProvinceInfoViewModel, SelectListItem>)((ArpaProvinceInfoViewModel item) => new SelectListItem
								{
									Text = (item.ProvinceName ?? ""),
									Value = (item.ProvinceID ?? ""),
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
		return list;
	}

	public List<SelectListItem> GetArpaCityList()
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
						string text2 = text + "api/GetCity";
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
							ArpaCityResponseViewModel arpaCityResponseViewModel = JsonConvert.DeserializeObject<ArpaCityResponseViewModel>(value2);
							if (arpaCityResponseViewModel != null && arpaCityResponseViewModel.data != null && Enumerable.Any<ArpaCityInfoViewModel>((IEnumerable<ArpaCityInfoViewModel>)arpaCityResponseViewModel.data))
							{
								foreach (ArpaCityInfoViewModel datum in arpaCityResponseViewModel.data)
								{
									datum.CityID = datum.CityID.TrimEnd(new char[1] { ' ' });
									datum.CityName = datum.CityName.TrimEnd(new char[1] { ' ' });
								}
								list.AddRange(Enumerable.Select<ArpaCityInfoViewModel, SelectListItem>((IEnumerable<ArpaCityInfoViewModel>)arpaCityResponseViewModel.data, (Func<ArpaCityInfoViewModel, SelectListItem>)((ArpaCityInfoViewModel item) => new SelectListItem
								{
									Text = (item.CityName ?? ""),
									Value = (item.CityID ?? ""),
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
		return list;
	}

	public List<ArpaUserInfoViewModel> GetArpaReferUserList()
	{
		List<ArpaUserInfoViewModel> list = new List<ArpaUserInfoViewModel>();
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
						string text3 = text + "api/GetRepresentors" + text2;
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
							ArpaUserResponseViewModel arpaUserResponseViewModel = JsonConvert.DeserializeObject<ArpaUserResponseViewModel>(value2);
							if (arpaUserResponseViewModel != null && arpaUserResponseViewModel.data != null && Enumerable.Any<ArpaUserInfoViewModel>((IEnumerable<ArpaUserInfoViewModel>)arpaUserResponseViewModel.data))
							{
								list.AddRange(Enumerable.Select<ArpaUserInfoViewModel, ArpaUserInfoViewModel>((IEnumerable<ArpaUserInfoViewModel>)arpaUserResponseViewModel.data, (Func<ArpaUserInfoViewModel, ArpaUserInfoViewModel>)((ArpaUserInfoViewModel item) => new ArpaUserInfoViewModel
								{
									RepresentorID = (item.RepresentorID ?? ""),
									RepresentorCode = (item.RepresentorCode ?? ""),
									RepresentorName = (item.RepresentorName ?? ""),
									Address = (item.Address ?? ""),
									PhoneNo = (item.PhoneNo ?? ""),
									FinCode = (item.FinCode ?? ""),
									Mobile = (item.Mobile ?? ""),
									Fax = (item.Fax ?? "")
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
		return list;
	}

	[AjaxOnly]
	public string ArpaCmpAccountingDetail(int cmpId, ref decimal remainAccount)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
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
									string text2 = "?BusinessID=" + companyById.cmpLinkAccCustomerIdStr;
									HttpClient httpClient = new HttpClient();
									string text3 = text + "api/GetBusRemaining" + text2;
									httpClient.BaseAddress = new Uri(text3);
									httpClient.DefaultRequestHeaders.Add("Authorization", value);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									HttpContent content = new StringContent("", Encoding.UTF8, "application/json");
									HttpResponseMessage result3 = httpClient.PostAsync(text3, content).Result;
									if (result3.IsSuccessStatusCode)
									{
										string value2 = result3.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										ArpaCmpAccountingDetailResponseViewModel arpaCmpAccountingDetailResponseViewModel = JsonConvert.DeserializeObject<ArpaCmpAccountingDetailResponseViewModel>(value2);
										if (arpaCmpAccountingDetailResponseViewModel != null && arpaCmpAccountingDetailResponseViewModel.data != null && Enumerable.Any<ArpaCmpAccountingDetailInfoViewModel>((IEnumerable<ArpaCmpAccountingDetailInfoViewModel>)arpaCmpAccountingDetailResponseViewModel.data))
										{
											ArpaCmpAccountingDetailInfoViewModel arpaCmpAccountingDetailInfoViewModel = Enumerable.FirstOrDefault<ArpaCmpAccountingDetailInfoViewModel>((IEnumerable<ArpaCmpAccountingDetailInfoViewModel>)arpaCmpAccountingDetailResponseViewModel.data);
											decimal result4 = default(decimal);
											if (arpaCmpAccountingDetailInfoViewModel != null)
											{
												decimal.TryParse(arpaCmpAccountingDetailInfoViewModel.BusinessRemain, out result4);
											}
											remainAccount = result4;
											result = "";
										}
									}
								}
							}
						}
						else
						{
							Exception e = new Exception(Messages.msgErrorReceivingToken);
							ErrorSignal.FromCurrentContext().Raise(e);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in arpa");
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e4 = new Exception(Messages.ErrorNotFound + "(customer)");
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

	[AjaxOnly]
	public string ArpaGetCmpCredit(int cmpId, ref decimal creditAccount)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCode))
					{
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
									string text2 = "?BusinessCode=" + companyById.cmpLinkAccCode;
									HttpClient httpClient = new HttpClient();
									string text3 = text + "api/GetCustomersCredit" + text2;
									httpClient.BaseAddress = new Uri(text3);
									httpClient.DefaultRequestHeaders.Add("Authorization", value);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									new StringContent("", Encoding.UTF8, "application/json");
									HttpResponseMessage result3 = httpClient.GetAsync(text3).Result;
									if (result3.IsSuccessStatusCode)
									{
										string value2 = result3.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(value2))
										{
											value2 = value2.ClearHiddenCharacters();
										}
										ArpaCmpAccountingDetailResponseViewModel arpaCmpAccountingDetailResponseViewModel = JsonConvert.DeserializeObject<ArpaCmpAccountingDetailResponseViewModel>(value2);
										if (arpaCmpAccountingDetailResponseViewModel != null && arpaCmpAccountingDetailResponseViewModel.data != null && Enumerable.Any<ArpaCmpAccountingDetailInfoViewModel>((IEnumerable<ArpaCmpAccountingDetailInfoViewModel>)arpaCmpAccountingDetailResponseViewModel.data))
										{
											ArpaCmpAccountingDetailInfoViewModel arpaCmpAccountingDetailInfoViewModel = Enumerable.FirstOrDefault<ArpaCmpAccountingDetailInfoViewModel>((IEnumerable<ArpaCmpAccountingDetailInfoViewModel>)arpaCmpAccountingDetailResponseViewModel.data);
											decimal num = default(decimal);
											if (arpaCmpAccountingDetailInfoViewModel != null)
											{
												num = arpaCmpAccountingDetailInfoViewModel.SumCashAndCheckCredit.GetValueOrDefault();
											}
											creditAccount = num;
											result = "";
										}
									}
								}
							}
						}
						else
						{
							Exception e = new Exception(Messages.msgErrorReceivingToken);
							ErrorSignal.FromCurrentContext().Raise(e);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in arpa");
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e4 = new Exception(Messages.ErrorNotFound + "(customer)");
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

	[AjaxOnly]
	public string LinkAccByViewGetCmpAccountingDetail(int cmpId, ref decimal linkAccRemain)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				if (CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId) != null)
				{
					ObjectParameter objectParameter = new ObjectParameter("CompanyRemain", typeof(decimal));
					_dbLink.CRMspLkVwReturnCmpAccountRemaining(cmpId, objectParameter);
					decimal result2 = default(decimal);
					if (objectParameter != null && objectParameter.Value != null)
					{
						decimal.TryParse(objectParameter.Value.ToString(), out result2);
					}
					linkAccRemain = result2;
					return "";
				}
				Exception e = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e);
				return Labels.frmError;
			}
			Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e2);
			return Labels.frmError;
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
			return Labels.frmError;
		}
	}

	[AjaxOnly]
	public string HamrahanActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						int result2 = 0;
						int result3 = 0;
						int.TryParse(companyById.cmpTypeId.ToString(), out result2);
						if (result2 == 0)
						{
							text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
							return text;
						}
						if (string.IsNullOrWhiteSpace(companyById.LinkAccCmpTypeIdStr))
						{
							text = string.Format(Messages.msgErrorOtherSystemsNotFindCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), Labels.Hamrahan, companyById.cmpType ?? "") + "|";
							return text;
						}
						int.TryParse(companyById.LinkAccCmpTypeIdStr, out result3);
						string value4 = new LinkAccHamrahanSettingController().Hamrahan_GetToken();
						if (!string.IsNullOrWhiteSpace(value4))
						{
							CRMIdeal.Classes.Helper.OtherSystems.HamrahanSettingViewModel hamrahanSetting = CRMIdeal.Classes.Helper.OtherSystems.GetHamrahanSetting();
							if (hamrahanSetting != null)
							{
								string text2 = hamrahanSetting.HamrahanApiAddress ?? "";
								string text3 = hamrahanSetting.HamrahanApiVersion ?? "";
								string text4 = hamrahanSetting.HamrahanCompanyId ?? "";
								string text5 = hamrahanSetting.HamrahanApiVersionDefineCmp ?? "";
								string text6 = hamrahanSetting.LegalStateFormal ?? "";
								string text7 = hamrahanSetting.RealStateFormal ?? "";
								string s = hamrahanSetting.LegalCompanyType ?? "";
								string s2 = hamrahanSetting.RealIndexOwner ?? "";
								string s3 = hamrahanSetting.RealIndexState ?? "";
								string s4 = hamrahanSetting.RealIndexClass ?? "";
								string s5 = hamrahanSetting.RealIndexKind ?? "";
								string s6 = hamrahanSetting.RealIndexCredit ?? "";
								string s7 = hamrahanSetting.LegalIndexOwner ?? "";
								string s8 = hamrahanSetting.LegalIndexState ?? "";
								string s9 = hamrahanSetting.LegalIndexClass ?? "";
								string s10 = hamrahanSetting.LegalIndexKind ?? "";
								string s11 = hamrahanSetting.LegalIndexCredit ?? "";
								if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text6) && !string.IsNullOrWhiteSpace(text7) && !string.IsNullOrWhiteSpace(text5))
								{
									if (!text2.EndsWith("/"))
									{
										text2 += "/";
									}
									if (!text2.EndsWith("api/"))
									{
										text2 += "api/";
									}
									string text8 = text2 + "v" + text5 + "/";
									text2 = text2 + "v" + text3 + "/";
									int result4 = 0;
									int.TryParse(text4, out result4);
									HamrahanCustomerDefineViewModel hamrahanCustomerDefineViewModel = new HamrahanCustomerDefineViewModel();
									HamrahanCompanyDefineViewModel hamrahanCompanyDefineViewModel = new HamrahanCompanyDefineViewModel();
									HamrahanPersonaDefineViewModel hamrahanPersonaDefineViewModel = new HamrahanPersonaDefineViewModel();
									int result5 = 0;
									int.TryParse(s, out result5);
									int result6 = 0;
									int.TryParse(s2, out result6);
									int result7 = 0;
									int.TryParse(s3, out result7);
									int result8 = 0;
									int.TryParse(s4, out result8);
									int result9 = 0;
									int.TryParse(s5, out result9);
									int result10 = 0;
									int.TryParse(s6, out result10);
									int result11 = 0;
									int.TryParse(s7, out result11);
									int result12 = 0;
									int.TryParse(s8, out result12);
									int result13 = 0;
									int.TryParse(s9, out result13);
									int result14 = 0;
									int.TryParse(s10, out result14);
									int result15 = 0;
									int.TryParse(s11, out result15);
									if (companyById.cmpKind == 0)
									{
										hamrahanCompanyDefineViewModel.recNo = companyById.cmpLinkAccCodeId;
										hamrahanCompanyDefineViewModel.company = result4;
										hamrahanCompanyDefineViewModel.caption = companyById.cmpTitle ?? "";
										hamrahanCompanyDefineViewModel.nameCompany = companyById.cmpName ?? "";
										hamrahanCompanyDefineViewModel.typeCompany = result5;
										hamrahanCompanyDefineViewModel.codeEconomic = companyById.cmpEconomicCode ?? "";
										hamrahanCompanyDefineViewModel.nameSummary = "";
										hamrahanCompanyDefineViewModel.latinCaption = "";
										hamrahanCompanyDefineViewModel.latinNameCompany = companyById.cmpNameEng ?? "";
										hamrahanCompanyDefineViewModel.address = companyById.cmpAddress ?? "";
										hamrahanCompanyDefineViewModel.active = true;
										hamrahanCompanyDefineViewModel.tel = companyById.cmpPreTel + companyById.cmpTel;
										if (string.IsNullOrWhiteSpace(hamrahanCompanyDefineViewModel.tel))
										{
											hamrahanCompanyDefineViewModel.tel = companyById.cmpPreTelII + companyById.cmpTelII;
										}
										hamrahanCompanyDefineViewModel.tel = hamrahanCompanyDefineViewModel.tel ?? "";
										hamrahanCompanyDefineViewModel.mobile = companyById.cmpMobile ?? "";
										hamrahanCompanyDefineViewModel.email = companyById.cmpEmail ?? "";
										hamrahanCompanyDefineViewModel.registerNo = companyById.cmpRegistrationNumber ?? "";
										hamrahanCompanyDefineViewModel.kindPersona = 0;
										hamrahanCompanyDefineViewModel.refDomain = 0;
										hamrahanCompanyDefineViewModel.postalCode = companyById.cmpZipCode ?? "";
										hamrahanCompanyDefineViewModel.nationalCode = companyById.cmpNationalCode ?? "";
										hamrahanCompanyDefineViewModel.rnGroupFormal = 0;
										hamrahanCompanyDefineViewModel.ttmS_Ostan = 0;
										hamrahanCompanyDefineViewModel.ttmS_Shahr = 0;
										hamrahanCompanyDefineViewModel.kindId = 0;
										hamrahanCompanyDefineViewModel.categoryId = 0;
										hamrahanCompanyDefineViewModel.nationality = null;
										hamrahanCompanyDefineViewModel.accountNumber = "";
										int result16 = 0;
										int.TryParse(text6, out result16);
										hamrahanCompanyDefineViewModel.StateFormal = result16;
										hamrahanCustomerDefineViewModel.indexCredit = result15;
										hamrahanCustomerDefineViewModel.indexKind = result14;
										hamrahanCustomerDefineViewModel.indexClass = result13;
										hamrahanCustomerDefineViewModel.indexState = result12;
										hamrahanCustomerDefineViewModel.indexOwner = result11;
									}
									else if (companyById.cmpKind.GetValueOrDefault() == 1)
									{
										CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result();
										if (companyById.cmpMainPersonId.HasValue)
										{
											cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
										}
										else
										{
											CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
											if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
											{
												cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result
												{
													CompanyPersonID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
													prsCompanyId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
													prsLName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName,
													prsFName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName,
													prsTitleId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
													prsJobId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
													prsTypeId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
													prsGroupId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
													prsSexId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
													prsEducationId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
													prsPreTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
													prsTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTel,
													prsTelUpTo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
													prsTelDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
													prsTelII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
													prsFax = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFax,
													prsFaxDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
													prsMobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
													prsWebSite = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
													prsEmail = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
													prsEmailII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
													prsCountryId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
													prsProvinceId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
													prsCityId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
													prsAddress = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
													prsAddressDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
													prsZipCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
													prsPostBox = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
													prsNationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
													prsIdentityNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
													prsFatherName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
													prsBirthDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
													prsBirthDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
													prsBirthPlace = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
													prsIsMarried = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
													prsMarriageDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
													prsMarriageDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
													prsEducationField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
													prsSkill = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
													prsStudyField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
													prsInteresting = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
													prsSpecialPoint = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
													prsDescription = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
													UserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.UserId,
													Year1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Year1,
													Month1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Month1,
													RegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
													RegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
													AddType = cRMspSelectCompanyPersonTop1ByOrderView_Result.AddType,
													ImportDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
													ImportDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
													prsFirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
													prsDepartmentId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
													prsStopSendSms = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
													prsOrderView = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
													prsWorkingOut = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
													GUId = cRMspSelectCompanyPersonTop1ByOrderView_Result.GUId,
													CompanyPersonTemplateID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
													LanguageID = cRMspSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
													FirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
													FirstRegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
													FirstRegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
													prsTelegramId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
													PersonName = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
													prsTitle = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
												};
											}
										}
										if (cRMspSelectCompanyPersonsByID_Result != null)
										{
											hamrahanPersonaDefineViewModel.recNo = companyById.cmpLinkAccCodeId;
											hamrahanPersonaDefineViewModel.company = result4;
											hamrahanPersonaDefineViewModel.caption = cRMspSelectCompanyPersonsByID_Result.prsTitle ?? "";
											hamrahanPersonaDefineViewModel.namePersona = cRMspSelectCompanyPersonsByID_Result.prsFName ?? "";
											hamrahanPersonaDefineViewModel.familyPersona = cRMspSelectCompanyPersonsByID_Result.prsLName ?? "";
											hamrahanPersonaDefineViewModel.latinCaption = "";
											hamrahanPersonaDefineViewModel.latinNamePersona = "";
											hamrahanPersonaDefineViewModel.latinFamilyPersona = "";
											hamrahanPersonaDefineViewModel.address = companyById.cmpAddress ?? "";
											hamrahanPersonaDefineViewModel.postalCode = companyById.cmpZipCode ?? "";
											if (string.IsNullOrWhiteSpace(hamrahanPersonaDefineViewModel.address))
											{
												hamrahanPersonaDefineViewModel.address = cRMspSelectCompanyPersonsByID_Result.prsAddress;
												hamrahanPersonaDefineViewModel.postalCode = cRMspSelectCompanyPersonsByID_Result.prsZipCode;
											}
											hamrahanPersonaDefineViewModel.address = hamrahanPersonaDefineViewModel.address ?? "";
											hamrahanPersonaDefineViewModel.postalCode = hamrahanPersonaDefineViewModel.postalCode ?? "";
											hamrahanPersonaDefineViewModel.active = true;
											hamrahanPersonaDefineViewModel.nationalCode = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
											hamrahanPersonaDefineViewModel.tel = companyById.cmpPreTel + companyById.cmpTel;
											if (string.IsNullOrWhiteSpace(hamrahanPersonaDefineViewModel.tel))
											{
												hamrahanPersonaDefineViewModel.tel = companyById.cmpPreTelII + companyById.cmpTelII;
											}
											if (string.IsNullOrWhiteSpace(hamrahanPersonaDefineViewModel.tel))
											{
												hamrahanPersonaDefineViewModel.tel = cRMspSelectCompanyPersonsByID_Result.prsPreTel + cRMspSelectCompanyPersonsByID_Result.prsTel;
											}
											if (string.IsNullOrWhiteSpace(hamrahanPersonaDefineViewModel.tel))
											{
												hamrahanPersonaDefineViewModel.tel = cRMspSelectCompanyPersonsByID_Result.prsTelII ?? "";
											}
											hamrahanPersonaDefineViewModel.tel = hamrahanPersonaDefineViewModel.tel ?? "";
											hamrahanPersonaDefineViewModel.mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
											hamrahanPersonaDefineViewModel.email = (cRMspSelectCompanyPersonsByID_Result.prsEmail ?? cRMspSelectCompanyPersonsByID_Result.prsEmailII) ?? "";
											hamrahanPersonaDefineViewModel.email = hamrahanPersonaDefineViewModel.email ?? "";
											hamrahanPersonaDefineViewModel.accountNumber = "";
											hamrahanPersonaDefineViewModel.rnGroupFormal = 0;
											hamrahanPersonaDefineViewModel.nationality = null;
											hamrahanPersonaDefineViewModel.ttmS_Ostan = 0;
											hamrahanPersonaDefineViewModel.ttmS_Shahr = 0;
											hamrahanPersonaDefineViewModel.kindId = 0;
											hamrahanPersonaDefineViewModel.categoryId = 0;
											hamrahanPersonaDefineViewModel.codeEconomic = companyById.cmpEconomicCode ?? "";
											int result17 = 0;
											int.TryParse(text7, out result17);
											hamrahanPersonaDefineViewModel.StateFormal = result17;
										}
										hamrahanCustomerDefineViewModel.indexCredit = result10;
										hamrahanCustomerDefineViewModel.indexKind = result9;
										hamrahanCustomerDefineViewModel.indexClass = result8;
										hamrahanCustomerDefineViewModel.indexState = result7;
										hamrahanCustomerDefineViewModel.indexOwner = result6;
									}
									hamrahanCustomerDefineViewModel.refGuild = 0;
									hamrahanCustomerDefineViewModel.dateSayNIDEID = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
									hamrahanCustomerDefineViewModel.company = result4;
									hamrahanCustomerDefineViewModel.refGroup = ((result3 != 0) ? new int?(result3) : null);
									string text9 = "DefineCompany";
									string text10 = "DefineCustomer";
									bool flag = true;
									if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
									{
										hamrahanCustomerDefineViewModel.recNo = 0;
										hamrahanCompanyDefineViewModel.recNo = 0;
										hamrahanPersonaDefineViewModel.recNo = 0;
										if (companyById.cmpKind == 0)
										{
											text9 = "DefineCompany";
										}
										else if (companyById.cmpKind.GetValueOrDefault() == 1)
										{
											text9 = "DefinePersona";
										}
									}
									else
									{
										flag = false;
										int result18 = 0;
										int.TryParse(companyById.cmpLinkAccCustomerIdStr.ToString(), out result18);
										hamrahanCustomerDefineViewModel.recNo = result18;
										hamrahanCompanyDefineViewModel.recNo = companyById.cmpLinkAccCodeId;
										hamrahanPersonaDefineViewModel.recNo = companyById.cmpLinkAccCodeId;
										hamrahanCustomerDefineViewModel.refFormal = companyById.cmpLinkAccCodeId.GetValueOrDefault();
										hamrahanCompanyDefineViewModel.registerDate = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
										if (companyById.cmpKind == 0)
										{
											text9 = "DefineCompany";
										}
										else if (companyById.cmpKind.GetValueOrDefault() == 1)
										{
											text9 = "DefinePersona";
										}
									}
									HttpClient httpClient = new HttpClient();
									string text11 = text8 + text9;
									httpClient.BaseAddress = new Uri(text11);
									httpClient.DefaultRequestHeaders.Add("Authorization", value4);
									httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
									string content = "";
									if (companyById.cmpKind == 0)
									{
										content = JsonConvert.SerializeObject(hamrahanCompanyDefineViewModel);
									}
									else if (companyById.cmpKind.GetValueOrDefault() == 1)
									{
										content = JsonConvert.SerializeObject(hamrahanPersonaDefineViewModel);
									}
									HttpContent content2 = new StringContent(content, Encoding.UTF8, "application/json");
									HttpResponseMessage httpResponseMessage = new HttpResponseMessage();
									httpResponseMessage = ((!flag) ? httpClient.PutAsync(text11, content2).Result : httpClient.PostAsync(text11, content2).Result);
									if (httpResponseMessage.IsSuccessStatusCode)
									{
										string text12 = httpResponseMessage.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(text12))
										{
											text12 = text12.ClearHiddenCharacters();
										}
										if (!string.IsNullOrWhiteSpace(text12))
										{
											int result19 = 0;
											bool result20 = false;
											if (flag)
											{
												int.TryParse(text12, out result19);
												hamrahanCustomerDefineViewModel.refFormal = result19;
											}
											else
											{
												bool.TryParse(text12, out result20);
											}
											if (result19 != 0 || result20)
											{
												httpClient = new HttpClient();
												text11 = text2 + text10;
												httpClient.BaseAddress = new Uri(text11);
												httpClient.DefaultRequestHeaders.Add("Authorization", value4);
												httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
												content = JsonConvert.SerializeObject(hamrahanCustomerDefineViewModel);
												content2 = new StringContent(content, Encoding.UTF8, "application/json");
												httpResponseMessage = new HttpResponseMessage();
												httpResponseMessage = ((!flag) ? httpClient.PutAsync(text11, content2).Result : httpClient.PostAsync(text11, content2).Result);
												text12 = "";
												if (httpResponseMessage.IsSuccessStatusCode)
												{
													text12 = httpResponseMessage.Content.ReadAsStringAsync().Result;
													if (!string.IsNullOrWhiteSpace(text12))
													{
														text12 = text12.ClearHiddenCharacters();
													}
													if (!string.IsNullOrWhiteSpace(text12))
													{
														bool result21 = false;
														bool.TryParse(text12, out result21);
														if (result21)
														{
															string text13 = "";
															if (flag)
															{
																HttpResponseHeaders headers = httpResponseMessage.Headers;
																if (headers != null && headers.TryGetValues("Location", out var values))
																{
																	text13 = Enumerable.First<string>(values);
																}
															}
															else
															{
																text13 = text2 + "DefineCustomer/company/" + result4 + "/recno/" + hamrahanCustomerDefineViewModel.recNo;
															}
															if (!string.IsNullOrWhiteSpace(text13))
															{
																httpClient = new HttpClient();
																text11 = text13;
																httpClient.BaseAddress = new Uri(text11);
																httpClient.DefaultRequestHeaders.Add("Authorization", value4);
																httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
																content = "";
																content2 = new StringContent(content, Encoding.UTF8, "application/json");
																httpResponseMessage = new HttpResponseMessage();
																httpResponseMessage = httpClient.GetAsync(text11).Result;
																text12 = "";
																if (httpResponseMessage.IsSuccessStatusCode)
																{
																	text12 = httpResponseMessage.Content.ReadAsStringAsync().Result;
																	if (!string.IsNullOrWhiteSpace(text12))
																	{
																		text12 = text12.ClearHiddenCharacters();
																	}
																	if (!string.IsNullOrWhiteSpace(text12))
																	{
																		HamrahanCustomerOneInfoViewModel hamrahanCustomerOneInfoViewModel = JsonConvert.DeserializeObject<HamrahanCustomerOneInfoViewModel>(text12);
																		if (hamrahanCustomerOneInfoViewModel != null)
																		{
																			string text14 = hamrahanCustomerOneInfoViewModel.customerCode ?? "";
																			int valueOrDefault = hamrahanCustomerOneInfoViewModel.refFormal.GetValueOrDefault();
																			string text15 = hamrahanCustomerOneInfoViewModel.recNo.GetValueOrDefault().ToString();
																			if (!string.IsNullOrWhiteSpace(text14) && !string.IsNullOrWhiteSpace(text15))
																			{
																				CRMLinkSpEntities dbLink = _dbLink;
																				int? companyId = cmpId;
																				string cmpLinkAccCode = text14;
																				dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, valueOrDefault, cmpLinkAccCode, null, text15, userId, value2, value3, value, registerDatePersian, appType, text14, "");
																				text = "1|" + text14;
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
																text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
															}
														}
														else
														{
															text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text12 + ")|";
														}
													}
													else
													{
														text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
													}
												}
												else
												{
													string text16 = httpResponseMessage.Content.ReadAsStringAsync().Result;
													if (!string.IsNullOrWhiteSpace(text16))
													{
														text16 = text16.ClearHiddenCharacters();
													}
													text = text + "<br>" + Messages.msgErrorCommunicateWithServer + " (" + text16 + ")|";
												}
											}
											else
											{
												text = text + "<br>" + Messages.msgErrorCommunicateWithServer + " (" + text12 + ")|";
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
										}
									}
									else
									{
										string text17 = httpResponseMessage.Content.ReadAsStringAsync().Result;
										if (!string.IsNullOrWhiteSpace(text17))
										{
											text17 = text17.ClearHiddenCharacters();
										}
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + " (" + text17 + ")|";
									}
								}
								else
								{
									text = Messages.errorInReadingSetting + "|";
								}
							}
							else
							{
								text = Messages.errorInReadingSetting + "|";
							}
						}
						else
						{
							text = Messages.msgErrorReceivingToken + "|";
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

	public HamrahanCompanyInfoViewModelObjects GetHamrahanCompanyList()
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		HamrahanCompanyInfoViewModelObjects hamrahanCompanyInfoViewModelObjects = new HamrahanCompanyInfoViewModelObjects();
		hamrahanCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		hamrahanCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
						string text4 = text + "customer/company/" + text3;
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
								List<HamrahanCustomerInfoViewModel> list2 = JsonConvert.DeserializeObject<List<HamrahanCustomerInfoViewModel>>(value2);
								if (list2 != null && Enumerable.Any<HamrahanCustomerInfoViewModel>((IEnumerable<HamrahanCustomerInfoViewModel>)list2))
								{
									List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
									int num = 1;
									foreach (HamrahanCustomerInfoViewModel item in list2)
									{
										bool flag = true;
										if (list != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list))
										{
											LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel m) => m.cmpLinkAccCustomerIdStr == item.rnCustomer.GetValueOrDefault().ToString()));
											if (lkCompanyAndPersonViewModel != null && !string.IsNullOrWhiteSpace(lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr))
											{
												flag = false;
											}
										}
										if (!flag)
										{
											continue;
										}
										LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel2 = new LkCompanyAndPersonViewModel();
										lkCompanyAndPersonViewModel2.cmpName = item.nameFormal;
										lkCompanyAndPersonViewModel2.cmpLinkAccCode = item.customerCode;
										lkCompanyAndPersonViewModel2.cmpLinkAccCodeId = item.refFormal;
										lkCompanyAndPersonViewModel2.cmpLinkAccCustomerIdStr = item.rnCustomer.GetValueOrDefault().ToString();
										if (item.refGroup.GetValueOrDefault() != 0L)
										{
											lkCompanyAndPersonViewModel2.LinkAccCmpTypeIdStr = item.refGroup.GetValueOrDefault().ToString();
											lkCompanyAndPersonViewModel2.CmpTypeTitle = item.groupName ?? "";
										}
										lkCompanyAndPersonViewModel2.prsLName = item.nameFormal;
										List<HamrahanCustomerInfoViewModel> list4 = Enumerable.ToList<HamrahanCustomerInfoViewModel>(Enumerable.Where<HamrahanCustomerInfoViewModel>((IEnumerable<HamrahanCustomerInfoViewModel>)list2, (Func<HamrahanCustomerInfoViewModel, bool>)((HamrahanCustomerInfoViewModel m) => m.rnCustomer == item.rnCustomer)));
										if (list4 != null && Enumerable.Any<HamrahanCustomerInfoViewModel>((IEnumerable<HamrahanCustomerInfoViewModel>)list4))
										{
											List<LkCompanyGroupsMultiViewModel> list5 = new List<LkCompanyGroupsMultiViewModel>();
											foreach (HamrahanCustomerInfoViewModel item3 in list4)
											{
												LkCompanyGroupsMultiViewModel item2 = new LkCompanyGroupsMultiViewModel
												{
													GroupName = item3.groupName,
													LinkAccGroupIdStr = item3.refGroup.GetValueOrDefault().ToString()
												};
												list5.Add(item2);
											}
											if (list5 != null && Enumerable.Any<LkCompanyGroupsMultiViewModel>((IEnumerable<LkCompanyGroupsMultiViewModel>)list5))
											{
												lkCompanyAndPersonViewModel2.CompanyGroupsMulti = JsonConvert.SerializeObject(Enumerable.ToList<LkCompanyGroupsMultiViewModel>((IEnumerable<LkCompanyGroupsMultiViewModel>)list5));
											}
										}
										lkCompanyAndPersonViewModel2.RowNumber = num;
										if (list3 != null)
										{
											CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.rnCustomer.GetValueOrDefault().ToString()));
											if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
											{
												lkCompanyAndPersonViewModel2.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
											}
											else
											{
												lkCompanyAndPersonViewModel2.CompanyId = 0;
											}
										}
										else
										{
											lkCompanyAndPersonViewModel2.CompanyId = 0;
										}
										list.Add(lkCompanyAndPersonViewModel2);
										num++;
									}
								}
							}
						}
					}
				}
			}
			hamrahanCompanyInfoViewModelObjects.lst = list;
			hamrahanCompanyInfoViewModelObjects.FilteredLst = list;
			hamrahanCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			hamrahanCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return hamrahanCompanyInfoViewModelObjects;
	}

	[AjaxOnly]
	public string HamrahanCmpAccountingDetail(int cmpId, ref decimal remainAccount)
	{
		//IL_0226: Unknown result type (might be due to invalid IL or missing references)
		//IL_022d: Expected O, but got Unknown
		//IL_02cc: Unknown result type (might be due to invalid IL or missing references)
		//IL_02d1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02de: Unknown result type (might be due to invalid IL or missing references)
		//IL_02e8: Invalid comparison between Unknown and I4
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
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
								string text5 = hamrahanSetting.HamrahanApiUserId ?? "";
								if (!string.IsNullOrWhiteSpace(text2) && !string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text4) && !string.IsNullOrWhiteSpace(text5))
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
									int result3 = 0;
									int.TryParse(text4, out result3);
									int result4 = 0;
									int.TryParse(text5, out result4);
									string text6 = DateTime.Now.ToString("yyyy/01/01", new PersianCulture());
									string text7 = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
									string text8 = text2 + "CustomerStatement";
									string value = "{\"company\":" + result3 + ",\"startDate\":\"" + text6 + "\",\"endDate\":\"" + text7 + "\",\"userID\":" + result4 + ",\"recNoCustomer\":\"" + companyById.cmpLinkAccCustomerIdStr + "\",\"customerStatementGetModel\":0}";
									HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text8);
									((NameValueCollection)((WebRequest)val).Headers).Add("Authorization", text);
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
											HamrahanCustomerStatementViewModel hamrahanCustomerStatementViewModel = JsonConvert.DeserializeObject<HamrahanCustomerStatementViewModel>(value3);
											if (hamrahanCustomerStatementViewModel != null)
											{
												remainAccount = hamrahanCustomerStatementViewModel.sumRemain.GetValueOrDefault();
												result = "";
											}
										}
									}
								}
							}
						}
						else
						{
							Exception e = new Exception(Messages.msgErrorReceivingToken);
							ErrorSignal.FromCurrentContext().Raise(e);
							result = Labels.frmError;
						}
					}
					else
					{
						Exception e2 = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in hamrahan");
						ErrorSignal.FromCurrentContext().Raise(e2);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e3);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e4 = new Exception(Messages.ErrorNotFound + "(customer)");
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

	[AjaxOnly]
	public string NoAvaranCapillaryActCmpSendToAcc(int cmpId, int benefiCmpId = 0, int zoneId = 0, int routeId = 0, int cmpType = 0, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					LinkAccNoAvCapillarySettingController linkAccNoAvCapillarySettingController = new LinkAccNoAvCapillarySettingController();
					if (benefiCmpId == 0)
					{
						List<SelectListItem> noAvaranCapillaryCompanyList = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryCompanyList();
						if (noAvaranCapillaryCompanyList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCompanyList))
						{
							SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCompanyList);
							if (selectListItem != null)
							{
								int.TryParse(selectListItem.Value ?? "0", out benefiCmpId);
							}
						}
					}
					if (zoneId == 0)
					{
						List<SelectListItem> noAvaranCapillaryZoneList = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryZoneList();
						if (noAvaranCapillaryZoneList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryZoneList))
						{
							SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryZoneList);
							if (selectListItem2 != null)
							{
								int.TryParse(selectListItem2.Value ?? "0", out zoneId);
							}
						}
					}
					if (routeId == 0)
					{
						List<SelectListItem> noAvaranCapillaryRouteList = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryRouteList();
						if (noAvaranCapillaryRouteList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryRouteList))
						{
							SelectListItem selectListItem3 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryRouteList);
							if (selectListItem3 != null)
							{
								int.TryParse(selectListItem3.Value ?? "0", out routeId);
							}
						}
					}
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
						if (noAvaranCapillarySetting != null)
						{
							string text2 = noAvaranCapillarySetting.ApiUserId ?? "";
							if (string.IsNullOrWhiteSpace(text2) || !string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
							{
								text = (string.IsNullOrWhiteSpace(text2) ? (Messages.errorInReadingSetting + "|") : ((string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr) || string.IsNullOrWhiteSpace(companyById.cmpLinkAccCode)) ? (Messages.msgErrorRunFunction + "|") : ("1|" + companyById.cmpLinkAccCode)));
							}
							else
							{
								CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result();
								if (companyById.cmpMainPersonId.HasValue)
								{
									cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
								}
								else
								{
									CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
									if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
									{
										cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result
										{
											CompanyPersonID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
											prsCompanyId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
											prsLName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName,
											prsFName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName,
											prsTitleId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
											prsJobId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
											prsTypeId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
											prsGroupId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
											prsSexId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
											prsEducationId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
											prsPreTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
											prsTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTel,
											prsTelUpTo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
											prsTelDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
											prsTelII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
											prsFax = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFax,
											prsFaxDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
											prsMobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
											prsWebSite = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
											prsEmail = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
											prsEmailII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
											prsCountryId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
											prsProvinceId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
											prsCityId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
											prsAddress = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
											prsAddressDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
											prsZipCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
											prsPostBox = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
											prsNationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
											prsIdentityNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
											prsFatherName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
											prsBirthDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
											prsBirthDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
											prsBirthPlace = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
											prsIsMarried = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
											prsMarriageDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
											prsMarriageDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
											prsEducationField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
											prsSkill = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
											prsStudyField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
											prsInteresting = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
											prsSpecialPoint = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
											prsDescription = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
											UserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.UserId,
											Year1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Year1,
											Month1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Month1,
											RegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
											RegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
											AddType = cRMspSelectCompanyPersonTop1ByOrderView_Result.AddType,
											ImportDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
											ImportDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
											prsFirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
											prsDepartmentId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
											prsStopSendSms = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
											prsOrderView = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
											prsWorkingOut = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
											GUId = cRMspSelectCompanyPersonTop1ByOrderView_Result.GUId,
											CompanyPersonTemplateID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
											LanguageID = cRMspSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
											FirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
											FirstRegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
											FirstRegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
											prsTelegramId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
											PersonName = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
											prsTitle = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
										};
									}
								}
								string text3 = "0";
								string name = "";
								string kindCustomer = cmpType.ToString();
								string text4 = "";
								string text5 = "";
								string text6 = "";
								string sh_Sabt = companyById.cmpRegistrationNumber ?? "";
								string code_E = companyById.cmpEconomicCode ?? "";
								string codePosti = companyById.cmpZipCode ?? "";
								string text7 = companyById.cmpAddress ?? "";
								string longitude = companyById.cmpCoordinateLongitude ?? "";
								string latitude = companyById.cmpCoordinateLatitude ?? "";
								string idCountry = companyById.LinkAccCountryIdStr ?? "";
								string idProvince = companyById.LinkAccProvinceIdStr ?? "";
								string idCity = companyById.LinkAccCityIdStr ?? "";
								string text8 = companyById.cmpPreTel + companyById.cmpTel;
								string pishCode = companyById.cmpPreTel ?? "";
								if (string.IsNullOrWhiteSpace(text8))
								{
									text8 = companyById.cmpPreTelII + companyById.cmpTelII;
									pishCode = companyById.cmpPreTelII ?? "";
								}
								string text9 = companyById.cmpFax ?? "";
								string webSayt = companyById.cmpWebSite ?? "";
								string text10 = companyById.cmpEmail ?? "";
								string text11 = companyById.cmpMobile ?? "";
								string kindAct = companyById.cmpActivityType ?? "";
								string dateSabt = DateTime.Now.ToString("yyyy/MM/dd", new PersianCulture());
								string shenaseMeli = "";
								string idZone = zoneId.ToString();
								string idRoute = routeId.ToString();
								string typeCustomer = "";
								string idCompany = benefiCmpId.ToString();
								string descCustomer = companyById.cmpDescription ?? "";
								if (companyById.cmpKind == 0)
								{
									name = companyById.CompanyName ?? "";
									typeCustomer = "2";
									text6 = companyById.cmpNationalCode ?? "";
									shenaseMeli = companyById.cmpNationalCode ?? "";
								}
								else if (companyById.cmpKind.GetValueOrDefault() == 1)
								{
									object obj = cRMspSelectCompanyPersonsByID_Result.PersonName ?? companyById.CompanyName;
									if (obj == null)
									{
										obj = "";
									}
									name = (string)obj;
									typeCustomer = "1";
									text6 = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
									shenaseMeli = text6;
									if (string.IsNullOrWhiteSpace(text7))
									{
										text7 = cRMspSelectCompanyPersonsByID_Result.prsAddress ?? "";
										codePosti = cRMspSelectCompanyPersonsByID_Result.prsZipCode ?? "";
									}
									if (string.IsNullOrWhiteSpace(text8))
									{
										text8 = cRMspSelectCompanyPersonsByID_Result.prsPreTel + cRMspSelectCompanyPersonsByID_Result.prsTel;
										pishCode = cRMspSelectCompanyPersonsByID_Result.prsPreTel ?? "";
										if (string.IsNullOrWhiteSpace(text8))
										{
											text8 = cRMspSelectCompanyPersonsByID_Result.prsTelII ?? "";
											pishCode = "";
										}
									}
									if (string.IsNullOrWhiteSpace(text9))
									{
										text9 = cRMspSelectCompanyPersonsByID_Result.prsFax ?? "";
									}
								}
								text4 = (cRMspSelectCompanyPersonsByID_Result.prsFName ?? companyById.CompanyName) ?? "";
								text5 = (cRMspSelectCompanyPersonsByID_Result.prsLName ?? companyById.CompanyName) ?? "";
								if (string.IsNullOrWhiteSpace(text10))
								{
									object obj2 = cRMspSelectCompanyPersonsByID_Result.prsEmail ?? cRMspSelectCompanyPersonsByID_Result.prsEmailII;
									if (obj2 == null)
									{
										obj2 = "";
									}
									text10 = (string)obj2;
								}
								if (string.IsNullOrWhiteSpace(text11))
								{
									text11 = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
								}
								CommercialSoapClient commercialSoapClient = new CommercialSoapClient();
								text3 = commercialSoapClient.GetLastCodeCustomer();
								text3 = ((!string.IsNullOrWhiteSpace(text3)) ? text3.Replace("\"", "") : "0");
								string text12 = commercialSoapClient.InsertIntoCustomer(text3, name, kindCustomer, text4, text5, text6, sh_Sabt, code_E, codePosti, text7, "", text2, idCountry, idProvince, idCity, "", text8, text9, webSayt, text10, text11, "", "", "", "", kindAct, "", "", "", dateSabt, "", "", "", "", "", "", pishCode, "", "", "0", shenaseMeli, "", "", "", "", idZone, idRoute, longitude, latitude, typeCustomer, idCompany, descCustomer);
								if (!string.IsNullOrWhiteSpace(text12))
								{
									text12 = text12.ClearHiddenCharacters();
								}
								if (!string.IsNullOrWhiteSpace(text12))
								{
									string[] array = Regex.Split(text12.ToLower(), "Success Insert Customer Id=".ToLower());
									if (array != null)
									{
										if (array.Length >= 2)
										{
											string text13 = text3 ?? "";
											string text14 = array[1] ?? "";
											if (!string.IsNullOrWhiteSpace(text13) && !string.IsNullOrWhiteSpace(text14))
											{
												CRMLinkSpEntities dbLink = _dbLink;
												int? companyId = cmpId;
												string cmpLinkAccCode = text13;
												dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, null, cmpLinkAccCode, null, text14, userId, value2, value3, value, registerDatePersian, appType, text13, "");
												text = "1|" + text13;
											}
											else
											{
												text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text12 + "|";
											}
										}
										else
										{
											text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text12 + "|";
										}
									}
									else
									{
										text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "<br>" + text12 + "|";
									}
								}
								else
								{
									text = text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
								}
							}
						}
						else
						{
							text = Messages.errorInReadingSetting + "|";
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

	public LkCompanyInfoViewModelObjects GetNoAvaranCapillaryCompanyList(string noAvCode = "", string noAvName = "", string noAvCodeMeli = "", string fromDate = "", string toDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string sabtDate = "";
					string sabtDate2 = "";
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fromDate))
						{
							fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							sabtDate = (lCID switch
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
							sabtDate2 = (lCID switch
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
					string value = new CommercialSoapClient().ReadFromCustomer(noAvCode ?? "", text, noAvName ?? "", noAvCodeMeli ?? "", sabtDate, sabtDate2);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryListCustomerViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryListCustomerViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryListCustomerViewModel>((IEnumerable<NoAvaranCapillaryListCustomerViewModel>)list2))
						{
							List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
							List<SelectListItem> noAvaranCapillaryCountryList = GetNoAvaranCapillaryCountryList();
							List<SelectListItem> noAvaranCapillaryProvinceList = GetNoAvaranCapillaryProvinceList();
							List<SelectListItem> noAvaranCapillaryCityList = GetNoAvaranCapillaryCityList();
							int num = 1;
							foreach (NoAvaranCapillaryListCustomerViewModel item2 in list2)
							{
								NoAvaranCapillaryCustomerInfoViewModel item = item2.x;
								if (item == null)
								{
									continue;
								}
								LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
								vm.cmpName = item.Name;
								vm.cmpLinkAccCode = item.Code;
								vm.cmpLinkAccCustomerIdStr = item.id.GetValueOrDefault().ToString();
								vm.cmpNationalCode = item.ShenaseMeli;
								if (string.IsNullOrWhiteSpace(vm.cmpNationalCode))
								{
									vm.cmpNationalCode = item.CodeMeli;
								}
								vm.cmpRegistrationNumber = item.Sh_Sabt;
								vm.cmpEconomicCode = item.Code_E;
								vm.cmpZipCode = item.CodePosti;
								vm.cmpAddress = item.AddressDaftar ?? item.AddressTahvil;
								if (string.IsNullOrWhiteSpace(vm.cmpAddress))
								{
									vm.cmpAddress = item.AddressDaftar;
								}
								vm.cmpPreTel = item.PishCode;
								vm.cmpTel = item.Tel;
								vm.cmpFax = item.Fax;
								vm.cmpWebSite = item.WebSayt;
								vm.cmpActivityType = item.KindAct;
								vm.cmpDescription = item.DescCustomer;
								if (item.idCountry.GetValueOrDefault() != 0L)
								{
									vm.LinkAccCountryIdStr = item.idCountry.GetValueOrDefault().ToString();
									if (noAvaranCapillaryCountryList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCountryList))
									{
										SelectListItem selectListItem = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCountryList, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == vm.LinkAccCountryIdStr));
										if (selectListItem != null)
										{
											vm.CountryName = selectListItem.Text ?? "";
										}
									}
								}
								if (item.idProvince.GetValueOrDefault() != 0L)
								{
									vm.LinkAccProvinceIdStr = item.idProvince.GetValueOrDefault().ToString();
									if (noAvaranCapillaryProvinceList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryProvinceList))
									{
										SelectListItem selectListItem2 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryProvinceList, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == vm.LinkAccProvinceIdStr));
										if (selectListItem2 != null)
										{
											vm.ProvinceName = selectListItem2.Text ?? "";
										}
									}
								}
								if (item.idCity.GetValueOrDefault() != 0L)
								{
									vm.LinkAccCityIdStr = item.idCity.GetValueOrDefault().ToString();
									if (noAvaranCapillaryCityList != null && Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCityList))
									{
										SelectListItem selectListItem3 = Enumerable.FirstOrDefault<SelectListItem>((IEnumerable<SelectListItem>)noAvaranCapillaryCityList, (Func<SelectListItem, bool>)((SelectListItem x) => x.Value == vm.LinkAccCityIdStr));
										if (selectListItem3 != null)
										{
											vm.CityName = selectListItem3.Text ?? "";
										}
									}
								}
								if (item.TypeCustomer.GetValueOrDefault() == 1)
								{
									vm.cmpKind = 1;
								}
								else
								{
									vm.cmpKind = 0;
								}
								vm.prsFName = item.FirstName;
								vm.prsLName = item.LastName;
								vm.prsEmail = item.Email;
								vm.prsMobile = item.Mobile;
								vm.RowNumber = num;
								if (list3 != null)
								{
									CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.id.GetValueOrDefault().ToString()));
									if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
									{
										vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
									}
									else
									{
										vm.CompanyId = 0;
									}
								}
								else
								{
									vm.CompanyId = 0;
								}
								list.Add(vm);
								num++;
							}
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkCompanyInfoViewModelObjects;
	}

	public List<SelectListItem> GetNoAvaranCapillaryCountryList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromContry("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryCountryInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryCountryInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryCountryInfoViewModel>((IEnumerable<NoAvaranCapillaryCountryInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryCountryInfoViewModel item in list2)
							{
								item.id = item.id;
								item.Name = item.Name.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryCountryInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryCountryInfoViewModel>)list2, (Func<NoAvaranCapillaryCountryInfoViewModel, SelectListItem>)((NoAvaranCapillaryCountryInfoViewModel item) => new SelectListItem
							{
								Text = (item.Name ?? ""),
								Value = item.id.GetValueOrDefault().ToString(),
								Selected = false
							})));
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

	public List<SelectListItem> GetNoAvaranCapillaryProvinceList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromProvince("", text);
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryProvinceInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryProvinceInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryProvinceInfoViewModel>((IEnumerable<NoAvaranCapillaryProvinceInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryProvinceInfoViewModel item in list2)
							{
								item.id = item.id;
								item.Name = item.Name.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryProvinceInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryProvinceInfoViewModel>)list2, (Func<NoAvaranCapillaryProvinceInfoViewModel, SelectListItem>)((NoAvaranCapillaryProvinceInfoViewModel item) => new SelectListItem
							{
								Text = (item.Name ?? ""),
								Value = item.id.GetValueOrDefault().ToString(),
								Selected = false
							})));
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

	public List<SelectListItem> GetNoAvaranCapillaryCityList()
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
			CRMIdeal.Classes.Helper.OtherSystems.NoAvaranCapillarySettingViewModel noAvaranCapillarySetting = CRMIdeal.Classes.Helper.OtherSystems.GetNoAvaranCapillarySetting();
			if (noAvaranCapillarySetting != null)
			{
				string text = noAvaranCapillarySetting.ApiUserId ?? "";
				if (!string.IsNullOrWhiteSpace(text))
				{
					string value = new CommercialSoapClient().ReadFromCity("", text, "");
					if (!string.IsNullOrWhiteSpace(value))
					{
						value = value.ClearHiddenCharacters();
					}
					if (!string.IsNullOrWhiteSpace(value))
					{
						List<NoAvaranCapillaryCityInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NoAvaranCapillaryCityInfoViewModel>>(value);
						if (list2 != null && Enumerable.Any<NoAvaranCapillaryCityInfoViewModel>((IEnumerable<NoAvaranCapillaryCityInfoViewModel>)list2))
						{
							foreach (NoAvaranCapillaryCityInfoViewModel item in list2)
							{
								item.id = item.id;
								item.Name = item.Name.TrimEnd(new char[1] { ' ' });
							}
							list.AddRange(Enumerable.Select<NoAvaranCapillaryCityInfoViewModel, SelectListItem>((IEnumerable<NoAvaranCapillaryCityInfoViewModel>)list2, (Func<NoAvaranCapillaryCityInfoViewModel, SelectListItem>)((NoAvaranCapillaryCityInfoViewModel item) => new SelectListItem
							{
								Text = (item.Name ?? ""),
								Value = item.id.GetValueOrDefault().ToString(),
								Selected = false
							})));
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
	public string NoAvaranCapillaryCmpAccountingDetail(int cmpId, ref decimal remainAccount)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						string text = new CommercialSoapClient().Idealsp_MandeHesab(companyById.cmpLinkAccCustomerIdStr);
						if (!string.IsNullOrWhiteSpace(text))
						{
							text = text.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text))
						{
							decimal.TryParse(text, out remainAccount);
							result = "";
						}
					}
					else
					{
						Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in hamrahan");
						ErrorSignal.FromCurrentContext().Raise(e);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e3);
				result = Labels.frmError;
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			result = Labels.frmError;
		}
		return result;
	}

	[AjaxOnly]
	public string RahkaranRetailActCmpSendToAcc(int cmpId, string cookieVal, int cmpType = 0, bool isExportCustomer = false, bool checkAction = true)
	{
		//IL_0a35: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a3c: Expected O, but got Unknown
		//IL_0adb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ae0: Unknown result type (might be due to invalid IL or missing references)
		//IL_0aed: Unknown result type (might be due to invalid IL or missing references)
		//IL_0af7: Invalid comparison between Unknown and I4
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						if (!string.IsNullOrWhiteSpace(cookieVal))
						{
							string text2 = new LinkAccRahkaranRetailSettingController().Rahkaran_GetCooKie(cookieVal);
							if (!string.IsNullOrWhiteSpace(text2))
							{
								if (cmpType == 0)
								{
									cmpType = 1;
								}
								CRMIdeal.Classes.Helper.OtherSystems.RahkaranRetailSettingViewModel rahkaranRetailSetting = CRMIdeal.Classes.Helper.OtherSystems.GetRahkaranRetailSetting();
								if (rahkaranRetailSetting != null)
								{
									string text3 = rahkaranRetailSetting.ApiAddress ?? "";
									int currencyRef = rahkaranRetailSetting.CurrencyRef;
									if (!string.IsNullOrWhiteSpace(text3) && !text3.EndsWith("/"))
									{
										text3 += "/";
									}
									if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(text2))
									{
										if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
										{
											long result2 = 0L;
											long.TryParse(companyById.cmpLinkAccCustomerIdStr, out result2);
											LkCompanyAndPersonViewModel rahkaranRetailCompanyById = GetRahkaranRetailCompanyById(cookieVal, result2);
											if (rahkaranRetailCompanyById != null && !string.IsNullOrWhiteSpace(rahkaranRetailCompanyById.cmpLinkAccCustomerIdStr))
											{
												return string.Format(Messages.msgErrorOtherSystemsAlreadyTransferred, Labels.OtherSystemsCompany, Labels.RahkaranRetail) + "|";
											}
										}
										RahkaranRetailCustomerDefineViewModel obj = new RahkaranRetailCustomerDefineViewModel
										{
											Addresss = new List<RahkaranRetailCustomerAddressDefineViewModel>()
										};
										RahkaranRetailCustomerAddressDefineViewModel rahkaranRetailCustomerAddressDefineViewModel = new RahkaranRetailCustomerAddressDefineViewModel
										{
											Location = new RahkaranRetailCustomerAddressLocationDefineViewModel()
										};
										RahkaranRetailCustomerPartyDefineViewModel rahkaranRetailCustomerPartyDefineViewModel = new RahkaranRetailCustomerPartyDefineViewModel();
										obj.CurrencyRef = currencyRef;
										obj.DeclarationDate = null;
										obj.EconomicCode = companyById.cmpEconomicCode ?? "";
										obj.ExchangeCode = "";
										obj.IsExportCustomer = isExportCustomer;
										obj.Number = "";
										obj.SalesOfficeIDs = null;
										obj.SecondCode = null;
										obj.Type = cmpType;
										rahkaranRetailCustomerAddressDefineViewModel.Details = companyById.cmpCountry + ((!string.IsNullOrWhiteSpace(companyById.cmpProvince)) ? ("  - " + companyById.cmpProvince) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpCity)) ? ("  - " + companyById.cmpCity) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpAddress)) ? ("  - " + companyById.cmpAddress) : "");
										rahkaranRetailCustomerAddressDefineViewModel.Tel = companyById.cmpPreTel + companyById.cmpTel;
										if (string.IsNullOrWhiteSpace(rahkaranRetailCustomerAddressDefineViewModel.Tel))
										{
											rahkaranRetailCustomerAddressDefineViewModel.Tel = companyById.cmpPreTelII + companyById.cmpTelII;
										}
										rahkaranRetailCustomerAddressDefineViewModel.Tel = rahkaranRetailCustomerAddressDefineViewModel.Tel ?? "";
										rahkaranRetailCustomerAddressDefineViewModel.Fax = companyById.cmpFax ?? "";
										rahkaranRetailCustomerAddressDefineViewModel.IsDefault = true;
										if (!string.IsNullOrWhiteSpace(companyById.cmpCoordinateLatitude) && !string.IsNullOrWhiteSpace(companyById.cmpCoordinateLongitude))
										{
											rahkaranRetailCustomerAddressDefineViewModel.Location.Latitude = companyById.cmpCoordinateLatitude;
											rahkaranRetailCustomerAddressDefineViewModel.Location.Longitude = companyById.cmpCoordinateLongitude;
										}
										rahkaranRetailCustomerAddressDefineViewModel.Email = companyById.cmpEmail ?? "";
										rahkaranRetailCustomerAddressDefineViewModel.Name = "اصلی";
										rahkaranRetailCustomerAddressDefineViewModel.ZipCode = companyById.cmpZipCode ?? "";
										rahkaranRetailCustomerAddressDefineViewModel.RegionalDivisionName = companyById.cmpCity ?? "";
										rahkaranRetailCustomerAddressDefineViewModel.RegionalDivisionRef = 3;
										if (companyById.cmpKind == 0)
										{
											rahkaranRetailCustomerPartyDefineViewModel.BirthCertificateNumber = "";
											rahkaranRetailCustomerPartyDefineViewModel.BirthDate = null;
											rahkaranRetailCustomerPartyDefineViewModel.CompanyName = ((!string.IsNullOrWhiteSpace(companyById.cmpTitle)) ? (companyById.cmpTitle + " ") : "") + companyById.cmpName;
											rahkaranRetailCustomerPartyDefineViewModel.CompanyRegisterationCode = companyById.cmpRegistrationNumber ?? "";
											rahkaranRetailCustomerPartyDefineViewModel.FatherName = "";
											rahkaranRetailCustomerPartyDefineViewModel.FidaRegistration = "";
											rahkaranRetailCustomerPartyDefineViewModel.FirstName = rahkaranRetailCustomerPartyDefineViewModel.CompanyName;
											rahkaranRetailCustomerPartyDefineViewModel.LastName = "";
											rahkaranRetailCustomerPartyDefineViewModel.Mobile = companyById.cmpMobile ?? "";
											rahkaranRetailCustomerPartyDefineViewModel.NationalID = companyById.cmpNationalCode ?? "";
											rahkaranRetailCustomerPartyDefineViewModel.Type = 1;
										}
										else if (companyById.cmpKind.GetValueOrDefault() == 1)
										{
											CRMspSelectCompanyPersonsByID_Result cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result();
											if (companyById.cmpMainPersonId.HasValue)
											{
												cRMspSelectCompanyPersonsByID_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonsByID_Result>((IEnumerable<CRMspSelectCompanyPersonsByID_Result>)_db.CRMspSelectCompanyPersonsByID(companyById.cmpMainPersonId, lCID, result));
											}
											else
											{
												CRMspSelectCompanyPersonTop1ByOrderView_Result cRMspSelectCompanyPersonTop1ByOrderView_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyPersonTop1ByOrderView_Result>((IEnumerable<CRMspSelectCompanyPersonTop1ByOrderView_Result>)_db.CRMspSelectCompanyPersonTop1ByOrderView(cmpId, lCID, result));
												if (cRMspSelectCompanyPersonTop1ByOrderView_Result != null)
												{
													cRMspSelectCompanyPersonsByID_Result = new CRMspSelectCompanyPersonsByID_Result
													{
														CompanyPersonID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonID,
														prsCompanyId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCompanyId,
														prsLName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsLName,
														prsFName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFName,
														prsTitleId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTitleId,
														prsJobId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsJobId,
														prsTypeId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTypeId,
														prsGroupId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsGroupId,
														prsSexId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSexId,
														prsEducationId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationId,
														prsPreTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPreTel,
														prsTel = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTel,
														prsTelUpTo = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelUpTo,
														prsTelDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelDesc,
														prsTelII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelII,
														prsFax = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFax,
														prsFaxDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFaxDesc,
														prsMobile = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMobile,
														prsWebSite = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWebSite,
														prsEmail = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmail,
														prsEmailII = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEmailII,
														prsCountryId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCountryId,
														prsProvinceId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsProvinceId,
														prsCityId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsCityId,
														prsAddress = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddress,
														prsAddressDesc = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsAddressDesc,
														prsZipCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsZipCode,
														prsPostBox = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsPostBox,
														prsNationalCode = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsNationalCode,
														prsIdentityNumber = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIdentityNumber,
														prsFatherName = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFatherName,
														prsBirthDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDate,
														prsBirthDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthDateTime,
														prsBirthPlace = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsBirthPlace,
														prsIsMarried = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsIsMarried,
														prsMarriageDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDate,
														prsMarriageDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsMarriageDateTime,
														prsEducationField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsEducationField,
														prsSkill = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSkill,
														prsStudyField = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStudyField,
														prsInteresting = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsInteresting,
														prsSpecialPoint = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsSpecialPoint,
														prsDescription = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDescription,
														UserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.UserId,
														Year1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Year1,
														Month1 = cRMspSelectCompanyPersonTop1ByOrderView_Result.Month1,
														RegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDate,
														RegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.RegisterDatePersian,
														AddType = cRMspSelectCompanyPersonTop1ByOrderView_Result.AddType,
														ImportDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDate,
														ImportDateTime = cRMspSelectCompanyPersonTop1ByOrderView_Result.ImportDateTime,
														prsFirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsFirstRegisterUserId,
														prsDepartmentId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsDepartmentId,
														prsStopSendSms = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsStopSendSms,
														prsOrderView = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsOrderView,
														prsWorkingOut = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsWorkingOut,
														GUId = cRMspSelectCompanyPersonTop1ByOrderView_Result.GUId,
														CompanyPersonTemplateID = cRMspSelectCompanyPersonTop1ByOrderView_Result.CompanyPersonTemplateID,
														LanguageID = cRMspSelectCompanyPersonTop1ByOrderView_Result.LanguageID,
														FirstRegisterUserId = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterUserId,
														FirstRegisterDatePersian = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDatePersian,
														FirstRegisterDate = cRMspSelectCompanyPersonTop1ByOrderView_Result.FirstRegisterDate,
														prsTelegramId = cRMspSelectCompanyPersonTop1ByOrderView_Result.prsTelegramId,
														PersonName = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitleName,
														prsTitle = cRMspSelectCompanyPersonTop1ByOrderView_Result.PersonTitle
													};
												}
											}
											if (cRMspSelectCompanyPersonsByID_Result != null)
											{
												rahkaranRetailCustomerPartyDefineViewModel.BirthCertificateNumber = cRMspSelectCompanyPersonsByID_Result.prsIdentityNumber ?? "";
												if (cRMspSelectCompanyPersonsByID_Result.prsBirthDateTime.HasValue)
												{
													string birthDate = "\\/Date(" + ((DateTimeOffset)cRMspSelectCompanyPersonsByID_Result.prsBirthDateTime.Value).ToUnixTimeMilliseconds() + "+0330)\\/";
													rahkaranRetailCustomerPartyDefineViewModel.BirthDate = birthDate;
												}
												rahkaranRetailCustomerPartyDefineViewModel.CompanyName = "";
												rahkaranRetailCustomerPartyDefineViewModel.CompanyRegisterationCode = companyById.cmpRegistrationNumber ?? "";
												rahkaranRetailCustomerPartyDefineViewModel.FatherName = cRMspSelectCompanyPersonsByID_Result.prsFatherName ?? "";
												rahkaranRetailCustomerPartyDefineViewModel.FidaRegistration = "";
												rahkaranRetailCustomerPartyDefineViewModel.FirstName = cRMspSelectCompanyPersonsByID_Result.prsFName;
												rahkaranRetailCustomerPartyDefineViewModel.LastName = cRMspSelectCompanyPersonsByID_Result.prsLName;
												rahkaranRetailCustomerPartyDefineViewModel.Mobile = cRMspSelectCompanyPersonsByID_Result.prsMobile ?? "";
												rahkaranRetailCustomerPartyDefineViewModel.NationalID = cRMspSelectCompanyPersonsByID_Result.prsNationalCode ?? "";
												rahkaranRetailCustomerPartyDefineViewModel.Type = 0;
											}
										}
										obj.Addresss.Add(rahkaranRetailCustomerAddressDefineViewModel);
										obj.Party = rahkaranRetailCustomerPartyDefineViewModel;
										string text4 = text3 + "Sales/PartyManagement/Services/PartyManagementService.svc/PlaceCustomer";
										string text5 = JsonConvert.SerializeObject(obj);
										text5 = text5.Replace("\\\\/Date(", "\\/Date(").Replace(")\\\\/", ")\\/");
										HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text4);
										((NameValueCollection)((WebRequest)val).Headers).Add("Cookie", text2);
										((WebRequest)val).ContentType = "application/json; charset=utf-8";
										((WebRequest)val).Method = "POST";
										val.Accept = "application/json";
										object value4 = ((object)val).GetType().GetProperty("CurrentMethod", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(val);
										value4.GetType().GetField("ContentBodyNotAllowed", BindingFlags.Instance | BindingFlags.NonPublic).SetValue(value4, false);
										using (StreamWriter streamWriter = new StreamWriter(((WebRequest)val).GetRequestStream()))
										{
											streamWriter.Write(text5);
										}
										HttpWebResponse val2 = (HttpWebResponse)((WebRequest)val).GetResponse();
										StreamReader streamReader = new StreamReader(((WebResponse)val2).GetResponseStream());
										if ((int)val2.StatusCode == 200)
										{
											string text6 = streamReader.ReadToEnd();
											if (!string.IsNullOrWhiteSpace(text6))
											{
												text6 = text6.ClearHiddenCharacters();
											}
											if (!string.IsNullOrWhiteSpace(text6))
											{
												RahkaranRetailCustomerResultViewModel rahkaranRetailCustomerResultViewModel = JsonConvert.DeserializeObject<RahkaranRetailCustomerResultViewModel>(text6);
												if (rahkaranRetailCustomerResultViewModel != null)
												{
													int valueOrDefault = rahkaranRetailCustomerResultViewModel.PartyID.GetValueOrDefault();
													string cmpLinkAccCustomerIdStr = rahkaranRetailCustomerResultViewModel.CustomerID.GetValueOrDefault().ToString();
													LkCompanyAndPersonViewModel rahkaranRetailCompanyById2 = GetRahkaranRetailCompanyById(cookieVal, rahkaranRetailCustomerResultViewModel.CustomerID.GetValueOrDefault());
													if (rahkaranRetailCompanyById2 != null)
													{
														if (!string.IsNullOrWhiteSpace(rahkaranRetailCompanyById2.cmpLinkAccCustomerIdStr))
														{
															string cmpLinkAccCode = rahkaranRetailCompanyById2.cmpLinkAccCode;
															CRMLinkSpEntities dbLink = _dbLink;
															int? companyId = cmpId;
															string cmpLinkAccCode2 = cmpLinkAccCode;
															dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, valueOrDefault, cmpLinkAccCode2, null, cmpLinkAccCustomerIdStr, userId, value2, value3, value, registerDatePersian, appType, cmpLinkAccCode, "");
															text = "1|" + cmpLinkAccCode;
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
													text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text6 + ")|";
												}
											}
										}
									}
								}
							}
							else
							{
								text = Messages.msgErrorReceivingToken + "|";
							}
						}
						else
						{
							text = string.Format(Messages.msgErrorIsNotEnteredItem, Labels.OtherSystemsCookie) + "|";
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

	public LkCompanyInfoViewModelObjects GetRahkaranRetailCompanyList(string cookieVal, int fromRec = 0, int recCount = 0, string cmpName = "", string cmpNationalCode = "", string mobileNo = "")
	{
		//IL_0209: Unknown result type (might be due to invalid IL or missing references)
		//IL_0210: Expected O, but got Unknown
		//IL_02af: Unknown result type (might be due to invalid IL or missing references)
		//IL_02b4: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c1: Unknown result type (might be due to invalid IL or missing references)
		//IL_02cb: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
							if (!string.IsNullOrWhiteSpace(cmpName))
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "name=" + cmpName;
							}
							if (!string.IsNullOrWhiteSpace(mobileNo))
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "mobile=" + mobileNo;
							}
							if (!string.IsNullOrWhiteSpace(cmpNationalCode))
							{
								if (!string.IsNullOrWhiteSpace(text3))
								{
									text3 += "&";
								}
								text3 = text3 + "nationalID=" + cmpNationalCode;
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
							string text4 = text2 + "Services/Retail/ESales.svc/customers" + text3;
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
									RahkaranRetailCustomerResponseViewModel rahkaranRetailCustomerResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailCustomerResponseViewModel>(value3);
									if (rahkaranRetailCustomerResponseViewModel != null && rahkaranRetailCustomerResponseViewModel.result != null && Enumerable.Any<RahkaranRetailCustomerInfoViewModel>((IEnumerable<RahkaranRetailCustomerInfoViewModel>)rahkaranRetailCustomerResponseViewModel.result))
									{
										List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
										int num = 1;
										foreach (RahkaranRetailCustomerInfoViewModel item in rahkaranRetailCustomerResponseViewModel.result)
										{
											LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
											lkCompanyAndPersonViewModel.cmpName = item.firstName;
											lkCompanyAndPersonViewModel.cmpLinkAccCode = item.code;
											lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = item.id.GetValueOrDefault().ToString();
											lkCompanyAndPersonViewModel.cmpEconomicCode = item.economicCode;
											lkCompanyAndPersonViewModel.cmpNationalCode = item.nationalCode;
											lkCompanyAndPersonViewModel.cmpTel = item.tel;
											if (item.addresses != null && Enumerable.Any<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)item.addresses))
											{
												RahkaranRetailCustomerAddressInfoViewModel rahkaranRetailCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)item.addresses, (Func<RahkaranRetailCustomerAddressInfoViewModel, bool>)((RahkaranRetailCustomerAddressInfoViewModel m) => m.isDefault.GetValueOrDefault()));
												if (rahkaranRetailCustomerAddressInfoViewModel == null)
												{
													rahkaranRetailCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)item.addresses);
												}
												if (rahkaranRetailCustomerAddressInfoViewModel != null)
												{
													lkCompanyAndPersonViewModel.cmpAddress = rahkaranRetailCustomerAddressInfoViewModel.details;
													lkCompanyAndPersonViewModel.cmpAddressDesc = rahkaranRetailCustomerAddressInfoViewModel.name;
													lkCompanyAndPersonViewModel.cmpTelII = rahkaranRetailCustomerAddressInfoViewModel.phone;
													lkCompanyAndPersonViewModel.cmpFax = rahkaranRetailCustomerAddressInfoViewModel.fax;
													lkCompanyAndPersonViewModel.cmpZipCode = rahkaranRetailCustomerAddressInfoViewModel.zipCode;
													lkCompanyAndPersonViewModel.prsEmail = rahkaranRetailCustomerAddressInfoViewModel.email;
												}
											}
											lkCompanyAndPersonViewModel.cmpKind = 0;
											if (item.partyType.GetValueOrDefault() == 0)
											{
												lkCompanyAndPersonViewModel.cmpKind = 1;
											}
											if (lkCompanyAndPersonViewModel.cmpKind.GetValueOrDefault() == 1)
											{
												lkCompanyAndPersonViewModel.prsFName = item.firstName;
											}
											lkCompanyAndPersonViewModel.prsLName = item.lastName;
											lkCompanyAndPersonViewModel.prsMobile = item.mobile;
											if (item.birthdate.HasValue)
											{
												lkCompanyAndPersonViewModel.prsBirthDateTime = item.birthdate;
												lkCompanyAndPersonViewModel.prsBirthDate = (lkCompanyAndPersonViewModel.prsBirthDateTime.HasValue ? lkCompanyAndPersonViewModel.prsBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
											}
											if (item.marriageDate.HasValue)
											{
												lkCompanyAndPersonViewModel.prsMarriageDateTime = item.marriageDate;
												lkCompanyAndPersonViewModel.prsMarriageDate = (lkCompanyAndPersonViewModel.prsMarriageDateTime.HasValue ? lkCompanyAndPersonViewModel.prsMarriageDateTime.Value.ToString("yyyy/MM/dd") : "");
											}
											lkCompanyAndPersonViewModel.RowNumber = num;
											if (list2 != null)
											{
												CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == item.id.GetValueOrDefault().ToString()));
												if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
												{
													lkCompanyAndPersonViewModel.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
												}
												else
												{
													lkCompanyAndPersonViewModel.CompanyId = 0;
												}
											}
											else
											{
												lkCompanyAndPersonViewModel.CompanyId = 0;
											}
											list.Add(lkCompanyAndPersonViewModel);
											num++;
										}
									}
								}
							}
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCompanyInfoViewModelObjects;
	}

	public LkCompanyInfoViewModelObjects GetRahkaranRetailAllCompanyList(string cookieVal)
	{
		//IL_00fb: Unknown result type (might be due to invalid IL or missing references)
		//IL_0102: Expected O, but got Unknown
		//IL_01a1: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01b3: Unknown result type (might be due to invalid IL or missing references)
		//IL_01bd: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
							string text3 = text2 + "Sales/PartyManagement/Services/PartyManagementService.svc/GetCustomers";
							string value = "";
							HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text3);
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
									List<RahkaranRetailAllCustomerInfoViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranRetailAllCustomerInfoViewModel>>(value3);
									if (list2 != null && Enumerable.Any<RahkaranRetailAllCustomerInfoViewModel>((IEnumerable<RahkaranRetailAllCustomerInfoViewModel>)list2))
									{
										List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
										int num = 1;
										foreach (RahkaranRetailAllCustomerInfoViewModel item in list2)
										{
											LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
											vm.cmpName = item.partyName;
											vm.cmpLinkAccCode = item.number;
											vm.cmpLinkAccCustomerIdStr = item.id;
											vm.RowNumber = num;
											if (list3 != null)
											{
												CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
												if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
												{
													vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
												}
												else
												{
													vm.CompanyId = 0;
												}
											}
											else
											{
												vm.CompanyId = 0;
											}
											list.Add(vm);
											num++;
										}
									}
								}
							}
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCompanyInfoViewModelObjects;
	}

	public LkCompanyAndPersonViewModel GetRahkaranRetailCompanyById(string cookieVal, long customerId = 0L)
	{
		//IL_00e3: Unknown result type (might be due to invalid IL or missing references)
		//IL_00ea: Expected O, but got Unknown
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_018d: Unknown result type (might be due to invalid IL or missing references)
		//IL_019a: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a4: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = new LkCompanyAndPersonViewModel();
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
							string text3 = text2 + "Services/Retail/ESales.svc/customer?id=" + customerId;
							string value = "";
							HttpWebRequest val = (HttpWebRequest)WebRequest.Create(text3);
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
									RahkaranRetailOneCustomerResponseViewModel rahkaranRetailOneCustomerResponseViewModel = JsonConvert.DeserializeObject<RahkaranRetailOneCustomerResponseViewModel>(value3);
									if (rahkaranRetailOneCustomerResponseViewModel != null && rahkaranRetailOneCustomerResponseViewModel.result != null)
									{
										RahkaranRetailCustomerInfoViewModel result2 = rahkaranRetailOneCustomerResponseViewModel.result;
										if (result2 != null)
										{
											lkCompanyAndPersonViewModel.cmpName = result2.firstName;
											lkCompanyAndPersonViewModel.cmpLinkAccCode = result2.code;
											lkCompanyAndPersonViewModel.cmpLinkAccCustomerIdStr = result2.id.GetValueOrDefault().ToString();
											lkCompanyAndPersonViewModel.cmpEconomicCode = result2.economicCode;
											lkCompanyAndPersonViewModel.cmpNationalCode = result2.nationalCode;
											lkCompanyAndPersonViewModel.cmpTel = result2.tel;
											if (result2.addresses != null && Enumerable.Any<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)result2.addresses))
											{
												RahkaranRetailCustomerAddressInfoViewModel rahkaranRetailCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)result2.addresses, (Func<RahkaranRetailCustomerAddressInfoViewModel, bool>)((RahkaranRetailCustomerAddressInfoViewModel m) => m.isDefault.GetValueOrDefault()));
												if (rahkaranRetailCustomerAddressInfoViewModel == null)
												{
													rahkaranRetailCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranRetailCustomerAddressInfoViewModel>((IEnumerable<RahkaranRetailCustomerAddressInfoViewModel>)result2.addresses);
												}
												if (rahkaranRetailCustomerAddressInfoViewModel != null)
												{
													lkCompanyAndPersonViewModel.cmpAddress = rahkaranRetailCustomerAddressInfoViewModel.details;
													lkCompanyAndPersonViewModel.cmpAddressDesc = rahkaranRetailCustomerAddressInfoViewModel.name;
													lkCompanyAndPersonViewModel.cmpTelII = rahkaranRetailCustomerAddressInfoViewModel.phone;
													lkCompanyAndPersonViewModel.cmpFax = rahkaranRetailCustomerAddressInfoViewModel.fax;
													lkCompanyAndPersonViewModel.cmpZipCode = rahkaranRetailCustomerAddressInfoViewModel.zipCode;
													lkCompanyAndPersonViewModel.prsEmail = rahkaranRetailCustomerAddressInfoViewModel.email;
												}
											}
											lkCompanyAndPersonViewModel.cmpKind = 0;
											if (result2.partyType.GetValueOrDefault() == 0)
											{
												lkCompanyAndPersonViewModel.cmpKind = 1;
											}
											if (lkCompanyAndPersonViewModel.cmpKind.GetValueOrDefault() == 1)
											{
												lkCompanyAndPersonViewModel.prsFName = result2.firstName;
											}
											lkCompanyAndPersonViewModel.prsLName = result2.lastName;
											lkCompanyAndPersonViewModel.prsMobile = result2.mobile;
											if (result2.birthdate.HasValue)
											{
												lkCompanyAndPersonViewModel.prsBirthDateTime = result2.birthdate;
												lkCompanyAndPersonViewModel.prsBirthDate = (lkCompanyAndPersonViewModel.prsBirthDateTime.HasValue ? lkCompanyAndPersonViewModel.prsBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
											}
											if (result2.marriageDate.HasValue)
											{
												lkCompanyAndPersonViewModel.prsMarriageDateTime = result2.marriageDate;
												lkCompanyAndPersonViewModel.prsMarriageDate = (lkCompanyAndPersonViewModel.prsMarriageDateTime.HasValue ? lkCompanyAndPersonViewModel.prsMarriageDateTime.Value.ToString("yyyy/MM/dd") : "");
											}
										}
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
		return lkCompanyAndPersonViewModel;
	}

	public LkCompanyInfoViewModelObjects GetNilramCompanyList(string fromDate = "", string toDate = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
					try
					{
						DateTime now = DateTime.Now;
						DateTime now2 = DateTime.Now;
						if (!string.IsNullOrWhiteSpace(fromDate))
						{
							fromDate = fromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text2 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(fromDate) + " 00:00:00", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
						if (!string.IsNullOrEmpty(toDate))
						{
							toDate = toDate.Replace("/", "").Replace("-", "").Replace("\\", "")
								.Replace(" ", "")
								.Replace("_", "");
							text3 = (lCID switch
							{
								1065 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59"), 
								1025 => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("ar-SA"), DateTimeStyles.None), 
								_ => DateTime.Parse(PersianDate.GetFormatetdDate(toDate) + " 23:59:59", new CultureInfo("en-US"), DateTimeStyles.None), 
							}).ToString("yyyy-MM-dd", new PersianCulture());
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					HttpClient httpClient = new HttpClient();
					string text4 = text + "MSTK_CUSTOMERS/" + text2 + "/" + text3;
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
							List<NilramCustomerInfoViewModel> list2 = JsonConvert.DeserializeObject<List<NilramCustomerInfoViewModel>>(value2);
							if (list2 != null && Enumerable.Any<NilramCustomerInfoViewModel>((IEnumerable<NilramCustomerInfoViewModel>)list2))
							{
								List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
								int num = 1;
								foreach (NilramCustomerInfoViewModel item in list2)
								{
									LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
									vm.cmpName = item.cust_name;
									vm.cmpLinkAccCode = item.custcode.GetValueOrDefault().ToString();
									vm.cmpLinkAccCustomerIdStr = item.custcode.GetValueOrDefault().ToString();
									vm.cmpEconomicCode = item.CODE_EGHTESADI;
									vm.cmpAddress = item.ADDRS;
									vm.cmpPreTel = item.pre_tel1;
									vm.cmpTel = item.tel1;
									vm.cmpPreTelII = item.pre_tel2;
									vm.cmpTelII = item.tel2;
									vm.cmpZipCode = item.DELADDRS;
									vm.cmpNationalCode = item.REG_NO;
									if (!string.IsNullOrWhiteSpace(item.PRSL_BAZARYAB))
									{
										vm.cmpReferLinkAccUserIdStr = item.PRSL_BAZARYAB;
										vm.cmpReferLinkAccUserCode = item.PRSL_BAZARYAB;
										vm.cmpReferLName = item.PRSL_BAZARYAB;
									}
									if (!string.IsNullOrWhiteSpace(item.PRSL_KARSHENAS))
									{
										vm.cmpSuppUserLinkAccUserIdStr = item.PRSL_KARSHENAS;
										vm.cmpSuppUserLinkAccUserCode = item.PRSL_KARSHENAS;
										vm.cmpSuppUserLName = item.PRSL_KARSHENAS;
									}
									vm.cmpKind = 0;
									int result3 = 0;
									int.TryParse(item.CUST_KIND.ToString(), out result3);
									if (result3 == 2 || result3 == 3)
									{
										vm.cmpKind = 0;
										vm.TspCmpTob = 2;
									}
									else
									{
										vm.cmpKind = 1;
										vm.TspCmpTob = 1;
										switch (result3)
										{
										case 4:
											vm.TspCmpTob = 4;
											break;
										case 5:
											vm.TspCmpTob = 3;
											break;
										}
									}
									vm.prsLName = item.cust_name;
									vm.prsMobile = item.MOBILE;
									if (!string.IsNullOrWhiteSpace(item.BIRTH_DATE))
									{
										switch (lCID)
										{
										case 1065:
										{
											DateTime dateTime4 = DateTime.Parse(item.BIRTH_DATE, new CultureInfo("en-US"));
											LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel3 = vm;
											DateTime dateTime2 = dateTime4;
											lkCompanyAndPersonViewModel3.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
											vm.prsBirthDateTime = dateTime4;
											break;
										}
										case 1025:
										{
											DateTime dateTime3 = DateTime.Parse(item.BIRTH_DATE, new CultureInfo("en-US"));
											LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel2 = vm;
											DateTime dateTime2 = dateTime3;
											lkCompanyAndPersonViewModel2.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
											vm.prsBirthDateTime = dateTime3;
											break;
										}
										default:
										{
											DateTime dateTime = DateTime.Parse(item.BIRTH_DATE, new CultureInfo("en-US"));
											LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = vm;
											DateTime dateTime2 = dateTime;
											lkCompanyAndPersonViewModel.prsBirthDate = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
											vm.prsBirthDateTime = dateTime;
											break;
										}
										}
									}
									vm.RowNumber = num;
									if (list3 != null)
									{
										CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
										if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
										{
											vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
										}
										else
										{
											vm.CompanyId = 0;
										}
									}
									else
									{
										vm.CompanyId = 0;
									}
									list.Add(vm);
									num++;
								}
							}
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkCompanyInfoViewModelObjects;
	}

	[AjaxOnly]
	public string NilramActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				try
				{
					string nilram = Labels.Nilram;
					DateTime now = DateTime.Now;
					DateTime value = now;
					string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
					short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
					string appType = Configuration.AppType;
					short value3 = short.Parse(Financial.Get().Id.ToString());
					int userId = UserLogin.CurrentUser.UserId;
					string text2 = value.ToString("yyyy-MM-dd", new PersianCulture());
					new LinkAccNoAvCapillarySettingController();
					CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
					if (companyById != null)
					{
						CRMIdeal.Classes.Helper.OtherSystems.NilramSettingViewModel nilramSetting = CRMIdeal.Classes.Helper.OtherSystems.GetNilramSetting();
						if (nilramSetting != null)
						{
							string text3 = nilramSetting.ApiAddress ?? "";
							string value4 = nilramSetting.ApiToken ?? "";
							if (!string.IsNullOrWhiteSpace(text3) && !string.IsNullOrWhiteSpace(value4))
							{
								if (!text3.EndsWith("/"))
								{
									text3 += "/";
								}
								if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
								{
									return string.Format(Messages.msgErrorOtherSystemsAlreadyTransferred, Labels.OtherSystemsCompany, nilram) + "|";
								}
								string p_ID = "1";
								string text4 = "";
								int result2 = 0;
								int.TryParse(companyById.cmpGroupId.ToString(), out result2);
								if (result2 == 0)
								{
									text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpGroupId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), nilram, Labels.cmpGroupId, companyById.cmpGroup ?? "") + "|";
									return text;
								}
								text4 = companyById.LinkAccGroupIdStr;
								string text5 = "";
								int result3 = 0;
								int.TryParse(companyById.cmpGroupIdIII.ToString(), out result3);
								if (result3 == 0)
								{
									text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpGroupIdIII, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(companyById.LinkAccGroupIIIIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), nilram, Labels.cmpGroupIdIII, companyById.cmpGroupIII ?? "") + "|";
									return text;
								}
								text5 = companyById.LinkAccGroupIIIIdStr;
								string text6 = "";
								int result4 = 0;
								int.TryParse(companyById.cmpCountryId.ToString(), out result4);
								if (result4 == 0)
								{
									text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpCountryId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(companyById.LinkAccCountryIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), nilram, Labels.cmpCountryId, companyById.cmpCountry ?? "") + "|";
									return text;
								}
								text6 = companyById.LinkAccCountryIdStr;
								string text7 = "";
								int result5 = 0;
								int.TryParse(companyById.cmpProvinceId.ToString(), out result5);
								if (result5 == 0)
								{
									text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpProvinceId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(companyById.LinkAccProvinceIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), nilram, Labels.cmpProvinceId, companyById.cmpProvince ?? "") + "|";
									return text;
								}
								text7 = companyById.LinkAccProvinceIdStr;
								string text8 = "";
								int result6 = 0;
								int.TryParse(companyById.cmpCityId.ToString(), out result6);
								if (result6 == 0)
								{
									text = string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpCityId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
									return text;
								}
								if (string.IsNullOrWhiteSpace(companyById.LinkAccCityIdStr))
								{
									text = string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), nilram, Labels.cmpCityId, companyById.cmpCity ?? "") + "|";
									return text;
								}
								text8 = companyById.LinkAccCityIdStr;
								NilramCustomerDefineViewModel nilramCustomerDefineViewModel = new NilramCustomerDefineViewModel();
								nilramCustomerDefineViewModel.P_TYP = "I";
								nilramCustomerDefineViewModel.P_ORGAN_STAT = text5;
								nilramCustomerDefineViewModel.P_SALE_CUST_KIND = text4;
								nilramCustomerDefineViewModel.P_COUNTRY = text6;
								nilramCustomerDefineViewModel.P_OSTAN = text7;
								nilramCustomerDefineViewModel.P_CITY = text8;
								nilramCustomerDefineViewModel.P_ADDRS = companyById.cmpAddress ?? "";
								nilramCustomerDefineViewModel.P_TEL1 = companyById.cmpPreTel + companyById.cmpTel;
								if (string.IsNullOrWhiteSpace(nilramCustomerDefineViewModel.P_TEL1))
								{
									nilramCustomerDefineViewModel.P_TEL1 = companyById.cmpPreTelII + companyById.cmpTelII;
								}
								nilramCustomerDefineViewModel.P_TEL1 = nilramCustomerDefineViewModel.P_TEL1 ?? "";
								nilramCustomerDefineViewModel.P_DELADDRS = companyById.cmpZipCode ?? "";
								nilramCustomerDefineViewModel.P_ID = p_ID;
								CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(cmpId, companyById.cmpMainPersonId.GetValueOrDefault());
								if (companyById.cmpKind == 0)
								{
									nilramCustomerDefineViewModel.P_CUST_NAME = ((!string.IsNullOrWhiteSpace(companyById.cmpTitle)) ? (companyById.cmpTitle + " ") : "") + companyById.cmpName;
									nilramCustomerDefineViewModel.P_CUST_KIND = "2";
									nilramCustomerDefineViewModel.P_REG_NO = companyById.cmpNationalCode ?? "";
								}
								else if (companyById.cmpKind.GetValueOrDefault() == 1 && companyPerson != null)
								{
									nilramCustomerDefineViewModel.P_CUST_NAME = ((!string.IsNullOrWhiteSpace(companyPerson.prsTitle)) ? (companyPerson.prsTitle + " ") : "") + ((!string.IsNullOrWhiteSpace(companyPerson.prsFName)) ? (companyPerson.prsFName + " ") : "") + ((!string.IsNullOrWhiteSpace(companyPerson.prsLName)) ? (companyPerson.prsLName ?? "") : "");
									nilramCustomerDefineViewModel.P_REG_NO = companyPerson.prsNationalCode ?? "";
									nilramCustomerDefineViewModel.P_CUST_KIND = "1";
									if (companyById.TspCmpTob.GetValueOrDefault() == 4)
									{
										nilramCustomerDefineViewModel.P_CUST_KIND = "4";
									}
									else if (companyById.TspCmpTob.GetValueOrDefault() == 3)
									{
										nilramCustomerDefineViewModel.P_CUST_KIND = "5";
									}
								}
								HttpClient httpClient = new HttpClient();
								string text9 = text3 + "MSTK_CUSTOMERS/" + text2 + "/" + text2;
								httpClient.BaseAddress = new Uri(text9);
								httpClient.DefaultRequestHeaders.Add("Access-Token", value4);
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								HttpContent content = new StringContent(JsonConvert.SerializeObject(nilramCustomerDefineViewModel), Encoding.UTF8, "application/json");
								HttpResponseMessage result7 = httpClient.PostAsync(text9, content).Result;
								if (result7.IsSuccessStatusCode)
								{
									string text10 = result7.Content.ReadAsStringAsync().Result;
									if (!string.IsNullOrWhiteSpace(text10))
									{
										text10 = text10.ClearHiddenCharacters();
									}
									if (!string.IsNullOrWhiteSpace(text10))
									{
										if (text10.IndexOf("customers", StringComparison.Ordinal) >= 0)
										{
											NilramCustomerDefineResponseViewModel nilramCustomerDefineResponseViewModel = JsonConvert.DeserializeObject<NilramCustomerDefineResponseViewModel>(text10);
											if (nilramCustomerDefineResponseViewModel != null)
											{
												if (nilramCustomerDefineResponseViewModel.customers != null)
												{
													if (Enumerable.Any<NilramCustomerInfoResponseViewModel>((IEnumerable<NilramCustomerInfoResponseViewModel>)nilramCustomerDefineResponseViewModel.customers))
													{
														NilramCustomerInfoResponseViewModel nilramCustomerInfoResponseViewModel = Enumerable.FirstOrDefault<NilramCustomerInfoResponseViewModel>((IEnumerable<NilramCustomerInfoResponseViewModel>)nilramCustomerDefineResponseViewModel.customers);
														if (nilramCustomerInfoResponseViewModel != null)
														{
															string text11 = nilramCustomerInfoResponseViewModel.code ?? "";
															string cmpCode = text11;
															string text12 = text11;
															if (!string.IsNullOrWhiteSpace(text12))
															{
																CRMLinkSpEntities dbLink = _dbLink;
																int? companyId = cmpId;
																string cmpLinkAccCode = text11;
																dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, null, cmpLinkAccCode, null, text12, userId, value2, value3, value, registerDatePersian, appType, cmpCode, "");
																text = "1|" + text11;
															}
															else
															{
																text = text + "<br>" + Messages.msgErrorRunFunction + "|";
															}
														}
														else
														{
															text = text + "<br>" + Messages.msgErrorRunFunction + "|";
														}
													}
													else
													{
														text = text + "<br>" + Messages.msgErrorRunFunction + "|";
													}
												}
												else
												{
													text = text + "<br>" + Messages.msgErrorRunFunction + "|";
												}
											}
											else
											{
												text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text10 + ")|";
											}
										}
										else
										{
											text10 = result7.Content.ReadAsStringAsync().Result;
											if (!string.IsNullOrWhiteSpace(text10))
											{
												text = text + "<br>" + Messages.msgErrorRunFunction + " (" + text10 + ")|";
											}
										}
									}
									else
									{
										text = Messages.errorInReadingSetting + "|";
									}
								}
								else
								{
									string result8 = result7.Content.ReadAsStringAsync().Result;
									if (!string.IsNullOrWhiteSpace(result8))
									{
										text = text + "<br>" + Messages.msgErrorRunFunction + " (" + result8 + ")|";
									}
								}
							}
							else
							{
								text = Messages.errorInReadingSetting + "|";
							}
						}
						else
						{
							text = Messages.errorInReadingSetting + "|";
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
	public string NilramCmpAccountingDetail(int cmpId, ref decimal remainAccount)
	{
		string result = "";
		try
		{
			_ = UserLogin.CurrentUser;
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result cmp = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (cmp != null)
				{
					if (!string.IsNullOrWhiteSpace(cmp.cmpLinkAccCode))
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
								string text2 = DateTime.Now.ToString("yyyy", new PersianCulture());
								string text3 = DateTime.Now.ToString("yyyy-MM-dd", new PersianCulture());
								string text4 = text + "MANDE_HESAB_CUST/" + text2 + "/" + text3 + "/" + cmp.cmpLinkAccCode;
								httpClient.BaseAddress = new Uri(text4);
								httpClient.DefaultRequestHeaders.Add("Access-Token", value);
								httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
								new StringContent("", Encoding.UTF8, "application/json");
								HttpResponseMessage result3 = httpClient.GetAsync(text4).Result;
								if (result3.IsSuccessStatusCode)
								{
									string value2 = result3.Content.ReadAsStringAsync().Result;
									if (!string.IsNullOrWhiteSpace(value2))
									{
										value2 = value2.ClearHiddenCharacters();
									}
									if (!string.IsNullOrWhiteSpace(value2))
									{
										List<NilramCustomerAccRemainInfoViewModel> list = JsonConvert.DeserializeObject<List<NilramCustomerAccRemainInfoViewModel>>(value2);
										if (list != null && Enumerable.Any<NilramCustomerAccRemainInfoViewModel>((IEnumerable<NilramCustomerAccRemainInfoViewModel>)list))
										{
											NilramCustomerAccRemainInfoViewModel nilramCustomerAccRemainInfoViewModel = Enumerable.FirstOrDefault<NilramCustomerAccRemainInfoViewModel>((IEnumerable<NilramCustomerAccRemainInfoViewModel>)list, (Func<NilramCustomerAccRemainInfoViewModel, bool>)((NilramCustomerAccRemainInfoViewModel m) => (m.tafzili ?? "") == cmp.cmpLinkAccCode));
											if (nilramCustomerAccRemainInfoViewModel != null)
											{
												remainAccount = nilramCustomerAccRemainInfoViewModel.bed.GetValueOrDefault();
												result = "";
											}
										}
									}
								}
							}
						}
					}
					else
					{
						Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + cmp.cmpName + " not in Nilram");
						ErrorSignal.FromCurrentContext().Raise(e);
						result = Labels.frmError;
					}
				}
				else
				{
					Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
					ErrorSignal.FromCurrentContext().Raise(e2);
					result = Labels.frmError;
				}
			}
			else
			{
				Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e3);
				result = Labels.frmError;
			}
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			result = Labels.frmError;
		}
		return result;
	}

	public string ImportHamyarCrmCompanyGroups()
	{
		return CRMIdeal.Classes.Helper.OtherSystems.SyncCrmCompanyGroups(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(false).GetAllMahiatFaliatTafsili(getAllCenters: true));
	}

	[AjaxOnly]
	public string RahkaranInternalSalesActCmpSendToAcc(int cmpId, int cmpType = 0, bool isExportCustomer = false, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string rahkaranInternalSales = Labels.RahkaranInternalSales;
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
					long currencyRef = rahkaranInternalSalesProvider.CurrencyRef;
					int addressTypeSendPrd = rahkaranInternalSalesProvider.AddressTypeSendPrd;
					string typeTitle = "ارسال کالا";
					int addressTypeSendOrd = rahkaranInternalSalesProvider.AddressTypeSendOrd;
					string typeTitle2 = "ارسال صورت حساب";
					if (cmpType == 0)
					{
						cmpType = 1;
					}
					long result2 = 0L;
					long result3 = 0L;
					if (companyById.cmpGroupId.GetValueOrDefault() != 0 && !string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr))
					{
						if (companyById.cmpSubGroupId == 0)
						{
							return text + "<br>" + string.Format(Messages.msgErrorIsNotSelectedItem, Labels.cmpSubGroupId) + "|";
						}
						if (string.IsNullOrWhiteSpace(companyById.LinkAccSubGroupIdStr))
						{
							return string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), rahkaranInternalSales, Labels.cmpSubGroupId, companyById.cmpSubGroup ?? "") + "|";
						}
					}
					if (!string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr) && !string.IsNullOrWhiteSpace(companyById.LinkAccSubGroupIdStr) && companyById.cmpGroupId.GetValueOrDefault() != 0 && companyById.cmpSubGroupId != 0)
					{
						long.TryParse(companyById.LinkAccGroupIdStr, out result2);
						if (result2 != 0L)
						{
							long.TryParse(companyById.LinkAccSubGroupIdStr, out result3);
						}
					}
					RahkaranInternalSalesCustomerDefineViewModel rahkaranInternalSalesCustomerDefineViewModel = new RahkaranInternalSalesCustomerDefineViewModel();
					rahkaranInternalSalesCustomerDefineViewModel.Addresses = new List<RahkaranInternalSalesCustomerAddressDefineViewModel>();
					RahkaranInternalSalesCustomerAddressDefineViewModel rahkaranInternalSalesCustomerAddressDefineViewModel = new RahkaranInternalSalesCustomerAddressDefineViewModel();
					RahkaranInternalSalesCustomerAddressDefineViewModel rahkaranInternalSalesCustomerAddressDefineViewModel2 = new RahkaranInternalSalesCustomerAddressDefineViewModel();
					rahkaranInternalSalesCustomerAddressDefineViewModel.Location = new RahkaranInternalSalesCustomerAddressLocationDefineViewModel();
					RahkaranInternalSalesCustomerPartyDefineViewModel rahkaranInternalSalesCustomerPartyDefineViewModel = new RahkaranInternalSalesCustomerPartyDefineViewModel();
					rahkaranInternalSalesCustomerDefineViewModel.CurrencyRef = currencyRef;
					rahkaranInternalSalesCustomerDefineViewModel.DeclarationDate = null;
					rahkaranInternalSalesCustomerDefineViewModel.EconomicCode = companyById.cmpEconomicCode ?? "";
					rahkaranInternalSalesCustomerDefineViewModel.ExchangeCode = "";
					rahkaranInternalSalesCustomerDefineViewModel.IsExportCustomer = isExportCustomer;
					rahkaranInternalSalesCustomerDefineViewModel.Number = "";
					rahkaranInternalSalesCustomerDefineViewModel.Type = cmpType;
					bool isDone = false;
					string text2 = "";
					CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(cmpId, companyById.cmpMainPersonId.GetValueOrDefault());
					if (companyById.cmpKind == 0)
					{
						rahkaranInternalSalesCustomerPartyDefineViewModel.BirthCertificateNumber = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.BirthDate = null;
						rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyName = ((!string.IsNullOrWhiteSpace(companyById.cmpTitle)) ? (companyById.cmpTitle + " ") : "") + companyById.cmpName;
						rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyRegisterationCode = companyById.cmpRegistrationNumber ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FatherName = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FidaRegistration = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FirstName = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.LastName = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.Mobile = companyById.cmpMobile ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.NationalID = companyById.cmpNationalCode ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.Type = 1;
						text2 = companyById.cmpEmail;
						if (companyPerson != null)
						{
							if (string.IsNullOrWhiteSpace(rahkaranInternalSalesCustomerPartyDefineViewModel.Mobile))
							{
								rahkaranInternalSalesCustomerPartyDefineViewModel.Mobile = companyPerson.prsMobile ?? "";
							}
							if (string.IsNullOrWhiteSpace(text2))
							{
								text2 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
							}
						}
					}
					else if (companyById.cmpKind.GetValueOrDefault() == 1 && companyPerson != null)
					{
						rahkaranInternalSalesCustomerPartyDefineViewModel.BirthCertificateNumber = companyPerson.prsIdentityNumber ?? "";
						if (companyPerson.prsBirthDateTime.HasValue)
						{
							string birthDate = "\\/Date(" + ((DateTimeOffset)companyPerson.prsBirthDateTime.Value).ToUnixTimeMilliseconds() + "+0330)\\/";
							rahkaranInternalSalesCustomerPartyDefineViewModel.BirthDate = birthDate;
						}
						rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyName = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyRegisterationCode = companyById.cmpRegistrationNumber ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FatherName = companyPerson.prsFatherName ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FidaRegistration = "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.FirstName = companyPerson.prsFName;
						rahkaranInternalSalesCustomerPartyDefineViewModel.LastName = companyPerson.prsLName;
						rahkaranInternalSalesCustomerPartyDefineViewModel.Mobile = companyPerson.prsMobile ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.NationalID = companyPerson.prsNationalCode ?? "";
						rahkaranInternalSalesCustomerPartyDefineViewModel.Type = 0;
						text2 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
						if (!string.IsNullOrWhiteSpace(companyById.cmpName) && companyById.cmpName != Labels.lblPerson && companyById.cmpName != "شخص")
						{
							rahkaranInternalSalesCustomerPartyDefineViewModel.Alias = companyById.cmpName;
						}
					}
					if (!string.IsNullOrWhiteSpace(companyById.cmpAddress))
					{
						rahkaranInternalSalesCustomerAddressDefineViewModel.Details = ((!string.IsNullOrWhiteSpace(companyById.cmpAddress)) ? (companyById.cmpAddress ?? "") : "");
						rahkaranInternalSalesCustomerAddressDefineViewModel.Tel = companyById.cmpPreTel + companyById.cmpTel;
						if (string.IsNullOrWhiteSpace(rahkaranInternalSalesCustomerAddressDefineViewModel.Tel))
						{
							rahkaranInternalSalesCustomerAddressDefineViewModel.Tel = companyById.cmpPreTelII + companyById.cmpTelII;
						}
						rahkaranInternalSalesCustomerAddressDefineViewModel.Tel = rahkaranInternalSalesCustomerAddressDefineViewModel.Tel ?? "";
						rahkaranInternalSalesCustomerAddressDefineViewModel.Fax = companyById.cmpFax ?? "";
						rahkaranInternalSalesCustomerAddressDefineViewModel.IsDefault = true;
						if (!string.IsNullOrWhiteSpace(companyById.cmpCoordinateLatitude) && !string.IsNullOrWhiteSpace(companyById.cmpCoordinateLongitude))
						{
							rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Latitude = companyById.cmpCoordinateLatitude;
							rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Longitude = companyById.cmpCoordinateLongitude;
						}
						rahkaranInternalSalesCustomerAddressDefineViewModel.Email = text2 ?? "";
						rahkaranInternalSalesCustomerAddressDefineViewModel.Name = "اصلی";
						rahkaranInternalSalesCustomerAddressDefineViewModel.ZipCode = companyById.cmpZipCode ?? "";
						long result4 = 0L;
						long.TryParse(companyById.LinkAccCityIdStr, out result4);
						rahkaranInternalSalesCustomerAddressDefineViewModel.RegionalDivisionRef = ((result4 != 0L) ? new long?(result4) : null);
						rahkaranInternalSalesCustomerAddressDefineViewModel.Type = addressTypeSendPrd;
						rahkaranInternalSalesCustomerAddressDefineViewModel.TypeTitle = typeTitle;
						rahkaranInternalSalesCustomerDefineViewModel.Addresses.Add(rahkaranInternalSalesCustomerAddressDefineViewModel);
						rahkaranInternalSalesCustomerAddressDefineViewModel2 = new RahkaranInternalSalesCustomerAddressDefineViewModel
						{
							Details = rahkaranInternalSalesCustomerAddressDefineViewModel.Details,
							Tel = rahkaranInternalSalesCustomerAddressDefineViewModel.Tel,
							Fax = rahkaranInternalSalesCustomerAddressDefineViewModel.Fax,
							IsDefault = false,
							Location = rahkaranInternalSalesCustomerAddressDefineViewModel.Location,
							Email = rahkaranInternalSalesCustomerAddressDefineViewModel.Email,
							Name = rahkaranInternalSalesCustomerAddressDefineViewModel.Name,
							ZipCode = rahkaranInternalSalesCustomerAddressDefineViewModel.ZipCode,
							RegionalDivisionRef = rahkaranInternalSalesCustomerAddressDefineViewModel.RegionalDivisionRef,
							Type = addressTypeSendOrd,
							TypeTitle = typeTitle2
						};
						rahkaranInternalSalesCustomerDefineViewModel.Addresses.Add(rahkaranInternalSalesCustomerAddressDefineViewModel2);
					}
					rahkaranInternalSalesCustomerDefineViewModel.Party = rahkaranInternalSalesCustomerPartyDefineViewModel;
					if (string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						string text3 = rahkaranInternalSalesProvider.SendCompany(rahkaranInternalSalesCustomerDefineViewModel, ref isDone);
						if (!string.IsNullOrWhiteSpace(text3))
						{
							text3 = text3.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text3) && isDone)
						{
							RahkaranInternalSalesCustomerResultViewModel rahkaranInternalSalesCustomerResultViewModel = JsonConvert.DeserializeObject<RahkaranInternalSalesCustomerResultViewModel>(text3);
							if (rahkaranInternalSalesCustomerResultViewModel != null)
							{
								int valueOrDefault = rahkaranInternalSalesCustomerResultViewModel.PartyID.GetValueOrDefault();
								string cmpLinkAccCustomerIdStr = rahkaranInternalSalesCustomerResultViewModel.CustomerID.GetValueOrDefault().ToString();
								LkCompanyAndPersonViewModel rahkaranInternalSalesCompanyById = GetRahkaranInternalSalesCompanyById(rahkaranInternalSalesCustomerResultViewModel.CustomerID.GetValueOrDefault());
								if (rahkaranInternalSalesCompanyById != null)
								{
									if (!string.IsNullOrWhiteSpace(rahkaranInternalSalesCompanyById.cmpLinkAccCustomerIdStr))
									{
										string cmpLinkAccCode = rahkaranInternalSalesCompanyById.cmpLinkAccCode;
										string cmpCode = rahkaranInternalSalesCompanyById.cmpCode;
										CRMLinkSpEntities dbLink = _dbLink;
										int? companyId = cmpId;
										string cmpLinkAccCode2 = cmpLinkAccCode;
										dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, valueOrDefault, cmpLinkAccCode2, null, cmpLinkAccCustomerIdStr, userId, value2, value3, value, registerDatePersian, appType, cmpCode, "");
										if (result2 != 0L && result3 != 0L)
										{
											string text4 = rahkaranInternalSalesProvider.SetCompanyGroup(rahkaranInternalSalesCustomerResultViewModel.CustomerID.GetValueOrDefault(), result2, result3);
											if (!string.IsNullOrWhiteSpace(text4))
											{
												return string.Format(Messages.msgErrorSendCmpToAccLinkWithError, companyById.CompanyName ?? "", rahkaranInternalSales, Labels.cmpGroupId) + "<br>" + text4 + "|";
											}
										}
										return "1|" + cmpLinkAccCode;
									}
									return text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
								}
								return text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
							}
							return text + "<br>" + Messages.msgErrorRunFunction + " (" + text3 + ")|";
						}
						return text + "<br>" + Messages.msgErrorRunFunction + " (" + text3 + ")|";
					}
					long result5 = 0L;
					long.TryParse(companyById.cmpLinkAccCustomerIdStr, out result5);
					long result6 = 0L;
					long.TryParse(companyById.cmpLinkAccCodeId.GetValueOrDefault().ToString(), out result6);
					LkCompanyAndPersonViewModel rahkaranInternalSalesCompanyById2 = GetRahkaranInternalSalesCompanyById(result5);
					if (rahkaranInternalSalesCompanyById2 != null)
					{
						RahkaranInternalSalesCustomerEditViewModel rahkaranInternalSalesCustomerEditViewModel = new RahkaranInternalSalesCustomerEditViewModel();
						rahkaranInternalSalesCustomerEditViewModel.Addresses = new List<RahkaranInternalSalesCustomerAddressEditViewModel>();
						RahkaranInternalSalesCustomerAddressEditViewModel rahkaranInternalSalesCustomerAddressEditViewModel = new RahkaranInternalSalesCustomerAddressEditViewModel();
						RahkaranInternalSalesCustomerAddressEditViewModel rahkaranInternalSalesCustomerAddressEditViewModel2 = new RahkaranInternalSalesCustomerAddressEditViewModel();
						RahkaranInternalSalesCustomerPartyEditViewModel rahkaranInternalSalesCustomerPartyEditViewModel = new RahkaranInternalSalesCustomerPartyEditViewModel();
						string addressIds = rahkaranInternalSalesCompanyById2.AddressIds;
						bool flag = true;
						if (!string.IsNullOrWhiteSpace(addressIds))
						{
							string[] array = addressIds.Split(new char[1] { ',' });
							if (array != null && array.Length != 0)
							{
								flag = false;
								foreach (string text5 in array)
								{
									if (string.IsNullOrWhiteSpace(text5))
									{
										continue;
									}
									string[] array2 = text5.Split(new char[1] { '|' });
									if (array2 != null && array2.Length > 1)
									{
										string s = array2[0];
										string s2 = array2[1];
										long result7 = 0L;
										long.TryParse(s, out result7);
										int result8 = 0;
										int.TryParse(s2, out result8);
										if (result7 != 0L)
										{
											rahkaranInternalSalesCustomerAddressEditViewModel.AddressRef = result7;
											rahkaranInternalSalesCustomerAddressEditViewModel.Details = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Details ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Tel = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Tel ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Fax = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Fax ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Email = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Email ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Latitude = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Latitude ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Longitude = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Longitude ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Name = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Name ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.ZipCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
											{
												Action = 1,
												NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.ZipCode ?? ""),
												OldValue = ""
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.CityRef = new RahkaranInternalSalesCustomerActionEditViewModel<long>
											{
												Action = 1,
												NewValue = rahkaranInternalSalesCustomerAddressDefineViewModel.RegionalDivisionRef.GetValueOrDefault(),
												OldValue = 0L
											};
											rahkaranInternalSalesCustomerAddressEditViewModel.Type = new RahkaranInternalSalesCustomerActionEditViewModel<int>
											{
												Action = 1,
												NewValue = result8,
												OldValue = 0
											};
											rahkaranInternalSalesCustomerEditViewModel.Addresses.Add(rahkaranInternalSalesCustomerAddressEditViewModel);
											flag = false;
										}
									}
								}
							}
						}
						if (flag && !string.IsNullOrWhiteSpace(companyById.cmpAddress))
						{
							rahkaranInternalSalesCustomerAddressEditViewModel.AddressRef = 0L;
							rahkaranInternalSalesCustomerAddressEditViewModel.Details = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Details ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Tel = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Tel ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Fax = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Fax ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Email = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Email ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Latitude = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Latitude ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Longitude = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Location.Longitude ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Name = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.Name ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.ZipCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerAddressDefineViewModel.ZipCode ?? ""),
								OldValue = ""
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.CityRef = new RahkaranInternalSalesCustomerActionEditViewModel<long>
							{
								Action = 1,
								NewValue = rahkaranInternalSalesCustomerAddressDefineViewModel.RegionalDivisionRef.GetValueOrDefault(),
								OldValue = 0L
							};
							rahkaranInternalSalesCustomerAddressEditViewModel.Type = new RahkaranInternalSalesCustomerActionEditViewModel<int>
							{
								Action = 1,
								NewValue = addressTypeSendPrd,
								OldValue = 0
							};
							rahkaranInternalSalesCustomerEditViewModel.Addresses.Add(rahkaranInternalSalesCustomerAddressEditViewModel);
							rahkaranInternalSalesCustomerAddressEditViewModel2 = new RahkaranInternalSalesCustomerAddressEditViewModel
							{
								AddressRef = rahkaranInternalSalesCustomerAddressEditViewModel.AddressRef,
								Details = rahkaranInternalSalesCustomerAddressEditViewModel.Details,
								Tel = rahkaranInternalSalesCustomerAddressEditViewModel.Tel,
								Fax = rahkaranInternalSalesCustomerAddressEditViewModel.Fax,
								Email = rahkaranInternalSalesCustomerAddressEditViewModel.Email,
								Latitude = rahkaranInternalSalesCustomerAddressEditViewModel.Latitude,
								Longitude = rahkaranInternalSalesCustomerAddressEditViewModel.Longitude,
								Name = rahkaranInternalSalesCustomerAddressEditViewModel.Name,
								ZipCode = rahkaranInternalSalesCustomerAddressEditViewModel.ZipCode,
								CityRef = rahkaranInternalSalesCustomerAddressEditViewModel.CityRef,
								Type = new RahkaranInternalSalesCustomerActionEditViewModel<int>
								{
									Action = 1,
									NewValue = addressTypeSendOrd,
									OldValue = 0
								}
							};
							rahkaranInternalSalesCustomerEditViewModel.Addresses.Add(rahkaranInternalSalesCustomerAddressEditViewModel2);
						}
						rahkaranInternalSalesCustomerEditViewModel.ID = result5;
						rahkaranInternalSalesCustomerEditViewModel.CurrencyRef = new RahkaranInternalSalesCustomerActionEditViewModel<long>
						{
							Action = 1,
							NewValue = rahkaranInternalSalesCustomerDefineViewModel.CurrencyRef,
							OldValue = 0L
						};
						rahkaranInternalSalesCustomerEditViewModel.EconomicCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerDefineViewModel.EconomicCode ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerEditViewModel.ExchangeCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerDefineViewModel.ExchangeCode ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerEditViewModel.IsExportCustomer = new RahkaranInternalSalesCustomerActionEditViewModel<bool>
						{
							Action = 1,
							NewValue = rahkaranInternalSalesCustomerDefineViewModel.IsExportCustomer,
							OldValue = false
						};
						rahkaranInternalSalesCustomerEditViewModel.Type = new RahkaranInternalSalesCustomerActionEditViewModel<int>
						{
							Action = 1,
							NewValue = rahkaranInternalSalesCustomerDefineViewModel.Type,
							OldValue = 0
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.ID = result6;
						rahkaranInternalSalesCustomerPartyEditViewModel.BirthCertificateNumber = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.BirthCertificateNumber ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.BirthDate = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = rahkaranInternalSalesCustomerPartyDefineViewModel.BirthDate,
							OldValue = null
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.CompanyName = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyName ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.CompanyRegisterationCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.CompanyRegisterationCode ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.EconomicCode = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerDefineViewModel.EconomicCode ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.FatherName = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.FatherName ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.FidaRegistration = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.FidaRegistration ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.FirstName = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.FirstName ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.LastName = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.LastName ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.Mobile = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.Mobile ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.NationalID = new RahkaranInternalSalesCustomerActionEditViewModel<string>
						{
							Action = 1,
							NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.NationalID ?? ""),
							OldValue = ""
						};
						rahkaranInternalSalesCustomerPartyEditViewModel.Type = new RahkaranInternalSalesCustomerActionEditViewModel<int>
						{
							Action = 1,
							NewValue = rahkaranInternalSalesCustomerPartyDefineViewModel.Type,
							OldValue = 0
						};
						if (!string.IsNullOrWhiteSpace(rahkaranInternalSalesCustomerPartyDefineViewModel.Alias) && companyById.cmpKind.GetValueOrDefault() == 1)
						{
							rahkaranInternalSalesCustomerPartyEditViewModel.Alias = new RahkaranInternalSalesCustomerActionEditViewModel<string>
							{
								Action = 1,
								NewValue = (rahkaranInternalSalesCustomerPartyDefineViewModel.Alias ?? ""),
								OldValue = ""
							};
						}
						string text6 = rahkaranInternalSalesProvider.SendCompany(rahkaranInternalSalesCustomerDefineViewModel, ref isDone, isEdit: true, rahkaranInternalSalesCustomerEditViewModel, rahkaranInternalSalesCustomerPartyEditViewModel);
						if (!string.IsNullOrWhiteSpace(text6))
						{
							text6 = text6.ClearHiddenCharacters();
						}
						if (!string.IsNullOrWhiteSpace(text6) && isDone)
						{
							if (text6 == "true")
							{
								if (!string.IsNullOrWhiteSpace(rahkaranInternalSalesCompanyById2.cmpLinkAccCustomerIdStr))
								{
									string cmpLinkAccCode3 = rahkaranInternalSalesCompanyById2.cmpLinkAccCode;
									_ = rahkaranInternalSalesCompanyById2.cmpCode;
									_dbLink.CRMspUpdateCompanyWithAccLinkField(cmpId, cmpLinkAccCode: companyById.cmpLinkAccCode, cmpLinkAccCodeId: companyById.cmpLinkAccCodeId, cmpLinkAccCustomerId: null, cmpLinkAccCustomerIdStr: companyById.cmpLinkAccCustomerIdStr, userId: userId, month1: value2, year1: value3, registerDate: value, registerDatePersian: registerDatePersian, appType: appType, cmpCode: companyById.cmpCode, cmpLinkAccData: "");
									if (result2 != 0L && result3 != 0L)
									{
										string text7 = rahkaranInternalSalesProvider.SetCompanyGroup(result5, result2, result3);
										if (!string.IsNullOrWhiteSpace(text7))
										{
											return string.Format(Messages.msgErrorSendCmpToAccLinkWithError, companyById.CompanyName ?? "", rahkaranInternalSales, Labels.cmpGroupId) + "<br>" + text7 + "|";
										}
									}
									return "1|" + cmpLinkAccCode3;
								}
								return text + "<br>" + Messages.msgErrorCommunicateWithServer + "|";
							}
							return text + "<br>" + Messages.msgErrorRunFunction + " (" + text6 + ")|";
						}
						return text + "<br>" + Messages.msgErrorRunFunction + " (" + text6 + ")|";
					}
					return Messages.ErrorNotFound + "(" + Labels.RahkaranInternalSales + ")|";
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

	public LkCompanyInfoViewModelObjects GetRahkaranInternalSalesCompanyList(string fromDate = "", string toDate = "", long cmpId = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
			CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
			string value = rahkaranInternalSalesProvider.GetCompanyList(fromDate2, toDate2, cmpId);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					int addressTypeSendPrd = rahkaranInternalSalesProvider.AddressTypeSendPrd;
					int addressTypeSendOrd = rahkaranInternalSalesProvider.AddressTypeSendOrd;
					List<RahkaranInternalSalesCustomerResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RahkaranInternalSalesCustomerResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RahkaranInternalSalesCustomerResponseViewModel>((IEnumerable<RahkaranInternalSalesCustomerResponseViewModel>)list2))
					{
						List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
						int num = 1;
						foreach (RahkaranInternalSalesCustomerResponseViewModel item in list2)
						{
							LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
							vm.cmpLinkAccCustomerIdStr = item.ID.GetValueOrDefault().ToString();
							vm.cmpName = item.CompanyName;
							vm.cmpLinkAccCode = item.Number;
							vm.cmpCode = item.DLCode ?? "";
							vm.cmpEconomicCode = item.EconomicCode;
							vm.cmpNationalCode = item.NationalID;
							vm.cmpRegistrationNumber = item.RegistrationCode;
							vm.cmpTel = item.Tel;
							vm.cmpWebSite = item.WebsiteUrl;
							if (item.PartyRef.GetValueOrDefault() != 0L)
							{
								vm.cmpLinkAccCodeId = int.Parse(item.PartyRef.GetValueOrDefault().ToString());
								if (vm.cmpLinkAccCodeId == 0)
								{
									vm.cmpLinkAccCodeId = null;
								}
							}
							RahkaranInternalSalesBrokerResponseViewModel customerBrokers = rahkaranInternalSalesProvider.GetCustomerBrokers(item.ID.GetValueOrDefault());
							if (customerBrokers != null && customerBrokers.RelatedEntityRef.GetValueOrDefault() != 0L)
							{
								vm.cmpReferLinkAccUserCode = customerBrokers.RelatedEntityCode;
								vm.cmpReferLinkAccUserIdStr = customerBrokers.RelatedEntityRef.GetValueOrDefault().ToString();
								vm.cmpReferLName = customerBrokers.RelatedEntityName;
							}
							if (item.Addresses != null && Enumerable.Any<RahkaranInternalSalesCustomerAddressInfoViewModel>((IEnumerable<RahkaranInternalSalesCustomerAddressInfoViewModel>)item.Addresses))
							{
								RahkaranInternalSalesCustomerAddressInfoViewModel rahkaranInternalSalesCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesCustomerAddressInfoViewModel>((IEnumerable<RahkaranInternalSalesCustomerAddressInfoViewModel>)item.Addresses, (Func<RahkaranInternalSalesCustomerAddressInfoViewModel, bool>)((RahkaranInternalSalesCustomerAddressInfoViewModel m) => m.IsDefault.GetValueOrDefault()));
								if (rahkaranInternalSalesCustomerAddressInfoViewModel == null)
								{
									rahkaranInternalSalesCustomerAddressInfoViewModel = Enumerable.FirstOrDefault<RahkaranInternalSalesCustomerAddressInfoViewModel>((IEnumerable<RahkaranInternalSalesCustomerAddressInfoViewModel>)item.Addresses);
								}
								if (rahkaranInternalSalesCustomerAddressInfoViewModel != null)
								{
									vm.cmpAddress = rahkaranInternalSalesCustomerAddressInfoViewModel.Details;
									vm.cmpAddressDesc = rahkaranInternalSalesCustomerAddressInfoViewModel.Name;
									vm.cmpTelII = rahkaranInternalSalesCustomerAddressInfoViewModel.Tel;
									vm.cmpFax = rahkaranInternalSalesCustomerAddressInfoViewModel.Fax;
									vm.cmpZipCode = rahkaranInternalSalesCustomerAddressInfoViewModel.ZipCode;
									vm.prsEmail = rahkaranInternalSalesCustomerAddressInfoViewModel.Email;
									if (rahkaranInternalSalesCustomerAddressInfoViewModel.RegionalDivisionRef.GetValueOrDefault() != 0L)
									{
										vm.LinkAccCityIdStr = rahkaranInternalSalesCustomerAddressInfoViewModel.RegionalDivisionRef.GetValueOrDefault().ToString();
									}
								}
								vm.AddressIds = "";
								foreach (RahkaranInternalSalesCustomerAddressInfoViewModel address in item.Addresses)
								{
									long result2 = 0L;
									long.TryParse(address.ID.GetValueOrDefault().ToString(), out result2);
									if (result2 != 0L && (addressTypeSendPrd == address.Type.GetValueOrDefault() || addressTypeSendOrd == address.Type.GetValueOrDefault()))
									{
										if (!string.IsNullOrWhiteSpace(vm.AddressIds))
										{
											vm.AddressIds += ",";
										}
										LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = vm;
										lkCompanyAndPersonViewModel.AddressIds = lkCompanyAndPersonViewModel.AddressIds + result2 + "|" + address.Type.GetValueOrDefault();
									}
								}
							}
							if (string.IsNullOrWhiteSpace(vm.prsEmail))
							{
								vm.prsEmail = item.Email;
							}
							else
							{
								vm.prsEmailII = item.Email;
							}
							if ((item.Email ?? "") != (vm.prsEmail ?? ""))
							{
								vm.prsEmailII = item.Email;
							}
							else
							{
								vm.prsEmailII = "";
							}
							vm.cmpKind = 0;
							if (item.PartyType.GetValueOrDefault() == 0)
							{
								vm.cmpKind = 1;
							}
							if (vm.cmpKind.GetValueOrDefault() == 1)
							{
								vm.prsFName = item.FirstName;
							}
							vm.prsLName = item.LastName;
							vm.prsMobile = item.Mobile;
							if (item.BirthDate.HasValue)
							{
								vm.prsBirthDateTime = DateTime.Parse(item.BirthDate.Value.ToString("yyyy-MM-dd"));
								vm.prsBirthDate = (vm.prsBirthDateTime.HasValue ? vm.prsBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
							}
							if (vm.cmpKind.GetValueOrDefault() == 1 && !string.IsNullOrWhiteSpace(item.Alias))
							{
								vm.cmpNameAlias = item.Alias;
							}
							vm.RowNumber = num;
							if (list3 != null)
							{
								CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
								if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
								{
									vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
								}
								else
								{
									vm.CompanyId = 0;
								}
							}
							else
							{
								vm.CompanyId = 0;
							}
							list.Add(vm);
							num++;
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkCompanyInfoViewModelObjects;
	}

	public LkCompanyAndPersonViewModel GetRahkaranInternalSalesCompanyById(long customerId = 0L)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyAndPersonViewModel result2 = new LkCompanyAndPersonViewModel();
		try
		{
			LkCompanyInfoViewModelObjects rahkaranInternalSalesCompanyList = GetRahkaranInternalSalesCompanyList("", "", customerId);
			if (rahkaranInternalSalesCompanyList != null)
			{
				List<LkCompanyAndPersonViewModel> lst = rahkaranInternalSalesCompanyList.lst;
				if (lst != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst))
				{
					result2 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel m) => (m.cmpLinkAccCustomerIdStr ?? "") == customerId.ToString()));
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result2;
	}

	[AjaxOnly]
	public string RahkaranInternalSalesCmpAccountingDetail(int cmpId, ref decimal remainAccount)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						long result2 = 0L;
						long.TryParse(companyById.cmpLinkAccCustomerIdStr, out result2);
						CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider rahkaranInternalSalesProvider = new CRMIdeal.Classes.Helper.OtherSystems.RahkaranInternalSalesProvider();
						remainAccount = rahkaranInternalSalesProvider.GetCustomerAccounts(result2);
						return "";
					}
					Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in Rahkaran");
					ErrorSignal.FromCurrentContext().Raise(e);
					return Labels.frmError;
				}
				Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e2);
				return Labels.frmError;
			}
			Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e3);
			return Labels.frmError;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			return Labels.frmError;
		}
	}

	[AjaxOnly]
	public string RayvarzActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string text2 = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string rayvarz = Labels.Rayvarz;
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
					int value4 = 1;
					long legalCenterGroupId = rayvarzProvider.LegalCenterGroupId;
					long legalParentCenterId = rayvarzProvider.LegalParentCenterId;
					long realCenterGroupId = rayvarzProvider.RealCenterGroupId;
					long realParentCenterId = rayvarzProvider.RealParentCenterId;
					long cmpDiscountTypeId = rayvarzProvider.CmpDiscountTypeId;
					if (legalCenterGroupId == 0L || legalParentCenterId == 0L || realCenterGroupId == 0L || realParentCenterId == 0L || cmpDiscountTypeId == 0L)
					{
						return Messages.errorInReadingSetting + "|";
					}
					int legalTaxSubId = rayvarzProvider.LegalTaxSubId;
					int realTaxSubId = rayvarzProvider.RealTaxSubId;
					int result2 = 0;
					int result3 = 0;
					int.TryParse(companyById.cmpTypeId.ToString(), out result3);
					if (result3 == 0)
					{
						return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
					}
					if (string.IsNullOrWhiteSpace(companyById.LinkAccCmpTypeIdStr))
					{
						return string.Format(Messages.msgErrorOtherSystemsNotFindCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), rayvarz, companyById.cmpType ?? "") + "|";
					}
					int.TryParse(companyById.LinkAccCmpTypeIdStr, out result2);
					int result4 = 0;
					int result5 = 0;
					int.TryParse(companyById.cmpGroupId.ToString(), out result5);
					if (result5 == 0)
					{
						return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpGroupId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
					}
					if (string.IsNullOrWhiteSpace(companyById.LinkAccGroupIdStr))
					{
						return string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), rayvarz, Labels.cmpGroupId, companyById.cmpGroup ?? "") + "|";
					}
					int.TryParse(companyById.LinkAccGroupIdStr, out result4);
					int result6 = 1101;
					int result7 = 0;
					int.TryParse(companyById.cmpCityId.ToString(), out result7);
					if (result7 == 0)
					{
						return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpCityId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
					}
					if (string.IsNullOrWhiteSpace(companyById.LinkAccCityIdStr))
					{
						return string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), rayvarz, Labels.cmpCityId, companyById.cmpCity ?? "") + "|";
					}
					int.TryParse(companyById.LinkAccCityIdStr, out result6);
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						return string.Format(Messages.msgErrorOtherSystemsAlreadyTransferred, Labels.OtherSystemsCompany, rayvarz) + "|";
					}
					RayvarzCustomerDefineViewModel rayvarzCustomerDefineViewModel = new RayvarzCustomerDefineViewModel();
					RayvarzCustomerCenterInsertViewModel rayvarzCustomerCenterInsertViewModel = new RayvarzCustomerCenterInsertViewModel();
					rayvarzCustomerDefineViewModel.nameEn = companyById.cmpNameEng ?? "";
					rayvarzCustomerDefineViewModel.salesTypeId = result2;
					if (companyById.FirstRegisterDate.HasValue)
					{
						rayvarzCustomerDefineViewModel.firstContactDate = (companyById.FirstRegisterDate.HasValue ? companyById.FirstRegisterDate.Value.ToString("yyyyMMdd") : "");
					}
					if (string.IsNullOrWhiteSpace(rayvarzCustomerDefineViewModel.firstContactDate))
					{
						rayvarzCustomerDefineViewModel.firstContactDate = text2;
					}
					rayvarzCustomerDefineViewModel.statusId = value4;
					rayvarzCustomerDefineViewModel.customerGroupId = result4;
					rayvarzCustomerDefineViewModel.economicalCode = companyById.cmpEconomicCode ?? "";
					rayvarzCustomerDefineViewModel.countyId = result6;
					rayvarzCustomerDefineViewModel.address1 = companyById.cmpCountry + ((!string.IsNullOrWhiteSpace(companyById.cmpProvince)) ? ("  - " + companyById.cmpProvince) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpCity)) ? ("  - " + companyById.cmpCity) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpAddress)) ? ("  - " + companyById.cmpAddress) : "");
					rayvarzCustomerDefineViewModel.address2 = "";
					rayvarzCustomerDefineViewModel.zipCode = companyById.cmpZipCode ?? "";
					rayvarzCustomerDefineViewModel.postBoxNo = companyById.cmpPostBox ?? "";
					rayvarzCustomerDefineViewModel.fax = companyById.cmpFax ?? "";
					rayvarzCustomerDefineViewModel.state = 0;
					rayvarzCustomerDefineViewModel.lastState = 0;
					rayvarzCustomerDefineViewModel.discountTypeId = cmpDiscountTypeId;
					rayvarzCustomerDefineViewModel.hasDiscount = 1;
					bool isDone = false;
					string text3 = "";
					CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(cmpId, companyById.cmpMainPersonId.GetValueOrDefault());
					string text4 = "";
					if (companyPerson != null)
					{
						text4 = companyPerson.prsMobile ?? "";
					}
					rayvarzCustomerDefineViewModel.tel1 = text4 ?? "";
					rayvarzCustomerDefineViewModel.tel2 = companyById.cmpPreTel + companyById.cmpTel;
					if (string.IsNullOrWhiteSpace(rayvarzCustomerDefineViewModel.tel2))
					{
						rayvarzCustomerDefineViewModel.tel2 = companyById.cmpPreTelII + companyById.cmpTelII;
					}
					if (companyById.cmpKind == 0)
					{
						rayvarzCustomerDefineViewModel.name = ((!string.IsNullOrWhiteSpace(companyById.cmpTitle)) ? (companyById.cmpTitle + " ") : "") + companyById.cmpName;
						rayvarzCustomerDefineViewModel.nationalId = companyById.cmpNationalCode ?? "";
						text3 = companyById.cmpEmail;
						rayvarzCustomerDefineViewModel.firstName = "";
						rayvarzCustomerDefineViewModel.lastName = "";
						rayvarzCustomerDefineViewModel.taxMainId = 2;
						rayvarzCustomerDefineViewModel.taxSubId = ((legalTaxSubId == 0) ? null : new int?(legalTaxSubId));
						if (companyPerson != null)
						{
							rayvarzCustomerDefineViewModel.firstName = companyPerson.prsFName ?? "";
							rayvarzCustomerDefineViewModel.lastName = companyPerson.prsLName ?? "";
							if (string.IsNullOrWhiteSpace(text3))
							{
								text3 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
							}
						}
						rayvarzCustomerCenterInsertViewModel.name = rayvarzCustomerDefineViewModel.name;
						rayvarzCustomerCenterInsertViewModel.centerGroupId = legalCenterGroupId;
						rayvarzCustomerCenterInsertViewModel.isActive = 1;
						rayvarzCustomerCenterInsertViewModel.hasDetails = 0;
						rayvarzCustomerCenterInsertViewModel.parentCenterId = legalParentCenterId;
						rayvarzCustomerCenterInsertViewModel.centerGroupIdsCollection = new long[1] { rayvarzCustomerCenterInsertViewModel.centerGroupId.GetValueOrDefault() };
						rayvarzCustomerCenterInsertViewModel.rowVersion = "AAAAABL03D4=";
					}
					else if (companyById.cmpKind.GetValueOrDefault() == 1 && companyPerson != null)
					{
						rayvarzCustomerDefineViewModel.name = companyById.CompanyName ?? "";
						rayvarzCustomerDefineViewModel.nationalId = companyPerson.prsNationalCode ?? "";
						text3 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
						rayvarzCustomerDefineViewModel.fatherName = companyPerson.prsFatherName ?? "";
						rayvarzCustomerDefineViewModel.birthCertificateNo = companyPerson.prsIdentityNumber ?? "";
						rayvarzCustomerDefineViewModel.firstName = companyPerson.prsFName ?? "";
						rayvarzCustomerDefineViewModel.lastName = companyPerson.prsLName ?? "";
						rayvarzCustomerDefineViewModel.taxMainId = 1;
						rayvarzCustomerDefineViewModel.taxSubId = ((realTaxSubId == 0) ? null : new int?(realTaxSubId));
						rayvarzCustomerCenterInsertViewModel.name = rayvarzCustomerDefineViewModel.name;
						rayvarzCustomerCenterInsertViewModel.centerGroupId = realCenterGroupId;
						rayvarzCustomerCenterInsertViewModel.isActive = 1;
						rayvarzCustomerCenterInsertViewModel.hasDetails = 0;
						rayvarzCustomerCenterInsertViewModel.parentCenterId = realParentCenterId;
						rayvarzCustomerCenterInsertViewModel.centerGroupIdsCollection = new long[1] { rayvarzCustomerCenterInsertViewModel.centerGroupId.GetValueOrDefault() };
						rayvarzCustomerCenterInsertViewModel.rowVersion = "AAAAABL03D4=";
					}
					rayvarzCustomerDefineViewModel.email = text3;
					long centerId = 0L;
					bool isDone2 = false;
					string text5 = rayvarzProvider.InsertCenter(rayvarzCustomerCenterInsertViewModel, ref centerId, ref isDone2);
					if (isDone2 && centerId != 0L)
					{
						rayvarzCustomerDefineViewModel.centerId = centerId;
						long customerId = 0L;
						rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
						string text6 = rayvarzProvider.SendCompany(rayvarzCustomerDefineViewModel, ref isDone, ref customerId);
						if (isDone && customerId != 0L)
						{
							string text7 = customerId.ToString();
							string text8 = text7;
							string cmpCode = text7;
							string text9 = "";
							DateTime value5 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							LinkAccDataViewModel value6 = new LinkAccDataViewModel
							{
								CId = 0,
								DBId = -1,
								Code = text8,
								Id = text7,
								FTDate = value5,
								LTDate = value5,
								LACId = centerId.ToString()
							};
							text9 = "[" + JsonConvert.SerializeObject(value6) + "]";
							CRMLinkSpEntities dbLink = _dbLink;
							int? companyId = cmpId;
							string cmpLinkAccCode = text8;
							dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, null, cmpLinkAccCode, null, text7, userId, value2, value3, value, text2, appType, cmpCode, text9);
							return "1|" + text8;
						}
						if (!string.IsNullOrWhiteSpace(text6))
						{
							return text + "<br>" + Messages.msgErrorRunFunction + " (" + text6 + ")|";
						}
						return Messages.msgErrorRunFunction + "|";
					}
					if (!string.IsNullOrWhiteSpace(text5))
					{
						return string.Format(Messages.msgErrorInSaveItem, Labels.Center) + "<br>" + text5 + "|";
					}
					return string.Format(Messages.msgErrorInSaveItem, Labels.Center) + "|";
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

	[AjaxOnly]
	public string RayvarzCmpAccountingDetail(int cmpId, ref decimal remainAccount, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider rayvarzProvider = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider();
						remainAccount = rayvarzProvider.GetCustomerAccounts(companyById.cmpLinkAccCustomerIdStr, ref linkAccDebitBalance, ref linkAccCreditBalance);
						return "";
					}
					Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in Rayvarz");
					ErrorSignal.FromCurrentContext().Raise(e);
					return Labels.frmError;
				}
				Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e2);
				return Labels.frmError;
			}
			Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e3);
			return Labels.frmError;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			return Labels.frmError;
		}
	}

	public LkCompanyInfoViewModelObjects GetRayvarzCompanyList(string fromDate = "", string toDate = "", int linkAccPageNum = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
			string value = new CRMIdeal.Classes.Helper.OtherSystems.RayvarzProvider().GetCustomerList(fromDate2, toDate2, linkAccPageNum);
			if (!string.IsNullOrWhiteSpace(value))
			{
				if (!string.IsNullOrWhiteSpace(value))
				{
					value = value.ClearHiddenCharacters();
				}
				if (!string.IsNullOrWhiteSpace(value))
				{
					List<RayvarzCustomerListResponseViewModel> list2 = JsonConvert.DeserializeObject<List<RayvarzCustomerListResponseViewModel>>(value);
					if (list2 != null && Enumerable.Any<RayvarzCustomerListResponseViewModel>((IEnumerable<RayvarzCustomerListResponseViewModel>)list2))
					{
						List<CRMspSelectCompanyWithAccLinkField_Result> list3 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
						int num = 1;
						foreach (RayvarzCustomerListResponseViewModel item in list2)
						{
							LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
							vm.cmpLinkAccCustomerIdStr = item.customerId ?? "";
							vm.cmpLinkAccCode = vm.cmpLinkAccCustomerIdStr;
							vm.cmpCode = vm.cmpLinkAccCode;
							vm.cmpName = item.name;
							vm.cmpNameEng = item.nameEn;
							vm.cmpEconomicCode = item.economicalCode;
							vm.cmpNationalCode = item.nationalId;
							vm.cmpAddress = item.address1 ?? item.address2;
							vm.cmpZipCode = item.zipCode;
							vm.cmpPostBox = item.postBoxNo;
							vm.cmpFax = item.fax;
							string tel = item.tel2;
							if (!string.IsNullOrWhiteSpace(tel))
							{
								string[] array = tel.Split(new char[1] { '-' });
								if (array != null)
								{
									if (array.Length != 0)
									{
										vm.cmpTel = array[0];
									}
									if (array.Length > 1)
									{
										vm.cmpTelII = array[1];
									}
								}
							}
							vm.prsMobile = item.tel1;
							vm.prsEmail = item.email;
							vm.prsLName = item.lastName ?? "";
							vm.prsFName = item.firstName;
							vm.prsFatherName = item.fatherName;
							vm.prsIdentityNumber = item.birthCertificateNo;
							long valueOrDefault = item.centerId.GetValueOrDefault();
							vm.cmpKind = 0;
							long result2 = 0L;
							long.TryParse(item.taxMainId.ToString(), out result2);
							switch (result2)
							{
							case 2L:
								vm.cmpKind = 0;
								break;
							case 1L:
								vm.cmpKind = 1;
								break;
							}
							string text = "";
							DateTime value2 = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
							LinkAccDataViewModel value3 = new LinkAccDataViewModel
							{
								CId = 0,
								DBId = -1,
								Code = vm.cmpLinkAccCode,
								Id = vm.cmpLinkAccCustomerIdStr,
								FTDate = value2,
								LTDate = value2,
								LACId = valueOrDefault.ToString()
							};
							text = "[" + JsonConvert.SerializeObject(value3) + "]";
							vm.cmpLinkAccData = text;
							if (item.countyId.GetValueOrDefault() != 0L)
							{
								vm.LinkAccCityIdStr = item.countyId.GetValueOrDefault().ToString();
								vm.CityName = item.county ?? "";
								if (string.IsNullOrWhiteSpace(vm.CityName))
								{
									vm.CityName = vm.LinkAccCityIdStr;
								}
							}
							if (item.salesTypeId.GetValueOrDefault() != 0L)
							{
								vm.LinkAccCmpTypeIdStr = item.salesTypeId.GetValueOrDefault().ToString();
								vm.CmpTypeTitle = item.salesType ?? "";
								if (string.IsNullOrWhiteSpace(vm.CmpTypeTitle))
								{
									vm.CmpTypeTitle = vm.LinkAccCmpTypeIdStr;
								}
							}
							if (item.customerGroupId.GetValueOrDefault() != 0L)
							{
								vm.CompanySubGroupName = item.customerGroup ?? "";
								vm.LinkAccSubGroupIdStr = item.customerGroupId.GetValueOrDefault().ToString();
								if (string.IsNullOrWhiteSpace(vm.CompanySubGroupName))
								{
									vm.CompanySubGroupName = vm.LinkAccSubGroupIdStr;
								}
							}
							vm.RowNumber = num;
							if (list3 != null)
							{
								CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list3, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
								if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
								{
									vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
								}
								else
								{
									vm.CompanyId = 0;
								}
							}
							else
							{
								vm.CompanyId = 0;
							}
							list.Add(vm);
							num++;
						}
					}
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkCompanyInfoViewModelObjects;
	}

	[AjaxOnly]
	public string SSOGetCompanyInfo_Old(int cmpId)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				if (CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId) != null)
				{
					return "1@|@<span style=\"font-size: 22px;display: block;width: 100%;color: green;text-align: center;margin: 15px auto;\"> اطلاعات مخاطب از نرم افزار SSO </span>";
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

	[AjaxOnly]
	public string ArianSystemActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider();
					long num = 0L;
					int result2 = 0;
					int.TryParse(companyById.cmpTypeId.ToString(), out result2);
					if (result2 == 0)
					{
						return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
					}
					CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider.ArianSystemSettingDetailsViewModel settingDetails = arianSystemProvider.GetSettingDetails(0, result2, "CompanyType");
					if (settingDetails != null)
					{
						num = settingDetails.PersonTypeAcc;
						if (num == 0L)
						{
							return string.Format(Messages.msgErrorInSendCmpToAccLinkNotSelectedItem, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), linkAccSystemTitle, string.Format(Labels.SettingByFormat, Labels.cmpTypeId)) + "|";
						}
						long result3 = 0L;
						int result4 = 0;
						int.TryParse(companyById.cmpCityId.ToString(), out result4);
						if (result4 == 0)
						{
							return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpField, Labels.cmpCityId, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
						}
						if (string.IsNullOrWhiteSpace(companyById.LinkAccCityIdStr))
						{
							return string.Format(Messages.msgErrorInSendCmpToAccLinkNotFoundIteminAcc, companyById.cmpNumber.GetValueOrDefault().ToString(), linkAccSystemTitle, Labels.cmpCityId, companyById.cmpCity ?? "") + "|";
						}
						long.TryParse(companyById.LinkAccCityIdStr, out result3);
						if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
						{
							return string.Format(Messages.msgErrorOtherSystemsAlreadyTransferred, Labels.OtherSystemsCompany, linkAccSystemTitle) + "|";
						}
						ArianSystemCustomerReqestViewModel arianSystemCustomerReqestViewModel = new ArianSystemCustomerReqestViewModel();
						arianSystemCustomerReqestViewModel.PersonTypeId = num;
						arianSystemCustomerReqestViewModel.InActive = 0;
						arianSystemCustomerReqestViewModel.RegisterLocationId = result3;
						arianSystemCustomerReqestViewModel.Address = companyById.cmpCountry + ((!string.IsNullOrWhiteSpace(companyById.cmpProvince)) ? ("  - " + companyById.cmpProvince) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpCity)) ? ("  - " + companyById.cmpCity) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpAddress)) ? ("  - " + companyById.cmpAddress) : "");
						arianSystemCustomerReqestViewModel.CodePosti = companyById.cmpZipCode ?? "";
						arianSystemCustomerReqestViewModel.Phone = companyById.cmpPreTel + companyById.cmpTel;
						if (string.IsNullOrWhiteSpace(arianSystemCustomerReqestViewModel.Phone))
						{
							arianSystemCustomerReqestViewModel.Phone = companyById.cmpPreTelII + companyById.cmpTelII;
						}
						bool isDone = false;
						string text2 = "";
						string text3 = "";
						CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(cmpId, companyById.cmpMainPersonId.GetValueOrDefault());
						if (companyById.cmpKind == 0)
						{
							arianSystemCustomerReqestViewModel.PersonFName = companyById.cmpName ?? "";
							arianSystemCustomerReqestViewModel.PersonTitle = companyById.cmpTitle ?? "";
							arianSystemCustomerReqestViewModel.IsPerson = 0;
							arianSystemCustomerReqestViewModel.FatherName = "";
							arianSystemCustomerReqestViewModel.NationalCode = companyById.cmpNationalCode ?? "";
							arianSystemCustomerReqestViewModel.NationalIdentity = "";
							text2 = companyById.cmpEmail ?? "";
							text3 = companyById.cmpMobile ?? "";
							if (companyPerson != null)
							{
								if (string.IsNullOrWhiteSpace(text3))
								{
									text3 = companyPerson.prsMobile ?? "";
								}
								if (string.IsNullOrWhiteSpace(text2))
								{
									text2 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
								}
							}
							arianSystemCustomerReqestViewModel.Email = text2 ?? "";
							arianSystemCustomerReqestViewModel.Mobile = text3 ?? "";
						}
						else if (companyById.cmpKind.GetValueOrDefault() == 1 && companyPerson != null)
						{
							arianSystemCustomerReqestViewModel.PersonFName = ((!string.IsNullOrWhiteSpace(companyPerson.prsFName)) ? (companyPerson.prsFName ?? "") : companyPerson.prsFName) + ((!string.IsNullOrWhiteSpace(companyPerson.prsLName)) ? (companyPerson.prsLName ?? "") : companyPerson.prsLName);
							arianSystemCustomerReqestViewModel.PersonTitle = companyPerson.prsTitle ?? "";
							arianSystemCustomerReqestViewModel.IsPerson = 1;
							arianSystemCustomerReqestViewModel.FatherName = companyPerson.prsFatherName ?? "";
							arianSystemCustomerReqestViewModel.NationalCode = companyPerson.prsNationalCode ?? "";
							arianSystemCustomerReqestViewModel.NationalIdentity = companyPerson.prsIdentityNumber ?? "";
							text3 = companyPerson.prsMobile ?? "";
							text2 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
							arianSystemCustomerReqestViewModel.Email = text2 ?? "";
							arianSystemCustomerReqestViewModel.Mobile = text3 ?? "";
						}
						long customerId = 0L;
						string customerCode = "";
						string cmpLinkAccData = "";
						arianSystemProvider = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider();
						string text4 = arianSystemProvider.SendCompany(arianSystemCustomerReqestViewModel, ref isDone, ref customerId, ref customerCode, ref cmpLinkAccData);
						if (isDone && customerId != 0L)
						{
							string text5 = customerId.ToString();
							if (string.IsNullOrWhiteSpace(customerCode))
							{
								customerCode = text5;
							}
							string text6 = customerCode;
							string cmpCode = customerCode;
							CRMLinkSpEntities dbLink = _dbLink;
							int? companyId = cmpId;
							string cmpLinkAccCode = text6;
							dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, null, cmpLinkAccCode, null, text5, userId, value2, value3, value, registerDatePersian, appType, cmpCode, cmpLinkAccData);
							return "1|" + text6;
						}
						if (!string.IsNullOrWhiteSpace(text4))
						{
							return text + "<br>" + Messages.msgErrorRunFunction + " (" + text4 + ")|";
						}
						return Messages.msgErrorRunFunction + "|";
					}
					return string.Format(Messages.msgErrorInSendCmpToAccLinkNotSelectedItem, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), linkAccSystemTitle, string.Format(Labels.SettingByFormat, Labels.cmpTypeId)) + "|";
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

	public LkCompanyInfoViewModelObjects GetArianSystemCompanyList(int recCount = 0, int linkAccPageNum = 0, string cmpName = "", string cmpCode = "", string cmpNationalCode = "", string mobileNo = "", string linkAccIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
			List<ArianSystemCustomerListResponseViewModel> customerList = new CRMIdeal.Classes.Helper.OtherSystems.ArianSystemProvider().GetCustomerList(recCount, linkAccPageNum, cmpName, cmpCode, cmpNationalCode, mobileNo, linkAccIdStr);
			if (customerList != null && Enumerable.Any<ArianSystemCustomerListResponseViewModel>((IEnumerable<ArianSystemCustomerListResponseViewModel>)customerList))
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				List<CRMspSelectUsersWithAccLinkField_Result> list3 = Enumerable.ToList<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)_dbLink.CRMspSelectUsersWithAccLinkField(true, false, lCID, result));
				int num = 1;
				foreach (ArianSystemCustomerListResponseViewModel item in customerList)
				{
					LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
					vm.cmpLinkAccCustomerIdStr = item.CustomerID.GetValueOrDefault().ToString();
					vm.cmpLinkAccCode = item.CustomerCode ?? "";
					vm.cmpCode = vm.cmpLinkAccCode;
					vm.cmpName = item.PersonFullName;
					vm.cmpNationalCode = item.NationalCode;
					vm.cmpAddress = item.Addrs;
					vm.cmpTel = item.Phone;
					vm.prsMobile = item.Mobile;
					vm.prsLName = item.PersonFullName;
					vm.prsFatherName = item.Fathername;
					int valueOrDefault = item.PersonID.GetValueOrDefault();
					vm.cmpKind = 0;
					bool result2 = false;
					bool.TryParse(item.IsPerson.ToString(), out result2);
					if (result2)
					{
						vm.cmpKind = 1;
					}
					string text = "";
					DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					LinkAccDataByExtraFieldsViewModel value2 = new LinkAccDataByExtraFieldsViewModel
					{
						CId = 0,
						DBId = -1,
						Code = vm.cmpLinkAccCode,
						Id = vm.cmpLinkAccCustomerIdStr,
						FTDate = value,
						LTDate = value,
						LACId = "0",
						ExtraI = valueOrDefault.ToString(),
						ExtraII = (item.TafsiliCode ?? ""),
						ExtraIII = ""
					};
					text = "[" + JsonConvert.SerializeObject(value2) + "]";
					vm.cmpLinkAccData = text;
					if (item.VisitorID.GetValueOrDefault() != 0)
					{
						vm.cmpReferLinkAccUserIdStr = item.VisitorID.GetValueOrDefault().ToString();
						if (list3 != null && !string.IsNullOrWhiteSpace(vm.cmpReferLinkAccUserIdStr) && Enumerable.Any<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3))
						{
							CRMspSelectUsersWithAccLinkField_Result cRMspSelectUsersWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectUsersWithAccLinkField_Result>((IEnumerable<CRMspSelectUsersWithAccLinkField_Result>)list3, (Func<CRMspSelectUsersWithAccLinkField_Result, bool>)((CRMspSelectUsersWithAccLinkField_Result m) => m.LinkAccUserIdStr == vm.cmpReferLinkAccUserIdStr));
							if (cRMspSelectUsersWithAccLinkField_Result != null)
							{
								vm.cmpReferLName = cRMspSelectUsersWithAccLinkField_Result.LName ?? "";
								vm.cmpReferFName = cRMspSelectUsersWithAccLinkField_Result.FName ?? "";
								vm.cmpReferLinkAccUserCode = cRMspSelectUsersWithAccLinkField_Result.LinkAccUserCode ?? "";
							}
						}
						if (string.IsNullOrWhiteSpace(vm.cmpReferLName))
						{
							vm.cmpReferLName = vm.cmpReferLinkAccUserIdStr;
						}
					}
					vm.RowNumber = num;
					if (list2 != null)
					{
						CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
						if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
						{
							vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
						}
						else
						{
							vm.CompanyId = 0;
						}
					}
					else
					{
						vm.CompanyId = 0;
					}
					list.Add(vm);
					num++;
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return lkCompanyInfoViewModelObjects;
	}

	[AjaxOnly]
	public string ShygunDetailedAPIActCmpSendToAcc(int cmpId, bool checkAction = true)
	{
		string text = "";
		try
		{
			CRMspLoadUserLoginInfoViewModel currentUser = UserLogin.CurrentUser;
			if (!UserLogin.IsUserAccess("frmCompanyI", "actSendToAcc", currentUser) && checkAction)
			{
				return Messages.ErrorNotAccess + "|";
			}
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				DateTime now = DateTime.Now;
				DateTime value = now;
				string registerDatePersian = now.ToString("yyyyMMdd", new PersianCulture());
				short value2 = short.Parse(now.ToString("MM", new PersianCulture()));
				string appType = Configuration.AppType;
				short value3 = short.Parse(Financial.Get().Id.ToString());
				int userId = UserLogin.CurrentUser.UserId;
				string linkAccSystemTitle = CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider shygunDetailedAPIProvider = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider();
					string text2 = "";
					int result2 = 0;
					int.TryParse(companyById.cmpTypeId.ToString(), out result2);
					if (result2 == 0)
					{
						return string.Format(Messages.msgErrorOtherSystemsNotSelectedCmpType, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString()) + "|";
					}
					CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider.ArianSystemSettingDetailsViewModel settingDetails = shygunDetailedAPIProvider.GetSettingDetails(0, result2, "CompanyType");
					if (settingDetails != null)
					{
						text2 = settingDetails.CmpMoeinAccCode;
						if (string.IsNullOrWhiteSpace(text2))
						{
							return string.Format(Messages.msgErrorInSendCmpToAccLinkNotSelectedItem, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), linkAccSystemTitle, string.Format(Labels.SettingByFormat, Labels.cmpTypeId)) + "|";
						}
						ShygunDetailedAPIAccountRequestDefineInfoViewModel shygunDetailedAPIAccountRequestDefineInfoViewModel = new ShygunDetailedAPIAccountRequestDefineInfoViewModel();
						shygunDetailedAPIAccountRequestDefineInfoViewModel.MoinNumber = text2;
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Country = companyById.cmpCountry ?? "";
						shygunDetailedAPIAccountRequestDefineInfoViewModel.State = companyById.cmpProvince ?? "";
						shygunDetailedAPIAccountRequestDefineInfoViewModel.City = companyById.cmpCity ?? "";
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Add1 = companyById.cmpCountry + ((!string.IsNullOrWhiteSpace(companyById.cmpProvince)) ? ("  - " + companyById.cmpProvince) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpCity)) ? ("  - " + companyById.cmpCity) : "") + ((!string.IsNullOrWhiteSpace(companyById.cmpAddress)) ? ("  - " + companyById.cmpAddress) : "");
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Add2 = companyById.cmpAddressDesc ?? "";
						shygunDetailedAPIAccountRequestDefineInfoViewModel.ZipCode = companyById.cmpZipCode ?? "";
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Tel1 = companyById.cmpPreTel + companyById.cmpTel;
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Tel2 = companyById.cmpPreTelII + companyById.cmpTelII;
						shygunDetailedAPIAccountRequestDefineInfoViewModel.Fax = companyById.cmpFax;
						shygunDetailedAPIAccountRequestDefineInfoViewModel.TaxCode = companyById.cmpEconomicCode ?? "";
						if (!string.IsNullOrWhiteSpace(companyById.cmpCoordinateLatitude) && !string.IsNullOrWhiteSpace(companyById.cmpCoordinateLongitude))
						{
							decimal result3 = default(decimal);
							decimal result4 = default(decimal);
							decimal.TryParse(companyById.cmpCoordinateLatitude, out result3);
							decimal.TryParse(companyById.cmpCoordinateLongitude, out result4);
							if (result3 != 0m && result4 != 0m)
							{
								shygunDetailedAPIAccountRequestDefineInfoViewModel.LocationLatitude = result3;
								shygunDetailedAPIAccountRequestDefineInfoViewModel.LocationLongitude = result4;
							}
						}
						if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
						{
							shygunDetailedAPIAccountRequestDefineInfoViewModel.UpdateKind = 1L;
							shygunDetailedAPIAccountRequestDefineInfoViewModel.GuId = companyById.cmpLinkAccCustomerIdStr;
						}
						else
						{
							shygunDetailedAPIAccountRequestDefineInfoViewModel.UpdateKind = 0L;
						}
						string text3 = "";
						string text4 = "";
						CRMspSelectCompanyPersonsByID_Result companyPerson = CRMIdeal.Classes.Helper.OtherSystems.GetCompanyPerson(cmpId, companyById.cmpMainPersonId.GetValueOrDefault());
						if (companyPerson == null)
						{
							return Messages.msgErrorNotDefinedCmpPerson + "|";
						}
						if (companyById.cmpKind == 0)
						{
							shygunDetailedAPIAccountRequestDefineInfoViewModel.AccountName = companyById.cmpName ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Title = companyById.cmpTitle ?? "";
							text3 = companyById.cmpEmail ?? "";
							text4 = companyById.cmpMobile ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.mellicode = companyById.cmpNationalCode ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.BirthDay = "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.AccountTypeLaw = 2L;
							if (companyPerson != null)
							{
								if (string.IsNullOrWhiteSpace(text4))
								{
									text4 = companyPerson.prsMobile ?? "";
								}
								if (string.IsNullOrWhiteSpace(text3))
								{
									text3 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
								}
							}
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Email = text3 ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Mobile = text4 ?? "";
						}
						else if (companyById.cmpKind.GetValueOrDefault() == 1 && companyPerson != null)
						{
							shygunDetailedAPIAccountRequestDefineInfoViewModel.AccountName = ((!string.IsNullOrWhiteSpace(companyPerson.prsFName)) ? (companyPerson.prsFName ?? "") : companyPerson.prsFName) + ((!string.IsNullOrWhiteSpace(companyPerson.prsLName)) ? (companyPerson.prsLName ?? "") : companyPerson.prsLName);
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Title = companyPerson.prsTitle ?? "";
							text4 = companyPerson.prsMobile ?? "";
							text3 = companyPerson.prsEmail ?? companyPerson.prsEmailII;
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Email = text3 ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.Mobile = text4 ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.mellicode = companyPerson.prsNationalCode ?? "";
							shygunDetailedAPIAccountRequestDefineInfoViewModel.AccountTypeLaw = 1L;
							if (companyPerson.prsBirthDateTime.HasValue)
							{
								shygunDetailedAPIAccountRequestDefineInfoViewModel.BirthDay = DateTime.Parse(companyPerson.prsBirthDateTime.ToString()).ToString("yyyyMMdd", new CultureInfo("en-US"));
							}
						}
						string customerId = "";
						bool isDone = false;
						string customerCode = "";
						string cmpLinkAccData = "";
						shygunDetailedAPIProvider = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider();
						string text5 = shygunDetailedAPIProvider.SendCompany(shygunDetailedAPIAccountRequestDefineInfoViewModel, ref isDone, ref customerId, ref customerCode, ref cmpLinkAccData);
						if (isDone && !string.IsNullOrWhiteSpace(customerId))
						{
							string text6 = customerId;
							if (string.IsNullOrWhiteSpace(customerCode))
							{
								customerCode = text6;
							}
							string text7 = customerCode;
							string cmpCode = customerCode;
							CRMLinkSpEntities dbLink = _dbLink;
							int? companyId = cmpId;
							string cmpLinkAccCode = text7;
							dbLink.CRMspUpdateCompanyWithAccLinkField(companyId, null, cmpLinkAccCode, null, text6, userId, value2, value3, value, registerDatePersian, appType, cmpCode, cmpLinkAccData);
							return "1|" + text7;
						}
						if (!string.IsNullOrWhiteSpace(text5))
						{
							return text + "<br>" + Messages.msgErrorRunFunction + " (" + text5 + ")|";
						}
						return Messages.msgErrorRunFunction + "|";
					}
					return string.Format(Messages.msgErrorInSendCmpToAccLinkNotSelectedItem, companyById.CompanyName ?? "", companyById.cmpNumber.GetValueOrDefault().ToString(), linkAccSystemTitle, string.Format(Labels.SettingByFormat, Labels.cmpTypeId)) + "|";
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

	public LkCompanyInfoViewModelObjects GetShygunDetailedAPICompanyList(int fromRec = 0, int recCount = 0, string fromLinkAccCmpCode = "", string toLinkAccCmpCode = "", string linkAccIdStr = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		LkCompanyInfoViewModelObjects lkCompanyInfoViewModelObjects = new LkCompanyInfoViewModelObjects();
		lkCompanyInfoViewModelObjects.lst = new List<LkCompanyAndPersonViewModel>();
		lkCompanyInfoViewModelObjects.FilteredLst = new List<LkCompanyAndPersonViewModel>();
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
		try
		{
			List<ShygunDetailedAPIAccountInfoViewModel> customerList = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider().GetCustomerList(fromRec, recCount, fromLinkAccCmpCode, toLinkAccCmpCode, linkAccIdStr);
			if (customerList != null && Enumerable.Any<ShygunDetailedAPIAccountInfoViewModel>((IEnumerable<ShygunDetailedAPIAccountInfoViewModel>)customerList))
			{
				List<CRMspSelectCompanyWithAccLinkField_Result> list2 = SelectCompanyWithAccLinkField(withLinkAccCode: false, withLinkAccCodeId: false, withLinkCustomerId: false, withLinkCustomerIdStr: true);
				int num = 1;
				foreach (ShygunDetailedAPIAccountInfoViewModel item in customerList)
				{
					LkCompanyAndPersonViewModel vm = new LkCompanyAndPersonViewModel();
					vm.cmpLinkAccCustomerIdStr = item.GuId ?? "";
					vm.cmpLinkAccCode = item.AccountNumber ?? "";
					vm.cmpCode = vm.cmpLinkAccCode;
					vm.cmpName = item.AccountName;
					vm.cmpDescription = item.Imemo ?? "";
					vm.cmpNationalCode = item.mellicode;
					vm.cmpTel = item.Tel1;
					vm.cmpTelII = item.Tel2;
					vm.cmpFax = item.Fax;
					vm.cmpAddress = item.Add1;
					vm.cmpAddressDesc = item.Add2;
					vm.cmpWebSite = item.Web;
					vm.cmpZipCode = item.ZipCode;
					if (item.LocationLatitude.GetValueOrDefault() != 0m && item.LocationLongitude.GetValueOrDefault() != 0m)
					{
						vm.cmpCoordinateLatitude = item.LocationLatitude.GetValueOrDefault().ToString();
						vm.cmpCoordinateLongitude = item.LocationLongitude.GetValueOrDefault().ToString();
					}
					vm.CityName = item.City ?? "";
					vm.ProvinceName = item.State ?? "";
					vm.CountryName = item.Country ?? "";
					vm.cmpEconomicCode = item.TaxCode ?? "";
					vm.CompanyTitle = item.Title ?? "";
					vm.prsMobile = item.Mobile;
					vm.prsLName = item.AccountName;
					if (!string.IsNullOrWhiteSpace(item.BirthDay))
					{
						try
						{
							DateTime dateTime = default(DateTime);
							dateTime = DateTime.Parse(item.BirthDay, new CultureInfo("en-US"));
							vm.prsBirthDateTime = dateTime;
							vm.prsBirthDate = dateTime.ToString("yyyyMMdd", new PersianCulture());
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
						}
					}
					vm.cmpKind = 0;
					if (item.AccountTypeLaw.GetValueOrDefault() == 1)
					{
						vm.cmpKind = 1;
					}
					string text = "";
					DateTime value = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
					LinkAccDataByExtraFieldsViewModel value2 = new LinkAccDataByExtraFieldsViewModel
					{
						CId = 0,
						DBId = -1,
						Code = vm.cmpLinkAccCode,
						Id = vm.cmpLinkAccCustomerIdStr,
						FTDate = value,
						LTDate = value,
						LACId = "0",
						ExtraI = "",
						ExtraII = "",
						ExtraIII = ""
					};
					text = "[" + JsonConvert.SerializeObject(value2) + "]";
					vm.cmpLinkAccData = text;
					vm.RowNumber = num;
					if (list2 != null)
					{
						CRMspSelectCompanyWithAccLinkField_Result cRMspSelectCompanyWithAccLinkField_Result = Enumerable.FirstOrDefault<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)list2, (Func<CRMspSelectCompanyWithAccLinkField_Result, bool>)((CRMspSelectCompanyWithAccLinkField_Result x) => x.cmpLinkAccCustomerIdStr == vm.cmpLinkAccCustomerIdStr));
						if (cRMspSelectCompanyWithAccLinkField_Result != null && !string.IsNullOrWhiteSpace(cRMspSelectCompanyWithAccLinkField_Result.cmpLinkAccCustomerIdStr))
						{
							vm.CompanyId = cRMspSelectCompanyWithAccLinkField_Result.CompanyID;
						}
						else
						{
							vm.CompanyId = 0;
						}
					}
					else
					{
						vm.CompanyId = 0;
					}
					list.Add(vm);
					num++;
				}
			}
			lkCompanyInfoViewModelObjects.lst = list;
			lkCompanyInfoViewModelObjects.FilteredLst = list;
			lkCompanyInfoViewModelObjects.Json = Json(list, JsonRequestBehavior.AllowGet);
			lkCompanyInfoViewModelObjects.SerializedJson = JsonConvert.SerializeObject(list);
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
		}
		return lkCompanyInfoViewModelObjects;
	}

	[AjaxOnly]
	public string ShygunDetailedAPICmpAccountingDetail(int cmpId, ref decimal remainAccount, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance)
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
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			if (cmpId > 0)
			{
				CRMspSelectCompanyById_Result companyById = CRMIdeal.Classes.Helper.Company.GetCompanyById(cmpId);
				if (companyById != null)
				{
					if (!string.IsNullOrWhiteSpace(companyById.cmpLinkAccCustomerIdStr))
					{
						CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider shygunDetailedAPIProvider = new CRMIdeal.Classes.Helper.OtherSystems.ShygunDetailedAPIProvider();
						remainAccount = shygunDetailedAPIProvider.GetCustomerClosingBalance(companyById.cmpLinkAccCustomerIdStr, ref linkAccDebitBalance, ref linkAccCreditBalance);
						return "";
					}
					Exception e = new Exception(Messages.ErrorNotFound + "(This customer by name " + companyById.cmpName + " not in Shygun");
					ErrorSignal.FromCurrentContext().Raise(e);
					return Labels.frmError;
				}
				Exception e2 = new Exception(Messages.ErrorNotFound + "(customer)");
				ErrorSignal.FromCurrentContext().Raise(e2);
				return Labels.frmError;
			}
			Exception e3 = new Exception(Messages.ErrorNotFound + "(customer)");
			ErrorSignal.FromCurrentContext().Raise(e3);
			return Labels.frmError;
		}
		catch (Exception e4)
		{
			ErrorSignal.FromCurrentContext().Raise(e4);
			return Labels.frmError;
		}
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc,actSendToAcc")]
	public ActionResult ManageCmpLinkAcc(int linkAccSystemId)
	{
		switch (linkAccSystemId)
		{
		case 12:
			GetArpaUserGroup();
			break;
		case 18:
		{
			LinkAccNoAvCapillarySettingController linkAccNoAvCapillarySettingController = new LinkAccNoAvCapillarySettingController();
			base.ViewBag.NoAvCompany = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryCompanyList();
			base.ViewBag.NoAvZone = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryZoneList();
			base.ViewBag.NoAvRoute = linkAccNoAvCapillarySettingController.GetNoAvaranCapillaryRouteList();
			break;
		}
		}
		GetCmpReferUser();
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportShowInfo")]
	public ActionResult ManageImportCompany_Read([DataSourceRequest] DataSourceRequest request, int linkAccSystemId, string arpaUserGroupId = "", string mobileNo = "", string businessCode = "", string fromDate = "", string toDate = "", string cmpName = "", string cmpCode = "", string cmpNationalCode = "", int fromRec = 0, int recCount = 0, string cookieVal = "", string records = "", int linkAccPageNum = 0, string fromLinkAccCmpCode = "", string toLinkAccCmpCode = "")
	{
		//IL_0e61: Unknown result type (might be due to invalid IL or missing references)
		List<LkCompanyAndPersonViewModel> list = new List<LkCompanyAndPersonViewModel>();
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
			ArpaCompanyInfoViewModelObjects arpaCompanyList = GetArpaCompanyList(arpaUserGroupId, mobileNo, businessCode);
			if (arpaCompanyList == null)
			{
				break;
			}
			list = arpaCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item12 in list)
			{
				item12.cmpName = ((!string.IsNullOrWhiteSpace(item12.cmpName)) ? item12.cmpName : "") + ((!string.IsNullOrWhiteSpace(item12.prsFName) || !string.IsNullOrWhiteSpace(item12.prsLName)) ? ("(" + item12.prsFName + " " + item12.prsLName + ")") : "");
				item12.cmpReferLName = ((!string.IsNullOrWhiteSpace(item12.cmpReferFName)) ? (item12.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item12.cmpReferLName)) ? (item12.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item12.cmpReferLName))
				{
					item12.cmpReferLName = item12.cmpReferLinkAccUserIdStr ?? item12.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item4 = new OtherSystemSelectedVIiewModel
				{
					Row = item12.RowNumber,
					Id = (item12.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item12.CompanyId <= 0)
				};
				list2.Add(item4);
			}
			break;
		}
		case 17:
		{
			HamrahanCompanyInfoViewModelObjects hamrahanCompanyList = GetHamrahanCompanyList();
			if (hamrahanCompanyList == null)
			{
				break;
			}
			list = hamrahanCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item13 in list)
			{
				item13.cmpName = ((!string.IsNullOrWhiteSpace(item13.cmpName)) ? item13.cmpName : "") + ((!string.IsNullOrWhiteSpace(item13.prsFName) || !string.IsNullOrWhiteSpace(item13.prsLName)) ? ("(" + item13.prsFName + " " + item13.prsLName + ")") : "");
				item13.cmpReferLName = ((!string.IsNullOrWhiteSpace(item13.cmpReferFName)) ? (item13.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item13.cmpReferLName)) ? (item13.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item13.cmpReferLName))
				{
					item13.cmpReferLName = item13.cmpReferLinkAccUserIdStr ?? item13.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item8 = new OtherSystemSelectedVIiewModel
				{
					Row = item13.RowNumber,
					Id = (item13.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item13.CompanyId <= 0)
				};
				list2.Add(item8);
			}
			break;
		}
		case 18:
		{
			LkCompanyInfoViewModelObjects noAvaranCapillaryCompanyList = GetNoAvaranCapillaryCompanyList(cmpCode, cmpName, cmpNationalCode, fromDate, toDate);
			if (noAvaranCapillaryCompanyList == null)
			{
				break;
			}
			list = noAvaranCapillaryCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item14 in list)
			{
				item14.cmpName = ((!string.IsNullOrWhiteSpace(item14.cmpName)) ? item14.cmpName : "") + ((!string.IsNullOrWhiteSpace(item14.prsFName) || !string.IsNullOrWhiteSpace(item14.prsLName)) ? ("(" + item14.prsFName + " " + item14.prsLName + ")") : "");
				item14.cmpReferLName = ((!string.IsNullOrWhiteSpace(item14.cmpReferFName)) ? (item14.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item14.cmpReferLName)) ? (item14.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item14.cmpReferLName))
				{
					item14.cmpReferLName = item14.cmpReferLinkAccUserIdStr ?? item14.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item10 = new OtherSystemSelectedVIiewModel
				{
					Row = item14.RowNumber,
					Id = (item14.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item14.CompanyId <= 0)
				};
				list2.Add(item10);
			}
			break;
		}
		case 19:
		{
			LkCompanyInfoViewModelObjects rahkaranRetailCompanyList = GetRahkaranRetailCompanyList(cookieVal, fromRec, recCount, cmpName, cmpNationalCode, mobileNo);
			if (rahkaranRetailCompanyList == null)
			{
				break;
			}
			list = rahkaranRetailCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item15 in list)
			{
				item15.cmpName = ((!string.IsNullOrWhiteSpace(item15.cmpName)) ? item15.cmpName : "") + ((!string.IsNullOrWhiteSpace(item15.prsFName) || !string.IsNullOrWhiteSpace(item15.prsLName)) ? ("(" + item15.prsFName + " " + item15.prsLName + ")") : "");
				item15.cmpReferLName = ((!string.IsNullOrWhiteSpace(item15.cmpReferFName)) ? (item15.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item15.cmpReferLName)) ? (item15.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item15.cmpReferLName))
				{
					item15.cmpReferLName = item15.cmpReferLinkAccUserIdStr ?? item15.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item6 = new OtherSystemSelectedVIiewModel
				{
					Row = item15.RowNumber,
					Id = (item15.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item15.CompanyId <= 0)
				};
				list2.Add(item6);
			}
			break;
		}
		case 20:
		{
			LkCompanyInfoViewModelObjects nilramCompanyList = GetNilramCompanyList(fromDate, toDate);
			if (nilramCompanyList == null)
			{
				break;
			}
			list = nilramCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item16 in list)
			{
				item16.cmpName = ((!string.IsNullOrWhiteSpace(item16.cmpName)) ? item16.cmpName : "") + ((!string.IsNullOrWhiteSpace(item16.prsFName) || !string.IsNullOrWhiteSpace(item16.prsLName)) ? ("(" + item16.prsFName + " " + item16.prsLName + ")") : "");
				item16.cmpReferLName = ((!string.IsNullOrWhiteSpace(item16.cmpReferFName)) ? (item16.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item16.cmpReferLName)) ? (item16.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item16.cmpReferLName))
				{
					item16.cmpReferLName = item16.cmpReferLinkAccUserIdStr ?? item16.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item11 = new OtherSystemSelectedVIiewModel
				{
					Row = item16.RowNumber,
					Id = (item16.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item16.CompanyId <= 0)
				};
				list2.Add(item11);
			}
			break;
		}
		case 22:
		{
			LkCompanyInfoViewModelObjects rahkaranInternalSalesCompanyList = GetRahkaranInternalSalesCompanyList(fromDate, toDate, 0L);
			if (rahkaranInternalSalesCompanyList == null)
			{
				break;
			}
			list = rahkaranInternalSalesCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item17 in list)
			{
				item17.cmpName = ((!string.IsNullOrWhiteSpace(item17.cmpName)) ? item17.cmpName : "") + ((!string.IsNullOrWhiteSpace(item17.prsFName) || !string.IsNullOrWhiteSpace(item17.prsLName)) ? ("(" + item17.prsFName + " " + item17.prsLName + ")") : "");
				item17.cmpReferLName = ((!string.IsNullOrWhiteSpace(item17.cmpReferFName)) ? (item17.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item17.cmpReferLName)) ? (item17.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item17.cmpReferLName))
				{
					item17.cmpReferLName = item17.cmpReferLinkAccUserIdStr ?? item17.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item9 = new OtherSystemSelectedVIiewModel
				{
					Row = item17.RowNumber,
					Id = (item17.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item17.CompanyId <= 0)
				};
				list2.Add(item9);
			}
			break;
		}
		case 23:
		{
			LkCompanyInfoViewModelObjects rayvarzCompanyList = GetRayvarzCompanyList(fromDate, toDate, linkAccPageNum);
			if (rayvarzCompanyList == null)
			{
				break;
			}
			list = rayvarzCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item18 in list)
			{
				item18.cmpName = ((!string.IsNullOrWhiteSpace(item18.cmpName)) ? item18.cmpName : "") + ((!string.IsNullOrWhiteSpace(item18.prsFName) || !string.IsNullOrWhiteSpace(item18.prsLName)) ? ("(" + item18.prsFName + " " + item18.prsLName + ")") : "");
				item18.cmpReferLName = ((!string.IsNullOrWhiteSpace(item18.cmpReferFName)) ? (item18.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item18.cmpReferLName)) ? (item18.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item18.cmpReferLName))
				{
					item18.cmpReferLName = item18.cmpReferLinkAccUserIdStr ?? item18.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item7 = new OtherSystemSelectedVIiewModel
				{
					Row = item18.RowNumber,
					Id = (item18.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item18.CompanyId <= 0)
				};
				list2.Add(item7);
			}
			break;
		}
		case 25:
		{
			LkCompanyInfoViewModelObjects arianSystemCompanyList = GetArianSystemCompanyList(recCount, linkAccPageNum, cmpName, cmpCode, cmpNationalCode, mobileNo);
			if (arianSystemCompanyList == null)
			{
				break;
			}
			list = arianSystemCompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item19 in list)
			{
				item19.cmpName = ((!string.IsNullOrWhiteSpace(item19.cmpName)) ? item19.cmpName : "");
				item19.cmpReferLName = ((!string.IsNullOrWhiteSpace(item19.cmpReferFName)) ? (item19.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item19.cmpReferLName)) ? (item19.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item19.cmpReferLName))
				{
					item19.cmpReferLName = item19.cmpReferLinkAccUserIdStr ?? item19.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item5 = new OtherSystemSelectedVIiewModel
				{
					Row = item19.RowNumber,
					Id = (item19.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item19.CompanyId <= 0)
				};
				list2.Add(item5);
			}
			break;
		}
		case 26:
		{
			LkCompanyInfoViewModelObjects shygunDetailedAPICompanyList = GetShygunDetailedAPICompanyList(fromRec, recCount, fromLinkAccCmpCode, toLinkAccCmpCode);
			if (shygunDetailedAPICompanyList == null)
			{
				break;
			}
			list = shygunDetailedAPICompanyList.lst;
			foreach (LkCompanyAndPersonViewModel item20 in list)
			{
				item20.cmpName = ((!string.IsNullOrWhiteSpace(item20.cmpName)) ? item20.cmpName : "");
				item20.cmpReferLName = ((!string.IsNullOrWhiteSpace(item20.cmpReferFName)) ? (item20.cmpReferFName + " ") : "") + ((!string.IsNullOrWhiteSpace(item20.cmpReferLName)) ? (item20.cmpReferLName + " ") : "");
				if (string.IsNullOrWhiteSpace(item20.cmpReferLName))
				{
					item20.cmpReferLName = item20.cmpReferLinkAccUserIdStr ?? item20.cmpReferLinkAccUserCode;
				}
				OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
				{
					Row = item20.RowNumber,
					Id = (item20.cmpLinkAccCustomerIdStr ?? "0"),
					Selected = (item20.CompanyId <= 0)
				};
				list2.Add(item3);
			}
			break;
		}
		}
		if (list == null)
		{
			list = new List<LkCompanyAndPersonViewModel>();
		}
		if (list != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list) && list2 != null && Enumerable.Any<OtherSystemSelectedVIiewModel>((IEnumerable<OtherSystemSelectedVIiewModel>)list2))
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
			if (Enumerable.Count<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list) >= num && list[num] != null)
			{
				list[num].ListItemRecords = listItemRecords;
			}
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageImportCompanyList(string records, int linkAccSystemId, string arpaUserGroupId = "", string mobileNo = "", string businessCode = "", string fromDate = "", string toDate = "", string cmpName = "", string cmpCode = "", string cmpNationalCode = "", int fromRec = 0, int recCount = 0, string cookieVal = "", int linkAccPageNum = 0, string fromLinkAccCmpCode = "", string toLinkAccCmpCode = "")
	{
		//IL_05cc: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedVIiewModel> list = new List<OtherSystemSelectedVIiewModel>();
		try
		{
			switch (linkAccSystemId)
			{
			case 12:
			{
				ArpaCompanyInfoViewModelObjects arpaCompanyList = GetArpaCompanyList(arpaUserGroupId, mobileNo, businessCode);
				if (arpaCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst8 = arpaCompanyList.lst;
				if (lst8 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item10 in lst8)
				{
					OtherSystemSelectedVIiewModel item8 = new OtherSystemSelectedVIiewModel
					{
						Row = item10.RowNumber,
						Id = (item10.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item10.CompanyId <= 0)
					};
					list.Add(item8);
				}
				break;
			}
			case 17:
			{
				HamrahanCompanyInfoViewModelObjects hamrahanCompanyList = GetHamrahanCompanyList();
				if (hamrahanCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst5 = hamrahanCompanyList.lst;
				if (lst5 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item11 in lst5)
				{
					OtherSystemSelectedVIiewModel item5 = new OtherSystemSelectedVIiewModel
					{
						Row = item11.RowNumber,
						Id = (item11.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item11.CompanyId <= 0)
					};
					list.Add(item5);
				}
				break;
			}
			case 18:
			{
				LkCompanyInfoViewModelObjects noAvaranCapillaryCompanyList = GetNoAvaranCapillaryCompanyList(cmpCode, cmpName, cmpNationalCode, fromDate, toDate);
				if (noAvaranCapillaryCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst9 = noAvaranCapillaryCompanyList.lst;
				if (lst9 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item12 in lst9)
				{
					OtherSystemSelectedVIiewModel item9 = new OtherSystemSelectedVIiewModel
					{
						Row = item12.RowNumber,
						Id = (item12.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item12.CompanyId <= 0)
					};
					list.Add(item9);
				}
				break;
			}
			case 19:
			{
				LkCompanyInfoViewModelObjects rahkaranRetailCompanyList = GetRahkaranRetailCompanyList(cookieVal, fromRec, recCount, cmpName, cmpNationalCode, mobileNo);
				if (rahkaranRetailCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst3 = rahkaranRetailCompanyList.lst;
				if (lst3 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item13 in lst3)
				{
					OtherSystemSelectedVIiewModel item3 = new OtherSystemSelectedVIiewModel
					{
						Row = item13.RowNumber,
						Id = (item13.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item13.CompanyId <= 0)
					};
					list.Add(item3);
				}
				break;
			}
			case 20:
			{
				LkCompanyInfoViewModelObjects nilramCompanyList = GetNilramCompanyList(fromDate, toDate);
				if (nilramCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst6 = nilramCompanyList.lst;
				if (lst6 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item14 in lst6)
				{
					OtherSystemSelectedVIiewModel item6 = new OtherSystemSelectedVIiewModel
					{
						Row = item14.RowNumber,
						Id = (item14.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item14.CompanyId <= 0)
					};
					list.Add(item6);
				}
				break;
			}
			case 22:
			{
				LkCompanyInfoViewModelObjects rahkaranInternalSalesCompanyList = GetRahkaranInternalSalesCompanyList(fromDate, toDate, 0L);
				if (rahkaranInternalSalesCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst2 = rahkaranInternalSalesCompanyList.lst;
				if (lst2 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item15 in lst2)
				{
					OtherSystemSelectedVIiewModel item2 = new OtherSystemSelectedVIiewModel
					{
						Row = item15.RowNumber,
						Id = (item15.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item15.CompanyId <= 0)
					};
					list.Add(item2);
				}
				break;
			}
			case 23:
			{
				LkCompanyInfoViewModelObjects rayvarzCompanyList = GetRayvarzCompanyList(fromDate, toDate, linkAccPageNum);
				if (rayvarzCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst7 = rayvarzCompanyList.lst;
				if (lst7 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item16 in lst7)
				{
					OtherSystemSelectedVIiewModel item7 = new OtherSystemSelectedVIiewModel
					{
						Row = item16.RowNumber,
						Id = (item16.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item16.CompanyId <= 0)
					};
					list.Add(item7);
				}
				break;
			}
			case 25:
			{
				LkCompanyInfoViewModelObjects arianSystemCompanyList = GetArianSystemCompanyList(recCount, linkAccPageNum, cmpName, cmpCode, cmpNationalCode, mobileNo);
				if (arianSystemCompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst4 = arianSystemCompanyList.lst;
				if (lst4 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item17 in lst4)
				{
					OtherSystemSelectedVIiewModel item4 = new OtherSystemSelectedVIiewModel
					{
						Row = item17.RowNumber,
						Id = (item17.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item17.CompanyId <= 0)
					};
					list.Add(item4);
				}
				break;
			}
			case 26:
			{
				LkCompanyInfoViewModelObjects shygunDetailedAPICompanyList = GetShygunDetailedAPICompanyList(fromRec, recCount, fromLinkAccCmpCode, toLinkAccCmpCode);
				if (shygunDetailedAPICompanyList == null)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst = shygunDetailedAPICompanyList.lst;
				if (lst == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item18 in lst)
				{
					OtherSystemSelectedVIiewModel item = new OtherSystemSelectedVIiewModel
					{
						Row = item18.RowNumber,
						Id = (item18.cmpLinkAccCustomerIdStr ?? "0"),
						Selected = (item18.CompanyId <= 0)
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
						foreach (OtherSystemSelectedVIiewModel item19 in list2)
						{
							foreach (OtherSystemSelectedVIiewModel item20 in list)
							{
								if (item20.Row == item19.Row)
								{
									item20.Selected = item19.Selected;
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actImportInfo")]
	[AjaxOnly]
	public JsonResult ManageCmpImportInfo(string records, int linkAccSystemId, int referUserId = 0, string arpaUserGroupId = "", string mobileNo = "", string businessCode = "", string fromDate = "", string toDate = "", string cmpName = "", string cmpCode = "", string cmpNationalCode = "", int fromRec = 0, int recCount = 0, string cookieVal = "", int linkAccPageNum = 0, string fromLinkAccCmpCode = "", string toLinkAccCmpCode = "")
	{
		//IL_00e4: Unknown result type (might be due to invalid IL or missing references)
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
			List<LkCompanyAndPersonViewModel> list3 = new List<LkCompanyAndPersonViewModel>();
			switch (linkAccSystemId)
			{
			case 12:
			{
				ArpaCompanyInfoViewModelObjects arpaCompanyList = GetArpaCompanyList(arpaUserGroupId, mobileNo, businessCode);
				if (arpaCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst8 = arpaCompanyList.lst;
					if (lst8 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst8))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item2 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel8 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst8, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item2.Id));
								if (lkCompanyAndPersonViewModel8 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel8);
								}
							}
						}
						else
						{
							string text23 = Messages.msgErrorRunFunction + " (get list from Apra) ";
							Exception e22 = new Exception(text23);
							ErrorSignal.FromCurrentContext().Raise(e22);
							text = text23;
						}
					}
					else
					{
						string text24 = Messages.msgErrorRunFunction + " (get list from Apra) ";
						Exception e23 = new Exception(text24);
						ErrorSignal.FromCurrentContext().Raise(e23);
						text = text24;
					}
				}
				else
				{
					string text25 = Messages.msgErrorRunFunction + " (get list from Apra) ";
					Exception e24 = new Exception(text25);
					ErrorSignal.FromCurrentContext().Raise(e24);
					text = text25;
				}
				break;
			}
			case 17:
			{
				HamrahanCompanyInfoViewModelObjects hamrahanCompanyList = GetHamrahanCompanyList();
				if (hamrahanCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst3 = hamrahanCompanyList.lst;
					if (lst3 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst3))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item7 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel3 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst3, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item7.Id));
								if (lkCompanyAndPersonViewModel3 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel3);
								}
							}
						}
						else
						{
							string text8 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
							Exception e7 = new Exception(text8);
							ErrorSignal.FromCurrentContext().Raise(e7);
							text = text8;
						}
					}
					else
					{
						string text9 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
						Exception e8 = new Exception(text9);
						ErrorSignal.FromCurrentContext().Raise(e8);
						text = text9;
					}
				}
				else
				{
					string text10 = Messages.msgErrorRunFunction + " (get list from Hamrahan) ";
					Exception e9 = new Exception(text10);
					ErrorSignal.FromCurrentContext().Raise(e9);
					text = text10;
				}
				break;
			}
			case 18:
			{
				LkCompanyInfoViewModelObjects noAvaranCapillaryCompanyList = GetNoAvaranCapillaryCompanyList(cmpCode, cmpName, cmpNationalCode, fromDate, toDate);
				if (noAvaranCapillaryCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst4 = noAvaranCapillaryCompanyList.lst;
					if (lst4 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst4))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item6 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel4 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst4, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item6.Id));
								if (lkCompanyAndPersonViewModel4 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel4);
								}
							}
						}
						else
						{
							string text11 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
							Exception e10 = new Exception(text11);
							ErrorSignal.FromCurrentContext().Raise(e10);
							text = text11;
						}
					}
					else
					{
						string text12 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
						Exception e11 = new Exception(text12);
						ErrorSignal.FromCurrentContext().Raise(e11);
						text = text12;
					}
				}
				else
				{
					string text13 = Messages.msgErrorRunFunction + " (get list from NoAvaran) ";
					Exception e12 = new Exception(text13);
					ErrorSignal.FromCurrentContext().Raise(e12);
					text = text13;
				}
				break;
			}
			case 19:
			{
				LkCompanyInfoViewModelObjects rahkaranRetailCompanyList = GetRahkaranRetailCompanyList(cookieVal, fromRec, recCount, cmpName, cmpNationalCode, mobileNo);
				if (rahkaranRetailCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst6 = rahkaranRetailCompanyList.lst;
					if (lst6 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst6))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item4 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel6 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst6, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item4.Id));
								if (lkCompanyAndPersonViewModel6 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel6);
								}
							}
						}
						else
						{
							string text17 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
							Exception e16 = new Exception(text17);
							ErrorSignal.FromCurrentContext().Raise(e16);
							text = text17;
						}
					}
					else
					{
						string text18 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
						Exception e17 = new Exception(text18);
						ErrorSignal.FromCurrentContext().Raise(e17);
						text = text18;
					}
				}
				else
				{
					string text19 = Messages.msgErrorRunFunction + " (get list from Rahkaran) ";
					Exception e18 = new Exception(text19);
					ErrorSignal.FromCurrentContext().Raise(e18);
					text = text19;
				}
				break;
			}
			case 20:
			{
				LkCompanyInfoViewModelObjects nilramCompanyList = GetNilramCompanyList(fromDate, toDate);
				if (nilramCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst7 = nilramCompanyList.lst;
					if (lst7 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst7))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item3 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel7 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst7, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item3.Id));
								if (lkCompanyAndPersonViewModel7 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel7);
								}
							}
						}
						else
						{
							string text20 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
							Exception e19 = new Exception(text20);
							ErrorSignal.FromCurrentContext().Raise(e19);
							text = text20;
						}
					}
					else
					{
						string text21 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
						Exception e20 = new Exception(text21);
						ErrorSignal.FromCurrentContext().Raise(e20);
						text = text21;
					}
				}
				else
				{
					string text22 = Messages.msgErrorRunFunction + " (get list from Nilram) ";
					Exception e21 = new Exception(text22);
					ErrorSignal.FromCurrentContext().Raise(e21);
					text = text22;
				}
				break;
			}
			case 22:
			{
				LkCompanyInfoViewModelObjects rahkaranInternalSalesCompanyList = GetRahkaranInternalSalesCompanyList(fromDate, toDate, 0L);
				if (rahkaranInternalSalesCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst5 = rahkaranInternalSalesCompanyList.lst;
					if (lst5 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst5))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item5 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel5 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst5, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item5.Id));
								if (lkCompanyAndPersonViewModel5 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel5);
								}
							}
						}
						else
						{
							string text14 = Messages.msgErrorRunFunction + " (get list from Rahkaran-InternalSales) ";
							Exception e13 = new Exception(text14);
							ErrorSignal.FromCurrentContext().Raise(e13);
							text = text14;
						}
					}
					else
					{
						string text15 = Messages.msgErrorRunFunction + " (get list from Rahkaran-InternalSales) ";
						Exception e14 = new Exception(text15);
						ErrorSignal.FromCurrentContext().Raise(e14);
						text = text15;
					}
				}
				else
				{
					string text16 = Messages.msgErrorRunFunction + " (get list from Rahkaran-InternalSales) ";
					Exception e15 = new Exception(text16);
					ErrorSignal.FromCurrentContext().Raise(e15);
					text = text16;
				}
				break;
			}
			case 23:
			{
				LkCompanyInfoViewModelObjects rayvarzCompanyList = GetRayvarzCompanyList(fromDate, toDate, linkAccPageNum);
				if (rayvarzCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst2 = rayvarzCompanyList.lst;
					if (lst2 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst2))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item8 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel2 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst2, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item8.Id));
								if (lkCompanyAndPersonViewModel2 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel2);
								}
							}
						}
						else
						{
							string text5 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
							Exception e4 = new Exception(text5);
							ErrorSignal.FromCurrentContext().Raise(e4);
							text = text5;
						}
					}
					else
					{
						string text6 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
						Exception e5 = new Exception(text6);
						ErrorSignal.FromCurrentContext().Raise(e5);
						text = text6;
					}
				}
				else
				{
					string text7 = Messages.msgErrorRunFunction + " (get list from Rayvarz) ";
					Exception e6 = new Exception(text7);
					ErrorSignal.FromCurrentContext().Raise(e6);
					text = text7;
				}
				break;
			}
			case 25:
			{
				LkCompanyInfoViewModelObjects arianSystemCompanyList = GetArianSystemCompanyList(recCount, linkAccPageNum, cmpName, cmpCode, cmpNationalCode, mobileNo);
				if (arianSystemCompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst9 = arianSystemCompanyList.lst;
					if (lst9 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst9))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel9 = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst9, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item.Id));
								if (lkCompanyAndPersonViewModel9 != null)
								{
									list3.Add(lkCompanyAndPersonViewModel9);
								}
							}
						}
						else
						{
							string text26 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
							Exception e25 = new Exception(text26);
							ErrorSignal.FromCurrentContext().Raise(e25);
							text = text26;
						}
					}
					else
					{
						string text27 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
						Exception e26 = new Exception(text27);
						ErrorSignal.FromCurrentContext().Raise(e26);
						text = text27;
					}
				}
				else
				{
					string text28 = Messages.msgErrorRunFunction + " (get list from ArianSystem) ";
					Exception e27 = new Exception(text28);
					ErrorSignal.FromCurrentContext().Raise(e27);
					text = text28;
				}
				break;
			}
			case 26:
			{
				LkCompanyInfoViewModelObjects shygunDetailedAPICompanyList = GetShygunDetailedAPICompanyList(fromRec, recCount, fromLinkAccCmpCode, toLinkAccCmpCode);
				if (shygunDetailedAPICompanyList != null)
				{
					List<LkCompanyAndPersonViewModel> lst = shygunDetailedAPICompanyList.lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst))
						{
							if (list2 == null)
							{
								break;
							}
							foreach (OtherSystemSelectedVIiewModel item9 in list2)
							{
								LkCompanyAndPersonViewModel lkCompanyAndPersonViewModel = Enumerable.FirstOrDefault<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst, (Func<LkCompanyAndPersonViewModel, bool>)((LkCompanyAndPersonViewModel x) => x.cmpLinkAccCustomerIdStr == item9.Id));
								if (lkCompanyAndPersonViewModel != null)
								{
									list3.Add(lkCompanyAndPersonViewModel);
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
					}
					else
					{
						string text3 = Messages.msgErrorRunFunction + " (get list from Shygun) ";
						Exception e2 = new Exception(text3);
						ErrorSignal.FromCurrentContext().Raise(e2);
						text = text3;
					}
				}
				else
				{
					string text4 = Messages.msgErrorRunFunction + " (get list from Shygun) ";
					Exception e3 = new Exception(text4);
					ErrorSignal.FromCurrentContext().Raise(e3);
					text = text4;
				}
				break;
			}
			}
			if (list3 != null && Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list3))
			{
				text = "";
				int num2;
				int num3 = (num2 = Enumerable.Count<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list3));
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
					List<LkCompanyAndPersonViewModel> list4 = new List<LkCompanyAndPersonViewModel>();
					for (int j = 0; j < num8; j++)
					{
						num7 = i * num4 + j;
						list4.Add(list3[num7]);
					}
					if (list4 == null || !Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)list4))
					{
						continue;
					}
					string cmpJson = JsonConvert.SerializeObject(list4);
					ObjectParameter objectParameter = new ObjectParameter("errorMessage", "");
					CRMLinkSpEntities dbLink = _dbLink;
					int? referUserId2 = referUserId;
					int? userId2 = userId;
					short? month = value2;
					int? fPId = id;
					short? year = result2;
					DateTime? registerDate = value;
					string appType2 = appType;
					dbLink.CRMspLkInsertUpdateCompanyByJson(cmpJson, referUserId2, userId2, fPId, year, month, registerDate, registerDatePersian, result, appType2, objectParameter, centerId);
					if (objectParameter.Value != null)
					{
						if (!string.IsNullOrWhiteSpace(objectParameter.Value.ToString()))
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
		}
		catch (Exception e28)
		{
			ErrorSignal.FromCurrentContext().Raise(e28);
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportShowInfo")]
	public ActionResult ManageExportCompany_Read([DataSourceRequest] DataSourceRequest request, string fDate = "", string tDate = "", string value = "", int currentItemId = 0, string records = "")
	{
		//IL_01cc: Unknown result type (might be due to invalid IL or missing references)
		List<CRMspLkSelectCompany_Result> list = new List<CRMspLkSelectCompany_Result>();
		List<OtherSystemSelectedViewModel> list2 = new List<OtherSystemSelectedViewModel>();
		OtherSystemSelectedViewModel item2 = new OtherSystemSelectedViewModel
		{
			Row = 0L,
			Id = 0,
			Selected = false
		};
		list2.Add(item2);
		try
		{
			list = Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value, currentItemId));
			if (list != null && Enumerable.Any<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list))
			{
				foreach (CRMspLkSelectCompany_Result item4 in list)
				{
					item4.cmpTel = item4.cmpPreTel + item4.cmpTel;
					item4.cmpTelII = item4.cmpPreTelII + item4.cmpTelII;
					item4.cmpAddress = item4.cmpCountry + "-" + item4.cmpProvince + "-" + item4.cmpCity + "-" + item4.cmpAddress;
					item4.PersonBirthDate = (item4.PersonBirthDateTime.HasValue ? item4.PersonBirthDateTime.Value.ToString("yyyy/MM/dd") : "");
					OtherSystemSelectedViewModel item3 = new OtherSystemSelectedViewModel
					{
						Row = item4.RowNumber.GetValueOrDefault(),
						Id = item4.CompanyID,
						Selected = string.IsNullOrWhiteSpace(item4.cmpLinkAccCustomerIdStr)
					};
					list2.Add(item3);
				}
			}
			if (list == null)
			{
				list = new List<CRMspLkSelectCompany_Result>();
			}
			if (list != null && Enumerable.Any<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list) && list2 != null && Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2))
			{
				if (!string.IsNullOrWhiteSpace(records))
				{
					List<OtherSystemSelectedViewModel> list3 = new List<OtherSystemSelectedViewModel>();
					list3 = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
					if (list3 != null && Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list3))
					{
						foreach (OtherSystemSelectedViewModel item in list3)
						{
							if (Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Row == item.Row)) != null)
							{
								Enumerable.FirstOrDefault<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Row == item.Row)).Selected = item.Selected;
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
				string listItemRecords = JsonConvert.SerializeObject(Enumerable.ToList<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2));
				if (Enumerable.Count<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)list) >= num && list[num] != null)
				{
					list[num].ListItemRecords = listItemRecords;
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetManageExportCompanyList(string records, string fDate = "", string tDate = "", string value = "", int currentItemId = 0)
	{
		//IL_0094: Unknown result type (might be due to invalid IL or missing references)
		List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
		try
		{
			foreach (CRMspLkSelectCompany_Result item2 in Enumerable.ToList<CRMspLkSelectCompany_Result>((IEnumerable<CRMspLkSelectCompany_Result>)GetCompanyList(fDate, tDate, value, currentItemId)))
			{
				OtherSystemSelectedViewModel item = new OtherSystemSelectedViewModel
				{
					Row = item2.RowNumber.GetValueOrDefault(),
					Id = item2.CompanyID,
					Selected = string.IsNullOrWhiteSpace(item2.cmpLinkAccCustomerIdStr)
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

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actExportInfo")]
	[AjaxOnly]
	public string ManageCmpExportInfo(string records, string cookieVal = "", int cmpType = 0, bool isExportCustomer = false, int benefiCmpId = 0, int zoneId = 0, int routeId = 0, int currentItemId = 0)
	{
		//IL_00ea: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		int data = 0;
		string text = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		try
		{
			DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(Financial.Get().Id.ToString());
			short.Parse(DateTime.Now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			int userId = UserLogin.CurrentUser.UserId;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			text = "";
			int num = 0;
			List<OtherSystemSelectedViewModel> list = new List<OtherSystemSelectedViewModel>();
			if (!string.IsNullOrWhiteSpace(records))
			{
				list = new JavaScriptSerializer().Deserialize<List<OtherSystemSelectedViewModel>>(records);
			}
			int result3 = 0;
			CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
			if (cRMspSelectCrmsysSetting_Result != null)
			{
				int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
			}
			CRMIdeal.Classes.Helper.Setting.GetLinkAccSystemTitle();
			text = "";
			if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list))
			{
				List<OtherSystemSelectedViewModel> list2 = Enumerable.ToList<OtherSystemSelectedViewModel>(Enumerable.Where<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list, (Func<OtherSystemSelectedViewModel, bool>)((OtherSystemSelectedViewModel m) => m.Selected && m.Id > 0)));
				if (Enumerable.Any<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2) && list2 != null)
				{
					num = Enumerable.Count<OtherSystemSelectedViewModel>((IEnumerable<OtherSystemSelectedViewModel>)list2);
					int num2 = 0;
					List<AdvanceResultViewModel> list3 = new List<AdvanceResultViewModel>();
					dynamic val = null;
					foreach (OtherSystemSelectedViewModel item in list2)
					{
						string text2 = "";
						switch (result3)
						{
						case 12:
							text2 = ArpaActCmpSendToAcc(item.Id);
							break;
						case 17:
							text2 = HamrahanActCmpSendToAcc(item.Id);
							break;
						case 18:
							text2 = NoAvaranCapillaryActCmpSendToAcc(item.Id, benefiCmpId, zoneId, routeId, cmpType);
							break;
						case 19:
							text2 = RahkaranRetailActCmpSendToAcc(item.Id, cookieVal, cmpType, isExportCustomer);
							break;
						case 20:
							text2 = NilramActCmpSendToAcc(item.Id);
							break;
						case 21:
						{
							if (_003C_003Eo__191._003C_003Ep__1 == null)
							{
								_003C_003Eo__191._003C_003Ep__1 = CallSite<Func<CallSite, object, bool>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.UnaryOperation(CSharpBinderFlags.None, (ExpressionType)83, typeof(CompanyController), new CSharpArgumentInfo[1] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							Func<CallSite, object, bool> target = _003C_003Eo__191._003C_003Ep__1.Target;
							CallSite<Func<CallSite, object, bool>> _003C_003Ep__ = _003C_003Eo__191._003C_003Ep__1;
							if (_003C_003Eo__191._003C_003Ep__0 == null)
							{
								_003C_003Eo__191._003C_003Ep__0 = CallSite<Func<CallSite, object, object, object>>.Create(Microsoft.CSharp.RuntimeBinder.Binder.BinaryOperation(CSharpBinderFlags.None, (ExpressionType)13, typeof(CompanyController), new CSharpArgumentInfo[2]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							if (target((CallSite)(object)_003C_003Ep__, _003C_003Eo__191._003C_003Ep__0.Target((CallSite)(object)_003C_003Eo__191._003C_003Ep__0, (object)val, null)))
							{
								val = new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider(true);
							}
							list3.AddRange(new CRMIdeal.Classes.Helper.OtherSystems.HamyarProvider.SendCompany(item.Id, val).GetFullResult(result2));
							break;
						}
						case 22:
							text2 = RahkaranInternalSalesActCmpSendToAcc(item.Id, cmpType, isExportCustomer);
							break;
						case 23:
							text2 = RayvarzActCmpSendToAcc(item.Id);
							break;
						case 25:
							text2 = ArianSystemActCmpSendToAcc(item.Id);
							break;
						case 26:
							text2 = ShygunDetailedAPIActCmpSendToAcc(item.Id);
							break;
						}
						if (result3 == 21)
						{
							continue;
						}
						if (!string.IsNullOrEmpty(text2))
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
					if (list3.Count > 0)
					{
						text = JsonConvert.SerializeObject(list3);
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
				return JsonConvert.SerializeObject(new CommonResultViewModel<int>
				{
					Data = data,
					Message = text,
					Status = CommonResultStatusViewModel.Error
				});
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = 0;
			return JsonConvert.SerializeObject(new CommonResultViewModel<int>
			{
				Data = data,
				Message = Messages.FOMsgErrorDoneOperation,
				Status = CommonResultStatusViewModel.Error
			});
		}
		return JsonConvert.SerializeObject(new CommonResultViewModel<int>
		{
			Data = data,
			Message = text,
			Status = status
		});
	}

	[DynamicAuthorize(ControllerName = "frmManageCmpLinkAcc", ActionName = "actLinkCmpWithAcc")]
	public ActionResult LinkedCompanyLinkAcc(int linkAccSystemId)
	{
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[HttpPost]
	public JsonResult ActLinkedCompanyAcc(string syncField, int mode, string cookieVal = "")
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
			List<LinkedCompanyWithAccViewModel> list = new List<LinkedCompanyWithAccViewModel>();
			DateTime now = DateTime.Now;
			now.ToString("yyyyMMdd", new PersianCulture());
			short.Parse(now.ToString("MM", new PersianCulture()));
			_ = Configuration.AppType;
			short.Parse(Financial.Get().Id.ToString());
			_ = UserLogin.CurrentUser.UserId;
			string text3 = "";
			int num = 0;
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actLinkCmpWithAcc", UserLogin.CurrentUser))
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
				bool flag2 = true;
				List<SelectListItem> arpaUserGroupList = GetArpaUserGroupList();
				if (arpaUserGroupList != null)
				{
					if (Enumerable.Any<SelectListItem>((IEnumerable<SelectListItem>)arpaUserGroupList))
					{
						foreach (SelectListItem item13 in arpaUserGroupList)
						{
							if (string.IsNullOrWhiteSpace(item13.Value))
							{
								continue;
							}
							List<LkCompanyAndPersonViewModel> lst2 = GetArpaCompanyList(item13.Value, "", "", getBaseInfoLinkAcc: false).lst;
							if (lst2 != null)
							{
								foreach (LkCompanyAndPersonViewModel item in lst2)
								{
									bool flag3 = true;
									if (list != null && Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list))
									{
										LinkedCompanyWithAccViewModel linkedCompanyWithAccViewModel = Enumerable.FirstOrDefault<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list, (Func<LinkedCompanyWithAccViewModel, bool>)((LinkedCompanyWithAccViewModel m) => (m.cmpLinkAccCode ?? "") == (item.cmpLinkAccCode ?? "") && (m.cmpLinkAccCustomerIdStr ?? "") == (item.cmpLinkAccCustomerIdStr ?? "")));
										if (linkedCompanyWithAccViewModel != null && !string.IsNullOrWhiteSpace(linkedCompanyWithAccViewModel.cmpLinkAccCustomerIdStr))
										{
											flag3 = false;
										}
									}
									if (flag3)
									{
										LinkedCompanyWithAccViewModel item3 = new LinkedCompanyWithAccViewModel
										{
											cmpLinkAccCode = item.cmpLinkAccCode,
											cmpLinkAccCodeId = 0,
											cmpLinkAccCustomerId = 0,
											cmpLinkAccCustomerIdStr = item.cmpLinkAccCustomerIdStr,
											cmpName = (item.cmpName ?? "")
										};
										list.Add(item3);
									}
								}
							}
							Thread.Sleep(500);
						}
					}
					else
					{
						flag2 = false;
					}
				}
				else
				{
					flag2 = false;
				}
				if (flag2)
				{
					break;
				}
				List<LkCompanyAndPersonViewModel> lst3 = GetArpaCompanyList("", "", "", getBaseInfoLinkAcc: false).lst;
				if (lst3 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item14 in lst3)
				{
					LinkedCompanyWithAccViewModel item4 = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item14.cmpLinkAccCode,
						cmpLinkAccCodeId = 0,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item14.cmpLinkAccCustomerIdStr,
						cmpName = (item14.cmpName ?? "")
					};
					list.Add(item4);
				}
				break;
			}
			case 17:
			{
				List<LkCompanyAndPersonViewModel> lst7 = GetHamrahanCompanyList().lst;
				if (lst7 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item15 in lst7)
				{
					LinkedCompanyWithAccViewModel item8 = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item15.cmpLinkAccCode,
						cmpLinkAccCodeId = item15.cmpLinkAccCodeId,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item15.cmpLinkAccCustomerIdStr,
						cmpName = (item15.cmpName ?? "")
					};
					list.Add(item8);
				}
				break;
			}
			case 18:
			{
				List<LkCompanyAndPersonViewModel> lst9 = GetNoAvaranCapillaryCompanyList().lst;
				if (lst9 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item16 in lst9)
				{
					LinkedCompanyWithAccViewModel item10 = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item16.cmpLinkAccCode,
						cmpLinkAccCodeId = item16.cmpLinkAccCodeId,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item16.cmpLinkAccCustomerIdStr,
						cmpName = (item16.cmpName ?? "")
					};
					list.Add(item10);
				}
				break;
			}
			case 19:
			{
				List<LkCompanyAndPersonViewModel> lst5 = GetRahkaranRetailAllCompanyList(cookieVal).lst;
				if (lst5 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item17 in lst5)
				{
					LinkedCompanyWithAccViewModel item6 = new LinkedCompanyWithAccViewModel
					{
						cmpLinkAccCode = item17.cmpLinkAccCode,
						cmpLinkAccCodeId = item17.cmpLinkAccCodeId,
						cmpLinkAccCustomerId = 0,
						cmpLinkAccCustomerIdStr = item17.cmpLinkAccCustomerIdStr,
						cmpName = (item17.cmpName ?? "")
					};
					list.Add(item6);
				}
				break;
			}
			case 20:
			{
				bool flag6 = true;
				DateTime dateTime = DateTime.Parse("1921/03/21", new CultureInfo("en-US"));
				DateTime dateTime2 = dateTime.AddYears(1);
				string text5 = "";
				string text6 = "";
				while (flag6)
				{
					switch (lCID)
					{
					case 1065:
						text5 = dateTime.ToString("yyyy/MM/dd", new PersianCulture());
						text6 = dateTime2.ToString("yyyy/MM/dd", new PersianCulture());
						break;
					case 1025:
						text5 = dateTime.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
						text6 = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
						break;
					default:
						text5 = dateTime.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						text6 = dateTime2.ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						break;
					}
					List<LkCompanyAndPersonViewModel> lst10 = GetNilramCompanyList(text5, text6).lst;
					if (lst10 != null)
					{
						foreach (LkCompanyAndPersonViewModel item18 in lst10)
						{
							LinkedCompanyWithAccViewModel item11 = new LinkedCompanyWithAccViewModel
							{
								cmpLinkAccCode = item18.cmpLinkAccCode,
								cmpLinkAccCodeId = item18.cmpLinkAccCodeId,
								cmpLinkAccCustomerId = 0,
								cmpLinkAccCustomerIdStr = item18.cmpLinkAccCustomerIdStr,
								cmpName = (item18.cmpName ?? "")
							};
							list.Add(item11);
						}
					}
					if (long.Parse(dateTime2.ToString("yyyyMMdd")) == long.Parse(DateTime.Now.ToString("yyyyMMdd")))
					{
						flag6 = false;
					}
					dateTime = dateTime2;
					dateTime2 = dateTime.AddYears(1);
					if (dateTime2 >= DateTime.Now)
					{
						dateTime2 = DateTime.Now;
					}
				}
				break;
			}
			case 22:
			{
				syncField = "cmpNationalCode,prsMobile";
				List<LkCompanyAndPersonViewModel> lst8 = GetRahkaranInternalSalesCompanyList("", "", 0L).lst;
				if (lst8 == null)
				{
					break;
				}
				foreach (LkCompanyAndPersonViewModel item19 in lst8)
				{
					LinkedCompanyWithAccViewModel linkedCompanyWithAccViewModel2 = new LinkedCompanyWithAccViewModel();
					linkedCompanyWithAccViewModel2.cmpLinkAccCode = item19.cmpLinkAccCode;
					linkedCompanyWithAccViewModel2.cmpLinkAccCodeId = item19.cmpLinkAccCodeId;
					linkedCompanyWithAccViewModel2.cmpLinkAccCustomerId = 0;
					linkedCompanyWithAccViewModel2.cmpLinkAccCustomerIdStr = item19.cmpLinkAccCustomerIdStr;
					linkedCompanyWithAccViewModel2.cmpName = ((!string.IsNullOrWhiteSpace(item19.cmpName)) ? item19.cmpName : "") + ((!string.IsNullOrWhiteSpace(item19.prsFName) || !string.IsNullOrWhiteSpace(item19.prsLName)) ? (((!string.IsNullOrWhiteSpace(item19.cmpName)) ? "(" : "") + item19.prsFName + " " + item19.prsLName + ((!string.IsNullOrWhiteSpace(item19.cmpName)) ? ")" : "")) : "");
					linkedCompanyWithAccViewModel2.cmpKind = item19.cmpKind.GetValueOrDefault();
					linkedCompanyWithAccViewModel2.cmpNationalCode = item19.cmpNationalCode ?? "";
					linkedCompanyWithAccViewModel2.prsMobile = item19.prsMobile ?? "";
					linkedCompanyWithAccViewModel2.cmpCode = item19.cmpCode;
					LinkedCompanyWithAccViewModel item9 = linkedCompanyWithAccViewModel2;
					list.Add(item9);
				}
				break;
			}
			case 23:
			{
				bool flag5 = true;
				int num5 = 0;
				while (flag5)
				{
					List<LkCompanyAndPersonViewModel> lst6 = GetRayvarzCompanyList("", "", num5).lst;
					if (lst6 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst6))
						{
							foreach (LkCompanyAndPersonViewModel item20 in lst6)
							{
								LinkedCompanyWithAccViewModel linkedCompanyWithAccViewModel2 = new LinkedCompanyWithAccViewModel();
								linkedCompanyWithAccViewModel2.cmpLinkAccCode = item20.cmpLinkAccCode;
								linkedCompanyWithAccViewModel2.cmpLinkAccCodeId = item20.cmpLinkAccCodeId;
								linkedCompanyWithAccViewModel2.cmpLinkAccCustomerId = 0;
								linkedCompanyWithAccViewModel2.cmpLinkAccCustomerIdStr = item20.cmpLinkAccCustomerIdStr;
								linkedCompanyWithAccViewModel2.cmpName = ((!string.IsNullOrWhiteSpace(item20.cmpName)) ? item20.cmpName : "") + ((!string.IsNullOrWhiteSpace(item20.prsFName) || !string.IsNullOrWhiteSpace(item20.prsLName)) ? (((!string.IsNullOrWhiteSpace(item20.cmpName)) ? "(" : "") + item20.prsFName + " " + item20.prsLName + ((!string.IsNullOrWhiteSpace(item20.cmpName)) ? ")" : "")) : "");
								linkedCompanyWithAccViewModel2.cmpKind = item20.cmpKind.GetValueOrDefault();
								linkedCompanyWithAccViewModel2.cmpNationalCode = item20.cmpNationalCode ?? "";
								linkedCompanyWithAccViewModel2.prsMobile = item20.prsMobile ?? "";
								linkedCompanyWithAccViewModel2.cmpCode = item20.cmpCode;
								linkedCompanyWithAccViewModel2.cmpLinkAccData = item20.cmpLinkAccData;
								LinkedCompanyWithAccViewModel item7 = linkedCompanyWithAccViewModel2;
								list.Add(item7);
							}
							num5++;
						}
						else
						{
							flag5 = false;
						}
					}
					else
					{
						flag5 = false;
					}
				}
				break;
			}
			case 25:
			{
				bool flag4 = true;
				int num4 = 1;
				while (flag4)
				{
					List<LkCompanyAndPersonViewModel> lst4 = GetArianSystemCompanyList(5000, num4).lst;
					if (lst4 != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst4))
						{
							foreach (LkCompanyAndPersonViewModel item21 in lst4)
							{
								LinkedCompanyWithAccViewModel linkedCompanyWithAccViewModel2 = new LinkedCompanyWithAccViewModel();
								linkedCompanyWithAccViewModel2.cmpLinkAccCode = item21.cmpLinkAccCode;
								linkedCompanyWithAccViewModel2.cmpLinkAccCodeId = item21.cmpLinkAccCodeId;
								linkedCompanyWithAccViewModel2.cmpLinkAccCustomerId = 0;
								linkedCompanyWithAccViewModel2.cmpLinkAccCustomerIdStr = item21.cmpLinkAccCustomerIdStr;
								linkedCompanyWithAccViewModel2.cmpName = ((!string.IsNullOrWhiteSpace(item21.cmpName)) ? item21.cmpName : "") + ((!string.IsNullOrWhiteSpace(item21.prsFName) || !string.IsNullOrWhiteSpace(item21.prsLName)) ? (((!string.IsNullOrWhiteSpace(item21.cmpName)) ? "(" : "") + item21.prsFName + " " + item21.prsLName + ((!string.IsNullOrWhiteSpace(item21.cmpName)) ? ")" : "")) : "");
								linkedCompanyWithAccViewModel2.cmpKind = item21.cmpKind.GetValueOrDefault();
								linkedCompanyWithAccViewModel2.cmpNationalCode = item21.cmpNationalCode ?? "";
								linkedCompanyWithAccViewModel2.prsMobile = item21.prsMobile ?? "";
								linkedCompanyWithAccViewModel2.cmpCode = item21.cmpCode;
								linkedCompanyWithAccViewModel2.cmpLinkAccData = item21.cmpLinkAccData;
								LinkedCompanyWithAccViewModel item5 = linkedCompanyWithAccViewModel2;
								list.Add(item5);
							}
							num4++;
						}
						else
						{
							flag4 = false;
						}
					}
					else
					{
						flag4 = false;
					}
				}
				break;
			}
			case 26:
			{
				bool flag = true;
				int fromRec = 0;
				int num2 = 1;
				while (flag)
				{
					int num3 = 100;
					List<LkCompanyAndPersonViewModel> lst = GetShygunDetailedAPICompanyList(fromRec, num3).lst;
					if (lst != null)
					{
						if (Enumerable.Any<LkCompanyAndPersonViewModel>((IEnumerable<LkCompanyAndPersonViewModel>)lst))
						{
							foreach (LkCompanyAndPersonViewModel item22 in lst)
							{
								LinkedCompanyWithAccViewModel item2 = new LinkedCompanyWithAccViewModel
								{
									cmpLinkAccCode = item22.cmpLinkAccCode,
									cmpLinkAccCodeId = item22.cmpLinkAccCodeId,
									cmpLinkAccCustomerId = 0,
									cmpLinkAccCustomerIdStr = item22.cmpLinkAccCustomerIdStr,
									cmpName = ((!string.IsNullOrWhiteSpace(item22.cmpName)) ? item22.cmpName : ""),
									cmpKind = item22.cmpKind.GetValueOrDefault(),
									cmpNationalCode = (item22.cmpNationalCode ?? ""),
									prsMobile = (item22.prsMobile ?? ""),
									cmpCode = item22.cmpCode,
									cmpLinkAccData = item22.cmpLinkAccData
								};
								list.Add(item2);
							}
							fromRec = num3 * num2;
							num2++;
						}
						else
						{
							flag = false;
						}
					}
					else
					{
						flag = false;
					}
				}
				break;
			}
			}
			if (list == null || !Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list))
			{
				text3 = string.Format(Messages.msgErrorListCmpInLinkAccIsEmpty, text4) + "<br>";
				num++;
			}
			if (num == 0)
			{
				string text7 = "";
				text = "";
				List<CRMspLkLinkedCompany_Result> list2 = new List<CRMspLkLinkedCompany_Result>();
				int count = list.Count;
				int num6 = 1000;
				int num7 = count / num6;
				if (count % num6 != 0)
				{
					num7++;
				}
				for (int i = 0; i <= num7; i++)
				{
					List<LinkedCompanyWithAccViewModel> list3 = new List<LinkedCompanyWithAccViewModel>();
					for (int j = i * num6; j < i * num6 + num6 && j < count; j++)
					{
						LinkedCompanyWithAccViewModel item12 = new LinkedCompanyWithAccViewModel
						{
							cmpLinkAccCode = list[j].cmpLinkAccCode,
							cmpLinkAccCodeId = list[j].cmpLinkAccCodeId,
							cmpLinkAccCustomerId = 0,
							cmpLinkAccCustomerIdStr = list[j].cmpLinkAccCustomerIdStr,
							cmpName = list[j].cmpName,
							cmpKind = list[j].cmpKind.GetValueOrDefault(),
							cmpNationalCode = (list[j].cmpNationalCode ?? ""),
							prsMobile = (list[j].prsMobile ?? ""),
							cmpCode = list[j].cmpCode,
							cmpLinkAccData = list[j].cmpLinkAccData
						};
						list3.Add(item12);
					}
					if (Enumerable.Any<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list3))
					{
						string itemJson = JsonConvert.SerializeObject(Enumerable.ToList<LinkedCompanyWithAccViewModel>((IEnumerable<LinkedCompanyWithAccViewModel>)list3));
						List<CRMspLkLinkedCompany_Result> list4 = Enumerable.ToList<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)_dbLink.CRMspLkLinkedCompany(result2, itemJson, syncField, mode, lCID, result));
						if (list4 != null && Enumerable.Any<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)list4))
						{
							list2.AddRange(list4);
						}
					}
				}
				if (list2 != null && Enumerable.Any<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)list2))
				{
					list2 = Enumerable.ToList<CRMspLkLinkedCompany_Result>(Enumerable.Distinct<CRMspLkLinkedCompany_Result>(Enumerable.Where<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)list2, (Func<CRMspLkLinkedCompany_Result, bool>)((CRMspLkLinkedCompany_Result m) => (m.cmpLinkAccCustomerIdStr ?? "") == "" || m.Type.GetValueOrDefault() == 1))));
					if (list2 != null && Enumerable.Any<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)list2))
					{
						text = "error";
						text7 = GetFileLinkedCompanyAcc(list2);
					}
				}
				if (!string.IsNullOrWhiteSpace(text7))
				{
					text2 = Messages.msgNotCompeleteSuccessAction;
					text2 = text2 + "<br><a href='" + text7 + "' class='link-excel-file' target='_blank'>" + Messages.msgLinkForDownloadFileWithError + "</a>";
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

	public string GetFileLinkedCompanyAcc(List<CRMspLkLinkedCompany_Result> res)
	{
		//IL_058e: Unknown result type (might be due to invalid IL or missing references)
		//IL_05a9: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkLinkedCompany_Result>((IEnumerable<CRMspLkLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListNationalCode;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListMobile;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkAccName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNationalCode ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.prsMobile ?? "";
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
						value2 = Messages.msgErrorCmpNotInCRM;
						break;
					case -1:
						value2 = Messages.msgErrorDupCmpLinkAccCode;
						break;
					case -2:
						value2 = Messages.msgErrorDupCmpCode;
						break;
					case -3:
						value2 = string.Format(Messages.msgErrorCmpNotInLinkAcc, text2);
						break;
					case -4:
						value2 = Messages.msgErrorDupCmpLinkAccNationalCode;
						break;
					case -5:
						value2 = Messages.msgErrorDupCmpLinkAccMobile;
						break;
					case -6:
						value2 = Messages.msgErrorDupCmpNationalCode;
						break;
					case -7:
						value2 = Messages.msgErrorDupPrsMobile;
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
	public JsonResult DeleteCmpImportedInfo(string records)
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
			if (!UserLogin.IsUserAccess("frmManageCmpLinkAcc", "actDeleteImportedInfo", UserLogin.CurrentUser))
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
				List<CRMspLkDeleteLinkedCompany_Result> list3 = Enumerable.ToList<CRMspLkDeleteLinkedCompany_Result>((IEnumerable<CRMspLkDeleteLinkedCompany_Result>)_dbLink.CRMspLkDeleteLinkedCompany(result2, text4, lCID, result));
				if (list3 != null && Enumerable.Any<CRMspLkDeleteLinkedCompany_Result>((IEnumerable<CRMspLkDeleteLinkedCompany_Result>)list3))
				{
					text = "error";
					text5 = GetFileNotDeletedCmpImportedInfo(list3);
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

	public string GetFileNotDeletedCmpImportedInfo(List<CRMspLkDeleteLinkedCompany_Result> res)
	{
		//IL_037a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0395: Unknown result type (might be due to invalid IL or missing references)
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
			if (res != null && Enumerable.Any<CRMspLkDeleteLinkedCompany_Result>((IEnumerable<CRMspLkDeleteLinkedCompany_Result>)res))
			{
				ExcelPackage excelPackage = new ExcelPackage();
				ExcelWorksheet excelWorksheet = excelPackage.Workbook.Worksheets.Add(Labels.OtherSystemsExcelPropertiesTitle);
				int num = 0;
				int num2 = 1;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsLinkedListCmpName;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpNumber;
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListCmpLinkAccCode + " (" + text2 + ")";
				num++;
				excelWorksheet.Cells[num2, num].Value = Labels.OtherSystemsListLinkDesc;
				foreach (CRMspLkDeleteLinkedCompany_Result re in res)
				{
					num2++;
					num = 0;
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpName ?? "";
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpNumber.GetValueOrDefault().ToString();
					num++;
					excelWorksheet.Cells[num2, num].Value = re.cmpLinkAccCode ?? "";
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
	public string LinkAccCmpAccountingDetail(int linkAccSystemId, int cmpId, ref decimal remainAccount, ref decimal linkAccDebitBalance, ref decimal linkAccCreditBalance, int linkAccSettingDBId = 0)
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
			decimal remainAccount2 = default(decimal);
			switch (linkAccSystemId)
			{
			case 8:
				result = ShygunCmpAccountingDetail(cmpId, ref remainAccount2, ref linkAccDebitBalance, ref linkAccCreditBalance);
				break;
			case 1:
				result = SepGetCmpAccountingDetail(cmpId, ref remainAccount2, ref linkAccDebitBalance, ref linkAccCreditBalance, linkAccSettingDBId);
				break;
			case 12:
				result = ArpaCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 15:
				result = LinkAccByViewGetCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 17:
				result = HamrahanCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 18:
				result = NoAvaranCapillaryCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 20:
				result = NilramCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 22:
				result = RahkaranInternalSalesCmpAccountingDetail(cmpId, ref remainAccount2);
				break;
			case 23:
				result = RayvarzCmpAccountingDetail(cmpId, ref remainAccount2, ref linkAccDebitBalance, ref linkAccCreditBalance);
				break;
			case 26:
				result = ShygunDetailedAPICmpAccountingDetail(cmpId, ref remainAccount2, ref linkAccDebitBalance, ref linkAccCreditBalance);
				break;
			}
			remainAccount = remainAccount2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			result = Labels.frmError;
		}
		return result;
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actManageCmpLinkAcc")]
	public ActionResult ShowLinkAccCmpAccountingDetail(int linkAccSystemId)
	{
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCmpFromOtherSystem")]
	public ActionResult PreviewContent(int cmpId, int linkAccSystemId)
	{
		string text = "";
		if (linkAccSystemId == 24)
		{
			text = new CRMIdeal.Classes.Helper.OtherSystems.KaramadProvider.Company(cmpId).GetInfoHtmlUrl();
		}
		base.ViewBag.OtherSystemUrl = text;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCmpFromOtherSystem")]
	public ActionResult ShowCmpFromOtherSystem(int cmpId, int linkAccSystemId)
	{
		base.ViewBag.LinkAccSystemId = linkAccSystemId;
		base.ViewBag.CmpId = cmpId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCmpFromOtherSystem")]
	[AjaxOnly]
	public JsonResult GetCmpFromOtherSystem(int cmpId, int linkAccSystemId)
	{
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		if (linkAccSystemId == 24)
		{
			data = new CRMIdeal.Classes.Helper.OtherSystems.KaramadProvider.Company(cmpId).GetInfoHtmlUrl();
			status = CommonResultStatusViewModel.Success;
		}
		CommonResultViewModel<string> data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[DynamicAuthorize(ControllerName = "frmCompanyI", ActionName = "actShowCmpFromOtherSystem")]
	[AjaxOnly]
	public JsonResult GetCmpFromOtherSystem_Old(int cmpId, int linkAccSystemId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			string text = "";
			_ = 24;
			if (!string.IsNullOrWhiteSpace(text))
			{
				string[] array = text.Split(new string[1] { "@|@" }, StringSplitOptions.None);
				if (array != null)
				{
					if (array.Length >= 2)
					{
						string text2 = array[0];
						if (text2 == "1")
						{
							message = Messages.msgSuccessAction;
							data = array[1];
							status = CommonResultStatusViewModel.Success;
						}
						else
						{
							if (string.IsNullOrWhiteSpace(text2))
							{
								text2 = Messages.ErrorNotFound;
							}
							data = "";
							status = CommonResultStatusViewModel.Fail;
							message = text2;
						}
					}
					else
					{
						string text3 = "";
						if (array.Length == 1)
						{
							text3 = array[0];
						}
						if (string.IsNullOrWhiteSpace(text3))
						{
							text3 = Messages.ErrorNotFound;
						}
						data = "";
						status = CommonResultStatusViewModel.Fail;
						message = text3;
					}
				}
			}
			else
			{
				data = "";
				status = CommonResultStatusViewModel.Fail;
				message = Messages.ErrorNotFound;
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			data = "";
			data2 = new CommonResultViewModel<string>
			{
				Data = data,
				Message = Messages.msgErrorRunFunction,
				Status = CommonResultStatusViewModel.Error
			};
			return Json(data2, JsonRequestBehavior.AllowGet);
		}
		data2 = new CommonResultViewModel<string>
		{
			Data = data,
			Message = message,
			Status = status
		};
		return Json(data2, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public string LinkAccGetCmpCredit(int linkAccSystemId, int linkAccSettingDBId, int cmpId, ref decimal creditAccount)
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
			decimal creditAccount2 = default(decimal);
			text = ((linkAccSystemId != 12) ? "no_credit_in-sysacc" : ArpaGetCmpCredit(cmpId, ref creditAccount2));
			creditAccount = creditAccount2;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
			text = Labels.frmError;
		}
		return text;
	}

	public List<CRMspSelectCompanyWithAccLinkField_Result> SelectCompanyWithAccLinkField(bool withLinkAccCode = false, bool withLinkAccCodeId = false, bool withLinkCustomerId = false, bool withLinkCustomerIdStr = false)
	{
		List<CRMspSelectCompanyWithAccLinkField_Result> result = new List<CRMspSelectCompanyWithAccLinkField_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectCompanyWithAccLinkField_Result>((IEnumerable<CRMspSelectCompanyWithAccLinkField_Result>)_dbLink.CRMspSelectCompanyWithAccLinkField(withLinkAccCode, withLinkAccCodeId, withLinkCustomerId, withLinkCustomerIdStr, lCID, result2, null));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetCmpLinkAccSetting(int linkAccSystemId, int linkAccSettingDBId, int linkAccSettingId, string objectType, string partTitle)
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
		_dbI.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
