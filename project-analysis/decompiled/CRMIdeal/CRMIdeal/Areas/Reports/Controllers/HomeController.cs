using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.Models;
using CRM.Models.ReportModel;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class HomeController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private static string _pathReportDatasets = "";

	private static string _pathReportFiles = "";

	private static Dictionary<string, string> _getInfo;

	private static string _methodName = "";

	private static Dictionary<string, string> GetInfo => _getInfo;

	public ActionResult Index()
	{
		_getInfo = new Dictionary<string, string>();
		if (base.HttpContext.Request["rtp"] != null)
		{
			base.TempData["MethodName"] = base.HttpContext.Request["rtp"];
			for (int i = 0; i < ((NameObjectCollectionBase)base.HttpContext.Request.QueryString).Count; i++)
			{
				if (!base.HttpContext.Request.QueryString.AllKeys[i].Contains("rtp"))
				{
					string[] array = new string[2]
					{
						base.HttpContext.Request.QueryString.AllKeys[i],
						base.HttpContext.Request.QueryString[i]
					};
					_getInfo.Add(array[0], array[1]);
				}
			}
		}
		return View();
	}

	public ActionResult Designer()
	{
		_pathReportFiles = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		_pathReportDatasets = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		_getInfo = new Dictionary<string, string>();
		if (base.HttpContext.Request["rtp"] != null)
		{
			base.TempData["MethodName"] = base.HttpContext.Request["rtp"];
			for (int i = 0; i < ((NameObjectCollectionBase)base.HttpContext.Request.QueryString).Count; i++)
			{
				if (!base.HttpContext.Request.QueryString.AllKeys[i].Contains("rtp"))
				{
					string[] array = new string[2]
					{
						base.HttpContext.Request.QueryString.AllKeys[i],
						base.HttpContext.Request.QueryString[i]
					};
					_getInfo.Add(array[0], array[1]);
				}
			}
		}
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		base.Dispose(disposing);
	}

	public ActionResult GetReportSnapshot()
	{
		StiReport report = new StiReport();
		try
		{
			int result = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result);
				base.TempData["PFCId"] = null;
			}
			_pathReportDatasets = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			_pathReportFiles = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			if (base.TempData["MethodName"] != null && (string)base.TempData["MethodName"] != "" && GetInfo != null && GetInfo.Count > 0)
			{
				report = (StiReport)GetType().GetMethod((string)base.TempData["MethodName"]).Invoke(this, new object[1] { GetInfo });
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return StiMvcViewer.GetReportResult(report);
	}

	public ActionResult ViewerEvent()
	{
		return StiMvcViewer.ViewerEventResult();
	}

	public StiReport SampleReport(Dictionary<string, string> info)
	{
		//IL_0039: Unknown result type (might be due to invalid IL or missing references)
		//IL_0052: Unknown result type (might be due to invalid IL or missing references)
		//IL_0059: Expected O, but got Unknown
		//IL_0090: Unknown result type (might be due to invalid IL or missing references)
		SampleRpt sampleRpt = new SampleRpt();
		sampleRpt.ReporterUserName = "مهدی آدابی فر";
		sampleRpt.ReportDateTime = DateTime.Now;
		int.TryParse(info["cmpId"], out var _);
		XmlSerializer val = new XmlSerializer(typeof(SampleRpt));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)sampleRpt);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(_pathReportDatasets + MethodBase.GetCurrentMethod().Name + ".xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		stiReport.Load(_pathReportFiles + MethodBase.GetCurrentMethod().Name + ".mrt");
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		StiOptions.Engine.DefaultPaperSize = (PaperKind)9;
		return stiReport;
	}

	public ActionResult GetReportSnapshotDesigner()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		SampleRpt sampleRpt = new SampleRpt();
		sampleRpt.ReporterUserName = "مهدی آدابی فر";
		sampleRpt.ReportDateTime = DateTime.Now;
		int.TryParse("6020", out var _);
		XmlSerializer val = new XmlSerializer(typeof(SampleRpt));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)sampleRpt);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(_pathReportDatasets + "SampleReport.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		stiReport.Load(_pathReportFiles + "SampleReport.mrt");
		stiReport.Compile();
		stiReport.RegData(val3);
		return StiMvcDesigner.GetReportResult(stiReport);
	}

	public ActionResult GetReportTemplate()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		SampleRpt sampleRpt = new SampleRpt();
		sampleRpt.ReporterUserName = "مهدی آدابی فر";
		sampleRpt.ReportDateTime = DateTime.Now;
		int.TryParse("6020", out var _);
		XmlSerializer val = new XmlSerializer(typeof(SampleRpt));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)sampleRpt);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(_pathReportDatasets + "SampleReport.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		stiReport.Load(_pathReportFiles + "SampleReport.mrt");
		stiReport.Compile();
		stiReport.RegData(val3);
		return StiMvcDesigner.GetReportTemplateResult(base.HttpContext, stiReport);
	}

	public ActionResult OpenReportTemplate()
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		//IL_004c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0053: Expected O, but got Unknown
		//IL_0080: Unknown result type (might be due to invalid IL or missing references)
		SampleRpt sampleRpt = new SampleRpt();
		sampleRpt.ReporterUserName = "مهدی آدابی فر";
		sampleRpt.ReportDateTime = DateTime.Now;
		int.TryParse("6020", out var _);
		XmlSerializer val = new XmlSerializer(typeof(SampleRpt));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)sampleRpt);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(_pathReportDatasets + "SampleReport.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		return StiMvcDesigner.OpenReportTemplateResult(base.HttpContext, val3);
	}

	public ActionResult SaveReportTemplate()
	{
		StiReport reportObject = StiMvcDesigner.GetReportObject(base.HttpContext);
		reportObject.Save(_pathReportFiles + reportObject.ReportName + ".mrt");
		return StiMvcDesigner.SaveReportTemplateResult(base.HttpContext);
	}

	public ActionResult GetNewReportData()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		DataSet val = new DataSet();
		val.ReadXmlSchema(base.Server.MapPath("~/Content/Data/Demo.xsd"));
		val.ReadXml(base.Server.MapPath("~/Content/Data/Demo.xml"));
		return StiMvcDesigner.GetNewReportDataResult(base.HttpContext, val);
	}

	public ActionResult DesignerEvent()
	{
		return StiMvcDesigner.DesignerEventResult(base.HttpContext);
	}
}
