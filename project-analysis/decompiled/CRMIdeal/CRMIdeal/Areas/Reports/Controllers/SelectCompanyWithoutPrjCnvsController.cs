using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.SelectCompanyWithoutPrjCnvsRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class SelectCompanyWithoutPrjCnvsController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptSelectCompanyWithoutPrjCnvs")]
	public ActionResult Index()
	{
		SelectCompanyWithoutPrjCnvsViewModel selectCompanyWithoutPrjCnvsViewModel = new SelectCompanyWithoutPrjCnvsViewModel();
		DateTime now = DateTime.Now;
		string fromDate = (selectCompanyWithoutPrjCnvsViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		selectCompanyWithoutPrjCnvsViewModel.FromDate = fromDate;
		selectCompanyWithoutPrjCnvsViewModel.Type = 0;
		return View(selectCompanyWithoutPrjCnvsViewModel);
	}

	public ActionResult SearchList_Read([DataSourceRequest] DataSourceRequest request, string modelObj)
	{
		//IL_0006: Unknown result type (might be due to invalid IL or missing references)
		List<CRMspSelectCompanyWithoutPrjCnvs_Result> enumerable = new List<CRMspSelectCompanyWithoutPrjCnvs_Result>();
		try
		{
			SelectCompanyWithoutPrjCnvsViewModel model = new JavaScriptSerializer().Deserialize<SelectCompanyWithoutPrjCnvsViewModel>(modelObj);
			enumerable = GetSelectCompany(model);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspSelectCompanyWithoutPrjCnvs_Result> GetSelectCompany(SelectCompanyWithoutPrjCnvsViewModel model)
	{
		List<CRMspSelectCompanyWithoutPrjCnvs_Result> list = new List<CRMspSelectCompanyWithoutPrjCnvs_Result>();
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
			model.ToDate = model.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			model.FromDate = model.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(model.FromDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(model.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(model.ToDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(model.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			_ = DateTime.Now;
			list = Enumerable.ToList<CRMspSelectCompanyWithoutPrjCnvs_Result>((IEnumerable<CRMspSelectCompanyWithoutPrjCnvs_Result>)_db.CRMspSelectCompanyWithoutPrjCnvs(model.FromDate, model.ToDate, UserLogin.CurrentUser.UserId, model.Type, value, value2, lCID, result, result2));
			foreach (CRMspSelectCompanyWithoutPrjCnvs_Result item in list)
			{
				item.Importdate = ((!string.IsNullOrEmpty(item.Importdate) && lCID != 1065) ? PersianDate.GetShamsi2Miladi(item.Importdate.Replace("/", "")).Replace("/", "") : item.Importdate);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[HttpPost]
	[LoginAuthorize]
	[AjaxOnly]
	public ActionResult FillSmsTempNumber(string fDate = "", string tDate = "", int type = 0, int sendMode = 0)
	{
		int? count = 0;
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
			tDate = tDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			fDate = fDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
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
			DateTime.Now.DayOfWeek.ToString();
			string firstRegisterDatePersian = DateTime.Now.ToString("yyyyMMdd", new PersianCulture());
			string appType = Configuration.AppType;
			count = Enumerable.FirstOrDefault<int?>((IEnumerable<int?>)_dbII.CRMspFillSmsTempNumberInCompanyWithoutPrjCnvs(UserLogin.CurrentUser.UserId, fDate, tDate, type, value, value2, lCID, result, result2, firstRegisterDatePersian, DateTime.Now, appType, sendMode));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new { count });
	}

	[DynamicAuthorize(ControllerName = "frmcmpprsCalenderEvent", ActionName = "actPrint")]
	public ActionResult Print(string modelObj, string fileName)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		try
		{
			SelectCompanyWithoutPrjCnvsViewModel value = new JavaScriptSerializer().Deserialize<SelectCompanyWithoutPrjCnvsViewModel>(modelObj);
			base.TempData["model"] = value;
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_021b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0239: Unknown result type (might be due to invalid IL or missing references)
		//IL_0240: Expected O, but got Unknown
		//IL_026a: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			int result = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result);
				base.TempData["PFCId"] = null;
			}
			SelectCompanyWithoutPrjCnvsViewModel selectCompanyWithoutPrjCnvsViewModel = new SelectCompanyWithoutPrjCnvsViewModel();
			if (base.TempData["model"] != null)
			{
				selectCompanyWithoutPrjCnvsViewModel = (SelectCompanyWithoutPrjCnvsViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = base.TempData["FileName"].ToString();
			base.TempData["FileName"] = null;
			DateTime now = DateTime.Now;
			Parameters parameters = new Parameters();
			CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
			parameters.SysSetting = reports.GetSysSetting();
			byte[] coLoGo = SysSeting.Get().CoLoGo;
			if (coLoGo != null && coLoGo.Length != 0)
			{
				parameters.CoLogo = Convert.ToBase64String(coLoGo);
			}
			parameters.ReportDateTime = now;
			parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
			parameters.NotUsed_ListCompanyWithoutPrjCnvs = GetSelectCompany(selectCompanyWithoutPrjCnvsViewModel);
			parameters.Parameter1 = Labels.ReportCustomersWithoutProject;
			if (selectCompanyWithoutPrjCnvsViewModel.Type == 1)
			{
				parameters.Parameter1 = Labels.ReportCustomersWithoutConversation;
			}
			parameters.Parameter2 = selectCompanyWithoutPrjCnvsViewModel.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			parameters.Parameter3 = selectCompanyWithoutPrjCnvsViewModel.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "SelectCompanyWithoutPrjCnvsPrint.xsd");
			XElement val4 = XElement.Parse(stringWriter.ToString());
			val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
			if (result != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result + "/";
			}
			stiReport.Load(text2 + text3);
			string text4 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
			text4 = text4.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
			text4 = text4.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
			text4 = text4.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
			text4 = text4.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
			((CollectionBase)stiReport.Dictionary.Databases).Clear();
			stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text4));
			stiReport.Compile();
			stiReport.RegData(val3);
			stiReport.Render();
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return StiMvcViewer.GetReportResult(stiReport);
	}

	public ActionResult ViewerEvent()
	{
		return StiMvcViewer.ViewerEventResult();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}
}
