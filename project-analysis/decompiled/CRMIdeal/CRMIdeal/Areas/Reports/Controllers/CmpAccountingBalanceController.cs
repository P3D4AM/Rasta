using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.CmpAccountingBalancePrintRpt;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class CmpAccountingBalanceController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpAccountingBalance")]
	public ActionResult Index()
	{
		return View();
	}

	[AjaxOnly]
	public JsonResult SearchCompany(string text = "", int searchType = 1)
	{
		List<CRMspMainSearchWeb_Result> list = new List<CRMspMainSearchWeb_Result>();
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
			if (!string.IsNullOrWhiteSpace(text))
			{
				string searchConditionMode = "";
				if (searchType == 1)
				{
					searchConditionMode = ",1000,1,2,3,8,9,11,12,14,17,20,21,22,";
				}
				list = Enumerable.ToList<CRMspMainSearchWeb_Result>(Enumerable.Take<CRMspMainSearchWeb_Result>((IEnumerable<CRMspMainSearchWeb_Result>)_dbI.CRMspMainSearchWeb(text, UserLogin.CurrentUser.UserId, searchType, lCID, result, searchConditionMode, result2), 800));
				foreach (CRMspMainSearchWeb_Result item in list)
				{
					item.cnvsDesc = item.cmpNameWithTitle + "|" + item.cmpNumber.GetValueOrDefault() + "|" + item.cmpPreTel + "|" + item.cmpTel + "|" + item.cmpPreTelII + "|" + item.cmpTelII + "|" + item.cmpMobile + "|" + item.cmpFax + "|" + item.cmpAddress + "|" + item.PrsName + "|" + item.prsTel + "|" + item.prsTelII + "|" + item.prsMobile + "|" + item.prsFax + "|" + item.prsNationalCode + "|" + item.cmpNationalCode + "|";
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

	public List<CRMspRpt_CmpAccountingBalance_Result> GetList(int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspRpt_CmpAccountingBalance_Result> list = new List<CRMspRpt_CmpAccountingBalance_Result>();
		try
		{
			int userId = UserLogin.CurrentUser.UserId;
			DateTime now = DateTime.Now;
			string rptDate = now.ToString("yyyy/MM/dd HH:mm:ss");
			string rptDay = DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString());
			if (cmpId != 0)
			{
				list = Enumerable.ToList<CRMspRpt_CmpAccountingBalance_Result>((IEnumerable<CRMspRpt_CmpAccountingBalance_Result>)_dbII.CRMspRpt_CmpAccountingBalance(cmpId, now, userId, rptDate, rptDay, lCID, result));
			}
			if (list == null)
			{
				list = new List<CRMspRpt_CmpAccountingBalance_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	public ActionResult ResultList_Read([DataSourceRequest] DataSourceRequest request, int cmpId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspRpt_CmpAccountingBalance_Result> enumerable = new List<CRMspRpt_CmpAccountingBalance_Result>();
		try
		{
			enumerable = GetList(cmpId);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCmpAccountingBalance")]
	public ActionResult Print(string fileName, int cmpId = 0)
	{
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		base.TempData["FileName"] = fileName;
		base.TempData["CmpId"] = cmpId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_0188: Unknown result type (might be due to invalid IL or missing references)
		//IL_01a6: Unknown result type (might be due to invalid IL or missing references)
		//IL_01ad: Expected O, but got Unknown
		//IL_01d7: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = base.TempData["FileName"].ToString();
			base.TempData["FileName"] = null;
			int result2 = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result2);
				base.TempData["PFCId"] = null;
			}
			int result3 = 0;
			int.TryParse(base.TempData["CmpId"].ToString(), out result3);
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
			parameters.NotUsed_ListCRMspRpt_CmpAccountingBalance = new List<CRMspRpt_CmpAccountingBalance_Result>();
			parameters.NotUsed_ListCRMspRpt_CmpAccountingBalance = GetList(result3);
			if (parameters.NotUsed_ListCRMspRpt_CmpAccountingBalance == null)
			{
				parameters.NotUsed_ListCRMspRpt_CmpAccountingBalance = new List<CRMspRpt_CmpAccountingBalance_Result>();
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CmpAccountingBalancePrint.xsd");
			XElement val4 = XElement.Parse(stringWriter.ToString());
			val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
			if (result2 != 0 && !string.IsNullOrWhiteSpace(text2))
			{
				if (!text2.EndsWith("/"))
				{
					text2 += "/";
				}
				text2 = text2 + result2 + "/";
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
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
