using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.ChartCompanyCampaignCountWithCmpRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class ChartCompanyCampaignCountWithCmpController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _db_spI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _db_spII = new CRMSpIIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	public ActionResult Index()
	{
		List<CRMspSelectCompanyCampaign_Result> list = new List<CRMspSelectCompanyCampaign_Result>();
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectCompanyCampaign_Result> list2 = Enumerable.ToList<CRMspSelectCompanyCampaign_Result>((IEnumerable<CRMspSelectCompanyCampaign_Result>)_db_spI.CRMspSelectCompanyCampaign(lCID, result));
		if (list2 != null)
		{
			list = list2;
		}
		base.ViewBag.CampList = list;
		return View();
	}

	public ActionResult Print(string model, string fileName)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		ChartCompanyCampaignCountWithCmpViewModel value = new ChartCompanyCampaignCountWithCmpViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<ChartCompanyCampaignCountWithCmpViewModel>(model);
		}
		base.TempData["model"] = value;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_01be: Unknown result type (might be due to invalid IL or missing references)
		//IL_01dc: Unknown result type (might be due to invalid IL or missing references)
		//IL_01e3: Expected O, but got Unknown
		//IL_020e: Unknown result type (might be due to invalid IL or missing references)
		StiReport stiReport = new StiReport();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int result2 = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result2);
				base.TempData["PFCId"] = null;
			}
			ChartCompanyCampaignCountWithCmpViewModel chartCompanyCampaignCountWithCmpViewModel = new ChartCompanyCampaignCountWithCmpViewModel();
			if (base.TempData["model"] != null)
			{
				chartCompanyCampaignCountWithCmpViewModel = (ChartCompanyCampaignCountWithCmpViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			_ = Labels.Unspecify;
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
			parameters.NotUsed_ChartCompanyCampaignCountWithCmp = new List<CRMspRpt_ChartCompanyCampaignCountWithCmp_Result>();
			List<CRMspRpt_ChartCompanyCampaignCountWithCmp_Result> list = Enumerable.ToList<CRMspRpt_ChartCompanyCampaignCountWithCmp_Result>((IEnumerable<CRMspRpt_ChartCompanyCampaignCountWithCmp_Result>)_db_spII.CRMspRpt_ChartCompanyCampaignCountWithCmp(chartCompanyCampaignCountWithCmpViewModel.CampIds, lCID, result));
			if (list != null)
			{
				parameters.NotUsed_ChartCompanyCampaignCountWithCmp = list;
			}
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "ChartCmpCampaignCountWithCmp.xsd");
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
}
