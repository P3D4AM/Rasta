using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
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
using CRM.Models.ReportModel.CallCountInGroupPrintRpt;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Stimulsoft.Report;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class CallCountInGroupController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCallCountInGroup")]
	public ActionResult Index()
	{
		GetUserList();
		CallCountInGroupViewModel callCountInGroupViewModel = new CallCountInGroupViewModel();
		DateTime now = DateTime.Now;
		string fromDate = (callCountInGroupViewModel.ToDate = now.ToString("yyyy/MM/dd"));
		callCountInGroupViewModel.FromDate = fromDate;
		return View(callCountInGroupViewModel);
	}

	[HttpPost]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCallCountInGroup")]
	[ValidateAntiForgeryToken]
	public ActionResult Index(CallCountInGroupViewModel model)
	{
		try
		{
			if (!base.ModelState.IsValid)
			{
				base.ViewBag.Error = string.Join("<br/> ", Enumerable.Select<ModelError, string>(Enumerable.SelectMany<ModelState, ModelError>((IEnumerable<ModelState>)base.ModelState.Values, (Func<ModelState, IEnumerable<ModelError>>)((ModelState x) => x.Errors)), (Func<ModelError, string>)((ModelError x) => x.ErrorMessage)));
			}
			else
			{
				base.TempData["model"] = model;
				base.ViewBag.Successfull = "ok";
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			base.ViewBag.Error = Messages.frmErrorMessage + "<br/>" + ex2.Message;
		}
		GetUserList();
		return View(model);
	}

	[AjaxOnly]
	public JsonResult GetUserList(int? id = null)
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
			string allUsers = Labels.AllUsers;
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (!id.HasValue)
			{
				id = UserLogin.CurrentUser.UserId;
			}
			List<CRMspSelectUsersWithAllForRepParam_Result> list2 = Enumerable.ToList<CRMspSelectUsersWithAllForRepParam_Result>((IEnumerable<CRMspSelectUsersWithAllForRepParam_Result>)_db.CRMspSelectUsersWithAllForRepParam(id, 2, lCID, result, allUsers, result2));
			list.AddRange(Enumerable.Select<CRMspSelectUsersWithAllForRepParam_Result, SelectListItem>((IEnumerable<CRMspSelectUsersWithAllForRepParam_Result>)list2, (Func<CRMspSelectUsersWithAllForRepParam_Result, SelectListItem>)((CRMspSelectUsersWithAllForRepParam_Result item) => new SelectListItem
			{
				Text = item.UserName,
				Value = item.UserId.ToString(),
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

	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actrptCallCountInGroup")]
	public ActionResult Print(string model, string fileName)
	{
		//IL_00eb: Unknown result type (might be due to invalid IL or missing references)
		base.ViewBag.FileName = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		CallCountInGroupViewModel value = new CallCountInGroupViewModel();
		if (model != "")
		{
			value = new JavaScriptSerializer().Deserialize<CallCountInGroupViewModel>(model);
		}
		base.TempData["model"] = value;
		base.TempData["FileName"] = fileName;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		//IL_03f4: Unknown result type (might be due to invalid IL or missing references)
		//IL_0412: Unknown result type (might be due to invalid IL or missing references)
		//IL_0419: Expected O, but got Unknown
		//IL_0444: Unknown result type (might be due to invalid IL or missing references)
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
			string notSpecified = Labels.NotSpecified;
			CallCountInGroupViewModel callCountInGroupViewModel = new CallCountInGroupViewModel();
			if (base.TempData["model"] != null)
			{
				callCountInGroupViewModel = (CallCountInGroupViewModel)base.TempData["model"];
			}
			base.TempData["model"] = null;
			Parameters parameters = new Parameters();
			parameters.Parameter1 = callCountInGroupViewModel.FromDate;
			parameters.Parameter2 = callCountInGroupViewModel.ToDate;
			callCountInGroupViewModel.ToDate = callCountInGroupViewModel.ToDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			callCountInGroupViewModel.FromDate = callCountInGroupViewModel.FromDate.Replace("/", "").Replace("-", "").Replace("\\", "")
				.Replace(" ", "")
				.Replace("_", "");
			DateTime value = DateTime.Now;
			DateTime value2 = DateTime.Now;
			if (!string.IsNullOrEmpty(callCountInGroupViewModel.FromDate))
			{
				value = DateTime.Parse(PersianDate.GetFormatetdDate(callCountInGroupViewModel.FromDate.Replace("/", "")) + " 00:00:00", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			if (!string.IsNullOrEmpty(callCountInGroupViewModel.ToDate))
			{
				value2 = DateTime.Parse(PersianDate.GetFormatetdDate(callCountInGroupViewModel.ToDate.Replace("/", "")) + " 23:59:59", lCID switch
				{
					1025 => new CultureInfo("ar-SA"), 
					1065 => new PersianCulture(), 
					_ => new CultureInfo("en-US"), 
				});
			}
			string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
			string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
			string text3 = base.TempData["FileName"].ToString();
			base.TempData["FileName"] = null;
			DateTime now = DateTime.Now;
			int result3 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result3);
			}
			CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
			parameters.SysSetting = reports.GetSysSetting();
			byte[] coLoGo = SysSeting.Get().CoLoGo;
			if (coLoGo != null && coLoGo.Length != 0)
			{
				parameters.CoLogo = Convert.ToBase64String(coLoGo);
			}
			parameters.ReportDateTime = now;
			parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
			parameters.NotUsed_ListCallCountInGroup = Enumerable.ToList<CRMspRpt_CallCountInGroup_Result>((IEnumerable<CRMspRpt_CallCountInGroup_Result>)_db.CRMspRpt_CallCountInGroup(UserLogin.CurrentUser.UserId, now.ToString("yyyy/MM/dd HH:mm:ss"), DateTimeClass.DefineDayeOfWeekFa(now.DayOfWeek.ToString()), callCountInGroupViewModel.FromDate, callCountInGroupViewModel.ToDate, callCountInGroupViewModel.UserId, value, value2, lCID, result, notSpecified, result3));
			XmlSerializer val = new XmlSerializer(typeof(Parameters));
			StringWriter stringWriter = new StringWriter();
			XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
			val.Serialize(val2, (object)parameters);
			DataSet val3 = new DataSet();
			val3.ReadXmlSchema(text + "CallCountInGroupPrint.xsd");
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
		base.Dispose(disposing);
	}
}
