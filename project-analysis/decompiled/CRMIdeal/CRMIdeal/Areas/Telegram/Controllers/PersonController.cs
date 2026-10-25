using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRM.Resources;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.Telegram.Controllers;

public class PersonController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMTabelEntities _dbTbl = new CRMTabelEntities();

	[LoginAuthorize]
	public ActionResult Index(int position = 0, int cmpId = 0, int prsId = 0, int oprId = 0, string prsMobile = "")
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		_ = Thread.CurrentThread.CurrentCulture.LCID;
		string text = "";
		string text2 = "";
		string text3 = "";
		switch (position)
		{
		case 0:
			text = "frmCompanyI";
			text2 = "actGoToTelegram";
			text3 = "CMP";
			break;
		case 1:
			text = "frmPreOrder";
			text2 = "actGoToTelegram";
			text3 = "PORD";
			break;
		case 2:
			text = "frmOrder";
			text2 = "actGoToTelegram";
			text3 = "ORD";
			break;
		case 3:
			text = "frmBuyOrder";
			text2 = "actGoToTelegram";
			text3 = "BORD";
			break;
		case 4:
			text = "frmPreOrder";
			text2 = "actSendToTelegram";
			text3 = "PORD";
			break;
		case 5:
			text = "frmOrder";
			text2 = "actSendToTelegram";
			text3 = "ORD";
			break;
		case 6:
			text = "frmBuyOrder";
			text2 = "actSendToTelegram";
			text3 = "BORD";
			break;
		case 7:
			text = "frmMain";
			text2 = "actcTelegram";
			text3 = "";
			break;
		default:
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		if (!UserLogin.IsUserAccess(text, text2, UserLogin.CurrentUser))
		{
			return RedirectToAction("Login", "Account", (object)new
			{
				area = "",
				d = DateTime.Now
			});
		}
		base.ViewBag.CmpId = cmpId;
		base.ViewBag.PrsId = prsId;
		base.ViewBag.OprName = text3;
		base.ViewBag.OprId = oprId;
		base.ViewBag.PrsMobile = prsMobile;
		GetTelegSetting();
		try
		{
			dynamic viewBag = base.ViewBag;
			DbSet<CrmFilesDirectory> crmFilesDirectory = _dbTbl.CrmFilesDirectory;
			ParameterExpression val = Expression.Parameter(typeof(CrmFilesDirectory), "c");
			viewBag.CntFileId = Queryable.Any<CrmFilesDirectory>((IQueryable<CrmFilesDirectory>)crmFilesDirectory, Expression.Lambda<Func<CrmFilesDirectory, bool>>((Expression)(object)Expression.GreaterThan((Expression)(object)Expression.Property((Expression)(object)val, (MethodInfo)MethodBase.GetMethodFromHandle((RuntimeMethodHandle)/*OpCode not supported: LdMemberToken*/)), (Expression)(object)Expression.Constant((object)10, typeof(int))), (ParameterExpression[])(object)new ParameterExpression[1] { val }));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return View();
	}

	public List<CRMspSelectTelegSetting_Result> GetTelegSettingList()
	{
		List<CRMspSelectTelegSetting_Result> result = new List<CRMspSelectTelegSetting_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result2);
			if (result2 <= 0)
			{
				result2 = 1065;
			}
			_ = Thread.CurrentThread.CurrentCulture.LCID;
			result = Enumerable.ToList<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)TelegramSeting.Get());
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return result;
	}

	[AjaxOnly]
	public JsonResult GetTelegSettingSelectListItem(int selectedId = 0)
	{
		List<SelectListItem> list = new List<SelectListItem>();
		try
		{
			List<CRMspSelectTelegSetting_Result> telegSettingList = GetTelegSettingList();
			list.AddRange(Enumerable.Select<CRMspSelectTelegSetting_Result, SelectListItem>((IEnumerable<CRMspSelectTelegSetting_Result>)telegSettingList, (Func<CRMspSelectTelegSetting_Result, SelectListItem>)((CRMspSelectTelegSetting_Result item) => new SelectListItem
			{
				Text = item.AppTitle,
				Value = item.TelegSettingId.ToString(),
				Selected = (selectedId == item.TelegSettingId)
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TeleSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetTelegContact(int telegContactId, int settingId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		CurrentTelegContactViewModel currentTelegContactViewModel = new CurrentTelegContactViewModel();
		currentTelegContactViewModel.TelegContact = new CRMspSelectTelegContact_Result();
		try
		{
			CRMspSelectTelegContact_Result cRMspSelectTelegContact_Result = Enumerable.FirstOrDefault<CRMspSelectTelegContact_Result>((IEnumerable<CRMspSelectTelegContact_Result>)_dbI.CRMspSelectTelegContact(telegContactId, null, languageID: lCID, defaultLanguageID: result, settingId: settingId, userId: UserLogin.CurrentUser.UserId));
			if (cRMspSelectTelegContact_Result != null)
			{
				currentTelegContactViewModel.IsFind = true;
				currentTelegContactViewModel.Message = "";
				currentTelegContactViewModel.TelegContactCurrentId = cRMspSelectTelegContact_Result.TelegContactId;
				currentTelegContactViewModel.TelegContact = cRMspSelectTelegContact_Result;
			}
			else
			{
				currentTelegContactViewModel.IsFind = false;
				currentTelegContactViewModel.Message = Messages.ErrorNotFound;
				currentTelegContactViewModel.TelegContact = null;
				currentTelegContactViewModel.TelegContactCurrentId = -1;
			}
		}
		catch (DbEntityValidationException ex)
		{
			ErrorSignal.FromCurrentContext().Raise((Exception)(object)ex);
			currentTelegContactViewModel.IsFind = false;
			currentTelegContactViewModel.Message = Messages.frmErrorMessage + "<br />" + ((Exception)(object)ex).Message;
		}
		catch (Exception ex2)
		{
			ErrorSignal.FromCurrentContext().Raise(ex2);
			currentTelegContactViewModel.IsFind = false;
			currentTelegContactViewModel.Message = Messages.frmErrorMessage + "<br />" + ex2.Message;
		}
		JsonResult jsonResult = Json(currentTelegContactViewModel, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	[AjaxOnly]
	public JsonResult GetTelegSetting()
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
			List<CRMspSelectTelegSetting_Result> list2 = Enumerable.ToList<CRMspSelectTelegSetting_Result>((IEnumerable<CRMspSelectTelegSetting_Result>)TelegramSeting.Get());
			list.AddRange(Enumerable.Select<CRMspSelectTelegSetting_Result, SelectListItem>((IEnumerable<CRMspSelectTelegSetting_Result>)list2, (Func<CRMspSelectTelegSetting_Result, SelectListItem>)((CRMspSelectTelegSetting_Result item) => new SelectListItem
			{
				Text = item.AppTitle,
				Value = item.TelegSettingId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.TeleSettingList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbTbl.Dispose();
		base.Dispose(disposing);
	}
}
