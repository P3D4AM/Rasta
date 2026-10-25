using System.Data;
using System.Web.Mvc;
using CRMIdeal.Classes;
using Stimulsoft.Report;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class DesignerController : Controller
{
	private static string _pathReportDatasets = "";

	private static string _pathReportFiles = "";

	public string PathReportDatasets
	{
		get
		{
			if (_pathReportDatasets != "")
			{
				return _pathReportDatasets;
			}
			_pathReportDatasets = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			return _pathReportDatasets;
		}
	}

	public string PathReportFiles
	{
		get
		{
			if (_pathReportFiles != "")
			{
				return _pathReportFiles;
			}
			_pathReportFiles = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			return _pathReportFiles;
		}
	}

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actReporter")]
	public ActionResult Index()
	{
		return View();
	}

	public ActionResult GetReportTemplate()
	{
		string text = "";
		if (base.Request.UrlReferrer != null)
		{
			text = base.Request.UrlReferrer.Query.Replace("?rpt=", "");
		}
		if (text == "")
		{
			text = "SampleReport";
		}
		StiReport stiReport = new StiReport();
		int result = 0;
		string text2 = "";
		if (base.Request.UrlReferrer != null)
		{
			int.TryParse(base.Request.UrlReferrer.Query.Replace("&pfCId=", ""), out result);
			if (result != 0)
			{
				text2 = "/" + result;
			}
		}
		string path = PathReportFiles + text2 + text + ".mrt";
		stiReport.Load(path);
		return StiMvcDesigner.GetReportResult(stiReport);
	}

	public ActionResult DesignerEvent()
	{
		return StiMvcDesigner.DesignerEventResult(base.HttpContext);
	}

	public ActionResult SaveReportTemplate()
	{
		string text = "";
		if (base.Request.UrlReferrer != null)
		{
			text = base.Request.UrlReferrer.Query.Replace("?rpt=", "");
		}
		int result = 0;
		string text2 = "";
		if (base.Request.UrlReferrer != null)
		{
			int.TryParse(base.Request.UrlReferrer.Query.Replace("&pfCId=", ""), out result);
			if (result != 0)
			{
				text2 = "/" + result;
			}
		}
		string path = PathReportFiles + text2 + text + ".mrt";
		StiMvcDesigner.GetReportObject(base.HttpContext).Save(path);
		return StiMvcDesigner.SaveReportTemplateResult(base.HttpContext);
	}

	public ActionResult EmptyGetReportTemplate()
	{
		string text = "";
		if (base.Request.UrlReferrer != null)
		{
			text = base.Request.UrlReferrer.Query.Replace("?rpt=", "");
		}
		if (text == "")
		{
			text = "SampleReport";
		}
		StiReport stiReport = new StiReport();
		int result = 0;
		string text2 = "";
		if (base.Request.UrlReferrer != null)
		{
			int.TryParse(base.Request.UrlReferrer.Query.Replace("&pfCId=", ""), out result);
			if (result != 0)
			{
				text2 = "/" + result;
			}
		}
		string path = PathReportFiles + text2 + text + ".mrt";
		stiReport.Load(path);
		return StiMvcDesigner.GetReportResult(stiReport);
	}

	public ActionResult EmptyDesignerEvent()
	{
		return StiMvcDesigner.DesignerEventResult(base.HttpContext);
	}

	public ActionResult EmptyOpenReportTemplate()
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0006: Expected O, but got Unknown
		DataSet data = new DataSet();
		return StiMvcDesigner.OpenReportTemplateResult(base.HttpContext, data);
	}

	public ActionResult EmptySaveReportTemplate()
	{
		StiReport reportObject = StiMvcDesigner.GetReportObject(base.HttpContext);
		int result = 0;
		string text = "";
		if (base.Request.UrlReferrer != null)
		{
			int.TryParse(base.Request.UrlReferrer.Query.Replace("&pfCId=", ""), out result);
			if (result != 0)
			{
				text = "/" + result;
			}
		}
		string path = PathReportFiles + text + reportObject.ReportName + ".mrt";
		reportObject.Save(path);
		return StiMvcDesigner.SaveReportTemplateResult(base.HttpContext);
	}
}
