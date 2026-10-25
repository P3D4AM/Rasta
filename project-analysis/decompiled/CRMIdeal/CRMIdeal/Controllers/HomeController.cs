using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Web.Mvc;
using CRM.General.IO;
using CRM.General.IO.FTP;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using CRMIdeal.Classes.Common;
using CRMIdeal.Classes.Helper;
using CRMIdeal.GSD.Globalization;
using Elmah;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Newtonsoft.Json;

namespace CRMIdeal.Controllers;

public class HomeController : Controller
{
	private CRMSpEntities db = new CRMSpEntities();

	public ActionResult Index(string dt = "", string jwt = "")
	{
		return RedirectToAction("HomePage", "Cartables", (object)new
		{
			area = "Cartables"
		});
	}

	public ActionResult Chat()
	{
		base.ViewBag.CurrentUsername = 3;
		return View();
	}

	public ActionResult Test()
	{
		if (base.HttpContext.Application["OnlineUsers"] == null)
		{
			base.ViewBag.cnt = 0;
		}
		else
		{
			string text = base.HttpContext.Application["OnlineUsers"].ToString();
			base.ViewBag.cnt = text;
		}
		return View();
	}

	public ActionResult Grid()
	{
		base.ViewBag.prList = "";
		base.ViewBag.rptList = "";
		return View();
	}

	public ActionResult CrmCompanyList_Read([DataSourceRequest] DataSourceRequest request, string prList, string rptList)
	{
		int num = 3;
		if (UserLogin.CurrentUser != null)
		{
			num = UserLogin.CurrentUser.UserId;
		}
		List<mct_CrmCompany_Result> enumerable = new List<mct_CrmCompany_Result>();
		int result = 0;
		if (UserLogin.CurrentUser != null)
		{
			int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result);
		}
		if (string.IsNullOrEmpty(rptList))
		{
			if (prList == null)
			{
				enumerable = Enumerable.ToList<mct_CrmCompany_Result>((IEnumerable<mct_CrmCompany_Result>)db.mfi_CRMspLoadCompany(0, num, "", "", num, "CompanyID", "", "", null, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, result));
			}
			else
			{
				string[] array = prList.Split(new char[1] { '|' });
				int value = int.Parse(array[0]);
				string mode = array[1];
				string text = array[2];
				if (text != "")
				{
					text = text.Substring(0, 4) + text.Substring(5, 2) + text.Substring(8, 2);
				}
				int value2 = num;
				if (array[3] != null && array[3] != "")
				{
					value2 = int.Parse(array[3]);
				}
				if (array[4] != "")
				{
					array[4].Replace('-', ' ');
				}
				string tmpVal = array[5];
				enumerable = Enumerable.ToList<mct_CrmCompany_Result>((IEnumerable<mct_CrmCompany_Result>)db.mfi_CRMspLoadCompany(value, num, mode, text, value2, "", tmpVal, "", null, Thread.CurrentThread.CurrentCulture.LCID, SysSeting.Get().DefaultLanguageID, result));
			}
		}
		return Json(((IEnumerable)enumerable).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	[DynamicAuthorize(ControllerName = "frmMain", ActionName = "actBackUp")]
	public JsonResult CreateBackup()
	{
		string data = "";
		string message = "";
		CommonResultStatusViewModel status = CommonResultStatusViewModel.Success;
		CommonResultViewModel<string> data2;
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			string text = DateTime.Now.ToString("yyyyMMdd-HHmmss", new PersianCulture());
			if (!UserLogin.IsUserAccess("frmMain", "actBackUp", UserLogin.CurrentUser))
			{
				data = "";
				message = Messages.ErrorNotAccess;
				status = CommonResultStatusViewModel.Error;
				data2 = new CommonResultViewModel<string>
				{
					Data = data,
					Message = message,
					Status = status
				};
				return Json(data2, JsonRequestBehavior.AllowGet);
			}
			string text2 = base.Server.MapPath("/BackUp/" + text);
			if (!System.IO.Directory.Exists(text2))
			{
				System.IO.Directory.CreateDirectory(text2);
				CRM.General.IO.Directory.SetFullControlForEveryOne(text2);
			}
			new FacadeFTP(Configuration.FacadeFtp);
			_ = Configuration.PathFtp;
			_ = Configuration.UserNameFtp;
			_ = Configuration.PasswordFtp;
			_ = Configuration.UsePassiveFtp;
			string text3 = text2 + "\\BCKCRM-" + text + ".bak";
			string dbName = CodeDecode.DeCodding(ConfigurationManager.AppSettings["DBName"]);
			mct_CRMspCreateBackupFromDb_Result mct_CRMspCreateBackupFromDb_Result = Enumerable.FirstOrDefault<mct_CRMspCreateBackupFromDb_Result>((IEnumerable<mct_CRMspCreateBackupFromDb_Result>)db.CRMspCreateBackupFromDb(dbName, text3));
			if (mct_CRMspCreateBackupFromDb_Result != null)
			{
				if (mct_CRMspCreateBackupFromDb_Result.Result.GetValueOrDefault() == 1)
				{
					data = text3;
					message = Messages.msgSuccessAction;
					status = CommonResultStatusViewModel.Success;
				}
				else
				{
					data = "";
					message = Messages.msgErrorRunFunction;
					status = CommonResultStatusViewModel.Error;
					if (!string.IsNullOrWhiteSpace(mct_CRMspCreateBackupFromDb_Result.Message))
					{
						Exception e = new Exception(Messages.msgErrorRunFunction + " - " + mct_CRMspCreateBackupFromDb_Result.Message);
						ErrorSignal.FromCurrentContext().Raise(e);
					}
				}
			}
		}
		catch (Exception e2)
		{
			ErrorSignal.FromCurrentContext().Raise(e2);
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

	public ActionResult AddNewViewToNewSolution()
	{
		return View();
	}

	public ActionResult ShowMessage(string message = "", string type = "")
	{
		if (string.IsNullOrWhiteSpace(message))
		{
			message = (string)base.TempData["Message"];
		}
		if (string.IsNullOrWhiteSpace(type))
		{
			type = (string)base.TempData["Type"];
		}
		base.ViewBag.Message = message;
		base.ViewBag.Type = type;
		return View();
	}

	public ActionResult cmp1()
	{
		return View();
	}

	public ActionResult cmp2()
	{
		return View();
	}

	public ActionResult cmp3()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		string text = "<br>";
		text = base.Request.UserHostAddress;
		ManagementObjectEnumerator enumerator = new ManagementClass("Win32_NetworkAdapterConfiguration").GetInstances().GetEnumerator();
		try
		{
			while (enumerator.MoveNext())
			{
				ManagementBaseObject current = enumerator.Current;
				if ((bool)current["IPEnabled"])
				{
					text = text + current["MacAddress"].ToString() + "<br>";
				}
				current.Dispose();
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		base.ViewBag.mac = text;
		return View();
	}

	[LoginAuthorize]
	public ActionResult nComponentSamples()
	{
		base.ViewBag.Centers = JsonConvert.SerializeObject(Center.Get());
		return View();
	}

	protected override void Dispose(bool disposing)
	{
		db.Dispose();
		base.Dispose(disposing);
	}
}
