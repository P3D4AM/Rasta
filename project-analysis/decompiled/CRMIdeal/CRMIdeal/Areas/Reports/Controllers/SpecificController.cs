using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using CRM.General.Calendar;
using CRM.General.IO;
using CRM.General.Security;
using CRM.Models;
using CRM.Models.ReportModel.BuyOrderPrintRpt;
using CRM.Models.ReportModel.DailyLeavePrintRpt;
using CRM.Models.ReportModel.DailyMissionPrintRpt;
using CRM.Models.ReportModel.DocPrintRpt;
using CRM.Models.ReportModel.DraftPrintRpt;
using CRM.Models.ReportModel.HourlyLeavePrintRpt;
using CRM.Models.ReportModel.HourlyMissionPrintRpt;
using CRM.Models.ReportModel.OrderPrintRpt;
using CRM.Models.ReportModel.PreOrderPrintRpt;
using CRM.Models.ReportModel.PrintDyFormRpt;
using CRM.Models.ReportModel.PrintPayRollUserCycleRpt;
using CRM.Models.ReportModel.SendLetterPrintRpt;
using CRM.Models.ReportModel.StockSupplyPrintRpt;
using CRM.Models.ReportModel.WarehouseMovementPrintRpt;
using CRM.Resources;
using CRMIdeal.Areas.OtherSystems.Controllers;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using Stimulsoft.Report;
using Stimulsoft.Report.Components;
using Stimulsoft.Report.Dictionary;
using Stimulsoft.Report.Export;
using Stimulsoft.Report.Mvc;

namespace CRMIdeal.Areas.Reports.Controllers;

public class SpecificController : Controller
{
	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass7_0
	{
		public int id;
	}

	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIEntities _dbII = new CRMSpIIEntities();

	[LoginAuthorize]
	public ActionResult Order(int id, string st = "", int? pfid = null, string formName = null, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		if (string.IsNullOrEmpty(formName))
		{
			formName = "frmOrder";
		}
		if (formName == "frmOrder" && !UserLogin.IsUserAccess(formName, "actPrintOrder"))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.TempData["CmpRemainAccLink"] = cmpRemainAccLink;
		base.ViewBag.CmpRemainAccLink = cmpRemainAccLink;
		base.TempData["CmpRemainAccLinkjs"] = cmpRemainAccLinkjs;
		base.ViewBag.CmpRemainAccLinkjs = cmpRemainAccLinkjs;
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["OrderId"] = id;
		base.ViewBag.CurrId = id;
		string text2 = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text2 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text2 != null && !text2.ToLower().EndsWith(".mrt"))
				{
					text2 += ".mrt";
				}
			}
			if (id != 0)
			{
				PrintLog.InsertPrintLog(id, 2, 1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (text2 == null)
		{
			text2 = "";
		}
		base.ViewBag.FileName = text2;
		base.TempData["FileName"] = text2;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text2);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmPreOrder", ActionName = "actPrintPreOrder")]
	public ActionResult PreOrder(int id, string st = "", int? pfid = null, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		base.TempData["CmpRemainAccLink"] = cmpRemainAccLink;
		base.ViewBag.CmpRemainAccLink = cmpRemainAccLink;
		base.TempData["CmpRemainAccLinkjs"] = cmpRemainAccLinkjs;
		base.ViewBag.CmpRemainAccLinkjs = cmpRemainAccLinkjs;
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["PreOrderId"] = id;
		base.ViewBag.CurrId = id;
		string text2 = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text2 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text2 != null && !text2.ToLower().EndsWith(".mrt"))
				{
					text2 += ".mrt";
				}
			}
			if (id != 0)
			{
				PrintLog.InsertPrintLog(id, 1, 1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (text2 == null)
		{
			text2 = "";
		}
		base.ViewBag.FileName = text2;
		base.TempData["FileName"] = text2;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text2);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[LoginAuthorize]
	public ActionResult BuyOrder(int id, string st = "", int? pfid = null, string formName = null)
	{
		if (string.IsNullOrEmpty(formName))
		{
			formName = "frmBuyOrder";
		}
		if (formName == "frmBuyOrder" && !UserLogin.IsUserAccess(formName, "actPrintBuyOrder"))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["BuyOrderId"] = id;
		base.ViewBag.CurrId = id;
		string text2 = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text2 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text2 != null && !text2.ToLower().EndsWith(".mrt"))
				{
					text2 += ".mrt";
				}
			}
			if (id != 0)
			{
				PrintLog.InsertPrintLog(id, 5, 1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (text2 == null)
		{
			text2 = "";
		}
		base.ViewBag.FileName = text2;
		base.TempData["FileName"] = text2;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text2);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmSendLetters", ActionName = "actPrintLetter")]
	public ActionResult SendLetter(int id, string st = "", int? pfid = null)
	{
		_003C_003Ec__DisplayClass7_0 _003C_003Ec__DisplayClass7_ = new _003C_003Ec__DisplayClass7_0();
		_003C_003Ec__DisplayClass7_.id = id;
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		try
		{
			DbSet<SecLetters> secLetters = _dbTbl.SecLetters;
			ParameterExpression val = Expression.Parameter(typeof(SecLetters), "m");
			SecLetters secLetters2 = Queryable.FirstOrDefault<SecLetters>((IQueryable<SecLetters>)secLetters, Expression.Lambda<Func<SecLetters, bool>>((Expression)(object)Expression.Equal((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Field((Expression)(object)Expression.Constant((object)_003C_003Ec__DisplayClass7_, typeof(_003C_003Ec__DisplayClass7_0)), FieldInfo.GetFieldFromHandle((RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
			if (secLetters2 != null)
			{
				DateTime now = DateTime.Now;
				secLetters2.LetterLastPrintDate = now.ToString("yyyyMMdd", new PersianCulture());
				secLetters2.LetterLastPrintDateTime = now;
				secLetters2.LetterLastPrintTime = now.ToString("HH:mm:ss");
				_dbTbl.Entry(secLetters2).State = EntityState.Modified;
				_dbTbl.Configuration.ValidateOnSaveEnabled = false;
				_dbTbl.SaveChanges();
				_dbTbl.Configuration.ValidateOnSaveEnabled = true;
				if (_003C_003Ec__DisplayClass7_.id != 0)
				{
					PrintLog.InsertPrintLog(_003C_003Ec__DisplayClass7_.id, 6, 1);
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
		base.TempData["SendLetterId"] = _003C_003Ec__DisplayClass7_.id;
		base.ViewBag.CurrId = _003C_003Ec__DisplayClass7_.id;
		string text2 = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text2 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text2 != null && !text2.ToLower().EndsWith(".mrt"))
				{
					text2 += ".mrt";
				}
			}
		}
		catch (Exception e3)
		{
			ErrorSignal.FromCurrentContext().Raise(e3);
		}
		if (text2 == null)
		{
			text2 = "";
		}
		base.ViewBag.FileName = text2;
		base.TempData["FileName"] = text2;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text2);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDoc", ActionName = "actPrintDoc")]
	public ActionResult Doc(int id, string st = "", bool? isUpdate = null, string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		if (isUpdate ?? false)
		{
			_db.WSspDocSetToIsFix(id);
		}
		if (id != 0)
		{
			PrintLog.InsertPrintLog(id, 11, 1);
		}
		base.TempData["DocId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDraft", ActionName = "actPrintDraft")]
	public ActionResult Draft(int id, string st = "", bool? isUpdate = null, string fileName = "", string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		if (isUpdate ?? false)
		{
			_db.WSspDocSetToIsFix(id);
		}
		if (id != 0)
		{
			PrintLog.InsertPrintLog(id, 12, 1);
		}
		base.TempData["CmpRemainAccLink"] = cmpRemainAccLink;
		base.ViewBag.CmpRemainAccLink = cmpRemainAccLink;
		base.TempData["CmpRemainAccLinkjs"] = cmpRemainAccLinkjs;
		base.ViewBag.CmpRemainAccLinkjs = cmpRemainAccLinkjs;
		base.TempData["DraftId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmWareHouseMovement", ActionName = "actPrintDoc")]
	public ActionResult WareHouseMovement(int id, string st = "", bool? isUpdate = null, string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		if (isUpdate ?? false)
		{
			_db.WSspDocSetToIsFix(id);
		}
		if (id != 0)
		{
			PrintLog.InsertPrintLog(id, 87, 1);
		}
		base.TempData["WrhsMovementDocId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmDyForm", ActionName = "actPrintDyForm")]
	public ActionResult DyForm(int id, string st = "", int? pfid = null, int formId = 0, int masterValueDetailId = 0, string fileName = "")
	{
		base.ViewBag.ShowToolbar = true;
		base.TempData["MasterValueId"] = id;
		base.TempData["MasterValueDetailId"] = masterValueDetailId;
		base.TempData["FormId"] = formId;
		base.ViewBag.CurrId = id;
		base.ViewBag.CurrIdI = masterValueDetailId;
		base.ViewBag.CurrFormId = formId;
		try
		{
			if (string.IsNullOrEmpty(fileName))
			{
				int.TryParse(pfid.ToString(), out var result);
				if (result != 0)
				{
					WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
					if (wSspReturnPrintFormatFileNameById_Result != null)
					{
						fileName = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
					}
					if (fileName != null && !fileName.ToLower().EndsWith(".mrt"))
					{
						fileName += ".mrt";
					}
				}
			}
			if (id != 0)
			{
				PrintLog.InsertPrintLog(id, 505, 1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmLeave", ActionName = "actLeavePrint")]
	public ActionResult HourlyLeave(int id, string st = "", string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["HourlyLeaveId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmLeave", ActionName = "actLeavePrint")]
	public ActionResult DailyLeave(int id, string st = "", string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["DailyLeaveId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmLeave", ActionName = "actMissionPrint")]
	public ActionResult HourlyMission(int id, string st = "", string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["HourlyMissionId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmLeave", ActionName = "actMissionPrint")]
	public ActionResult DailyMission(int id, string st = "", string fileName = "")
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["DailyMissionId"] = id;
		base.ViewBag.CurrId = id;
		if (fileName == null)
		{
			fileName = "";
		}
		base.ViewBag.FileName = fileName;
		base.TempData["FileName"] = fileName;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(0, fileName);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	public ActionResult PayRollUserCycle(int id, string st = "", int? pfid = null)
	{
		base.ViewBag.ShowToolbar = true;
		base.TempData["ParRollUserCycleId"] = id;
		base.ViewBag.CurrId = id;
		string text = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)Enumerable.ToList<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result)));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text != null && !text.ToLower().EndsWith(".mrt"))
				{
					text += ".mrt";
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (text == null)
		{
			text = "";
		}
		base.ViewBag.FileName = text;
		base.TempData["FileName"] = text;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	[DynamicAuthorize(ControllerName = "frmStockSupply", ActionName = "actPrintStockSupply")]
	public ActionResult StockSupply(int id, string st = "", int? pfid = null)
	{
		if (st.Trim() == "")
		{
			base.ViewBag.ShowToolbar = false;
		}
		else
		{
			try
			{
				string text = st.Substring(6, 1);
				base.ViewBag.ShowToolbar = text.ToLower() == "t";
			}
			catch
			{
				base.ViewBag.ShowToolbar = false;
			}
		}
		base.TempData["StockSupplyId"] = id;
		base.ViewBag.CurrId = id;
		string text2 = "";
		try
		{
			int.TryParse(pfid.ToString(), out var result);
			if (result != 0)
			{
				WSspReturnPrintFormatFileNameById_Result wSspReturnPrintFormatFileNameById_Result = Enumerable.FirstOrDefault<WSspReturnPrintFormatFileNameById_Result>((IEnumerable<WSspReturnPrintFormatFileNameById_Result>)_db.WSspReturnPrintFormatFileNameById(result));
				if (wSspReturnPrintFormatFileNameById_Result != null)
				{
					text2 = wSspReturnPrintFormatFileNameById_Result.FileNameWeb;
				}
				if (text2 != null && !text2.ToLower().EndsWith(".mrt"))
				{
					text2 += ".mrt";
				}
			}
			if (id != 0)
			{
				PrintLog.InsertPrintLog(id, 82, 1);
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		if (text2 == null)
		{
			text2 = "";
		}
		base.ViewBag.FileName = text2;
		base.TempData["FileName"] = text2;
		int printFormatCId = CRMIdeal.Classes.Helper.PrintFormat.GetPrintFormatCId(pfid.GetValueOrDefault(), text2);
		base.ViewBag.pfCId = printFormatCId;
		base.TempData["PFCId"] = printFormatCId;
		return View();
	}

	public ActionResult GetReportSnapshot()
	{
		StiReport report = new StiReport();
		string text = "";
		string fileName = "";
		string filePdfPath = "";
		try
		{
			int result = 0;
			int result2 = 0;
			if (base.TempData["PFCId"] != null)
			{
				int.TryParse(base.TempData["PFCId"].ToString(), out result2);
				base.TempData["PFCId"] = null;
			}
			if (base.TempData["OrderId"] != null)
			{
				int.TryParse(base.TempData["OrderId"].ToString(), out result);
				base.TempData["OrderId"] = null;
				text = "order";
			}
			if (base.TempData["BuyOrderId"] != null)
			{
				int.TryParse(base.TempData["BuyOrderId"].ToString(), out result);
				base.TempData["BuyOrderId"] = null;
				text = "buyorder";
			}
			if (base.TempData["PreOrderId"] != null)
			{
				int.TryParse(base.TempData["PreOrderId"].ToString(), out result);
				base.TempData["PreOrderId"] = null;
				text = "preOrder";
			}
			if (base.TempData["DocId"] != null)
			{
				int.TryParse(base.TempData["DocId"].ToString(), out result);
				base.TempData["DocId"] = null;
				text = "doc";
			}
			if (base.TempData["DraftId"] != null)
			{
				int.TryParse(base.TempData["DraftId"].ToString(), out result);
				base.TempData["DraftId"] = null;
				text = "draft";
			}
			if (base.TempData["WrhsMovementDocId"] != null)
			{
				int.TryParse(base.TempData["WrhsMovementDocId"].ToString(), out result);
				base.TempData["WrhsMovementDocId"] = null;
				text = "wrhsmovement";
			}
			if (base.TempData["SendLetterId"] != null)
			{
				int.TryParse(base.TempData["SendLetterId"].ToString(), out result);
				base.TempData["SendLetterId"] = null;
				text = "sendletter";
			}
			if (base.TempData["MasterValueId"] != null)
			{
				int.TryParse(base.TempData["MasterValueId"].ToString(), out result);
				base.TempData["MasterValueId"] = null;
				text = "dyForm";
			}
			if (base.TempData["ParRollUserCycleId"] != null)
			{
				int.TryParse(base.TempData["ParRollUserCycleId"].ToString(), out result);
				base.TempData["ParRollUserCycleId"] = null;
				text = "payrollUserCycle";
			}
			string cmpRemainAccLink = "";
			if (base.TempData["CmpRemainAccLink"] != null)
			{
				cmpRemainAccLink = base.TempData["CmpRemainAccLink"].ToString();
				cmpRemainAccLink = cmpRemainAccLink ?? "";
				base.TempData["CmpRemainAccLink"] = null;
			}
			string cmpRemainAccLinkjs = "";
			if (base.TempData["CmpRemainAccLinkjs"] != null)
			{
				cmpRemainAccLinkjs = base.TempData["CmpRemainAccLinkjs"].ToString();
				cmpRemainAccLinkjs = cmpRemainAccLinkjs ?? "";
				base.TempData["CmpRemainAccLinkjs"] = null;
			}
			if (base.TempData["HourlyLeaveId"] != null)
			{
				int.TryParse(base.TempData["HourlyLeaveId"].ToString(), out result);
				base.TempData["HourlyLeaveId"] = null;
				text = "hourlyLeave";
			}
			if (base.TempData["DailyLeaveId"] != null)
			{
				int.TryParse(base.TempData["DailyLeaveId"].ToString(), out result);
				base.TempData["DailyLeaveId"] = null;
				text = "dailyLeave";
			}
			if (base.TempData["HourlyMissionId"] != null)
			{
				int.TryParse(base.TempData["HourlyMissionId"].ToString(), out result);
				base.TempData["HourlyMissionId"] = null;
				text = "hourlyMission";
			}
			if (base.TempData["DailyMissionId"] != null)
			{
				int.TryParse(base.TempData["DailyMissionId"].ToString(), out result);
				base.TempData["DailyMissionId"] = null;
				text = "dailyMission";
			}
			if (base.TempData["StockSupplyId"] != null)
			{
				int.TryParse(base.TempData["StockSupplyId"].ToString(), out result);
				base.TempData["StockSupplyId"] = null;
				text = "stockSupply";
			}
			if (base.TempData["FileName"] != null)
			{
				fileName = base.TempData["FileName"].ToString();
				base.TempData["FileName"] = null;
			}
			if (result > 0)
			{
				switch (text)
				{
				case "preOrder":
					report = PreOrderPrint(result, fileName, ref filePdfPath, cmpRemainAccLink, 0, result2, cmpRemainAccLinkjs);
					break;
				case "order":
					report = OrderPrint(result, fileName, ref filePdfPath, cmpRemainAccLink, 0, result2, cmpRemainAccLinkjs);
					break;
				case "buyorder":
					report = BuyOrderPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "doc":
					report = DocPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "draft":
					report = DraftPrint(result, fileName, ref filePdfPath, 0, result2, cmpRemainAccLink, cmpRemainAccLinkjs);
					break;
				case "wrhsmovement":
					report = WarehouseMovementPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "sendletter":
					report = SendLetterPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "dyForm":
				{
					int result3 = 0;
					int result4 = 0;
					if (base.TempData["MasterValueDetailId"] != null)
					{
						int.TryParse(base.TempData["MasterValueDetailId"].ToString(), out result3);
						base.TempData["MasterValueDetailId"] = null;
					}
					if (base.TempData["FormId"] != null)
					{
						int.TryParse(base.TempData["FormId"].ToString(), out result4);
						base.TempData["FormId"] = null;
					}
					report = DyFormPrint(result, fileName, ref filePdfPath, result4, result3, 0, result2);
					break;
				}
				case "payrollUserCycle":
					report = PayRollUserCyclePrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "hourlyLeave":
					report = HourlyLeavePrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "dailyLeave":
					report = DailyLeavePrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "hourlyMission":
					report = HourlyMissionPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "dailyMission":
					report = DailyMissionPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				case "stockSupply":
					report = StockSupplyPrint(result, fileName, ref filePdfPath, 0, result2);
					break;
				default:
					report = PreOrderPrint(result, fileName, ref filePdfPath, cmpRemainAccLink, 0, result2, cmpRemainAccLinkjs);
					break;
				}
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

	public StiReport PreOrderPrint(int preOrderId, string fileName, ref string filePdfPath, string cmpRemainAccLink = "", int imgResolution = 0, int pfCId = 0, string cmpRemainAccLinkjs = "")
	{
		//IL_1d27: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d2e: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d31: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d4f: Expected I4, but got Unknown
		//IL_1d4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1d53: Invalid comparison between Unknown and I4
		//IL_0357: Unknown result type (might be due to invalid IL or missing references)
		//IL_1020: Unknown result type (might be due to invalid IL or missing references)
		//IL_181c: Unknown result type (might be due to invalid IL or missing references)
		//IL_1974: Unknown result type (might be due to invalid IL or missing references)
		//IL_1992: Unknown result type (might be due to invalid IL or missing references)
		//IL_1999: Expected O, but got Unknown
		//IL_19c3: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		CRM.Models.ReportModel.PreOrderPrintRpt.Parameters parameters = new CRM.Models.ReportModel.PreOrderPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		int num = int.Parse(DateTime.Now.ToString("ddHHmmss"));
		string reporterUserName = Labels.lblUnknown;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserId;
			reporterUserName = UserLogin.CurrentUser.FullName;
		}
		int value = num;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
		parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
		parameters.NotUsed_ListPreOrderItemSpecifications = new List<WSspSelectProductSpecificationValues_Result>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result2 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.CmpLinkAccAllPayRemain = default(decimal);
		decimal result3 = default(decimal);
		int cmpId = 0;
		if (result2 > 0)
		{
			CompanyController companyController = new CompanyController();
			string text3 = "";
			WSspSelectPreOrderWithId_Result wSspSelectPreOrderWithId_Result = Enumerable.FirstOrDefault<WSspSelectPreOrderWithId_Result>((IEnumerable<WSspSelectPreOrderWithId_Result>)_db.WSspSelectPreOrderWithId(preOrderId, currLangID, defLangID));
			if (wSspSelectPreOrderWithId_Result != null)
			{
				cmpId = wSspSelectPreOrderWithId_Result.pordCompanyId.GetValueOrDefault();
			}
			switch (result2)
			{
			case 1:
			{
				decimal num2 = default(decimal);
				if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
				{
					break;
				}
				foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in list)
				{
					int result4 = 0;
					int.TryParse(item.LinkAccSettingDBId.ToString(), out result4);
					if (result4 != 0)
					{
						CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
						{
							DBId = result4,
							DbName = item.LinkAccSettingDbName,
							DbTitle = item.LinkAccSettingDbTitle
						};
						num2 = default(decimal);
						decimal linkAccDebitBalance = default(decimal);
						decimal linkAccCreditBalance = default(decimal);
						companyController.SepGetCmpAccountingDetail(cmpId, ref num2, ref linkAccDebitBalance, ref linkAccCreditBalance, result4);
						text3 = $"{num2:N2}";
						cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text3 ?? "0");
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
					}
				}
				break;
			}
			case 4:
				if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
				{
					text3 = cmpRemainAccLink;
				}
				if (string.IsNullOrWhiteSpace(cmpRemainAccLinkjs))
				{
					break;
				}
				try
				{
					parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(cmpRemainAccLinkjs);
					if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
					{
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
						break;
					}
					foreach (CmpAccountingLinkAccDataViewModel notUsed_ListCmpAllPayRemainLinkAccDatum in parameters.NotUsed_ListCmpAllPayRemainLinkAccData)
					{
						notUsed_ListCmpAllPayRemainLinkAccDatum.AllPayRemainStr = notUsed_ListCmpAllPayRemainLinkAccDatum.cmpLinkAccAllPayRemain;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				break;
			default:
				if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
				{
					text3 = cmpRemainAccLink;
				}
				break;
			}
			if (text3 == Labels.frmError)
			{
				text3 = "0.00";
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				decimal.TryParse(text3, out result3);
			}
		}
		parameters.CmpLinkAccAllPayRemain = result3;
		parameters.ActNotShowFinancialInfo = false;
		if (UserLogin.CurrentUser != null)
		{
			parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmPreOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
		}
		parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
		parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)_dbII.WSspRpt_PrintPreOrderById(preOrderId, currLangID, defLangID, value, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
		if (parameters.PrintPreOrder == null)
		{
			parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
		}
		else if (currLangID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDate))
			{
				parameters.PrintPreOrder.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prsBirthDate))
			{
				parameters.PrintPreOrder.prsBirthDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prsBirthDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryDate))
			{
				parameters.PrintPreOrder.pordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryEndDate))
			{
				parameters.PrintPreOrder.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.RegisterDatePersian))
			{
				parameters.PrintPreOrder.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordExpireDate))
			{
				parameters.PrintPreOrder.pordExpireDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordExpireDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prjStartDate))
			{
				parameters.PrintPreOrder.prjStartDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prjStartDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeadlineDatePersian))
			{
				parameters.PrintPreOrder.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordChangeStatusDatePersian))
			{
				parameters.PrintPreOrder.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		List<WSspRpt_PrintPreOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)_db.WSspRpt_PrintPreOrder(preOrderId, currLangID, defLangID, value, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
		foreach (WSspRpt_PrintPreOrder_Result item2 in list2)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item2.pordDate))
				{
					item2.pordDate = PersianDate.GetShamsi2Miladi(item2.pordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.prsBirthDate))
				{
					item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordDeliveryDate))
				{
					item2.pordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.pordDeliveryDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
				{
					item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.POIRegisterDatePersian))
				{
					item2.POIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.POIRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.LastOrdDate))
				{
					item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordIDeliveryDatePersian))
				{
					item2.pordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.prjStartDate))
				{
					item2.prjStartDate = PersianDate.GetShamsi2Miladi(item2.prjStartDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordDeadlineDatePersian))
				{
					item2.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordIValidityExpireDatePersian))
				{
					item2.pordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordIDiscountCodeRegisterDatePersian))
				{
					item2.pordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.pordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.pordChangeStatusDatePersian))
				{
					item2.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(item2.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = reporterUserName;
		WSspRpt_PrintPreOrder_Result wSspRpt_PrintPreOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list2);
		if (wSspRpt_PrintPreOrder_Result == null)
		{
			wSspRpt_PrintPreOrder_Result = new WSspRpt_PrintPreOrder_Result();
			if (parameters.PrintPreOrder != null)
			{
				wSspRpt_PrintPreOrder_Result.PreOrderID = parameters.PrintPreOrder.PreOrderID;
				wSspRpt_PrintPreOrder_Result.pordCompanyId = parameters.PrintPreOrder.pordCompanyId;
				wSspRpt_PrintPreOrder_Result.pordCompanyPersonId = parameters.PrintPreOrder.pordCompanyPersonId;
				wSspRpt_PrintPreOrder_Result.pordProjectId = parameters.PrintPreOrder.pordProjectId;
				wSspRpt_PrintPreOrder_Result.pordReferUserId = parameters.PrintPreOrder.pordReferUserId;
				wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId = parameters.PrintPreOrder.pordFirstRegisterUserId;
				wSspRpt_PrintPreOrder_Result.UserId = parameters.PrintPreOrder.UserId;
				wSspRpt_PrintPreOrder_Result.pordVerifierId = parameters.PrintPreOrder.pordVerifierId;
				wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId = parameters.PrintPreOrder.pordVerificationWorkFlowId;
			}
		}
		parameters.ListPrintPreOrder = list2;
		List<WSspSelectPreOrderItemSpecificationByItemId_Result> list3 = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
		foreach (List<WSspSelectPreOrderItemSpecificationByItemId_Result> item3 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, currLangID, defLangID)))))
		{
			list3.AddRange(item3);
		}
		foreach (WSspSelectPreOrderItemSpecificationByItemId_Result item4 in list3)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item4.RegisterDatePersian))
				{
					item4.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item4.FirstRegisterDatePersian))
				{
					item4.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.ListPrintPreOrderItemSpecification = list3;
		parameters.NotUsed_ListPreOrderItemSpecifications = new List<WSspSelectProductSpecificationValues_Result>();
		foreach (WSspRpt_PrintPreOrder_Result item5 in parameters.ListPrintPreOrder)
		{
			List<WSspSelectProductSpecificationValues_Result> list4 = Product.SelectProductSpecificationValues(item5.PreOrderItemID);
			if (list4 == null)
			{
				continue;
			}
			foreach (WSspSelectProductSpecificationValues_Result item6 in list4)
			{
				item6.ProductId = item5.PreOrderItemID;
			}
			parameters.NotUsed_ListPreOrderItemSpecifications.AddRange(list4);
		}
		List<WSspRpt_PrintPreOrderPayments_Result> list5 = new List<WSspRpt_PrintPreOrderPayments_Result>();
		foreach (List<WSspRpt_PrintPreOrderPayments_Result> item7 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)_db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, currLangID, defLangID)))))
		{
			list5.AddRange(item7);
		}
		foreach (WSspRpt_PrintPreOrderPayments_Result item8 in list5)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item8.RegisterDatePersian))
				{
					item8.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.ImportDate))
				{
					item8.ImportDate = PersianDate.GetShamsi2Miladi(item8.ImportDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.pordpayDocDate))
				{
					item8.pordpayDocDate = PersianDate.GetShamsi2Miladi(item8.pordpayDocDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.pordpayFirstRegisteDatePersian))
				{
					item8.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item8.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.FirstRegisterDatePersian))
				{
					item8.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item8.pordpayVerifiedRegisterDatePersian))
				{
					item8.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item8.pordpayDocDateTemp))
				{
					item8.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item8.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
				}
			}
			if (string.IsNullOrWhiteSpace(item8.pordpayLinkAccData))
			{
				continue;
			}
			List<PayLinkAccDataViewModel> list6 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item8.pordpayLinkAccData);
			if (list6 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list6))
			{
				continue;
			}
			foreach (PayLinkAccDataViewModel vmLkAcc2 in list6)
			{
				vmLkAcc2.PayId = item8.PreOrderPaymentId;
				CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
				if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
				{
					vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
					vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
				}
			}
			parameters.NotUsed_ListPayLinkAccData.AddRange(list6);
		}
		parameters.ListPrintPreOrderPayments = list5;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (wSspRpt_PrintPreOrder_Result != null)
		{
			if (wSspRpt_PrintPreOrder_Result.pordCompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintPreOrder_Result.pordCompanyId, currLangID, defLangID, value, result));
			}
			if (wSspRpt_PrintPreOrder_Result.pordCompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintPreOrder_Result.pordCompanyPersonId, currLangID, defLangID, value, result));
			}
			if (wSspRpt_PrintPreOrder_Result.pordProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangID, defLangID, value, result));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintPreOrder_Result.pordProjectId, currLangID, defLangID));
			}
			parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangID, defLangID, value, result));
		}
		parameters.SignatureReferUser = null;
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordReferUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordVerifierId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (wSspRpt_PrintPreOrder_Result != null && wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintPreOrder_Result.PreOrderID, 10, wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId, currLangID, defLangID));
			if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintPreOrderOrderVerificationRequestDetail in parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails)
				{
					if (currLangID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintPreOrderOrderVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintPreOrderOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
		if (wSspRpt_PrintPreOrder_Result != null)
		{
			parameters.NotUsed_ListPreOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintPreOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintPreOrderItemPrdPicture_Result>)_dbI.WSspRpt_PrintPreOrderItemPrdPicture(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangID, defLangID));
		}
		if (parameters.NotUsed_ListPreOrderItemPrdPicture == null)
		{
			parameters.NotUsed_ListPreOrderItemPrdPicture = new List<WSspRpt_PrintPreOrderItemPrdPicture_Result>();
		}
		parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
		if (wSspRpt_PrintPreOrder_Result != null)
		{
			parameters.NotUsed_ListPreOrderDiscount = Enumerable.ToList<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)_dbII.WSspRpt_PrintPreOrderDiscounts(wSspRpt_PrintPreOrder_Result.PreOrderID, currLangID, defLangID));
			if (parameters.NotUsed_ListPreOrderDiscount != null && Enumerable.Any<WSspRpt_PrintPreOrderDiscounts_Result>((IEnumerable<WSspRpt_PrintPreOrderDiscounts_Result>)parameters.NotUsed_ListPreOrderDiscount))
			{
				foreach (WSspRpt_PrintPreOrderDiscounts_Result item9 in parameters.NotUsed_ListPreOrderDiscount)
				{
					if (currLangID != 1065)
					{
						if (!string.IsNullOrEmpty(item9.FirstRegisterDatePersian))
						{
							item9.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item9.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(item9.RegisterDatePersian))
						{
							item9.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item9.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPreOrderDiscount == null)
		{
			parameters.NotUsed_ListPreOrderDiscount = new List<WSspRpt_PrintPreOrderDiscounts_Result>();
		}
		string text4 = "";
		if (wSspRpt_PrintPreOrder_Result != null)
		{
			text4 = wSspRpt_PrintPreOrder_Result.pordLinkAccData ?? "";
		}
		else if (parameters.PrintPreOrder != null)
		{
			text4 = parameters.PrintPreOrder.pordLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text4))
		{
			List<PordLinkAccDataViewModel> list7 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(text4);
			if (list7 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list7))
			{
				foreach (PordLinkAccDataViewModel vmLkAcc in list7)
				{
					vmLkAcc.PordId = preOrderId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list7);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
		}
		if (parameters.NotUsed_ListPayLinkAccData == null)
		{
			parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		}
		if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
		{
			parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
		}
		CRMspReturnCmpAccountingSummary_Result cmpAccountingSummary = new CRMspReturnCmpAccountingSummary_Result();
		if (list2 != null)
		{
			WSspRpt_PrintPreOrder_Result wSspRpt_PrintPreOrder_Result2 = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list2);
			if (wSspRpt_PrintPreOrder_Result2 != null)
			{
				cmpAccountingSummary = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)_db.CRMspReturnCmpAccountingSummary(wSspRpt_PrintPreOrder_Result2.pordCompanyId, result));
			}
		}
		parameters.CmpAccountingSummary = cmpAccountingSummary;
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PreOrderPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PreOrderPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId == 0 && parameters.PrintPreOrder != null)
		{
			int? pordPrintFormatId = parameters.PrintPreOrder.pordPrintFormatId;
			if (pordPrintFormatId.HasValue)
			{
				CRMspSelectPrintFormatById_Result cRMspSelectPrintFormatById_Result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatById_Result>((IEnumerable<CRMspSelectPrintFormatById_Result>)_dbII.CRMspSelectPrintFormatById(pordPrintFormatId, num, defLangID));
				if (cRMspSelectPrintFormatById_Result != null && cRMspSelectPrintFormatById_Result.CId.HasValue)
				{
					pfCId = cRMspSelectPrintFormatById_Result.CId.Value;
				}
			}
		}
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text6 = Configuration.HostTempFilesPath + "\\Prints\\" + num;
			string text7 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + num;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text8 = text7 + "\\Pord_" + num + "_" + preOrderId + ".pdf";
			text6 = text6 + "\\Pord_" + num + "_" + preOrderId + ".pdf";
			string text9 = text7 + "\\Pord_Zip_" + num + "_" + preOrderId;
			if (!System.IO.Directory.Exists(text9))
			{
				System.IO.Directory.CreateDirectory(text9);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
			}
			string file = text9 + "\\Pord_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text9);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_1d25;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_1d25;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_1d25;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_1d25;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_1d25;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_1d25;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_1d25:;
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text8);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text9);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text9))
				{
					System.IO.Directory.Delete(text9);
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
			if (!System.IO.File.Exists(text8))
			{
				text8 = "";
			}
			filePdfPath = text8;
		}
		return stiReport;
	}

	public StiReport OrderPrint(int orderId, string fileName, ref string filePdfPath, string cmpRemainAccLink = "", int imgResolution = 0, int pfCId = 0, string cmpRemainAccLinkjs = "")
	{
		//IL_1bea: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bef: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf1: Unknown result type (might be due to invalid IL or missing references)
		//IL_1bf4: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c12: Expected I4, but got Unknown
		//IL_1c12: Unknown result type (might be due to invalid IL or missing references)
		//IL_1c16: Invalid comparison between Unknown and I4
		//IL_0342: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e4f: Unknown result type (might be due to invalid IL or missing references)
		//IL_1725: Unknown result type (might be due to invalid IL or missing references)
		//IL_183d: Unknown result type (might be due to invalid IL or missing references)
		//IL_185b: Unknown result type (might be due to invalid IL or missing references)
		//IL_1862: Expected O, but got Unknown
		//IL_188c: Unknown result type (might be due to invalid IL or missing references)
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		CRM.Models.ReportModel.OrderPrintRpt.Parameters parameters = new CRM.Models.ReportModel.OrderPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		int num = int.Parse(DateTime.Now.ToString("ddHHmmss"));
		string reporterUserName = Labels.lblUnknown;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserId;
			reporterUserName = UserLogin.CurrentUser.FullName;
		}
		int value = num;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
		parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result2 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.CmpLinkAccAllPayRemain = default(decimal);
		int num2 = 0;
		decimal result3 = default(decimal);
		if (result2 > 0)
		{
			CompanyController companyController = new CompanyController();
			string text3 = "";
			WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(orderId, currLangID, defLangID));
			if (wSspSelectOrderById_Result != null)
			{
				num2 = wSspSelectOrderById_Result.ordCompanyId;
			}
			switch (result2)
			{
			case 1:
			{
				decimal num3 = default(decimal);
				if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
				{
					break;
				}
				foreach (CRMspSelectLinkAccSettingDBIsActive_Result item in list)
				{
					int result4 = 0;
					int.TryParse(item.LinkAccSettingDBId.ToString(), out result4);
					if (result4 != 0)
					{
						CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
						{
							DBId = result4,
							DbName = item.LinkAccSettingDbName,
							DbTitle = item.LinkAccSettingDbTitle
						};
						num3 = default(decimal);
						decimal linkAccDebitBalance = default(decimal);
						decimal linkAccCreditBalance = default(decimal);
						companyController.SepGetCmpAccountingDetail(num2, ref num3, ref linkAccDebitBalance, ref linkAccCreditBalance, result4);
						text3 = $"{num3:N2}";
						cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text3 ?? "0");
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
					}
				}
				break;
			}
			case 4:
				if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
				{
					text3 = cmpRemainAccLink;
				}
				if (string.IsNullOrWhiteSpace(cmpRemainAccLinkjs))
				{
					break;
				}
				try
				{
					parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(cmpRemainAccLinkjs);
					if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
					{
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
						break;
					}
					foreach (CmpAccountingLinkAccDataViewModel notUsed_ListCmpAllPayRemainLinkAccDatum in parameters.NotUsed_ListCmpAllPayRemainLinkAccData)
					{
						notUsed_ListCmpAllPayRemainLinkAccDatum.AllPayRemainStr = notUsed_ListCmpAllPayRemainLinkAccDatum.cmpLinkAccAllPayRemain;
					}
				}
				catch (Exception e)
				{
					ErrorSignal.FromCurrentContext().Raise(e);
				}
				break;
			default:
				if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
				{
					text3 = cmpRemainAccLink;
				}
				break;
			}
			if (text3 == Labels.frmError)
			{
				text3 = "0.00";
			}
			if (!string.IsNullOrWhiteSpace(text3))
			{
				decimal.TryParse(text3, out result3);
			}
		}
		parameters.CmpLinkAccAllPayRemain = result3;
		parameters.ActNotShowFinancialInfo = false;
		if (UserLogin.CurrentUser != null)
		{
			parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
		}
		List<WSspRpt_PrintOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)_db.WSspRpt_PrintOrder(orderId, currLangID, defLangID, value, rptDate, rptDay, parameters.CmpLinkAccAllPayRemain));
		foreach (WSspRpt_PrintOrder_Result item2 in list2)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item2.ordDate))
				{
					item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.prsBirthDate))
				{
					item2.prsBirthDate = PersianDate.GetShamsi2Miladi(item2.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordDeliveryDate))
				{
					item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.RegisterDatePersian))
				{
					item2.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.OIRegisterDatePersian))
				{
					item2.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.LastOrdDate))
				{
					item2.LastOrdDate = PersianDate.GetShamsi2Miladi(item2.LastOrdDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordIDeliveryDatePersian))
				{
					item2.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordDeadlineDatePersian))
				{
					item2.ordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item2.ordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordDeliveryEndDate))
				{
					item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordIValidityExpireDatePersian))
				{
					item2.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item2.ordIDiscountCodeRegisterDatePersian))
				{
					item2.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			string cmpPassword = null;
			if (!string.IsNullOrWhiteSpace(item2.cmpPassword))
			{
				try
				{
					cmpPassword = XorCipher.DecryptByPublicKey(item2.cmpPassword);
				}
				catch (Exception e2)
				{
					ErrorSignal.FromCurrentContext().Raise(e2);
				}
			}
			item2.cmpPassword = cmpPassword;
		}
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = reporterUserName;
		WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
		if (wSspRpt_PrintOrder_Result == null)
		{
			wSspRpt_PrintOrder_Result = new WSspRpt_PrintOrder_Result();
		}
		parameters.NotUsed_ListPrintOrder = list2;
		List<WSspRpt_PrintOrderItemSerials_Result> list3 = new List<WSspRpt_PrintOrderItemSerials_Result>();
		foreach (WSspRpt_PrintOrder_Result item3 in parameters.NotUsed_ListPrintOrder)
		{
			List<WSspRpt_PrintOrderItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintOrderItemSerials_Result>((IEnumerable<WSspRpt_PrintOrderItemSerials_Result>)_db.WSspRpt_PrintOrderItemSerials(item3.OrderItemID, currLangID, defLangID));
			list3.AddRange(collection);
		}
		foreach (WSspRpt_PrintOrderItemSerials_Result item4 in list3)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item4.RegisterDatePersian))
				{
					item4.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item4.FirstRegisterDatePersian))
				{
					item4.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item4.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintOrderItemSerials = list3;
		parameters.NotUsed_ListOrderItemSpecifications = new List<WSspSelectProductSpecificationValues_Result>();
		foreach (WSspRpt_PrintOrder_Result item5 in parameters.NotUsed_ListPrintOrder)
		{
			List<WSspSelectProductSpecificationValues_Result> list4 = Product.SelectProductSpecificationValues(item5.OrderItemID);
			if (list4 == null)
			{
				continue;
			}
			foreach (WSspSelectProductSpecificationValues_Result item6 in list4)
			{
				item6.ProductId = item5.OrderItemID;
			}
			parameters.NotUsed_ListOrderItemSpecifications.AddRange(list4);
		}
		List<WSspRpt_PrintOrderItems_Result> list5 = new List<WSspRpt_PrintOrderItems_Result>();
		foreach (List<WSspRpt_PrintOrderItems_Result> item7 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderItems_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderItems_Result>((IEnumerable<WSspRpt_PrintOrderItems_Result>)_db.WSspRpt_PrintOrderItems(itemSpe.OrderID, currLangID, defLangID)))))
		{
			list5.AddRange(item7);
		}
		foreach (WSspRpt_PrintOrderItems_Result item8 in list5)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item8.OIRegisterDatePersian))
				{
					item8.OIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.OIRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.ordIDeliveryDatePersian))
				{
					item8.ordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item8.ordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.ordIValidityExpireDatePersian))
				{
					item8.ordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item8.ordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item8.ordIDiscountCodeRegisterDatePersian))
				{
					item8.ordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.ordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintOrderItems = list5;
		List<WSspRpt_PrintOrderPayments_Result> list6 = new List<WSspRpt_PrintOrderPayments_Result>();
		foreach (List<WSspRpt_PrintOrderPayments_Result> item9 in Enumerable.Select<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>((IEnumerable<WSspRpt_PrintOrder_Result>)parameters.NotUsed_ListPrintOrder, (Func<WSspRpt_PrintOrder_Result, List<WSspRpt_PrintOrderPayments_Result>>)((WSspRpt_PrintOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintOrderPayments_Result>((IEnumerable<WSspRpt_PrintOrderPayments_Result>)_db.WSspRpt_PrintOrderPayments(itemSpe.OrderID, currLangID, defLangID)))))
		{
			list6.AddRange(item9);
		}
		foreach (WSspRpt_PrintOrderPayments_Result item10 in list6)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item10.RegisterDatePersian))
				{
					item10.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item10.ImportDate))
				{
					item10.ImportDate = PersianDate.GetShamsi2Miladi(item10.ImportDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item10.ordpayDocDate))
				{
					item10.ordpayDocDate = PersianDate.GetShamsi2Miladi(item10.ordpayDocDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item10.ordpayFirstRegisteDatePersian))
				{
					item10.ordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item10.ordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item10.FirstRegisterDatePersian))
				{
					item10.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item10.ordpayVerifiedRegisterDatePersian))
				{
					item10.ordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.ordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item10.ordpayBankDocDatePersian))
				{
					item10.ordpayBankDocDatePersian = PersianDate.GetShamsi2Miladi(item10.ordpayBankDocDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item10.ordpayBankDocRegisterDatePersian))
				{
					item10.ordpayBankDocRegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.ordpayBankDocRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item10.ordpayDocDateTemp))
				{
					item10.ordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item10.ordpayDocDateTemp.Replace("/", "")).Replace("/", "");
				}
			}
			if (string.IsNullOrWhiteSpace(item10.ordpayLinkAccData))
			{
				continue;
			}
			List<PayLinkAccDataViewModel> list7 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item10.ordpayLinkAccData);
			if (list7 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list7))
			{
				continue;
			}
			foreach (PayLinkAccDataViewModel vmLkAcc2 in list7)
			{
				vmLkAcc2.PayId = item10.OrderPaymentId;
				CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
				if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
				{
					vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
					vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
				}
			}
			parameters.NotUsed_ListPayLinkAccData.AddRange(list7);
		}
		parameters.NotUsed_ListPrintOrderPayments = list6;
		CRMspReturnCmpAccountingSummary_Result cmpAccountingSummary = new CRMspReturnCmpAccountingSummary_Result();
		if (list2 != null)
		{
			WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result2 = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
			if (wSspRpt_PrintOrder_Result2 != null)
			{
				cmpAccountingSummary = Enumerable.FirstOrDefault<CRMspReturnCmpAccountingSummary_Result>((IEnumerable<CRMspReturnCmpAccountingSummary_Result>)_db.CRMspReturnCmpAccountingSummary(wSspRpt_PrintOrder_Result2.ordCompanyId, result));
			}
		}
		parameters.CmpAccountingSummary = cmpAccountingSummary;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintPordForm = new List<CRMspDyPrintPordForm_Result>();
		parameters.ListDyPrintOrdForm = new List<CRMspDyPrintOrdForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		parameters.NotUsed_ScorespSelectOrderScores = new List<ScorespSelectOrderScores_Result>();
		if (wSspRpt_PrintOrder_Result != null)
		{
			_ = wSspRpt_PrintOrder_Result.ordCompanyId;
			parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintOrder_Result.ordCompanyId, currLangID, defLangID, value, result));
			if (wSspRpt_PrintOrder_Result.ordCompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintOrder_Result.ordCompanyPersonId, currLangID, defLangID, value, result));
			}
			if (wSspRpt_PrintOrder_Result.ordProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintOrder_Result.ordProjectId, currLangID, defLangID, value, result));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintOrder_Result.ordProjectId, currLangID, defLangID));
			}
			if (wSspRpt_PrintOrder_Result.PreOrderId.HasValue)
			{
				parameters.ListDyPrintPordForm = Enumerable.ToList<CRMspDyPrintPordForm_Result>((IEnumerable<CRMspDyPrintPordForm_Result>)_db.CRMspDyPrintPordForm(wSspRpt_PrintOrder_Result.PreOrderId, currLangID, defLangID, value, result));
			}
			parameters.ListDyPrintOrdForm = Enumerable.ToList<CRMspDyPrintOrdForm_Result>((IEnumerable<CRMspDyPrintOrdForm_Result>)_db.CRMspDyPrintOrdForm(wSspRpt_PrintOrder_Result.OrderID, currLangID, defLangID, value, result));
		}
		parameters.Signature = "";
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(num));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.Signature = Convert.ToBase64String(cRMspSelectUserSignatureByUserId_Result.Signature);
		}
		parameters.SignatureReferUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		WSspRpt_PrintOrder_Result wSspRpt_PrintOrder_Result3 = Enumerable.FirstOrDefault<WSspRpt_PrintOrder_Result>((IEnumerable<WSspRpt_PrintOrder_Result>)list2);
		if (wSspRpt_PrintOrder_Result3 != null)
		{
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result3.ordReferUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result3.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintOrder_Result3.ordVerifierId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
		}
		parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (wSspRpt_PrintOrder_Result != null && wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintOrder_Result.OrderID, 20, wSspRpt_PrintOrder_Result.ordVerificationWorkFlowId, currLangID, defLangID));
			if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
				{
					if (currLangID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
		if (wSspRpt_PrintOrder_Result != null)
		{
			parameters.NotUsed_ListPrintOrderDoc = Enumerable.ToList<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)_dbI.WSspRpt_PrintOrderDoc(wSspRpt_PrintOrder_Result.OrderID, currLangID, defLangID));
			if (parameters.NotUsed_ListPrintOrderDoc != null && Enumerable.Any<WSspRpt_PrintOrderDoc_Result>((IEnumerable<WSspRpt_PrintOrderDoc_Result>)parameters.NotUsed_ListPrintOrderDoc))
			{
				foreach (WSspRpt_PrintOrderDoc_Result item11 in parameters.NotUsed_ListPrintOrderDoc)
				{
					if (currLangID != 1065 && !string.IsNullOrEmpty(item11.DocDate))
					{
						item11.DocDate = PersianDate.GetShamsi2Miladi(item11.DocDate.Replace("/", "")).Replace("/", "");
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintOrderDoc == null)
		{
			parameters.NotUsed_ListPrintOrderDoc = new List<WSspRpt_PrintOrderDoc_Result>();
		}
		parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
		if (wSspRpt_PrintOrder_Result != null)
		{
			parameters.NotUsed_ListOrderItemPrdPicture = Enumerable.ToList<WSspRpt_PrintOrderItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintOrderItemPrdPicture_Result>)_dbI.WSspRpt_PrintOrderItemPrdPicture(wSspRpt_PrintOrder_Result.OrderID, currLangID, defLangID));
		}
		if (parameters.NotUsed_ListOrderItemPrdPicture == null)
		{
			parameters.NotUsed_ListOrderItemPrdPicture = new List<WSspRpt_PrintOrderItemPrdPicture_Result>();
		}
		CRMspReturnSumCompanyScores_Result cRMspReturnSumCompanyScores_Result = Enumerable.FirstOrDefault<CRMspReturnSumCompanyScores_Result>((IEnumerable<CRMspReturnSumCompanyScores_Result>)_dbI.CRMspReturnSumCompanyScores(num2, result));
		if (cRMspReturnSumCompanyScores_Result != null)
		{
			parameters.SumScores = cRMspReturnSumCompanyScores_Result.SumScores;
			parameters.SumUsableScores = cRMspReturnSumCompanyScores_Result.SumUsableScores;
		}
		List<ScorespSelectOrderScores_Result> list8 = Enumerable.ToList<ScorespSelectOrderScores_Result>((IEnumerable<ScorespSelectOrderScores_Result>)_dbI.ScorespSelectOrderScores(orderId, currLangID, defLangID, result));
		if (list8 != null)
		{
			parameters.NotUsed_ScorespSelectOrderScores = list8;
		}
		string text4 = "";
		if (wSspRpt_PrintOrder_Result != null)
		{
			text4 = wSspRpt_PrintOrder_Result.ordLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text4))
		{
			List<OrdLinkAccDataViewModel> list9 = new JavaScriptSerializer().Deserialize<List<OrdLinkAccDataViewModel>>(text4);
			if (list9 != null && Enumerable.Any<OrdLinkAccDataViewModel>((IEnumerable<OrdLinkAccDataViewModel>)list9))
			{
				foreach (OrdLinkAccDataViewModel vmLkAcc in list9)
				{
					vmLkAcc.OrdId = orderId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list9);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<OrdLinkAccDataViewModel>();
		}
		if (parameters.NotUsed_ListPayLinkAccData == null)
		{
			parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		}
		if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
		{
			parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.OrderPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "OrderPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId == 0 && wSspRpt_PrintOrder_Result != null)
		{
			int? ordPrintFormatId = wSspRpt_PrintOrder_Result.ordPrintFormatId;
			if (ordPrintFormatId.HasValue)
			{
				CRMspSelectPrintFormatById_Result cRMspSelectPrintFormatById_Result = Enumerable.FirstOrDefault<CRMspSelectPrintFormatById_Result>((IEnumerable<CRMspSelectPrintFormatById_Result>)_dbII.CRMspSelectPrintFormatById(ordPrintFormatId, currLangID, defLangID));
				if (cRMspSelectPrintFormatById_Result != null && cRMspSelectPrintFormatById_Result.CId.HasValue)
				{
					pfCId = cRMspSelectPrintFormatById_Result.CId.GetValueOrDefault();
				}
			}
		}
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text6 = Configuration.HostTempFilesPath + "\\Prints\\" + num;
			string text7 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + num;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text8 = text7 + "\\Ord_" + num + "_" + orderId + ".pdf";
			text6 = text6 + "\\Ord_" + num + "_" + orderId + ".pdf";
			string text9 = text7 + "\\Ord_Zip_" + num + "_" + orderId;
			if (!System.IO.Directory.Exists(text9))
			{
				System.IO.Directory.CreateDirectory(text9);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
			}
			string file = text9 + "\\Ord_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text9);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_1be8;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_1be8;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_1be8;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_1be8;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_1be8;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_1be8;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_1be8:;
						}
						catch (Exception e3)
						{
							ErrorSignal.FromCurrentContext().Raise(e3);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text8);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text9);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text9))
				{
					System.IO.Directory.Delete(text9);
				}
			}
			catch (Exception e4)
			{
				ErrorSignal.FromCurrentContext().Raise(e4);
			}
			if (!System.IO.File.Exists(text8))
			{
				text8 = "";
			}
			filePdfPath = text8;
		}
		return stiReport;
	}

	public StiReport BuyOrderPrint(int buyOrderId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_1580: Unknown result type (might be due to invalid IL or missing references)
		//IL_1585: Unknown result type (might be due to invalid IL or missing references)
		//IL_1587: Unknown result type (might be due to invalid IL or missing references)
		//IL_158a: Unknown result type (might be due to invalid IL or missing references)
		//IL_15a8: Expected I4, but got Unknown
		//IL_15a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_15ac: Invalid comparison between Unknown and I4
		//IL_0a65: Unknown result type (might be due to invalid IL or missing references)
		//IL_1100: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1221: Unknown result type (might be due to invalid IL or missing references)
		//IL_1228: Expected O, but got Unknown
		//IL_1252: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.BuyOrderPrintRpt.Parameters parameters = new CRM.Models.ReportModel.BuyOrderPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<BordLinkAccDataViewModel>();
		parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result2 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result2);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result2 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.ActNotShowFinancialInfo = UserLogin.IsUserAccess("frmBuyOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
		List<WSspRpt_PrintBuyOrder_Result> list2 = Enumerable.ToList<WSspRpt_PrintBuyOrder_Result>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)_db.WSspRpt_PrintBuyOrder(buyOrderId, currLangID, defLangID, userId, rptDate, rptDay));
		foreach (WSspRpt_PrintBuyOrder_Result item in list2)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item.bordDate))
				{
					item.bordDate = PersianDate.GetShamsi2Miladi(item.bordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.prsBirthDate))
				{
					item.prsBirthDate = PersianDate.GetShamsi2Miladi(item.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bOIRegisterDatePersian))
				{
					item.bOIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.bOIRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordDeliveryDatePersian))
				{
					item.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordTaxClearedDatePersian))
				{
					item.bordTaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item.bordTaxClearedDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordSupplierDeliveryDatePersian))
				{
					item.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordFinalDeliveryDatePersian))
				{
					item.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordITaxClearedDatePersian))
				{
					item.bordITaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item.bordITaxClearedDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.bordOrderDate))
				{
					item.bordOrderDate = PersianDate.GetShamsi2Miladi(item.bordOrderDate.Replace("/", "")).Replace("/", "");
				}
			}
		}
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		WSspRpt_PrintBuyOrder_Result wSspRpt_PrintBuyOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintBuyOrder_Result>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)list2);
		if (wSspRpt_PrintBuyOrder_Result == null)
		{
			wSspRpt_PrintBuyOrder_Result = new WSspRpt_PrintBuyOrder_Result();
		}
		parameters.NotUsed_ListBuyOrder = list2;
		List<WSspRpt_PrintBuyOrderItemSerials_Result> list3 = new List<WSspRpt_PrintBuyOrderItemSerials_Result>();
		foreach (WSspRpt_PrintBuyOrder_Result item2 in parameters.NotUsed_ListBuyOrder)
		{
			List<WSspRpt_PrintBuyOrderItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintBuyOrderItemSerials_Result>((IEnumerable<WSspRpt_PrintBuyOrderItemSerials_Result>)_db.WSspRpt_PrintBuyOrderItemSerials(item2.BuyOrderItemId, currLangID, defLangID));
			list3.AddRange(collection);
		}
		foreach (WSspRpt_PrintBuyOrderItemSerials_Result item3 in list3)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item3.RegisterDatePersian))
				{
					item3.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item3.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item3.FirstRegisterDatePersian))
				{
					item3.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item3.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListBuyOrderItemSerials = list3;
		parameters.NotUsed_ListBuyOrderItemSpecifications = new List<WSspSelectProductSpecificationValues_Result>();
		foreach (WSspRpt_PrintBuyOrder_Result item4 in parameters.NotUsed_ListBuyOrder)
		{
			List<WSspSelectProductSpecificationValues_Result> list4 = Product.SelectProductSpecificationValues(item4.BuyOrderItemId);
			if (list4 == null)
			{
				continue;
			}
			foreach (WSspSelectProductSpecificationValues_Result item5 in list4)
			{
				item5.ProductId = item4.BuyOrderItemId;
			}
			parameters.NotUsed_ListBuyOrderItemSpecifications.AddRange(list4);
		}
		List<WSspRpt_PrintBuyOrderItems_Result> list5 = new List<WSspRpt_PrintBuyOrderItems_Result>();
		foreach (List<WSspRpt_PrintBuyOrderItems_Result> item6 in Enumerable.Select<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderItems_Result>>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)parameters.NotUsed_ListBuyOrder, (Func<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderItems_Result>>)((WSspRpt_PrintBuyOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintBuyOrderItems_Result>((IEnumerable<WSspRpt_PrintBuyOrderItems_Result>)_db.WSspRpt_PrintBuyOrderItems(itemSpe.BuyOrderID, currLangID, defLangID)))))
		{
			list5.AddRange(item6);
		}
		foreach (WSspRpt_PrintBuyOrderItems_Result item7 in list5)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item7.RegisterDatePersian))
				{
					item7.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item7.FirstRegisterDatePersian))
				{
					item7.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item7.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item7.bordITaxClearedDatePersian))
				{
					item7.bordITaxClearedDatePersian = PersianDate.GetShamsi2Miladi(item7.bordITaxClearedDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintBuyOrderItems = list5;
		List<WSspRpt_PrintBuyOrderPayments_Result> list6 = new List<WSspRpt_PrintBuyOrderPayments_Result>();
		foreach (List<WSspRpt_PrintBuyOrderPayments_Result> item8 in Enumerable.Select<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderPayments_Result>>((IEnumerable<WSspRpt_PrintBuyOrder_Result>)parameters.NotUsed_ListBuyOrder, (Func<WSspRpt_PrintBuyOrder_Result, List<WSspRpt_PrintBuyOrderPayments_Result>>)((WSspRpt_PrintBuyOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintBuyOrderPayments_Result>((IEnumerable<WSspRpt_PrintBuyOrderPayments_Result>)_db.WSspRpt_PrintBuyOrderPayments(itemSpe.BuyOrderID, currLangID, defLangID)))))
		{
			list6.AddRange(item8);
		}
		foreach (WSspRpt_PrintBuyOrderPayments_Result item9 in list6)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item9.RegisterDatePersian))
				{
					item9.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item9.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item9.ImportDate))
				{
					item9.ImportDate = PersianDate.GetShamsi2Miladi(item9.ImportDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item9.bordpayDocDate))
				{
					item9.bordpayDocDate = PersianDate.GetShamsi2Miladi(item9.bordpayDocDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item9.bordpayFirstRegisteDatePersian))
				{
					item9.bordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item9.bordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item9.FirstRegisterDatePersian))
				{
					item9.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item9.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item9.bordpayDocDateTemp))
				{
					item9.bordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item9.bordpayDocDateTemp.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrWhiteSpace(item9.bordpayVerifiedRegisterDatePersian))
				{
					item9.bordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item9.bordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			if (string.IsNullOrWhiteSpace(item9.bordpayLinkAccData))
			{
				continue;
			}
			List<PayLinkAccDataViewModel> list7 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item9.bordpayLinkAccData);
			if (list7 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list7))
			{
				continue;
			}
			foreach (PayLinkAccDataViewModel vmLkAcc2 in list7)
			{
				vmLkAcc2.PayId = item9.BuyOrderPaymentId;
				CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
				if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
				{
					vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
					vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
				}
			}
			parameters.NotUsed_ListPayLinkAccData.AddRange(list7);
		}
		parameters.NotUsed_ListPrintBuyOrderPayments = list6;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintBordForm = new List<CRMspDyPrintBordForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (wSspRpt_PrintBuyOrder_Result != null)
		{
			_ = wSspRpt_PrintBuyOrder_Result.bordCompanyId;
			parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintBuyOrder_Result.bordCompanyId, currLangID, defLangID, userId, result));
			if (wSspRpt_PrintBuyOrder_Result.bordCompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintBuyOrder_Result.bordCompanyPersonId, currLangID, defLangID, userId, result));
			}
			if (wSspRpt_PrintBuyOrder_Result.bordProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintBuyOrder_Result.bordProjectId, currLangID, defLangID, userId, result));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintBuyOrder_Result.bordProjectId, currLangID, defLangID));
			}
			parameters.ListDyPrintBordForm = Enumerable.ToList<CRMspDyPrintBordForm_Result>((IEnumerable<CRMspDyPrintBordForm_Result>)_db.CRMspDyPrintBordForm(wSspRpt_PrintBuyOrder_Result.BuyOrderID, currLangID, defLangID, userId, result));
		}
		parameters.Signature = "";
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(UserLogin.CurrentUser.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.Signature = Convert.ToBase64String(cRMspSelectUserSignatureByUserId_Result.Signature);
		}
		parameters.SignatureReferUser = null;
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.bordReferUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.FirstRegisterUserId.GetValueOrDefault()));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintBuyOrder_Result.bordVerifierId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (wSspRpt_PrintBuyOrder_Result != null && wSspRpt_PrintBuyOrder_Result.bordVerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintBuyOrder_Result.BuyOrderID, 40, wSspRpt_PrintBuyOrder_Result.bordVerificationWorkFlowId, currLangID, defLangID));
			if (parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintBuyOrderVerificationRequestDetail in parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails)
				{
					if (currLangID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintBuyOrderVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintBuyOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		string text3 = "";
		if (wSspRpt_PrintBuyOrder_Result != null)
		{
			text3 = wSspRpt_PrintBuyOrder_Result.bordLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			List<BordLinkAccDataViewModel> list8 = new JavaScriptSerializer().Deserialize<List<BordLinkAccDataViewModel>>(text3);
			if (list8 != null && Enumerable.Any<BordLinkAccDataViewModel>((IEnumerable<BordLinkAccDataViewModel>)list8))
			{
				foreach (BordLinkAccDataViewModel vmLkAcc in list8)
				{
					vmLkAcc.BordId = buyOrderId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list8);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<BordLinkAccDataViewModel>();
		}
		if (parameters.NotUsed_ListPayLinkAccData == null)
		{
			parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.BuyOrderPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "BuyOrderPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
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
		if (filePdfPath == "1")
		{
			string text5 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text6 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text7 = text6 + "\\Bord_" + UserLogin.CurrentUser.UserId + "_" + buyOrderId + ".pdf";
			text5 = text5 + "\\Bord_" + UserLogin.CurrentUser.UserId + "_" + buyOrderId + ".pdf";
			string text8 = text6 + "\\Bord_Zip_" + UserLogin.CurrentUser.UserId + "_" + buyOrderId;
			if (!System.IO.Directory.Exists(text8))
			{
				System.IO.Directory.CreateDirectory(text8);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
			}
			string file = text8 + "\\Bord_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text8);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_157e;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_157e;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_157e;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_157e;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_157e;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_157e;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_157e:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text7);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text8);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text8))
				{
					System.IO.Directory.Delete(text8);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text7))
			{
				text7 = "";
			}
			filePdfPath = text7;
		}
		return stiReport;
	}

	public StiReport SendLetterPrint(int letterId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0b91: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b98: Unknown result type (might be due to invalid IL or missing references)
		//IL_0b9b: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bb9: Expected I4, but got Unknown
		//IL_0bb9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0bbd: Invalid comparison between Unknown and I4
		//IL_080c: Unknown result type (might be due to invalid IL or missing references)
		//IL_082a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0831: Expected O, but got Unknown
		//IL_085c: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		int result2 = 0;
		int value = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			value = UserLogin.CurrentUser.UserId;
		}
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.SendLetterPrintRpt.Parameters parameters = new CRM.Models.ReportModel.SendLetterPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		string rptDay = DefineDayeOfWeekFa(DateTime.Now.DayOfWeek.ToString());
		List<SecspRpt_PrintSendLetter_Result> list = Enumerable.ToList<SecspRpt_PrintSendLetter_Result>((IEnumerable<SecspRpt_PrintSendLetter_Result>)_db.SecspRpt_PrintSendLetter(letterId, UserLogin.CurrentUser.UserId, DateTime.Now.ToString("yyyy/MM/dd"), rptDay, lCID, result));
		foreach (SecspRpt_PrintSendLetter_Result item in list)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(item.LetterDate))
				{
					item.LetterDate = PersianDate.GetShamsi2Miladi(item.LetterDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.LetterLastPrintDate))
				{
					item.LetterLastPrintDate = PersianDate.GetShamsi2Miladi(item.LetterLastPrintDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.LetterVerifiedRegisterDatePersian))
				{
					item.LetterVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.LetterVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			if (!string.IsNullOrWhiteSpace(item.LetterContextRtf))
			{
				item.LetterContextRtf = item.LetterContextRtf.Replace("////", "//").Replace("\\\\", "\\");
			}
		}
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		SecspRpt_PrintSendLetter_Result secspRpt_PrintSendLetter_Result = Enumerable.FirstOrDefault<SecspRpt_PrintSendLetter_Result>((IEnumerable<SecspRpt_PrintSendLetter_Result>)list);
		if (secspRpt_PrintSendLetter_Result == null)
		{
			secspRpt_PrintSendLetter_Result = new SecspRpt_PrintSendLetter_Result();
		}
		parameters.PrintSendLetter = secspRpt_PrintSendLetter_Result;
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierRequestUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.FirstRegisterUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.LetterVerifierRequestId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureVerifierRequestUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(secspRpt_PrintSendLetter_Result.LetterVerifierId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintLetterForm = new List<CRMspDyPrintSecLetterForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (secspRpt_PrintSendLetter_Result != null)
		{
			if (secspRpt_PrintSendLetter_Result.LetterCompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(secspRpt_PrintSendLetter_Result.LetterCompanyId, lCID, result, value, result2));
			}
			if (secspRpt_PrintSendLetter_Result.LettercmpPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(secspRpt_PrintSendLetter_Result.LettercmpPersonId, lCID, result, value, result2));
			}
			if (secspRpt_PrintSendLetter_Result.LettercmpProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(secspRpt_PrintSendLetter_Result.LettercmpProjectId, lCID, result, value, result2));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(secspRpt_PrintSendLetter_Result.LettercmpProjectId, lCID, result));
			}
			parameters.ListDyPrintLetterForm = Enumerable.ToList<CRMspDyPrintSecLetterForm_Result>((IEnumerable<CRMspDyPrintSecLetterForm_Result>)_db.CRMspDyPrintSecLetterForm(secspRpt_PrintSendLetter_Result.LetterId, lCID, result, value, result2));
		}
		parameters.NotUsed_ListPrintLetterVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (secspRpt_PrintSendLetter_Result != null && secspRpt_PrintSendLetter_Result.LetterVerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintLetterVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(secspRpt_PrintSendLetter_Result.LetterId, 110, secspRpt_PrintSendLetter_Result.LetterVerificationWorkFlowId, lCID, result));
			if (parameters.NotUsed_ListPrintLetterVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLetterVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLetterVerificationRequestDetail in parameters.NotUsed_ListPrintLetterVerificationRequestDetails)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLetterVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLetterVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintLetterVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintLetterVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.SendLetterPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "SendLetterPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\Lett_" + UserLogin.CurrentUser.UserId + "_" + letterId + ".pdf";
			text4 = text4 + "\\Lett_" + UserLogin.CurrentUser.UserId + "_" + letterId + ".pdf";
			string text7 = text5 + "\\Lett_Zip_" + UserLogin.CurrentUser.UserId + "_" + letterId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\Lett_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0b8f;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0b8f;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0b8f;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0b8f;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0b8f;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0b8f;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0b8f:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport DocPrint(int docId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_1491: Unknown result type (might be due to invalid IL or missing references)
		//IL_1496: Unknown result type (might be due to invalid IL or missing references)
		//IL_1498: Unknown result type (might be due to invalid IL or missing references)
		//IL_149b: Unknown result type (might be due to invalid IL or missing references)
		//IL_14b9: Expected I4, but got Unknown
		//IL_14b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_14bd: Invalid comparison between Unknown and I4
		//IL_0e98: Unknown result type (might be due to invalid IL or missing references)
		//IL_110c: Unknown result type (might be due to invalid IL or missing references)
		//IL_112a: Unknown result type (might be due to invalid IL or missing references)
		//IL_1131: Expected O, but got Unknown
		//IL_115c: Unknown result type (might be due to invalid IL or missing references)
		string manualIssuing = Labels.ManualIssuing;
		string systemIssuing = Labels.SystemIssuing;
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.DocPrintRpt.Parameters parameters = new CRM.Models.ReportModel.DocPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result3 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result3 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.PrintDoc = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)Enumerable.ToList<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)_db.WSspRpt_PrintDoc(docId, lCID, result, manualIssuing, systemIssuing, userId, rptDate, rptDay)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintDoc.DocDate))
			{
				parameters.PrintDoc.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.DocDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.RegisterDatePersian))
			{
				parameters.PrintDoc.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.FirstRegisterDatePersian))
			{
				parameters.PrintDoc.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryDate))
			{
				parameters.PrintDoc.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryEndDate))
			{
				parameters.PrintDoc.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordDeliveryDatePersian))
			{
				parameters.PrintDoc.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordSupplierDeliveryDatePersian))
			{
				parameters.PrintDoc.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordFinalDeliveryDatePersian))
			{
				parameters.PrintDoc.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.VerifiedRegisterDatePersian))
			{
				parameters.PrintDoc.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.pordDate))
			{
				parameters.PrintDoc.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.pordDate.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintDocItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)_db.WSspRpt_PrintDocItems(docId, lCID, result));
		if (parameters.NotUsed_ListPrintDocItems == null)
		{
			parameters.NotUsed_ListPrintDocItems = new List<WSspRpt_PrintDocItems_Result>();
		}
		List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
		foreach (WSspRpt_PrintDocItems_Result notUsed_ListPrintDocItem in parameters.NotUsed_ListPrintDocItems)
		{
			List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)_db.WSspRpt_PrintDocItemSerials(notUsed_ListPrintDocItem.DocItemID, lCID, result));
			list2.AddRange(collection);
		}
		foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintDocItemSerials = list2;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (parameters.PrintDoc != null)
		{
			if (parameters.PrintDoc.CompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(parameters.PrintDoc.CompanyId, lCID, result, userId, result2));
			}
			if (parameters.PrintDoc.CompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(parameters.PrintDoc.CompanyPersonId, lCID, result, userId, result2));
			}
			if (parameters.PrintDoc.ProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(parameters.PrintDoc.ProjectId, lCID, result, userId, result2));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(parameters.PrintDoc.ProjectId, lCID, result));
			}
			parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)_db.CRMspDyPrintDocForm(parameters.PrintDoc.DocID, lCID, result, userId, result2));
		}
		parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintDoc != null)
		{
			int result4 = 0;
			int.TryParse(parameters.PrintDoc.OrderId.ToString(), out result4);
			if (result4 > 0)
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(result4, lCID, result));
				if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordVerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspSelectOrderById_Result.OrderID, 20, wSspSelectOrderById_Result.ordVerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		if (parameters.PrintDoc != null && parameters.PrintDoc.VerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDoc.DocID, 60, parameters.PrintDoc.VerificationWorkFlowId, lCID, result));
			if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		if (parameters.PrintDoc != null)
		{
			parameters.NotUsed_ListDocItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)_dbI.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDoc.DocID, lCID, result));
		}
		if (parameters.NotUsed_ListDocItemPrdPicture == null)
		{
			parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		WSspRpt_PrintDoc_Result printDoc = parameters.PrintDoc;
		if (printDoc != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printDoc.VerifierId.HasValue)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.VerifierId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		parameters.NotUsed_ListPrintDocItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)_dbI.WSspRpt_PrintDocItemsFromQuantity(docId, lCID, result));
		if (parameters.NotUsed_ListPrintDocItemsFromQuantity == null)
		{
			parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		}
		string text3 = "";
		if (parameters.PrintDoc != null)
		{
			text3 = parameters.PrintDoc.DocLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text3);
			if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
			{
				foreach (DocLinkAccDataViewModel vmLkAcc in list3)
				{
					vmLkAcc.DocId = docId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list3);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		}
		parameters.NotUsed_ListOrder = new List<WSspRpt_PrintDocOrder_Result>();
		List<WSspRpt_PrintDocOrder_Result> list4 = Enumerable.ToList<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)_dbII.WSspRpt_PrintDocOrder(docId, lCID, result));
		if (list4 != null)
		{
			if (Enumerable.Any<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)list4))
			{
				foreach (WSspRpt_PrintDocOrder_Result item2 in list4)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(item2.ordDate))
						{
							item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordVerifiedRegisterDatePersian))
						{
							item2.ordVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryDate))
						{
							item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryEndDate))
						{
							item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			parameters.NotUsed_ListOrder = list4;
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.DocPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "DocPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
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
		if (filePdfPath == "1")
		{
			string text5 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text6 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text7 = text6 + "\\Doc_" + UserLogin.CurrentUser.UserId + "_" + docId + ".pdf";
			text5 = text5 + "\\Doc_" + UserLogin.CurrentUser.UserId + "_" + docId + ".pdf";
			string text8 = text6 + "\\Doc_Zip_" + UserLogin.CurrentUser.UserId + "_" + docId;
			if (!System.IO.Directory.Exists(text8))
			{
				System.IO.Directory.CreateDirectory(text8);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
			}
			string file = text8 + "\\Doc_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text8);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_148f;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_148f;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_148f;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_148f;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_148f;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_148f;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_148f:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text7);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text8);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text8))
				{
					System.IO.Directory.Delete(text8);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text7))
			{
				text7 = "";
			}
			filePdfPath = text7;
		}
		return stiReport;
	}

	public StiReport DraftPrint(int draftId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0, string cmpRemainAccLink = "", string cmpRemainAccLinkjs = "")
	{
		//IL_13cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_13eb: Unknown result type (might be due to invalid IL or missing references)
		//IL_13f2: Expected O, but got Unknown
		//IL_141d: Unknown result type (might be due to invalid IL or missing references)
		//IL_1752: Unknown result type (might be due to invalid IL or missing references)
		//IL_1757: Unknown result type (might be due to invalid IL or missing references)
		//IL_1759: Unknown result type (might be due to invalid IL or missing references)
		//IL_175c: Unknown result type (might be due to invalid IL or missing references)
		//IL_177a: Expected I4, but got Unknown
		//IL_177a: Unknown result type (might be due to invalid IL or missing references)
		//IL_177e: Invalid comparison between Unknown and I4
		//IL_0ea4: Unknown result type (might be due to invalid IL or missing references)
		//IL_130b: Unknown result type (might be due to invalid IL or missing references)
		string manualIssuing = Labels.ManualIssuing;
		string systemIssuing = Labels.SystemIssuing;
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.DraftPrintRpt.Parameters parameters = new CRM.Models.ReportModel.DraftPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result3 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result3 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.PrintDraft = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)Enumerable.ToList<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)_db.WSspRpt_PrintDoc(draftId, lCID, result, manualIssuing, systemIssuing, userId, rptDate, rptDay)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintDraft.DocDate))
			{
				parameters.PrintDraft.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.DocDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.RegisterDatePersian))
			{
				parameters.PrintDraft.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.FirstRegisterDatePersian))
			{
				parameters.PrintDraft.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.ordDeliveryDate))
			{
				parameters.PrintDraft.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.ordDeliveryDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.ordDeliveryEndDate))
			{
				parameters.PrintDraft.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.bordDeliveryDatePersian))
			{
				parameters.PrintDraft.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.bordSupplierDeliveryDatePersian))
			{
				parameters.PrintDraft.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.bordFinalDeliveryDatePersian))
			{
				parameters.PrintDraft.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.VerifiedRegisterDatePersian))
			{
				parameters.PrintDraft.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDraft.pordDate))
			{
				parameters.PrintDraft.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDraft.pordDate.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListDraftItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)_db.WSspRpt_PrintDocItems(draftId, lCID, result));
		if (parameters.NotUsed_ListDraftItems == null)
		{
			parameters.NotUsed_ListDraftItems = new List<WSspRpt_PrintDocItems_Result>();
		}
		List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
		foreach (WSspRpt_PrintDocItems_Result notUsed_ListDraftItem in parameters.NotUsed_ListDraftItems)
		{
			List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)_db.WSspRpt_PrintDocItemSerials(notUsed_ListDraftItem.DocItemID, lCID, result));
			list2.AddRange(collection);
		}
		foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListDraftItemSerials = list2;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
		if (parameters.PrintDraft != null)
		{
			if (parameters.PrintDraft.CompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(parameters.PrintDraft.CompanyId, lCID, result, userId, result2));
			}
			if (parameters.PrintDraft.CompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(parameters.PrintDraft.CompanyPersonId, lCID, result, userId, result2));
			}
			if (parameters.PrintDraft.ProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(parameters.PrintDraft.ProjectId, lCID, result, userId, result2));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(parameters.PrintDraft.ProjectId, lCID, result));
			}
			parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)_db.CRMspDyPrintDocForm(parameters.PrintDraft.DocID, lCID, result, userId, result2));
		}
		parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintDraft != null)
		{
			int result4 = 0;
			int.TryParse(parameters.PrintDraft.OrderId.ToString(), out result4);
			if (result4 > 0)
			{
				WSspSelectOrderById_Result wSspSelectOrderById_Result = Enumerable.FirstOrDefault<WSspSelectOrderById_Result>((IEnumerable<WSspSelectOrderById_Result>)_db.WSspSelectOrderById(result4, lCID, result));
				if (wSspSelectOrderById_Result != null && wSspSelectOrderById_Result.ordVerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintOrderVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspSelectOrderById_Result.OrderID, 20, wSspSelectOrderById_Result.ordVerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintOrderVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintOrderVerificationRequestDetail in parameters.NotUsed_ListPrintOrderVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintOrderVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintOrderVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintOrderVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintOrderVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		if (parameters.PrintDraft != null && parameters.PrintDraft.VerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDraft.DocID, 60, parameters.PrintDraft.VerificationWorkFlowId, lCID, result));
			if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListDraftItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		if (parameters.PrintDraft != null)
		{
			parameters.NotUsed_ListDraftItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)_dbI.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDraft.DocID, lCID, result));
		}
		if (parameters.NotUsed_ListDraftItemPrdPicture == null)
		{
			parameters.NotUsed_ListDraftItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		}
		parameters.NotUsed_ListDraftItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		parameters.NotUsed_ListDraftItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)_dbI.WSspRpt_PrintDocItemsFromQuantity(draftId, lCID, result));
		if (parameters.NotUsed_ListDraftItemsFromQuantity == null)
		{
			parameters.NotUsed_ListDraftItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		WSspRpt_PrintDoc_Result printDraft = parameters.PrintDraft;
		if (printDraft != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDraft.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDraft.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printDraft.VerifierId.HasValue)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDraft.VerifierId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		string text3 = "";
		if (parameters.PrintDraft != null)
		{
			text3 = parameters.PrintDraft.DocLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text3);
			if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
			{
				foreach (DocLinkAccDataViewModel vmLkAcc in list3)
				{
					vmLkAcc.DocId = draftId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list3);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		}
		parameters.NotUsed_ListOrder = new List<WSspRpt_PrintDocOrder_Result>();
		List<WSspRpt_PrintDocOrder_Result> list4 = Enumerable.ToList<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)_dbII.WSspRpt_PrintDocOrder(draftId, lCID, result));
		if (list4 != null)
		{
			if (Enumerable.Any<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)list4))
			{
				foreach (WSspRpt_PrintDocOrder_Result item2 in list4)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(item2.ordDate))
						{
							item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordVerifiedRegisterDatePersian))
						{
							item2.ordVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryDate))
						{
							item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryEndDate))
						{
							item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			parameters.NotUsed_ListOrder = list4;
		}
		bool flag = false;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			flag = ((cRMspSelectCrmsysSetting_Result.CmpAccFromLink.HasValue && cRMspSelectCrmsysSetting_Result.CmpAccFromLink.GetValueOrDefault()) ? true : false);
		}
		parameters.CmpLinkAccAllPayRemain = default(decimal);
		if (parameters.PrintDraft.CompanyId.HasValue && parameters.PrintDraft.CompanyId > 0 && flag && result3 > 0)
		{
			int? companyId = parameters.PrintDraft.CompanyId;
			decimal result5 = default(decimal);
			if (result3 > 0)
			{
				CompanyController companyController = new CompanyController();
				string text4 = "";
				switch (result3)
				{
				case 1:
				{
					decimal num = default(decimal);
					if (list == null || !Enumerable.Any<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list))
					{
						break;
					}
					foreach (CRMspSelectLinkAccSettingDBIsActive_Result item3 in list)
					{
						int result6 = 0;
						int.TryParse(item3.LinkAccSettingDBId.ToString(), out result6);
						if (result6 != 0)
						{
							CmpAccountingLinkAccDataViewModel cmpAccountingLinkAccDataViewModel = new CmpAccountingLinkAccDataViewModel
							{
								DBId = result6,
								DbName = item3.LinkAccSettingDbName,
								DbTitle = item3.LinkAccSettingDbTitle
							};
							num = default(decimal);
							decimal linkAccDebitBalance = default(decimal);
							decimal linkAccCreditBalance = default(decimal);
							companyController.SepGetCmpAccountingDetail(companyId.Value, ref num, ref linkAccDebitBalance, ref linkAccCreditBalance, result6);
							text4 = $"{num:N2}";
							cmpAccountingLinkAccDataViewModel.AllPayRemain = decimal.Parse(text4 ?? "0");
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData.Add(cmpAccountingLinkAccDataViewModel);
						}
					}
					break;
				}
				case 4:
					if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
					{
						text4 = cmpRemainAccLink;
					}
					if (string.IsNullOrWhiteSpace(cmpRemainAccLinkjs))
					{
						break;
					}
					try
					{
						parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new JavaScriptSerializer().Deserialize<List<CmpAccountingLinkAccDataViewModel>>(cmpRemainAccLinkjs);
						if (parameters.NotUsed_ListCmpAllPayRemainLinkAccData == null)
						{
							parameters.NotUsed_ListCmpAllPayRemainLinkAccData = new List<CmpAccountingLinkAccDataViewModel>();
							break;
						}
						foreach (CmpAccountingLinkAccDataViewModel notUsed_ListCmpAllPayRemainLinkAccDatum in parameters.NotUsed_ListCmpAllPayRemainLinkAccData)
						{
							notUsed_ListCmpAllPayRemainLinkAccDatum.AllPayRemainStr = notUsed_ListCmpAllPayRemainLinkAccDatum.cmpLinkAccAllPayRemain;
						}
					}
					catch (Exception e)
					{
						ErrorSignal.FromCurrentContext().Raise(e);
					}
					break;
				default:
					if (!string.IsNullOrWhiteSpace(cmpRemainAccLink))
					{
						text4 = cmpRemainAccLink;
					}
					break;
				}
				if (text4 == Labels.frmError)
				{
					text4 = "0.00";
				}
				if (!string.IsNullOrWhiteSpace(text4))
				{
					decimal.TryParse(text4, out result5);
				}
			}
			parameters.CmpLinkAccAllPayRemain = result5;
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.DraftPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "DraftPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text5 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text5 = text5.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text5 = text5.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text5 = text5.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text5 = text5.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text5));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text6 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text7 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text8 = text7 + "\\Draft_" + UserLogin.CurrentUser.UserId + "_" + draftId + ".pdf";
			text6 = text6 + "\\Draft_" + UserLogin.CurrentUser.UserId + "_" + draftId + ".pdf";
			string text9 = text7 + "\\Draft_Zip_" + UserLogin.CurrentUser.UserId + "_" + draftId;
			if (!System.IO.Directory.Exists(text9))
			{
				System.IO.Directory.CreateDirectory(text9);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text9);
			}
			string file = text9 + "\\Draft_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text9);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_1750;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_1750;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_1750;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_1750;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_1750;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_1750;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_1750:;
						}
						catch (Exception e2)
						{
							ErrorSignal.FromCurrentContext().Raise(e2);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text8);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text9);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text9))
				{
					System.IO.Directory.Delete(text9);
				}
			}
			catch (Exception e3)
			{
				ErrorSignal.FromCurrentContext().Raise(e3);
			}
			if (!System.IO.File.Exists(text8))
			{
				text8 = "";
			}
			filePdfPath = text8;
		}
		return stiReport;
	}

	public StiReport WarehouseMovementPrint(int docId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_11fc: Unknown result type (might be due to invalid IL or missing references)
		//IL_1201: Unknown result type (might be due to invalid IL or missing references)
		//IL_1203: Unknown result type (might be due to invalid IL or missing references)
		//IL_1206: Unknown result type (might be due to invalid IL or missing references)
		//IL_1224: Expected I4, but got Unknown
		//IL_1224: Unknown result type (might be due to invalid IL or missing references)
		//IL_1228: Invalid comparison between Unknown and I4
		//IL_0c03: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e77: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e95: Unknown result type (might be due to invalid IL or missing references)
		//IL_0e9c: Expected O, but got Unknown
		//IL_0ec7: Unknown result type (might be due to invalid IL or missing references)
		string manualIssuing = Labels.ManualIssuing;
		string systemIssuing = Labels.SystemIssuing;
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.WarehouseMovementPrintRpt.Parameters parameters = new CRM.Models.ReportModel.WarehouseMovementPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result3 = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result3);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result3 == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		parameters.PrintDoc = Enumerable.FirstOrDefault<WSspRpt_PrintDoc_Result>((IEnumerable<WSspRpt_PrintDoc_Result>)_db.WSspRpt_PrintDoc(docId, lCID, result, manualIssuing, systemIssuing, userId, rptDate, rptDay));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintDoc.DocDate))
			{
				parameters.PrintDoc.DocDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.DocDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.RegisterDatePersian))
			{
				parameters.PrintDoc.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.FirstRegisterDatePersian))
			{
				parameters.PrintDoc.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryDate))
			{
				parameters.PrintDoc.ordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.ordDeliveryEndDate))
			{
				parameters.PrintDoc.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordDeliveryDatePersian))
			{
				parameters.PrintDoc.bordDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordSupplierDeliveryDatePersian))
			{
				parameters.PrintDoc.bordSupplierDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordSupplierDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.bordFinalDeliveryDatePersian))
			{
				parameters.PrintDoc.bordFinalDeliveryDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.bordFinalDeliveryDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.VerifiedRegisterDatePersian))
			{
				parameters.PrintDoc.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintDoc.pordDate))
			{
				parameters.PrintDoc.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintDoc.pordDate.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintDocItems = Enumerable.ToList<WSspRpt_PrintDocItems_Result>((IEnumerable<WSspRpt_PrintDocItems_Result>)_db.WSspRpt_PrintDocItems(docId, lCID, result));
		if (parameters.NotUsed_ListPrintDocItems == null)
		{
			parameters.NotUsed_ListPrintDocItems = new List<WSspRpt_PrintDocItems_Result>();
		}
		List<WSspRpt_PrintDocItemSerials_Result> list2 = new List<WSspRpt_PrintDocItemSerials_Result>();
		foreach (WSspRpt_PrintDocItems_Result notUsed_ListPrintDocItem in parameters.NotUsed_ListPrintDocItems)
		{
			List<WSspRpt_PrintDocItemSerials_Result> collection = Enumerable.ToList<WSspRpt_PrintDocItemSerials_Result>((IEnumerable<WSspRpt_PrintDocItemSerials_Result>)_db.WSspRpt_PrintDocItemSerials(notUsed_ListPrintDocItem.DocItemID, lCID, result));
			list2.AddRange(collection);
		}
		foreach (WSspRpt_PrintDocItemSerials_Result item in list2)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintDocItemSerials = list2;
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintDocForm = new List<CRMspDyPrintDocForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (parameters.PrintDoc != null)
		{
			if (parameters.PrintDoc.CompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(parameters.PrintDoc.CompanyId, lCID, result, userId, result2));
			}
			if (parameters.PrintDoc.CompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(parameters.PrintDoc.CompanyPersonId, lCID, result, userId, result2));
			}
			if (parameters.PrintDoc.ProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(parameters.PrintDoc.ProjectId, lCID, result, userId, result2));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(parameters.PrintDoc.ProjectId, lCID, result));
			}
			parameters.ListDyPrintDocForm = Enumerable.ToList<CRMspDyPrintDocForm_Result>((IEnumerable<CRMspDyPrintDocForm_Result>)_db.CRMspDyPrintDocForm(parameters.PrintDoc.DocID, lCID, result, userId, result2));
		}
		parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		if (parameters.PrintDoc != null && parameters.PrintDoc.VerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintDocVerificationRequestDetails(parameters.PrintDoc.DocID, 60, parameters.PrintDoc.VerificationWorkFlowId, lCID, result));
			if (parameters.NotUsed_ListPrintDocVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintDocVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintDocVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDocVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintDocVerificationRequestDetails_Result notUsed_ListPrintDocVerificationRequestDetail in parameters.NotUsed_ListPrintDocVerificationRequestDetails)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDocVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDocVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintDocVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintDocVerificationRequestDetails = new List<WSspRpt_PrintDocVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		if (parameters.PrintDoc != null)
		{
			parameters.NotUsed_ListDocItemPrdPicture = Enumerable.ToList<WSspRpt_PrintDocItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintDocItemPrdPicture_Result>)_dbI.WSspRpt_PrintDocItemPrdPicture(parameters.PrintDoc.DocID, lCID, result));
		}
		if (parameters.NotUsed_ListDocItemPrdPicture == null)
		{
			parameters.NotUsed_ListDocItemPrdPicture = new List<WSspRpt_PrintDocItemPrdPicture_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		WSspRpt_PrintDoc_Result printDoc = parameters.PrintDoc;
		if (printDoc != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printDoc.VerifierId.HasValue)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printDoc.VerifierId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		parameters.NotUsed_ListPrintDocItemsFromQuantity = Enumerable.ToList<WSspRpt_PrintDocItemsFromQuantity_Result>((IEnumerable<WSspRpt_PrintDocItemsFromQuantity_Result>)_dbI.WSspRpt_PrintDocItemsFromQuantity(docId, lCID, result));
		if (parameters.NotUsed_ListPrintDocItemsFromQuantity == null)
		{
			parameters.NotUsed_ListPrintDocItemsFromQuantity = new List<WSspRpt_PrintDocItemsFromQuantity_Result>();
		}
		string text3 = "";
		if (parameters.PrintDoc != null)
		{
			text3 = parameters.PrintDoc.DocLinkAccData ?? "";
		}
		if (!string.IsNullOrWhiteSpace(text3))
		{
			List<DocLinkAccDataViewModel> list3 = new JavaScriptSerializer().Deserialize<List<DocLinkAccDataViewModel>>(text3);
			if (list3 != null && Enumerable.Any<DocLinkAccDataViewModel>((IEnumerable<DocLinkAccDataViewModel>)list3))
			{
				foreach (DocLinkAccDataViewModel vmLkAcc in list3)
				{
					vmLkAcc.DocId = docId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListLinkAccData.AddRange(list3);
			}
		}
		if (parameters.NotUsed_ListLinkAccData == null)
		{
			parameters.NotUsed_ListLinkAccData = new List<DocLinkAccDataViewModel>();
		}
		parameters.NotUsed_ListOrder = new List<WSspRpt_PrintDocOrder_Result>();
		List<WSspRpt_PrintDocOrder_Result> list4 = Enumerable.ToList<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)_dbII.WSspRpt_PrintDocOrder(docId, lCID, result));
		if (list4 != null)
		{
			if (Enumerable.Any<WSspRpt_PrintDocOrder_Result>((IEnumerable<WSspRpt_PrintDocOrder_Result>)list4))
			{
				foreach (WSspRpt_PrintDocOrder_Result item2 in list4)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrWhiteSpace(item2.ordDate))
						{
							item2.ordDate = PersianDate.GetShamsi2Miladi(item2.ordDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordVerifiedRegisterDatePersian))
						{
							item2.ordVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.ordVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryDate))
						{
							item2.ordDeliveryDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryDate.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrWhiteSpace(item2.ordDeliveryEndDate))
						{
							item2.ordDeliveryEndDate = PersianDate.GetShamsi2Miladi(item2.ordDeliveryEndDate.Replace("/", "")).Replace("/", "");
						}
					}
				}
			}
			parameters.NotUsed_ListOrder = list4;
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.WarehouseMovementPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "WareHouseMovementPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
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
		if (filePdfPath == "1")
		{
			string text5 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text6 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text7 = text6 + "\\Doc_" + UserLogin.CurrentUser.UserId + "_" + docId + ".pdf";
			text5 = text5 + "\\Doc_" + UserLogin.CurrentUser.UserId + "_" + docId + ".pdf";
			string text8 = text6 + "\\Doc_Zip_" + UserLogin.CurrentUser.UserId + "_" + docId;
			if (!System.IO.Directory.Exists(text8))
			{
				System.IO.Directory.CreateDirectory(text8);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text8);
			}
			string file = text8 + "\\Doc_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text8);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_11fa;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_11fa;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_11fa;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_11fa;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_11fa;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_11fa;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_11fa:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text7);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text8);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text8))
				{
					System.IO.Directory.Delete(text8);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text7))
			{
				text7 = "";
			}
			filePdfPath = text7;
		}
		return stiReport;
	}

	public StiReport DyFormPrint(int masterValueId, string fileName, ref string filePdfPath, int formId = 0, int masterValueDetailId = 0, int imgResolution = 0, int pfCId = 0)
	{
		//IL_27cf: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d4: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d6: Unknown result type (might be due to invalid IL or missing references)
		//IL_27d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_27f7: Expected I4, but got Unknown
		//IL_27f7: Unknown result type (might be due to invalid IL or missing references)
		//IL_27fb: Invalid comparison between Unknown and I4
		//IL_0a01: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a08: Expected O, but got Unknown
		//IL_2427: Unknown result type (might be due to invalid IL or missing references)
		//IL_2444: Unknown result type (might be due to invalid IL or missing references)
		//IL_244b: Expected O, but got Unknown
		//IL_2475: Unknown result type (might be due to invalid IL or missing references)
		//IL_247f: Unknown result type (might be due to invalid IL or missing references)
		//IL_2486: Expected O, but got Unknown
		//IL_248a: Unknown result type (might be due to invalid IL or missing references)
		//IL_20cd: Unknown result type (might be due to invalid IL or missing references)
		//IL_2328: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var defLangID);
		if (defLangID <= 0)
		{
			defLangID = 1065;
		}
		int currLangID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.PrintDyFormRpt.Parameters parameters = new CRM.Models.ReportModel.PrintDyFormRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = now.ToString("dddd");
		parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
		parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
		CRMspSelectCrmsysSetting_Result cRMspSelectCrmsysSetting_Result = SysSeting.Get();
		int result = 0;
		if (cRMspSelectCrmsysSetting_Result != null)
		{
			int.TryParse(cRMspSelectCrmsysSetting_Result.LinkAccSystemId.ToString(), out result);
		}
		List<CRMspSelectLinkAccSettingDBIsActive_Result> list = new List<CRMspSelectLinkAccSettingDBIsActive_Result>();
		if (result == 1)
		{
			list = CRMIdeal.Classes.Helper.OtherSystems.GetLinkAccSettingDBList(1);
		}
		List<CRMspDyPrintForm_Result> list2 = Enumerable.ToList<CRMspDyPrintForm_Result>((IEnumerable<CRMspDyPrintForm_Result>)_db.CRMspDyPrintForm(masterValueId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangID, defLangID));
		foreach (CRMspDyPrintForm_Result item in list2)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.CheckedDatePersian))
				{
					item.CheckedDatePersian = PersianDate.GetShamsi2Miladi(item.CheckedDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		CRMspDyPrintForm_Result cRMspDyPrintForm_Result = Enumerable.FirstOrDefault<CRMspDyPrintForm_Result>((IEnumerable<CRMspDyPrintForm_Result>)list2);
		if (cRMspDyPrintForm_Result == null)
		{
			cRMspDyPrintForm_Result = new CRMspDyPrintForm_Result();
		}
		parameters.NotUsed_ListPrintDyForm = new List<CRMspDyPrintFormViewModel>();
		foreach (CRMspDyPrintFormViewModel item2 in Enumerable.Select<CRMspDyPrintForm_Result, CRMspDyPrintFormViewModel>((IEnumerable<CRMspDyPrintForm_Result>)list2, (Func<CRMspDyPrintForm_Result, CRMspDyPrintFormViewModel>)((CRMspDyPrintForm_Result itm) => new CRMspDyPrintFormViewModel
		{
			FormFieldMasterValueId = itm.FormFieldMasterValueId,
			StrFormFieldMasterValueId = itm.FormFieldMasterValueId.ToString(),
			FormId = itm.FormId,
			FormName = itm.FormName,
			FormTitle = itm.FormTitle,
			CrmSysPartId = itm.CrmSysPartId,
			FOSysPartId = itm.FOSysPartId,
			CrmSysPartTitle = itm.CrmSysPartTitle,
			CrmSysPart = itm.CrmSysPart,
			CrmSysPartType = itm.CrmSysPartType,
			FOSysPartTitle = itm.FOSysPartTitle,
			FOSysPart = itm.FOSysPart,
			FOSysPartType = itm.FOSysPartType,
			CompanyId = itm.CompanyId,
			StrCompanyId = (itm.CompanyId.HasValue ? itm.CompanyId.ToString() : ""),
			CompanyNumber = itm.CompanyNumber,
			CompanyName = itm.CompanyName,
			CompanyTel = itm.CompanyTel,
			CompanyTelII = itm.CompanyTelII,
			CompanyFax = itm.CompanyFax,
			CompanyCountry = itm.CompanyCountry,
			CompanyProvince = itm.CompanyProvince,
			CompanyCity = itm.CompanyCity,
			CompanyAddress = itm.CompanyAddress,
			CompanyZipCode = itm.CompanyZipCode,
			CompanyPostBox = itm.CompanyPostBox,
			CompanyRegistrationNumber = itm.CompanyRegistrationNumber,
			CompanyEconomicCode = itm.CompanyEconomicCode,
			CompanyNationalCode = itm.CompanyNationalCode,
			CompanyCode = itm.CompanyCode,
			CompanyPersonId = itm.CompanyPersonId,
			StrCompanyPersonId = (itm.CompanyPersonId.HasValue ? itm.CompanyPersonId.ToString() : ""),
			PersonName = itm.PersonName,
			PersonMobile = itm.PersonMobile,
			PersonEmail = itm.PersonEmail,
			PersonEmailII = itm.PersonEmailII,
			ProjectId = itm.ProjectId,
			StrProjectId = (itm.ProjectId.HasValue ? itm.ProjectId.ToString() : ""),
			ProjectTitle = itm.ProjectTitle,
			ConversationId = itm.ConversationId,
			StrConversationId = (itm.ConversationId.HasValue ? itm.ConversationId.ToString() : ""),
			MasterObjectId = itm.MasterObjectId,
			StrMasterObjectId = (itm.MasterObjectId.HasValue ? itm.MasterObjectId.ToString() : ""),
			DetailObjectId = itm.DetailObjectId,
			StrDetailObjectId = (itm.DetailObjectId.HasValue ? itm.DetailObjectId.ToString() : ""),
			SubDetailObjectId = itm.SubDetailObjectId,
			StrSubDetailObjectId = (itm.SubDetailObjectId.HasValue ? itm.SubDetailObjectId.ToString() : ""),
			IsDeleted = itm.IsDeleted,
			FirstRegisterUserId = itm.FirstRegisterUserId,
			FirstRegisterUser = itm.FirstRegisterUser,
			FirstRegisterDate = itm.FirstRegisterDate,
			FirstRegisterDatePersian = itm.FirstRegisterDatePersian,
			UserId = itm.UserId,
			RegisterUser = itm.RegisterUser,
			RegisterDate = itm.RegisterDate,
			RegisterDatePersian = itm.RegisterDatePersian,
			Year1 = itm.Year1,
			Month1 = itm.Month1,
			GUId = itm.GUId,
			AppType = itm.AppType,
			LanguageID = itm.LanguageID,
			IsChecked = itm.IsChecked,
			CheckerUserId = itm.CheckerUserId,
			CheckerUser = itm.CheckerUser,
			CheckedDate = itm.CheckedDate,
			CheckedDatePersian = itm.CheckedDatePersian,
			rptUserName = itm.rptUserName,
			rptUserId = itm.rptUserId,
			rptDate = itm.rptDate,
			rptDay = itm.rptDay,
			FieldValue = itm.FieldValue,
			WorkflowId = itm.WorkflowId,
			WorkflowStepId = itm.WorkflowStepId,
			Workflow = itm.Workflow,
			WorkflowStep = itm.WorkflowStep,
			CompanyMobile = itm.CompanyMobile,
			CompanyEmail = itm.CompanyEmail,
			CompanyNameOfficial = itm.CompanyNameOfficial,
			CompanyMainPerson = itm.CompanyMainPerson,
			CompanyMainPersonMobile = itm.CompanyMainPersonMobile,
			CompanyMainPersonEmail = itm.CompanyMainPersonEmail,
			CompanyMainPersonEmailII = itm.CompanyMainPersonEmailII,
			CompanyMainPersonTel = itm.CompanyMainPersonTel,
			CompanyMainPersonTelII = itm.CompanyMainPersonTelII,
			CompanyMainPersonFax = itm.CompanyMainPersonFax,
			CompanyMainPersonNationalCode = itm.CompanyMainPersonNationalCode,
			PersonTel = itm.PersonTel,
			PersonTelII = itm.PersonTelII,
			PersonFax = itm.PersonFax,
			PersonNationalCode = itm.PersonNationalCode,
			ProjectInquiryNum = itm.ProjectInquiryNum,
			ProjectNumRef = itm.ProjectNumRef,
			ProjectNumR = itm.ProjectNumR,
			ProjectGroup = itm.ProjectGroup,
			ProjectCnvsStatusGroup = itm.ProjectCnvsStatusGroup,
			DyFormNumber = itm.DyFormNumber,
			VerificationWorkFlowId = itm.VerificationWorkFlowId,
			VerificationWorkFlow = itm.VerificationWorkFlow,
			CId = itm.CId,
			CenterName = itm.CenterName,
			CenterCode = itm.CenterCode
		})))
		{
			parameters.NotUsed_ListPrintDyForm.Add(item2);
		}
		List<FieldValueItemViewModel> list3 = new List<FieldValueItemViewModel>();
		foreach (CRMspDyPrintFormViewModel item3 in parameters.NotUsed_ListPrintDyForm)
		{
			if (string.IsNullOrEmpty(item3.FieldValue))
			{
				continue;
			}
			string[] array = item3.FieldValue.Split(new string[1] { "|^,^|" }, StringSplitOptions.None);
			if (array == null)
			{
				continue;
			}
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (array[i] == null || !(array[i] != ""))
				{
					continue;
				}
				string[] array2 = array[i].Split(new string[1] { "|^:^|" }, StringSplitOptions.None);
				if (array2 == null || !Enumerable.Any<string>((IEnumerable<string>)array2) || Enumerable.Count<string>((IEnumerable<string>)array2) <= 3)
				{
					continue;
				}
				FieldValueItemViewModel fieldValueItemViewModel = new FieldValueItemViewModel
				{
					FormId = item3.FormId,
					CompanyId = item3.CompanyId,
					CompanyPersonId = item3.CompanyPersonId,
					ProjectId = item3.ProjectId,
					ConversationId = item3.ConversationId,
					MasterObjectId = item3.MasterObjectId,
					DetailObjectId = item3.DetailObjectId,
					SubDetailObjectId = item3.SubDetailObjectId,
					MasterValueId = item3.FormFieldMasterValueId,
					FieldTitle = array2[0],
					Value = array2[1],
					FieldType = ((array2[2] != null) ? array2[2].Trim() : array2[2]),
					FieldRepeatId = ((!string.IsNullOrWhiteSpace(array2[3])) ? long.Parse(array2[3].Trim() ?? "0") : 0)
				};
				if (fieldValueItemViewModel.FieldType == "4" && !string.IsNullOrEmpty(fieldValueItemViewModel.Value))
				{
					fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("/", "").Replace("-", "").Replace("\\", "")
						.Replace(" ", "")
						.Replace("_", "");
					if (!string.IsNullOrWhiteSpace(fieldValueItemViewModel.Value))
					{
						string formatetdDate = PersianDate.GetFormatetdDate(fieldValueItemViewModel.Value.Replace("/", ""));
						if (currLangID == 1065)
						{
							fieldValueItemViewModel.Value = DateTime.Parse(formatetdDate + " " + DateTime.Now.ToString("HH:mm:ss"), new PersianCulture()).ToString("yyyy/MM/dd");
						}
						else if (currLangID == 1025)
						{
							fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("ar-SA"));
						}
						else
						{
							fieldValueItemViewModel.Value = DateTime.Parse(PersianDate.GetShamsi2Miladi(fieldValueItemViewModel.Value.Replace("/", ""))).ToString("yyyy/MM/dd", new CultureInfo("en-US"));
						}
					}
				}
				else if (fieldValueItemViewModel.FieldType == "8")
				{
					if (!string.IsNullOrWhiteSpace(fieldValueItemViewModel.Value))
					{
						fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.Replace("|", ",");
						fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
					}
					fieldValueItemViewModel.Value.TrimEnd(new char[1] { ',' });
				}
				else if (fieldValueItemViewModel.FieldType == "13")
				{
					fieldValueItemViewModel.Value = fieldValueItemViewModel.Value.TrimStart(new char[1] { ' ' }).TrimEnd(new char[1] { ' ' });
					if (!string.IsNullOrWhiteSpace(fieldValueItemViewModel.Value))
					{
						byte[] inArray = BaseInfo.HexToByteArray(fieldValueItemViewModel.Value);
						fieldValueItemViewModel.Value = Convert.ToBase64String(inArray);
					}
				}
				list3.Add(fieldValueItemViewModel);
			}
		}
		parameters.NotUsed_ListFieldValue = list3;
		List<CRMspDyPrintFormDetails_Result> list4 = new List<CRMspDyPrintFormDetails_Result>();
		foreach (CRMspDyPrintForm_Result item4 in list2)
		{
			if (!item4.ConversationId.HasValue && !item4.MasterObjectId.HasValue && !item4.DetailObjectId.HasValue && !item4.SubDetailObjectId.HasValue)
			{
				continue;
			}
			if (item4.CrmSysPartId.HasValue)
			{
				List<CRMspDyPrintFormDetails_Result> list5 = Enumerable.ToList<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)_db.CRMspDyPrintFormDetails(item4.CrmSysPart, item4.ConversationId, item4.MasterObjectId, item4.DetailObjectId, item4.SubDetailObjectId, UserLogin.CurrentUser.UserId, currLangID, defLangID));
				if (list5 != null && Enumerable.Any<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)list5))
				{
					list4.AddRange(list5);
				}
			}
			if (item4.FOSysPartId.HasValue)
			{
				List<CRMspDyPrintFormDetails_Result> list6 = Enumerable.ToList<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)_db.CRMspDyPrintFormDetails(item4.FOSysPart, item4.ConversationId, item4.MasterObjectId, item4.DetailObjectId, item4.SubDetailObjectId, UserLogin.CurrentUser.UserId, currLangID, defLangID));
				if (list6 != null && Enumerable.Any<CRMspDyPrintFormDetails_Result>((IEnumerable<CRMspDyPrintFormDetails_Result>)list6))
				{
					list4.AddRange(list6);
				}
			}
		}
		foreach (CRMspDyPrintFormDetails_Result item5 in list4)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(item5.OprDate))
				{
					item5.OprDate = PersianDate.GetShamsi2Miladi(item5.OprDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item5.OprRemindDate))
				{
					item5.OprRemindDate = PersianDate.GetShamsi2Miladi(item5.OprRemindDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item5.OprRemindDateForAllarm))
				{
					item5.OprRemindDateForAllarm = PersianDate.GetShamsi2Miladi(item5.OprRemindDateForAllarm.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintFormDetails = list4;
		MemoryStream memoryStream = new MemoryStream();
		XmlWriterSettings val = new XmlWriterSettings();
		val.OmitXmlDeclaration = true;
		val.Indent = true;
		if (parameters.NotUsed_ListFieldValue != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)parameters.NotUsed_ListFieldValue))
		{
			XmlWriter val2 = XmlWriter.Create((Stream)memoryStream, val);
			try
			{
				val2.WriteStartDocument();
				val2.WriteStartElement("Container");
				foreach (CRMspDyPrintForm_Result itm2 in list2)
				{
					List<FieldValueItemViewModel> list7 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == 0)));
					if (list7 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list7))
					{
						continue;
					}
					FieldValueItemViewModel fieldValueItemViewModel2 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list7);
					if (fieldValueItemViewModel2 == null)
					{
						continue;
					}
					val2.WriteStartElement("Row");
					foreach (FieldValueItemViewModel item6 in list7)
					{
						if (!string.IsNullOrEmpty(item6.FieldTitle))
						{
							string text3 = item6.FieldTitle.Trim();
							text3 = text3.Replace(" ", "_");
							text3 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text3);
							val2.WriteElementString(text3, item6.Value ?? "");
						}
					}
					val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
					val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
					val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
					val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
					val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
					val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
					val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
					val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
					val2.WriteEndElement();
					List<FieldValueItemViewModel> list8 = new List<FieldValueItemViewModel>();
					List<FieldValueItemViewModel> list9 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId != 0)));
					if (list9 == null || !Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list9))
					{
						continue;
					}
					foreach (FieldValueItemViewModel repeateItem in list9)
					{
						FieldValueItemViewModel fieldValueItemViewModel3 = null;
						if (list8 != null && Enumerable.Any<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list8))
						{
							fieldValueItemViewModel3 = Enumerable.FirstOrDefault<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list8, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId));
						}
						if (fieldValueItemViewModel3 != null)
						{
							continue;
						}
						list7 = Enumerable.ToList<FieldValueItemViewModel>(Enumerable.Where<FieldValueItemViewModel>((IEnumerable<FieldValueItemViewModel>)list3, (Func<FieldValueItemViewModel, bool>)((FieldValueItemViewModel m) => m.MasterValueId == itm2.FormFieldMasterValueId && m.FieldRepeatId == repeateItem.FieldRepeatId)));
						val2.WriteStartElement("Row");
						foreach (FieldValueItemViewModel item7 in list7)
						{
							if (!string.IsNullOrEmpty(item7.FieldTitle))
							{
								string text4 = item7.FieldTitle.Trim();
								text4 = text4.Replace(" ", "_");
								text4 = ConvertCharacter.RemoveSpecialCharactersWithoutDot(text4);
								val2.WriteElementString(text4, item7.Value ?? "");
							}
						}
						val2.WriteElementString("CompanyId", fieldValueItemViewModel2.CompanyId.ToString());
						val2.WriteElementString("CompanyPersonId", fieldValueItemViewModel2.CompanyPersonId.ToString());
						val2.WriteElementString("ProjectId", fieldValueItemViewModel2.ProjectId.ToString());
						val2.WriteElementString("ConversationId", fieldValueItemViewModel2.ConversationId.ToString());
						val2.WriteElementString("MasterObjectId", fieldValueItemViewModel2.MasterObjectId.ToString());
						val2.WriteElementString("DetailObjectId", fieldValueItemViewModel2.DetailObjectId.ToString());
						val2.WriteElementString("SubDetailObjectId", fieldValueItemViewModel2.SubDetailObjectId.ToString());
						val2.WriteElementString("MasterValueId", fieldValueItemViewModel2.MasterValueId.ToString());
						val2.WriteEndElement();
						list8.Add(repeateItem);
					}
				}
				val2.WriteEndElement();
				val2.WriteEndDocument();
				val2.Flush();
				val2.Close();
			}
			finally
			{
				((IDisposable)val2)?.Dispose();
			}
			memoryStream.Position = 0L;
		}
		parameters.NotUsed_ListPrintFormFieldValues = new List<CRMspDyPrintFormFieldValues_Result>();
		parameters.NotUsed_ListPrintFormFieldValues = Enumerable.ToList<CRMspDyPrintFormFieldValues_Result>((IEnumerable<CRMspDyPrintFormFieldValues_Result>)_db.CRMspDyPrintFormFieldValues(masterValueId, formId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangID, defLangID));
		foreach (CRMspDyPrintFormFieldValues_Result notUsed_ListPrintFormFieldValue in parameters.NotUsed_ListPrintFormFieldValues)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian))
				{
					notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldValue.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldValue.RegisterDatePersian))
				{
					notUsed_ListPrintFormFieldValue.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldValue.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.NotUsed_ListPrintFormFieldMasterValueDetails = new List<CRMspDyPrintFormFieldMasterValueDetails_Result>();
		parameters.NotUsed_ListPrintFormFieldMasterValueDetails = Enumerable.ToList<CRMspDyPrintFormFieldMasterValueDetails_Result>((IEnumerable<CRMspDyPrintFormFieldMasterValueDetails_Result>)_db.CRMspDyPrintFormFieldMasterValueDetails(masterValueId, masterValueDetailId, UserLogin.CurrentUser.UserId, rptDate, rptDay, currLangID, defLangID));
		foreach (CRMspDyPrintFormFieldMasterValueDetails_Result notUsed_ListPrintFormFieldMasterValueDetail in parameters.NotUsed_ListPrintFormFieldMasterValueDetails)
		{
			if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian))
				{
					notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian))
				{
					notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian))
				{
					notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintFormFieldMasterValueDetail.CheckedDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			if (notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignature != null)
			{
				notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.RegisterUserSignature);
			}
			if (notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignature != null)
			{
				notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.FirstRegisterUserSignature);
			}
			if (notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignature != null)
			{
				notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintFormFieldMasterValueDetail.CheckerUserSignature);
			}
		}
		parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (cRMspDyPrintForm_Result != null && cRMspDyPrintForm_Result.VerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(cRMspDyPrintForm_Result.FormFieldMasterValueId, 80, cRMspDyPrintForm_Result.VerificationWorkFlowId, currLangID, defLangID));
			if (parameters.NotUsed_ListPrintDyFormVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintDyFormVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintDyFormVerificationRequestDetail in parameters.NotUsed_ListPrintDyFormVerificationRequestDetails)
				{
					if (currLangID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintDyFormVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintDyFormVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintDyFormVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintDyFormVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureChekerUser = null;
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.FirstRegisterUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(cRMspDyPrintForm_Result.CheckerUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureChekerUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		int result2 = 0;
		int result3 = 0;
		int result4 = 0;
		if (cRMspDyPrintForm_Result != null)
		{
			int.TryParse(cRMspDyPrintForm_Result.MasterObjectId.ToString(), out result2);
			int.TryParse(cRMspDyPrintForm_Result.CrmSysPartId.ToString(), out result3);
			int.TryParse(cRMspDyPrintForm_Result.FOSysPartId.ToString(), out result4);
		}
		parameters.ListPrintPreOrder = new List<WSspRpt_PrintPreOrder_Result>();
		parameters.ListPrintPreOrderItemSpecification = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
		parameters.ListPrintPreOrderPayments = new List<WSspRpt_PrintPreOrderPayments_Result>();
		parameters.PreOrderSignatureFirstUser = null;
		parameters.PreOrderSignatureLastEditUser = null;
		parameters.PreOrderSignatureReferUser = null;
		parameters.PreOrderSignatureVerifierUser = null;
		parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
		if (result2 != 0 && (result3 == 20 || result3 == 120 || result4 == 20 || result4 == 120))
		{
			parameters.PordActNotShowFinancialInfo = UserLogin.IsUserAccess("frmPreOrder", "actNotShowFinancialInfo", UserLogin.CurrentUser);
			parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
			parameters.PrintPreOrder = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrderById_Result>((IEnumerable<WSspRpt_PrintPreOrderById_Result>)_dbII.WSspRpt_PrintPreOrderById(result2, currLangID, defLangID, userId, rptDate, rptDay, default(decimal)));
			if (parameters.PrintPreOrder == null)
			{
				parameters.PrintPreOrder = new WSspRpt_PrintPreOrderById_Result();
			}
			else if (currLangID != 1065)
			{
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDate))
				{
					parameters.PrintPreOrder.pordDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prsBirthDate))
				{
					parameters.PrintPreOrder.prsBirthDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryDate))
				{
					parameters.PrintPreOrder.pordDeliveryDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeliveryEndDate))
				{
					parameters.PrintPreOrder.pordDeliveryEndDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeliveryEndDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.RegisterDatePersian))
				{
					parameters.PrintPreOrder.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordExpireDate))
				{
					parameters.PrintPreOrder.pordExpireDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordExpireDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.prjStartDate))
				{
					parameters.PrintPreOrder.prjStartDate = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.prjStartDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordDeadlineDatePersian))
				{
					parameters.PrintPreOrder.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(parameters.PrintPreOrder.pordChangeStatusDatePersian))
				{
					parameters.PrintPreOrder.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintPreOrder.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
			List<WSspRpt_PrintPreOrder_Result> list10 = Enumerable.ToList<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)_db.WSspRpt_PrintPreOrder(result2, currLangID, defLangID, userId, rptDate, rptDay, default(decimal)));
			foreach (WSspRpt_PrintPreOrder_Result item8 in list10)
			{
				if (currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item8.pordDate))
					{
						item8.pordDate = PersianDate.GetShamsi2Miladi(item8.pordDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.prsBirthDate))
					{
						item8.prsBirthDate = PersianDate.GetShamsi2Miladi(item8.prsBirthDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordDeliveryDate))
					{
						item8.pordDeliveryDate = PersianDate.GetShamsi2Miladi(item8.pordDeliveryDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.RegisterDatePersian))
					{
						item8.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.POIRegisterDatePersian))
					{
						item8.POIRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.POIRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.LastOrdDate))
					{
						item8.LastOrdDate = PersianDate.GetShamsi2Miladi(item8.LastOrdDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordIDeliveryDatePersian))
					{
						item8.pordIDeliveryDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIDeliveryDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.prjStartDate))
					{
						item8.prjStartDate = PersianDate.GetShamsi2Miladi(item8.prjStartDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordDeadlineDatePersian))
					{
						item8.pordDeadlineDatePersian = PersianDate.GetShamsi2Miladi(item8.pordDeadlineDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordIValidityExpireDatePersian))
					{
						item8.pordIValidityExpireDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIValidityExpireDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordIDiscountCodeRegisterDatePersian))
					{
						item8.pordIDiscountCodeRegisterDatePersian = PersianDate.GetShamsi2Miladi(item8.pordIDiscountCodeRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item8.pordChangeStatusDatePersian))
					{
						item8.pordChangeStatusDatePersian = PersianDate.GetShamsi2Miladi(item8.pordChangeStatusDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
			WSspRpt_PrintPreOrder_Result wSspRpt_PrintPreOrder_Result = Enumerable.FirstOrDefault<WSspRpt_PrintPreOrder_Result>((IEnumerable<WSspRpt_PrintPreOrder_Result>)list10);
			if (wSspRpt_PrintPreOrder_Result == null)
			{
				wSspRpt_PrintPreOrder_Result = new WSspRpt_PrintPreOrder_Result();
				if (parameters.PrintPreOrder != null)
				{
					wSspRpt_PrintPreOrder_Result.PreOrderID = parameters.PrintPreOrder.PreOrderID;
					wSspRpt_PrintPreOrder_Result.pordCompanyId = parameters.PrintPreOrder.pordCompanyId;
					wSspRpt_PrintPreOrder_Result.pordCompanyPersonId = parameters.PrintPreOrder.pordCompanyPersonId;
					wSspRpt_PrintPreOrder_Result.pordProjectId = parameters.PrintPreOrder.pordProjectId;
					wSspRpt_PrintPreOrder_Result.pordReferUserId = parameters.PrintPreOrder.pordReferUserId;
					wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId = parameters.PrintPreOrder.pordFirstRegisterUserId;
					wSspRpt_PrintPreOrder_Result.UserId = parameters.PrintPreOrder.UserId;
					wSspRpt_PrintPreOrder_Result.pordVerifierId = parameters.PrintPreOrder.pordVerifierId;
					wSspRpt_PrintPreOrder_Result.pordVerificationWorkFlowId = parameters.PrintPreOrder.pordVerificationWorkFlowId;
				}
			}
			parameters.ListPrintPreOrder = list10;
			List<WSspSelectPreOrderItemSpecificationByItemId_Result> list11 = new List<WSspSelectPreOrderItemSpecificationByItemId_Result>();
			foreach (List<WSspSelectPreOrderItemSpecificationByItemId_Result> item9 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspSelectPreOrderItemSpecificationByItemId_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspSelectPreOrderItemSpecificationByItemId_Result>((IEnumerable<WSspSelectPreOrderItemSpecificationByItemId_Result>)_db.WSspSelectPreOrderItemSpecificationByItemId(itemSpe.PreOrderItemID, currLangID, defLangID)))))
			{
				list11.AddRange(item9);
			}
			foreach (WSspSelectPreOrderItemSpecificationByItemId_Result item10 in list11)
			{
				if (currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item10.RegisterDatePersian))
					{
						item10.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item10.FirstRegisterDatePersian))
					{
						item10.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item10.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
			parameters.ListPrintPreOrderItemSpecification = list11;
			List<WSspRpt_PrintPreOrderPayments_Result> list12 = new List<WSspRpt_PrintPreOrderPayments_Result>();
			foreach (List<WSspRpt_PrintPreOrderPayments_Result> item11 in Enumerable.Select<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>((IEnumerable<WSspRpt_PrintPreOrder_Result>)parameters.ListPrintPreOrder, (Func<WSspRpt_PrintPreOrder_Result, List<WSspRpt_PrintPreOrderPayments_Result>>)((WSspRpt_PrintPreOrder_Result itemSpe) => Enumerable.ToList<WSspRpt_PrintPreOrderPayments_Result>((IEnumerable<WSspRpt_PrintPreOrderPayments_Result>)_db.WSspRpt_PrintPreOrderPayments(itemSpe.PreOrderID, currLangID, defLangID)))))
			{
				list12.AddRange(item11);
			}
			foreach (WSspRpt_PrintPreOrderPayments_Result item12 in list12)
			{
				if (currLangID != 1065)
				{
					if (!string.IsNullOrEmpty(item12.RegisterDatePersian))
					{
						item12.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item12.ImportDate))
					{
						item12.ImportDate = PersianDate.GetShamsi2Miladi(item12.ImportDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item12.pordpayDocDate))
					{
						item12.pordpayDocDate = PersianDate.GetShamsi2Miladi(item12.pordpayDocDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item12.pordpayFirstRegisteDatePersian))
					{
						item12.pordpayFirstRegisteDatePersian = PersianDate.GetShamsi2Miladi(item12.pordpayFirstRegisteDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item12.FirstRegisterDatePersian))
					{
						item12.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item12.pordpayVerifiedRegisterDatePersian))
					{
						item12.pordpayVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item12.pordpayVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrWhiteSpace(item12.pordpayDocDateTemp))
					{
						item12.pordpayDocDateTemp = PersianDate.GetShamsi2Miladi(item12.pordpayDocDateTemp.Replace("/", "")).Replace("/", "");
					}
				}
				if (string.IsNullOrWhiteSpace(item12.pordpayLinkAccData))
				{
					continue;
				}
				List<PayLinkAccDataViewModel> list13 = new JavaScriptSerializer().Deserialize<List<PayLinkAccDataViewModel>>(item12.pordpayLinkAccData);
				if (list13 == null || !Enumerable.Any<PayLinkAccDataViewModel>((IEnumerable<PayLinkAccDataViewModel>)list13))
				{
					continue;
				}
				foreach (PayLinkAccDataViewModel vmLkAcc2 in list13)
				{
					vmLkAcc2.PayId = item12.PreOrderPaymentId;
					CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc2.DBId.GetValueOrDefault()));
					if (cRMspSelectLinkAccSettingDBIsActive_Result != null)
					{
						vmLkAcc2.DbName = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbName ?? "";
						vmLkAcc2.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result.LinkAccSettingDbTitle ?? "";
					}
				}
				parameters.NotUsed_ListPayLinkAccData.AddRange(list13);
			}
			parameters.ListPrintPreOrderPayments = list12;
			parameters.PreOrderSignatureFirstUser = null;
			parameters.PreOrderSignatureLastEditUser = null;
			parameters.PreOrderSignatureReferUser = null;
			parameters.PreOrderSignatureVerifierUser = null;
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordFirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
			{
				parameters.PreOrderSignatureFirstUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.UserId));
			if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
			{
				parameters.PreOrderSignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordReferUserId));
			if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
			{
				parameters.PreOrderSignatureReferUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintPreOrder_Result.pordVerifierId));
			if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
			{
				parameters.PreOrderSignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
			}
			string text5 = "";
			if (wSspRpt_PrintPreOrder_Result != null)
			{
				text5 = wSspRpt_PrintPreOrder_Result.pordLinkAccData ?? "";
			}
			else if (parameters.PrintPreOrder != null)
			{
				text5 = parameters.PrintPreOrder.pordLinkAccData ?? "";
			}
			if (!string.IsNullOrWhiteSpace(text5))
			{
				List<PordLinkAccDataViewModel> list14 = new JavaScriptSerializer().Deserialize<List<PordLinkAccDataViewModel>>(text5);
				if (list14 != null && Enumerable.Any<PordLinkAccDataViewModel>((IEnumerable<PordLinkAccDataViewModel>)list14))
				{
					foreach (PordLinkAccDataViewModel vmLkAcc in list14)
					{
						vmLkAcc.PordId = result2;
						CRMspSelectLinkAccSettingDBIsActive_Result cRMspSelectLinkAccSettingDBIsActive_Result2 = Enumerable.FirstOrDefault<CRMspSelectLinkAccSettingDBIsActive_Result>((IEnumerable<CRMspSelectLinkAccSettingDBIsActive_Result>)list, (Func<CRMspSelectLinkAccSettingDBIsActive_Result, bool>)((CRMspSelectLinkAccSettingDBIsActive_Result m) => m.LinkAccSettingDBId == vmLkAcc.DBId.GetValueOrDefault()));
						if (cRMspSelectLinkAccSettingDBIsActive_Result2 != null)
						{
							vmLkAcc.DbName = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbName ?? "";
							vmLkAcc.DbTitle = cRMspSelectLinkAccSettingDBIsActive_Result2.LinkAccSettingDbTitle ?? "";
						}
					}
					parameters.NotUsed_ListLinkAccData.AddRange(list14);
				}
			}
			if (parameters.NotUsed_ListLinkAccData == null)
			{
				parameters.NotUsed_ListLinkAccData = new List<PordLinkAccDataViewModel>();
			}
			if (parameters.NotUsed_ListPayLinkAccData == null)
			{
				parameters.NotUsed_ListPayLinkAccData = new List<PayLinkAccDataViewModel>();
			}
		}
		XmlSerializer val3 = new XmlSerializer(typeof(CRM.Models.ReportModel.PrintDyFormRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val4 = XmlWriter.Create((TextWriter)stringWriter);
		val3.Serialize(val4, (object)parameters);
		DataSet val5 = new DataSet();
		val5.ReadXmlSchema(text + "PrintDyForm.xsd");
		XElement val6 = XElement.Parse(stringWriter.ToString());
		val5.ReadXml(((XNode)val6).CreateReader((ReaderOptions)0));
		if (memoryStream != null)
		{
			DataSet val7 = new DataSet();
			val7.ReadXml((Stream)memoryStream);
			val5.Merge(val7);
			memoryStream.Dispose();
			((MarshalByValueComponent)val7).Dispose();
		}
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text6 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text6 = text6.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text6 = text6.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text6 = text6.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text6 = text6.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text6));
		stiReport.Compile();
		stiReport.RegData(val5);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text7 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text8 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text9 = text8 + "\\DyForm_" + UserLogin.CurrentUser.UserId + "_" + masterValueId + ".pdf";
			text7 = text7 + "\\DyForm_" + UserLogin.CurrentUser.UserId + "_" + masterValueId + ".pdf";
			string text10 = text8 + "\\DyForm_Zip_" + UserLogin.CurrentUser.UserId + "_" + masterValueId;
			if (!System.IO.Directory.Exists(text10))
			{
				System.IO.Directory.CreateDirectory(text10);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text10);
			}
			string file = text10 + "\\DyForm_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text10);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int j = 0; j < files.Length; j++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_27cd;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_27cd;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_27cd;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_27cd;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_27cd;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_27cd;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_27cd:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[j]);
					XImage xImage = XImage.FromFile(files[j]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text9);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text10);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int k = 0; k < files2.Length; k++)
				{
					files2[k].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int k = 0; k < directories.Length; k++)
				{
					directories[k].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text10))
				{
					System.IO.Directory.Delete(text10);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text9))
			{
				text9 = "";
			}
			filePdfPath = text9;
		}
		return stiReport;
	}

	public StiReport HourlyLeavePrint(int leaveId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected I4, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.HourlyLeavePrintRpt.Parameters parameters = new CRM.Models.ReportModel.HourlyLeavePrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		parameters.PrintLeave = Enumerable.FirstOrDefault<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)Enumerable.ToList<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)_dbI.CRMspRpt_PrintLeave(leaveId, lCID, result, userId, rptDate, rptDay, result2)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FirstRegisterDatePersian))
			{
				parameters.PrintLeave.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.RegisterDatePersian))
			{
				parameters.PrintLeave.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FromDate))
			{
				parameters.PrintLeave.FromDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FromDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ToDate))
			{
				parameters.PrintLeave.ToDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ToDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ReplaceUserVerifiedDatePersian))
			{
				parameters.PrintLeave.ReplaceUserVerifiedDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ReplaceUserVerifiedDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.VerifiedRegisterDatePersian))
			{
				parameters.PrintLeave.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintLeave != null)
		{
			int result3 = 0;
			int.TryParse(parameters.PrintLeave.LeaveId.ToString(), out result3);
			if (result3 > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, result3, null, null, null, null, lCID, result, null, result2));
				if (cRMspSelectLeave_Result != null && cRMspSelectLeave_Result.VerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(cRMspSelectLeave_Result.LeaveId, 90, cRMspSelectLeave_Result.VerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLeaveVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLeaveVerificationRequestDetail in parameters.NotUsed_ListPrintLeaveVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspRpt_PrintLeave_Result printLeave = parameters.PrintLeave;
		if (printLeave != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printLeave.LeaveStatusId.GetValueOrDefault() == 2)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.VerifierUserId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.HourlyLeavePrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "HourlyLeavePrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\HourlyLeave_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			text4 = text4 + "\\HourlyLeave_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			string text7 = text5 + "\\HourlyLeave_Zip_" + UserLogin.CurrentUser.UserId + "_" + leaveId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\HourlyLeave_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0a8d;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0a8d;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0a8d;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0a8d;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0a8d;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0a8d;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0a8d:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport DailyLeavePrint(int leaveId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected I4, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.DailyLeavePrintRpt.Parameters parameters = new CRM.Models.ReportModel.DailyLeavePrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		parameters.PrintLeave = Enumerable.FirstOrDefault<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)Enumerable.ToList<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)_dbI.CRMspRpt_PrintLeave(leaveId, lCID, result, userId, rptDate, rptDay, result2)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FirstRegisterDatePersian))
			{
				parameters.PrintLeave.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.RegisterDatePersian))
			{
				parameters.PrintLeave.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FromDate))
			{
				parameters.PrintLeave.FromDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FromDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ToDate))
			{
				parameters.PrintLeave.ToDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ToDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ReplaceUserVerifiedDatePersian))
			{
				parameters.PrintLeave.ReplaceUserVerifiedDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ReplaceUserVerifiedDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.VerifiedRegisterDatePersian))
			{
				parameters.PrintLeave.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintLeave != null)
		{
			int result3 = 0;
			int.TryParse(parameters.PrintLeave.LeaveId.ToString(), out result3);
			if (result3 > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, result3, null, null, null, null, lCID, result, null, result2));
				if (cRMspSelectLeave_Result != null && cRMspSelectLeave_Result.VerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(cRMspSelectLeave_Result.LeaveId, 90, cRMspSelectLeave_Result.VerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLeaveVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLeaveVerificationRequestDetail in parameters.NotUsed_ListPrintLeaveVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspRpt_PrintLeave_Result printLeave = parameters.PrintLeave;
		if (printLeave != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printLeave.LeaveStatusId.GetValueOrDefault() == 2)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.VerifierUserId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.DailyLeavePrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "DailyLeavePrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\DailyLeave_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			text4 = text4 + "\\DailyLeave_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			string text7 = text5 + "\\DailyLeave_Zip_" + UserLogin.CurrentUser.UserId + "_" + leaveId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\DailyLeave_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0a8d;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0a8d;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0a8d;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0a8d;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0a8d;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0a8d;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0a8d:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport HourlyMissionPrint(int leaveId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected I4, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.HourlyMissionPrintRpt.Parameters parameters = new CRM.Models.ReportModel.HourlyMissionPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		parameters.PrintLeave = Enumerable.FirstOrDefault<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)Enumerable.ToList<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)_dbI.CRMspRpt_PrintLeave(leaveId, lCID, result, userId, rptDate, rptDay, result2)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FirstRegisterDatePersian))
			{
				parameters.PrintLeave.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.RegisterDatePersian))
			{
				parameters.PrintLeave.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FromDate))
			{
				parameters.PrintLeave.FromDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FromDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ToDate))
			{
				parameters.PrintLeave.ToDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ToDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ReplaceUserVerifiedDatePersian))
			{
				parameters.PrintLeave.ReplaceUserVerifiedDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ReplaceUserVerifiedDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.VerifiedRegisterDatePersian))
			{
				parameters.PrintLeave.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintLeave != null)
		{
			int result3 = 0;
			int.TryParse(parameters.PrintLeave.LeaveId.ToString(), out result3);
			if (result3 > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, result3, null, null, null, null, lCID, result, null, result2));
				if (cRMspSelectLeave_Result != null && cRMspSelectLeave_Result.VerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(cRMspSelectLeave_Result.LeaveId, 100, cRMspSelectLeave_Result.VerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLeaveVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLeaveVerificationRequestDetail in parameters.NotUsed_ListPrintLeaveVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspRpt_PrintLeave_Result printLeave = parameters.PrintLeave;
		if (printLeave != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printLeave.LeaveStatusId.GetValueOrDefault() == 2)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.VerifierUserId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.HourlyMissionPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "HourlyMissionPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\HourlyMission_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			text4 = text4 + "\\HourlyMission_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			string text7 = text5 + "\\HourlyMission_Zip_" + UserLogin.CurrentUser.UserId + "_" + leaveId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\HourlyMission_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0a8d;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0a8d;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0a8d;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0a8d;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0a8d;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0a8d;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0a8d:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport DailyMissionPrint(int leaveId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0a8f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a94: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a96: Unknown result type (might be due to invalid IL or missing references)
		//IL_0a99: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Expected I4, but got Unknown
		//IL_0712: Unknown result type (might be due to invalid IL or missing references)
		//IL_0730: Unknown result type (might be due to invalid IL or missing references)
		//IL_0737: Expected O, but got Unknown
		//IL_0761: Unknown result type (might be due to invalid IL or missing references)
		//IL_0ab7: Unknown result type (might be due to invalid IL or missing references)
		//IL_0abb: Invalid comparison between Unknown and I4
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.DailyMissionPrintRpt.Parameters parameters = new CRM.Models.ReportModel.DailyMissionPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		parameters.PrintLeave = Enumerable.FirstOrDefault<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)Enumerable.ToList<CRMspRpt_PrintLeave_Result>((IEnumerable<CRMspRpt_PrintLeave_Result>)_dbI.CRMspRpt_PrintLeave(leaveId, lCID, result, userId, rptDate, rptDay, result2)));
		if (lCID != 1065)
		{
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FirstRegisterDatePersian))
			{
				parameters.PrintLeave.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.RegisterDatePersian))
			{
				parameters.PrintLeave.RegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.FromDate))
			{
				parameters.PrintLeave.FromDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.FromDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ToDate))
			{
				parameters.PrintLeave.ToDate = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ToDate.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.ReplaceUserVerifiedDatePersian))
			{
				parameters.PrintLeave.ReplaceUserVerifiedDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.ReplaceUserVerifiedDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(parameters.PrintLeave.VerifiedRegisterDatePersian))
			{
				parameters.PrintLeave.VerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(parameters.PrintLeave.VerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (parameters.PrintLeave != null)
		{
			int result3 = 0;
			int.TryParse(parameters.PrintLeave.LeaveId.ToString(), out result3);
			if (result3 > 0)
			{
				CRMspSelectLeave_Result cRMspSelectLeave_Result = Enumerable.FirstOrDefault<CRMspSelectLeave_Result>((IEnumerable<CRMspSelectLeave_Result>)_dbI.CRMspSelectLeave(null, result3, null, null, null, null, lCID, result, null, result2));
				if (cRMspSelectLeave_Result != null && cRMspSelectLeave_Result.VerificationWorkFlowId.HasValue)
				{
					parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(cRMspSelectLeave_Result.LeaveId, 100, cRMspSelectLeave_Result.VerificationWorkFlowId, lCID, result));
					if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintLeaveVerificationRequestDetails))
					{
						foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintLeaveVerificationRequestDetail in parameters.NotUsed_ListPrintLeaveVerificationRequestDetails)
						{
							if (lCID != 1065)
							{
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
								}
								if (!string.IsNullOrEmpty(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian))
								{
									notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintLeaveVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
								}
							}
							if (notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature != null)
							{
								notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintLeaveVerificationRequestDetail.VerifyUserSignature);
							}
						}
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintLeaveVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintLeaveVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.SignatureFirstRegisterUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspRpt_PrintLeave_Result printLeave = parameters.PrintLeave;
		if (printLeave != null)
		{
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstRegisterUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.UserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			if (printLeave.LeaveStatusId.GetValueOrDefault() == 2)
			{
				cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(printLeave.VerifierUserId));
				if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
				}
			}
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.DailyMissionPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "DailyMissionPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\DailyMission_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			text4 = text4 + "\\DailyMission_" + UserLogin.CurrentUser.UserId + "_" + leaveId + ".pdf";
			string text7 = text5 + "\\DailyMission_Zip_" + UserLogin.CurrentUser.UserId + "_" + leaveId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\DailyMission_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0a8d;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0a8d;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0a8d;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0a8d;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0a8d;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0a8d;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0a8d:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport PayRollUserCyclePrint(int cycleId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0c58: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c5f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c62: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c80: Expected I4, but got Unknown
		//IL_0c80: Unknown result type (might be due to invalid IL or missing references)
		//IL_0c84: Invalid comparison between Unknown and I4
		//IL_08db: Unknown result type (might be due to invalid IL or missing references)
		//IL_08f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_0900: Expected O, but got Unknown
		//IL_092a: Unknown result type (might be due to invalid IL or missing references)
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters parameters = new CRM.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		_ = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = now.ToString("dddd");
		int result2 = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
		}
		PayRollspPrintUserCycle_Result payRollspPrintUserCycle_Result = Enumerable.FirstOrDefault<PayRollspPrintUserCycle_Result>((IEnumerable<PayRollspPrintUserCycle_Result>)_db.PayRollspPrintUserCycle(cycleId, UserLogin.CurrentUser.UserId, rptDate, rptDay, lCID, result, result2));
		if (payRollspPrintUserCycle_Result != null && lCID != 1065)
		{
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.FirstRegisterDatePersian))
			{
				payRollspPrintUserCycle_Result.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.RegisterDatePersian))
			{
				payRollspPrintUserCycle_Result.RegisterDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.RegisterDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CycleVerifiedDatePersian))
			{
				payRollspPrintUserCycle_Result.CycleVerifiedDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CycleVerifiedDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CycleDatePersian))
			{
				payRollspPrintUserCycle_Result.CycleDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CycleDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CrmUserStartDatePersian))
			{
				payRollspPrintUserCycle_Result.CrmUserStartDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CrmUserStartDatePersian.Replace("/", "")).Replace("/", "");
			}
			if (!string.IsNullOrEmpty(payRollspPrintUserCycle_Result.CrmUserExpireDatePersian))
			{
				payRollspPrintUserCycle_Result.CrmUserExpireDatePersian = PersianDate.GetShamsi2Miladi(payRollspPrintUserCycle_Result.CrmUserExpireDatePersian.Replace("/", "")).Replace("/", "");
			}
		}
		parameters.PayRollspPrintUserCycle = payRollspPrintUserCycle_Result;
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		parameters.NotUsed_ListUserCycleItems = new List<PayRollspPrintUserCycleItemValues_Result>();
		parameters.NotUsed_ListUserCycleItems = Enumerable.ToList<PayRollspPrintUserCycleItemValues_Result>((IEnumerable<PayRollspPrintUserCycleItemValues_Result>)_db.PayRollspPrintUserCycleItemValues(cycleId, lCID, result));
		parameters.NotUsed_ListUserPayments = new List<PayRollspPrintUserPayments_Result>();
		parameters.NotUsed_ListUserPayments = Enumerable.ToList<PayRollspPrintUserPayments_Result>((IEnumerable<PayRollspPrintUserPayments_Result>)_db.PayRollspPrintUserPayments(cycleId, lCID, result));
		foreach (PayRollspPrintUserPayments_Result notUsed_ListUserPayment in parameters.NotUsed_ListUserPayments)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(notUsed_ListUserPayment.FirstRegisterDatePersian))
				{
					notUsed_ListUserPayment.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(notUsed_ListUserPayment.RegisterDatePersian))
				{
					notUsed_ListUserPayment.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(notUsed_ListUserPayment.PaymentDatePersian))
				{
					notUsed_ListUserPayment.PaymentDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListUserPayment.PaymentDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		parameters.SignatureCrmUser = null;
		if (payRollspPrintUserCycle_Result != null)
		{
			_ = payRollspPrintUserCycle_Result.FirstRegisterUserId;
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.FirstRegisterUserId));
			if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
			{
				parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
			}
			_ = payRollspPrintUserCycle_Result.UserId;
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result2 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.UserId));
			if (cRMspSelectUserSignatureByUserId_Result2 != null && cRMspSelectUserSignatureByUserId_Result2.Signature != null && cRMspSelectUserSignatureByUserId_Result2.Signature.Length != 0)
			{
				parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result2.Signature;
			}
			if (payRollspPrintUserCycle_Result.CycleVerifierUserId.HasValue)
			{
				CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result3 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.CycleVerifierUserId));
				if (cRMspSelectUserSignatureByUserId_Result3 != null && cRMspSelectUserSignatureByUserId_Result3.Signature != null && cRMspSelectUserSignatureByUserId_Result3.Signature.Length != 0)
				{
					parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result3.Signature;
				}
			}
			_ = payRollspPrintUserCycle_Result.CrmUserId;
			CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result4 = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(payRollspPrintUserCycle_Result.CrmUserId));
			if (cRMspSelectUserSignatureByUserId_Result4 != null && cRMspSelectUserSignatureByUserId_Result4.Signature != null && cRMspSelectUserSignatureByUserId_Result4.Signature.Length != 0)
			{
				parameters.SignatureCrmUser = cRMspSelectUserSignatureByUserId_Result4.Signature;
			}
		}
		parameters.NotUsed_ListOrderCommissions = new List<PayRollspPrintUserCycleOrderCommissions_Result>();
		parameters.NotUsed_ListOrderCommissions = Enumerable.ToList<PayRollspPrintUserCycleOrderCommissions_Result>((IEnumerable<PayRollspPrintUserCycleOrderCommissions_Result>)_dbI.PayRollspPrintUserCycleOrderCommissions(cycleId, UserLogin.CurrentUser.UserId, lCID, result));
		if (parameters.NotUsed_ListOrderCommissions != null && Enumerable.Any<PayRollspPrintUserCycleOrderCommissions_Result>((IEnumerable<PayRollspPrintUserCycleOrderCommissions_Result>)parameters.NotUsed_ListOrderCommissions))
		{
			foreach (PayRollspPrintUserCycleOrderCommissions_Result notUsed_ListOrderCommission in parameters.NotUsed_ListOrderCommissions)
			{
				if (lCID != 1065)
				{
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommDatePersian))
					{
						notUsed_ListOrderCommission.CommDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.FirstRegisterDatePersian))
					{
						notUsed_ListOrderCommission.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.RegisterDatePersian))
					{
						notUsed_ListOrderCommission.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.RegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommEffectiveDatePersian))
					{
						notUsed_ListOrderCommission.CommEffectiveDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommEffectiveDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommVerifiedDatePersian))
					{
						notUsed_ListOrderCommission.CommVerifiedDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommVerifiedDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommIsPaidDatePersian))
					{
						notUsed_ListOrderCommission.CommIsPaidDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommIsPaidDatePersian.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(notUsed_ListOrderCommission.CommOrderDate))
					{
						notUsed_ListOrderCommission.CommOrderDate = PersianDate.GetShamsi2Miladi(notUsed_ListOrderCommission.CommOrderDate.Replace("/", "")).Replace("/", "");
					}
				}
				if (notUsed_ListOrderCommission.CommUserSignature != null)
				{
					notUsed_ListOrderCommission.CommUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommUserSignature);
				}
				if (notUsed_ListOrderCommission.FirstRegisterUserSignature != null)
				{
					notUsed_ListOrderCommission.FirstRegisterUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.FirstRegisterUserSignature);
				}
				if (notUsed_ListOrderCommission.EditUserSignature != null)
				{
					notUsed_ListOrderCommission.EditUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.EditUserSignature);
				}
				if (notUsed_ListOrderCommission.CommVerifierUserSignature != null)
				{
					notUsed_ListOrderCommission.CommVerifierUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommVerifierUserSignature);
				}
				if (notUsed_ListOrderCommission.CommIsPaidUserSignature != null)
				{
					notUsed_ListOrderCommission.CommIsPaidUserSignatureStr = Convert.ToBase64String(notUsed_ListOrderCommission.CommIsPaidUserSignature);
				}
			}
		}
		else
		{
			parameters.NotUsed_ListOrderCommissions = new List<PayRollspPrintUserCycleOrderCommissions_Result>();
		}
		parameters.NotUsed_ListUserCycleItemsInfo = new List<PayRollspPrintUserCycleItemValuesInfo_Result>();
		parameters.NotUsed_ListUserCycleItemsInfo = Enumerable.ToList<PayRollspPrintUserCycleItemValuesInfo_Result>((IEnumerable<PayRollspPrintUserCycleItemValuesInfo_Result>)_dbI.PayRollspPrintUserCycleItemValuesInfo(cycleId, lCID, result));
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.PrintPayRollUserCycleRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "PrintPayRollUserCycle.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\PayRoll_" + UserLogin.CurrentUser.UserId + "_" + cycleId + ".pdf";
			text4 = text4 + "\\PayRoll_" + UserLogin.CurrentUser.UserId + "_" + cycleId + ".pdf";
			string text7 = text5 + "\\PayRoll_Zip_" + UserLogin.CurrentUser.UserId + "_" + cycleId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\PayRoll_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0c56;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0c56;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0c56;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0c56;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0c56;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0c56;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0c56:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	public StiReport StockSupplyPrint(int stockSupplyId, string fileName, ref string filePdfPath, int imgResolution = 0, int pfCId = 0)
	{
		//IL_0d1f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d24: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d26: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d29: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d47: Expected I4, but got Unknown
		//IL_0d47: Unknown result type (might be due to invalid IL or missing references)
		//IL_0d4b: Invalid comparison between Unknown and I4
		//IL_099b: Unknown result type (might be due to invalid IL or missing references)
		//IL_09b9: Unknown result type (might be due to invalid IL or missing references)
		//IL_09c0: Expected O, but got Unknown
		//IL_09ea: Unknown result type (might be due to invalid IL or missing references)
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
		string text = base.Server.MapPath("~/Areas/Reports/ReportDatasets/");
		string text2 = base.Server.MapPath("~/Areas/Reports/ReportFiles/");
		CRM.Models.ReportModel.StockSupplyPrintRpt.Parameters parameters = new CRM.Models.ReportModel.StockSupplyPrintRpt.Parameters();
		CRMIdeal.Classes.Helper.Reports reports = new CRMIdeal.Classes.Helper.Reports();
		parameters.SysSetting = reports.GetSysSetting();
		int userId = UserLogin.CurrentUser.UserId;
		DateTime now = DateTime.Now;
		string rptDate = now.ToString("yyyy/MM/dd");
		string rptDay = DateTimeClass.DefineDayeOfWeekFaWithoutNull(now.DayOfWeek.ToString());
		byte[] coLoGo = SysSeting.Get().CoLoGo;
		if (coLoGo != null && coLoGo.Length != 0)
		{
			parameters.CoLogo = Convert.ToBase64String(coLoGo);
		}
		parameters.ReportDateTime = DateTime.Now;
		parameters.ReporterUserName = UserLogin.CurrentUser.FullName;
		List<WSspRpt_PrintStockSupply_Result> list = Enumerable.ToList<WSspRpt_PrintStockSupply_Result>((IEnumerable<WSspRpt_PrintStockSupply_Result>)_dbII.WSspRpt_PrintStockSupply(stockSupplyId, userId, rptDate, rptDay, lCID, result));
		foreach (WSspRpt_PrintStockSupply_Result item in list)
		{
			if (lCID != 1065)
			{
				if (!string.IsNullOrEmpty(item.stsupDate))
				{
					item.stsupDate = PersianDate.GetShamsi2Miladi(item.stsupDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.prsBirthDate))
				{
					item.prsBirthDate = PersianDate.GetShamsi2Miladi(item.prsBirthDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.prjStartDate))
				{
					item.prjStartDate = PersianDate.GetShamsi2Miladi(item.prjStartDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.stsupVerifiedRegisterDatePersian))
				{
					item.stsupVerifiedRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.stsupVerifiedRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.pordDate))
				{
					item.pordDate = PersianDate.GetShamsi2Miladi(item.pordDate.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.FirstRegisterDatePersian))
				{
					item.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
				if (!string.IsNullOrEmpty(item.RegisterDatePersian))
				{
					item.RegisterDatePersian = PersianDate.GetShamsi2Miladi(item.RegisterDatePersian.Replace("/", "")).Replace("/", "");
				}
			}
		}
		WSspRpt_PrintStockSupply_Result wSspRpt_PrintStockSupply_Result = Enumerable.FirstOrDefault<WSspRpt_PrintStockSupply_Result>((IEnumerable<WSspRpt_PrintStockSupply_Result>)list);
		if (wSspRpt_PrintStockSupply_Result == null)
		{
			wSspRpt_PrintStockSupply_Result = new WSspRpt_PrintStockSupply_Result();
		}
		parameters.ListStockSupply = list;
		parameters.ListBuyOrder = new List<WSspReturnBuyOrderFromStockSupply_Result>();
		List<WSspReturnBuyOrderFromStockSupply_Result> list2 = Enumerable.ToList<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)_dbII.WSspReturnBuyOrderFromStockSupply(stockSupplyId, lCID, result));
		if (list2 != null && Enumerable.Any<WSspReturnBuyOrderFromStockSupply_Result>((IEnumerable<WSspReturnBuyOrderFromStockSupply_Result>)list2))
		{
			foreach (WSspReturnBuyOrderFromStockSupply_Result item2 in list2)
			{
				if (lCID != 1065)
				{
					if (!string.IsNullOrEmpty(item2.bordDate))
					{
						item2.bordDate = PersianDate.GetShamsi2Miladi(item2.bordDate.Replace("/", "")).Replace("/", "");
					}
					if (!string.IsNullOrEmpty(item2.FirstRegisterDatePersian))
					{
						item2.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(item2.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
					}
				}
			}
		}
		parameters.ListDyPrintCmpForm = new List<CRMspDyPrintCmpForm_Result>();
		parameters.ListDyPrintPrsForm = new List<CRMspDyPrintPrsForm_Result>();
		parameters.ListDyPrintPrjForm = new List<CRMspDyPrintPrjForm_Result>();
		parameters.ListDyPrintStsupForm = new List<CRMspDyPrintStsupForm_Result>();
		parameters.ListPrintProjectInformationTree = new List<CRMspPrintProjectInformationTree_Result>();
		if (wSspRpt_PrintStockSupply_Result != null)
		{
			if (wSspRpt_PrintStockSupply_Result.stsupCompanyId.HasValue)
			{
				parameters.ListDyPrintCmpForm = Enumerable.ToList<CRMspDyPrintCmpForm_Result>((IEnumerable<CRMspDyPrintCmpForm_Result>)_db.CRMspDyPrintCmpForm(wSspRpt_PrintStockSupply_Result.stsupCompanyId, lCID, result, userId, result2));
			}
			if (wSspRpt_PrintStockSupply_Result.stsupCompanyPersonId.HasValue)
			{
				parameters.ListDyPrintPrsForm = Enumerable.ToList<CRMspDyPrintPrsForm_Result>((IEnumerable<CRMspDyPrintPrsForm_Result>)_db.CRMspDyPrintPrsForm(wSspRpt_PrintStockSupply_Result.stsupCompanyPersonId, lCID, result, userId, result2));
			}
			if (wSspRpt_PrintStockSupply_Result.stsupProjectId.HasValue)
			{
				parameters.ListDyPrintPrjForm = Enumerable.ToList<CRMspDyPrintPrjForm_Result>((IEnumerable<CRMspDyPrintPrjForm_Result>)_db.CRMspDyPrintPrjForm(wSspRpt_PrintStockSupply_Result.stsupProjectId, lCID, result, userId, result2));
				parameters.ListPrintProjectInformationTree = Enumerable.ToList<CRMspPrintProjectInformationTree_Result>((IEnumerable<CRMspPrintProjectInformationTree_Result>)_db.CRMspPrintProjectInformationTree(wSspRpt_PrintStockSupply_Result.stsupProjectId, lCID, result));
			}
			parameters.ListDyPrintStsupForm = Enumerable.ToList<CRMspDyPrintStsupForm_Result>((IEnumerable<CRMspDyPrintStsupForm_Result>)_dbII.CRMspDyPrintStsupForm(wSspRpt_PrintStockSupply_Result.StockSupplyId, lCID, result, userId, result2));
		}
		parameters.SignatureReferUser = null;
		parameters.SignatureFirstUser = null;
		parameters.SignatureLastEditUser = null;
		parameters.SignatureVerifierUser = null;
		CRMspSelectUserSignatureByUserId_Result cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintStockSupply_Result.stsupReferUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureReferUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintStockSupply_Result.FirstRegisterUserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureFirstUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintStockSupply_Result.UserId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureLastEditUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		cRMspSelectUserSignatureByUserId_Result = Enumerable.FirstOrDefault<CRMspSelectUserSignatureByUserId_Result>((IEnumerable<CRMspSelectUserSignatureByUserId_Result>)_dbI.CRMspSelectUserSignatureByUserId(wSspRpt_PrintStockSupply_Result.stsupVerifierId));
		if (cRMspSelectUserSignatureByUserId_Result != null && cRMspSelectUserSignatureByUserId_Result.Signature != null && cRMspSelectUserSignatureByUserId_Result.Signature.Length != 0)
		{
			parameters.SignatureVerifierUser = cRMspSelectUserSignatureByUserId_Result.Signature;
		}
		parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		if (wSspRpt_PrintStockSupply_Result != null && wSspRpt_PrintStockSupply_Result.stsupVerificationWorkFlowId.HasValue)
		{
			parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails = Enumerable.ToList<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)_dbI.WSspRpt_PrintVerificationRequestDetails(wSspRpt_PrintStockSupply_Result.StockSupplyId, 45, wSspRpt_PrintStockSupply_Result.stsupVerificationWorkFlowId, lCID, result));
			if (parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails != null && Enumerable.Any<WSspRpt_PrintVerificationRequestDetails_Result>((IEnumerable<WSspRpt_PrintVerificationRequestDetails_Result>)parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails))
			{
				foreach (WSspRpt_PrintVerificationRequestDetails_Result notUsed_ListPrintStockSupplyVerificationRequestDetail in parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails)
				{
					if (lCID != 1065)
					{
						if (!string.IsNullOrEmpty(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyDatePersian))
						{
							notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintStockSupplyVerificationRequestDetail.FirstRegisterDatePersian))
						{
							notUsed_ListPrintStockSupplyVerificationRequestDetail.FirstRegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintStockSupplyVerificationRequestDetail.FirstRegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintStockSupplyVerificationRequestDetail.RegisterDatePersian))
						{
							notUsed_ListPrintStockSupplyVerificationRequestDetail.RegisterDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintStockSupplyVerificationRequestDetail.RegisterDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqDatePersian))
						{
							notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqDatePersian.Replace("/", "")).Replace("/", "");
						}
						if (!string.IsNullOrEmpty(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqExpiredDatePersian))
						{
							notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqExpiredDatePersian = PersianDate.GetShamsi2Miladi(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerificationReqExpiredDatePersian.Replace("/", "")).Replace("/", "");
						}
					}
					if (notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyUserSignature != null)
					{
						notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyUserSignatureStr = Convert.ToBase64String(notUsed_ListPrintStockSupplyVerificationRequestDetail.VerifyUserSignature);
					}
				}
			}
		}
		if (parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails == null)
		{
			parameters.NotUsed_ListPrintStockSupplyVerificationRequestDetails = new List<WSspRpt_PrintVerificationRequestDetails_Result>();
		}
		parameters.NotUsed_ListStockSupplyItemPrdPicture = new List<WSspRpt_PrintStockSupplyItemPrdPicture_Result>();
		if (wSspRpt_PrintStockSupply_Result != null)
		{
			parameters.NotUsed_ListStockSupplyItemPrdPicture = Enumerable.ToList<WSspRpt_PrintStockSupplyItemPrdPicture_Result>((IEnumerable<WSspRpt_PrintStockSupplyItemPrdPicture_Result>)_dbII.WSspRpt_PrintStockSupplyItemPrdPicture(wSspRpt_PrintStockSupply_Result.StockSupplyId, lCID, result));
		}
		if (parameters.NotUsed_ListStockSupplyItemPrdPicture == null)
		{
			parameters.NotUsed_ListStockSupplyItemPrdPicture = new List<WSspRpt_PrintStockSupplyItemPrdPicture_Result>();
		}
		XmlSerializer val = new XmlSerializer(typeof(CRM.Models.ReportModel.StockSupplyPrintRpt.Parameters));
		StringWriter stringWriter = new StringWriter();
		XmlWriter val2 = XmlWriter.Create((TextWriter)stringWriter);
		val.Serialize(val2, (object)parameters);
		DataSet val3 = new DataSet();
		val3.ReadXmlSchema(text + "StockSupplyPrint.xsd");
		XElement val4 = XElement.Parse(stringWriter.ToString());
		val3.ReadXml(((XNode)val4).CreateReader((ReaderOptions)0));
		StiReport stiReport = new StiReport();
		if (pfCId != 0 && !string.IsNullOrWhiteSpace(text2))
		{
			if (!text2.EndsWith("/"))
			{
				text2 += "/";
			}
			text2 = text2 + pfCId + "/";
		}
		stiReport.Load(text2 + fileName);
		string text3 = "Integrated Security=False;Data Source={DBServer};Initial Catalog={DBName};Password={DBPass};User ID={DBUser}";
		text3 = text3.Replace("{DBServer}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBServer"]));
		text3 = text3.Replace("{DBName}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]));
		text3 = text3.Replace("{DBUser}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBUser"]));
		text3 = text3.Replace("{DBPass}", CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBPass"]));
		((CollectionBase)stiReport.Dictionary.Databases).Clear();
		stiReport.Dictionary.Databases.Add(new StiSqlDatabase("CRMIdealExtra", text3));
		stiReport.Compile();
		stiReport.RegData(val3);
		stiReport.Render();
		if (filePdfPath == "1")
		{
			string text4 = Configuration.HostTempFilesPath + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			string text5 = base.Server.MapPath(Configuration.HostTempFilesPath) + "\\Prints\\" + UserLogin.CurrentUser.UserId;
			StiJpegExportSettings stiJpegExportSettings = new StiJpegExportSettings
			{
				ImageResolution = ((imgResolution == 0) ? 300 : imgResolution)
			};
			int currentPage = Enumerable.Count<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
			string text6 = text5 + "\\Stsup_" + UserLogin.CurrentUser.UserId + "_" + stockSupplyId + ".pdf";
			text4 = text4 + "\\Stsup_" + UserLogin.CurrentUser.UserId + "_" + stockSupplyId + ".pdf";
			string text7 = text5 + "\\Stsup_Zip_" + UserLogin.CurrentUser.UserId + "_" + stockSupplyId;
			if (!System.IO.Directory.Exists(text7))
			{
				System.IO.Directory.CreateDirectory(text7);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text7);
			}
			string file = text7 + "\\Stsup_001.jpg";
			stiJpegExportSettings.PageRange = new StiPagesRange(currentPage);
			stiReport.ExportDocument(StiExportFormat.ImageJpeg, file, stiJpegExportSettings);
			string[] files = System.IO.Directory.GetFiles(text7);
			if (Enumerable.Any<string>((IEnumerable<string>)files))
			{
				PdfDocument pdfDocument = new PdfDocument();
				for (int i = 0; i < files.Length; i++)
				{
					PdfPage pdfPage = new PdfPage();
					StiPage stiPage = Enumerable.FirstOrDefault<StiPage>((IEnumerable<StiPage>)stiReport.RenderedPages.Items);
					if (stiPage != null)
					{
						if (stiPage.Orientation == StiPageOrientation.Landscape)
						{
							pdfPage.Orientation = PageOrientation.Landscape;
						}
						try
						{
							PaperKind paperSize = stiPage.PaperSize;
							switch (paperSize - 8)
							{
							default:
								if ((int)paperSize != 66)
								{
									break;
								}
								pdfPage.Size = PageSize.A2;
								goto end_IL_0d1d;
							case 0:
								pdfPage.Size = PageSize.A3;
								goto end_IL_0d1d;
							case 1:
								pdfPage.Size = PageSize.A4;
								goto end_IL_0d1d;
							case 3:
								pdfPage.Size = PageSize.A5;
								goto end_IL_0d1d;
							case 4:
								pdfPage.Size = PageSize.B4;
								goto end_IL_0d1d;
							case 5:
								pdfPage.Size = PageSize.B5;
								goto end_IL_0d1d;
							case 2:
								break;
							}
							pdfPage.Size = PageSize.A4;
							end_IL_0d1d:;
						}
						catch (Exception e)
						{
							ErrorSignal.FromCurrentContext().Raise(e);
							pdfPage.Size = PageSize.A4;
						}
					}
					pdfDocument.Pages.Add(pdfPage);
					XGraphics xGraphics = XGraphics.FromPdfPage(pdfDocument.Pages[i]);
					XImage xImage = XImage.FromFile(files[i]);
					xGraphics.DrawImage(xImage, 0.0, 0.0);
					xImage.Dispose();
					xGraphics.Dispose();
				}
				pdfDocument.Save(text6);
				pdfDocument.Close();
			}
			try
			{
				DirectoryInfo directoryInfo = new DirectoryInfo(text7);
				FileInfo[] files2 = directoryInfo.GetFiles();
				for (int j = 0; j < files2.Length; j++)
				{
					files2[j].Delete();
				}
				DirectoryInfo[] directories = directoryInfo.GetDirectories();
				for (int j = 0; j < directories.Length; j++)
				{
					directories[j].Delete(recursive: true);
				}
				if (System.IO.Directory.Exists(text7))
				{
					System.IO.Directory.Delete(text7);
				}
			}
			catch (Exception e2)
			{
				ErrorSignal.FromCurrentContext().Raise(e2);
			}
			if (!System.IO.File.Exists(text6))
			{
				text6 = "";
			}
			filePdfPath = text6;
		}
		return stiReport;
	}

	[HttpPost]
	public async Task<JsonResult> UploadFile(string fileName, int pfCId = 0)
	{
		try
		{
			foreach (string item in (NameObjectCollectionBase)base.Request.Files)
			{
				HttpPostedFileBase val = base.Request.Files[item];
				if (val != null && val.ContentLength > 0)
				{
					Stream inputStream = val.InputStream;
					string text2 = "";
					if (pfCId != 0)
					{
						text2 = "/" + pfCId;
					}
					string path = Path.Combine(base.Server.MapPath("~/Areas/Reports/ReportFiles" + text2), fileName);
					CRM.General.IO.Directory.SetFullControlForEveryOne(base.Server.MapPath("~/Areas/Reports/ReportFiles" + text2));
					FileAttributes attributes = System.IO.File.GetAttributes(path);
					if ((attributes & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
					{
						attributes &= ~FileAttributes.ReadOnly;
						System.IO.File.SetAttributes(path, attributes);
					}
					using (FileStream fileStream = System.IO.File.OpenWrite(path))
					{
						inputStream.CopyTo(fileStream);
						fileStream.Close();
					}
					inputStream.Close();
				}
			}
		}
		catch (Exception ex)
		{
			ErrorSignal.FromCurrentContext().Raise(ex);
			base.Response.StatusCode = 400;
			return Json(Messages.ReportSendFileFailed + "\r\n" + ex.Message);
		}
		return Json(Messages.ReportSendFileSuccessfully);
	}

	public string DefineDayeOfWeekFa(string day)
	{
		return day switch
		{
			"Saturday" => Labels.Saturday, 
			"Sunday" => Labels.Sunday, 
			"Monday" => Labels.Monday, 
			"Tuesday" => Labels.Tuesday, 
			"Wednesday" => Labels.Wednesday, 
			"Thursday" => Labels.Thursday, 
			"Friday" => Labels.Friday, 
			_ => day, 
		};
	}

	public string GetPdfPath(int id, string fileName, string type, int? idI = 0, int? idII = 0, string cmpRemainAccLink = "", int imgResolution = 0, int pfCId = 0, string cmpRemainAccLinkjs = "")
	{
		new StiReport();
		string filePdfPath = "Not file";
		try
		{
			if (imgResolution == 0)
			{
				imgResolution = 300;
			}
			if (id > 0)
			{
				filePdfPath = "1";
				switch (type)
				{
				case "preOrder":
					PreOrderPrint(id, fileName, ref filePdfPath, cmpRemainAccLink, imgResolution, pfCId, cmpRemainAccLinkjs);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 1, 3);
					}
					break;
				case "order":
					OrderPrint(id, fileName, ref filePdfPath, cmpRemainAccLink, imgResolution, pfCId, cmpRemainAccLinkjs);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 2, 3);
					}
					break;
				case "buyorder":
					BuyOrderPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 5, 3);
					}
					break;
				case "doc":
					DocPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 11, 3);
					}
					break;
				case "draft":
					DraftPrint(id, fileName, ref filePdfPath, imgResolution, pfCId, cmpRemainAccLink, cmpRemainAccLinkjs);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 12, 3);
					}
					break;
				case "wrhsmovement":
					WarehouseMovementPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 87, 3);
					}
					break;
				case "sendletter":
					SendLetterPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 6, 3);
					}
					break;
				case "dyForm":
				{
					int valueOrDefault = idI.GetValueOrDefault();
					int valueOrDefault2 = idII.GetValueOrDefault();
					DyFormPrint(id, fileName, ref filePdfPath, valueOrDefault, valueOrDefault2, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 505, 3);
					}
					break;
				}
				case "payrollUserCycle":
					PayRollUserCyclePrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					break;
				case "hourlyLeave":
					HourlyLeavePrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					break;
				case "dailyLeave":
					DailyLeavePrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					break;
				case "hourlyMission":
					HourlyMissionPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					break;
				case "dailyMission":
					DailyMissionPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					break;
				case "stockSupply":
					StockSupplyPrint(id, fileName, ref filePdfPath, imgResolution, pfCId);
					if (id != 0 && !string.IsNullOrWhiteSpace(filePdfPath))
					{
						PrintLog.InsertPrintLog(id, 82, 3);
					}
					break;
				default:
					filePdfPath = "Not file";
					break;
				}
			}
			else
			{
				filePdfPath = "Not file";
			}
			if (string.IsNullOrWhiteSpace(filePdfPath))
			{
				filePdfPath = "Not file";
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return filePdfPath;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		_dbI.Dispose();
		_dbII.Dispose();
		base.Dispose(disposing);
	}
}
