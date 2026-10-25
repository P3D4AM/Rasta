using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Calendar;
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

namespace CRMIdeal.Areas.Cartables.Controllers;

public class SelectKnowledgeTankController : Controller
{
	private CRMSpEntities _db = new CRMSpEntities();

	private CRMSpIEntities _dbI = new CRMSpIEntities();

	[LoginAuthorize]
	public ActionResult Index(int knowledgeTankId, string frameName = "", string formName = "", bool isShowSearch = true, string itemName = "")
	{
		base.ViewBag.SelectedknowledgeTankId = knowledgeTankId;
		base.ViewBag.FrameName = frameName;
		base.ViewBag.FormName = formName;
		base.ViewBag.IsShowSearch = isShowSearch;
		base.ViewBag.ItemName = itemName;
		GetKnowledgeTankGroup();
		return View();
	}

	[AjaxOnly]
	public JsonResult GetKnowledgeTankGroup()
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
			List<CRMspknlgSelectKnowledgeTankGroup_Result> list2 = Enumerable.ToList<CRMspknlgSelectKnowledgeTankGroup_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)_db.CRMspknlgSelectKnowledgeTankGroup(UserLogin.CurrentUser.RollId, lCID, result));
			list.AddRange(Enumerable.Select<CRMspknlgSelectKnowledgeTankGroup_Result, SelectListItem>((IEnumerable<CRMspknlgSelectKnowledgeTankGroup_Result>)list2, (Func<CRMspknlgSelectKnowledgeTankGroup_Result, SelectListItem>)((CRMspknlgSelectKnowledgeTankGroup_Result item) => new SelectListItem
			{
				Text = item.KnowledgeTankGroupTitle,
				Value = item.KnowledgeTankGroupId.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		base.ViewBag.KnowledgeTankGrouptList = list;
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult KnlgSearch(string txtSearch, int mode)
	{
		List<CRMspKnlgSearch_Result> data = new List<CRMspKnlgSearch_Result>();
		try
		{
			data = GetKnlgSearchList(txtSearch, mode);
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(data, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	public List<CRMspKnlgSearch_Result> GetKnlgSearchList(string txtSearch, int mode)
	{
		List<CRMspKnlgSearch_Result> list = new List<CRMspKnlgSearch_Result>();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			int? rollId = UserLogin.CurrentUser.RollId;
			list = Enumerable.ToList<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)_db.CRMspKnlgSearch(txtSearch, rollId, mode, lCID, result));
			if (list != null && Enumerable.Any<CRMspKnlgSearch_Result>((IEnumerable<CRMspKnlgSearch_Result>)list))
			{
				foreach (CRMspKnlgSearch_Result item in list)
				{
					_ = item.FirstRegisterDate;
					item.FirstRegisterDatePersian = item.FirstRegisterDate.ToString("yyyyMMdd");
					_ = item.RegisterDate;
					item.RegisterDatePersian = item.RegisterDate.ToString("yyyyMMdd");
				}
			}
			else
			{
				list = new List<CRMspKnlgSearch_Result>();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return list;
	}

	[AjaxOnly]
	public ActionResult KnowledgeTankFilse_Read([DataSourceRequest] DataSourceRequest request, int knowledgeTankId)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<CRMspSelectFilesDirectory_Result> list = new List<CRMspSelectFilesDirectory_Result>();
		try
		{
			if (knowledgeTankId != 0)
			{
				list = Files.SelectFilesDirectory("0", "0", "0", "40", knowledgeTankId.ToString(), "0", "0", false);
				if (list != null && Enumerable.Any<CRMspSelectFilesDirectory_Result>((IEnumerable<CRMspSelectFilesDirectory_Result>)list))
				{
					foreach (CRMspSelectFilesDirectory_Result item in list)
					{
						if (item.DocDateTime.HasValue)
						{
							DateTime.TryParse(item.DocDateTime.ToString(), out var result2);
							item.DocDate = result2.ToString("yyyy/MM/dd");
						}
						else if (!string.IsNullOrEmpty(item.DocDate))
						{
							if (lCID != 1065)
							{
								item.DocDate = DateTime.ParseExact(PersianDate.GetFormatetdDate(item.DocDate.Replace("/", "")), "yyyy/MM/dd", new PersianCulture()).ToString("yyyy/MM/dd");
							}
							else
							{
								item.DocDate = PersianDate.GetFormatetdDate(item.DocDate.Replace("/", ""));
							}
						}
						if (string.IsNullOrEmpty(item.AppType))
						{
							item.AppType = Configuration.AppType;
						}
						item.AppType = Configuration.GetAppType(item.AppType);
						string text = item.FirstRegisterUser ?? "";
						string text2 = (item.FirstRegisterDate.HasValue ? item.FirstRegisterDate.Value.ToString("yyyy/MM/dd HH:mm:ss") : "");
						item.FirstRegisterUser = Labels.frmFirstRegisterUser + ": " + text + " (" + text2 + ")";
						string text3 = item.EditUser ?? "";
						_ = item.RegisterDate;
						string text4 = item.RegisterDate.ToString("yyyy/MM/dd HH:mm:ss");
						item.EditUser = Labels.frmRegisterUser + ": " + text3 + " (" + Labels.AppType + ":" + item.AppType + ")  (" + text4 + ")";
					}
				}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(((IEnumerable)list).ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
	}

	[AjaxOnly]
	public JsonResult GetKnowledgeTankInfo(int knowledgeTankId)
	{
		CRMspknlgSelectKnowledgeTankById_Result cRMspknlgSelectKnowledgeTankById_Result = new CRMspknlgSelectKnowledgeTankById_Result();
		try
		{
			int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
			if (result <= 0)
			{
				result = 1065;
			}
			int lCID = Thread.CurrentThread.CurrentCulture.LCID;
			cRMspknlgSelectKnowledgeTankById_Result = Enumerable.FirstOrDefault<CRMspknlgSelectKnowledgeTankById_Result>((IEnumerable<CRMspknlgSelectKnowledgeTankById_Result>)_dbI.CRMspknlgSelectKnowledgeTankById(knowledgeTankId, lCID, result));
			if (cRMspknlgSelectKnowledgeTankById_Result == null)
			{
				cRMspknlgSelectKnowledgeTankById_Result = new CRMspknlgSelectKnowledgeTankById_Result();
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		JsonResult jsonResult = Json(cRMspknlgSelectKnowledgeTankById_Result, JsonRequestBehavior.AllowGet);
		jsonResult.MaxJsonLength = int.MaxValue;
		return jsonResult;
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		base.Dispose(disposing);
	}
}
