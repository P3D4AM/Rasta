using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web.Mvc;
using CRM.General.Security;
using CRM.Models;
using CRMIdeal.Cache.Setting;
using CRMIdeal.Classes;
using Elmah;

namespace CRMIdeal.Areas.FormBase.Controllers;

public class SelectProductsMultiController : Controller
{
	private readonly CRMSpEntities _db = new CRMSpEntities();

	private readonly CRMSpIEntities _dbI = new CRMSpIEntities();

	private readonly CRMSpIIIEntities _dbIII = new CRMSpIIIEntities();

	public ActionResult Index(int criterionId = 1, string resultInputId = "")
	{
		base.ViewBag.CriterionId = criterionId;
		base.ViewBag.ResultInputId = resultInputId;
		return View();
	}

	[HttpPost]
	public ActionResult GetRecords(int criterionId = 1, int userId = 0, int pageNumber = 1, int pageSize = 30, string searchKeyword = "", int? productFirstGroupId = 0, int? productSecondGroupId = 0)
	{
		int.TryParse(SysSeting.Get().DefaultLanguageID.ToString(), out var result);
		if (result <= 0)
		{
			result = 1065;
		}
		int lCID = Thread.CurrentThread.CurrentCulture.LCID;
		List<SelectListItem> list = new List<SelectListItem>();
		int totalCount = 0;
		try
		{
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			if (userId == 0)
			{
				userId = UserLogin.CurrentUser.UserId;
			}
			switch (criterionId)
			{
			case 1:
			{
				List<WSspSelectProductFirstGroupWithPaging_Result> list3 = Enumerable.ToList<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)_dbIII.WSspSelectProductFirstGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword));
				list.AddRange(Enumerable.Select<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list3, (Func<WSspSelectProductFirstGroupWithPaging_Result, SelectListItem>)((WSspSelectProductFirstGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.FGName,
					Value = item.PrdFirstGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list3) ? Enumerable.FirstOrDefault<WSspSelectProductFirstGroupWithPaging_Result>((IEnumerable<WSspSelectProductFirstGroupWithPaging_Result>)list3).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 2:
			{
				List<WSspSelectProductSecondGroupWithPaging_Result> list4 = Enumerable.ToList<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)_dbIII.WSspSelectProductSecondGroupWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list4, (Func<WSspSelectProductSecondGroupWithPaging_Result, SelectListItem>)((WSspSelectProductSecondGroupWithPaging_Result item) => new SelectListItem
				{
					Text = item.SGName,
					Value = item.PrdSecondGroupID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list4) ? Enumerable.FirstOrDefault<WSspSelectProductSecondGroupWithPaging_Result>((IEnumerable<WSspSelectProductSecondGroupWithPaging_Result>)list4).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			case 3:
			{
				List<WSspSelectProductWithPaging_Result> list2 = Enumerable.ToList<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)_dbIII.WSspSelectProductWithPaging(pageNumber, pageSize, lCID, result, searchKeyword, productFirstGroupId, productSecondGroupId));
				list.AddRange(Enumerable.Select<WSspSelectProductWithPaging_Result, SelectListItem>((IEnumerable<WSspSelectProductWithPaging_Result>)list2, (Func<WSspSelectProductWithPaging_Result, SelectListItem>)((WSspSelectProductWithPaging_Result item) => new SelectListItem
				{
					Text = item.PrdName,
					Value = item.ProductID.ToString(),
					Selected = false
				})));
				totalCount = (Enumerable.Any<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list2) ? Enumerable.FirstOrDefault<WSspSelectProductWithPaging_Result>((IEnumerable<WSspSelectProductWithPaging_Result>)list2).TotalCount.GetValueOrDefault() : 0);
				break;
			}
			}
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(new
		{
			Data = list,
			TotalCount = totalCount
		}, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetProductFirstGroups()
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			_ = UserLogin.CurrentUser.UserId;
			List<WSspSelectProductFirstGroup_Result> list2 = Enumerable.ToList<WSspSelectProductFirstGroup_Result>((IEnumerable<WSspSelectProductFirstGroup_Result>)_db.WSspSelectProductFirstGroup(lCID, result));
			list.AddRange(Enumerable.Select<WSspSelectProductFirstGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductFirstGroup_Result>)list2, (Func<WSspSelectProductFirstGroup_Result, SelectListItem>)((WSspSelectProductFirstGroup_Result item) => new SelectListItem
			{
				Text = item.FGName,
				Value = item.PrdFirstGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	[HttpPost]
	[AjaxOnly]
	public ActionResult GetProductSecondGroups(int? productFirstGroupId = 0)
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
			int result2 = 0;
			if (UserLogin.CurrentUser != null)
			{
				int.TryParse(UserLogin.CurrentUser.UserLastCId.ToString(), out result2);
			}
			_ = UserLogin.CurrentUser.UserId;
			CRMSpEntities db = _db;
			int? languageID = lCID;
			int? defaultLanguageID = result;
			List<WSspSelectProductSecondGroup_Result> list2 = Enumerable.ToList<WSspSelectProductSecondGroup_Result>((IEnumerable<WSspSelectProductSecondGroup_Result>)db.WSspSelectProductSecondGroup(productFirstGroupId, languageID, defaultLanguageID));
			list.AddRange(Enumerable.Select<WSspSelectProductSecondGroup_Result, SelectListItem>((IEnumerable<WSspSelectProductSecondGroup_Result>)list2, (Func<WSspSelectProductSecondGroup_Result, SelectListItem>)((WSspSelectProductSecondGroup_Result item) => new SelectListItem
			{
				Text = item.SGName,
				Value = item.PrdSecondGroupID.ToString(),
				Selected = false
			})));
		}
		catch (Exception e)
		{
			ErrorSignal.FromCurrentContext().Raise(e);
		}
		return Json(list, JsonRequestBehavior.AllowGet);
	}

	protected override void Dispose(bool disposing)
	{
		_db.Dispose();
		_dbI.Dispose();
		_dbIII.Dispose();
		base.Dispose(disposing);
	}
}
